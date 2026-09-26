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
			return default(Dictionary<EffectTypes, Dictionary<EffectTypes, EffectTypes>>);
		}
		set
		{
		}
	}

	public EffectTypes EffectType
	{
		get
		{
			return default(EffectTypes);
		}
		set
		{
		}
	}

	public bool IsMultiLevel
	{
		get
		{
			return default(bool);
		}
		set
		{
		}
	}

	public int PowerLevel
	{
		get
		{
			return default(int);
		}
		set
		{
		}
	}

	public bool isBeneficial()
	{
		return default(bool);
	}

	public static bool isBeneficial(EffectTypes effType)
	{
		return default(bool);
	}

	public static BaseEffect GetEffectInstance(EffectTypes effectType, GameObject owner)
	{
		return default(BaseEffect);
	}

	public abstract void Init();

	public abstract void Update();

	public abstract void Shutdown();

	public abstract bool Stack(BaseEffect second);

	public abstract BaseEffect GetEffectSnapShot();

	public virtual void FixedUpdate()
	{
	}

	public static void InitComboLookup()
	{
	}

	public static void SetUpComboLookup(EffectTypes type1, EffectTypes type2, EffectTypes comboType)
	{
	}

	public static bool GetComboEffectType(EffectTypes type1, EffectTypes type2, out EffectTypes comboType)
	{
		comboType = default(EffectTypes);
		return default(bool);
	}

	public void DebugDump()
	{
	}
}
