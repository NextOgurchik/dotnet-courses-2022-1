using System;

namespace Task3
{
    class Triangle
    {
        private double a;
        public double A
        {
            get => a;
            set
            {
                if (((a + b > c) && (a + c > b) && (b + c > a)) != true)
                {
                    throw new Exception("Triangle does not exist.");
                }
                a = value > 0 ? value : throw new Exception("Side cannot be less than zero.");

            }
        }
        private double b;
        public double B
        {
            get => b;
            set
            {
                if (((a + b > c) && (a + c > b) && (b + c > a)) != true)
                {
                    throw new Exception("Triangle does not exist.");
                }
                b = value > 0 ? value : throw new Exception("Side cannot be less than zero.");

            }
        }
        private double c;
        public double C
        {
            get => c;
            set 
            {
                if (((a + b > c) && (a + c > b) && (b + c > a)) != true)
                {
                    throw new Exception("Triangle does not exist.");
                }
                c = value > 0 ? value : throw new Exception("Side cannot be less than zero.");
                
            }
        }
        public Triangle(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
        }
        public double GetPerimeter()
        {
            return A + B + C;
        }
        public double GetArea()
        {
            double p = GetPerimeter() / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
        public override string ToString()
        {
            return $"Треугольник. Сторона a = {A}. Сторона b = {B}. Сторона c = {C}." +
                $" Периметр = {GetPerimeter()}. Площадь = {Math.Round(GetArea(), 2)}.";
        }
    }
}
