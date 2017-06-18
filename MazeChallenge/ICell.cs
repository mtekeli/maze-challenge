using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeChallenge
{
    interface ICell
    {
        /// <summary>
        /// Get hash code for this cell.
        /// </summary>
        /// <returns>A hash code for the current cell.</returns>
        int GetHashCode();

        /// <summary>
        /// Returns whether this cell is blocked or not.
        /// </summary>
        /// <returns>True if the cell is blocked, false otherwise.</returns>
        bool IsOccupied();
    }
}
