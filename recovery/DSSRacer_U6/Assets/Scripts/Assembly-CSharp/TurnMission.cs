using UnityEngine;

// Tutorial mission: steer; moves the HUD's Power/Drift/Reverse buttons to their tutorial layout.
// Source listing: recovery/aot_listings/Assembly-CSharp/TurnMission.txt
public class TurnMission : BaseMission
{
	// RECUPERADO-AOT TurnMission::Init token 0x060002e0 @0x000ec788
	public override void Init()
	{
		Transform parent = HUDLogic.Instance.ughButtons["Power"].transform.parent;
		parent.localPosition = parent.localPosition + Vector3.down * 6.04f;
		HUDLogic.Instance.ughButtons["Drift"].transform.localPosition = Vector3.down * 2.04f;
		HUDLogic.Instance.ughButtons["Reverse"].transform.localPosition = new Vector3(-2.8f, -2.04f, 0f);
		if (Application.platform != (RuntimePlatform)8)
		{
			hasArrow = false;
		}
	}

	// RECUPERADO-AOT TurnMission::Update token 0x060002e1 @0x000eca14 (empty)
	public override void Update()
	{
	}

	// RECUPERADO-AOT TurnMission::Shutdown token 0x060002e2 @0x000eca40 (empty)
	public override void Shutdown()
	{
	}

	// RECUPERADO-AOT TurnMission::Signal token 0x060002e3 @0x000eca6c
	public override void Signal(string signal)
	{
		if (signal == "Turning")
		{
			manager.CompleteMission(this);
		}
	}

	// RECUPERADO-AOT TurnMission::Signal token 0x060002e4 @0x000ecad0 (empty)
	public override void Signal(string signal, object value)
	{
	}
}
