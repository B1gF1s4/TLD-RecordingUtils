using Il2Cpp;

namespace RecordingUtils.Commands
{
	public abstract class CommandBase
	{
		private readonly string _command;

		public CommandBase(string command)
		{
			_command = command;
		}

		public void AddToConsole()
		{
			uConsole.RegisterCommand(_command, new Action(() =>
			{
				uConsole.print(Execute());
			}));
		}

		public abstract string Execute();

	}
}
