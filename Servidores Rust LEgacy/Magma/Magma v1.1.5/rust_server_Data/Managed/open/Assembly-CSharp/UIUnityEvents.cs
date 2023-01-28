using System;
using System.Collections;
using System.Reflection;
using NGUIHack;
using UnityEngine;

// Token: 0x02000970 RID: 2416
[global::UnityEngine.AddComponentMenu("")]
public class UIUnityEvents : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600524C RID: 21068 RVA: 0x00151E30 File Offset: 0x00150030
	public UIUnityEvents()
	{
	}

	// Token: 0x0600524D RID: 21069 RVA: 0x00151E38 File Offset: 0x00150038
	// Note: this type is marked as 'beforefieldinit'.
	static UIUnityEvents()
	{
	}

	// Token: 0x0600524E RID: 21070 RVA: 0x00151E80 File Offset: 0x00150080
	public static void CameraCreated(global::UICamera camera)
	{
		if (global::UnityEngine.Application.isPlaying && !global::UIUnityEvents.LateLoaded.singleton)
		{
			global::UnityEngine.Debug.Log("singleton check failed.");
		}
	}

	// Token: 0x0600524F RID: 21071 RVA: 0x00151EA8 File Offset: 0x001500A8
	private void Awake()
	{
		base.useGUILayout = false;
	}

	// Token: 0x06005250 RID: 21072 RVA: 0x00151EB4 File Offset: 0x001500B4
	private void OnDestroy()
	{
		if (global::UIUnityEvents.madeSingleton && global::UIUnityEvents.LateLoaded.singleton == this)
		{
			global::UIUnityEvents.LateLoaded.singleton = null;
		}
	}

	// Token: 0x06005251 RID: 21073 RVA: 0x00151EE4 File Offset: 0x001500E4
	private static bool PerformOperation(global::UnityEngine.TextEditor te, global::UIUnityEvents.TextEditOp operation)
	{
		switch (operation)
		{
		case global::UIUnityEvents.TextEditOp.MoveLeft:
			te.MoveLeft();
			return false;
		case global::UIUnityEvents.TextEditOp.MoveRight:
			te.MoveRight();
			return false;
		case global::UIUnityEvents.TextEditOp.MoveUp:
			te.MoveUp();
			return false;
		case global::UIUnityEvents.TextEditOp.MoveDown:
			te.MoveDown();
			return false;
		case global::UIUnityEvents.TextEditOp.MoveLineStart:
			te.MoveLineStart();
			return false;
		case global::UIUnityEvents.TextEditOp.MoveLineEnd:
			te.MoveLineEnd();
			return false;
		case global::UIUnityEvents.TextEditOp.MoveTextStart:
			te.MoveTextStart();
			return false;
		case global::UIUnityEvents.TextEditOp.MoveTextEnd:
			te.MoveTextEnd();
			return false;
		case global::UIUnityEvents.TextEditOp.MoveGraphicalLineStart:
			te.MoveGraphicalLineStart();
			return false;
		case global::UIUnityEvents.TextEditOp.MoveGraphicalLineEnd:
			te.MoveGraphicalLineEnd();
			return false;
		case global::UIUnityEvents.TextEditOp.MoveWordLeft:
			te.MoveWordLeft();
			return false;
		case global::UIUnityEvents.TextEditOp.MoveWordRight:
			te.MoveWordRight();
			return false;
		case global::UIUnityEvents.TextEditOp.MoveParagraphForward:
			te.MoveParagraphForward();
			return false;
		case global::UIUnityEvents.TextEditOp.MoveParagraphBackward:
			te.MoveParagraphBackward();
			return false;
		case global::UIUnityEvents.TextEditOp.MoveToStartOfNextWord:
			te.MoveToStartOfNextWord();
			return false;
		case global::UIUnityEvents.TextEditOp.MoveToEndOfPreviousWord:
			te.MoveToEndOfPreviousWord();
			return false;
		case global::UIUnityEvents.TextEditOp.SelectLeft:
			te.SelectLeft();
			return false;
		case global::UIUnityEvents.TextEditOp.SelectRight:
			te.SelectRight();
			return false;
		case global::UIUnityEvents.TextEditOp.SelectUp:
			te.SelectUp();
			return false;
		case global::UIUnityEvents.TextEditOp.SelectDown:
			te.SelectDown();
			return false;
		case global::UIUnityEvents.TextEditOp.SelectTextStart:
			te.SelectTextStart();
			return false;
		case global::UIUnityEvents.TextEditOp.SelectTextEnd:
			te.SelectTextEnd();
			return false;
		case global::UIUnityEvents.TextEditOp.ExpandSelectGraphicalLineStart:
			te.ExpandSelectGraphicalLineStart();
			return false;
		case global::UIUnityEvents.TextEditOp.ExpandSelectGraphicalLineEnd:
			te.ExpandSelectGraphicalLineEnd();
			return false;
		case global::UIUnityEvents.TextEditOp.SelectGraphicalLineStart:
			te.SelectGraphicalLineStart();
			return false;
		case global::UIUnityEvents.TextEditOp.SelectGraphicalLineEnd:
			te.SelectGraphicalLineEnd();
			return false;
		case global::UIUnityEvents.TextEditOp.SelectWordLeft:
			te.SelectWordLeft();
			return false;
		case global::UIUnityEvents.TextEditOp.SelectWordRight:
			te.SelectWordRight();
			return false;
		case global::UIUnityEvents.TextEditOp.SelectToEndOfPreviousWord:
			te.SelectToEndOfPreviousWord();
			return false;
		case global::UIUnityEvents.TextEditOp.SelectToStartOfNextWord:
			te.SelectToStartOfNextWord();
			return false;
		case global::UIUnityEvents.TextEditOp.SelectParagraphBackward:
			te.SelectParagraphBackward();
			return false;
		case global::UIUnityEvents.TextEditOp.SelectParagraphForward:
			te.SelectParagraphForward();
			return false;
		case global::UIUnityEvents.TextEditOp.Delete:
			return te.Delete();
		case global::UIUnityEvents.TextEditOp.Backspace:
			return te.Backspace();
		case global::UIUnityEvents.TextEditOp.DeleteWordBack:
			return te.DeleteWordBack();
		case global::UIUnityEvents.TextEditOp.DeleteWordForward:
			return te.DeleteWordForward();
		case global::UIUnityEvents.TextEditOp.Cut:
			return te.Cut();
		case global::UIUnityEvents.TextEditOp.Copy:
			te.Copy();
			return false;
		case global::UIUnityEvents.TextEditOp.Paste:
			return te.Paste();
		case global::UIUnityEvents.TextEditOp.SelectAll:
			te.SelectAll();
			return false;
		case global::UIUnityEvents.TextEditOp.SelectNone:
			te.SelectNone();
			return false;
		}
		global::UnityEngine.Debug.Log("Unimplemented: " + operation);
		return false;
	}

	// Token: 0x06005252 RID: 21074 RVA: 0x00152178 File Offset: 0x00150378
	private static bool Perform(global::UnityEngine.TextEditor te, global::UIUnityEvents.TextEditOp operation)
	{
		return global::UIUnityEvents.PerformOperation(te, operation);
	}

	// Token: 0x06005253 RID: 21075 RVA: 0x00152190 File Offset: 0x00150390
	private static bool GetTextEditor(out global::UnityEngine.TextEditor te)
	{
		global::UIUnityEvents.submit = false;
		if (!global::UIUnityEvents.focusSetInOnGUI && global::UIUnityEvents.requiresBinding && global::UIUnityEvents.lastInput && global::UIUnityEvents.lastInputCamera)
		{
			global::UnityEngine.GUI.FocusControl("ngui-unityevents");
		}
		global::UIUnityEvents.Bind();
		te = (global::UnityEngine.GUIUtility.GetStateObject(typeof(global::UnityEngine.TextEditor), global::UIUnityEvents.controlID) as global::UnityEngine.TextEditor);
		if (global::UIUnityEvents.lastInput)
		{
			global::UnityEngine.GUIContent guicontent;
			if ((guicontent = global::UIUnityEvents.textInputContent) == null)
			{
				guicontent = (global::UIUnityEvents.textInputContent = new global::UnityEngine.GUIContent());
			}
			guicontent.text = global::UIUnityEvents.lastInput.inputText;
			te.content.text = global::UIUnityEvents.textInputContent.text;
			te.SaveBackup();
			te.position = global::UIUnityEvents.idRect;
			te.style = global::UIUnityEvents.textStyle;
			te.multiline = global::UIUnityEvents.lastInput.inputMultiline;
			te.controlID = global::UIUnityEvents.controlID;
			te.ClampPos();
			return true;
		}
		te = null;
		return false;
	}

	// Token: 0x06005254 RID: 21076 RVA: 0x00152294 File Offset: 0x00150494
	private static bool SetKeyboardControl()
	{
		global::UnityEngine.GUIUtility.keyboardControl = global::UIUnityEvents.controlID;
		return global::UnityEngine.GUIUtility.keyboardControl == global::UIUnityEvents.controlID;
	}

	// Token: 0x06005255 RID: 21077 RVA: 0x001522AC File Offset: 0x001504AC
	private static bool GetKeyboardControl()
	{
		int keyboardControl = global::UnityEngine.GUIUtility.keyboardControl;
		return keyboardControl == global::UIUnityEvents.controlID;
	}

	// Token: 0x17000F75 RID: 3957
	// (get) Token: 0x06005256 RID: 21078 RVA: 0x001522D0 File Offset: 0x001504D0
	private static global::UnityEngine.GUIStyle textStyle
	{
		get
		{
			return global::UnityEngine.GUI.skin.textField;
		}
	}

	// Token: 0x06005257 RID: 21079 RVA: 0x001522DC File Offset: 0x001504DC
	private static bool TextEditorHandleEvent2(global::UnityEngine.Event e, global::UnityEngine.TextEditor te)
	{
		if (global::UIUnityEvents.LateLoaded.Keyactions.Contains(e))
		{
			global::UIUnityEvents.Perform(te, (global::UIUnityEvents.TextEditOp)global::System.Convert.ToInt32(global::UIUnityEvents.LateLoaded.Keyactions[e]));
			return true;
		}
		return false;
	}

	// Token: 0x06005258 RID: 21080 RVA: 0x00152314 File Offset: 0x00150514
	private static bool TextEditorHandleEvent(global::UnityEngine.Event e, global::UnityEngine.TextEditor te)
	{
		global::UnityEngine.EventModifiers modifiers = e.modifiers;
		if ((modifiers & 0x20) == 0x20)
		{
			try
			{
				e.modifiers = (modifiers & -0x21);
				return global::UIUnityEvents.TextEditorHandleEvent2(e, te);
			}
			finally
			{
				e.modifiers = modifiers;
			}
		}
		return global::UIUnityEvents.TextEditorHandleEvent2(e, te);
	}

	// Token: 0x06005259 RID: 21081 RVA: 0x0015237C File Offset: 0x0015057C
	private static void TextSharedEnd(bool changed, global::UnityEngine.TextEditor te, global::UnityEngine.Event @event)
	{
		if (global::UIUnityEvents.GetKeyboardControl())
		{
			global::UIUnityEvents.LateLoaded.textFieldInput = true;
		}
		if (changed || @event.type == 0xC)
		{
			if (global::UIUnityEvents.lastInput)
			{
				global::UIUnityEvents.textInputContent.text = te.content.text;
			}
			if (changed)
			{
				global::UnityEngine.GUI.changed = true;
				global::UIUnityEvents.lastInput.CheckChanges(global::UIUnityEvents.textInputContent.text);
				global::UIUnityEvents.lastInput.CheckPositioning(te.pos, te.selectPos);
				@event.Use();
			}
			else
			{
				global::UIUnityEvents.lastInput.CheckPositioning(te.pos, te.selectPos);
			}
		}
		if (global::UIUnityEvents.submit)
		{
			global::UIUnityEvents.submit = false;
			if (global::UIUnityEvents.lastInput.SendSubmitMessage())
			{
				@event.Use();
			}
		}
	}

	// Token: 0x0600525A RID: 21082 RVA: 0x00152450 File Offset: 0x00150650
	private static bool MoveTextPosition(global::UnityEngine.Event @event, global::UnityEngine.TextEditor te, ref global::UITextPosition res)
	{
		global::UIUnityEvents.lastTextPosition = res;
		if (res.valid)
		{
			te.pos = res.uniformPosition;
			if (!@event.shift)
			{
				te.selectPos = te.pos;
			}
			return true;
		}
		return false;
	}

	// Token: 0x0600525B RID: 21083 RVA: 0x0015249C File Offset: 0x0015069C
	private static bool SelectTextPosition(global::UnityEngine.Event @event, global::UnityEngine.TextEditor te, ref global::UITextPosition res)
	{
		global::UIUnityEvents.lastTextPosition = res;
		if (res.valid)
		{
			global::UIUnityEvents.lastCursorPosition = global::UIUnityEvents.textStyle.GetCursorPixelPosition(global::UIUnityEvents.idRect, global::UIUnityEvents.textInputContent, res.uniformPosition);
			te.SelectToPosition(global::UIUnityEvents.lastCursorPosition);
			return true;
		}
		return false;
	}

	// Token: 0x0600525C RID: 21084 RVA: 0x001524EC File Offset: 0x001506EC
	internal static void TextGainFocus(global::UIInput input)
	{
	}

	// Token: 0x0600525D RID: 21085 RVA: 0x001524F0 File Offset: 0x001506F0
	internal static void TextLostFocus(global::UIInput input)
	{
		if (input == global::UIUnityEvents.lastInput)
		{
			if (global::UIUnityEvents.lastInputCamera && global::UICamera.selectedObject == input)
			{
				global::UICamera.selectedObject = null;
			}
			global::UIUnityEvents.lastInput = null;
			global::UIUnityEvents.lastInputCamera = null;
			global::UIUnityEvents.lastLabel = null;
		}
	}

	// Token: 0x0600525E RID: 21086 RVA: 0x00152544 File Offset: 0x00150744
	internal static void TextClickDown(global::UICamera camera, global::UIInput input, global::NGUIHack.Event @event, global::UILabel label)
	{
		global::UIUnityEvents.TextClickDown(camera, input, @event.real, label);
	}

	// Token: 0x0600525F RID: 21087 RVA: 0x00152554 File Offset: 0x00150754
	private static void ChangeFocus(global::UICamera camera, global::UIInput input, global::UILabel label)
	{
		bool flag = global::UIUnityEvents.lastInput != input;
		if (flag)
		{
			global::UIUnityEvents.lastInput = input;
			global::UIUnityEvents.textInputContent = null;
			global::UIUnityEvents.requiresBinding = input;
			global::UIUnityEvents.focusSetInOnGUI = global::UIUnityEvents.inOnGUI;
		}
		global::UIUnityEvents.lastInputCamera = camera;
		global::UIUnityEvents.lastLabel = label;
	}

	// Token: 0x06005260 RID: 21088 RVA: 0x001525A0 File Offset: 0x001507A0
	private static void Bind()
	{
		if (global::UIUnityEvents.requiresBinding && global::UIUnityEvents.lastInput && global::UIUnityEvents.lastInputCamera)
		{
			global::UIUnityEvents.SetKeyboardControl();
			global::UIUnityEvents.requiresBinding = false;
			global::UIUnityEvents.focusSetInOnGUI = true;
		}
	}

	// Token: 0x06005261 RID: 21089 RVA: 0x001525E8 File Offset: 0x001507E8
	private static void TextClickDown(global::UICamera camera, global::UIInput input, global::UnityEngine.Event @event, global::UILabel label)
	{
		global::UITextPosition uitextPosition = (!@event.shift) ? camera.RaycastText(global::UnityEngine.Input.mousePosition, label) : default(global::UITextPosition);
		global::UnityEngine.TextEditor textEditor = null;
		global::UIUnityEvents.ChangeFocus(camera, input, label);
		if (!global::UIUnityEvents.GetTextEditor(out textEditor))
		{
			global::UnityEngine.Debug.LogError("Null Text Editor");
		}
		else
		{
			global::UnityEngine.GUIUtility.hotControl = global::UIUnityEvents.controlID;
			global::UIUnityEvents.SetKeyboardControl();
			global::UIUnityEvents.MoveTextPosition(@event, textEditor, ref uitextPosition);
			int clickCount = @event.clickCount;
			if (clickCount != 2)
			{
				if (clickCount == 3)
				{
					if (input.trippleClickSelect)
					{
						textEditor.SelectCurrentParagraph();
						textEditor.MouseDragSelectsWholeWords(true);
						textEditor.DblClickSnap(1);
					}
				}
			}
			else
			{
				textEditor.SelectCurrentWord();
				textEditor.DblClickSnap(0);
				textEditor.MouseDragSelectsWholeWords(true);
			}
			@event.Use();
		}
		global::UIUnityEvents.TextSharedEnd(false, textEditor, @event);
	}

	// Token: 0x06005262 RID: 21090 RVA: 0x001526C0 File Offset: 0x001508C0
	internal static void TextClickUp(global::UICamera camera, global::UIInput input, global::NGUIHack.Event @event, global::UILabel label)
	{
		global::UIUnityEvents.TextClickUp(camera, input, @event.real, label);
	}

	// Token: 0x06005263 RID: 21091 RVA: 0x001526D0 File Offset: 0x001508D0
	private static void TextClickUp(global::UICamera camera, global::UIInput input, global::UnityEngine.Event @event, global::UILabel label)
	{
		if (input == global::UIUnityEvents.lastInput && camera == global::UIUnityEvents.lastInputCamera)
		{
			global::UIUnityEvents.lastLabel = label;
			global::UnityEngine.TextEditor textEditor = null;
			if (!global::UIUnityEvents.GetTextEditor(out textEditor))
			{
				return;
			}
			if (global::UIUnityEvents.controlID == global::UnityEngine.GUIUtility.hotControl)
			{
				textEditor.MouseDragSelectsWholeWords(false);
				global::UnityEngine.GUIUtility.hotControl = 0;
				@event.Use();
				global::UIUnityEvents.SetKeyboardControl();
			}
			else
			{
				global::UnityEngine.Debug.Log(string.Concat(new object[]
				{
					"Did not match ",
					global::UIUnityEvents.controlID,
					" ",
					global::UnityEngine.GUIUtility.hotControl
				}));
			}
			global::UIUnityEvents.TextSharedEnd(false, textEditor, @event);
		}
	}

	// Token: 0x06005264 RID: 21092 RVA: 0x00152784 File Offset: 0x00150984
	internal static void TextDrag(global::UICamera camera, global::UIInput input, global::NGUIHack.Event @event, global::UILabel label)
	{
		global::UIUnityEvents.TextDrag(camera, input, @event.real, label);
	}

	// Token: 0x06005265 RID: 21093 RVA: 0x00152794 File Offset: 0x00150994
	private static void TextDrag(global::UICamera camera, global::UIInput input, global::UnityEngine.Event @event, global::UILabel label)
	{
		if (input == global::UIUnityEvents.lastInput && camera == global::UIUnityEvents.lastInputCamera)
		{
			global::UIUnityEvents.lastLabel = label;
			global::UnityEngine.TextEditor te = null;
			if (!global::UIUnityEvents.GetTextEditor(out te))
			{
				return;
			}
			if (global::UIUnityEvents.controlID == global::UnityEngine.GUIUtility.hotControl)
			{
				global::UITextPosition uitextPosition = camera.RaycastText(global::UnityEngine.Input.mousePosition, label);
				if (!@event.shift)
				{
					global::UIUnityEvents.SelectTextPosition(@event, te, ref uitextPosition);
				}
				else
				{
					global::UIUnityEvents.MoveTextPosition(@event, te, ref uitextPosition);
				}
				@event.Use();
			}
			global::UIUnityEvents.TextSharedEnd(false, te, @event);
		}
	}

	// Token: 0x06005266 RID: 21094 RVA: 0x00152824 File Offset: 0x00150A24
	internal static void TextKeyUp(global::UICamera camera, global::UIInput input, global::NGUIHack.Event @event, global::UILabel label)
	{
		global::UIUnityEvents.TextKeyUp(camera, input, @event.real, label);
	}

	// Token: 0x06005267 RID: 21095 RVA: 0x00152834 File Offset: 0x00150A34
	private static void TextKeyUp(global::UICamera camera, global::UIInput input, global::UnityEngine.Event @event, global::UILabel label)
	{
		if (input == global::UIUnityEvents.lastInput && camera == global::UIUnityEvents.lastInputCamera)
		{
			global::UIUnityEvents.lastLabel = label;
			global::UnityEngine.TextEditor te = null;
			if (!global::UIUnityEvents.GetTextEditor(out te))
			{
				return;
			}
			global::UIUnityEvents.TextSharedEnd(false, te, @event);
		}
	}

	// Token: 0x06005268 RID: 21096 RVA: 0x00152880 File Offset: 0x00150A80
	internal static void TextKeyDown(global::UICamera camera, global::UIInput input, global::NGUIHack.Event @event, global::UILabel label)
	{
		global::UIUnityEvents.TextKeyDown(camera, input, @event.real, label);
	}

	// Token: 0x06005269 RID: 21097 RVA: 0x00152890 File Offset: 0x00150A90
	private static void TextKeyDown(global::UICamera camera, global::UIInput input, global::UnityEngine.Event @event, global::UILabel label)
	{
		if (input == global::UIUnityEvents.lastInput && camera == global::UIUnityEvents.lastInputCamera)
		{
			global::UIUnityEvents.lastLabel = label;
			global::UnityEngine.TextEditor textEditor = null;
			if (!global::UIUnityEvents.GetTextEditor(out textEditor))
			{
				return;
			}
			if (!global::UIUnityEvents.GetKeyboardControl())
			{
				global::UnityEngine.Debug.Log("Did not " + @event);
				return;
			}
			bool changed = false;
			if (global::UIUnityEvents.TextEditorHandleEvent(@event, textEditor))
			{
				@event.Use();
				changed = true;
			}
			else
			{
				global::UnityEngine.KeyCode keyCode = @event.keyCode;
				if (keyCode == 9)
				{
					return;
				}
				if (keyCode == null)
				{
					char character = @event.character;
					if (character == '\t')
					{
						return;
					}
					bool flag = character == '\n';
					global::BMFont bmFont;
					if (flag && !input.inputMultiline && !@event.alt)
					{
						global::UIUnityEvents.submit = true;
					}
					else if (label.font && (bmFont = label.font.bmFont) != null)
					{
						if (flag || (character != '\0' && bmFont.ContainsGlyph((int)character)))
						{
							textEditor.Insert(character);
							changed = true;
						}
						else if (character == '\0')
						{
							if (global::UnityEngine.Input.compositionString.Length > 0)
							{
								textEditor.ReplaceSelection(string.Empty);
								changed = true;
							}
							@event.Use();
						}
					}
				}
			}
			global::UIUnityEvents.TextSharedEnd(changed, textEditor, @event);
		}
	}

	// Token: 0x0600526A RID: 21098 RVA: 0x001529DC File Offset: 0x00150BDC
	internal static bool RequestKeyboardFocus(global::UIInput input)
	{
		if (input == global::UIUnityEvents.lastInput)
		{
			return true;
		}
		if (global::UIUnityEvents.lastInput)
		{
			return false;
		}
		if (!input.label || !input.label.enabled)
		{
			return false;
		}
		int layer = input.label.gameObject.layer;
		global::UICamera uicamera = global::UICamera.FindCameraForLayer(layer);
		if (!uicamera)
		{
			return false;
		}
		if (uicamera.SetKeyboardFocus(input))
		{
			global::UIUnityEvents.ChangeFocus(uicamera, input, input.label);
			return true;
		}
		return false;
	}

	// Token: 0x17000F76 RID: 3958
	// (get) Token: 0x0600526B RID: 21099 RVA: 0x00152A70 File Offset: 0x00150C70
	public static bool shouldBlockButtonInput
	{
		get
		{
			return global::UIUnityEvents.lastInput;
		}
	}

	// Token: 0x0600526C RID: 21100 RVA: 0x00152A7C File Offset: 0x00150C7C
	private void OnGUI()
	{
		try
		{
			global::UIUnityEvents.inOnGUI = true;
			global::UnityEngine.GUI.depth = 0x31;
			global::UIUnityEvents.blankID = global::UnityEngine.GUIUtility.GetControlID(1);
			global::UnityEngine.GUI.SetNextControlName("ngui-unityevents");
			global::UIUnityEvents.controlID = global::UnityEngine.GUIUtility.GetControlID(1);
			global::UnityEngine.GUI.color = global::UnityEngine.Color.clear;
			global::UnityEngine.Event current = global::UnityEngine.Event.current;
			global::UnityEngine.EventType type = current.type;
			if (type == 2)
			{
				global::UnityEngine.Debug.Log("Mouse Move");
			}
			switch (type)
			{
			case 0:
				if (!global::UIUnityEvents.forbidHandlingNewEvents)
				{
					bool flag = current.button == 0;
					using (global::NGUIHack.Event @event = new global::NGUIHack.Event(current))
					{
						global::UICamera.HandleEvent(@event, type);
					}
					if (flag && current.type == 0xC && global::UnityEngine.GUIUtility.hotControl == 0)
					{
						global::UnityEngine.GUIUtility.hotControl = global::UIUnityEvents.blankID;
					}
				}
				break;
			case 1:
			{
				bool flag2 = current.button == 0;
				using (global::NGUIHack.Event event2 = new global::NGUIHack.Event(current))
				{
					global::UICamera.HandleEvent(event2, type);
				}
				if (flag2 && global::UnityEngine.GUIUtility.hotControl == global::UIUnityEvents.blankID)
				{
					global::UnityEngine.GUIUtility.hotControl = 0;
				}
				break;
			}
			case 2:
			case 3:
			case 5:
			case 6:
				using (global::NGUIHack.Event event3 = new global::NGUIHack.Event(current))
				{
					global::UICamera.HandleEvent(event3, type);
				}
				break;
			case 4:
				if (!global::UIUnityEvents.forbidHandlingNewEvents)
				{
					using (global::NGUIHack.Event event4 = new global::NGUIHack.Event(current))
					{
						global::UICamera.HandleEvent(event4, type);
					}
				}
				break;
			case 7:
				if (!global::UIUnityEvents.forbidHandlingNewEvents && global::UIUnityEvents.lastMousePosition != current.mousePosition)
				{
					global::UIUnityEvents.lastMousePosition = current.mousePosition;
					using (global::NGUIHack.Event event5 = new global::NGUIHack.Event(current, 2))
					{
						global::UICamera.HandleEvent(event5, 2);
					}
				}
				break;
			case 0xC:
				global::UnityEngine.Debug.Log("Used");
				return;
			}
			if (type == 7)
			{
			}
		}
		finally
		{
			global::UIUnityEvents.inOnGUI = false;
		}
	}

	// Token: 0x04002E9F RID: 11935
	private const int idLoop = 0x12C;

	// Token: 0x04002EA0 RID: 11936
	private const int controlIDHint = 0x1317BFA4;

	// Token: 0x04002EA1 RID: 11937
	private const string kControlName = "ngui-unityevents";

	// Token: 0x04002EA2 RID: 11938
	private const int kGUIDepth = 0x31;

	// Token: 0x04002EA3 RID: 11939
	public static bool forbidHandlingNewEvents;

	// Token: 0x04002EA4 RID: 11940
	private global::UIInput mInput;

	// Token: 0x04002EA5 RID: 11941
	private global::UICamera mCamera;

	// Token: 0x04002EA6 RID: 11942
	private static bool madeSingleton;

	// Token: 0x04002EA7 RID: 11943
	private static readonly global::UnityEngine.Rect idRect = new global::UnityEngine.Rect(0f, 0f, 69999f, 69999f);

	// Token: 0x04002EA8 RID: 11944
	private static int controlID;

	// Token: 0x04002EA9 RID: 11945
	private static global::UIInput lastInput;

	// Token: 0x04002EAA RID: 11946
	private static global::UILabel lastLabel;

	// Token: 0x04002EAB RID: 11947
	private static global::UICamera lastInputCamera;

	// Token: 0x04002EAC RID: 11948
	private static bool submit;

	// Token: 0x04002EAD RID: 11949
	private static global::UnityEngine.GUIContent textInputContent = null;

	// Token: 0x04002EAE RID: 11950
	private static global::UnityEngine.Vector2 lastCursorPosition;

	// Token: 0x04002EAF RID: 11951
	private static global::UITextPosition lastTextPosition;

	// Token: 0x04002EB0 RID: 11952
	private static bool requiresBinding;

	// Token: 0x04002EB1 RID: 11953
	private static bool focusSetInOnGUI;

	// Token: 0x04002EB2 RID: 11954
	private static global::UnityEngine.Vector2 lastMousePosition = new global::UnityEngine.Vector2(-100f, -100f);

	// Token: 0x04002EB3 RID: 11955
	private static int blankID;

	// Token: 0x04002EB4 RID: 11956
	private static bool inOnGUI;

	// Token: 0x02000971 RID: 2417
	private static class LateLoaded
	{
		// Token: 0x0600526D RID: 21101 RVA: 0x00152D3C File Offset: 0x00150F3C
		static LateLoaded()
		{
			global::UIUnityEvents.LateLoaded.mTextBlockStyle.alignment = 0;
			global::UIUnityEvents.LateLoaded.mTextBlockStyle.border = new global::UnityEngine.RectOffset(0, 0, 0, 0);
			global::UIUnityEvents.LateLoaded.mTextBlockStyle.clipping = 0;
			global::UIUnityEvents.LateLoaded.mTextBlockStyle.contentOffset = default(global::UnityEngine.Vector2);
			global::UIUnityEvents.LateLoaded.mTextBlockStyle.fixedWidth = -1f;
			global::UIUnityEvents.LateLoaded.mTextBlockStyle.fixedHeight = -1f;
			global::UIUnityEvents.LateLoaded.mTextBlockStyle.imagePosition = 3;
			global::UIUnityEvents.LateLoaded.mTextBlockStyle.margin = new global::UnityEngine.RectOffset(0, 0, 0, 0);
			global::UIUnityEvents.LateLoaded.mTextBlockStyle.name = "BLOCK STYLE";
			global::UIUnityEvents.LateLoaded.mTextBlockStyle.overflow = new global::UnityEngine.RectOffset(0, 0, 0, 0);
			global::UIUnityEvents.LateLoaded.mTextBlockStyle.padding = new global::UnityEngine.RectOffset(0, 0, 0, 0);
			global::UIUnityEvents.LateLoaded.mTextBlockStyle.stretchHeight = false;
			global::UIUnityEvents.LateLoaded.mTextBlockStyle.stretchWidth = false;
			global::UIUnityEvents.LateLoaded.mTextBlockStyle.wordWrap = false;
			global::UnityEngine.GUIStyleState guistyleState = new global::UnityEngine.GUIStyleState();
			guistyleState.background = null;
			guistyleState.textColor = global::UnityEngine.Color.clear;
			global::UIUnityEvents.LateLoaded.mTextBlockStyle.active = guistyleState;
			global::UIUnityEvents.LateLoaded.mTextBlockStyle.focused = guistyleState;
			global::UIUnityEvents.LateLoaded.mTextBlockStyle.hover = guistyleState;
			global::UIUnityEvents.LateLoaded.mTextBlockStyle.normal = guistyleState;
			global::UIUnityEvents.LateLoaded.mTextBlockStyle.onActive = guistyleState;
			global::UIUnityEvents.LateLoaded.mTextBlockStyle.onFocused = guistyleState;
			global::UIUnityEvents.LateLoaded.mTextBlockStyle.onHover = guistyleState;
			global::UIUnityEvents.LateLoaded.mTextBlockStyle.onNormal = guistyleState;
			global::UIUnityEvents.LateLoaded._textFieldInput = typeof(global::UnityEngine.GUIUtility).GetProperty("textFieldInput", global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.NonPublic);
			if (global::UIUnityEvents.LateLoaded._textFieldInput == null)
			{
				global::UIUnityEvents.LateLoaded.failedInvokeTextFieldInputGet = true;
				global::UIUnityEvents.LateLoaded.failedInvokeTextFieldInputSet = true;
				global::UnityEngine.Debug.LogError("Unity has changed. no bool property textFieldInput in GUIUtility");
			}
			global::UnityEngine.GameObject gameObject = new global::UnityEngine.GameObject("__UIUnityEvents", new global::System.Type[]
			{
				typeof(global::UIUnityEvents)
			});
			global::UIUnityEvents.LateLoaded.singleton = gameObject.GetComponent<global::UIUnityEvents>();
			global::UIUnityEvents.madeSingleton = true;
			global::UnityEngine.Object.DontDestroyOnLoad(gameObject);
			global::UnityEngine.TextEditor textEditor = null;
			if (textEditor != null)
			{
				global::UnityEngine.Debug.Log("Thats imposible.");
			}
			try
			{
				global::System.Reflection.MethodInfo method = typeof(global::UnityEngine.TextEditor).GetMethod("InitKeyActions", global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.NonPublic);
				if (method == null)
				{
					throw new global::System.MethodAccessException("Unity has changed. no InitKeyActions member in TextEditor");
				}
				method.Invoke(new global::UnityEngine.TextEditor(), new object[0]);
				object obj = typeof(global::UnityEngine.TextEditor).InvokeMember("s_Keyactions", global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.NonPublic | global::System.Reflection.BindingFlags.GetField, null, null, new object[0]);
				if (obj is global::System.Collections.Hashtable)
				{
					global::UIUnityEvents.LateLoaded.Keyactions = (global::System.Collections.Hashtable)obj;
				}
				else
				{
					if (!(obj is global::System.Collections.IDictionary))
					{
						throw new global::System.MethodAccessException("Unity has changed. no s_Keyactions member in TextEditor");
					}
					global::UIUnityEvents.LateLoaded.Keyactions = new global::System.Collections.Hashtable(obj as global::System.Collections.IDictionary);
				}
			}
			catch (global::System.MethodAccessException arg)
			{
				global::UnityEngine.Debug.Log("Caught exception \r\n" + arg + "\r\nManually building keyactions.");
				global::UIUnityEvents.LateLoaded.Keyactions = new global::System.Collections.Hashtable();
				global::UIUnityEvents.LateLoaded.MapKey("left", global::UIUnityEvents.TextEditOp.MoveLeft);
				global::UIUnityEvents.LateLoaded.MapKey("right", global::UIUnityEvents.TextEditOp.MoveRight);
				global::UIUnityEvents.LateLoaded.MapKey("up", global::UIUnityEvents.TextEditOp.MoveUp);
				global::UIUnityEvents.LateLoaded.MapKey("down", global::UIUnityEvents.TextEditOp.MoveDown);
				global::UIUnityEvents.LateLoaded.MapKey("#left", global::UIUnityEvents.TextEditOp.SelectLeft);
				global::UIUnityEvents.LateLoaded.MapKey("#right", global::UIUnityEvents.TextEditOp.SelectRight);
				global::UIUnityEvents.LateLoaded.MapKey("#up", global::UIUnityEvents.TextEditOp.SelectUp);
				global::UIUnityEvents.LateLoaded.MapKey("#down", global::UIUnityEvents.TextEditOp.SelectDown);
				global::UIUnityEvents.LateLoaded.MapKey("delete", global::UIUnityEvents.TextEditOp.Delete);
				global::UIUnityEvents.LateLoaded.MapKey("backspace", global::UIUnityEvents.TextEditOp.Backspace);
				global::UIUnityEvents.LateLoaded.MapKey("#backspace", global::UIUnityEvents.TextEditOp.Backspace);
				if (global::UnityEngine.Application.platform != 2 && global::UnityEngine.Application.platform != 5 && global::UnityEngine.Application.platform != 7)
				{
					global::UIUnityEvents.LateLoaded.MapKey("^left", global::UIUnityEvents.TextEditOp.MoveGraphicalLineStart);
					global::UIUnityEvents.LateLoaded.MapKey("^right", global::UIUnityEvents.TextEditOp.MoveGraphicalLineEnd);
					global::UIUnityEvents.LateLoaded.MapKey("&left", global::UIUnityEvents.TextEditOp.MoveWordLeft);
					global::UIUnityEvents.LateLoaded.MapKey("&right", global::UIUnityEvents.TextEditOp.MoveWordRight);
					global::UIUnityEvents.LateLoaded.MapKey("&up", global::UIUnityEvents.TextEditOp.MoveParagraphBackward);
					global::UIUnityEvents.LateLoaded.MapKey("&down", global::UIUnityEvents.TextEditOp.MoveParagraphForward);
					global::UIUnityEvents.LateLoaded.MapKey("%left", global::UIUnityEvents.TextEditOp.MoveGraphicalLineStart);
					global::UIUnityEvents.LateLoaded.MapKey("%right", global::UIUnityEvents.TextEditOp.MoveGraphicalLineEnd);
					global::UIUnityEvents.LateLoaded.MapKey("%up", global::UIUnityEvents.TextEditOp.MoveTextStart);
					global::UIUnityEvents.LateLoaded.MapKey("%down", global::UIUnityEvents.TextEditOp.MoveTextEnd);
					global::UIUnityEvents.LateLoaded.MapKey("#home", global::UIUnityEvents.TextEditOp.SelectTextStart);
					global::UIUnityEvents.LateLoaded.MapKey("#end", global::UIUnityEvents.TextEditOp.SelectTextEnd);
					global::UIUnityEvents.LateLoaded.MapKey("#^left", global::UIUnityEvents.TextEditOp.ExpandSelectGraphicalLineStart);
					global::UIUnityEvents.LateLoaded.MapKey("#^right", global::UIUnityEvents.TextEditOp.ExpandSelectGraphicalLineEnd);
					global::UIUnityEvents.LateLoaded.MapKey("#^up", global::UIUnityEvents.TextEditOp.SelectParagraphBackward);
					global::UIUnityEvents.LateLoaded.MapKey("#^down", global::UIUnityEvents.TextEditOp.SelectParagraphForward);
					global::UIUnityEvents.LateLoaded.MapKey("#&left", global::UIUnityEvents.TextEditOp.SelectWordLeft);
					global::UIUnityEvents.LateLoaded.MapKey("#&right", global::UIUnityEvents.TextEditOp.SelectWordRight);
					global::UIUnityEvents.LateLoaded.MapKey("#&up", global::UIUnityEvents.TextEditOp.SelectParagraphBackward);
					global::UIUnityEvents.LateLoaded.MapKey("#&down", global::UIUnityEvents.TextEditOp.SelectParagraphForward);
					global::UIUnityEvents.LateLoaded.MapKey("#%left", global::UIUnityEvents.TextEditOp.ExpandSelectGraphicalLineStart);
					global::UIUnityEvents.LateLoaded.MapKey("#%right", global::UIUnityEvents.TextEditOp.ExpandSelectGraphicalLineEnd);
					global::UIUnityEvents.LateLoaded.MapKey("#%up", global::UIUnityEvents.TextEditOp.SelectTextStart);
					global::UIUnityEvents.LateLoaded.MapKey("#%down", global::UIUnityEvents.TextEditOp.SelectTextEnd);
					global::UIUnityEvents.LateLoaded.MapKey("%a", global::UIUnityEvents.TextEditOp.SelectAll);
					global::UIUnityEvents.LateLoaded.MapKey("%x", global::UIUnityEvents.TextEditOp.Cut);
					global::UIUnityEvents.LateLoaded.MapKey("%c", global::UIUnityEvents.TextEditOp.Copy);
					global::UIUnityEvents.LateLoaded.MapKey("%v", global::UIUnityEvents.TextEditOp.Paste);
					global::UIUnityEvents.LateLoaded.MapKey("^d", global::UIUnityEvents.TextEditOp.Delete);
					global::UIUnityEvents.LateLoaded.MapKey("^h", global::UIUnityEvents.TextEditOp.Backspace);
					global::UIUnityEvents.LateLoaded.MapKey("^b", global::UIUnityEvents.TextEditOp.MoveLeft);
					global::UIUnityEvents.LateLoaded.MapKey("^f", global::UIUnityEvents.TextEditOp.MoveRight);
					global::UIUnityEvents.LateLoaded.MapKey("^a", global::UIUnityEvents.TextEditOp.MoveLineStart);
					global::UIUnityEvents.LateLoaded.MapKey("^e", global::UIUnityEvents.TextEditOp.MoveLineEnd);
					global::UIUnityEvents.LateLoaded.MapKey("&delete", global::UIUnityEvents.TextEditOp.DeleteWordForward);
					global::UIUnityEvents.LateLoaded.MapKey("&backspace", global::UIUnityEvents.TextEditOp.DeleteWordBack);
				}
				else
				{
					global::UIUnityEvents.LateLoaded.MapKey("home", global::UIUnityEvents.TextEditOp.MoveGraphicalLineStart);
					global::UIUnityEvents.LateLoaded.MapKey("end", global::UIUnityEvents.TextEditOp.MoveGraphicalLineEnd);
					global::UIUnityEvents.LateLoaded.MapKey("%left", global::UIUnityEvents.TextEditOp.MoveWordLeft);
					global::UIUnityEvents.LateLoaded.MapKey("%right", global::UIUnityEvents.TextEditOp.MoveWordRight);
					global::UIUnityEvents.LateLoaded.MapKey("%up", global::UIUnityEvents.TextEditOp.MoveParagraphBackward);
					global::UIUnityEvents.LateLoaded.MapKey("%down", global::UIUnityEvents.TextEditOp.MoveParagraphForward);
					global::UIUnityEvents.LateLoaded.MapKey("^left", global::UIUnityEvents.TextEditOp.MoveToEndOfPreviousWord);
					global::UIUnityEvents.LateLoaded.MapKey("^right", global::UIUnityEvents.TextEditOp.MoveToStartOfNextWord);
					global::UIUnityEvents.LateLoaded.MapKey("^up", global::UIUnityEvents.TextEditOp.MoveParagraphBackward);
					global::UIUnityEvents.LateLoaded.MapKey("^down", global::UIUnityEvents.TextEditOp.MoveParagraphForward);
					global::UIUnityEvents.LateLoaded.MapKey("#^left", global::UIUnityEvents.TextEditOp.SelectToEndOfPreviousWord);
					global::UIUnityEvents.LateLoaded.MapKey("#^right", global::UIUnityEvents.TextEditOp.SelectToStartOfNextWord);
					global::UIUnityEvents.LateLoaded.MapKey("#^up", global::UIUnityEvents.TextEditOp.SelectParagraphBackward);
					global::UIUnityEvents.LateLoaded.MapKey("#^down", global::UIUnityEvents.TextEditOp.SelectParagraphForward);
					global::UIUnityEvents.LateLoaded.MapKey("#home", global::UIUnityEvents.TextEditOp.SelectGraphicalLineStart);
					global::UIUnityEvents.LateLoaded.MapKey("#end", global::UIUnityEvents.TextEditOp.SelectGraphicalLineEnd);
					global::UIUnityEvents.LateLoaded.MapKey("^delete", global::UIUnityEvents.TextEditOp.DeleteWordForward);
					global::UIUnityEvents.LateLoaded.MapKey("^backspace", global::UIUnityEvents.TextEditOp.DeleteWordBack);
					global::UIUnityEvents.LateLoaded.MapKey("^a", global::UIUnityEvents.TextEditOp.SelectAll);
					global::UIUnityEvents.LateLoaded.MapKey("^x", global::UIUnityEvents.TextEditOp.Cut);
					global::UIUnityEvents.LateLoaded.MapKey("^c", global::UIUnityEvents.TextEditOp.Copy);
					global::UIUnityEvents.LateLoaded.MapKey("^v", global::UIUnityEvents.TextEditOp.Paste);
					global::UIUnityEvents.LateLoaded.MapKey("#delete", global::UIUnityEvents.TextEditOp.Cut);
					global::UIUnityEvents.LateLoaded.MapKey("^insert", global::UIUnityEvents.TextEditOp.Copy);
					global::UIUnityEvents.LateLoaded.MapKey("#insert", global::UIUnityEvents.TextEditOp.Paste);
				}
			}
		}

		// Token: 0x17000F77 RID: 3959
		// (get) Token: 0x0600526E RID: 21102 RVA: 0x00153380 File Offset: 0x00151580
		// (set) Token: 0x0600526F RID: 21103 RVA: 0x001533F0 File Offset: 0x001515F0
		public static bool textFieldInput
		{
			get
			{
				if (!global::UIUnityEvents.LateLoaded.failedInvokeTextFieldInputGet)
				{
					try
					{
						return (bool)global::UIUnityEvents.LateLoaded._textFieldInput.GetValue(null, null);
					}
					catch (global::System.MethodAccessException arg)
					{
						global::UIUnityEvents.LateLoaded.failedInvokeTextFieldInputGet = true;
						global::UnityEngine.Debug.Log("Can not get GUIUtility.textFieldInput\r\n" + arg);
					}
					return false;
				}
				return false;
			}
			set
			{
				if (!global::UIUnityEvents.LateLoaded.failedInvokeTextFieldInputSet)
				{
					try
					{
						global::UIUnityEvents.LateLoaded._textFieldInput.SetValue(null, value, null);
					}
					catch (global::System.MethodAccessException arg)
					{
						global::UIUnityEvents.LateLoaded.failedInvokeTextFieldInputSet = true;
						global::UnityEngine.Debug.Log("Can not set GUIUtility.textFieldInput\r\n" + arg);
					}
				}
			}
		}

		// Token: 0x06005270 RID: 21104 RVA: 0x00153458 File Offset: 0x00151658
		private static void MapKey(string key, global::UIUnityEvents.TextEditOp action)
		{
			global::UIUnityEvents.LateLoaded.Keyactions[global::UnityEngine.Event.KeyboardEvent(key)] = action;
		}

		// Token: 0x04002EB5 RID: 11957
		public static readonly global::UnityEngine.GUIStyle mTextBlockStyle = new global::UnityEngine.GUIStyle();

		// Token: 0x04002EB6 RID: 11958
		private static readonly global::System.Reflection.PropertyInfo _textFieldInput;

		// Token: 0x04002EB7 RID: 11959
		public static global::UIUnityEvents singleton;

		// Token: 0x04002EB8 RID: 11960
		public static global::System.Collections.Hashtable Keyactions;

		// Token: 0x04002EB9 RID: 11961
		private static bool failedInvokeTextFieldInputGet;

		// Token: 0x04002EBA RID: 11962
		private static bool failedInvokeTextFieldInputSet;
	}

	// Token: 0x02000972 RID: 2418
	private enum TextEditOp
	{
		// Token: 0x04002EBC RID: 11964
		MoveLeft,
		// Token: 0x04002EBD RID: 11965
		MoveRight,
		// Token: 0x04002EBE RID: 11966
		MoveUp,
		// Token: 0x04002EBF RID: 11967
		MoveDown,
		// Token: 0x04002EC0 RID: 11968
		MoveLineStart,
		// Token: 0x04002EC1 RID: 11969
		MoveLineEnd,
		// Token: 0x04002EC2 RID: 11970
		MoveTextStart,
		// Token: 0x04002EC3 RID: 11971
		MoveTextEnd,
		// Token: 0x04002EC4 RID: 11972
		MovePageUp,
		// Token: 0x04002EC5 RID: 11973
		MovePageDown,
		// Token: 0x04002EC6 RID: 11974
		MoveGraphicalLineStart,
		// Token: 0x04002EC7 RID: 11975
		MoveGraphicalLineEnd,
		// Token: 0x04002EC8 RID: 11976
		MoveWordLeft,
		// Token: 0x04002EC9 RID: 11977
		MoveWordRight,
		// Token: 0x04002ECA RID: 11978
		MoveParagraphForward,
		// Token: 0x04002ECB RID: 11979
		MoveParagraphBackward,
		// Token: 0x04002ECC RID: 11980
		MoveToStartOfNextWord,
		// Token: 0x04002ECD RID: 11981
		MoveToEndOfPreviousWord,
		// Token: 0x04002ECE RID: 11982
		SelectLeft,
		// Token: 0x04002ECF RID: 11983
		SelectRight,
		// Token: 0x04002ED0 RID: 11984
		SelectUp,
		// Token: 0x04002ED1 RID: 11985
		SelectDown,
		// Token: 0x04002ED2 RID: 11986
		SelectTextStart,
		// Token: 0x04002ED3 RID: 11987
		SelectTextEnd,
		// Token: 0x04002ED4 RID: 11988
		SelectPageUp,
		// Token: 0x04002ED5 RID: 11989
		SelectPageDown,
		// Token: 0x04002ED6 RID: 11990
		ExpandSelectGraphicalLineStart,
		// Token: 0x04002ED7 RID: 11991
		ExpandSelectGraphicalLineEnd,
		// Token: 0x04002ED8 RID: 11992
		SelectGraphicalLineStart,
		// Token: 0x04002ED9 RID: 11993
		SelectGraphicalLineEnd,
		// Token: 0x04002EDA RID: 11994
		SelectWordLeft,
		// Token: 0x04002EDB RID: 11995
		SelectWordRight,
		// Token: 0x04002EDC RID: 11996
		SelectToEndOfPreviousWord,
		// Token: 0x04002EDD RID: 11997
		SelectToStartOfNextWord,
		// Token: 0x04002EDE RID: 11998
		SelectParagraphBackward,
		// Token: 0x04002EDF RID: 11999
		SelectParagraphForward,
		// Token: 0x04002EE0 RID: 12000
		Delete,
		// Token: 0x04002EE1 RID: 12001
		Backspace,
		// Token: 0x04002EE2 RID: 12002
		DeleteWordBack,
		// Token: 0x04002EE3 RID: 12003
		DeleteWordForward,
		// Token: 0x04002EE4 RID: 12004
		Cut,
		// Token: 0x04002EE5 RID: 12005
		Copy,
		// Token: 0x04002EE6 RID: 12006
		Paste,
		// Token: 0x04002EE7 RID: 12007
		SelectAll,
		// Token: 0x04002EE8 RID: 12008
		SelectNone,
		// Token: 0x04002EE9 RID: 12009
		ScrollStart,
		// Token: 0x04002EEA RID: 12010
		ScrollEnd,
		// Token: 0x04002EEB RID: 12011
		ScrollPageUp,
		// Token: 0x04002EEC RID: 12012
		ScrollPageDown
	}
}
