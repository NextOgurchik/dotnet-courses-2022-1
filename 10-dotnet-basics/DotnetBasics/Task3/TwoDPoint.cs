namespace Task3
{
	internal class TwoDPoint
	{
		public readonly int x, y;

		public TwoDPoint(int x, int y)  //constructor
		{
			this.x = x;
			this.y = y;
		}

		public override bool Equals(object obj)
		{
			// If parameter is null return false.
			if (obj == null)
			{
				return false;
			}

			// If parameter cannot be cast to Point return false.
			if (!(obj is TwoDPoint p))
			{
				return false;
			}

			// Return true if the fields match:
			return (x == p.x) && (y == p.y);
		}

		public bool Equals(TwoDPoint p)
		{
			// If parameter is null return false:
			if (p is null)
			{
				return false;
			}

			// Return true if the fields match:
			return (x == p.x) && (y == p.y);
		}

		public static bool operator ==(TwoDPoint a, TwoDPoint b)
		{
			// If both are null, or both are same instance, return true.
			if (ReferenceEquals(a, b))
			{
				return true;
			}

			// If one is null, but not both, return false.
			if ((a is null) || (b is null))
			{
				return false;
			}

			// Return true if the fields match:
			return a.x == b.x && a.y == b.y;
		}

		public static bool operator !=(TwoDPoint a, TwoDPoint b)
		{
			return !(a == b);
		}

		public override string ToString()
		{
			return string.Format("x:{0} y:{1}", x, y);
		}
	}
}

