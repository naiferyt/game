using UnityEngine;

// Tutorial/race mission: buy a power-up with coins.
// Source listing: recovery/aot_listings/Assembly-CSharp/BuyPowerupMission.txt
public class BuyPowerupMission : BaseMission
{
	// RECUPERADO-AOT BuyPowerupMission::Start token 0x060002a2 @0x000eaae0 (empty)
	private void Start()
	{
	}

	// RECUPERADO-AOT BuyPowerupMission::Init token 0x060002a3 @0x000eab0c (empty)
	public override void Init()
	{
	}

	// RECUPERADO-AOT BuyPowerupMission::Shutdown token 0x060002a4 @0x000eab38 (empty)
	public override void Shutdown()
	{
	}

	// RECUPERADO-AOT BuyPowerupMission::Update token 0x060002a5 @0x000eab64 (empty)
	public override void Update()
	{
	}

	// RECUPERADO-AOT BuyPowerupMission::Signal token 0x060002a6 @0x000eab90
	public override void Signal(string signal)
	{
		if (signal == "Bought Powerup" && (missionCollection == null || missionCollection.getCheckCurrentMission()))
		{
			manager.CompleteMission(this);
		}
	}

	// RECUPERADO-AOT BuyPowerupMission::Signal token 0x060002a7 @0x000eac20 (empty)
	public override void Signal(string signal, object value)
	{
	}
}
