using System;
using System.Collections.Generic;

namespace MazeChallenge
{
    public abstract class MazeSolver
    {
        protected MazeSolver(Maze maze)
        {
            this.Maze = maze;
            InitializeSolver();
        }

        /// <summary>
        /// Maze to run the solver on.
        /// </summary>
        protected Maze Maze { get; set; }

        /// <summary>
        /// Array to hold the nodes of a maze.
        /// </summary>
        protected Node[,] Nodes { get; set; }

        /// <summary>
        /// Run the solver algorithm.
        /// </summary>
        /// <param name="solvedResultCallback">Callback function to be notified when algorithm is finished.
        /// Note that this function returns null if no solution is found.</param>
        public abstract void Solve(Action<IEnumerable<Cell>> solvedResultCallback);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract Algorithm GetAlgorithm();

        /// <summary>
        /// Get corresponding node by the given cell.
        /// </summary>
        /// <param name="mazeNode"></param>
        /// <returns>Node by the given cell.</returns>
        protected virtual Cell GetNode(Cell mazeNode)
        {
            return Nodes[mazeNode.RowIndex, mazeNode.ColumnIndex];
        }

        /// <summary>
        /// Get the travelled path from the start to the end node.
        /// </summary>
        /// <param name="maze">Maze to get the trace from.</param>
        /// <param name="endNode">End node to get the trace for.</param>
        /// <returns>Trace of the path traveled.</returns>
        protected virtual IEnumerable<Cell> TraceSolvedPath(Maze maze, Node endNode)
        {
            var curNode = endNode;
            ICollection<Cell> pathTrace = new List<Cell>();
            while (curNode != null)
            {
                //pathTrace.Add(GetMazeCell(maze, curNode));
                pathTrace.Add(curNode);
                curNode = curNode.PreviousNode;
            }
            return pathTrace;
        }

        /// <summary>
        /// Initializes the solver. Prepares the walls and available paths.
        /// </summary>
        private void InitializeSolver()
        {
            Nodes = new Node[Maze.Rows, Maze.Columns];
            var mazeNodes = Maze.GetCells();
            while (mazeNodes.MoveNext())
            {
                var mazeNode = mazeNodes.Current;
                if (mazeNode.IsOccupied()) // WALL. Simply mark it as visited.
                    Nodes[mazeNode.RowIndex, mazeNode.ColumnIndex] = new Node(mazeNode.RowIndex, mazeNode.ColumnIndex)
                    {
                        State = State.Visited,
                        Distance = int.MaxValue
                    };
                else
                    Nodes[mazeNode.RowIndex, mazeNode.ColumnIndex] = new Node(mazeNode.RowIndex, mazeNode.ColumnIndex)
                    {
                        State = State.NotVisited,
                        Distance = int.MaxValue
                    };
            }
        }
    }
}
