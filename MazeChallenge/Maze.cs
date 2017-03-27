using System;
using System.Collections.Generic;
using System.IO;

namespace MazeChallenge
{
    public abstract class Maze
    { 
        public int Columns { get; protected set; }
        public int Rows { get; protected set; }
        public Cell Start { get; protected set; }
        public Cell Goal { get; protected set; }

        protected Cell[,] Cells = null;
        protected string MazeFilePath;
        protected string MazeDataRaw;

        /// <summary>
        /// Read the maze from file input.
        /// </summary>
        public virtual void InitMaze()
        {
            if (!File.Exists(MazeFilePath))
                throw new FileNotFoundException("File not found!", MazeFilePath);

            // Open the text file using a stream reader.
            using (var sr = new StreamReader(MazeFilePath))
            {
                // Read the stream to a string
                MazeDataRaw = sr.ReadToEnd();
            }

            // Write the string to the console.
            Console.WriteLine("Maze input:");
            Console.WriteLine(MazeDataRaw);

        }

        /// <summary>
        /// Get adjacent cells to the current cell.
        /// </summary>
        /// <param name="currCell">Current cell.</param>
        /// <returns>Adjacent cells to the given cell.</returns>
        public virtual IEnumerable<Cell> GetAdjacentCells(Cell currCell)
        {
            int rowPosition = currCell.RowIndex;
            int colPosition = currCell.ColumnIndex;

            if (rowPosition < 0 || rowPosition >= Rows || colPosition < 0 || colPosition >= Columns) //if given node is out of bounds return an empty list as adjacents.
                return new List<Cell>(0);

            var adjacents = new List<Cell>(8);
            for (var i = rowPosition - 1; i <= rowPosition + 1; i++)
            {
                for (var j = colPosition - 1; j <= colPosition + 1; j++)
                {
                    if (i < 0 || i >= Rows || j < 0 || j >= Columns || (i == rowPosition && j == colPosition))//eliminates out of bounds from being sent as adjacents.
                        continue;
                    adjacents.Add(Cells[i, j]);
                }
            }
            return adjacents;
        }

        /// <summary>
        /// Returns if goal is reached.
        /// </summary>
        /// <param name="cell">Current cell.</param>
        /// <returns>True if goal is reached, false otherwise.</returns>
        public bool IsGoal(Cell cell)
        {
            return cell != null && cell.Equals(Goal);
        }

        /// <summary>
        /// Returns all cells in maze.
        /// </summary>
        /// <returns>List of cells.</returns>
        public IEnumerator<Cell> GetCells()
        {
            for (var i = 0; i < Rows; i++)
                for (var j = 0; j < Columns; j++)
                    yield return Cells[i, j];
        }

        /// <summary>
        /// Returns a single cell by a given row and column index.
        /// </summary>
        /// <param name="rowIndex">Zero based row index of the cell to be returned.</param>
        /// <param name="colIndex">Zero based column index of the cell to be returned.</param>
        /// <returns>Corresponding cell by the given row and column index.</returns>
        public Cell GetCell(int rowIndex, int colIndex)
        {
            if (rowIndex < 0 || rowIndex >= Rows || colIndex < 0 || colIndex >= Columns)
                throw new ArgumentException("Requested cell positon is out of bounds!");
            return Cells[rowIndex, colIndex];
        }

    }
}
