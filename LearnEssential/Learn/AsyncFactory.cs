using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnInfra.Interface;
using ThreadingEssential.CAsync;

namespace LearnEssential.Learn
{
	class AsyncFactory : ILearnerFactory
	{
		public string Help
		{
			get
			{
				var sb = new StringBuilder();
				sb.AppendLine("** I. Windows Forms **");
				sb.AppendLine("1 => DownloadForm");
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

				default:
					learner = new DownloadWinForm();
					break;
			}
			return learner;
		}
	}
}
