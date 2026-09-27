using UnityEngine;

// Tutorial/race mission: combine two power-ups.
// Source listing: recovery/aot_listings/Assembly-CSharp/CombinePowerupMission.txt
public class CombinePowerupMission : BaseMission
{
	// RECUPERADO-AOT CombinePowerupMission::Start token 0x060002af @0x000eaf08 (empty)
	private void Start()
	{
	}

	// RECUPERADO-AOT CombinePowerupMission::Init token 0x060002b0 @0x000eaf34 (empty)
	public override void Init()
	{
	}

	// RECUPERADO-AOT CombinePowerupMission::Update token 0x060002b1 @0x000eaf60 (empty)
	public override void Update()
	{
	}

	// RECUPERADO-AOT CombinePowerupMission::Shutdown token 0x060002b2 @0x000eaf8c (empty)
	public override void Shutdown()
	{
	}

	// RECUPERADO-AOT CombinePowerupMission::Signal token 0x060002b3 @0x000eafb8
	public override void Signal(string signal)
	{
		if (signal == "Combined Powerup" && (missionCollection == null || missionCollection.getCheckCurrentMission()))
		{
			manager.CompleteMission(this);
		}
	}

	// RECUPERADO-AOT CombinePowerupMission::Signal token 0x060002b4 @0x000eb048 (empty)
	public override void Signal(string signal, object value)
	{
	}
}
