namespace Task4.Obstacles
{
    internal class Stone : Obstruction
    {
        public Stone(Point position)
            : base(position)
        {

        }
        public override char Show()
        {
            return 's';
        }
    }
}
