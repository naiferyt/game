using UnityEngine;

// Tutorial/race mission: use a power-up.
// Source listing: recovery/aot_listings/Assembly-CSharp/UsePowerupMission.txt
public class UsePowerupMission : BaseMission
{
	// RECUPERADO-AOT UsePowerupMission::Init token 0x060002e6 @0x000ecb38 (empty)
	public override void Init()
	{
	}

	// RECUPERADO-AOT UsePowerupMission::Update token 0x060002e7 @0x000ecb64 (empty)
	public override void Update()
	{
	}

	// RECUPERADO-AOT UsePowerupMission::Shutdown token 0x060002e8 @0x000ecb90 (empty)
	public override void Shutdown()
	{
	}

	// RECUPERADO-AOT UsePowerupMission::Signal token 0x060002e9 @0x000ecbbc
	public override void Signal(string signal)
	{
		if (signal == "Used Powerup" && (missionCollection == null || missionCollection.getCheckCurrentMission()))
		{
			manager.CompleteMission(this);
		}
	}

	// RECUPERADO-AOT UsePowerupMission::Signal token 0x060002ea @0x000ecc4c (empty)
	public override void Signal(string signal, object value)
	{
	}
}
