using LearnInfra.Enums;
using LearnInfra.Interface;

namespace LearnEssential.Learn
{
	public class LearnerFactory : ILearnerFactory
	{
		private ILearnerFactory learnerFactory;

		public LearnerFactory(EssentialMode essentialMode) => SetFactory(essentialMode);

		private void SetFactory(EssentialMode essentialMode)
		{
			switch (essentialMode)
			{
				case EssentialMode.Basic:
					learnerFactory = new BasicFactory();
					break;

				case EssentialMode.Advanced:
					learnerFactory = new AdvancedFactory();
					break;

				case EssentialMode.Async:
					learnerFactory = new AsyncFactory();
					break;
			}
		}

		public string Help => learnerFactory.Help;

		public ILearner GetLearner(int result) => learnerFactory.GetLearner(result);
	}
}