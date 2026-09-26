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
		RecoveryPending.Hit("BlipTrackPublisher.InitBlips");
	}

	public void InitValues()
	{
		RecoveryPending.Hit("BlipTrackPublisher.InitValues");
	}

	public void UpdateBlips()
	{
		RecoveryPending.Hit("BlipTrackPublisher.UpdateBlips");
	}
}
