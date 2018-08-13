using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncEssentialUnitTest
{
	[TestClass]
	public class DatabasesTest
	{
		private const string connectionString = "Integrated Security=SSPI;Data Source=WINAK185312-FUI;Initial Catalog=Sample;Persist Security Info=False;Integrated Security=True";
		private const string sqlSelect = "SELECT @@VERSION";
		private ManualResetEvent manualResetEvent = new ManualResetEvent(false);

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
		public void DatabaseBeginEndTest()
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
		public void DatabaseBeginEndSignalTest()
		{
			var sb = new StringBuilder();
			using (var sqlConnection = new SqlConnection(connectionString))
			{
				sqlConnection.Open();
				var sqlCommand = new SqlCommand(sqlSelect, sqlConnection);
				var callback = new AsyncCallback(DataAvailable);
				var asyncResult = sqlCommand.BeginExecuteReader(callback, sqlCommand);
				asyncResult.AsyncWaitHandle.WaitOne();
			}
			Assert.IsNotNull(sb);
		}

		[TestMethod]
		public void DatabaseAsyncTaskTest()
		{
			var sb = new StringBuilder();
			var sqlConnection = new SqlConnection(connectionString);
			var taskSqlConnection = sqlConnection.OpenAsync();
			taskSqlConnection.ContinueWith((sc, state) =>
			{
				var sqlConn = state as SqlConnection;
				Assert.IsTrue(sqlConn.State == System.Data.ConnectionState.Open);
				var sqlCommand = new SqlCommand(sqlSelect, sqlConn);
				var taskDataReader = sqlCommand.ExecuteReaderAsync();
				var taskProcessData = taskDataReader.ContinueWith((dr) =>
				{
					using (var reader = dr.Result)
					{
						while (reader.Read())
						{
							sb.AppendLine($"{reader[0]}");
						}
						manualResetEvent.Set();
					}
				}, TaskContinuationOptions.OnlyOnRanToCompletion);
			}, sqlConnection, TaskContinuationOptions.OnlyOnRanToCompletion);
			manualResetEvent.WaitOne();
			Assert.IsNotNull(sb);
		}

		public async Task DatabaseAsyncAwaitTest()
		{
			var sb = new StringBuilder();
			using (var sqlConnection = new SqlConnection(connectionString))
			{
				await sqlConnection.OpenAsync();
				using (var sqlCommand = new SqlCommand(sqlSelect, sqlConnection))
				{
					using (var reader = await sqlCommand.ExecuteReaderAsync())
					{
						while (reader.Read())
						{
							sb.AppendLine($"{reader[0]}");
						}
					}
				}
			}
			Assert.IsNotNull(sb);
		}

		private void DataAvailable(IAsyncResult asyncResult)
		{
			var sb = new StringBuilder();
			var sqlCommand = asyncResult.AsyncState as SqlCommand;
			using (var reader = sqlCommand.EndExecuteReader(asyncResult))
			{
				while (reader.Read())
				{
					sb.AppendLine($"{reader[0]}");
				}
			}
			Assert.IsNotNull(sb);
		}
	}
}