namespace Task2
{
	public interface ISeries
	{
		double GetCurrent();
		bool MoveNext();
		void Reset();
	}

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

	public class List : ISeries
	{
		private double[] series;
		private int currentIndex;

		public List(double[] series)
		{
			this.series = series;
			currentIndex = 0;
		}

		public double GetCurrent()
		{
			return series[currentIndex];
		}

		public bool MoveNext()
		{
			currentIndex = currentIndex < series.Length - 1 ? currentIndex + 1 : 0;
			return true;
		}

		public void Reset()
		{
			currentIndex = 0;
		}
	}
}
