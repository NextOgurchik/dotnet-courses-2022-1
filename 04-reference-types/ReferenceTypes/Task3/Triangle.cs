using System;

namespace Task3
{
    class Triangle
    {
        private double side1;
        public double Side1
        {
            get => side1;
            set => side1 = value > 0 ? value : throw new Exception("Side cannot be less than zero.");
        }
        private double side2;
        public double Side2
        {
            get => side2;
            set => side2 = value > 0 ? value : throw new Exception("Side cannot be less than zero.");
        }
        private double side3;
        public double Side3
        {
            get => side3;
            set => side3 = value > 0 ? value : throw new Exception("Side cannot be less than zero.");
        }
        public Triangle(double side1, double side2, double side3)
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }
        public double GetLength()
        {
            return Side1 + Side2 + Side3;
        }
        public double GetArea()
        {
            double p = GetLength() / 2;
            return Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));
        }
        public override string ToString()
        {
            return $"Треугольник. Сторона a = {Side1}. Сторона b = {Side2}. Сторона c = {Side3}." +
                $" Периметр = {GetLength()}. Площадь = {Math.Round(GetArea(), 2)}.";
        }
    }
}
