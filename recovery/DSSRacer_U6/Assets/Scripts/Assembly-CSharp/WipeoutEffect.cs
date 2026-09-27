using UnityEngine;

// Wipeout (oil slick, drifting too long...): the kart spins in place with input blocked, then eases back
// to its heading over the last half second; the player's camera switches to the crash view meanwhile.
// Source listing: recovery/aot_listings/Assembly-CSharp/WipeoutEffect.txt
// (Adelantado de la Etapa 4 en 3.9: lo usan las pistas y los choques de la carrera.)
public class WipeoutEffect : BaseEffect
{
	private GameObject parentObject;

	private float baseTime;

	private float spinRate;

	// RECUPERADO-AOT WipeoutEffect::.ctor token 0x060003f2 @0x000f9dcc (field initializers + body)
	private Quaternion startingRot = Quaternion.identity;

	private Quaternion lastRot = Quaternion.identity;

	private bool restoreCamFacingFlag;

	public WipeoutEffect(GameObject parent)
	{
		parentObject = parent;
		effectType = EffectTypes.WipeoutEffect;
		power = 50;
		time = 1f;
	}

	// RECUPERADO-AOT WipeoutEffect::Init token 0x060003f3 @0x000f9e8c
	// Cancels a guided jump; whole turns only: spinRate = 360 * (int)(time / 0.5) / time.
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
		if (component.HasEffect(typeof(GuidedJumpEffect)))
		{
			component.RemoveEffect(component.GetStrongestEffect(typeof(GuidedJumpEffect)));
		}
		if (component != null)
		{
			SoundSequencer component2 = component.gameObject.GetComponent<SoundSequencer>();
			if (component2 != null)
			{
				component2.RequestPlay("brakes");
			}
		}
		CharacterVOController vOController = parentObject.GetVOController();
		if (vOController != null)
		{
			vOController.PlayPout();
		}
		CarCollider component3 = parentObject.GetComponent<CarCollider>();
		if ((bool)component3)
		{
			component3.IncrementInputBlock();
		}
		startingRot = parentObject.transform.rotation;
		baseTime = time;
		spinRate = 360f * (float)(int)(baseTime / 0.5f) / baseTime;
		FollowCamera followCamera = U4Compat.FindObjectOfType(typeof(FollowCamera)) as FollowCamera;
		if (followCamera != null && followCamera.followObject == parentObject)
		{
			followCamera.SendMessage("SetCrashCam", true);
			restoreCamFacingFlag = true;
		}
	}

	// RECUPERADO-AOT WipeoutEffect::Update token 0x060003f4 @0x000fa33c
	public override void Update()
	{
		if (parentObject != null)
		{
			if (time > 0.5f)
			{
				parentObject.transform.Rotate(0f, spinRate * Time.deltaTime, 0f);
				lastRot = parentObject.transform.rotation;
			}
			else
			{
				parentObject.transform.rotation = Quaternion.Lerp(startingRot, lastRot, time / 0.5f);
			}
		}
	}

	// RECUPERADO-AOT WipeoutEffect::Shutdown token 0x060003f5 @0x000fa57c
	// ADAPTADO-U6: Transform.FindChild -> Find; Object.DestroyObject -> Destroy; FindObjectOfType -> U4Compat.
	public override void Shutdown()
	{
		EffectManager component = parentObject.GetComponent<EffectManager>();
		CarCollider component2 = parentObject.GetComponent<CarCollider>();
		if ((bool)component2)
		{
			component2.DecrementInputBlock();
		}
		if (!component.HasEffect(typeof(WipeoutEffect)))
		{
			Transform transform = component.transform.Find("Wipeout Particle Effect");
			if (transform != null)
			{
				Object.Destroy(transform.gameObject);
			}
		}
		Transform transform2 = component.transform.Find("Laser Hit Particle");
		if (transform2 != null)
		{
			Object.Destroy(transform2.gameObject);
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

	// RECUPERADO-AOT WipeoutEffect::Stack token 0x060003f6 @0x000fa7a4
	public override bool Stack(BaseEffect second)
	{
		return false;
	}

	// RECUPERADO-AOT WipeoutEffect::GetEffectSnapShot token 0x060003f7 @0x000fa7d8
	public override BaseEffect GetEffectSnapShot()
	{
		return this;
	}
}
