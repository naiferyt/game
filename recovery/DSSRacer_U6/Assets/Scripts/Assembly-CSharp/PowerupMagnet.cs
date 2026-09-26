using System.Collections.Generic;
using UnityEngine;

public class PowerupMagnet : BaseEffect
{
	private const float TIME_DELAY = 0.15f;

	public GameObject parentObject;

	public float magnetRadius;

	public float pullSpeed;

	public float timer;

	private EffectManager em;

	private List<GameObject> itemList;

	private GameObject particles;

	private GameObject camera;

	public PowerupMagnet(GameObject owner)
	{
		RecoveryPending.Hit("PowerupMagnet..ctor");
	}

	private void Start()
	{
		RecoveryPending.Hit("PowerupMagnet.Start");
	}

	public override void Init()
	{
		RecoveryPending.Hit("PowerupMagnet.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("PowerupMagnet.Update");
	}

	public override void FixedUpdate()
	{
		RecoveryPending.Hit("PowerupMagnet.FixedUpdate");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("PowerupMagnet.Shutdown");
	}

	public override bool Stack(BaseEffect second)
	{
		RecoveryPending.Hit("PowerupMagnet.Stack");
		return default(bool);
	}

	public override BaseEffect GetEffectSnapShot()
	{
		RecoveryPending.Hit("PowerupMagnet.GetEffectSnapShot");
		return default(BaseEffect);
	}
}
