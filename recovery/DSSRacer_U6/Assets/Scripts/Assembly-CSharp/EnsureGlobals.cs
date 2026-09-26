using UnityEngine;

// Instantiates the persistent global objects (DataUtility, StreamManager, Localize, PlayerInstance...) once per run.
// Source listing: recovery/aot_listings/Assembly-CSharp/EnsureGlobals.txt
public class EnsureGlobals : MonoBehaviour
{
	public GameObject[] globalsList;

	// RECUPERADO-AOT EnsureGlobals.Awake token 0x06000433 @0x000ff8f0
	private void Awake()
	{
		// ELIMINADO (servicio iOS): MoreGamesBinding.Init() inicializaba la promo "More Disney".
		for (int i = 0; i < globalsList.Length; i++)
		{
			GameObject prefab = globalsList[i];
			if (GameObject.Find(prefab.name) == null)
			{
				GameObject instance = Object.Instantiate(prefab) as GameObject;
				instance.name = prefab.name;
				Object.DontDestroyOnLoad(instance);
			}
		}
	}
}
