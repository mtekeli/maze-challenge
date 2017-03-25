using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeChallenge
{
    public enum Algorithm
    {
        BFS = 0,
        DFS = 1
    }

    public class MazeSolutionBuilder
    {
        public MazeSolver BuildMazeSolver(Algorithm algorithm)
        {
            MazeSolver mazeSolver = null;

            switch (algorithm)
            {
                case Algorithm.BFS:
                    mazeSolver = new BfsMazeSolver();
                    break;
                case Algorithm.DFS:
                    mazeSolver = new DfsMazeSolver();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(algorithm), algorithm, null);
            }

            return mazeSolver;
        }

        public MazeSolver BuildMazeSolver(string algorithmId)
        {
            var alg = (Algorithm) ushort.Parse(algorithmId);
            return BuildMazeSolver(alg);
        }
    }
}
