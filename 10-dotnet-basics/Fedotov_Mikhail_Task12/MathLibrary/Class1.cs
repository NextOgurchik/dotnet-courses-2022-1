namespace MathLibrary
{
    public static class MathFunctions
    {
        public static long Factorial(int number)
        {
            int y = 1;
            for (int i = 2; i <= number; i++)
            {
                y *= i;
            }
            return y;
        }
        public static double Power(double x, double y)
        {
            if (y == 0)
                return 1;
            if (y > 0)
                return Power(x, y - 1) * x;
            return 1 / Power(x, -y);
        }
    }
}
