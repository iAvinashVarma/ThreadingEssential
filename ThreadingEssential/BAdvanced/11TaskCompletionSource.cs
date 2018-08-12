using LearnEssential.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;
using ThreadingEssential.Model;

namespace ThreadingEssential.BAdvanced
{
	internal class TaskCompletionSource : ILearner
	{
		public void Practice(string[] args)
		{
			var taskCompletionSource = new TaskCompletionSource<Product>();
			Task<Product> lazyTask = taskCompletionSource.Task;
			Task.Factory.StartNew(() =>
			{
				Thread.Sleep(1000);
				taskCompletionSource.SetResult(new Product { Id = 1, Name = "Software Development" });
			});

			Task.Factory.StartNew(() =>
			{
				if (Console.ReadKey().KeyChar == 'x')
				{
					Product result = lazyTask.Result;
					Console.WriteLine($"{Environment.NewLine}Result: {result}");
				}
			});

			Thread.Sleep(5000);
			Console.ReadLine();
		}
	}
}