using UnityEngine;

// Tutorial/race mission: finish the lap.
// Source listing: recovery/aot_listings/Assembly-CSharp/FinishTheLapMission.txt
public class FinishTheLapMission : BaseMission
{
	// RECUPERADO-AOT FinishTheLapMission::Init token 0x060002bc @0x000eb32c (empty)
	public override void Init()
	{
	}

	// RECUPERADO-AOT FinishTheLapMission::Update token 0x060002bd @0x000eb358 (empty)
	public override void Update()
	{
	}

	// RECUPERADO-AOT FinishTheLapMission::Shutdown token 0x060002be @0x000eb384 (empty)
	public override void Shutdown()
	{
	}

	// RECUPERADO-AOT FinishTheLapMission::Signal token 0x060002bf @0x000eb3b0
	public override void Signal(string signal)
	{
		if (signal == "Finished Lap" && (missionCollection == null || missionCollection.getCheckCurrentMission()))
		{
			manager.CompleteMission(this);
		}
	}

	// RECUPERADO-AOT FinishTheLapMission::Signal token 0x060002c0 @0x000eb440 (empty)
	public override void Signal(string signal, object value)
	{
	}
}
