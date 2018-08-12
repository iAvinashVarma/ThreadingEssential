using LearnInfra.Interface;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ThreadingEssential.BAdvanced
{
	public class TPLIntro : ILearner
	{
		public void Practice(string[] args)
		{
			int count = 10000;
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			for (int i = 0; i < count; i++)
			{
				Console.WriteLine(i);
			}
			Console.WriteLine($"Time taken without TPL: {stopwatch.ElapsedMilliseconds}");
			stopwatch.Stop();
			stopwatch.Restart();
			Console.WriteLine("Press a key to go for TPL.");
			Console.ReadKey();
			Parallel.For(0, count, i =>
			{
				Console.WriteLine(i);
			});
			Console.WriteLine($"Time taken with TPL: {stopwatch.ElapsedMilliseconds}");
		}
	}
}