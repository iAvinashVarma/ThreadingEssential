using System;
using System.Threading;
using ThreadingEssential.Interface;

namespace ThreadingEssential.ABasics
{
	public class Concepts : ILearner
	{
		public void Practice(string[] args)
		{
			var thread = new Thread(PrintHelloWorld)
			{
				IsBackground = true
			};
			thread.Start();
			thread.Join();
			Console.WriteLine("Hello World Printed.");
		}

		private void PrintHelloWorld()
		{
			Console.WriteLine("Hello World");
			Thread.Sleep(5000);
		}
	}
}