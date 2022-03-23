using System;

namespace Task1
{
    internal class Ring : Round
    {
        private double radius;
        public override double Radius
        {
            get { return radius; }
            set
            {
                if (value <= innerRadius)
                {
                    throw new Exception("The outer ring can't be smaller than the inner ring.");
                }
                radius = value;
            }
        }
        private double innerRadius;
        public double InnerRadius
        {
            get { return innerRadius; }
            set
            {
                if (value < 0 || value > radius)
                {
                    throw new Exception("The radius can't be less than zero, and the outer ring can't be smaller than the inner ring.");
                }
                innerRadius = value;
            }
        }
        public Ring(Point point, double radius, double innerRadius)
            : base(point, radius)
        {
            InnerRadius = innerRadius;
        }
        public override string Draw()
        {
            return $"Координата центра: ({Point.X},{Point.Y}) Внешний радиус: {Radius} Внутренний радиус: {InnerRadius} Тип: {GetType().Name}";
        }
    }
}
