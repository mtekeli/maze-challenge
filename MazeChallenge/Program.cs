using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MazeChallenge
{
    class Program
    {
        static Stopwatch _swatch = new Stopwatch();
        private static MazeSolver _mazeSolver;

        static void Main(string[] args)
        {
            if (args.Length != 2) //argument check
            {
                Console.WriteLine("Invalid number of arguments");
                PrintUsage();
                return;
            }

            try
            {
                string mazePath = args[0]; // Path to the maze text file
                string algorithmId = args[1]; // Algorithm id. 0: BFS, 1: DFS

                Maze maze = new StandardMaze(mazePath); // New standard maze
                var builder = new MazeSolutionBuilder(); // MazeSolution Factory
                _mazeSolver = builder.BuildMazeSolver(maze, algorithmId); 

                _swatch.Start(); // start watch
                _mazeSolver.Solve(ShowSolution); // run algorithm
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
            }

            Console.Read(); // Wait until user inputs a key
        }

        /// <summary>
        /// Prints solution result triggered by the MazeSolver.
        /// </summary>
        /// <param name="solution">Solution for the maze.</param>
        private static void ShowSolution(IEnumerable<Cell> solution)
        {
            _swatch.Stop();
            Console.WriteLine("{0} Completed:", _mazeSolver.GetAlgorithm());
            if (solution == null)
            {
                Console.WriteLine("No solution found!");
            }
            else
            {
                solution = solution.Reverse(); // Reverse the nodes so that they start from Start -> Goal
                // Print solution
                foreach (var cell in solution)
                {
                    Console.Write("({0},{1}) ", cell.RowIndex+1, cell.ColumnIndex+1);
                }
            }
            Console.WriteLine("\nProcess took {0} milliseconds.", _swatch.Elapsed.Milliseconds.ToString());
        }

        /// <summary>
        /// Print usage information.
        /// </summary>
        static void PrintUsage()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("MazeChallange maze.txt [0:BFS,1:DFS]");
            Console.WriteLine();
        }
    }
}
