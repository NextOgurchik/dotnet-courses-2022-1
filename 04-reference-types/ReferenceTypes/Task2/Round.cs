using System;

namespace Task2
{
    class Round
    {
        public Point Center { get; set; }
        private double radius;
        public double Radius
        {
            get => radius;
            set
            {
                radius = value > 0 ? value : throw new Exception("Radius cannot be less than zero.");
                Length = 2 * Math.PI * radius;
                Area = Math.PI * radius * radius;
            }
        }
        public double Length { get; private set; }
        public double Area { get; private set; }
        public Round(Point centerPoint, double radius)
        {
            Center = centerPoint;
            Radius = radius;
        }
        public override string ToString()
        {
            return $"Координаты X = {Center.X} Y = {Center.Y}. Радиус = {Radius}. " +
                $"Длина окружности = {Math.Round(Length, 2)}. Площадь окружности = {Math.Round(Area, 2)}.";
        }
    }
}
