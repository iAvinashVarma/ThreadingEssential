using LearnInfra.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingEssential.CAsync
{
	public class ThreadSafety : ILearner
	{
		private List<int> numbers = new List<int>();
		private object currentLock = new object();

		public void Practice(string[] args)
		{
			Console.WriteLine("Starting in the main method.");
			new Thread(new ThreadStart(AddToList))
			{
				Name = "Thread One"
			}.Start();

			new Thread(new ThreadStart(AddToList))
			{
				Name = "Thread Two"
			}.Start();

			new Thread(new ThreadStart(AddToList))
			{
				Name = "Thread Three"
			}.Start();

			new Thread(new ThreadStart(AddToList))
			{
				Name = "Thread Four"
			}.Start();

			new Thread(new ThreadStart(AddToList))
			{
				Name = "Thread Five"
			}.Start();

			Console.WriteLine("Ending in the main method.");
		}

		private void AddToList()
		{
			lock (currentLock)
			{
				for (int i = 0; i < 1000; i++)
				{
					numbers.Add(i);
				} 
			}
		}
	}
}
