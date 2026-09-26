using System.Configuration.Assemblies;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Reflection
{
	[Serializable]
	[ClassInterface(ClassInterfaceType.None)]
	public sealed class AssemblyName : ICloneable, _AssemblyName, IDeserializationCallback, ISerializable
	{
		private string name;

		private string codebase;

		private int major;

		private int minor;

		private int build;

		private int revision;

		private CultureInfo cultureinfo;

		private AssemblyNameFlags flags;

		private AssemblyHashAlgorithm hashalg;

		private StrongNameKeyPair keypair;

		private byte[] publicKey;

		private byte[] keyToken;

		private AssemblyVersionCompatibility versioncompat;

		private Version version;

		private ProcessorArchitecture processor_architecture;

		public string Name
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string CodeBase
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public CultureInfo CultureInfo
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public AssemblyNameFlags Flags
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string FullName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public Version Version
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public AssemblyName()
		{
		}

		internal AssemblyName(SerializationInfo si, StreamingContext sc)
		{
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public byte[] GetPublicKeyToken()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private byte[] InternalGetPublicKeyToken()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private byte[] ComputePublicKeyToken()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}

		public object Clone()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void OnDeserialization(object sender)
		{
		}
	}
}
