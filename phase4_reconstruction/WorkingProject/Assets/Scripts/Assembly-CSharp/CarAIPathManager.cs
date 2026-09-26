using UnityEngine;

public class CarAIPathManager : MonoBehaviour
{
	[SerializeField]
	private CarAIPath[] pathList;

	private static CarAIPathManager s_instance;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public static int GetPathCount()
	{
		return default(int);
	}

	public static void AddPath(CarAIPath path)
	{
	}

	public static CarAIPath GetRandomPath()
	{
		return default(CarAIPath);
	}

	public static int GetPathIndex(CarAIPath path)
	{
		return default(int);
	}

	public static CarAIPath GetPathByIndex(int index)
	{
		return default(CarAIPath);
	}

	public static void ProduceInstance()
	{
	}

	private void OnDrawGizmos()
	{
	}
}
