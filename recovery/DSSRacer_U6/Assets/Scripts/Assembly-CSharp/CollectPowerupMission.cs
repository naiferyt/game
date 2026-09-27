using UnityEngine;

// Tutorial mission: collect a power-up (empties the reserve and enables pickups first).
// Source listing: recovery/aot_listings/Assembly-CSharp/CollectPowerupMission.txt
public class CollectPowerupMission : BaseMission
{
	private bool hasStartedMission;

	// RECUPERADO-AOT CollectPowerupMission::.ctor token 0x060002a8 @0x000eac54 (constructor body)
	public CollectPowerupMission()
	{
		missionName = new LocalizedString("Collect Powerup Tutorial Mission");
	}

	// RECUPERADO-AOT CollectPowerupMission::Init token 0x060002a9 @0x000eacc8
	public override void Init()
	{
		hasStartedMission = false;
	}

	// RECUPERADO-AOT CollectPowerupMission::Update token 0x060002aa @0x000ead00
	public override void Update()
	{
		if (!hasStartedMission)
		{
			hasStartedMission = true;
			manager.gameObject.GetComponent<PowerupHolder>().ClearEffectsInReserve();
			manager.gameObject.GetComponent<PowerupHolder>().allowPowerups = true;
		}
	}

	// RECUPERADO-AOT CollectPowerupMission::Shutdown token 0x060002ab @0x000eadac (empty)
	public override void Shutdown()
	{
	}

	// RECUPERADO-AOT CollectPowerupMission::Signal token 0x060002ac @0x000eadd8
	public override void Signal(string signal)
	{
		if (signal == "Collected Powerup" && (missionCollection == null || missionCollection.getCheckCurrentMission()))
		{
			manager.CompleteMission(this);
			HUDLogic.Instance.StartCoroutine(HUDLogic.Instance.AnimatePowerupDohickeyIn());
		}
	}

	// RECUPERADO-AOT CollectPowerupMission::Signal token 0x060002ad @0x000eaea0 (empty)
	public override void Signal(string signal, object value)
	{
	}
}
