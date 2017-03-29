# Maze Challenge
### About
This project presents an object oriented based solution for the Maze Challange problem.
### Problem
Beginning from the start point, discover the route to the end point (a.k.a Goal) in a walled maze which is represented by the two-dimensional matrix.
### Solution
External maze input format:
```sh
S___X
__XX_
__X__
_X__G
___X_
```
Output format:
```sh
Bfs Completed:
(1,1) (2,1) (3,1) (4,1) (5,1) (5,2) (5,3) (4,3) (4,4) (4,5)
Process took 6 milliseconds.
```
Solver Algorithms:
At the moment two algorithms are supported.
- BFS (Breadth-first search)
- DFS (Depth-first search)

### Tests
16 unit tests are defined:
- Maze input and format validation: Validate user inputs and make sure that they are in the correct form of data and valid range.
- Algorithm input validation
- Solution: Test that different mazes can be solved both by the supported algorithms.


### Usage
```sh
MazeChallange maze.txt [0:BFS,1:DFS]
```


### Todos

 - Recognize maze type from extension (e.g. maze.sm for standard maze)

License
----

GPLv3
