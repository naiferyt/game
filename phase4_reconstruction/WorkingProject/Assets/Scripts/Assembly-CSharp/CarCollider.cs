using System.Collections;
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
			return default(AudioSource);
		}
	}

	public bool isCarLocked
	{
		get
		{
			return default(bool);
		}
		set
		{
		}
	}

	public EffectManager EffectMgr
	{
		get
		{
			return default(EffectManager);
		}
	}

	public bool isDrifting
	{
		get
		{
			return default(bool);
		}
	}

	public float PowerSlideTimer
	{
		get
		{
			return default(float);
		}
	}

	public bool isPowerSlideQueued
	{
		get
		{
			return default(bool);
		}
	}

	public bool isInAir
	{
		get
		{
			return default(bool);
		}
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator CarUpdatePump()
	{
		return default(IEnumerator);
	}

	private void Start()
	{
	}

	public void PauseSounds(bool pause)
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private void CheckForCatchUp()
	{
	}

	public void ApplyAcceleration(float value)
	{
	}

	public void ApplyTurning(float value)
	{
	}

	public void ApplyDrift(bool state)
	{
	}

	public void RaceInitFinished()
	{
	}

	private void SetEngineSoundState(EngineSoundState state)
	{
	}

	public float GetActualAcceleration()
	{
		return default(float);
	}

	private float GetActualCollisionMass()
	{
		return default(float);
	}

	private float GetActualCollisionRestitution()
	{
		return default(float);
	}

	public float GetActualMaxSpeed()
	{
		return default(float);
	}

	public float GetActualHandling()
	{
		return default(float);
	}

	private void DoGroundCollision()
	{
	}

	private void DoAcceleration()
	{
	}

	private void DoMovement()
	{
	}

	private void PlayRandomCollisionSound()
	{
	}

	private void DoGimpedMovement()
	{
	}

	private void CheckForStall(float detla)
	{
	}

	public void DoResetCarOnTrack(bool gap)
	{
	}

	public void DoResetCarOnTrack(bool gap, Vector3 spawnPos)
	{
	}

	private void DoTireDrag()
	{
	}

	private void DoRoadBoundaries()
	{
	}

	private void DoPowerSlideCheck()
	{
	}

	private void DoWrongWayCheck()
	{
	}

	public Vector3 GetVelocity()
	{
		return default(Vector3);
	}

	public void TransformVelocity(Vector3 trans)
	{
	}

	public Vector3 GetAccel()
	{
		return default(Vector3);
	}

	public void DecrementInputBlock()
	{
	}

	public void IncrementInputBlock()
	{
	}

	public bool InputBlocked()
	{
		return default(bool);
	}

	public bool IsShielded()
	{
		return default(bool);
	}

	private void OnDrawGizmos()
	{
	}

	private void SetupAudioStuff()
	{
	}
}
