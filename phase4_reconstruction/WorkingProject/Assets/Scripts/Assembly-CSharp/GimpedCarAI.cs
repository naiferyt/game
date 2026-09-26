using System.Collections;
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
			return default(float);
		}
		set
		{
		}
	}

	public float Velocity
	{
		get
		{
			return default(float);
		}
	}

	public Vector3 Direction
	{
		get
		{
			return default(Vector3);
		}
	}

	public bool IsInAir
	{
		get
		{
			return default(bool);
		}
	}

	private void SetNewPath()
	{
	}

	private void SetNextPoint()
	{
	}

	private void DoRoadBoundaries()
	{
	}

	private void DoCarCollisions()
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator PowerupUseEvaluationCoroutinue()
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator AggressionTherapyCoroutine()
	{
		return default(IEnumerator);
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	public void Bump(Vector3 force)
	{
	}

	public void GetGimpedSnapShot(out int pathIndex, out int pointIndex)
	{
		pathIndex = default(int);
		pointIndex = default(int);
	}

	public void SetGimpedSnapShot(int pathIndex, int pointIndex)
	{
	}

	public void SetToClosestPathHead()
	{
	}
}
