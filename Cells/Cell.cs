using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace PublicAssembly
{
    public abstract class Cell : MonoBehaviour
    {
        public LinkedListNode<Cell> LinkedListNode { get; set; }
        private Vector2Int _position;
        private Direction _facedDirection;
        private int _rotation;

        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract string SpriteName { get; }

        public LinkedListNode<Cell> Node { get; set; }
        public Vector2Int Position
        {
            get => _position;
            set
            {
                var oldPosition = _position;
                _position = value;
                PositionChanged?.Invoke(value, _position);
            }
        }
        // Cached direction from _rotation
        public Direction FacedDirection
        {
            get => _facedDirection;
            private set
            {
                _facedDirection = value;
                DirectionChanged?.Invoke(value);
            }
        }
        public int Rotation
        {
            get => _rotation;
            private set
            {
                _rotation = value;
                FacedDirection = DirectionHelpers.FromInt(value);
            }
        }

        public IStateManager StateManager { get; private set; }

        public event Action<Vector2Int, Vector2Int>? PositionChanged;
        public event Action<Direction>? DirectionChanged;

        public bool Push(Direction? direction = null)
        {
            direction ??= FacedDirection;
            return Push(this, this, (Direction)direction, 1);
        }

        public virtual bool Push(Cell? originalCaller, Cell? lastCaller, Direction direction, int bias)
        {
            Vector2Int target = Position + direction.ToVector2Int();
            if (originalCaller == this && lastCaller != this)
            {
                Position = target;
            }

            if (!StateManager.InBounds(target))
                return false;

            var cell = StateManager.GetCell(target);
            if (cell is not null)
            {
                bool success = cell.Push(originalCaller, this, _facedDirection, bias);
                if(success)
                    Position = target;
                return success;
            }

            Position = target;
            return true;
        }

        public virtual void Rotate(int amount)
        {
            Rotation += amount;
        }

        public virtual void SetRotation(Direction direction)
        {
            Rotation = (int)direction;
        }

        public virtual void SetRotation(int rotation)
        {
            Rotation = rotation;
        }

        public void SetStateManager(IStateManager stateManager)
        {
            StateManager = stateManager;
        }

        public void UpdatePosition(float animationTime)
        {
            StopAllCoroutines();
            StartCoroutine(UpdatePositionCoroutine(animationTime));
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        private IEnumerator UpdatePositionCoroutine(float animationTime)
        {
            Vector2 target = Position;
            Vector2 start = transform.position;
            var startingAngle = transform.rotation;
            var endingAngle = Quaternion.Euler(0, 0, Rotation * -90);
            float time = 0;
            while (time < animationTime)
            {
                time += Time.deltaTime;
                transform.position = Vector2.Lerp(start, target, time / animationTime);
                transform.rotation = Quaternion.Lerp(startingAngle, endingAngle, time / animationTime);
                yield return null;
            }
            transform.position = target;
        }
    }
}