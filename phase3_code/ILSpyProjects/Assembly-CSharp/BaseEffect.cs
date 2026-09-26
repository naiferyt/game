using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class BaseEffect
{
	public enum EffectTypes
	{
		BoosterEffect,
		SlowdownEffect,
		WipeoutEffect,
		FlipEffect,
		GuidedJumpEffect,
		MineEffect,
		RocketEffect,
		ShieldEffect,
		SmashEffect,
		TeleportEffect,
		SkidEffect,
		BoatAnchorEffect,
		RocketRideEffect,
		TripLineEffect,
		PowerupMagnetEffect,
		SpreadMineEffect,
		RandomShotEffect,
		ShockEffect,
		PieHitEffect
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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	public EffectTypes EffectType
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	public bool IsMultiLevel
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	public int PowerLevel
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	public bool isBeneficial()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static bool isBeneficial(EffectTypes effType)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static BaseEffect GetEffectInstance(EffectTypes effectType, GameObject owner)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public void DebugDump()
	{
	}
}
