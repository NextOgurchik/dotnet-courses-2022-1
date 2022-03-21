using System;

namespace Task2
{
    class Round
    {
        public int X { get; set; }
        public int Y { get; set; }
        public virtual double Circumference => 2 * Math.PI * radius;
        private int radius;
        public virtual int Radius
        {
            get => radius;
            set
            {
                radius = value > 0 ? value : throw new Exception("Radius cannot be less than zero.");
            }
        }
        public virtual double Area => Math.PI * radius * radius;
        public Round(int radius, int x, int y)
        {
            Radius = radius;
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"Координаты X = {X}. Y = {Y}. Радиус = {Radius}. " +
                $"Длина окружности = {Circumference}. Площадь круга = {Area}.";
        }
    }
}
