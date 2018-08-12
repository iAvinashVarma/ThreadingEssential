using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnInfra.Interface;
using ThreadingEssential.BAdvanced;

namespace LearnEssential.Learn
{
	public class AdvancedFactory : ILearnerFactory
	{
		public string Help
		{
			get
			{
				var sb = new StringBuilder();
				sb.AppendLine("** I. Signaling and Thread Concepts **");
				sb.AppendLine("1 => ThreadSafety");
				sb.AppendLine("2 => ThreadAffinityApp");
				sb.AppendLine("3 => SignalAutoEvent");
				sb.AppendLine("4 => TwoWaySignal");
				sb.AppendLine("5 => SignalManualEvent");
				sb.AppendLine("6 => CountDown");
				sb.AppendLine("** II. Task Parallel Library (TPL) **");
				sb.AppendLine("7 => TPLIntro");
				sb.AppendLine("8 => ParallelVsNormal");
				sb.AppendLine("9 => Cancellation");
				sb.AppendLine("10 => ContinuationWithState");
				sb.AppendLine("11 => TaskCompletionSource");
				sb.AppendLine("** III. Parallel LINQ (PLINQ) **");
				sb.AppendLine("12 => PLINQIntro");
				sb.AppendLine("13 => PLINQDegreeParallelism");
				sb.AppendLine("14 => PLINQForAll");
				sb.AppendLine("15 => PLINQMergeOptions");
				sb.AppendLine("** IV. Task-Based Asynchronous Pattern (TAP) **");
				sb.AppendLine("16 => TAPIntro");
				return sb.ToString();
			}
		}

		public ILearner GetLearner(int result)
		{
			ILearner learner = null;
			switch (result)
			{
				case 1:
					learner = new ThreadSafety();
					break;

				case 2:
					learner = new ThreadAffinityApp();
					break;

				case 3:
					learner = new SignalAutoEvent();
					break;

				case 4:
					learner = new TwoWaySignal();
					break;

				case 5:
					learner = new SignalManualReset();
					break;

				case 6:
					learner = new CountDown();
					break;

				case 7:
					learner = new TPLIntro();
					break;

				case 8:
					learner = new ParallelVsNormal();
					break;

				case 9:
					learner = new Cancellation();
					break;

				case 10:
					learner = new ContinuationWithState();
					break;

				case 11:
					learner = new TaskCompletionSource();
					break;

				case 12:
					learner = new PLINQIntro();
					break;

				case 13:
					learner = new PLINQDegreeParallelism();
					break;

				case 14:
					learner = new PLINQForAll();
					break;

				case 15:
					learner = new PLINQMergeOptions();
					break;

				case 16:
					learner = new TAPIntro();
					break;

				default:
					learner = new ThreadSafety();
					break;
			}
			return learner;
		}
	}
}
