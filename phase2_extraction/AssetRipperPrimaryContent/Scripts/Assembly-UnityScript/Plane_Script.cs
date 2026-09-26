using System;
using UnityEngine;

[Serializable]
public class Plane_Script : MonoBehaviour
{
	public Transform propeller;

	public float speed;

	public float turnSpeed;

	public float climbSpeed;

	public float climbLimit;

	public float diveSpeed;

	public float diveLimit;

	public float topLimit;

	public float bottomLimit;

	private Quaternion defaultTilt;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}

	public virtual void Main()
	{
	}
}
