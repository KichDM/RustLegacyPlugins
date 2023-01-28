using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000830 RID: 2096
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/Containers/Scrollable Panel")]
[global::UnityEngine.ExecuteInEditMode]
public class dfScrollPanel : global::dfControl
{
	// Token: 0x06004763 RID: 18275 RVA: 0x00107968 File Offset: 0x00105B68
	public dfScrollPanel()
	{
	}

	// Token: 0x1400004E RID: 78
	// (add) Token: 0x06004764 RID: 18276 RVA: 0x001079D4 File Offset: 0x00105BD4
	// (remove) Token: 0x06004765 RID: 18277 RVA: 0x001079F0 File Offset: 0x00105BF0
	public event global::PropertyChangedEventHandler<global::UnityEngine.Vector2> ScrollPositionChanged
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.ScrollPositionChanged = (global::PropertyChangedEventHandler<global::UnityEngine.Vector2>)global::System.Delegate.Combine(this.ScrollPositionChanged, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.ScrollPositionChanged = (global::PropertyChangedEventHandler<global::UnityEngine.Vector2>)global::System.Delegate.Remove(this.ScrollPositionChanged, value);
		}
	}

	// Token: 0x17000D56 RID: 3414
	// (get) Token: 0x06004766 RID: 18278 RVA: 0x00107A0C File Offset: 0x00105C0C
	// (set) Token: 0x06004767 RID: 18279 RVA: 0x00107A14 File Offset: 0x00105C14
	public bool UseScrollMomentum
	{
		get
		{
			return this.useScrollMomentum;
		}
		set
		{
			this.useScrollMomentum = value;
			this.scrollMomentum = global::UnityEngine.Vector2.zero;
		}
	}

	// Token: 0x17000D57 RID: 3415
	// (get) Token: 0x06004768 RID: 18280 RVA: 0x00107A28 File Offset: 0x00105C28
	// (set) Token: 0x06004769 RID: 18281 RVA: 0x00107A30 File Offset: 0x00105C30
	public bool ScrollWithArrowKeys
	{
		get
		{
			return this.scrollWithArrowKeys;
		}
		set
		{
			this.scrollWithArrowKeys = value;
		}
	}

	// Token: 0x17000D58 RID: 3416
	// (get) Token: 0x0600476A RID: 18282 RVA: 0x00107A3C File Offset: 0x00105C3C
	// (set) Token: 0x0600476B RID: 18283 RVA: 0x00107A84 File Offset: 0x00105C84
	public global::dfAtlas Atlas
	{
		get
		{
			if (this.atlas == null)
			{
				global::dfGUIManager manager = base.GetManager();
				if (manager != null)
				{
					return this.atlas = manager.DefaultAtlas;
				}
			}
			return this.atlas;
		}
		set
		{
			if (!global::dfAtlas.Equals(value, this.atlas))
			{
				this.atlas = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D59 RID: 3417
	// (get) Token: 0x0600476C RID: 18284 RVA: 0x00107AA4 File Offset: 0x00105CA4
	// (set) Token: 0x0600476D RID: 18285 RVA: 0x00107AAC File Offset: 0x00105CAC
	public string BackgroundSprite
	{
		get
		{
			return this.backgroundSprite;
		}
		set
		{
			if (value != this.backgroundSprite)
			{
				this.backgroundSprite = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D5A RID: 3418
	// (get) Token: 0x0600476E RID: 18286 RVA: 0x00107ACC File Offset: 0x00105CCC
	// (set) Token: 0x0600476F RID: 18287 RVA: 0x00107AD4 File Offset: 0x00105CD4
	public global::UnityEngine.Color32 BackgroundColor
	{
		get
		{
			return this.backgroundColor;
		}
		set
		{
			if (!object.Equals(value, this.backgroundColor))
			{
				this.backgroundColor = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D5B RID: 3419
	// (get) Token: 0x06004770 RID: 18288 RVA: 0x00107B0C File Offset: 0x00105D0C
	// (set) Token: 0x06004771 RID: 18289 RVA: 0x00107B14 File Offset: 0x00105D14
	public bool AutoReset
	{
		get
		{
			return this.autoReset;
		}
		set
		{
			if (value != this.autoReset)
			{
				this.autoReset = value;
				if (value)
				{
					this.Reset();
				}
			}
		}
	}

	// Token: 0x17000D5C RID: 3420
	// (get) Token: 0x06004772 RID: 18290 RVA: 0x00107B38 File Offset: 0x00105D38
	// (set) Token: 0x06004773 RID: 18291 RVA: 0x00107B58 File Offset: 0x00105D58
	public global::UnityEngine.RectOffset ScrollPadding
	{
		get
		{
			if (this.scrollPadding == null)
			{
				this.scrollPadding = new global::UnityEngine.RectOffset();
			}
			return this.scrollPadding;
		}
		set
		{
			value = value.ConstrainPadding();
			if (!object.Equals(value, this.scrollPadding))
			{
				this.scrollPadding = value;
				this.Reset();
			}
		}
	}

	// Token: 0x17000D5D RID: 3421
	// (get) Token: 0x06004774 RID: 18292 RVA: 0x00107B8C File Offset: 0x00105D8C
	// (set) Token: 0x06004775 RID: 18293 RVA: 0x00107B94 File Offset: 0x00105D94
	public bool AutoLayout
	{
		get
		{
			return this.autoLayout;
		}
		set
		{
			if (value != this.autoLayout)
			{
				this.autoLayout = value;
				this.Reset();
			}
		}
	}

	// Token: 0x17000D5E RID: 3422
	// (get) Token: 0x06004776 RID: 18294 RVA: 0x00107BB0 File Offset: 0x00105DB0
	// (set) Token: 0x06004777 RID: 18295 RVA: 0x00107BB8 File Offset: 0x00105DB8
	public bool WrapLayout
	{
		get
		{
			return this.wrapLayout;
		}
		set
		{
			if (value != this.wrapLayout)
			{
				this.wrapLayout = value;
				this.Reset();
			}
		}
	}

	// Token: 0x17000D5F RID: 3423
	// (get) Token: 0x06004778 RID: 18296 RVA: 0x00107BD4 File Offset: 0x00105DD4
	// (set) Token: 0x06004779 RID: 18297 RVA: 0x00107BDC File Offset: 0x00105DDC
	public global::dfScrollPanel.LayoutDirection FlowDirection
	{
		get
		{
			return this.flowDirection;
		}
		set
		{
			if (value != this.flowDirection)
			{
				this.flowDirection = value;
				this.Reset();
			}
		}
	}

	// Token: 0x17000D60 RID: 3424
	// (get) Token: 0x0600477A RID: 18298 RVA: 0x00107BF8 File Offset: 0x00105DF8
	// (set) Token: 0x0600477B RID: 18299 RVA: 0x00107C18 File Offset: 0x00105E18
	public global::UnityEngine.RectOffset FlowPadding
	{
		get
		{
			if (this.flowPadding == null)
			{
				this.flowPadding = new global::UnityEngine.RectOffset();
			}
			return this.flowPadding;
		}
		set
		{
			value = value.ConstrainPadding();
			if (!object.Equals(value, this.flowPadding))
			{
				this.flowPadding = value;
				this.Reset();
			}
		}
	}

	// Token: 0x17000D61 RID: 3425
	// (get) Token: 0x0600477C RID: 18300 RVA: 0x00107C4C File Offset: 0x00105E4C
	// (set) Token: 0x0600477D RID: 18301 RVA: 0x00107C54 File Offset: 0x00105E54
	public global::UnityEngine.Vector2 ScrollPosition
	{
		get
		{
			return this.scrollPosition;
		}
		set
		{
			global::UnityEngine.Vector2 vector = this.calculateViewSize();
			global::UnityEngine.Vector2 vector2;
			vector2..ctor(this.size.x - (float)this.scrollPadding.horizontal, this.size.y - (float)this.scrollPadding.vertical);
			value = global::UnityEngine.Vector2.Min(vector - vector2, value);
			value = global::UnityEngine.Vector2.Max(global::UnityEngine.Vector2.zero, value);
			value = value.RoundToInt();
			if ((value - this.scrollPosition).sqrMagnitude > 1E-45f)
			{
				global::UnityEngine.Vector2 vector3 = value - this.scrollPosition;
				this.scrollPosition = value;
				this.scrollChildControls(vector3);
				this.updateScrollbars();
			}
			this.OnScrollPositionChanged();
		}
	}

	// Token: 0x17000D62 RID: 3426
	// (get) Token: 0x0600477E RID: 18302 RVA: 0x00107D10 File Offset: 0x00105F10
	// (set) Token: 0x0600477F RID: 18303 RVA: 0x00107D18 File Offset: 0x00105F18
	public int ScrollWheelAmount
	{
		get
		{
			return this.scrollWheelAmount;
		}
		set
		{
			this.scrollWheelAmount = value;
		}
	}

	// Token: 0x17000D63 RID: 3427
	// (get) Token: 0x06004780 RID: 18304 RVA: 0x00107D24 File Offset: 0x00105F24
	// (set) Token: 0x06004781 RID: 18305 RVA: 0x00107D2C File Offset: 0x00105F2C
	public global::dfScrollbar HorzScrollbar
	{
		get
		{
			return this.horzScroll;
		}
		set
		{
			this.horzScroll = value;
			this.updateScrollbars();
		}
	}

	// Token: 0x17000D64 RID: 3428
	// (get) Token: 0x06004782 RID: 18306 RVA: 0x00107D3C File Offset: 0x00105F3C
	// (set) Token: 0x06004783 RID: 18307 RVA: 0x00107D44 File Offset: 0x00105F44
	public global::dfScrollbar VertScrollbar
	{
		get
		{
			return this.vertScroll;
		}
		set
		{
			this.vertScroll = value;
			this.updateScrollbars();
		}
	}

	// Token: 0x17000D65 RID: 3429
	// (get) Token: 0x06004784 RID: 18308 RVA: 0x00107D54 File Offset: 0x00105F54
	// (set) Token: 0x06004785 RID: 18309 RVA: 0x00107D5C File Offset: 0x00105F5C
	public global::dfControlOrientation WheelScrollDirection
	{
		get
		{
			return this.wheelDirection;
		}
		set
		{
			this.wheelDirection = value;
		}
	}

	// Token: 0x06004786 RID: 18310 RVA: 0x00107D68 File Offset: 0x00105F68
	protected internal override global::UnityEngine.Plane[] GetClippingPlanes()
	{
		if (!base.ClipChildren)
		{
			return null;
		}
		global::UnityEngine.Vector3[] corners = base.GetCorners();
		global::UnityEngine.Vector3 vector = base.transform.TransformDirection(global::UnityEngine.Vector3.right);
		global::UnityEngine.Vector3 vector2 = base.transform.TransformDirection(global::UnityEngine.Vector3.left);
		global::UnityEngine.Vector3 vector3 = base.transform.TransformDirection(global::UnityEngine.Vector3.up);
		global::UnityEngine.Vector3 vector4 = base.transform.TransformDirection(global::UnityEngine.Vector3.down);
		float num = base.PixelsToUnits();
		global::UnityEngine.RectOffset rectOffset = this.ScrollPadding;
		corners[0] += vector * (float)rectOffset.left * num + vector4 * (float)rectOffset.top * num;
		corners[1] += vector2 * (float)rectOffset.right * num + vector4 * (float)rectOffset.top * num;
		corners[2] += vector * (float)rectOffset.left * num + vector3 * (float)rectOffset.bottom * num;
		return new global::UnityEngine.Plane[]
		{
			new global::UnityEngine.Plane(vector, corners[0]),
			new global::UnityEngine.Plane(vector2, corners[1]),
			new global::UnityEngine.Plane(vector3, corners[2]),
			new global::UnityEngine.Plane(vector4, corners[0])
		};
	}

	// Token: 0x17000D66 RID: 3430
	// (get) Token: 0x06004787 RID: 18311 RVA: 0x00107F34 File Offset: 0x00106134
	public override bool CanFocus
	{
		get
		{
			return (base.IsEnabled && base.IsVisible) || base.CanFocus;
		}
	}

	// Token: 0x06004788 RID: 18312 RVA: 0x00107F54 File Offset: 0x00106154
	public override void OnDestroy()
	{
		if (this.horzScroll != null)
		{
			this.horzScroll.ValueChanged -= this.horzScroll_ValueChanged;
		}
		if (this.vertScroll != null)
		{
			this.vertScroll.ValueChanged -= this.vertScroll_ValueChanged;
		}
		this.horzScroll = null;
		this.vertScroll = null;
	}

	// Token: 0x06004789 RID: 18313 RVA: 0x00107FC0 File Offset: 0x001061C0
	public override void Update()
	{
		base.Update();
		if (this.useScrollMomentum && !this.isMouseDown && this.scrollMomentum.sqrMagnitude > 1E-45f)
		{
			this.ScrollPosition += this.scrollMomentum;
		}
		if (this.isControlInvalidated && this.autoLayout && base.IsVisible)
		{
			this.AutoArrange();
			this.updateScrollbars();
		}
		this.scrollMomentum *= 0.95f - global::UnityEngine.Time.deltaTime;
	}

	// Token: 0x0600478A RID: 18314 RVA: 0x00108060 File Offset: 0x00106260
	public override void LateUpdate()
	{
		base.LateUpdate();
		this.initialize();
		if (this.resetNeeded && base.IsVisible)
		{
			this.resetNeeded = false;
			if (this.autoReset || this.autoLayout)
			{
				this.Reset();
			}
		}
	}

	// Token: 0x0600478B RID: 18315 RVA: 0x001080B4 File Offset: 0x001062B4
	public override void OnEnable()
	{
		base.OnEnable();
		if (this.size == global::UnityEngine.Vector2.zero)
		{
			this.SuspendLayout();
			global::UnityEngine.Camera camera = base.GetCamera();
			base.Size = new global::UnityEngine.Vector3(camera.pixelWidth / 2f, camera.pixelHeight / 2f);
			this.ResumeLayout();
		}
		if (this.autoLayout)
		{
			this.AutoArrange();
		}
		this.updateScrollbars();
	}

	// Token: 0x0600478C RID: 18316 RVA: 0x00108130 File Offset: 0x00106330
	protected internal override void OnIsVisibleChanged()
	{
		base.OnIsVisibleChanged();
		if (base.IsVisible && (this.autoReset || this.autoLayout))
		{
			this.Reset();
			this.updateScrollbars();
		}
	}

	// Token: 0x0600478D RID: 18317 RVA: 0x00108168 File Offset: 0x00106368
	protected internal override void OnSizeChanged()
	{
		base.OnSizeChanged();
		if (this.autoReset || this.autoLayout)
		{
			this.Reset();
			return;
		}
		global::UnityEngine.Vector2 vector = this.calculateMinChildPosition();
		if (vector.x > (float)this.scrollPadding.left || vector.y > (float)this.scrollPadding.top)
		{
			vector -= new global::UnityEngine.Vector2((float)this.scrollPadding.left, (float)this.scrollPadding.top);
			vector = global::UnityEngine.Vector2.Max(vector, global::UnityEngine.Vector2.zero);
			this.scrollChildControls(vector);
		}
		this.updateScrollbars();
	}

	// Token: 0x0600478E RID: 18318 RVA: 0x00108214 File Offset: 0x00106414
	protected internal override void OnResolutionChanged(global::UnityEngine.Vector2 previousResolution, global::UnityEngine.Vector2 currentResolution)
	{
		base.OnResolutionChanged(previousResolution, currentResolution);
		this.resetNeeded = true;
	}

	// Token: 0x0600478F RID: 18319 RVA: 0x00108228 File Offset: 0x00106428
	protected internal override void OnGotFocus(global::dfFocusEventArgs args)
	{
		if (args.Source != this)
		{
			this.ScrollIntoView(args.Source);
		}
		base.OnGotFocus(args);
	}

	// Token: 0x06004790 RID: 18320 RVA: 0x0010825C File Offset: 0x0010645C
	protected internal override void OnKeyDown(global::dfKeyEventArgs args)
	{
		if (!this.scrollWithArrowKeys || args.Used)
		{
			base.OnKeyDown(args);
			return;
		}
		float num = (!(this.horzScroll != null)) ? 1f : this.horzScroll.IncrementAmount;
		float num2 = (!(this.vertScroll != null)) ? 1f : this.vertScroll.IncrementAmount;
		if (args.KeyCode == 0x114)
		{
			this.ScrollPosition += new global::UnityEngine.Vector2(-num, 0f);
			args.Use();
		}
		else if (args.KeyCode == 0x113)
		{
			this.ScrollPosition += new global::UnityEngine.Vector2(num, 0f);
			args.Use();
		}
		else if (args.KeyCode == 0x111)
		{
			this.ScrollPosition += new global::UnityEngine.Vector2(0f, -num2);
			args.Use();
		}
		else if (args.KeyCode == 0x112)
		{
			this.ScrollPosition += new global::UnityEngine.Vector2(0f, num2);
			args.Use();
		}
		base.OnKeyDown(args);
	}

	// Token: 0x06004791 RID: 18321 RVA: 0x001083B8 File Offset: 0x001065B8
	protected internal override void OnMouseEnter(global::dfMouseEventArgs args)
	{
		base.OnMouseEnter(args);
		this.touchStartPosition = args.Position;
	}

	// Token: 0x06004792 RID: 18322 RVA: 0x001083D0 File Offset: 0x001065D0
	protected internal override void OnMouseDown(global::dfMouseEventArgs args)
	{
		base.OnMouseDown(args);
		this.touchStartPosition = args.Position;
		this.isMouseDown = true;
	}

	// Token: 0x06004793 RID: 18323 RVA: 0x001083EC File Offset: 0x001065EC
	internal override void OnDragStart(global::dfDragEventArgs args)
	{
		base.OnDragStart(args);
		if (args.Used)
		{
			this.isMouseDown = false;
		}
	}

	// Token: 0x06004794 RID: 18324 RVA: 0x00108408 File Offset: 0x00106608
	protected internal override void OnMouseUp(global::dfMouseEventArgs args)
	{
		base.OnMouseUp(args);
		this.isMouseDown = false;
	}

	// Token: 0x06004795 RID: 18325 RVA: 0x00108418 File Offset: 0x00106618
	protected internal override void OnMouseMove(global::dfMouseEventArgs args)
	{
		if ((args is global::dfTouchEventArgs || this.isMouseDown) && !args.Used && (args.Position - this.touchStartPosition).magnitude > 5f)
		{
			global::UnityEngine.Vector2 vector = args.MoveDelta.Scale(-1f, 1f);
			this.ScrollPosition += vector;
			this.scrollMomentum = (this.scrollMomentum + vector) * 0.5f;
			args.Use();
		}
		base.OnMouseMove(args);
	}

	// Token: 0x06004796 RID: 18326 RVA: 0x001084BC File Offset: 0x001066BC
	protected internal override void OnMouseWheel(global::dfMouseEventArgs args)
	{
		try
		{
			if (!args.Used)
			{
				float num = (this.wheelDirection != global::dfControlOrientation.Horizontal) ? ((!(this.vertScroll != null)) ? ((float)this.scrollWheelAmount) : this.vertScroll.IncrementAmount) : ((!(this.horzScroll != null)) ? ((float)this.scrollWheelAmount) : this.horzScroll.IncrementAmount);
				if (this.wheelDirection == global::dfControlOrientation.Horizontal)
				{
					this.ScrollPosition = new global::UnityEngine.Vector2(this.scrollPosition.x - num * args.WheelDelta, this.scrollPosition.y);
					this.scrollMomentum = new global::UnityEngine.Vector2(-num * args.WheelDelta, 0f);
				}
				else
				{
					this.ScrollPosition = new global::UnityEngine.Vector2(this.scrollPosition.x, this.scrollPosition.y - num * args.WheelDelta);
					this.scrollMomentum = new global::UnityEngine.Vector2(0f, -num * args.WheelDelta);
				}
				args.Use();
				base.Signal("OnMouseWheel", new object[]
				{
					args
				});
			}
		}
		finally
		{
			base.OnMouseWheel(args);
		}
	}

	// Token: 0x06004797 RID: 18327 RVA: 0x00108618 File Offset: 0x00106818
	protected internal override void OnControlAdded(global::dfControl child)
	{
		base.OnControlAdded(child);
		this.attachEvents(child);
		if (this.autoLayout)
		{
			this.AutoArrange();
		}
	}

	// Token: 0x06004798 RID: 18328 RVA: 0x0010863C File Offset: 0x0010683C
	protected internal override void OnControlRemoved(global::dfControl child)
	{
		base.OnControlRemoved(child);
		if (child != null)
		{
			this.detachEvents(child);
		}
		if (this.autoLayout)
		{
			this.AutoArrange();
		}
		else
		{
			this.updateScrollbars();
		}
	}

	// Token: 0x06004799 RID: 18329 RVA: 0x00108680 File Offset: 0x00106880
	protected override void OnRebuildRenderData()
	{
		if (this.Atlas == null || string.IsNullOrEmpty(this.backgroundSprite))
		{
			return;
		}
		global::dfAtlas.ItemInfo itemInfo = this.Atlas[this.backgroundSprite];
		if (itemInfo == null)
		{
			return;
		}
		this.renderData.Material = this.Atlas.Material;
		global::UnityEngine.Color32 color = base.ApplyOpacity(this.BackgroundColor);
		global::dfSprite.RenderOptions options = new global::dfSprite.RenderOptions
		{
			atlas = this.atlas,
			color = color,
			fillAmount = 1f,
			offset = this.pivot.TransformToUpperLeft(base.Size),
			pixelsToUnits = base.PixelsToUnits(),
			size = base.Size,
			spriteInfo = itemInfo
		};
		if (itemInfo.border.horizontal == 0 && itemInfo.border.vertical == 0)
		{
			global::dfSprite.renderSprite(this.renderData, options);
		}
		else
		{
			global::dfSlicedSprite.renderSprite(this.renderData, options);
		}
	}

	// Token: 0x0600479A RID: 18330 RVA: 0x00108798 File Offset: 0x00106998
	protected internal void OnScrollPositionChanged()
	{
		this.Invalidate();
		base.SignalHierarchy("OnScrollPositionChanged", new object[]
		{
			this.ScrollPosition
		});
		if (this.ScrollPositionChanged != null)
		{
			this.ScrollPositionChanged(this, this.ScrollPosition);
		}
	}

	// Token: 0x0600479B RID: 18331 RVA: 0x001087E8 File Offset: 0x001069E8
	public void FitToContents()
	{
		if (this.controls.Count == 0)
		{
			return;
		}
		global::UnityEngine.Vector2 vector = global::UnityEngine.Vector2.zero;
		for (int i = 0; i < this.controls.Count; i++)
		{
			global::dfControl dfControl = this.controls[i];
			global::UnityEngine.Vector2 vector2 = dfControl.RelativePosition + dfControl.Size;
			vector = global::UnityEngine.Vector2.Max(vector, vector2);
		}
		base.Size = vector + new global::UnityEngine.Vector2((float)this.scrollPadding.right, (float)this.scrollPadding.bottom);
	}

	// Token: 0x0600479C RID: 18332 RVA: 0x00108880 File Offset: 0x00106A80
	public void CenterChildControls()
	{
		if (this.controls.Count == 0)
		{
			return;
		}
		global::UnityEngine.Vector2 vector = global::UnityEngine.Vector2.one * float.MaxValue;
		global::UnityEngine.Vector2 vector2 = global::UnityEngine.Vector2.one * float.MinValue;
		for (int i = 0; i < this.controls.Count; i++)
		{
			global::dfControl dfControl = this.controls[i];
			global::UnityEngine.Vector2 vector3 = dfControl.RelativePosition;
			global::UnityEngine.Vector2 vector4 = vector3 + dfControl.Size;
			vector = global::UnityEngine.Vector2.Min(vector, vector3);
			vector2 = global::UnityEngine.Vector2.Max(vector2, vector4);
		}
		global::UnityEngine.Vector2 vector5 = vector2 - vector;
		global::UnityEngine.Vector2 vector6 = (base.Size - vector5) * 0.5f;
		for (int j = 0; j < this.controls.Count; j++)
		{
			global::dfControl dfControl2 = this.controls[j];
			dfControl2.RelativePosition = dfControl2.RelativePosition - vector + vector6;
		}
	}

	// Token: 0x0600479D RID: 18333 RVA: 0x0010898C File Offset: 0x00106B8C
	public void ScrollToTop()
	{
		this.ScrollPosition = new global::UnityEngine.Vector2(this.scrollPosition.x, 0f);
	}

	// Token: 0x0600479E RID: 18334 RVA: 0x001089AC File Offset: 0x00106BAC
	public void ScrollToBottom()
	{
		this.ScrollPosition = new global::UnityEngine.Vector2(this.scrollPosition.x, 2.1474836E+09f);
	}

	// Token: 0x0600479F RID: 18335 RVA: 0x001089CC File Offset: 0x00106BCC
	public void ScrollToLeft()
	{
		this.ScrollPosition = new global::UnityEngine.Vector2(0f, this.scrollPosition.y);
	}

	// Token: 0x060047A0 RID: 18336 RVA: 0x001089EC File Offset: 0x00106BEC
	public void ScrollToRight()
	{
		this.ScrollPosition = new global::UnityEngine.Vector2(2.1474836E+09f, this.scrollPosition.y);
	}

	// Token: 0x060047A1 RID: 18337 RVA: 0x00108A0C File Offset: 0x00106C0C
	public void ScrollIntoView(global::dfControl control)
	{
		global::UnityEngine.Rect rect = new global::UnityEngine.Rect(this.scrollPosition.x + (float)this.scrollPadding.left, this.scrollPosition.y + (float)this.scrollPadding.top, this.size.x - (float)this.scrollPadding.horizontal, this.size.y - (float)this.scrollPadding.vertical).RoundToInt();
		global::UnityEngine.Vector3 vector = control.RelativePosition;
		global::UnityEngine.Vector2 size = control.Size;
		while (!this.controls.Contains(control))
		{
			control = control.Parent;
			vector += control.RelativePosition;
		}
		global::UnityEngine.Rect other = new global::UnityEngine.Rect(this.scrollPosition.x + vector.x, this.scrollPosition.y + vector.y, size.x, size.y).RoundToInt();
		if (rect.Contains(other))
		{
			return;
		}
		global::UnityEngine.Vector2 vector2 = this.scrollPosition;
		if (other.xMin < rect.xMin)
		{
			vector2.x = other.xMin - (float)this.scrollPadding.left;
		}
		else if (other.xMax > rect.xMax)
		{
			vector2.x = other.xMax - global::UnityEngine.Mathf.Max(this.size.x, size.x) + (float)this.scrollPadding.horizontal;
		}
		if (other.y < rect.y)
		{
			vector2.y = other.yMin - (float)this.scrollPadding.top;
		}
		else if (other.yMax > rect.yMax)
		{
			vector2.y = other.yMax - global::UnityEngine.Mathf.Max(this.size.y, size.y) + (float)this.scrollPadding.vertical;
		}
		this.ScrollPosition = vector2;
		this.scrollMomentum = global::UnityEngine.Vector2.zero;
	}

	// Token: 0x060047A2 RID: 18338 RVA: 0x00108C18 File Offset: 0x00106E18
	public void Reset()
	{
		try
		{
			this.SuspendLayout();
			if (this.autoLayout)
			{
				global::UnityEngine.Vector2 vector = this.ScrollPosition;
				this.ScrollPosition = global::UnityEngine.Vector2.zero;
				this.AutoArrange();
				this.ScrollPosition = vector;
			}
			else
			{
				this.scrollPadding = this.ScrollPadding.ConstrainPadding();
				global::UnityEngine.Vector3 vector2 = this.calculateMinChildPosition();
				vector2 -= new global::UnityEngine.Vector3((float)this.scrollPadding.left, (float)this.scrollPadding.top);
				for (int i = 0; i < this.controls.Count; i++)
				{
					this.controls[i].RelativePosition -= vector2;
				}
				this.scrollPosition = global::UnityEngine.Vector2.zero;
			}
			this.Invalidate();
			this.updateScrollbars();
		}
		finally
		{
			this.ResumeLayout();
		}
	}

	// Token: 0x060047A3 RID: 18339 RVA: 0x00108D14 File Offset: 0x00106F14
	[global::UnityEngine.HideInInspector]
	private void AutoArrange()
	{
		this.SuspendLayout();
		try
		{
			this.scrollPadding = this.ScrollPadding.ConstrainPadding();
			this.flowPadding = this.FlowPadding.ConstrainPadding();
			float num = (float)this.scrollPadding.left + (float)this.flowPadding.left - this.scrollPosition.x;
			float num2 = (float)this.scrollPadding.top + (float)this.flowPadding.top - this.scrollPosition.y;
			float num3 = 0f;
			float num4 = 0f;
			for (int i = 0; i < this.controls.Count; i++)
			{
				global::dfControl dfControl = this.controls[i];
				if (dfControl.IsVisible && dfControl.enabled && dfControl.gameObject.activeSelf)
				{
					if (!(dfControl == this.horzScroll) && !(dfControl == this.vertScroll))
					{
						if (this.wrapLayout)
						{
							if (this.flowDirection == global::dfScrollPanel.LayoutDirection.Horizontal)
							{
								if (num + dfControl.Width >= this.size.x - (float)this.scrollPadding.right)
								{
									num = (float)this.scrollPadding.left + (float)this.flowPadding.left;
									num2 += num4;
									num4 = 0f;
								}
							}
							else if (num2 + dfControl.Height + (float)this.flowPadding.vertical >= this.size.y - (float)this.scrollPadding.bottom)
							{
								num2 = (float)this.scrollPadding.top + (float)this.flowPadding.top;
								num += num3;
								num3 = 0f;
							}
						}
						global::UnityEngine.Vector2 vector;
						vector..ctor(num, num2);
						dfControl.RelativePosition = vector;
						float num5 = dfControl.Width + (float)this.flowPadding.horizontal;
						float num6 = dfControl.Height + (float)this.flowPadding.vertical;
						num3 = global::UnityEngine.Mathf.Max(num5, num3);
						num4 = global::UnityEngine.Mathf.Max(num6, num4);
						if (this.flowDirection == global::dfScrollPanel.LayoutDirection.Horizontal)
						{
							num += num5;
						}
						else
						{
							num2 += num6;
						}
					}
				}
			}
			this.updateScrollbars();
		}
		finally
		{
			this.ResumeLayout();
		}
	}

	// Token: 0x060047A4 RID: 18340 RVA: 0x00108F80 File Offset: 0x00107180
	[global::UnityEngine.HideInInspector]
	private void initialize()
	{
		if (this.initialized)
		{
			return;
		}
		this.initialized = true;
		if (global::UnityEngine.Application.isPlaying)
		{
			if (this.horzScroll != null)
			{
				this.horzScroll.ValueChanged += this.horzScroll_ValueChanged;
			}
			if (this.vertScroll != null)
			{
				this.vertScroll.ValueChanged += this.vertScroll_ValueChanged;
			}
		}
		if (this.resetNeeded || this.autoLayout || this.autoReset)
		{
			this.Reset();
		}
		this.Invalidate();
		this.ScrollPosition = global::UnityEngine.Vector2.zero;
		this.updateScrollbars();
	}

	// Token: 0x060047A5 RID: 18341 RVA: 0x00109038 File Offset: 0x00107238
	private void vertScroll_ValueChanged(global::dfControl control, float value)
	{
		this.ScrollPosition = new global::UnityEngine.Vector2(this.scrollPosition.x, value);
	}

	// Token: 0x060047A6 RID: 18342 RVA: 0x00109054 File Offset: 0x00107254
	private void horzScroll_ValueChanged(global::dfControl control, float value)
	{
		this.ScrollPosition = new global::UnityEngine.Vector2(value, this.ScrollPosition.y);
	}

	// Token: 0x060047A7 RID: 18343 RVA: 0x0010907C File Offset: 0x0010727C
	private void scrollChildControls(global::UnityEngine.Vector3 delta)
	{
		try
		{
			this.scrolling = true;
			delta = delta.Scale(1f, -1f, 1f);
			for (int i = 0; i < this.controls.Count; i++)
			{
				global::dfControl dfControl = this.controls[i];
				dfControl.Position = (dfControl.Position - delta).RoundToInt();
			}
		}
		finally
		{
			this.scrolling = false;
		}
	}

	// Token: 0x060047A8 RID: 18344 RVA: 0x00109110 File Offset: 0x00107310
	private global::UnityEngine.Vector2 calculateMinChildPosition()
	{
		float num = float.MaxValue;
		float num2 = float.MaxValue;
		for (int i = 0; i < this.controls.Count; i++)
		{
			global::dfControl dfControl = this.controls[i];
			if (dfControl.enabled && dfControl.gameObject.activeSelf)
			{
				global::UnityEngine.Vector3 vector = dfControl.RelativePosition.FloorToInt();
				num = global::UnityEngine.Mathf.Min(num, vector.x);
				num2 = global::UnityEngine.Mathf.Min(num2, vector.y);
			}
		}
		return new global::UnityEngine.Vector2(num, num2);
	}

	// Token: 0x060047A9 RID: 18345 RVA: 0x001091A4 File Offset: 0x001073A4
	private global::UnityEngine.Vector2 calculateViewSize()
	{
		global::UnityEngine.Vector2 vector = new global::UnityEngine.Vector2((float)this.scrollPadding.horizontal, (float)this.scrollPadding.vertical).RoundToInt();
		global::UnityEngine.Vector2 vector2 = base.Size.RoundToInt() - vector;
		if (!base.IsVisible || this.controls.Count == 0)
		{
			return vector2;
		}
		global::UnityEngine.Vector2 vector3 = global::UnityEngine.Vector2.one * float.MaxValue;
		global::UnityEngine.Vector2 vector4 = global::UnityEngine.Vector2.one * float.MinValue;
		for (int i = 0; i < this.controls.Count; i++)
		{
			global::dfControl dfControl = this.controls[i];
			if (!global::UnityEngine.Application.isPlaying || dfControl.IsVisible)
			{
				global::UnityEngine.Vector2 vector5 = dfControl.RelativePosition.RoundToInt();
				global::UnityEngine.Vector2 vector6 = vector5 + dfControl.Size.RoundToInt();
				vector3 = global::UnityEngine.Vector2.Min(vector5, vector3);
				vector4 = global::UnityEngine.Vector2.Max(vector6, vector4);
			}
		}
		vector4 = global::UnityEngine.Vector2.Max(vector4, vector2);
		return vector4 - vector3;
	}

	// Token: 0x060047AA RID: 18346 RVA: 0x001092B8 File Offset: 0x001074B8
	[global::UnityEngine.HideInInspector]
	private void updateScrollbars()
	{
		global::UnityEngine.Vector2 vector = this.calculateViewSize();
		global::UnityEngine.Vector2 vector2 = base.Size - new global::UnityEngine.Vector2((float)this.scrollPadding.horizontal, (float)this.scrollPadding.vertical);
		if (this.horzScroll != null)
		{
			this.horzScroll.MinValue = 0f;
			this.horzScroll.MaxValue = vector.x;
			this.horzScroll.ScrollSize = vector2.x;
			this.horzScroll.Value = global::UnityEngine.Mathf.Max(0f, this.scrollPosition.x);
		}
		if (this.vertScroll != null)
		{
			this.vertScroll.MinValue = 0f;
			this.vertScroll.MaxValue = vector.y;
			this.vertScroll.ScrollSize = vector2.y;
			this.vertScroll.Value = global::UnityEngine.Mathf.Max(0f, this.scrollPosition.y);
		}
	}

	// Token: 0x060047AB RID: 18347 RVA: 0x001093C0 File Offset: 0x001075C0
	private void attachEvents(global::dfControl control)
	{
		control.IsVisibleChanged += this.childIsVisibleChanged;
		control.PositionChanged += this.childControlInvalidated;
		control.SizeChanged += this.childControlInvalidated;
		control.ZOrderChanged += this.childOrderChanged;
	}

	// Token: 0x060047AC RID: 18348 RVA: 0x00109418 File Offset: 0x00107618
	private void detachEvents(global::dfControl control)
	{
		control.IsVisibleChanged -= this.childIsVisibleChanged;
		control.PositionChanged -= this.childControlInvalidated;
		control.SizeChanged -= this.childControlInvalidated;
		control.ZOrderChanged -= this.childOrderChanged;
	}

	// Token: 0x060047AD RID: 18349 RVA: 0x00109470 File Offset: 0x00107670
	private void childOrderChanged(global::dfControl control, int value)
	{
		this.onChildControlInvalidatedLayout();
	}

	// Token: 0x060047AE RID: 18350 RVA: 0x00109478 File Offset: 0x00107678
	private void childIsVisibleChanged(global::dfControl control, bool value)
	{
		this.onChildControlInvalidatedLayout();
	}

	// Token: 0x060047AF RID: 18351 RVA: 0x00109480 File Offset: 0x00107680
	private void childControlInvalidated(global::dfControl control, global::UnityEngine.Vector2 value)
	{
		this.onChildControlInvalidatedLayout();
	}

	// Token: 0x060047B0 RID: 18352 RVA: 0x00109488 File Offset: 0x00107688
	[global::UnityEngine.HideInInspector]
	private void onChildControlInvalidatedLayout()
	{
		if (this.scrolling || base.IsLayoutSuspended)
		{
			return;
		}
		if (this.autoLayout)
		{
			this.AutoArrange();
		}
		this.updateScrollbars();
		this.Invalidate();
	}

	// Token: 0x0400266F RID: 9839
	[global::UnityEngine.SerializeField]
	protected global::dfAtlas atlas;

	// Token: 0x04002670 RID: 9840
	[global::UnityEngine.SerializeField]
	protected string backgroundSprite;

	// Token: 0x04002671 RID: 9841
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Color32 backgroundColor = global::UnityEngine.Color.white;

	// Token: 0x04002672 RID: 9842
	[global::UnityEngine.SerializeField]
	protected bool autoReset = true;

	// Token: 0x04002673 RID: 9843
	[global::UnityEngine.SerializeField]
	protected bool autoLayout;

	// Token: 0x04002674 RID: 9844
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.RectOffset scrollPadding = new global::UnityEngine.RectOffset();

	// Token: 0x04002675 RID: 9845
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.RectOffset flowPadding = new global::UnityEngine.RectOffset();

	// Token: 0x04002676 RID: 9846
	[global::UnityEngine.SerializeField]
	protected global::dfScrollPanel.LayoutDirection flowDirection;

	// Token: 0x04002677 RID: 9847
	[global::UnityEngine.SerializeField]
	protected bool wrapLayout;

	// Token: 0x04002678 RID: 9848
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Vector2 scrollPosition = global::UnityEngine.Vector2.zero;

	// Token: 0x04002679 RID: 9849
	[global::UnityEngine.SerializeField]
	protected int scrollWheelAmount = 0xA;

	// Token: 0x0400267A RID: 9850
	[global::UnityEngine.SerializeField]
	protected global::dfScrollbar horzScroll;

	// Token: 0x0400267B RID: 9851
	[global::UnityEngine.SerializeField]
	protected global::dfScrollbar vertScroll;

	// Token: 0x0400267C RID: 9852
	[global::UnityEngine.SerializeField]
	protected global::dfControlOrientation wheelDirection;

	// Token: 0x0400267D RID: 9853
	[global::UnityEngine.SerializeField]
	protected bool scrollWithArrowKeys;

	// Token: 0x0400267E RID: 9854
	[global::UnityEngine.SerializeField]
	protected bool useScrollMomentum;

	// Token: 0x0400267F RID: 9855
	private bool initialized;

	// Token: 0x04002680 RID: 9856
	private bool resetNeeded;

	// Token: 0x04002681 RID: 9857
	private bool scrolling;

	// Token: 0x04002682 RID: 9858
	private bool isMouseDown;

	// Token: 0x04002683 RID: 9859
	private global::UnityEngine.Vector2 touchStartPosition = global::UnityEngine.Vector2.zero;

	// Token: 0x04002684 RID: 9860
	private global::UnityEngine.Vector2 scrollMomentum = global::UnityEngine.Vector2.zero;

	// Token: 0x04002685 RID: 9861
	private global::PropertyChangedEventHandler<global::UnityEngine.Vector2> ScrollPositionChanged;

	// Token: 0x02000831 RID: 2097
	public enum LayoutDirection
	{
		// Token: 0x04002687 RID: 9863
		Horizontal,
		// Token: 0x04002688 RID: 9864
		Vertical
	}
}
