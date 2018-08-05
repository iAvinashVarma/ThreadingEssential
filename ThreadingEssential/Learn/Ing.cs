using System;
using ThreadingEssential.Interface;

namespace ThreadingEssential.Learn
{
	public class Ing : ILearner
	{
		private static readonly Lazy<Ing> lazy = new Lazy<Ing>(() => new Ing());
		private const string seperator = "-----------------------------------------------------------------";

		private Ing()
		{
		}

		public static Ing Instance => lazy?.Value;

		public void Practice(string[] args)
		{
			Console.Write("Enter Mode (1 => Basics or 2 => Advanced) : ");
			int.TryParse(Console.ReadLine(), out int mode);
			var essentialMode = mode != 0 ? (EssentialMode)mode : EssentialMode.Basic;
			var factory = new Factory(essentialMode);
			Console.Write("{0} Concepts:{1}{2}Enter {0} concept number (E.g. 1) : ", essentialMode, Environment.NewLine, factory.ConceptHelp);
			int.TryParse(Console.ReadLine(), out int result);
			ILearner learner = factory.GetLearner(result);
			Console.WriteLine(seperator);
			learner.Practice(args);
			Console.WriteLine(seperator);
		}
	}
}