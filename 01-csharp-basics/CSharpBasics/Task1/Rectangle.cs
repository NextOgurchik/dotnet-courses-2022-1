using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    internal class Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public int Area()
        {
            return Width * Height;
        }
    }
}
