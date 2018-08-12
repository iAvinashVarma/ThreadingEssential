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
			var asyAVCorpesult = doWork.BeginInvoke(asyncCallback, doWork);
			asyAVCorpesult.AsyncWaitHandle.WaitOne();
		}

		private void TheCallBack(IAsyncResult asyAVCorpesult)
		{
			var doWork = asyAVCorpesult.AsyncState as DoWorkDelegate;
			doWork.EndInvoke(asyAVCorpesult);
		}
	}
}