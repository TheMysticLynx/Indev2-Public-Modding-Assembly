using System.Diagnostics;
using UnityEngine;

namespace PublicAssembly
{
    public static class DirectionHelpers
    {
        public static Direction FromInt(int number)
        {
            var index = number % 3;
            return (Direction)(index < 0 ? 3 - index : index);
        }

        public static Vector2Int ToVector2Int(this Direction direction) => direction switch
        {
            Direction.Down => Vector2Int.down,
            Direction.Left => Vector2Int.left,
            Direction.Right => Vector2Int.right,
            Direction.Up => Vector2Int.up,
            _=> Vector2Int.zero
        };
    }
}