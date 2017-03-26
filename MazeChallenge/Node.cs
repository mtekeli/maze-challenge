using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeChallenge
{
    /// <summary>
    /// State options for the nodes
    /// </summary>
    public enum State
    {
        NotVisited = 0,
        Visited = 1,
    }

    public class Node : Cell
    {
        public Node(int rowIndex, int columnIndex) : base(rowIndex, columnIndex)
        {
        }

        public override bool IsOccupied()
        {
            return false;
        }

        public int Distance { get; set; }
        public Node PreviousNode { get; set; }
        public State State { get; set; }
    }
}
