﻿using System;

namespace Task2
{
    class Round
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double Circumference 
        { 
            get => 2 * Math.PI * radius;
        }
        private double radius;
        public double Radius
        {
            get => radius;
            set
            {
                radius = value > 0 ? value : throw new Exception("Radius cannot be less than zero.");
            }
        }
        public double Area { get => Math.PI * radius * radius; }
        public Round(double radius, int x, int y)
        {
            Radius = radius;
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"Координаты X = {X}. Y = {Y}. Радиус = {Radius}. " +
                $"Длина окружности = {Circumference}. Площадь окружности = {Area}.";
        }
    }
}
