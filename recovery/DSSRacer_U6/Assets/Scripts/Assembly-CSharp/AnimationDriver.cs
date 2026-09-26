using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AnimationDriver : MonoBehaviour
{
	public float leanFactor;

	public float turnFactor;

	private bool inCoroutine;

	public static string[] animationNames;

	private Animation animationComp;

	private Dictionary<string, AnimationState> animationMap;

	public AnimationState this[string index]
	{
		get
		{
			RecoveryPending.Hit("AnimationDriver.get_Item");
			return default(AnimationState);
		}
	}

	public void SetAnimationTarget(GameObject targ)
	{
		RecoveryPending.Hit("AnimationDriver.SetAnimationTarget");
	}

	private void Update()
	{
		RecoveryPending.Hit("AnimationDriver.Update");
	}

	public void Play(string anim, bool looping)
	{
		RecoveryPending.Hit("AnimationDriver.Play");
	}

	[DebuggerHidden]
	private IEnumerator CrossFadeToNewAnimation(string anim, bool loop)
	{
		RecoveryPending.Hit("AnimationDriver.CrossFadeToNewAnimation");
		yield break;
	}

	public void Blend(string anim, float weight)
	{
		RecoveryPending.Hit("AnimationDriver.Blend");
	}

	public void Lean(float offset)
	{
		RecoveryPending.Hit("AnimationDriver.Lean");
	}
}
