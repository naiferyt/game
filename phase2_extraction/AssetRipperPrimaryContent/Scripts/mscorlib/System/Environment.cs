using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System
{
	public static class Environment
	{
		[ComVisible(true)]
		public enum SpecialFolder
		{
			MyDocuments = 5,
			Desktop = 0,
			MyComputer = 17,
			Programs = 2,
			Personal = 5,
			Favorites = 6,
			Startup = 7,
			Recent = 8,
			SendTo = 9,
			StartMenu = 11,
			MyMusic = 13,
			DesktopDirectory = 16,
			Templates = 21,
			ApplicationData = 26,
			LocalApplicationData = 28,
			InternetCache = 32,
			Cookies = 33,
			History = 34,
			CommonApplicationData = 35,
			System = 37,
			ProgramFiles = 38,
			MyPictures = 39,
			CommonProgramFiles = 43
		}

		private const int mono_corlib_version = 82;

		private static OperatingSystem os;

		public static string CommandLine
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static string CurrentDirectory
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public static extern int ExitCode
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		public static extern bool HasShutdownStarted
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern string EmbeddingHostName
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern bool SocketSecurityEnabled
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static bool UnityWebSecurityEnabled
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static extern string MachineName
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern string NewLine
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		internal static extern PlatformID Platform
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static OperatingSystem OSVersion
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static string StackTrace
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static extern int TickCount
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static string UserDomainName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		[MonoTODO("Currently always returns false, regardless of interactive state")]
		public static bool UserInteractive
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static extern string UserName
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static Version Version
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		[MonoTODO("Currently always returns zero")]
		public static long WorkingSet
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal static bool IsRunningOnWindows
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern string GetOSVersionString();

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void Exit(int exitCode);

		public static string ExpandEnvironmentVariables(string name)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern string[] GetCommandLineArgs();

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern string internalGetEnvironmentVariable(string variable);

		public static string GetEnvironmentVariable(string variable)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static Hashtable GetEnvironmentVariablesNoCase()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static IDictionary GetEnvironmentVariables()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string GetWindowsFolderPath(int folder);

		public static string GetFolderPath(SpecialFolder folder)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static string ReadXdgUserDir(string config_dir, string home_dir, string key, string fallback)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static string InternalGetFolderPath(SpecialFolder folder)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static string[] GetLogicalDrives()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string[] GetLogicalDrivesInternal();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string[] GetEnvironmentVariableNames();

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern string GetMachineConfigPath();

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern string internalGetHome();
	}
}
