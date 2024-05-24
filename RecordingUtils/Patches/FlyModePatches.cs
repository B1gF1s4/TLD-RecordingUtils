using HarmonyLib;
using Il2Cpp;
using RecordingUtils.FreeBird;

namespace RecordingUtils.Patches
{
	[HarmonyPatch(typeof(FlyMode), nameof(FlyMode.Update))]
	internal class FlyModeUpdatePatch
	{
		internal static void Postfix(ref FlyMode __instance)
		{
			if (__instance == null)
				return;

			__instance.m_MoveSpeedNormal = Settings.ModSettings.SpeedRegular;
			__instance.m_MoveSpeedFast = Settings.ModSettings.SpeedFast;
			__instance.m_MoveSpeedSlow = Settings.ModSettings.SpeedSlow;
		}
	}

	[HarmonyPatch(typeof(FlyMode), nameof(FlyMode.LateUpdate))]
	internal class FlyModeLateUpdatePatch
	{
		internal static bool Prefix(ref FlyMode __instance)
		{
			if (FBCam.Instance == null)
				return true;

			return !FBCam.Instance.Enabled;
		}
	}
}
