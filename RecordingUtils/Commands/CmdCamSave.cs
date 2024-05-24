using Il2Cpp;
using ModTemplate.Models;
using RecordingUtils;
using RecordingUtils.Commands;
using System.Text.Json;

namespace ModTemplate.Commands
{
	internal class CmdCamSave : CommandBase
	{
		public CmdCamSave() : base("cam_save")
		{ }

		public override string Execute()
		{
			if (!FlyMode.m_Enabled)
				return "cam_save only works in flymode";

			var transform = GameManager.GetCurrentCamera().transform;

			var pos = new CamPos()
			{
				PosX = transform.position.x,
				PosY = transform.position.y,
				PosZ = transform.position.z,
				RotX = transform.rotation.x,
				RotY = transform.rotation.y,
				RotZ = transform.rotation.z,
				RotW = transform.rotation.w,
				SceneName = GameManager.m_ActiveScene
			};

			var posJson = JsonSerializer.Serialize(pos);
			Settings.DataManager.Save(posJson, "cam_pos");

			return posJson;
		}
	}
}
