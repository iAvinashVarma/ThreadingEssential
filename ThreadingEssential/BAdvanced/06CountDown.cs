using LearnEssential.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingEssential.BAdvanced
{
	internal class CountDown : ILearner
	{
		private CountdownEvent countdownEvent = new CountdownEvent(5);

		public void Practice(string[] args)
		{
			Task.Factory.StartNew(DoSomething);
			Task.Factory.StartNew(DoSomething);
			Task.Factory.StartNew(DoSomething);
			Task.Factory.StartNew(DoSomething);
			Task.Factory.StartNew(DoSomething);
			countdownEvent.Wait();
			Console.WriteLine($"Signal has been called {countdownEvent.InitialCount} times.");
		}

		private void DoSomething()
		{
			Thread.Sleep(250);
			Console.WriteLine($"{Task.CurrentId} is calling signal.");
			countdownEvent.Signal();
		}
	}
}