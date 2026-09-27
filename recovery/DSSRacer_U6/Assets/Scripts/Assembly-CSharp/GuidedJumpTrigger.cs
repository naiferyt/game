using UnityEngine;

// Ramp volume: a kart entering it is flown along jumpCurve to jumpTarget (GuidedJumpEffect).
// Source listing: recovery/aot_listings/Assembly-CSharp/GuidedJumpTrigger.txt
// (Adelantado de la Etapa 4 en 3.9: sin el salto guiado no se completan pistas como Kick Butt Track 1.)
public class GuidedJumpTrigger : MonoBehaviour
{
	public GameObject jumpTarget;

	public AnimationCurve jumpCurve;

	// RECUPERADO-AOT GuidedJumpTrigger::OnTriggerEnter token 0x060004e6 @0x0010b304
	private void OnTriggerEnter(Collider other)
	{
		if (!(other.gameObject.GetComponent<CarCollider>() == null))
		{
			EffectManager component = other.gameObject.GetComponent<EffectManager>();
			if (!(component == null))
			{
				component.AddEffect(new GuidedJumpEffect(other.gameObject, base.transform.position, jumpTarget.transform.position, jumpCurve));
			}
		}
	}

	// RECUPERADO-AOT GuidedJumpTrigger::OnDrawGizmos token 0x060004e7 @0x0010b470
	// Jump path in blue (20 segments over the distance / 40); the green colour set at the end is unused.
	private void OnDrawGizmos()
	{
		if (jumpTarget != null)
		{
			Gizmos.color = Color.blue;
			float num = (jumpTarget.transform.position - base.transform.position).magnitude / 40f;
			float num2 = num / 20f;
			Vector3 from = base.transform.position;
			for (float num3 = num2; num3 < num; num3 += num2)
			{
				Vector3 vector = Vector3.Lerp(base.transform.position, jumpTarget.transform.position, num3);
				vector.y += jumpCurve.Evaluate(num3);
				Gizmos.DrawLine(from, vector);
				from = vector;
			}
		}
		Gizmos.color = Color.green;
	}
}
