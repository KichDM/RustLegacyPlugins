using System;
using UnityEngine;

namespace NGUI.Meshing
{
	// Token: 0x020008FE RID: 2302
	public class MeshBuffer
	{
		// Token: 0x06004ED9 RID: 20185 RVA: 0x001301F4 File Offset: 0x0012E3F4
		public MeshBuffer()
		{
		}

		// Token: 0x06004EDA RID: 20186 RVA: 0x00130208 File Offset: 0x0012E408
		private static int Gen_Alloc<T>(int count, ref int size, ref int cap, ref T[] array, int initAllocSize, int maxAllocSize, int maxAllocSizeIncrement)
		{
			if (count <= 0)
			{
				return -1;
			}
			int result = size;
			size += count;
			if (size > cap)
			{
				if (cap == 0)
				{
					cap = initAllocSize;
				}
				while (cap < size)
				{
					if (cap < maxAllocSize)
					{
						cap *= 2;
					}
					else
					{
						cap += maxAllocSizeIncrement;
					}
				}
				global::System.Array.Resize<T>(ref array, cap);
			}
			return result;
		}

		// Token: 0x06004EDB RID: 20187 RVA: 0x00130270 File Offset: 0x0012E470
		public int Alloc(global::NGUI.Meshing.PrimitiveKind kind, out int end)
		{
			int num = global::NGUI.Meshing.Primitive.VertexCount(kind);
			if (this.lastPrimitiveKind != kind)
			{
				int num2 = global::NGUI.Meshing.MeshBuffer.Gen_Alloc<global::NGUI.Meshing.Primitive>(1, ref this.primSize, ref this.primCapacity, ref this.primitives, 4, 0x20, 0x20);
				if (global::NGUI.Meshing.Primitive.JoinsInList(kind))
				{
					this.lastPrimitiveKind = kind;
				}
				else
				{
					this.lastPrimitiveKind = global::NGUI.Meshing.PrimitiveKind.Invalid;
				}
				this.primitives[num2] = new global::NGUI.Meshing.Primitive(kind, (ushort)this.vSize);
			}
			this.iCount += global::NGUI.Meshing.Primitive.IndexCount(kind);
			int num3 = global::NGUI.Meshing.MeshBuffer.Gen_Alloc<global::NGUI.Meshing.Vertex>(num, ref this.vSize, ref this.vertCapacity, ref this.v, 0x20, 0x200, 0x200);
			end = num3 + num;
			return num3;
		}

		// Token: 0x06004EDC RID: 20188 RVA: 0x0013032C File Offset: 0x0012E52C
		public int Alloc(global::NGUI.Meshing.PrimitiveKind primitive, global::UnityEngine.Color color, out int end)
		{
			int num = this.Alloc(primitive, out end);
			float r = color.r;
			float g = color.g;
			float b = color.b;
			float a = color.a;
			for (int i = num; i < end; i++)
			{
				this.v[i].r = r;
				this.v[i].g = g;
				this.v[i].b = b;
				this.v[i].a = a;
			}
			return num;
		}

		// Token: 0x06004EDD RID: 20189 RVA: 0x001303CC File Offset: 0x0012E5CC
		public int Alloc(global::NGUI.Meshing.PrimitiveKind primitive, float z, global::UnityEngine.Color color, out int end)
		{
			int num = this.Alloc(primitive, out end);
			float r = color.r;
			float g = color.g;
			float b = color.b;
			float a = color.a;
			for (int i = num; i < end; i++)
			{
				this.v[i].r = r;
				this.v[i].g = g;
				this.v[i].b = b;
				this.v[i].a = a;
				this.v[i].z = z;
			}
			return num;
		}

		// Token: 0x06004EDE RID: 20190 RVA: 0x00130484 File Offset: 0x0012E684
		public int Alloc(global::NGUI.Meshing.PrimitiveKind primitive, float z, ref global::UnityEngine.Color color, out int end)
		{
			int num = this.Alloc(primitive, out end);
			float r = color.r;
			float g = color.g;
			float b = color.b;
			float a = color.a;
			for (int i = num; i < end; i++)
			{
				this.v[i].r = r;
				this.v[i].g = g;
				this.v[i].b = b;
				this.v[i].a = a;
				this.v[i].z = z;
			}
			return num;
		}

		// Token: 0x06004EDF RID: 20191 RVA: 0x00130538 File Offset: 0x0012E738
		public int Alloc(global::NGUI.Meshing.PrimitiveKind primitive, float z, out int end)
		{
			int num = this.Alloc(primitive, out end);
			for (int i = num; i < end; i++)
			{
				this.v[i].z = z;
				this.v[i].r = (this.v[i].g = (this.v[i].b = (this.v[i].a = 1f)));
			}
			return num;
		}

		// Token: 0x06004EE0 RID: 20192 RVA: 0x001305C8 File Offset: 0x0012E7C8
		public int Alloc(global::NGUI.Meshing.PrimitiveKind primitive, global::NGUI.Meshing.Vertex V, out int end)
		{
			int num = this.Alloc(primitive, out end);
			for (int i = num; i < end; i++)
			{
				this.v[i].x = V.x;
				this.v[i].y = V.y;
				this.v[i].r = V.r;
				this.v[i].u = V.u;
				this.v[i].v = V.v;
				this.v[i].g = V.g;
				this.v[i].b = V.b;
				this.v[i].a = V.a;
			}
			return num;
		}

		// Token: 0x06004EE1 RID: 20193 RVA: 0x001306B4 File Offset: 0x0012E8B4
		public int Alloc(global::NGUI.Meshing.PrimitiveKind kind)
		{
			int num;
			return this.Alloc(kind, out num);
		}

		// Token: 0x06004EE2 RID: 20194 RVA: 0x001306CC File Offset: 0x0012E8CC
		public int Alloc(global::NGUI.Meshing.PrimitiveKind kind, global::UnityEngine.Color color)
		{
			int num;
			return this.Alloc(kind, color, out num);
		}

		// Token: 0x06004EE3 RID: 20195 RVA: 0x001306E4 File Offset: 0x0012E8E4
		public int Alloc(global::NGUI.Meshing.PrimitiveKind kind, float z)
		{
			int num;
			return this.Alloc(kind, z, out num);
		}

		// Token: 0x06004EE4 RID: 20196 RVA: 0x001306FC File Offset: 0x0012E8FC
		public int Alloc(global::NGUI.Meshing.PrimitiveKind kind, float z, global::UnityEngine.Color color)
		{
			int num;
			return this.Alloc(kind, z, color, out num);
		}

		// Token: 0x06004EE5 RID: 20197 RVA: 0x00130714 File Offset: 0x0012E914
		public int Alloc(global::NGUI.Meshing.PrimitiveKind kind, float z, ref global::UnityEngine.Color color)
		{
			int num;
			return this.Alloc(kind, z, ref color, out num);
		}

		// Token: 0x06004EE6 RID: 20198 RVA: 0x0013072C File Offset: 0x0012E92C
		public int Alloc(global::NGUI.Meshing.PrimitiveKind kind, global::NGUI.Meshing.Vertex v)
		{
			int num;
			return this.Alloc(kind, v, out num);
		}

		// Token: 0x06004EE7 RID: 20199 RVA: 0x00130744 File Offset: 0x0012E944
		public int Triangle(global::NGUI.Meshing.Vertex A, global::NGUI.Meshing.Vertex B, global::NGUI.Meshing.Vertex C)
		{
			int num2;
			int num = this.Alloc(global::NGUI.Meshing.PrimitiveKind.Triangle, out num2);
			int num3 = num;
			this.v[num3++] = A;
			this.v[num3++] = B;
			this.v[num3++] = C;
			return num;
		}

		// Token: 0x06004EE8 RID: 20200 RVA: 0x001307A0 File Offset: 0x0012E9A0
		public int Quad(global::NGUI.Meshing.Vertex A, global::NGUI.Meshing.Vertex B, global::NGUI.Meshing.Vertex C, global::NGUI.Meshing.Vertex D)
		{
			int num2;
			int num = this.Alloc(global::NGUI.Meshing.PrimitiveKind.Quad, out num2);
			int num3 = num;
			this.v[num3++] = B;
			this.v[num3++] = A;
			this.v[num3++] = C;
			this.v[num3++] = D;
			return num;
		}

		// Token: 0x06004EE9 RID: 20201 RVA: 0x00130814 File Offset: 0x0012EA14
		public int QuadAlt(global::NGUI.Meshing.Vertex A, global::NGUI.Meshing.Vertex B, global::NGUI.Meshing.Vertex C, global::NGUI.Meshing.Vertex D)
		{
			return this.Quad(D, A, B, C);
		}

		// Token: 0x06004EEA RID: 20202 RVA: 0x00130824 File Offset: 0x0012EA24
		public int TextureQuad(global::NGUI.Meshing.Vertex A, global::NGUI.Meshing.Vertex B, global::NGUI.Meshing.Vertex C, global::NGUI.Meshing.Vertex D)
		{
			int num2;
			int num = this.Alloc(global::NGUI.Meshing.PrimitiveKind.Quad, out num2);
			int num3 = num;
			this.v[num3++] = D;
			this.v[num3++] = A;
			this.v[num3++] = C;
			this.v[num3++] = B;
			return num;
		}

		// Token: 0x06004EEB RID: 20203 RVA: 0x00130898 File Offset: 0x0012EA98
		public int FastQuad(global::UnityEngine.Vector2 uv0, global::UnityEngine.Vector2 uv1, global::UnityEngine.Color color)
		{
			global::NGUI.Meshing.Vertex a;
			global::NGUI.Meshing.Vertex b;
			a.x = (b.x = 1f);
			global::NGUI.Meshing.Vertex c;
			b.y = (c.y = -1f);
			global::NGUI.Meshing.Vertex d;
			a.y = (a.z = (b.z = (c.x = (c.z = (d.x = (d.y = (d.z = 0f)))))));
			a.u = (b.u = uv1.x);
			a.v = (d.v = uv1.y);
			c.u = (d.u = uv0.x);
			b.v = (c.v = uv0.y);
			a.r = (b.r = (c.r = (d.r = color.r)));
			a.g = (b.g = (c.g = (d.g = color.g)));
			a.b = (b.b = (c.b = (d.b = color.b)));
			a.a = (b.a = (c.a = (d.a = color.a)));
			return this.Quad(a, b, c, d);
		}

		// Token: 0x06004EEC RID: 20204 RVA: 0x00130A70 File Offset: 0x0012EC70
		public int FastQuad(global::UnityEngine.Rect uv, global::UnityEngine.Color color)
		{
			return this.FastQuad(new global::UnityEngine.Vector2(uv.xMin, uv.yMin), new global::UnityEngine.Vector2(uv.xMax, uv.yMax), color);
		}

		// Token: 0x06004EED RID: 20205 RVA: 0x00130AAC File Offset: 0x0012ECAC
		public int FastQuad(global::UnityEngine.Vector2 xy0, global::UnityEngine.Vector2 xy1, global::UnityEngine.Vector2 uv0, global::UnityEngine.Vector2 uv1, global::UnityEngine.Color color)
		{
			global::NGUI.Meshing.Vertex a;
			global::NGUI.Meshing.Vertex b;
			a.x = (b.x = xy1.x);
			global::NGUI.Meshing.Vertex d;
			a.y = (d.y = xy1.y);
			global::NGUI.Meshing.Vertex c;
			c.x = (d.x = xy0.x);
			b.y = (c.y = xy0.y);
			a.z = (b.z = (c.z = (d.z = 0f)));
			a.u = (b.u = uv1.x);
			a.v = (d.v = uv1.y);
			c.u = (d.u = uv0.x);
			b.v = (c.v = uv0.y);
			a.r = (b.r = (c.r = (d.r = color.r)));
			a.g = (b.g = (c.g = (d.g = color.g)));
			a.b = (b.b = (c.b = (d.b = color.b)));
			a.a = (b.a = (c.a = (d.a = color.a)));
			return this.Quad(a, b, c, d);
		}

		// Token: 0x06004EEE RID: 20206 RVA: 0x00130C8C File Offset: 0x0012EE8C
		public void FastCell(global::UnityEngine.Vector2 xy0, global::UnityEngine.Vector2 xy1, global::UnityEngine.Vector2 uv0, global::UnityEngine.Vector2 uv1, ref global::UnityEngine.Color color)
		{
			global::NGUI.Meshing.Vertex a;
			global::NGUI.Meshing.Vertex b;
			a.x = (b.x = xy1.x);
			global::NGUI.Meshing.Vertex d;
			a.y = (d.y = xy1.y);
			global::NGUI.Meshing.Vertex c;
			c.x = (d.x = xy0.x);
			b.y = (c.y = xy0.y);
			a.z = (b.z = (c.z = (d.z = 0f)));
			a.u = (b.u = uv1.x);
			a.v = (d.v = uv1.y);
			c.u = (d.u = uv0.x);
			b.v = (c.v = uv0.y);
			a.r = (b.r = (c.r = (d.r = color.r)));
			a.g = (b.g = (c.g = (d.g = color.g)));
			a.b = (b.b = (c.b = (d.b = color.b)));
			a.a = (b.a = (c.a = (d.a = color.a)));
			this.Quad(a, b, c, d);
		}

		// Token: 0x06004EEF RID: 20207 RVA: 0x00130E6C File Offset: 0x0012F06C
		public int FastQuad(global::UnityEngine.Vector2 xy0, global::UnityEngine.Vector2 xy1, float z, global::UnityEngine.Vector2 uv0, global::UnityEngine.Vector2 uv1, global::UnityEngine.Color color)
		{
			global::NGUI.Meshing.Vertex a;
			global::NGUI.Meshing.Vertex b;
			a.x = (b.x = xy1.x);
			global::NGUI.Meshing.Vertex d;
			a.y = (d.y = xy1.y);
			global::NGUI.Meshing.Vertex c;
			c.x = (d.x = xy0.x);
			b.y = (c.y = xy0.y);
			d.z = z;
			c.z = z;
			b.z = z;
			a.z = z;
			a.u = (b.u = uv1.x);
			a.v = (d.v = uv1.y);
			c.u = (d.u = uv0.x);
			b.v = (c.v = uv0.y);
			a.r = (b.r = (c.r = (d.r = color.r)));
			a.g = (b.g = (c.g = (d.g = color.g)));
			a.b = (b.b = (c.b = (d.b = color.b)));
			a.a = (b.a = (c.a = (d.a = color.a)));
			return this.Quad(a, b, c, d);
		}

		// Token: 0x06004EF0 RID: 20208 RVA: 0x00131048 File Offset: 0x0012F248
		private void Extract(global::NGUI.Meshing.MeshBuffer.FillBuffer<global::UnityEngine.Vector3> vertices, global::NGUI.Meshing.MeshBuffer.FillBuffer<global::UnityEngine.Vector2> uvs, global::NGUI.Meshing.MeshBuffer.FillBuffer<global::UnityEngine.Color> colors, global::NGUI.Meshing.MeshBuffer.FillBuffer<int> triangles)
		{
			global::UnityEngine.Vector3[] buf = vertices.buf;
			global::UnityEngine.Vector2[] buf2 = uvs.buf;
			global::UnityEngine.Color[] buf3 = colors.buf;
			int[] buf4 = triangles.buf;
			int num = vertices.offset;
			int num2 = uvs.offset;
			int num3 = colors.offset;
			for (int i = 0; i < this.vSize; i++)
			{
				buf[num].x = this.v[i].x;
				buf[num].y = this.v[i].y;
				buf[num].z = this.v[i].z;
				buf2[num2].x = this.v[i].u;
				buf2[num2].y = this.v[i].v;
				buf3[num3].r = this.v[i].r;
				buf3[num3].g = this.v[i].g;
				buf3[num3].b = this.v[i].b;
				buf3[num3].a = this.v[i].a;
				num++;
				num2++;
				num3++;
			}
			int offset = triangles.offset;
			int offset2 = vertices.offset;
			if (this.primSize > 0)
			{
				for (int j = 0; j < this.primSize - 1; j++)
				{
					this.primitives[j].Put(buf4, ref offset2, ref offset, (int)this.primitives[j + 1].start);
				}
				this.primitives[this.primSize - 1].Put(buf4, ref offset2, ref offset, this.vSize);
			}
		}

		// Token: 0x06004EF1 RID: 20209 RVA: 0x00131268 File Offset: 0x0012F468
		private static bool ResizeChecked<T>(ref T[] array, int size)
		{
			if (size == 0)
			{
				if (array != null && array.Length != 0)
				{
					array = null;
					return true;
				}
				return false;
			}
			else
			{
				if (array == null || array.Length != size)
				{
					global::System.Array.Resize<T>(ref array, size);
					return true;
				}
				return false;
			}
		}

		// Token: 0x06004EF2 RID: 20210 RVA: 0x001312B0 File Offset: 0x0012F4B0
		public bool ExtractMeshBuffers(ref global::UnityEngine.Vector3[] vertices, ref global::UnityEngine.Vector2[] uvs, ref global::UnityEngine.Color[] colors, ref int[] triangles)
		{
			bool result = global::NGUI.Meshing.MeshBuffer.ResizeChecked<global::UnityEngine.Vector3>(ref vertices, this.vSize) | global::NGUI.Meshing.MeshBuffer.ResizeChecked<global::UnityEngine.Vector2>(ref uvs, this.vSize) | global::NGUI.Meshing.MeshBuffer.ResizeChecked<global::UnityEngine.Color>(ref colors, this.vSize) | global::NGUI.Meshing.MeshBuffer.ResizeChecked<int>(ref triangles, this.iCount);
			this.Extract(new global::NGUI.Meshing.MeshBuffer.FillBuffer<global::UnityEngine.Vector3>
			{
				buf = vertices
			}, new global::NGUI.Meshing.MeshBuffer.FillBuffer<global::UnityEngine.Vector2>
			{
				buf = uvs
			}, new global::NGUI.Meshing.MeshBuffer.FillBuffer<global::UnityEngine.Color>
			{
				buf = colors
			}, new global::NGUI.Meshing.MeshBuffer.FillBuffer<int>
			{
				buf = triangles
			});
			return result;
		}

		// Token: 0x06004EF3 RID: 20211 RVA: 0x00131344 File Offset: 0x0012F544
		public void Offset(float x, float y, float z)
		{
			if (x == 0f)
			{
				if (y == 0f)
				{
					if (z == 0f)
					{
						return;
					}
					for (int i = 0; i < this.vSize; i++)
					{
						global::NGUI.Meshing.Vertex[] array = this.v;
						int num = i;
						array[num].z = array[num].z + z;
					}
				}
				else if (z == 0f)
				{
					for (int j = 0; j < this.vSize; j++)
					{
						global::NGUI.Meshing.Vertex[] array2 = this.v;
						int num2 = j;
						array2[num2].y = array2[num2].y + y;
					}
				}
				else
				{
					for (int k = 0; k < this.vSize; k++)
					{
						global::NGUI.Meshing.Vertex[] array3 = this.v;
						int num3 = k;
						array3[num3].y = array3[num3].y + y;
						global::NGUI.Meshing.Vertex[] array4 = this.v;
						int num4 = k;
						array4[num4].z = array4[num4].z + z;
					}
				}
			}
			else if (y == 0f)
			{
				if (z == 0f)
				{
					for (int l = 0; l < this.vSize; l++)
					{
						global::NGUI.Meshing.Vertex[] array5 = this.v;
						int num5 = l;
						array5[num5].x = array5[num5].x + x;
					}
				}
				else
				{
					for (int m = 0; m < this.vSize; m++)
					{
						global::NGUI.Meshing.Vertex[] array6 = this.v;
						int num6 = m;
						array6[num6].x = array6[num6].x + x;
						global::NGUI.Meshing.Vertex[] array7 = this.v;
						int num7 = m;
						array7[num7].z = array7[num7].z + z;
					}
				}
			}
			else if (z == 0f)
			{
				for (int n = 0; n < this.vSize; n++)
				{
					global::NGUI.Meshing.Vertex[] array8 = this.v;
					int num8 = n;
					array8[num8].x = array8[num8].x + x;
					global::NGUI.Meshing.Vertex[] array9 = this.v;
					int num9 = n;
					array9[num9].y = array9[num9].y + y;
				}
			}
			else
			{
				for (int num10 = 0; num10 < this.vSize; num10++)
				{
					global::NGUI.Meshing.Vertex[] array10 = this.v;
					int num11 = num10;
					array10[num11].x = array10[num11].x + x;
					global::NGUI.Meshing.Vertex[] array11 = this.v;
					int num12 = num10;
					array11[num12].y = array11[num12].y + y;
					global::NGUI.Meshing.Vertex[] array12 = this.v;
					int num13 = num10;
					array12[num13].z = array12[num13].z + z;
				}
			}
		}

		// Token: 0x06004EF4 RID: 20212 RVA: 0x001315A0 File Offset: 0x0012F7A0
		public void BuildTransformedVertices4x4(ref global::UnityEngine.Vector3[] tV, float m00, float m10, float m20, float m30, float m01, float m11, float m21, float m31, float m02, float m12, float m22, float m32, float m03, float m13, float m23, float m33)
		{
			global::System.Array.Resize<global::UnityEngine.Vector3>(ref tV, this.vSize);
			for (int i = 0; i < this.vSize; i++)
			{
				float num = 1f / (m30 * this.v[i].x + m31 * this.v[i].y + m32 * this.v[i].z + m33);
				tV[i].x = (m00 * this.v[i].x + m01 * this.v[i].y + m02 * this.v[i].z + m03) * num;
				tV[i].y = (m10 * this.v[i].x + m11 * this.v[i].y + m12 * this.v[i].z + m13) * num;
				tV[i].z = (m20 * this.v[i].x + m21 * this.v[i].y + m22 * this.v[i].z + m23) * num;
			}
		}

		// Token: 0x06004EF5 RID: 20213 RVA: 0x00131708 File Offset: 0x0012F908
		public void TransformVertices(float m00, float m10, float m20, float m01, float m11, float m21, float m02, float m12, float m22, float m03, float m13, float m23)
		{
			for (int i = 0; i < this.vSize; i++)
			{
				float x = this.v[i].x;
				float y = this.v[i].y;
				float z = this.v[i].z;
				this.v[i].x = m00 * x + m01 * y + m02 * z + m03;
				this.v[i].y = m10 * x + m11 * y + m12 * z + m13;
				this.v[i].z = m20 * x + m21 * y + m22 * z + m23;
			}
		}

		// Token: 0x06004EF6 RID: 20214 RVA: 0x001317C8 File Offset: 0x0012F9C8
		public void OffsetThenTransformVertices(float x, float y, float z, float m00, float m10, float m20, float m01, float m11, float m21, float m02, float m12, float m22, float m03, float m13, float m23)
		{
			if (x == 0f)
			{
				if (y == 0f)
				{
					if (z == 0f)
					{
						for (int i = 0; i < this.vSize; i++)
						{
							float num = this.v[i].x;
							float num2 = this.v[i].y;
							float num3 = this.v[i].z;
							this.v[i].x = m00 * num + m01 * num2 + m02 * num3 + m03;
							this.v[i].y = m10 * num + m11 * num2 + m12 * num3 + m13;
							this.v[i].z = m20 * num + m21 * num2 + m22 * num3 + m23;
						}
					}
					else
					{
						for (int j = 0; j < this.vSize; j++)
						{
							float num = this.v[j].x;
							float num2 = this.v[j].y;
							float num3 = this.v[j].z + z;
							this.v[j].x = m00 * num + m01 * num2 + m02 * num3 + m03;
							this.v[j].y = m10 * num + m11 * num2 + m12 * num3 + m13;
							this.v[j].z = m20 * num + m21 * num2 + m22 * num3 + m23;
						}
					}
				}
				else if (z == 0f)
				{
					for (int k = 0; k < this.vSize; k++)
					{
						float num = this.v[k].x;
						float num2 = this.v[k].y + y;
						float num3 = this.v[k].z;
						this.v[k].x = m00 * num + m01 * num2 + m02 * num3 + m03;
						this.v[k].y = m10 * num + m11 * num2 + m12 * num3 + m13;
						this.v[k].z = m20 * num + m21 * num2 + m22 * num3 + m23;
					}
				}
				else
				{
					for (int l = 0; l < this.vSize; l++)
					{
						float num = this.v[l].x;
						float num2 = this.v[l].y + y;
						float num3 = this.v[l].z + z;
						this.v[l].x = m00 * num + m01 * num2 + m02 * num3 + m03;
						this.v[l].y = m10 * num + m11 * num2 + m12 * num3 + m13;
						this.v[l].z = m20 * num + m21 * num2 + m22 * num3 + m23;
					}
				}
			}
			else if (y == 0f)
			{
				if (z == 0f)
				{
					for (int n = 0; n < this.vSize; n++)
					{
						float num = this.v[n].x + x;
						float num2 = this.v[n].y;
						float num3 = this.v[n].z;
						this.v[n].x = m00 * num + m01 * num2 + m02 * num3 + m03;
						this.v[n].y = m10 * num + m11 * num2 + m12 * num3 + m13;
						this.v[n].z = m20 * num + m21 * num2 + m22 * num3 + m23;
					}
				}
				else
				{
					for (int num4 = 0; num4 < this.vSize; num4++)
					{
						float num = this.v[num4].x + x;
						float num2 = this.v[num4].y;
						float num3 = this.v[num4].z + z;
						this.v[num4].x = m00 * num + m01 * num2 + m02 * num3 + m03;
						this.v[num4].y = m10 * num + m11 * num2 + m12 * num3 + m13;
						this.v[num4].z = m20 * num + m21 * num2 + m22 * num3 + m23;
					}
				}
			}
			else if (z == 0f)
			{
				for (int num5 = 0; num5 < this.vSize; num5++)
				{
					float num = this.v[num5].x + x;
					float num2 = this.v[num5].y + y;
					float num3 = this.v[num5].z;
					this.v[num5].x = m00 * num + m01 * num2 + m02 * num3 + m03;
					this.v[num5].y = m10 * num + m11 * num2 + m12 * num3 + m13;
					this.v[num5].z = m20 * num + m21 * num2 + m22 * num3 + m23;
				}
			}
			else
			{
				for (int num6 = 0; num6 < this.vSize; num6++)
				{
					float num = this.v[num6].x + x;
					float num2 = this.v[num6].y + y;
					float num3 = this.v[num6].z + z;
					this.v[num6].x = m00 * num + m01 * num2 + m02 * num3 + m03;
					this.v[num6].y = m10 * num + m11 * num2 + m12 * num3 + m13;
					this.v[num6].z = m20 * num + m21 * num2 + m22 * num3 + m23;
				}
			}
		}

		// Token: 0x06004EF7 RID: 20215 RVA: 0x00131E3C File Offset: 0x0013003C
		public void TransformThenOffsetVertices(float m00, float m10, float m20, float m01, float m11, float m21, float m02, float m12, float m22, float m03, float m13, float m23, float x, float y, float z)
		{
			if (x == 0f)
			{
				if (y == 0f)
				{
					if (z == 0f)
					{
						for (int i = 0; i < this.vSize; i++)
						{
							float x2 = this.v[i].x;
							float y2 = this.v[i].y;
							float z2 = this.v[i].z;
							this.v[i].x = m00 * x2 + m01 * y2 + m02 * z2 + m03;
							this.v[i].y = m10 * x2 + m11 * y2 + m12 * z2 + m13;
							this.v[i].z = m20 * x2 + m21 * y2 + m22 * z2 + m23;
						}
					}
					else
					{
						for (int j = 0; j < this.vSize; j++)
						{
							float x2 = this.v[j].x;
							float y2 = this.v[j].y;
							float z2 = this.v[j].z;
							this.v[j].x = m00 * x2 + m01 * y2 + m02 * z2 + m03;
							this.v[j].y = m10 * x2 + m11 * y2 + m12 * z2 + m13;
							this.v[j].z = m20 * x2 + m21 * y2 + m22 * z2 + m23 + z;
						}
					}
				}
				else if (z == 0f)
				{
					for (int k = 0; k < this.vSize; k++)
					{
						float x2 = this.v[k].x;
						float y2 = this.v[k].y;
						float z2 = this.v[k].z;
						this.v[k].x = m00 * x2 + m01 * y2 + m02 * z2 + m03;
						this.v[k].y = m10 * x2 + m11 * y2 + m12 * z2 + m13 + y;
						this.v[k].z = m20 * x2 + m21 * y2 + m22 * z2 + m23;
					}
				}
				else
				{
					for (int l = 0; l < this.vSize; l++)
					{
						float x2 = this.v[l].x;
						float y2 = this.v[l].y;
						float z2 = this.v[l].z;
						this.v[l].x = m00 * x2 + m01 * y2 + m02 * z2 + m03;
						this.v[l].y = m10 * x2 + m11 * y2 + m12 * z2 + m13 + y;
						this.v[l].z = m20 * x2 + m21 * y2 + m22 * z2 + m23 + z;
					}
				}
			}
			else if (y == 0f)
			{
				if (z == 0f)
				{
					for (int n = 0; n < this.vSize; n++)
					{
						float x2 = this.v[n].x;
						float y2 = this.v[n].y;
						float z2 = this.v[n].z;
						this.v[n].x = m00 * x2 + m01 * y2 + m02 * z2 + m03 + x;
						this.v[n].y = m10 * x2 + m11 * y2 + m12 * z2 + m13;
						this.v[n].z = m20 * x2 + m21 * y2 + m22 * z2 + m23;
					}
				}
				else
				{
					for (int num = 0; num < this.vSize; num++)
					{
						float x2 = this.v[num].x;
						float y2 = this.v[num].y;
						float z2 = this.v[num].z;
						this.v[num].x = m00 * x2 + m01 * y2 + m02 * z2 + m03 + x;
						this.v[num].y = m10 * x2 + m11 * y2 + m12 * z2 + m13;
						this.v[num].z = m20 * x2 + m21 * y2 + m22 * z2 + m23 + z;
					}
				}
			}
			else if (z == 0f)
			{
				for (int num2 = 0; num2 < this.vSize; num2++)
				{
					float x2 = this.v[num2].x;
					float y2 = this.v[num2].y;
					float z2 = this.v[num2].z;
					this.v[num2].x = m00 * x2 + m01 * y2 + m02 * z2 + m03 + x;
					this.v[num2].y = m10 * x2 + m11 * y2 + m12 * z2 + m13 + y;
					this.v[num2].z = m20 * x2 + m21 * y2 + m22 * z2 + m23;
				}
			}
			else
			{
				for (int num3 = 0; num3 < this.vSize; num3++)
				{
					float x2 = this.v[num3].x;
					float y2 = this.v[num3].y;
					float z2 = this.v[num3].z;
					this.v[num3].x = m00 * x2 + m01 * y2 + m02 * z2 + m03 + x;
					this.v[num3].y = m10 * x2 + m11 * y2 + m12 * z2 + m13 + y;
					this.v[num3].z = m20 * x2 + m21 * y2 + m22 * z2 + m23 + z;
				}
			}
		}

		// Token: 0x06004EF8 RID: 20216 RVA: 0x001324AC File Offset: 0x001306AC
		public void Clear()
		{
			this.vSize = 0;
			this.iCount = 0;
			this.primSize = 0;
			this.lastPrimitiveKind = global::NGUI.Meshing.PrimitiveKind.Invalid;
		}

		// Token: 0x06004EF9 RID: 20217 RVA: 0x001324DC File Offset: 0x001306DC
		private static bool ZeroedXYScale(global::UnityEngine.Transform transform)
		{
			if (!transform)
			{
				return false;
			}
			global::UnityEngine.Vector3 localScale = transform.localScale;
			return localScale.x == 0f || localScale.y == 0f;
		}

		// Token: 0x06004EFA RID: 20218 RVA: 0x00132520 File Offset: 0x00130720
		private bool SeekPrimitiveIndex(int start, out int i)
		{
			for (i = this.primSize - 1; i >= 0; i--)
			{
				if ((int)this.primitives[i].start <= start)
				{
					return true;
				}
			}
			i = -1;
			return false;
		}

		// Token: 0x06004EFB RID: 20219 RVA: 0x00132560 File Offset: 0x00130760
		private void ApplyShadow(int start, int end, int primitiveIndex, float pixel, float r, float g, float b, float a)
		{
			while (start < end)
			{
				if (primitiveIndex != this.primSize - 1 && (int)this.primitives[primitiveIndex + 1].start <= start)
				{
					primitiveIndex++;
				}
				int num;
				int i = this.Alloc(this.primitives[primitiveIndex].kind, out num);
				if (i == num)
				{
					throw new global::System.InvalidOperationException();
				}
				while (i < num)
				{
					this.v[i++] = this.v[start];
					this.v[start].r = r;
					this.v[start].g = g;
					this.v[start].b = b;
					global::NGUI.Meshing.Vertex[] array = this.v;
					int num2 = start;
					array[num2].a = array[num2].a * a;
					global::NGUI.Meshing.Vertex[] array2 = this.v;
					int num3 = start;
					array2[num3].x = array2[num3].x + pixel;
					global::NGUI.Meshing.Vertex[] array3 = this.v;
					int num4 = start;
					array3[num4].y = array3[num4].y - pixel;
					start++;
				}
			}
		}

		// Token: 0x06004EFC RID: 20220 RVA: 0x0013268C File Offset: 0x0013088C
		private void ApplyOutline(int start, int end, int primitiveIndex, float pixel, float r, float g, float b, float a)
		{
			while (start < end)
			{
				if (primitiveIndex != this.primSize - 1 && (int)this.primitives[primitiveIndex + 1].start <= start)
				{
					primitiveIndex++;
				}
				int num2;
				int num = this.Alloc(this.primitives[primitiveIndex].kind, out num2);
				int num4;
				int num3 = this.Alloc(this.primitives[primitiveIndex].kind, out num4);
				int num6;
				int num5 = this.Alloc(this.primitives[primitiveIndex].kind, out num6);
				int num7;
				int i = this.Alloc(this.primitives[primitiveIndex].kind, out num7);
				if (i == num7)
				{
					throw new global::System.InvalidOperationException();
				}
				while (i < num7)
				{
					this.v[i] = this.v[start];
					this.v[start].r = r;
					this.v[start].g = g;
					this.v[start].b = b;
					global::NGUI.Meshing.Vertex[] array = this.v;
					int num8 = start;
					array[num8].a = array[num8].a * a;
					this.v[num] = (this.v[num3] = (this.v[num5] = this.v[start]));
					global::NGUI.Meshing.Vertex[] array2 = this.v;
					int num9 = start;
					array2[num9].x = array2[num9].x + pixel;
					global::NGUI.Meshing.Vertex[] array3 = this.v;
					int num10 = start;
					array3[num10].y = array3[num10].y - pixel;
					global::NGUI.Meshing.Vertex[] array4 = this.v;
					int num11 = num;
					array4[num11].x = array4[num11].x - pixel;
					global::NGUI.Meshing.Vertex[] array5 = this.v;
					int num12 = num;
					array5[num12].y = array5[num12].y + pixel;
					global::NGUI.Meshing.Vertex[] array6 = this.v;
					int num13 = num3;
					array6[num13].x = array6[num13].x + pixel;
					global::NGUI.Meshing.Vertex[] array7 = this.v;
					int num14 = num3;
					array7[num14].y = array7[num14].y + pixel;
					global::NGUI.Meshing.Vertex[] array8 = this.v;
					int num15 = num5;
					array8[num15].x = array8[num15].x - pixel;
					global::NGUI.Meshing.Vertex[] array9 = this.v;
					int num16 = num5;
					array9[num16].y = array9[num16].y - pixel;
					num++;
					num3++;
					num5++;
					i++;
					start++;
				}
			}
		}

		// Token: 0x06004EFD RID: 20221 RVA: 0x00132914 File Offset: 0x00130B14
		public void ApplyEffect(global::UnityEngine.Transform transform, int vertexStart, global::UILabel.Effect effect, global::UnityEngine.Color effectColor, float size)
		{
			this.ApplyEffect(transform, vertexStart, this.vSize, effect, effectColor, size);
		}

		// Token: 0x06004EFE RID: 20222 RVA: 0x0013292C File Offset: 0x00130B2C
		public void ApplyEffect(global::UnityEngine.Transform transform, int vertexStart, int vertexEnd, global::UILabel.Effect effect, global::UnityEngine.Color effectColor, float size)
		{
			int primitiveIndex;
			if (effect != global::UILabel.Effect.None && vertexStart != vertexEnd && !global::NGUITools.ZeroAlpha(effectColor.a) && size != 0f && !global::NGUI.Meshing.MeshBuffer.ZeroedXYScale(transform) && this.SeekPrimitiveIndex(vertexStart, out primitiveIndex))
			{
				float pixel = 1f / size;
				if (effect != global::UILabel.Effect.Shadow)
				{
					if (effect == global::UILabel.Effect.Outline)
					{
						this.ApplyOutline(vertexStart, vertexEnd, primitiveIndex, pixel, effectColor.r, effectColor.g, effectColor.b, effectColor.a);
					}
				}
				else
				{
					this.ApplyShadow(vertexStart, vertexEnd, primitiveIndex, pixel, effectColor.r, effectColor.g, effectColor.b, effectColor.a);
				}
			}
		}

		// Token: 0x06004EFF RID: 20223 RVA: 0x001329F4 File Offset: 0x00130BF4
		public void WriteBuffers(global::UnityEngine.Vector3[] transformedVertexes, global::NGUI.Meshing.MeshBuffer target)
		{
			if (transformedVertexes == null)
			{
				this.WriteBuffers(target);
			}
			else if (this.primSize > 0)
			{
				int num = 0;
				int i;
				for (i = 0; i < this.primSize - 1; i++)
				{
					this.primitives[i].Copy(ref num, this.v, transformedVertexes, (int)this.primitives[i + 1].start, target);
				}
				this.primitives[i].Copy(ref num, this.v, transformedVertexes, this.vSize, target);
			}
		}

		// Token: 0x06004F00 RID: 20224 RVA: 0x00132A8C File Offset: 0x00130C8C
		public void WriteBuffers(global::NGUI.Meshing.MeshBuffer target)
		{
			if (this.primSize > 0)
			{
				int num = 0;
				int i;
				for (i = 0; i < this.primSize - 1; i++)
				{
					this.primitives[i].Copy(ref num, this.v, (int)this.primitives[i + 1].start, target);
				}
				this.primitives[i].Copy(ref num, this.v, this.vSize, target);
			}
		}

		// Token: 0x04002B83 RID: 11139
		public global::NGUI.Meshing.Vertex[] v;

		// Token: 0x04002B84 RID: 11140
		public int vSize;

		// Token: 0x04002B85 RID: 11141
		public int iCount;

		// Token: 0x04002B86 RID: 11142
		private global::NGUI.Meshing.Primitive[] primitives;

		// Token: 0x04002B87 RID: 11143
		private int vertCapacity;

		// Token: 0x04002B88 RID: 11144
		private int primSize;

		// Token: 0x04002B89 RID: 11145
		private int primCapacity;

		// Token: 0x04002B8A RID: 11146
		private global::NGUI.Meshing.PrimitiveKind lastPrimitiveKind = global::NGUI.Meshing.PrimitiveKind.Invalid;

		// Token: 0x020008FF RID: 2303
		private struct FillBuffer<T>
		{
			// Token: 0x04002B8B RID: 11147
			public T[] buf;

			// Token: 0x04002B8C RID: 11148
			public int offset;
		}
	}
}
