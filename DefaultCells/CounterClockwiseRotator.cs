namespace PublicAssembly.DefaultCells
{
    public class CounterClockwiseRotator : TickedCell
    {
        public override string Name => "Counter-Clockwise Rotator";
        public override string Description => "Rotates the cell counter-clockwise.";
        public override string SpriteName => "CounterClockwiseRotator.png";
        public override void Tick()
        {
            for (int i = 0; i < 3; i++)
            {
                Cell? cell = StateManager.GetCell(Position + ((Direction)i).ToVector2Int());
                if (cell is not null)
                {
                    cell.Rotate(-1);
                }
            }
        }
    }
}