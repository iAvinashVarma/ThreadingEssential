using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnInfra.Interface;
using ThreadingEssential.ABasics;

namespace LearnEssential.Learn
{
	class BasicFactory : ILearnerFactory
	{
		public string Help
		{
			get
			{
				var sb = new StringBuilder();
				sb.AppendLine("** I. Introduction to Threading **");
				sb.AppendLine("1 => ContextSwitching");
				sb.AppendLine("2 => SharedResources");
				sb.AppendLine("3 => LocalMemory");
				sb.AppendLine("4 => ThreadPoolDemo");
				sb.AppendLine("5 => Concepts");
				sb.AppendLine("6 => ExceptionHandling");
				sb.AppendLine("** II. Tasks **");
				sb.AppendLine("7 => TasksIntro");
				sb.AppendLine("8 => TasksIOBound");
				sb.AppendLine("9 => TasksChaining");
				sb.AppendLine("** III. Synchronization **");
				sb.AppendLine("10 => LocksAndMonitor");
				sb.AppendLine("11 => NestedLocks");
				sb.AppendLine("12 => DeadLocks");
				sb.AppendLine("13 => ReaderWriterLock");
				sb.AppendLine("14 => MutexLock");
				sb.AppendLine("15 => Semaphores");
				return sb.ToString();
			}
		}

		public ILearner GetLearner(int result)
		{
			ILearner learner = null;
			switch (result)
			{
				case 1:
					learner = new ContextSwitching(1000);
					break;

				case 2:
					learner = new SharedResources();
					break;

				case 3:
					learner = new LocalMemory();
					break;

				case 4:
					learner = new ThreadPoolDemo();
					break;

				case 5:
					learner = new Concepts();
					break;

				case 6:
					learner = new ExceptionHandling();
					break;

				case 7:
					learner = new TasksIntro();
					break;

				case 8:
					learner = new TasksIOBound();
					break;

				case 9:
					learner = new TasksChaining();
					break;

				case 10:
					learner = new LocksAndMonitor();
					break;

				case 11:
					learner = new NestedLocks();
					break;

				case 12:
					learner = new DeadLocks();
					break;

				case 13:
					learner = new ReaderWriterLock();
					break;

				case 14:
					learner = new MutexLock();
					break;

				case 15:
					learner = new Semaphores();
					break;

				default:
					learner = new ContextSwitching(10);
					break;
			}
			return learner;
		}
	}
}
