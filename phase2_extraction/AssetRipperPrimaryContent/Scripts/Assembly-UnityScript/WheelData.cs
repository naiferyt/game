using System;
using UnityEngine;

[Serializable]
public class WheelData
{
	public Transform transform;

	public GameObject go;

	public WheelCollider col;

	public Vector3 startPos;

	public float rotation;

	public float maxSteer;

	public bool motor;

	public float radius;
}
