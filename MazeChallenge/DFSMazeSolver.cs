using System;
using System.Collections.Generic;

namespace MazeChallenge
{
    public class DfsMazeSolver : MazeSolver
    {
        public DfsMazeSolver(Maze maze) : base(maze)
        {
        }

        public override void Solve(Action<IEnumerable<Cell>> solvedResultCallback)
        {
            var nodeStack = new Stack<Node>();
            var startNode = (Node) GetNode(Maze.Start); //Start of the maze as defined by IWalledMaze.
            startNode.Distance = 0;
            startNode.PreviousNode = null;
            startNode.State = State.Visited;
            nodeStack.Push(startNode);

            while (nodeStack.Count > 0)
            {
                var curNode = nodeStack.Peek();

                if (Maze.IsGoal(curNode)) // Check if we have the solution
                {
                    IEnumerable<Cell> solvedPath = TraceSolvedPath(Maze, curNode);
                    solvedResultCallback(solvedPath); //Notify the solution
                    return;
                }
                var hasUnvisitedChild = false;
                foreach (var adjMazeNode in Maze.GetAdjacentCells(curNode))
                {
                    // Explore child nodes
                    var adjNode = (Node) GetNode(adjMazeNode);
                    if (adjNode.State != State.NotVisited) continue;
                    hasUnvisitedChild = true;
                    adjNode.State = State.Visited;
                    adjNode.PreviousNode = curNode;
                    adjNode.Distance = curNode.Distance + 1;
                    nodeStack.Push(adjNode);
                    break;
                }
                if (!hasUnvisitedChild)
                    nodeStack.Pop();
            }
            solvedResultCallback(null); //if it comes this far then no solution found.
        }

        public override Algorithm GetAlgorithm()
        {
            return Algorithm.Dfs;
        }
    }
}
