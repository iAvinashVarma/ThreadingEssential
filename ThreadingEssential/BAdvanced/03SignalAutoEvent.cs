using System;
using System.Threading;
using System.Threading.Tasks;
using ThreadingEssential.Interface;

namespace ThreadingEssential.BAdvanced
{
	internal class SignalAutoEvent : ILearner
	{
		//EventWaitHandle eventWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
		private AutoResetEvent autoResetEvent = new AutoResetEvent(false);

		public void Practice(string[] args)
		{
			Task.Factory.StartNew(WorkerThread);
			Thread.Sleep(2500);
			autoResetEvent.Set();
		}

		private void WorkerThread()
		{
			Console.WriteLine("Turnstile or Baffle Gate");
			Console.WriteLine("Waiting to enter the gate.");
			autoResetEvent.WaitOne();
			Console.WriteLine("Entered");
		}
	}
}