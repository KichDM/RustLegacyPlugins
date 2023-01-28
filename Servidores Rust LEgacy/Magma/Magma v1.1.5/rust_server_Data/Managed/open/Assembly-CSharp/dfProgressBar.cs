using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200082A RID: 2090
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/Progress Bar")]
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.BoxCollider))]
public class dfProgressBar : global::dfControl
{
	// Token: 0x06004707 RID: 18183 RVA: 0x00105BE4 File Offset: 0x00103DE4
	public dfProgressBar()
	{
	}

	// Token: 0x1400004D RID: 77
	// (add) Token: 0x06004708 RID: 18184 RVA: 0x00105C20 File Offset: 0x00103E20
	// (remove) Token: 0x06004709 RID: 18185 RVA: 0x00105C3C File Offset: 0x00103E3C
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

	// Token: 0x17000D3D RID: 3389
	// (get) Token: 0x0600470A RID: 18186 RVA: 0x00105C58 File Offset: 0x00103E58
	// (set) Token: 0x0600470B RID: 18187 RVA: 0x00105CA0 File Offset: 0x00103EA0
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

	// Token: 0x17000D3E RID: 3390
	// (get) Token: 0x0600470C RID: 18188 RVA: 0x00105CC0 File Offset: 0x00103EC0
	// (set) Token: 0x0600470D RID: 18189 RVA: 0x00105CC8 File Offset: 0x00103EC8
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
				this.setDefaultSize(value);
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D3F RID: 3391
	// (get) Token: 0x0600470E RID: 18190 RVA: 0x00105CF0 File Offset: 0x00103EF0
	// (set) Token: 0x0600470F RID: 18191 RVA: 0x00105CF8 File Offset: 0x00103EF8
	public string ProgressSprite
	{
		get
		{
			return this.progressSprite;
		}
		set
		{
			if (value != this.progressSprite)
			{
				this.progressSprite = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D40 RID: 3392
	// (get) Token: 0x06004710 RID: 18192 RVA: 0x00105D18 File Offset: 0x00103F18
	// (set) Token: 0x06004711 RID: 18193 RVA: 0x00105D20 File Offset: 0x00103F20
	public global::UnityEngine.Color32 ProgressColor
	{
		get
		{
			return this.progressColor;
		}
		set
		{
			if (!object.Equals(value, this.progressColor))
			{
				this.progressColor = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D41 RID: 3393
	// (get) Token: 0x06004712 RID: 18194 RVA: 0x00105D58 File Offset: 0x00103F58
	// (set) Token: 0x06004713 RID: 18195 RVA: 0x00105D60 File Offset: 0x00103F60
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

	// Token: 0x17000D42 RID: 3394
	// (get) Token: 0x06004714 RID: 18196 RVA: 0x00105D9C File Offset: 0x00103F9C
	// (set) Token: 0x06004715 RID: 18197 RVA: 0x00105DA4 File Offset: 0x00103FA4
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

	// Token: 0x17000D43 RID: 3395
	// (get) Token: 0x06004716 RID: 18198 RVA: 0x00105DE0 File Offset: 0x00103FE0
	// (set) Token: 0x06004717 RID: 18199 RVA: 0x00105DE8 File Offset: 0x00103FE8
	public float Value
	{
		get
		{
			return this.rawValue;
		}
		set
		{
			value = global::UnityEngine.Mathf.Max(this.minValue, global::UnityEngine.Mathf.Min(this.maxValue, value));
			if (!global::UnityEngine.Mathf.Approximately(value, this.rawValue))
			{
				this.rawValue = value;
				this.OnValueChanged();
			}
		}
	}

	// Token: 0x17000D44 RID: 3396
	// (get) Token: 0x06004718 RID: 18200 RVA: 0x00105E24 File Offset: 0x00104024
	// (set) Token: 0x06004719 RID: 18201 RVA: 0x00105E2C File Offset: 0x0010402C
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

	// Token: 0x17000D45 RID: 3397
	// (get) Token: 0x0600471A RID: 18202 RVA: 0x00105E48 File Offset: 0x00104048
	// (set) Token: 0x0600471B RID: 18203 RVA: 0x00105E68 File Offset: 0x00104068
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
			if (!object.Equals(value, this.padding))
			{
				this.padding = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D46 RID: 3398
	// (get) Token: 0x0600471C RID: 18204 RVA: 0x00105E88 File Offset: 0x00104088
	// (set) Token: 0x0600471D RID: 18205 RVA: 0x00105E90 File Offset: 0x00104090
	public bool ActAsSlider
	{
		get
		{
			return this.actAsSlider;
		}
		set
		{
			this.actAsSlider = value;
		}
	}

	// Token: 0x0600471E RID: 18206 RVA: 0x00105E9C File Offset: 0x0010409C
	protected internal override void OnMouseWheel(global::dfMouseEventArgs args)
	{
		try
		{
			if (this.actAsSlider)
			{
				float num = (this.maxValue - this.minValue) * 0.1f;
				this.Value += num * (float)global::UnityEngine.Mathf.RoundToInt(-args.WheelDelta);
				args.Use();
			}
		}
		finally
		{
			base.OnMouseWheel(args);
		}
	}

	// Token: 0x0600471F RID: 18207 RVA: 0x00105F18 File Offset: 0x00104118
	protected internal override void OnMouseMove(global::dfMouseEventArgs args)
	{
		try
		{
			if (this.actAsSlider)
			{
				if (args.Buttons.IsSet(global::dfMouseButtons.Left))
				{
					this.Value = this.getValueFromMouseEvent(args);
					args.Use();
				}
			}
		}
		finally
		{
			base.OnMouseMove(args);
		}
	}

	// Token: 0x06004720 RID: 18208 RVA: 0x00105F88 File Offset: 0x00104188
	protected internal override void OnMouseDown(global::dfMouseEventArgs args)
	{
		try
		{
			if (this.actAsSlider)
			{
				if (args.Buttons.IsSet(global::dfMouseButtons.Left))
				{
					base.Focus();
					this.Value = this.getValueFromMouseEvent(args);
					args.Use();
				}
			}
		}
		finally
		{
			base.OnMouseDown(args);
		}
	}

	// Token: 0x06004721 RID: 18209 RVA: 0x00106000 File Offset: 0x00104200
	protected internal override void OnKeyDown(global::dfKeyEventArgs args)
	{
		try
		{
			if (this.actAsSlider)
			{
				float num = (this.maxValue - this.minValue) * 0.1f;
				if (args.KeyCode == 0x114)
				{
					this.Value -= num;
					args.Use();
				}
				else if (args.KeyCode == 0x113)
				{
					this.Value += num;
					args.Use();
				}
			}
		}
		finally
		{
			base.OnKeyDown(args);
		}
	}

	// Token: 0x06004722 RID: 18210 RVA: 0x001060AC File Offset: 0x001042AC
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

	// Token: 0x06004723 RID: 18211 RVA: 0x001060FC File Offset: 0x001042FC
	protected override void OnRebuildRenderData()
	{
		if (this.Atlas == null)
		{
			return;
		}
		this.renderData.Material = this.Atlas.Material;
		this.renderBackground();
		this.renderProgressFill();
	}

	// Token: 0x06004724 RID: 18212 RVA: 0x00106140 File Offset: 0x00104340
	private void renderProgressFill()
	{
		if (this.Atlas == null)
		{
			return;
		}
		global::dfAtlas.ItemInfo itemInfo = this.Atlas[this.progressSprite];
		if (itemInfo == null)
		{
			return;
		}
		global::UnityEngine.Vector3 vector;
		vector..ctor((float)this.padding.left, (float)(-(float)this.padding.top));
		global::UnityEngine.Vector2 size;
		size..ctor(this.size.x - (float)this.padding.horizontal, this.size.y - (float)this.padding.vertical);
		float fillAmount = 1f;
		float num = this.maxValue - this.minValue;
		float num2 = (this.rawValue - this.minValue) / num;
		global::dfProgressFillMode dfProgressFillMode = this.fillMode;
		if (dfProgressFillMode != global::dfProgressFillMode.Stretch || size.x * num2 < (float)itemInfo.border.horizontal)
		{
		}
		if (dfProgressFillMode == global::dfProgressFillMode.Fill)
		{
			fillAmount = num2;
		}
		else
		{
			size.x = global::UnityEngine.Mathf.Max((float)itemInfo.border.horizontal, size.x * num2);
		}
		global::UnityEngine.Color32 color = base.ApplyOpacity((!base.IsEnabled) ? base.DisabledColor : this.ProgressColor);
		global::dfSprite.RenderOptions options = new global::dfSprite.RenderOptions
		{
			atlas = this.atlas,
			color = color,
			fillAmount = fillAmount,
			offset = this.pivot.TransformToUpperLeft(base.Size) + vector,
			pixelsToUnits = base.PixelsToUnits(),
			size = size,
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

	// Token: 0x06004725 RID: 18213 RVA: 0x00106324 File Offset: 0x00104524
	private void renderBackground()
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
		global::UnityEngine.Color32 color = base.ApplyOpacity((!base.IsEnabled) ? base.DisabledColor : base.Color);
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

	// Token: 0x06004726 RID: 18214 RVA: 0x0010642C File Offset: 0x0010462C
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
		global::UnityEngine.Vector3 vector3 = global::dfProgressBar.closestPoint(vector, vector2, test, true);
		float num2 = (vector3 - vector).magnitude / (vector2 - vector).magnitude;
		return this.minValue + (this.maxValue - this.minValue) * num2;
	}

	// Token: 0x06004727 RID: 18215 RVA: 0x00106500 File Offset: 0x00104700
	private global::UnityEngine.Vector3[] getEndPoints(bool convertToWorld = false)
	{
		global::UnityEngine.Vector3 vector = this.pivot.TransformToUpperLeft(base.Size);
		global::UnityEngine.Vector3 vector2;
		vector2..ctor(vector.x + (float)this.padding.left, vector.y - this.size.y * 0.5f);
		global::UnityEngine.Vector3 vector3 = vector2 + new global::UnityEngine.Vector3(this.size.x - (float)this.padding.right, 0f);
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

	// Token: 0x06004728 RID: 18216 RVA: 0x001065D4 File Offset: 0x001047D4
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

	// Token: 0x06004729 RID: 18217 RVA: 0x00106640 File Offset: 0x00104840
	private void setDefaultSize(string spriteName)
	{
		if (this.Atlas == null)
		{
			return;
		}
		global::dfAtlas.ItemInfo itemInfo = this.Atlas[spriteName];
		if (this.size == global::UnityEngine.Vector2.zero && itemInfo != null)
		{
			base.Size = itemInfo.sizeInPixels;
		}
	}

	// Token: 0x04002648 RID: 9800
	[global::UnityEngine.SerializeField]
	protected global::dfAtlas atlas;

	// Token: 0x04002649 RID: 9801
	[global::UnityEngine.SerializeField]
	protected string backgroundSprite;

	// Token: 0x0400264A RID: 9802
	[global::UnityEngine.SerializeField]
	protected string progressSprite;

	// Token: 0x0400264B RID: 9803
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Color32 progressColor = global::UnityEngine.Color.white;

	// Token: 0x0400264C RID: 9804
	[global::UnityEngine.SerializeField]
	protected float rawValue = 0.25f;

	// Token: 0x0400264D RID: 9805
	[global::UnityEngine.SerializeField]
	protected float minValue;

	// Token: 0x0400264E RID: 9806
	[global::UnityEngine.SerializeField]
	protected float maxValue = 1f;

	// Token: 0x0400264F RID: 9807
	[global::UnityEngine.SerializeField]
	protected global::dfProgressFillMode fillMode;

	// Token: 0x04002650 RID: 9808
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.RectOffset padding = new global::UnityEngine.RectOffset();

	// Token: 0x04002651 RID: 9809
	[global::UnityEngine.SerializeField]
	protected bool actAsSlider;

	// Token: 0x04002652 RID: 9810
	private global::PropertyChangedEventHandler<float> ValueChanged;
}
