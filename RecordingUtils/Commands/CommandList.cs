﻿using ModTemplate.Commands;

namespace RecordingUtils.Commands
{
	public static class CommandList
	{
		public static List<CommandBase> Commands = new();

		public static CmdCamBloom CmdCamBloom = new();

		public static void Init()
		{
			Commands.Add(new CmdCamSave());
			Commands.Add(new CmdCamLoad());
			Commands.Add(new CmdToggleFreeBird());
			Commands.Add(CmdCamBloom);
			Commands.Add(new CmdPlayerHeartbeat());
			Commands.Add(new CmdPlayerStumble());

			foreach (var cmd in Commands)
			{
				cmd.AddToConsole();
			}
		}
	}
}
