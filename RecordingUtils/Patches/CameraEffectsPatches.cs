using HarmonyLib;
using Il2Cpp;
using RecordingUtils;

namespace ModTemplate.Patches
{
	[HarmonyPatch(typeof(CameraEffects), nameof(CameraEffects.Update))]
	public class CameraEffectsUpdatePatch
	{
		public static void Postfix()
		{
			if (Settings.RequiresBloomReset)
				GameManager.GetCameraEffects()
					.BloomEnable(Settings.ModSettings.EnableBloom);
		}
	}
}
