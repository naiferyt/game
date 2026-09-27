using UnityEngine;

// Tutorial mission: brake (acceleration pointing against the kart's forward).
// Source listing: recovery/aot_listings/Assembly-CSharp/BrakeMission.txt
public class BrakeMission : BaseMission
{
	private bool hasStartedMission;

	// RECUPERADO-AOT BrakeMission::Init token 0x0600029c @0x000ea830
	public override void Init()
	{
		hasStartedMission = false;
		if (Application.platform != (RuntimePlatform)8)
		{
			hasArrow = false;
		}
	}

	// RECUPERADO-AOT BrakeMission::Update token 0x0600029d @0x000ea880
	public override void Update()
	{
		if (!hasStartedMission)
		{
			hasStartedMission = true;
			HUDLogic.Instance.StartCoroutine(HUDLogic.Instance.AnimateBrakeButtonIn());
		}
		GameObject playerCar = RaceManager.GetPlayerCar();
		CarCollider component = playerCar.GetComponent<CarCollider>();
		if (Vector3.Angle(playerCar.transform.forward, component.GetAccel()) >= 165f)
		{
			manager.CompleteMission(this);
		}
	}

	// RECUPERADO-AOT BrakeMission::Shutdown token 0x0600029e @0x000eaa1c (empty)
	public override void Shutdown()
	{
	}

	// RECUPERADO-AOT BrakeMission::Signal token 0x0600029f @0x000eaa48 (empty)
	public override void Signal(string signal)
	{
	}

	// RECUPERADO-AOT BrakeMission::Signal token 0x060002a0 @0x000eaa78 (empty)
	public override void Signal(string signal, object value)
	{
	}
}
