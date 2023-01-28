using System;
using UnityEngine;

// Token: 0x020007B9 RID: 1977
public class GeometryMeshing
{
	// Token: 0x060041CC RID: 16844 RVA: 0x000EDAD0 File Offset: 0x000EBCD0
	public GeometryMeshing()
	{
	}

	// Token: 0x060041CD RID: 16845 RVA: 0x000EDAD8 File Offset: 0x000EBCD8
	public static global::GeometryMeshing.Mesh Sphere(global::GeometryMeshing.SphereInfo sphere)
	{
		global::UnityEngine.Debug.Log("TODO");
		return default(global::GeometryMeshing.Mesh);
	}

	// Token: 0x060041CE RID: 16846 RVA: 0x000EDAF8 File Offset: 0x000EBCF8
	public static global::GeometryMeshing.Mesh Capsule(global::GeometryMeshing.CapsuleInfo capsule)
	{
		if (capsule.height <= capsule.radius * 2f)
		{
			global::GeometryMeshing.SphereInfo sphere;
			sphere.offset = capsule.offset;
			sphere.radius = capsule.radius;
			sphere.capSplit = capsule.capSplit;
			sphere.sides = capsule.sides;
			return global::GeometryMeshing.Sphere(sphere);
		}
		bool flag = capsule.capSplit == 0;
		int num = (!flag) ? (capsule.capSplit - 1) : 0;
		int num2 = (!flag) ? (num * capsule.sides + 1) : 0;
		global::UnityEngine.Vector3[] array = new global::UnityEngine.Vector3[capsule.sides * 2 + ((!flag) ? (2 + num * capsule.sides * 2) : 0)];
		float num3 = capsule.offset.y - capsule.height / 2f;
		float y = num3 + capsule.radius;
		float num4 = capsule.offset.y + capsule.height / 2f;
		float y2 = num4 - capsule.radius;
		for (int i = 0; i < capsule.sides; i++)
		{
			float num5 = (float)i / ((float)capsule.sides / 2f) * 3.1415927f;
			int num6 = i + num2;
			int num7 = num6 + capsule.sides;
			array[num6].x = (array[num7].x = capsule.offset.x + global::UnityEngine.Mathf.Cos(num5) * capsule.radius);
			array[num6].z = (array[num7].z = capsule.offset.z + global::UnityEngine.Mathf.Sin(num5) * capsule.radius);
			array[num6].y = y;
			array[num7].y = y2;
		}
		if (!flag)
		{
			array[0] = new global::UnityEngine.Vector3(capsule.offset.x, num3, capsule.offset.z);
			array[array.Length - 1] = new global::UnityEngine.Vector3(capsule.offset.x, num4, capsule.offset.z);
		}
		int[] array2 = new int[3 * (((!flag) ? capsule.sides : (capsule.sides - 1)) * 2 + capsule.sides * 2)];
		int num8 = 0;
		if (flag)
		{
			for (int j = 1; j < capsule.sides; j++)
			{
				array2[num8++] = j + num2;
				array2[num8++] = (j + 1) % capsule.sides + num2;
				array2[num8++] = 0;
			}
			for (int k = 0; k < capsule.sides - 1; k++)
			{
				array2[num8++] = k + (num2 + capsule.sides);
				array2[num8++] = (k + 1) % capsule.sides + num2 + capsule.sides;
				array2[num8++] = array.Length - 1;
			}
		}
		else
		{
			for (int l = 0; l < capsule.sides; l++)
			{
				array2[num8++] = l + num2;
				array2[num8++] = (l + 1) % capsule.sides + num2;
				array2[num8++] = 0;
			}
			for (int m = 0; m < capsule.sides; m++)
			{
				array2[num8++] = m + (num2 + capsule.sides);
				array2[num8++] = array.Length - 1;
				array2[num8++] = (m + 1) % capsule.sides + (num2 + capsule.sides);
			}
		}
		for (int n = 0; n < capsule.sides; n++)
		{
			array2[num8++] = n + num2;
			array2[num8++] = n + num2 + capsule.sides;
			array2[num8++] = (n + 1) % capsule.sides + num2;
			array2[num8++] = n + num2 + capsule.sides;
			array2[num8++] = (n + 1) % capsule.sides + num2 + capsule.sides;
			array2[num8++] = (n + 1) % capsule.sides + num2;
		}
		return new global::GeometryMeshing.Mesh(array, array2, global::GeometryMeshing.IndexKind.Triangles);
	}

	// Token: 0x020007BA RID: 1978
	public enum IndexKind : sbyte
	{
		// Token: 0x0400226E RID: 8814
		Invalid,
		// Token: 0x0400226F RID: 8815
		Triangles,
		// Token: 0x04002270 RID: 8816
		TriangleStrip
	}

	// Token: 0x020007BB RID: 1979
	public struct Mesh
	{
		// Token: 0x060041CF RID: 16847 RVA: 0x000EDFA4 File Offset: 0x000EC1A4
		internal Mesh(global::UnityEngine.Vector3[] vertices, int[] indices, global::GeometryMeshing.IndexKind kind)
		{
			this.vertices = vertices;
			this.indices = indices;
			this.vertexCount = (ushort)this.vertices.Length;
			this.indexCount = (uint)this.indices.Length;
			this.indexKind = kind;
		}

		// Token: 0x17000C13 RID: 3091
		// (get) Token: 0x060041D0 RID: 16848 RVA: 0x000EDFE4 File Offset: 0x000EC1E4
		public bool valid
		{
			get
			{
				return (int)this.indexKind != 0;
			}
		}

		// Token: 0x04002271 RID: 8817
		public readonly global::UnityEngine.Vector3[] vertices;

		// Token: 0x04002272 RID: 8818
		public readonly int[] indices;

		// Token: 0x04002273 RID: 8819
		public readonly uint indexCount;

		// Token: 0x04002274 RID: 8820
		public readonly ushort vertexCount;

		// Token: 0x04002275 RID: 8821
		public readonly global::GeometryMeshing.IndexKind indexKind;
	}

	// Token: 0x020007BC RID: 1980
	public struct CapsuleInfo
	{
		// Token: 0x04002276 RID: 8822
		public global::UnityEngine.Vector3 offset;

		// Token: 0x04002277 RID: 8823
		public float height;

		// Token: 0x04002278 RID: 8824
		public float radius;

		// Token: 0x04002279 RID: 8825
		public int sides;

		// Token: 0x0400227A RID: 8826
		public int capSplit;
	}

	// Token: 0x020007BD RID: 1981
	public struct SphereInfo
	{
		// Token: 0x0400227B RID: 8827
		public global::UnityEngine.Vector3 offset;

		// Token: 0x0400227C RID: 8828
		public float radius;

		// Token: 0x0400227D RID: 8829
		public int sides;

		// Token: 0x0400227E RID: 8830
		public int capSplit;
	}
}
