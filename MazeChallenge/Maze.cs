using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeChallenge;

namespace MazeChallenge
{
    public abstract class Maze
    { 
        public int Columns { get; protected set; }
        public int Rows { get; protected set; }
        public Cell Start { get; protected set; }
        public Cell Goal { get; protected set; }

        public abstract void InitMaze();

        protected Cell[,] Cells = null;
        protected string MazeFilePath;

        public IEnumerable<Cell> GetAdjacentCells(Cell currCell)
        {
            int rowPosition = currCell.RowIndex;
            int colPosition = currCell.ColumnIndex;

            if (rowPosition < 0 || rowPosition >= Rows || colPosition < 0 || colPosition >= Columns) //if given node is out of bounds return a empty list as adjacents.
                return new List<Cell>(0);

            List<Cell> adjacents = new List<Cell>(8);
            for (int i = rowPosition - 1; i <= rowPosition + 1; i++)
            {
                for (int j = colPosition - 1; j <= colPosition + 1; j++)
                {
                    if (i < 0 || i >= Rows || j < 0 || j >= Columns || (i == rowPosition && j == colPosition))//eliminates out of bounds from being sent as adjacents.
                        continue;
                    if ((i == rowPosition - 1 && j == colPosition - 1) || (i == rowPosition - 1 && j == colPosition + 1)
                         || (i == rowPosition + 1 && j == colPosition - 1) || (i == rowPosition + 1 && j == colPosition + 1))
                        continue;
                    adjacents.Add(Cells[i, j]);
                }
            }
            return adjacents;
        }

        public bool IsGoal(Cell cell)
        {
            return cell != null && cell.Equals(Goal);
        }

        public IEnumerator<Cell> GetCells()
        {
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    yield return Cells[i, j];
        }

        public Cell GetCell(int rowIndex, int colIndex)
        {
            if (rowIndex < 0 || rowIndex >= Rows || colIndex < 0 || colIndex >= Columns)
                throw new ArgumentException("Requested cell positon is out of bounds!");
            return Cells[rowIndex, colIndex];
        }

    }
}
