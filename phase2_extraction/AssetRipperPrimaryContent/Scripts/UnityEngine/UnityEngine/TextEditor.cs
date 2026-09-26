using System.Collections.Generic;

namespace UnityEngine
{
	public class TextEditor
	{
		private enum CharacterType
		{
			LetterLike = 0,
			Symbol = 1,
			Symbol2 = 2,
			WhiteSpace = 3
		}

		public enum DblClickSnapping : byte
		{
			WORDS = 0,
			PARAGRAPHS = 1
		}

		private enum TextEditOp
		{
			MoveLeft = 0,
			MoveRight = 1,
			MoveUp = 2,
			MoveDown = 3,
			MoveLineStart = 4,
			MoveLineEnd = 5,
			MoveTextStart = 6,
			MoveTextEnd = 7,
			MovePageUp = 8,
			MovePageDown = 9,
			MoveGraphicalLineStart = 10,
			MoveGraphicalLineEnd = 11,
			MoveWordLeft = 12,
			MoveWordRight = 13,
			MoveParagraphForward = 14,
			MoveParagraphBackward = 15,
			MoveToStartOfNextWord = 16,
			MoveToEndOfPreviousWord = 17,
			SelectLeft = 18,
			SelectRight = 19,
			SelectUp = 20,
			SelectDown = 21,
			SelectTextStart = 22,
			SelectTextEnd = 23,
			SelectPageUp = 24,
			SelectPageDown = 25,
			ExpandSelectGraphicalLineStart = 26,
			ExpandSelectGraphicalLineEnd = 27,
			SelectGraphicalLineStart = 28,
			SelectGraphicalLineEnd = 29,
			SelectWordLeft = 30,
			SelectWordRight = 31,
			SelectToEndOfPreviousWord = 32,
			SelectToStartOfNextWord = 33,
			SelectParagraphBackward = 34,
			SelectParagraphForward = 35,
			Delete = 36,
			Backspace = 37,
			DeleteWordBack = 38,
			DeleteWordForward = 39,
			DeleteLineBack = 40,
			Cut = 41,
			Copy = 42,
			Paste = 43,
			SelectAll = 44,
			SelectNone = 45,
			ScrollStart = 46,
			ScrollEnd = 47,
			ScrollPageUp = 48,
			ScrollPageDown = 49
		}

		public TouchScreenKeyboard keyboardOnScreen;

		public int pos;

		public int selectPos;

		public int controlID;

		public GUIContent content;

		public GUIStyle style;

		public Rect position;

		public bool multiline;

		public bool hasHorizontalCursorPos;

		public bool isPasswordField;

		internal bool m_HasFocus;

		public Vector2 scrollOffset;

		public Vector2 graphicalCursorPos;

		public Vector2 graphicalSelectCursorPos;

		private bool m_MouseDragSelectsWholeWords;

		private int m_DblClickInitPos;

		private DblClickSnapping m_DblClickSnap;

		private bool m_bJustSelected;

		private int m_iAltCursorPos;

		private string oldText;

		private int oldPos;

		private int oldSelectPos;

		private static Dictionary<Event, TextEditOp> s_Keyactions;

		public bool hasSelection
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string SelectedText
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private void ClearCursorPos()
		{
		}

		public void OnFocus()
		{
		}

		public void OnLostFocus()
		{
		}

		private void GrabGraphicalCursorPos()
		{
		}

		public bool HandleKeyEvent(Event e)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public bool DeleteLineBack()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public bool DeleteWordBack()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public bool DeleteWordForward()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public bool Delete()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public bool CanPaste()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public bool Backspace()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void SelectAll()
		{
		}

		public void SelectNone()
		{
		}

		public bool DeleteSelection()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void ReplaceSelection(string replace)
		{
		}

		public void Insert(char c)
		{
		}

		public void MoveSelectionToAltCursor()
		{
		}

		public void MoveRight()
		{
		}

		public void MoveLeft()
		{
		}

		public void MoveUp()
		{
		}

		public void MoveDown()
		{
		}

		public void MoveLineStart()
		{
		}

		public void MoveLineEnd()
		{
		}

		public void MoveGraphicalLineStart()
		{
		}

		public void MoveGraphicalLineEnd()
		{
		}

		public void MoveTextStart()
		{
		}

		public void MoveTextEnd()
		{
		}

		public void MoveParagraphForward()
		{
		}

		public void MoveParagraphBackward()
		{
		}

		public void MoveCursorToPosition(Vector2 cursorPosition)
		{
		}

		public void MoveAltCursorToPosition(Vector2 cursorPosition)
		{
		}

		public bool IsOverSelection(Vector2 cursorPosition)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void SelectToPosition(Vector2 cursorPosition)
		{
		}

		public void SelectLeft()
		{
		}

		public void SelectRight()
		{
		}

		public void SelectUp()
		{
		}

		public void SelectDown()
		{
		}

		public void SelectTextEnd()
		{
		}

		public void SelectTextStart()
		{
		}

		public void MouseDragSelectsWholeWords(bool on)
		{
		}

		public void DblClickSnap(DblClickSnapping snapping)
		{
		}

		private int GetGraphicalLineStart(int p)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private int GetGraphicalLineEnd(int p)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private int FindNextSeperator(int startPos)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static bool isLetterLikeChar(char c)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private int FindPrevSeperator(int startPos)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void MoveWordRight()
		{
		}

		public void MoveToStartOfNextWord()
		{
		}

		public void MoveToEndOfPreviousWord()
		{
		}

		public void SelectToStartOfNextWord()
		{
		}

		public void SelectToEndOfPreviousWord()
		{
		}

		private CharacterType ClassifyChar(char c)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public int FindStartOfNextWord(int p)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private int FindEndOfPreviousWord(int p)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void MoveWordLeft()
		{
		}

		public void SelectWordRight()
		{
		}

		public void SelectWordLeft()
		{
		}

		public void ExpandSelectGraphicalLineStart()
		{
		}

		public void ExpandSelectGraphicalLineEnd()
		{
		}

		public void SelectGraphicalLineStart()
		{
		}

		public void SelectGraphicalLineEnd()
		{
		}

		public void SelectParagraphForward()
		{
		}

		public void SelectParagraphBackward()
		{
		}

		public void SelectCurrentWord()
		{
		}

		private int FindEndOfClassification(int p, int dir)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void SelectCurrentParagraph()
		{
		}

		public void DrawCursor(string text)
		{
		}

		private bool PerformOperation(TextEditOp operation)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void SaveBackup()
		{
		}

		public void Undo()
		{
		}

		public bool Cut()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void Copy()
		{
		}

		public bool Paste()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static void MapKey(string key, TextEditOp action)
		{
		}

		private void InitKeyActions()
		{
		}

		public void ClampPos()
		{
		}
	}
}
