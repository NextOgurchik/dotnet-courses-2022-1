using System;

namespace Task1
{
    abstract internal class Figure
    {
        public Point Point { get; set; }

        public Figure() : this(new Point(0, 0)) { }
        public Figure(Point point)
        {
            Point = point;
        }
        public abstract string Draw();
    }
}

