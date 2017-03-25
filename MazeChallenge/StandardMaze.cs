using System;
using System.IO;

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

        public StandardMaze(string mazeFilePath)
        {
            this.MazeFilePath = mazeFilePath;
            InitMaze();
        }

        public override void InitMaze()
        {
            if (!File.Exists(MazeFilePath))
                throw new FileNotFoundException("File not found!", MazeFilePath);

            String line;
            // Open the text file using a stream reader.
            using (StreamReader sr = new StreamReader(MazeFilePath))
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
            Console.WriteLine("Maze read successfully...");
        }

    }

}
