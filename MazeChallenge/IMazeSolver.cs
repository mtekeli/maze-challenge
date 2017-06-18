using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeChallenge
{
    public interface IMazeSolver
    {
        /// <summary>
        /// Run the solver algorithm.
        /// </summary>
        /// <param name="solvedResultCallback">Callback function to be notified when algorithm is finished.
        /// Note that this function returns null if no solution is found.</param>
        void Solve(Action<IEnumerable<Cell>> solvedResultCallback);


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Algorithm GetAlgorithm();
    }


}
