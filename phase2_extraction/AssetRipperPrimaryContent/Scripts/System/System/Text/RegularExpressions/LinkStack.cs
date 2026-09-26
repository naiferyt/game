using System.Collections;

namespace System.Text.RegularExpressions
{
	internal abstract class LinkStack : LinkRef
	{
		private Stack stack;

		public LinkStack()
		{
		}

		public void Push()
		{
		}

		public bool Pop()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		protected abstract object GetCurrent();

		protected abstract void SetCurrent(object l);
	}
}
