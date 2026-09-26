using System.Collections;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;

namespace System.Threading
{
	[ComDefaultInterface(typeof(_Thread))]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	public sealed class Thread : CriticalFinalizerObject, _Thread
	{
		private int lock_thread_id;

		private IntPtr system_thread_handle;

		private object cached_culture_info;

		private IntPtr unused0;

		private bool threadpool_thread;

		private IntPtr name;

		private int name_len;

		private ThreadState state;

		private object abort_exc;

		private int abort_state_handle;

		private long thread_id;

		private IntPtr start_notify;

		private IntPtr stack_ptr;

		private UIntPtr static_data;

		private IntPtr jit_data;

		private IntPtr lock_data;

		private object current_appcontext;

		private int stack_size;

		private object start_obj;

		private IntPtr appdomain_refs;

		private int interruption_requested;

		private IntPtr suspend_event;

		private IntPtr suspended_event;

		private IntPtr resume_event;

		private IntPtr synch_cs;

		private IntPtr serialized_culture_info;

		private int serialized_culture_info_len;

		private IntPtr serialized_ui_culture_info;

		private int serialized_ui_culture_info_len;

		private bool thread_dump_requested;

		private IntPtr end_stack;

		private bool thread_interrupt_requested;

		private byte apartment_state;

		private volatile int critical_region_level;

		private int small_id;

		private IntPtr manage_callback;

		private object pending_exception;

		private ExecutionContext ec_to_set;

		private IntPtr interrupt_on_stop;

		private IntPtr unused3;

		private IntPtr unused4;

		private IntPtr unused5;

		private IntPtr unused6;

		[ThreadStatic]
		private static object[] local_slots;

		[ThreadStatic]
		private static ExecutionContext _ec;

		private MulticastDelegate threadstart;

		private static int _managed_id_counter;

		private int managed_id;

		private static Hashtable datastorehash;

		private static object datastore_lock;

		private bool in_currentculture;

		private static object culture_lock;

		public static Context CurrentContext
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static Thread CurrentThread
		{
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal static int CurrentThreadId
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		[Obsolete("Deprecated in favor of GetApartmentState, SetApartmentState and TrySetApartmentState.")]
		public ApartmentState ApartmentState
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public CultureInfo CurrentCulture
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public CultureInfo CurrentUICulture
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public bool IsThreadPoolThread
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal bool IsThreadPoolThreadInternal
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public bool IsAlive
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public bool IsBackground
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public string Name
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public ThreadPriority Priority
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public ThreadState ThreadState
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		[MonoTODO("limited to CompressedStack support")]
		public ExecutionContext ExecutionContext
		{
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public int ManagedThreadId
		{
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public Thread(ThreadStart start)
		{
		}

		public Thread(ThreadStart start, int maxStackSize)
		{
		}

		public Thread(ParameterizedThreadStart start)
		{
		}

		public Thread(ParameterizedThreadStart start, int maxStackSize)
		{
		}

		void _Thread.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
		{
		}

		void _Thread.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
		}

		void _Thread.GetTypeInfoCount(out uint pcTInfo)
		{
		}

		void _Thread.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Thread CurrentThread_internal();

		private static void InitDataStoreHash()
		{
		}

		public static LocalDataStoreSlot AllocateNamedDataSlot(string name)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static void FreeNamedDataSlot(string name)
		{
		}

		public static LocalDataStoreSlot AllocateDataSlot()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static object GetData(LocalDataStoreSlot slot)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static void SetData(LocalDataStoreSlot slot, object data)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void FreeLocalSlotValues(int slot, bool thread_local);

		public static LocalDataStoreSlot GetNamedDataSlot(string name)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static AppDomain GetDomain()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int GetDomainID();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ResetAbort_internal();

		public static void ResetAbort()
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Sleep_internal(int ms);

		public static void Sleep(int millisecondsTimeout)
		{
		}

		public static void Sleep(TimeSpan timeout)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern IntPtr Thread_internal(MulticastDelegate start);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Thread_init();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern CultureInfo GetCachedCurrentCulture();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern byte[] GetSerializedCurrentCulture();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetCachedCurrentCulture(CultureInfo culture);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetSerializedCurrentCulture(byte[] culture);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern CultureInfo GetCachedCurrentUICulture();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern byte[] GetSerializedCurrentUICulture();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetCachedCurrentUICulture(CultureInfo culture);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetSerializedCurrentUICulture(byte[] culture);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern string GetName_internal();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetName_internal(string name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Abort_internal(object stateInfo);

		public void Abort()
		{
		}

		public void Abort(object stateInfo)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern object GetAbortExceptionState();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Interrupt_internal();

		public void Interrupt()
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool Join_internal(int ms, IntPtr handle);

		public void Join()
		{
		}

		public bool Join(int millisecondsTimeout)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public bool Join(TimeSpan timeout)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void MemoryBarrier();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Resume_internal();

		[Obsolete("")]
		public void Resume()
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SpinWait_nop();

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static void SpinWait(int iterations)
		{
		}

		public void Start()
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Suspend_internal();

		[Obsolete("")]
		public void Suspend()
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Thread_free_internal(IntPtr handle);

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		~Thread()
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetState(ThreadState set);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void ClrState(ThreadState clr);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern ThreadState GetState();

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern byte VolatileRead(ref byte address);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern double VolatileRead(ref double address);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern short VolatileRead(ref short address);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int VolatileRead(ref int address);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern long VolatileRead(ref long address);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr VolatileRead(ref IntPtr address);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern object VolatileRead(ref object address);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[CLSCompliant(false)]
		public static extern sbyte VolatileRead(ref sbyte address);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern float VolatileRead(ref float address);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[CLSCompliant(false)]
		public static extern ushort VolatileRead(ref ushort address);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[CLSCompliant(false)]
		public static extern uint VolatileRead(ref uint address);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[CLSCompliant(false)]
		public static extern ulong VolatileRead(ref ulong address);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[CLSCompliant(false)]
		public static extern UIntPtr VolatileRead(ref UIntPtr address);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void VolatileWrite(ref byte address, byte value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void VolatileWrite(ref double address, double value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void VolatileWrite(ref short address, short value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void VolatileWrite(ref int address, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void VolatileWrite(ref long address, long value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void VolatileWrite(ref IntPtr address, IntPtr value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void VolatileWrite(ref object address, object value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[CLSCompliant(false)]
		public static extern void VolatileWrite(ref sbyte address, sbyte value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void VolatileWrite(ref float address, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[CLSCompliant(false)]
		public static extern void VolatileWrite(ref ushort address, ushort value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[CLSCompliant(false)]
		public static extern void VolatileWrite(ref uint address, uint value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[CLSCompliant(false)]
		public static extern void VolatileWrite(ref ulong address, ulong value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[CLSCompliant(false)]
		public static extern void VolatileWrite(ref UIntPtr address, UIntPtr value);

		private static int GetNewManagedId()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static void BeginCriticalRegion()
		{
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static void EndCriticalRegion()
		{
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static void BeginThreadAffinity()
		{
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static void EndThreadAffinity()
		{
		}

		public ApartmentState GetApartmentState()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void SetApartmentState(ApartmentState state)
		{
		}

		public bool TrySetApartmentState(ApartmentState state)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ComVisible(false)]
		public override int GetHashCode()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void Start(object parameter)
		{
		}

		[Obsolete("see CompressedStack class")]
		public CompressedStack GetCompressedStack()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[Obsolete("see CompressedStack class")]
		public void SetCompressedStack(CompressedStack stack)
		{
		}
	}
}
