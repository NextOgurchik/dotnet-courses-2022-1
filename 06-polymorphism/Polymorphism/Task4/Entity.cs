namespace Task4
{
    abstract internal class Entity
    {
        public Point Position { get; set; }
        public Entity() : this(new Point(0, 0)) { }
        public Entity(Point position)
        {
            Position = position;
        }
        public virtual char Show()
        {
            return '*';
        }
    }    
}
