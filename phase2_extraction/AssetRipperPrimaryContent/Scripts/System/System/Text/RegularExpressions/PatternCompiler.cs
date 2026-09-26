using System.Collections;

namespace System.Text.RegularExpressions
{
	internal class PatternCompiler : ICompiler
	{
		private class PatternLinkStack : LinkStack
		{
			private struct Link
			{
				public int base_addr;

				public int offset_addr;
			}

			private Link link;

			public int BaseAddress
			{
				set
				{
				}
			}

			public int OffsetAddress
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
				set
				{
				}
			}

			public int GetOffset(int target_addr)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			protected override object GetCurrent()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			protected override void SetCurrent(object l)
			{
			}
		}

		private ArrayList pgm;

		private int CurrentAddress
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static ushort EncodeOp(OpCode op, OpFlags flags)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public IMachineFactory GetMachineFactory()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void EmitFalse()
		{
		}

		public void EmitTrue()
		{
		}

		private void EmitCount(int count)
		{
		}

		public void EmitCharacter(char c, bool negate, bool ignore, bool reverse)
		{
		}

		public void EmitCategory(Category cat, bool negate, bool reverse)
		{
		}

		public void EmitNotCategory(Category cat, bool negate, bool reverse)
		{
		}

		public void EmitRange(char lo, char hi, bool negate, bool ignore, bool reverse)
		{
		}

		public void EmitSet(char lo, BitArray set, bool negate, bool ignore, bool reverse)
		{
		}

		public void EmitString(string str, bool ignore, bool reverse)
		{
		}

		public void EmitPosition(Position pos)
		{
		}

		public void EmitOpen(int gid)
		{
		}

		public void EmitClose(int gid)
		{
		}

		public void EmitBalanceStart(int gid, int balance, bool capture, LinkRef tail)
		{
		}

		public void EmitBalance()
		{
		}

		public void EmitReference(int gid, bool ignore, bool reverse)
		{
		}

		public void EmitIfDefined(int gid, LinkRef tail)
		{
		}

		public void EmitSub(LinkRef tail)
		{
		}

		public void EmitTest(LinkRef yes, LinkRef tail)
		{
		}

		public void EmitBranch(LinkRef next)
		{
		}

		public void EmitJump(LinkRef target)
		{
		}

		public void EmitRepeat(int min, int max, bool lazy, LinkRef until)
		{
		}

		public void EmitUntil(LinkRef repeat)
		{
		}

		public void EmitFastRepeat(int min, int max, bool lazy, LinkRef tail)
		{
		}

		public void EmitIn(LinkRef tail)
		{
		}

		public void EmitAnchor(bool reverse, int offset, LinkRef tail)
		{
		}

		public void EmitInfo(int count, int min, int max)
		{
		}

		public LinkRef NewLink()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void ResolveLink(LinkRef lref)
		{
		}

		public void EmitBranchEnd()
		{
		}

		public void EmitAlternationEnd()
		{
		}

		private static OpFlags MakeFlags(bool negate, bool ignore, bool reverse, bool lazy)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void Emit(OpCode op)
		{
		}

		private void Emit(OpCode op, OpFlags flags)
		{
		}

		private void Emit(ushort word)
		{
		}

		private void BeginLink(LinkRef lref)
		{
		}

		private void EmitLink(LinkRef lref)
		{
		}
	}
}
