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
			return default(bool);
		}
		set
		{
		}
	}

	private void Awake()
	{
	}
}
