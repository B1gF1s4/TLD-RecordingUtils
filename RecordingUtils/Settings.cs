using ModData;
using ModSettings;
using System.Reflection;
using UnityEngine;

namespace RecordingUtils
{
	public static class Settings
	{

		internal static readonly ModSettings ModSettings = new();
		internal static readonly ModDataManager DataManager = new(nameof(RecordingUtils), false);

		public static void OnLoad()
		{
			ModSettings.AddToModSettings("Recording Utils");
		}
	}

	public class ModSettings : JsonModSettings
	{
		[Section("Flymode")]

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

		[Section("FreeBird (by Digitalzombie)")]

		[Name("Movement Speed")]
		[Description("")]
		[Slider(0f, 50f)]
		public float MovementSpeed = 20f;

		[Name("Always Rotation")]
		[Description("")]
		public bool AlwaysRotate = true;

		[Name("Auto leveling")]
		[Description("")]
		[Slider(0f, 0.005f)]
		public float AutoLeveling = 0.0025f;

		[Name("Mouse Sensitivity")]
		[Description("")]
		[Slider(0f, 1f)]
		public float MouseSens = 0.2f;

		[Name("Rotation Speed")]
		[Description("")]
		[Slider(0f, 15f)]
		public float RotationSpeed = 1f;

		[Name("Floatyness")]
		[Description("")]
		[Slider(4f, 0f)]
		public float Floatyness = 1f;

		[Name("Handbrake Strenght")]
		[Description("")]
		[Slider(0f, 10f)]
		public float HandbrakeStrength = 6f;

		[Name("Forward")]
		[Description("Flymod")]
		public KeyCode Forward = KeyCode.W;

		[Name("Backward")]
		[Description("")]
		public KeyCode Backward = KeyCode.S;

		[Name("Left")]
		[Description("")]
		public KeyCode Left = KeyCode.A;

		[Name("Right")]
		[Description("")]
		public KeyCode Right = KeyCode.D;

		[Name("Up")]
		[Description("")]
		public KeyCode Up = KeyCode.Q;

		[Name("Down")]
		[Description("")]
		public KeyCode Down = KeyCode.E;

		[Name("Rotation Toggle")]
		[Description("Toggle  to Rotate")]
		public KeyCode CamRotToggle = KeyCode.H;

		[Name("Rotation Hold")]
		[Description("Hold to Rotate")]
		public KeyCode CamRotHold = KeyCode.C;

		[Name("Scan")]
		[Description("Hold to Scam")]
		public KeyCode CamScanHold = KeyCode.X;

		[Name("Handbrake")]
		[Description("")]
		public KeyCode HandbrakeKey = KeyCode.Space;

		[Section("Vanilla Camera")]

		[Name("Camera Sway")]
		[Description("")]
		public bool CameraSway = true;

		[Name("Camera Bob")]
		[Description("")]
		public bool CameraBob = true;

		[Name("Camera Shake")]
		[Description("")]
		public bool CameraShake = true;

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
			RefreshAllFields();
		}

		public void RefreshAllFields()
		{

		}
	}
}
