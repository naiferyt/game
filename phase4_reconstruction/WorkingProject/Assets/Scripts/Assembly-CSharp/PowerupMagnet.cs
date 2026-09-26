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
	}

	private void Start()
	{
	}

	public override void Init()
	{
	}

	public override void Update()
	{
	}

	public override void FixedUpdate()
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
