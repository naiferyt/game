using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// "Full" rival AI: a stack of states (drive waypoints, get pickup, hit beneficial terrain, use powerup, avoid bad
// terrain) re-evaluated three times a second from what the kart sees within its personality's awareness radius.
// The shipped game never runs it: QualityControl.DoFullAI is folded to false, so Start swaps it for GimpedCarAI.
// Source listing: recovery/aot_listings/Assembly-CSharp/CarAI.txt
public class CarAI : MonoBehaviour
{
	public enum AIStates
	{
		driveWaypoints = 0,
		getPickup = 1,
		hitBeneficialTerrain = 2,
		usePowerup = 3,
		avoidBadTerrain = 4
	}

	private delegate bool TestActionDelegate(Collider collider);

	private const float AI_EVALUATION_TICK = 1f / 3f;

	public const int losBlockerLayerMask = 2048;

	public const float AIVersion = 0.6f;

	public float DistEpsilon;

	public CarAIPersonality personality;

	private Dictionary<AIStates, Type> stateClassMap;

	private List<KeyValuePair<AIStates, TestActionDelegate>> delegateActionTestList;

	// RECUPERADO-AOT CarAI::.ctor token 0x06000016 @0x000c21c0 (field initializers + constructor body)
	private List<BaseCarAIState> stateStack = new List<BaseCarAIState>();

	private List<GameObject> knownGameObjects = new List<GameObject>();

	private CarCollider carCollider;

	private Transform myTransform;

	public CarAI()
	{
		stateClassMap = new Dictionary<AIStates, Type>();
		stateClassMap[AIStates.driveWaypoints] = typeof(DriveWaypointsCarAIState);
		stateClassMap[AIStates.getPickup] = typeof(DrivePickupAIState);
		stateClassMap[AIStates.usePowerup] = typeof(UsePowerupAIState);
		stateClassMap[AIStates.avoidBadTerrain] = typeof(DriveAvoidTerrainAIState);
		stateClassMap[AIStates.hitBeneficialTerrain] = typeof(DriveHitBeneficialAIState);
		delegateActionTestList = new List<KeyValuePair<AIStates, TestActionDelegate>>();
		delegateActionTestList.Add(new KeyValuePair<AIStates, TestActionDelegate>(AIStates.getPickup, TestForNoticePickup));
		delegateActionTestList.Add(new KeyValuePair<AIStates, TestActionDelegate>(AIStates.usePowerup, TestForPowerupUsage));
		delegateActionTestList.Add(new KeyValuePair<AIStates, TestActionDelegate>(AIStates.avoidBadTerrain, TestForAvoidBadTerrain));
		delegateActionTestList.Add(new KeyValuePair<AIStates, TestActionDelegate>(AIStates.hitBeneficialTerrain, TestForHitBeneficialTerrain));
	}

	// RECUPERADO-AOT CarAI::AIEvaluationPump token 0x06000017 @0x000c25b8
	// RECUPERADO-AOT CarAI/<AIEvaluationPump>c__Iterator0::MoveNext token 0x060007d0 @0x00140fc8
	[DebuggerHidden]
	private IEnumerator AIEvaluationPump()
	{
		while (true)
		{
			EvaluateStates();
			yield return new WaitForSeconds(1f / 3f + UnityEngine.Random.Range(0f, 0.02f));
		}
	}

	// RECUPERADO-AOT CarAI::TestForNoticePickup token 0x06000018 @0x000c2600
	private bool TestForNoticePickup(Collider collider)
	{
		PowerupHolder component = GetComponent<PowerupHolder>();
		if (component == null)
		{
			return false;
		}
		if (!component.CanTakePowerup)
		{
			return false;
		}
		if (collider.tag != "Pickup" || collider.GetComponent<Coin>() != null)
		{
			return false;
		}
		ObjectTrackDistanceLogic component2 = collider.gameObject.GetComponent<ObjectTrackDistanceLogic>();
		if (component2 != null)
		{
			if (component2.trackDistance < WaypointLogic.GetTrackDistanceForPoint(myTransform.position))
			{
				return false;
			}
		}
		else
		{
			UnityEngine.Debug.Log("The " + collider.gameObject.ToString() + " needs an ObjectTrackDistanceLogic component!!");
		}
		return !((collider.transform.position - myTransform.position).sqrMagnitude < 1600f);
	}

	// RECUPERADO-AOT CarAI::TestForPowerupUsage token 0x06000019 @0x000c286c
	private bool TestForPowerupUsage(Collider collider)
	{
		if (GetComponent<CarAIPathRecorder>() != null)
		{
			return false;
		}
		PowerupHolder component = GetComponent<PowerupHolder>();
		if (component == null)
		{
			return false;
		}
		return component.numEffects > 0;
	}

	// RECUPERADO-AOT CarAI::TestForAvoidBadTerrain token 0x0600001a @0x000c2920
	private bool TestForAvoidBadTerrain(Collider collider)
	{
		TerrainEffectTrigger component = collider.gameObject.GetComponent<TerrainEffectTrigger>();
		if (component == null)
		{
			return false;
		}
		if (BaseEffect.isBeneficial(component.effectType))
		{
			return false;
		}
		ObjectTrackDistanceLogic component2 = collider.gameObject.GetComponent<ObjectTrackDistanceLogic>();
		if (component2 != null)
		{
			if (component2.trackDistance < WaypointLogic.GetTrackDistanceForPoint(myTransform.position))
			{
				return false;
			}
		}
		else
		{
			UnityEngine.Debug.Log("The " + collider.gameObject.ToString() + " needs an ObjectTrackDistanceLogic component!!");
		}
		return true;
	}

	// RECUPERADO-AOT CarAI::TestForHitBeneficialTerrain token 0x0600001b @0x000c2a8c
	private bool TestForHitBeneficialTerrain(Collider collider)
	{
		TerrainEffectTrigger component = collider.gameObject.GetComponent<TerrainEffectTrigger>();
		if (component == null)
		{
			return false;
		}
		if (!BaseEffect.isBeneficial(component.effectType))
		{
			return false;
		}
		ObjectTrackDistanceLogic component2 = collider.gameObject.GetComponent<ObjectTrackDistanceLogic>();
		if (component2 != null)
		{
			if (component2.trackDistance < WaypointLogic.GetTrackDistanceForPoint(myTransform.position))
			{
				return false;
			}
		}
		else
		{
			UnityEngine.Debug.Log("The " + collider.gameObject.ToString() + " needs an ObjectTrackDistanceLogic component!!");
		}
		return !((collider.transform.position - myTransform.position).sqrMagnitude < 1600f);
	}

	// RECUPERADO-AOT CarAI::TestForHarassCar token 0x0600001c @0x000c2cac (not in the test list: unused)
	private bool TestForHarassCar(Collider collider)
	{
		if (collider.GetComponent<CarCollider>() == null)
		{
			return false;
		}
		float trackDistanceForPoint = WaypointLogic.GetTrackDistanceForPoint(collider.transform.position);
		return !(WaypointLogic.GetTrackDistanceForPoint(myTransform.position) < trackDistanceForPoint);
	}

	// RECUPERADO-AOT CarAI::EvaluateStates token 0x0600001d @0x000c2da0
	// RECUPERADO-AOT CarAI/<EvaluateStates>c__AnonStorey8F::<>m__1 token 0x06000b30 @0x001664ec (predicate)
	// Each newly seen object (not a coin, in line of sight) triggers at most one test; each test fires at most once
	// per evaluation. Every triggered state is then added with probability = its personality weight.
	private void EvaluateStates()
	{
		if (personality == null || personality.stateWeightMap == null)
		{
			UnityEngine.Debug.LogError("Could not find a personality with stateWeightMap!");
			return;
		}
		List<KeyValuePair<AIStates, TestActionDelegate>> list = new List<KeyValuePair<AIStates, TestActionDelegate>>(delegateActionTestList);
		List<KeyValuePair<AIStates, float>> list2 = new List<KeyValuePair<AIStates, float>>();
		Dictionary<AIStates, float> stateWeightMap = personality.stateWeightMap;
		List<GameObject> list3 = new List<GameObject>();
		Collider[] array = Physics.OverlapSphere(myTransform.position, personality.awarenessRadius);
		for (int i = 0; i < array.Length; i++)
		{
			Collider collider = array[i];
			if (collider.gameObject.GetComponent<Coin>() != null)
			{
				continue;
			}
			Vector3 vector = collider.transform.position - myTransform.position;
			Ray ray = new Ray(myTransform.position, vector.normalized);
			if (Physics.Raycast(ray, vector.magnitude, 2048))
			{
				continue;
			}
			list3.Add(collider.gameObject);
			if (knownGameObjects.Exists((GameObject go) => go == collider.gameObject))
			{
				continue;
			}
			foreach (KeyValuePair<AIStates, TestActionDelegate> item in list)
			{
				if (item.Value(collider))
				{
					list2.Add(new KeyValuePair<AIStates, float>(item.Key, stateWeightMap[item.Key]));
					list.Remove(item);
					break;
				}
			}
		}
		knownGameObjects = list3;
		if (list2.Count == 0)
		{
			return;
		}
		foreach (KeyValuePair<AIStates, float> item2 in list2)
		{
			if (UnityEngine.Random.value < item2.Value)
			{
				AddState(item2.Key);
			}
		}
	}

	// RECUPERADO-AOT CarAI::StateDone token 0x0600001e @0x000c350c
	public void StateDone(BaseCarAIState state)
	{
		if (state != null)
		{
			int num = stateStack.IndexOf(state);
			state.Shutdown();
			stateStack.Remove(state);
			if (num == 0 && stateStack.Count > 0 && stateStack[0] != null)
			{
				stateStack[0].Init();
			}
		}
	}

	// RECUPERADO-AOT CarAI::AddState token 0x0600001f @0x000c35e4
	// New states queue behind the current one; a plain "drive waypoints" on top gives way immediately.
	private void AddState(AIStates state)
	{
		if (!stateClassMap.ContainsKey(state))
		{
			UnityEngine.Debug.Log("Could not switch to state " + state.ToString() + " (no class defined)");
			return;
		}
		Type type = stateClassMap[state];
		BaseCarAIState baseCarAIState = (BaseCarAIState)type.GetConstructor(Type.EmptyTypes).Invoke(null);
		baseCarAIState.parentAI = this;
		stateStack.Add(baseCarAIState);
		if (stateStack[0].GetAIStateEnum() == AIStates.driveWaypoints)
		{
			if (stateStack.Count > 1)
			{
				StateDone(stateStack[0]);
			}
			else
			{
				stateStack[0].Init();
			}
		}
	}

	// RECUPERADO-AOT CarAI::Start token 0x06000020 @0x000c37cc
	private void Start()
	{
		if (!QualityControl.DoFullAI)
		{
			base.gameObject.AddComponent(typeof(GimpedCarAI));
			UnityEngine.Object.Destroy(this);
			return;
		}
		myTransform = base.transform;
		carCollider = GetComponent<CarCollider>();
		personality = (CarAIPersonality)UnityEngine.Object.Instantiate(personality);
		Animation componentInChildren = GetComponentInChildren<Animation>();
		if (componentInChildren != null && !RaceManager.IsPlayerCar(base.gameObject))
		{
			AnimationDriver component = GetComponent<AnimationDriver>();
			if (component != null)
			{
				component.SetAnimationTarget(componentInChildren.gameObject);
			}
			else
			{
				UnityEngine.Debug.LogWarning("Could not find an AnimationDriver on " + base.name);
			}
		}
		else
		{
			UnityEngine.Debug.LogWarning("Could not find an Animation component on " + base.name);
		}
		StartCoroutine(AIEvaluationPump());
	}

	// RECUPERADO-AOT CarAI::Update token 0x06000021 @0x000c39cc
	private void Update()
	{
		if (stateStack.Count > 0)
		{
			stateStack[0].Update();
		}
		else
		{
			AddState(AIStates.driveWaypoints);
		}
	}

	// RECUPERADO-AOT CarAI::OnDrawGizmos token 0x06000022 @0x000c3a44
	private void OnDrawGizmos()
	{
		if (stateStack.Count > 0 && stateStack[0].GetAIStateEnum() == AIStates.driveWaypoints)
		{
			DriveWaypointsCarAIState driveWaypointsCarAIState = stateStack[0] as DriveWaypointsCarAIState;
			Gizmos.color = Color.magenta;
			if (driveWaypointsCarAIState != null && driveWaypointsCarAIState.targetSP != null)
			{
				Gizmos.DrawLine(base.transform.position, driveWaypointsCarAIState.targetSP.transform.position);
			}
		}
		if (stateStack.Count > 0 && stateStack[0].GetAIStateEnum() == AIStates.getPickup)
		{
			DrivePickupAIState drivePickupAIState = stateStack[0] as DrivePickupAIState;
			Gizmos.color = Color.cyan;
			if (drivePickupAIState != null && drivePickupAIState.desiredPickup != null)
			{
				Gizmos.DrawLine(base.transform.position, drivePickupAIState.desiredPickup.transform.position);
			}
		}
		if (stateStack.Count > 0 && stateStack[0].GetAIStateEnum() == AIStates.hitBeneficialTerrain)
		{
			DriveHitBeneficialAIState driveHitBeneficialAIState = stateStack[0] as DriveHitBeneficialAIState;
			Gizmos.color = Color.yellow;
			if (driveHitBeneficialAIState != null && driveHitBeneficialAIState.aimPoint != Vector3.zero)
			{
				Gizmos.DrawLine(base.transform.position, driveHitBeneficialAIState.aimPoint);
			}
		}
		if (stateStack.Count > 0 && stateStack[0].GetAIStateEnum() == AIStates.avoidBadTerrain)
		{
			DriveAvoidTerrainAIState driveAvoidTerrainAIState = stateStack[0] as DriveAvoidTerrainAIState;
			Gizmos.color = Color.black;
			if (driveAvoidTerrainAIState != null && driveAvoidTerrainAIState.awayfromPoint != Vector3.zero)
			{
				Gizmos.DrawLine(base.transform.position, driveAvoidTerrainAIState.awayfromPoint);
			}
		}
	}

	// RECUPERADO-AOT CarAI::FixedUpdate token 0x06000023 @0x000c3fdc
	private void FixedUpdate()
	{
		if (stateStack.Count > 0)
		{
			stateStack[0].FixedUpdate();
		}
	}

	// RECUPERADO-AOT CarAI::ClearStates token 0x06000024 @0x000c404c
	public void ClearStates()
	{
		foreach (BaseCarAIState item in stateStack)
		{
			if (item != null)
			{
				item.Shutdown();
			}
		}
		stateStack.Clear();
	}

	// RECUPERADO-AOT CarAI::DriveWithFacing token 0x06000025 @0x000c41ac
	// Steers toward the flattened direction (dead zone 5 degrees), drifts past the kart's power-slide angle and
	// backs up when the target is more than 30 degrees off and farther than DistEpsilon.
	public void DriveWithFacing(Vector3 desiredFacing)
	{
		float magnitude = desiredFacing.magnitude;
		desiredFacing.Normalize();
		Vector3 forward = myTransform.forward;
		forward.y = 0f;
		desiredFacing.y = 0f;
		float num = Vector3.Angle(forward, desiredFacing);
		num *= Mathf.Sign(Vector3.Dot(myTransform.right, desiredFacing));
		if (!(5f >= Mathf.Abs(num)))
		{
			carCollider.ApplyTurning(Mathf.Sign(num));
		}
		carCollider.ApplyDrift(carCollider.attributes.powerSlideAngle < Mathf.Abs(num));
		if (!(30f >= Mathf.Abs(num)) && !(DistEpsilon >= magnitude))
		{
			carCollider.ApplyAcceleration(-1f);
		}
		else
		{
			carCollider.ApplyAcceleration(1f);
		}
	}

	// RECUPERADO-AOT CarAI::DriveTowardPoint token 0x06000026 @0x000c44fc
	public void DriveTowardPoint(Vector3 desiredPoint)
	{
		DriveWithFacing(desiredPoint - myTransform.position);
	}
}
