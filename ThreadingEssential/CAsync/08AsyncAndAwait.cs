using LearnInfra.Interface;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ThreadingEssential.CAsync
{
	public class AsyncAndAwait : ILearner
	{
		public void Practice(string[] args)
		{
			var url = "http://www.deelay.me/1000/http://www.google.com/";
			var downloadData = DownloadAsync(url).GetAwaiter().GetResult();
		}

		private async Task<byte[]> DownloadAsync(string url)
		{
			using (var downloader = new WebClient())
			{
				return await downloader.DownloadDataTaskAsync(url);
			}
		}
	}
}
