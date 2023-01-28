using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200082C RID: 2092
public class dfRenderData : global::System.IDisposable
{
	// Token: 0x06004734 RID: 18228 RVA: 0x00106D28 File Offset: 0x00104F28
	internal dfRenderData(int capacity = 0x20)
	{
		this.Vertices = new global::dfList<global::UnityEngine.Vector3>(capacity);
		this.Triangles = new global::dfList<int>(capacity);
		this.Normals = new global::dfList<global::UnityEngine.Vector3>(capacity);
		this.Tangents = new global::dfList<global::UnityEngine.Vector4>(capacity);
		this.UV = new global::dfList<global::UnityEngine.Vector2>(capacity);
		this.Colors = new global::dfList<global::UnityEngine.Color32>(capacity);
		this.Transform = global::UnityEngine.Matrix4x4.identity;
	}

	// Token: 0x06004735 RID: 18229 RVA: 0x00106D90 File Offset: 0x00104F90
	// Note: this type is marked as 'beforefieldinit'.
	static dfRenderData()
	{
	}

	// Token: 0x17000D48 RID: 3400
	// (get) Token: 0x06004736 RID: 18230 RVA: 0x00106D9C File Offset: 0x00104F9C
	// (set) Token: 0x06004737 RID: 18231 RVA: 0x00106DA4 File Offset: 0x00104FA4
	public global::UnityEngine.Material Material
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Material>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<Material>k__BackingField = value;
		}
	}

	// Token: 0x17000D49 RID: 3401
	// (get) Token: 0x06004738 RID: 18232 RVA: 0x00106DB0 File Offset: 0x00104FB0
	// (set) Token: 0x06004739 RID: 18233 RVA: 0x00106DB8 File Offset: 0x00104FB8
	public global::UnityEngine.Shader Shader
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Shader>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<Shader>k__BackingField = value;
		}
	}

	// Token: 0x17000D4A RID: 3402
	// (get) Token: 0x0600473A RID: 18234 RVA: 0x00106DC4 File Offset: 0x00104FC4
	// (set) Token: 0x0600473B RID: 18235 RVA: 0x00106DCC File Offset: 0x00104FCC
	public global::UnityEngine.Matrix4x4 Transform
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Transform>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<Transform>k__BackingField = value;
		}
	}

	// Token: 0x17000D4B RID: 3403
	// (get) Token: 0x0600473C RID: 18236 RVA: 0x00106DD8 File Offset: 0x00104FD8
	// (set) Token: 0x0600473D RID: 18237 RVA: 0x00106DE0 File Offset: 0x00104FE0
	public global::dfList<global::UnityEngine.Vector3> Vertices
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Vertices>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<Vertices>k__BackingField = value;
		}
	}

	// Token: 0x17000D4C RID: 3404
	// (get) Token: 0x0600473E RID: 18238 RVA: 0x00106DEC File Offset: 0x00104FEC
	// (set) Token: 0x0600473F RID: 18239 RVA: 0x00106DF4 File Offset: 0x00104FF4
	public global::dfList<global::UnityEngine.Vector2> UV
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<UV>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<UV>k__BackingField = value;
		}
	}

	// Token: 0x17000D4D RID: 3405
	// (get) Token: 0x06004740 RID: 18240 RVA: 0x00106E00 File Offset: 0x00105000
	// (set) Token: 0x06004741 RID: 18241 RVA: 0x00106E08 File Offset: 0x00105008
	public global::dfList<global::UnityEngine.Vector3> Normals
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Normals>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<Normals>k__BackingField = value;
		}
	}

	// Token: 0x17000D4E RID: 3406
	// (get) Token: 0x06004742 RID: 18242 RVA: 0x00106E14 File Offset: 0x00105014
	// (set) Token: 0x06004743 RID: 18243 RVA: 0x00106E1C File Offset: 0x0010501C
	public global::dfList<global::UnityEngine.Vector4> Tangents
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Tangents>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<Tangents>k__BackingField = value;
		}
	}

	// Token: 0x17000D4F RID: 3407
	// (get) Token: 0x06004744 RID: 18244 RVA: 0x00106E28 File Offset: 0x00105028
	// (set) Token: 0x06004745 RID: 18245 RVA: 0x00106E30 File Offset: 0x00105030
	public global::dfList<int> Triangles
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Triangles>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<Triangles>k__BackingField = value;
		}
	}

	// Token: 0x17000D50 RID: 3408
	// (get) Token: 0x06004746 RID: 18246 RVA: 0x00106E3C File Offset: 0x0010503C
	// (set) Token: 0x06004747 RID: 18247 RVA: 0x00106E44 File Offset: 0x00105044
	public global::dfList<global::UnityEngine.Color32> Colors
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Colors>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<Colors>k__BackingField = value;
		}
	}

	// Token: 0x17000D51 RID: 3409
	// (get) Token: 0x06004748 RID: 18248 RVA: 0x00106E50 File Offset: 0x00105050
	// (set) Token: 0x06004749 RID: 18249 RVA: 0x00106E58 File Offset: 0x00105058
	public uint Checksum
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Checksum>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<Checksum>k__BackingField = value;
		}
	}

	// Token: 0x17000D52 RID: 3410
	// (get) Token: 0x0600474A RID: 18250 RVA: 0x00106E64 File Offset: 0x00105064
	// (set) Token: 0x0600474B RID: 18251 RVA: 0x00106E6C File Offset: 0x0010506C
	public global::dfIntersectionType Intersection
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Intersection>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<Intersection>k__BackingField = value;
		}
	}

	// Token: 0x0600474C RID: 18252 RVA: 0x00106E78 File Offset: 0x00105078
	public static global::dfRenderData Obtain()
	{
		return (global::dfRenderData.pool.Count <= 0) ? new global::dfRenderData(0x20) : global::dfRenderData.pool.Dequeue();
	}

	// Token: 0x0600474D RID: 18253 RVA: 0x00106EAC File Offset: 0x001050AC
	public static void FlushObjectPool()
	{
		while (global::dfRenderData.pool.Count > 0)
		{
			global::dfRenderData dfRenderData = global::dfRenderData.pool.Dequeue();
			dfRenderData.Vertices.TrimExcess();
			dfRenderData.Triangles.TrimExcess();
			dfRenderData.UV.TrimExcess();
			dfRenderData.Colors.TrimExcess();
		}
	}

	// Token: 0x0600474E RID: 18254 RVA: 0x00106F08 File Offset: 0x00105108
	public void Release()
	{
		this.Clear();
		global::dfRenderData.pool.Enqueue(this);
	}

	// Token: 0x0600474F RID: 18255 RVA: 0x00106F1C File Offset: 0x0010511C
	public void Clear()
	{
		this.Material = null;
		this.Shader = null;
		this.Transform = global::UnityEngine.Matrix4x4.identity;
		this.Checksum = 0U;
		this.Intersection = global::dfIntersectionType.None;
		this.Vertices.Clear();
		this.UV.Clear();
		this.Triangles.Clear();
		this.Colors.Clear();
		this.Normals.Clear();
		this.Tangents.Clear();
	}

	// Token: 0x06004750 RID: 18256 RVA: 0x00106F94 File Offset: 0x00105194
	public bool IsValid()
	{
		int count = this.Vertices.Count;
		return count > 0 && count <= 0xFDE8 && this.UV.Count == count && this.Colors.Count == count;
	}

	// Token: 0x06004751 RID: 18257 RVA: 0x00106FE4 File Offset: 0x001051E4
	public void EnsureCapacity(int capacity)
	{
		this.Vertices.EnsureCapacity(capacity);
		this.Triangles.EnsureCapacity(capacity);
		this.UV.EnsureCapacity(capacity);
		this.Colors.EnsureCapacity(capacity);
	}

	// Token: 0x06004752 RID: 18258 RVA: 0x00107024 File Offset: 0x00105224
	public void Merge(global::dfRenderData buffer, bool transformVertices = true)
	{
		int count = this.Vertices.Count;
		this.Vertices.EnsureCapacity(this.Vertices.Count + buffer.Vertices.Count);
		if (transformVertices)
		{
			for (int i = 0; i < buffer.Vertices.Count; i++)
			{
				this.Vertices.Add(buffer.Transform.MultiplyPoint(buffer.Vertices[i]));
			}
		}
		else
		{
			this.Vertices.AddRange(buffer.Vertices);
		}
		this.UV.AddRange(buffer.UV);
		this.Colors.AddRange(buffer.Colors);
		this.Normals.AddRange(buffer.Normals);
		this.Tangents.AddRange(buffer.Tangents);
		this.Triangles.EnsureCapacity(this.Triangles.Count + buffer.Triangles.Count);
		for (int j = 0; j < buffer.Triangles.Count; j++)
		{
			this.Triangles.Add(buffer.Triangles[j] + count);
		}
	}

	// Token: 0x06004753 RID: 18259 RVA: 0x00107158 File Offset: 0x00105358
	internal void ApplyTransform(global::UnityEngine.Matrix4x4 transform)
	{
		for (int i = 0; i < this.Vertices.Count; i++)
		{
			this.Vertices[i] = transform.MultiplyPoint(this.Vertices[i]);
		}
		if (this.Normals.Count > 0)
		{
			for (int j = 0; j < this.Vertices.Count; j++)
			{
				this.Normals[j] = transform.MultiplyVector(this.Normals[j]);
			}
		}
	}

	// Token: 0x06004754 RID: 18260 RVA: 0x001071EC File Offset: 0x001053EC
	public override string ToString()
	{
		return string.Format("V:{0} T:{1} U:{2} C:{3}", new object[]
		{
			this.Vertices.Count,
			this.Triangles.Count,
			this.UV.Count,
			this.Colors.Count
		});
	}

	// Token: 0x06004755 RID: 18261 RVA: 0x00107258 File Offset: 0x00105458
	public void Dispose()
	{
		this.Release();
	}

	// Token: 0x04002655 RID: 9813
	private static global::System.Collections.Generic.Queue<global::dfRenderData> pool = new global::System.Collections.Generic.Queue<global::dfRenderData>();

	// Token: 0x04002656 RID: 9814
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.Material <Material>k__BackingField;

	// Token: 0x04002657 RID: 9815
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.Shader <Shader>k__BackingField;

	// Token: 0x04002658 RID: 9816
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.Matrix4x4 <Transform>k__BackingField;

	// Token: 0x04002659 RID: 9817
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::dfList<global::UnityEngine.Vector3> <Vertices>k__BackingField;

	// Token: 0x0400265A RID: 9818
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::dfList<global::UnityEngine.Vector2> <UV>k__BackingField;

	// Token: 0x0400265B RID: 9819
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::dfList<global::UnityEngine.Vector3> <Normals>k__BackingField;

	// Token: 0x0400265C RID: 9820
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::dfList<global::UnityEngine.Vector4> <Tangents>k__BackingField;

	// Token: 0x0400265D RID: 9821
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::dfList<int> <Triangles>k__BackingField;

	// Token: 0x0400265E RID: 9822
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::dfList<global::UnityEngine.Color32> <Colors>k__BackingField;

	// Token: 0x0400265F RID: 9823
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private uint <Checksum>k__BackingField;

	// Token: 0x04002660 RID: 9824
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::dfIntersectionType <Intersection>k__BackingField;
}
