using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeChallange
{
    interface ICell
    {
        int ColumnIndex { get; } // Column position
        int RowIndex { get; } // Row position
        bool IsOccupied(); // return whether the cell is blocked
    }
}
