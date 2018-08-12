using LearnEssential.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ThreadingEssential.BAdvanced
{
	internal class PLINQIntro : ILearner
	{
		public void Practice(string[] args)
		{
			var range = Enumerable.Range(1, 1000000000);
			Invoke(range, ParallelQuery);
			Invoke(range, NormalQuery);
		}

		private ParallelQuery<int> ParallelQuery(IEnumerable<int> range)
		{
			var primeNumbers = range.AsParallel().Where(IsPrime);
			Console.WriteLine($"{primeNumbers.Count()} prime numbers found.");
			return primeNumbers;
		}

		private IEnumerable<int> NormalQuery(IEnumerable<int> range)
		{
			var primeNumbers = range.Where(IsPrime);
			Console.WriteLine($"{primeNumbers.Count()} prime numbers found.");
			return primeNumbers;
		}

		private T Invoke<T>(IEnumerable<int> numbers, Func<IEnumerable<int>, T> func)
		{
			var sw = new Stopwatch();
			sw.Start();
			T result = func(numbers);
			sw.Stop();
			Console.WriteLine($"{func.Method.Name}: {sw.ElapsedMilliseconds}");
			return result;
		}

		private bool IsPrime(int number)
		{
			if (number == 1) return false;
			if (number == 2) return true;
			if (number % 2 == 0) return false;
			var boundary = (int)Math.Floor(Math.Sqrt(number));
			for (int i = 3; i <= boundary; i += 2)
			{
				if (number % i == 0) return false;
			}
			return true;
		}
	}
}