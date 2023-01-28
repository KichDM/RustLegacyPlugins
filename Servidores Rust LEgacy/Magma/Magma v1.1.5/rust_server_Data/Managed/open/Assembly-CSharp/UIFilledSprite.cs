using System;
using NGUI.Meshing;
using UnityEngine;

// Token: 0x02000941 RID: 2369
[global::UnityEngine.AddComponentMenu("NGUI/UI/Sprite (Filled)")]
[global::UnityEngine.ExecuteInEditMode]
public class UIFilledSprite : global::UISprite
{
	// Token: 0x060050A7 RID: 20647 RVA: 0x0013AE04 File Offset: 0x00139004
	public UIFilledSprite()
	{
	}

	// Token: 0x17000EF1 RID: 3825
	// (get) Token: 0x060050A8 RID: 20648 RVA: 0x0013AE20 File Offset: 0x00139020
	// (set) Token: 0x060050A9 RID: 20649 RVA: 0x0013AE28 File Offset: 0x00139028
	public global::UIFilledSprite.FillDirection fillDirection
	{
		get
		{
			return this.mFillDirection;
		}
		set
		{
			if (this.mFillDirection != value)
			{
				this.mFillDirection = value;
				base.ChangedAuto();
			}
		}
	}

	// Token: 0x17000EF2 RID: 3826
	// (get) Token: 0x060050AA RID: 20650 RVA: 0x0013AE44 File Offset: 0x00139044
	// (set) Token: 0x060050AB RID: 20651 RVA: 0x0013AE4C File Offset: 0x0013904C
	public float fillAmount
	{
		get
		{
			return this.mFillAmount;
		}
		set
		{
			float num = global::UnityEngine.Mathf.Clamp01(value);
			if (this.mFillAmount != num)
			{
				this.mFillAmount = num;
				base.ChangedAuto();
			}
		}
	}

	// Token: 0x17000EF3 RID: 3827
	// (get) Token: 0x060050AC RID: 20652 RVA: 0x0013AE7C File Offset: 0x0013907C
	// (set) Token: 0x060050AD RID: 20653 RVA: 0x0013AE84 File Offset: 0x00139084
	public bool invert
	{
		get
		{
			return this.mInvert;
		}
		set
		{
			if (this.mInvert != value)
			{
				this.mInvert = value;
				base.ChangedAuto();
			}
		}
	}

	// Token: 0x060050AE RID: 20654 RVA: 0x0013AEA0 File Offset: 0x001390A0
	private bool AdjustRadial(global::UnityEngine.Vector2[] xy, global::UnityEngine.Vector2[] uv, float fill, bool invert)
	{
		if (fill < 0.001f)
		{
			return false;
		}
		if (!invert && fill > 0.999f)
		{
			return true;
		}
		float num = global::UnityEngine.Mathf.Clamp01(fill);
		if (!invert)
		{
			num = 1f - num;
		}
		num *= 1.5707964f;
		float num2 = global::UnityEngine.Mathf.Sin(num);
		float num3 = global::UnityEngine.Mathf.Cos(num);
		if (num2 > num3)
		{
			num3 *= 1f / num2;
			num2 = 1f;
			if (!invert)
			{
				xy[0].y = global::UnityEngine.Mathf.Lerp(xy[2].y, xy[0].y, num3);
				xy[3].y = xy[0].y;
				uv[0].y = global::UnityEngine.Mathf.Lerp(uv[2].y, uv[0].y, num3);
				uv[3].y = uv[0].y;
			}
		}
		else if (num3 > num2)
		{
			num2 *= 1f / num3;
			num3 = 1f;
			if (invert)
			{
				xy[0].x = global::UnityEngine.Mathf.Lerp(xy[2].x, xy[0].x, num2);
				xy[1].x = xy[0].x;
				uv[0].x = global::UnityEngine.Mathf.Lerp(uv[2].x, uv[0].x, num2);
				uv[1].x = uv[0].x;
			}
		}
		else
		{
			num2 = 1f;
			num3 = 1f;
		}
		if (invert)
		{
			xy[1].y = global::UnityEngine.Mathf.Lerp(xy[2].y, xy[0].y, num3);
			uv[1].y = global::UnityEngine.Mathf.Lerp(uv[2].y, uv[0].y, num3);
		}
		else
		{
			xy[3].x = global::UnityEngine.Mathf.Lerp(xy[2].x, xy[0].x, num2);
			uv[3].x = global::UnityEngine.Mathf.Lerp(uv[2].x, uv[0].x, num2);
		}
		return true;
	}

	// Token: 0x060050AF RID: 20655 RVA: 0x0013B10C File Offset: 0x0013930C
	private void Rotate(global::UnityEngine.Vector2[] v, int offset)
	{
		for (int i = 0; i < offset; i++)
		{
			global::UnityEngine.Vector2 vector;
			vector..ctor(v[3].x, v[3].y);
			v[3].x = v[2].y;
			v[3].y = v[2].x;
			v[2].x = v[1].y;
			v[2].y = v[1].x;
			v[1].x = v[0].y;
			v[1].y = v[0].x;
			v[0].x = vector.y;
			v[0].y = vector.x;
		}
	}

	// Token: 0x060050B0 RID: 20656 RVA: 0x0013B200 File Offset: 0x00139400
	public override void OnFill(global::NGUI.Meshing.MeshBuffer m)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 1f;
		float num4 = -1f;
		float num5 = this.mOuterUV.xMin;
		float num6 = this.mOuterUV.yMin;
		float num7 = this.mOuterUV.xMax;
		float num8 = this.mOuterUV.yMax;
		if (this.mFillDirection == global::UIFilledSprite.FillDirection.Horizontal || this.mFillDirection == global::UIFilledSprite.FillDirection.Vertical)
		{
			float num9 = (num7 - num5) * this.mFillAmount;
			float num10 = (num8 - num6) * this.mFillAmount;
			if (this.fillDirection == global::UIFilledSprite.FillDirection.Horizontal)
			{
				if (this.mInvert)
				{
					num = 1f - this.mFillAmount;
					num5 = num7 - num9;
				}
				else
				{
					num3 *= this.mFillAmount;
					num7 = num5 + num9;
				}
			}
			else if (this.fillDirection == global::UIFilledSprite.FillDirection.Vertical)
			{
				if (this.mInvert)
				{
					num4 *= this.mFillAmount;
					num6 = num8 - num10;
				}
				else
				{
					num2 = -(1f - this.mFillAmount);
					num8 = num6 + num10;
				}
			}
		}
		global::UnityEngine.Vector2[] array = new global::UnityEngine.Vector2[4];
		global::UnityEngine.Vector2[] array2 = new global::UnityEngine.Vector2[4];
		array[0] = new global::UnityEngine.Vector2(num3, num2);
		array[1] = new global::UnityEngine.Vector2(num3, num4);
		array[2] = new global::UnityEngine.Vector2(num, num4);
		array[3] = new global::UnityEngine.Vector2(num, num2);
		array2[0] = new global::UnityEngine.Vector2(num7, num8);
		array2[1] = new global::UnityEngine.Vector2(num7, num6);
		array2[2] = new global::UnityEngine.Vector2(num5, num6);
		array2[3] = new global::UnityEngine.Vector2(num5, num8);
		global::UnityEngine.Color color = base.color;
		if (this.fillDirection == global::UIFilledSprite.FillDirection.Radial90)
		{
			if (!this.AdjustRadial(array, array2, this.mFillAmount, this.mInvert))
			{
				return;
			}
		}
		else
		{
			if (this.fillDirection == global::UIFilledSprite.FillDirection.Radial180)
			{
				global::UnityEngine.Vector2[] array3 = new global::UnityEngine.Vector2[4];
				global::UnityEngine.Vector2[] array4 = new global::UnityEngine.Vector2[4];
				for (int i = 0; i < 2; i++)
				{
					array3[0] = new global::UnityEngine.Vector2(0f, 0f);
					array3[1] = new global::UnityEngine.Vector2(0f, 1f);
					array3[2] = new global::UnityEngine.Vector2(1f, 1f);
					array3[3] = new global::UnityEngine.Vector2(1f, 0f);
					array4[0] = new global::UnityEngine.Vector2(0f, 0f);
					array4[1] = new global::UnityEngine.Vector2(0f, 1f);
					array4[2] = new global::UnityEngine.Vector2(1f, 1f);
					array4[3] = new global::UnityEngine.Vector2(1f, 0f);
					if (this.mInvert)
					{
						if (i > 0)
						{
							this.Rotate(array3, i);
							this.Rotate(array4, i);
						}
					}
					else if (i < 1)
					{
						this.Rotate(array3, 1 - i);
						this.Rotate(array4, 1 - i);
					}
					float num11;
					float num12;
					if (i == 1)
					{
						num11 = ((!this.mInvert) ? 1f : 0.5f);
						num12 = ((!this.mInvert) ? 0.5f : 1f);
					}
					else
					{
						num11 = ((!this.mInvert) ? 0.5f : 1f);
						num12 = ((!this.mInvert) ? 1f : 0.5f);
					}
					array3[1].y = global::UnityEngine.Mathf.Lerp(num11, num12, array3[1].y);
					array3[2].y = global::UnityEngine.Mathf.Lerp(num11, num12, array3[2].y);
					array4[1].y = global::UnityEngine.Mathf.Lerp(num11, num12, array4[1].y);
					array4[2].y = global::UnityEngine.Mathf.Lerp(num11, num12, array4[2].y);
					float fill = this.mFillAmount * 2f - (float)i;
					bool flag = i % 2 == 1;
					if (this.AdjustRadial(array3, array4, fill, !flag))
					{
						if (this.mInvert)
						{
							flag = !flag;
						}
						if (flag)
						{
							int num13 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Quad);
							for (int j = 0; j < 4; j++)
							{
								m.v[num13].x = global::UnityEngine.Mathf.Lerp(array[0].x, array[2].x, array3[j].x);
								m.v[num13].y = global::UnityEngine.Mathf.Lerp(array[0].y, array[2].y, array3[j].y);
								m.v[num13].z = 0f;
								m.v[num13].u = global::UnityEngine.Mathf.Lerp(array2[0].x, array2[2].x, array4[j].x);
								m.v[num13].v = global::UnityEngine.Mathf.Lerp(array2[0].y, array2[2].y, array4[j].y);
								m.v[num13].r = color.r;
								m.v[num13].g = color.g;
								m.v[num13].b = color.b;
								m.v[num13].a = color.a;
								num13++;
							}
						}
						else
						{
							int num14 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Quad);
							for (int k = 3; k > -1; k--)
							{
								m.v[num14].x = global::UnityEngine.Mathf.Lerp(array[0].x, array[2].x, array3[k].x);
								m.v[num14].y = global::UnityEngine.Mathf.Lerp(array[0].y, array[2].y, array3[k].y);
								m.v[num14].z = 0f;
								m.v[num14].u = global::UnityEngine.Mathf.Lerp(array2[0].x, array2[2].x, array4[k].x);
								m.v[num14].v = global::UnityEngine.Mathf.Lerp(array2[0].y, array2[2].y, array4[k].y);
								m.v[num14].r = color.r;
								m.v[num14].g = color.g;
								m.v[num14].b = color.b;
								m.v[num14].a = color.a;
								num14++;
							}
						}
					}
				}
				return;
			}
			if (this.fillDirection == global::UIFilledSprite.FillDirection.Radial360)
			{
				float[] array5 = new float[]
				{
					0.5f,
					1f,
					0f,
					0.5f,
					0.5f,
					1f,
					0.5f,
					1f,
					0f,
					0.5f,
					0.5f,
					1f,
					0f,
					0.5f,
					0f,
					0.5f
				};
				global::UnityEngine.Vector2[] array6 = new global::UnityEngine.Vector2[4];
				global::UnityEngine.Vector2[] array7 = new global::UnityEngine.Vector2[4];
				for (int l = 0; l < 4; l++)
				{
					array6[0] = new global::UnityEngine.Vector2(0f, 0f);
					array6[1] = new global::UnityEngine.Vector2(0f, 1f);
					array6[2] = new global::UnityEngine.Vector2(1f, 1f);
					array6[3] = new global::UnityEngine.Vector2(1f, 0f);
					array7[0] = new global::UnityEngine.Vector2(0f, 0f);
					array7[1] = new global::UnityEngine.Vector2(0f, 1f);
					array7[2] = new global::UnityEngine.Vector2(1f, 1f);
					array7[3] = new global::UnityEngine.Vector2(1f, 0f);
					if (this.mInvert)
					{
						if (l > 0)
						{
							this.Rotate(array6, l);
							this.Rotate(array7, l);
						}
					}
					else if (l < 3)
					{
						this.Rotate(array6, 3 - l);
						this.Rotate(array7, 3 - l);
					}
					for (int n = 0; n < 4; n++)
					{
						int num15 = (!this.mInvert) ? (l * 4) : ((3 - l) * 4);
						float num16 = array5[num15];
						float num17 = array5[num15 + 1];
						float num18 = array5[num15 + 2];
						float num19 = array5[num15 + 3];
						array6[n].x = global::UnityEngine.Mathf.Lerp(num16, num17, array6[n].x);
						array6[n].y = global::UnityEngine.Mathf.Lerp(num18, num19, array6[n].y);
						array7[n].x = global::UnityEngine.Mathf.Lerp(num16, num17, array7[n].x);
						array7[n].y = global::UnityEngine.Mathf.Lerp(num18, num19, array7[n].y);
					}
					float fill2 = this.mFillAmount * 4f - (float)l;
					bool flag2 = l % 2 == 1;
					if (this.AdjustRadial(array6, array7, fill2, !flag2))
					{
						if (this.mInvert)
						{
							flag2 = !flag2;
						}
						if (flag2)
						{
							int num20 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Quad);
							for (int num21 = 0; num21 < 4; num21++)
							{
								m.v[num20].x = global::UnityEngine.Mathf.Lerp(array[0].x, array[2].x, array6[num21].x);
								m.v[num20].y = global::UnityEngine.Mathf.Lerp(array[0].y, array[2].y, array6[num21].y);
								m.v[num20].z = 0f;
								m.v[num20].u = global::UnityEngine.Mathf.Lerp(array2[0].x, array2[2].x, array7[num21].x);
								m.v[num20].v = global::UnityEngine.Mathf.Lerp(array2[0].y, array2[2].y, array7[num21].y);
								m.v[num20].r = color.r;
								m.v[num20].g = color.g;
								m.v[num20].b = color.b;
								m.v[num20].a = color.a;
								num20++;
							}
						}
						else
						{
							int num22 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Quad);
							for (int num23 = 3; num23 > -1; num23--)
							{
								m.v[num22].x = global::UnityEngine.Mathf.Lerp(array[0].x, array[2].x, array6[num23].x);
								m.v[num22].y = global::UnityEngine.Mathf.Lerp(array[0].y, array[2].y, array6[num23].y);
								m.v[num22].z = 0f;
								m.v[num22].u = global::UnityEngine.Mathf.Lerp(array2[0].x, array2[2].x, array7[num23].x);
								m.v[num22].v = global::UnityEngine.Mathf.Lerp(array2[0].y, array2[2].y, array7[num23].y);
								m.v[num22].r = color.r;
								m.v[num22].g = color.g;
								m.v[num22].b = color.b;
								m.v[num22].a = color.a;
								num22++;
							}
						}
					}
				}
				return;
			}
		}
		global::NGUI.Meshing.Vertex a;
		a.x = array[0].x;
		a.y = array[0].y;
		a.u = array2[0].x;
		a.v = array2[0].y;
		global::NGUI.Meshing.Vertex b;
		b.x = array[1].x;
		b.y = array[1].y;
		b.u = array2[1].x;
		b.v = array2[1].y;
		global::NGUI.Meshing.Vertex c;
		c.x = array[2].x;
		c.y = array[2].y;
		c.u = array2[2].x;
		c.v = array2[2].y;
		global::NGUI.Meshing.Vertex d;
		d.x = array[3].x;
		d.y = array[3].y;
		d.u = array2[3].x;
		d.v = array2[3].y;
		a.z = (b.z = (c.z = (d.z = 0f)));
		a.r = (b.r = (c.r = (d.r = color.r)));
		a.g = (b.g = (c.g = (d.g = color.g)));
		a.b = (b.b = (c.b = (d.b = color.b)));
		a.a = (b.a = (c.a = (d.a = color.a)));
		m.Quad(a, b, c, d);
	}

	// Token: 0x04002D4D RID: 11597
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UIFilledSprite.FillDirection mFillDirection = global::UIFilledSprite.FillDirection.Radial360;

	// Token: 0x04002D4E RID: 11598
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private float mFillAmount = 1f;

	// Token: 0x04002D4F RID: 11599
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private bool mInvert;

	// Token: 0x02000942 RID: 2370
	public enum FillDirection
	{
		// Token: 0x04002D51 RID: 11601
		Horizontal,
		// Token: 0x04002D52 RID: 11602
		Vertical,
		// Token: 0x04002D53 RID: 11603
		Radial90,
		// Token: 0x04002D54 RID: 11604
		Radial180,
		// Token: 0x04002D55 RID: 11605
		Radial360
	}
}
