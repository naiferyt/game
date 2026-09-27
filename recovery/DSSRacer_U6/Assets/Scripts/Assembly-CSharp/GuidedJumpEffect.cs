using UnityEngine;

// Guided jump: the kart is locked, weightless and carried from the ramp to the target along the jump
// curve in about 2/3 of the time it would take at top speed, turning to face the target; the rider
// cheers. AI karts (GimpedCarAI) handle the jump themselves.
// Source listing: recovery/aot_listings/Assembly-CSharp/GuidedJumpEffect.txt
// (Adelantado de la Etapa 4 en 3.9.)
public class GuidedJumpEffect : BaseEffect
{
	private GameObject parentObject;

	private Vector3 jumpStart;

	private Vector3 targetPosition;

	private Vector3 offset;

	private AnimationCurve jumpCurve;

	private float startTime;

	private Vector3 toTarget;

	// RECUPERADO-AOT GuidedJumpEffect::.ctor token 0x0600037e @0x000f40e8
	public GuidedJumpEffect(GameObject owner, Vector3 startPos, Vector3 targetPos, AnimationCurve curve)
	{
		effectType = EffectTypes.GuidedJumpEffect;
		parentObject = owner;
		jumpStart = startPos;
		targetPosition = targetPos;
		offset = owner.transform.position - startPos;
		jumpCurve = curve;
		CarCollider component = owner.GetComponent<CarCollider>();
		time = (targetPos - owner.transform.position).magnitude / component.attributes.maxSpeed * 0.66f;
		startTime = time;
		toTarget = (targetPos - startPos).normalized;
	}

	// RECUPERADO-AOT GuidedJumpEffect::Init token 0x0600037f @0x000f439c
	// (The animation pick is "(int)Random.value % 2", which is almost always 0 -> "cheering"; kept.)
	public override void Init()
	{
		if (parentObject.GetComponent<GimpedCarAI>() != null)
		{
			return;
		}
		CarCollider component = parentObject.GetComponent<CarCollider>();
		if (component == null)
		{
			return;
		}
		component.isCarLocked = true;
		component.IncrementInputBlock();
		component.ignoreGravity = true;
		component.TransformVelocity(-component.GetVelocity() + toTarget * component.attributes.maxSpeed);
		AnimationDriver component2 = parentObject.GetComponent<AnimationDriver>();
		if (component2 != null)
		{
			string anim = (((int)Random.value % 2 != 0) ? "handsUp" : "cheering");
			component2.Play(anim, false);
		}
		CharacterVOController vOController = parentObject.GetVOController();
		if (vOController != null)
		{
			vOController.PlayCelebrate();
		}
	}

	// RECUPERADO-AOT GuidedJumpEffect::Update token 0x06000380 @0x000f45cc
	public override void Update()
	{
		if (!(parentObject.GetComponent<GimpedCarAI>() != null))
		{
			parentObject.transform.forward = Vector3.Lerp(parentObject.transform.forward, toTarget, Time.deltaTime * 10f);
		}
	}

	// RECUPERADO-AOT GuidedJumpEffect::FixedUpdate token 0x06000381 @0x000f46ec
	public override void FixedUpdate()
	{
		if (!(parentObject.GetComponent<GimpedCarAI>() != null))
		{
			float num = 1f - time / startTime;
			Vector3 vector = Vector3.Lerp(jumpStart, targetPosition, num) + offset;
			float num2 = jumpCurve.Evaluate(num);
			parentObject.transform.position = Vector3.Lerp(parentObject.transform.position, new Vector3(vector.x, vector.y + num2, vector.z), Time.deltaTime * 3f);
		}
	}

	// RECUPERADO-AOT GuidedJumpEffect::Shutdown token 0x06000382 @0x000f4954
	// ADAPTADO-U6: Object.DestroyObject -> Destroy.
	public override void Shutdown()
	{
		CarCollider component = parentObject.GetComponent<CarCollider>();
		if (!(component == null))
		{
			component.DecrementInputBlock();
			component.ignoreGravity = false;
			component.isCarLocked = false;
			if (RaceManager.IsPlayerCar(parentObject))
			{
				GameObject gameObject = GameObject.Find("Full Screen Jump Effect");
				if (gameObject != null)
				{
					Object.Destroy(gameObject);
				}
			}
		}
	}

	// RECUPERADO-AOT GuidedJumpEffect::Stack token 0x06000383 @0x000f4a20
	public override bool Stack(BaseEffect second)
	{
		return false;
	}

	// RECUPERADO-AOT GuidedJumpEffect::GetEffectSnapShot token 0x06000384 @0x000f4a54
	// A snapshot (rewind) of a jump lands the kart straight at the target.
	public override BaseEffect GetEffectSnapShot()
	{
		return new TeleportEffect(parentObject, targetPosition, true);
	}
}
