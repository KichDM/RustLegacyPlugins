using System;
using UnityEngine;

// Token: 0x02000828 RID: 2088
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/Containers/Panel")]
[global::UnityEngine.ExecuteInEditMode]
public class dfPanel : global::dfControl
{
	// Token: 0x060046E7 RID: 18151 RVA: 0x00105124 File Offset: 0x00103324
	public dfPanel()
	{
	}

	// Token: 0x17000D35 RID: 3381
	// (get) Token: 0x060046E8 RID: 18152 RVA: 0x00105148 File Offset: 0x00103348
	// (set) Token: 0x060046E9 RID: 18153 RVA: 0x00105190 File Offset: 0x00103390
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

	// Token: 0x17000D36 RID: 3382
	// (get) Token: 0x060046EA RID: 18154 RVA: 0x001051B0 File Offset: 0x001033B0
	// (set) Token: 0x060046EB RID: 18155 RVA: 0x001051B8 File Offset: 0x001033B8
	public string BackgroundSprite
	{
		get
		{
			return this.backgroundSprite;
		}
		set
		{
			value = base.getLocalizedValue(value);
			if (value != this.backgroundSprite)
			{
				this.backgroundSprite = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D37 RID: 3383
	// (get) Token: 0x060046EC RID: 18156 RVA: 0x001051E4 File Offset: 0x001033E4
	// (set) Token: 0x060046ED RID: 18157 RVA: 0x001051EC File Offset: 0x001033EC
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

	// Token: 0x17000D38 RID: 3384
	// (get) Token: 0x060046EE RID: 18158 RVA: 0x00105224 File Offset: 0x00103424
	// (set) Token: 0x060046EF RID: 18159 RVA: 0x00105244 File Offset: 0x00103444
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

	// Token: 0x060046F0 RID: 18160 RVA: 0x00105278 File Offset: 0x00103478
	protected internal override void OnLocalize()
	{
		base.OnLocalize();
		this.BackgroundSprite = base.getLocalizedValue(this.backgroundSprite);
	}

	// Token: 0x060046F1 RID: 18161 RVA: 0x00105294 File Offset: 0x00103494
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
		global::UnityEngine.RectOffset rectOffset = this.Padding;
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

	// Token: 0x060046F2 RID: 18162 RVA: 0x00105460 File Offset: 0x00103660
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
	}

	// Token: 0x060046F3 RID: 18163 RVA: 0x001054C4 File Offset: 0x001036C4
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

	// Token: 0x060046F4 RID: 18164 RVA: 0x001055DC File Offset: 0x001037DC
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
		base.Size = vector + new global::UnityEngine.Vector2((float)this.padding.right, (float)this.padding.bottom);
	}

	// Token: 0x060046F5 RID: 18165 RVA: 0x00105674 File Offset: 0x00103874
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

	// Token: 0x0400263F RID: 9791
	[global::UnityEngine.SerializeField]
	protected global::dfAtlas atlas;

	// Token: 0x04002640 RID: 9792
	[global::UnityEngine.SerializeField]
	protected string backgroundSprite;

	// Token: 0x04002641 RID: 9793
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Color32 backgroundColor = global::UnityEngine.Color.white;

	// Token: 0x04002642 RID: 9794
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.RectOffset padding = new global::UnityEngine.RectOffset();
}
