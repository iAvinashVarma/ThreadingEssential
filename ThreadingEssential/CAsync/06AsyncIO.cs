using LearnInfra.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingEssential.CAsync
{
	public class AsyncIO : ILearner
	{
		public void Practice(string[] args)
		{
			// Way #1
			var taskOne = new Task(() =>
			{
				Console.WriteLine("Task One!");
			});
			var taskTwo = taskOne.ContinueWith((tO) =>
			{
				Console.WriteLine("Task Continued!");
			});
			//Task.Run(() => taskOne);
			//Task.Run(() => taskTwo);
			//taskOne.Start();
			//taskOne.Wait();
			//taskTwo.Wait();
			Task.WaitAll(taskOne, taskTwo);

			// Way #2
			var taskFactory = new TaskFactory();
			taskFactory.StartNew(() =>
			{

			});
		}
	}
}
