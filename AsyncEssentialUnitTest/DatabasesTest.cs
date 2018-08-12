using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;

namespace AsyncEssentialUnitTest
{
	[TestClass]
	public class DatabasesTest
	{
		private const string connectionString = "Integrated Security=SSPI;Data Source=WINAK185312-FUI;Initial Catalog=Sample;Persist Security Info=False;Integrated Security=True";
		private const string sqlSelect = "SELECT @@VERSION";

		[TestMethod]
		public void DatabaseSyncTest()
		{
			using (var sqlConnection = new SqlConnection(connectionString))
			{
				sqlConnection.Open();
				using (var sqlCommand = new SqlCommand(sqlSelect, sqlConnection))
				{
					using (var reader = sqlCommand.ExecuteReader())
					{
						while (reader.Read())
						{
							var data = $"{reader[0]}";
						}
					}
				}
			}
		}

		[TestMethod]
		public void DatabaseAsyncTest()
		{
			using (var sqlConnection = new SqlConnection(connectionString))
			{
				sqlConnection.Open();
				var sqlCommand = new SqlCommand(sqlSelect, sqlConnection);
				var callback = new AsyncCallback(DataAvailable);
				var asyncResult = sqlCommand.BeginExecuteReader(callback, sqlCommand);
			}
		}

		[TestMethod]
		public void DatabaseAsyncSignalingTest()
		{
			using (var sqlConnection = new SqlConnection(connectionString))
			{
				sqlConnection.Open();
				var sqlCommand = new SqlCommand(sqlSelect, sqlConnection);
				var callback = new AsyncCallback(DataAvailable);
				var asyncResult = sqlCommand.BeginExecuteReader(callback, sqlCommand);
				asyncResult.AsyncWaitHandle.WaitOne();
			}
		}

		private void DataAvailable(IAsyncResult asyncResult)
		{
			var sqlCommand = asyncResult.AsyncState as SqlCommand;
			using (var reader = sqlCommand.EndExecuteReader(asyncResult))
			{
				while (reader.Read())
				{
					var data = $"{reader[0]}";
				}
			}
		}
	}
}