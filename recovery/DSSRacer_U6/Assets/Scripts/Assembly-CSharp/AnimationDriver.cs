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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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

	[DebuggerHidden]
	private IEnumerator CrossFadeToNewAnimation(string anim, bool loop)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public void Blend(string anim, float weight)
	{
	}

	public void Lean(float offset)
	{
	}
}
