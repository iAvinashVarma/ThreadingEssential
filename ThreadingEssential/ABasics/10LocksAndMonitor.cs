using LearnInfra.Interface;
using LearnInfra.Model;
using System;
using System.Threading.Tasks;

namespace ThreadingEssential.ABasics
{
	public class LocksAndMonitor : ILearner
	{
		public void Practice(string[] args)
		{
			var account = new Account(20000);
			var taskOne = Task.Factory.StartNew(() => account.WithdrawRandomly());
			var taskTwo = Task.Factory.StartNew(() => account.WithdrawRandomly());
			var taskThree = Task.Factory.StartNew(() => account.WithdrawRandomly());
			Task.WaitAll(taskOne, taskTwo, taskThree);
			Console.WriteLine("All tasks completed.");
		}
	}
}