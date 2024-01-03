

# C# Chess Library

This is a C# chess library that provides functionality for playing and managing chess games. It includes classes for chess pieces, board positions, moves, game states, and more. 

## Features

- Piece classes for each chess piece, including their moves and captures
- Board class for managing the state of the chess board
- Movement class for managing moves made by players
- Sample console application
- Sample Windows Forms Application
- UDP client and server implementations

## Getting Started

Here is how to get started: 

1. Clone the repository
2. Open the solution file in Visual Studio
3. Build and run sample applications

## Sample Applications

### Console Application

The console application provides a simple interface for playing between two players. You simply have to enter your move in the prompt and if it is valid, the game state will be printed out onto the CLI window.

### Windows Forms Application

This application provides a more fully-featured interface for demonstrating the chess library in a windows desktop app:
- Player vs Player: Control both players and test the functionality of a full chess match with reset and undo capabilities
- Host Server: Host a UDP server on you local machine on a custom port, upon starting the server a client interface is automatically connected to it.
- Join Server: Join a UDP server by entering a host's IP and port number

## Contributing

If you would like to contribute, feel free to open an issue or pull request on the repository. 
https://github.com/ruskpr/chess
