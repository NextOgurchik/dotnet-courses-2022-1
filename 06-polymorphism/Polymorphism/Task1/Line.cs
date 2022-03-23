namespace Task1
{
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
}
