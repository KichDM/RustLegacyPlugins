using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000834 RID: 2100
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/Slider")]
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.BoxCollider))]
public class dfSlider : global::dfControl
{
	// Token: 0x060047F1 RID: 18417 RVA: 0x0010B678 File Offset: 0x00109878
	public dfSlider()
	{
	}

	// Token: 0x14000050 RID: 80
	// (add) Token: 0x060047F2 RID: 18418 RVA: 0x0010B6D4 File Offset: 0x001098D4
	// (remove) Token: 0x060047F3 RID: 18419 RVA: 0x0010B6F0 File Offset: 0x001098F0
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

	// Token: 0x17000D76 RID: 3446
	// (get) Token: 0x060047F4 RID: 18420 RVA: 0x0010B70C File Offset: 0x0010990C
	// (set) Token: 0x060047F5 RID: 18421 RVA: 0x0010B754 File Offset: 0x00109954
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

	// Token: 0x17000D77 RID: 3447
	// (get) Token: 0x060047F6 RID: 18422 RVA: 0x0010B774 File Offset: 0x00109974
	// (set) Token: 0x060047F7 RID: 18423 RVA: 0x0010B77C File Offset: 0x0010997C
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

	// Token: 0x17000D78 RID: 3448
	// (get) Token: 0x060047F8 RID: 18424 RVA: 0x0010B79C File Offset: 0x0010999C
	// (set) Token: 0x060047F9 RID: 18425 RVA: 0x0010B7A4 File Offset: 0x001099A4
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
				if (this.rawValue < value)
				{
					this.Value = value;
				}
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D79 RID: 3449
	// (get) Token: 0x060047FA RID: 18426 RVA: 0x0010B7E0 File Offset: 0x001099E0
	// (set) Token: 0x060047FB RID: 18427 RVA: 0x0010B7E8 File Offset: 0x001099E8
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
				if (this.rawValue > value)
				{
					this.Value = value;
				}
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D7A RID: 3450
	// (get) Token: 0x060047FC RID: 18428 RVA: 0x0010B824 File Offset: 0x00109A24
	// (set) Token: 0x060047FD RID: 18429 RVA: 0x0010B82C File Offset: 0x00109A2C
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
				this.Value = this.rawValue.Quantize(value);
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D7B RID: 3451
	// (get) Token: 0x060047FE RID: 18430 RVA: 0x0010B874 File Offset: 0x00109A74
	// (set) Token: 0x060047FF RID: 18431 RVA: 0x0010B87C File Offset: 0x00109A7C
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
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D7C RID: 3452
	// (get) Token: 0x06004800 RID: 18432 RVA: 0x0010B8B0 File Offset: 0x00109AB0
	// (set) Token: 0x06004801 RID: 18433 RVA: 0x0010B8B8 File Offset: 0x00109AB8
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
				this.updateValueIndicators(this.rawValue);
			}
		}
	}

	// Token: 0x17000D7D RID: 3453
	// (get) Token: 0x06004802 RID: 18434 RVA: 0x0010B8E0 File Offset: 0x00109AE0
	// (set) Token: 0x06004803 RID: 18435 RVA: 0x0010B8E8 File Offset: 0x00109AE8
	public float Value
	{
		get
		{
			return this.rawValue;
		}
		set
		{
			value = global::UnityEngine.Mathf.Max(this.minValue, global::UnityEngine.Mathf.Min(this.maxValue, value)).Quantize(this.stepSize);
			if (!global::UnityEngine.Mathf.Approximately(value, this.rawValue))
			{
				this.rawValue = value;
				this.OnValueChanged();
			}
		}
	}

	// Token: 0x17000D7E RID: 3454
	// (get) Token: 0x06004804 RID: 18436 RVA: 0x0010B938 File Offset: 0x00109B38
	// (set) Token: 0x06004805 RID: 18437 RVA: 0x0010B940 File Offset: 0x00109B40
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
				this.updateValueIndicators(this.rawValue);
			}
		}
	}

	// Token: 0x17000D7F RID: 3455
	// (get) Token: 0x06004806 RID: 18438 RVA: 0x0010B978 File Offset: 0x00109B78
	// (set) Token: 0x06004807 RID: 18439 RVA: 0x0010B980 File Offset: 0x00109B80
	public global::dfControl Progress
	{
		get
		{
			return this.fillIndicator;
		}
		set
		{
			if (value != this.fillIndicator)
			{
				this.fillIndicator = value;
				this.Invalidate();
				this.updateValueIndicators(this.rawValue);
			}
		}
	}

	// Token: 0x17000D80 RID: 3456
	// (get) Token: 0x06004808 RID: 18440 RVA: 0x0010B9B8 File Offset: 0x00109BB8
	// (set) Token: 0x06004809 RID: 18441 RVA: 0x0010B9C0 File Offset: 0x00109BC0
	public global::dfProgressFillMode FillMode
	{
		get
		{
			return this.fillMode;
		}
		set
		{
			if (value != this.fillMode)
			{
				this.fillMode = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D81 RID: 3457
	// (get) Token: 0x0600480A RID: 18442 RVA: 0x0010B9DC File Offset: 0x00109BDC
	// (set) Token: 0x0600480B RID: 18443 RVA: 0x0010B9FC File Offset: 0x00109BFC
	public global::UnityEngine.RectOffset FillPadding
	{
		get
		{
			if (this.fillPadding == null)
			{
				this.fillPadding = new global::UnityEngine.RectOffset();
			}
			return this.fillPadding;
		}
		set
		{
			if (!object.Equals(value, this.fillPadding))
			{
				this.fillPadding = value;
				this.updateValueIndicators(this.rawValue);
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D82 RID: 3458
	// (get) Token: 0x0600480C RID: 18444 RVA: 0x0010BA34 File Offset: 0x00109C34
	// (set) Token: 0x0600480D RID: 18445 RVA: 0x0010BA3C File Offset: 0x00109C3C
	public global::UnityEngine.Vector2 ThumbOffset
	{
		get
		{
			return this.thumbOffset;
		}
		set
		{
			if (global::UnityEngine.Vector2.Distance(value, this.thumbOffset) > 1E-45f)
			{
				this.thumbOffset = value;
				this.updateValueIndicators(this.rawValue);
			}
		}
	}

	// Token: 0x17000D83 RID: 3459
	// (get) Token: 0x0600480E RID: 18446 RVA: 0x0010BA68 File Offset: 0x00109C68
	// (set) Token: 0x0600480F RID: 18447 RVA: 0x0010BA70 File Offset: 0x00109C70
	public bool RightToLeft
	{
		get
		{
			return this.rightToLeft;
		}
		set
		{
			if (value != this.rightToLeft)
			{
				this.rightToLeft = value;
				this.updateValueIndicators(this.rawValue);
			}
		}
	}

	// Token: 0x06004810 RID: 18448 RVA: 0x0010BA94 File Offset: 0x00109C94
	protected internal override void OnKeyDown(global::dfKeyEventArgs args)
	{
		if (this.Orientation == global::dfControlOrientation.Horizontal)
		{
			if (args.KeyCode == 0x114)
			{
				this.Value -= this.ScrollSize;
				args.Use();
				return;
			}
			if (args.KeyCode == 0x113)
			{
				this.Value += this.ScrollSize;
				args.Use();
				return;
			}
		}
		else
		{
			if (args.KeyCode == 0x111)
			{
				this.Value -= this.ScrollSize;
				args.Use();
				return;
			}
			if (args.KeyCode == 0x112)
			{
				this.Value += this.ScrollSize;
				args.Use();
				return;
			}
		}
		base.OnKeyDown(args);
	}

	// Token: 0x06004811 RID: 18449 RVA: 0x0010BB60 File Offset: 0x00109D60
	public override void Start()
	{
		base.Start();
		this.updateValueIndicators(this.rawValue);
	}

	// Token: 0x06004812 RID: 18450 RVA: 0x0010BB74 File Offset: 0x00109D74
	public override void OnEnable()
	{
		if (this.size.magnitude < 1E-45f)
		{
			this.size = new global::UnityEngine.Vector2(100f, 25f);
		}
		base.OnEnable();
		this.updateValueIndicators(this.rawValue);
	}

	// Token: 0x06004813 RID: 18451 RVA: 0x0010BBC0 File Offset: 0x00109DC0
	protected internal override void OnMouseWheel(global::dfMouseEventArgs args)
	{
		int num = (this.orientation != global::dfControlOrientation.Horizontal) ? 1 : -1;
		this.Value += this.scrollSize * args.WheelDelta * (float)num;
		args.Use();
		base.Signal("OnMouseWheel", new object[]
		{
			args
		});
		base.RaiseEvent("MouseWheel", new object[]
		{
			this,
			args
		});
	}

	// Token: 0x06004814 RID: 18452 RVA: 0x0010BC34 File Offset: 0x00109E34
	protected internal override void OnMouseMove(global::dfMouseEventArgs args)
	{
		if (!args.Buttons.IsSet(global::dfMouseButtons.Left))
		{
			base.OnMouseMove(args);
			return;
		}
		this.Value = this.getValueFromMouseEvent(args);
		args.Use();
		base.Signal("OnMouseMove", new object[]
		{
			args
		});
		base.RaiseEvent("MouseMove", new object[]
		{
			this,
			args
		});
	}

	// Token: 0x06004815 RID: 18453 RVA: 0x0010BC9C File Offset: 0x00109E9C
	protected internal override void OnMouseDown(global::dfMouseEventArgs args)
	{
		if (!args.Buttons.IsSet(global::dfMouseButtons.Left))
		{
			base.OnMouseMove(args);
			return;
		}
		base.Focus();
		this.Value = this.getValueFromMouseEvent(args);
		args.Use();
		base.Signal("OnMouseDown", new object[]
		{
			args
		});
		base.RaiseEvent("MouseDown", new object[]
		{
			this,
			args
		});
	}

	// Token: 0x06004816 RID: 18454 RVA: 0x0010BD0C File Offset: 0x00109F0C
	protected internal override void OnSizeChanged()
	{
		base.OnSizeChanged();
		this.updateValueIndicators(this.rawValue);
	}

	// Token: 0x06004817 RID: 18455 RVA: 0x0010BD20 File Offset: 0x00109F20
	protected internal virtual void OnValueChanged()
	{
		this.Invalidate();
		this.updateValueIndicators(this.rawValue);
		base.SignalHierarchy("OnValueChanged", new object[]
		{
			this.Value
		});
		if (this.ValueChanged != null)
		{
			this.ValueChanged(this, this.Value);
		}
	}

	// Token: 0x17000D84 RID: 3460
	// (get) Token: 0x06004818 RID: 18456 RVA: 0x0010BD7C File Offset: 0x00109F7C
	public override bool CanFocus
	{
		get
		{
			return (base.IsEnabled && base.IsVisible) || base.CanFocus;
		}
	}

	// Token: 0x06004819 RID: 18457 RVA: 0x0010BD9C File Offset: 0x00109F9C
	protected override void OnRebuildRenderData()
	{
		if (this.Atlas == null)
		{
			return;
		}
		this.renderData.Material = this.Atlas.Material;
		this.renderBackground();
	}

	// Token: 0x0600481A RID: 18458 RVA: 0x0010BDD8 File Offset: 0x00109FD8
	protected internal virtual void renderBackground()
	{
		if (this.Atlas == null)
		{
			return;
		}
		global::dfAtlas.ItemInfo itemInfo = this.Atlas[this.backgroundSprite];
		if (itemInfo == null)
		{
			return;
		}
		global::UnityEngine.Color32 color = base.ApplyOpacity((!base.IsEnabled) ? this.disabledColor : this.color);
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

	// Token: 0x0600481B RID: 18459 RVA: 0x0010BEE0 File Offset: 0x0010A0E0
	private void updateValueIndicators(float rawValue)
	{
		if (this.thumb != null)
		{
			global::UnityEngine.Vector3[] endPoints = this.getEndPoints(true);
			global::UnityEngine.Vector3 vector = endPoints[1] - endPoints[0];
			float num = this.maxValue - this.minValue;
			float num2 = (rawValue - this.minValue) / num * vector.magnitude;
			global::UnityEngine.Vector3 vector2 = this.thumbOffset * base.PixelsToUnits();
			global::UnityEngine.Vector3 position = endPoints[0] + vector.normalized * num2 + vector2;
			if (this.orientation == global::dfControlOrientation.Vertical || this.rightToLeft)
			{
				position = endPoints[1] + -vector.normalized * num2 + vector2;
			}
			this.thumb.Pivot = global::dfPivotPoint.MiddleCenter;
			this.thumb.transform.position = position;
		}
		if (this.fillIndicator == null)
		{
			return;
		}
		global::UnityEngine.RectOffset rectOffset = this.FillPadding;
		float num3 = (rawValue - this.minValue) / (this.maxValue - this.minValue);
		global::UnityEngine.Vector3 relativePosition;
		relativePosition..ctor((float)rectOffset.left, (float)rectOffset.top);
		global::UnityEngine.Vector2 size = this.size - new global::UnityEngine.Vector2((float)rectOffset.horizontal, (float)rectOffset.vertical);
		global::dfSprite dfSprite = this.fillIndicator as global::dfSprite;
		if (dfSprite != null && this.fillMode == global::dfProgressFillMode.Fill)
		{
			dfSprite.FillAmount = num3;
		}
		else if (this.orientation == global::dfControlOrientation.Horizontal)
		{
			size.x = base.Width * num3 - (float)rectOffset.horizontal;
		}
		else
		{
			size.y = base.Height * num3 - (float)rectOffset.vertical;
		}
		this.fillIndicator.Size = size;
		this.fillIndicator.RelativePosition = relativePosition;
	}

	// Token: 0x0600481C RID: 18460 RVA: 0x0010C0E0 File Offset: 0x0010A2E0
	private float getValueFromMouseEvent(global::dfMouseEventArgs args)
	{
		global::UnityEngine.Vector3[] endPoints = this.getEndPoints(true);
		global::UnityEngine.Vector3 vector = endPoints[0];
		global::UnityEngine.Vector3 vector2 = endPoints[1];
		global::UnityEngine.Plane plane;
		plane..ctor(base.transform.TransformDirection(global::UnityEngine.Vector3.back), vector);
		global::UnityEngine.Ray ray = args.Ray;
		float num = 0f;
		if (!plane.Raycast(ray, ref num))
		{
			return this.rawValue;
		}
		global::UnityEngine.Vector3 test = ray.origin + ray.direction * num;
		global::UnityEngine.Vector3 vector3 = global::dfSlider.closestPoint(vector, vector2, test, true);
		float num2 = (vector3 - vector).magnitude / (vector2 - vector).magnitude;
		float num3 = this.minValue + (this.maxValue - this.minValue) * num2;
		if (this.orientation == global::dfControlOrientation.Vertical || this.rightToLeft)
		{
			num3 = this.maxValue - num3;
		}
		return num3;
	}

	// Token: 0x0600481D RID: 18461 RVA: 0x0010C1D8 File Offset: 0x0010A3D8
	private global::UnityEngine.Vector3[] getEndPoints(bool convertToWorld = false)
	{
		global::UnityEngine.Vector3 vector = this.pivot.TransformToUpperLeft(base.Size);
		global::UnityEngine.Vector3 vector2;
		vector2..ctor(vector.x, vector.y - this.size.y * 0.5f);
		global::UnityEngine.Vector3 vector3 = vector2 + new global::UnityEngine.Vector3(this.size.x, 0f);
		if (this.orientation == global::dfControlOrientation.Vertical)
		{
			vector2..ctor(vector.x + this.size.x * 0.5f, vector.y);
			vector3 = vector2 - new global::UnityEngine.Vector3(0f, this.size.y);
		}
		if (convertToWorld)
		{
			float num = base.PixelsToUnits();
			global::UnityEngine.Matrix4x4 localToWorldMatrix = base.transform.localToWorldMatrix;
			vector2 = localToWorldMatrix.MultiplyPoint(vector2 * num);
			vector3 = localToWorldMatrix.MultiplyPoint(vector3 * num);
		}
		return new global::UnityEngine.Vector3[]
		{
			vector2,
			vector3
		};
	}

	// Token: 0x0600481E RID: 18462 RVA: 0x0010C2E4 File Offset: 0x0010A4E4
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

	// Token: 0x0400269F RID: 9887
	[global::UnityEngine.SerializeField]
	protected global::dfAtlas atlas;

	// Token: 0x040026A0 RID: 9888
	[global::UnityEngine.SerializeField]
	protected string backgroundSprite;

	// Token: 0x040026A1 RID: 9889
	[global::UnityEngine.SerializeField]
	protected global::dfControlOrientation orientation;

	// Token: 0x040026A2 RID: 9890
	[global::UnityEngine.SerializeField]
	protected float rawValue = 10f;

	// Token: 0x040026A3 RID: 9891
	[global::UnityEngine.SerializeField]
	protected float minValue;

	// Token: 0x040026A4 RID: 9892
	[global::UnityEngine.SerializeField]
	protected float maxValue = 100f;

	// Token: 0x040026A5 RID: 9893
	[global::UnityEngine.SerializeField]
	protected float stepSize = 1f;

	// Token: 0x040026A6 RID: 9894
	[global::UnityEngine.SerializeField]
	protected float scrollSize = 1f;

	// Token: 0x040026A7 RID: 9895
	[global::UnityEngine.SerializeField]
	protected global::dfControl thumb;

	// Token: 0x040026A8 RID: 9896
	[global::UnityEngine.SerializeField]
	protected global::dfControl fillIndicator;

	// Token: 0x040026A9 RID: 9897
	[global::UnityEngine.SerializeField]
	protected global::dfProgressFillMode fillMode = global::dfProgressFillMode.Fill;

	// Token: 0x040026AA RID: 9898
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.RectOffset fillPadding = new global::UnityEngine.RectOffset();

	// Token: 0x040026AB RID: 9899
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Vector2 thumbOffset = global::UnityEngine.Vector2.zero;

	// Token: 0x040026AC RID: 9900
	[global::UnityEngine.SerializeField]
	protected bool rightToLeft;

	// Token: 0x040026AD RID: 9901
	private global::PropertyChangedEventHandler<float> ValueChanged;
}
