namespace PublicAssembly.DefaultCells
{
    public class OneWay : Cell
    {
        public override string Name => "One Way";
        public override string Description => "Can only be pushed one way";
        public override string SpriteName => "OneWay.png";

        public override bool Push(Cell originalCaller, Cell lastCaller, Direction direction, int bias)
        {
            if ((int)direction % 2 != (int)FacedDirection % 2)
                return false;
            return base.Push(originalCaller, lastCaller, direction, bias);
        }
    }
}