using LearnInfra.Interface;
using System.Linq;

namespace ThreadingEssential.BAdvanced
{
	public class PLINQMergeOptions : ILearner
	{
		public void Practice(string[] args)
		{
			var range = Enumerable.Range(1, 10);
			var query = from n in range.AsParallel()
						.WithMergeOptions(ParallelMergeOptions.FullyBuffered)
						select n;
		}
	}
}