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
}
