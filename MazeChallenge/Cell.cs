

using System;

namespace MazeChallenge
{
    public abstract class Cell : ICell
    {
        /// <summary>
        /// Constructor for a maze cell.
        /// </summary>
        /// <param name="rowIndex">Zero based row index of the cell in a maze.</param>
        /// <param name="columnIndex">Zero based column index of the cell in a maze.</param>
        protected Cell(int rowIndex, int columnIndex)
        {
            this.RowIndex = rowIndex;
            this.ColumnIndex = columnIndex;
        }

        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }

        /// <summary>
        /// Compares given cell with this cell.
        /// </summary>
        /// <param name="obj">Cell to compare.</param>
        /// <returns>Returns true if both cells are from the same position in a maze, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            var c = obj as Cell;
            return c != null && c.ColumnIndex == this.ColumnIndex && c.RowIndex == this.RowIndex;
        }

        /// <summary>
        /// Get hash code for this cell.
        /// </summary>
        /// <returns>A hash code for the current cell.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode()+1;
        }

        public abstract bool IsOccupied();
    }
}
