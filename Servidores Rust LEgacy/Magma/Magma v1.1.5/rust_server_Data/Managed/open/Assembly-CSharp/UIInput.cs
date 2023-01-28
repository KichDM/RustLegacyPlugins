using System;
using System.Collections.Generic;
using NGUIHack;
using UnityEngine;

// Token: 0x02000952 RID: 2386
[global::UnityEngine.AddComponentMenu("NGUI/UI/Input (Basic)")]
public class UIInput : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600511B RID: 20763 RVA: 0x001409A0 File Offset: 0x0013EBA0
	public UIInput()
	{
	}

	// Token: 0x17000F14 RID: 3860
	// (get) Token: 0x0600511C RID: 20764 RVA: 0x001409FC File Offset: 0x0013EBFC
	public string inputText
	{
		get
		{
			return this.mText;
		}
	}

	// Token: 0x17000F15 RID: 3861
	// (get) Token: 0x0600511D RID: 20765 RVA: 0x00140A04 File Offset: 0x0013EC04
	// (set) Token: 0x0600511E RID: 20766 RVA: 0x00140A0C File Offset: 0x0013EC0C
	public string text
	{
		get
		{
			return this.mText;
		}
		set
		{
			value = (value ?? string.Empty);
			bool flag = (this.mText ?? string.Empty) != value;
			this.mText = value;
			if (this.label != null)
			{
				if (value != string.Empty)
				{
					value = this.mDefaultText;
				}
				this.label.supportEncoding = false;
				this.label.showLastPasswordChar = this.selected;
				this.label.color = ((!this.selected && !(value != this.mDefaultText)) ? this.mDefaultColor : this.activeColor);
				if (flag)
				{
					this.UpdateLabel();
				}
			}
		}
	}

	// Token: 0x17000F16 RID: 3862
	// (get) Token: 0x0600511F RID: 20767 RVA: 0x00140AD4 File Offset: 0x0013ECD4
	// (set) Token: 0x06005120 RID: 20768 RVA: 0x00140AE8 File Offset: 0x0013ECE8
	public bool selected
	{
		get
		{
			return global::UICamera.selectedObject == base.gameObject;
		}
		set
		{
			if (!value && global::UICamera.selectedObject == base.gameObject)
			{
				global::UICamera.selectedObject = null;
			}
			else if (value)
			{
				global::UICamera.selectedObject = base.gameObject;
			}
		}
	}

	// Token: 0x06005121 RID: 20769 RVA: 0x00140B2C File Offset: 0x0013ED2C
	protected void Init()
	{
		if (this.label == null)
		{
			this.label = base.GetComponentInChildren<global::UILabel>();
		}
		if (this.label != null)
		{
			this.mDefaultText = this.label.text;
			this.mDefaultColor = this.label.color;
			this.label.supportEncoding = false;
		}
	}

	// Token: 0x06005122 RID: 20770 RVA: 0x00140B98 File Offset: 0x0013ED98
	private void Awake()
	{
		this.markups = new global::System.Collections.Generic.List<global::UITextMarkup>();
		this.Init();
	}

	// Token: 0x06005123 RID: 20771 RVA: 0x00140BAC File Offset: 0x0013EDAC
	private void OnEnable()
	{
		if (global::UICamera.IsHighlighted(base.gameObject))
		{
			this.OnSelect(true);
		}
	}

	// Token: 0x06005124 RID: 20772 RVA: 0x00140BC8 File Offset: 0x0013EDC8
	private void OnDisable()
	{
		if (global::UICamera.IsHighlighted(base.gameObject))
		{
			this.OnSelect(false);
		}
	}

	// Token: 0x06005125 RID: 20773 RVA: 0x00140BE4 File Offset: 0x0013EDE4
	private void OnSelect(bool isSelected)
	{
		if (this.label != null && base.enabled && base.gameObject.activeInHierarchy)
		{
			if (isSelected)
			{
				this.mText = ((!(this.label.text == this.mDefaultText)) ? this.label.text : string.Empty);
				this.label.color = this.activeColor;
				if (this.isPassword)
				{
					this.label.password = true;
				}
				global::UnityEngine.Transform cachedTransform = this.label.cachedTransform;
				global::UnityEngine.Vector3 vector = this.label.pivotOffset;
				vector.y += this.label.relativeSize.y;
				vector = cachedTransform.TransformPoint(vector);
				this.UpdateLabel();
			}
			else
			{
				if (string.IsNullOrEmpty(this.mText))
				{
					this.label.text = this.mDefaultText;
					this.label.color = this.mDefaultColor;
					if (this.isPassword)
					{
						this.label.password = false;
					}
				}
				else
				{
					this.label.text = this.mText;
				}
				this.label.showLastPasswordChar = false;
			}
		}
	}

	// Token: 0x06005126 RID: 20774 RVA: 0x00140D40 File Offset: 0x0013EF40
	internal void OnEvent(global::UICamera camera, global::NGUIHack.Event @event, global::UnityEngine.EventType type)
	{
		switch (type)
		{
		case 0:
			if (@event.button == 0)
			{
				global::UIUnityEvents.TextClickDown(camera, this, @event, this.label);
			}
			break;
		case 1:
			if (@event.button == 0)
			{
				global::UIUnityEvents.TextClickUp(camera, this, @event, this.label);
			}
			else
			{
				global::UnityEngine.Debug.Log("Wee");
			}
			break;
		case 3:
			if (@event.button == 0)
			{
				global::UIUnityEvents.TextDrag(camera, this, @event, this.label);
			}
			break;
		case 4:
			global::UIUnityEvents.TextKeyDown(camera, this, @event, this.label);
			break;
		case 5:
			global::UIUnityEvents.TextKeyUp(camera, this, @event, this.label);
			break;
		}
	}

	// Token: 0x06005127 RID: 20775 RVA: 0x00140E04 File Offset: 0x0013F004
	public bool RequestKeyboardFocus()
	{
		return global::UIUnityEvents.RequestKeyboardFocus(this);
	}

	// Token: 0x06005128 RID: 20776 RVA: 0x00140E0C File Offset: 0x0013F00C
	private void Update()
	{
	}

	// Token: 0x06005129 RID: 20777 RVA: 0x00140E10 File Offset: 0x0013F010
	public bool SendSubmitMessage()
	{
		if (this.eventReceiver == null)
		{
			this.eventReceiver = base.gameObject;
		}
		string a = this.mText;
		this.eventReceiver.SendMessage(this.functionName, 1);
		return a != this.mText;
	}

	// Token: 0x0600512A RID: 20778 RVA: 0x00140E60 File Offset: 0x0013F060
	internal void UpdateLabel()
	{
		if (this.maxChars > 0 && this.mText.Length > this.maxChars)
		{
			this.mText = this.mText.Substring(0, this.maxChars);
		}
		if (this.label.font != null)
		{
			string text;
			if (this.selected)
			{
				text = this.mText + this.mLastIME;
			}
			else
			{
				text = this.mText;
			}
			this.label.supportEncoding = false;
			text = this.label.font.WrapText(this.markups, text, (float)this.label.lineWidth / this.label.cachedTransform.localScale.x, 0, false, global::UIFont.SymbolStyle.None);
			this.markups.SortMarkup();
			this.label.text = text;
			this.label.showLastPasswordChar = this.selected;
		}
	}

	// Token: 0x0600512B RID: 20779 RVA: 0x00140F5C File Offset: 0x0013F15C
	internal void CheckPositioning(int carratPos, int selectPos)
	{
		this.label.selection = this.label.ConvertUnprocessedSelection(carratPos, selectPos);
	}

	// Token: 0x0600512C RID: 20780 RVA: 0x00140F78 File Offset: 0x0013F178
	internal string CheckChanges(string newText)
	{
		if (this.mText != newText)
		{
			this.mText = newText;
			this.UpdateLabel();
			return this.mText;
		}
		return this.mText;
	}

	// Token: 0x0600512D RID: 20781 RVA: 0x00140FA8 File Offset: 0x0013F1A8
	internal void LoseFocus()
	{
		global::UIUnityEvents.TextLostFocus(this);
	}

	// Token: 0x0600512E RID: 20782 RVA: 0x00140FB0 File Offset: 0x0013F1B0
	internal void GainFocus()
	{
		global::UIUnityEvents.TextGainFocus(this);
	}

	// Token: 0x04002DD1 RID: 11729
	public static global::UIInput current;

	// Token: 0x04002DD2 RID: 11730
	public global::UILabel label;

	// Token: 0x04002DD3 RID: 11731
	public int maxChars;

	// Token: 0x04002DD4 RID: 11732
	public bool inputMultiline;

	// Token: 0x04002DD5 RID: 11733
	public global::UIInput.Validator validator;

	// Token: 0x04002DD6 RID: 11734
	public global::UIInput.KeyboardType type;

	// Token: 0x04002DD7 RID: 11735
	public bool isPassword;

	// Token: 0x04002DD8 RID: 11736
	public global::UnityEngine.Color activeColor = global::UnityEngine.Color.white;

	// Token: 0x04002DD9 RID: 11737
	public global::UnityEngine.GameObject eventReceiver;

	// Token: 0x04002DDA RID: 11738
	public string functionName = "OnSubmit";

	// Token: 0x04002DDB RID: 11739
	public bool trippleClickSelect = true;

	// Token: 0x04002DDC RID: 11740
	private global::System.Collections.Generic.List<global::UITextMarkup> markups;

	// Token: 0x04002DDD RID: 11741
	private string mText = string.Empty;

	// Token: 0x04002DDE RID: 11742
	private string mDefaultText = string.Empty;

	// Token: 0x04002DDF RID: 11743
	private global::UnityEngine.Color mDefaultColor = global::UnityEngine.Color.white;

	// Token: 0x04002DE0 RID: 11744
	private string mLastIME = string.Empty;

	// Token: 0x02000953 RID: 2387
	public enum KeyboardType
	{
		// Token: 0x04002DE2 RID: 11746
		Default,
		// Token: 0x04002DE3 RID: 11747
		ASCIICapable,
		// Token: 0x04002DE4 RID: 11748
		NumbersAndPunctuation,
		// Token: 0x04002DE5 RID: 11749
		URL,
		// Token: 0x04002DE6 RID: 11750
		NumberPad,
		// Token: 0x04002DE7 RID: 11751
		PhonePad,
		// Token: 0x04002DE8 RID: 11752
		NamePhonePad,
		// Token: 0x04002DE9 RID: 11753
		EmailAddress
	}

	// Token: 0x02000954 RID: 2388
	// (Invoke) Token: 0x06005130 RID: 20784
	public delegate char Validator(string currentText, char nextChar);
}
