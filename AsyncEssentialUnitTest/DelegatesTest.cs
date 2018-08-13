using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading;

namespace AsyncEssentialUnitTest
{
	[TestClass]
	public class DelegatesTest
	{
		private void DoWork()
		{
			Debug.WriteLine("Hello World");
			Debug.WriteLine($"Demo Work Thread: {Thread.CurrentThread.ManagedThreadId}");
		}

		private delegate void DoWorkDelegate();

		[TestMethod]
		public void CheckDelegateAsyncOperation()
		{
			Debug.WriteLine($"Demo One Thread: {Thread.CurrentThread.ManagedThreadId}");
			var doWork = new DoWorkDelegate(DoWork);
			var asyncCallback = new AsyncCallback(TheCallBack);
			var asyncResult = doWork.BeginInvoke(asyncCallback, doWork);
			asyncResult.AsyncWaitHandle.WaitOne();
		}

		private void TheCallBack(IAsyncResult asyncResult)
		{
			var doWork = asyncResult.AsyncState as DoWorkDelegate;
			doWork.EndInvoke(asyncResult);
		}
	}
}