using System.Collections.Generic;
using UnityEngine;

public class CoinPoint : MonoBehaviour
{
	public enum ShapeTypes
	{
		Circle,
		Trail
	}

	private const int groundLayerMask = 256;

	public ShapeTypes shapeType;

	public bool spawnInAir;

	public float weight;

	public GameObject coinPrefab;

	private float layerSize;

	private int maxLayers;

	public float radius;

	public List<Transform> points;

	public ShapeTypes ShapeType
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	public void SpawnCoins(int num)
	{
	}

	private void SpawnCircleHelper(int num)
	{
	}

	private void SpawnTrailHelper(int num)
	{
	}

	private int ProperCoinNum(int num, float objDiam)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void OnDrawGizmos()
	{
	}
}
