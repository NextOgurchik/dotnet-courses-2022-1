using System;

namespace Task2
{
    internal class Program
    {
		static void Main(string[] args)
		{
			ISeries progression = new GeometricProgression(2, 2);
			Console.WriteLine("Progression:");
			PrintSeries(progression, 10);

			ISeries list = new List(new double[] { 5, 8, 6, 3, 1 });
			Console.WriteLine("List:");
			PrintSeries(list, 10);
		}
		static void PrintSeries(ISeries series, int count)
		{
			series.Reset();

			for (int i = 0; i < count; i++)
			{
				Console.WriteLine(series.GetCurrent());
				series.MoveNext();
			}
		}
	}
}
