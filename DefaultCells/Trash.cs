namespace PublicAssembly.DefaultCells
{
    public class Trash : Cell
    {
        public override string Name => "Trash";
        public override string Description => "Deletes cells that push it";
        public override string SpriteName => "Trash.png";

        public override bool Push(Cell originalCaller, Cell lastCaller, Direction direction, int bias)
        {
            if (lastCaller != null)
            {
                StateManager.DeleteCell(lastCaller);
                return true;
            }

            return false;
        }
    }
}