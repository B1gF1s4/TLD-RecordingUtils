namespace RecordingUtils.Commands
{
	public class CmdCamBloom : CommandBase
	{
		public CmdCamBloom() : base("cam_bloom")
		{ }

		public override string Execute()
		{
			return "not implemented yet";
			//if (Settings.ModSettings.EnableBloom)
			//{
			//	GameManager.GetCameraEffects().BloomEnable(false);
			//	Settings.ModSettings.EnableBloom = false;
			//	return "bloom disabled";
			//}
			//else
			//{
			//	GameManager.GetCameraEffects().BloomEnable(true);
			//	Settings.ModSettings.EnableBloom = true;
			//	return "bloom enabled";
			//}
		}
	}
}
