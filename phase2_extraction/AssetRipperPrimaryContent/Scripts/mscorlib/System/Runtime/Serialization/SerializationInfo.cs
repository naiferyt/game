using System.Collections;
using System.Runtime.InteropServices;

namespace System.Runtime.Serialization
{
	[ComVisible(true)]
	public sealed class SerializationInfo
	{
		private Hashtable serialized;

		private ArrayList values;

		private string assemblyName;

		private string fullTypeName;

		private IFormatterConverter converter;

		public string AssemblyName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string FullTypeName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public int MemberCount
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		[CLSCompliant(false)]
		public SerializationInfo(Type type, IFormatterConverter converter)
		{
		}

		public void AddValue(string name, object value, Type type)
		{
		}

		public object GetValue(string name, Type type)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void SetType(Type type)
		{
		}

		public SerializationInfoEnumerator GetEnumerator()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void AddValue(string name, short value)
		{
		}

		public void AddValue(string name, int value)
		{
		}

		public void AddValue(string name, bool value)
		{
		}

		public void AddValue(string name, DateTime value)
		{
		}

		public void AddValue(string name, float value)
		{
		}

		public void AddValue(string name, long value)
		{
		}

		[CLSCompliant(false)]
		public void AddValue(string name, ulong value)
		{
		}

		public void AddValue(string name, object value)
		{
		}

		public bool GetBoolean(string name)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public short GetInt16(string name)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public int GetInt32(string name)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public long GetInt64(string name)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public string GetString(string name)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
