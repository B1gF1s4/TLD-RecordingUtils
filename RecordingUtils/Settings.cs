using ModData;
using ModSettings;
using System.Reflection;

namespace RecordingUtils
{
	public static class Settings
	{

		internal static readonly ModSettings ModSettings = new();
		internal static readonly ModDataManager DataManager = new(nameof(RecordingUtils), false);

		public static void OnLoad()
		{
			ModSettings.AddToModSettings("Stream Utils");
		}
	}

	public class ModSettings : JsonModSettings
	{
		[Name("Flymode speed slow")]
		[Description($"How fast camera moves in flymode slow")]
		[Slider(0.1f, 1, 10)]
		public float SpeedSlow = 0.1f;

		[Name("Flymode speed regular")]
		[Description($"How fast camera moves in flymode regular")]
		[Slider(1, 3, 10)]
		public float SpeedRegular = 2;

		[Name("Flymode speed fast")]
		[Description($"How fast camera moves in flymode fast")]
		[Slider(3, 10, 10)]
		public float SpeedFast = 10;

		public ModSettings() : base(Path.Combine(Mod.BaseDirectory, "user-settings"))
		{
			RefreshAllFields();
		}

		protected override void OnConfirm()
		{
			base.OnConfirm();
		}

		protected override void OnChange(FieldInfo field, object? oldValue, object? newValue)
		{
			base.OnChange(field, oldValue, newValue);
		}

		public void RefreshAllFields()
		{

		}
	}
}
