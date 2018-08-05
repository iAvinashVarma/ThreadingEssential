using System;
using System.Threading;
using ThreadingEssential.Interface;

namespace ThreadingEssential.ABasics
{
	internal class ContextSwitching : ILearner
	{
		private int _count;

		public ContextSwitching(int count) => _count = count;

		public void Practice(string[] args)
		{
			Thread.CurrentThread.Name = "AV Main Thread";
			var thread = new Thread(() => Counter(_count))
			{
				Name = "AV Worker Thread",
				Priority = ThreadPriority.Highest
			};
			// Worker Thread.
			thread.Start();
			// Main Thread.
			for (int i = 0; i < _count; i++)
			{
				Console.Write($" A{i} ");
			}
		}

		private void Counter(int count)
		{
			for (int i = 0; i < count; i++)
			{
				Console.Write($" Z{i} ");
			}
		}
	}
}