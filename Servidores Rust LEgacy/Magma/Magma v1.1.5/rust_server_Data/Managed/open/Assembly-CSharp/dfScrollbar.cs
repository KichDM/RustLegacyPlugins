using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000832 RID: 2098
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/Scrollbar")]
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.BoxCollider))]
public class dfScrollbar : global::dfControl
{
	// Token: 0x060047B1 RID: 18353 RVA: 0x001094CC File Offset: 0x001076CC
	public dfScrollbar()
	{
	}

	// Token: 0x1400004F RID: 79
	// (add) Token: 0x060047B2 RID: 18354 RVA: 0x0010952C File Offset: 0x0010772C
	// (remove) Token: 0x060047B3 RID: 18355 RVA: 0x00109548 File Offset: 0x00107748
	public event global::PropertyChangedEventHandler<float> ValueChanged
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.ValueChanged = (global::PropertyChangedEventHandler<float>)global::System.Delegate.Combine(this.ValueChanged, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.ValueChanged = (global::PropertyChangedEventHandler<float>)global::System.Delegate.Remove(this.ValueChanged, value);
		}
	}

	// Token: 0x17000D67 RID: 3431
	// (get) Token: 0x060047B4 RID: 18356 RVA: 0x00109564 File Offset: 0x00107764
	// (set) Token: 0x060047B5 RID: 18357 RVA: 0x001095AC File Offset: 0x001077AC
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

	// Token: 0x17000D68 RID: 3432
	// (get) Token: 0x060047B6 RID: 18358 RVA: 0x001095CC File Offset: 0x001077CC
	// (set) Token: 0x060047B7 RID: 18359 RVA: 0x001095D4 File Offset: 0x001077D4
	public float MinValue
	{
		get
		{
			return this.minValue;
		}
		set
		{
			if (value != this.minValue)
			{
				this.minValue = value;
				this.Value = this.Value;
				this.Invalidate();
				this.doAutoHide();
			}
		}
	}

	// Token: 0x17000D69 RID: 3433
	// (get) Token: 0x060047B8 RID: 18360 RVA: 0x00109604 File Offset: 0x00107804
	// (set) Token: 0x060047B9 RID: 18361 RVA: 0x0010960C File Offset: 0x0010780C
	public float MaxValue
	{
		get
		{
			return this.maxValue;
		}
		set
		{
			if (value != this.maxValue)
			{
				this.maxValue = value;
				this.Value = this.Value;
				this.Invalidate();
				this.doAutoHide();
			}
		}
	}

	// Token: 0x17000D6A RID: 3434
	// (get) Token: 0x060047BA RID: 18362 RVA: 0x0010963C File Offset: 0x0010783C
	// (set) Token: 0x060047BB RID: 18363 RVA: 0x00109644 File Offset: 0x00107844
	public float StepSize
	{
		get
		{
			return this.stepSize;
		}
		set
		{
			value = global::UnityEngine.Mathf.Max(0f, value);
			if (value != this.stepSize)
			{
				this.stepSize = value;
				this.Value = this.Value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D6B RID: 3435
	// (get) Token: 0x060047BC RID: 18364 RVA: 0x00109684 File Offset: 0x00107884
	// (set) Token: 0x060047BD RID: 18365 RVA: 0x0010968C File Offset: 0x0010788C
	public float ScrollSize
	{
		get
		{
			return this.scrollSize;
		}
		set
		{
			value = global::UnityEngine.Mathf.Max(0f, value);
			if (value != this.scrollSize)
			{
				this.scrollSize = value;
				this.Value = this.Value;
				this.Invalidate();
				this.doAutoHide();
			}
		}
	}

	// Token: 0x17000D6C RID: 3436
	// (get) Token: 0x060047BE RID: 18366 RVA: 0x001096D4 File Offset: 0x001078D4
	// (set) Token: 0x060047BF RID: 18367 RVA: 0x001096DC File Offset: 0x001078DC
	public float IncrementAmount
	{
		get
		{
			return this.increment;
		}
		set
		{
			value = global::UnityEngine.Mathf.Max(0f, value);
			if (!global::UnityEngine.Mathf.Approximately(value, this.increment))
			{
				this.increment = value;
			}
		}
	}

	// Token: 0x17000D6D RID: 3437
	// (get) Token: 0x060047C0 RID: 18368 RVA: 0x00109704 File Offset: 0x00107904
	// (set) Token: 0x060047C1 RID: 18369 RVA: 0x0010970C File Offset: 0x0010790C
	public global::dfControlOrientation Orientation
	{
		get
		{
			return this.orientation;
		}
		set
		{
			if (value != this.orientation)
			{
				this.orientation = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D6E RID: 3438
	// (get) Token: 0x060047C2 RID: 18370 RVA: 0x00109728 File Offset: 0x00107928
	// (set) Token: 0x060047C3 RID: 18371 RVA: 0x00109730 File Offset: 0x00107930
	public float Value
	{
		get
		{
			return this.rawValue;
		}
		set
		{
			value = this.adjustValue(value);
			if (!global::UnityEngine.Mathf.Approximately(value, this.rawValue))
			{
				this.rawValue = value;
				this.OnValueChanged();
			}
			this.updateThumb(this.rawValue);
		}
	}

	// Token: 0x17000D6F RID: 3439
	// (get) Token: 0x060047C4 RID: 18372 RVA: 0x00109768 File Offset: 0x00107968
	// (set) Token: 0x060047C5 RID: 18373 RVA: 0x00109770 File Offset: 0x00107970
	public global::dfControl Thumb
	{
		get
		{
			return this.thumb;
		}
		set
		{
			if (value != this.thumb)
			{
				this.thumb = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D70 RID: 3440
	// (get) Token: 0x060047C6 RID: 18374 RVA: 0x00109790 File Offset: 0x00107990
	// (set) Token: 0x060047C7 RID: 18375 RVA: 0x00109798 File Offset: 0x00107998
	public global::dfControl Track
	{
		get
		{
			return this.track;
		}
		set
		{
			if (value != this.track)
			{
				this.track = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D71 RID: 3441
	// (get) Token: 0x060047C8 RID: 18376 RVA: 0x001097B8 File Offset: 0x001079B8
	// (set) Token: 0x060047C9 RID: 18377 RVA: 0x001097C0 File Offset: 0x001079C0
	public global::dfControl IncButton
	{
		get
		{
			return this.incButton;
		}
		set
		{
			if (value != this.incButton)
			{
				this.incButton = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D72 RID: 3442
	// (get) Token: 0x060047CA RID: 18378 RVA: 0x001097E0 File Offset: 0x001079E0
	// (set) Token: 0x060047CB RID: 18379 RVA: 0x001097E8 File Offset: 0x001079E8
	public global::dfControl DecButton
	{
		get
		{
			return this.decButton;
		}
		set
		{
			if (value != this.decButton)
			{
				this.decButton = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D73 RID: 3443
	// (get) Token: 0x060047CC RID: 18380 RVA: 0x00109808 File Offset: 0x00107A08
	// (set) Token: 0x060047CD RID: 18381 RVA: 0x00109828 File Offset: 0x00107A28
	public global::UnityEngine.RectOffset ThumbPadding
	{
		get
		{
			if (this.thumbPadding == null)
			{
				this.thumbPadding = new global::UnityEngine.RectOffset();
			}
			return this.thumbPadding;
		}
		set
		{
			if (this.orientation == global::dfControlOrientation.Horizontal)
			{
				int num = 0;
				value.bottom = num;
				value.top = num;
			}
			else
			{
				int num = 0;
				value.right = num;
				value.left = num;
			}
			if (!object.Equals(value, this.thumbPadding))
			{
				this.thumbPadding = value;
				this.updateThumb(this.rawValue);
			}
		}
	}

	// Token: 0x17000D74 RID: 3444
	// (get) Token: 0x060047CE RID: 18382 RVA: 0x0010988C File Offset: 0x00107A8C
	// (set) Token: 0x060047CF RID: 18383 RVA: 0x00109894 File Offset: 0x00107A94
	public bool AutoHide
	{
		get
		{
			return this.autoHide;
		}
		set
		{
			if (value != this.autoHide)
			{
				this.autoHide = value;
				this.Invalidate();
				this.doAutoHide();
			}
		}
	}

	// Token: 0x060047D0 RID: 18384 RVA: 0x001098B8 File Offset: 0x00107AB8
	public override global::UnityEngine.Vector2 CalculateMinimumSize()
	{
		global::UnityEngine.Vector2[] array = new global::UnityEngine.Vector2[3];
		if (this.decButton != null)
		{
			array[0] = this.decButton.CalculateMinimumSize();
		}
		if (this.incButton != null)
		{
			array[1] = this.incButton.CalculateMinimumSize();
		}
		if (this.thumb != null)
		{
			array[2] = this.thumb.CalculateMinimumSize();
		}
		global::UnityEngine.Vector2 zero = global::UnityEngine.Vector2.zero;
		if (this.orientation == global::dfControlOrientation.Horizontal)
		{
			zero.x = array[0].x + array[1].x + array[2].x;
			zero.y = global::UnityEngine.Mathf.Max(new float[]
			{
				array[0].y,
				array[1].y,
				array[2].y
			});
		}
		else
		{
			zero.x = global::UnityEngine.Mathf.Max(new float[]
			{
				array[0].x,
				array[1].x,
				array[2].x
			});
			zero.y = array[0].y + array[1].y + array[2].y;
		}
		return global::UnityEngine.Vector2.Max(zero, base.CalculateMinimumSize());
	}

	// Token: 0x17000D75 RID: 3445
	// (get) Token: 0x060047D1 RID: 18385 RVA: 0x00109A40 File Offset: 0x00107C40
	public override bool CanFocus
	{
		get
		{
			return (base.IsEnabled && base.IsVisible) || base.CanFocus;
		}
	}

	// Token: 0x060047D2 RID: 18386 RVA: 0x00109A60 File Offset: 0x00107C60
	protected override void OnRebuildRenderData()
	{
		this.updateThumb(this.rawValue);
		base.OnRebuildRenderData();
	}

	// Token: 0x060047D3 RID: 18387 RVA: 0x00109A74 File Offset: 0x00107C74
	public override void Start()
	{
		base.Start();
		this.attachEvents();
	}

	// Token: 0x060047D4 RID: 18388 RVA: 0x00109A84 File Offset: 0x00107C84
	public override void OnDisable()
	{
		base.OnDisable();
		this.detachEvents();
	}

	// Token: 0x060047D5 RID: 18389 RVA: 0x00109A94 File Offset: 0x00107C94
	public override void OnDestroy()
	{
		base.OnDestroy();
		this.detachEvents();
	}

	// Token: 0x060047D6 RID: 18390 RVA: 0x00109AA4 File Offset: 0x00107CA4
	private void attachEvents()
	{
		if (!global::UnityEngine.Application.isPlaying)
		{
			return;
		}
		if (this.IncButton != null)
		{
			this.IncButton.MouseDown += this.incrementPressed;
			this.IncButton.MouseHover += this.incrementPressed;
		}
		if (this.DecButton != null)
		{
			this.DecButton.MouseDown += this.decrementPressed;
			this.DecButton.MouseHover += this.decrementPressed;
		}
	}

	// Token: 0x060047D7 RID: 18391 RVA: 0x00109B3C File Offset: 0x00107D3C
	private void detachEvents()
	{
		if (!global::UnityEngine.Application.isPlaying)
		{
			return;
		}
		if (this.IncButton != null)
		{
			this.IncButton.MouseDown -= this.incrementPressed;
			this.IncButton.MouseHover -= this.incrementPressed;
		}
		if (this.DecButton != null)
		{
			this.DecButton.MouseDown -= this.decrementPressed;
			this.DecButton.MouseHover -= this.decrementPressed;
		}
	}

	// Token: 0x060047D8 RID: 18392 RVA: 0x00109BD4 File Offset: 0x00107DD4
	protected internal override void OnKeyDown(global::dfKeyEventArgs args)
	{
		if (this.Orientation == global::dfControlOrientation.Horizontal)
		{
			if (args.KeyCode == 0x114)
			{
				this.Value -= this.IncrementAmount;
				args.Use();
				return;
			}
			if (args.KeyCode == 0x113)
			{
				this.Value += this.IncrementAmount;
				args.Use();
				return;
			}
		}
		else
		{
			if (args.KeyCode == 0x111)
			{
				this.Value -= this.IncrementAmount;
				args.Use();
				return;
			}
			if (args.KeyCode == 0x112)
			{
				this.Value += this.IncrementAmount;
				args.Use();
				return;
			}
		}
		base.OnKeyDown(args);
	}

	// Token: 0x060047D9 RID: 18393 RVA: 0x00109CA0 File Offset: 0x00107EA0
	protected internal override void OnMouseWheel(global::dfMouseEventArgs args)
	{
		this.Value += this.IncrementAmount * -args.WheelDelta;
		args.Use();
		base.Signal("OnMouseWheel", new object[]
		{
			args
		});
	}

	// Token: 0x060047DA RID: 18394 RVA: 0x00109CE4 File Offset: 0x00107EE4
	protected internal override void OnMouseHover(global::dfMouseEventArgs args)
	{
		bool flag = args.Source == this.incButton || args.Source == this.decButton || args.Source == this.thumb;
		if (flag)
		{
			return;
		}
		if (args.Source != this.track || !args.Buttons.IsSet(global::dfMouseButtons.Left))
		{
			base.OnMouseHover(args);
			return;
		}
		this.updateFromTrackClick(args);
		args.Use();
		base.Signal("OnMouseHover", new object[]
		{
			args
		});
	}

	// Token: 0x060047DB RID: 18395 RVA: 0x00109D8C File Offset: 0x00107F8C
	protected internal override void OnMouseMove(global::dfMouseEventArgs args)
	{
		if (args.Source == this.incButton || args.Source == this.decButton)
		{
			return;
		}
		if ((args.Source != this.track && args.Source != this.thumb) || !args.Buttons.IsSet(global::dfMouseButtons.Left))
		{
			base.OnMouseMove(args);
			return;
		}
		this.Value = global::UnityEngine.Mathf.Max(this.minValue, this.getValueFromMouseEvent(args) - this.scrollSize * 0.5f);
		args.Use();
		base.Signal("OnMouseMove", new object[]
		{
			args
		});
	}

	// Token: 0x060047DC RID: 18396 RVA: 0x00109E4C File Offset: 0x0010804C
	protected internal override void OnMouseDown(global::dfMouseEventArgs args)
	{
		if (args.Buttons.IsSet(global::dfMouseButtons.Left))
		{
			base.Focus();
		}
		if (args.Source == this.incButton || args.Source == this.decButton)
		{
			return;
		}
		if ((args.Source != this.track && args.Source != this.thumb) || !args.Buttons.IsSet(global::dfMouseButtons.Left))
		{
			base.OnMouseDown(args);
			return;
		}
		if (args.Source == this.thumb)
		{
			global::UnityEngine.RaycastHit raycastHit;
			this.thumb.collider.Raycast(args.Ray, ref raycastHit, 1000f);
			global::UnityEngine.Vector3 vector = this.thumb.transform.position + this.thumb.Pivot.TransformToCenter(this.thumb.Size * base.PixelsToUnits());
			this.thumbMouseOffset = vector - raycastHit.point;
		}
		else
		{
			this.updateFromTrackClick(args);
		}
		args.Use();
		base.Signal("OnMouseDown", new object[]
		{
			args
		});
	}

	// Token: 0x060047DD RID: 18397 RVA: 0x00109F90 File Offset: 0x00108190
	protected internal virtual void OnValueChanged()
	{
		this.Invalidate();
		base.SignalHierarchy("OnValueChanged", new object[]
		{
			this.Value
		});
		if (this.ValueChanged != null)
		{
			this.ValueChanged(this, this.Value);
		}
	}

	// Token: 0x060047DE RID: 18398 RVA: 0x00109FE0 File Offset: 0x001081E0
	protected internal override void OnSizeChanged()
	{
		base.OnSizeChanged();
		this.updateThumb(this.rawValue);
	}

	// Token: 0x060047DF RID: 18399 RVA: 0x00109FF4 File Offset: 0x001081F4
	private void doAutoHide()
	{
		if (!this.autoHide || !global::UnityEngine.Application.isPlaying)
		{
			return;
		}
		if (global::UnityEngine.Mathf.CeilToInt(this.ScrollSize) >= global::UnityEngine.Mathf.CeilToInt(this.maxValue - this.minValue))
		{
			base.Hide();
		}
		else
		{
			base.Show();
		}
	}

	// Token: 0x060047E0 RID: 18400 RVA: 0x0010A04C File Offset: 0x0010824C
	private void incrementPressed(global::dfControl sender, global::dfMouseEventArgs args)
	{
		if (args.Buttons.IsSet(global::dfMouseButtons.Left))
		{
			this.Value += this.IncrementAmount;
			args.Use();
		}
	}

	// Token: 0x060047E1 RID: 18401 RVA: 0x0010A084 File Offset: 0x00108284
	private void decrementPressed(global::dfControl sender, global::dfMouseEventArgs args)
	{
		if (args.Buttons.IsSet(global::dfMouseButtons.Left))
		{
			this.Value -= this.IncrementAmount;
			args.Use();
		}
	}

	// Token: 0x060047E2 RID: 18402 RVA: 0x0010A0BC File Offset: 0x001082BC
	private void updateFromTrackClick(global::dfMouseEventArgs args)
	{
		float valueFromMouseEvent = this.getValueFromMouseEvent(args);
		if (valueFromMouseEvent > this.rawValue + this.scrollSize)
		{
			this.Value += this.scrollSize;
		}
		else if (valueFromMouseEvent < this.rawValue)
		{
			this.Value -= this.scrollSize;
		}
	}

	// Token: 0x060047E3 RID: 18403 RVA: 0x0010A11C File Offset: 0x0010831C
	private float adjustValue(float value)
	{
		float num = global::UnityEngine.Mathf.Max(this.maxValue - this.minValue, 0f);
		float num2 = global::UnityEngine.Mathf.Max(num - this.scrollSize, 0f) + this.minValue;
		float value2 = global::UnityEngine.Mathf.Max(global::UnityEngine.Mathf.Min(num2, value), this.minValue);
		return value2.Quantize(this.stepSize);
	}

	// Token: 0x060047E4 RID: 18404 RVA: 0x0010A17C File Offset: 0x0010837C
	private void updateThumb(float rawValue)
	{
		if (this.controls.Count == 0 || this.thumb == null || this.track == null || !base.IsVisible)
		{
			return;
		}
		float num = this.maxValue - this.minValue;
		if (num <= 0f || num <= this.scrollSize)
		{
			this.thumb.IsVisible = false;
			return;
		}
		this.thumb.IsVisible = true;
		float num2 = (this.orientation != global::dfControlOrientation.Horizontal) ? this.track.Height : this.track.Width;
		float num3 = (this.orientation != global::dfControlOrientation.Horizontal) ? global::UnityEngine.Mathf.Max(this.scrollSize / num * num2, this.thumb.MinimumSize.y) : global::UnityEngine.Mathf.Max(this.scrollSize / num * num2, this.thumb.MinimumSize.x);
		global::UnityEngine.Vector2 size = (this.orientation != global::dfControlOrientation.Horizontal) ? new global::UnityEngine.Vector2(this.thumb.Width, num3) : new global::UnityEngine.Vector2(num3, this.thumb.Height);
		if (this.Orientation == global::dfControlOrientation.Horizontal)
		{
			size.x -= (float)this.thumbPadding.horizontal;
		}
		else
		{
			size.y -= (float)this.thumbPadding.vertical;
		}
		this.thumb.Size = size;
		float num4 = (rawValue - this.minValue) / (num - this.scrollSize);
		float num5 = num4 * (num2 - num3);
		global::UnityEngine.Vector3 vector = (this.orientation != global::dfControlOrientation.Horizontal) ? global::UnityEngine.Vector3.up : global::UnityEngine.Vector3.right;
		global::UnityEngine.Vector3 vector2 = (this.Orientation != global::dfControlOrientation.Horizontal) ? new global::UnityEngine.Vector3((this.track.Width - this.thumb.Width) * 0.5f, 0f) : new global::UnityEngine.Vector3(0f, (this.track.Height - this.thumb.Height) * 0.5f);
		if (this.Orientation == global::dfControlOrientation.Horizontal)
		{
			vector2.x = (float)this.thumbPadding.left;
		}
		else
		{
			vector2.y = (float)this.thumbPadding.top;
		}
		if (this.thumb.Parent == this)
		{
			this.thumb.RelativePosition = this.track.RelativePosition + vector2 + vector * num5;
		}
		else
		{
			this.thumb.RelativePosition = vector * num5 + vector2;
		}
	}

	// Token: 0x060047E5 RID: 18405 RVA: 0x0010A434 File Offset: 0x00108634
	private float getValueFromMouseEvent(global::dfMouseEventArgs args)
	{
		global::UnityEngine.Vector3[] corners = this.track.GetCorners();
		global::UnityEngine.Vector3 vector = corners[0];
		global::UnityEngine.Vector3 vector2 = corners[(this.orientation != global::dfControlOrientation.Horizontal) ? 2 : 1];
		global::UnityEngine.Plane plane;
		plane..ctor(base.transform.TransformDirection(global::UnityEngine.Vector3.back), vector);
		global::UnityEngine.Ray ray = args.Ray;
		float num = 0f;
		if (!plane.Raycast(ray, ref num))
		{
			return this.rawValue;
		}
		global::UnityEngine.Vector3 vector3 = ray.origin + ray.direction * num;
		if (args.Source == this.thumb)
		{
			vector3 += this.thumbMouseOffset;
		}
		global::UnityEngine.Vector3 vector4 = global::dfScrollbar.closestPoint(vector, vector2, vector3, true);
		float num2 = (vector4 - vector).magnitude / (vector2 - vector).magnitude;
		return this.minValue + (this.maxValue - this.minValue) * num2;
	}

	// Token: 0x060047E6 RID: 18406 RVA: 0x0010A544 File Offset: 0x00108744
	private static global::UnityEngine.Vector3 closestPoint(global::UnityEngine.Vector3 start, global::UnityEngine.Vector3 end, global::UnityEngine.Vector3 test, bool clamp)
	{
		global::UnityEngine.Vector3 vector = test - start;
		global::UnityEngine.Vector3 vector2 = (end - start).normalized;
		float magnitude = (end - start).magnitude;
		float num = global::UnityEngine.Vector3.Dot(vector2, vector);
		if (clamp)
		{
			if (num < 0f)
			{
				return start;
			}
			if (num > magnitude)
			{
				return end;
			}
		}
		vector2 *= num;
		return start + vector2;
	}

	// Token: 0x04002689 RID: 9865
	[global::UnityEngine.SerializeField]
	protected global::dfAtlas atlas;

	// Token: 0x0400268A RID: 9866
	[global::UnityEngine.SerializeField]
	protected global::dfControlOrientation orientation;

	// Token: 0x0400268B RID: 9867
	[global::UnityEngine.SerializeField]
	protected float rawValue = 1f;

	// Token: 0x0400268C RID: 9868
	[global::UnityEngine.SerializeField]
	protected float minValue;

	// Token: 0x0400268D RID: 9869
	[global::UnityEngine.SerializeField]
	protected float maxValue = 100f;

	// Token: 0x0400268E RID: 9870
	[global::UnityEngine.SerializeField]
	protected float stepSize = 1f;

	// Token: 0x0400268F RID: 9871
	[global::UnityEngine.SerializeField]
	protected float scrollSize = 1f;

	// Token: 0x04002690 RID: 9872
	[global::UnityEngine.SerializeField]
	protected float increment = 1f;

	// Token: 0x04002691 RID: 9873
	[global::UnityEngine.SerializeField]
	protected global::dfControl thumb;

	// Token: 0x04002692 RID: 9874
	[global::UnityEngine.SerializeField]
	protected global::dfControl track;

	// Token: 0x04002693 RID: 9875
	[global::UnityEngine.SerializeField]
	protected global::dfControl incButton;

	// Token: 0x04002694 RID: 9876
	[global::UnityEngine.SerializeField]
	protected global::dfControl decButton;

	// Token: 0x04002695 RID: 9877
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.RectOffset thumbPadding = new global::UnityEngine.RectOffset();

	// Token: 0x04002696 RID: 9878
	[global::UnityEngine.SerializeField]
	protected bool autoHide;

	// Token: 0x04002697 RID: 9879
	private global::UnityEngine.Vector3 thumbMouseOffset = global::UnityEngine.Vector3.zero;

	// Token: 0x04002698 RID: 9880
	private global::PropertyChangedEventHandler<float> ValueChanged;
}
