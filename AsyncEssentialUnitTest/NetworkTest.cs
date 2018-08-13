using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace AsyncEssentialUnitTest
{
	[TestClass]
	public class NetworkTest
	{
		private const string url = "http://www.deelay.me/1000/http://www.google.com/";

		[TestMethod]
		public void DownloadLinkSyncTest()
		{
			var httpRequestInfo = WebRequest.CreateHttp(url);
			var httpResponseInfo = httpRequestInfo.GetResponse() as HttpWebResponse;
			var responseStream = httpResponseInfo.GetResponseStream();
			using (var sr = new StreamReader(responseStream))
			{
				var webPage = sr.ReadToEnd();
			}
		}

		[TestMethod]
		public void DownloadLinkBeginEndTest()
		{
			var httpRequestInfo = WebRequest.CreateHttp(url);
			var httpCallback = new AsyncCallback(HttpResponseAvailable);
			var asyncResult = httpRequestInfo.BeginGetResponse(httpCallback, httpRequestInfo);
		}

		[TestMethod]
		public void DownloadLinkAsyncTaskTest()
		{
			var httpRequestInfo = HttpWebRequest.CreateHttp(url);
			var taskWebResponse = httpRequestInfo.GetResponseAsync();
			var taskContinuation = taskWebResponse.ContinueWith(HttpResponseContinuation, TaskContinuationOptions.OnlyOnRanToCompletion);
			Task.WaitAll(taskWebResponse, taskContinuation);
		}

		[TestMethod]
		public void DownloadLinkBeginEndSignalTest()
		{
			var httpRequestInfo = WebRequest.CreateHttp(url);
			var httpCallback = new AsyncCallback(HttpResponseAvailable);
			var asyncResult = httpRequestInfo.BeginGetResponse(httpCallback, httpRequestInfo);
			asyncResult.AsyncWaitHandle.WaitOne();
		}

		[TestMethod]
		public async Task DownloadLinkAsyncAwaitTest()
		{
			var httpRequestInfo = WebRequest.CreateHttp(url);
			var httpResponseInfo = await httpRequestInfo.GetResponseAsync();
			var responseStream = httpResponseInfo.GetResponseStream();
			using (var sr = new StreamReader(responseStream))
			{
				var webPage = await sr.ReadToEndAsync();
			}
		}

		private void HttpResponseAvailable(IAsyncResult asyncResult)
		{
			var httpRequestInfo = asyncResult.AsyncState as HttpWebRequest;
			var httpResponseInfo = httpRequestInfo.EndGetResponse(asyncResult) as HttpWebResponse;
			var responseStream = httpResponseInfo.GetResponseStream();
			using (var sr = new StreamReader(responseStream))
			{
				var webPage = sr.ReadToEnd();
			}
		}

		private void HttpResponseContinuation(Task<WebResponse> taskWebResponse)
		{
			var httpResponseInfo = taskWebResponse.Result as WebResponse;
			var responseStream = httpResponseInfo.GetResponseStream();
			using (var sr = new StreamReader(responseStream))
			{
				var webPage = sr.ReadToEnd();
			}
		}
	}
}