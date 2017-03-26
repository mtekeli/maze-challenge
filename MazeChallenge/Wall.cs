

namespace MazeChallenge
{
    internal class Wall : Cell
    {

        public Wall(int rowIndex, int columnIndex) : base(rowIndex, columnIndex) { }

        public override bool IsOccupied()
        {
            return true;
        }
    }
}
