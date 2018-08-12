using LearnInfra.Interface;
using System;
using System.Collections.Concurrent;
using System.Linq;

namespace ThreadingEssential.BAdvanced
{
	public class PLINQForAll : ILearner
	{
		public void Practice(string[] args)
		{
			var range = Enumerable.Range(2000, 5000);
			var query = range.AsParallel()
				.Where(x => x % 2 == 0);
			var orderedQuery = range.AsParallel()
				.AsOrdered().Where(x => x % 2 == 0);
			var concurrentBag = new ConcurrentBag<int>();
			query.ForAll(x => concurrentBag.Add(x));
			Console.WriteLine(concurrentBag.Count);
		}
	}
}