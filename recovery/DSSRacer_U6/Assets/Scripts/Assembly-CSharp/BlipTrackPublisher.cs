using System.Collections.Generic;
using UnityEngine;

// HUD position track: a vertical bar with one blip per kart, placed by how far along the current lap it is;
// rival blips show whether they are ahead of or behind the player.
// Source listing: recovery/aot_listings/Assembly-CSharp/BlipTrackPublisher.txt
public class BlipTrackPublisher : UghPublisher
{
	public GameObject playerBlipPrefab;

	public GameObject aiBlipPrefab;

	private Bounds trackBounds;

	private Dictionary<GameObject, GameObject> blipMap;

	private float totalTrackDistance;

	private GameObject playerCar;

	// RECUPERADO-AOT BlipTrackPublisher::InitBlips token 0x06000742 @0x001387f8
	public void InitBlips()
	{
		GameObject[] allCars = RaceManager.allCars;
		blipMap = new Dictionary<GameObject, GameObject>(allCars.Length);
		for (int i = 0; i < allCars.Length; i++)
		{
			GameObject gameObject;
			if (RaceManager.IsPlayerCar(allCars[i]))
			{
				gameObject = Script.Instantiate(playerBlipPrefab);
				gameObject.transform.parent = base.transforms["Track"].transform.parent;
				gameObject.transform.localPosition = new Vector3(0f, 0f, -0.5f);
				playerCar = allCars[i];
			}
			else
			{
				gameObject = Script.Instantiate(aiBlipPrefab);
				gameObject.transform.parent = base.transforms["Track"].transform.parent;
				gameObject.transform.localPosition = new Vector3(0f, 0f, -0.25f);
			}
			blipMap.Add(allCars[i], gameObject);
		}
	}

	// RECUPERADO-AOT BlipTrackPublisher::InitValues token 0x06000743 @0x00138b58
	// ADAPTADO-U6: Component.renderer -> GetComponent<Renderer>().
	public void InitValues()
	{
		trackBounds = base.transforms["Track"].GetComponent<Renderer>().bounds;
		WaypointLogic lastWaypoint = RaceManager.lastWaypoint;
		if (lastWaypoint != null)
		{
			totalTrackDistance = lastWaypoint.totalTrackDistance + lastWaypoint.distanceToNext;
		}
	}

	// RECUPERADO-AOT BlipTrackPublisher::UpdateBlips token 0x06000744 @0x00138c08
	// ADAPTADO-U6: Transform.FindChild -> Find.
	public void UpdateBlips()
	{
		if (!(totalTrackDistance > 0f))
		{
			return;
		}
		float carLastTrackDistance = RaceManager.GetCarLastTrackDistance(playerCar);
		foreach (KeyValuePair<GameObject, GameObject> item in blipMap)
		{
			if (!RaceManager.Instance.GetCarIsActive(item.Key))
			{
				if (item.Value.activeInHierarchy)
				{
					item.Value.SetActive(false);
				}
				continue;
			}
			float carLastTrackDistance2 = RaceManager.GetCarLastTrackDistance(item.Key);
			float num = carLastTrackDistance2 / totalTrackDistance;
			num -= (float)RaceManager.GetCarLap(item.Key);
			Vector3 localPosition = item.Value.transform.localPosition;
			localPosition.y = Mathf.Lerp(trackBounds.min.y, trackBounds.max.y, num) + 0.5f;
			if (item.Key != playerCar)
			{
				Transform transform = item.Value.transform.Find("AI Behind Blip");
				Transform transform2 = item.Value.transform.Find("AI Ahead Blip");
				bool flag = !(carLastTrackDistance2 < carLastTrackDistance);
				transform.gameObject.SetActive(!flag);
				transform2.gameObject.SetActive(flag);
			}
			item.Value.transform.localPosition = localPosition;
		}
	}
}
