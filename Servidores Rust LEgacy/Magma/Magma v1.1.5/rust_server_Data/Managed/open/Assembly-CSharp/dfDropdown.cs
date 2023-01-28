using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020007E2 RID: 2018
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/Dropdown List")]
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.BoxCollider))]
public class dfDropdown : global::dfInteractiveBase, global::IDFMultiRender
{
	// Token: 0x060043C5 RID: 17349 RVA: 0x000F7A44 File Offset: 0x000F5C44
	public dfDropdown()
	{
	}

	// Token: 0x14000045 RID: 69
	// (add) Token: 0x060043C6 RID: 17350 RVA: 0x000F7B0C File Offset: 0x000F5D0C
	// (remove) Token: 0x060043C7 RID: 17351 RVA: 0x000F7B28 File Offset: 0x000F5D28
	public event global::dfDropdown.PopupEventHandler DropdownOpen
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.DropdownOpen = (global::dfDropdown.PopupEventHandler)global::System.Delegate.Combine(this.DropdownOpen, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.DropdownOpen = (global::dfDropdown.PopupEventHandler)global::System.Delegate.Remove(this.DropdownOpen, value);
		}
	}

	// Token: 0x14000046 RID: 70
	// (add) Token: 0x060043C8 RID: 17352 RVA: 0x000F7B44 File Offset: 0x000F5D44
	// (remove) Token: 0x060043C9 RID: 17353 RVA: 0x000F7B60 File Offset: 0x000F5D60
	public event global::dfDropdown.PopupEventHandler DropdownClose
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.DropdownClose = (global::dfDropdown.PopupEventHandler)global::System.Delegate.Combine(this.DropdownClose, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.DropdownClose = (global::dfDropdown.PopupEventHandler)global::System.Delegate.Remove(this.DropdownClose, value);
		}
	}

	// Token: 0x14000047 RID: 71
	// (add) Token: 0x060043CA RID: 17354 RVA: 0x000F7B7C File Offset: 0x000F5D7C
	// (remove) Token: 0x060043CB RID: 17355 RVA: 0x000F7B98 File Offset: 0x000F5D98
	public event global::PropertyChangedEventHandler<int> SelectedIndexChanged
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.SelectedIndexChanged = (global::PropertyChangedEventHandler<int>)global::System.Delegate.Combine(this.SelectedIndexChanged, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.SelectedIndexChanged = (global::PropertyChangedEventHandler<int>)global::System.Delegate.Remove(this.SelectedIndexChanged, value);
		}
	}

	// Token: 0x17000C71 RID: 3185
	// (get) Token: 0x060043CC RID: 17356 RVA: 0x000F7BB4 File Offset: 0x000F5DB4
	// (set) Token: 0x060043CD RID: 17357 RVA: 0x000F7BF8 File Offset: 0x000F5DF8
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
				this.closePopup(true);
				this.font = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C72 RID: 3186
	// (get) Token: 0x060043CE RID: 17358 RVA: 0x000F7C20 File Offset: 0x000F5E20
	// (set) Token: 0x060043CF RID: 17359 RVA: 0x000F7C28 File Offset: 0x000F5E28
	public global::dfScrollbar ListScrollbar
	{
		get
		{
			return this.listScrollbar;
		}
		set
		{
			if (value != this.listScrollbar)
			{
				this.listScrollbar = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C73 RID: 3187
	// (get) Token: 0x060043D0 RID: 17360 RVA: 0x000F7C48 File Offset: 0x000F5E48
	// (set) Token: 0x060043D1 RID: 17361 RVA: 0x000F7C50 File Offset: 0x000F5E50
	public global::UnityEngine.Vector2 ListOffset
	{
		get
		{
			return this.listOffset;
		}
		set
		{
			if (global::UnityEngine.Vector2.Distance(this.listOffset, value) > 1f)
			{
				this.listOffset = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C74 RID: 3188
	// (get) Token: 0x060043D2 RID: 17362 RVA: 0x000F7C78 File Offset: 0x000F5E78
	// (set) Token: 0x060043D3 RID: 17363 RVA: 0x000F7C80 File Offset: 0x000F5E80
	public string ListBackground
	{
		get
		{
			return this.listBackground;
		}
		set
		{
			if (value != this.listBackground)
			{
				this.closePopup(true);
				this.listBackground = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C75 RID: 3189
	// (get) Token: 0x060043D4 RID: 17364 RVA: 0x000F7CA8 File Offset: 0x000F5EA8
	// (set) Token: 0x060043D5 RID: 17365 RVA: 0x000F7CB0 File Offset: 0x000F5EB0
	public string ItemHover
	{
		get
		{
			return this.itemHover;
		}
		set
		{
			if (value != this.itemHover)
			{
				this.itemHover = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C76 RID: 3190
	// (get) Token: 0x060043D6 RID: 17366 RVA: 0x000F7CD0 File Offset: 0x000F5ED0
	// (set) Token: 0x060043D7 RID: 17367 RVA: 0x000F7CD8 File Offset: 0x000F5ED8
	public string ItemHighlight
	{
		get
		{
			return this.itemHighlight;
		}
		set
		{
			if (value != this.itemHighlight)
			{
				this.closePopup(true);
				this.itemHighlight = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C77 RID: 3191
	// (get) Token: 0x060043D8 RID: 17368 RVA: 0x000F7D00 File Offset: 0x000F5F00
	// (set) Token: 0x060043D9 RID: 17369 RVA: 0x000F7D10 File Offset: 0x000F5F10
	public string SelectedValue
	{
		get
		{
			return this.items[this.selectedIndex];
		}
		set
		{
			this.selectedIndex = -1;
			for (int i = 0; i < this.items.Length; i++)
			{
				if (this.items[i] == value)
				{
					this.selectedIndex = i;
					break;
				}
			}
		}
	}

	// Token: 0x17000C78 RID: 3192
	// (get) Token: 0x060043DA RID: 17370 RVA: 0x000F7D5C File Offset: 0x000F5F5C
	// (set) Token: 0x060043DB RID: 17371 RVA: 0x000F7D64 File Offset: 0x000F5F64
	public int SelectedIndex
	{
		get
		{
			return this.selectedIndex;
		}
		set
		{
			value = global::UnityEngine.Mathf.Max(-1, value);
			value = global::UnityEngine.Mathf.Min(this.items.Length - 1, value);
			if (value != this.selectedIndex)
			{
				if (this.popup != null)
				{
					this.popup.SelectedIndex = value;
				}
				this.selectedIndex = value;
				this.OnSelectedIndexChanged();
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C79 RID: 3193
	// (get) Token: 0x060043DC RID: 17372 RVA: 0x000F7DC8 File Offset: 0x000F5FC8
	// (set) Token: 0x060043DD RID: 17373 RVA: 0x000F7DE8 File Offset: 0x000F5FE8
	public global::UnityEngine.RectOffset TextFieldPadding
	{
		get
		{
			if (this.textFieldPadding == null)
			{
				this.textFieldPadding = new global::UnityEngine.RectOffset();
			}
			return this.textFieldPadding;
		}
		set
		{
			value = value.ConstrainPadding();
			if (!object.Equals(value, this.textFieldPadding))
			{
				this.textFieldPadding = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C7A RID: 3194
	// (get) Token: 0x060043DE RID: 17374 RVA: 0x000F7E1C File Offset: 0x000F601C
	// (set) Token: 0x060043DF RID: 17375 RVA: 0x000F7E24 File Offset: 0x000F6024
	public global::UnityEngine.Color32 TextColor
	{
		get
		{
			return this.textColor;
		}
		set
		{
			this.closePopup(true);
			this.textColor = value;
			this.Invalidate();
		}
	}

	// Token: 0x17000C7B RID: 3195
	// (get) Token: 0x060043E0 RID: 17376 RVA: 0x000F7E3C File Offset: 0x000F603C
	// (set) Token: 0x060043E1 RID: 17377 RVA: 0x000F7E44 File Offset: 0x000F6044
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
				this.closePopup(true);
				this.textScale = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C7C RID: 3196
	// (get) Token: 0x060043E2 RID: 17378 RVA: 0x000F7E84 File Offset: 0x000F6084
	// (set) Token: 0x060043E3 RID: 17379 RVA: 0x000F7E8C File Offset: 0x000F608C
	public int ItemHeight
	{
		get
		{
			return this.itemHeight;
		}
		set
		{
			value = global::UnityEngine.Mathf.Max(1, value);
			if (value != this.itemHeight)
			{
				this.closePopup(true);
				this.itemHeight = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C7D RID: 3197
	// (get) Token: 0x060043E4 RID: 17380 RVA: 0x000F7EB8 File Offset: 0x000F60B8
	// (set) Token: 0x060043E5 RID: 17381 RVA: 0x000F7ED8 File Offset: 0x000F60D8
	public string[] Items
	{
		get
		{
			if (this.items == null)
			{
				this.items = new string[0];
			}
			return this.items;
		}
		set
		{
			this.closePopup(true);
			if (value == null)
			{
				value = new string[0];
			}
			this.items = value;
			this.Invalidate();
		}
	}

	// Token: 0x17000C7E RID: 3198
	// (get) Token: 0x060043E6 RID: 17382 RVA: 0x000F7F08 File Offset: 0x000F6108
	// (set) Token: 0x060043E7 RID: 17383 RVA: 0x000F7F28 File Offset: 0x000F6128
	public global::UnityEngine.RectOffset ListPadding
	{
		get
		{
			if (this.listPadding == null)
			{
				this.listPadding = new global::UnityEngine.RectOffset();
			}
			return this.listPadding;
		}
		set
		{
			value = value.ConstrainPadding();
			if (!object.Equals(value, this.listPadding))
			{
				this.listPadding = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C7F RID: 3199
	// (get) Token: 0x060043E8 RID: 17384 RVA: 0x000F7F5C File Offset: 0x000F615C
	// (set) Token: 0x060043E9 RID: 17385 RVA: 0x000F7F64 File Offset: 0x000F6164
	public global::dfDropdown.PopupListPosition ListPosition
	{
		get
		{
			return this.listPosition;
		}
		set
		{
			if (value != this.ListPosition)
			{
				this.closePopup(true);
				this.listPosition = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C80 RID: 3200
	// (get) Token: 0x060043EA RID: 17386 RVA: 0x000F7F94 File Offset: 0x000F6194
	// (set) Token: 0x060043EB RID: 17387 RVA: 0x000F7F9C File Offset: 0x000F619C
	public int MaxListWidth
	{
		get
		{
			return this.listWidth;
		}
		set
		{
			this.listWidth = value;
		}
	}

	// Token: 0x17000C81 RID: 3201
	// (get) Token: 0x060043EC RID: 17388 RVA: 0x000F7FA8 File Offset: 0x000F61A8
	// (set) Token: 0x060043ED RID: 17389 RVA: 0x000F7FB0 File Offset: 0x000F61B0
	public int MaxListHeight
	{
		get
		{
			return this.listHeight;
		}
		set
		{
			this.listHeight = value;
			this.Invalidate();
		}
	}

	// Token: 0x17000C82 RID: 3202
	// (get) Token: 0x060043EE RID: 17390 RVA: 0x000F7FC0 File Offset: 0x000F61C0
	// (set) Token: 0x060043EF RID: 17391 RVA: 0x000F7FC8 File Offset: 0x000F61C8
	public global::dfControl TriggerButton
	{
		get
		{
			return this.triggerButton;
		}
		set
		{
			if (value != this.triggerButton)
			{
				this.detachChildEvents();
				this.triggerButton = value;
				this.attachChildEvents();
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C83 RID: 3203
	// (get) Token: 0x060043F0 RID: 17392 RVA: 0x000F8000 File Offset: 0x000F6200
	// (set) Token: 0x060043F1 RID: 17393 RVA: 0x000F8008 File Offset: 0x000F6208
	public bool OpenOnMouseDown
	{
		get
		{
			return this.openOnMouseDown;
		}
		set
		{
			this.openOnMouseDown = value;
		}
	}

	// Token: 0x17000C84 RID: 3204
	// (get) Token: 0x060043F2 RID: 17394 RVA: 0x000F8014 File Offset: 0x000F6214
	// (set) Token: 0x060043F3 RID: 17395 RVA: 0x000F801C File Offset: 0x000F621C
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

	// Token: 0x17000C85 RID: 3205
	// (get) Token: 0x060043F4 RID: 17396 RVA: 0x000F8038 File Offset: 0x000F6238
	// (set) Token: 0x060043F5 RID: 17397 RVA: 0x000F8040 File Offset: 0x000F6240
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

	// Token: 0x17000C86 RID: 3206
	// (get) Token: 0x060043F6 RID: 17398 RVA: 0x000F8078 File Offset: 0x000F6278
	// (set) Token: 0x060043F7 RID: 17399 RVA: 0x000F8080 File Offset: 0x000F6280
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

	// Token: 0x060043F8 RID: 17400 RVA: 0x000F80A0 File Offset: 0x000F62A0
	protected internal override void OnMouseWheel(global::dfMouseEventArgs args)
	{
		this.SelectedIndex = global::UnityEngine.Mathf.Max(0, this.SelectedIndex - global::UnityEngine.Mathf.RoundToInt(args.WheelDelta));
		args.Use();
		base.OnMouseWheel(args);
	}

	// Token: 0x060043F9 RID: 17401 RVA: 0x000F80D8 File Offset: 0x000F62D8
	protected internal override void OnMouseDown(global::dfMouseEventArgs args)
	{
		if (this.openOnMouseDown && !args.Used && args.Buttons == global::dfMouseButtons.Left && args.Source == this)
		{
			args.Use();
			base.OnMouseDown(args);
			if (this.popup != null)
			{
				this.closePopup(true);
			}
			else
			{
				this.openPopup();
			}
		}
		else
		{
			base.OnMouseDown(args);
		}
	}

	// Token: 0x060043FA RID: 17402 RVA: 0x000F8154 File Offset: 0x000F6354
	protected internal override void OnKeyDown(global::dfKeyEventArgs args)
	{
		global::UnityEngine.KeyCode keyCode = args.KeyCode;
		switch (keyCode)
		{
		case 0x111:
			this.SelectedIndex = global::UnityEngine.Mathf.Max(0, this.selectedIndex - 1);
			break;
		case 0x112:
			this.SelectedIndex = global::UnityEngine.Mathf.Min(this.items.Length - 1, this.selectedIndex + 1);
			break;
		default:
			if (keyCode == 0xD || keyCode == 0x20)
			{
				this.openPopup();
			}
			break;
		case 0x116:
			this.SelectedIndex = 0;
			break;
		case 0x117:
			this.SelectedIndex = this.items.Length - 1;
			break;
		}
		base.OnKeyDown(args);
	}

	// Token: 0x060043FB RID: 17403 RVA: 0x000F8214 File Offset: 0x000F6414
	public override void OnEnable()
	{
		base.OnEnable();
		bool flag = this.Font != null && this.Font.IsValid;
		if (global::UnityEngine.Application.isPlaying && !flag)
		{
			this.Font = base.GetManager().DefaultFont;
		}
	}

	// Token: 0x060043FC RID: 17404 RVA: 0x000F8268 File Offset: 0x000F6468
	public override void OnDisable()
	{
		base.OnDisable();
		this.closePopup(false);
	}

	// Token: 0x060043FD RID: 17405 RVA: 0x000F8278 File Offset: 0x000F6478
	public override void OnDestroy()
	{
		base.OnDestroy();
		this.closePopup(false);
		this.detachChildEvents();
	}

	// Token: 0x060043FE RID: 17406 RVA: 0x000F8290 File Offset: 0x000F6490
	public override void Update()
	{
		base.Update();
		this.checkForPopupClose();
	}

	// Token: 0x060043FF RID: 17407 RVA: 0x000F82A0 File Offset: 0x000F64A0
	private void checkForPopupClose()
	{
		if (this.popup == null || !global::UnityEngine.Input.GetMouseButtonDown(0))
		{
			return;
		}
		global::UnityEngine.Camera camera = base.GetCamera();
		global::UnityEngine.Ray ray = camera.ScreenPointToRay(global::UnityEngine.Input.mousePosition);
		global::UnityEngine.RaycastHit raycastHit;
		if (this.popup.collider.Raycast(ray, ref raycastHit, camera.farClipPlane))
		{
			return;
		}
		if (this.popup.Scrollbar != null && this.popup.Scrollbar.collider.Raycast(ray, ref raycastHit, camera.farClipPlane))
		{
			return;
		}
		this.closePopup(true);
	}

	// Token: 0x06004400 RID: 17408 RVA: 0x000F8340 File Offset: 0x000F6540
	public override void LateUpdate()
	{
		base.LateUpdate();
		if (!global::UnityEngine.Application.isPlaying)
		{
			return;
		}
		if (!this.eventsAttached)
		{
			this.attachChildEvents();
		}
		if (this.popup != null && !this.popup.ContainsFocus)
		{
			this.closePopup(true);
		}
	}

	// Token: 0x06004401 RID: 17409 RVA: 0x000F8398 File Offset: 0x000F6598
	private void attachChildEvents()
	{
		if (this.triggerButton != null && !this.eventsAttached)
		{
			this.eventsAttached = true;
			this.triggerButton.Click += this.trigger_Click;
		}
	}

	// Token: 0x06004402 RID: 17410 RVA: 0x000F83E0 File Offset: 0x000F65E0
	private void detachChildEvents()
	{
		if (this.triggerButton != null && this.eventsAttached)
		{
			this.triggerButton.Click -= this.trigger_Click;
			this.eventsAttached = false;
		}
	}

	// Token: 0x06004403 RID: 17411 RVA: 0x000F8428 File Offset: 0x000F6628
	private void trigger_Click(global::dfControl control, global::dfMouseEventArgs mouseEvent)
	{
		if (mouseEvent.Source == this.triggerButton && !mouseEvent.Used)
		{
			mouseEvent.Use();
			if (this.popup == null)
			{
				this.openPopup();
			}
			else
			{
				global::UnityEngine.Debug.Log("Close popup");
				this.closePopup(true);
			}
		}
	}

	// Token: 0x06004404 RID: 17412 RVA: 0x000F848C File Offset: 0x000F668C
	protected internal virtual void OnSelectedIndexChanged()
	{
		base.SignalHierarchy("OnSelectedIndexChanged", new object[]
		{
			this.selectedIndex
		});
		if (this.SelectedIndexChanged != null)
		{
			this.SelectedIndexChanged(this, this.selectedIndex);
		}
	}

	// Token: 0x06004405 RID: 17413 RVA: 0x000F84CC File Offset: 0x000F66CC
	private void renderText(global::dfRenderData buffer)
	{
		if (this.selectedIndex < 0 || this.selectedIndex >= this.items.Length)
		{
			return;
		}
		string text = this.items[this.selectedIndex];
		float num = base.PixelsToUnits();
		global::UnityEngine.Vector2 maxSize;
		maxSize..ctor(this.size.x - (float)this.textFieldPadding.horizontal, this.size.y - (float)this.textFieldPadding.vertical);
		global::UnityEngine.Vector3 vector = this.pivot.TransformToUpperLeft(base.Size);
		global::UnityEngine.Vector3 vectorOffset = new global::UnityEngine.Vector3(vector.x + (float)this.textFieldPadding.left, vector.y - (float)this.textFieldPadding.top, 0f) * num;
		global::UnityEngine.Color32 defaultColor = (!base.IsEnabled) ? base.DisabledColor : this.TextColor;
		using (global::dfFontRendererBase dfFontRendererBase = this.font.ObtainRenderer())
		{
			dfFontRendererBase.WordWrap = false;
			dfFontRendererBase.MaxSize = maxSize;
			dfFontRendererBase.PixelRatio = num;
			dfFontRendererBase.TextScale = this.TextScale;
			dfFontRendererBase.VectorOffset = vectorOffset;
			dfFontRendererBase.MultiLine = false;
			dfFontRendererBase.TextAlign = 0;
			dfFontRendererBase.ProcessMarkup = true;
			dfFontRendererBase.DefaultColor = defaultColor;
			dfFontRendererBase.OverrideMarkupColors = false;
			dfFontRendererBase.Opacity = base.CalculateOpacity();
			dfFontRendererBase.Shadow = this.Shadow;
			dfFontRendererBase.ShadowColor = this.ShadowColor;
			dfFontRendererBase.ShadowOffset = this.ShadowOffset;
			global::dfDynamicFont.DynamicFontRenderer dynamicFontRenderer = dfFontRendererBase as global::dfDynamicFont.DynamicFontRenderer;
			if (dynamicFontRenderer != null)
			{
				dynamicFontRenderer.SpriteAtlas = base.Atlas;
				dynamicFontRenderer.SpriteBuffer = buffer;
			}
			dfFontRendererBase.Render(text, buffer);
		}
	}

	// Token: 0x06004406 RID: 17414 RVA: 0x000F86A8 File Offset: 0x000F68A8
	public void AddItem(string item)
	{
		string[] array = new string[this.items.Length + 1];
		global::System.Array.Copy(this.items, array, this.items.Length);
		array[this.items.Length] = item;
		this.items = array;
	}

	// Token: 0x06004407 RID: 17415 RVA: 0x000F86EC File Offset: 0x000F68EC
	private global::UnityEngine.Vector3 calculatePopupPosition(int height)
	{
		float num = base.PixelsToUnits();
		global::UnityEngine.Vector3 vector = this.pivot.TransformToUpperLeft(base.Size);
		global::UnityEngine.Vector3 vector2 = base.transform.position + vector * num;
		global::UnityEngine.Vector3 scaledDirection = base.getScaledDirection(global::UnityEngine.Vector3.down);
		global::UnityEngine.Vector3 vector3 = base.transformOffset(this.listOffset) * num;
		global::UnityEngine.Vector3 vector4 = vector2 + vector3 + scaledDirection * base.Size.y * num;
		global::UnityEngine.Vector3 result = vector2 + vector3 - scaledDirection * this.popup.Size.y * num;
		if (this.listPosition == global::dfDropdown.PopupListPosition.Above)
		{
			return result;
		}
		if (this.listPosition == global::dfDropdown.PopupListPosition.Below)
		{
			return vector4;
		}
		global::UnityEngine.Vector3 vector5 = this.popup.transform.parent.position / num + this.popup.Parent.Pivot.TransformToUpperLeft(base.Size);
		global::UnityEngine.Vector3 vector6 = vector5 + scaledDirection * this.parent.Size.y;
		global::UnityEngine.Vector3 vector7 = vector4 / num + scaledDirection * this.popup.Size.y;
		if (vector7.y < vector6.y)
		{
			return result;
		}
		if (base.GetCamera().WorldToScreenPoint(vector7 * num).y <= 0f)
		{
			return result;
		}
		return vector4;
	}

	// Token: 0x06004408 RID: 17416 RVA: 0x000F8890 File Offset: 0x000F6A90
	private global::UnityEngine.Vector2 calculatePopupSize()
	{
		float num = (this.MaxListWidth <= 0) ? this.size.x : ((float)this.MaxListWidth);
		int num2 = this.items.Length * this.itemHeight + this.listPadding.vertical;
		if (this.items.Length == 0)
		{
			num2 = this.itemHeight / 2 + this.listPadding.vertical;
		}
		return new global::UnityEngine.Vector2(num, (float)global::UnityEngine.Mathf.Min(this.MaxListHeight, num2));
	}

	// Token: 0x06004409 RID: 17417 RVA: 0x000F8914 File Offset: 0x000F6B14
	private void openPopup()
	{
		if (this.popup != null || this.items.Length == 0)
		{
			return;
		}
		global::UnityEngine.Vector2 size2 = this.calculatePopupSize();
		this.popup = base.GetManager().AddControl<global::dfListbox>();
		this.popup.name = base.name + " - Dropdown List";
		this.popup.gameObject.hideFlags = 4;
		this.popup.Atlas = base.Atlas;
		this.popup.Anchor = (global::dfAnchorStyle.Top | global::dfAnchorStyle.Left);
		this.popup.Font = this.Font;
		this.popup.Pivot = global::dfPivotPoint.TopLeft;
		this.popup.Size = size2;
		this.popup.Font = this.Font;
		this.popup.ItemHeight = this.ItemHeight;
		this.popup.ItemHighlight = this.ItemHighlight;
		this.popup.ItemHover = this.ItemHover;
		this.popup.ItemPadding = this.TextFieldPadding;
		this.popup.ItemTextColor = this.TextColor;
		this.popup.ItemTextScale = this.TextScale;
		this.popup.Items = this.Items;
		this.popup.ListPadding = this.ListPadding;
		this.popup.BackgroundSprite = this.ListBackground;
		this.popup.Shadow = this.Shadow;
		this.popup.ShadowColor = this.ShadowColor;
		this.popup.ShadowOffset = this.ShadowOffset;
		this.popup.ZOrder = int.MaxValue;
		if (size2.y >= (float)this.MaxListHeight && this.listScrollbar != null)
		{
			global::UnityEngine.GameObject gameObject = global::UnityEngine.Object.Instantiate(this.listScrollbar.gameObject) as global::UnityEngine.GameObject;
			global::dfScrollbar activeScrollbar = gameObject.GetComponent<global::dfScrollbar>();
			float num = base.PixelsToUnits();
			global::UnityEngine.Vector3 vector = this.popup.transform.TransformDirection(global::UnityEngine.Vector3.right);
			global::UnityEngine.Vector3 position = this.popup.transform.position + vector * (size2.x - activeScrollbar.Width) * num;
			activeScrollbar.transform.parent = this.popup.transform;
			activeScrollbar.transform.position = position;
			activeScrollbar.Anchor = (global::dfAnchorStyle.Top | global::dfAnchorStyle.Bottom);
			activeScrollbar.Height = this.popup.Height;
			this.popup.Width -= activeScrollbar.Width;
			this.popup.Scrollbar = activeScrollbar;
			this.popup.SizeChanged += delegate(global::dfControl control, global::UnityEngine.Vector2 size)
			{
				activeScrollbar.Height = control.Height;
			};
		}
		global::UnityEngine.Vector3 position2 = this.calculatePopupPosition((int)this.popup.Size.y);
		this.popup.transform.position = position2;
		this.popup.transform.rotation = base.transform.rotation;
		this.popup.SelectedIndexChanged += this.popup_SelectedIndexChanged;
		this.popup.LostFocus += this.popup_LostFocus;
		this.popup.ItemClicked += this.popup_ItemClicked;
		this.popup.KeyDown += this.popup_KeyDown;
		this.popup.SelectedIndex = global::UnityEngine.Mathf.Max(0, this.SelectedIndex);
		this.popup.EnsureVisible(this.popup.SelectedIndex);
		this.popup.Focus();
		if (this.DropdownOpen != null)
		{
			bool flag = false;
			this.DropdownOpen(this, this.popup, ref flag);
		}
		base.Signal("OnDropdownOpen", new object[]
		{
			this,
			this.popup
		});
	}

	// Token: 0x0600440A RID: 17418 RVA: 0x000F8D14 File Offset: 0x000F6F14
	private void closePopup(bool allowOverride = true)
	{
		if (this.popup == null)
		{
			return;
		}
		this.popup.LostFocus -= this.popup_LostFocus;
		this.popup.SelectedIndexChanged -= this.popup_SelectedIndexChanged;
		this.popup.ItemClicked -= this.popup_ItemClicked;
		this.popup.KeyDown -= this.popup_KeyDown;
		if (!allowOverride)
		{
			global::UnityEngine.Object.Destroy(this.popup.gameObject);
			this.popup = null;
			return;
		}
		bool flag = false;
		if (this.DropdownClose != null)
		{
			this.DropdownClose(this, this.popup, ref flag);
		}
		if (!flag)
		{
			flag = base.Signal("OnDropdownClose", new object[]
			{
				this,
				this.popup
			});
		}
		if (!flag)
		{
			global::UnityEngine.Object.Destroy(this.popup.gameObject);
		}
		this.popup = null;
	}

	// Token: 0x0600440B RID: 17419 RVA: 0x000F8E10 File Offset: 0x000F7010
	private void popup_KeyDown(global::dfControl control, global::dfKeyEventArgs args)
	{
		if (args.KeyCode == 0x1B || args.KeyCode == 0xD)
		{
			this.closePopup(true);
			base.Focus();
		}
	}

	// Token: 0x0600440C RID: 17420 RVA: 0x000F8E3C File Offset: 0x000F703C
	private void popup_ItemClicked(global::dfControl control, int selectedIndex)
	{
		this.closePopup(true);
		base.Focus();
	}

	// Token: 0x0600440D RID: 17421 RVA: 0x000F8E4C File Offset: 0x000F704C
	private void popup_LostFocus(global::dfControl control, global::dfFocusEventArgs args)
	{
		if (this.popup != null && !this.popup.ContainsFocus)
		{
			this.closePopup(true);
		}
	}

	// Token: 0x0600440E RID: 17422 RVA: 0x000F8E84 File Offset: 0x000F7084
	private void popup_SelectedIndexChanged(global::dfControl control, int selectedIndex)
	{
		this.SelectedIndex = selectedIndex;
		this.Invalidate();
	}

	// Token: 0x0600440F RID: 17423 RVA: 0x000F8E94 File Offset: 0x000F7094
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

	// Token: 0x040023FC RID: 9212
	[global::UnityEngine.SerializeField]
	protected global::dfFontBase font;

	// Token: 0x040023FD RID: 9213
	[global::UnityEngine.SerializeField]
	protected int selectedIndex = -1;

	// Token: 0x040023FE RID: 9214
	[global::UnityEngine.SerializeField]
	protected global::dfControl triggerButton;

	// Token: 0x040023FF RID: 9215
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Color32 textColor = global::UnityEngine.Color.white;

	// Token: 0x04002400 RID: 9216
	[global::UnityEngine.SerializeField]
	protected float textScale = 1f;

	// Token: 0x04002401 RID: 9217
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.RectOffset textFieldPadding = new global::UnityEngine.RectOffset();

	// Token: 0x04002402 RID: 9218
	[global::UnityEngine.SerializeField]
	protected global::dfDropdown.PopupListPosition listPosition;

	// Token: 0x04002403 RID: 9219
	[global::UnityEngine.SerializeField]
	protected int listWidth;

	// Token: 0x04002404 RID: 9220
	[global::UnityEngine.SerializeField]
	protected int listHeight = 0xC8;

	// Token: 0x04002405 RID: 9221
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.RectOffset listPadding = new global::UnityEngine.RectOffset();

	// Token: 0x04002406 RID: 9222
	[global::UnityEngine.SerializeField]
	protected global::dfScrollbar listScrollbar;

	// Token: 0x04002407 RID: 9223
	[global::UnityEngine.SerializeField]
	protected int itemHeight = 0x19;

	// Token: 0x04002408 RID: 9224
	[global::UnityEngine.SerializeField]
	protected string itemHighlight = string.Empty;

	// Token: 0x04002409 RID: 9225
	[global::UnityEngine.SerializeField]
	protected string itemHover = string.Empty;

	// Token: 0x0400240A RID: 9226
	[global::UnityEngine.SerializeField]
	protected string listBackground = string.Empty;

	// Token: 0x0400240B RID: 9227
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Vector2 listOffset = global::UnityEngine.Vector2.zero;

	// Token: 0x0400240C RID: 9228
	[global::UnityEngine.SerializeField]
	protected string[] items = new string[0];

	// Token: 0x0400240D RID: 9229
	[global::UnityEngine.SerializeField]
	protected bool shadow;

	// Token: 0x0400240E RID: 9230
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Color32 shadowColor = global::UnityEngine.Color.black;

	// Token: 0x0400240F RID: 9231
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Vector2 shadowOffset = new global::UnityEngine.Vector2(1f, -1f);

	// Token: 0x04002410 RID: 9232
	[global::UnityEngine.SerializeField]
	protected bool openOnMouseDown;

	// Token: 0x04002411 RID: 9233
	private bool eventsAttached;

	// Token: 0x04002412 RID: 9234
	private global::dfListbox popup;

	// Token: 0x04002413 RID: 9235
	private global::dfRenderData textRenderData;

	// Token: 0x04002414 RID: 9236
	private global::dfList<global::dfRenderData> buffers = global::dfList<global::dfRenderData>.Obtain();

	// Token: 0x04002415 RID: 9237
	private global::dfDropdown.PopupEventHandler DropdownOpen;

	// Token: 0x04002416 RID: 9238
	private global::dfDropdown.PopupEventHandler DropdownClose;

	// Token: 0x04002417 RID: 9239
	private global::PropertyChangedEventHandler<int> SelectedIndexChanged;

	// Token: 0x020007E3 RID: 2019
	public enum PopupListPosition
	{
		// Token: 0x04002419 RID: 9241
		Below,
		// Token: 0x0400241A RID: 9242
		Above,
		// Token: 0x0400241B RID: 9243
		Automatic
	}

	// Token: 0x020007E4 RID: 2020
	// (Invoke) Token: 0x06004411 RID: 17425
	[global::dfEventCategory("Popup")]
	public delegate void PopupEventHandler(global::dfDropdown dropdown, global::dfListbox popup, ref bool overridden);

	// Token: 0x020007E5 RID: 2021
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <openPopup>c__AnonStorey67
	{
		// Token: 0x06004414 RID: 17428 RVA: 0x000F9004 File Offset: 0x000F7204
		public <openPopup>c__AnonStorey67()
		{
		}

		// Token: 0x06004415 RID: 17429 RVA: 0x000F900C File Offset: 0x000F720C
		internal void <>m__1C(global::dfControl control, global::UnityEngine.Vector2 size)
		{
			this.activeScrollbar.Height = control.Height;
		}

		// Token: 0x0400241C RID: 9244
		internal global::dfScrollbar activeScrollbar;
	}
}
