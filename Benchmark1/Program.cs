using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace Benchmark1
{
	[MemoryDiagnoser]
	public class Program
	{
		const int n = 1;
		IList<int> valsList = new List<int>();

		[GlobalSetup]
		public void GlobalSetup()
		{
			var rnd = new Random();

			for (int i = 0; i < n; i++)
			{
				int number = rnd.Next(1, 100);
				valsList.Add(number);
			}
		}
		[Benchmark]
		public void ForLoop()
		{
			// Implement your benchmark here
			int minValue = int.MaxValue;
			for (int i = 0; i < valsList.Count; i++)
				if (valsList[i] < minValue) minValue = valsList[i];
		}
		[Benchmark]
		public void ForeachLoop()
		{
			// Implement your benchmark here
			int minValue = int.MaxValue;
			foreach (int number in valsList)
				if (number < minValue) minValue = number;
		}
		[Benchmark]
		public void EnumeratorLoop()
		{
			// Implement your benchmark here
			int minValue = int.MaxValue;
			IEnumerator<int> enumerator = valsList.GetEnumerator();
			while(enumerator.MoveNext())
				if (enumerator.Current < minValue) minValue = enumerator.Current;
		}
		[Benchmark]
		public void LinqOrderByFirst()
		{
			// Implement your benchmark here
			valsList.OrderBy(x => x).First();
		}
		[Benchmark]
		public void LinqMin()
		{
			// Implement your benchmark here
			valsList.Min();
		}
		public static void Main(string[] args)
		{
			// Else, use BenchmarkRunner
			BenchmarkRunner.Run<Program>(BenchmarkConfig.Get());
		}
	}
}