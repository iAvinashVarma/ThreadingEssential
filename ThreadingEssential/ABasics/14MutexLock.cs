using System;
using System.Threading;
using System.Threading.Tasks;
using ThreadingEssential.Interface;

namespace ThreadingEssential.ABasics
{
	internal class MutexLock : ILearner
	{
		private static Mutex mutex = new Mutex();

		public void Practice(string[] args)
		{
			var taskOne = Task.Factory.StartNew(() =>
			{
				for (int i = 0; i < 10; i++)
				{
					new Thread(AcquireMutex)
					{
						Name = $"Thread{i + 1}"
					}.Start();
				}
			});
			Console.WriteLine("Mutex Aquire And Release One By One.");
			taskOne.Wait();
			taskOne.GetAwaiter().GetResult();
			var taskTwo = Task.Factory.StartNew(() =>
			{
				for (int i = 0; i < 10; i++)
				{
					new Thread(AcquireAllMutex)
					{
						Name = $"Thread{i + 1}"
					}.Start();
				}
			});
			Console.WriteLine("Mutex Aquire All And Release Once.");
			Task.WaitAll(taskTwo);
			taskTwo.GetAwaiter().GetResult();
		}

		private void AcquireMutex()
		{
			mutex.WaitOne();
			DoSomething();
			mutex.ReleaseMutex();
			Console.WriteLine($"Mutex is released by {Thread.CurrentThread.Name}.");
		}

		private void AcquireAllMutex()
		{
			if (!mutex.WaitOne(TimeSpan.FromSeconds(1), false))
			{
				Console.WriteLine($"Mutex acquired by {Thread.CurrentThread.Name}.");
				return;
			}
			DoSomething();
			mutex.ReleaseMutex();
			Console.WriteLine($"Mutex is released by {Thread.CurrentThread.Name}.");
		}

		private void DoSomething()
		{
			Thread.Sleep(2000);
			Console.WriteLine($"Mutex acquired by {Thread.CurrentThread.Name}.");
		}
	}
}