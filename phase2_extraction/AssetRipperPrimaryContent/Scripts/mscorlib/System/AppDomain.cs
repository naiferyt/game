using System.Collections;
using System.Configuration.Assemblies;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System
{
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	public sealed class AppDomain : MarshalByRefObject
	{
		private IntPtr _mono_app_domain;

		private static string _process_guid;

		[ThreadStatic]
		private static Hashtable type_resolve_in_progress;

		[ThreadStatic]
		private static Hashtable assembly_resolve_in_progress;

		[ThreadStatic]
		private static Hashtable assembly_resolve_in_progress_refonly;

		private static AppDomain default_domain;

		internal AppDomainSetup SetupInformationNoCopy
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public AppDomainSetup SetupInformation
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string BaseDirectory
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string RelativeSearchPath
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string DynamicDirectory
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public bool ShadowCopyFiles
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string FriendlyName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static AppDomain CurrentDomain
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal static AppDomain DefaultDomain
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public event AssemblyLoadEventHandler AssemblyLoad
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
			}
		}

		public event ResolveEventHandler AssemblyResolve
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
			}
		}

		public event EventHandler DomainUnload
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
			}
		}

		public event EventHandler ProcessExit
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
			}
		}

		public event ResolveEventHandler ResourceResolve
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
			}
		}

		public event ResolveEventHandler TypeResolve
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
			}
		}

		public event UnhandledExceptionEventHandler UnhandledException
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
			}
		}

		private AppDomain()
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern AppDomainSetup getSetup();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern string getFriendlyName();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AppDomain getCurDomain();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AppDomain getRootDomain();

		[Obsolete("AppDomain.AppendPrivatePath has been deprecated. Please investigate the use of AppDomainSetup.PrivateBinPath instead.")]
		public void AppendPrivatePath(string path)
		{
		}

		[Obsolete("AppDomain.ClearPrivatePath has been deprecated. Please investigate the use of AppDomainSetup.PrivateBinPath instead.")]
		public void ClearPrivatePath()
		{
		}

		[Obsolete("Use AppDomainSetup.ShadowCopyDirectories")]
		public void ClearShadowCopyPath()
		{
		}

		public ObjectHandle CreateInstance(string assemblyName, string typeName)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public ObjectHandle CreateInstance(string assemblyName, string typeName, object[] activationAttributes)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public ObjectHandle CreateInstance(string assemblyName, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes, object securityAttributes)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public object CreateInstanceAndUnwrap(string assemblyName, string typeName)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public object CreateInstanceAndUnwrap(string assemblyName, string typeName, object[] activationAttributes)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public object CreateInstanceAndUnwrap(string assemblyName, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes, object securityAttributes)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public ObjectHandle CreateInstanceFrom(string assemblyFile, string typeName)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public ObjectHandle CreateInstanceFrom(string assemblyFile, string typeName, object[] activationAttributes)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public ObjectHandle CreateInstanceFrom(string assemblyFile, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes, object securityAttributes)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public object CreateInstanceFromAndUnwrap(string assemblyName, string typeName)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public object CreateInstanceFromAndUnwrap(string assemblyName, string typeName, object[] activationAttributes)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public object CreateInstanceFromAndUnwrap(string assemblyName, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes, object securityAttributes)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void DoCallBack(CrossAppDomainDelegate callBackDelegate)
		{
		}

		public int ExecuteAssembly(string assemblyFile)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public int ExecuteAssembly(string assemblyFile, object assemblySecurity)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public int ExecuteAssembly(string assemblyFile, object assemblySecurity, string[] args)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public int ExecuteAssembly(string assemblyFile, object assemblySecurity, string[] args, byte[] hashValue, AssemblyHashAlgorithm hashAlgorithm)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private int ExecuteAssemblyInternal(Assembly a, string[] args)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int ExecuteAssembly(Assembly a, string[] args);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern Assembly[] GetAssemblies(bool refOnly);

		public Assembly[] GetAssemblies()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern object GetData(string name);

		public new Type GetType()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override object InitializeLifetimeService()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern Assembly LoadAssembly(string assemblyRef, object securityEvidence, bool refOnly);

		public Assembly Load(AssemblyName assemblyRef)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal Assembly LoadSatellite(AssemblyName assemblyRef, bool throwOnError)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public Assembly Load(AssemblyName assemblyRef, object assemblySecurity)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public Assembly Load(string assemblyString)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public Assembly Load(string assemblyString, object assemblySecurity)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal Assembly Load(string assemblyString, object assemblySecurity, bool refonly)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public Assembly Load(byte[] rawAssembly)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public Assembly Load(byte[] rawAssembly, byte[] rawSymbolStore)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern Assembly LoadAssemblyRaw(byte[] rawAssembly, byte[] rawSymbolStore, object securityEvidence, bool refonly);

		public Assembly Load(byte[] rawAssembly, byte[] rawSymbolStore, object securityEvidence)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal Assembly Load(byte[] rawAssembly, byte[] rawSymbolStore, object securityEvidence, bool refonly)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AppDomain InternalSetDomainByID(int domain_id);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AppDomain InternalSetDomain(AppDomain context);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void InternalPushDomainRef(AppDomain domain);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void InternalPushDomainRefByID(int domain_id);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void InternalPopDomainRef();

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern Context InternalSetContext(Context context);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern Context InternalGetContext();

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern Context InternalGetDefaultContext();

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern string InternalGetProcessGuid(string newguid);

		internal static object InvokeInDomain(AppDomain domain, MethodInfo method, object obj, object[] args)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static object InvokeInDomainByID(int domain_id, MethodInfo method, object obj, object[] args)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static string GetProcessGuid()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static AppDomain CreateDomain(string friendlyName)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static AppDomain CreateDomain(string friendlyName, object securityInfo)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AppDomain createDomain(string friendlyName, AppDomainSetup info);

		public static AppDomain CreateDomain(string friendlyName, object securityInfo, AppDomainSetup info)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static AppDomain CreateDomain(string friendlyName, object securityInfo, string appBasePath, string appRelativeSearchPath, bool shadowCopyFiles)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static AppDomainSetup CreateDomainSetup(string appBasePath, string appRelativeSearchPath, bool shadowCopyFiles)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool InternalIsFinalizingForUnload(int domain_id);

		public bool IsFinalizingForUnload()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalUnload(int domain_id);

		private int getDomainID()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ReliabilityContract(Consistency.MayCorruptAppDomain, Cer.MayFail)]
		public static void Unload(AppDomain domain)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetData(string name, object data);

		[MonoTODO]
		public void SetData(string name, object data, IPermission permission)
		{
		}

		[Obsolete("AppDomain.GetCurrentThreadId has been deprecated because it does not provide a stable Id when managed threads are running on fibers (aka lightweight threads). To get a stable identifier for a managed thread, use the ManagedThreadId property on Thread.'")]
		public static int GetCurrentThreadId()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static void ValidateAssemblyName(string name)
		{
		}

		private void DoAssemblyLoad(Assembly assembly)
		{
		}

		private Assembly DoAssemblyResolve(string name, bool refonly)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal Assembly DoTypeResolve(object name_or_tb)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void DoDomainUnload()
		{
		}

		internal void ProcessMessageInDomain(byte[] arrRequest, CADMethodCallMessage cadMsg, out byte[] arrResponse, out CADMethodReturnMessage cadMrm)
		{
		}
	}
}
