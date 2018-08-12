using LearnInfra.Interface;
using System.Threading.Tasks;

namespace ThreadingEssential.ABasics
{
	public class NestedLocks : ILearner
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