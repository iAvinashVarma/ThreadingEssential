using LearnInfra.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingEssential.ABasics
{
	public class TasksIntro : ILearner
	{
		public void Practice(string[] args)
		{
			var task = new Task(SimpleMethod);
			task.Start();

			var taskThatReturns = new Task<string>(MethodThatReturns);
			taskThatReturns.Start();
			taskThatReturns.Wait();
			Console.WriteLine(taskThatReturns.Result);
		}

		private string MethodThatReturns()
		{
			Thread.Sleep(2000);
			return "Hello";
		}

		private void SimpleMethod()
		{
			Console.WriteLine("Hello World");
		}
	}
}