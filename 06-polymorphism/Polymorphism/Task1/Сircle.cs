using System;

namespace Task1
{
    internal class Сircle : Figure
    {
        private double radius;
        public virtual double Radius
        {
            get { return radius; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Radius cannot be less than zero.");

                }
                radius = value;
            }
        }
        public Сircle(Point point, double radius)
            : base(point)
        {
            Radius = radius;
        }
        public override string Draw()
        {
            return $"Координата центра: ({Point.X},{Point.Y}) Радиус: {Radius} Тип: {GetType().Name}";
        }
    }
}
