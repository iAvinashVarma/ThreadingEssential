using LearnEssential.Interface;
using System.Diagnostics;

namespace ThreadingEssential.BAdvanced
{
	internal class ThreadAffinityApp : ILearner
	{
		public void Practice(string[] args)
		{
			Process.Start("ThreadAffinity.exe");
		}
	}
}