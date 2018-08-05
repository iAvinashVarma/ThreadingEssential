using System.Diagnostics;
using ThreadingEssential.Interface;

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