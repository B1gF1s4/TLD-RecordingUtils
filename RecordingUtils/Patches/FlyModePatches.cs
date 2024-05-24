using HarmonyLib;
using Il2Cpp;
using RecordingUtils;

namespace ModTemplate.Patches
{
	[HarmonyPatch(typeof(FlyMode), nameof(FlyMode.Update))]
	internal class FlyModeUpdatePatch
	{
		internal static void Postfix(FlyMode __instance)
		{
			__instance.m_MoveSpeedNormal = Settings.ModSettings.SpeedRegular;
			__instance.m_MoveSpeedFast = Settings.ModSettings.SpeedFast;
			__instance.m_MoveSpeedSlow = Settings.ModSettings.SpeedSlow;
		}
	}
}
