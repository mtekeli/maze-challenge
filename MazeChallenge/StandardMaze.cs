using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MazeChallenge
{
    public sealed class StandardMaze : Maze
    {
        public const string MazeRowsLessThanTwoMessage = "Check your maze data! Rows can not be less than two!";
        public const string MazeRowsMustHaveSameNumberOfCellsMessage = "Check your maze data! Each row must have same number of cells!";
        public const string MazeCanOnlyHaveOneStartPointMessage = "Check your maze data! Maze can only have one start point!";
        public const string MazeCanOnlyHaveOneGoalMessage = "Check your maze data! Maze can only have one goal point!";
        public const string MazeInputNotValidMessage = "Check your maze data! Invalid input!";
        public const string MazeMustHaveStartPointMessage = "Check your maze data! Maze must have a starting point!";
        public const string MazeMustHaveGoalMessage = "Check your maze data! Maze must have a goal point!";

        /// <summary>
        /// Standard maze constructor using path to maze text file
        /// </summary>
        /// <param name="mazeFilePath">Path to maze text file</param>
        public StandardMaze(string mazeFilePath)
        {
            this.MazeFilePath = mazeFilePath;
            InitMaze();
        }

        /// <summary>
        /// Construct the maze.
        /// </summary>
        public override void InitMaze()
        {
            base.InitMaze();

            string[] rows = MazeDataRaw.Split(new[] {Environment.NewLine}, StringSplitOptions.None);

            if (rows.Length < 2)
                throw new InvalidDataException(MazeRowsLessThanTwoMessage);

            int colCount = rows[0].Length;

            Cells = new Cell[rows.Length, colCount];

            for (int i = 0; i < rows.Length; i++) // iterate over the rows
            {
                string row = rows[i];

                if (colCount != row.Length)
                    throw new InvalidDataException(MazeRowsMustHaveSameNumberOfCellsMessage);

                colCount = row.Length;

                for (int j = 0; j < row.Length; j++) // iterate over the cols
                {
                    char c = row[j];
                    switch (c)
                    {
                        case '_':
                            Cells[i, j] = new Node(i, j);
                            break;
                        case 'X':
                            Cells[i, j] = new Wall(i, j);
                            break;
                        case 'S':
                            Cells[i, j] = new Node(i, j);
                            if (Start == null)
                                Start = Cells[i, j];
                            else
                                throw new InvalidDataException(MazeCanOnlyHaveOneStartPointMessage);
                            break;
                        case 'G':
                            Cells[i, j] = new Node(i, j);
                            if (Goal == null)
                                Goal = Cells[i, j];
                            else
                                throw new InvalidDataException(MazeCanOnlyHaveOneGoalMessage);
                            break;
                        default:
                            throw new InvalidDataException(MazeInputNotValidMessage);
                    }
                }
            }
            if (Start == null)
                throw new InvalidDataException(MazeMustHaveStartPointMessage);
            if (Goal == null)
                throw new InvalidDataException(MazeMustHaveGoalMessage);
            Columns = colCount;
            Rows = rows.Length;
            Console.WriteLine("Standard maze read successfully...");
        }

        /// <summary>
        /// Get adjacent cells of current cell in a standard maze.
        /// </summary>
        /// <param name="currCell">Current cell.</param>
        /// <returns>Adjacent cells to the given cell in a standard maze.</returns>
        public override IEnumerable<Cell> GetAdjacentCells(Cell currCell)
        {
            int rowPosition = currCell.RowIndex;
            int colPosition = currCell.ColumnIndex;

            var cells = (List<Cell>) base.GetAdjacentCells(currCell);

            return cells.Where(cell => (cell.RowIndex != rowPosition - 1 || cell.ColumnIndex != colPosition - 1) && (cell.RowIndex != rowPosition - 1 || cell.ColumnIndex != colPosition + 1) && (cell.RowIndex != rowPosition + 1 || cell.ColumnIndex != colPosition - 1) && (cell.RowIndex != rowPosition + 1 || cell.ColumnIndex != colPosition + 1)).ToList();
        }
    }
}
