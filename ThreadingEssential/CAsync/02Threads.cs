using LearnInfra.Interface;
using System;
using System.Threading;

namespace ThreadingEssential.CAsync
{
	public class Threads : ILearner
	{
		private int total = 0;
		private Random random = new Random();

		public void Practice(string[] args)
		{
			Console.WriteLine("Starting in the main method.");
			new Thread(new ThreadStart(DoWork))
			{
				Name = "Thread One"
			}.Start();

			new Thread(new ThreadStart(DoWork))
			{
				Name = "Thread Two"
			}.Start();

			new Thread(new ThreadStart(DoWork))
			{
				Name = "Thread Three"
			}.Start();

			new Thread(new ThreadStart(DoWork))
			{
				Name = "Thread Four"
			}.Start();

			new Thread(new ThreadStart(DoWork))
			{
				Name = "Thread Five"
			}.Start();

			Console.WriteLine("Ending in the main method.");
		}

		private void DoWork()
		{
			Thread.Sleep(random.Next(1, 1500));
			int myTotal = total;
			Thread.Sleep(random.Next(1, 1500));
			total = myTotal + 1;
			Console.WriteLine($"Managed Thread ID: {Thread.CurrentThread.ManagedThreadId} says {total}.");
		}
	}
}