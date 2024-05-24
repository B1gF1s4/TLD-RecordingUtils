using HarmonyLib;
using Il2Cpp;
using RecordingUtils.FreeBird;
using UnityEngine;

namespace RecordingUtils.Patches
{
	[HarmonyPatch(typeof(vp_FPSCamera), "DoBob")]
	public class DoBobPatch
	{
		public static bool Prefix(ref vp_FPSCamera __instance, ref float speed, ref float time)
		{
			return Settings.ModSettings.CameraBob;
		}
	}

	[HarmonyPatch(typeof(vp_FPSCamera), "DoSwaying")]
	public class DoSway1Patch
	{
		public static bool Prefix(ref vp_FPSCamera __instance, ref Vector3 velocity)
		{
			return Settings.ModSettings.CameraSway;
		}
	}

	[HarmonyPatch(typeof(vp_FPSCamera), "UpdateAmbientSway")]
	public class DoSway2Patch
	{
		public static bool Prefix(ref vp_FPSCamera __instance, ref float fixedDeltaTime)
		{
			return Settings.ModSettings.CameraSway;
		}
	}

	[HarmonyPatch(typeof(vp_FPSCamera), "Awake")]
	public class FPSCamPatch1
	{
		public static void Postfix(ref vp_FPSCamera __instance)
		{
			if (!__instance.GetComponent<FBCam>())
			{
				__instance.gameObject.AddComponent<FBCam>();
			}
		}
	}

	[HarmonyPatch(typeof(vp_FPSCamera), "UpdateMouseLook")]
	public class FPSCamPatch2
	{
		public static bool Prefix(ref vp_FPSCamera __instance)
		{
			if (FBCam.Instance == null)
				return true;

			return !FBCam.Instance.Enabled;
		}
	}

	[HarmonyPatch(typeof(vp_FPSCamera), "UpdateCameraRotation")]
	public class FPSCamPatch3
	{
		public static bool Prefix(ref vp_FPSCamera __instance)
		{
			if (FBCam.Instance == null)
				return true;

			return !FBCam.Instance.Enabled;
		}
	}

	[HarmonyPatch(typeof(vp_FPSCamera), "RefreshCameraTransform")]
	public class FPSCamPatch4
	{
		public static bool Prefix(ref vp_FPSCamera __instance)
		{
			if (FBCam.Instance == null)
				return true;

			return !FBCam.Instance.Enabled;
		}
	}

	[HarmonyPatch(typeof(vp_FPSCamera), "UpdateShakes")]
	public class ShakesPatch
	{
		public static bool Prefix(ref vp_FPSCamera __instance, ref float fixedTime)
		{
			return Settings.ModSettings.CameraShake;
		}
	}
}
