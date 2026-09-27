# Version 0.6: impact audio, glass and presentation

## Changes

- Replaced per-impact WAV loading, player creation and disposal with one prepared audio engine, 30 predecoded buffers and four reusable playback channels. Impact playback only looks up and schedules a buffer. Score music, crowd and prop audio can overlap.
- Exported the original scene's 28 nonempty AudioSource bindings; animated lighter, phone and launcher reactions now use their own recovered clips.
- Glass alone receives the legacy doubled lighting output, alpha blending and disabled depth writes. Restored the 13 round-specific glass contact-shadow assignments and sizes from SetGlasses. Table brightness is unchanged.
- Recovered GlassScaleController's original scale curve, 2/3-second playback duration and 0.75 scale adjustment. The supported scoring body's visible mesh pulses in X/Y and returns to its original scale. The original IgnoreGlassEffect tag excludes the lazy Susan and beer yard.
- Restored score stinger, applause volume by successful shot number, practice announcement, streak digits/animation, multiplier graphics and original coin fly-in clip segments.
- Restored automatic positional ricochet replay, count graphics and sound, and delayed bonus display before progression. Replay counts use the same filtered collision chain as scoring.
- Restored original round-complete, new-round-high, practice-great-score and game-over clips. Unused round numerals and digit variants are hidden explicitly.
- Round banner stays until the shot, spins while waiting and reappears between shots. New-round input waits through the recovered initial half-second.
- Pause freezes the gameplay effect sequence while the pause-panel animation continues. Physics coefficients, input formulas and integration are unchanged; the core only exposes the already-selected scoring owner for visual effects.

## Observed checks

- C# source compilation: zero errors and warnings.
- 47 core/gameplay checks passed.
- Three 39-shot desktop trace passes match the previous build's SHA-256: `3625eeed688305e7ee2dec51fd8a1dbe2f9ce404a8184503b1f45d06537c538e`.
- macOS offline AVAudioEngine test rendered all 30 buffers audibly, resumed after pause and rendered four scheduled channels. Worst measured scheduling call was about 0.026 ms. This is not iOS hardware timing or an audible listening test.
- Separate macOS SceneKit snapshots inspected for glass visibility and the round-complete animation. These are asset/render previews, not screenshots of the iOS app.

## Remaining fidelity limits

This remains a reconstruction. Exact old fixed-function shader output, light-ray vertex-color effects, collision particles, original replay camera cuts/slow motion and some secret-round/coin-stack presentation remain incomplete. Restored presentation follows the supplied scripts and serialized assets; not every presentation method has been cross-checked against ARM AOT bodies. Automatic replay currently uses the existing main-camera pose playback. No iOS device was connected: impact stutter, audio mixing, animation timing and appearance still need confirmation on the owner's devices.
