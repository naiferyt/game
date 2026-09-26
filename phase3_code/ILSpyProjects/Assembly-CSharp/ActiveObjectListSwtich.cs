using UnityEngine;

public class ActiveObjectListSwtich : MonoBehaviour
{
	public bool fireAtStart;

	public ObjectGroupList[] putToActive;

	public ObjectGroupList[] putToPassive;

	private void Fire()
	{
	}

	private void Start()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}
}
