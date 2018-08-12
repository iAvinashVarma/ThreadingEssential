using LearnInfra;
using LearnInfra.Interface;
using LearnInfra.Model;
using System;
using System.Threading;

namespace ThreadingEssential.ABasics
{
	public class ThreadPoolDemo : ILearner
	{
		public void Practice(string[] args)
		{
			var employee = new Employee
			{
				Name = "Avinash",
				Company = "AVCorp"
			};
			ThreadPool.QueueUserWorkItem(new WaitCallback(Display), employee);
			var processorCount = Environment.ProcessorCount;
			Console.WriteLine($"Processor Count: {processorCount}");
			ThreadPool.SetMaxThreads(processorCount * 2, processorCount * 2);
			ThreadPool.GetMaxThreads(out int maxWorkerThreads, out int maxCompletionPortThreads);
			ThreadPool.GetMinThreads(out int minWorkerThreads, out int minCompletionPortThreads);
			Console.WriteLine($"Max Worker Threads: {maxWorkerThreads} | Min Worker Threads: {minWorkerThreads}.");
			Console.WriteLine($"Max Completion Port Threads: {maxCompletionPortThreads} | Min Completion Port Threads: {minCompletionPortThreads}.");
			Console.WriteLine($"Out Display: {Thread.CurrentThread.IsThreadPoolThread}");
		}

		private void Display(object employee)
		{
			Console.WriteLine($"In Display: {Thread.CurrentThread.IsThreadPoolThread}");
			var emp = employee as Employee;
			Console.WriteLine($"Person name is {emp.Name} | Company name is {emp.Company}.");
		}
	}
}