using System.Collections.Generic;
using UnityEngine;

public class RocketEffect : BaseEffect
{
	private const float BATTERY_LAUNCH_DELAY = 0.25f;

	private const float MAX_TARGET_DISTANCE = 150f;

	private GameObject parentObject;

	public bool isReflected;

	private List<GameObject> targetList;

	private float batteryTimer;

	private bool reverse;

	public RocketEffect(GameObject parent)
	{
		RecoveryPending.Hit("RocketEffect..ctor");
	}

	public override void Init()
	{
		RecoveryPending.Hit("RocketEffect.Init");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("RocketEffect.Shutdown");
	}

	public override bool Stack(BaseEffect second)
	{
		RecoveryPending.Hit("RocketEffect.Stack");
		return default(bool);
	}

	public override void Update()
	{
		RecoveryPending.Hit("RocketEffect.Update");
	}

	public override BaseEffect GetEffectSnapShot()
	{
		RecoveryPending.Hit("RocketEffect.GetEffectSnapShot");
		return default(BaseEffect);
	}

	protected void LaunchRocket(GameObject target)
	{
		RecoveryPending.Hit("RocketEffect.LaunchRocket");
	}
}
