using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Mono.Security.Cryptography
{
	internal class KeyPairPersistence
	{
		private static bool _userPathExists;

		private static string _userPath;

		private static bool _machinePathExists;

		private static string _machinePath;

		private CspParameters _params;

		private string _keyvalue;

		private string _filename;

		private string _container;

		private static object lockobj;

		public string Filename
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string KeyValue
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		private static string UserPath
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private static string MachinePath
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private bool CanChange
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private bool UseDefaultKeyContainer
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private bool UseMachineKeyStore
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private string ContainerName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public KeyPairPersistence(CspParameters parameters)
		{
		}

		public KeyPairPersistence(CspParameters parameters, string keyPair)
		{
		}

		public bool Load()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void Save()
		{
		}

		public void Remove()
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool _CanSecure(string root);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool _ProtectUser(string path);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool _ProtectMachine(string path);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool _IsUserProtected(string path);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool _IsMachineProtected(string path);

		private static bool CanSecure(string path)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static bool ProtectUser(string path)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static bool ProtectMachine(string path)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static bool IsUserProtected(string path)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static bool IsMachineProtected(string path)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private CspParameters Copy(CspParameters p)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
