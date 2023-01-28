using System;
using System.Runtime.InteropServices;
using NGUI.Meshing;
using UnityEngine;

namespace NGUI.Structures
{
	// Token: 0x02000962 RID: 2402
	[global::System.Runtime.InteropServices.StructLayout(global::System.Runtime.InteropServices.LayoutKind.Explicit)]
	public struct NineRectangle
	{
		// Token: 0x17000F4C RID: 3916
		// (get) Token: 0x060051DB RID: 20955 RVA: 0x00144C9C File Offset: 0x00142E9C
		// (set) Token: 0x060051DC RID: 20956 RVA: 0x00144CD0 File Offset: 0x00142ED0
		public global::UnityEngine.Vector2 xy
		{
			get
			{
				global::UnityEngine.Vector2 result;
				result.x = this.xx.x;
				result.y = this.yy.y;
				return result;
			}
			set
			{
				this.xx.x = value.x;
				this.yy.y = value.y;
			}
		}

		// Token: 0x17000F4D RID: 3917
		// (get) Token: 0x060051DD RID: 20957 RVA: 0x00144D04 File Offset: 0x00142F04
		// (set) Token: 0x060051DE RID: 20958 RVA: 0x00144D38 File Offset: 0x00142F38
		public global::UnityEngine.Vector2 xz
		{
			get
			{
				global::UnityEngine.Vector2 result;
				result.x = this.xx.x;
				result.y = this.zz.y;
				return result;
			}
			set
			{
				this.xx.x = value.x;
				this.zz.y = value.y;
			}
		}

		// Token: 0x17000F4E RID: 3918
		// (get) Token: 0x060051DF RID: 20959 RVA: 0x00144D6C File Offset: 0x00142F6C
		// (set) Token: 0x060051E0 RID: 20960 RVA: 0x00144DA0 File Offset: 0x00142FA0
		public global::UnityEngine.Vector2 xw
		{
			get
			{
				global::UnityEngine.Vector2 result;
				result.x = this.xx.x;
				result.y = this.ww.y;
				return result;
			}
			set
			{
				this.xx.x = value.x;
				this.ww.y = value.y;
			}
		}

		// Token: 0x17000F4F RID: 3919
		// (get) Token: 0x060051E1 RID: 20961 RVA: 0x00144DD4 File Offset: 0x00142FD4
		// (set) Token: 0x060051E2 RID: 20962 RVA: 0x00144E08 File Offset: 0x00143008
		public global::UnityEngine.Vector2 yx
		{
			get
			{
				global::UnityEngine.Vector2 result;
				result.x = this.yy.x;
				result.y = this.xx.y;
				return result;
			}
			set
			{
				this.yy.x = value.x;
				this.xx.y = value.y;
			}
		}

		// Token: 0x17000F50 RID: 3920
		// (get) Token: 0x060051E3 RID: 20963 RVA: 0x00144E3C File Offset: 0x0014303C
		// (set) Token: 0x060051E4 RID: 20964 RVA: 0x00144E70 File Offset: 0x00143070
		public global::UnityEngine.Vector2 yz
		{
			get
			{
				global::UnityEngine.Vector2 result;
				result.x = this.yy.x;
				result.y = this.zz.y;
				return result;
			}
			set
			{
				this.yy.x = value.x;
				this.zz.y = value.y;
			}
		}

		// Token: 0x17000F51 RID: 3921
		// (get) Token: 0x060051E5 RID: 20965 RVA: 0x00144EA4 File Offset: 0x001430A4
		// (set) Token: 0x060051E6 RID: 20966 RVA: 0x00144ED8 File Offset: 0x001430D8
		public global::UnityEngine.Vector2 yw
		{
			get
			{
				global::UnityEngine.Vector2 result;
				result.x = this.yy.x;
				result.y = this.ww.y;
				return result;
			}
			set
			{
				this.yy.x = value.x;
				this.ww.y = value.y;
			}
		}

		// Token: 0x17000F52 RID: 3922
		// (get) Token: 0x060051E7 RID: 20967 RVA: 0x00144F0C File Offset: 0x0014310C
		// (set) Token: 0x060051E8 RID: 20968 RVA: 0x00144F40 File Offset: 0x00143140
		public global::UnityEngine.Vector2 zx
		{
			get
			{
				global::UnityEngine.Vector2 result;
				result.x = this.zz.x;
				result.y = this.xx.y;
				return result;
			}
			set
			{
				this.zz.x = value.x;
				this.xx.y = value.y;
			}
		}

		// Token: 0x17000F53 RID: 3923
		// (get) Token: 0x060051E9 RID: 20969 RVA: 0x00144F74 File Offset: 0x00143174
		// (set) Token: 0x060051EA RID: 20970 RVA: 0x00144FA8 File Offset: 0x001431A8
		public global::UnityEngine.Vector2 zy
		{
			get
			{
				global::UnityEngine.Vector2 result;
				result.x = this.zz.x;
				result.y = this.yy.y;
				return result;
			}
			set
			{
				this.zz.x = value.x;
				this.zz.y = value.y;
			}
		}

		// Token: 0x17000F54 RID: 3924
		// (get) Token: 0x060051EB RID: 20971 RVA: 0x00144FDC File Offset: 0x001431DC
		// (set) Token: 0x060051EC RID: 20972 RVA: 0x00145010 File Offset: 0x00143210
		public global::UnityEngine.Vector2 zw
		{
			get
			{
				global::UnityEngine.Vector2 result;
				result.x = this.zz.x;
				result.y = this.ww.y;
				return result;
			}
			set
			{
				this.zz.x = value.x;
				this.ww.y = value.y;
			}
		}

		// Token: 0x17000F55 RID: 3925
		// (get) Token: 0x060051ED RID: 20973 RVA: 0x00145044 File Offset: 0x00143244
		// (set) Token: 0x060051EE RID: 20974 RVA: 0x00145078 File Offset: 0x00143278
		public global::UnityEngine.Vector2 wx
		{
			get
			{
				global::UnityEngine.Vector2 result;
				result.x = this.ww.x;
				result.y = this.xx.y;
				return result;
			}
			set
			{
				this.ww.x = value.x;
				this.xx.y = value.y;
			}
		}

		// Token: 0x17000F56 RID: 3926
		// (get) Token: 0x060051EF RID: 20975 RVA: 0x001450AC File Offset: 0x001432AC
		// (set) Token: 0x060051F0 RID: 20976 RVA: 0x001450E0 File Offset: 0x001432E0
		public global::UnityEngine.Vector2 wy
		{
			get
			{
				global::UnityEngine.Vector2 result;
				result.x = this.ww.x;
				result.y = this.yy.y;
				return result;
			}
			set
			{
				this.ww.x = value.x;
				this.zz.y = value.y;
			}
		}

		// Token: 0x17000F57 RID: 3927
		// (get) Token: 0x060051F1 RID: 20977 RVA: 0x00145114 File Offset: 0x00143314
		// (set) Token: 0x060051F2 RID: 20978 RVA: 0x00145148 File Offset: 0x00143348
		public global::UnityEngine.Vector2 wz
		{
			get
			{
				global::UnityEngine.Vector2 result;
				result.x = this.ww.x;
				result.y = this.zz.y;
				return result;
			}
			set
			{
				this.ww.x = value.x;
				this.zz.y = value.y;
			}
		}

		// Token: 0x17000F58 RID: 3928
		public global::UnityEngine.Vector2 this[int i]
		{
			get
			{
				switch (i)
				{
				case 0:
					return this.xx;
				case 1:
					return this.yy;
				case 2:
					return this.zz;
				case 3:
					return this.ww;
				default:
					throw new global::System.IndexOutOfRangeException();
				}
			}
		}

		// Token: 0x17000F59 RID: 3929
		public float this[int i, int a]
		{
			get
			{
				switch (i)
				{
				case 0:
					return this.xx[a];
				case 1:
					return this.yy[a];
				case 2:
					return this.zz[a];
				case 3:
					return this.ww[a];
				default:
					throw new global::System.IndexOutOfRangeException();
				}
			}
		}

		// Token: 0x060051F5 RID: 20981 RVA: 0x0014522C File Offset: 0x0014342C
		public static void Calculate(global::UIWidget.Pivot pivot, float pixelSize, global::UnityEngine.Texture tex, ref global::UnityEngine.Vector4 minMaxX, ref global::UnityEngine.Vector4 minMaxY, ref global::UnityEngine.Vector2 scale, out global::NGUI.Structures.NineRectangle nqV, out global::NGUI.Structures.NineRectangle nqT)
		{
			if (tex && pixelSize != 0f)
			{
				float num = (minMaxX.y - minMaxX.x) * pixelSize;
				float num2 = (minMaxX.w - minMaxX.z) * pixelSize;
				float num3 = (minMaxY.z - minMaxY.w) * pixelSize;
				float num4 = (minMaxY.x - minMaxY.y) * pixelSize;
				global::UnityEngine.Vector2 vector;
				global::UnityEngine.Vector2 vector2;
				if (scale.x < 0f)
				{
					scale.x = 0f;
					vector.x = num / 0f;
					vector2.x = num2 / 0f;
				}
				else
				{
					float num5 = (float)(1.0 / ((double)scale.x / (double)tex.width));
					vector.x = num * num5;
					vector2.x = num2 * num5;
				}
				if (scale.y < 0f)
				{
					scale.y = 0f;
					vector.y = num3 / 0f;
					vector2.y = num4 / 0f;
				}
				else
				{
					float num6 = (float)(1.0 / ((double)scale.y / (double)tex.height));
					vector.y = num3 * num6;
					vector2.y = num4 * num6;
				}
				float num7;
				switch (pivot)
				{
				case global::UIWidget.Pivot.TopRight:
				case global::UIWidget.Pivot.Right:
					break;
				default:
					if (pivot != global::UIWidget.Pivot.BottomRight)
					{
						nqV.xx.x = 0f;
						nqV.yy.x = vector.x;
						num7 = 1f - vector2.x;
						nqV.zz.x = ((num7 <= vector.x) ? vector.x : num7);
						num7 = vector.x + vector2.x;
						nqV.ww.x = ((num7 <= 1f) ? 1f : num7);
						goto IL_320;
					}
					break;
				}
				num7 = vector2.x + vector.x;
				if (num7 <= 1f)
				{
					nqV.xx.x = 0f;
					nqV.ww.x = 1f;
					nqV.yy.x = vector.x;
					num7 = 1f - vector2.x;
					nqV.zz.x = ((num7 <= vector.x) ? vector.x : num7);
				}
				else
				{
					nqV.xx.x = 1f - num7;
					nqV.yy.x = nqV.xx.x + vector.x;
					nqV.ww.x = nqV.xx.x + num7;
					num7 = 1f - vector2.x;
					nqV.zz.x = nqV.xx.x + ((num7 <= vector.x) ? vector.x : num7);
				}
				IL_320:
				switch (pivot)
				{
				case global::UIWidget.Pivot.BottomLeft:
				case global::UIWidget.Pivot.Bottom:
				case global::UIWidget.Pivot.BottomRight:
					num7 = -1f - vector2.y + vector.y;
					if (num7 <= 0f)
					{
						nqV.xx.y = 0f;
						nqV.yy.y = vector.y;
						num7 = -1f - vector2.y;
						nqV.zz.y = ((num7 >= vector.y) ? vector.y : num7);
						num7 = vector.y + vector2.y;
						nqV.ww.y = ((num7 >= -1f) ? -1f : num7);
					}
					else
					{
						nqV.xx.y = num7;
						nqV.yy.y = nqV.xx.y + vector.x;
						num7 = -1f - vector2.y;
						nqV.zz.y = nqV.xx.y + ((num7 >= vector.y) ? vector.y : num7);
						num7 = vector.y + vector2.y;
						nqV.ww.y = nqV.xx.y + ((num7 >= -1f) ? -1f : num7);
					}
					break;
				default:
					nqV.xx.y = 0f;
					nqV.yy.y = vector.y;
					num7 = -1f - vector2.y;
					nqV.zz.y = ((num7 >= vector.y) ? vector.y : num7);
					num7 = vector2.y + vector.y;
					nqV.ww.y = ((num7 >= -1f) ? -1f : num7);
					break;
				}
				nqT.xx.x = minMaxX.x;
				nqT.yy.x = minMaxX.y;
				nqT.zz.x = minMaxX.z;
				nqT.ww.x = minMaxX.w;
				nqT.xx.y = minMaxY.w;
				nqT.yy.y = minMaxY.z;
				nqT.zz.y = minMaxY.y;
				nqT.ww.y = minMaxY.x;
			}
			else
			{
				nqV.xx.x = (nqV.yy.x = (nqV.xx.y = (nqV.yy.y = 0f)));
				nqV.zz.x = (nqV.ww.x = 1f);
				nqV.zz.y = (nqV.ww.y = -1f);
				nqT = default(global::NGUI.Structures.NineRectangle);
			}
		}

		// Token: 0x060051F6 RID: 20982 RVA: 0x001458B0 File Offset: 0x00143AB0
		public static void Fill9(ref global::NGUI.Structures.NineRectangle nqV, ref global::NGUI.Structures.NineRectangle nqT, ref global::UnityEngine.Color color, global::NGUI.Meshing.MeshBuffer m)
		{
			if (nqV.xx.x == nqV.yy.x)
			{
				if (nqV.yy.x == nqV.zz.x)
				{
					if (nqV.zz.x != nqT.ww.x)
					{
						global::NGUI.Structures.NineRectangle.FillColumn1(ref nqV, ref nqT, 2, ref color, m);
					}
				}
				else if (nqV.zz.x == nqT.ww.x)
				{
					global::NGUI.Structures.NineRectangle.FillColumn1(ref nqV, ref nqT, 1, ref color, m);
				}
				else
				{
					global::NGUI.Structures.NineRectangle.FillColumn2(ref nqV, ref nqT, 1, ref color, m);
				}
			}
			else if (nqV.yy.x == nqV.zz.x)
			{
				if (nqV.zz.x == nqV.ww.x)
				{
					global::NGUI.Structures.NineRectangle.FillColumn1(ref nqV, ref nqT, 1, ref color, m);
				}
				else
				{
					global::NGUI.Structures.NineRectangle.FillColumn2(ref nqV, ref nqT, 2, ref color, m);
				}
			}
			else if (nqV.zz.x == nqV.ww.x)
			{
				global::NGUI.Structures.NineRectangle.FillColumn2(ref nqV, ref nqT, 0, ref color, m);
			}
			else
			{
				global::NGUI.Structures.NineRectangle.FillColumn3(ref nqV, ref nqT, ref color, m);
			}
		}

		// Token: 0x060051F7 RID: 20983 RVA: 0x001459E0 File Offset: 0x00143BE0
		private static void FillColumn1(ref global::NGUI.Structures.NineRectangle nqV, ref global::NGUI.Structures.NineRectangle nqT, int columnStart, ref global::UnityEngine.Color color, global::NGUI.Meshing.MeshBuffer m)
		{
			if (nqV.xx.y == nqV.yy.y)
			{
				if (nqV.yy.y == nqV.zz.y)
				{
					if (nqV.zz.y != nqV.ww.y)
					{
						switch (columnStart)
						{
						case 0:
							m.FastCell(nqV.xz, nqV.yw, nqT.xz, nqT.yw, ref color);
							break;
						case 1:
							m.FastCell(nqV.yz, nqV.zw, nqT.yz, nqT.zw, ref color);
							break;
						case 2:
							m.FastCell(nqV.zz, nqV.ww, nqT.zz, nqT.ww, ref color);
							break;
						}
					}
				}
				else if (nqV.zz.y == nqV.ww.y)
				{
					switch (columnStart)
					{
					case 0:
						m.FastCell(nqV.xy, nqV.yz, nqT.xy, nqT.yz, ref color);
						break;
					case 1:
						m.FastCell(nqV.yy, nqV.zz, nqT.yy, nqT.zz, ref color);
						break;
					case 2:
						m.FastCell(nqV.zy, nqV.wz, nqT.zy, nqT.wz, ref color);
						break;
					}
				}
				else
				{
					int num = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid1x2, 0f, color);
					switch (columnStart)
					{
					case 0:
						m.v[num].x = nqV.xx.x;
						m.v[num].y = nqV.yy.y;
						m.v[num].u = nqT.xx.x;
						m.v[num].v = nqT.yy.y;
						m.v[num + 1].x = nqV.yy.x;
						m.v[num + 1].y = nqV.yy.y;
						m.v[num + 1].u = nqT.yy.x;
						m.v[num + 1].v = nqT.yy.y;
						m.v[num + 2].x = nqV.xx.x;
						m.v[num + 2].y = nqV.zz.y;
						m.v[num + 2].u = nqT.xx.x;
						m.v[num + 2].v = nqT.zz.y;
						m.v[num + 3].x = nqV.yy.x;
						m.v[num + 3].y = nqV.zz.y;
						m.v[num + 3].u = nqT.yy.x;
						m.v[num + 3].v = nqT.zz.y;
						m.v[num + 4].x = nqV.xx.x;
						m.v[num + 4].y = nqV.ww.y;
						m.v[num + 4].u = nqT.xx.x;
						m.v[num + 4].v = nqT.ww.y;
						m.v[num + 5].x = nqV.yy.x;
						m.v[num + 5].y = nqV.ww.y;
						m.v[num + 5].u = nqT.yy.x;
						m.v[num + 5].v = nqT.ww.y;
						break;
					case 1:
						m.v[num].x = nqV.yy.x;
						m.v[num].y = nqV.yy.y;
						m.v[num].u = nqT.yy.x;
						m.v[num].v = nqT.yy.y;
						m.v[num + 1].x = nqV.zz.x;
						m.v[num + 1].y = nqV.yy.y;
						m.v[num + 1].u = nqT.zz.x;
						m.v[num + 1].v = nqT.yy.y;
						m.v[num + 2].x = nqV.yy.x;
						m.v[num + 2].y = nqV.zz.y;
						m.v[num + 2].u = nqT.yy.x;
						m.v[num + 2].v = nqT.zz.y;
						m.v[num + 3].x = nqV.zz.x;
						m.v[num + 3].y = nqV.zz.y;
						m.v[num + 3].u = nqT.zz.x;
						m.v[num + 3].v = nqT.zz.y;
						m.v[num + 4].x = nqV.yy.x;
						m.v[num + 4].y = nqV.ww.y;
						m.v[num + 4].u = nqT.yy.x;
						m.v[num + 4].v = nqT.ww.y;
						m.v[num + 5].x = nqV.zz.x;
						m.v[num + 5].y = nqV.ww.y;
						m.v[num + 5].u = nqT.zz.x;
						m.v[num + 5].v = nqT.ww.y;
						break;
					case 2:
						m.v[num].x = nqV.zz.x;
						m.v[num].y = nqV.yy.y;
						m.v[num].u = nqT.zz.x;
						m.v[num].v = nqT.yy.y;
						m.v[num + 1].x = nqV.ww.x;
						m.v[num + 1].y = nqV.yy.y;
						m.v[num + 1].u = nqT.ww.x;
						m.v[num + 1].v = nqT.yy.y;
						m.v[num + 2].x = nqV.zz.x;
						m.v[num + 2].y = nqV.zz.y;
						m.v[num + 2].u = nqT.zz.x;
						m.v[num + 2].v = nqT.zz.y;
						m.v[num + 3].x = nqV.ww.x;
						m.v[num + 3].y = nqV.zz.y;
						m.v[num + 3].u = nqT.ww.x;
						m.v[num + 3].v = nqT.zz.y;
						m.v[num + 4].x = nqV.zz.x;
						m.v[num + 4].y = nqV.ww.y;
						m.v[num + 4].u = nqT.zz.x;
						m.v[num + 4].v = nqT.ww.y;
						m.v[num + 5].x = nqV.ww.x;
						m.v[num + 5].y = nqV.ww.y;
						m.v[num + 5].u = nqT.ww.x;
						m.v[num + 5].v = nqT.ww.y;
						break;
					}
				}
			}
			else if (nqV.yy.y == nqV.zz.y)
			{
				if (nqV.zz.y == nqV.ww.y)
				{
					switch (columnStart)
					{
					case 0:
						m.FastCell(nqV.xx, nqV.yy, nqT.xx, nqT.yy, ref color);
						break;
					case 1:
						m.FastCell(nqV.yx, nqV.zy, nqT.yx, nqT.zy, ref color);
						break;
					case 2:
						m.FastCell(nqV.zx, nqV.wy, nqT.zx, nqT.wy, ref color);
						break;
					}
				}
				else
				{
					switch (columnStart)
					{
					case 0:
						m.FastCell(nqV.xx, nqV.yy, nqT.xx, nqT.yy, ref color);
						m.FastCell(nqV.xz, nqV.yw, nqT.xz, nqT.yw, ref color);
						break;
					case 1:
						m.FastCell(nqV.yx, nqV.zy, nqT.yx, nqT.zy, ref color);
						m.FastCell(nqV.yz, nqV.zw, nqT.yz, nqT.zw, ref color);
						break;
					case 2:
						m.FastCell(nqV.zx, nqV.wy, nqT.zx, nqT.wy, ref color);
						m.FastCell(nqV.zz, nqV.ww, nqT.zz, nqT.ww, ref color);
						break;
					}
				}
			}
			else if (nqV.zz.y == nqV.ww.y)
			{
				int num2 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid1x2, 0f, color);
				switch (columnStart)
				{
				case 0:
					m.v[num2].x = nqV.xx.x;
					m.v[num2].y = nqV.xx.y;
					m.v[num2].u = nqT.xx.x;
					m.v[num2].v = nqT.xx.y;
					m.v[num2 + 1].x = nqV.yy.x;
					m.v[num2 + 1].y = nqV.xx.y;
					m.v[num2 + 1].u = nqT.yy.x;
					m.v[num2 + 1].v = nqT.xx.y;
					m.v[num2 + 2].x = nqV.xx.x;
					m.v[num2 + 2].y = nqV.yy.y;
					m.v[num2 + 2].u = nqT.xx.x;
					m.v[num2 + 2].v = nqT.yy.y;
					m.v[num2 + 3].x = nqV.yy.x;
					m.v[num2 + 3].y = nqV.yy.y;
					m.v[num2 + 3].u = nqT.yy.x;
					m.v[num2 + 3].v = nqT.yy.y;
					m.v[num2 + 4].x = nqV.xx.x;
					m.v[num2 + 4].y = nqV.zz.y;
					m.v[num2 + 4].u = nqT.xx.x;
					m.v[num2 + 4].v = nqT.zz.y;
					m.v[num2 + 5].x = nqV.yy.x;
					m.v[num2 + 5].y = nqV.zz.y;
					m.v[num2 + 5].u = nqT.yy.x;
					m.v[num2 + 5].v = nqT.zz.y;
					break;
				case 1:
					m.v[num2].x = nqV.yy.x;
					m.v[num2].y = nqV.xx.y;
					m.v[num2].u = nqT.yy.x;
					m.v[num2].v = nqT.xx.y;
					m.v[num2 + 1].x = nqV.zz.x;
					m.v[num2 + 1].y = nqV.xx.y;
					m.v[num2 + 1].u = nqT.zz.x;
					m.v[num2 + 1].v = nqT.xx.y;
					m.v[num2 + 2].x = nqV.yy.x;
					m.v[num2 + 2].y = nqV.yy.y;
					m.v[num2 + 2].u = nqT.yy.x;
					m.v[num2 + 2].v = nqT.yy.y;
					m.v[num2 + 3].x = nqV.zz.x;
					m.v[num2 + 3].y = nqV.yy.y;
					m.v[num2 + 3].u = nqT.zz.x;
					m.v[num2 + 3].v = nqT.yy.y;
					m.v[num2 + 4].x = nqV.yy.x;
					m.v[num2 + 4].y = nqV.zz.y;
					m.v[num2 + 4].u = nqT.yy.x;
					m.v[num2 + 4].v = nqT.zz.y;
					m.v[num2 + 5].x = nqV.zz.x;
					m.v[num2 + 5].y = nqV.zz.y;
					m.v[num2 + 5].u = nqT.zz.x;
					m.v[num2 + 5].v = nqT.zz.y;
					break;
				case 2:
					m.v[num2].x = nqV.zz.x;
					m.v[num2].y = nqV.xx.y;
					m.v[num2].u = nqT.zz.x;
					m.v[num2].v = nqT.xx.y;
					m.v[num2 + 1].x = nqV.ww.x;
					m.v[num2 + 1].y = nqV.xx.y;
					m.v[num2 + 1].u = nqT.ww.x;
					m.v[num2 + 1].v = nqT.xx.y;
					m.v[num2 + 2].x = nqV.zz.x;
					m.v[num2 + 2].y = nqV.yy.y;
					m.v[num2 + 2].u = nqT.zz.x;
					m.v[num2 + 2].v = nqT.yy.y;
					m.v[num2 + 3].x = nqV.ww.x;
					m.v[num2 + 3].y = nqV.yy.y;
					m.v[num2 + 3].u = nqT.ww.x;
					m.v[num2 + 3].v = nqT.yy.y;
					m.v[num2 + 4].x = nqV.zz.x;
					m.v[num2 + 4].y = nqV.zz.y;
					m.v[num2 + 4].u = nqT.zz.x;
					m.v[num2 + 4].v = nqT.zz.y;
					m.v[num2 + 5].x = nqV.ww.x;
					m.v[num2 + 5].y = nqV.zz.y;
					m.v[num2 + 5].u = nqT.ww.x;
					m.v[num2 + 5].v = nqT.zz.y;
					break;
				}
			}
			else
			{
				int num3 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid1x2, 0f, color);
				switch (columnStart)
				{
				case 0:
					m.v[num3].x = nqV.xx.x;
					m.v[num3].y = nqV.xx.y;
					m.v[num3].u = nqT.xx.x;
					m.v[num3].v = nqT.xx.y;
					m.v[num3 + 1].x = nqV.yy.x;
					m.v[num3 + 1].y = nqV.xx.y;
					m.v[num3 + 1].u = nqT.yy.x;
					m.v[num3 + 1].v = nqT.xx.y;
					m.v[num3 + 2].x = nqV.xx.x;
					m.v[num3 + 2].y = nqV.yy.y;
					m.v[num3 + 2].u = nqT.xx.x;
					m.v[num3 + 2].v = nqT.yy.y;
					m.v[num3 + 3].x = nqV.yy.x;
					m.v[num3 + 3].y = nqV.yy.y;
					m.v[num3 + 3].u = nqT.yy.x;
					m.v[num3 + 3].v = nqT.yy.y;
					m.v[num3 + 4].x = nqV.xx.x;
					m.v[num3 + 4].y = nqV.zz.y;
					m.v[num3 + 4].u = nqT.xx.x;
					m.v[num3 + 4].v = nqT.zz.y;
					m.v[num3 + 5].x = nqV.yy.x;
					m.v[num3 + 5].y = nqV.zz.y;
					m.v[num3 + 5].u = nqT.yy.x;
					m.v[num3 + 5].v = nqT.zz.y;
					m.v[num3 + 6].x = nqV.xx.x;
					m.v[num3 + 6].y = nqV.ww.y;
					m.v[num3 + 6].u = nqT.xx.x;
					m.v[num3 + 6].v = nqT.ww.y;
					m.v[num3 + 7].x = nqV.yy.x;
					m.v[num3 + 7].y = nqV.ww.y;
					m.v[num3 + 7].u = nqT.yy.x;
					m.v[num3 + 7].v = nqT.ww.y;
					break;
				case 1:
					m.v[num3].x = nqV.yy.x;
					m.v[num3].y = nqV.xx.y;
					m.v[num3].u = nqT.yy.x;
					m.v[num3].v = nqT.xx.y;
					m.v[num3 + 1].x = nqV.zz.x;
					m.v[num3 + 1].y = nqV.xx.y;
					m.v[num3 + 1].u = nqT.zz.x;
					m.v[num3 + 1].v = nqT.xx.y;
					m.v[num3 + 2].x = nqV.yy.x;
					m.v[num3 + 2].y = nqV.yy.y;
					m.v[num3 + 2].u = nqT.yy.x;
					m.v[num3 + 2].v = nqT.yy.y;
					m.v[num3 + 3].x = nqV.zz.x;
					m.v[num3 + 3].y = nqV.yy.y;
					m.v[num3 + 3].u = nqT.zz.x;
					m.v[num3 + 3].v = nqT.yy.y;
					m.v[num3 + 4].x = nqV.yy.x;
					m.v[num3 + 4].y = nqV.zz.y;
					m.v[num3 + 4].u = nqT.yy.x;
					m.v[num3 + 4].v = nqT.zz.y;
					m.v[num3 + 5].x = nqV.zz.x;
					m.v[num3 + 5].y = nqV.zz.y;
					m.v[num3 + 5].u = nqT.zz.x;
					m.v[num3 + 5].v = nqT.zz.y;
					m.v[num3 + 6].x = nqV.yy.x;
					m.v[num3 + 6].y = nqV.ww.y;
					m.v[num3 + 6].u = nqT.yy.x;
					m.v[num3 + 6].v = nqT.ww.y;
					m.v[num3 + 7].x = nqV.zz.x;
					m.v[num3 + 7].y = nqV.ww.y;
					m.v[num3 + 7].u = nqT.zz.x;
					m.v[num3 + 7].v = nqT.ww.y;
					break;
				case 2:
					m.v[num3].x = nqV.zz.x;
					m.v[num3].y = nqV.xx.y;
					m.v[num3].u = nqT.zz.x;
					m.v[num3].v = nqT.xx.y;
					m.v[num3 + 1].x = nqV.ww.x;
					m.v[num3 + 1].y = nqV.xx.y;
					m.v[num3 + 1].u = nqT.ww.x;
					m.v[num3 + 1].v = nqT.xx.y;
					m.v[num3 + 2].x = nqV.zz.x;
					m.v[num3 + 2].y = nqV.yy.y;
					m.v[num3 + 2].u = nqT.zz.x;
					m.v[num3 + 2].v = nqT.yy.y;
					m.v[num3 + 3].x = nqV.ww.x;
					m.v[num3 + 3].y = nqV.yy.y;
					m.v[num3 + 3].u = nqT.ww.x;
					m.v[num3 + 3].v = nqT.yy.y;
					m.v[num3 + 4].x = nqV.zz.x;
					m.v[num3 + 4].y = nqV.zz.y;
					m.v[num3 + 4].u = nqT.zz.x;
					m.v[num3 + 4].v = nqT.zz.y;
					m.v[num3 + 5].x = nqV.ww.x;
					m.v[num3 + 5].y = nqV.zz.y;
					m.v[num3 + 5].u = nqT.ww.x;
					m.v[num3 + 5].v = nqT.zz.y;
					m.v[num3 + 6].x = nqV.zz.x;
					m.v[num3 + 6].y = nqV.ww.y;
					m.v[num3 + 6].u = nqT.zz.x;
					m.v[num3 + 6].v = nqT.ww.y;
					m.v[num3 + 7].x = nqV.ww.x;
					m.v[num3 + 7].y = nqV.ww.y;
					m.v[num3 + 7].u = nqT.ww.x;
					m.v[num3 + 7].v = nqT.ww.y;
					break;
				}
			}
		}

		// Token: 0x060051F8 RID: 20984 RVA: 0x00147AC4 File Offset: 0x00145CC4
		private static void FillColumn2(ref global::NGUI.Structures.NineRectangle nqV, ref global::NGUI.Structures.NineRectangle nqT, int columnStart, ref global::UnityEngine.Color color, global::NGUI.Meshing.MeshBuffer m)
		{
			if (nqV.xx.y == nqV.yy.y)
			{
				if (nqV.yy.y == nqV.zz.y)
				{
					if (nqV.zz.y != nqV.ww.y)
					{
						switch (columnStart)
						{
						case 0:
						{
							int num = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid2x1, 0f, color);
							m.v[num].x = nqV.xx.x;
							m.v[num].y = nqV.zz.y;
							m.v[num].u = nqT.xx.x;
							m.v[num].v = nqT.zz.y;
							m.v[num + 1].x = nqV.yy.x;
							m.v[num + 1].y = nqV.zz.y;
							m.v[num + 1].u = nqT.yy.x;
							m.v[num + 1].v = nqT.zz.y;
							m.v[num + 2].x = nqV.zz.x;
							m.v[num + 2].y = nqV.zz.y;
							m.v[num + 2].u = nqT.zz.x;
							m.v[num + 2].v = nqT.zz.y;
							m.v[num + 3].x = nqV.xx.x;
							m.v[num + 3].y = nqV.ww.y;
							m.v[num + 3].u = nqT.xx.x;
							m.v[num + 3].v = nqT.ww.y;
							m.v[num + 4].x = nqV.yy.x;
							m.v[num + 4].y = nqV.ww.y;
							m.v[num + 4].u = nqT.yy.x;
							m.v[num + 4].v = nqT.ww.y;
							m.v[num + 5].x = nqV.zz.x;
							m.v[num + 5].y = nqV.ww.y;
							m.v[num + 5].u = nqT.zz.x;
							m.v[num + 5].v = nqT.ww.y;
							break;
						}
						case 1:
						{
							int num = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid2x1, 0f, color);
							m.v[num].x = nqV.yy.x;
							m.v[num].y = nqV.zz.y;
							m.v[num].u = nqT.yy.x;
							m.v[num].v = nqT.zz.y;
							m.v[num + 1].x = nqV.zz.x;
							m.v[num + 1].y = nqV.zz.y;
							m.v[num + 1].u = nqT.zz.x;
							m.v[num + 1].v = nqT.zz.y;
							m.v[num + 2].x = nqV.ww.x;
							m.v[num + 2].y = nqV.zz.y;
							m.v[num + 2].u = nqT.ww.x;
							m.v[num + 2].v = nqT.zz.y;
							m.v[num + 3].x = nqV.yy.x;
							m.v[num + 3].y = nqV.ww.y;
							m.v[num + 3].u = nqT.yy.x;
							m.v[num + 3].v = nqT.ww.y;
							m.v[num + 4].x = nqV.zz.x;
							m.v[num + 4].y = nqV.ww.y;
							m.v[num + 4].u = nqT.zz.x;
							m.v[num + 4].v = nqT.ww.y;
							m.v[num + 5].x = nqV.ww.x;
							m.v[num + 5].y = nqV.ww.y;
							m.v[num + 5].u = nqT.ww.x;
							m.v[num + 5].v = nqT.ww.y;
							break;
						}
						case 2:
							m.FastCell(nqV.xz, nqV.yw, nqT.xz, nqT.yw, ref color);
							m.FastCell(nqV.zz, nqV.ww, nqT.zz, nqT.ww, ref color);
							break;
						}
					}
				}
				else if (nqV.zz.y == nqV.ww.y)
				{
					switch (columnStart)
					{
					case 0:
					{
						int num2 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid2x1, 0f, color);
						m.v[num2].x = nqV.xx.x;
						m.v[num2].y = nqV.yy.y;
						m.v[num2].u = nqT.xx.x;
						m.v[num2].v = nqT.yy.y;
						m.v[num2 + 1].x = nqV.yy.x;
						m.v[num2 + 1].y = nqV.yy.y;
						m.v[num2 + 1].u = nqT.yy.x;
						m.v[num2 + 1].v = nqT.yy.y;
						m.v[num2 + 2].x = nqV.zz.x;
						m.v[num2 + 2].y = nqV.yy.y;
						m.v[num2 + 2].u = nqT.zz.x;
						m.v[num2 + 2].v = nqT.yy.y;
						m.v[num2 + 3].x = nqV.xx.x;
						m.v[num2 + 3].y = nqV.zz.y;
						m.v[num2 + 3].u = nqT.xx.x;
						m.v[num2 + 3].v = nqT.zz.y;
						m.v[num2 + 4].x = nqV.yy.x;
						m.v[num2 + 4].y = nqV.zz.y;
						m.v[num2 + 4].u = nqT.yy.x;
						m.v[num2 + 4].v = nqT.zz.y;
						m.v[num2 + 5].x = nqV.zz.x;
						m.v[num2 + 5].y = nqV.zz.y;
						m.v[num2 + 5].u = nqT.zz.x;
						m.v[num2 + 5].v = nqT.zz.y;
						break;
					}
					case 1:
					{
						int num2 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid2x1, 0f, color);
						m.v[num2].x = nqV.yy.x;
						m.v[num2].y = nqV.yy.y;
						m.v[num2].u = nqT.yy.x;
						m.v[num2].v = nqT.yy.y;
						m.v[num2 + 1].x = nqV.zz.x;
						m.v[num2 + 1].y = nqV.yy.y;
						m.v[num2 + 1].u = nqT.zz.x;
						m.v[num2 + 1].v = nqT.yy.y;
						m.v[num2 + 2].x = nqV.ww.x;
						m.v[num2 + 2].y = nqV.yy.y;
						m.v[num2 + 2].u = nqT.ww.x;
						m.v[num2 + 2].v = nqT.yy.y;
						m.v[num2 + 3].x = nqV.yy.x;
						m.v[num2 + 3].y = nqV.zz.y;
						m.v[num2 + 3].u = nqT.yy.x;
						m.v[num2 + 3].v = nqT.zz.y;
						m.v[num2 + 4].x = nqV.zz.x;
						m.v[num2 + 4].y = nqV.zz.y;
						m.v[num2 + 4].u = nqT.zz.x;
						m.v[num2 + 4].v = nqT.zz.y;
						m.v[num2 + 5].x = nqV.ww.x;
						m.v[num2 + 5].y = nqV.zz.y;
						m.v[num2 + 5].u = nqT.ww.x;
						m.v[num2 + 5].v = nqT.zz.y;
						break;
					}
					case 2:
						m.FastCell(nqV.xy, nqV.yz, nqT.xy, nqT.yz, ref color);
						m.FastCell(nqV.zy, nqV.wz, nqT.zy, nqT.wz, ref color);
						break;
					}
				}
				else
				{
					switch (columnStart)
					{
					case 0:
					{
						int num3 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid2x2, 0f, color);
						m.v[num3].x = nqV.xx.x;
						m.v[num3].y = nqV.yy.y;
						m.v[num3].u = nqT.xx.x;
						m.v[num3].v = nqT.yy.y;
						m.v[num3 + 1].x = nqV.yy.x;
						m.v[num3 + 1].y = nqV.yy.y;
						m.v[num3 + 1].u = nqT.yy.x;
						m.v[num3 + 1].v = nqT.yy.y;
						m.v[num3 + 2].x = nqV.zz.x;
						m.v[num3 + 2].y = nqV.yy.y;
						m.v[num3 + 2].u = nqT.zz.x;
						m.v[num3 + 2].v = nqT.yy.y;
						m.v[num3 + 3].x = nqV.xx.x;
						m.v[num3 + 3].y = nqV.zz.y;
						m.v[num3 + 3].u = nqT.xx.x;
						m.v[num3 + 3].v = nqT.zz.y;
						m.v[num3 + 4].x = nqV.yy.x;
						m.v[num3 + 4].y = nqV.zz.y;
						m.v[num3 + 4].u = nqT.yy.x;
						m.v[num3 + 4].v = nqT.zz.y;
						m.v[num3 + 5].x = nqV.zz.x;
						m.v[num3 + 5].y = nqV.zz.y;
						m.v[num3 + 5].u = nqT.zz.x;
						m.v[num3 + 5].v = nqT.zz.y;
						m.v[num3 + 6].x = nqV.xx.x;
						m.v[num3 + 6].y = nqV.ww.y;
						m.v[num3 + 6].u = nqT.xx.x;
						m.v[num3 + 6].v = nqT.ww.y;
						m.v[num3 + 7].x = nqV.yy.x;
						m.v[num3 + 7].y = nqV.ww.y;
						m.v[num3 + 7].u = nqT.yy.x;
						m.v[num3 + 7].v = nqT.ww.y;
						m.v[num3 + 8].x = nqV.zz.x;
						m.v[num3 + 8].y = nqV.ww.y;
						m.v[num3 + 8].u = nqT.zz.x;
						m.v[num3 + 8].v = nqT.ww.y;
						break;
					}
					case 1:
					{
						int num3 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid2x2, 0f, color);
						m.v[num3].x = nqV.yy.x;
						m.v[num3].y = nqV.yy.y;
						m.v[num3].u = nqT.yy.x;
						m.v[num3].v = nqT.yy.y;
						m.v[num3 + 1].x = nqV.zz.x;
						m.v[num3 + 1].y = nqV.yy.y;
						m.v[num3 + 1].u = nqT.zz.x;
						m.v[num3 + 1].v = nqT.yy.y;
						m.v[num3 + 2].x = nqV.ww.x;
						m.v[num3 + 2].y = nqV.yy.y;
						m.v[num3 + 2].u = nqT.ww.x;
						m.v[num3 + 2].v = nqT.yy.y;
						m.v[num3 + 3].x = nqV.yy.x;
						m.v[num3 + 3].y = nqV.zz.y;
						m.v[num3 + 3].u = nqT.yy.x;
						m.v[num3 + 3].v = nqT.zz.y;
						m.v[num3 + 4].x = nqV.zz.x;
						m.v[num3 + 4].y = nqV.zz.y;
						m.v[num3 + 4].u = nqT.zz.x;
						m.v[num3 + 4].v = nqT.zz.y;
						m.v[num3 + 5].x = nqV.ww.x;
						m.v[num3 + 5].y = nqV.zz.y;
						m.v[num3 + 5].u = nqT.ww.x;
						m.v[num3 + 5].v = nqT.zz.y;
						m.v[num3 + 6].x = nqV.yy.x;
						m.v[num3 + 6].y = nqV.ww.y;
						m.v[num3 + 6].u = nqT.yy.x;
						m.v[num3 + 6].v = nqT.ww.y;
						m.v[num3 + 7].x = nqV.zz.x;
						m.v[num3 + 7].y = nqV.ww.y;
						m.v[num3 + 7].u = nqT.zz.x;
						m.v[num3 + 7].v = nqT.ww.y;
						m.v[num3 + 8].x = nqV.ww.x;
						m.v[num3 + 8].y = nqV.ww.y;
						m.v[num3 + 8].u = nqT.ww.x;
						m.v[num3 + 8].v = nqT.ww.y;
						break;
					}
					case 2:
					{
						int num3 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid2x1, 0f, color);
						m.v[num3].x = nqV.xx.x;
						m.v[num3].y = nqV.yy.y;
						m.v[num3].u = nqT.xx.x;
						m.v[num3].v = nqT.yy.y;
						m.v[num3 + 1].x = nqV.yy.x;
						m.v[num3 + 1].y = nqV.yy.y;
						m.v[num3 + 1].u = nqT.yy.x;
						m.v[num3 + 1].v = nqT.yy.y;
						m.v[num3 + 2].x = nqV.xx.x;
						m.v[num3 + 2].y = nqV.zz.y;
						m.v[num3 + 2].u = nqT.xx.x;
						m.v[num3 + 2].v = nqT.zz.y;
						m.v[num3 + 3].x = nqV.yy.x;
						m.v[num3 + 3].y = nqV.zz.y;
						m.v[num3 + 3].u = nqT.yy.x;
						m.v[num3 + 3].v = nqT.zz.y;
						m.v[num3 + 4].x = nqV.yy.x;
						m.v[num3 + 4].y = nqV.ww.y;
						m.v[num3 + 4].u = nqT.yy.x;
						m.v[num3 + 4].v = nqT.ww.y;
						m.v[num3 + 5].x = nqV.zz.x;
						m.v[num3 + 5].y = nqV.ww.y;
						m.v[num3 + 5].u = nqT.zz.x;
						m.v[num3 + 5].v = nqT.ww.y;
						num3 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid2x1, 0f, color);
						m.v[num3].x = nqV.zz.x;
						m.v[num3].y = nqV.yy.y;
						m.v[num3].u = nqT.zz.x;
						m.v[num3].v = nqT.yy.y;
						m.v[num3 + 1].x = nqV.ww.x;
						m.v[num3 + 1].y = nqV.yy.y;
						m.v[num3 + 1].u = nqT.ww.x;
						m.v[num3 + 1].v = nqT.yy.y;
						m.v[num3 + 2].x = nqV.zz.x;
						m.v[num3 + 2].y = nqV.zz.y;
						m.v[num3 + 2].u = nqT.zz.x;
						m.v[num3 + 2].v = nqT.zz.y;
						m.v[num3 + 3].x = nqV.ww.x;
						m.v[num3 + 3].y = nqV.zz.y;
						m.v[num3 + 3].u = nqT.ww.x;
						m.v[num3 + 3].v = nqT.zz.y;
						m.v[num3 + 4].x = nqV.zz.x;
						m.v[num3 + 4].y = nqV.ww.y;
						m.v[num3 + 4].u = nqT.zz.x;
						m.v[num3 + 4].v = nqT.ww.y;
						m.v[num3 + 5].x = nqV.ww.x;
						m.v[num3 + 5].y = nqV.ww.y;
						m.v[num3 + 5].u = nqT.ww.x;
						m.v[num3 + 5].v = nqT.ww.y;
						break;
					}
					}
				}
			}
			else if (nqV.yy.y == nqV.zz.y)
			{
				if (nqV.zz.y == nqV.ww.y)
				{
					switch (columnStart)
					{
					case 0:
					{
						int num4 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid2x1, 0f, color);
						m.v[num4].x = nqV.xx.x;
						m.v[num4].y = nqV.xx.y;
						m.v[num4].u = nqT.xx.x;
						m.v[num4].v = nqT.xx.y;
						m.v[num4 + 1].x = nqV.yy.x;
						m.v[num4 + 1].y = nqV.xx.y;
						m.v[num4 + 1].u = nqT.yy.x;
						m.v[num4 + 1].v = nqT.xx.y;
						m.v[num4 + 2].x = nqV.zz.x;
						m.v[num4 + 2].y = nqV.xx.y;
						m.v[num4 + 2].u = nqT.zz.x;
						m.v[num4 + 2].v = nqT.xx.y;
						m.v[num4 + 3].x = nqV.xx.x;
						m.v[num4 + 3].y = nqV.yy.y;
						m.v[num4 + 3].u = nqT.xx.x;
						m.v[num4 + 3].v = nqT.yy.y;
						m.v[num4 + 4].x = nqV.yy.x;
						m.v[num4 + 4].y = nqV.yy.y;
						m.v[num4 + 4].u = nqT.yy.x;
						m.v[num4 + 4].v = nqT.yy.y;
						m.v[num4 + 5].x = nqV.zz.x;
						m.v[num4 + 5].y = nqV.yy.y;
						m.v[num4 + 5].u = nqT.zz.x;
						m.v[num4 + 5].v = nqT.yy.y;
						break;
					}
					case 1:
					{
						int num4 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid2x1, 0f, color);
						m.v[num4].x = nqV.yy.x;
						m.v[num4].y = nqV.xx.y;
						m.v[num4].u = nqT.yy.x;
						m.v[num4].v = nqT.xx.y;
						m.v[num4 + 1].x = nqV.zz.x;
						m.v[num4 + 1].y = nqV.xx.y;
						m.v[num4 + 1].u = nqT.zz.x;
						m.v[num4 + 1].v = nqT.xx.y;
						m.v[num4 + 2].x = nqV.ww.x;
						m.v[num4 + 2].y = nqV.xx.y;
						m.v[num4 + 2].u = nqT.ww.x;
						m.v[num4 + 2].v = nqT.xx.y;
						m.v[num4 + 3].x = nqV.yy.x;
						m.v[num4 + 3].y = nqV.yy.y;
						m.v[num4 + 3].u = nqT.yy.x;
						m.v[num4 + 3].v = nqT.yy.y;
						m.v[num4 + 4].x = nqV.zz.x;
						m.v[num4 + 4].y = nqV.yy.y;
						m.v[num4 + 4].u = nqT.zz.x;
						m.v[num4 + 4].v = nqT.yy.y;
						m.v[num4 + 5].x = nqV.ww.x;
						m.v[num4 + 5].y = nqV.yy.y;
						m.v[num4 + 5].u = nqT.ww.x;
						m.v[num4 + 5].v = nqT.yy.y;
						break;
					}
					case 2:
						m.FastCell(nqV.xx, nqV.yy, nqT.xx, nqT.yy, ref color);
						m.FastCell(nqV.zx, nqV.wy, nqT.zx, nqT.wy, ref color);
						break;
					}
				}
				else
				{
					switch (columnStart)
					{
					case 0:
					{
						int num5 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid2x1, 0f, color);
						m.v[num5].x = nqV.xx.x;
						m.v[num5].y = nqV.xx.y;
						m.v[num5].u = nqT.xx.x;
						m.v[num5].v = nqT.xx.y;
						m.v[num5 + 1].x = nqV.yy.x;
						m.v[num5 + 1].y = nqV.xx.y;
						m.v[num5 + 1].u = nqT.yy.x;
						m.v[num5 + 1].v = nqT.xx.y;
						m.v[num5 + 2].x = nqV.zz.x;
						m.v[num5 + 2].y = nqV.xx.y;
						m.v[num5 + 2].u = nqT.zz.x;
						m.v[num5 + 2].v = nqT.xx.y;
						m.v[num5 + 3].x = nqV.xx.x;
						m.v[num5 + 3].y = nqV.yy.y;
						m.v[num5 + 3].u = nqT.xx.x;
						m.v[num5 + 3].v = nqT.yy.y;
						m.v[num5 + 4].x = nqV.yy.x;
						m.v[num5 + 4].y = nqV.yy.y;
						m.v[num5 + 4].u = nqT.yy.x;
						m.v[num5 + 4].v = nqT.yy.y;
						m.v[num5 + 5].x = nqV.zz.x;
						m.v[num5 + 5].y = nqV.yy.y;
						m.v[num5 + 5].u = nqT.zz.x;
						m.v[num5 + 5].v = nqT.yy.y;
						num5 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid2x1, 0f, color);
						m.v[num5].x = nqV.xx.x;
						m.v[num5].y = nqV.zz.y;
						m.v[num5].u = nqT.xx.x;
						m.v[num5].v = nqT.zz.y;
						m.v[num5 + 1].x = nqV.yy.x;
						m.v[num5 + 1].y = nqV.zz.y;
						m.v[num5 + 1].u = nqT.yy.x;
						m.v[num5 + 1].v = nqT.zz.y;
						m.v[num5 + 2].x = nqV.zz.x;
						m.v[num5 + 2].y = nqV.zz.y;
						m.v[num5 + 2].u = nqT.zz.x;
						m.v[num5 + 2].v = nqT.zz.y;
						m.v[num5 + 3].x = nqV.xx.x;
						m.v[num5 + 3].y = nqV.ww.y;
						m.v[num5 + 3].u = nqT.xx.x;
						m.v[num5 + 3].v = nqT.ww.y;
						m.v[num5 + 4].x = nqV.yy.x;
						m.v[num5 + 4].y = nqV.ww.y;
						m.v[num5 + 4].u = nqT.yy.x;
						m.v[num5 + 4].v = nqT.ww.y;
						m.v[num5 + 5].x = nqV.zz.x;
						m.v[num5 + 5].y = nqV.ww.y;
						m.v[num5 + 5].u = nqT.zz.x;
						m.v[num5 + 5].v = nqT.ww.y;
						break;
					}
					case 1:
					{
						int num5 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid2x1, 0f, color);
						m.v[num5].x = nqV.yy.x;
						m.v[num5].y = nqV.xx.y;
						m.v[num5].u = nqT.yy.x;
						m.v[num5].v = nqT.xx.y;
						m.v[num5 + 1].x = nqV.zz.x;
						m.v[num5 + 1].y = nqV.xx.y;
						m.v[num5 + 1].u = nqT.zz.x;
						m.v[num5 + 1].v = nqT.xx.y;
						m.v[num5 + 2].x = nqV.ww.x;
						m.v[num5 + 2].y = nqV.xx.y;
						m.v[num5 + 2].u = nqT.ww.x;
						m.v[num5 + 2].v = nqT.xx.y;
						m.v[num5 + 3].x = nqV.yy.x;
						m.v[num5 + 3].y = nqV.yy.y;
						m.v[num5 + 3].u = nqT.yy.x;
						m.v[num5 + 3].v = nqT.yy.y;
						m.v[num5 + 4].x = nqV.zz.x;
						m.v[num5 + 4].y = nqV.yy.y;
						m.v[num5 + 4].u = nqT.zz.x;
						m.v[num5 + 4].v = nqT.yy.y;
						m.v[num5 + 5].x = nqV.ww.x;
						m.v[num5 + 5].y = nqV.yy.y;
						m.v[num5 + 5].u = nqT.ww.x;
						m.v[num5 + 5].v = nqT.yy.y;
						num5 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid2x1, 0f, color);
						m.v[num5].x = nqV.yy.x;
						m.v[num5].y = nqV.zz.y;
						m.v[num5].u = nqT.yy.x;
						m.v[num5].v = nqT.zz.y;
						m.v[num5 + 1].x = nqV.zz.x;
						m.v[num5 + 1].y = nqV.zz.y;
						m.v[num5 + 1].u = nqT.zz.x;
						m.v[num5 + 1].v = nqT.zz.y;
						m.v[num5 + 2].x = nqV.ww.x;
						m.v[num5 + 2].y = nqV.zz.y;
						m.v[num5 + 2].u = nqT.ww.x;
						m.v[num5 + 2].v = nqT.zz.y;
						m.v[num5 + 3].x = nqV.yy.x;
						m.v[num5 + 3].y = nqV.ww.y;
						m.v[num5 + 3].u = nqT.yy.x;
						m.v[num5 + 3].v = nqT.ww.y;
						m.v[num5 + 4].x = nqV.zz.x;
						m.v[num5 + 4].y = nqV.ww.y;
						m.v[num5 + 4].u = nqT.zz.x;
						m.v[num5 + 4].v = nqT.ww.y;
						m.v[num5 + 5].x = nqV.ww.x;
						m.v[num5 + 5].y = nqV.ww.y;
						m.v[num5 + 5].u = nqT.ww.x;
						m.v[num5 + 5].v = nqT.ww.y;
						break;
					}
					case 2:
						m.FastCell(nqV.xx, nqV.yy, nqT.xx, nqT.yy, ref color);
						m.FastCell(nqV.zx, nqV.wy, nqT.zx, nqT.wy, ref color);
						m.FastCell(nqV.xz, nqV.yw, nqT.xz, nqT.yw, ref color);
						m.FastCell(nqV.zz, nqV.ww, nqT.zz, nqT.ww, ref color);
						break;
					}
				}
			}
			else if (nqV.zz.y == nqV.ww.y)
			{
				switch (columnStart)
				{
				case 0:
				{
					int num6 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid2x2, 0f, color);
					m.v[num6].x = nqV.xx.x;
					m.v[num6].y = nqV.xx.y;
					m.v[num6].u = nqT.xx.x;
					m.v[num6].v = nqT.xx.y;
					m.v[num6 + 1].x = nqV.yy.x;
					m.v[num6 + 1].y = nqV.xx.y;
					m.v[num6 + 1].u = nqT.yy.x;
					m.v[num6 + 1].v = nqT.xx.y;
					m.v[num6 + 2].x = nqV.zz.x;
					m.v[num6 + 2].y = nqV.xx.y;
					m.v[num6 + 2].u = nqT.zz.x;
					m.v[num6 + 2].v = nqT.xx.y;
					m.v[num6 + 3].x = nqV.xx.x;
					m.v[num6 + 3].y = nqV.yy.y;
					m.v[num6 + 3].u = nqT.xx.x;
					m.v[num6 + 3].v = nqT.zz.y;
					m.v[num6 + 4].x = nqV.yy.x;
					m.v[num6 + 4].y = nqV.yy.y;
					m.v[num6 + 4].u = nqT.yy.x;
					m.v[num6 + 4].v = nqT.yy.y;
					m.v[num6 + 5].x = nqV.zz.x;
					m.v[num6 + 5].y = nqV.yy.y;
					m.v[num6 + 5].u = nqT.zz.x;
					m.v[num6 + 5].v = nqT.yy.y;
					m.v[num6 + 6].x = nqV.xx.x;
					m.v[num6 + 6].y = nqV.zz.y;
					m.v[num6 + 6].u = nqT.xx.x;
					m.v[num6 + 6].v = nqT.zz.y;
					m.v[num6 + 7].x = nqV.yy.x;
					m.v[num6 + 7].y = nqV.zz.y;
					m.v[num6 + 7].u = nqT.yy.x;
					m.v[num6 + 7].v = nqT.zz.y;
					m.v[num6 + 8].x = nqV.zz.x;
					m.v[num6 + 8].y = nqV.zz.y;
					m.v[num6 + 8].u = nqT.zz.x;
					m.v[num6 + 8].v = nqT.zz.y;
					break;
				}
				case 1:
				{
					int num6 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid2x2, 0f, color);
					m.v[num6].x = nqV.yy.x;
					m.v[num6].y = nqV.xx.y;
					m.v[num6].u = nqT.yy.x;
					m.v[num6].v = nqT.xx.y;
					m.v[num6 + 1].x = nqV.zz.x;
					m.v[num6 + 1].y = nqV.xx.y;
					m.v[num6 + 1].u = nqT.zz.x;
					m.v[num6 + 1].v = nqT.xx.y;
					m.v[num6 + 2].x = nqV.ww.x;
					m.v[num6 + 2].y = nqV.xx.y;
					m.v[num6 + 2].u = nqT.ww.x;
					m.v[num6 + 2].v = nqT.xx.y;
					m.v[num6 + 3].x = nqV.yy.x;
					m.v[num6 + 3].y = nqV.yy.y;
					m.v[num6 + 3].u = nqT.yy.x;
					m.v[num6 + 3].v = nqT.yy.y;
					m.v[num6 + 4].x = nqV.zz.x;
					m.v[num6 + 4].y = nqV.yy.y;
					m.v[num6 + 4].u = nqT.zz.x;
					m.v[num6 + 4].v = nqT.yy.y;
					m.v[num6 + 5].x = nqV.ww.x;
					m.v[num6 + 5].y = nqV.yy.y;
					m.v[num6 + 5].u = nqT.ww.x;
					m.v[num6 + 5].v = nqT.yy.y;
					m.v[num6 + 6].x = nqV.yy.x;
					m.v[num6 + 6].y = nqV.zz.y;
					m.v[num6 + 6].u = nqT.yy.x;
					m.v[num6 + 6].v = nqT.zz.y;
					m.v[num6 + 7].x = nqV.zz.x;
					m.v[num6 + 7].y = nqV.zz.y;
					m.v[num6 + 7].u = nqT.zz.x;
					m.v[num6 + 7].v = nqT.zz.y;
					m.v[num6 + 8].x = nqV.ww.x;
					m.v[num6 + 8].y = nqV.zz.y;
					m.v[num6 + 8].u = nqT.ww.x;
					m.v[num6 + 8].v = nqT.zz.y;
					break;
				}
				case 2:
				{
					int num6 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid2x1, 0f, color);
					m.v[num6].x = nqV.xx.x;
					m.v[num6].y = nqV.xx.y;
					m.v[num6].u = nqT.xx.x;
					m.v[num6].v = nqT.xx.y;
					m.v[num6 + 1].x = nqV.yy.x;
					m.v[num6 + 1].y = nqV.xx.y;
					m.v[num6 + 1].u = nqT.yy.x;
					m.v[num6 + 1].v = nqT.xx.y;
					m.v[num6 + 2].x = nqV.xx.x;
					m.v[num6 + 2].y = nqV.yy.y;
					m.v[num6 + 2].u = nqT.xx.x;
					m.v[num6 + 2].v = nqT.yy.y;
					m.v[num6 + 3].x = nqV.yy.x;
					m.v[num6 + 3].y = nqV.yy.y;
					m.v[num6 + 3].u = nqT.yy.x;
					m.v[num6 + 3].v = nqT.yy.y;
					m.v[num6 + 4].x = nqV.yy.x;
					m.v[num6 + 4].y = nqV.zz.y;
					m.v[num6 + 4].u = nqT.yy.x;
					m.v[num6 + 4].v = nqT.zz.y;
					m.v[num6 + 5].x = nqV.zz.x;
					m.v[num6 + 5].y = nqV.zz.y;
					m.v[num6 + 5].u = nqT.zz.x;
					m.v[num6 + 5].v = nqT.zz.y;
					num6 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid2x1, 0f, color);
					m.v[num6].x = nqV.zz.x;
					m.v[num6].y = nqV.xx.y;
					m.v[num6].u = nqT.zz.x;
					m.v[num6].v = nqT.xx.y;
					m.v[num6 + 1].x = nqV.ww.x;
					m.v[num6 + 1].y = nqV.xx.y;
					m.v[num6 + 1].u = nqT.ww.x;
					m.v[num6 + 1].v = nqT.xx.y;
					m.v[num6 + 2].x = nqV.zz.x;
					m.v[num6 + 2].y = nqV.yy.y;
					m.v[num6 + 2].u = nqT.zz.x;
					m.v[num6 + 2].v = nqT.yy.y;
					m.v[num6 + 3].x = nqV.ww.x;
					m.v[num6 + 3].y = nqV.yy.y;
					m.v[num6 + 3].u = nqT.ww.x;
					m.v[num6 + 3].v = nqT.yy.y;
					m.v[num6 + 4].x = nqV.zz.x;
					m.v[num6 + 4].y = nqV.zz.y;
					m.v[num6 + 4].u = nqT.zz.x;
					m.v[num6 + 4].v = nqT.zz.y;
					m.v[num6 + 5].x = nqV.ww.x;
					m.v[num6 + 5].y = nqV.zz.y;
					m.v[num6 + 5].u = nqT.ww.x;
					m.v[num6 + 5].v = nqT.zz.y;
					break;
				}
				}
			}
			else
			{
				switch (columnStart)
				{
				case 0:
				{
					int num7 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid2x3, 0f, color);
					m.v[num7].x = nqV.xx.x;
					m.v[num7].y = nqV.xx.y;
					m.v[num7].u = nqT.xx.x;
					m.v[num7].v = nqT.xx.y;
					m.v[num7 + 1].x = nqV.yy.x;
					m.v[num7 + 1].y = nqV.xx.y;
					m.v[num7 + 1].u = nqT.yy.x;
					m.v[num7 + 1].v = nqT.xx.y;
					m.v[num7 + 2].x = nqV.zz.x;
					m.v[num7 + 2].y = nqV.xx.y;
					m.v[num7 + 2].u = nqT.zz.x;
					m.v[num7 + 2].v = nqT.xx.y;
					m.v[num7 + 3].x = nqV.xx.x;
					m.v[num7 + 3].y = nqV.yy.y;
					m.v[num7 + 3].u = nqT.xx.x;
					m.v[num7 + 3].v = nqT.yy.y;
					m.v[num7 + 4].x = nqV.yy.x;
					m.v[num7 + 4].y = nqV.yy.y;
					m.v[num7 + 4].u = nqT.yy.x;
					m.v[num7 + 4].v = nqT.yy.y;
					m.v[num7 + 5].x = nqV.zz.x;
					m.v[num7 + 5].y = nqV.yy.y;
					m.v[num7 + 5].u = nqT.zz.x;
					m.v[num7 + 5].v = nqT.yy.y;
					m.v[num7 + 6].x = nqV.xx.x;
					m.v[num7 + 6].y = nqV.zz.y;
					m.v[num7 + 6].u = nqT.xx.x;
					m.v[num7 + 6].v = nqT.zz.y;
					m.v[num7 + 7].x = nqV.yy.x;
					m.v[num7 + 7].y = nqV.zz.y;
					m.v[num7 + 7].u = nqT.yy.x;
					m.v[num7 + 7].v = nqT.zz.y;
					m.v[num7 + 8].x = nqV.zz.x;
					m.v[num7 + 8].y = nqV.zz.y;
					m.v[num7 + 8].u = nqT.zz.x;
					m.v[num7 + 8].v = nqT.zz.y;
					m.v[num7 + 9].x = nqV.xx.x;
					m.v[num7 + 9].y = nqV.ww.y;
					m.v[num7 + 9].u = nqT.xx.x;
					m.v[num7 + 9].v = nqT.ww.y;
					m.v[num7 + 0xA].x = nqV.yy.x;
					m.v[num7 + 0xA].y = nqV.ww.y;
					m.v[num7 + 0xA].u = nqT.yy.x;
					m.v[num7 + 0xA].v = nqT.ww.y;
					m.v[num7 + 0xB].x = nqV.zz.x;
					m.v[num7 + 0xB].y = nqV.ww.y;
					m.v[num7 + 0xB].u = nqT.zz.x;
					m.v[num7 + 0xB].v = nqT.ww.y;
					break;
				}
				case 1:
				{
					int num7 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid2x3, 0f, color);
					m.v[num7].x = nqV.yy.x;
					m.v[num7].y = nqV.xx.y;
					m.v[num7].u = nqT.yy.x;
					m.v[num7].v = nqT.xx.y;
					m.v[num7 + 1].x = nqV.zz.x;
					m.v[num7 + 1].y = nqV.xx.y;
					m.v[num7 + 1].u = nqT.zz.x;
					m.v[num7 + 1].v = nqT.xx.y;
					m.v[num7 + 2].x = nqV.ww.x;
					m.v[num7 + 2].y = nqV.xx.y;
					m.v[num7 + 2].u = nqT.ww.x;
					m.v[num7 + 2].v = nqT.xx.y;
					m.v[num7 + 3].x = nqV.yy.x;
					m.v[num7 + 3].y = nqV.yy.y;
					m.v[num7 + 3].u = nqT.yy.x;
					m.v[num7 + 3].v = nqT.yy.y;
					m.v[num7 + 4].x = nqV.zz.x;
					m.v[num7 + 4].y = nqV.yy.y;
					m.v[num7 + 4].u = nqT.zz.x;
					m.v[num7 + 4].v = nqT.yy.y;
					m.v[num7 + 5].x = nqV.ww.x;
					m.v[num7 + 5].y = nqV.yy.y;
					m.v[num7 + 5].u = nqT.ww.x;
					m.v[num7 + 5].v = nqT.yy.y;
					m.v[num7 + 6].x = nqV.yy.x;
					m.v[num7 + 6].y = nqV.zz.y;
					m.v[num7 + 6].u = nqT.yy.x;
					m.v[num7 + 6].v = nqT.zz.y;
					m.v[num7 + 7].x = nqV.zz.x;
					m.v[num7 + 7].y = nqV.zz.y;
					m.v[num7 + 7].u = nqT.zz.x;
					m.v[num7 + 7].v = nqT.zz.y;
					m.v[num7 + 8].x = nqV.ww.x;
					m.v[num7 + 8].y = nqV.zz.y;
					m.v[num7 + 8].u = nqT.ww.x;
					m.v[num7 + 8].v = nqT.zz.y;
					m.v[num7 + 9].x = nqV.yy.x;
					m.v[num7 + 9].y = nqV.ww.y;
					m.v[num7 + 9].u = nqT.yy.x;
					m.v[num7 + 9].v = nqT.ww.y;
					m.v[num7 + 0xA].x = nqV.zz.x;
					m.v[num7 + 0xA].y = nqV.ww.y;
					m.v[num7 + 0xA].u = nqT.zz.x;
					m.v[num7 + 0xA].v = nqT.ww.y;
					m.v[num7 + 0xB].x = nqV.ww.x;
					m.v[num7 + 0xB].y = nqV.ww.y;
					m.v[num7 + 0xB].u = nqT.ww.x;
					m.v[num7 + 0xB].v = nqT.ww.y;
					break;
				}
				case 2:
				{
					int num7 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid1x3, 0f, color);
					m.v[num7].x = nqV.xx.x;
					m.v[num7].y = nqV.xx.y;
					m.v[num7].u = nqT.xx.x;
					m.v[num7].v = nqT.xx.y;
					m.v[num7 + 1].x = nqV.yy.x;
					m.v[num7 + 1].y = nqV.xx.y;
					m.v[num7 + 1].u = nqT.yy.x;
					m.v[num7 + 1].v = nqT.xx.y;
					m.v[num7 + 2].x = nqV.xx.x;
					m.v[num7 + 2].y = nqV.yy.y;
					m.v[num7 + 2].u = nqT.xx.x;
					m.v[num7 + 2].v = nqT.yy.y;
					m.v[num7 + 3].x = nqV.yy.x;
					m.v[num7 + 3].y = nqV.yy.y;
					m.v[num7 + 3].u = nqT.yy.x;
					m.v[num7 + 3].v = nqT.yy.y;
					m.v[num7 + 4].x = nqV.xx.x;
					m.v[num7 + 4].y = nqV.zz.y;
					m.v[num7 + 4].u = nqT.xx.x;
					m.v[num7 + 4].v = nqT.zz.y;
					m.v[num7 + 5].x = nqV.yy.x;
					m.v[num7 + 5].y = nqV.zz.y;
					m.v[num7 + 5].u = nqT.yy.x;
					m.v[num7 + 5].v = nqT.zz.y;
					m.v[num7 + 6].x = nqV.xx.x;
					m.v[num7 + 6].y = nqV.ww.y;
					m.v[num7 + 6].u = nqT.xx.x;
					m.v[num7 + 6].v = nqT.ww.y;
					m.v[num7 + 7].x = nqV.yy.x;
					m.v[num7 + 7].y = nqV.ww.y;
					m.v[num7 + 7].u = nqT.yy.x;
					m.v[num7 + 7].v = nqT.ww.y;
					num7 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid1x3, 0f, color);
					m.v[num7].x = nqV.zz.x;
					m.v[num7].y = nqV.xx.y;
					m.v[num7].u = nqT.zz.x;
					m.v[num7].v = nqT.xx.y;
					m.v[num7 + 1].x = nqV.ww.x;
					m.v[num7 + 1].y = nqV.xx.y;
					m.v[num7 + 1].u = nqT.ww.x;
					m.v[num7 + 1].v = nqT.xx.y;
					m.v[num7 + 2].x = nqV.zz.x;
					m.v[num7 + 2].y = nqV.yy.y;
					m.v[num7 + 2].u = nqT.zz.x;
					m.v[num7 + 2].v = nqT.yy.y;
					m.v[num7 + 3].x = nqV.ww.x;
					m.v[num7 + 3].y = nqV.yy.y;
					m.v[num7 + 3].u = nqT.ww.x;
					m.v[num7 + 3].v = nqT.yy.y;
					m.v[num7 + 4].x = nqV.zz.x;
					m.v[num7 + 4].y = nqV.zz.y;
					m.v[num7 + 4].u = nqT.zz.x;
					m.v[num7 + 4].v = nqT.zz.y;
					m.v[num7 + 5].x = nqV.ww.x;
					m.v[num7 + 5].y = nqV.zz.y;
					m.v[num7 + 5].u = nqT.ww.x;
					m.v[num7 + 5].v = nqT.zz.y;
					m.v[num7 + 6].x = nqV.zz.x;
					m.v[num7 + 6].y = nqV.ww.y;
					m.v[num7 + 6].u = nqT.zz.x;
					m.v[num7 + 6].v = nqT.ww.y;
					m.v[num7 + 7].x = nqV.ww.x;
					m.v[num7 + 7].y = nqV.ww.y;
					m.v[num7 + 7].u = nqT.ww.x;
					m.v[num7 + 7].v = nqT.ww.y;
					break;
				}
				}
			}
		}

		// Token: 0x060051F9 RID: 20985 RVA: 0x0014CE38 File Offset: 0x0014B038
		private static void FillColumn3(ref global::NGUI.Structures.NineRectangle nqV, ref global::NGUI.Structures.NineRectangle nqT, ref global::UnityEngine.Color color, global::NGUI.Meshing.MeshBuffer m)
		{
			if (nqV.xx.y == nqV.yy.y)
			{
				if (nqV.yy.y == nqV.zz.y)
				{
					if (nqV.zz.y != nqV.ww.y)
					{
						int num = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid3x1, 0f, color);
						m.v[num].x = nqV.xx.x;
						m.v[num].y = nqV.zz.y;
						m.v[num].u = nqT.xx.x;
						m.v[num].v = nqT.zz.y;
						m.v[num + 1].x = nqV.yy.x;
						m.v[num + 1].y = nqV.zz.y;
						m.v[num + 1].u = nqT.yy.x;
						m.v[num + 1].v = nqT.zz.y;
						m.v[num + 2].x = nqV.zz.x;
						m.v[num + 2].y = nqV.zz.y;
						m.v[num + 2].u = nqT.zz.x;
						m.v[num + 2].v = nqT.zz.y;
						m.v[num + 3].x = nqV.ww.x;
						m.v[num + 3].y = nqV.zz.y;
						m.v[num + 3].u = nqT.ww.x;
						m.v[num + 3].v = nqT.zz.y;
						m.v[num + 4].x = nqV.xx.x;
						m.v[num + 4].y = nqV.ww.y;
						m.v[num + 4].u = nqT.xx.x;
						m.v[num + 4].v = nqT.ww.y;
						m.v[num + 5].x = nqV.yy.x;
						m.v[num + 5].y = nqV.ww.y;
						m.v[num + 5].u = nqT.yy.x;
						m.v[num + 5].v = nqT.ww.y;
						m.v[num + 6].x = nqV.zz.x;
						m.v[num + 6].y = nqV.ww.y;
						m.v[num + 6].u = nqT.zz.x;
						m.v[num + 6].v = nqT.ww.y;
						m.v[num + 7].x = nqV.ww.x;
						m.v[num + 7].y = nqV.ww.y;
						m.v[num + 7].u = nqT.ww.x;
						m.v[num + 7].v = nqT.ww.y;
					}
				}
				else if (nqV.zz.y == nqV.ww.y)
				{
					int num2 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid3x1, 0f, color);
					m.v[num2].x = nqV.xx.x;
					m.v[num2].y = nqV.yy.y;
					m.v[num2].u = nqT.xx.x;
					m.v[num2].v = nqT.yy.y;
					m.v[num2 + 1].x = nqV.yy.x;
					m.v[num2 + 1].y = nqV.yy.y;
					m.v[num2 + 1].u = nqT.yy.x;
					m.v[num2 + 1].v = nqT.yy.y;
					m.v[num2 + 2].x = nqV.zz.x;
					m.v[num2 + 2].y = nqV.yy.y;
					m.v[num2 + 2].u = nqT.zz.x;
					m.v[num2 + 2].v = nqT.yy.y;
					m.v[num2 + 3].x = nqV.ww.x;
					m.v[num2 + 3].y = nqV.yy.y;
					m.v[num2 + 3].u = nqT.ww.x;
					m.v[num2 + 3].v = nqT.yy.y;
					m.v[num2 + 4].x = nqV.xx.x;
					m.v[num2 + 4].y = nqV.zz.y;
					m.v[num2 + 4].u = nqT.xx.x;
					m.v[num2 + 4].v = nqT.zz.y;
					m.v[num2 + 5].x = nqV.yy.x;
					m.v[num2 + 5].y = nqV.zz.y;
					m.v[num2 + 5].u = nqT.yy.x;
					m.v[num2 + 5].v = nqT.zz.y;
					m.v[num2 + 6].x = nqV.zz.x;
					m.v[num2 + 6].y = nqV.zz.y;
					m.v[num2 + 6].u = nqT.zz.x;
					m.v[num2 + 6].v = nqT.zz.y;
					m.v[num2 + 7].x = nqV.ww.x;
					m.v[num2 + 7].y = nqV.zz.y;
					m.v[num2 + 7].u = nqT.ww.x;
					m.v[num2 + 7].v = nqT.zz.y;
				}
				else
				{
					int num3 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid3x2, 0f, color);
					m.v[num3].x = nqV.xx.x;
					m.v[num3].y = nqV.yy.y;
					m.v[num3].u = nqT.xx.x;
					m.v[num3].v = nqT.yy.y;
					m.v[num3 + 1].x = nqV.yy.x;
					m.v[num3 + 1].y = nqV.yy.y;
					m.v[num3 + 1].u = nqT.yy.x;
					m.v[num3 + 1].v = nqT.yy.y;
					m.v[num3 + 2].x = nqV.zz.x;
					m.v[num3 + 2].y = nqV.yy.y;
					m.v[num3 + 2].u = nqT.zz.x;
					m.v[num3 + 2].v = nqT.yy.y;
					m.v[num3 + 3].x = nqV.ww.x;
					m.v[num3 + 3].y = nqV.yy.y;
					m.v[num3 + 3].u = nqT.ww.x;
					m.v[num3 + 3].v = nqT.yy.y;
					m.v[num3 + 4].x = nqV.xx.x;
					m.v[num3 + 4].y = nqV.zz.y;
					m.v[num3 + 4].u = nqT.xx.x;
					m.v[num3 + 4].v = nqT.zz.y;
					m.v[num3 + 5].x = nqV.yy.x;
					m.v[num3 + 5].y = nqV.zz.y;
					m.v[num3 + 5].u = nqT.yy.x;
					m.v[num3 + 5].v = nqT.zz.y;
					m.v[num3 + 6].x = nqV.zz.x;
					m.v[num3 + 6].y = nqV.zz.y;
					m.v[num3 + 6].u = nqT.zz.x;
					m.v[num3 + 6].v = nqT.zz.y;
					m.v[num3 + 7].x = nqV.ww.x;
					m.v[num3 + 7].y = nqV.zz.y;
					m.v[num3 + 7].u = nqT.ww.x;
					m.v[num3 + 7].v = nqT.zz.y;
					m.v[num3 + 8].x = nqV.xx.x;
					m.v[num3 + 8].y = nqV.ww.y;
					m.v[num3 + 8].u = nqT.xx.x;
					m.v[num3 + 8].v = nqT.ww.y;
					m.v[num3 + 9].x = nqV.yy.x;
					m.v[num3 + 9].y = nqV.ww.y;
					m.v[num3 + 9].u = nqT.yy.x;
					m.v[num3 + 9].v = nqT.ww.y;
					m.v[num3 + 0xA].x = nqV.zz.x;
					m.v[num3 + 0xA].y = nqV.ww.y;
					m.v[num3 + 0xA].u = nqT.zz.x;
					m.v[num3 + 0xA].v = nqT.ww.y;
					m.v[num3 + 0xB].x = nqV.ww.x;
					m.v[num3 + 0xB].y = nqV.ww.y;
					m.v[num3 + 0xB].u = nqT.ww.x;
					m.v[num3 + 0xB].v = nqT.ww.y;
				}
			}
			else if (nqV.yy.y == nqV.zz.y)
			{
				if (nqV.zz.y == nqV.ww.y)
				{
					int num4 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid3x1, 0f, color);
					m.v[num4].x = nqV.xx.x;
					m.v[num4].y = nqV.xx.y;
					m.v[num4].u = nqT.xx.x;
					m.v[num4].v = nqT.xx.y;
					m.v[num4 + 1].x = nqV.yy.x;
					m.v[num4 + 1].y = nqV.xx.y;
					m.v[num4 + 1].u = nqT.yy.x;
					m.v[num4 + 1].v = nqT.xx.y;
					m.v[num4 + 2].x = nqV.zz.x;
					m.v[num4 + 2].y = nqV.xx.y;
					m.v[num4 + 2].u = nqT.zz.x;
					m.v[num4 + 2].v = nqT.xx.y;
					m.v[num4 + 3].x = nqV.ww.x;
					m.v[num4 + 3].y = nqV.xx.y;
					m.v[num4 + 3].u = nqT.ww.x;
					m.v[num4 + 3].v = nqT.xx.y;
					m.v[num4 + 4].x = nqV.xx.x;
					m.v[num4 + 4].y = nqV.yy.y;
					m.v[num4 + 4].u = nqT.xx.x;
					m.v[num4 + 4].v = nqT.yy.y;
					m.v[num4 + 5].x = nqV.yy.x;
					m.v[num4 + 5].y = nqV.yy.y;
					m.v[num4 + 5].u = nqT.yy.x;
					m.v[num4 + 5].v = nqT.yy.y;
					m.v[num4 + 6].x = nqV.zz.x;
					m.v[num4 + 6].y = nqV.yy.y;
					m.v[num4 + 6].u = nqT.zz.x;
					m.v[num4 + 6].v = nqT.yy.y;
					m.v[num4 + 7].x = nqV.ww.x;
					m.v[num4 + 7].y = nqV.yy.y;
					m.v[num4 + 7].u = nqT.ww.x;
					m.v[num4 + 7].v = nqT.yy.y;
				}
				else
				{
					int num5 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid3x1, 0f, color);
					m.v[num5].x = nqV.xx.x;
					m.v[num5].y = nqV.xx.y;
					m.v[num5].u = nqT.xx.x;
					m.v[num5].v = nqT.xx.y;
					m.v[num5 + 1].x = nqV.yy.x;
					m.v[num5 + 1].y = nqV.xx.y;
					m.v[num5 + 1].u = nqT.yy.x;
					m.v[num5 + 1].v = nqT.xx.y;
					m.v[num5 + 2].x = nqV.zz.x;
					m.v[num5 + 2].y = nqV.xx.y;
					m.v[num5 + 2].u = nqT.zz.x;
					m.v[num5 + 2].v = nqT.xx.y;
					m.v[num5 + 3].x = nqV.ww.x;
					m.v[num5 + 3].y = nqV.xx.y;
					m.v[num5 + 3].u = nqT.ww.x;
					m.v[num5 + 3].v = nqT.xx.y;
					m.v[num5 + 4].x = nqV.xx.x;
					m.v[num5 + 4].y = nqV.yy.y;
					m.v[num5 + 4].u = nqT.xx.x;
					m.v[num5 + 4].v = nqT.yy.y;
					m.v[num5 + 5].x = nqV.yy.x;
					m.v[num5 + 5].y = nqV.yy.y;
					m.v[num5 + 5].u = nqT.yy.x;
					m.v[num5 + 5].v = nqT.yy.y;
					m.v[num5 + 6].x = nqV.zz.x;
					m.v[num5 + 6].y = nqV.yy.y;
					m.v[num5 + 6].u = nqT.zz.x;
					m.v[num5 + 6].v = nqT.yy.y;
					m.v[num5 + 7].x = nqV.ww.x;
					m.v[num5 + 7].y = nqV.yy.y;
					m.v[num5 + 7].u = nqT.ww.x;
					m.v[num5 + 7].v = nqT.yy.y;
					num5 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid3x1, 0f, color);
					m.v[num5].x = nqV.xx.x;
					m.v[num5].y = nqV.zz.y;
					m.v[num5].u = nqT.xx.x;
					m.v[num5].v = nqT.zz.y;
					m.v[num5 + 1].x = nqV.yy.x;
					m.v[num5 + 1].y = nqV.zz.y;
					m.v[num5 + 1].u = nqT.yy.x;
					m.v[num5 + 1].v = nqT.zz.y;
					m.v[num5 + 2].x = nqV.zz.x;
					m.v[num5 + 2].y = nqV.zz.y;
					m.v[num5 + 2].u = nqT.zz.x;
					m.v[num5 + 2].v = nqT.zz.y;
					m.v[num5 + 3].x = nqV.ww.x;
					m.v[num5 + 3].y = nqV.zz.y;
					m.v[num5 + 3].u = nqT.ww.x;
					m.v[num5 + 3].v = nqT.zz.y;
					m.v[num5 + 4].x = nqV.xx.x;
					m.v[num5 + 4].y = nqV.ww.y;
					m.v[num5 + 4].u = nqT.xx.x;
					m.v[num5 + 4].v = nqT.ww.y;
					m.v[num5 + 5].x = nqV.yy.x;
					m.v[num5 + 5].y = nqV.ww.y;
					m.v[num5 + 5].u = nqT.yy.x;
					m.v[num5 + 5].v = nqT.ww.y;
					m.v[num5 + 6].x = nqV.zz.x;
					m.v[num5 + 6].y = nqV.ww.y;
					m.v[num5 + 6].u = nqT.zz.x;
					m.v[num5 + 6].v = nqT.ww.y;
					m.v[num5 + 7].x = nqV.ww.x;
					m.v[num5 + 7].y = nqV.ww.y;
					m.v[num5 + 7].u = nqT.ww.x;
					m.v[num5 + 7].v = nqT.ww.y;
				}
			}
			else if (nqV.zz.y == nqV.ww.y)
			{
				int num6 = m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid3x2, 0f, color);
				m.v[num6].x = nqV.xx.x;
				m.v[num6].y = nqV.xx.y;
				m.v[num6].u = nqT.xx.x;
				m.v[num6].v = nqT.xx.y;
				m.v[num6 + 1].x = nqV.yy.x;
				m.v[num6 + 1].y = nqV.xx.y;
				m.v[num6 + 1].u = nqT.yy.x;
				m.v[num6 + 1].v = nqT.xx.y;
				m.v[num6 + 2].x = nqV.zz.x;
				m.v[num6 + 2].y = nqV.xx.y;
				m.v[num6 + 2].u = nqT.zz.x;
				m.v[num6 + 2].v = nqT.xx.y;
				m.v[num6 + 3].x = nqV.ww.x;
				m.v[num6 + 3].y = nqV.xx.y;
				m.v[num6 + 3].u = nqT.ww.x;
				m.v[num6 + 3].v = nqT.xx.y;
				m.v[num6 + 4].x = nqV.xx.x;
				m.v[num6 + 4].y = nqV.yy.y;
				m.v[num6 + 4].u = nqT.xx.x;
				m.v[num6 + 4].v = nqT.yy.y;
				m.v[num6 + 5].x = nqV.yy.x;
				m.v[num6 + 5].y = nqV.yy.y;
				m.v[num6 + 5].u = nqT.yy.x;
				m.v[num6 + 5].v = nqT.yy.y;
				m.v[num6 + 6].x = nqV.zz.x;
				m.v[num6 + 6].y = nqV.yy.y;
				m.v[num6 + 6].u = nqT.zz.x;
				m.v[num6 + 6].v = nqT.yy.y;
				m.v[num6 + 7].x = nqV.ww.x;
				m.v[num6 + 7].y = nqV.yy.y;
				m.v[num6 + 7].u = nqT.ww.x;
				m.v[num6 + 7].v = nqT.yy.y;
				m.v[num6 + 8].x = nqV.xx.x;
				m.v[num6 + 8].y = nqV.zz.y;
				m.v[num6 + 8].u = nqT.xx.x;
				m.v[num6 + 8].v = nqT.zz.y;
				m.v[num6 + 9].x = nqV.yy.x;
				m.v[num6 + 9].y = nqV.zz.y;
				m.v[num6 + 9].u = nqT.yy.x;
				m.v[num6 + 9].v = nqT.zz.y;
				m.v[num6 + 0xA].x = nqV.zz.x;
				m.v[num6 + 0xA].y = nqV.zz.y;
				m.v[num6 + 0xA].u = nqT.zz.x;
				m.v[num6 + 0xA].v = nqT.zz.y;
				m.v[num6 + 0xB].x = nqV.ww.x;
				m.v[num6 + 0xB].y = nqV.zz.y;
				m.v[num6 + 0xB].u = nqT.ww.x;
				m.v[num6 + 0xB].v = nqT.zz.y;
			}
			else
			{
				global::NGUI.Structures.NineRectangle.Commit3x3(m.Alloc(global::NGUI.Meshing.PrimitiveKind.Grid3x3), ref nqV, ref nqT, ref color, m);
			}
		}

		// Token: 0x060051FA RID: 20986 RVA: 0x0014EE0C File Offset: 0x0014D00C
		public static void Fill8(ref global::NGUI.Structures.NineRectangle nqV, ref global::NGUI.Structures.NineRectangle nqT, ref global::UnityEngine.Color color, global::NGUI.Meshing.MeshBuffer m)
		{
			global::NGUI.Structures.NineRectangle.Commit3x3(m.Alloc(global::NGUI.Meshing.PrimitiveKind.Hole3x3), ref nqV, ref nqT, ref color, m);
		}

		// Token: 0x060051FB RID: 20987 RVA: 0x0014EE20 File Offset: 0x0014D020
		private static void Commit3x3(int start, ref global::NGUI.Structures.NineRectangle nqV, ref global::NGUI.Structures.NineRectangle nqT, ref global::UnityEngine.Color color, global::NGUI.Meshing.MeshBuffer m)
		{
			m.v[start].x = nqV.xx.x;
			m.v[start].y = nqV.xx.y;
			m.v[start].u = nqT.xx.x;
			m.v[start].v = nqT.xx.y;
			m.v[start + 1].x = nqV.yx.x;
			m.v[start + 1].y = nqV.yx.y;
			m.v[start + 1].u = nqT.yx.x;
			m.v[start + 1].v = nqT.yx.y;
			m.v[start + 2].x = nqV.zx.x;
			m.v[start + 2].y = nqV.zx.y;
			m.v[start + 2].u = nqT.zx.x;
			m.v[start + 2].v = nqT.zx.y;
			m.v[start + 3].x = nqV.wx.x;
			m.v[start + 3].y = nqV.wx.y;
			m.v[start + 3].u = nqT.wx.x;
			m.v[start + 3].v = nqT.wx.y;
			m.v[start + 4].x = nqV.xy.x;
			m.v[start + 4].y = nqV.xy.y;
			m.v[start + 4].u = nqT.xy.x;
			m.v[start + 4].v = nqT.xy.y;
			m.v[start + 1 + 4].x = nqV.yy.x;
			m.v[start + 1 + 4].y = nqV.yy.y;
			m.v[start + 1 + 4].u = nqT.yy.x;
			m.v[start + 1 + 4].v = nqT.yy.y;
			m.v[start + 2 + 4].x = nqV.zy.x;
			m.v[start + 2 + 4].y = nqV.zy.y;
			m.v[start + 2 + 4].u = nqT.zy.x;
			m.v[start + 2 + 4].v = nqT.zy.y;
			m.v[start + 3 + 4].x = nqV.wy.x;
			m.v[start + 3 + 4].y = nqV.wy.y;
			m.v[start + 3 + 4].u = nqT.wy.x;
			m.v[start + 3 + 4].v = nqT.wy.y;
			m.v[start + 8].x = nqV.xz.x;
			m.v[start + 8].y = nqV.xz.y;
			m.v[start + 8].u = nqT.xz.x;
			m.v[start + 8].v = nqT.xz.y;
			m.v[start + 1 + 8].x = nqV.yz.x;
			m.v[start + 1 + 8].y = nqV.yz.y;
			m.v[start + 1 + 8].u = nqT.yz.x;
			m.v[start + 1 + 8].v = nqT.yz.y;
			m.v[start + 2 + 8].x = nqV.zz.x;
			m.v[start + 2 + 8].y = nqV.zz.y;
			m.v[start + 2 + 8].u = nqT.zz.x;
			m.v[start + 2 + 8].v = nqT.zz.y;
			m.v[start + 3 + 8].x = nqV.wz.x;
			m.v[start + 3 + 8].y = nqV.wz.y;
			m.v[start + 3 + 8].u = nqT.wz.x;
			m.v[start + 3 + 8].v = nqT.wz.y;
			m.v[start + 0xC].x = nqV.xw.x;
			m.v[start + 0xC].y = nqV.xw.y;
			m.v[start + 0xC].u = nqT.xw.x;
			m.v[start + 0xC].v = nqT.xw.y;
			m.v[start + 1 + 0xC].x = nqV.yw.x;
			m.v[start + 1 + 0xC].y = nqV.yw.y;
			m.v[start + 1 + 0xC].u = nqT.yw.x;
			m.v[start + 1 + 0xC].v = nqT.yw.y;
			m.v[start + 2 + 0xC].x = nqV.zw.x;
			m.v[start + 2 + 0xC].y = nqV.zw.y;
			m.v[start + 2 + 0xC].u = nqT.zw.x;
			m.v[start + 2 + 0xC].v = nqT.zw.y;
			m.v[start + 3 + 0xC].x = nqV.ww.x;
			m.v[start + 3 + 0xC].y = nqV.ww.y;
			m.v[start + 3 + 0xC].u = nqT.ww.x;
			m.v[start + 3 + 0xC].v = nqT.ww.y;
			for (int i = 0; i < 0x10; i++)
			{
				m.v[start + i].z = 0f;
				m.v[start + i].r = color.r;
				m.v[start + i].g = color.g;
				m.v[start + i].b = color.b;
				m.v[start + i].a = color.a;
			}
		}

		// Token: 0x04002E52 RID: 11858
		private const global::NGUI.Meshing.PrimitiveKind GRID_3ROWS_3COLUMNS = global::NGUI.Meshing.PrimitiveKind.Grid3x3;

		// Token: 0x04002E53 RID: 11859
		private const global::NGUI.Meshing.PrimitiveKind GRID_3ROWS_2COLUMNS = global::NGUI.Meshing.PrimitiveKind.Grid2x3;

		// Token: 0x04002E54 RID: 11860
		private const global::NGUI.Meshing.PrimitiveKind GRID_3ROWS_1COLUMNS = global::NGUI.Meshing.PrimitiveKind.Grid1x3;

		// Token: 0x04002E55 RID: 11861
		private const global::NGUI.Meshing.PrimitiveKind GRID_2ROWS_3COLUMNS = global::NGUI.Meshing.PrimitiveKind.Grid3x2;

		// Token: 0x04002E56 RID: 11862
		private const global::NGUI.Meshing.PrimitiveKind GRID_2ROWS_2COLUMNS = global::NGUI.Meshing.PrimitiveKind.Grid2x2;

		// Token: 0x04002E57 RID: 11863
		private const global::NGUI.Meshing.PrimitiveKind GRID_2ROWS_1COLUMNS = global::NGUI.Meshing.PrimitiveKind.Grid1x2;

		// Token: 0x04002E58 RID: 11864
		private const global::NGUI.Meshing.PrimitiveKind GRID_1ROWS_3COLUMNS = global::NGUI.Meshing.PrimitiveKind.Grid3x1;

		// Token: 0x04002E59 RID: 11865
		private const global::NGUI.Meshing.PrimitiveKind GRID_1ROWS_2COLUMNS = global::NGUI.Meshing.PrimitiveKind.Grid2x1;

		// Token: 0x04002E5A RID: 11866
		private const global::NGUI.Meshing.PrimitiveKind GRID_1ROWS_1COLUMNS = global::NGUI.Meshing.PrimitiveKind.Quad;

		// Token: 0x04002E5B RID: 11867
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public global::UnityEngine.Vector2 xx;

		// Token: 0x04002E5C RID: 11868
		[global::System.Runtime.InteropServices.FieldOffset(8)]
		public global::UnityEngine.Vector2 yy;

		// Token: 0x04002E5D RID: 11869
		[global::System.Runtime.InteropServices.FieldOffset(0x10)]
		public global::UnityEngine.Vector2 zz;

		// Token: 0x04002E5E RID: 11870
		[global::System.Runtime.InteropServices.FieldOffset(0x18)]
		public global::UnityEngine.Vector2 ww;
	}
}
