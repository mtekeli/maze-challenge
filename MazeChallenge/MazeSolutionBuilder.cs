using System;

namespace MazeChallenge
{
    /// <summary>
    /// Supported solver algorithms for the maze.
    /// </summary>
    public enum Algorithm
    {
        Bfs = 0, // Breadth First Search
        Dfs = 1 // Depth First Search
    }

    public class MazeSolutionBuilder
    {
        /// <summary>
        /// Create a maze solver for the given Algorithm. See Algorithm enum for the supported algorithms.
        /// </summary>
        /// <param name="maze">Maze to get the solution for.</param>
        /// <param name="algorithm">Algorithm to use for solution.</param>
        /// <returns>Returns MazeSolver to run the solution</returns>
        public MazeSolver BuildMazeSolver(Maze maze, Algorithm algorithm)
        {
            MazeSolver mazeSolver = null;

            switch (algorithm)
            {
                case Algorithm.Bfs:
                    mazeSolver = new BfsMazeSolver(maze);
                    break;
                case Algorithm.Dfs:
                    mazeSolver = new DfsMazeSolver(maze);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(algorithm), algorithm, null);
            }

            return mazeSolver;
        }

        /// <summary>
        /// Create a maze solver for the given algorithm id. See Algorithm enum for the supported algorithms.
        /// </summary>
        /// <param name="maze">Maze to get the solution for.</param>
        /// <param name="algorithmId">Algorithm id to use for solution.</param>
        /// <returns>Returns MazeSolver to run the solution</returns>
        public MazeSolver BuildMazeSolver(Maze maze, string algorithmId)
        {
            var alg = (Algorithm) ushort.Parse(algorithmId);
            return BuildMazeSolver(maze, alg);
        }
    }
}
