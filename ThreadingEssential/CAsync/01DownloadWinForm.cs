using LearnEssential.Interface;
using System.Diagnostics;

namespace ThreadingEssential.CAsync
{
	class DownloadWinForm : ILearner
	{
		public void Practice(string[] args)
		{
			var form = Process.Start("DownloadForm.exe");
		}
	}
}
