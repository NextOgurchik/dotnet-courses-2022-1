namespace Task2
{
	public class GeometricProgression : ISeries
	{
		public double Start { get; set; }
		public double Step { get; set; }
		private int currentIndex;

		public GeometricProgression(double start, double step)
		{
			Start = start;
			Step = step;
			currentIndex = 1;
		}

		public double GetCurrent()
		{
			return Start + Step * currentIndex;
		}

		public bool MoveNext()
		{
			currentIndex++;
			return true;
		}

		public void Reset()
		{
			currentIndex = 1;
		}
	}
}
