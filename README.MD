# Snake Game (Console Edition)

A simple **Snake Game** implemented in **C#** for the console. The game features movement, apple collection, and collision detection.

## Features
- Classic **Snake** game mechanics.
- Play in the **console** window.
- **Apple collection** to grow the snake.
- **Collision detection** (wall and self-collision).
- **Win condition** when the board is fully occupied.

## How to Play
- Use **Arrow Keys** to control the snake:
  - `↑` (Up)
  - `↓` (Down)
  - `←` (Left)
  - `→` (Right)
- The goal is to **eat apples** (``) to grow your snake.
- Avoid **colliding with yourself** or **hitting the screen boundary**.
- The game **ends** when you either win (filling the screen) or lose (collision).

## Requirements
- .NET SDK installed on your system
- Windows, Mac, or Linux terminal that supports `Console.SetCursorPosition()`

## Installation & Running
1. **Clone or Download** the repository:
   ```sh
   git clone https://github.com/mzelder/console-eater.git
   cd console-eater
   ```
2. **Run the game** using .NET CLI:
   ```sh
   dotnet run
   ```

## Code Structure
- `MoveSnake()`: Moves the snake in the selected direction.
- `AddSnakeElement()`: Adds a new segment to the snake when eating an apple.
- `Collision()`: Detects if the snake collides with itself or the walls.
- `Win()`: Checks if the player wins by filling the screen.
- `GenerateApple()`: Spawns a new apple at a random location.
- `UpdateUI()`: Updates the console to display the game state.
