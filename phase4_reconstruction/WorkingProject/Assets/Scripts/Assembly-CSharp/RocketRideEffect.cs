using UnityEngine;

public class RocketRideEffect : BaseEffect
{
	private const float MAX_TARGET_DISTANCE = 150f;

	public GameObject parentObject;

	private CarCollider cc;

	private GameObject target;

	private bool reverse;

	private GameObject rocket;

	private float oldDist;

	public RocketRideEffect(GameObject owner)
	{
	}

	public override void Init()
	{
	}

	public override void Update()
	{
	}

	public override void Shutdown()
	{
	}

	public override bool Stack(BaseEffect second)
	{
		return default(bool);
	}

	public override BaseEffect GetEffectSnapShot()
	{
		return default(BaseEffect);
	}

	protected void LaunchRocket(GameObject target)
	{
	}

	public void DetachFromRocket()
	{
	}
}
