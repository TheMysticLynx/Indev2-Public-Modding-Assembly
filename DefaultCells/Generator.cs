using System.Numerics;

namespace PublicAssembly.DefaultCells
{
    public class Generator : SteppedCell
    {
        public override void Step()
        {
            var directionVector = FacedDirection.ToVector2Int();
            Cell? referenceCell = StateManager.GetCell(Position - directionVector);
            if (referenceCell is null)
                return;


            Cell? targetCell = StateManager.GetCell(Position + directionVector);
            if (targetCell is null || targetCell.Push(this, null, FacedDirection, 1))
            {
                StateManager.CreateCell(referenceCell.GetType(), referenceCell.FacedDirection, Position + directionVector, Position);
            }
        }

        public override string Name => "Generator";
        public override string Description => "Generates cells based off of cell behind it";
        public override string SpriteName => "Generator.png";
    }
}