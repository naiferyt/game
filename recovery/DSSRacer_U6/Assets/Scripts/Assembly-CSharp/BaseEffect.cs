using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class BaseEffect
{
	public enum EffectTypes
	{
		BoosterEffect = 0,
		SlowdownEffect = 1,
		WipeoutEffect = 2,
		FlipEffect = 3,
		GuidedJumpEffect = 4,
		MineEffect = 5,
		RocketEffect = 6,
		ShieldEffect = 7,
		SmashEffect = 8,
		TeleportEffect = 9,
		SkidEffect = 10,
		BoatAnchorEffect = 11,
		RocketRideEffect = 12,
		TripLineEffect = 13,
		PowerupMagnetEffect = 14,
		SpreadMineEffect = 15,
		RandomShotEffect = 16,
		ShockEffect = 17,
		PieHitEffect = 18
	}

	public float time;

	public int power;

	public EffectTypes effectType;

	protected bool isMultiLevel;

	// RECUPERADO-AOT BaseEffect::.ctor token 0x06000345 @0x000f05fc (field initializer)
	protected int powerLevel = 1;

	private static Dictionary<EffectTypes, Dictionary<EffectTypes, EffectTypes>> comboLookup;

	// RECUPERADO-AOT BaseEffect::get_ComboLookup token 0x06000347 @0x000f0658
	// RECUPERADO-AOT BaseEffect::set_ComboLookup token 0x06000348 @0x000f0690
	public static Dictionary<EffectTypes, Dictionary<EffectTypes, EffectTypes>> ComboLookup
	{
		get
		{
			return comboLookup;
		}
		set
		{
			comboLookup = value;
		}
	}

	// RECUPERADO-AOT BaseEffect::get_EffectType token 0x06000349 @0x000f06d4
	// RECUPERADO-AOT BaseEffect::set_EffectType token 0x0600034a @0x000f0708
	public EffectTypes EffectType
	{
		get
		{
			return effectType;
		}
		set
		{
			effectType = value;
		}
	}

	// RECUPERADO-AOT BaseEffect::get_IsMultiLevel token 0x0600034b @0x000f0744
	// RECUPERADO-AOT BaseEffect::set_IsMultiLevel token 0x0600034c @0x000f0778
	public bool IsMultiLevel
	{
		get
		{
			return isMultiLevel;
		}
		set
		{
			isMultiLevel = value;
		}
	}

	// RECUPERADO-AOT BaseEffect::get_PowerLevel token 0x0600034d @0x000f07b4
	// RECUPERADO-AOT BaseEffect::set_PowerLevel token 0x0600034e @0x000f07e8
	public int PowerLevel
	{
		get
		{
			return powerLevel;
		}
		set
		{
			powerLevel = value;
		}
	}

	// RECUPERADO-AOT BaseEffect::isBeneficial token 0x0600034f @0x000f0824
	public bool isBeneficial()
	{
		return isBeneficial(effectType);
	}

	// RECUPERADO-AOT BaseEffect::isBeneficial token 0x06000350 @0x000f085c
	// Case targets decoded from the SWITCH patch (forensics/scripts/switch_tables.py, GOT[616]).
	public static bool isBeneficial(EffectTypes effType)
	{
		switch (effType)
		{
		case EffectTypes.BoosterEffect:
			return true;
		case EffectTypes.SlowdownEffect:
			return false;
		case EffectTypes.WipeoutEffect:
			return false;
		case EffectTypes.FlipEffect:
			return false;
		case EffectTypes.GuidedJumpEffect:
			return false;
		case EffectTypes.MineEffect:
			return true;
		case EffectTypes.RocketEffect:
			return true;
		case EffectTypes.ShieldEffect:
			return true;
		case EffectTypes.SmashEffect:
			return true;
		case EffectTypes.TeleportEffect:
			return false;
		case EffectTypes.SkidEffect:
			return false;
		case EffectTypes.BoatAnchorEffect:
			return true;
		case EffectTypes.RocketRideEffect:
			return true;
		case EffectTypes.TripLineEffect:
			return true;
		case EffectTypes.PowerupMagnetEffect:
			return true;
		case EffectTypes.SpreadMineEffect:
			return true;
		case EffectTypes.RandomShotEffect:
			return true;
		case EffectTypes.ShockEffect:
			return false;
		case EffectTypes.PieHitEffect:
			return false;
		default:
			UnityEngine.Debug.Break();
			return true;
		}
	}

	// RECUPERADO-AOT BaseEffect::GetEffectInstance token 0x06000351 @0x000f0960
	// Case targets decoded from the SWITCH patch (GOT[617]). Guided jumps and teleports are never created
	// through here.
	public static BaseEffect GetEffectInstance(EffectTypes effectType, GameObject owner)
	{
		BaseEffect result = null;
		switch (effectType)
		{
		case EffectTypes.BoosterEffect:
			result = new BoosterEffect(owner);
			break;
		case EffectTypes.SlowdownEffect:
			result = new SlowdownEffect(owner);
			break;
		case EffectTypes.WipeoutEffect:
			result = new WipeoutEffect(owner);
			break;
		case EffectTypes.FlipEffect:
			result = new FlipEffect(owner);
			break;
		case EffectTypes.GuidedJumpEffect:
			UnityEngine.Debug.Log("Bad Boy! Trying to get an instance of a GuidedJump, which you shouldn't be doing!");
			break;
		case EffectTypes.TeleportEffect:
			UnityEngine.Debug.Log("You must be trying to be evil, reaching for an instance of a Teleport. No no no...");
			break;
		case EffectTypes.MineEffect:
			result = new MineEffect(owner);
			break;
		case EffectTypes.RocketEffect:
			result = new RocketEffect(owner);
			break;
		case EffectTypes.ShieldEffect:
			result = new ShieldEffect(owner);
			break;
		case EffectTypes.SmashEffect:
			result = new SmashEffect(owner);
			break;
		case EffectTypes.SkidEffect:
			result = new SkidEffect(owner);
			break;
		case EffectTypes.BoatAnchorEffect:
			result = new BoatAnchorEffect(owner);
			break;
		case EffectTypes.RocketRideEffect:
			result = new RocketRideEffect(owner);
			break;
		case EffectTypes.TripLineEffect:
			result = new TripLineEffect(owner);
			break;
		case EffectTypes.RandomShotEffect:
			result = new RandomShotEffect(owner);
			break;
		case EffectTypes.SpreadMineEffect:
			result = new SpreadMineEffect(owner);
			break;
		case EffectTypes.PowerupMagnetEffect:
			result = new PowerupMagnet(owner);
			break;
		case EffectTypes.ShockEffect:
			result = new ShockedEffect(owner);
			break;
		case EffectTypes.PieHitEffect:
			result = new PieHitEffect(owner, PieHitEffect.HitDirection.Right);
			break;
		default:
			UnityEngine.Debug.LogWarning("Unrecognized effect type!");
			break;
		}
		return result;
	}

	public abstract void Init();

	public abstract void Update();

	public abstract void Shutdown();

	public abstract bool Stack(BaseEffect second);

	public abstract BaseEffect GetEffectSnapShot();

	// RECUPERADO-AOT BaseEffect::FixedUpdate token 0x06000357 @0x000f0d04 (empty)
	public virtual void FixedUpdate()
	{
	}

	// RECUPERADO-AOT BaseEffect::InitComboLookup token 0x06000358 @0x000f0d30
	// Power-up pairs that merge into a combo: rocket+shield = boat anchor, booster+rocket = rocket ride,
	// booster+shield = trip line, mine+shield = magnet, mine+rocket = spread mine, booster+mine = random shot.
	public static void InitComboLookup()
	{
		comboLookup = new Dictionary<EffectTypes, Dictionary<EffectTypes, EffectTypes>>();
		SetUpComboLookup(EffectTypes.RocketEffect, EffectTypes.ShieldEffect, EffectTypes.BoatAnchorEffect);
		SetUpComboLookup(EffectTypes.BoosterEffect, EffectTypes.RocketEffect, EffectTypes.RocketRideEffect);
		SetUpComboLookup(EffectTypes.BoosterEffect, EffectTypes.ShieldEffect, EffectTypes.TripLineEffect);
		SetUpComboLookup(EffectTypes.MineEffect, EffectTypes.ShieldEffect, EffectTypes.PowerupMagnetEffect);
		SetUpComboLookup(EffectTypes.MineEffect, EffectTypes.RocketEffect, EffectTypes.SpreadMineEffect);
		SetUpComboLookup(EffectTypes.BoosterEffect, EffectTypes.MineEffect, EffectTypes.RandomShotEffect);
	}

	// RECUPERADO-AOT BaseEffect::SetUpComboLookup token 0x06000359 @0x000f0dec
	// Registers the combo in both orders.
	public static void SetUpComboLookup(EffectTypes type1, EffectTypes type2, EffectTypes comboType)
	{
		if (!comboLookup.ContainsKey(type1))
		{
			comboLookup[type1] = new Dictionary<EffectTypes, EffectTypes>();
		}
		comboLookup[type1][type2] = comboType;
		if (!comboLookup.ContainsKey(type2))
		{
			comboLookup[type2] = new Dictionary<EffectTypes, EffectTypes>();
		}
		comboLookup[type2][type1] = comboType;
	}

	// RECUPERADO-AOT BaseEffect::GetComboEffectType token 0x0600035a @0x000f0f80
	// True when the pair forms a combo whose type is a named EffectTypes value.
	public static bool GetComboEffectType(EffectTypes type1, EffectTypes type2, out EffectTypes comboType)
	{
		comboType = EffectTypes.BoosterEffect;
		if (!comboLookup.ContainsKey(type1))
		{
			return false;
		}
		if (!comboLookup[type1].ContainsKey(type2))
		{
			return false;
		}
		comboType = comboLookup[type1][type2];
		string[] names = Enum.GetNames(typeof(EffectTypes));
		for (int i = 0; i < names.Length; i++)
		{
			if (names[i] == comboType.ToString())
			{
				return true;
			}
		}
		return false;
	}

	// RECUPERADO-AOT BaseEffect::DebugDump token 0x0600035b @0x000f1138
	public void DebugDump()
	{
		UnityEngine.Debug.Log(string.Empty + effectType + "\n" + ("Time: " + time.ToString() + "\n") + ("Power: " + power.ToString() + "\n") + ("PowerLevel: " + powerLevel.ToString() + "\n") + ("Multilevel: " + isMultiLevel.ToString()));
	}
}
