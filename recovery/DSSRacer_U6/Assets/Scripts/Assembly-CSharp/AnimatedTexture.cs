using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class AnimatedTexture : MonoBehaviour
{
	public float uOffset;

	public float vOffset;

	public float uTile;

	public float vTile;

	private Material mat;

	private void Start()
	{
		RecoveryPending.Hit("AnimatedTexture.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("AnimatedTexture.Update");
	}

	[DebuggerHidden]
	private IEnumerator UpdateTexture()
	{
		RecoveryPending.Hit("AnimatedTexture.UpdateTexture");
		yield break;
	}
}
