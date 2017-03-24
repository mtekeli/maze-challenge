using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeChallange
{

    class BFSMazeSolver : IMazeSolver
    {
        enum BFSNodeState
        {
            NotVisited = 0,
            Visited = 1,
            Queued = 2,
        }

        class BFSNode
        {
            public int ColumnIndex { get; set; }
            public int RowIndex { get; set; }
            public BFSNodeState State { get; set; }
            public int Distance { get; set; }
            public BFSNode PreviousNode { get; set; }

            public BFSNode(int rowIndex, int columnIndex)
            {
                this.RowIndex = rowIndex;
                this.ColumnIndex = columnIndex;
            }
        }

        BFSNode[,] _bfsNodes = null;

        public void Solve(Maze maze, Action<IEnumerable<ICell>> solvedResultCallback)
        {
            InitializeSolver(maze);
            Queue<BFSNode> frontierQueue = new Queue<BFSNode>();//Queue that maintains the frontier to the explored.
            BFSNode startNode = GetBFSNode(maze.Start);//Start of the maze as defined by IWalledMaze.
            startNode.Distance = 0;
            startNode.PreviousNode = null;
            startNode.State = BFSNodeState.Queued;
            frontierQueue.Enqueue(startNode);

            while (frontierQueue.Count > 0)
            {
                BFSNode curBFSNode = frontierQueue.Dequeue();
               
                //foreach (BFSNode n in frontierQueue)
                //    Console.Write(String.Format("({0},{1}) ", n.RowIndex+1, n.ColumnIndex+1));
                //Console.WriteLine();
                ICell curMazeNode = GetMazeNode(maze, curBFSNode);

                if (maze.IsGoal(curMazeNode))//Uses the goal defined by the IWalledMaze as terminating point.
                {
                    IEnumerable<ICell> solvedPath = TraceSolvedPath(maze, curBFSNode);
                    solvedResultCallback(solvedPath);//Calls the callback Action and returns.
                    return;
                }
                foreach (ICell adjMazeNode in maze.GetAdjacentCells(curMazeNode))
                {
                    //Just use the x & Y positions from the adjNode and use the internal representation to do comparision.
                    BFSNode adjBFSNode = GetBFSNode(adjMazeNode);
                    if (adjBFSNode.State == BFSNodeState.NotVisited)
                    {
                        adjBFSNode.State = BFSNodeState.Queued;
                        adjBFSNode.PreviousNode = curBFSNode;
                        adjBFSNode.Distance = curBFSNode.Distance + 1;
                        frontierQueue.Enqueue(adjBFSNode);
                    }
                }
                curBFSNode.State = BFSNodeState.Visited;//In BFS this is marked by the color BLACK
            }
            solvedResultCallback(null); //if it comes this far then no solution found.
        }

        private void InitializeSolver(Maze maze)
        {
            _bfsNodes = new BFSNode[maze.Rows, maze.Columns];
            IEnumerator<ICell> mazeNodes = maze.GetCells();
            while (mazeNodes.MoveNext())
            {
                ICell mazeNode = mazeNodes.Current;
                if (mazeNode.IsOccupied()) // WALL. Simply mark it as visited.
                    _bfsNodes[mazeNode.RowIndex, mazeNode.ColumnIndex] = new BFSNode(mazeNode.RowIndex, mazeNode.ColumnIndex) { State = BFSNodeState.Visited, Distance = int.MaxValue };
                else
                    _bfsNodes[mazeNode.RowIndex, mazeNode.ColumnIndex] = new BFSNode(mazeNode.RowIndex, mazeNode.ColumnIndex) { State = BFSNodeState.NotVisited, Distance = int.MaxValue };
            }
        }

        private IEnumerable<ICell> TraceSolvedPath(IMaze maze, BFSNode endNode)
        {
            BFSNode curNode = endNode;
            ICollection<ICell> pathTrace = new List<ICell>();
            while (curNode != null)
            {
                pathTrace.Add(GetMazeNode(maze, curNode));
                curNode = curNode.PreviousNode;
            }
            return pathTrace;
        }

        private BFSNode GetBFSNode(ICell mazeNode)
        {
            return _bfsNodes[mazeNode.RowIndex, mazeNode.ColumnIndex]; 
        }

        private ICell GetMazeNode(IMaze maze, BFSNode bfsNode)
        {
            return maze.GetCell(bfsNode.RowIndex, bfsNode.ColumnIndex);//Both BFS and Maze node have positional relationship.
        }
    }
}
