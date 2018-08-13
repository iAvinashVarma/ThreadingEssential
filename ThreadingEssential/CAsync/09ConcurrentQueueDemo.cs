using LearnInfra.Interface;
using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ThreadingEssential.CAsync
{
	public class ConcurrentQueueDemo : ILearner
	{
		Random random = new Random();
		ConcurrentQueue<ulong> concurrentQueue = new ConcurrentQueue<ulong>();

		public void Practice(string[] args)
		{
			var fibonacciThread = new Thread(new ThreadStart(GenerateFibanocii))
			{
				IsBackground = false
			};
			fibonacciThread.Start();

			var readerThread = new Thread(new ThreadStart(ReadFibonacci))
			{
				IsBackground = false
			};
			readerThread.Start();
		}

		private void ReadFibonacci()
		{
			Console.WriteLine("Starting the read from the queue...");

			do
			{
				if(concurrentQueue.TryDequeue(out ulong x))
				{
					Console.Write($"[Fibonacci {x}]");
				}
				Thread.Sleep(10);
			} while (true);
		}

		private void GenerateFibanocii()
		{
			for (ushort i = 1; i <= 50; i++)
			{
				Thread.Sleep(random.Next(1, 500));
				var f = Fibonacci(i);
				concurrentQueue.Enqueue(f);
				//Console.WriteLine($"Fibonacci of {i} is {f}.");
			}
		}

		public ulong Fibonacci(ushort number) => number == 0 ? 0 : GetFibonacci(number);

		private ulong GetFibonacci(ushort number)
		{
			ulong previous = 0;
			ulong before = 1;
			for (int i = 0; i < number - 1; i++)
			{
				ulong next = checked(previous + before);
				previous = before;
				before = next;
			}
			return before;
		}
	}
}
