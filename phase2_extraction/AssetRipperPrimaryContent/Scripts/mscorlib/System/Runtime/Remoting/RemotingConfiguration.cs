using System.Collections;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting
{
	[ComVisible(true)]
	public static class RemotingConfiguration
	{
		private static string applicationID;

		private static string applicationName;

		private static string processGuid;

		private static bool defaultConfigRead;

		private static bool defaultDelayedConfigRead;

		private static string _errorMode;

		private static Hashtable wellKnownClientEntries;

		private static Hashtable activatedClientEntries;

		private static Hashtable wellKnownServiceEntries;

		private static Hashtable activatedServiceEntries;

		private static Hashtable channelTemplates;

		private static Hashtable clientProviderTemplates;

		private static Hashtable serverProviderTemplates;

		public static string ApplicationName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static bool IsActivationAllowed(Type svrType)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
