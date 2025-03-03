# Toy Robot App

## Description
ToyRobotApp is a simple console application written in C# that simulates a toy robot being placed on a tabletop, following movement commands, and reporting its position. The robot can be placed at specific coordinates, moved around, and rotated based on user commands. It also has unit tests for validating the core functionality.

## Table of Contents
- [Installation](#installation)
- [Usage](#usage)
- [Constraints](#constraints)
- [Test Data and Results](#test-data-and-results)
- [Contact](#contact)

## Installation
Step-by-step instructions to set up the project locally.

### Clone the repository:
```bash
git clone https://github.com/samanthazakir/toy-robot-task.git
cd ToyRobotApp
```

### Prerequisites:
- **.NET 9 SDK** (Download from [here](https://dotnet.microsoft.com/en-us/download/dotnet/9.0))
- **Visual Studio** or any C# compatible IDE.
- **Docker**
   
### Setup:
1. Install necessary dependencies:
```bash
dotnet restore
```

2. If you also want to run the unit tests, navigate to the ToyRobotApp.Tests directory:
```bash
cd ToyRobotApp.Tests
dotnet restore
```

### Project Files
The `ToyRobotApp` project has the following files:
| File | Description |
|---|---|
| `Program.cs` | Entry point, reads commands from file and executes them. |
| `RobotApp.cs` | Processes commands and calls `RobotService`. |
| `RobotService.cs` | Handles actual logic for movement, rotation, and boundary checks. |
| `TableTopService.cs` | Defines the table size and validates positions. |
| `Position.cs` | Represents a coordinate (X, Y). |
| `Direction.cs` | Enum for directions (NORTH, SOUTH, EAST, WEST). |

### Tests

The `ToyRobotApp.Tests` project contains unit tests for:
- `RobotApp` command processing.
- `RobotService` logic (placement, movement, rotation).
- `TableTopService` validation logic.

## Running the Application

Ensure Docker is installed and running on your system. If you want to run the app in a containerized environment, follow the steps below to build the Docker image and run the app in a container.

If you're not using Docker, you can skip the Docker steps and simply run the application directly and ignore the Dockerfile.

### Steps to Run the Application:

1. **Build the Solution:**
   - Open your solution in Visual Studio or through the command line with `dotnet build`.

2. **Prepare the Input File:**
   - Place your command in `command.txt` file in the `ToyRobotApp/Input` folder. This file should contain valid commands for the toy robot (e.g., `PLACE`, `MOVE`, `REPORT`, etc.).

3. **Run the Application:**
   - If you're running directly (without Docker), simply run the application using `dotnet run` from the command line in the project directory.
   
   - If you're using Docker, make sure your docker is running and then run the application.
     
## Usage

### Running the Application
1. Navigate to the ToyRobotApp directory:
```bash
cd ToyRobotApp
```

2. Run the application:
```bash
dotnet run
```
### Valid Commands:
- **PLACE** will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST.)
- **MOVE** will move the toy robot one unit forward in the direction it is currently facing.
- **LEFT** will rotate the robot 90 degrees in the left direction without changing the position of the robot.
- **RIGHT** will rotate the robot 90 degrees in the right direction without changing the position of the robot.
- **REPORT** will announce the X,Y and F of the robot. This can be in any form, but standard output is sufficient.

### Sample Input:
You can input commands like the following:

```text
PLACE 0,0,NORTH
MOVE
LEFT
REPORT
```

**Expected output:**
```text
0,1,WEST
```

## Constraints
- **The robot must be prevented from falling off the table.** 
- **Any movement that would result in the robot falling must be prevented, while allowing further valid
commands.**

## Test Data and Results

### Sample Test Case 1
**Commands:**
```text
PLACE 0,0,NORTH
MOVE
REPORT
```

**Expected Output:**
```text
0,1,NORTH
```

### Sample Test Case 2
**Commands:**
```text
PLACE 0,0,NORTH
LEFT
REPORT
```

**Expected Output:**
```text
0,0,WEST
```

### Sample Test Case 3
**Commands:**
```text
PLACE 1,2,EAST
MOVE
MOVE
LEFT
MOVE
REPORT
```

**Expected Output:**
```text
3,3,NORTH
```

### Sample Test Case 4 (Edge Check)
**Commands:**
```text
PLACE 4,4,NORTH
MOVE
REPORT
```

**Expected Output:**
```text
4,4,NORTH (No move - outside tabletop boundary)
```

### Sample Test Case 5 (Invalid Position)
**Commands:**
```text
PLACE -1,0,NORTH
REPORT
```

**Expected Output:**
```text
Please place in a valid position.
```

### Sample Test Case 6 (Boundary Check)
**Commands:**
```text
PLACE 5,5,NORTH
MOVE
REPORT
```

**Expected Output:**
```text
PLACE in a valid position first to perform this operation.
```

## Contact
- **Author:** Samantha Zakir
- **Email:** samanthazakir@gmail.com
- **GitHub:** [@samanthazakir](https://github.com/samanthazakir)
