using System.Collections;
using UnityEngine;

public class GDMOManager : MonoBehaviour
{
	private const string appKey = "5FCC9A6D-6A6C-4CE1-9E81-B8732147BA49";

	private const string secretKey = "539CAD93-2E81-493C-8CD4-DA4A174DEE49";

	private static bool hasInit;

	private void Start()
	{
	}

	private void OnApplicationPause()
	{
	}

	public static void Init()
	{
	}

	public static void Send(string description)
	{
	}

	public static void SendWithContext(string scope, Hashtable details)
	{
	}

	public static void Flush()
	{
	}
}
