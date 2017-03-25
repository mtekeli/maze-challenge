using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeChallange
{
    class Wall : Cell
    {
        public Wall(int rowIndex, int columnIndex) : base(rowIndex, columnIndex)
        {
            _isOccupied = true;
        }
    }
}
