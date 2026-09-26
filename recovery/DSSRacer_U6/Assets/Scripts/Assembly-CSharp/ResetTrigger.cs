using UnityEngine;

// Out-of-track volume: puts the kart that falls in back on the track at the spawn point.
// Source listing: recovery/aot_listings/Assembly-CSharp/ResetTrigger.txt
public class ResetTrigger : MonoBehaviour
{
	public bool underGap;

	public Transform spawnPoint;

	// RECUPERADO-AOT ResetTrigger::OnTriggerEnter token 0x0600056b @0x00114cac
	private void OnTriggerEnter(Collider other)
	{
		CarCollider component = other.gameObject.GetComponent<CarCollider>();
		if (component != null)
		{
			if (spawnPoint != null)
			{
				component.DoResetCarOnTrack(underGap, spawnPoint.position);
				return;
			}
			Debug.LogError("You should have a spawnPoint set in this Trigger!");
			component.DoResetCarOnTrack(underGap, Vector3.zero);
		}
	}
}
