using LearnInfra.Interface;

namespace LearnEssential.Learn
{
	public interface ILearnerFactory
	{
		string Help { get; }

		ILearner GetLearner(int result);
	}
}