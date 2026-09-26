using UnityEngine;

public class ActiveObjectListSwtich : MonoBehaviour
{
	public bool fireAtStart;

	public ObjectGroupList[] putToActive;

	public ObjectGroupList[] putToPassive;

	private void Fire()
	{
		RecoveryPending.Hit("ActiveObjectListSwtich.Fire");
	}

	private void Start()
	{
		RecoveryPending.Hit("ActiveObjectListSwtich.Start");
	}

	private void OnTriggerEnter(Collider other)
	{
		RecoveryPending.Hit("ActiveObjectListSwtich.OnTriggerEnter");
	}
}
