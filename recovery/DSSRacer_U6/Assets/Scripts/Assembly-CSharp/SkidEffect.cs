using UnityEngine;

// Skid after a kart bump: halves the handling (CarCollider.GetActualHandling) until the velocity is
// back within SKID_EQUALIZE_ANGLE of the heading. No time limit (float.MinValue).
// Source listing: recovery/aot_listings/Assembly-CSharp/SkidEffect.txt
// (Adelantado de la Etapa 4 en 3.9: lo usan las pistas y los choques de la carrera.)
public class SkidEffect : BaseEffect
{
	private const float SKID_EQUALIZE_ANGLE = 10f;

	private GameObject parentObject;

	private CarCollider carCollider;

	// RECUPERADO-AOT SkidEffect::.ctor token 0x060003c7 @0x000f846c
	public SkidEffect(GameObject owner)
	{
		parentObject = owner;
		time = float.MinValue;
	}

	// RECUPERADO-AOT SkidEffect::Init token 0x060003c8 @0x000f84c4
	public override void Init()
	{
		carCollider = parentObject.GetComponent<CarCollider>();
	}

	// RECUPERADO-AOT SkidEffect::Update token 0x060003c9 @0x000f8520
	public override void Update()
	{
		if (Vector3.Angle(parentObject.transform.forward, carCollider.GetVelocity()) <= 10f)
		{
			time = 0f;
		}
	}

	// RECUPERADO-AOT SkidEffect::Shutdown token 0x060003ca @0x000f860c (empty)
	public override void Shutdown()
	{
	}

	// RECUPERADO-AOT SkidEffect::Stack token 0x060003cb @0x000f8638
	public override bool Stack(BaseEffect second)
	{
		return false;
	}

	// RECUPERADO-AOT SkidEffect::GetEffectSnapShot token 0x060003cc @0x000f866c
	public override BaseEffect GetEffectSnapShot()
	{
		return this;
	}
}
