using System;
using UnityEngine;

namespace NGUI.Meshing
{
	// Token: 0x020008FD RID: 2301
	public struct Primitive
	{
		// Token: 0x06004ED2 RID: 20178 RVA: 0x0012F64C File Offset: 0x0012D84C
		public Primitive(global::NGUI.Meshing.PrimitiveKind kind, ushort start)
		{
			this.kind = kind;
			this.start = start;
		}

		// Token: 0x06004ED3 RID: 20179 RVA: 0x0012F65C File Offset: 0x0012D85C
		public static int VertexCount(global::NGUI.Meshing.PrimitiveKind kind)
		{
			switch (kind)
			{
			case global::NGUI.Meshing.PrimitiveKind.Triangle:
				return 3;
			case global::NGUI.Meshing.PrimitiveKind.Quad:
				return 4;
			case global::NGUI.Meshing.PrimitiveKind.Grid2x1:
			case global::NGUI.Meshing.PrimitiveKind.Grid1x2:
				return 6;
			case global::NGUI.Meshing.PrimitiveKind.Grid2x2:
				return 9;
			case global::NGUI.Meshing.PrimitiveKind.Grid1x3:
			case global::NGUI.Meshing.PrimitiveKind.Grid3x1:
				return 8;
			case global::NGUI.Meshing.PrimitiveKind.Grid3x2:
			case global::NGUI.Meshing.PrimitiveKind.Grid2x3:
				return 0xC;
			case global::NGUI.Meshing.PrimitiveKind.Grid3x3:
			case global::NGUI.Meshing.PrimitiveKind.Hole3x3:
				return 0x10;
			default:
				throw new global::System.NotImplementedException();
			}
		}

		// Token: 0x06004ED4 RID: 20180 RVA: 0x0012F6B8 File Offset: 0x0012D8B8
		public static int IndexCount(global::NGUI.Meshing.PrimitiveKind kind)
		{
			switch (kind)
			{
			case global::NGUI.Meshing.PrimitiveKind.Triangle:
				return 3;
			case global::NGUI.Meshing.PrimitiveKind.Quad:
				return 6;
			case global::NGUI.Meshing.PrimitiveKind.Grid2x1:
			case global::NGUI.Meshing.PrimitiveKind.Grid1x2:
				return 0xC;
			case global::NGUI.Meshing.PrimitiveKind.Grid2x2:
				return 0x18;
			case global::NGUI.Meshing.PrimitiveKind.Grid1x3:
			case global::NGUI.Meshing.PrimitiveKind.Grid3x1:
				return 0x12;
			case global::NGUI.Meshing.PrimitiveKind.Grid3x2:
			case global::NGUI.Meshing.PrimitiveKind.Grid2x3:
				return 0x24;
			case global::NGUI.Meshing.PrimitiveKind.Grid3x3:
				return 0x36;
			case global::NGUI.Meshing.PrimitiveKind.Hole3x3:
				return 0x30;
			default:
				throw new global::System.NotImplementedException();
			}
		}

		// Token: 0x06004ED5 RID: 20181 RVA: 0x0012F71C File Offset: 0x0012D91C
		public static bool JoinsInList(global::NGUI.Meshing.PrimitiveKind kind)
		{
			return true;
		}

		// Token: 0x06004ED6 RID: 20182 RVA: 0x0012F720 File Offset: 0x0012D920
		public void Copy(ref int start, global::NGUI.Meshing.Vertex[] v, int end, global::NGUI.Meshing.MeshBuffer p)
		{
			int num = (end - start) / global::NGUI.Meshing.Primitive.VertexCount(this.kind);
			while (num-- > 0)
			{
				int num2;
				int i = p.Alloc(this.kind, out num2);
				while (i < num2)
				{
					p.v[i++] = v[start++];
				}
			}
		}

		// Token: 0x06004ED7 RID: 20183 RVA: 0x0012F794 File Offset: 0x0012D994
		public void Copy(ref int start, global::NGUI.Meshing.Vertex[] v, global::UnityEngine.Vector3[] transformed, int end, global::NGUI.Meshing.MeshBuffer p)
		{
			int num = (end - start) / global::NGUI.Meshing.Primitive.VertexCount(this.kind);
			while (num-- > 0)
			{
				int num2;
				int i = p.Alloc(this.kind, out num2);
				while (i < num2)
				{
					p.v[i].x = transformed[start].x;
					p.v[i].y = transformed[start].y;
					p.v[i].z = transformed[start].z;
					p.v[i].u = v[start].u;
					p.v[i].v = v[start].v;
					p.v[i].r = v[start].r;
					p.v[i].g = v[start].g;
					p.v[i].b = v[start].b;
					p.v[i].a = v[start].a;
					i++;
					start++;
				}
			}
		}

		// Token: 0x06004ED8 RID: 20184 RVA: 0x0012F900 File Offset: 0x0012DB00
		public void Put(int[] t, ref int v, ref int i, int end)
		{
			int num = (end - (int)this.start) / global::NGUI.Meshing.Primitive.VertexCount(this.kind);
			switch (this.kind)
			{
			case global::NGUI.Meshing.PrimitiveKind.Triangle:
				while (num-- > 0)
				{
					t[i++] = v;
					t[i++] = v + 1;
					t[i++] = v + 2;
					v += 3;
				}
				break;
			case global::NGUI.Meshing.PrimitiveKind.Quad:
				while (num-- > 0)
				{
					t[i++] = v;
					t[i++] = v + 1;
					t[i++] = v + 3;
					t[i++] = v + 2;
					t[i++] = v;
					t[i++] = v + 3;
					v += 4;
				}
				break;
			case global::NGUI.Meshing.PrimitiveKind.Grid2x1:
				while (num-- > 0)
				{
					for (int j = 0; j < 2; j++)
					{
						for (int k = 0; k < 1; k++)
						{
							t[i++] = v + (j + k * 3);
							t[i++] = v + (j + 1 + k * 3);
							t[i++] = v + (j + (k + 1) * 3);
							t[i++] = v + (j + 1 + k * 3);
							t[i++] = v + (j + 1 + (k + 1) * 3);
							t[i++] = v + (j + (k + 1) * 3);
						}
					}
					v += 6;
				}
				break;
			case global::NGUI.Meshing.PrimitiveKind.Grid1x2:
				while (num-- > 0)
				{
					for (int l = 0; l < 1; l++)
					{
						for (int m = 0; m < 2; m++)
						{
							t[i++] = v + (l + m * 2);
							t[i++] = v + (l + 1 + m * 2);
							t[i++] = v + (l + (m + 1) * 2);
							t[i++] = v + (l + 1 + m * 2);
							t[i++] = v + (l + 1 + (m + 1) * 2);
							t[i++] = v + (l + (m + 1) * 2);
						}
					}
					v += 6;
				}
				break;
			case global::NGUI.Meshing.PrimitiveKind.Grid2x2:
				while (num-- > 0)
				{
					for (int n = 0; n < 2; n++)
					{
						for (int num2 = 0; num2 < 2; num2++)
						{
							t[i++] = v + (n + num2 * 3);
							t[i++] = v + (n + 1 + num2 * 3);
							t[i++] = v + (n + (num2 + 1) * 3);
							t[i++] = v + (n + 1 + num2 * 3);
							t[i++] = v + (n + 1 + (num2 + 1) * 3);
							t[i++] = v + (n + (num2 + 1) * 3);
						}
					}
					v += 9;
				}
				break;
			case global::NGUI.Meshing.PrimitiveKind.Grid1x3:
				while (num-- > 0)
				{
					for (int num3 = 0; num3 < 1; num3++)
					{
						for (int num4 = 0; num4 < 3; num4++)
						{
							t[i++] = v + (num3 + num4 * 2);
							t[i++] = v + (num3 + 1 + num4 * 2);
							t[i++] = v + (num3 + (num4 + 1) * 2);
							t[i++] = v + (num3 + 1 + num4 * 2);
							t[i++] = v + (num3 + 1 + (num4 + 1) * 2);
							t[i++] = v + (num3 + (num4 + 1) * 2);
						}
					}
					v += 8;
				}
				break;
			case global::NGUI.Meshing.PrimitiveKind.Grid3x1:
				while (num-- > 0)
				{
					for (int num5 = 0; num5 < 3; num5++)
					{
						for (int num6 = 0; num6 < 1; num6++)
						{
							t[i++] = v + (num5 + num6 * 4);
							t[i++] = v + (num5 + 1 + num6 * 4);
							t[i++] = v + (num5 + (num6 + 1) * 4);
							t[i++] = v + (num5 + 1 + num6 * 4);
							t[i++] = v + (num5 + 1 + (num6 + 1) * 4);
							t[i++] = v + (num5 + (num6 + 1) * 4);
						}
					}
					v += 8;
				}
				break;
			case global::NGUI.Meshing.PrimitiveKind.Grid3x2:
				while (num-- > 0)
				{
					for (int num7 = 0; num7 < 3; num7++)
					{
						for (int num8 = 0; num8 < 2; num8++)
						{
							t[i++] = v + (num7 + num8 * 4);
							t[i++] = v + (num7 + 1 + num8 * 4);
							t[i++] = v + (num7 + (num8 + 1) * 4);
							t[i++] = v + (num7 + 1 + num8 * 4);
							t[i++] = v + (num7 + 1 + (num8 + 1) * 4);
							t[i++] = v + (num7 + (num8 + 1) * 4);
						}
					}
					v += 0xC;
				}
				break;
			case global::NGUI.Meshing.PrimitiveKind.Grid2x3:
				while (num-- > 0)
				{
					for (int num9 = 0; num9 < 2; num9++)
					{
						for (int num10 = 0; num10 < 3; num10++)
						{
							t[i++] = v + (num9 + num10 * 3);
							t[i++] = v + (num9 + 1 + num10 * 3);
							t[i++] = v + (num9 + (num10 + 1) * 3);
							t[i++] = v + (num9 + 1 + num10 * 3);
							t[i++] = v + (num9 + 1 + (num10 + 1) * 3);
							t[i++] = v + (num9 + (num10 + 1) * 3);
						}
					}
					v += 0xC;
				}
				break;
			case global::NGUI.Meshing.PrimitiveKind.Grid3x3:
				while (num-- > 0)
				{
					for (int num11 = 0; num11 < 3; num11++)
					{
						for (int num12 = 0; num12 < 3; num12++)
						{
							t[i++] = v + (num11 + num12 * 4);
							t[i++] = v + (num11 + 1 + num12 * 4);
							t[i++] = v + (num11 + (num12 + 1) * 4);
							t[i++] = v + (num11 + 1 + num12 * 4);
							t[i++] = v + (num11 + 1 + (num12 + 1) * 4);
							t[i++] = v + (num11 + (num12 + 1) * 4);
						}
					}
					v += 0x10;
				}
				break;
			case global::NGUI.Meshing.PrimitiveKind.Hole3x3:
				while (num-- > 0)
				{
					for (int num13 = 0; num13 < 3; num13++)
					{
						for (int num14 = 0; num14 < 3; num14++)
						{
							if (num13 != 1 || num14 != 1)
							{
								t[i++] = v + (num13 + num14 * 4);
								t[i++] = v + (num13 + 1 + num14 * 4);
								t[i++] = v + (num13 + (num14 + 1) * 4);
								t[i++] = v + (num13 + 1 + num14 * 4);
								t[i++] = v + (num13 + 1 + (num14 + 1) * 4);
								t[i++] = v + (num13 + (num14 + 1) * 4);
							}
						}
					}
					v += 0x10;
				}
				break;
			default:
				throw new global::System.NotImplementedException();
			}
		}

		// Token: 0x04002B81 RID: 11137
		public readonly global::NGUI.Meshing.PrimitiveKind kind;

		// Token: 0x04002B82 RID: 11138
		public readonly ushort start;
	}
}
