namespace RecordingUtils.Commands
{
	public static class CommandList
	{
		public static List<CommandBase> Commands = new();

		public static CmdCamBloom CmdCamBloom = new();

		public static CmdAnimalFreeze CmdAnimalFreeze = new();

		public static CmdAnimalWanderToMyLocation CmdAnimalWanderToMyLocation = new();

		public static void Init()
		{
			Commands.Add(new CmdCamSave());
			Commands.Add(new CmdCamLoad());
			Commands.Add(new CmdToggleFreeBird());
			//Commands.Add(CmdCamBloom);
			//Commands.Add(new CmdPlayerHeartbeat());
			//Commands.Add(new CmdPlayerStumble());
			Commands.Add(CmdAnimalFreeze);
			Commands.Add(CmdAnimalWanderToMyLocation);

			foreach (var cmd in Commands)
			{
				cmd.AddToConsole();
			}
		}
	}
}
