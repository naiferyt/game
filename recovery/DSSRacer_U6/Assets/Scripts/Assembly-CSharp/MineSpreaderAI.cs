using UnityEngine;

public class MineSpreaderAI : MonoBehaviour
{
	public GameObject minePrefab;

	public int numMines;

	private GameObject launchOwner;

	private float launchTimer;

	private Vector3 launchVector;

	public float velocityModifier;

	private float velocity;

	private void Start()
	{
		RecoveryPending.Hit("MineSpreaderAI.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("MineSpreaderAI.Update");
	}

	private void LaunchUpdate()
	{
		RecoveryPending.Hit("MineSpreaderAI.LaunchUpdate");
	}

	private void Explode()
	{
		RecoveryPending.Hit("MineSpreaderAI.Explode");
	}

	public void SetOwner(GameObject obj)
	{
		RecoveryPending.Hit("MineSpreaderAI.SetOwner");
	}

	private void SpreadMines()
	{
		RecoveryPending.Hit("MineSpreaderAI.SpreadMines");
	}
}
