using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class Script : MonoBehaviour
{
	public delegate void AnimationDelegate(float alpha);

	public void AddAnimation(float duration, AnimationDelegate d)
	{
		RecoveryPending.Hit("Script.AddAnimation");
	}

	public void AddAnimation(float duration, AnimationDelegate d, float wait)
	{
		RecoveryPending.Hit("Script.AddAnimation");
	}

	[DebuggerHidden]
	private IEnumerator AnimationHelper(float duration, AnimationDelegate d, float wait)
	{
		RecoveryPending.Hit("Script.AnimationHelper");
		yield break;
	}

	public void AddDelayed(float wait, Action delayed)
	{
		RecoveryPending.Hit("Script.AddDelayed");
	}

	[DebuggerHidden]
	private IEnumerator DelayedHelper(float wait, Action delayed)
	{
		RecoveryPending.Hit("Script.DelayedHelper");
		yield break;
	}

	public static T GetComponentFrom<T>(GameObject g) where T : Component
	{
		RecoveryPending.Hit("Script.GetComponentFrom");
		return default(T);
	}

	public static T GetComponentFrom<T>(Component c) where T : Component
	{
		RecoveryPending.Hit("Script.GetComponentFrom");
		return default(T);
	}

	public static T[] GetComponentsFrom<T>(GameObject g) where T : Component
	{
		RecoveryPending.Hit("Script.GetComponentsFrom");
		return default(T[]);
	}

	public static T[] GetComponentsInChildrenFrom<T>(GameObject g) where T : Component
	{
		RecoveryPending.Hit("Script.GetComponentsInChildrenFrom");
		return default(T[]);
	}

	public static T[] GetComponentsInChildrenFrom<T>(Component c) where T : Component
	{
		RecoveryPending.Hit("Script.GetComponentsInChildrenFrom");
		return default(T[]);
	}

	public T AddComponent<T>() where T : Component
	{
		RecoveryPending.Hit("Script.AddComponent");
		return default(T);
	}

	public static T AddComponentTo<T>(GameObject g) where T : Component
	{
		RecoveryPending.Hit("Script.AddComponentTo");
		return default(T);
	}

	public static T AddComponentTo<T>(Component c) where T : Component
	{
		RecoveryPending.Hit("Script.AddComponentTo");
		return default(T);
	}

	public static T[] ConvertObjectArray<T>(UnityEngine.Object[] objects) where T : UnityEngine.Object
	{
		RecoveryPending.Hit("Script.ConvertObjectArray");
		return default(T[]);
	}

	public T GetComponentUpwards<T>() where T : Component
	{
		RecoveryPending.Hit("Script.GetComponentUpwards");
		return default(T);
	}

	public static T GetComponentUpwardsFrom<T>(GameObject g) where T : Component
	{
		RecoveryPending.Hit("Script.GetComponentUpwardsFrom");
		return default(T);
	}

	public static T GetComponentUpwardsFrom<T>(Component c) where T : Component
	{
		RecoveryPending.Hit("Script.GetComponentUpwardsFrom");
		return default(T);
	}

	public static T Instantiate<T>(T original, Vector3 position, Quaternion rotation) where T : UnityEngine.Object
	{
		RecoveryPending.Hit("Script.Instantiate");
		return default(T);
	}

	public static T Instantiate<T>(T original) where T : UnityEngine.Object
	{
		RecoveryPending.Hit("Script.Instantiate");
		return default(T);
	}

	public static GameObject InstantiateIfNotPresent(GameObject prefab)
	{
		RecoveryPending.Hit("Script.InstantiateIfNotPresent");
		return default(GameObject);
	}

	public static T InstantiateIfNotPresent<T>(T prefab) where T : Component
	{
		RecoveryPending.Hit("Script.InstantiateIfNotPresent");
		return default(T);
	}

	public static void SendMessageToObjectsOfType<T>(string messageName) where T : Component
	{
		RecoveryPending.Hit("Script.SendMessageToObjectsOfType");
	}

	public static void SendMessageToObjectsOfType<T>(string messageName, UnityEngine.Object data) where T : Component
	{
		RecoveryPending.Hit("Script.SendMessageToObjectsOfType");
	}

	public static void SendMessageToGameObjects(string messageName)
	{
		RecoveryPending.Hit("Script.SendMessageToGameObjects");
	}

	public static void SendMessageToGameObjects(string messageName, UnityEngine.Object data)
	{
		RecoveryPending.Hit("Script.SendMessageToGameObjects");
	}

	public AudioSource CreateLoop(AudioClip clip)
	{
		RecoveryPending.Hit("Script.CreateLoop");
		return default(AudioSource);
	}

	public AudioSource CreateLoop(AudioCrumb crumb)
	{
		RecoveryPending.Hit("Script.CreateLoop");
		return default(AudioSource);
	}

	public AudioSource CreateLoop(AudioClip clip, float volume)
	{
		RecoveryPending.Hit("Script.CreateLoop");
		return default(AudioSource);
	}

	public Transform FindNameRecursive(string name)
	{
		RecoveryPending.Hit("Script.FindNameRecursive");
		return default(Transform);
	}

	private Transform FindNameRecursive(Transform t, string name)
	{
		RecoveryPending.Hit("Script.FindNameRecursive");
		return default(Transform);
	}
}
