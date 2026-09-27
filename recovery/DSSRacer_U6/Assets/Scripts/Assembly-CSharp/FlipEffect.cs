using UnityEngine;

// Flip (smashed by another kart): the kart stops, is lifted "power" units while somersaulting and lands
// back where it was, with gravity off and input blocked; crash view for the player.
// Source listing: recovery/aot_listings/Assembly-CSharp/FlipEffect.txt
// (Adelantado de la Etapa 4 en 3.9: lo usan las pistas y los choques de la carrera.)
public class FlipEffect : BaseEffect
{
	private GameObject parentObject;

	private float baseTime;

	private float spinRate;

	// RECUPERADO-AOT FlipEffect::.ctor token 0x06000378 @0x000f373c (field initializers + body)
	private Vector3 startPos = Vector3.zero;

	private Vector3 peakPos = Vector3.zero;

	private bool restoreCamFacingFlag;

	public FlipEffect(GameObject parent)
	{
		parentObject = parent;
		effectType = EffectTypes.FlipEffect;
		power = 10;
		time = 1f;
	}

	// RECUPERADO-AOT FlipEffect::Init token 0x06000379 @0x000f37ec
	// ADAPTADO-U6: Transform.FindChild -> Find; Object.FindObjectOfType -> U4Compat.
	public override void Init()
	{
		if (parentObject == null)
		{
			return;
		}
		EffectManager component = parentObject.GetComponent<EffectManager>();
		if (component.transform.Find("Wipeout Particle Effect") == null)
		{
			GameObject gameObject = Object.Instantiate(ParticleLibrary.Instance.GetPrefab("Wipeout"), parentObject.transform.position, parentObject.transform.rotation) as GameObject;
			gameObject.transform.parent = parentObject.transform;
			gameObject.name = "Wipeout Particle Effect";
		}
		CharacterVOController vOController = parentObject.GetVOController();
		if (vOController != null)
		{
			vOController.PlayPout();
		}
		CarCollider component2 = parentObject.GetComponent<CarCollider>();
		component2.TransformVelocity(-component2.GetVelocity());
		component2.IncrementInputBlock();
		component2.ignoreGravity = true;
		startPos = parentObject.transform.position;
		peakPos = startPos + Vector3.up * power;
		baseTime = time;
		spinRate = 360f * (float)(int)(baseTime / 0.5f) / baseTime;
		FollowCamera followCamera = U4Compat.FindObjectOfType(typeof(FollowCamera)) as FollowCamera;
		if (followCamera != null && followCamera.followObject == parentObject)
		{
			followCamera.SendMessage("SetCrashCam", true);
			restoreCamFacingFlag = true;
		}
	}

	// RECUPERADO-AOT FlipEffect::Update token 0x0600037a @0x000f3cb0
	// Up to the peak during the first half of the effect, back down during the second.
	public override void Update()
	{
		if (parentObject != null)
		{
			parentObject.transform.Rotate(spinRate * Time.deltaTime, 0f, 0f);
			float num = time / baseTime / 0.5f;
			if (num > 1f)
			{
				num = 2f - num;
			}
			parentObject.transform.position = Vector3.Lerp(startPos, peakPos, num);
		}
	}

	// RECUPERADO-AOT FlipEffect::Shutdown token 0x0600037b @0x000f3eb4
	// ADAPTADO-U6: Transform.FindChild -> Find; Object.DestroyObject -> Destroy; FindObjectOfType -> U4Compat.
	public override void Shutdown()
	{
		EffectManager component = parentObject.GetComponent<EffectManager>();
		CarCollider component2 = parentObject.GetComponent<CarCollider>();
		component2.DecrementInputBlock();
		component2.ignoreGravity = false;
		if (!component.HasEffect(typeof(FlipEffect)))
		{
			Transform transform = component.transform.Find("Wipeout Particle Effect");
			if (transform != null)
			{
				Object.Destroy(transform.gameObject);
			}
		}
		if (restoreCamFacingFlag)
		{
			FollowCamera followCamera = U4Compat.FindObjectOfType(typeof(FollowCamera)) as FollowCamera;
			if (followCamera != null)
			{
				followCamera.SendMessage("SetCrashCam", false);
			}
		}
	}

	// RECUPERADO-AOT FlipEffect::Stack token 0x0600037c @0x000f4084
	public override bool Stack(BaseEffect second)
	{
		return false;
	}

	// RECUPERADO-AOT FlipEffect::GetEffectSnapShot token 0x0600037d @0x000f40b8
	public override BaseEffect GetEffectSnapShot()
	{
		return this;
	}
}
