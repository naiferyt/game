using System.Collections.Generic;
using UnityEngine;

public class BlipTrackPublisher : UghPublisher
{
	public GameObject playerBlipPrefab;

	public GameObject aiBlipPrefab;

	private Bounds trackBounds;

	private Dictionary<GameObject, GameObject> blipMap;

	private float totalTrackDistance;

	private GameObject playerCar;

	public void InitBlips()
	{
	}

	public void InitValues()
	{
	}

	public void UpdateBlips()
	{
	}
}
