using Il2Cpp;
using RecordingUtils.FreeBird;
using RecordingUtils.Models;
using System.Text.Json;
using UnityEngine;

namespace RecordingUtils.Commands
{
	internal class CmdCamLoad : CommandBase
	{
		public CmdCamLoad() : base("cam_load")
		{ }

		public override string Execute()
		{
			if (!FlyMode.m_Enabled && (FBCam.Instance == null || !FBCam.Instance.Enabled))
				return "cam_load only works in flymode";

			var pos = Settings.DataManager.Load("cam_pos");

			if (pos == null)
				return "no camera save found";

			var camPos = JsonSerializer.Deserialize<CamPos>(pos);

			if (camPos == null)
				return "error deserializing camera pos";

			if (string.IsNullOrEmpty(camPos.SceneName) ||
				camPos.SceneName != GameManager.m_ActiveScene)
				return $"last cam save is tied to scene {camPos.SceneName}";

			var position = new Vector3(
				camPos.PosX, camPos.PosY, camPos.PosZ);

			var rotation = new Quaternion(
				camPos.RotX, camPos.RotY, camPos.RotZ, camPos.RotW);

			FlyMode.Warp(position, rotation);

			return "camera position loaded";
		}
	}
}
