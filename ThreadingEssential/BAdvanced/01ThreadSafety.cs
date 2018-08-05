using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThreadingEssential.Interface;

namespace ThreadingEssential.BAdvanced
{
	internal class ThreadSafety : ILearner
	{
		private Dictionary<int, string> items = new Dictionary<int, string>();

		public void Practice(string[] args)
		{
			var taskOne = Task.Factory.StartNew(AddItem);
			var taskTwo = Task.Factory.StartNew(AddItem);
			var taskThree = Task.Factory.StartNew(AddItem);
			var taskFour = Task.Factory.StartNew(AddItem);
			var taskFive = Task.Factory.StartNew(AddItem);
			Task.WaitAll(taskThree, taskTwo, taskOne, taskFour, taskFive);
		}

		private void AddItem()
		{
			lock (items)
			{
				Console.WriteLine($"Lock #1 acquired by {Task.CurrentId}");
				items.Add(items.Count, $"Avi {items.Count}");
			}

			Dictionary<int, string> dictionary;
			lock (items)
			{
				Console.WriteLine($"Lock #2 acquired by {Task.CurrentId}");
				dictionary = items;
			}

			foreach (var kvp in dictionary)
			{
				Console.WriteLine($"{kvp.Key} {kvp.Value}");
			}
		}
	}
}