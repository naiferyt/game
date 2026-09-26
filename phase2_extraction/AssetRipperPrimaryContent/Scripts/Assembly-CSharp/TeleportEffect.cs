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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public override BaseEffect GetEffectSnapShot()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
