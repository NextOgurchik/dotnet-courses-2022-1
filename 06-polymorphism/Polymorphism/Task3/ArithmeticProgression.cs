public class ArithmeticProgression : IIndexableSeries
{
	public double Start { get; set; }
	public double Step { get; set; }
	private int currentIndex;

	public ArithmeticProgression(double start, double step)
	{
		Start = start;
		Step = step;
		currentIndex = 0;
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
		currentIndex = 0;
	}

	public double this[int index]
	{
		get
		{
			return Start + Step * index;
		}
	}
}