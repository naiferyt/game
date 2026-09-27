using UnityEngine;

// A pie in the face: shows the full-screen pie splat for this effect's time (flipped when hit from the left).
// Source listing: recovery/aot_listings/Assembly-CSharp/PieHitEffect.txt
public class PieHitEffect : BaseEffect
{
	public enum HitDirection
	{
		Left = 0,
		Right = 1
	}

	// RECUPERADO-AOT PieHitEffect::.ctor token 0x06000395 @0x000f5298 (field initializer + constructor body)
	private HitDirection hitDirection = HitDirection.Right;

	public PieHitEffect(GameObject owner, HitDirection dir = HitDirection.Right)
	{
		hitDirection = dir;
	}

	// RECUPERADO-AOT PieHitEffect::Init token 0x06000396 @0x000f52e4
	public override void Init()
	{
		GameObject prefab = ParticleLibrary.Instance.GetPrefab("Pie Splat");
		if (prefab != null)
		{
			GameObject gameObject = Object.Instantiate(prefab) as GameObject;
			gameObject.GetComponent<PieSplat>().splatDuration = time;
			if (hitDirection == HitDirection.Left)
			{
				gameObject.transform.Rotate(0f, 0f, 180f);
			}
		}
	}

	// RECUPERADO-AOT PieHitEffect::Update token 0x06000397 @0x000f5444
	public override void Update()
	{
	}

	// RECUPERADO-AOT PieHitEffect::Shutdown token 0x06000398 @0x000f5470
	public override void Shutdown()
	{
	}

	// RECUPERADO-AOT PieHitEffect::Stack token 0x06000399 @0x000f549c
	public override bool Stack(BaseEffect second)
	{
		return false;
	}

	// RECUPERADO-AOT PieHitEffect::GetEffectSnapShot token 0x0600039a @0x000f54d0
	public override BaseEffect GetEffectSnapShot()
	{
		return this;
	}
}
