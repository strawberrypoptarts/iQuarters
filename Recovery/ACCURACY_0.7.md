# Recovery 0.7.0 — device adaptation and original presentation

## Implemented

- Full-screen rendering at the current screen's NativeScale; no fixed 320×480 framebuffer or letterbox. Camera expands vertical framing on taller phones while retaining the original horizontal scene coverage. iPad main-camera base FOV remains 70°. HUD edge wrappers account for safe areas without rewriting original animation curves. Flick deltas are normalized to the original 320-point reference width (SE1 width is unchanged).
- Corrected Unity Renderer.enabled translation: an invisible helper mesh must not hide its children. Fixes the angle control, ricochet parent/score and coin fly-in. The angle control uses its original hold pose; playing its onscreen clip as well as moving its root had doubled the slide displacement.
- Restored scoring glow above the coin using original meshes 426/427, texture 28, material 624 and animation 506. White vertex color with alpha masked by original green channel; additive yellow tint; speed 2; position Y minus 0.12; lazy Susan X/Z following.
- Round-complete dim plane uses original color (0.117647, 0.117647, 0.117647, 0.5), restoring scene visibility through it.
- Replay uses recovered cameras 1–3, beginning with camera 3 overhead, cycling with the original round exclusions, and following the coin with saved damping. Replay FOV uses its own serialized value rather than the iPad main-camera FOV. Camera and poses restore when replay ends.
- Stinger 596 now plays only on the third successful Classic shot, matching the original native gate. Practice voice and crowd clips remain separate. Ricochet score display now uses frames 0–45, followed by the holder's frames 15–20 exit.

## Native evidence

The supplied scripts are reconstructed. Some method bodies omit behavior still present in the original ARMv7 executable. They are evidence, not a definitive specification by themselves.

- `QuarterTrigger.FixedUpdate`: 0x257f34–0x258050 gates the scoring stinger on `feGameType == gtClassic` and `curMadeShotsThisRound == shotsPerRound - 1`. GOT fields resolved against preserved metadata: FieldIDs 226, 224, 354, 352.
- `lightray.TintMesh`: calls Color.white, then sets alpha according to mesh green. `lightray.Update`: animation speed 2 and coin Y minus 0.12. The reconstructed source incorrectly used black and omitted these values.
- `QuarterTrigger.GetValidReplayCamera`: zero-based rounds 3/6 force camera 3; round 8 maps camera 1 to 2; rounds 10/12 map camera 3 to 1. Other selections unchanged.
- `InGameAngleIcon.Start/Update`: root-position movement; no Animation.Play call in these native routines. Resting hold pose avoids applying a second mesh slide.
- Annotated method disassemblies are retained in `Recovery/native/`.

## iPad startup report and mitigation

Both supplied reports fail before gameplay. Version 0.6.0's UUID exactly matches archived symbols (`12CCE6B0-FE21-3033-A5E2-27C94E2A3968`). Symbolication reaches `System.AppContext.Setup` during `mono_runtime_install_appctx_properties`, then Mono initialization and `xamarin_main`. The fault targets offset 0x18 inside a read-only mapped page.

This is consistent with a failure to execute a remapped Mono AOT trampoline page. It is an inference, not a device-confirmed root cause. Version 0.7 builds with Mono's `nopagetrampolines` AOT option, using precompiled static trampoline pools inside the signed executable. Binary inspection confirms static trampoline symbols and no `specific_trampolines_page` symbol. Native symbols are retained for further diagnosis.

Runtime implementation reference: [Mono AOT runtime 10.0.12](https://github.com/dotnet/runtime/blob/v10.0.12/src/mono/mono/mini/aot-runtime.c), `get_new_trampoline_from_page`. The compiler accepts the option and the generated binary confirms its effect. This avoids runtime page remapping; no JIT, entitlement bypass or Unity runtime is added. The finite compiler-default pools replace dynamically added pages. **Actual iPad launch and extended play remain untested.**

## Verification and limits

- Release device build, minimum iOS 15.0, arm64, device families 1 and 2; package/signature/resource checks recorded under `dist/`.
- 61 managed checks pass, including five viewport cases, fractional flick equivalence, all 39 replay camera choices and stinger gating.
- 39-shot physics trace remains SHA256 `3625eeed688305e7ee2dec51fd8a1dbe2f9ce404a8184503b1f45d06537c538e`, unchanged from 0.4/0.6. This tests static-scene simulation, not device frame timing.
- Native desktop SceneKit renders checked glow shader, translucent dim panel, overhead camera and tall-phone HUD. These are inspection renders, not iPhone/iPad screenshots; preview HUD numbers are placeholders.
- Original IPA, extracted files and all 84 supplied scripts remain unchanged.

## Accuracy work still open

The [84-file coverage ledger](SCRIPT_COVERAGE_0.7.md) explicitly distinguishes attachments, ported behavior and gaps. It does not claim that every native branch has been audited. Remaining differences include six-slot persistent replay saving/gallery, coin-stack/particle presentation, secret-round intro/outro wiring, animated spotlights, angle reminder/adjustment graphic, some menu/help/stats text and transitions, and original 3D UI lighting. End-to-end sound/animation timing, appearance and performance need device comparison. This is a test recovery, not a completed 1:1 edition.
