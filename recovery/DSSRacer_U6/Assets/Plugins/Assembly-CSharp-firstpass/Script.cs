using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class Script : MonoBehaviour
{
	public delegate void AnimationDelegate(float alpha);

	public void AddAnimation(float duration, AnimationDelegate d)
	{
	}

	public void AddAnimation(float duration, AnimationDelegate d, float wait)
	{
	}

	[DebuggerHidden]
	private IEnumerator AnimationHelper(float duration, AnimationDelegate d, float wait)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public void AddDelayed(float wait, Action delayed)
	{
	}

	[DebuggerHidden]
	private IEnumerator DelayedHelper(float wait, Action delayed)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static T GetComponentFrom<T>(GameObject g) where T : Component
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static T GetComponentFrom<T>(Component c) where T : Component
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static T[] GetComponentsFrom<T>(GameObject g) where T : Component
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static T[] GetComponentsInChildrenFrom<T>(GameObject g) where T : Component
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static T[] GetComponentsInChildrenFrom<T>(Component c) where T : Component
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public T AddComponent<T>() where T : Component
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static T AddComponentTo<T>(GameObject g) where T : Component
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static T AddComponentTo<T>(Component c) where T : Component
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static T[] ConvertObjectArray<T>(UnityEngine.Object[] objects) where T : UnityEngine.Object
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public T GetComponentUpwards<T>() where T : Component
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static T GetComponentUpwardsFrom<T>(GameObject g) where T : Component
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static T GetComponentUpwardsFrom<T>(Component c) where T : Component
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static T Instantiate<T>(T original, Vector3 position, Quaternion rotation) where T : UnityEngine.Object
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static T Instantiate<T>(T original) where T : UnityEngine.Object
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static GameObject InstantiateIfNotPresent(GameObject prefab)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static T InstantiateIfNotPresent<T>(T prefab) where T : Component
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static void SendMessageToObjectsOfType<T>(string messageName) where T : Component
	{
	}

	public static void SendMessageToObjectsOfType<T>(string messageName, UnityEngine.Object data) where T : Component
	{
	}

	public static void SendMessageToGameObjects(string messageName)
	{
	}

	public static void SendMessageToGameObjects(string messageName, UnityEngine.Object data)
	{
	}

	public AudioSource CreateLoop(AudioClip clip)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public AudioSource CreateLoop(AudioCrumb crumb)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public AudioSource CreateLoop(AudioClip clip, float volume)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public Transform FindNameRecursive(string name)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private Transform FindNameRecursive(Transform t, string name)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
