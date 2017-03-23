using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeChallange
{
    abstract class Maze : IMaze
    {
        public abstract int Columns { get; }
        public abstract int Rows { get; }

        public abstract ICell Start { get; }

        public abstract ICell Goal { get; }

        protected Cell[,] _cells = null;
        protected int _columns = 0;
        protected int _rows = 0;
        protected string _mazeFilePath;
        protected Cell _start = null;
        protected Cell _goal = null;

        public IEnumerable<ICell> GetAdjacentCells(ICell currCell)
        {
            int rowPosition = currCell.RowIndex;
            int colPosition = currCell.ColumnIndex;

            if (rowPosition < 0 || rowPosition >= Rows || colPosition < 0 || colPosition >= Columns) //if given node is out of bounds return a empty list as adjacents.
                return new List<ICell>(0);

            List<ICell> adjacents = new List<ICell>(8);
            for (int i = rowPosition - 1; i <= rowPosition + 1; i++)
            {
                for (int j = colPosition - 1; j <= colPosition + 1; j++)
                {
                    if (i < 0 || i >= Rows || j < 0 || j >= Columns || (i == rowPosition && j == colPosition))//eliminates out of bounds from being sent as adjacents.
                        continue;
                    if ((i == rowPosition - 1 && j == colPosition - 1) || (i == rowPosition - 1 && j == colPosition + 1)
                         || (i == rowPosition + 1 && j == colPosition - 1) || (i == rowPosition + 1 && j == colPosition + 1))
                        continue;
                    adjacents.Add(_cells[i, j]);
                }
            }
            return adjacents;
        }

        public bool IsGoal(ICell cell)
        {
            if (cell.RowIndex == 3 && cell.ColumnIndex == 4)
            {
                Console.WriteLine("");
            }
            return cell != null & cell.Equals(_goal);
        }

        public IEnumerator<ICell> GetCells()
        {
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    yield return _cells[i, j];
        }

        public ICell GetCell(int rowIndex, int colIndex)
        {
            if (rowIndex < 0 || rowIndex >= _rows || colIndex < 0 || colIndex >= _columns)
                throw new ArgumentException("Requested cell positon is out of bounds!");
            return _cells[rowIndex, colIndex];
        }

        public abstract void InitMaze();
    }
}
