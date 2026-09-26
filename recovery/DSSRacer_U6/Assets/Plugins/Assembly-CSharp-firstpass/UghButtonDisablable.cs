using System.Collections;

// Button that can be locked: while locked (normal == locked prototype) it ignores presses.
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/UghButtonDisablable.txt
public class UghButtonDisablable : UghButton
{
	public UghSpritePrototype unlocked;

	private UghSpritePrototype locked;

	// RECUPERADO-AOT UghButtonDisablable.Start token 0x06000391 @0x0003ae6c
	public void Start()
	{
		locked = normal;
	}

	// RECUPERADO-AOT UghButtonDisablable.OnUghInputDown token 0x06000392 @0x0003aea4
	// (body: <OnUghInputDown>c__Iterator1C.MoveNext token 0x060005be @0x00057804)
	public override IEnumerator OnUghInputDown()
	{
		if (normal == unlocked || normal == pressed)
		{
			// (as compiled: the base iterator is created but never run, so no pressed sprite is shown)
			base.OnUghInputDown();
		}
		yield break;
	}

	// RECUPERADO-AOT UghButtonDisablable.OnUghInputUpAsButton token 0x06000393 @0x0003aeec
	public override void OnUghInputUpAsButton()
	{
		if (normal == unlocked || normal == pressed)
		{
			base.OnUghInputUpAsButton();
		}
	}

	// RECUPERADO-AOT UghButtonDisablable.SetLock token 0x06000394 @0x0003af48
	public void SetLock(bool b)
	{
		normal = b ? locked : unlocked;
		UpdateMeshWithSpritePrototype(normal);
	}

	// RECUPERADO-AOT UghButtonDisablable.ToggleLock token 0x06000395 @0x0003afac
	public void ToggleLock()
	{
		normal = (normal == locked) ? unlocked : locked;
		UpdateMeshWithSpritePrototype(normal);
	}
}
