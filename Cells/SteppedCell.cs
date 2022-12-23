using System;

namespace PublicAssembly
{
    public abstract class SteppedCell : Cell, IComparable<SteppedCell>
    {
        private int _distanceFromCellWall;
        public abstract void Step();
        public void CacheDistanceFromCellWall()
        {
            _distanceFromCellWall = FacedDirection switch
            {
                Direction.Right => StateManager.Size.x - 1 - (Position.x),
                Direction.Left => StateManager.Size.y - 1 - Position.y,
                Direction.Up => Position.y,
                Direction.Down => Position.x,
                _ => _distanceFromCellWall
            };
        }

        public int CompareTo(SteppedCell other)
        {
            return _distanceFromCellWall.CompareTo(other._distanceFromCellWall);
        }
    }
}