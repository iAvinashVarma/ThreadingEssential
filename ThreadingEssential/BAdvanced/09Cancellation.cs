using LearnInfra.Interface;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingEssential.BAdvanced
{
	public class Cancellation : ILearner
	{
		public void Practice(string[] args)
		{
			var range = Enumerable.Range(0, 100000000).ToList();
			using (var cancellationTokenSource = new CancellationTokenSource())
			{
				var parallelOptions = new ParallelOptions()
				{
					CancellationToken = cancellationTokenSource.Token,
					MaxDegreeOfParallelism = Environment.ProcessorCount
				};

				Console.WriteLine("Press \"X\" to cancel.");

				Task.Factory.StartNew(() =>
				{
					if (Console.ReadKey().KeyChar.Equals('x'))
					{
						cancellationTokenSource.Cancel();
					}
				});

				long total = 0;
				try
				{
					Parallel.For<long>(0, range.Count(), parallelOptions, () => 0, (c, p, t) =>
					{
						Thread.Sleep(200);
						parallelOptions.CancellationToken.ThrowIfCancellationRequested();
						t += range[c];
						return t;
					},
					x =>
					{
						Console.WriteLine(Interlocked.Add(ref total, x));
					});
				}
				catch (OperationCanceledException oce)
				{
					Console.WriteLine($"Cancelled Avi {oce.Message}");
				}
				Console.WriteLine($"Final sum is {total}");
			}
		}
	}
}