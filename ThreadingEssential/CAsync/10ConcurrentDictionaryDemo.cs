using LearnInfra.Interface;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading.Tasks;

namespace ThreadingEssential.CAsync
{
	public class ConcurrentDictionaryDemo : ILearner
	{
		ConcurrentDictionary<int, string> concurrentDictionary = new ConcurrentDictionary<int, string>();
		ConcurrentDictionary<string, uint> wordCount = new ConcurrentDictionary<string, uint>();

		public void Practice(string[] args)
		{
			((Action)(() => Example())).Invoke();
			var wordCounter = ((Func<ConcurrentDictionary<string, uint>>)(() => WordCounter(@"C:\Trash\Sample.csv"))).Invoke();
		}

		private void Example()
		{
			if (concurrentDictionary.TryAdd(1, "One"))
			{
				Console.WriteLine($"KeyValuePair 1: Added.");
			}

			var valueOne = concurrentDictionary.GetOrAdd(1, "ONE");
			Console.WriteLine($"Existing 1: {valueOne}");
			var valueTwo = concurrentDictionary.AddOrUpdate(1, "_ONE_", (existingKey, existingValue) =>
			{
				return existingValue.ToUpper();
			});
			Console.WriteLine($"Existing 2: {valueTwo}");

			if (concurrentDictionary.TryGetValue(1, out string valueThree))
			{
				Console.WriteLine($"Existing 3: {valueThree}");
			}
		}

		private ConcurrentDictionary<string, uint> WordCounter(string fileName)
		{
			if (File.Exists(fileName))
			{
				var lines = File.ReadAllLines(fileName);
				Parallel.ForEach<string>(lines, (line) =>
				{
					var words = line.Split(',');
					foreach (var word in words)
					{
						if (string.IsNullOrWhiteSpace(word)) continue;
						wordCount.AddOrUpdate(word, 1, (k, currentCount) =>
						{
							return currentCount + 1;
						});
					}
				}); 
			}
			return wordCount;
		}
	}
}
