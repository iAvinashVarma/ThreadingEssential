using LearnInfra.Interface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingEssential.CAsync
{
	public class ProduceConsumer : ILearner
	{
		Random random = new Random();
		BlockingCollection<ulong> blockingCollection = new BlockingCollection<ulong>(10);

		public void Practice(string[] args)
		{
			new Thread(new ThreadStart(GenerateFibonacci))
			{
				IsBackground = false
			}.Start();

			new Thread(new ThreadStart(ReadFibonacci))
			{
				IsBackground = false
			}.Start();
		}

		private void ReadFibonacci()
		{
			do
			{
				var num = blockingCollection.Take();
				Console.Write($"[Fibonacci {num}]");
			} while (true);
		}

		private void GenerateFibonacci()
		{
			for (ushort i = 0; i < 50; i++)
			{
				Thread.Sleep(random.Next(1, 500));
				Console.WriteLine("Adding next Fibonacci..");
				blockingCollection.Add(Fibonacci(i));
			}
		}

		private ulong Fibonacci(ushort number) => number == 0 ? 0 : GetFibonacci(number);

		private ulong GetFibonacci(ushort number)
		{
			ulong a = 0;
			ulong b = 1;
			for (int i = 1; i < number; i++)
			{
				ulong c = checked(a + b);
				a = b;
				b = c;
			}
			return b;
		}
	}
}
