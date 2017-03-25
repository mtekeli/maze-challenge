using System;
using System.Collections.Generic;

namespace MazeChallenge
{
    public class DfsMazeSolver : MazeSolver
    {
        public override void Solve(Maze maze, Action<IEnumerable<Cell>> solvedResultCallback)
        {
            InitializeSolver(maze);
            var nodeStack = new Stack<Node>();
            var startNode = (Node) GetNode(maze.Start); //Start of the maze as defined by IWalledMaze.
            startNode.Distance = 0;
            startNode.PreviousNode = null;
            startNode.State = State.Visited;
            nodeStack.Push(startNode);

            while (nodeStack.Count > 0)
            {
                var curNode = nodeStack.Peek();

#if DEBUG
                foreach (var n in nodeStack)
                    Console.Write("({0},{1}) ", n.RowIndex + 1, n.ColumnIndex + 1);
                Console.WriteLine();
#endif

                Cell curMazeNode = GetMazeNode(maze, curNode);

                if (maze.IsGoal(curMazeNode)) //Uses the goal defined by the IWalledMaze as terminating point.
                {
                    IEnumerable<Cell> solvedPath = TraceSolvedPath(maze, curNode);
                    solvedResultCallback(solvedPath); //Calls the callback Action and returns.
                    return;
                }
                bool hasUnvisitedChild = false;
                foreach (Cell adjMazeNode in maze.GetAdjacentCells(curMazeNode))
                {
                    //Just use the x & Y positions from the adjNode and use the internal representation to do comparision.
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
                //curNode.State = NodeState.Visited;
            }
            solvedResultCallback(null); //if it comes this far then no solution found.
        }

        public override Algorithm GetAlgorithm()
        {
            return Algorithm.DFS;
        }
    }
}
