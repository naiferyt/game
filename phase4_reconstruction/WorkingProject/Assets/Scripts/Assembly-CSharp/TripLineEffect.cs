using UnityEngine;

public class TripLineEffect : BaseEffect
{
	public GameObject parentObject;

	private GameObject particles;

	private GameObject camera;

	private GameObject line;

	public TripLineEffect(GameObject owner)
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
}
