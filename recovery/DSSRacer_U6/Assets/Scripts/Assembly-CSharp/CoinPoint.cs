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
			RecoveryPending.Hit("CoinPoint.get_ShapeType");
			return default(ShapeTypes);
		}
		set
		{
			RecoveryPending.Hit("CoinPoint.set_ShapeType");
		}
	}

	public void SpawnCoins(int num)
	{
		RecoveryPending.Hit("CoinPoint.SpawnCoins");
	}

	private void SpawnCircleHelper(int num)
	{
		RecoveryPending.Hit("CoinPoint.SpawnCircleHelper");
	}

	private void SpawnTrailHelper(int num)
	{
		RecoveryPending.Hit("CoinPoint.SpawnTrailHelper");
	}

	private int ProperCoinNum(int num, float objDiam)
	{
		RecoveryPending.Hit("CoinPoint.ProperCoinNum");
		return default(int);
	}

	private void OnDrawGizmos()
	{
		RecoveryPending.Hit("CoinPoint.OnDrawGizmos");
	}
}
