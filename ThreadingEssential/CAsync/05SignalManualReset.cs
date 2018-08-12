using LearnInfra.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingEssential.CAsync
{
	public class SignalManualReset : ILearner
	{
		// Start as no signal received.
		ManualResetEvent manualResetEvent = new ManualResetEvent(false);

		public void Practice(string[] args)
		{
			Console.WriteLine($"Current Thread {Thread.CurrentThread.ManagedThreadId}.");
			ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork));
			Console.WriteLine($"Is Background Thread? {Thread.CurrentThread.IsBackground}.");
			manualResetEvent.WaitOne();
		}

		private void DoWork(object state)
		{
			Console.WriteLine($"D => Current Thread {Thread.CurrentThread.ManagedThreadId}.");
			Console.WriteLine($"D => Is Background Thread? {Thread.CurrentThread.IsBackground}.");
			manualResetEvent.Set();
		}
	}
}
