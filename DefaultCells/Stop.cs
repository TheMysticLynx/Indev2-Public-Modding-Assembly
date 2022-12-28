namespace PublicAssembly.DefaultCells
{
    public class Stop : Cell
    {
        public override string Name => "Stop";
        public override string Description => "Stops cells from moving.";
        public override string SpriteName => "Stop.png";

        public override bool Push(Cell originalCaller, Cell lastCaller, Direction direction, int bias)
        {
            return false;
        }

        public override void Rotate(int amount)
        {
            // Do nothing
        }

        public override void SetRotation(Direction direction)
        {
            // Do nothing
        }

        public override void SetRotation(int rotation)
        {
            // Do nothing
        }
    }
}