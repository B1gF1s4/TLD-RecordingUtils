using Il2Cpp;
using MelonLoader;
using UnityEngine;

namespace RecordingUtils.FreeBird
{
	public class FBCam : MonoBehaviour
	{
		public float Rad2Deg()
		{
			return 57.29578f;
		}

		public static FBCam? Instance;
		public bool Enabled;

		private Camera? _mainCam;
		private vp_FPSCamera? _fpsCam;
		private vp_FPSController? _fpsController;
		private vp_FPSPlayer? _fpsPlayer;
		private readonly GameObject? _anchorObject;
		private FlyMode? _flyMode;
		private Rigidbody? _thisRigid;
		private SphereCollider? _thisCollider;
		private GameObject? _originalParent;
		private Vector3 _initialPosition;
		private Quaternion _initialRotation;
		private int _initialLayer;
		private bool _rotationToggled;
		private int _rotationToggledTimer;
		private readonly object? _stopTimerRoutine;
		private Vector3 _levelCamVelocity = new(0f, 0f, 10f);
		private Vector3 _stopVector = new(0f, 0f, 0f);
		private readonly float _speed = 0.01f;
		private float _timeCount;

		public void Awake()
		{
			Instance = this;

			_mainCam = gameObject.GetComponent<Camera>();
			_fpsCam = gameObject.GetComponent<vp_FPSCamera>();
			_flyMode = gameObject.GetComponent<FlyMode>();
			_thisRigid = gameObject.GetComponent<Rigidbody>();

			_initialLayer = gameObject.layer;

			if (!_thisRigid)
			{
				_thisRigid = gameObject.AddComponent<Rigidbody>();
				_thisCollider = gameObject.AddComponent<SphereCollider>();
				_thisCollider.center = new Vector3(0f, 0f, 0f);
				_thisCollider.radius = 0.4f;
				_thisCollider.enabled = false;
			}

			_thisRigid.isKinematic = true;
			_thisRigid.detectCollisions = false;
			_thisRigid.interpolation = RigidbodyInterpolation.Interpolate;
			_thisRigid.collisionDetectionMode = CollisionDetectionMode.Continuous;
			_thisRigid.useGravity = false;
		}

		public void Enable()
		{
			_fpsCam.enabled = false;

			_originalParent = gameObject.transform.parent.gameObject;

			_initialPosition = this._mainCam.transform.position;
			_initialRotation = this._mainCam.transform.rotation;

			gameObject.layer = 17;

			_thisCollider.enabled = true;

			_thisRigid.isKinematic = false;
			_thisRigid.detectCollisions = true;

			gameObject.transform.parent = null;

			_fpsController.enabled = false;

			Enabled = true;
		}

		public void Disable()
		{
			_thisCollider.enabled = false;

			_thisRigid.isKinematic = true;
			_thisRigid.detectCollisions = false;

			gameObject.layer = _initialLayer;
			gameObject.transform.parent = _originalParent.transform;

			_fpsController.enabled = true;

			Enabled = false;

			_fpsCam.enabled = true;
		}

		public void Toggle()
		{
			if (!_fpsCam)
			{
				_fpsCam = base.gameObject.GetComponent<vp_FPSCamera>();
			}

			if (!_fpsPlayer)
			{
				_fpsPlayer = GameManager.GetVpFPSPlayer();
				_fpsController = _fpsPlayer.gameObject.GetComponent<vp_FPSController>();
			}

			if (Enabled)
			{
				Disable();
				return;
			}

			Enable();
		}

		public void FixedUpdate()
		{
			if (Enabled)
			{
				MouseMovement();
				KeyboardMovement();
			}
		}

		public void MouseMovement()
		{
			if (Settings.ModSettings.AlwaysRotate)
			{
				_thisRigid.AddRelativeTorque(Vector3.up * Settings.ModSettings.MouseSens * Input.GetAxis("Mouse X"));
				_thisRigid.AddRelativeTorque(Vector3.right * Settings.ModSettings.MouseSens * -Input.GetAxis("Mouse Y"));
				return;
			}

			if (Input.GetKey(Settings.ModSettings.CamRotToggle) && !_rotationToggled)
			{
				_thisRigid.AddRelativeTorque(Vector3.up * Settings.ModSettings.MouseSens * Input.GetAxis("Mouse X"));
				_thisRigid.AddRelativeTorque(Vector3.right * Settings.ModSettings.MouseSens * -Input.GetAxis("Mouse Y"));
			}

			if (Input.GetKey(Settings.ModSettings.CamRotToggle))
			{
				_rotationToggledTimer++;
				if (_rotationToggledTimer > 20)
				{
					MelonLogger.Msg("Toggle rotation");
					_rotationToggled = !_rotationToggled;
					_rotationToggledTimer = 0;
					return;
				}
			}
			else
			{
				_rotationToggledTimer = 0;
			}
		}

		public void KeyboardMovement()
		{
			if (Input.GetKey(Settings.ModSettings.Forward))
			{
				_thisRigid.AddForce(_thisRigid.transform.forward * Settings.ModSettings.MovementSpeed, ForceMode.Acceleration);
			}

			if (Input.GetKey(Settings.ModSettings.Left))
			{
				_thisRigid.AddForce(_thisRigid.transform.right * -Settings.ModSettings.MovementSpeed, ForceMode.Acceleration);
			}

			if (Input.GetKey(Settings.ModSettings.Right))
			{
				_thisRigid.AddForce(_thisRigid.transform.right * Settings.ModSettings.MovementSpeed, ForceMode.Acceleration);
			}

			if (Input.GetKey(Settings.ModSettings.Backward))
			{
				_thisRigid.AddForce(_thisRigid.transform.forward * -Settings.ModSettings.MovementSpeed, ForceMode.Acceleration);
			}

			if (Input.GetKey(Settings.ModSettings.Up))
			{
				_thisRigid.AddForce(_thisRigid.transform.up * Settings.ModSettings.MovementSpeed, ForceMode.Acceleration);
			}

			if (Input.GetKey(Settings.ModSettings.Down))
			{
				_thisRigid.AddForce(_thisRigid.transform.up * -Settings.ModSettings.MovementSpeed, ForceMode.Acceleration);
			}

			if (Input.GetKey(Settings.ModSettings.HandbrakeKey))
			{
				_thisRigid.velocity = iTween.Vector3Update(_thisRigid.velocity, _stopVector, Settings.ModSettings.HandbrakeStrength);
				_thisRigid.angularVelocity = iTween.Vector3Update(_thisRigid.angularVelocity, _stopVector, Settings.ModSettings.HandbrakeStrength);
			}
			else
			{
				_thisRigid.velocity = iTween.Vector3Update(_thisRigid.velocity, _stopVector, Settings.ModSettings.Floatyness);
				_thisRigid.angularVelocity = iTween.Vector3Update(_thisRigid.angularVelocity, _stopVector, Settings.ModSettings.Floatyness);
			}

			if ((double)Settings.ModSettings.AutoLeveling > 0.0001)
			{
				Quaternion.Euler(new Vector3(_thisRigid.transform.rotation.eulerAngles.x,
					_thisRigid.transform.rotation.eulerAngles.y, 0f));

				Quaternion quaternion = Quaternion.Slerp(_thisRigid.transform.rotation,
					Quaternion.Euler(new Vector3(_thisRigid.transform.rotation.eulerAngles.x,
					_thisRigid.transform.rotation.eulerAngles.y, 0f)), _timeCount * Settings.ModSettings.AutoLeveling);

				_timeCount += Time.deltaTime;
				_thisRigid.MoveRotation(quaternion);
			}
		}

	}
}
