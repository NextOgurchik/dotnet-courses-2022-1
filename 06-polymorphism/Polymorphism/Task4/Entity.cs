
namespace Task4
{
    internal class Entity
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
    internal class Bonus : Entity
    {
        public Bonus(Point position)
            : base(position)
        {

        }
        public virtual void Taken()
        {

        }
    }
    internal class Apple : Bonus
    {
        public Apple(Point position)
            : base(position)
        {

        }
        public override void Taken()
        {

        }
        public override char Show()
        {
            return 'a';
        }
    }
    internal class Cherry : Bonus
    {
        public Cherry(Point position)
            : base(position)
        {

        }
        public override void Taken()
        {

        }
        public override char Show()
        {
            return 'c';
        }
    }
    internal class Enemy : Entity
    {
        public Enemy(Point position)
            : base(position)
        {

        }
        public virtual void Damage()
        {

        }
        public virtual void Move()
        {

        }
    }
    internal class Wolf : Enemy
    {
        public Wolf(Point position)
            : base(position)
        {

        }
        public override void Damage()
        {

        }
        public override void Move()
        {

        }
        public override char Show()
        {
            return 'w';
        }
    }
    internal class Bear : Enemy
    {
        public Bear(Point position)
            : base(position)
        {

        }
        public override void Damage()
        {

        }
        public override void Move()
        {

        }
        public override char Show()
        {
            return 'b';
        }
    }
    internal class Obstruction : Entity
    {
        public Obstruction(Point position)
            : base(position)
        {

        }
    }
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
