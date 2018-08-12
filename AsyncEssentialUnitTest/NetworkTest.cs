using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Net;

namespace AsyncEssentialUnitTest
{
	[TestClass]
	public class NetworkTest
	{
		private const string url = "http://www.deelay.me/1000/http://www.google.com/";

		[TestMethod]
		public void DownloadLinkSyncTest()
		{
			var httpRequestInfo = HttpWebRequest.CreateHttp(url);
			var httpResponseInfo = httpRequestInfo.GetResponse() as HttpWebResponse;
			var responseStream = httpResponseInfo.GetResponseStream();
			using (var sr = new StreamReader(responseStream))
			{
				var webPage = sr.ReadToEnd();
			}
		}

		[TestMethod]
		public void DownloadLinkTestAsync()
		{
			var httpRequestInfo = HttpWebRequest.CreateHttp(url);
			var httpCallback = new AsyncCallback(HttpResponseAvailable);
			var asyncResult = httpRequestInfo.BeginGetResponse(httpCallback, httpRequestInfo);
		}

		[TestMethod]
		public void DownloadLinkTestSignalling()
		{
			var httpRequestInfo = HttpWebRequest.CreateHttp(url);
			var httpCallback = new AsyncCallback(HttpResponseAvailable);
			var asyncResult = httpRequestInfo.BeginGetResponse(httpCallback, httpRequestInfo);
			asyncResult.AsyncWaitHandle.WaitOne();
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
	}
}