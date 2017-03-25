﻿using System;
using System.Collections.Generic;

namespace MazeChallenge
{
    public class BfsMazeSolver : MazeSolver
    {
        public override void Solve(Maze maze, Action<IEnumerable<Cell>> solvedResultCallback)
        {
            InitializeSolver(maze);
            var nodeQueue = new Queue<Node>(); //Queue that maintains the frontier to the explored.
            var startNode = (Node) GetNode(maze.Start); //Start of the maze as defined by IWalledMaze.
            startNode.Distance = 0;
            startNode.PreviousNode = null;
            startNode.State = State.Visited;
            nodeQueue.Enqueue(startNode);

            while (nodeQueue.Count > 0)
            {
                var curNode = nodeQueue.Dequeue();
#if DEBUG
                foreach (var n in nodeQueue)
                    Console.Write("({0},{1}) ", n.RowIndex + 1, n.ColumnIndex + 1);
                Console.WriteLine();
#endif
                Cell curMazeNode = GetMazeNode(maze, curNode);

                if (maze.IsGoal(curMazeNode)) //Uses the goal defined by the IWalledMaze as terminating point.
                {
                    IEnumerable<Cell> solvedNode = TraceSolvedPath(maze, curNode);
                    solvedResultCallback(solvedNode); //Calls the callback Action and returns.
                    return;
                }
                foreach (Cell adjMazeNode in maze.GetAdjacentCells(curMazeNode))
                {
                    //Just use the x & Y positions from the adjNode and use the internal representation to do comparision.
                    var adjNode = (Node) GetNode(adjMazeNode);
                    if (adjNode.State != State.NotVisited) continue;
                    adjNode.State = State.Visited;
                    adjNode.PreviousNode = curNode;
                    adjNode.Distance = curNode.Distance + 1;
                    nodeQueue.Enqueue(adjNode);
                }
                //curNode.State = NodeState.Visited;
            }
            solvedResultCallback(null); //if it comes this far then no solution found.
        }

        
        public override Algorithm GetAlgorithm()
        {
            return Algorithm.BFS;
        }

    }
}