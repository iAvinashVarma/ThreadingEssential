using System;
using System.Threading;
using ThreadingEssential.Interface;

namespace ThreadingEssential.ABasics
{
	public class ExceptionHandling : ILearner
	{
		public void Practice(string[] args)
		{
			Demo();
		}

		private void Demo()
		{
			try
			{
				// Worker Thread.
				new Thread(Execute).Start();
			}
			// Main Thread.
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}

		private void Execute()
		{
			try
			{
				throw null;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
	}
}