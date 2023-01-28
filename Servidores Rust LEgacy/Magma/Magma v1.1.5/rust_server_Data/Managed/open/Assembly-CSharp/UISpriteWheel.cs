using System;
using NGUI.Meshing;
using NGUI.Structures;
using UnityEngine;

// Token: 0x0200054C RID: 1356
public class UISpriteWheel : global::UISlicedSprite
{
	// Token: 0x06002E3A RID: 11834 RVA: 0x000AFB64 File Offset: 0x000ADD64
	public UISpriteWheel()
	{
	}

	// Token: 0x170009E1 RID: 2529
	// (get) Token: 0x06002E3B RID: 11835 RVA: 0x000AFBA4 File Offset: 0x000ADDA4
	// (set) Token: 0x06002E3C RID: 11836 RVA: 0x000AFBAC File Offset: 0x000ADDAC
	public float innerRadius
	{
		get
		{
			return this._innerRadius;
		}
		set
		{
			if (value < 0f)
			{
				if (this._innerRadius != 0f)
				{
					this._innerRadius = 0f;
					this.MarkAsChanged();
				}
			}
			else if (value > 1f)
			{
				if (this._innerRadius != 1f)
				{
					this._innerRadius = 1f;
					this.MarkAsChanged();
				}
			}
			else if (this._innerRadius != value)
			{
				this._innerRadius = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x170009E2 RID: 2530
	// (get) Token: 0x06002E3D RID: 11837 RVA: 0x000AFC34 File Offset: 0x000ADE34
	// (set) Token: 0x06002E3E RID: 11838 RVA: 0x000AFC44 File Offset: 0x000ADE44
	public float outerRadius
	{
		get
		{
			return 1f - this._innerRadius;
		}
		set
		{
			this.innerRadius = 1f - value;
		}
	}

	// Token: 0x170009E3 RID: 2531
	// (get) Token: 0x06002E3F RID: 11839 RVA: 0x000AFC54 File Offset: 0x000ADE54
	// (set) Token: 0x06002E40 RID: 11840 RVA: 0x000AFC5C File Offset: 0x000ADE5C
	public float sliceDegrees
	{
		get
		{
			return this._sliceDegrees;
		}
		set
		{
			if (value < 0f)
			{
				value = 0f;
			}
			if (this._sliceDegrees != value)
			{
				this._sliceDegrees = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x170009E4 RID: 2532
	// (get) Token: 0x06002E41 RID: 11841 RVA: 0x000AFC8C File Offset: 0x000ADE8C
	// (set) Token: 0x06002E42 RID: 11842 RVA: 0x000AFC94 File Offset: 0x000ADE94
	public float circumferenceFillRatio
	{
		get
		{
			return this._sliceFill;
		}
		set
		{
			if (value < 0.05f)
			{
				value = 0.05f;
			}
			else if (value > 1f)
			{
				value = 1f;
			}
			if (this._sliceFill != value)
			{
				this._sliceFill = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x170009E5 RID: 2533
	// (get) Token: 0x06002E43 RID: 11843 RVA: 0x000AFCE4 File Offset: 0x000ADEE4
	// (set) Token: 0x06002E44 RID: 11844 RVA: 0x000AFCEC File Offset: 0x000ADEEC
	public float degreesOfRotation
	{
		get
		{
			return this._degreesOfRotation;
		}
		set
		{
			if (value < 0.01f)
			{
				value = 0.01f;
			}
			else if (value > 360f)
			{
				value = 360f;
			}
			if (value != this._degreesOfRotation)
			{
				this._degreesOfRotation = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x170009E6 RID: 2534
	// (get) Token: 0x06002E45 RID: 11845 RVA: 0x000AFD3C File Offset: 0x000ADF3C
	// (set) Token: 0x06002E46 RID: 11846 RVA: 0x000AFD44 File Offset: 0x000ADF44
	public float facialCrank
	{
		get
		{
			return this._facialRotationOffset;
		}
		set
		{
			if (value < -1f)
			{
				value = -1f;
			}
			else if (value > 1f)
			{
				value = 1f;
			}
			if (value != this._facialRotationOffset)
			{
				this._facialRotationOffset = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x170009E7 RID: 2535
	// (get) Token: 0x06002E47 RID: 11847 RVA: 0x000AFD94 File Offset: 0x000ADF94
	// (set) Token: 0x06002E48 RID: 11848 RVA: 0x000AFD9C File Offset: 0x000ADF9C
	public float additionalRotation
	{
		get
		{
			return this._addDegrees;
		}
		set
		{
			if (float.IsInfinity(value) || float.IsNaN(value))
			{
				return;
			}
			while (value > 180f)
			{
				value -= 360f;
			}
			while (value <= -180f)
			{
				value += 360f;
			}
			if (value != this._addDegrees)
			{
				this._addDegrees = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x170009E8 RID: 2536
	// (get) Token: 0x06002E49 RID: 11849 RVA: 0x000AFE0C File Offset: 0x000AE00C
	// (set) Token: 0x06002E4A RID: 11850 RVA: 0x000AFE14 File Offset: 0x000AE014
	public float targetDegreeResolution
	{
		get
		{
			return this._targetDegreeResolution;
		}
		set
		{
			if (0.5f > value)
			{
				value = 0.5f;
			}
			if (this._targetDegreeResolution != value)
			{
				this._targetDegreeResolution = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x170009E9 RID: 2537
	// (get) Token: 0x06002E4B RID: 11851 RVA: 0x000AFE44 File Offset: 0x000AE044
	// (set) Token: 0x06002E4C RID: 11852 RVA: 0x000AFE4C File Offset: 0x000AE04C
	public global::UnityEngine.Vector2 center
	{
		get
		{
			return this._center;
		}
		set
		{
			if (this._center != value)
			{
				this._center = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x170009EA RID: 2538
	// (get) Token: 0x06002E4D RID: 11853 RVA: 0x000AFE6C File Offset: 0x000AE06C
	// (set) Token: 0x06002E4E RID: 11854 RVA: 0x000AFE74 File Offset: 0x000AE074
	public int slices
	{
		get
		{
			return this._slices;
		}
		set
		{
			if (value < 0)
			{
				value = 0;
			}
			else if (value > 0x168)
			{
				value = 0x168;
			}
			if (this._slices != value)
			{
				this._slices = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x06002E4F RID: 11855 RVA: 0x000AFEBC File Offset: 0x000AE0BC
	public override void OnFill(global::NGUI.Meshing.MeshBuffer m)
	{
		float num = this._degreesOfRotation * 0.017453292f;
		float num2 = this._sliceDegrees * 0.017453292f;
		float sliceFill = this._sliceFill;
		int num3 = this.slices + 1;
		float num4 = (num - num2 * (float)this.slices) * sliceFill;
		float num5 = num4 / (float)num3;
		float num6 = num4 / 6.2831855f;
		float num7 = (num - num4) / (float)num3;
		global::NGUI.Structures.float3 @float = default(global::NGUI.Structures.float3);
		@float.xyz = base.cachedTransform.localScale;
		float num8 = (@float.x >= @float.y) ? @float.x : @float.y;
		@float.xy.x = 3.1415927f * num8 / (float)num3 * num6;
		@float.xy.y = num8 * (this.outerRadius * 0.5f);
		global::UnityEngine.Vector4 vector;
		vector.x = this.mOuterUV.xMin;
		vector.y = this.mInnerUV.xMin;
		vector.z = this.mInnerUV.xMax;
		vector.w = this.mOuterUV.xMax;
		global::UnityEngine.Vector4 vector2;
		vector2.x = this.mOuterUV.yMin;
		vector2.y = this.mInnerUV.yMin;
		vector2.z = this.mInnerUV.yMax;
		vector2.w = this.mOuterUV.yMax;
		global::NGUI.Structures.NineRectangle nineRectangle;
		global::NGUI.Structures.NineRectangle nineRectangle2;
		global::NGUI.Structures.NineRectangle.Calculate(global::UIWidget.Pivot.Center, base.atlas.pixelSize, base.mainTexture, ref vector, ref vector2, ref @float.xy, out nineRectangle, out nineRectangle2);
		if (this.innerRadius > 0f && !global::UnityEngine.Mathf.Approximately(nineRectangle.zz.x - nineRectangle.yy.x, 0f))
		{
			@float.xy.x = 3.1415927f * num8 * this.innerRadius / (float)num3 * num6;
			global::NGUI.Structures.NineRectangle nineRectangle3;
			global::NGUI.Structures.NineRectangle nineRectangle4;
			global::NGUI.Structures.NineRectangle.Calculate(global::UIWidget.Pivot.Center, base.atlas.pixelSize, base.mainTexture, ref vector, ref vector2, ref @float.xy, out nineRectangle3, out nineRectangle4);
			float num9 = (nineRectangle.yy.x + nineRectangle.zz.x) * 0.5f;
			if (nineRectangle3.yy.x > num9)
			{
				float num10 = (nineRectangle3.yy.x - num9) / (nineRectangle.ww.x - num9);
				if (num10 >= 1f)
				{
					nineRectangle3.xx.x = nineRectangle.xx.x;
					nineRectangle3.xx.y = nineRectangle.xx.y;
					nineRectangle3.yy.x = nineRectangle.yy.x;
					nineRectangle3.yy.y = nineRectangle.yy.y;
					nineRectangle3.zz.x = nineRectangle.zz.x;
					nineRectangle3.zz.y = nineRectangle.zz.y;
					nineRectangle3.ww.x = nineRectangle.ww.x;
					nineRectangle3.ww.y = nineRectangle.ww.y;
					nineRectangle4.xx.x = nineRectangle2.xx.x;
					nineRectangle4.xx.y = nineRectangle2.xx.y;
					nineRectangle4.yy.x = nineRectangle2.yy.x;
					nineRectangle4.yy.y = nineRectangle2.yy.y;
					nineRectangle4.zz.x = nineRectangle2.zz.x;
					nineRectangle4.zz.y = nineRectangle2.zz.y;
					nineRectangle4.ww.x = nineRectangle2.ww.x;
					nineRectangle4.ww.y = nineRectangle2.ww.y;
				}
				else
				{
					float num11 = 1f - num10;
					nineRectangle3.xx.y = nineRectangle.xx.y * num10 + nineRectangle3.xx.y * num11;
					nineRectangle3.yy.x = nineRectangle.yy.x * num10 + 0.5f * num11;
					nineRectangle3.yy.y = nineRectangle.yy.y * num10 + nineRectangle3.yy.y * num11;
					nineRectangle3.zz.x = nineRectangle.zz.x * num10 + 0.5f * num11;
					nineRectangle3.zz.y = nineRectangle.zz.y * num10 + nineRectangle3.zz.y * num11;
					nineRectangle3.ww.y = nineRectangle.ww.y * num10 + nineRectangle3.ww.y * num11;
					nineRectangle3.ww.x = nineRectangle.ww.x;
					nineRectangle3.xx.x = nineRectangle.xx.x;
				}
			}
		}
		else
		{
			global::NGUI.Structures.NineRectangle nineRectangle3;
			nineRectangle3.xx.x = nineRectangle.xx.x;
			nineRectangle3.xx.y = nineRectangle.xx.y;
			nineRectangle3.yy.x = nineRectangle.yy.x;
			nineRectangle3.yy.y = nineRectangle.yy.y;
			nineRectangle3.zz.x = nineRectangle.zz.x;
			nineRectangle3.zz.y = nineRectangle.zz.y;
			nineRectangle3.ww.x = nineRectangle.ww.x;
			nineRectangle3.ww.y = nineRectangle.ww.y;
			global::NGUI.Structures.NineRectangle nineRectangle4;
			nineRectangle4.xx.x = nineRectangle2.xx.x;
			nineRectangle4.xx.y = nineRectangle2.xx.y;
			nineRectangle4.yy.x = nineRectangle2.yy.x;
			nineRectangle4.yy.y = nineRectangle2.yy.y;
			nineRectangle4.zz.x = nineRectangle2.zz.x;
			nineRectangle4.zz.y = nineRectangle2.zz.y;
			nineRectangle4.ww.x = nineRectangle2.ww.x;
			nineRectangle4.ww.y = nineRectangle2.ww.y;
		}
		float num12 = global::UnityEngine.Mathf.Abs(nineRectangle.ww.x - nineRectangle.xx.x);
		float num13 = num5 / num12;
		if (num2 > 0f)
		{
			num12 += num2 / num13;
			num13 = num5 / num12;
		}
		float num14 = this.innerRadius * 0.5f;
		float num15 = this.outerRadius * 0.5f;
		float num16 = global::UnityEngine.Mathf.Min(nineRectangle.xx.y, nineRectangle.ww.y);
		float num17 = global::UnityEngine.Mathf.Max(nineRectangle.ww.y, nineRectangle.xx.y) - num16;
		global::UnityEngine.Color color = base.color;
		int num18 = m.vSize;
		float num19 = num7 + num5;
		float num20 = num7 * -0.5f + (this._facialRotationOffset * 0.5f + 0.5f) * num5 + this._addDegrees * 0.017453292f;
		for (;;)
		{
			global::NGUI.Meshing.Vertex[] v = m.v;
			int vSize = m.vSize;
			for (int i = num18; i < vSize; i++)
			{
				float num21 = num14 + (v[i].y - num16) / num17 * num15;
				float num22 = v[i].x * num13 + num20;
				v[i].x = 0.5f + global::UnityEngine.Mathf.Sin(num22) * num21;
				v[i].y = -0.5f + global::UnityEngine.Mathf.Cos(num22) * num21;
			}
			if (--num3 <= 0)
			{
				break;
			}
			num20 += num19;
			num18 = vSize;
		}
	}

	// Token: 0x040017E3 RID: 6115
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private float _innerRadius = 0.5f;

	// Token: 0x040017E4 RID: 6116
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Vector2 _center;

	// Token: 0x040017E5 RID: 6117
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private int _slices;

	// Token: 0x040017E6 RID: 6118
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private float _sliceDegrees;

	// Token: 0x040017E7 RID: 6119
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private float _targetDegreeResolution = 10f;

	// Token: 0x040017E8 RID: 6120
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private float _sliceFill = 1f;

	// Token: 0x040017E9 RID: 6121
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private float _degreesOfRotation = 360f;

	// Token: 0x040017EA RID: 6122
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private float _facialRotationOffset;

	// Token: 0x040017EB RID: 6123
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private float _addDegrees;
}
