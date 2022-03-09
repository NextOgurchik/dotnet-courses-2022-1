using System;

namespace Task3
{
    class Triangle
    {
        private int a;
        public int A
        {
            get => a;
            private set
            {
                a = value > 0 ? value : throw new Exception("Side cannot be less than zero.");
            }
        }
        private int b;
        public int B
        {
            get => b;
            private set
            {
                b = value > 0 ? value : throw new Exception("Side cannot be less than zero.");
            }
        }
        private int c;
        public int C
        {
            get => c;
            private set 
            {
                c = value > 0 ? value : throw new Exception("Side cannot be less than zero.");
            }
        }
        public Triangle(int a, int b, int c)
        {
            if (!((a + b > c) && (a + c > b) && (b + c > a)))
            {
                throw new Exception("Triangle does not exist.");
            }
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
