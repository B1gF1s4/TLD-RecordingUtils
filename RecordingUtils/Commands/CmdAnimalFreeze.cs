using Il2Cpp;

namespace RecordingUtils.Commands
{
	public class CmdAnimalFreeze : CommandBase
	{
		public CmdAnimalFreeze() : base("animal_freeze")
		{ }

		public override string Execute()
		{
			var animals = AiUtils.GetAisWithinRange(
				GameManager.GetCurrentCamera().transform.position,
				Settings.ModSettings.AnimalControlRadius);

			if (animals == null || animals.Count <= 0)
				return "no animals found";

			foreach (var animal in animals)
			{
				var shouldFreeze = animal.m_Animator.enabled;
				animal.m_Animator.enabled = !shouldFreeze;

				if (shouldFreeze)
					animal.SetAiMode(AiMode.WanderPaused);
				else
					animal.SetAiMode(AiMode.Wander);
			}

			return $"{animals.Count} animals in a {Settings.ModSettings.AnimalControlRadius} m radius affected";
		}
	}
}
