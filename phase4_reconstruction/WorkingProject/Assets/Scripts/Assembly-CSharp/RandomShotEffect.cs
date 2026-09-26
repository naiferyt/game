using UnityEngine;

public class RandomShotEffect : BaseEffect
{
	public GameObject parentObject;

	private GameObject droneOne;

	private GameObject droneTwo;

	public RandomShotEffect(GameObject owner)
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

	public override void FixedUpdate()
	{
	}
}
