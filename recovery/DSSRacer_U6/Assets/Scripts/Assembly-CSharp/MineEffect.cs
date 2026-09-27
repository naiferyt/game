using UnityEngine;

// Mine power-up: drops `power` mines (MineAI) behind the kart over `time` seconds; level 2 drops 3 in 3 s.
// Source listing: recovery/aot_listings/Assembly-CSharp/MineEffect.txt
public class MineEffect : BaseEffect
{
	private GameObject parentObject;

	private float dropDelay;

	private float dropCountdown;

	// RECUPERADO-AOT MineEffect::.ctor token 0x06000385 @0x000f4ae4
	public MineEffect(GameObject parent)
	{
		parentObject = parent;
		effectType = EffectTypes.MineEffect;
		power = 1;
		time = 1f;
		isMultiLevel = true;
	}

	// RECUPERADO-AOT MineEffect::Init token 0x06000386 @0x000f4b54
	public override void Init()
	{
		if (powerLevel > 1)
		{
			time = 3f;
			power = 3;
		}
		dropDelay = time / (float)power;
		dropCountdown = 0f;
	}

	// RECUPERADO-AOT MineEffect::Shutdown token 0x06000387 @0x000f4be8
	public override void Shutdown()
	{
	}

	// RECUPERADO-AOT MineEffect::Stack token 0x06000388 @0x000f4c14
	public override bool Stack(BaseEffect second)
	{
		if (second.PowerLevel >= powerLevel)
		{
			time = 0f;
			return true;
		}
		return false;
	}

	// RECUPERADO-AOT MineEffect::Update token 0x06000389 @0x000f4c84
	public override void Update()
	{
		EffectManager component = parentObject.GetComponent<EffectManager>();
		dropCountdown -= Time.deltaTime;
		if (!(0f < dropCountdown))
		{
			dropCountdown = dropDelay;
			GameObject gameObject = Object.Instantiate(component.mineEffectPrefab, parentObject.transform.position, parentObject.transform.rotation) as GameObject;
			gameObject.GetComponent<MineAI>().SetOwner(parentObject);
		}
	}

	// RECUPERADO-AOT MineEffect::GetEffectSnapShot token 0x0600038a @0x000f4e30
	public override BaseEffect GetEffectSnapShot()
	{
		return this;
	}
}
