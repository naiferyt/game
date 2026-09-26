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

	protected int powerLevel;

	private static Dictionary<EffectTypes, Dictionary<EffectTypes, EffectTypes>> comboLookup;

	public static Dictionary<EffectTypes, Dictionary<EffectTypes, EffectTypes>> ComboLookup
	{
		get
		{
			RecoveryPending.Hit("BaseEffect.get_ComboLookup");
			return default(Dictionary<EffectTypes, Dictionary<EffectTypes, EffectTypes>>);
		}
		set
		{
			RecoveryPending.Hit("BaseEffect.set_ComboLookup");
		}
	}

	public EffectTypes EffectType
	{
		get
		{
			RecoveryPending.Hit("BaseEffect.get_EffectType");
			return default(EffectTypes);
		}
		set
		{
			RecoveryPending.Hit("BaseEffect.set_EffectType");
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

	public int PowerLevel
	{
		get
		{
			RecoveryPending.Hit("BaseEffect.get_PowerLevel");
			return default(int);
		}
		set
		{
			RecoveryPending.Hit("BaseEffect.set_PowerLevel");
		}
	}

	public bool isBeneficial()
	{
		RecoveryPending.Hit("BaseEffect.isBeneficial");
		return default(bool);
	}

	public static bool isBeneficial(EffectTypes effType)
	{
		RecoveryPending.Hit("BaseEffect.isBeneficial");
		return default(bool);
	}

	public static BaseEffect GetEffectInstance(EffectTypes effectType, GameObject owner)
	{
		RecoveryPending.Hit("BaseEffect.GetEffectInstance");
		return default(BaseEffect);
	}

	public abstract void Init();

	public abstract void Update();

	public abstract void Shutdown();

	public abstract bool Stack(BaseEffect second);

	public abstract BaseEffect GetEffectSnapShot();

	public virtual void FixedUpdate()
	{
		RecoveryPending.Hit("BaseEffect.FixedUpdate");
	}

	public static void InitComboLookup()
	{
		RecoveryPending.Hit("BaseEffect.InitComboLookup");
	}

	public static void SetUpComboLookup(EffectTypes type1, EffectTypes type2, EffectTypes comboType)
	{
		RecoveryPending.Hit("BaseEffect.SetUpComboLookup");
	}

	public static bool GetComboEffectType(EffectTypes type1, EffectTypes type2, out EffectTypes comboType)
	{
		RecoveryPending.Hit("BaseEffect.GetComboEffectType");
		comboType = default(EffectTypes);
		return default(bool);
	}

	public void DebugDump()
	{
		RecoveryPending.Hit("BaseEffect.DebugDump");
	}
}
