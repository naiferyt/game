using UnityEngine;

// Mine spreader shell: flies out for launchTimer seconds, then bursts into numMines spread MineAI.
// Source listing: recovery/aot_listings/Assembly-CSharp/MineSpreaderAI.txt
public class MineSpreaderAI : MonoBehaviour
{
	public GameObject minePrefab;

	// RECUPERADO-AOT MineSpreaderAI::.ctor token 0x06000072 @0x000caa34 (field initializers)
	public int numMines = 4;

	private GameObject launchOwner;

	private float launchTimer = 0.5f;

	private Vector3 launchVector = Vector3.zero;

	public float velocityModifier = 1f;

	private float velocity = 1f;

	// RECUPERADO-AOT MineSpreaderAI::Start token 0x06000073 @0x000caadc
	// Note (original): the random circle is overwritten with (0, 1), so the side sign is a no-op and the
	// shell always flies straight ahead with a 0.175 upward tilt.
	private void Start()
	{
		System.Random random = new System.Random();
		Vector2 insideUnitCircle = Random.insideUnitCircle;
		insideUnitCircle.x = 0f;
		insideUnitCircle.y = 1f;
		insideUnitCircle.x *= (random.Next() % 2 != 0) ? 1 : (-1);
		launchVector = launchOwner.transform.rotation * new Vector3(insideUnitCircle.x, 0.175f, insideUnitCircle.y).normalized;
		base.transform.forward = launchVector;
		if (launchOwner != null)
		{
			CarCollider component = launchOwner.GetComponent<CarCollider>();
			if (component != null)
			{
				velocity = component.GetVelocity().magnitude;
			}
			if (velocity < velocityModifier * 10f)
			{
				velocity = velocityModifier * 10f;
			}
		}
		SoundSequencer component2 = GetComponent<SoundSequencer>();
		if ((bool)component2)
		{
			component2.RequestPlay("rocketLaunch");
			component2.RequestPlayLoop("rocketFlight");
		}
	}

	// RECUPERADO-AOT MineSpreaderAI::Update token 0x06000074 @0x000cae78
	private void Update()
	{
		LaunchUpdate();
		launchTimer -= Time.deltaTime;
		if (launchTimer <= 0f)
		{
			SpreadMines();
			Explode();
		}
	}

	// RECUPERADO-AOT MineSpreaderAI::LaunchUpdate token 0x06000075 @0x000caf0c
	private void LaunchUpdate()
	{
		base.transform.position = base.transform.position + launchVector * (velocity * velocityModifier) * Time.deltaTime;
	}

	// RECUPERADO-AOT MineSpreaderAI::Explode token 0x06000076 @0x000cb014
	private void Explode()
	{
		GameObject gameObject = Object.Instantiate(ParticleLibrary.Instance.GetPrefab("Explosion"), base.transform.position, base.transform.rotation) as GameObject;
		gameObject.transform.parent = null;
		gameObject.name = "Explosion Particle Effect";
		Object.Destroy(base.gameObject);
	}

	// RECUPERADO-AOT MineSpreaderAI::SetOwner token 0x06000077 @0x000cb158
	public void SetOwner(GameObject obj)
	{
		launchOwner = obj;
	}

	// RECUPERADO-AOT MineSpreaderAI::SpreadMines token 0x06000078 @0x000cb194
	// The owner store is MineAI.SetOwner inlined (private field owner).
	private void SpreadMines()
	{
		for (int i = 0; i < numMines; i++)
		{
			Vector2 insideUnitCircle = Random.insideUnitCircle;
			Vector3 vector = new Vector3(insideUnitCircle.x, 0f, insideUnitCircle.y);
			GameObject gameObject = Object.Instantiate(minePrefab, vector, Quaternion.identity) as GameObject;
			MineAI component = gameObject.GetComponent<MineAI>();
			if (component != null)
			{
				component.SetOwner(launchOwner);
				component.isSpread = true;
				component.transform.position = component.transform.position + base.transform.position;
				component.spreadVector = vector;
			}
		}
	}
}
