using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

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

	private List<BaseCarAIState> stateStack;

	private List<GameObject> knownGameObjects;

	private CarCollider carCollider;

	private Transform myTransform;

	[DebuggerHidden]
	private IEnumerator AIEvaluationPump()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private bool TestForNoticePickup(Collider collider)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private bool TestForPowerupUsage(Collider collider)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private bool TestForAvoidBadTerrain(Collider collider)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private bool TestForHitBeneficialTerrain(Collider collider)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private bool TestForHarassCar(Collider collider)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void EvaluateStates()
	{
	}

	public void StateDone(BaseCarAIState state)
	{
	}

	private void AddState(AIStates state)
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnDrawGizmos()
	{
	}

	private void FixedUpdate()
	{
	}

	public void ClearStates()
	{
	}

	public void DriveWithFacing(Vector3 desiredFacing)
	{
	}

	public void DriveTowardPoint(Vector3 desiredPoint)
	{
	}
}
