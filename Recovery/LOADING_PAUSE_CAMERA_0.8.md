# Recovery 0.8.0 — loading, pause background, camera reset

## Original evidence

- `mainmenu.DisplayLoadingMessage` native 0x240fa8 uses the label `Loading...` with a phone rectangle (6, 480−32, 120, 32). The supplied reconstruction has a different rectangle. `mainmenu.LevelLoad` calls the scene loader; there is no UIKit presentation slide.
- `PauseMenu.Update` native 0x271570 compares animation time against 0.25 before calling `QuarterTrigger.DisplayBackDrop(true)`. The latter toggles the renderer named `BackDrop`. This is scene node **1825**, using texture `sharedassets0.assets-29`, the same wood/glass artwork as the menu. It is separate from the disabled `background01` child (1811).
- `MainCameraScript.LateUpdate` native 0x24ec98 calls `Quaternion.LookRotation(Vector3)`, then Slerp, using the default world-up convention. The previous port called SceneKit's single-argument Look, which can preserve the node's current up direction. It also left the previous shot's orientation in place when resetting the coin.

Annotated routines are preserved in `Recovery/native/`.

## Changes

- New games, resumed games and Practice now show `Loading...` at the bottom left of the menu background, respecting device safe areas. Scene preparation runs off the UI thread; UIKit views are created on the main thread. Rendering resources are prepared before presentation. Game presentation and return to the menu use no native slide animation.
- World and overlay scenes only build their own render-layer geometry/materials, sharing immutable source meshes, textures and parsed data during that load. On the recovered scene this reduces mesh reads/conversions from 700 to 350 and geometry instances from 1120 to 560. These are structural counts, **not measured device startup times**. Audio remains decoded before gameplay.
- The original standalone pause backdrop appears after 0.25 seconds, remains behind pause/help/score controls, and hides after resume or before replay. Its coverage adapts to the current screen. The disabled animated background child remains disabled.
- Main-camera following now uses fixed world up and removes roll introduced by interpolation. A new coin explicitly restores the main camera's position and level aim immediately. Replay retains its original views, with explicit world up for following. The original damping, angle offsets and coin physics are retained.
- Loading failures return to the menu with an error instead of leaving a stuck loading state. Temporary audio/notification resources are released.

## Checks and limitations

- 64 managed checks pass, including a rolled starting camera, lateral throws, vertical targets and the next-coin reset.
- Pause artwork/layering inspected with the native desktop SceneKit renderer at a tall phone viewport. This is not a device screenshot.
- Release build and IPA signature/version/resource checks recorded in `dist/`.
- iPad startup mitigation from 0.7 remains enabled. Launch, real loading duration and perceived camera movement still need device testing. Full original-game parity remains incomplete; the 0.7 coverage ledger continues to list unrelated gaps.
