namespace System.Text.RegularExpressions
{
	internal class Interpreter : BaseMachine
	{
		private struct IntStack
		{
			private int[] values;

			private int count;

			public int Count
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
				set
				{
				}
			}

			public int Pop()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public void Push(int value)
			{
			}
		}

		private enum Mode
		{
			Search = 0,
			Match = 1,
			Count = 2
		}

		private class RepeatContext
		{
			private int start;

			private int min;

			private int max;

			private bool lazy;

			private int expr_pc;

			private RepeatContext previous;

			private int count;

			public int Count
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
				set
				{
				}
			}

			public int Start
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
				set
				{
				}
			}

			public bool IsMinimum
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public bool IsMaximum
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public bool IsLazy
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public int Expression
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public RepeatContext Previous
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public RepeatContext(RepeatContext previous, int min, int max, bool lazy, int expr_pc)
			{
			}
		}

		private ushort[] program;

		private int program_start;

		private string text;

		private int text_end;

		private int group_count;

		private int match_min;

		private QuickSearch qs;

		private int scan_ptr;

		private RepeatContext repeat;

		private RepeatContext fast;

		private IntStack stack;

		private RepeatContext deep;

		private Mark[] marks;

		private int mark_start;

		private int mark_end;

		private int[] groups;

		public Interpreter(ushort[] program)
		{
		}

		private int ReadProgramCount(int ptr)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override Match Scan(Regex regex, string text, int start, int end)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void Reset()
		{
		}

		private bool Eval(Mode mode, ref int ref_ptr, int pc)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private bool EvalChar(Mode mode, ref int ptr, ref int pc, bool multi)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private bool TryMatch(ref int ref_ptr, int pc)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private bool IsPosition(Position pos, int ptr)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private bool IsWordChar(char c)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private string GetString(int pc)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void Open(int gid, int ptr)
		{
		}

		private void Close(int gid, int ptr)
		{
		}

		private bool Balance(int gid, int balance_gid, bool capture, int ptr)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private int Checkpoint()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void Backtrack(int cp)
		{
		}

		private void ResetGroups()
		{
		}

		private int GetLastDefined(int gid)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private int CreateMark(int previous)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void GetGroupInfo(int gid, out int first_mark_index, out int n_caps)
		{
		}

		private void PopulateGroup(Group g, int first_mark_index, int n_caps)
		{
		}

		private Match GenerateMatch(Regex regex)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
