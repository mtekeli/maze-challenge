using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeChallange
{
    class Program
    {
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
                });
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
            }

            Console.Read();
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
