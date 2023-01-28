using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200053F RID: 1343
public class RPOSWindow : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002D96 RID: 11670 RVA: 0x000ADABC File Offset: 0x000ABCBC
	public RPOSWindow()
	{
		this.buttonCallback = new global::UIEventListener.VoidDelegate(this.ButtonClickCallback);
	}

	// Token: 0x14000018 RID: 24
	// (add) Token: 0x06002D97 RID: 11671 RVA: 0x000ADB10 File Offset: 0x000ABD10
	// (remove) Token: 0x06002D98 RID: 11672 RVA: 0x000ADB1C File Offset: 0x000ABD1C
	public event global::RPOSWindowMessageHandler WillOpen
	{
		add
		{
			this.AddMessageHandler(global::RPOSWindowMessage.WillOpen, value);
		}
		remove
		{
			this.RemoveMessageHandler(global::RPOSWindowMessage.WillOpen, value);
		}
	}

	// Token: 0x14000019 RID: 25
	// (add) Token: 0x06002D99 RID: 11673 RVA: 0x000ADB28 File Offset: 0x000ABD28
	// (remove) Token: 0x06002D9A RID: 11674 RVA: 0x000ADB34 File Offset: 0x000ABD34
	public event global::RPOSWindowMessageHandler DidOpen
	{
		add
		{
			this.AddMessageHandler(global::RPOSWindowMessage.DidOpen, value);
		}
		remove
		{
			this.RemoveMessageHandler(global::RPOSWindowMessage.DidOpen, value);
		}
	}

	// Token: 0x1400001A RID: 26
	// (add) Token: 0x06002D9B RID: 11675 RVA: 0x000ADB40 File Offset: 0x000ABD40
	// (remove) Token: 0x06002D9C RID: 11676 RVA: 0x000ADB4C File Offset: 0x000ABD4C
	public event global::RPOSWindowMessageHandler WillShow
	{
		add
		{
			this.AddMessageHandler(global::RPOSWindowMessage.WillShow, value);
		}
		remove
		{
			this.RemoveMessageHandler(global::RPOSWindowMessage.WillShow, value);
		}
	}

	// Token: 0x1400001B RID: 27
	// (add) Token: 0x06002D9D RID: 11677 RVA: 0x000ADB58 File Offset: 0x000ABD58
	// (remove) Token: 0x06002D9E RID: 11678 RVA: 0x000ADB64 File Offset: 0x000ABD64
	public event global::RPOSWindowMessageHandler DidShow
	{
		add
		{
			this.AddMessageHandler(global::RPOSWindowMessage.DidShow, value);
		}
		remove
		{
			this.RemoveMessageHandler(global::RPOSWindowMessage.DidShow, value);
		}
	}

	// Token: 0x1400001C RID: 28
	// (add) Token: 0x06002D9F RID: 11679 RVA: 0x000ADB70 File Offset: 0x000ABD70
	// (remove) Token: 0x06002DA0 RID: 11680 RVA: 0x000ADB7C File Offset: 0x000ABD7C
	public event global::RPOSWindowMessageHandler WillHide
	{
		add
		{
			this.AddMessageHandler(global::RPOSWindowMessage.WillHide, value);
		}
		remove
		{
			this.RemoveMessageHandler(global::RPOSWindowMessage.WillHide, value);
		}
	}

	// Token: 0x1400001D RID: 29
	// (add) Token: 0x06002DA1 RID: 11681 RVA: 0x000ADB88 File Offset: 0x000ABD88
	// (remove) Token: 0x06002DA2 RID: 11682 RVA: 0x000ADB94 File Offset: 0x000ABD94
	public event global::RPOSWindowMessageHandler DidHide
	{
		add
		{
			this.AddMessageHandler(global::RPOSWindowMessage.DidHide, value);
		}
		remove
		{
			this.RemoveMessageHandler(global::RPOSWindowMessage.DidHide, value);
		}
	}

	// Token: 0x1400001E RID: 30
	// (add) Token: 0x06002DA3 RID: 11683 RVA: 0x000ADBA0 File Offset: 0x000ABDA0
	// (remove) Token: 0x06002DA4 RID: 11684 RVA: 0x000ADBAC File Offset: 0x000ABDAC
	public event global::RPOSWindowMessageHandler WillClose
	{
		add
		{
			this.AddMessageHandler(global::RPOSWindowMessage.WillClose, value);
		}
		remove
		{
			this.RemoveMessageHandler(global::RPOSWindowMessage.WillClose, value);
		}
	}

	// Token: 0x1400001F RID: 31
	// (add) Token: 0x06002DA5 RID: 11685 RVA: 0x000ADBB8 File Offset: 0x000ABDB8
	// (remove) Token: 0x06002DA6 RID: 11686 RVA: 0x000ADBC4 File Offset: 0x000ABDC4
	public event global::RPOSWindowMessageHandler DidClose
	{
		add
		{
			this.AddMessageHandler(global::RPOSWindowMessage.DidClose, value);
		}
		remove
		{
			this.RemoveMessageHandler(global::RPOSWindowMessage.DidClose, value);
		}
	}

	// Token: 0x06002DA7 RID: 11687 RVA: 0x000ADBD0 File Offset: 0x000ABDD0
	private void FireEvent(global::RPOSWindowMessage message)
	{
		this.messageCenter.Fire(this, message);
	}

	// Token: 0x06002DA8 RID: 11688 RVA: 0x000ADBE0 File Offset: 0x000ABDE0
	public bool AddMessageHandler(global::RPOSWindowMessage message, global::RPOSWindowMessageHandler handler)
	{
		return !this._destroyed && !this._lock_destroy && !this._destroyAfterAwake && (this._awake || this._lock_awake) && this.messageCenter.Add(message, handler);
	}

	// Token: 0x06002DA9 RID: 11689 RVA: 0x000ADC34 File Offset: 0x000ABE34
	public bool RemoveMessageHandler(global::RPOSWindowMessage message, global::RPOSWindowMessageHandler handler)
	{
		return (!this._awake || this._destroyed) && this.messageCenter.Remove(message, handler);
	}

	// Token: 0x06002DAA RID: 11690 RVA: 0x000ADC5C File Offset: 0x000ABE5C
	[global::System.Obsolete("Use WindowAwake", true)]
	protected void Awake()
	{
		this._EnsureAwake();
	}

	// Token: 0x06002DAB RID: 11691 RVA: 0x000ADC64 File Offset: 0x000ABE64
	[global::System.Obsolete("Forwarder to SubTouch with SubTouchKind.Press if true else SubTouchKind.Release", true)]
	protected void OnChildPress(bool press)
	{
		this.SubTouch(global::UICamera.Cursor.Buttons.LeftValue.Pressed, (!press) ? global::RPOSWindow.SubTouchKind.Release : global::RPOSWindow.SubTouchKind.Press);
	}

	// Token: 0x06002DAC RID: 11692 RVA: 0x000ADC90 File Offset: 0x000ABE90
	[global::System.Obsolete("Forwarder to SubTouch with SubTouchKind.Click", true)]
	protected void OnChildClick(global::UnityEngine.GameObject go)
	{
		this.SubTouch(go, global::RPOSWindow.SubTouchKind.Click);
	}

	// Token: 0x06002DAD RID: 11693 RVA: 0x000ADC9C File Offset: 0x000ABE9C
	[global::System.Obsolete("Forwarder to SubTouch with SubTouchKind.ClickCancel", true)]
	protected void OnChildClickMissed(global::UnityEngine.GameObject go)
	{
		this.SubTouch(go, global::RPOSWindow.SubTouchKind.ClickCancel);
	}

	// Token: 0x06002DAE RID: 11694 RVA: 0x000ADCA8 File Offset: 0x000ABEA8
	[global::System.Obsolete("Use WindowDestroy", true)]
	protected void OnDestroy()
	{
		if (this._awake)
		{
			this._EnsureDestroy();
		}
	}

	// Token: 0x06002DAF RID: 11695 RVA: 0x000ADCBC File Offset: 0x000ABEBC
	private void _EnsureAwake()
	{
		if (!this._awake)
		{
			if (this._lock_awake)
			{
				global::UnityEngine.Debug.LogWarning("Something tried to ensure this while it was being awoken in ensure awake", this);
				return;
			}
			if (this._destroyed)
			{
				global::UnityEngine.Debug.LogWarning("This window was destroyed before it could be awoke", this);
			}
			else if (this._lock_destroy)
			{
				global::UnityEngine.Debug.LogWarning("This window is in the process of being destroyed, please look at the call stack and avoid this", this);
			}
			else
			{
				try
				{
					this._lock_awake = true;
					this._myPanel = base.GetComponent<global::UIPanel>();
					this.panelsEnabled = false;
					if (this._closeButton)
					{
						this.closeButtonListener = global::UIEventListener.Get(this._closeButton.gameObject);
						if (this.closeButtonListener)
						{
							global::UIEventListener uieventListener = this.closeButtonListener;
							uieventListener.onClick = (global::UIEventListener.VoidDelegate)global::System.Delegate.Combine(uieventListener.onClick, this.buttonCallback);
						}
					}
					this.WindowAwake();
				}
				catch (global::System.Exception arg)
				{
					global::UnityEngine.Debug.LogError(string.Format("A exception was thrown during window awake ({0}, title={1}) and has probably broken something, exception is below\r\n{2}", this, this.TitleText, arg), this);
				}
				finally
				{
					this._awake = true;
					this._lock_awake = false;
					if (this._destroyAfterAwake)
					{
						global::UnityEngine.Debug.LogWarning("Because of something trying to destroy this while we were awaking, destroy will occur now", this);
						try
						{
							this._lock_destroy = true;
							this.WindowDestroy();
						}
						catch (global::System.Exception arg2)
						{
							global::UnityEngine.Debug.LogError(string.Format("A exception was thrown during window destroy following awake. ({0}, title={1}) and potentially screwed up stuff, exception is below\r\n{2}", this, this.TitleText, arg2), this);
						}
						finally
						{
							this._destroyed = true;
							this._lock_destroy = false;
						}
					}
					else
					{
						global::RPOS.RegisterWindow(this);
					}
				}
			}
		}
	}

	// Token: 0x06002DB0 RID: 11696 RVA: 0x000ADE90 File Offset: 0x000AC090
	private void _EnsureDestroy()
	{
		if (this._awake)
		{
			if (this._lock_destroy)
			{
				global::UnityEngine.Debug.LogWarning("Something tried to destroy while this window was destroying", this);
			}
			else
			{
				try
				{
					this._lock_destroy = true;
					if (this.closeButtonListener)
					{
						global::UIEventListener uieventListener = this.closeButtonListener;
						uieventListener.onClick = (global::UIEventListener.VoidDelegate)global::System.Delegate.Remove(uieventListener.onClick, this.buttonCallback);
					}
					if (!this._closed)
					{
						this._showWithRPOS = false;
						this._showWithoutRPOS = false;
						this.CheckDisplay();
						if (this._opened && !this._closed)
						{
							this.WindowClose();
						}
					}
					this.WindowDestroy();
				}
				catch (global::System.Exception arg)
				{
					global::UnityEngine.Debug.LogError(string.Format("A exception was thrown during window destroy ({0}, title={1}) and potentially screwed up stuff, exception is below\r\n{2}", this, this.TitleText, arg), this);
				}
				finally
				{
					this._destroyed = true;
					this._lock_destroy = false;
					global::RPOS.UnregisterWindow(this);
				}
			}
		}
		else if (this._lock_awake)
		{
			global::UnityEngine.Debug.LogWarning("This window was awakening.. the call to destroy will happen when its done. Look at call stack. Avoid this.", this);
			this._destroyAfterAwake = true;
		}
		else if (!this._lock_destroy)
		{
			this._lock_destroy = true;
			global::UnityEngine.Debug.LogWarning("This window is being destroyed, and has never got it's Awake.", this);
		}
	}

	// Token: 0x06002DB1 RID: 11697 RVA: 0x000ADFF0 File Offset: 0x000AC1F0
	[global::System.Obsolete("For use by RPOS only!")]
	internal void RPOSReady()
	{
		if (!this.neverAutoShow)
		{
			if (this.autoShowWithRPOS)
			{
				this._showWithRPOS = true;
			}
			if (this.autoShowWithoutRPOS)
			{
				this._showWithoutRPOS = true;
			}
		}
		if (global::RPOS.IsOpen)
		{
			global::UnityEngine.Debug.Log("Was ready");
			this.RPOSOn();
		}
		this.CheckDisplay();
	}

	// Token: 0x06002DB2 RID: 11698 RVA: 0x000AE050 File Offset: 0x000AC250
	[global::System.Obsolete("For use by RPOS only!")]
	internal void RPOSOn()
	{
		this.OnRPOSOpened();
	}

	// Token: 0x06002DB3 RID: 11699 RVA: 0x000AE058 File Offset: 0x000AC258
	[global::System.Obsolete("For use by RPOS only!")]
	internal void RPOSOff()
	{
		this.OnRPOSClosed();
	}

	// Token: 0x06002DB4 RID: 11700 RVA: 0x000AE060 File Offset: 0x000AC260
	[global::System.Obsolete("For use by RPOS only!")]
	internal bool CheckDisplay()
	{
		if (this._lock_show)
		{
			return false;
		}
		if (!this._showing)
		{
			if ((!this._showWithoutRPOS && (!this._showWithRPOS || !global::RPOS.IsOpen)) || (this._inventoryHide && this._isInventoryRelated))
			{
				return false;
			}
			this._showing = true;
			this.WindowShow();
		}
		else
		{
			if (!this._forceHide && (this._showWithoutRPOS || (this._showWithRPOS && global::RPOS.IsOpen)) && (!this._inventoryHide || !this._isInventoryRelated))
			{
				return false;
			}
			this._showing = false;
			this.WindowHide();
		}
		return true;
	}

	// Token: 0x06002DB5 RID: 11701 RVA: 0x000AE12C File Offset: 0x000AC32C
	public static void EnsureAwake(global::RPOSWindow window)
	{
		window._EnsureAwake();
	}

	// Token: 0x06002DB6 RID: 11702 RVA: 0x000AE134 File Offset: 0x000AC334
	private static bool GameObjectEqual(global::UnityEngine.Object A, global::UnityEngine.Object B)
	{
		if (!A)
		{
			return !B;
		}
		if (!B)
		{
			return false;
		}
		if (A is global::UnityEngine.GameObject)
		{
			if (B is global::UnityEngine.GameObject)
			{
				return A == B;
			}
			return B is global::UnityEngine.Component && (global::UnityEngine.GameObject)A == ((global::UnityEngine.Component)B).gameObject;
		}
		else
		{
			if (!(A is global::UnityEngine.Component))
			{
				return false;
			}
			if (B is global::UnityEngine.GameObject)
			{
				return ((global::UnityEngine.Component)A).gameObject == (global::UnityEngine.GameObject)B;
			}
			return B is global::UnityEngine.Component && ((global::UnityEngine.Component)A).gameObject == ((global::UnityEngine.Component)B).gameObject;
		}
	}

	// Token: 0x06002DB7 RID: 11703 RVA: 0x000AE204 File Offset: 0x000AC404
	private void ButtonClickCallback(global::UnityEngine.GameObject button)
	{
		if (global::RPOSWindow.GameObjectEqual(button, this._closeButton))
		{
			this.CloseButtonClicked();
		}
		else if (this.bumpers != null)
		{
			int count = this.bumpers.Count;
			if (count > 0 && button)
			{
				global::UIButton component = button.GetComponent<global::UIButton>();
				if (component)
				{
					for (int i = 0; i < count; i++)
					{
						if (component == this.bumpers[i].button)
						{
							this.OnBumperClick(this.bumpers[i]);
							return;
						}
					}
				}
			}
		}
	}

	// Token: 0x06002DB8 RID: 11704 RVA: 0x000AE2AC File Offset: 0x000AC4AC
	private void HideOrClose(bool hideIsTrue)
	{
		if (hideIsTrue)
		{
			this.Hide();
		}
		else
		{
			this.WindowClose();
		}
	}

	// Token: 0x170009C2 RID: 2498
	// (set) Token: 0x06002DB9 RID: 11705 RVA: 0x000AE2C8 File Offset: 0x000AC4C8
	private bool panelsEnabled
	{
		set
		{
			if (this._myPanel)
			{
				this._myPanel.enabled = value;
			}
			if (this.childPanels != null)
			{
				foreach (global::UIPanel uipanel in this.childPanels)
				{
					if (uipanel)
					{
						uipanel.enabled = value;
					}
				}
			}
		}
	}

	// Token: 0x06002DBA RID: 11706 RVA: 0x000AE330 File Offset: 0x000AC530
	private void WindowShow()
	{
		if (this._lock_show)
		{
			throw new global::System.InvalidOperationException("The window was already in the process of showing or hiding");
		}
		if (!this._opened)
		{
			this.WindowOpen();
		}
		try
		{
			this._lock_show = true;
			this.FireEvent(global::RPOSWindowMessage.WillShow);
			this.OnWindowShow();
			this.FireEvent(global::RPOSWindowMessage.DidShow);
		}
		finally
		{
			this._lock_show = false;
		}
	}

	// Token: 0x06002DBB RID: 11707 RVA: 0x000AE3A8 File Offset: 0x000AC5A8
	private void WindowHide()
	{
		if (this._lock_show)
		{
			throw new global::System.InvalidOperationException("The window was already in the process of showing or hiding");
		}
		try
		{
			this._lock_show = true;
			this.FireEvent(global::RPOSWindowMessage.WillHide);
			this.OnWindowHide();
			this.FireEvent(global::RPOSWindowMessage.DidHide);
		}
		finally
		{
			this._lock_show = false;
		}
	}

	// Token: 0x06002DBC RID: 11708 RVA: 0x000AE410 File Offset: 0x000AC610
	private void WindowClose()
	{
		if (this._closed || this._lock_close)
		{
			return;
		}
		if (this._lock_open)
		{
			throw new global::System.InvalidOperationException("cannot close while opening -- check call stack.");
		}
		try
		{
			this._lock_close = true;
			this._forceHide = true;
			if (this._showing)
			{
				this.CheckDisplay();
			}
			if (this._opened)
			{
				this.FireEvent(global::RPOSWindowMessage.WillClose);
				this._closed = true;
				this.OnWindowClosed();
				this._opened = false;
				this.FireEvent(global::RPOSWindowMessage.DidClose);
			}
		}
		finally
		{
			this._lock_close = false;
		}
		if (this.destroyWithClose && !this._lock_destroy && !this._destroyed && !this._destroyAfterAwake)
		{
			global::UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06002DBD RID: 11709 RVA: 0x000AE4F8 File Offset: 0x000AC6F8
	private void WindowOpen()
	{
		if (this._opened || this._lock_open)
		{
			return;
		}
		if (this._lock_close)
		{
			throw new global::System.InvalidOperationException("cannot open while closing -- check call stack.");
		}
		try
		{
			this._lock_open = true;
			bool closed = this._closed;
			this.FireEvent(global::RPOSWindowMessage.WillOpen);
			this._opened = true;
			this._closed = false;
			if (closed)
			{
				this.OnWindowReOpen();
			}
			else
			{
				this.OnWindowOpened();
			}
			this.FireEvent(global::RPOSWindowMessage.DidOpen);
		}
		finally
		{
			this._lock_open = false;
		}
		if (!this._lock_show)
		{
			this.CheckDisplay();
		}
	}

	// Token: 0x06002DBE RID: 11710 RVA: 0x000AE5B0 File Offset: 0x000AC7B0
	internal void AddBumper(global::RPOSBumper.Instance inst)
	{
		inst.label.text = this.title;
		global::UIEventListener listener = inst.listener;
		if (listener)
		{
			global::UIEventListener uieventListener = listener;
			uieventListener.onClick = (global::UIEventListener.VoidDelegate)global::System.Delegate.Combine(uieventListener.onClick, this.buttonCallback);
			if (this.bumpers == null)
			{
				this.bumpers = new global::System.Collections.Generic.List<global::RPOSBumper.Instance>();
			}
			this.bumpers.Add(inst);
		}
	}

	// Token: 0x06002DBF RID: 11711 RVA: 0x000AE620 File Offset: 0x000AC820
	internal void RemoveBumper(global::RPOSBumper.Instance inst)
	{
		if (this.bumpers != null && this.bumpers.Remove(inst))
		{
			global::UIEventListener listener = inst.listener;
			if (listener)
			{
				global::UIEventListener uieventListener = listener;
				uieventListener.onClick = (global::UIEventListener.VoidDelegate)global::System.Delegate.Remove(uieventListener.onClick, this.buttonCallback);
			}
		}
	}

	// Token: 0x170009C3 RID: 2499
	// (get) Token: 0x06002DC0 RID: 11712 RVA: 0x000AE678 File Offset: 0x000AC878
	// (set) Token: 0x06002DC1 RID: 11713 RVA: 0x000AE680 File Offset: 0x000AC880
	internal bool inventoryHide
	{
		get
		{
			return this._inventoryHide;
		}
		set
		{
			if (this._inventoryHide != value)
			{
				this._inventoryHide = value;
				if (this._isInventoryRelated && this.ready)
				{
					this.CheckDisplay();
				}
			}
		}
	}

	// Token: 0x06002DC2 RID: 11714 RVA: 0x000AE6C0 File Offset: 0x000AC8C0
	internal void zzz___INTERNAL_FOCUS()
	{
		if (!this.showWithRPOS)
		{
			this.showWithRPOS = true;
		}
		this.BringToFront();
	}

	// Token: 0x170009C4 RID: 2500
	// (get) Token: 0x06002DC3 RID: 11715 RVA: 0x000AE6DC File Offset: 0x000AC8DC
	public global::UnityEngine.Vector4 windowDimensions
	{
		get
		{
			return this._windowDimensions;
		}
	}

	// Token: 0x170009C5 RID: 2501
	// (get) Token: 0x06002DC4 RID: 11716 RVA: 0x000AE6E4 File Offset: 0x000AC8E4
	public global::UIWidget.Pivot shrinkPivot
	{
		get
		{
			return this._shrinkPivot;
		}
	}

	// Token: 0x170009C6 RID: 2502
	// (get) Token: 0x06002DC5 RID: 11717 RVA: 0x000AE6EC File Offset: 0x000AC8EC
	// (set) Token: 0x06002DC6 RID: 11718 RVA: 0x000AE6F4 File Offset: 0x000AC8F4
	public global::UILabel titleObj
	{
		get
		{
			return this._titleObj;
		}
		private set
		{
			this._titleObj = value;
		}
	}

	// Token: 0x170009C7 RID: 2503
	// (get) Token: 0x06002DC7 RID: 11719 RVA: 0x000AE700 File Offset: 0x000AC900
	// (set) Token: 0x06002DC8 RID: 11720 RVA: 0x000AE708 File Offset: 0x000AC908
	public global::UIButton closeButton
	{
		get
		{
			return this._closeButton;
		}
		private set
		{
			this._closeButton = value;
		}
	}

	// Token: 0x170009C8 RID: 2504
	// (get) Token: 0x06002DC9 RID: 11721 RVA: 0x000AE714 File Offset: 0x000AC914
	// (set) Token: 0x06002DCA RID: 11722 RVA: 0x000AE71C File Offset: 0x000AC91C
	public global::UIPanel mainPanel
	{
		get
		{
			return this._myPanel;
		}
		private set
		{
			this._myPanel = value;
		}
	}

	// Token: 0x170009C9 RID: 2505
	// (get) Token: 0x06002DCB RID: 11723 RVA: 0x000AE728 File Offset: 0x000AC928
	// (set) Token: 0x06002DCC RID: 11724 RVA: 0x000AE730 File Offset: 0x000AC930
	public global::UnityEngine.GameObject background
	{
		get
		{
			return this._background;
		}
		private set
		{
			this._background = value;
		}
	}

	// Token: 0x170009CA RID: 2506
	// (get) Token: 0x06002DCD RID: 11725 RVA: 0x000AE73C File Offset: 0x000AC93C
	// (set) Token: 0x06002DCE RID: 11726 RVA: 0x000AE744 File Offset: 0x000AC944
	public global::UnityEngine.GameObject dragger
	{
		get
		{
			return this._dragger;
		}
		private set
		{
			this._dragger = value;
		}
	}

	// Token: 0x170009CB RID: 2507
	// (get) Token: 0x06002DCF RID: 11727 RVA: 0x000AE750 File Offset: 0x000AC950
	public bool open
	{
		get
		{
			return this._opened && !this._closed;
		}
	}

	// Token: 0x170009CC RID: 2508
	// (get) Token: 0x06002DD0 RID: 11728 RVA: 0x000AE76C File Offset: 0x000AC96C
	public bool closed
	{
		get
		{
			return this._closed && !this._opened;
		}
	}

	// Token: 0x170009CD RID: 2509
	// (get) Token: 0x06002DD1 RID: 11729 RVA: 0x000AE788 File Offset: 0x000AC988
	public bool showing
	{
		get
		{
			return this._showing;
		}
	}

	// Token: 0x170009CE RID: 2510
	// (get) Token: 0x06002DD2 RID: 11730 RVA: 0x000AE790 File Offset: 0x000AC990
	// (set) Token: 0x06002DD3 RID: 11731 RVA: 0x000AE7A8 File Offset: 0x000AC9A8
	public bool showWithRPOS
	{
		get
		{
			return !this._forceHide && this._showWithRPOS;
		}
		protected set
		{
			if (value != this._showWithRPOS)
			{
				this._showWithRPOS = value;
				this.CheckDisplay();
			}
		}
	}

	// Token: 0x170009CF RID: 2511
	// (get) Token: 0x06002DD4 RID: 11732 RVA: 0x000AE7C4 File Offset: 0x000AC9C4
	public bool showingWithRPOS
	{
		get
		{
			return this._showing && global::RPOS.IsOpen;
		}
	}

	// Token: 0x170009D0 RID: 2512
	// (get) Token: 0x06002DD5 RID: 11733 RVA: 0x000AE7DC File Offset: 0x000AC9DC
	// (set) Token: 0x06002DD6 RID: 11734 RVA: 0x000AE7F4 File Offset: 0x000AC9F4
	public bool showWithoutRPOS
	{
		get
		{
			return !this._forceHide && this._showWithoutRPOS;
		}
		protected set
		{
			if (value != this._showWithoutRPOS)
			{
				this._showWithoutRPOS = value;
				this.CheckDisplay();
			}
		}
	}

	// Token: 0x170009D1 RID: 2513
	// (get) Token: 0x06002DD7 RID: 11735 RVA: 0x000AE810 File Offset: 0x000ACA10
	public bool showingWithoutRPOS
	{
		get
		{
			return this._showing && !global::RPOS.IsOpen;
		}
	}

	// Token: 0x170009D2 RID: 2514
	// (get) Token: 0x06002DD8 RID: 11736 RVA: 0x000AE828 File Offset: 0x000ACA28
	// (set) Token: 0x06002DD9 RID: 11737 RVA: 0x000AE830 File Offset: 0x000ACA30
	public string title
	{
		get
		{
			return this.TitleText;
		}
		set
		{
			if (value != null && !string.Equals(this.TitleText, value))
			{
				this.SetWindowTitle(value);
			}
		}
	}

	// Token: 0x170009D3 RID: 2515
	// (get) Token: 0x06002DDA RID: 11738 RVA: 0x000AE850 File Offset: 0x000ACA50
	public bool ready
	{
		get
		{
			return this.zzz__index != -1;
		}
	}

	// Token: 0x170009D4 RID: 2516
	// (get) Token: 0x06002DDB RID: 11739 RVA: 0x000AE860 File Offset: 0x000ACA60
	public int numBelow
	{
		get
		{
			return this.order;
		}
	}

	// Token: 0x170009D5 RID: 2517
	// (get) Token: 0x06002DDC RID: 11740 RVA: 0x000AE868 File Offset: 0x000ACA68
	public int numAbove
	{
		get
		{
			return global::RPOS.WindowCount - (this.order + 1);
		}
	}

	// Token: 0x170009D6 RID: 2518
	// (get) Token: 0x06002DDD RID: 11741 RVA: 0x000AE878 File Offset: 0x000ACA78
	public int order
	{
		get
		{
			if (this.zzz__index == -1)
			{
				throw new global::System.InvalidOperationException("this window is not yet ready. you should check .ready");
			}
			return this.zzz__index;
		}
	}

	// Token: 0x170009D7 RID: 2519
	// (get) Token: 0x06002DDE RID: 11742 RVA: 0x000AE898 File Offset: 0x000ACA98
	// (set) Token: 0x06002DDF RID: 11743 RVA: 0x000AE8A4 File Offset: 0x000ACAA4
	public bool bumpersEnabled
	{
		get
		{
			return !this.bumpersDisabled;
		}
		set
		{
			this.bumpersDisabled = !value;
		}
	}

	// Token: 0x170009D8 RID: 2520
	// (get) Token: 0x06002DE0 RID: 11744 RVA: 0x000AE8B0 File Offset: 0x000ACAB0
	public bool isInventoryRelated
	{
		get
		{
			return this._isInventoryRelated;
		}
	}

	// Token: 0x06002DE1 RID: 11745 RVA: 0x000AE8B8 File Offset: 0x000ACAB8
	public bool BringToFront()
	{
		return global::RPOS.BringToFront(this);
	}

	// Token: 0x06002DE2 RID: 11746 RVA: 0x000AE8C0 File Offset: 0x000ACAC0
	public bool SendToBack()
	{
		return global::RPOS.SendToBack(this);
	}

	// Token: 0x06002DE3 RID: 11747 RVA: 0x000AE8C8 File Offset: 0x000ACAC8
	public bool MoveUp()
	{
		global::RPOSWindow.EnsureAwake(this);
		return global::RPOS.MoveUp(this);
	}

	// Token: 0x06002DE4 RID: 11748 RVA: 0x000AE8D8 File Offset: 0x000ACAD8
	public bool MoveDown()
	{
		global::RPOSWindow.EnsureAwake(this);
		return global::RPOS.MoveDown(this);
	}

	// Token: 0x06002DE5 RID: 11749 RVA: 0x000AE8E8 File Offset: 0x000ACAE8
	public bool IsAbove(global::RPOSWindow window)
	{
		return window.order < this.order;
	}

	// Token: 0x06002DE6 RID: 11750 RVA: 0x000AE8F8 File Offset: 0x000ACAF8
	public bool IsBelow(global::RPOSWindow window)
	{
		return window.order > this.order;
	}

	// Token: 0x170009D9 RID: 2521
	// (get) Token: 0x06002DE7 RID: 11751 RVA: 0x000AE908 File Offset: 0x000ACB08
	public global::RPOSWindow prevWindow
	{
		get
		{
			return global::RPOS.GetWindowBelow(this);
		}
	}

	// Token: 0x170009DA RID: 2522
	// (get) Token: 0x06002DE8 RID: 11752 RVA: 0x000AE910 File Offset: 0x000ACB10
	public global::RPOSWindow nextWindow
	{
		get
		{
			return global::RPOS.GetWindowAbove(this);
		}
	}

	// Token: 0x06002DE9 RID: 11753 RVA: 0x000AE918 File Offset: 0x000ACB18
	public void ExternalClose()
	{
		this.OnExternalClose();
	}

	// Token: 0x06002DEA RID: 11754 RVA: 0x000AE920 File Offset: 0x000ACB20
	protected void Hide()
	{
		this.showWithRPOS = false;
		this.showWithoutRPOS = false;
	}

	// Token: 0x06002DEB RID: 11755 RVA: 0x000AE930 File Offset: 0x000ACB30
	protected void SetWindowTitle(string title)
	{
		this.TitleText = title;
		this._titleObj.text = title.ToUpper();
		if (this.bumpers != null)
		{
			foreach (global::RPOSBumper.Instance instance in this.bumpers)
			{
				if (instance.label)
				{
					instance.label.text = title.ToUpper();
				}
			}
		}
	}

	// Token: 0x06002DEC RID: 11756 RVA: 0x000AE9D4 File Offset: 0x000ACBD4
	public void OnScroll(float delta)
	{
		global::UnityEngine.Debug.Log("fuck you" + delta);
	}

	// Token: 0x06002DED RID: 11757 RVA: 0x000AE9EC File Offset: 0x000ACBEC
	protected virtual void WindowAwake()
	{
		this.SetWindowTitle(this.TitleText);
	}

	// Token: 0x06002DEE RID: 11758 RVA: 0x000AE9FC File Offset: 0x000ACBFC
	protected virtual void WindowDestroy()
	{
	}

	// Token: 0x06002DEF RID: 11759 RVA: 0x000AEA00 File Offset: 0x000ACC00
	protected virtual void OnWindowShow()
	{
		this.panelsEnabled = true;
	}

	// Token: 0x06002DF0 RID: 11760 RVA: 0x000AEA0C File Offset: 0x000ACC0C
	protected virtual void OnWindowHide()
	{
		this.panelsEnabled = false;
	}

	// Token: 0x06002DF1 RID: 11761 RVA: 0x000AEA18 File Offset: 0x000ACC18
	protected virtual void OnWindowOpened()
	{
		this.BringToFront();
	}

	// Token: 0x06002DF2 RID: 11762 RVA: 0x000AEA24 File Offset: 0x000ACC24
	protected virtual void OnWindowReOpen()
	{
		this.OnWindowOpened();
	}

	// Token: 0x06002DF3 RID: 11763 RVA: 0x000AEA2C File Offset: 0x000ACC2C
	protected virtual void OnWindowClosed()
	{
	}

	// Token: 0x06002DF4 RID: 11764 RVA: 0x000AEA30 File Offset: 0x000ACC30
	protected virtual void OnRPOSClosed()
	{
	}

	// Token: 0x06002DF5 RID: 11765 RVA: 0x000AEA34 File Offset: 0x000ACC34
	protected virtual void OnRPOSOpened()
	{
	}

	// Token: 0x06002DF6 RID: 11766 RVA: 0x000AEA38 File Offset: 0x000ACC38
	protected virtual void OnBumperClick(global::RPOSBumper.Instance bumper)
	{
		if (!this.bumpersDisabled)
		{
			this.showWithRPOS = !this.showWithRPOS;
			if (this._showWithRPOS)
			{
				this.BringToFront();
			}
		}
	}

	// Token: 0x06002DF7 RID: 11767 RVA: 0x000AEA74 File Offset: 0x000ACC74
	protected virtual void SubTouch(global::UnityEngine.GameObject go, global::RPOSWindow.SubTouchKind kind)
	{
		switch (kind)
		{
		case global::RPOSWindow.SubTouchKind.Press:
			if (go == this._dragger || go == this._background)
			{
				this.BringToFront();
			}
			break;
		case global::RPOSWindow.SubTouchKind.Click:
		case global::RPOSWindow.SubTouchKind.ClickCancel:
			this.BringToFront();
			break;
		}
	}

	// Token: 0x06002DF8 RID: 11768 RVA: 0x000AEAD4 File Offset: 0x000ACCD4
	protected virtual void OnExternalClose()
	{
		this.HideOrClose(this.hidesWithExternalClose);
	}

	// Token: 0x06002DF9 RID: 11769 RVA: 0x000AEAE4 File Offset: 0x000ACCE4
	protected virtual void CloseButtonClicked()
	{
		this.HideOrClose(this.hidesWithCloseButton);
	}

	// Token: 0x06002DFA RID: 11770 RVA: 0x000AEAF4 File Offset: 0x000ACCF4
	public void MovePixelXY(int x, int y)
	{
		base.transform.position = base.transform.TransformPoint((float)x, (float)y, 0f);
	}

	// Token: 0x06002DFB RID: 11771 RVA: 0x000AEB20 File Offset: 0x000ACD20
	public void MovePixelX(int x)
	{
		this.MovePixelXY(x, 0);
	}

	// Token: 0x06002DFC RID: 11772 RVA: 0x000AEB2C File Offset: 0x000ACD2C
	public void MovePixelY(int y)
	{
		this.MovePixelXY(0, y);
	}

	// Token: 0x06002DFD RID: 11773 RVA: 0x000AEB38 File Offset: 0x000ACD38
	protected void OnDrawGizmosSelected()
	{
		global::UnityEngine.Matrix4x4 matrix = global::UnityEngine.Gizmos.matrix;
		global::UnityEngine.Gizmos.matrix = base.transform.localToWorldMatrix;
		global::UnityEngine.Gizmos.DrawWireCube(new global::UnityEngine.Vector3(this._windowDimensions.x + this._windowDimensions.z / 2f, this._windowDimensions.y + this._windowDimensions.w / 2f), new global::UnityEngine.Vector3(this._windowDimensions.z, this._windowDimensions.w));
		global::UnityEngine.Gizmos.matrix = matrix;
	}

	// Token: 0x04001787 RID: 6023
	private global::RPOSWindowMessageCenter messageCenter;

	// Token: 0x04001788 RID: 6024
	private readonly global::UIEventListener.VoidDelegate buttonCallback;

	// Token: 0x04001789 RID: 6025
	private global::System.Collections.Generic.List<global::RPOSBumper.Instance> bumpers;

	// Token: 0x0400178A RID: 6026
	private global::UIEventListener closeButtonListener;

	// Token: 0x0400178B RID: 6027
	[global::System.Obsolete("RPOS ONLY")]
	internal int zzz__index = -1;

	// Token: 0x0400178C RID: 6028
	private bool _showWithRPOS;

	// Token: 0x0400178D RID: 6029
	private bool _showWithoutRPOS;

	// Token: 0x0400178E RID: 6030
	private bool _forceHide;

	// Token: 0x0400178F RID: 6031
	private bool _showing;

	// Token: 0x04001790 RID: 6032
	private bool _opened;

	// Token: 0x04001791 RID: 6033
	private bool _closed;

	// Token: 0x04001792 RID: 6034
	private bool _awake;

	// Token: 0x04001793 RID: 6035
	private bool _destroyed;

	// Token: 0x04001794 RID: 6036
	private bool _destroyAfterAwake;

	// Token: 0x04001795 RID: 6037
	private bool _inventoryHide;

	// Token: 0x04001796 RID: 6038
	private bool _lock_awake;

	// Token: 0x04001797 RID: 6039
	private bool _lock_open;

	// Token: 0x04001798 RID: 6040
	private bool _lock_close;

	// Token: 0x04001799 RID: 6041
	private bool _lock_show;

	// Token: 0x0400179A RID: 6042
	private bool _lock_destroy;

	// Token: 0x0400179B RID: 6043
	protected bool neverAutoShow;

	// Token: 0x0400179C RID: 6044
	[global::UnityEngine.SerializeField]
	private global::UILabel _titleObj;

	// Token: 0x0400179D RID: 6045
	[global::UnityEngine.SerializeField]
	private global::UIButton _closeButton;

	// Token: 0x0400179E RID: 6046
	[global::UnityEngine.SerializeField]
	private global::UIPanel _myPanel;

	// Token: 0x0400179F RID: 6047
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.GameObject _background;

	// Token: 0x040017A0 RID: 6048
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.GameObject _dragger;

	// Token: 0x040017A1 RID: 6049
	[global::UnityEngine.SerializeField]
	private string TitleText;

	// Token: 0x040017A2 RID: 6050
	[global::UnityEngine.SerializeField]
	protected bool autoShowWithRPOS;

	// Token: 0x040017A3 RID: 6051
	[global::UnityEngine.SerializeField]
	protected bool autoShowWithoutRPOS;

	// Token: 0x040017A4 RID: 6052
	[global::UnityEngine.SerializeField]
	protected bool hidesWithCloseButton;

	// Token: 0x040017A5 RID: 6053
	[global::UnityEngine.SerializeField]
	protected bool hidesWithExternalClose;

	// Token: 0x040017A6 RID: 6054
	[global::UnityEngine.SerializeField]
	protected bool destroyWithClose;

	// Token: 0x040017A7 RID: 6055
	[global::UnityEngine.SerializeField]
	protected global::UIPanel[] childPanels;

	// Token: 0x040017A8 RID: 6056
	[global::UnityEngine.SerializeField]
	private bool _isInventoryRelated;

	// Token: 0x040017A9 RID: 6057
	[global::UnityEngine.SerializeField]
	private global::UIWidget.Pivot _shrinkPivot = global::UIWidget.Pivot.Center;

	// Token: 0x040017AA RID: 6058
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Vector4 _windowDimensions = new global::UnityEngine.Vector4(0f, 0f, 128f, 32f);

	// Token: 0x040017AB RID: 6059
	private bool bumpersDisabled;

	// Token: 0x02000540 RID: 1344
	protected enum SubTouchKind
	{
		// Token: 0x040017AD RID: 6061
		Press,
		// Token: 0x040017AE RID: 6062
		Click,
		// Token: 0x040017AF RID: 6063
		ClickCancel,
		// Token: 0x040017B0 RID: 6064
		Release
	}
}
