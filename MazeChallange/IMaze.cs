using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeChallange
{
    interface IMaze
    {
        ICell Start { get; }
        ICell Goal { get;  }
        bool IsGoal(ICell cell);
        IEnumerator<ICell> GetCells();
        ICell GetCell(int rowIndex, int colIndex); 
        void InitMaze();
    }
}
