# Casino Slot Machine Game

A polished casino-style slot machine game developed in Unity.

## 🎮 Game Overview

This project is a fully playable slot machine game featuring:

* Smooth reel spinning animations
* Randomized symbol generation
* Coin and payout system
* Win detection logic
* Audio effects
* Animated UI feedback
* Main menu with animated video background
* Win text animations
* Escape key support for quitting the game

The game was built as part of a Unity game development assignment focused on gameplay systems, animation, clean code structure, and UI polish.

---

# ✨ Features

## Core Gameplay

* Match 3 identical symbols on the middle payline to win.
* Randomized outcomes using Unity RNG.
* Coin system with spin cost and payouts.
* Different reward values for different symbols.

## Reel System

* Smooth reel spinning animation.
* Staggered reel start timing.
* Fixed symbol alignment system.
* Stable reel architecture to prevent symbol overlap or desync.

## UI & Feedback

* Animated win text.
* Main menu scene.
* Video background in menu.
* Press ESC to quit functionality.
* Coin counter UI.

## Audio

* Reel spinning sound.
* Win sound effects.
* Background ambience.

---

# 🧠 Technical Details

## Engine

* Unity

## Programming Concepts Used

* Object-Oriented Programming (OOP)
* Coroutines
* Singleton pattern
* Scene Management
* UI Animation
* Audio System
* RNG-based gameplay logic

## Scripts

### Core Systems

* `SlotMachineController.cs`
* `GameManager.cs`
* `ReelController.cs`

### UI Systems

* `MainMenu.cs`
* `GameUIController.cs`
* `UIManager.cs`

### Data Classes

* `SymbolData.cs`

---

# 📁 Folder Structure

Assets/

* Scripts/

  * Core/
  * Reels/
  * UI/
* Audio/
* Animations/
* Art/
* Scenes/
* Prefabs/

---

# ▶️ How To Play

1. Open the game.
2. Press PLAY from the main menu.
3. Press the SPIN button.
4. Match 3 identical symbols in the middle row to win.
5. Winning combinations reward coins.
6. Press ESC anytime to quit.

---

# 🛠️ How To Run

## Unity Project

1. Open the project in Unity.
2. Open the `MainMenu` scene.
3. Press Play.

## WebGL Build

Open the WebGL build inside:

`Build/WebGL`

and run it using a local server or compatible browser.

---

# 🎨 Bonus Features Added

* Animated main menu
* Video background
* Win animation system
* Sound effects
* Coin economy system
* Staggered reel timing
* Animated UI feedback

---

# 👨‍💻 Development Notes

The project originally began with a basic reel movement system, but was later redesigned into a more stable indexed reel architecture to improve symbol alignment and eliminate visual desynchronization issues.

Special focus was placed on:

* Clean gameplay flow
* Consistent reel alignment
* UI polish
* Smooth audio integration
* Readable and maintainable code

---

# 📌 Controls

| Action     | Input       |
| ---------- | ----------- |
| Spin Reels | Spin Button |
| Quit Game  | ESC Key     |

---

# ✅ Assignment Requirements Covered

* Winning Logic
* Smooth Reel Animation
* Clean Symbol Alignment
* RNG-based Outcomes
* Payout System
* Bonus Features
* OOP Structure
* Organized Project Structure
* Commented Code

---

# 📦 Build Information

Platform: Windows / WebGL

Unity Version: Unity 6
