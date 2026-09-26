namespace System.Runtime.Serialization.Formatters.Binary
{
	internal class BinaryCommon
	{
		public static byte[] BinaryHeader;

		private static Type[] _typeCodesToType;

		private static byte[] _typeCodeMap;

		public static bool UseReflectionSerialization;

		static BinaryCommon()
		{
		}

		public static bool IsPrimitive(Type type)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static byte GetTypeCode(Type type)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static Type GetTypeFromCode(int code)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static void CheckSerializable(Type type, ISurrogateSelector selector, StreamingContext context)
		{
		}

		public static void SwapBytes(byte[] byteArray, int size, int dataSize)
		{
		}
	}
}
