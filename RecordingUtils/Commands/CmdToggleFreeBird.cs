using RecordingUtils.Commands;
using RecordingUtils.FreeBird;

namespace RecordingUtils.Commands
{
	public class CmdToggleFreeBird : CommandBase
	{
		public CmdToggleFreeBird() : base("cam_freebird")
		{ }

		public override string Execute()
		{
			if (FBCam.Instance == null)
				return "error initializing FreeBird cam";

			FBCam.Instance.Toggle();

			if (FBCam.Instance.Enabled)
				return "FreeBird cam activated";
			else
				return "FreeBird cam deactivated";
		}
	}
}
