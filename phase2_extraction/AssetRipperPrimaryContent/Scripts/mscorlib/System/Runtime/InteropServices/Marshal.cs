using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using System.Threading;

namespace System.Runtime.InteropServices
{
	[SuppressUnmanagedCodeSecurity]
	public static class Marshal
	{
		public static readonly int SystemMaxDBCSCharSize;

		public static readonly int SystemDefaultCharSize;

		static Marshal()
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int AddRefInternal(IntPtr pUnk);

		public static int AddRef(IntPtr pUnk)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr AllocCoTaskMem(int cb);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static extern IntPtr AllocHGlobal(IntPtr cb);

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static IntPtr AllocHGlobal(int cb)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MonoTODO]
		public static object BindToMoniker(string monikerName)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MonoTODO]
		public static void ChangeWrapperHandleStrength(object otp, bool fIsWeak)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void copy_to_unmanaged(Array source, int startIndex, IntPtr destination, int length);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void copy_from_unmanaged(IntPtr source, int startIndex, Array destination, int length);

		public static void Copy(byte[] source, int startIndex, IntPtr destination, int length)
		{
		}

		public static void Copy(char[] source, int startIndex, IntPtr destination, int length)
		{
		}

		public static void Copy(short[] source, int startIndex, IntPtr destination, int length)
		{
		}

		public static void Copy(int[] source, int startIndex, IntPtr destination, int length)
		{
		}

		public static void Copy(long[] source, int startIndex, IntPtr destination, int length)
		{
		}

		public static void Copy(float[] source, int startIndex, IntPtr destination, int length)
		{
		}

		public static void Copy(double[] source, int startIndex, IntPtr destination, int length)
		{
		}

		public static void Copy(IntPtr[] source, int startIndex, IntPtr destination, int length)
		{
		}

		public static void Copy(IntPtr source, byte[] destination, int startIndex, int length)
		{
		}

		public static void Copy(IntPtr source, char[] destination, int startIndex, int length)
		{
		}

		public static void Copy(IntPtr source, short[] destination, int startIndex, int length)
		{
		}

		public static void Copy(IntPtr source, int[] destination, int startIndex, int length)
		{
		}

		public static void Copy(IntPtr source, long[] destination, int startIndex, int length)
		{
		}

		public static void Copy(IntPtr source, float[] destination, int startIndex, int length)
		{
		}

		public static void Copy(IntPtr source, double[] destination, int startIndex, int length)
		{
		}

		public static void Copy(IntPtr source, IntPtr[] destination, int startIndex, int length)
		{
		}

		public static IntPtr CreateAggregatedObject(IntPtr pOuter, object o)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static object CreateWrapperOfType(object o, Type t)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ComVisible(true)]
		public static extern void DestroyStructure(IntPtr ptr, Type structuretype);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void FreeBSTR(IntPtr ptr);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void FreeCoTaskMem(IntPtr ptr);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static extern void FreeHGlobal(IntPtr hglobal);

		private static void ClearBSTR(IntPtr ptr)
		{
		}

		public static void ZeroFreeBSTR(IntPtr s)
		{
		}

		private static void ClearAnsi(IntPtr ptr)
		{
		}

		private static void ClearUnicode(IntPtr ptr)
		{
		}

		public static void ZeroFreeCoTaskMemAnsi(IntPtr s)
		{
		}

		public static void ZeroFreeCoTaskMemUnicode(IntPtr s)
		{
		}

		public static void ZeroFreeGlobalAllocAnsi(IntPtr s)
		{
		}

		public static void ZeroFreeGlobalAllocUnicode(IntPtr s)
		{
		}

		public static Guid GenerateGuidForType(Type type)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MonoTODO]
		public static string GenerateProgIdForType(Type type)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MonoTODO]
		public static object GetActiveObject(string progID)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetCCW(object o, Type T);

		private static IntPtr GetComInterfaceForObjectInternal(object o, Type T)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static IntPtr GetComInterfaceForObject(object o, Type T)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MonoTODO]
		public static IntPtr GetComInterfaceForObjectInContext(object o, Type t)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MonoNotSupported("MSDN states user code should never need to call this method.")]
		public static object GetComObjectData(object obj, object key)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetComSlotForMethodInfoInternal(MemberInfo m);

		public static int GetComSlotForMethodInfo(MemberInfo m)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MonoTODO]
		public static int GetEndComSlot(Type t)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MonoTODO]
		public static int GetExceptionCode()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ComVisible(true)]
		[MonoTODO]
		public static IntPtr GetExceptionPointers()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static IntPtr GetHINSTANCE(Module m)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MonoTODO("SetErrorInfo")]
		public static int GetHRForException(Exception e)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MonoTODO]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static int GetHRForLastWin32Error()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetIDispatchForObjectInternal(object o);

		public static IntPtr GetIDispatchForObject(object o)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MonoTODO]
		public static IntPtr GetIDispatchForObjectInContext(object o)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MonoTODO]
		public static IntPtr GetITypeInfoForType(Type t)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetIUnknownForObjectInternal(object o);

		public static IntPtr GetIUnknownForObject(object o)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MonoTODO]
		public static IntPtr GetIUnknownForObjectInContext(object o)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MonoTODO]
		[Obsolete("This method has been deprecated")]
		public static IntPtr GetManagedThunkForUnmanagedMethodPtr(IntPtr pfnMethodToWrap, IntPtr pbSignature, int cbSignature)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MonoTODO]
		public static MemberInfo GetMethodInfoForComSlot(Type t, int slot, ref ComMemberType memberType)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static void GetNativeVariantForObject(object obj, IntPtr pDstNativeVariant)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern object GetObjectForCCW(IntPtr pUnk);

		public static object GetObjectForIUnknown(IntPtr pUnk)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static object GetObjectForNativeVariant(IntPtr pSrcNativeVariant)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static object[] GetObjectsForNativeVariants(IntPtr aSrcNativeVariant, int cVars)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MonoTODO]
		public static int GetStartComSlot(Type t)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[Obsolete("This method has been deprecated")]
		[MonoTODO]
		public static Thread GetThreadFromFiberCookie(int cookie)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static object GetTypedObjectForIUnknown(IntPtr pUnk, Type t)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MonoTODO]
		public static Type GetTypeForITypeInfo(IntPtr piTypeInfo)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[Obsolete]
		[MonoTODO]
		public static string GetTypeInfoName(UCOMITypeInfo pTI)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static string GetTypeInfoName(ITypeInfo typeInfo)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[Obsolete]
		[MonoTODO]
		public static Guid GetTypeLibGuid(UCOMITypeLib pTLB)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MonoTODO]
		public static Guid GetTypeLibGuid(ITypeLib typelib)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MonoTODO]
		public static Guid GetTypeLibGuidForAssembly(Assembly asm)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[Obsolete]
		[MonoTODO]
		public static int GetTypeLibLcid(UCOMITypeLib pTLB)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MonoTODO]
		public static int GetTypeLibLcid(ITypeLib typelib)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MonoTODO]
		[Obsolete]
		public static string GetTypeLibName(UCOMITypeLib pTLB)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MonoTODO]
		public static string GetTypeLibName(ITypeLib typelib)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MonoTODO]
		public static void GetTypeLibVersionForAssembly(Assembly inputAssembly, out int majorVersion, out int minorVersion)
		{
		}

		public static object GetUniqueObjectForIUnknown(IntPtr unknown)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MonoTODO]
		[Obsolete("This method has been deprecated")]
		public static IntPtr GetUnmanagedThunkForManagedMethodPtr(IntPtr pfnMethodToWrap, IntPtr pbSignature, int cbSignature)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsComObject(object o);

		[MonoTODO]
		public static bool IsTypeVisibleFromCom(Type t)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MonoTODO]
		public static int NumParamBytes(MethodInfo m)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static extern int GetLastWin32Error();

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr OffsetOf(Type t, string fieldName);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void Prelink(MethodInfo m);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void PrelinkAll(Type c);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern string PtrToStringAnsi(IntPtr ptr);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern string PtrToStringAnsi(IntPtr ptr, int len);

		public static string PtrToStringAuto(IntPtr ptr)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static string PtrToStringAuto(IntPtr ptr, int len)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern string PtrToStringUni(IntPtr ptr);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern string PtrToStringUni(IntPtr ptr, int len);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern string PtrToStringBSTR(IntPtr ptr);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ComVisible(true)]
		public static extern void PtrToStructure(IntPtr ptr, object structure);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ComVisible(true)]
		public static extern object PtrToStructure(IntPtr ptr, Type structureType);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int QueryInterfaceInternal(IntPtr pUnk, ref Guid iid, out IntPtr ppv);

		public static int QueryInterface(IntPtr pUnk, ref Guid iid, out IntPtr ppv)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static byte ReadByte(IntPtr ptr)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern byte ReadByte(IntPtr ptr, int ofs);

		[MonoTODO]
		public static byte ReadByte([In][MarshalAs((UnmanagedType)40)] object ptr, int ofs)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static short ReadInt16(IntPtr ptr)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern short ReadInt16(IntPtr ptr, int ofs);

		[MonoTODO]
		public static short ReadInt16([In][MarshalAs((UnmanagedType)40)] object ptr, int ofs)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static int ReadInt32(IntPtr ptr)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static extern int ReadInt32(IntPtr ptr, int ofs);

		[MonoTODO]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static int ReadInt32([In][MarshalAs((UnmanagedType)40)] object ptr, int ofs)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static long ReadInt64(IntPtr ptr)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static extern long ReadInt64(IntPtr ptr, int ofs);

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MonoTODO]
		public static long ReadInt64([In][MarshalAs((UnmanagedType)40)] object ptr, int ofs)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static IntPtr ReadIntPtr(IntPtr ptr)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static extern IntPtr ReadIntPtr(IntPtr ptr, int ofs);

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MonoTODO]
		public static IntPtr ReadIntPtr([In][MarshalAs((UnmanagedType)40)] object ptr, int ofs)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr ReAllocCoTaskMem(IntPtr pv, int cb);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr ReAllocHGlobal(IntPtr pv, IntPtr cb);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		private static extern int ReleaseInternal(IntPtr pUnk);

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static int Release(IntPtr pUnk)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int ReleaseComObjectInternal(object co);

		public static int ReleaseComObject(object o)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MonoTODO]
		[Obsolete]
		public static void ReleaseThreadCache()
		{
		}

		[MonoNotSupported("MSDN states user code should never need to call this method.")]
		public static bool SetComObjectData(object obj, object key, object data)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ComVisible(true)]
		public static int SizeOf(object structure)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int SizeOf(Type t);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr StringToBSTR(string s);

		public static IntPtr StringToCoTaskMemAnsi(string s)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static IntPtr StringToCoTaskMemAuto(string s)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static IntPtr StringToCoTaskMemUni(string s)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr StringToHGlobalAnsi(string s);

		public static IntPtr StringToHGlobalAuto(string s)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr StringToHGlobalUni(string s);

		public static IntPtr SecureStringToBSTR(SecureString s)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static IntPtr SecureStringToCoTaskMemAnsi(SecureString s)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static IntPtr SecureStringToCoTaskMemUnicode(SecureString s)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static IntPtr SecureStringToGlobalAllocAnsi(SecureString s)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static IntPtr SecureStringToGlobalAllocUnicode(SecureString s)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ComVisible(true)]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static extern void StructureToPtr(object structure, IntPtr ptr, bool fDeleteOld);

		public static void ThrowExceptionForHR(int errorCode)
		{
		}

		public static void ThrowExceptionForHR(int errorCode, IntPtr errorInfo)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr UnsafeAddrOfPinnedArrayElement(Array arr, int index);

		public static void WriteByte(IntPtr ptr, byte val)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void WriteByte(IntPtr ptr, int ofs, byte val);

		[MonoTODO]
		public static void WriteByte([In][Out][MarshalAs((UnmanagedType)40)] object ptr, int ofs, byte val)
		{
		}

		public static void WriteInt16(IntPtr ptr, short val)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void WriteInt16(IntPtr ptr, int ofs, short val);

		[MonoTODO]
		public static void WriteInt16([In][Out][MarshalAs((UnmanagedType)40)] object ptr, int ofs, short val)
		{
		}

		public static void WriteInt16(IntPtr ptr, char val)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[MonoTODO]
		public static extern void WriteInt16(IntPtr ptr, int ofs, char val);

		[MonoTODO]
		public static void WriteInt16([In][Out] object ptr, int ofs, char val)
		{
		}

		public static void WriteInt32(IntPtr ptr, int val)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void WriteInt32(IntPtr ptr, int ofs, int val);

		[MonoTODO]
		public static void WriteInt32([In][Out][MarshalAs((UnmanagedType)40)] object ptr, int ofs, int val)
		{
		}

		public static void WriteInt64(IntPtr ptr, long val)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void WriteInt64(IntPtr ptr, int ofs, long val);

		[MonoTODO]
		public static void WriteInt64([In][Out][MarshalAs((UnmanagedType)40)] object ptr, int ofs, long val)
		{
		}

		public static void WriteIntPtr(IntPtr ptr, IntPtr val)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void WriteIntPtr(IntPtr ptr, int ofs, IntPtr val);

		[MonoTODO]
		public static void WriteIntPtr([In][Out][MarshalAs((UnmanagedType)40)] object ptr, int ofs, IntPtr val)
		{
		}

		public static Exception GetExceptionForHR(int errorCode)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static Exception GetExceptionForHR(int errorCode, IntPtr errorInfo)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static int FinalReleaseComObject(object o)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Delegate GetDelegateForFunctionPointerInternal(IntPtr ptr, Type t);

		public static Delegate GetDelegateForFunctionPointer(IntPtr ptr, Type t)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetFunctionPointerForDelegateInternal(Delegate d);

		public static IntPtr GetFunctionPointerForDelegate(Delegate d)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
