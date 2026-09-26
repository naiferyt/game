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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	public void KillAI()
	{
	}

	[DebuggerHidden]
	private IEnumerator ArmMine()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
