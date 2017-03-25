using System;
using System.Collections.Generic;

namespace MazeChallenge
{
    public abstract class MazeSolver
    {
        protected Node[,] Nodes { get; set; }
        public abstract void Solve(Maze maze, Action<IEnumerable<Cell>> solvedResultCallback);
        public abstract Algorithm GetAlgorithm();

        protected virtual Cell GetNode(Cell mazeNode)
        {
            return Nodes[mazeNode.RowIndex, mazeNode.ColumnIndex];
        }

        protected virtual Cell GetMazeNode(Maze maze, Cell node)
        {
            return maze.GetCell(node.RowIndex, node.ColumnIndex);
        }

        protected virtual IEnumerable<Cell> TraceSolvedPath(Maze maze, Node endNode)
        {
            Node curNode = endNode;
            ICollection<Cell> pathTrace = new List<Cell>();
            while (curNode != null)
            {
                pathTrace.Add(GetMazeNode(maze, curNode));
                curNode = curNode.PreviousNode;
            }
            return pathTrace;
        }

        protected virtual void InitializeSolver(Maze maze)
        {
            Nodes = new Node[maze.Rows, maze.Columns];
            var mazeNodes = maze.GetCells();
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
