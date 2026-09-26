using System.Collections;
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
			return default(bool);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	public void KillAI()
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator ArmMine()
	{
		return default(IEnumerator);
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void SetOwner(GameObject obj)
	{
	}
}
