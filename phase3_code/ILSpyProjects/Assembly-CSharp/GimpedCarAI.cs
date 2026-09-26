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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	public float Velocity
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public Vector3 Direction
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public bool IsInAir
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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

	[DebuggerHidden]
	private IEnumerator PowerupUseEvaluationCoroutinue()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	private IEnumerator AggressionTherapyCoroutine()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
	}

	public void SetGimpedSnapShot(int pathIndex, int pointIndex)
	{
	}

	public void SetToClosestPathHead()
	{
	}
}
