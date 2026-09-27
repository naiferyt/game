using UnityEngine;

// Tutorial mission: pause the game.
// Source listing: recovery/aot_listings/Assembly-CSharp/PauseMission.txt
public class PauseMission : BaseMission
{
	// RECUPERADO-AOT PauseMission::Init token 0x060002da @0x000ec60c (empty)
	public override void Init()
	{
	}

	// RECUPERADO-AOT PauseMission::Update token 0x060002db @0x000ec638 (empty)
	public override void Update()
	{
	}

	// RECUPERADO-AOT PauseMission::Shutdown token 0x060002dc @0x000ec664 (empty)
	public override void Shutdown()
	{
	}

	// RECUPERADO-AOT PauseMission::Signal token 0x060002dd @0x000ec690
	public override void Signal(string signal)
	{
		if (signal == "Paused Game" && (missionCollection == null || missionCollection.getCheckCurrentMission()))
		{
			manager.CompleteMission(this);
		}
	}

	// RECUPERADO-AOT PauseMission::Signal token 0x060002de @0x000ec720 (empty)
	public override void Signal(string signal, object value)
	{
	}
}
