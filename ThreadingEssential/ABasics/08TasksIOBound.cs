using LearnInfra.Interface;
using System;
using System.Threading.Tasks;

namespace ThreadingEssential.ABasics
{
	public class TasksIOBound : ILearner
	{
		public void Practice(string[] args)
		{
			var task = Task.Factory.StartNew<string>(() => GetPosts("https://jsonplaceholder.typicode.com/posts"));
			SomethingElse();
			try
			{
				Console.WriteLine(task.Result);
			}
			catch (AggregateException ae)
			{
				Console.WriteLine(ae);
			}
		}

		private void SomethingElse()
		{
			Console.WriteLine("Something else.");
		}

		private string GetPosts(string url)
		{
			using (var client = new System.Net.WebClient())
			{
				return client.DownloadString(url);
			}
		}
	}
}