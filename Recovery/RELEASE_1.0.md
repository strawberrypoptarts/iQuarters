# iQuarters 1.0

The first numbered 1.0 release of the C# iQuarters reconstruction for iOS and iPadOS 15+.

## Included

- App name: **iQuarters**; version **1.0**, build **11**.
- Original recovered assets, menus, coin physics, scoring and round presentation.
- Native-resolution layout and ProMotion support requesting up to 120 Hz.
- Timestamp-based flick sampling to address refresh-rate-dependent swipe strength.
- Loading indicator, immediate gameplay transition, pause backdrop and camera leveling fixes.
- Preloaded impact audio and the iPad startup mitigation from recent builds.

## Install

Use `iQuarters-1.0-ios15.ipa` with a compatible signing-capable sideloader.
The arm64 package is ad-hoc signed; conventional sideloaders must re-sign and provision it.
The bundle identifier is unchanged for upgrade/save continuity.

## Status

Restoration remains in progress. Physical-device confirmation of the iPad startup mitigation,
sustained 120 FPS, and complete audiovisual parity remains outstanding. See the README
and script coverage report for known fidelity gaps.
