using RecordingUtils.Commands;

namespace ModTemplate.Commands
{
	public class CmdPlayerHeartbeat : CommandBase
	{
		public CmdPlayerHeartbeat() : base("player_heartbeat")
		{ }

		public override string Execute()
		{
			return "not implemented";
		}
	}
}
