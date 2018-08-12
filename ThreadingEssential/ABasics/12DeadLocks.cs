using LearnEssential.Interface;
using System;
using System.Threading;

namespace ThreadingEssential.ABasics
{
	internal class DeadLocks : ILearner
	{
		private static object caztonLock = new object();
		private static object avLock = new object();

		public void Practice(string[] args)
		{
			new Thread(() =>
			{
				lock (caztonLock)
				{
					Console.WriteLine("Cazton Lock Obtained.");
					Thread.Sleep(2000);
					lock (avLock)
					{
						Console.WriteLine("Avi Lock Obtained.");
					}
				}
			}).Start();
			lock (avLock)
			{
				Console.WriteLine("Main Thread obtained Avi Lock.");
				Thread.Sleep(1000);
				lock (caztonLock)
				{
					Console.WriteLine("Main Thread obtained Cazton Lock.");
				}
			}
		}
	}
}