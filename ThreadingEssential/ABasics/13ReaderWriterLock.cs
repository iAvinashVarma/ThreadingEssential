using LearnEssential.Interface;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingEssential.ABasics
{
	internal class ReaderWriterLock : ILearner
	{
		private static ReaderWriterLockSlim readerWriterLockSlim = new ReaderWriterLockSlim();
		private static Dictionary<int, string> persons = new Dictionary<int, string>();
		private static Random random = new Random();

		public void Practice(string[] args)
		{
			var taskOne = Task.Factory.StartNew(Read);
			var taskTwo = Task.Factory.StartNew(Write, "Cazton");
			var taskThree = Task.Factory.StartNew(Read);
			var taskFour = Task.Factory.StartNew(Write, "Avi");
			var taskFive = Task.Factory.StartNew(Read);
			Task.WaitAll(taskOne, taskTwo, taskThree, taskFour, taskFive);
		}

		private void Read()
		{
			for (int i = 0; i < 10; i++)
			{
				readerWriterLockSlim.EnterReadLock();
				Thread.Sleep(50);
				readerWriterLockSlim.ExitReadLock();
			}
		}

		private void Write(object user)
		{
			for (int i = 0; i < 10; i++)
			{
				readerWriterLockSlim.EnterWriteLock();
				var person = $"Person{i}";
				persons.Add(GetRandom(), person);
				readerWriterLockSlim.ExitWriteLock();
				Console.WriteLine($"{user} added {person}.");
				Thread.Sleep(250);
			}
		}

		private int GetRandom()
		{
			lock (random)
			{
				return random.Next(2000, 5000);
			}
		}
	}
}