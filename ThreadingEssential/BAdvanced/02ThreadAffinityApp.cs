using LearnInfra.Interface;
using System.Diagnostics;

namespace ThreadingEssential.BAdvanced
{
	public class ThreadAffinityApp : ILearner
	{
		public void Practice(string[] args)
		{
			Process.Start("ThreadAffinity.exe");
		}
	}
}