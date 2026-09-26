using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// Drives a kart driver's legacy Animation: maps the clips by suffix (idle, driving, turnLeft...), keeps "driving"
// looping, leans into turns by blending turnLeft/turnRight and pauses with the race.
// Source listing: recovery/aot_listings/Assembly-CSharp/AnimationDriver.txt
public class AnimationDriver : MonoBehaviour
{
	// RECUPERADO-AOT AnimationDriver::.ctor token 0x06000196 @0x000d5424 (field initializers)
	public float leanFactor = 10f;

	public float turnFactor;

	private bool inCoroutine;

	// RECUPERADO-AOT AnimationDriver::.cctor token 0x06000197 @0x000d5470
	public static string[] animationNames = new string[12]
	{
		"idle", "idle2", "idle3", "driving", "sitting", "turnLeft", "turnRight", "cheering", "fist", "handsUp",
		"selection", "wave"
	};

	private Animation animationComp;

	private Dictionary<string, AnimationState> animationMap;

	// RECUPERADO-AOT AnimationDriver::get_Item token 0x06000198 @0x000d5674
	public AnimationState this[string index]
	{
		get
		{
			return animationMap[index];
		}
	}

	// RECUPERADO-AOT AnimationDriver::SetAnimationTarget token 0x06000199 @0x000d56bc
	// Each clip whose name ends with one of animationNames (case-insensitive) is registered under that name.
	public void SetAnimationTarget(GameObject targ)
	{
		animationComp = targ.GetComponentInChildren<Animation>();
		if (animationComp == null)
		{
			UnityEngine.Debug.LogWarning("Could not find animation component on object " + base.name);
			return;
		}
		animationMap = new Dictionary<string, AnimationState>();
		foreach (AnimationState item in animationComp)
		{
			string[] array = animationNames;
			foreach (string text in array)
			{
				if (item.name.ToLower().EndsWith(text.ToLower()))
				{
					if (animationMap.ContainsKey(text))
					{
						UnityEngine.Debug.LogWarning("Found multiple animation candidates for name " + text + " in object " + base.name);
					}
					animationMap[text] = item;
					break;
				}
			}
		}
		animationComp.clip.wrapMode = WrapMode.Once;
		Play("driving", true);
	}

	// RECUPERADO-AOT AnimationDriver::Update token 0x0600019a @0x000d5b2c
	private void Update()
	{
		if (animationComp == null)
		{
			return;
		}
		if (!animationComp.IsPlaying(animationMap["driving"].name))
		{
			Play("driving", true);
		}
		if (turnFactor != 0f)
		{
			Lean(turnFactor * leanFactor);
		}
		else
		{
			Lean(0f);
		}
		if (RaceManager.isPaused)
		{
			animationComp.enabled = false;
		}
		else
		{
			animationComp.enabled = true;
		}
	}

	// RECUPERADO-AOT AnimationDriver::Play token 0x0600019b @0x000d5c84
	public void Play(string anim, bool looping)
	{
		if (!animationMap.ContainsKey(anim))
		{
			UnityEngine.Debug.LogWarning("Trying to play undefined animation " + anim);
			return;
		}
		if (animationComp.IsPlaying(animationMap[anim].name))
		{
			return;
		}
		if (looping)
		{
			animationMap[anim].wrapMode = WrapMode.Loop;
		}
		else
		{
			animationMap[anim].wrapMode = WrapMode.Once;
		}
		if (base.gameObject.activeInHierarchy)
		{
			StartCoroutine(CrossFadeToNewAnimation(anim, looping));
		}
	}

	// RECUPERADO-AOT AnimationDriver::CrossFadeToNewAnimation token 0x0600019c @0x000d5dc4
	// (iterator <CrossFadeToNewAnimation>c__Iterator1B MoveNext token 0x06000872 @0x00144fd0)
	// A one-shot clip in progress finishes first (a looping one is never interrupted, as in the original, which
	// also leaves inCoroutine set in that case); "driving" and the turn blends cross-fade immediately.
	[DebuggerHidden]
	private IEnumerator CrossFadeToNewAnimation(string anim, bool loop)
	{
		if (inCoroutine)
		{
			yield break;
		}
		inCoroutine = true;
		string stateName = animationMap[anim].name;
		if (!(anim == "driving") && !animationComp.clip.name.Contains("turnLeft") && !animationComp.clip.name.Contains("turnRight"))
		{
			if (animationComp.clip.wrapMode == WrapMode.Loop)
			{
				yield break;
			}
			yield return new WaitForSeconds(animationComp.clip.length);
		}
		animationComp.CrossFade(stateName);
		animationComp.clip.wrapMode = (loop ? WrapMode.Loop : WrapMode.Default);
		inCoroutine = false;
		yield return 0;
	}

	// RECUPERADO-AOT AnimationDriver::Blend token 0x0600019d @0x000d5e2c
	public void Blend(string anim, float weight)
	{
		if (!animationMap.ContainsKey(anim))
		{
			UnityEngine.Debug.LogWarning("Trying to play undefined animation " + anim);
			return;
		}
		string text = animationMap[anim].name;
		animationMap[anim].wrapMode = WrapMode.ClampForever;
		animationComp.Blend(text, weight);
	}

	// RECUPERADO-AOT AnimationDriver::Lean token 0x0600019e @0x000d5f0c
	// offset in [-1, 1]: negative leans left, positive right.
	public void Lean(float offset)
	{
		offset = Mathf.Clamp(offset, -1f, 1f);
		float weight = 0f;
		float weight2 = 0f;
		if (offset > 0f)
		{
			weight2 = offset;
		}
		else if (offset < 0f)
		{
			weight = 0f - offset;
		}
		Blend("turnLeft", weight);
		Blend("turnRight", weight2);
	}
}
