using System;
using UnityEngine;

// Per-track store of the recorded AI driving lines (CarAIPath), serialized in each track scene.
// Source listing: recovery/aot_listings/Assembly-CSharp/CarAIPathManager.txt
public class CarAIPathManager : MonoBehaviour
{
	[SerializeField]
	private CarAIPath[] pathList;

	private static CarAIPathManager s_instance;

	// RECUPERADO-AOT CarAIPathManager::OnEnable token 0x06000006 @0x000c09e0
	private void OnEnable()
	{
		s_instance = this;
		if (pathList == null)
		{
			pathList = new CarAIPath[0];
		}
	}

	// RECUPERADO-AOT CarAIPathManager::OnDisable token 0x06000007 @0x000c0a48
	private void OnDisable()
	{
		s_instance = null;
	}

	// RECUPERADO-AOT CarAIPathManager::GetPathCount token 0x06000008 @0x000c0a8c
	public static int GetPathCount()
	{
		if (s_instance == null)
		{
			return 0;
		}
		return s_instance.pathList.Length;
	}

	// RECUPERADO-AOT CarAIPathManager::AddPath token 0x06000009 @0x000c0af8
	public static void AddPath(CarAIPath path)
	{
		if (!(s_instance == null))
		{
			Array.Resize(ref s_instance.pathList, s_instance.pathList.Length + 1);
			s_instance.pathList[s_instance.pathList.Length - 1] = path;
		}
	}

	// RECUPERADO-AOT CarAIPathManager::GetRandomPath token 0x0600000a @0x000c0bd4
	// (int Random.Range excludes its max: the last recorded path is never picked, as in the original)
	public static CarAIPath GetRandomPath()
	{
		if (s_instance == null)
		{
			return null;
		}
		int num = UnityEngine.Random.Range(0, s_instance.pathList.Length - 1);
		return s_instance.pathList[num];
	}

	// RECUPERADO-AOT CarAIPathManager::GetPathIndex token 0x0600000b @0x000c0c98
	// RECUPERADO-AOT CarAIPathManager/<GetPathIndex>c__AnonStorey8E::<>m__0 token 0x06000b2e @0x00166478 (predicate)
	public static int GetPathIndex(CarAIPath path)
	{
		return Array.FindIndex(s_instance.pathList, (CarAIPath x) => x == path);
	}

	// RECUPERADO-AOT CarAIPathManager::GetPathByIndex token 0x0600000c @0x000c0d7c
	public static CarAIPath GetPathByIndex(int index)
	{
		if (index > -1 && index < s_instance.pathList.Length)
		{
			return s_instance.pathList[index];
		}
		return null;
	}

	// RECUPERADO-AOT CarAIPathManager::ProduceInstance token 0x0600000d @0x000c0e24
	public static void ProduceInstance()
	{
		if (s_instance == null)
		{
			GameObject gameObject = new GameObject("+CarAIPathManager");
			gameObject.AddComponent(typeof(CarAIPathManager));
		}
	}

	// RECUPERADO-AOT CarAIPathManager::OnDrawGizmos token 0x0600000e @0x000c0ecc
	private void OnDrawGizmos()
	{
		CarAIPath[] array = pathList;
		for (int i = 0; i < array.Length; i++)
		{
			CarAIPath carAIPath = array[i];
			Gizmos.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
			for (int j = 0; j < carAIPath.pathPoints.Length - 1; j++)
			{
				Gizmos.DrawLine(carAIPath.pathPoints[j].point, carAIPath.pathPoints[j + 1].point);
			}
			Gizmos.DrawLine(carAIPath.pathPoints[carAIPath.pathPoints.Length - 1].point, carAIPath.pathPoints[0].point);
		}
	}
}
