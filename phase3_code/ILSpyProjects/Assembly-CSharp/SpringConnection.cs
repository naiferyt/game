using UnityEngine;

public class SpringConnection : MonoBehaviour
{
	public enum RestrictDirection
	{
		VERT,
		HORZ,
		NONE
	}

	public GameObject connection;

	public float maxDistance;

	public float energy;

	public float damping;

	public float constantDrag;

	public float deadZone;

	public RestrictDirection restrictMotion;

	public Vector3 constantForce;

	private Vector3 connectionOffset;

	private Vector3 springVelocity;

	private Vector3 lastConnectionPosition;

	private void Start()
	{
	}

	private void FixedUpdate()
	{
	}
}
