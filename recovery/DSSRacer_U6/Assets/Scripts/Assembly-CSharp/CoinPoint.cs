using System.Collections.Generic;
using UnityEngine;

// Track token spawner: lays coins out in concentric rings (Circle, remaining ones scattered inside) or along a
// polyline of points (Trail), dropped onto the ground (layer 8) unless spawnInAir.
// Source listing: recovery/aot_listings/Assembly-CSharp/CoinPoint.txt
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

	// RECUPERADO-AOT CoinPoint::.ctor token 0x060004cf @0x0010859c (field initializers)
	public float weight = 1f;

	public GameObject coinPrefab;

	private float layerSize;

	private int maxLayers;

	public float radius = 1f;

	public List<Transform> points;

	public ShapeTypes ShapeType
	{
		// RECUPERADO-AOT CoinPoint::get_ShapeType token 0x060004d0 @0x00108600
		get
		{
			return shapeType;
		}
		// RECUPERADO-AOT CoinPoint::set_ShapeType token 0x060004d1 @0x00108634
		set
		{
			shapeType = value;
		}
	}

	// RECUPERADO-AOT CoinPoint::SpawnCoins token 0x060004d2 @0x00108670
	public void SpawnCoins(int num)
	{
		if (shapeType == ShapeTypes.Circle)
		{
			SpawnCircleHelper(num);
		}
		else if (shapeType == ShapeTypes.Trail)
		{
			SpawnTrailHelper(num);
		}
	}

	// RECUPERADO-AOT CoinPoint::SpawnCircleHelper token 0x060004d3 @0x001086d4
	// ADAPTADO-U6: Component.collider -> GetComponent<Collider>().
	// Note (original): the centre coin's ground ray starts at the spawner itself (the +5 lift is overwritten).
	private void SpawnCircleHelper(int num)
	{
		RaycastHit hitInfo;
		SphereCollider sphereCollider = (SphereCollider)coinPrefab.transform.GetComponent<Collider>();
		float num2 = sphereCollider.radius * 7f;
		maxLayers = (int)(radius / num2);
		layerSize = radius / (float)maxLayers;
		int num3 = ProperCoinNum(num, num2);
		int num4 = 0;
		Vector3 position = base.transform.position;
		if (!spawnInAir)
		{
			position.y = base.transform.position.y + 5f;
			if (Physics.Raycast(base.transform.position, Vector3.down, out hitInfo, float.PositiveInfinity, 256))
			{
				position.y = hitInfo.point.y + sphereCollider.radius * sphereCollider.transform.localScale.y;
			}
			else
			{
				position.y = base.transform.position.y + 1f;
			}
		}
		Object.Instantiate(coinPrefab, position, new Quaternion(0f, Random.rotation.y, 0f, 1f));
		num4++;
		for (int i = 1; i <= maxLayers; i++)
		{
			float num5 = layerSize * (float)i;
			int num6 = (int)(num5 * Mathf.PI * 2f / num2);
			int num7 = 360 / num6;
			for (int j = 0; j < num6; j++)
			{
				float x = Mathf.Cos((float)(num7 * j) * Mathf.Deg2Rad) * num5;
				float z = Mathf.Sin((float)(num7 * j) * Mathf.Deg2Rad) * num5;
				Vector3 vector = base.transform.position + base.transform.rotation * new Vector3(x, 0f, z);
				if (!spawnInAir)
				{
					if (Physics.Raycast(new Vector3(vector.x, base.transform.position.y + 5f, vector.z), Vector3.down, out hitInfo, float.PositiveInfinity, 256))
					{
						vector.y = hitInfo.point.y + sphereCollider.radius * sphereCollider.transform.localScale.y;
					}
					else
					{
						vector.y = base.transform.position.y + 1f;
					}
				}
				Object.Instantiate(coinPrefab, vector, new Quaternion(0f, Random.rotation.y, 0f, 1f));
				num4++;
			}
			if (num4 >= num3)
			{
				break;
			}
		}
		if (num4 >= num)
		{
			return;
		}
		int num8 = num - num4;
		for (int k = 0; k < num8; k++)
		{
			Vector2 vector2 = Random.insideUnitCircle.normalized * Random.Range(0f, radius);
			Vector3 vector3 = base.transform.position + base.transform.rotation * new Vector3(vector2.x, 0f, vector2.y);
			if (!spawnInAir)
			{
				if (Physics.Raycast(new Vector3(vector3.x, base.transform.position.y + 5f, vector3.z), Vector3.down, out hitInfo, float.PositiveInfinity, 256))
				{
					vector3.y = hitInfo.point.y + sphereCollider.radius * sphereCollider.transform.localScale.y;
				}
				else
				{
					vector3.y = base.transform.position.y + 1f;
				}
			}
			Object.Instantiate(coinPrefab, vector3, new Quaternion(0f, Random.rotation.y, 0f, 1f));
		}
	}

	// RECUPERADO-AOT CoinPoint::SpawnTrailHelper token 0x060004d4 @0x00109728
	// ADAPTADO-U6: Component.collider -> GetComponent<Collider>().
	// Note (original): the ground height is taken at each segment's start point only.
	private void SpawnTrailHelper(int num)
	{
		SphereCollider sphereCollider = (SphereCollider)coinPrefab.transform.GetComponent<Collider>();
		if (points.Count < 2)
		{
			UnityEngine.Debug.LogWarning("You must have at least 2 point transforms in order to use this coin point as a trail");
			shapeType = ShapeTypes.Circle;
			SpawnCoins(num);
			return;
		}
		int count = points.Count;
		int num2 = num / (count - 1);
		for (int i = 0; i < count; i++)
		{
			if (i >= count - 1)
			{
				break;
			}
			Vector3 vector = points[i + 1].transform.position - points[i].position;
			float num3 = vector.magnitude / (float)num2;
			vector = vector.normalized;
			for (int j = 0; j < num2; j++)
			{
				Vector3 position = points[i].position;
				if (!spawnInAir)
				{
					position.y = points[i].position.y + 5f;
					RaycastHit hitInfo;
					if (Physics.Raycast(position, Vector3.down, out hitInfo, float.PositiveInfinity, 256))
					{
						position.y = hitInfo.point.y + sphereCollider.radius * sphereCollider.transform.localScale.y;
					}
					else
					{
						position.y = points[i].position.y + 1f;
					}
				}
				Object.Instantiate(coinPrefab, position + vector * (num3 * (float)j), new Quaternion(0f, Random.rotation.y, 0f, 1f));
			}
		}
	}

	// RECUPERADO-AOT CoinPoint::ProperCoinNum token 0x060004d5 @0x00109d68
	private int ProperCoinNum(int num, float objDiam)
	{
		int num2 = 1;
		for (int i = 1; i <= maxLayers; i++)
		{
			num2 += (int)(layerSize * (float)i * Mathf.PI * 2f / objDiam);
			if (num2 >= num)
			{
				return num2;
			}
		}
		return num2;
	}

	// RECUPERADO-AOT CoinPoint::OnDrawGizmos token 0x060004d6 @0x00109e3c
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(base.transform.position, 0.5f);
		if (shapeType == ShapeTypes.Circle)
		{
			Gizmos.color = Color.cyan;
			float num = 22.5f;
			Vector3 vector = base.transform.forward * radius;
			for (float num2 = 0f; num2 <= 360f; num2 += num)
			{
				Vector3 vector2 = Quaternion.AngleAxis(num, base.transform.up) * vector;
				Gizmos.DrawLine(base.transform.position + vector, base.transform.position + vector2);
				vector = vector2;
			}
		}
		else
		{
			if (shapeType != ShapeTypes.Trail)
			{
				return;
			}
			foreach (Transform point in points)
			{
				Gizmos.DrawLine(base.gameObject.transform.position, point.position);
			}
			Gizmos.color = Color.cyan;
			if (points.Count > 0)
			{
				Gizmos.DrawWireSphere(points[0].position, 0.25f);
				for (int i = 1; i < points.Count; i++)
				{
					Vector3 position = points[i - 1].position;
					Gizmos.DrawWireSphere(points[i].position, 0.25f);
					Gizmos.DrawLine(points[i].position, position);
				}
			}
		}
	}
}
