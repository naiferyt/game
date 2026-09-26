using UnityEngine;

public class ApplyEffectDebugUtility : MonoBehaviour
{
	public BaseEffect.EffectTypes targetEffectType;

	public int power;

	public float time;

	public int powerLevel;

	public bool applyNow;

	private void Update()
	{
		RecoveryPending.Hit("ApplyEffectDebugUtility.Update");
	}
}
