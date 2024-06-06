using Il2Cpp;

namespace RecordingUtils.Commands
{
	public class CmdAnimalWanderToMyLocation : CommandBase
	{
		public CmdAnimalWanderToMyLocation() : base("animal_wander")
		{ }

		public override string Execute()
		{
			var animals = AiUtils.GetAisWithinRange(
				GameManager.GetCurrentCamera().transform.position,
				Settings.ModSettings.AnimalControlRadius);

			if (animals == null || animals.Count <= 0)
				return "no animals found";

			var pos = GameManager.GetCurrentCamera().transform.position;

			foreach (var animal in animals)
			{
				animal.SetAiMode(AiMode.Idle);
				animal.ForceWanderToPoint(pos);
			}

			return $"{animals.Count} animals in a {Settings.ModSettings.AnimalControlRadius} m radius affected";
		}
	}
}
