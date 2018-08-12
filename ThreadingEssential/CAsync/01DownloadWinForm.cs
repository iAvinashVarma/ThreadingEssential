using LearnInfra.Interface;
using System.Diagnostics;

namespace ThreadingEssential.CAsync
{
	public class DownloadWinForm : ILearner
	{
		public void Practice(string[] args)
		{
			var form = Process.Start("DownloadForm.exe");
		}
	}
}