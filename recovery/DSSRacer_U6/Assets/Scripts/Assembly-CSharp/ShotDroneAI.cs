using UnityEngine;

// UFO drone (RandomShotEffect): every second shoots a LaserLogic beam at a random kart in range other
// than its owner; 35 % of the shots hit (wipeout unless shielded).
// Source listing: recovery/aot_listings/Assembly-CSharp/ShotDroneAI.txt
public class ShotDroneAI : MonoBehaviour
{
	private const int carLayerMask = 512;

	private const float BATTERY_SHOT_DELAY = 1f;

	private const float shotAccuracy = 0.35f;

	private float timer;

	// RECUPERADO-AOT ShotDroneAI::.ctor token 0x06000084 @0x000cc8cc (field initializer)
	public float shotRange = 20f;

	public GameObject projectilePrefab;

	private GameObject parentObject;

	// RECUPERADO-AOT ShotDroneAI::Start token 0x06000085 @0x000cc918
	private void Start()
	{
		timer = 1f;
	}

	// RECUPERADO-AOT ShotDroneAI::SetParent token 0x06000086 @0x000cc960
	public void SetParent(GameObject parent)
	{
		parentObject = parent;
	}

	// RECUPERADO-AOT ShotDroneAI::Update token 0x06000087 @0x000cc99c
	private void Update()
	{
		if (timer > 0f)
		{
			timer -= Time.deltaTime;
			return;
		}
		Collider[] array = Physics.OverlapSphere(base.transform.position, shotRange, 512);
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
			Shoot(gameObject);
		}
	}

	// RECUPERADO-AOT ShotDroneAI::FixedUpdate token 0x06000088 @0x000ccb20
	private void FixedUpdate()
	{
	}

	// RECUPERADO-AOT ShotDroneAI::Shoot token 0x06000089 @0x000ccb4c
	private void Shoot(GameObject target)
	{
		EffectManager component = target.GetComponent<EffectManager>();
		if (!(component != null))
		{
			return;
		}
		bool flag = !(Random.value > 0.35f);
		bool flag2 = false;
		CarCollider component2 = target.GetComponent<CarCollider>();
		if (component2 != null)
		{
			flag2 = component2.IsShielded();
		}
		GameObject gameObject = Object.Instantiate(projectilePrefab, base.transform.position, base.transform.rotation) as GameObject;
		gameObject.SendMessage("SetParent", base.gameObject);
		gameObject.SendMessage("SetTarget", target);
		if (!flag)
		{
			gameObject.SendMessage("ApplyError");
		}
		if (flag && !flag2)
		{
			SoundLibrary.PlaySoundOnPlayer("lazerHit", true);
			WipeoutEffect wipeoutEffect = new WipeoutEffect(target);
			wipeoutEffect.power = 1;
			component.AddEffect(wipeoutEffect);
		}
		else if (flag && flag2)
		{
			SoundLibrary.PlaySoundOnPlayer("lazerHitShield", true);
		}
		else
		{
			SoundLibrary.PlaySoundOnPlayer((Random.Range(0, 2) != 0) ? "lazerMissTwo" : "lazerMissOne", true);
		}
		timer = 1f;
	}
}
