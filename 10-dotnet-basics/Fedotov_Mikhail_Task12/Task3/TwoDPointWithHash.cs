
namespace Task3
{
	class TwoDPointWithHash : TwoDPoint
	{
		public TwoDPointWithHash(int x, int y) : base(x, y)
		{ }

		public override int GetHashCode()
		{
			return (10000000 * x - 159) - (100 * y) + 574;
			//int key = 666;
			//return key - (x * 2 + 265 * key - y + 951 * (key + (84 * key + y - 984))) + (y * key + 7 * (key + (147 * key + x)));
		}
	}
}
