using LearnInfra.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ThreadingEssential.CAsync
{
	public class TPLDemo : ILearner
	{
		public void Practice(string[] args)
		{
			Parallel.For(0, 100, i => Console.Write(i));
			var range = Enumerable.Range(1, 10000);
			Parallel.ForEach<int>(range, i => Console.Write(i));
		}
	}
}