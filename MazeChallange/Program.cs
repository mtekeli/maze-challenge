using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MazeChallange
{
    class Program
    {
        static Stopwatch swatch = new Stopwatch();
        static void Main(string[] args)
        {
            if (args.Length != 2)//input from command line
            {
                Console.WriteLine("Invalid number of arguments");
                PrintUsage();
                return;
            }

            string mazePath = args[0];
            string algorithm = args[1];

            try
            {
                ETravelMaze maze = new ETravelMaze(mazePath);

                IMazeSolver bfsSolver = new BFSMazeSolver();
                Action<IEnumerable<ICell>> SolvedResultCallback = ShowSolution;
                /*
                bfsSolver.Solve(maze, (solvedPath) => //callback defines action to perform after the maze is solved.
                {
                    Console.WriteLine();
                    Console.WriteLine("Completed:");
                    Console.WriteLine("=========");
                    if (solvedPath != null)
                    {
                        solvedPath = solvedPath.Reverse();
                        foreach (var cell in solvedPath)
                        {
                            Console.Write(String.Format("({0},{1}) ", cell.RowIndex+1, cell.ColumnIndex+1));
                        }
                        Console.WriteLine();
                    }
                });*/
                swatch.Start();
                bfsSolver.Solve(maze, SolvedResultCallback);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
            }

            Console.Read();
        }

        static void ShowSolution(IEnumerable<ICell> solution)
        {
            swatch.Stop();
            Console.WriteLine();
            Console.WriteLine("Completed:");
            Console.WriteLine("=========");
            if (solution == null)
            {
                Console.WriteLine("No solution found!");
            }else
            {
                solution = solution.Reverse();
                foreach (var cell in solution)
                {
                    Console.Write(String.Format("({0},{1}) ", cell.RowIndex + 1, cell.ColumnIndex + 1));
                }
                Console.WriteLine();
            }
            Console.WriteLine("Process took {0} milliseconds.", swatch.Elapsed.Milliseconds.ToString());
        }


        static void PrintUsage()
        {
            Console.WriteLine("Usage");
            Console.WriteLine("=====");
            Console.WriteLine("MazeChallange maze.txt Algorithm:[BFS,DFS]");
            Console.WriteLine();
        }
    }
}
