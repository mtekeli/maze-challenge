# maze-challenge
About
This document presents an object oriented based solution for the Maze Challange problem.

Problem
Beginning from the start point, discover the route to the end point (a.k.a Goal) in a walled maze which represented by the two-dimensional matrix. 

External maze input format for StandardMaze class:
S___X
__XX_
__X__
_X__G
___X_

Output format:
Bfs Completed:
(1,1) (2,1) (3,1) (4,1) (5,1) (5,2) (5,3) (4,3) (4,4) (4,5)
Process took 6 milliseconds.

Solver Algorithms:
At the moment two algorithms are supported. BFS (Breadth-first search) and DFS (Depth-first search).

Tests
16 unit tests are defined:
  •	Validation: Validate user inputs and make sure that they are in the correct form of data and valid range.
    o	Maze input and format validation
    o	Algorithm input validation

  •	Solution: Test that different mazes can be solved both by the supported algorithms.

Usage
MazeChallange.exe maze.txt [0:BFS,1:DFS]
