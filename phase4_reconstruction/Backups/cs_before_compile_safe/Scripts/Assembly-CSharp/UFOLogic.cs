using UnityEngine;

public class UFOLogic : MonoBehaviour
{
	private const float laserRange = 20f;

	private const float laserEffect = 1f;

	private const float maxVertWobble = 0.5f;

	private const float maxHorzWobble = 0.5f;

	private const float maxRotWobble = 10f;

	private const float wobbleRate = 1f;

	private const int carLayerMask = 512;

	public GameObject laserPrefab;

	public float laserAccuracy;

	public float laserROF;

	public Vector3 firstUFOOffset;

	public Vector3 secondUFOOffset;

	private GameObject parentObject;

	private bool secondUFO;

	private float flyAwayTimer;

	private float wobbleTimer;

	private float wobbleVertTarget;

	private float wobbleHorzTarget;

	private float wobbleRotTarget;

	private float lastWobbleRotTarget;

	private float nextShot;

	private void FireLaser(GameObject target)
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	public void SetParent(GameObject parent)
	{
	}

	public void SetSecondUFO(bool state)
	{
	}

	public void StartFlyaway()
	{
	}

	private void OnDrawGizmos()
	{
	}
}
