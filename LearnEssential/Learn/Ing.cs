using LearnInfra.Enums;
using LearnInfra.Interface;
using LearnInfra.Extension;
using System;
using System.Linq;
using System.Reflection;

namespace LearnEssential.Learn
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
			Console.Write($"Enter Mode {string.Join(", ", ((EssentialMode)1).GetDictionary().Select(x => $"{x.Key} => {x.Value}"))} : ");
			int.TryParse(Console.ReadLine(), out int mode);
			var essentialMode = mode != 0 ? (EssentialMode)mode : EssentialMode.Basic;
			var factory = new LearnerFactory(essentialMode);
			Console.Write("{0} Concepts:{1}{2}Enter {0} concept number (E.g. 1) : ", essentialMode, Environment.NewLine, factory.Help);
			int.TryParse(Console.ReadLine(), out int result);
			ILearner learner = factory.GetLearner(result);
			Console.WriteLine(seperator);
			learner.Practice(args);
			Console.WriteLine(seperator);
		}
	}
}