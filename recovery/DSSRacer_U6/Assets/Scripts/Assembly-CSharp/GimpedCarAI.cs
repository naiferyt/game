using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class GimpedCarAI : MonoBehaviour
{
	private const float WRECK_FLIP_TIME = 0.25f;

	private const float USE_POWERUP_INTERVAL = 3f;

	private const float USE_POWERUP_CHANCE = 0.5f;

	private const float GAIN_AGGRESSION_POWERUP = 0.05f;

	private CarCollider carCollider;

	private AnimationDriver animDriver;

	private CarAIPath currentPath;

	private int currentPathIndex;

	private Vector3 targetPos;

	private Vector3 lastPos;

	private Quaternion targetRot;

	private Quaternion lastRot;

	private float targetDist;

	private float linearVelocity;

	private Vector3 bumpVelocity;

	private ShadowBlob shadowBlob;

	private float wreckedFlipTimer;

	private PIDVectorController pid;

	public float aggressionIndex;

	public float LinearVelocity
	{
		get
		{
			RecoveryPending.Hit("GimpedCarAI.get_LinearVelocity");
			return default(float);
		}
		set
		{
			RecoveryPending.Hit("GimpedCarAI.set_LinearVelocity");
		}
	}

	public float Velocity
	{
		get
		{
			RecoveryPending.Hit("GimpedCarAI.get_Velocity");
			return default(float);
		}
	}

	public Vector3 Direction
	{
		get
		{
			RecoveryPending.Hit("GimpedCarAI.get_Direction");
			return default(Vector3);
		}
	}

	public bool IsInAir
	{
		get
		{
			RecoveryPending.Hit("GimpedCarAI.get_IsInAir");
			return default(bool);
		}
	}

	private void SetNewPath()
	{
		RecoveryPending.Hit("GimpedCarAI.SetNewPath");
	}

	private void SetNextPoint()
	{
		RecoveryPending.Hit("GimpedCarAI.SetNextPoint");
	}

	private void DoRoadBoundaries()
	{
		RecoveryPending.Hit("GimpedCarAI.DoRoadBoundaries");
	}

	private void DoCarCollisions()
	{
		RecoveryPending.Hit("GimpedCarAI.DoCarCollisions");
	}

	[DebuggerHidden]
	private IEnumerator PowerupUseEvaluationCoroutinue()
	{
		RecoveryPending.Hit("GimpedCarAI.PowerupUseEvaluationCoroutinue");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator AggressionTherapyCoroutine()
	{
		RecoveryPending.Hit("GimpedCarAI.AggressionTherapyCoroutine");
		yield break;
	}

	private void Start()
	{
		RecoveryPending.Hit("GimpedCarAI.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("GimpedCarAI.Update");
	}

	private void FixedUpdate()
	{
		RecoveryPending.Hit("GimpedCarAI.FixedUpdate");
	}

	public void Bump(Vector3 force)
	{
		RecoveryPending.Hit("GimpedCarAI.Bump");
	}

	public void GetGimpedSnapShot(out int pathIndex, out int pointIndex)
	{
		RecoveryPending.Hit("GimpedCarAI.GetGimpedSnapShot");
		pathIndex = default(int);
		pointIndex = default(int);
	}

	public void SetGimpedSnapShot(int pathIndex, int pointIndex)
	{
		RecoveryPending.Hit("GimpedCarAI.SetGimpedSnapShot");
	}

	public void SetToClosestPathHead()
	{
		RecoveryPending.Hit("GimpedCarAI.SetToClosestPathHead");
	}
}
