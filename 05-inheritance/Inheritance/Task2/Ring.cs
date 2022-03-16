using System;

namespace Task2
{
    internal sealed class Ring : Round
    {
        private double radius;
        public new double Radius
        {
            get { return radius; }
            set
            {
                if (value > innerRadius)
                {
                    radius = value;
                }
                else
                {
                    throw new Exception("The outer ring can't be smaller than the inner ring.");
                }
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
                    throw new Exception("The radius can't be less than zero and the outer ring can't be smaller than the inner ring.");
                }
                innerRadius = value;
            }
        }
        public override double Circumference => (2 * Math.PI * radius) + (2 * Math.PI * innerRadius);
        public override double Area => (Math.PI * radius * radius) - (Math.PI * innerRadius * innerRadius);
        public Ring(int radius, int innerRadius, int x, int y)
            : base(radius, x, y)
        {
            Radius = radius;
            InnerRadius = innerRadius;
        }
        public override string ToString()
        {
            return $"Координаты X = {X} Y = {Y}. Внешний радиус = {Radius}. " +
                   $"Внутренний радиус = {InnerRadius}. Суммарная длина границ кольца = {Math.Round(Circumference, 2)}. " +
                   $"Площадь кольца = {Math.Round(Area, 2)}.";
        }
    }
}
