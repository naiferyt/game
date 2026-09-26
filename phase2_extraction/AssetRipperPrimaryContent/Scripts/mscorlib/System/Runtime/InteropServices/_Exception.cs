namespace System.Runtime.InteropServices
{
	[Guid("b36b5c63-42ef-38bc-a07e-0b34c98f164a")]
	[ComVisible(true)]
	[CLSCompliant(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface _Exception
	{
		Exception InnerException { get; }

		string Message { get; }

		string Source { get; }

		string StackTrace { get; }

		new Type GetType();

		new string ToString();
	}
}
