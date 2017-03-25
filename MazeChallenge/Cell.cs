

namespace MazeChallenge
{
    public abstract class Cell
    {
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }


        protected Cell(int rowIndex, int columnIndex)
        {
            this.RowIndex = rowIndex;
            this.ColumnIndex = columnIndex;
        }

        public override bool Equals(object obj)
        {
            var c = obj as Cell;
            return c != null && c.ColumnIndex == this.ColumnIndex && c.RowIndex == this.RowIndex;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode()+1;
        }

        public abstract bool IsOccupied();
    }
}
