using System;
using System.Diagnostics;
using System.Text;

namespace Task4
{
    internal class Program
    {
		static readonly int iterations = 50000;
		private static void StringAddition()
		{
			var str = "";

			for (int i = 0; i < iterations; i++)
			{
				str += i.ToString() + ", ";
			}
		}

		private static void StringBuilderAddition()
		{
			var builder = new StringBuilder();

			for (int i = 0; i < iterations; i++)
			{
				builder.Append(i);
				builder.Append(", ");
			}
		}
		static void Main(string[] args)
		{
			double number;
			var watch = new Stopwatch();
			watch.Start();
			StringAddition();
			watch.Stop();
			number = Convert.ToDouble(watch.ElapsedMilliseconds) / 1000;
			Console.WriteLine("String: " + number);
			watch = new Stopwatch();
			watch.Start();
			StringBuilderAddition();
			watch.Stop();
			number = Convert.ToDouble(watch.ElapsedMilliseconds) / 1000;
			Console.WriteLine("StringBuilder: " + number);
		}
	}
}
