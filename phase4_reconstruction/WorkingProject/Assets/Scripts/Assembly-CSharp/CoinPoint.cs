using System.Collections.Generic;
using UnityEngine;

public class CoinPoint : MonoBehaviour
{
	public enum ShapeTypes
	{
		Circle = 0,
		Trail = 1
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
			return default(ShapeTypes);
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
		return default(int);
	}

	private void OnDrawGizmos()
	{
	}
}
