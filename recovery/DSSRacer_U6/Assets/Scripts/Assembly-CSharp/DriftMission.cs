using UnityEngine;

// Tutorial mission: drift for half a second, or (isBoost) get a power-slide boost.
// Source listing: recovery/aot_listings/Assembly-CSharp/DriftMission.txt
public class DriftMission : BaseMission
{
	public bool isBoost;

	private bool hasStartedMission;

	// RECUPERADO-AOT DriftMission::Init token 0x060002b6 @0x000eb0b0
	public override void Init()
	{
		hasStartedMission = false;
		if (Application.platform != (RuntimePlatform)8 && !isBoost)
		{
			hasArrow = false;
		}
		else
		{
			hasArrow = true;
		}
	}

	// RECUPERADO-AOT DriftMission::Update token 0x060002b7 @0x000eb110
	public override void Update()
	{
		if (!hasStartedMission)
		{
			hasStartedMission = true;
			if (!isBoost)
			{
				HUDLogic.Instance.StartCoroutine(HUDLogic.Instance.AnimateDriftButtonIn());
			}
		}
		CarCollider component = RaceManager.GetPlayerCar().GetComponent<CarCollider>();
		if (isBoost)
		{
			HUDLogic.Instance.forceDriftScaleToShow = true;
			if (component.isDrifting && component.isPowerSlideQueued)
			{
				HUDLogic.Instance.forceDriftScaleToShow = false;
				manager.CompleteMission(this);
			}
		}
		else if (component.PowerSlideTimer > 0.5f)
		{
			manager.CompleteMission(this);
		}
	}

	// RECUPERADO-AOT DriftMission::Shutdown token 0x060002b8 @0x000eb268 (empty)
	public override void Shutdown()
	{
	}

	// RECUPERADO-AOT DriftMission::Signal token 0x060002b9 @0x000eb294 (empty)
	public override void Signal(string signal)
	{
	}

	// RECUPERADO-AOT DriftMission::Signal token 0x060002ba @0x000eb2c4 (empty)
	public override void Signal(string signal, object value)
	{
	}
}
