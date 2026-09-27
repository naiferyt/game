using UnityEngine;

// Teleport: after teleportTime the kart is moved to targetPos and faced along the track (the
// snapshot variant used by rewind teleports on the first Update).
// Source listing: recovery/aot_listings/Assembly-CSharp/TeleportEffect.txt
public class TeleportEffect : BaseEffect
{
	// RECUPERADO-AOT TeleportEffect::.ctor token 0x060003e1 @0x000f8fe4 (initializer + body below)
	public float teleportTime = 1f;

	private GameObject parentObject;

	private Vector3 targetPos;

	private float teleportTimer;

	private bool timeToTeleport;

	private bool isSnapshot;

	public TeleportEffect(GameObject owner, Vector3 target, bool isSnap)
	{
		parentObject = owner;
		targetPos = target;
		isSnapshot = isSnap;
		effectType = EffectTypes.TeleportEffect;
		time = teleportTime + 0.5f;
		power = 1;
	}

	// RECUPERADO-AOT TeleportEffect::Init token 0x060003e2 @0x000f90ac
	public override void Init()
	{
		if (!(parentObject != null))
		{
			return;
		}
		if (isSnapshot)
		{
			timeToTeleport = true;
			return;
		}
		EffectManager component = parentObject.GetComponent<EffectManager>();
		if (component != null)
		{
			SoundSequencer component2 = component.gameObject.GetComponent<SoundSequencer>();
			if (component2 != null)
			{
				component2.RequestPlay("teleport");
			}
		}
		teleportTimer = teleportTime;
		timeToTeleport = false;
	}

	// RECUPERADO-AOT TeleportEffect::Update token 0x060003e3 @0x000f91a8
	public override void Update()
	{
		teleportTimer -= Time.deltaTime;
		if (teleportTimer <= 0f)
		{
			timeToTeleport = true;
		}
		if (timeToTeleport)
		{
			parentObject.transform.position = targetPos;
			WaypointLogic waypointLogic = WaypointLogic.FindNextWaypoint(parentObject.transform.position);
			Vector3 vector = waypointLogic.transform.position - waypointLogic.backwardPoint.transform.position;
			parentObject.transform.forward = vector.normalized;
			timeToTeleport = false;
			teleportTimer = teleportTime;
		}
	}

	// RECUPERADO-AOT TeleportEffect::Shutdown token 0x060003e4 @0x000f9398
	// ADAPTADO-U6: Transform.FindChild -> Find.
	public override void Shutdown()
	{
		EffectManager component = parentObject.GetComponent<EffectManager>();
		if (!component.HasEffect(typeof(TeleportEffect)))
		{
			GameObject gameObject = component.transform.Find("Teleport Particle Effect").gameObject;
			if (gameObject != null)
			{
				Object.Destroy(gameObject);
			}
		}
	}

	// RECUPERADO-AOT TeleportEffect::Stack token 0x060003e5 @0x000f9464
	public override bool Stack(BaseEffect second)
	{
		return false;
	}

	// RECUPERADO-AOT TeleportEffect::GetEffectSnapShot token 0x060003e6 @0x000f9498
	public override BaseEffect GetEffectSnapShot()
	{
		return this;
	}
}
