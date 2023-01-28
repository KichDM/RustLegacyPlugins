using System;
using System.Reflection;
using UnityEngine;

// Token: 0x020007B6 RID: 1974
public class EndAllTextSolution : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060041BF RID: 16831 RVA: 0x000ED63C File Offset: 0x000EB83C
	public EndAllTextSolution()
	{
	}

	// Token: 0x17000C10 RID: 3088
	// (get) Token: 0x060041C0 RID: 16832 RVA: 0x000ED65C File Offset: 0x000EB85C
	private static global::UnityEngine.GUISkin skin
	{
		get
		{
			return global::UnityEngine.GUI.skin;
		}
	}

	// Token: 0x17000C11 RID: 3089
	// (get) Token: 0x060041C1 RID: 16833 RVA: 0x000ED664 File Offset: 0x000EB864
	// (set) Token: 0x060041C2 RID: 16834 RVA: 0x000ED66C File Offset: 0x000EB86C
	private static bool changed
	{
		get
		{
			return global::UnityEngine.GUI.changed;
		}
		set
		{
			global::UnityEngine.GUI.changed = value;
		}
	}

	// Token: 0x060041C3 RID: 16835 RVA: 0x000ED674 File Offset: 0x000EB874
	private static void DoTextField(global::UnityEngine.Rect position, int id, global::UnityEngine.GUIContent content, bool multiline, int maxLength, global::UnityEngine.GUIStyle style)
	{
		if (maxLength >= 0 && content.text.Length > maxLength)
		{
			content.text = content.text.Substring(0, maxLength);
		}
		global::EndAllTextSolution.GUI2.CheckOnGUI();
		global::UnityEngine.TextEditor textEditor = (global::UnityEngine.TextEditor)global::UnityEngine.GUIUtility.GetStateObject(typeof(global::UnityEngine.TextEditor), id);
		textEditor.content.text = content.text;
		textEditor.SaveBackup();
		textEditor.position = position;
		textEditor.style = style;
		textEditor.multiline = multiline;
		textEditor.controlID = id;
		textEditor.ClampPos();
		global::UnityEngine.Event current = global::UnityEngine.Event.current;
		bool flag = false;
		switch (current.type)
		{
		case 0:
			if (position.Contains(current.mousePosition))
			{
				global::UnityEngine.GUIUtility.hotControl = id;
				global::UnityEngine.GUIUtility.keyboardControl = id;
				textEditor.MoveCursorToPosition(global::UnityEngine.Event.current.mousePosition);
				if (global::UnityEngine.Event.current.clickCount == 2 && global::EndAllTextSolution.skin.settings.doubleClickSelectsWord)
				{
					textEditor.SelectCurrentWord();
					textEditor.DblClickSnap(0);
					textEditor.MouseDragSelectsWholeWords(true);
				}
				if (global::UnityEngine.Event.current.clickCount == 3 && global::EndAllTextSolution.skin.settings.tripleClickSelectsLine)
				{
					textEditor.SelectCurrentParagraph();
					textEditor.MouseDragSelectsWholeWords(true);
					textEditor.DblClickSnap(1);
				}
				current.Use();
			}
			break;
		case 1:
			if (global::UnityEngine.GUIUtility.hotControl == id)
			{
				textEditor.MouseDragSelectsWholeWords(false);
				global::UnityEngine.GUIUtility.hotControl = 0;
				current.Use();
			}
			break;
		case 3:
			if (global::UnityEngine.GUIUtility.hotControl == id)
			{
				if (!current.shift)
				{
					textEditor.SelectToPosition(global::UnityEngine.Event.current.mousePosition);
				}
				else
				{
					textEditor.MoveCursorToPosition(global::UnityEngine.Event.current.mousePosition);
				}
				current.Use();
			}
			break;
		case 4:
			if (global::UnityEngine.GUIUtility.keyboardControl != id)
			{
				return;
			}
			if (textEditor.HandleKeyEvent(current))
			{
				current.Use();
				flag = true;
				content.text = textEditor.content.text;
			}
			else
			{
				if (current.keyCode == 9 || current.character == '\t')
				{
					return;
				}
				char character = current.character;
				if (character == '\n' && !multiline && !current.alt)
				{
					return;
				}
				global::UnityEngine.Font font = style.font;
				if (font == null)
				{
					font = global::EndAllTextSolution.skin.font;
				}
				if (font.HasCharacter(character) || character == '\n')
				{
					textEditor.Insert(character);
					flag = true;
				}
				else if (character == '\0')
				{
					if (global::UnityEngine.Input.compositionString.Length > 0)
					{
						textEditor.ReplaceSelection(string.Empty);
						flag = true;
					}
					current.Use();
				}
			}
			break;
		case 7:
			if (global::UnityEngine.GUIUtility.keyboardControl == id)
			{
				textEditor.DrawCursor(content.text);
			}
			else
			{
				style.Draw(position, content, id, false);
			}
			break;
		}
		if (global::UnityEngine.GUIUtility.keyboardControl == id)
		{
			global::EndAllTextSolution.GUI2.textFieldInput = true;
		}
		if (flag)
		{
			global::EndAllTextSolution.changed = true;
			content.text = textEditor.content.text;
			if (maxLength >= 0 && content.text.Length > maxLength)
			{
				content.text = content.text.Substring(0, maxLength);
			}
			current.Use();
		}
	}

	// Token: 0x060041C4 RID: 16836 RVA: 0x000ED9D4 File Offset: 0x000EBBD4
	private void OnGUI()
	{
		int controlID = global::UnityEngine.GUIUtility.GetControlID(1);
		global::EndAllTextSolution.DoTextField(new global::UnityEngine.Rect(0f, 0f, (float)global::UnityEngine.Screen.width, 30f), controlID, this.content, this.multiLine, this.maxLength, this.styleName);
	}

	// Token: 0x04002265 RID: 8805
	public global::UnityEngine.GUIContent content = new global::UnityEngine.GUIContent();

	// Token: 0x04002266 RID: 8806
	[global::UnityEngine.SerializeField]
	private string styleName = "textfield";

	// Token: 0x04002267 RID: 8807
	[global::UnityEngine.SerializeField]
	private bool multiLine;

	// Token: 0x04002268 RID: 8808
	[global::UnityEngine.SerializeField]
	private int maxLength;

	// Token: 0x020007B7 RID: 1975
	private static class GUI2
	{
		// Token: 0x060041C5 RID: 16837 RVA: 0x000EDA28 File Offset: 0x000EBC28
		static GUI2()
		{
			global::System.Reflection.MethodInfo method = typeof(global::UnityEngine.GUIUtility).GetMethod("CheckOnGUI", global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.NonPublic);
			global::EndAllTextSolution.GUI2.CheckOnGUI = (global::EndAllTextSolution.VoidCall)global::System.Delegate.CreateDelegate(typeof(global::EndAllTextSolution.VoidCall), method);
			global::EndAllTextSolution.GUI2.textFieldInputProperty = typeof(global::UnityEngine.GUIUtility).GetProperty("textFieldInput", global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.NonPublic);
		}

		// Token: 0x17000C12 RID: 3090
		// (get) Token: 0x060041C6 RID: 16838 RVA: 0x000EDA98 File Offset: 0x000EBC98
		// (set) Token: 0x060041C7 RID: 16839 RVA: 0x000EDAAC File Offset: 0x000EBCAC
		public static bool textFieldInput
		{
			get
			{
				return (bool)global::EndAllTextSolution.GUI2.textFieldInputProperty.GetValue(null, null);
			}
			set
			{
				global::EndAllTextSolution.GUI2.textFieldInputProperty.SetValue(null, (!value) ? global::EndAllTextSolution.GUI2.boxed_false : global::EndAllTextSolution.GUI2.boxed_true, null);
			}
		}

		// Token: 0x04002269 RID: 8809
		public static readonly global::EndAllTextSolution.VoidCall CheckOnGUI;

		// Token: 0x0400226A RID: 8810
		private static readonly global::System.Reflection.PropertyInfo textFieldInputProperty;

		// Token: 0x0400226B RID: 8811
		private static readonly object boxed_true = true;

		// Token: 0x0400226C RID: 8812
		private static readonly object boxed_false = false;
	}

	// Token: 0x020007B8 RID: 1976
	// (Invoke) Token: 0x060041C9 RID: 16841
	private delegate void VoidCall();
}
