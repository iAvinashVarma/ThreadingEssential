using LearnInfra.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingEssential.BAdvanced
{
	public class SignalManualReset : ILearner
	{
		private EventWaitHandle manualResetEvent = new ManualResetEvent(false);

		public void Practice(string[] args)
		{
			Task.Factory.StartNew(CallWaitOne);
			Task.Factory.StartNew(CallWaitOne);
			Task.Factory.StartNew(CallWaitOne);
			Task.Factory.StartNew(CallWaitOne);
			Task.Factory.StartNew(CallWaitOne);
			Thread.Sleep(2000);
			Console.WriteLine("Pressed a key to release all the threads so far.");
			Console.ReadKey();
			manualResetEvent.Set();
			Thread.Sleep(2000);

			Console.WriteLine("Press a key again. Threads won't block even if they call WaitOne.");
			Console.ReadKey();
			Task.Factory.StartNew(CallWaitOne);
			Task.Factory.StartNew(CallWaitOne);
			Task.Factory.StartNew(CallWaitOne);
			Task.Factory.StartNew(CallWaitOne);
			Task.Factory.StartNew(CallWaitOne);
			Thread.Sleep(2000);

			Console.WriteLine("Press a key again. Threads will block again if they call WaitOne.");
			Console.ReadKey();
			manualResetEvent.Reset();
			Task.Factory.StartNew(CallWaitOne);
			Task.Factory.StartNew(CallWaitOne);
			Task.Factory.StartNew(CallWaitOne);
			Task.Factory.StartNew(CallWaitOne);
			Task.Factory.StartNew(CallWaitOne);
			Thread.Sleep(2000);

			Console.WriteLine("Press a key again. Calls Set() method.");
			Console.ReadKey();
			manualResetEvent.Set();
			Console.ReadLine();
		}

		private void CallWaitOne()
		{
			Console.WriteLine($"{Task.CurrentId} has called WaitOne.");
			manualResetEvent.WaitOne();
			Console.WriteLine($"{Task.CurrentId} finally ended.");
		}
	}
}