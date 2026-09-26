using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class MineAI : MonoBehaviour
{
	private const int groundLayerMask = 256;

	private const int carLayerMask = 512;

	public float explosionRadius;

	public bool isSpread;

	public Vector3 spreadVector;

	private float spreadTime;

	private float armedDuration;

	private float armTime;

	private bool isArmed;

	private GameObject owner;

	public bool IsArmed
	{
		get
		{
			RecoveryPending.Hit("MineAI.get_IsArmed");
			return default(bool);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		RecoveryPending.Hit("MineAI.OnTriggerEnter");
	}

	public void KillAI()
	{
		RecoveryPending.Hit("MineAI.KillAI");
	}

	[DebuggerHidden]
	private IEnumerator ArmMine()
	{
		RecoveryPending.Hit("MineAI.ArmMine");
		yield break;
	}

	private void Start()
	{
		RecoveryPending.Hit("MineAI.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("MineAI.Update");
	}

	public void SetOwner(GameObject obj)
	{
		RecoveryPending.Hit("MineAI.SetOwner");
	}
}
