using UnityEngine;

// UFO drone (random-shot power-up): hovers with a wobble next to its owner kart, zaps a random kart in range every
// laserROF seconds (hits with probability laserAccuracy, wipeout unless shielded), then flies off when told to.
// Source listing: recovery/aot_listings/Assembly-CSharp/UFOLogic.txt
public class UFOLogic : MonoBehaviour
{
	private const float laserRange = 20f;

	private const float laserEffect = 1f;

	private const float maxVertWobble = 0.5f;

	private const float maxHorzWobble = 0.5f;

	private const float maxRotWobble = 10f;

	private const float wobbleRate = 1f;

	private const int carLayerMask = 512;

	public GameObject laserPrefab;

	// RECUPERADO-AOT UFOLogic::.ctor token 0x0600008a @0x000cce78 (field initializers)
	public float laserAccuracy = 0.55f;

	public float laserROF = 1f;

	public Vector3 firstUFOOffset = new Vector3(2f, 2f, 2.5f);

	public Vector3 secondUFOOffset = new Vector3(-2f, 2f, 2.5f);

	private GameObject parentObject;

	private bool secondUFO;

	private float flyAwayTimer;

	private float wobbleTimer;

	private float wobbleVertTarget;

	private float wobbleHorzTarget;

	private float wobbleRotTarget;

	private float lastWobbleRotTarget;

	private float nextShot;

	// RECUPERADO-AOT UFOLogic::FireLaser token 0x0600008b @0x000cd02c
	// ADAPTADO-U6: Transform.FindChild -> Find.
	private void FireLaser(GameObject target)
	{
		EffectManager component = target.GetComponent<EffectManager>();
		if (component != null)
		{
			bool flag = !(laserAccuracy < Random.value);
			bool flag2 = false;
			CarCollider component2 = target.GetComponent<CarCollider>();
			if (component2 != null)
			{
				flag2 = component2.IsShielded();
			}
			GameObject gameObject = Object.Instantiate(laserPrefab, base.transform.position, base.transform.rotation) as GameObject;
			gameObject.SendMessage("SetParent", base.gameObject);
			gameObject.SendMessage("SetTarget", target);
			if (!flag)
			{
				gameObject.SendMessage("ApplyError");
			}
			if (flag && !flag2)
			{
				WipeoutEffect wipeoutEffect = new WipeoutEffect(target);
				wipeoutEffect.power = 1;
				wipeoutEffect.time = 1f;
				component.AddEffect(wipeoutEffect);
				SoundLibrary.PlaySoundOnPlayer("lazerHit", true);
				if (target.transform.Find("Laser Hit Particle") == null)
				{
					GameObject gameObject2 = Object.Instantiate(ParticleLibrary.Instance.GetPrefab("Laser Hit"), target.transform.position, target.transform.rotation) as GameObject;
					gameObject2.transform.parent = target.transform;
					gameObject2.name = "Laser Hit Particle";
				}
			}
			else if (flag && flag2)
			{
				SoundLibrary.PlaySoundOnPlayer("lazerHitShield", true);
			}
			else
			{
				SoundLibrary.PlaySoundOnPlayer((Random.Range(0, 2) != 0) ? "lazerMissTwo" : "lazerMissOne", true);
			}
		}
		nextShot = laserROF;
	}

	// RECUPERADO-AOT UFOLogic::Update token 0x0600008c @0x000cd4f0
	private void Update()
	{
		if (flyAwayTimer > 0f || RaceManager.isPaused)
		{
			return;
		}
		if (nextShot > 0f)
		{
			nextShot -= Time.deltaTime;
			return;
		}
		Collider[] array = Physics.OverlapSphere(base.transform.position, 20f, 512);
		if (array.Length > 1)
		{
			int num = Random.Range(0, array.Length);
			GameObject gameObject = array[num].gameObject;
			if (gameObject == parentObject)
			{
				num++;
				if (num >= array.Length)
				{
					num = 0;
				}
				gameObject = array[num].gameObject;
			}
			FireLaser(gameObject);
		}
	}

	// RECUPERADO-AOT UFOLogic::FixedUpdate token 0x0600008d @0x000cd6ac
	// Note (original): the wobble targets use -Mathf.Sign(<max>) * Random.value * <max>, so they are never positive.
	private void FixedUpdate()
	{
		if (parentObject == null || RaceManager.isPaused)
		{
			return;
		}
		if (flyAwayTimer > 0f)
		{
			flyAwayTimer -= Time.deltaTime;
			if (!(flyAwayTimer > 0f))
			{
				Object.Destroy(base.gameObject);
				return;
			}
			base.transform.position = base.transform.position + base.transform.forward * 5f;
			base.transform.position = base.transform.position + new Vector3(0f, 1f, 0f);
			return;
		}
		Vector3 zero = Vector3.zero;
		zero = ((!secondUFO) ? firstUFOOffset : secondUFOOffset);
		zero = parentObject.transform.rotation * zero;
		zero = zero + parentObject.transform.position;
		zero = zero + new Vector3(wobbleHorzTarget, wobbleVertTarget, 0f);
		float magnitude = (zero - base.transform.position).magnitude;
		base.transform.position = Vector3.Lerp(base.transform.position, zero, Time.deltaTime * magnitude);
		base.transform.forward = Vector3.Lerp(base.transform.forward, parentObject.transform.forward, Time.deltaTime * 5f);
		Quaternion a = Quaternion.Euler(0f, base.transform.rotation.eulerAngles.y, lastWobbleRotTarget);
		Quaternion b = Quaternion.Euler(0f, base.transform.rotation.eulerAngles.y, wobbleRotTarget);
		base.transform.rotation = Quaternion.Lerp(a, b, 1f - wobbleTimer / 1f);
		wobbleTimer -= Time.deltaTime;
		if (!(wobbleTimer > 0f))
		{
			lastWobbleRotTarget = wobbleRotTarget;
			wobbleVertTarget = (0f - Mathf.Sign(0.5f)) * Random.value * 0.5f;
			wobbleHorzTarget = (0f - Mathf.Sign(0.5f)) * Random.value * 0.5f;
			wobbleRotTarget = (0f - Mathf.Sign(10f)) * Random.value * 10f;
			wobbleTimer = 1f;
		}
	}

	// RECUPERADO-AOT UFOLogic::SetParent token 0x0600008e @0x000ce0d8
	public void SetParent(GameObject parent)
	{
		parentObject = parent;
	}

	// RECUPERADO-AOT UFOLogic::SetSecondUFO token 0x0600008f @0x000ce114
	public void SetSecondUFO(bool state)
	{
		secondUFO = state;
	}

	// RECUPERADO-AOT UFOLogic::StartFlyaway token 0x06000090 @0x000ce150
	public void StartFlyaway()
	{
		flyAwayTimer = 1f;
	}

	// RECUPERADO-AOT UFOLogic::OnDrawGizmos token 0x06000091 @0x000ce198
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(base.transform.position, 20f);
	}
}
