using System;
using System.Collections.Generic;

namespace MazeChallenge
{
    public class BfsMazeSolver : MazeSolver
    {
        public BfsMazeSolver(Maze maze) : base(maze)
        {
        }

        public override void Solve(Action<IEnumerable<Cell>> solvedResultCallback)
        {
            var nodeQueue = new Queue<Node>(); //Queue that holds the nodes
            var startNode = (Node) GetNode(Maze.Start); // Start of the maze
            startNode.Distance = 0;
            startNode.PreviousNode = null;
            startNode.State = State.Visited; // Start node is already visited
            nodeQueue.Enqueue(startNode);

            while (nodeQueue.Count > 0)
            {
                var curNode = nodeQueue.Dequeue();
#if DEBUG
                foreach (var n in nodeQueue)
                    Console.Write("({0},{1}) ", n.RowIndex + 1, n.ColumnIndex + 1);
                Console.WriteLine();
#endif
                //Cell curMazeCell = GetMazeCell(Maze, curNode);

                if (Maze.IsGoal(curNode)) // Check if we have the solution
                {
                    IEnumerable<Cell> solvedNode = TraceSolvedPath(Maze, curNode);
                    solvedResultCallback(solvedNode); //Notify the solution
                    return;
                }
                foreach (Cell adjMazeNode in Maze.GetAdjacentCells(curNode))
                {
                    // Explore child nodes
                    var adjNode = (Node) GetNode(adjMazeNode);
                    if (adjNode.State != State.NotVisited) continue;
                    adjNode.State = State.Visited;
                    adjNode.PreviousNode = curNode;
                    adjNode.Distance = curNode.Distance + 1;
                    nodeQueue.Enqueue(adjNode);
                }
            }
            solvedResultCallback(null); //if it comes this far then no solution found.
        }


        public override Algorithm GetAlgorithm()
        {
            return Algorithm.Bfs;
        }
    }
}
