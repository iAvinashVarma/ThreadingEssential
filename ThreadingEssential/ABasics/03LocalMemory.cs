using System;
using System.Threading;
using ThreadingEssential.Interface;

namespace ThreadingEssential.ABasics
{
	public class LocalMemory : ILearner
	{
		public void Practice(string[] args)
		{
			// Worker Thread.
			new Thread(PrintOneToThirty).Start();
			// Main Thread.
			PrintOneToThirty();
		}

		private void PrintOneToThirty()
		{
			for (int i = 0; i < 30; i++)
			{
				Console.Write($"{i + 1} ");
			}
		}
	}
}