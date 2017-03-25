using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MazeChallenge
{
    class Program
    {
        static Stopwatch _swatch = new Stopwatch();
        private static string _algorithmId;
        private static MazeSolver _mazeSolver;

        static void Main(string[] args)
        {
            if (args.Length != 2) //input from command line
            {
                Console.WriteLine("Invalid number of arguments");
                PrintUsage();
                return;
            }

            try
            {
                string mazePath = args[0];
                _algorithmId = args[1];

                Maze maze = new StandardMaze(mazePath);
                var builder = new MazeSolutionBuilder();
                _mazeSolver = builder.BuildMazeSolver(_algorithmId);
                Action<IEnumerable<Cell>> solvedResultCallback = ShowSolution;

                _swatch.Start();
                _mazeSolver.Solve(maze, solvedResultCallback);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
            }

            Console.Read();
        }

        private static void ShowSolution(IEnumerable<Cell> solution)
        {
            _swatch.Stop();
            Console.WriteLine();
            Console.WriteLine("{0} Completed:", _mazeSolver.GetAlgorithm());
            Console.WriteLine("=========");
            if (solution == null)
            {
                Console.WriteLine("No solution found!");
            }
            else
            {
                solution = solution.Reverse();
                foreach (var cell in solution)
                {
                    Console.Write("({0},{1}) ", cell.RowIndex, cell.ColumnIndex);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Process took {0} milliseconds.", _swatch.Elapsed.Milliseconds.ToString());
        }


        static void PrintUsage()
        {
            Console.WriteLine("Usage");
            Console.WriteLine("=====");
            Console.WriteLine("MazeChallange maze.txt [0:BFS,1:DFS]");
            Console.WriteLine();
        }
    }
}
