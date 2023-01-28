using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000861 RID: 2145
public class dfMarkupBoxTexture : global::dfMarkupBox
{
	// Token: 0x06004A6F RID: 19055 RVA: 0x00117A38 File Offset: 0x00115C38
	public dfMarkupBoxTexture(global::dfMarkupElement element, global::dfMarkupDisplayType display, global::dfMarkupStyle style) : base(element, display, style)
	{
	}

	// Token: 0x06004A70 RID: 19056 RVA: 0x00117A50 File Offset: 0x00115C50
	// Note: this type is marked as 'beforefieldinit'.
	static dfMarkupBoxTexture()
	{
	}

	// Token: 0x17000DF0 RID: 3568
	// (get) Token: 0x06004A71 RID: 19057 RVA: 0x00117A68 File Offset: 0x00115C68
	// (set) Token: 0x06004A72 RID: 19058 RVA: 0x00117A70 File Offset: 0x00115C70
	public global::UnityEngine.Texture Texture
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Texture>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<Texture>k__BackingField = value;
		}
	}

	// Token: 0x06004A73 RID: 19059 RVA: 0x00117A7C File Offset: 0x00115C7C
	internal void LoadTexture(global::UnityEngine.Texture texture)
	{
		if (texture == null)
		{
			throw new global::System.InvalidOperationException();
		}
		this.Texture = texture;
		this.Size = new global::UnityEngine.Vector2((float)texture.width, (float)texture.height);
		this.Baseline = (int)this.Size.y;
	}

	// Token: 0x06004A74 RID: 19060 RVA: 0x00117AD0 File Offset: 0x00115CD0
	protected override global::dfRenderData OnRebuildRenderData()
	{
		this.renderData.Clear();
		this.ensureMaterial();
		this.renderData.Material = this.material;
		this.renderData.Material.mainTexture = this.Texture;
		global::UnityEngine.Vector3 zero = global::UnityEngine.Vector3.zero;
		global::UnityEngine.Vector3 vector = zero + global::UnityEngine.Vector3.right * this.Size.x;
		global::UnityEngine.Vector3 item = vector + global::UnityEngine.Vector3.down * this.Size.y;
		global::UnityEngine.Vector3 item2 = zero + global::UnityEngine.Vector3.down * this.Size.y;
		this.renderData.Vertices.Add(zero);
		this.renderData.Vertices.Add(vector);
		this.renderData.Vertices.Add(item);
		this.renderData.Vertices.Add(item2);
		this.renderData.Triangles.AddRange(global::dfMarkupBoxTexture.TRIANGLE_INDICES);
		this.renderData.UV.Add(new global::UnityEngine.Vector2(0f, 1f));
		this.renderData.UV.Add(new global::UnityEngine.Vector2(1f, 1f));
		this.renderData.UV.Add(new global::UnityEngine.Vector2(1f, 0f));
		this.renderData.UV.Add(new global::UnityEngine.Vector2(0f, 0f));
		global::UnityEngine.Color color = this.Style.Color;
		this.renderData.Colors.Add(color);
		this.renderData.Colors.Add(color);
		this.renderData.Colors.Add(color);
		this.renderData.Colors.Add(color);
		return this.renderData;
	}

	// Token: 0x06004A75 RID: 19061 RVA: 0x00117CB4 File Offset: 0x00115EB4
	private void ensureMaterial()
	{
		if (this.material != null || this.Texture == null)
		{
			return;
		}
		global::UnityEngine.Shader shader = global::UnityEngine.Shader.Find("Daikon Forge/Default UI Shader");
		if (shader == null)
		{
			global::UnityEngine.Debug.LogError("Failed to find default shader");
			return;
		}
		this.material = new global::UnityEngine.Material(shader)
		{
			name = "Default Texture Shader",
			hideFlags = 4,
			mainTexture = this.Texture
		};
	}

	// Token: 0x06004A76 RID: 19062 RVA: 0x00117D34 File Offset: 0x00115F34
	private static void addTriangleIndices(global::dfList<global::UnityEngine.Vector3> verts, global::dfList<int> triangles)
	{
		int count = verts.Count;
		int[] triangle_INDICES = global::dfMarkupBoxTexture.TRIANGLE_INDICES;
		for (int i = 0; i < triangle_INDICES.Length; i++)
		{
			triangles.Add(count + triangle_INDICES[i]);
		}
	}

	// Token: 0x040027A3 RID: 10147
	private static int[] TRIANGLE_INDICES = new int[]
	{
		0,
		1,
		2,
		0,
		2,
		3
	};

	// Token: 0x040027A4 RID: 10148
	private global::dfRenderData renderData = new global::dfRenderData(0x20);

	// Token: 0x040027A5 RID: 10149
	private global::UnityEngine.Material material;

	// Token: 0x040027A6 RID: 10150
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.Texture <Texture>k__BackingField;
}
