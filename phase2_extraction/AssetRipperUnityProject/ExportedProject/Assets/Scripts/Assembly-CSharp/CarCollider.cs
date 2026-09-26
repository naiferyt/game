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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public bool isCarLocked
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	public EffectManager EffectMgr
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public bool isDrifting
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public float PowerSlideTimer
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public bool isPowerSlideQueued
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public bool isInAir
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	[DebuggerHidden]
	private IEnumerator CarUpdatePump()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private float GetActualCollisionMass()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private float GetActualCollisionRestitution()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public float GetActualMaxSpeed()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public float GetActualHandling()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public void TransformVelocity(Vector3 trans)
	{
	}

	public Vector3 GetAccel()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public void DecrementInputBlock()
	{
	}

	public void IncrementInputBlock()
	{
	}

	public bool InputBlocked()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public bool IsShielded()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void OnDrawGizmos()
	{
	}

	private void SetupAudioStuff()
	{
	}
}
