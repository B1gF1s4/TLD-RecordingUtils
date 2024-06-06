using HarmonyLib;
using Il2Cpp;
using RecordingUtils.Commands;
using RecordingUtils.FreeBird;
using UnityEngine;

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

		public static void Postfix(ref InputManager __instance)
		{
			if (Input.GetKeyDown(Settings.ModSettings.Freeze))
				uConsole.print(CommandList.CmdAnimalFreeze.Execute());

			if (Input.GetKeyDown(Settings.ModSettings.Wander))
				uConsole.print(CommandList.CmdAnimalWanderToMyLocation.Execute());
		}
	}

}
