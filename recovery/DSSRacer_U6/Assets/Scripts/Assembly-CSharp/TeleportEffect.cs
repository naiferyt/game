using UnityEngine;

public class TeleportEffect : BaseEffect
{
	public float teleportTime;

	private GameObject parentObject;

	private Vector3 targetPos;

	private float teleportTimer;

	private bool timeToTeleport;

	private bool isSnapshot;

	public TeleportEffect(GameObject owner, Vector3 target, bool isSnap)
	{
		RecoveryPending.Hit("TeleportEffect..ctor");
	}

	public override void Init()
	{
		RecoveryPending.Hit("TeleportEffect.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("TeleportEffect.Update");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("TeleportEffect.Shutdown");
	}

	public override bool Stack(BaseEffect second)
	{
		RecoveryPending.Hit("TeleportEffect.Stack");
		return default(bool);
	}

	public override BaseEffect GetEffectSnapShot()
	{
		RecoveryPending.Hit("TeleportEffect.GetEffectSnapShot");
		return default(BaseEffect);
	}
}
