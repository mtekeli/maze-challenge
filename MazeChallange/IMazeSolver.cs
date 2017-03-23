using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeChallange
{
    interface IMazeSolver
    {
        void Solve(Maze maze, Action<IEnumerable<ICell>> solvedResultCallback);
    }
}
