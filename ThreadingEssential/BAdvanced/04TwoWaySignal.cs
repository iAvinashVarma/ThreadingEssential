using System;
using System.Threading;
using System.Threading.Tasks;
using ThreadingEssential.Interface;

namespace ThreadingEssential.BAdvanced
{
	internal class TwoWaySignal : ILearner
	{
		private EventWaitHandle first = new AutoResetEvent(false);
		private EventWaitHandle second = new AutoResetEvent(false);
		private object avLock = new object();
		private string value = string.Empty;

		public void Practice(string[] args)
		{
			Task.Factory.StartNew(WorkerThread);
			Console.WriteLine("Main thread is waiting.");
			first.WaitOne();
			lock (avLock)
			{
				value = "Updating value in main thread.";
				Console.WriteLine(value);
			}
			Thread.Sleep(1000);
			second.Set();
			Console.WriteLine("Released worker thread.");
		}

		private void WorkerThread()
		{
			Thread.Sleep(1000);
			lock (avLock)
			{
				value = "Updating value in worker thread.";
				Console.WriteLine(value);
			}
			first.Set();
			Console.WriteLine("Release main thread.");
			Console.WriteLine("Worker thread is waiting.");
			second.WaitOne();
		}
	}
}