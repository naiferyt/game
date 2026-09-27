using UnityEngine;

// AI state: decide, once, whether to fire each held power-up (rocket at the kart ahead unless shielded, shield
// against an incoming rocket or a mine ahead, mine when not last), then hand back to the previous state.
// Source listing: recovery/aot_listings/Assembly-CSharp/UsePowerupAIState.txt
public class UsePowerupAIState : BaseCarAIState
{
	private const int carLayerMask = 512;

	// RECUPERADO-AOT UsePowerupAIState::.ctor token 0x06000049 @0x000c66d4 (field initializers)
	public float RocketChancePercent = 0.25f;

	public float ShieldChancePercent = 0.33f;

	public float MineChancePercent = 0.5f;

	// RECUPERADO-AOT UsePowerupAIState::GetAIStateEnum token 0x0600004a @0x000c6748
	public override CarAI.AIStates GetAIStateEnum()
	{
		return CarAI.AIStates.usePowerup;
	}

	// RECUPERADO-AOT UsePowerupAIState::Init token 0x0600004b @0x000c6778
	public override void Init()
	{
	}

	// RECUPERADO-AOT UsePowerupAIState::Update token 0x0600004c @0x000c67a4
	public override void Update()
	{
		PowerupHolder component = parentAI.GetComponent<PowerupHolder>();
		if (component != null)
		{
			for (int i = 0; i < component.numEffects; i++)
			{
				if (component[i] == null)
				{
					continue;
				}
				switch (component[i].effectType)
				{
				case BaseEffect.EffectTypes.RocketEffect:
					DoRocketEffectExecute(component);
					break;
				case BaseEffect.EffectTypes.ShieldEffect:
					DoShieldEffectExecute(component);
					break;
				case BaseEffect.EffectTypes.MineEffect:
					DoMineEffectExecute(component);
					break;
				default:
					if (!(0.33f >= Random.value))
					{
						component.ExecutePowerups();
					}
					break;
				}
			}
		}
		parentAI.StateDone(this);
	}

	// RECUPERADO-AOT UsePowerupAIState::DoRocketEffectExecute token 0x0600004d @0x000c6908
	private void DoRocketEffectExecute(PowerupHolder holder)
	{
		if (!(RocketChancePercent >= Random.value))
		{
			holder.ExecutePowerups();
		}
		if (!(RaceManager.leadCar == parentAI.gameObject))
		{
			GameObject carInPosition = RaceManager.GetCarInPosition(RaceManager.GetCarPosition(parentAI.gameObject) - 1);
			EffectManager component = carInPosition.GetComponent<EffectManager>();
			if (component == null || !component.HasEffect(typeof(ShieldEffect)))
			{
				holder.ExecutePowerups();
			}
		}
	}

	// RECUPERADO-AOT UsePowerupAIState::DoShieldEffectExecute token 0x0600004e @0x000c6a10
	// Kept as compiled: the rocket/mine tests compare collider.gameObject.GetType() (always GameObject) with
	// typeof(RocketAI)/typeof(MineAI), so they never match and only the "not last" rule fires the shield.
	private void DoShieldEffectExecute(PowerupHolder holder)
	{
		if (!(ShieldChancePercent >= Random.value))
		{
			holder.ExecutePowerups();
		}
		Collider[] array = Physics.OverlapSphere(parentAI.gameObject.transform.position, parentAI.personality.awarenessRadius);
		foreach (Collider collider in array)
		{
			if (collider.gameObject.GetType() == typeof(RocketAI))
			{
				RocketAI component = collider.gameObject.GetComponent<RocketAI>();
				if (component != null && component.launchTarget == parentAI.gameObject)
				{
					holder.ExecutePowerups();
					return;
				}
			}
			if (collider.gameObject.GetType() == typeof(MineAI))
			{
				Vector3 rhs = collider.gameObject.transform.position - parentAI.gameObject.transform.position;
				if (!(Vector3.Dot(parentAI.gameObject.transform.forward, rhs) < 0f))
				{
					holder.ExecutePowerups();
					return;
				}
			}
		}
		if (RaceManager.GetCarPosition(parentAI.gameObject) != RaceManager.allCars.Length - 1)
		{
			holder.ExecutePowerups();
		}
	}

	// RECUPERADO-AOT UsePowerupAIState::DoMineEffectExecute token 0x0600004f @0x000c6d74
	// Kept as compiled: the per-kart test (collider.GetType() == typeof(CarCollider), never true) discards its
	// result, so the mine is always dropped after the scan.
	private void DoMineEffectExecute(PowerupHolder holder)
	{
		if (!(MineChancePercent >= Random.value))
		{
			holder.ExecutePowerups();
		}
		Collider[] array = Physics.OverlapSphere(parentAI.gameObject.transform.position, parentAI.personality.awarenessRadius);
		foreach (Collider collider in array)
		{
			if (collider.GetType() == typeof(CarCollider))
			{
				Vector3 rhs = collider.gameObject.transform.position - parentAI.gameObject.transform.position;
				Vector3.Dot(parentAI.gameObject.transform.forward, rhs);
			}
		}
		holder.ExecutePowerups();
	}

	// RECUPERADO-AOT UsePowerupAIState::FixedUpdate token 0x06000050 @0x000c6fbc
	public override void FixedUpdate()
	{
	}

	// RECUPERADO-AOT UsePowerupAIState::Shutdown token 0x06000051 @0x000c6fe8
	public override void Shutdown()
	{
	}
}
