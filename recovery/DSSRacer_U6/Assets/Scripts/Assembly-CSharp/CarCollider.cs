using System.Collections;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(SoundSequencer))]
public class CarCollider : MonoBehaviour
{
	private enum EngineSoundState
	{
		NONE = 0,
		IDLE = 1,
		ACCEL = 2
	}

	private const float COLLISION_RESTITUTION = 0.3f;

	private const bool COLLISION_NOSE_JERK = false;

	public const float CAR_GRAVITY = 10f;

	public const float STALL_TIME = 3f;

	public const float STALL_DIST_EPSILON = 0.1f;

	private const int groundLayerMask = 256;

	private const int carLayerMask = 512;

	private const int collideLayerMask = 1024;

	private Vector3 lastPosition;

	private float stallTimer;

	public CartAttributes attributes;

	public bool ignoreFixedUpdate;

	private Vector3 velocity;

	private Vector3 accel;

	private bool drifting;

	public Vector3 driftVector;

	public bool ignoreGravity;

	private bool carLocked;

	private int inhibitBlockLevel;

	private bool playingTireSqueal;

	private bool initFinished;

	private bool sparks;

	private bool soundPaused;

	public WaypointLogic lastClosestWP;

	private GimpedCarAI gimpedAI;

	private float powerSlideTimer;

	private bool powerSlideQueued;

	private EffectManager carEffectMgr;

	private TriFoot triFoot;

	private SoundSequencer sequencer;

	private EngineSoundState engineSoundState;

	private AudioSource engineAudioSource;

	private GameObject lastRoadContact;

	private Vector3 lastRoadContactPos;

	private CameraShake cameraShake;

	public AudioSource EngineAudioSource
	{
		get
		{
			RecoveryPending.Hit("CarCollider.get_EngineAudioSource");
			return default(AudioSource);
		}
	}

	public bool isCarLocked
	{
		get
		{
			RecoveryPending.Hit("CarCollider.get_isCarLocked");
			return default(bool);
		}
		set
		{
			RecoveryPending.Hit("CarCollider.set_isCarLocked");
		}
	}

	public EffectManager EffectMgr
	{
		get
		{
			RecoveryPending.Hit("CarCollider.get_EffectMgr");
			return default(EffectManager);
		}
	}

	public bool isDrifting
	{
		get
		{
			RecoveryPending.Hit("CarCollider.get_isDrifting");
			return default(bool);
		}
	}

	public float PowerSlideTimer
	{
		get
		{
			RecoveryPending.Hit("CarCollider.get_PowerSlideTimer");
			return default(float);
		}
	}

	public bool isPowerSlideQueued
	{
		get
		{
			RecoveryPending.Hit("CarCollider.get_isPowerSlideQueued");
			return default(bool);
		}
	}

	public bool isInAir
	{
		get
		{
			RecoveryPending.Hit("CarCollider.get_isInAir");
			return default(bool);
		}
	}

	private void OnEnable()
	{
		RecoveryPending.Hit("CarCollider.OnEnable");
	}

	private void OnDisable()
	{
		RecoveryPending.Hit("CarCollider.OnDisable");
	}

	[DebuggerHidden]
	private IEnumerator CarUpdatePump()
	{
		RecoveryPending.Hit("CarCollider.CarUpdatePump");
		yield break;
	}

	private void Start()
	{
		RecoveryPending.Hit("CarCollider.Start");
	}

	public void PauseSounds(bool pause)
	{
		RecoveryPending.Hit("CarCollider.PauseSounds");
	}

	private void Update()
	{
		RecoveryPending.Hit("CarCollider.Update");
	}

	private void FixedUpdate()
	{
		RecoveryPending.Hit("CarCollider.FixedUpdate");
	}

	private void CheckForCatchUp()
	{
		RecoveryPending.Hit("CarCollider.CheckForCatchUp");
	}

	public void ApplyAcceleration(float value)
	{
		RecoveryPending.Hit("CarCollider.ApplyAcceleration");
	}

	public void ApplyTurning(float value)
	{
		RecoveryPending.Hit("CarCollider.ApplyTurning");
	}

	public void ApplyDrift(bool state)
	{
		RecoveryPending.Hit("CarCollider.ApplyDrift");
	}

	public void RaceInitFinished()
	{
		RecoveryPending.Hit("CarCollider.RaceInitFinished");
	}

	private void SetEngineSoundState(EngineSoundState state)
	{
		RecoveryPending.Hit("CarCollider.SetEngineSoundState");
	}

	public float GetActualAcceleration()
	{
		RecoveryPending.Hit("CarCollider.GetActualAcceleration");
		return default(float);
	}

	private float GetActualCollisionMass()
	{
		RecoveryPending.Hit("CarCollider.GetActualCollisionMass");
		return default(float);
	}

	private float GetActualCollisionRestitution()
	{
		RecoveryPending.Hit("CarCollider.GetActualCollisionRestitution");
		return default(float);
	}

	public float GetActualMaxSpeed()
	{
		RecoveryPending.Hit("CarCollider.GetActualMaxSpeed");
		return default(float);
	}

	public float GetActualHandling()
	{
		RecoveryPending.Hit("CarCollider.GetActualHandling");
		return default(float);
	}

	private void DoGroundCollision()
	{
		RecoveryPending.Hit("CarCollider.DoGroundCollision");
	}

	private void DoAcceleration()
	{
		RecoveryPending.Hit("CarCollider.DoAcceleration");
	}

	private void DoMovement()
	{
		RecoveryPending.Hit("CarCollider.DoMovement");
	}

	private void PlayRandomCollisionSound()
	{
		RecoveryPending.Hit("CarCollider.PlayRandomCollisionSound");
	}

	private void DoGimpedMovement()
	{
		RecoveryPending.Hit("CarCollider.DoGimpedMovement");
	}

	private void CheckForStall(float detla)
	{
		RecoveryPending.Hit("CarCollider.CheckForStall");
	}

	public void DoResetCarOnTrack(bool gap)
	{
		RecoveryPending.Hit("CarCollider.DoResetCarOnTrack");
	}

	public void DoResetCarOnTrack(bool gap, Vector3 spawnPos)
	{
		RecoveryPending.Hit("CarCollider.DoResetCarOnTrack");
	}

	private void DoTireDrag()
	{
		RecoveryPending.Hit("CarCollider.DoTireDrag");
	}

	private void DoRoadBoundaries()
	{
		RecoveryPending.Hit("CarCollider.DoRoadBoundaries");
	}

	private void DoPowerSlideCheck()
	{
		RecoveryPending.Hit("CarCollider.DoPowerSlideCheck");
	}

	private void DoWrongWayCheck()
	{
		RecoveryPending.Hit("CarCollider.DoWrongWayCheck");
	}

	public Vector3 GetVelocity()
	{
		RecoveryPending.Hit("CarCollider.GetVelocity");
		return default(Vector3);
	}

	public void TransformVelocity(Vector3 trans)
	{
		RecoveryPending.Hit("CarCollider.TransformVelocity");
	}

	public Vector3 GetAccel()
	{
		RecoveryPending.Hit("CarCollider.GetAccel");
		return default(Vector3);
	}

	public void DecrementInputBlock()
	{
		RecoveryPending.Hit("CarCollider.DecrementInputBlock");
	}

	public void IncrementInputBlock()
	{
		RecoveryPending.Hit("CarCollider.IncrementInputBlock");
	}

	public bool InputBlocked()
	{
		RecoveryPending.Hit("CarCollider.InputBlocked");
		return default(bool);
	}

	public bool IsShielded()
	{
		RecoveryPending.Hit("CarCollider.IsShielded");
		return default(bool);
	}

	private void OnDrawGizmos()
	{
		RecoveryPending.Hit("CarCollider.OnDrawGizmos");
	}

	private void SetupAudioStuff()
	{
		RecoveryPending.Hit("CarCollider.SetupAudioStuff");
	}
}
