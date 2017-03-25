using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeChallange
{
    public class ETravelMaze : Maze
    {
        public const string MazeRowsLessThanTwoMessage = "Check your maze data! Rows can not be less than two!";
        public const string MazeRowsMustHaveSameNumberOfCellsMessage = "Check your maze data! Each row must have same number of cells!";
        public const string MazeCanOnlyHaveOneStartPointMessage = "Check your maze data! Maze can only have one start point!";
        public const string MazeCanOnlyHaveOneGoalMessage = "Check your maze data! Maze can only have one goal point!";
        public const string MazeInputNotValidMessage = "Check your maze data! Invalid input!";
        public const string MazeMustHaveStartPointMessage = "Check your maze data! Maze must have a starting point!";
        public const string MazeMustHaveGoalMessage = "Check your maze data! Maze must have a goal point!";

        public ETravelMaze(string mazeFilePath)
        {
            this._mazeFilePath = mazeFilePath;
            InitMaze();
        }

        public override int Columns
        {
            get { return _columns; }
        }

        public override int Rows
        {
            get { return _rows; }
        }

        public override ICell Start
        {
            get { return _start; }
        }

        public override ICell Goal
        {
            get { return _goal; }
        }

        public override void InitMaze()
        {
            if (!File.Exists(_mazeFilePath))
                throw new FileNotFoundException("File not found!", _mazeFilePath);

            String line;
            // Open the text file using a stream reader.
            using (StreamReader sr = new StreamReader(_mazeFilePath))
            {
                // Read the stream to a string, and write the string to the console.
                line = sr.ReadToEnd();
            }

            Console.WriteLine("Maze input:");
            Console.WriteLine(line);

            string[] rows = line.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            if (rows.Length < 2)
                throw new InvalidDataException(MazeRowsLessThanTwoMessage);

            int colCount = rows[0].Length;

            _cells = new Cell[rows.Length, colCount];

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
                            _cells[i, j] = new Cell(i, j);
                            break;
                        case 'X':
                            _cells[i, j] = new Wall(i, j);
                            break;
                        case 'S':
                            _cells[i, j] = new Cell(i, j);
                            if (_start == null)
                                _start = _cells[i, j];
                            else
                                throw new InvalidDataException(MazeCanOnlyHaveOneStartPointMessage);
                            break;
                        case 'G':
                            _cells[i, j] = new Cell(i, j);
                            if (_goal == null)
                                _goal = _cells[i, j];
                            else
                                throw new InvalidDataException(MazeCanOnlyHaveOneGoalMessage);
                            break;
                        default:
                            throw new InvalidDataException(MazeInputNotValidMessage);
                    }
                }
            }
            if (_start == null)
                throw new InvalidDataException(MazeMustHaveStartPointMessage);
            if (_goal == null)
                throw new InvalidDataException(MazeMustHaveGoalMessage);
            _columns = colCount;
            _rows = rows.Length;
            Console.WriteLine("Maze read successfully...");
        }

    }

}
