using UnityEngine;

public class TripLineEffect : BaseEffect
{
	public GameObject parentObject;

	private GameObject particles;

	private GameObject camera;

	private GameObject line;

	public TripLineEffect(GameObject owner)
	{
		RecoveryPending.Hit("TripLineEffect..ctor");
	}

	private void Start()
	{
		RecoveryPending.Hit("TripLineEffect.Start");
	}

	public override void Init()
	{
		RecoveryPending.Hit("TripLineEffect.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("TripLineEffect.Update");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("TripLineEffect.Shutdown");
	}

	public override bool Stack(BaseEffect second)
	{
		RecoveryPending.Hit("TripLineEffect.Stack");
		return default(bool);
	}

	public override BaseEffect GetEffectSnapShot()
	{
		RecoveryPending.Hit("TripLineEffect.GetEffectSnapShot");
		return default(BaseEffect);
	}
}
