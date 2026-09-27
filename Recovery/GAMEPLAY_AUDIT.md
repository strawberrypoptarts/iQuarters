# iQuarters gameplay audit — recovery 0.4.0

## Evidence and limits

The supplied C# scripts are reconstructions, not an exact source release. Their field declarations match the serialized records, but important method bodies differ from the original executable. The managed DLL's methods contain `ret`; the actual gameplay implementation survives in the executable's ARMv7 Mono AOT section.

`tools/native_aot.py` maps the original Mach-O segments and AOT globals. `tools/IlInspect` reads preserved MethodDef names/tokens. `tools/annotate_aot.py` resolves native PLT calls and writes annotated disassemblies in `native/`. The mapping follows the original [Mono 2.6 AOT runtime](https://github.com/mono/mono/blob/mono-2-6/mono/mini/aot-runtime.c), including `decode_value`, `decode_method_ref`, and MethodDef row-to-code offsets. This is static analysis, not execution of the original game.

The original IPA and supplied scripts are preserved. The rebuilt application contains C# game logic and native Apple rendering; it does not include the old executable or a Unity runtime.

## Corrections established from native code

### Flick: QuarterTrigger.FixedUpdate, 0x25685c–0x256cec

The executable sums touch deltas. It uses **upward Y**, not vector magnitude. The fields' misleading names contributed to the earlier reconstruction error.

| ARM instance offset | Preserved field | Saved value | Native use |
|---|---|---:|---|
| 996 | debugFlickPower | 0.1 | Flick power exponent |
| 1000 | touchYScale | 0.02 | Upward-delta scale |
| 1004 | debugTargetRange | 1.8 | Flick power divisor |
| 1008 | magThreshFlick | 0.9 | Flick firing threshold |
| 1012 | shotPowerPower | 0.9 | Shake exponent |
| 1020 | debugTargetRangeShake | 1.975 | Shake divisor |
| 1024 | magThresh | 0.8 | Shake firing threshold |

For positive upward delta `y`, the original flick is:

```text
y = min(y, 360)
power = pow(y * 0.02 / 1.8, 0.1)
aim = 4 * deltaX / y
fire when power > 0.9
```

At delta `(12,40)`, power is about `0.9221` and aim is `1.2`. At `(0,360)`, power is about `1.1487`. Horizontal motion does not increase power. The prior guessed 0.7 threshold, 0.9 exponent, length-based power, normalized-vector aim and ±2 flick aim clamp are removed. One shot per contact and rejection of touches begun on UI controls remain host safeguards.

At version 0.4, the adapter used UIKit points without 320/width scaling. Version 0.7 normalizes to 320/current-width so the same fractional-screen gesture is consistent across devices; SE1 input remains unchanged. Original input coordinates and event delivery came from the legacy Unity/iPhone bridge. Exact pixel-density and event-timing equivalence on modern hardware remains a device comparison item; static analysis alone cannot validate the feel.

### Shake: 0x256384–0x256858

Native code averages raw acceleration events weighted by their duration, projects onto `(0,-0.25,-0.9)`, computes `pow(projection/1.975,0.9)`, fires above `0.8`, and uses `clamp(accelerationX,-2,2)*1.25` for aim. The host now samples raw Core Motion acceleration, including gravity, at 50 Hz and uses these calculations. It replaces the former fixed-strength shake. Core Motion's latest-sample delivery approximates the old event-weighted collection.

### Glass detection: QuarterTrigger.OnCollisionStay, 0x252194–0x2522b0

The original ContactPoint struct contains point, normal, thisCollider and otherCollider; it has no separation field. Native code reads normal Y and records otherCollider when **normal.y > 0.05**. The supplied method's separation test was incorrect. C# now retains the last qualifying continuing contact and scores its COL/COL2/COL3/COL4 multiplier. It no longer substitutes a 0.5 normal threshold and a 40 ms expiry. Contact generation itself remains the new solver's responsibility.

## Scene and script corrections

- Original coin box plus cylinder compound replaces the sphere proxy. The cylinder comes from the IPA's built-in mesh, with original child transforms and root scale. This adds nine built-in meshes to the export, for 423 total.
- Coin orientation is simulated and rendered. Original mass 1, angular drag 0.05, torque 6, maximum angular speed 7, and gravity -19.64 are applied. Bounce threshold is 3.
- Collider materials carry their recovered restitution and friction values. Quarter restitution 0.65 uses maximum combine. Smooth surfaces use their own material rather than a shared guessed response.
- Boxes and mesh surfaces use original geometry. Sphere and capsule obstacles now use curved triangulations rather than boxes. Export contains 100 obstacle colliders and 18,200 triangles.
- Animated obstacle triangle velocities contribute to collision response.
- All 24 serialized launcher/lighter instances provide their own launch velocity, contact threshold, shot-time extension, animation and hinge reset.
- Ricochet scoring follows ordered collider/body transitions, including returning to an earlier object, rather than counting unique objects. Best ricochet updates only on successful shots.
- Collision audio selects original clip arrays by the original body-mass sound category and per-category hit count.
- Main camera follows the coin using script damping and angle offset; iPad uses the script's 70-degree field of view. Quarter shadow follows position, height and table bounds.
- Replay records coin and visible obstacle positions, rotations and scales with timestamps, without advancing live obstacle animations during playback. Returning or backgrounding restores the prior round and poses.
- Practice consumes missed coins and finishes after three successes or exhaustion; it does not overwrite Classic round records.
- Input mode and angle persist with player/session state. Player high scores are added when each player finishes, and qualifying names can be entered.
- The approved main menu implementation is retained.

## Verification

See `../dist/verification-0.4.0.json` for the observed check log and package inspection. Automated checks cover progression, input formulas, rejection of invalid directions, gesture latching, launch timing/gravity, original compound geometry, bounded rotation, material rebound differences, launcher contact, collision-chain ordering, first-round reachability from actual flick samples, and finite terminating trajectories through all 13 static round layouts.

These are regression and reachability checks, not a recording comparison with the original game. Static round sweeps do not exercise animated prop timing. No iOS runtime or device launch has been performed in this workspace.

## Still not exact

- The C# rigid-body/contact solver is not legacy PhysX. Inertia estimation, contact manifolds, collision callback timing, damping integration, friction, sleep behavior and curved primitive tessellation can change bounce and settling. The serialized legacy material combine interpretation assumes PhysX ordering (average/minimum/multiply/maximum).
- Touch delivery and accelerometer sampling require comparison on the iPad 9 and iPhone SE. Device performance is unmeasured.
- Original custom shaders, lighting, particles, announcer timing, some prop audio, score/rack-up effects, some help/statistics presentation, replay camera switches and saved replay/Hall of Fame playback are not fully reconstructed. Name entry uses a native alert.
- Remaining reconstructed methods have not all been checked against native bodies. Recovery 0.4 is a more evidence-based playable build, not a claim of complete behavioral parity.
