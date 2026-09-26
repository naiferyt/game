using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class ParticleSystemDestroy : MonoBehaviour
{
	[DebuggerHidden]
	private IEnumerator Start()
	{
		RecoveryPending.Hit("ParticleSystemDestroy.Start");
		yield break;
	}
}
