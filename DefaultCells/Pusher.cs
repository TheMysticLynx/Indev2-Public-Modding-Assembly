namespace PublicAssembly.DefaultCells
{
    public class Pusher : SteppedCell
    {
        public override string Name => "Pusher";
        public override string Description => "Moves towards faced direction every step";
        public override string SpriteName => "Pusher.png";
        public override void Step()
        {
            Push();
        }
    }
}