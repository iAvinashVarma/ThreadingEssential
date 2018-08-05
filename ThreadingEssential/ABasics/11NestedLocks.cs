using System.Threading.Tasks;
using ThreadingEssential.Interface;

namespace ThreadingEssential.ABasics
{
	internal class NestedLocks : ILearner
	{
		private static object caztonLock = new object();

		public void Practice(string[] args)
		{
			lock (caztonLock)
			{
				DoSomething();
			}
		}

		private void DoSomething()
		{
			lock (caztonLock)
			{
				Task.Delay(2000);
				AnotherMethod();
			}
		}

		private void AnotherMethod()
		{
			lock (caztonLock)
			{
			}
		}
	}
}