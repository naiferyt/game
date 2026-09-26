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
		RecoveryPending.Hit("CarAI.AIEvaluationPump");
		yield break;
	}

	private bool TestForNoticePickup(Collider collider)
	{
		RecoveryPending.Hit("CarAI.TestForNoticePickup");
		return default(bool);
	}

	private bool TestForPowerupUsage(Collider collider)
	{
		RecoveryPending.Hit("CarAI.TestForPowerupUsage");
		return default(bool);
	}

	private bool TestForAvoidBadTerrain(Collider collider)
	{
		RecoveryPending.Hit("CarAI.TestForAvoidBadTerrain");
		return default(bool);
	}

	private bool TestForHitBeneficialTerrain(Collider collider)
	{
		RecoveryPending.Hit("CarAI.TestForHitBeneficialTerrain");
		return default(bool);
	}

	private bool TestForHarassCar(Collider collider)
	{
		RecoveryPending.Hit("CarAI.TestForHarassCar");
		return default(bool);
	}

	private void EvaluateStates()
	{
		RecoveryPending.Hit("CarAI.EvaluateStates");
	}

	public void StateDone(BaseCarAIState state)
	{
		RecoveryPending.Hit("CarAI.StateDone");
	}

	private void AddState(AIStates state)
	{
		RecoveryPending.Hit("CarAI.AddState");
	}

	private void Start()
	{
		RecoveryPending.Hit("CarAI.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("CarAI.Update");
	}

	private void OnDrawGizmos()
	{
		RecoveryPending.Hit("CarAI.OnDrawGizmos");
	}

	private void FixedUpdate()
	{
		RecoveryPending.Hit("CarAI.FixedUpdate");
	}

	public void ClearStates()
	{
		RecoveryPending.Hit("CarAI.ClearStates");
	}

	public void DriveWithFacing(Vector3 desiredFacing)
	{
		RecoveryPending.Hit("CarAI.DriveWithFacing");
	}

	public void DriveTowardPoint(Vector3 desiredPoint)
	{
		RecoveryPending.Hit("CarAI.DriveTowardPoint");
	}
}
