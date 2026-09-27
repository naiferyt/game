using UnityEngine;

// Mine spreader (Rocket + Mine combo): launches one MineSpreaderAI that scatters mines ahead.
// Source listing: recovery/aot_listings/Assembly-CSharp/SpreadMineEffect.txt
public class SpreadMineEffect : BaseEffect
{
	public GameObject parentObject;

	// RECUPERADO-AOT SpreadMineEffect::.ctor token 0x060003d9 @0x000f8c14
	public SpreadMineEffect(GameObject owner)
	{
		effectType = EffectTypes.SpreadMineEffect;
		parentObject = owner;
		time = 0.25f;
	}

	// RECUPERADO-AOT SpreadMineEffect::Start token 0x060003da @0x000f8c74
	private void Start()
	{
	}

	// RECUPERADO-AOT SpreadMineEffect::Init token 0x060003db @0x000f8ca0
	public override void Init()
	{
		LaunchSpreader();
	}

	// RECUPERADO-AOT SpreadMineEffect::Update token 0x060003dc @0x000f8cd4
	public override void Update()
	{
	}

	// RECUPERADO-AOT SpreadMineEffect::Shutdown token 0x060003dd @0x000f8d00
	public override void Shutdown()
	{
	}

	// RECUPERADO-AOT SpreadMineEffect::Stack token 0x060003de @0x000f8d2c
	public override bool Stack(BaseEffect second)
	{
		return false;
	}

	// RECUPERADO-AOT SpreadMineEffect::GetEffectSnapShot token 0x060003df @0x000f8d60
	public override BaseEffect GetEffectSnapShot()
	{
		return this;
	}

	// RECUPERADO-AOT SpreadMineEffect::LaunchSpreader token 0x060003e0 @0x000f8d90
	// The owner store is MineSpreaderAI.SetOwner inlined (private field launchOwner).
	protected void LaunchSpreader()
	{
		EffectManager component = parentObject.GetComponent<EffectManager>();
		GameObject gameObject = (GameObject)Object.Instantiate(component.mineSpreaderPrefab, parentObject.transform.position + parentObject.transform.forward * 5f + Vector3.up * 2f, parentObject.transform.rotation);
		MineSpreaderAI component2 = gameObject.GetComponent<MineSpreaderAI>();
		if (component2 != null)
		{
			component2.SetOwner(parentObject);
		}
		else
		{
			Debug.LogWarning("no AI on spreader!!");
		}
	}
}
