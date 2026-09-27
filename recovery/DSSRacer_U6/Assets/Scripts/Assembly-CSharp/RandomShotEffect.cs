using UnityEngine;

// UFO attack (Booster + Rocket combo): boosts and spawns two ShotDroneAI UFOs that follow the owner
// for 10 s and then fly away.
// Source listing: recovery/aot_listings/Assembly-CSharp/RandomShotEffect.txt
public class RandomShotEffect : BaseEffect
{
	public GameObject parentObject;

	private GameObject droneOne;

	private GameObject droneTwo;

	// RECUPERADO-AOT RandomShotEffect::.ctor token 0x060003a3 @0x000f60dc
	public RandomShotEffect(GameObject owner)
	{
		effectType = EffectTypes.RandomShotEffect;
		parentObject = owner;
		time = 10f;
	}

	// RECUPERADO-AOT RandomShotEffect::Start token 0x060003a4 @0x000f613c
	private void Start()
	{
	}

	// RECUPERADO-AOT RandomShotEffect::Init token 0x060003a5 @0x000f6168
	// Note (original): the drones spawn at an absolute height of y = 10 above the owner's x/z.
	public override void Init()
	{
		EffectManager component = parentObject.GetComponent<EffectManager>();
		if (component != null)
		{
			component.AddEffect(new BoosterEffect(parentObject));
			Vector3 position = parentObject.transform.position;
			position.y = 10f;
			droneOne = Object.Instantiate(component.randomShotPrefab, position, parentObject.transform.rotation) as GameObject;
			droneOne.SendMessage("SetParent", parentObject);
			droneTwo = Object.Instantiate(component.randomShotPrefab, position, parentObject.transform.rotation) as GameObject;
			droneTwo.SendMessage("SetParent", parentObject);
			droneTwo.SendMessage("SetSecondUFO", true);
		}
	}

	// RECUPERADO-AOT RandomShotEffect::Update token 0x060003a6 @0x000f646c
	public override void Update()
	{
	}

	// RECUPERADO-AOT RandomShotEffect::Shutdown token 0x060003a7 @0x000f6498
	public override void Shutdown()
	{
		if (droneOne != null)
		{
			droneOne.SendMessage("StartFlyaway");
		}
		if (droneTwo != null)
		{
			droneTwo.SendMessage("StartFlyaway");
		}
	}

	// RECUPERADO-AOT RandomShotEffect::Stack token 0x060003a8 @0x000f652c
	public override bool Stack(BaseEffect second)
	{
		return false;
	}

	// RECUPERADO-AOT RandomShotEffect::GetEffectSnapShot token 0x060003a9 @0x000f6560
	public override BaseEffect GetEffectSnapShot()
	{
		return this;
	}

	// RECUPERADO-AOT RandomShotEffect::FixedUpdate token 0x060003aa @0x000f6590
	public override void FixedUpdate()
	{
	}
}
