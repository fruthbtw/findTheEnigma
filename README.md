# Find the Enigma

A text-based RPG adventure for the console, written in C# (.NET 8).
Explore a 5×5 world, collect items, fight Shadow Lords and save your progress.

> Developed as the final project of the DGD203 Game Programming course, building on the course's starter framework.

## Features

- **Grid-based exploration:** move between locations with `N`, `S`, `E`, `W`
- **Turn-based combat:** face 1–2 Shadow Lords at once, choose which one to attack or try to flee (50% chance)
- **Inventory system:** pick up items found in locations and check your inventory
- **NPCs and locations:** each location has its own description and events
- **Save / load:** player name, position and inventory are stored in a save file

## Commands

| Command | Action |
|---|---|
| `N` / `S` / `E` / `W` | Move north / south / east / west |
| `take` | Pick up the item at your location |
| `inventory` | Show your inventory |
| `where` | Describe your current location |
| `who` | Show player info |
| `save` / `load` | Save or load the game |
| `help` | List all commands |
| `clear` | Clear the screen |
| `exit` | Quit the game |

## How to Run

Requires the [.NET 8 SDK](https://dotnet.microsoft.com/download).

    git clone https://github.com/fruthbtw/findTheEnigma.git
    cd findTheEnigma
    dotnet run

## Project Structure

| File | Responsibility |
|---|---|
| `Game.cs` | Game loop, input handling, save/load |
| `Map.cs`, `Location.cs` | World grid and location logic |
| `Player.cs`, `Inventory.cs` | Player stats and items |
| `Combat.cs` | Turn-based combat system |
| `Enemy.cs`, `ShadowLord.cs` | Enemy base class and enemy type |
| `Npc.cs` | Non-player characters |
