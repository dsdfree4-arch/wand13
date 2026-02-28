# Ward13 Demo Scripts

This repository now includes Unity C# scripts for the requested demo ending flow and admin code unlock.

## Included scripts

- `Assets/Scripts/LevelCompleteTrigger.cs`
  - Put this on a trigger collider at the end of Level 1.
  - Detects the `Player` and starts the credits sequence.
  - Optionally freezes game time during the sequence.

- `Assets/Scripts/CreditsSequenceController.cs`
  - Controls a 3-step UI text sequence:
    1. Thanks for playing/demo text
    2. `WARD13 CHAPTER 2 SOON`
    3. Final creator message (`Made by JOE BIDEN / Jovanni`)
  - Uses `WaitForSecondsRealtime`, so it still runs while `Time.timeScale = 0`.

- `Assets/Scripts/AdminPanelCodeUnlock.cs`
  - Call `CheckCode(string input)` from your UI button.
  - Unlocks an admin panel when the entered code matches `admin1`.

## Quick Unity setup

1. Create a `CreditsPanel` canvas object and a `TextMeshProUGUI` label.
2. Add `CreditsSequenceController` to a manager object.
3. Link `creditsPanel` and `creditsText` in the inspector.
4. Create a trigger collider at the level exit and attach `LevelCompleteTrigger`.
5. Assign the `CreditsSequenceController` reference in `LevelCompleteTrigger`.
6. For admin unlock, place `AdminPanelCodeUnlock` on a UI manager and wire your input field button to call `CheckCode`.
