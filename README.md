# Toy Robot App

## Description
ToyRobotApp is a simple console application that simulates a toy robot being placed on a tabletop, following movement commands, and reporting its position. The robot can be placed at specific coordinates, moved around, and rotated based on user commands. It also has unit tests for validating the core functionality.

## Table of Contents
- [Installation](#installation)
- [Usage](#usage)
- [Features](#features)
- [Test Data and Results](#test-data-and-results)
- [Contact](#contact)

## Installation
Step-by-step instructions to set up the project locally.

### Clone the repository:
bash
git clone https://github.com/samanthazakir/toy-robot-task.git
cd ToyRobotApp


### Prerequisites:
- **.NET 9 SDK** (Download from [here](https://dotnet.microsoft.com/en-us/download/dotnet/9.0))
- **Visual Studio** or any C# compatible IDE.

### Setup:
1. Install necessary dependencies:
bash
dotnet restore


2. If you also want to run the unit tests, navigate to the ToyRobotApp.Tests directory:
bash
cd ToyRobotApp.Tests
dotnet restore


## Usage

### Running the Application
1. Navigate to the ToyRobotApp directory:
bash
cd ToyRobotApp

2. Run the application:
bash
dotnet run


### Sample Commands:
You can input commands like the following:

PLACE 0,0,NORTH
MOVE
LEFT
REPORT

Expected output:
0,1,WEST


## Features
- **PLACE** command to place the robot at a specified position on the tabletop.
- **MOVE** command to move the robot one unit forward.
- **LEFT** command to rotate the robot 90 degrees to the left.
- **RIGHT** command to rotate the robot 90 degrees to the right.
- **REPORT** command to get the current position and facing direction of the robot.
- Boundary checks to ensure the robot stays within the tabletop (5x5 grid).
- Unit tests to validate all core operations.

## Test Data and Results

### Sample Test Case 1
**Commands:**
PLACE 0,0,NORTH
MOVE
REPORT

**Expected Output:**
0,1,NORTH


### Sample Test Case 2
**Commands:**
PLACE 0,0,NORTH
LEFT
REPORT

**Expected Output:**
0,0,WEST


### Sample Test Case 3
**Commands:**
PLACE 1,2,EAST
MOVE
MOVE
LEFT
MOVE
REPORT

**Expected Output:**
3,3,NORTH


### Sample Test Case 4 (Edge Check)
**Commands:**
PLACE 4,4,NORTH
MOVE
REPORT

**Expected Output:**
4,4,NORTH (No move - outside tabletop boundary)


## Contact
- **Author:** Samantha Zakir
- **Email:** samanthazakir@gmail.com
- **GitHub:** [@samanthazakir](https://github.com/samanthazakir)