using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

// Token: 0x02000840 RID: 2112
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/Textbox")]
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.BoxCollider))]
public class dfTextbox : global::dfInteractiveBase, global::IDFMultiRender
{
	// Token: 0x0600489B RID: 18587 RVA: 0x0010E604 File Offset: 0x0010C804
	public dfTextbox()
	{
	}

	// Token: 0x14000054 RID: 84
	// (add) Token: 0x0600489C RID: 18588 RVA: 0x0010E6DC File Offset: 0x0010C8DC
	// (remove) Token: 0x0600489D RID: 18589 RVA: 0x0010E6F8 File Offset: 0x0010C8F8
	public event global::PropertyChangedEventHandler<bool> ReadOnlyChanged
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.ReadOnlyChanged = (global::PropertyChangedEventHandler<bool>)global::System.Delegate.Combine(this.ReadOnlyChanged, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.ReadOnlyChanged = (global::PropertyChangedEventHandler<bool>)global::System.Delegate.Remove(this.ReadOnlyChanged, value);
		}
	}

	// Token: 0x14000055 RID: 85
	// (add) Token: 0x0600489E RID: 18590 RVA: 0x0010E714 File Offset: 0x0010C914
	// (remove) Token: 0x0600489F RID: 18591 RVA: 0x0010E730 File Offset: 0x0010C930
	public event global::PropertyChangedEventHandler<string> PasswordCharacterChanged
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.PasswordCharacterChanged = (global::PropertyChangedEventHandler<string>)global::System.Delegate.Combine(this.PasswordCharacterChanged, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.PasswordCharacterChanged = (global::PropertyChangedEventHandler<string>)global::System.Delegate.Remove(this.PasswordCharacterChanged, value);
		}
	}

	// Token: 0x14000056 RID: 86
	// (add) Token: 0x060048A0 RID: 18592 RVA: 0x0010E74C File Offset: 0x0010C94C
	// (remove) Token: 0x060048A1 RID: 18593 RVA: 0x0010E768 File Offset: 0x0010C968
	public event global::PropertyChangedEventHandler<string> TextChanged
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.TextChanged = (global::PropertyChangedEventHandler<string>)global::System.Delegate.Combine(this.TextChanged, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.TextChanged = (global::PropertyChangedEventHandler<string>)global::System.Delegate.Remove(this.TextChanged, value);
		}
	}

	// Token: 0x14000057 RID: 87
	// (add) Token: 0x060048A2 RID: 18594 RVA: 0x0010E784 File Offset: 0x0010C984
	// (remove) Token: 0x060048A3 RID: 18595 RVA: 0x0010E7A0 File Offset: 0x0010C9A0
	public event global::PropertyChangedEventHandler<string> TextSubmitted
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.TextSubmitted = (global::PropertyChangedEventHandler<string>)global::System.Delegate.Combine(this.TextSubmitted, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.TextSubmitted = (global::PropertyChangedEventHandler<string>)global::System.Delegate.Remove(this.TextSubmitted, value);
		}
	}

	// Token: 0x14000058 RID: 88
	// (add) Token: 0x060048A4 RID: 18596 RVA: 0x0010E7BC File Offset: 0x0010C9BC
	// (remove) Token: 0x060048A5 RID: 18597 RVA: 0x0010E7D8 File Offset: 0x0010C9D8
	public event global::PropertyChangedEventHandler<string> TextCancelled
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.TextCancelled = (global::PropertyChangedEventHandler<string>)global::System.Delegate.Combine(this.TextCancelled, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.TextCancelled = (global::PropertyChangedEventHandler<string>)global::System.Delegate.Remove(this.TextCancelled, value);
		}
	}

	// Token: 0x17000D97 RID: 3479
	// (get) Token: 0x060048A6 RID: 18598 RVA: 0x0010E7F4 File Offset: 0x0010C9F4
	// (set) Token: 0x060048A7 RID: 18599 RVA: 0x0010E838 File Offset: 0x0010CA38
	public global::dfFontBase Font
	{
		get
		{
			if (this.font == null)
			{
				global::dfGUIManager manager = base.GetManager();
				if (manager != null)
				{
					this.font = manager.DefaultFont;
				}
			}
			return this.font;
		}
		set
		{
			if (value != this.font)
			{
				this.font = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D98 RID: 3480
	// (get) Token: 0x060048A8 RID: 18600 RVA: 0x0010E858 File Offset: 0x0010CA58
	// (set) Token: 0x060048A9 RID: 18601 RVA: 0x0010E860 File Offset: 0x0010CA60
	public int SelectionStart
	{
		get
		{
			return this.selectionStart;
		}
		set
		{
			if (value != this.selectionStart)
			{
				this.selectionStart = global::UnityEngine.Mathf.Max(0, global::UnityEngine.Mathf.Min(value, this.text.Length));
				this.selectionEnd = global::UnityEngine.Mathf.Max(this.selectionEnd, this.selectionStart);
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D99 RID: 3481
	// (get) Token: 0x060048AA RID: 18602 RVA: 0x0010E8B4 File Offset: 0x0010CAB4
	// (set) Token: 0x060048AB RID: 18603 RVA: 0x0010E8BC File Offset: 0x0010CABC
	public int SelectionEnd
	{
		get
		{
			return this.selectionEnd;
		}
		set
		{
			if (value != this.selectionEnd)
			{
				this.selectionEnd = global::UnityEngine.Mathf.Max(0, global::UnityEngine.Mathf.Min(value, this.text.Length));
				this.selectionStart = global::UnityEngine.Mathf.Max(this.selectionStart, this.selectionEnd);
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D9A RID: 3482
	// (get) Token: 0x060048AC RID: 18604 RVA: 0x0010E910 File Offset: 0x0010CB10
	public int SelectionLength
	{
		get
		{
			return this.selectionEnd - this.selectionStart;
		}
	}

	// Token: 0x17000D9B RID: 3483
	// (get) Token: 0x060048AD RID: 18605 RVA: 0x0010E920 File Offset: 0x0010CB20
	public string SelectedText
	{
		get
		{
			if (this.selectionEnd == this.selectionStart)
			{
				return string.Empty;
			}
			return this.text.Substring(this.selectionStart, this.selectionEnd - this.selectionStart);
		}
	}

	// Token: 0x17000D9C RID: 3484
	// (get) Token: 0x060048AE RID: 18606 RVA: 0x0010E958 File Offset: 0x0010CB58
	// (set) Token: 0x060048AF RID: 18607 RVA: 0x0010E960 File Offset: 0x0010CB60
	public bool SelectOnFocus
	{
		get
		{
			return this.selectOnFocus;
		}
		set
		{
			this.selectOnFocus = value;
		}
	}

	// Token: 0x17000D9D RID: 3485
	// (get) Token: 0x060048B0 RID: 18608 RVA: 0x0010E96C File Offset: 0x0010CB6C
	// (set) Token: 0x060048B1 RID: 18609 RVA: 0x0010E98C File Offset: 0x0010CB8C
	public global::UnityEngine.RectOffset Padding
	{
		get
		{
			if (this.padding == null)
			{
				this.padding = new global::UnityEngine.RectOffset();
			}
			return this.padding;
		}
		set
		{
			value = value.ConstrainPadding();
			if (!object.Equals(value, this.padding))
			{
				this.padding = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D9E RID: 3486
	// (get) Token: 0x060048B2 RID: 18610 RVA: 0x0010E9C0 File Offset: 0x0010CBC0
	// (set) Token: 0x060048B3 RID: 18611 RVA: 0x0010E9C8 File Offset: 0x0010CBC8
	public bool IsPasswordField
	{
		get
		{
			return this.displayAsPassword;
		}
		set
		{
			if (value != this.displayAsPassword)
			{
				this.displayAsPassword = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D9F RID: 3487
	// (get) Token: 0x060048B4 RID: 18612 RVA: 0x0010E9E4 File Offset: 0x0010CBE4
	// (set) Token: 0x060048B5 RID: 18613 RVA: 0x0010E9EC File Offset: 0x0010CBEC
	public string PasswordCharacter
	{
		get
		{
			return this.passwordChar;
		}
		set
		{
			if (!string.IsNullOrEmpty(value))
			{
				this.passwordChar = value[0].ToString();
			}
			else
			{
				this.passwordChar = value;
			}
			this.OnPasswordCharacterChanged();
			this.Invalidate();
		}
	}

	// Token: 0x17000DA0 RID: 3488
	// (get) Token: 0x060048B6 RID: 18614 RVA: 0x0010EA34 File Offset: 0x0010CC34
	// (set) Token: 0x060048B7 RID: 18615 RVA: 0x0010EA3C File Offset: 0x0010CC3C
	public float CursorBlinkTime
	{
		get
		{
			return this.cursorBlinkTime;
		}
		set
		{
			this.cursorBlinkTime = value;
		}
	}

	// Token: 0x17000DA1 RID: 3489
	// (get) Token: 0x060048B8 RID: 18616 RVA: 0x0010EA48 File Offset: 0x0010CC48
	// (set) Token: 0x060048B9 RID: 18617 RVA: 0x0010EA50 File Offset: 0x0010CC50
	public int CursorWidth
	{
		get
		{
			return this.cursorWidth;
		}
		set
		{
			this.cursorWidth = value;
		}
	}

	// Token: 0x17000DA2 RID: 3490
	// (get) Token: 0x060048BA RID: 18618 RVA: 0x0010EA5C File Offset: 0x0010CC5C
	// (set) Token: 0x060048BB RID: 18619 RVA: 0x0010EA64 File Offset: 0x0010CC64
	public int CursorIndex
	{
		get
		{
			return this.cursorIndex;
		}
		set
		{
			value = global::UnityEngine.Mathf.Max(0, value);
			value = global::UnityEngine.Mathf.Min(0, this.text.Length - 1);
			this.cursorIndex = value;
		}
	}

	// Token: 0x17000DA3 RID: 3491
	// (get) Token: 0x060048BC RID: 18620 RVA: 0x0010EA8C File Offset: 0x0010CC8C
	// (set) Token: 0x060048BD RID: 18621 RVA: 0x0010EA94 File Offset: 0x0010CC94
	public bool ReadOnly
	{
		get
		{
			return this.readOnly;
		}
		set
		{
			if (value != this.readOnly)
			{
				this.readOnly = value;
				this.OnReadOnlyChanged();
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000DA4 RID: 3492
	// (get) Token: 0x060048BE RID: 18622 RVA: 0x0010EAB8 File Offset: 0x0010CCB8
	// (set) Token: 0x060048BF RID: 18623 RVA: 0x0010EAC0 File Offset: 0x0010CCC0
	public string Text
	{
		get
		{
			return this.text;
		}
		set
		{
			if (value.Length > this.MaxLength)
			{
				value = value.Substring(0, this.MaxLength);
			}
			value = value.Replace("\t", " ");
			if (value != this.text)
			{
				this.text = value;
				this.scrollIndex = (this.cursorIndex = 0);
				this.OnTextChanged();
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000DA5 RID: 3493
	// (get) Token: 0x060048C0 RID: 18624 RVA: 0x0010EB34 File Offset: 0x0010CD34
	// (set) Token: 0x060048C1 RID: 18625 RVA: 0x0010EB3C File Offset: 0x0010CD3C
	public global::UnityEngine.Color32 TextColor
	{
		get
		{
			return this.textColor;
		}
		set
		{
			this.textColor = value;
			this.Invalidate();
		}
	}

	// Token: 0x17000DA6 RID: 3494
	// (get) Token: 0x060048C2 RID: 18626 RVA: 0x0010EB4C File Offset: 0x0010CD4C
	// (set) Token: 0x060048C3 RID: 18627 RVA: 0x0010EB54 File Offset: 0x0010CD54
	public string SelectionSprite
	{
		get
		{
			return this.selectionSprite;
		}
		set
		{
			if (value != this.selectionSprite)
			{
				this.selectionSprite = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000DA7 RID: 3495
	// (get) Token: 0x060048C4 RID: 18628 RVA: 0x0010EB74 File Offset: 0x0010CD74
	// (set) Token: 0x060048C5 RID: 18629 RVA: 0x0010EB7C File Offset: 0x0010CD7C
	public global::UnityEngine.Color32 SelectionBackgroundColor
	{
		get
		{
			return this.selectionBackground;
		}
		set
		{
			this.selectionBackground = value;
			this.Invalidate();
		}
	}

	// Token: 0x17000DA8 RID: 3496
	// (get) Token: 0x060048C6 RID: 18630 RVA: 0x0010EB8C File Offset: 0x0010CD8C
	// (set) Token: 0x060048C7 RID: 18631 RVA: 0x0010EB94 File Offset: 0x0010CD94
	public float TextScale
	{
		get
		{
			return this.textScale;
		}
		set
		{
			value = global::UnityEngine.Mathf.Max(0.1f, value);
			if (!global::UnityEngine.Mathf.Approximately(this.textScale, value))
			{
				this.textScale = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000DA9 RID: 3497
	// (get) Token: 0x060048C8 RID: 18632 RVA: 0x0010EBC4 File Offset: 0x0010CDC4
	// (set) Token: 0x060048C9 RID: 18633 RVA: 0x0010EBCC File Offset: 0x0010CDCC
	public global::dfTextScaleMode TextScaleMode
	{
		get
		{
			return this.textScaleMode;
		}
		set
		{
			this.textScaleMode = value;
			this.Invalidate();
		}
	}

	// Token: 0x17000DAA RID: 3498
	// (get) Token: 0x060048CA RID: 18634 RVA: 0x0010EBDC File Offset: 0x0010CDDC
	// (set) Token: 0x060048CB RID: 18635 RVA: 0x0010EBE4 File Offset: 0x0010CDE4
	public int MaxLength
	{
		get
		{
			return this.maxLength;
		}
		set
		{
			if (value != this.maxLength)
			{
				this.maxLength = global::UnityEngine.Mathf.Max(0, value);
				if (this.maxLength < this.text.Length)
				{
					this.Text = this.text.Substring(0, this.maxLength);
				}
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000DAB RID: 3499
	// (get) Token: 0x060048CC RID: 18636 RVA: 0x0010EC40 File Offset: 0x0010CE40
	// (set) Token: 0x060048CD RID: 18637 RVA: 0x0010EC48 File Offset: 0x0010CE48
	public global::UnityEngine.TextAlignment TextAlignment
	{
		get
		{
			return this.textAlign;
		}
		set
		{
			if (value != this.textAlign)
			{
				this.textAlign = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000DAC RID: 3500
	// (get) Token: 0x060048CE RID: 18638 RVA: 0x0010EC64 File Offset: 0x0010CE64
	// (set) Token: 0x060048CF RID: 18639 RVA: 0x0010EC6C File Offset: 0x0010CE6C
	public bool Shadow
	{
		get
		{
			return this.shadow;
		}
		set
		{
			if (value != this.shadow)
			{
				this.shadow = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000DAD RID: 3501
	// (get) Token: 0x060048D0 RID: 18640 RVA: 0x0010EC88 File Offset: 0x0010CE88
	// (set) Token: 0x060048D1 RID: 18641 RVA: 0x0010EC90 File Offset: 0x0010CE90
	public global::UnityEngine.Color32 ShadowColor
	{
		get
		{
			return this.shadowColor;
		}
		set
		{
			if (!value.Equals(this.shadowColor))
			{
				this.shadowColor = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000DAE RID: 3502
	// (get) Token: 0x060048D2 RID: 18642 RVA: 0x0010ECC8 File Offset: 0x0010CEC8
	// (set) Token: 0x060048D3 RID: 18643 RVA: 0x0010ECD0 File Offset: 0x0010CED0
	public global::UnityEngine.Vector2 ShadowOffset
	{
		get
		{
			return this.shadowOffset;
		}
		set
		{
			if (value != this.shadowOffset)
			{
				this.shadowOffset = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000DAF RID: 3503
	// (get) Token: 0x060048D4 RID: 18644 RVA: 0x0010ECF0 File Offset: 0x0010CEF0
	// (set) Token: 0x060048D5 RID: 18645 RVA: 0x0010ECF8 File Offset: 0x0010CEF8
	public bool UseMobileKeyboard
	{
		get
		{
			return this.useMobileKeyboard;
		}
		set
		{
			this.useMobileKeyboard = value;
		}
	}

	// Token: 0x17000DB0 RID: 3504
	// (get) Token: 0x060048D6 RID: 18646 RVA: 0x0010ED04 File Offset: 0x0010CF04
	// (set) Token: 0x060048D7 RID: 18647 RVA: 0x0010ED0C File Offset: 0x0010CF0C
	public bool MobileAutoCorrect
	{
		get
		{
			return this.mobileAutoCorrect;
		}
		set
		{
			this.mobileAutoCorrect = value;
		}
	}

	// Token: 0x17000DB1 RID: 3505
	// (get) Token: 0x060048D8 RID: 18648 RVA: 0x0010ED18 File Offset: 0x0010CF18
	// (set) Token: 0x060048D9 RID: 18649 RVA: 0x0010ED20 File Offset: 0x0010CF20
	public bool HideMobileInputField
	{
		get
		{
			return this.mobileHideInputField;
		}
		set
		{
			this.mobileHideInputField = value;
		}
	}

	// Token: 0x17000DB2 RID: 3506
	// (get) Token: 0x060048DA RID: 18650 RVA: 0x0010ED2C File Offset: 0x0010CF2C
	// (set) Token: 0x060048DB RID: 18651 RVA: 0x0010ED34 File Offset: 0x0010CF34
	public global::dfMobileKeyboardTrigger MobileKeyboardTrigger
	{
		get
		{
			return this.mobileKeyboardTrigger;
		}
		set
		{
			this.mobileKeyboardTrigger = value;
		}
	}

	// Token: 0x060048DC RID: 18652 RVA: 0x0010ED40 File Offset: 0x0010CF40
	protected override void OnTabKeyPressed(global::dfKeyEventArgs args)
	{
		if (this.acceptsTab)
		{
			base.OnKeyPress(args);
			if (args.Used)
			{
				return;
			}
			args.Character = '\t';
			this.processKeyPress(args);
		}
		else
		{
			base.OnTabKeyPressed(args);
		}
	}

	// Token: 0x060048DD RID: 18653 RVA: 0x0010ED88 File Offset: 0x0010CF88
	protected internal override void OnKeyPress(global::dfKeyEventArgs args)
	{
		if (this.ReadOnly || char.IsControl(args.Character))
		{
			base.OnKeyPress(args);
			return;
		}
		base.OnKeyPress(args);
		if (args.Used)
		{
			return;
		}
		this.processKeyPress(args);
	}

	// Token: 0x060048DE RID: 18654 RVA: 0x0010EDD4 File Offset: 0x0010CFD4
	private void processKeyPress(global::dfKeyEventArgs args)
	{
		this.deleteSelection();
		if (this.text.Length < this.MaxLength)
		{
			if (this.cursorIndex == this.text.Length)
			{
				this.text += args.Character;
			}
			else
			{
				this.text = this.text.Insert(this.cursorIndex, args.Character.ToString());
			}
			this.cursorIndex++;
			this.OnTextChanged();
			this.Invalidate();
		}
		args.Use();
	}

	// Token: 0x060048DF RID: 18655 RVA: 0x0010EE7C File Offset: 0x0010D07C
	protected internal override void OnKeyDown(global::dfKeyEventArgs args)
	{
		if (this.ReadOnly)
		{
			return;
		}
		base.OnKeyDown(args);
		if (args.Used)
		{
			return;
		}
		global::UnityEngine.KeyCode keyCode = args.KeyCode;
		switch (keyCode)
		{
		case 0x113:
			if (args.Control)
			{
				if (args.Shift)
				{
					this.moveSelectionPointRightWord();
				}
				else
				{
					this.moveToNextWord();
				}
			}
			else if (args.Shift)
			{
				this.moveSelectionPointRight();
			}
			else
			{
				this.moveToNextChar();
			}
			break;
		case 0x114:
			if (args.Control)
			{
				if (args.Shift)
				{
					this.moveSelectionPointLeftWord();
				}
				else
				{
					this.moveToPreviousWord();
				}
			}
			else if (args.Shift)
			{
				this.moveSelectionPointLeft();
			}
			else
			{
				this.moveToPreviousChar();
			}
			break;
		case 0x115:
			if (args.Shift)
			{
				string clipBoard = global::dfClipboardHelper.clipBoard;
				if (!string.IsNullOrEmpty(clipBoard))
				{
					this.pasteAtCursor(clipBoard);
				}
			}
			break;
		case 0x116:
			if (args.Shift)
			{
				this.selectToStart();
			}
			else
			{
				this.moveToStart();
			}
			break;
		case 0x117:
			if (args.Shift)
			{
				this.selectToEnd();
			}
			else
			{
				this.moveToEnd();
			}
			break;
		default:
			switch (keyCode)
			{
			case 0x61:
				if (args.Control)
				{
					this.selectAll();
				}
				break;
			default:
				switch (keyCode)
				{
				case 0x76:
					if (args.Control)
					{
						string clipBoard2 = global::dfClipboardHelper.clipBoard;
						if (!string.IsNullOrEmpty(clipBoard2))
						{
							this.pasteAtCursor(clipBoard2);
						}
					}
					break;
				default:
					if (keyCode != 8)
					{
						if (keyCode != 0xD)
						{
							if (keyCode != 0x1B)
							{
								if (keyCode != 0x7F)
								{
									base.OnKeyDown(args);
									return;
								}
								if (this.selectionStart != this.selectionEnd)
								{
									this.deleteSelection();
								}
								else if (args.Control)
								{
									this.deleteNextWord();
								}
								else
								{
									this.deleteNextChar();
								}
							}
							else
							{
								this.ClearSelection();
								this.cursorIndex = (this.scrollIndex = 0);
								this.Invalidate();
								this.OnCancel();
							}
						}
						else
						{
							this.OnSubmit();
						}
					}
					else if (args.Control)
					{
						this.deletePreviousWord();
					}
					else
					{
						this.deletePreviousChar();
					}
					break;
				case 0x78:
					if (args.Control)
					{
						this.cutSelectionToClipboard();
					}
					break;
				}
				break;
			case 0x63:
				if (args.Control)
				{
					this.copySelectionToClipboard();
				}
				break;
			}
			break;
		}
		args.Use();
	}

	// Token: 0x060048E0 RID: 18656 RVA: 0x0010F12C File Offset: 0x0010D32C
	private void selectAll()
	{
		this.selectionStart = 0;
		this.selectionEnd = this.text.Length;
		this.scrollIndex = 0;
		this.setCursorPos(0);
	}

	// Token: 0x060048E1 RID: 18657 RVA: 0x0010F160 File Offset: 0x0010D360
	private void cutSelectionToClipboard()
	{
		this.copySelectionToClipboard();
		this.deleteSelection();
	}

	// Token: 0x060048E2 RID: 18658 RVA: 0x0010F170 File Offset: 0x0010D370
	private void copySelectionToClipboard()
	{
		if (this.selectionStart == this.selectionEnd)
		{
			return;
		}
		global::dfClipboardHelper.clipBoard = this.text.Substring(this.selectionStart, this.selectionEnd - this.selectionStart);
	}

	// Token: 0x060048E3 RID: 18659 RVA: 0x0010F1A8 File Offset: 0x0010D3A8
	private void pasteAtCursor(string clipData)
	{
		this.deleteSelection();
		global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder(this.text.Length + clipData.Length);
		stringBuilder.Append(this.text);
		foreach (char c in clipData)
		{
			if (c >= ' ')
			{
				stringBuilder.Insert(this.cursorIndex++, c);
			}
		}
		stringBuilder.Length = global::UnityEngine.Mathf.Min(stringBuilder.Length, this.maxLength);
		this.text = stringBuilder.ToString();
		this.setCursorPos(this.cursorIndex);
		this.OnTextChanged();
		this.Invalidate();
	}

	// Token: 0x060048E4 RID: 18660 RVA: 0x0010F25C File Offset: 0x0010D45C
	private void selectWordAtIndex(int index)
	{
		if (string.IsNullOrEmpty(this.text))
		{
			return;
		}
		index = global::UnityEngine.Mathf.Max(global::UnityEngine.Mathf.Min(this.text.Length - 1, index), 0);
		char c = this.text[index];
		if (!char.IsLetterOrDigit(c))
		{
			this.selectionStart = index;
			this.selectionEnd = index + 1;
			this.mouseSelectionAnchor = 0;
		}
		else
		{
			this.selectionStart = index;
			for (int i = index; i > 0; i--)
			{
				if (!char.IsLetterOrDigit(this.text[i - 1]))
				{
					break;
				}
				this.selectionStart--;
			}
			this.selectionEnd = index;
			for (int j = index; j < this.text.Length; j++)
			{
				if (!char.IsLetterOrDigit(this.text[j]))
				{
					break;
				}
				this.selectionEnd = j + 1;
			}
		}
		this.cursorIndex = this.selectionStart;
		this.Invalidate();
	}

	// Token: 0x060048E5 RID: 18661 RVA: 0x0010F370 File Offset: 0x0010D570
	private void moveToNextWord()
	{
		this.ClearSelection();
		if (this.cursorIndex == this.text.Length)
		{
			return;
		}
		int cursorPos = this.findNextWord(this.cursorIndex);
		this.setCursorPos(cursorPos);
	}

	// Token: 0x060048E6 RID: 18662 RVA: 0x0010F3B0 File Offset: 0x0010D5B0
	private void moveToPreviousWord()
	{
		this.ClearSelection();
		if (this.cursorIndex == 0)
		{
			return;
		}
		int cursorPos = this.findPreviousWord(this.cursorIndex);
		this.setCursorPos(cursorPos);
	}

	// Token: 0x060048E7 RID: 18663 RVA: 0x0010F3E4 File Offset: 0x0010D5E4
	private void deletePreviousChar()
	{
		if (this.selectionStart != this.selectionEnd)
		{
			int cursorPos = this.selectionStart;
			this.deleteSelection();
			this.setCursorPos(cursorPos);
			return;
		}
		this.ClearSelection();
		if (this.cursorIndex == 0)
		{
			return;
		}
		this.text = this.text.Remove(this.cursorIndex - 1, 1);
		this.cursorIndex--;
		this.cursorShown = true;
		this.OnTextChanged();
		this.Invalidate();
	}

	// Token: 0x060048E8 RID: 18664 RVA: 0x0010F464 File Offset: 0x0010D664
	private void deletePreviousWord()
	{
		this.ClearSelection();
		if (this.cursorIndex == 0)
		{
			return;
		}
		int num = this.findPreviousWord(this.cursorIndex);
		if (num == this.cursorIndex)
		{
			num = 0;
		}
		this.text = this.text.Remove(num, this.cursorIndex - num);
		this.setCursorPos(num);
		this.OnTextChanged();
		this.Invalidate();
	}

	// Token: 0x060048E9 RID: 18665 RVA: 0x0010F4CC File Offset: 0x0010D6CC
	private void deleteSelection()
	{
		if (this.selectionStart == this.selectionEnd)
		{
			return;
		}
		this.text = this.text.Remove(this.selectionStart, this.selectionEnd - this.selectionStart);
		this.setCursorPos(this.selectionStart);
		this.ClearSelection();
		this.OnTextChanged();
		this.Invalidate();
	}

	// Token: 0x060048EA RID: 18666 RVA: 0x0010F530 File Offset: 0x0010D730
	private void deleteNextChar()
	{
		this.ClearSelection();
		if (this.cursorIndex >= this.text.Length)
		{
			return;
		}
		this.text = this.text.Remove(this.cursorIndex, 1);
		this.cursorShown = true;
		this.OnTextChanged();
		this.Invalidate();
	}

	// Token: 0x060048EB RID: 18667 RVA: 0x0010F588 File Offset: 0x0010D788
	private void deleteNextWord()
	{
		this.ClearSelection();
		if (this.cursorIndex == this.text.Length)
		{
			return;
		}
		int num = this.findNextWord(this.cursorIndex);
		if (num == this.cursorIndex)
		{
			num = this.text.Length;
		}
		this.text = this.text.Remove(this.cursorIndex, num - this.cursorIndex);
		this.OnTextChanged();
		this.Invalidate();
	}

	// Token: 0x060048EC RID: 18668 RVA: 0x0010F604 File Offset: 0x0010D804
	private void selectToStart()
	{
		if (this.cursorIndex == 0)
		{
			return;
		}
		if (this.selectionEnd == this.selectionStart)
		{
			this.selectionEnd = this.cursorIndex;
		}
		else if (this.selectionEnd == this.cursorIndex)
		{
			this.selectionEnd = this.selectionStart;
		}
		this.selectionStart = 0;
		this.setCursorPos(0);
	}

	// Token: 0x060048ED RID: 18669 RVA: 0x0010F66C File Offset: 0x0010D86C
	private void selectToEnd()
	{
		if (this.cursorIndex == this.text.Length)
		{
			return;
		}
		if (this.selectionEnd == this.selectionStart)
		{
			this.selectionStart = this.cursorIndex;
		}
		else if (this.selectionStart == this.cursorIndex)
		{
			this.selectionStart = this.selectionEnd;
		}
		this.selectionEnd = this.text.Length;
		this.setCursorPos(this.text.Length);
	}

	// Token: 0x060048EE RID: 18670 RVA: 0x0010F6F4 File Offset: 0x0010D8F4
	private void moveToEnd()
	{
		this.ClearSelection();
		this.setCursorPos(this.text.Length);
	}

	// Token: 0x060048EF RID: 18671 RVA: 0x0010F710 File Offset: 0x0010D910
	private void moveToStart()
	{
		this.ClearSelection();
		this.setCursorPos(0);
	}

	// Token: 0x060048F0 RID: 18672 RVA: 0x0010F720 File Offset: 0x0010D920
	private void moveToNextChar()
	{
		this.ClearSelection();
		this.setCursorPos(this.cursorIndex + 1);
	}

	// Token: 0x060048F1 RID: 18673 RVA: 0x0010F738 File Offset: 0x0010D938
	private void moveSelectionPointRightWord()
	{
		if (this.cursorIndex == this.text.Length)
		{
			return;
		}
		int cursorPos = this.findNextWord(this.cursorIndex);
		if (this.selectionEnd == this.selectionStart)
		{
			this.selectionStart = this.cursorIndex;
			this.selectionEnd = cursorPos;
		}
		else if (this.selectionEnd == this.cursorIndex)
		{
			this.selectionEnd = cursorPos;
		}
		else if (this.selectionStart == this.cursorIndex)
		{
			this.selectionStart = cursorPos;
		}
		this.setCursorPos(cursorPos);
	}

	// Token: 0x060048F2 RID: 18674 RVA: 0x0010F7D0 File Offset: 0x0010D9D0
	private void moveSelectionPointLeftWord()
	{
		if (this.cursorIndex == 0)
		{
			return;
		}
		int cursorPos = this.findPreviousWord(this.cursorIndex);
		if (this.selectionEnd == this.selectionStart)
		{
			this.selectionEnd = this.cursorIndex;
			this.selectionStart = cursorPos;
		}
		else if (this.selectionEnd == this.cursorIndex)
		{
			this.selectionEnd = cursorPos;
		}
		else if (this.selectionStart == this.cursorIndex)
		{
			this.selectionStart = cursorPos;
		}
		this.setCursorPos(cursorPos);
	}

	// Token: 0x060048F3 RID: 18675 RVA: 0x0010F85C File Offset: 0x0010DA5C
	private void moveSelectionPointRight()
	{
		if (this.cursorIndex == this.text.Length)
		{
			return;
		}
		if (this.selectionEnd == this.selectionStart)
		{
			this.selectionEnd = this.cursorIndex + 1;
			this.selectionStart = this.cursorIndex;
		}
		else if (this.selectionEnd == this.cursorIndex)
		{
			this.selectionEnd++;
		}
		else if (this.selectionStart == this.cursorIndex)
		{
			this.selectionStart++;
		}
		this.setCursorPos(this.cursorIndex + 1);
	}

	// Token: 0x060048F4 RID: 18676 RVA: 0x0010F904 File Offset: 0x0010DB04
	private void moveSelectionPointLeft()
	{
		if (this.cursorIndex == 0)
		{
			return;
		}
		if (this.selectionEnd == this.selectionStart)
		{
			this.selectionEnd = this.cursorIndex;
			this.selectionStart = this.cursorIndex - 1;
		}
		else if (this.selectionEnd == this.cursorIndex)
		{
			this.selectionEnd--;
		}
		else if (this.selectionStart == this.cursorIndex)
		{
			this.selectionStart--;
		}
		this.setCursorPos(this.cursorIndex - 1);
	}

	// Token: 0x060048F5 RID: 18677 RVA: 0x0010F9A0 File Offset: 0x0010DBA0
	private void moveToPreviousChar()
	{
		this.ClearSelection();
		this.setCursorPos(this.cursorIndex - 1);
	}

	// Token: 0x060048F6 RID: 18678 RVA: 0x0010F9B8 File Offset: 0x0010DBB8
	private void setCursorPos(int index)
	{
		index = global::UnityEngine.Mathf.Max(0, global::UnityEngine.Mathf.Min(this.text.Length, index));
		if (index == this.cursorIndex)
		{
			return;
		}
		this.cursorIndex = index;
		this.cursorShown = this.HasFocus;
		this.scrollIndex = global::UnityEngine.Mathf.Min(this.scrollIndex, this.cursorIndex);
		this.Invalidate();
	}

	// Token: 0x060048F7 RID: 18679 RVA: 0x0010FA1C File Offset: 0x0010DC1C
	private int findPreviousWord(int startIndex)
	{
		int i;
		for (i = startIndex; i > 0; i--)
		{
			char c = this.text[i - 1];
			if (!char.IsWhiteSpace(c) && !char.IsSeparator(c) && !char.IsPunctuation(c))
			{
				break;
			}
		}
		for (int j = i; j >= 0; j--)
		{
			if (j == 0)
			{
				i = 0;
				break;
			}
			char c2 = this.text[j - 1];
			if (char.IsWhiteSpace(c2) || char.IsSeparator(c2) || char.IsPunctuation(c2))
			{
				i = j;
				break;
			}
		}
		return i;
	}

	// Token: 0x060048F8 RID: 18680 RVA: 0x0010FACC File Offset: 0x0010DCCC
	private int findNextWord(int startIndex)
	{
		int length = this.text.Length;
		int i = startIndex;
		for (int j = i; j < length; j++)
		{
			char c = this.text[j];
			if (char.IsWhiteSpace(c) || char.IsSeparator(c) || char.IsPunctuation(c))
			{
				i = j;
				break;
			}
		}
		while (i < length)
		{
			char c2 = this.text[i];
			if (!char.IsWhiteSpace(c2) && !char.IsSeparator(c2) && !char.IsPunctuation(c2))
			{
				break;
			}
			i++;
		}
		return i;
	}

	// Token: 0x060048F9 RID: 18681 RVA: 0x0010FB7C File Offset: 0x0010DD7C
	public override void OnEnable()
	{
		if (this.padding == null)
		{
			this.padding = new global::UnityEngine.RectOffset();
		}
		base.OnEnable();
		if (this.size.magnitude == 0f)
		{
			base.Size = new global::UnityEngine.Vector2(100f, 20f);
		}
		this.cursorShown = false;
		this.cursorIndex = (this.scrollIndex = 0);
		bool flag = this.Font != null && this.Font.IsValid;
		if (global::UnityEngine.Application.isPlaying && !flag)
		{
			this.Font = base.GetManager().DefaultFont;
		}
	}

	// Token: 0x060048FA RID: 18682 RVA: 0x0010FC28 File Offset: 0x0010DE28
	public override void Awake()
	{
		base.Awake();
		this.startSize = base.Size;
	}

	// Token: 0x060048FB RID: 18683 RVA: 0x0010FC3C File Offset: 0x0010DE3C
	protected internal override void OnEnterFocus(global::dfFocusEventArgs args)
	{
		base.OnEnterFocus(args);
		this.undoText = this.Text;
		if (!this.ReadOnly)
		{
			this.whenGotFocus = global::UnityEngine.Time.realtimeSinceStartup;
			base.StartCoroutine(this.doCursorBlink());
			if (this.selectOnFocus)
			{
				this.selectionStart = 0;
				this.selectionEnd = this.text.Length;
			}
			else
			{
				this.selectionStart = (this.selectionEnd = 0);
			}
		}
		this.Invalidate();
	}

	// Token: 0x060048FC RID: 18684 RVA: 0x0010FCC0 File Offset: 0x0010DEC0
	protected internal override void OnLeaveFocus(global::dfFocusEventArgs args)
	{
		base.OnLeaveFocus(args);
		this.cursorShown = false;
		this.ClearSelection();
		this.Invalidate();
		this.whenGotFocus = 0f;
	}

	// Token: 0x060048FD RID: 18685 RVA: 0x0010FCE8 File Offset: 0x0010DEE8
	protected internal override void OnDoubleClick(global::dfMouseEventArgs args)
	{
		if (args.Source != this)
		{
			base.OnDoubleClick(args);
			return;
		}
		if (!this.ReadOnly && this.HasFocus && args.Buttons.IsSet(global::dfMouseButtons.Left) && global::UnityEngine.Time.realtimeSinceStartup - this.whenGotFocus > 0.5f)
		{
			int charIndexOfMouse = this.getCharIndexOfMouse(args);
			this.selectWordAtIndex(charIndexOfMouse);
		}
		base.OnDoubleClick(args);
	}

	// Token: 0x060048FE RID: 18686 RVA: 0x0010FD64 File Offset: 0x0010DF64
	protected internal override void OnMouseDown(global::dfMouseEventArgs args)
	{
		if (args.Source != this)
		{
			base.OnMouseDown(args);
			return;
		}
		bool flag = !this.ReadOnly && args.Buttons.IsSet(global::dfMouseButtons.Left) && ((!this.HasFocus && !this.SelectOnFocus) || global::UnityEngine.Time.realtimeSinceStartup - this.whenGotFocus > 0.25f);
		if (flag)
		{
			int charIndexOfMouse = this.getCharIndexOfMouse(args);
			if (charIndexOfMouse != this.cursorIndex)
			{
				this.cursorIndex = charIndexOfMouse;
				this.cursorShown = true;
				this.Invalidate();
				args.Use();
			}
			this.mouseSelectionAnchor = this.cursorIndex;
			this.selectionStart = (this.selectionEnd = this.cursorIndex);
		}
		base.OnMouseDown(args);
	}

	// Token: 0x060048FF RID: 18687 RVA: 0x0010FE34 File Offset: 0x0010E034
	protected internal override void OnMouseMove(global::dfMouseEventArgs args)
	{
		if (args.Source != this)
		{
			base.OnMouseMove(args);
			return;
		}
		if (!this.ReadOnly && this.HasFocus && args.Buttons.IsSet(global::dfMouseButtons.Left))
		{
			int charIndexOfMouse = this.getCharIndexOfMouse(args);
			if (charIndexOfMouse != this.cursorIndex)
			{
				this.cursorIndex = charIndexOfMouse;
				this.cursorShown = true;
				this.Invalidate();
				args.Use();
				this.selectionStart = global::UnityEngine.Mathf.Min(this.mouseSelectionAnchor, charIndexOfMouse);
				this.selectionEnd = global::UnityEngine.Mathf.Max(this.mouseSelectionAnchor, charIndexOfMouse);
				return;
			}
		}
		base.OnMouseMove(args);
	}

	// Token: 0x06004900 RID: 18688 RVA: 0x0010FEDC File Offset: 0x0010E0DC
	protected internal virtual void OnTextChanged()
	{
		base.SignalHierarchy("OnTextChanged", new object[]
		{
			this.text
		});
		if (this.TextChanged != null)
		{
			this.TextChanged(this, this.text);
		}
	}

	// Token: 0x06004901 RID: 18689 RVA: 0x0010FF24 File Offset: 0x0010E124
	protected internal virtual void OnReadOnlyChanged()
	{
		if (this.ReadOnlyChanged != null)
		{
			this.ReadOnlyChanged(this, this.readOnly);
		}
	}

	// Token: 0x06004902 RID: 18690 RVA: 0x0010FF44 File Offset: 0x0010E144
	protected internal virtual void OnPasswordCharacterChanged()
	{
		if (this.PasswordCharacterChanged != null)
		{
			this.PasswordCharacterChanged(this, this.passwordChar);
		}
	}

	// Token: 0x06004903 RID: 18691 RVA: 0x0010FF64 File Offset: 0x0010E164
	protected internal virtual void OnSubmit()
	{
		base.SignalHierarchy("OnTextSubmitted", new object[]
		{
			this,
			this.text
		});
		if (this.TextSubmitted != null)
		{
			this.TextSubmitted(this, this.text);
		}
	}

	// Token: 0x06004904 RID: 18692 RVA: 0x0010FFB0 File Offset: 0x0010E1B0
	protected internal virtual void OnCancel()
	{
		this.text = this.undoText;
		base.SignalHierarchy("OnTextCancelled", new object[]
		{
			this,
			this.text
		});
		if (this.TextCancelled != null)
		{
			this.TextCancelled(this, this.text);
		}
	}

	// Token: 0x06004905 RID: 18693 RVA: 0x00110008 File Offset: 0x0010E208
	public void ClearSelection()
	{
		this.selectionStart = 0;
		this.selectionEnd = 0;
		this.mouseSelectionAnchor = 0;
	}

	// Token: 0x06004906 RID: 18694 RVA: 0x00110020 File Offset: 0x0010E220
	private global::System.Collections.IEnumerator doCursorBlink()
	{
		if (!global::UnityEngine.Application.isPlaying)
		{
			yield break;
		}
		this.cursorShown = true;
		while (this.ContainsFocus)
		{
			yield return new global::UnityEngine.WaitForSeconds(this.cursorBlinkTime);
			this.cursorShown = !this.cursorShown;
			this.Invalidate();
		}
		this.cursorShown = false;
		yield break;
	}

	// Token: 0x06004907 RID: 18695 RVA: 0x0011003C File Offset: 0x0010E23C
	private void renderText(global::dfRenderData textBuffer)
	{
		float num = base.PixelsToUnits();
		global::UnityEngine.Vector2 vector;
		vector..ctor(this.size.x - (float)this.padding.horizontal, this.size.y - (float)this.padding.vertical);
		global::UnityEngine.Vector3 vector2 = this.pivot.TransformToUpperLeft(base.Size);
		global::UnityEngine.Vector3 vectorOffset = new global::UnityEngine.Vector3(vector2.x + (float)this.padding.left, vector2.y - (float)this.padding.top, 0f) * num;
		string text = (!this.IsPasswordField || string.IsNullOrEmpty(this.passwordChar)) ? this.text : this.passwordDisplayText();
		global::UnityEngine.Color32 color = (!base.IsEnabled) ? base.DisabledColor : this.TextColor;
		float textScaleMultiplier = this.getTextScaleMultiplier();
		using (global::dfFontRendererBase dfFontRendererBase = this.font.ObtainRenderer())
		{
			dfFontRendererBase.WordWrap = false;
			dfFontRendererBase.MaxSize = vector;
			dfFontRendererBase.PixelRatio = num;
			dfFontRendererBase.TextScale = this.TextScale * textScaleMultiplier;
			dfFontRendererBase.VectorOffset = vectorOffset;
			dfFontRendererBase.MultiLine = false;
			dfFontRendererBase.TextAlign = 0;
			dfFontRendererBase.ProcessMarkup = false;
			dfFontRendererBase.DefaultColor = color;
			dfFontRendererBase.BottomColor = new global::UnityEngine.Color32?(color);
			dfFontRendererBase.OverrideMarkupColors = false;
			dfFontRendererBase.Opacity = base.CalculateOpacity();
			dfFontRendererBase.Shadow = this.Shadow;
			dfFontRendererBase.ShadowColor = this.ShadowColor;
			dfFontRendererBase.ShadowOffset = this.ShadowOffset;
			this.cursorIndex = global::UnityEngine.Mathf.Min(this.cursorIndex, text.Length);
			this.scrollIndex = global::UnityEngine.Mathf.Min(global::UnityEngine.Mathf.Min(this.scrollIndex, this.cursorIndex), text.Length);
			this.charWidths = dfFontRendererBase.GetCharacterWidths(text);
			global::UnityEngine.Vector2 vector3 = vector * num;
			this.leftOffset = 0f;
			if (this.textAlign == null)
			{
				float num2 = 0f;
				for (int i = this.scrollIndex; i < this.cursorIndex; i++)
				{
					num2 += this.charWidths[i];
				}
				while (num2 >= vector3.x && this.scrollIndex < this.cursorIndex)
				{
					num2 -= this.charWidths[this.scrollIndex++];
				}
			}
			else
			{
				this.scrollIndex = global::UnityEngine.Mathf.Max(0, global::UnityEngine.Mathf.Min(this.cursorIndex, text.Length - 1));
				float num3 = 0f;
				float num4 = (float)this.font.FontSize * 1.25f * num;
				while (this.scrollIndex > 0 && num3 < vector3.x - num4)
				{
					num3 += this.charWidths[this.scrollIndex--];
				}
				float num5 = (text.Length <= 0) ? 0f : dfFontRendererBase.GetCharacterWidths(text.Substring(this.scrollIndex)).Sum();
				global::UnityEngine.TextAlignment textAlignment = this.textAlign;
				if (textAlignment != 1)
				{
					if (textAlignment == 2)
					{
						this.leftOffset = global::UnityEngine.Mathf.Max(0f, vector3.x - num5);
					}
				}
				else
				{
					this.leftOffset = global::UnityEngine.Mathf.Max(0f, (vector3.x - num5) * 0.5f);
				}
				vectorOffset.x += this.leftOffset;
				dfFontRendererBase.VectorOffset = vectorOffset;
			}
			if (this.selectionEnd != this.selectionStart)
			{
				this.renderSelection(this.scrollIndex, this.charWidths, this.leftOffset);
			}
			else if (this.cursorShown)
			{
				this.renderCursor(this.scrollIndex, this.cursorIndex, this.charWidths, this.leftOffset);
			}
			dfFontRendererBase.Render(text.Substring(this.scrollIndex), textBuffer);
		}
	}

	// Token: 0x06004908 RID: 18696 RVA: 0x00110480 File Offset: 0x0010E680
	private float getTextScaleMultiplier()
	{
		if (this.textScaleMode == global::dfTextScaleMode.None || !global::UnityEngine.Application.isPlaying)
		{
			return 1f;
		}
		if (this.textScaleMode == global::dfTextScaleMode.ScreenResolution)
		{
			return (float)global::UnityEngine.Screen.height / (float)this.manager.FixedHeight;
		}
		return base.Size.y / this.startSize.y;
	}

	// Token: 0x06004909 RID: 18697 RVA: 0x001104E4 File Offset: 0x0010E6E4
	private string passwordDisplayText()
	{
		return new string(this.passwordChar[0], this.text.Length);
	}

	// Token: 0x0600490A RID: 18698 RVA: 0x00110504 File Offset: 0x0010E704
	private void renderSelection(int scrollIndex, float[] charWidths, float leftOffset)
	{
		if (string.IsNullOrEmpty(this.SelectionSprite) || base.Atlas == null)
		{
			return;
		}
		float num = base.PixelsToUnits();
		float num2 = (this.size.x - (float)this.padding.horizontal) * num;
		int num3 = scrollIndex;
		float num4 = 0f;
		for (int i = scrollIndex; i < this.text.Length; i++)
		{
			num3++;
			num4 += charWidths[i];
			if (num4 > num2)
			{
				break;
			}
		}
		if (this.selectionStart > num3 || this.selectionEnd < scrollIndex)
		{
			return;
		}
		int num5 = global::UnityEngine.Mathf.Max(scrollIndex, this.selectionStart);
		if (num5 > num3)
		{
			return;
		}
		int num6 = global::UnityEngine.Mathf.Min(this.selectionEnd, num3);
		if (num6 <= scrollIndex)
		{
			return;
		}
		float num7 = 0f;
		float num8 = 0f;
		num4 = 0f;
		for (int j = scrollIndex; j <= num3; j++)
		{
			if (j == num5)
			{
				num7 = num4;
			}
			if (j == num6)
			{
				num8 = num4;
				break;
			}
			num4 += charWidths[j];
		}
		float num9 = base.Size.y * num;
		this.addQuadIndices(this.renderData.Vertices, this.renderData.Triangles);
		float num10 = num7 + leftOffset + (float)this.padding.left * num;
		float num11 = num10 + global::UnityEngine.Mathf.Min(num8 - num7, num2);
		float num12 = (float)(-(float)(this.padding.top + 1)) * num;
		float num13 = num12 - num9 + (float)(this.padding.vertical + 2) * num;
		global::UnityEngine.Vector3 vector = this.pivot.TransformToUpperLeft(base.Size) * num;
		global::UnityEngine.Vector3 item = new global::UnityEngine.Vector3(num10, num12) + vector;
		global::UnityEngine.Vector3 item2 = new global::UnityEngine.Vector3(num11, num12) + vector;
		global::UnityEngine.Vector3 item3 = new global::UnityEngine.Vector3(num10, num13) + vector;
		global::UnityEngine.Vector3 item4 = new global::UnityEngine.Vector3(num11, num13) + vector;
		this.renderData.Vertices.Add(item);
		this.renderData.Vertices.Add(item2);
		this.renderData.Vertices.Add(item4);
		this.renderData.Vertices.Add(item3);
		global::UnityEngine.Color32 item5 = base.ApplyOpacity(this.SelectionBackgroundColor);
		this.renderData.Colors.Add(item5);
		this.renderData.Colors.Add(item5);
		this.renderData.Colors.Add(item5);
		this.renderData.Colors.Add(item5);
		global::dfAtlas.ItemInfo itemInfo = base.Atlas[this.SelectionSprite];
		global::UnityEngine.Rect region = itemInfo.region;
		float num14 = region.width / itemInfo.sizeInPixels.x;
		float num15 = region.height / itemInfo.sizeInPixels.y;
		this.renderData.UV.Add(new global::UnityEngine.Vector2(region.x + num14, region.yMax - num15));
		this.renderData.UV.Add(new global::UnityEngine.Vector2(region.xMax - num14, region.yMax - num15));
		this.renderData.UV.Add(new global::UnityEngine.Vector2(region.xMax - num14, region.y + num15));
		this.renderData.UV.Add(new global::UnityEngine.Vector2(region.x + num14, region.y + num15));
	}

	// Token: 0x0600490B RID: 18699 RVA: 0x00110894 File Offset: 0x0010EA94
	private void renderCursor(int startIndex, int cursorIndex, float[] charWidths, float leftOffset)
	{
		if (string.IsNullOrEmpty(this.SelectionSprite) || base.Atlas == null)
		{
			return;
		}
		float num = 0f;
		for (int i = startIndex; i < cursorIndex; i++)
		{
			num += charWidths[i];
		}
		float num2 = base.PixelsToUnits();
		float num3 = (num + leftOffset + (float)this.padding.left * num2).Quantize(num2);
		float num4 = (float)(-(float)this.padding.top) * num2;
		float num5 = num2 * (float)this.cursorWidth;
		float num6 = (this.size.y - (float)this.padding.vertical) * num2;
		global::UnityEngine.Vector3 vector;
		vector..ctor(num3, num4);
		global::UnityEngine.Vector3 vector2;
		vector2..ctor(num3 + num5, num4);
		global::UnityEngine.Vector3 vector3;
		vector3..ctor(num3 + num5, num4 - num6);
		global::UnityEngine.Vector3 vector4;
		vector4..ctor(num3, num4 - num6);
		global::dfList<global::UnityEngine.Vector3> vertices = this.renderData.Vertices;
		global::dfList<int> triangles = this.renderData.Triangles;
		global::dfList<global::UnityEngine.Vector2> uv = this.renderData.UV;
		global::dfList<global::UnityEngine.Color32> colors = this.renderData.Colors;
		global::UnityEngine.Vector3 vector5 = this.pivot.TransformToUpperLeft(this.size) * num2;
		this.addQuadIndices(vertices, triangles);
		vertices.Add(vector + vector5);
		vertices.Add(vector2 + vector5);
		vertices.Add(vector3 + vector5);
		vertices.Add(vector4 + vector5);
		global::UnityEngine.Color32 item = base.ApplyOpacity(this.TextColor);
		colors.Add(item);
		colors.Add(item);
		colors.Add(item);
		colors.Add(item);
		global::dfAtlas.ItemInfo itemInfo = base.Atlas[this.SelectionSprite];
		global::UnityEngine.Rect region = itemInfo.region;
		uv.Add(new global::UnityEngine.Vector2(region.x, region.yMax));
		uv.Add(new global::UnityEngine.Vector2(region.xMax, region.yMax));
		uv.Add(new global::UnityEngine.Vector2(region.xMax, region.y));
		uv.Add(new global::UnityEngine.Vector2(region.x, region.y));
	}

	// Token: 0x0600490C RID: 18700 RVA: 0x00110ABC File Offset: 0x0010ECBC
	private void addQuadIndices(global::dfList<global::UnityEngine.Vector3> verts, global::dfList<int> triangles)
	{
		int count = verts.Count;
		int[] array = new int[]
		{
			0,
			1,
			3,
			3,
			1,
			2
		};
		for (int i = 0; i < array.Length; i++)
		{
			triangles.Add(count + array[i]);
		}
	}

	// Token: 0x0600490D RID: 18701 RVA: 0x00110B04 File Offset: 0x0010ED04
	private int getCharIndexOfMouse(global::dfMouseEventArgs args)
	{
		global::UnityEngine.Vector2 hitPosition = base.GetHitPosition(args);
		float num = base.PixelsToUnits();
		int num2 = this.scrollIndex;
		float num3 = this.leftOffset / num;
		for (int i = this.scrollIndex; i < this.charWidths.Length; i++)
		{
			num3 += this.charWidths[i] / num;
			if (num3 < hitPosition.x)
			{
				num2++;
			}
		}
		return num2;
	}

	// Token: 0x0600490E RID: 18702 RVA: 0x00110B74 File Offset: 0x0010ED74
	public global::dfList<global::dfRenderData> RenderMultiple()
	{
		if (base.Atlas == null || this.Font == null)
		{
			return null;
		}
		if (!this.isVisible)
		{
			return null;
		}
		if (this.renderData == null)
		{
			this.renderData = global::dfRenderData.Obtain();
			this.textRenderData = global::dfRenderData.Obtain();
			this.isControlInvalidated = true;
		}
		if (!this.isControlInvalidated)
		{
			for (int i = 0; i < this.buffers.Count; i++)
			{
				this.buffers[i].Transform = base.transform.localToWorldMatrix;
			}
			return this.buffers;
		}
		this.buffers.Clear();
		this.renderData.Clear();
		this.renderData.Material = base.Atlas.Material;
		this.renderData.Transform = base.transform.localToWorldMatrix;
		this.buffers.Add(this.renderData);
		this.textRenderData.Clear();
		this.textRenderData.Material = base.Atlas.Material;
		this.textRenderData.Transform = base.transform.localToWorldMatrix;
		this.buffers.Add(this.textRenderData);
		this.renderBackground();
		this.renderText(this.textRenderData);
		this.isControlInvalidated = false;
		this.updateCollider();
		return this.buffers;
	}

	// Token: 0x040026D2 RID: 9938
	[global::UnityEngine.SerializeField]
	protected global::dfFontBase font;

	// Token: 0x040026D3 RID: 9939
	[global::UnityEngine.SerializeField]
	protected bool acceptsTab;

	// Token: 0x040026D4 RID: 9940
	[global::UnityEngine.SerializeField]
	protected bool displayAsPassword;

	// Token: 0x040026D5 RID: 9941
	[global::UnityEngine.SerializeField]
	protected string passwordChar = "*";

	// Token: 0x040026D6 RID: 9942
	[global::UnityEngine.SerializeField]
	protected bool readOnly;

	// Token: 0x040026D7 RID: 9943
	[global::UnityEngine.SerializeField]
	protected string text = string.Empty;

	// Token: 0x040026D8 RID: 9944
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Color32 textColor = global::UnityEngine.Color.white;

	// Token: 0x040026D9 RID: 9945
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Color32 selectionBackground = new global::UnityEngine.Color32(0, 0x69, 0xD2, byte.MaxValue);

	// Token: 0x040026DA RID: 9946
	[global::UnityEngine.SerializeField]
	protected string selectionSprite = string.Empty;

	// Token: 0x040026DB RID: 9947
	[global::UnityEngine.SerializeField]
	protected float textScale = 1f;

	// Token: 0x040026DC RID: 9948
	[global::UnityEngine.SerializeField]
	protected global::dfTextScaleMode textScaleMode;

	// Token: 0x040026DD RID: 9949
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.RectOffset padding = new global::UnityEngine.RectOffset();

	// Token: 0x040026DE RID: 9950
	[global::UnityEngine.SerializeField]
	protected float cursorBlinkTime = 0.45f;

	// Token: 0x040026DF RID: 9951
	[global::UnityEngine.SerializeField]
	protected int cursorWidth = 1;

	// Token: 0x040026E0 RID: 9952
	[global::UnityEngine.SerializeField]
	protected int maxLength = 0x400;

	// Token: 0x040026E1 RID: 9953
	[global::UnityEngine.SerializeField]
	protected bool selectOnFocus;

	// Token: 0x040026E2 RID: 9954
	[global::UnityEngine.SerializeField]
	protected bool shadow;

	// Token: 0x040026E3 RID: 9955
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Color32 shadowColor = global::UnityEngine.Color.black;

	// Token: 0x040026E4 RID: 9956
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Vector2 shadowOffset = new global::UnityEngine.Vector2(1f, -1f);

	// Token: 0x040026E5 RID: 9957
	[global::UnityEngine.SerializeField]
	protected bool useMobileKeyboard;

	// Token: 0x040026E6 RID: 9958
	[global::UnityEngine.SerializeField]
	protected int mobileKeyboardType;

	// Token: 0x040026E7 RID: 9959
	[global::UnityEngine.SerializeField]
	protected bool mobileAutoCorrect;

	// Token: 0x040026E8 RID: 9960
	[global::UnityEngine.SerializeField]
	protected bool mobileHideInputField;

	// Token: 0x040026E9 RID: 9961
	[global::UnityEngine.SerializeField]
	protected global::dfMobileKeyboardTrigger mobileKeyboardTrigger;

	// Token: 0x040026EA RID: 9962
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.TextAlignment textAlign;

	// Token: 0x040026EB RID: 9963
	private global::UnityEngine.Vector2 startSize = global::UnityEngine.Vector2.zero;

	// Token: 0x040026EC RID: 9964
	private int selectionStart;

	// Token: 0x040026ED RID: 9965
	private int selectionEnd;

	// Token: 0x040026EE RID: 9966
	private int mouseSelectionAnchor;

	// Token: 0x040026EF RID: 9967
	private int scrollIndex;

	// Token: 0x040026F0 RID: 9968
	private int cursorIndex;

	// Token: 0x040026F1 RID: 9969
	private float leftOffset;

	// Token: 0x040026F2 RID: 9970
	private bool cursorShown;

	// Token: 0x040026F3 RID: 9971
	private float[] charWidths;

	// Token: 0x040026F4 RID: 9972
	private float whenGotFocus;

	// Token: 0x040026F5 RID: 9973
	private string undoText = string.Empty;

	// Token: 0x040026F6 RID: 9974
	private global::dfRenderData textRenderData;

	// Token: 0x040026F7 RID: 9975
	private global::dfList<global::dfRenderData> buffers = global::dfList<global::dfRenderData>.Obtain();

	// Token: 0x040026F8 RID: 9976
	private global::PropertyChangedEventHandler<bool> ReadOnlyChanged;

	// Token: 0x040026F9 RID: 9977
	private global::PropertyChangedEventHandler<string> PasswordCharacterChanged;

	// Token: 0x040026FA RID: 9978
	private global::PropertyChangedEventHandler<string> TextChanged;

	// Token: 0x040026FB RID: 9979
	private global::PropertyChangedEventHandler<string> TextSubmitted;

	// Token: 0x040026FC RID: 9980
	private global::PropertyChangedEventHandler<string> TextCancelled;

	// Token: 0x02000841 RID: 2113
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <doCursorBlink>c__Iterator53 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x0600490F RID: 18703 RVA: 0x00110CE4 File Offset: 0x0010EEE4
		public <doCursorBlink>c__Iterator53()
		{
		}

		// Token: 0x17000DB3 RID: 3507
		// (get) Token: 0x06004910 RID: 18704 RVA: 0x00110CEC File Offset: 0x0010EEEC
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000DB4 RID: 3508
		// (get) Token: 0x06004911 RID: 18705 RVA: 0x00110CF4 File Offset: 0x0010EEF4
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06004912 RID: 18706 RVA: 0x00110CFC File Offset: 0x0010EEFC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				if (!global::UnityEngine.Application.isPlaying)
				{
					return false;
				}
				this.cursorShown = true;
				break;
			case 1U:
				this.cursorShown = !this.cursorShown;
				this.Invalidate();
				break;
			default:
				return false;
			}
			if (this.ContainsFocus)
			{
				this.$current = new global::UnityEngine.WaitForSeconds(this.cursorBlinkTime);
				this.$PC = 1;
				return true;
			}
			this.cursorShown = false;
			this.$PC = -1;
			return false;
		}

		// Token: 0x06004913 RID: 18707 RVA: 0x00110DB8 File Offset: 0x0010EFB8
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06004914 RID: 18708 RVA: 0x00110DC4 File Offset: 0x0010EFC4
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x040026FD RID: 9981
		internal int $PC;

		// Token: 0x040026FE RID: 9982
		internal object $current;

		// Token: 0x040026FF RID: 9983
		internal global::dfTextbox <>f__this;
	}
}
