using System;

namespace Task1
{
    internal class Figure
    {
        public Point Point { get; set; }

        public Figure() : this(new Point(0, 0)) { }
        public Figure(Point point)
        {
            Point = point;
        }
        public virtual string Draw()
        {
            return $"Координаты: ({Point.X},{Point.Y}) Тип: {GetType().Name}";
        }
    }
    internal class Line : Figure
    {
        public Point Point2 { get; set; }
        public Line(Point point, Point point2)
            : base(point)
        {
            Point2 = point2;
        }
        public override string Draw()
        {
            return $"Координаты: ({Point.X},{Point.Y}) ({Point2.X},{Point2.Y}) Тип: {GetType().Name}";
        }
    }
    internal class Rectangle : Line
    {
        public Rectangle(Point point, Point point2)
            : base(point, point2)
        {

        }
        public override string Draw()
        {
            return $"Координаты: ({Point.X},{Point.Y}) ({Point2.X},{Point2.Y}) Тип: {GetType().Name}";
        }
    }
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
    internal class Round : Сircle
    {
        public Round(Point point, double radius)
            : base(point, radius)
        {

        }
        public override string Draw()
        {
            return $"Координата центра: ({Point.X},{Point.Y}) Радиус: {Radius} Тип: {GetType().Name}";
        }
    }
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

