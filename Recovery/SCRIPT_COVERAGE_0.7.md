# Script coverage ledger — 0.7.0

All 84 supplied files are inventoried below with their actual attachments and port status. This is **not** a completed 1:1 certification: only the native routines identified in the evidence notes have been checked against the executable. Unattached scripts can still be referenced statically; the JSON ledger lists those references and every declared method.

| Script | Scene components | Current coverage / remaining difference |
|---|---:|---|
| About | 1 | Menu assets/animations implemented in MainMenuController; selected text/dialogs use UIKit. Complete native branch parity not audited. |
| AngleAdjustScript | 1 | Angle input/range implemented; separate angle adjustment graphic not restored. |
| AnnouncerScript | 1 | Recovered clips preloaded; 0.7 native stinger gate corrected. Audio mixing/device timing still unverified. |
| AreYouSure | 1 | Menu assets/animations implemented in MainMenuController; selected text/dialogs use UIKit. Complete native branch parity not audited. |
| BackClearButtons | 1 | Menu assets/animations implemented in MainMenuController; selected text/dialogs use UIKit. Complete native branch parity not audited. |
| BirdScript | 5 | Recovered geometry, animation and reaction values loaded; replay uses recorded poses. Original engine simulation equivalence not guaranteed. |
| Boundary | 0 | No component attached in either shipped scene. Referenced by supplied scripts; reachability/native behavior not fully established. |
| ButtonDownScript | 0 | No component attached in either shipped scene. No name reference in other supplied scripts; not activated by this port. |
| CameraRelativeControl | 0 | No component attached in either shipped scene. No name reference in other supplied scripts; not activated by this port. |
| CellPhoneScript | 0 | No component attached in either shipped scene. No name reference in other supplied scripts; not activated by this port. |
| ChipBounceBounceScript | 0 | No component attached in either shipped scene. No name reference in other supplied scripts; not activated by this port. |
| ChipBounceScript | 0 | No component attached in either shipped scene. Referenced by supplied scripts; reachability/native behavior not fully established. |
| ChipRackupScript | 0 | No component attached in either shipped scene. No name reference in other supplied scripts; not activated by this port. |
| ChipRackupTextScript | 0 | No component attached in either shipped scene. No name reference in other supplied scripts; not activated by this port. |
| ChipRicochetBounce00Script | 0 | No component attached in either shipped scene. No name reference in other supplied scripts; not activated by this port. |
| ChipRicochetScript | 0 | No component attached in either shipped scene. Referenced by supplied scripts; reachability/native behavior not fully established. |
| CoinHolder | 1 | Score/coin HUD and original fly clips implemented; 0.7 restores visibility beneath helper parent. Holder transition state details not all reproduced. |
| CoinsLeft | 1 | Counter works; original particle/coin-stack presentation incomplete. |
| CoinsLeftController | 0 | No component attached in either shipped scene. No name reference in other supplied scripts; not activated by this port. |
| ColliderGameObjectClass | 0 | Data role replaced by CollisionShape/CollisionChain; core trajectory regression preserved. |
| ColliderInfoClass | 0 | Data role replaced by CollisionShape/CollisionChain; core trajectory regression preserved. |
| ConstraintAxis | 0 | No component attached in either shipped scene. Referenced by supplied scripts; reachability/native behavior not fully established. |
| ControlState | 0 | No component attached in either shipped scene. Referenced by supplied scripts; reachability/native behavior not fully established. |
| CrowdScript | 1 | Recovered clips preloaded; 0.7 native stinger gate corrected. Audio mixing/device timing still unverified. |
| Entry | 0 | Scores persisted through GameStorage; exact original presentation/preference format not retained. |
| FirstPersonControl | 0 | No component attached in either shipped scene. No name reference in other supplied scripts; not activated by this port. |
| FollowTransform | 0 | No component attached in either shipped scene. No name reference in other supplied scripts; not activated by this port. |
| GameHighScreen | 1 | Menu assets/animations implemented in MainMenuController; selected text/dialogs use UIKit. Complete native branch parity not audited. |
| GameManagerScript | 1 | C# session/player rules retained and tested; original platform input/preferences adapted to UIKit/storage. |
| GameOrRoundButtons | 1 | Menu assets/animations implemented in MainMenuController; selected text/dialogs use UIKit. Complete native branch parity not audited. |
| GameOver | 1 | Original meshes/clips and event wiring implemented; complete frame-by-frame parity not verified. |
| GlassScaleController | 1 | Original sampled pulse with 1.05 speed, 0.75 scale weighting; no device parity measurement. |
| Help | 1 | Functional host UI/selected original clips; text, help, statistics and some transitions use host substitutes. |
| HiScorePracticeScript | 0 | No component attached in either shipped scene. No name reference in other supplied scripts; not activated by this port. |
| HiScoreRoundScript | 1 | Scores persisted through GameStorage; exact original presentation/preference format not retained. |
| HiScoreScript | 1 | Scores persisted through GameStorage; exact original presentation/preference format not retained. |
| InGameAngleIcon | 1 | 0.7 restores helper children and resting hold pose; root slide offset retained. Reminder animation/state detail remains incomplete. |
| InGameHiScore | 1 | Scores persisted through GameStorage; exact original presentation/preference format not retained. |
| IntroCamScript | 1 | Serialized camera preserved; original intro camera flow not restored. |
| Joystick | 0 | No component attached in either shipped scene. Referenced by supplied scripts; reachability/native behavior not fully established. |
| LauncherScript | 11 | Recovered geometry, animation and reaction values loaded; replay uses recorded poses. Original engine simulation equivalence not guaranteed. |
| LazySusanGlassShadow | 1 | Recovered follow/shadow values implemented; aspect adaptation is a deliberate modern-device change. |
| LighterScript | 13 | Recovered geometry, animation and reaction values loaded; replay uses recorded poses. Original engine simulation equivalence not guaranteed. |
| Logo | 1 | Menu assets/animations implemented in MainMenuController; selected text/dialogs use UIKit. Complete native branch parity not audited. |
| MainCameraScript | 1 | Recovered follow/shadow values implemented; aspect adaptation is a deliberate modern-device change. |
| NewtonsCradleScript | 0 | No component attached in either shipped scene. No name reference in other supplied scripts; not activated by this port. |
| ObliqueNear | 0 | No component attached in either shipped scene. Referenced by supplied scripts; reachability/native behavior not fully established. |
| PauseButtonScript | 1 | Functional host UI/selected original clips; text, help, statistics and some transitions use host substitutes. |
| PauseMenu | 1 | Functional host UI/selected original clips; text, help, statistics and some transitions use host substitutes. |
| PlayerInfoClass | 0 | C# session/player rules retained and tested; original platform input/preferences adapted to UIKit/storage. |
| PlayerRelativeControl | 0 | No component attached in either shipped scene. No name reference in other supplied scripts; not activated by this port. |
| PowerX | 1 | Original meshes/clips and event wiring implemented; complete frame-by-frame parity not verified. |
| PracticeGreatScore | 1 | Original meshes/clips and event wiring implemented; complete frame-by-frame parity not verified. |
| PracticeUI | 1 | Functional host UI/selected original clips; text, help, statistics and some transitions use host substitutes. |
| AssemblyInfo | 0 | Assembly metadata; no gameplay behavior. |
| QuarterTrigger | 1 | Core physics/input/scoring ported; native flick/contact/stinger/replay selection checked. New solver is not original PhysX; complete native state-machine parity remains unverified. |
| RenderWater | 0 | No component attached in either shipped scene. Referenced by supplied scripts; reachability/native behavior not fully established. |
| ReplayCameraScript | 3 | 0.7 uses all three recovered transforms/FOVs/damping; native round exclusions checked. Device comparison pending. |
| ReplayController | 1 | Current-shot automatic/manual replay implemented; six-slot persistent replay gallery/save workflow missing. |
| ReplayExciter | 0 | No component attached in either shipped scene. No name reference in other supplied scripts; not activated by this port. |
| RicochetExciter | 1 | Original holder/coin clips and scoring textures; 0.7 restores 45-frame score and 15–20-frame exit. Replay skipping remains incomplete. |
| RollABall | 0 | No component attached in either shipped scene. No name reference in other supplied scripts; not activated by this port. |
| RotationConstraint | 0 | No component attached in either shipped scene. No name reference in other supplied scripts; not activated by this port. |
| RoundComplete | 1 | Original clips and digit selection retained; 0.7 restores dim material alpha 0.5. UI 3D lighting still differs. |
| RoundHighScreen | 1 | Menu assets/animations implemented in MainMenuController; selected text/dialogs use UIKit. Complete native branch parity not audited. |
| RoundIndicator | 1 | Original meshes/clips and event wiring implemented; complete frame-by-frame parity not verified. |
| SaveGameScript | 0 | No component attached in either shipped scene. No name reference in other supplied scripts; not activated by this port. |
| SaveReplayButtons | 1 | Current-shot automatic/manual replay implemented; six-slot persistent replay gallery/save workflow missing. |
| SecretRound | 1 | Round content available; original secret intro/outro presentation not fully connected. |
| ShadowQuarterScript | 1 | Recovered follow/shadow values implemented; aspect adaptation is a deliberate modern-device change. |
| ShotTypeHelper | 1 | Functional host UI/selected original clips; text, help, statistics and some transitions use host substitutes. |
| SidescrollControl | 0 | No component attached in either shipped scene. No name reference in other supplied scripts; not activated by this port. |
| SmoothFollow2D | 0 | No component attached in either shipped scene. No name reference in other supplied scripts; not activated by this port. |
| SpotlightScript | 1 | Original static lighting recovered; animated spotlight/rotation behavior not reproduced. |
| StatsScreen | 1 | Functional host UI/selected original clips; text, help, statistics and some transitions use host substitutes. |
| Streak | 1 | Original meshes/clips and event wiring implemented; complete frame-by-frame parity not verified. |
| TapControl | 0 | No component attached in either shipped scene. No name reference in other supplied scripts; not activated by this port. |
| UIPlayer | 1 | Original meshes/clips and event wiring implemented; complete frame-by-frame parity not verified. |
| ZoomCamera | 0 | No component attached in either shipped scene. Referenced by supplied scripts; reachability/native behavior not fully established. |
| iPhoneWater | 0 | No component attached in either shipped scene. No name reference in other supplied scripts; not activated by this port. |
| lightray | 1 | 0.7 restores meshes, vertex alpha, additive tint, double-speed clip and Y minus 0.12 from native code; dynamic original side-by-side comparison pending. |
| mainmenu | 1 | Menu assets/animations implemented in MainMenuController; selected text/dialogs use UIKit. Complete native branch parity not audited. |
| qstack | 0 | No component attached in either shipped scene. No name reference in other supplied scripts; not activated by this port. |
| spotdirScript | 1 | Original static lighting recovered; animated spotlight/rotation behavior not reproduced. |
