using HarmonyLib;
using Il2Cpp;
using RecordingUtils.FreeBird;

namespace RecordingUtils.Patches
{
	[HarmonyPatch(typeof(PlayerAnimation), "UpdateFreeCameraLook")]
	public class PlayerAnimationPatch1
	{
		public static bool Prefix(ref FlyMode __instance)
		{
			if (FBCam.Instance == null)
				return true;

			return !FBCam.Instance.Enabled;
		}
	}

	[HarmonyPatch(typeof(PlayerAnimation), "Update")]
	public class PlayerAnimationPatch2
	{
		public static bool Prefix(ref FlyMode __instance)
		{
			if (FBCam.Instance == null)
				return true;

			return !FBCam.Instance.Enabled;
		}
	}
}
