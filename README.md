# iQuarters

**The 2010 coin-tossing game, rebuilt in C# for modern iPhones and iPads.**

Flick a quarter, bounce it across the table, and land it in a glass. This project recovers the original game's assets and behavior from its IPA and reconstructed scripts, with a new **.NET, UIKit, and SceneKit** implementation. The app contains no Unity runtime.

## Version 1.0

- Classic and practice play, with support for 1–4 players.
- Recovered menus, table layouts, meshes, textures, animations, and audio.
- Coin physics, angle adjustment, scoring, round progression, and ricochet replay.
- Pause controls, high scores, and saved-game resume.
- Native-resolution rendering with screen and safe-area adjustments.
- ProMotion support requesting up to **120 Hz** on compatible displays.
- Timestamp-based flick input, keeping swipe strength consistent across touch sampling rates.

**Restoration is ongoing.** Version 1.0 packages the current reconstruction; it does not imply that every effect or behavior has reached exact parity with the original.

## Install

Download `iQuarters-1.0-ios15.ipa` from the [Releases page](https://github.com/strawberrypoptarts/iQuarters/releases/latest).

| Requirement | Details |
| --- | --- |
| Platform | iPhone or iPad |
| Operating system | iOS / iPadOS 15.0 or newer |
| Architecture | arm64 |
| Installation | A compatible sideloader and signing method |

The packaged IPA is ad-hoc signed. Conventional sideloaders must re-sign it with valid provisioning. Compatibility with an individual sideloading method depends on the device and OS version.

The Home Screen name is **iQuarters**. The existing bundle identifier, `com.itsgames.iquarters.recovery`, is retained for upgrade and save continuity.

## Play

1. Choose **Play Now → Classic**, then select the number of players.
2. Flick upward to throw. Sideways movement during the flick changes aim.
3. Use the angle graphic to adjust the launch angle, then select **Done**.
4. Make three successful shots to complete your round. Misses consume reserve coins.
5. Pause to access replay, sound and input options, or quit. Continue saved Classic progress from the main menu.

## Build from source

The converted assets needed by the app are included. Building the app does not require the original IPA, Unity, or running the asset exporters.

### Toolchain

The current project targets `net10.0-ios27.0` with a deployment minimum of iOS 15.0. The development environment uses **.NET SDK 10.0.401**, the matching **iOS 27 preview workload**, and **Xcode 27**. Use matching SDK/workload/Xcode versions; a stable older iOS workload will not build this target unchanged.

On macOS, from the repository root, with that toolchain installed:

```sh
export DEVELOPER_DIR=/Applications/Xcode.app/Contents/Developer
dotnet workload restore Recovered/iOS/IQuarters.iOS.csproj
dotnet build Recovered/iOS/IQuarters.iOS.csproj \
  -t:Rebuild -c Release -r ios-arm64 \
  -p:EnableCodeSigning=false -p:UseSharedCompilation=false -p:BuildIpa=true
python3 Recovery/tools/package_ipa.py
```

The packager checks version, display name, minimum OS, device families, ProMotion configuration, archive integrity, and absence of Unity runtime files. It writes the IPA and a SHA-256 build manifest to `dist/`.

### Verification

```sh
dotnet run --project Recovered/Verification -p:UseSharedCompilation=false
```

The current suite has **76 checks**, covering game progression, physics, replay rules, camera leveling, and input timing. Flick tests compare equivalent strokes at 30, 60, 90, 120, and 240 Hz, including irregular and invalid timestamps. These checks do not establish physical-device frame rate or complete audiovisual parity.

## Project layout

| Directory | Purpose |
| --- | --- |
| [`Recovered/Core`](Recovered/Core) | Portable C# game rules, physics, camera math, and flick input |
| [`Recovered/iOS`](Recovered/iOS) | Native UIKit/SceneKit rendering, touch, audio, menus, and persistence |
| [`Recovered/Verification`](Recovered/Verification) | Executable correctness checks |
| [`Recovered/Performance`](Recovered/Performance) | Deterministic shot benchmark |
| [`Recovery/converted`](Recovery/converted) | Converted meshes, textures, audio, animation curves, and scene data |
| [`Assets/Scripts`](Assets/Scripts) | 84 supplied reconstructed scripts, retained as historical reference |
| [`Recovery/tools`](Recovery/tools) | Asset exporters, analysis tools, and IPA packaging |
| [`Recovery/catalog`](Recovery/catalog) | Decoded original scene and object records |
| [`Recovery/native`](Recovery/native) | Annotated original native behavior and method metadata |

Original scripts may reference Unity APIs; they are reference material and are not compiled into the new application. The original IPA, extracted app, local toolchains, build caches, and generated release packages are excluded from Git.

## Accuracy and remaining work

The reconstruction uses both supplied scripts and original native-code evidence. Script reconstruction alone is not treated as proof of original behavior.

- [Script coverage and remaining gaps](Recovery/SCRIPT_COVERAGE_0.7.md)
- [Physics and gameplay audit](Recovery/GAMEPLAY_AUDIT.md)
- [Scoring effects and audio](Recovery/EFFECTS_AUDIO_0.6.md)
- [Adaptive presentation, replay cameras, and iPad startup investigation](Recovery/ACCURACY_0.7.md)
- [Loading, pause backdrop, and camera reset](Recovery/LOADING_PAUSE_CAMERA_0.8.md)
- [ProMotion timing](Recovery/PROMOTION_0.9.md)
- [Frame-rate-independent flick sampling](Recovery/FLICK_TIMING_0.10.md)

Remaining fidelity work includes the persistent replay gallery, some particles, secret-round transitions, animated lighting, and portions of help/statistics presentation. The iPad startup mitigation still requires confirmation on the affected physical device. Sustained 120 FPS and final visual/input fidelity require device testing; iOS controls the actual refresh rate.

## Reporting a problem

Include the app version, device model, OS version, reproduction steps, and—when useful—a recording compared with the original. For a launch failure, include the matching app crash report after removing personal identifiers.
