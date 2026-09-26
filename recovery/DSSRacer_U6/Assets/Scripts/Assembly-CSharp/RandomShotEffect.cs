using UnityEngine;

public class RandomShotEffect : BaseEffect
{
	public GameObject parentObject;

	private GameObject droneOne;

	private GameObject droneTwo;

	public RandomShotEffect(GameObject owner)
	{
		RecoveryPending.Hit("RandomShotEffect..ctor");
	}

	private void Start()
	{
		RecoveryPending.Hit("RandomShotEffect.Start");
	}

	public override void Init()
	{
		RecoveryPending.Hit("RandomShotEffect.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("RandomShotEffect.Update");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("RandomShotEffect.Shutdown");
	}

	public override bool Stack(BaseEffect second)
	{
		RecoveryPending.Hit("RandomShotEffect.Stack");
		return default(bool);
	}

	public override BaseEffect GetEffectSnapShot()
	{
		RecoveryPending.Hit("RandomShotEffect.GetEffectSnapShot");
		return default(BaseEffect);
	}

	public override void FixedUpdate()
	{
		RecoveryPending.Hit("RandomShotEffect.FixedUpdate");
	}
}
