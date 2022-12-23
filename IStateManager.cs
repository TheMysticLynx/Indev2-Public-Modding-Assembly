using System;
using JetBrains.Annotations;
using UnityEngine;

namespace PublicAssembly
{
    public interface IStateManager
    {
        public Vector2Int Size { get; }
        public Cell? GetCell(Vector2Int position);
        public Cell? GetCell(int x, int y);
        public Cell? CreateCell(Type type, Direction direction, Vector2Int position, Vector2Int? visualStartingPosition = null);
        public void DeleteCell(Vector2Int position);
        public void DeleteCell(Cell cell);

        public bool InBounds(Vector2Int vector2Int);
    }
}