using LearnInfra.Extension;
using LearnInfra.Interface;
using System.Reflection;
using System.Text;
using ThreadingEssential.CAsync;

namespace LearnEssential.Learn
{
	internal class AsyncFactory : ILearnerFactory
	{
		public string Help
		{
			get
			{
				var sb = new StringBuilder();
				var learning = Classes.GetTypesInNamespace<ILearner>(Assembly.LoadFrom("ThreadingEssential.dll"), "ThreadingEssential.CAsync");
				sb.AppendLine("** I. Windows Forms **");
				sb.AppendLine("1 => DownloadForm");
				sb.AppendLine("** II. Hard MultiThreading **");
				sb.AppendLine("2 => Threads");
				sb.AppendLine("3 => ThreadSafety");
				sb.AppendLine("4 => EasyPools");
				sb.AppendLine("5 => SignalManualReset");
				sb.AppendLine("** III. Less Hard MultiThreading **");
				sb.AppendLine("6 => AsyncIO");
				sb.AppendLine("7 => TPLDemo");
				sb.AppendLine("** IV. Async and Await **");
				sb.AppendLine("8 => Async and Await");
				sb.AppendLine("9 => ConcurrentQueue");
				sb.AppendLine("10 => ConcurrentDictionary");
				sb.AppendLine("11 => BlockingCollection");
				return sb.ToString();
			}
		}

		public ILearner GetLearner(int result)
		{
			ILearner learner = null;
			switch (result)
			{
				case 1:
					learner = new DownloadWinForm();
					break;

				case 2:
					learner = new Threads();
					break;

				case 3:
					learner = new ThreadSafety();
					break;

				case 4:
					learner = new EasyPools();
					break;

				case 5:
					learner = new SignalManualReset();
					break;

				case 6:
					learner = new AsyncIO();
					break;

				case 7:
					learner = new TPLDemo();
					break;

				case 8:
					learner = new AsyncAndAwait();
					break;

				case 9:
					learner = new ConcurrentQueueDemo();
					break;

				case 10:
					learner = new ConcurrentDictionaryDemo();
					break;

				case 11:
					learner = new ProduceConsumer();
					break;

				default:
					learner = new DownloadWinForm();
					break;
			}
			return learner;
		}
	}
}