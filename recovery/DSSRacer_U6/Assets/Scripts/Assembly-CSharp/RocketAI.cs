using UnityEngine;

[RequireComponent(typeof(SoundSequencer))]
public class RocketAI : MonoBehaviour
{
	private const float MAX_VELOCITY = 100f;

	private const float ACCELERATION = 200f;

	private const float CYCLE_WP_DISTANCE_SQR = 25f;

	private const float HUNT_DISTANCE_SQR = 900f;

	private const float KILL_DISTANCE = 1f;

	private float launchTimer;

	private float lifeTimer;

	private WaypointLogic nextWP;

	private GameObject launchOwner;

	public GameObject launchTarget;

	private Vector3 launchVector;

	private float velocity;

	private RocketRideEffect riderEffect;

	public bool isReverse;

	public bool isBoatAnchor;

	public bool rideRocket;

	private GameObject explosionEffectPrefab;

	private SoundSequencer seq;

	private void StrikeTarget(GameObject target)
	{
	}

	private void LaunchUpdate()
	{
	}

	private void BurnUpdate()
	{
	}

	private void Explode()
	{
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

	public void SetOwner(GameObject obj)
	{
	}

	public void SetTarget(GameObject obj)
	{
	}

	public void SetRiderEffect(RocketRideEffect rre)
	{
	}
}
