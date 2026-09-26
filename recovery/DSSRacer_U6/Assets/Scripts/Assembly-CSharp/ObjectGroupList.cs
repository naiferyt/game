using System.Collections.Generic;
using UnityEngine;

public class ObjectGroupList : MonoBehaviour
{
	public bool activationState;

	public List<GameObject> list;

	private bool currentState;

	public bool CurrentState
	{
		get
		{
			RecoveryPending.Hit("ObjectGroupList.get_CurrentState");
			return default(bool);
		}
		set
		{
			RecoveryPending.Hit("ObjectGroupList.set_CurrentState");
		}
	}

	private void Awake()
	{
		RecoveryPending.Hit("ObjectGroupList.Awake");
	}
}
