using UnityEngine;

public class SpreadMineEffect : BaseEffect
{
	public GameObject parentObject;

	public SpreadMineEffect(GameObject owner)
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

	protected void LaunchSpreader()
	{
	}
}
