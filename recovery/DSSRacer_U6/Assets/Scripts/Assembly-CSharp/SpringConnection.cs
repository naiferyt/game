using UnityEngine;

// Spring-follows a connected object (the kart body) toward its rest offset from this transform, with drag,
// a constant force, optional restriction to the local vertical / horizontal axis and a maximum distance.
// Source listing: recovery/aot_listings/Assembly-CSharp/SpringConnection.txt
public class SpringConnection : MonoBehaviour
{
	public enum RestrictDirection
	{
		VERT = 0,
		HORZ = 1,
		NONE = 2
	}

	public GameObject connection;

	// RECUPERADO-AOT SpringConnection::.ctor token 0x06000480 @0x00103b40 (field initializers)
	public float maxDistance = 0.1f;

	public float energy = 100f;

	public float damping = 10f;

	public float constantDrag = 0.93f;

	public float deadZone = 0.1f;

	public RestrictDirection restrictMotion;

	public Vector3 constantForce = Vector3.up;

	private Vector3 connectionOffset = Vector3.zero;

	private Vector3 springVelocity = Vector3.zero;

	private Vector3 lastConnectionPosition = Vector3.zero;

	// RECUPERADO-AOT SpringConnection::Start token 0x06000481 @0x00103c7c
	private void Start()
	{
		if (!(connection == null))
		{
			connectionOffset = connection.transform.position - base.transform.position;
			lastConnectionPosition = connection.transform.position;
		}
	}

	// RECUPERADO-AOT SpringConnection::FixedUpdate token 0x06000482 @0x00103d84
	// (damping and deadZone are not used by the original.)
	private void FixedUpdate()
	{
		if (!(connection == null))
		{
			connection.transform.position = lastConnectionPosition;
			Vector3 vector = base.transform.position + connectionOffset;
			Vector3 vector2 = vector - connection.transform.position;
			float magnitude = vector2.magnitude;
			springVelocity += vector2.normalized * (magnitude * energy) * Time.deltaTime;
			springVelocity *= constantDrag;
			springVelocity += constantForce * Time.deltaTime;
			connection.transform.position = connection.transform.position + springVelocity * Time.deltaTime;
			Vector3 lhs = connection.transform.position - vector;
			if (restrictMotion == RestrictDirection.VERT)
			{
				connection.transform.position = base.transform.up * Vector3.Dot(lhs, base.transform.up) + vector;
			}
			else if (restrictMotion == RestrictDirection.HORZ)
			{
				connection.transform.position = base.transform.right * Vector3.Dot(lhs, base.transform.right) + vector;
			}
			Vector3 vector3 = vector - connection.transform.position;
			if (vector3.sqrMagnitude > maxDistance * maxDistance)
			{
				connection.transform.position = vector + -vector3.normalized * maxDistance;
			}
			lastConnectionPosition = connection.transform.position;
		}
	}
}
