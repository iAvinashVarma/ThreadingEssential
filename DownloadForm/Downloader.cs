using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;

namespace DownloadForm
{
	/// <summary>
	/// Demonstrate what happens when an IO operation blocks the UI thread.
	/// </summary>
	/// <remarks>
	/// Windows SDK ISO (Large Download):
	/// https://go.microsoft.com/fwlink/p/?linkid=845299
	///
	/// Artificially Slow Down HTTP Requests:
	/// http://www.deelay.me/5000/http://www.delsink.com
	/// </remarks>
	public partial class Downloader : Form
	{
		private DateTime _startTime = DateTime.MaxValue;

		public Downloader() => InitializeComponent();

		private void Bw_Download_DoWork(object sender, DoWorkEventArgs e)
		{
			Invoke(new Action(DownloadingUI));

			// Do not modify the UI controls in this thread.
			using (var downloader = new WebClient())
			{
				var page = downloader.DownloadString(Tb_Url.Text);
			}

			Invoke(new Action(DownloaderUI));
		}

		private void DownloadingUI() => Text = "Downloading!";

		private void DownloaderUI() => Text = "Downloader";

		private void DownloadButtons(bool isEnable = true)
		{
			Btn_DownloadSync.Enabled = isEnable;
			Btn_DownloadAsync.Enabled = isEnable;
		}

		private void StartTimer()
		{
			_startTime = DateTime.UtcNow;
			ShowDuration();
			Tmr_Watch.Enabled = true;
		}

		private void Bw_Download_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			StopTimer();
			DownloadButtons();
		}

		private void StopTimer()
		{
			Tmr_Watch.Enabled = false;
			ShowDuration();
		}

		private void ShowDuration() => Lbl_Duration.Text = $"Duration: {(DateTime.UtcNow - _startTime).TotalMilliseconds}MS";

		private void Btn_DownloadSync_Click(object sender, EventArgs e)
		{
			DownloadButtons(false);
			StartTimer();
			using (var downloader = new WebClient())
			{
				var page = downloader.DownloadString(Tb_Url.Text);
			}
			StopTimer();
			DownloadButtons();
		}

		private void Btn_DownloadAsync_Click(object sender, EventArgs e)
		{
			DownloadButtons(false);
			StartTimer();
			Bw_Download.RunWorkerAsync();
		}

		private void Tmr_Watch_Tick(object sender, EventArgs e) => ShowDuration();
	}
}