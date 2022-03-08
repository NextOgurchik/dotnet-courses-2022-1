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
			Console.WriteLine("Программа для анализа скорости работы классов String и StringBuilder для операции сложения");
			Console.WriteLine("Скорость сложения строки " + iterations + " раз");

			double sec;
			var watch = new Stopwatch();
			watch.Start();
			StringAddition();
			watch.Stop();
			sec = Convert.ToDouble(watch.ElapsedMilliseconds) / 1000;
			Console.WriteLine("String: " + sec);

			watch = new Stopwatch();
			watch.Start();
			StringBuilderAddition();
			watch.Stop();
			sec = Convert.ToDouble(watch.ElapsedMilliseconds) / 1000;
			Console.WriteLine("StringBuilder: " + sec);
		}
	}
}
