﻿using ModTemplate.Commands;

namespace RecordingUtils.Commands
{
	public static class CommandList
	{
		public static List<CommandBase> Commands = new();

		public static void Init()
		{
			Commands.Add(new CmdCamSave());
			Commands.Add(new CmdCamLoad());

			foreach (var cmd in Commands)
			{
				cmd.AddToConsole();
			}
		}
	}
}
