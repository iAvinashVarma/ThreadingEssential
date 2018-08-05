using System;
using System.Threading;
using ThreadingEssential.Interface;

namespace ThreadingEssential.ABasics
{
	public class SharedResources : ILearner
	{
		private bool isCompleted;
		private static readonly object lockCompleted = new object();

		public void Practice(string[] args)
		{
			var thread = new Thread(HelloWorld)
			{
				Name = "AV Worker Thread"
			};
			thread.Start();
			HelloWorld();
		}

		public void HelloWorld()
		{
			lock (lockCompleted)
			{
				if (!isCompleted)
				{
					isCompleted = true;
					Console.WriteLine("Hello World should print only once.");
				}
			}
		}
	}
}