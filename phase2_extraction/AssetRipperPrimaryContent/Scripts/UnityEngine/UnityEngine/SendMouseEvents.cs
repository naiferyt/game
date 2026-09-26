namespace UnityEngine
{
	internal class SendMouseEvents
	{
		private struct HitInfo
		{
			public GameObject target;

			public Camera camera;

			public void SendMessage(string name)
			{
			}

			public static bool Compare(HitInfo lhs, HitInfo rhs)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public static implicit operator bool(HitInfo exists)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private static HitInfo[] m_LastHit;

		private static HitInfo[] m_MouseDownHit;

		private static RaycastHit2D[] m_MouseRayHits2D;

		[NotRenamed]
		private static void DoSendMouseEvents(int mouseUsed, int skipRTCameras)
		{
		}

		private static void SendEvents(int i, HitInfo hit)
		{
		}
	}
}
