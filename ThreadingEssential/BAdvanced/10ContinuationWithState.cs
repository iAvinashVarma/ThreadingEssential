using LearnInfra;
using LearnInfra.Interface;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LearnInfra.Extension;
using LearnInfra.Model;

namespace ThreadingEssential.BAdvanced
{
	public class ContinuationWithState : ILearner
	{
		public void Practice(string[] args)
		{
			var task = Task.Run(() => GetDateTime());
			var continuationTasks = new List<Task<DateTime>>();
			Enumerables.For(1, 10, i =>
			{
				var utf32 = 'A' - 1 + i;
				Thread.Sleep(200);
				task = task.ContinueWith((x, y) => GetDateTime(), new Person { Id = i, Name = $"{(char)(utf32)}{(char)(utf32 + 1)}{(char)(utf32 + 2)}{(char)(utf32 + 3)}{(char)(utf32 + 4)}{i}" });
				continuationTasks.Add(task);
			});
			task.Wait();

			continuationTasks.ForEach(c =>
			{
				var person = c.AsyncState as Person;
				Console.WriteLine($"Task finished at {c.Result}. {person}");
			});
		}

		private DateTime GetDateTime() => DateTime.Now;
	}
}