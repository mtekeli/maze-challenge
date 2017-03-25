using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeChallange
{
    public class Cell : ICell
    {
        protected bool _isOccupied = false;
        int _columnIndex = 0; // col index
        int _rowIndex = 0; // row index

        public Cell(int rowIndex, int columnIndex)
        {
            this._rowIndex = rowIndex;
            this._columnIndex = columnIndex;
        }

        public override bool Equals(object obj)
        {
            var c = obj as Cell;
            return c != null && c.ColumnIndex == this._columnIndex && c.RowIndex == this._rowIndex;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int ColumnIndex
        {
            get { return _columnIndex; }
        }

        public int RowIndex
        {
            get { return _rowIndex; }
        }

        public bool IsOccupied()
        {
            return _isOccupied;
        }
    }
}
