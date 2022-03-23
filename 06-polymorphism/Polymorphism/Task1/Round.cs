namespace Task1
{
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
}
