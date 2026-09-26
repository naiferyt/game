using UnityEngine;

public class CarAIPathManager : MonoBehaviour
{
	[SerializeField]
	private CarAIPath[] pathList;

	private static CarAIPathManager s_instance;

	private void OnEnable()
	{
		RecoveryPending.Hit("CarAIPathManager.OnEnable");
	}

	private void OnDisable()
	{
		RecoveryPending.Hit("CarAIPathManager.OnDisable");
	}

	public static int GetPathCount()
	{
		RecoveryPending.Hit("CarAIPathManager.GetPathCount");
		return default(int);
	}

	public static void AddPath(CarAIPath path)
	{
		RecoveryPending.Hit("CarAIPathManager.AddPath");
	}

	public static CarAIPath GetRandomPath()
	{
		RecoveryPending.Hit("CarAIPathManager.GetRandomPath");
		return default(CarAIPath);
	}

	public static int GetPathIndex(CarAIPath path)
	{
		RecoveryPending.Hit("CarAIPathManager.GetPathIndex");
		return default(int);
	}

	public static CarAIPath GetPathByIndex(int index)
	{
		RecoveryPending.Hit("CarAIPathManager.GetPathByIndex");
		return default(CarAIPath);
	}

	public static void ProduceInstance()
	{
		RecoveryPending.Hit("CarAIPathManager.ProduceInstance");
	}

	private void OnDrawGizmos()
	{
		RecoveryPending.Hit("CarAIPathManager.OnDrawGizmos");
	}
}
