using LearnEssential.Interface;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingEssential.BAdvanced
{
	internal class TAPIntro : ILearner
	{
		public void Practice(string[] args)
		{
			var tokenSource = new CancellationTokenSource();
			var token = tokenSource.Token;

			Task.Factory.StartNew(() =>
			{
				Thread.Sleep(4000);
				tokenSource.Cancel();
			});
			DownloadAsync(new Uri("https://jsonplaceholder.typicode.com/posts"), token).Wait();
		}

		private async Task DownloadAsync(Uri uri, CancellationToken cancellationToken)
		{
			while (true)
			{
				cancellationToken.ThrowIfCancellationRequested();
				try
				{
					HttpResponseMessage result = await GetAsync(uri);
					Console.WriteLine($"Result is {result}");
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex);
				}
			}
		}

		private Task<HttpResponseMessage> GetAsync(Uri uri)
		{
			var client = new HttpClient();
			return client.GetAsync(uri);
		}
	}
}