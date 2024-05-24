using Il2Cpp;
using RecordingUtils;
using RecordingUtils.Commands;

namespace ModTemplate.Commands
{
	public class CmdCamBloom : CommandBase
	{
		public CmdCamBloom() : base("cam_bloom")
		{ }

		public override string Execute()
		{
			if (Settings.ModSettings.EnableBloom)
			{
				GameManager.GetCameraEffects().BloomEnable(false);
				Settings.ModSettings.EnableBloom = false;
				return "bloom disabled";
			}
			else
			{
				GameManager.GetCameraEffects().BloomEnable(true);
				Settings.ModSettings.EnableBloom = true;
				return "bloom enabled";
			}
		}
	}
}
