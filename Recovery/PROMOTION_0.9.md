# Recovery 0.9.0 — ProMotion

## Implementation

- Adds `CADisableMinimumFrameDurationOnPhone = true` to the shipped Info.plist. Apple requires this opt-in for rates above the iPhone system default: [Apple documentation](https://developer.apple.com/documentation/bundleresources/information-property-list/cadisableminimumframedurationonphone).
- Uses CADisplayLink instead of the 60 Hz NSTimer for menus and gameplay. The preferred range is 60 through the connected screen's maximum, capped at 120, with the maximum preferred. A 60 Hz device therefore requests 60, not 120.
- Sets both world and overlay SceneKit views, and the menu view, to the matching preferred frame rate with continuous rendering.
- Uses monotonic display target timestamps for elapsed time. Common run-loop mode keeps updates running during touch tracking. Links are invalidated when controllers disappear; a hidden menu no longer continues ticking underneath gameplay.
- Camera smoothing preserves its former 60 Hz response using elapsed-time exponential weights. Animation, replay and effect clocks continue to use elapsed seconds. Physics retains its existing 4 ms fixed solver steps.

## Verification

- 66 managed checks pass. New checks compare camera response at 30/60/120 Hz and verify identical settled position, orientation, duration and contact count for a physical shot driven at 60 versus 120 Hz.
- Release build and package checks verify version 0.9.0/build 9, arm64, iOS 15.0 minimum, iPhone/iPad families, the ProMotion plist flag, and retained static AOT trampolines.
- No device FPS measurement has been made here. This enables and requests 120 Hz; sustained delivered frame rate is unverified. iOS can vary refresh rate with system conditions: [Apple ProMotion guidance](https://developer.apple.com/documentation/quartzcore/optimizing-iphone-and-ipad-apps-to-support-promotion-displays).
