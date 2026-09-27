# Version 0.5: lighting and flick slowdown

## Scope

The owner reports that 0.4 physics feel accurate. This update keeps its input formulas, collider shapes, solver, timing and coefficients. It targets work done during a shot and the darker rendering.

## Shot performance

- Replaced per-triangle-vertex native SceneKit position conversion with one native transform-matrix conversion per collider and managed vector multiplication. Unchanged collider matrices reuse geometry and bounds. Surface velocities are cleared on the first stationary frame so a stopped prop cannot retain motion.
- Cached the current round's collider list instead of rebuilding it every frame.
- Cached replay node selection at round changes. Replay captures the coin and animation targets rather than traversing every scene node and its ancestors each frame. Pose records are value types rather than individually allocated objects. Static geometry remains in the scene.
- Removed a captured LINQ minimum calculation from the innermost convex contact test. It now uses an allocation-free loop with the same arithmetic.

### Observed desktop checks

A repeatable benchmark runs 39 shots through all 13 static round layouts, three measured passes after warmup. It records each frame's position, velocity, rotation, contact count and final score/ricochets.

| Measurement | 0.4 code | 0.5 code |
|---|---:|---:|
| Managed allocations per 39-shot pass | 69,766,144 bytes | 1,514,352 bytes |
| Median elapsed time | 81.93 ms | 78.79 ms |
| Trajectory trace SHA-256 | 3625eeed688305e7ee2dec51fd8a1dbe2f9ce404a8184503b1f45d06537c538e | identical |

This is about 97.8% less allocation in the headless physics benchmark. It is not an iPhone/iPad frame-rate measurement; most expected app-side savings come from removing native calls and full-scene replay traversal, which this benchmark does not execute.

A separate native SceneKit check compared 109,200 vertex conversions across all 100 colliders, both stationary and displaced. Maximum component difference between the matrix calculation and native per-position conversion was 0.00000383 world units. When processing every collider, native transform calls fall from 54,600 to 100 per update. A real round uses a subset; unchanged colliders also skip vertex work entirely.

All 47 gameplay regression checks passed. Device performance still needs measurement on the owner's devices.

## Lighting

`export_lighting.py` reads the original level's 72-byte RenderSettings record, ten 100-byte Light records, and original shader references. It exports ambient color (0.2, 0.2, 0.2), light type, color, intensity, range, cone angle and layer masks. The runtime restores the five enabled gameplay lights; disabled room/top lights and overlay-only lights remain excluded. Geometry layer masks ensure the lights illuminate their original object groups.

The default SceneKit headlight is disabled in gameplay. Material diffuse tint, shininess, specular color and textured emission are restored. The room photographs have full white emission in the original and are displayed as self-lit textures. Partial glass emission retains the glass texture rather than adding a flat color.

Two native macOS SceneKit comparison renders were inspected:

- `dist/previews/lighting-0.4.png`
- `dist/previews/lighting-0.5.png`

An initial direct translation of the legacy shader's DOUBLE operation overexposed the modern rendering, so it was removed. SceneKit and the old fixed-function/Unity pipeline use different lighting/color calculations. Original light data is recovered; exact original appearance is still unverified without an original reference capture. The previews are desktop renders, not screenshots from the iOS app.

## Reproduce

```sh
DOTNET_CLI_HOME="$PWD/.dotnet-home" .dotnet/dotnet run --project Recovered/Performance -c Release -p:UseSharedCompilation=false -- Recovery/converted
swift Recovery/tools/verify_scene_transforms.swift Recovery/converted
python3 Recovery/tools/export_lighting.py
swift Recovery/tools/preview_gameplay.swift Recovery/converted dist/previews/lighting-0.5.png after
```
