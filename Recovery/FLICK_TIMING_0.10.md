# Recovery 0.10.0 — flick sampling correction

## Cause

The input adapter passed each UIKit callback's displacement directly to `FlickGesture.Sample`. That formula expects a displacement and has a fixed firing threshold. Faster touch delivery divides the same stroke into smaller deltas, making the per-callback trigger harder to reach. The 0.9 physics/camera timing checks did not cover touch-event frequency.

## Correction

- `TimedFlickGesture` combines timestamped movement into 1/60-second windows, retaining the established 60 Hz port's displacement scale. This is a host-input adaptation, not a claim that the original engine used this sampling interval.
- The native-derived `FlickGesture` formula, thresholds, strength cap and aim calculation are unchanged. Physics and ProMotion rendering are unchanged.
- UIKit coalesced samples use their own original timestamps, so batch delivery does not change the time scale. Duplicate/out-of-order samples are ignored before updating the prior touch location.
- Ending a contact includes its final position and evaluates any remaining partial window normalized by its duration. Cancellation discards pending movement. One contact still fires at most once.
- Long gaps are handled without iterating through every empty time window.

## Verification

76 managed checks pass, including matching power/aim for the same constant-speed diagonal stroke at 30, 60, 90, 120 and 240 Hz; irregular sample intervals; slow drags; short contact completion; cancellation; and duplicate/out-of-order timestamps. Existing camera, physics and presentation-rule checks continue to pass.

Release IPA validation confirms version 0.10.0/build 10, the ProMotion opt-in, iOS 15 minimum, arm64/iPhone/iPad support and retained static AOT trampolines. Actual feel on the user's 14 Pro still needs device testing. These synthetic traces do not prove equality for every possible physical touch trajectory or sampling loss.
