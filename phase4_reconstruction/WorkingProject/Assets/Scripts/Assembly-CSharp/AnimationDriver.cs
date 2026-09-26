using System.Collections;
using System.Collections.Generic;
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
			return default(AnimationState);
		}
	}

	public void SetAnimationTarget(GameObject targ)
	{
	}

	private void Update()
	{
	}

	public void Play(string anim, bool looping)
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator CrossFadeToNewAnimation(string anim, bool loop)
	{
		return default(IEnumerator);
	}

	public void Blend(string anim, float weight)
	{
	}

	public void Lean(float offset)
	{
	}
}
