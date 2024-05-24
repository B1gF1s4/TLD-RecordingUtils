using HarmonyLib;
using Il2Cpp;
using RecordingUtils.FreeBird;

namespace RecordingUtils.Patches
{
	[HarmonyPatch(typeof(InputManager), "ProcessInput")]
	public class InputManagerProcessInputPatch
	{
		public static bool Prefix(ref InputManager __instance)
		{
			if (FBCam.Instance == null)
				return true;

			return !FBCam.Instance.Enabled;
		}
	}
}
