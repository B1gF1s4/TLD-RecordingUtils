using Il2CppInterop.Runtime.Injection;
using MelonLoader;
using MelonLoader.Utils;
using RecordingUtils.Commands;
using RecordingUtils.FreeBird;

namespace RecordingUtils
{
	public class Mod : MelonMod
	{
		public const string BaseDirectory = nameof(RecordingUtils);

		public override void OnInitializeMelon()
		{
			base.OnInitializeMelon();

			Directory.CreateDirectory(Path.Combine(
				MelonEnvironment.ModsDirectory, BaseDirectory));

			CommandList.Init();

			Settings.OnLoad();

			ClassInjector.RegisterTypeInIl2Cpp<FBCam>();
		}
	}
}
