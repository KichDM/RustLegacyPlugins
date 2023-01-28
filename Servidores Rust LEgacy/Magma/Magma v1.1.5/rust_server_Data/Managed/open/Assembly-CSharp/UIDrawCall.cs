using System;
using NGUI.Meshing;
using UnityEngine;

// Token: 0x020008EB RID: 2283
[global::UnityEngine.AddComponentMenu("NGUI/Internal/Draw Call")]
[global::UnityEngine.ExecuteInEditMode]
public class UIDrawCall : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004E60 RID: 20064 RVA: 0x0012DC04 File Offset: 0x0012BE04
	public UIDrawCall()
	{
	}

	// Token: 0x06004E61 RID: 20065 RVA: 0x0012DC1C File Offset: 0x0012BE1C
	// Note: this type is marked as 'beforefieldinit'.
	static UIDrawCall()
	{
	}

	// Token: 0x17000E7C RID: 3708
	// (get) Token: 0x06004E62 RID: 20066 RVA: 0x0012DC34 File Offset: 0x0012BE34
	// (set) Token: 0x06004E63 RID: 20067 RVA: 0x0012DC3C File Offset: 0x0012BE3C
	public bool depthPass
	{
		get
		{
			return this.mDepthPass;
		}
		set
		{
			if (this.mDepthPass != value)
			{
				this.mDepthPass = value;
				this.mReset = true;
			}
		}
	}

	// Token: 0x17000E7D RID: 3709
	// (get) Token: 0x06004E64 RID: 20068 RVA: 0x0012DC58 File Offset: 0x0012BE58
	public global::UnityEngine.Transform cachedTransform
	{
		get
		{
			if (this.mTrans == null)
			{
				this.mTrans = base.transform;
			}
			return this.mTrans;
		}
	}

	// Token: 0x17000E7E RID: 3710
	// (get) Token: 0x06004E65 RID: 20069 RVA: 0x0012DC80 File Offset: 0x0012BE80
	// (set) Token: 0x06004E66 RID: 20070 RVA: 0x0012DC88 File Offset: 0x0012BE88
	public global::UIMaterial material
	{
		get
		{
			return this.mSharedMat;
		}
		set
		{
			this.mSharedMat = value;
		}
	}

	// Token: 0x17000E7F RID: 3711
	// (get) Token: 0x06004E67 RID: 20071 RVA: 0x0012DC94 File Offset: 0x0012BE94
	public int triangles
	{
		get
		{
			global::UnityEngine.Mesh mesh = (!this.mEven) ? this.mMesh1 : this.mMesh0;
			return (!(mesh != null)) ? 0 : (mesh.vertexCount >> 1);
		}
	}

	// Token: 0x17000E80 RID: 3712
	// (get) Token: 0x06004E68 RID: 20072 RVA: 0x0012DCD8 File Offset: 0x0012BED8
	// (set) Token: 0x06004E69 RID: 20073 RVA: 0x0012DCE0 File Offset: 0x0012BEE0
	public global::UIDrawCall.Clipping clipping
	{
		get
		{
			return this.mClipping;
		}
		set
		{
			if (this.mClipping != value)
			{
				this.mClipping = value;
				this.mReset = true;
			}
		}
	}

	// Token: 0x17000E81 RID: 3713
	// (get) Token: 0x06004E6A RID: 20074 RVA: 0x0012DCFC File Offset: 0x0012BEFC
	// (set) Token: 0x06004E6B RID: 20075 RVA: 0x0012DD04 File Offset: 0x0012BF04
	public global::UnityEngine.Vector4 clipRange
	{
		get
		{
			return this.mClipRange;
		}
		set
		{
			this.mClipRange = value;
		}
	}

	// Token: 0x17000E82 RID: 3714
	// (get) Token: 0x06004E6C RID: 20076 RVA: 0x0012DD10 File Offset: 0x0012BF10
	// (set) Token: 0x06004E6D RID: 20077 RVA: 0x0012DD18 File Offset: 0x0012BF18
	public global::UnityEngine.Vector2 clipSoftness
	{
		get
		{
			return this.mClipSoft;
		}
		set
		{
			this.mClipSoft = value;
		}
	}

	// Token: 0x17000E83 RID: 3715
	// (get) Token: 0x06004E6E RID: 20078 RVA: 0x0012DD24 File Offset: 0x0012BF24
	// (set) Token: 0x06004E6F RID: 20079 RVA: 0x0012DD2C File Offset: 0x0012BF2C
	public global::UIPanelMaterialPropertyBlock panelPropertyBlock
	{
		get
		{
			return this.mPanelPropertyBlock;
		}
		set
		{
			this.mPanelPropertyBlock = value;
		}
	}

	// Token: 0x06004E70 RID: 20080 RVA: 0x0012DD38 File Offset: 0x0012BF38
	private global::UnityEngine.Mesh GetMesh(ref bool rebuildIndices, int vertexCount)
	{
		this.mEven = !this.mEven;
		if (this.mEven)
		{
			if (this.mMesh0 == null)
			{
				this.mMesh0 = new global::UnityEngine.Mesh();
				this.mMesh0.hideFlags = 4;
				rebuildIndices = true;
			}
			else if (rebuildIndices || this.mMesh0.vertexCount != vertexCount)
			{
				rebuildIndices = true;
				this.mMesh0.Clear();
			}
			return this.mMesh0;
		}
		if (this.mMesh1 == null)
		{
			this.mMesh1 = new global::UnityEngine.Mesh();
			this.mMesh1.hideFlags = 4;
			rebuildIndices = true;
		}
		else if (rebuildIndices || this.mMesh1.vertexCount != vertexCount)
		{
			rebuildIndices = true;
			this.mMesh1.Clear();
		}
		return this.mMesh1;
	}

	// Token: 0x06004E71 RID: 20081 RVA: 0x0012DE18 File Offset: 0x0012C018
	private void UpdateMaterials()
	{
		if (this.mDepthPass)
		{
			if (this.mDepthMat == null)
			{
				global::UnityEngine.Shader shader = global::UnityEngine.Shader.Find("Depth");
				this.mDepthMat = global::UIMaterial.Create(new global::UnityEngine.Material(shader)
				{
					hideFlags = 4,
					mainTexture = this.mSharedMat.mainTexture
				}, true, this.mClipping);
			}
		}
		else if (this.mDepthMat != null)
		{
			global::NGUITools.Destroy(this.mDepthMat);
			this.mDepthMat = null;
		}
		global::UnityEngine.Material material = this.mSharedMat[this.mClipping];
		if (this.mDepthMat != null)
		{
			global::UIDrawCall.materialBuffer2[0] = this.mDepthMat[this.mClipping];
			global::UIDrawCall.materialBuffer2[1] = material;
			this.mRen.sharedMaterials = global::UIDrawCall.materialBuffer2;
			global::UIDrawCall.materialBuffer2[0] = (global::UIDrawCall.materialBuffer2[1] = null);
		}
		else if (this.mRen.sharedMaterial != material)
		{
			global::UIDrawCall.materialBuffer1[0] = material;
			this.mRen.sharedMaterials = global::UIDrawCall.materialBuffer1;
			global::UIDrawCall.materialBuffer1[0] = null;
		}
	}

	// Token: 0x06004E72 RID: 20082 RVA: 0x0012DF48 File Offset: 0x0012C148
	public void Set(global::NGUI.Meshing.MeshBuffer m)
	{
		if (this.mFilter == null)
		{
			this.mFilter = base.gameObject.GetComponent<global::UnityEngine.MeshFilter>();
		}
		if (this.mFilter == null)
		{
			this.mFilter = base.gameObject.AddComponent<global::UnityEngine.MeshFilter>();
		}
		if (this.mRen == null)
		{
			this.mRen = base.gameObject.GetComponent<global::UnityEngine.MeshRenderer>();
		}
		if (this.mRen == null)
		{
			this.mRen = base.gameObject.AddComponent<global::UnityEngine.MeshRenderer>();
			this.UpdateMaterials();
		}
		if (m.vSize < 0xFDE8)
		{
			bool flag = m.ExtractMeshBuffers(ref this.mVerts, ref this.mUVs, ref this.mColors, ref this.mIndices);
			global::UnityEngine.Mesh mesh = this.GetMesh(ref flag, m.vSize);
			mesh.vertices = this.mVerts;
			mesh.uv = this.mUVs;
			mesh.colors = this.mColors;
			mesh.triangles = this.mIndices;
			mesh.RecalculateBounds();
			this.mFilter.mesh = mesh;
		}
		else
		{
			if (this.mFilter.mesh != null)
			{
				this.mFilter.mesh.Clear();
			}
			global::UnityEngine.Debug.LogError("Too many vertices on one panel: " + m.vSize);
		}
	}

	// Token: 0x06004E73 RID: 20083 RVA: 0x0012E0A8 File Offset: 0x0012C2A8
	private void OnWillRenderObject()
	{
		if (this.mReset)
		{
			this.mReset = false;
			this.UpdateMaterials();
		}
		if (this.mBlock == null)
		{
			this.mBlock = new global::UnityEngine.MaterialPropertyBlock();
		}
		else
		{
			this.mBlock.Clear();
		}
		if (this.mPanelPropertyBlock != null)
		{
			this.mPanelPropertyBlock.AddToMaterialPropertyBlock(this.mBlock);
		}
		if (this.mClipping != global::UIDrawCall.Clipping.None)
		{
			global::UnityEngine.Vector4 vector;
			vector.z = -this.mClipRange.x / this.mClipRange.z;
			vector.w = -this.mClipRange.y / this.mClipRange.w;
			vector.x = 1f / this.mClipRange.z;
			vector.y = 1f / this.mClipRange.w;
			this.mBlock.AddVector(global::UIDrawCall.FastProperties.kProp_ClippingRegion, vector);
			global::UnityEngine.Vector4 vector2;
			if (this.mClipSoft.x > 0f)
			{
				vector2.x = this.mClipRange.z / this.mClipSoft.x;
			}
			else
			{
				vector2.x = 1000f;
			}
			if (this.mClipSoft.y > 0f)
			{
				vector2.y = this.mClipRange.w / this.mClipSoft.y;
			}
			else
			{
				vector2.y = 1000f;
			}
			vector2.z = (vector2.w = 0f);
			this.mBlock.AddVector(global::UIDrawCall.FastProperties.kProp_ClipSharpness, vector2);
		}
		base.renderer.SetPropertyBlock(this.mBlock);
	}

	// Token: 0x06004E74 RID: 20084 RVA: 0x0012E25C File Offset: 0x0012C45C
	private void OnDestroy()
	{
		global::NGUITools.DestroyImmediate(this.mMesh0);
		global::NGUITools.DestroyImmediate(this.mMesh1);
		global::NGUITools.DestroyImmediate(this.mDepthMat);
	}

	// Token: 0x06004E75 RID: 20085 RVA: 0x0012E280 File Offset: 0x0012C480
	internal void LinkedList__Insert(ref global::UIDrawCall list)
	{
		this.mHasPrev = false;
		this.mHasNext = list;
		this.mNext = list;
		this.mPrev = null;
		if (this.mHasNext)
		{
			list.mHasPrev = true;
			list.mPrev = this;
		}
		list = this;
	}

	// Token: 0x06004E76 RID: 20086 RVA: 0x0012E2D0 File Offset: 0x0012C4D0
	internal void LinkedList__Remove()
	{
		if (this.mHasPrev)
		{
			this.mPrev.mHasNext = this.mHasNext;
			this.mPrev.mNext = this.mNext;
		}
		if (this.mHasNext)
		{
			this.mNext.mHasPrev = this.mHasPrev;
			this.mNext.mPrev = this.mPrev;
		}
		this.mHasNext = (this.mHasPrev = false);
		this.mNext = (this.mPrev = null);
	}

	// Token: 0x04002B23 RID: 11043
	private global::UnityEngine.Transform mTrans;

	// Token: 0x04002B24 RID: 11044
	private global::UIMaterial mSharedMat;

	// Token: 0x04002B25 RID: 11045
	private global::UnityEngine.Mesh mMesh0;

	// Token: 0x04002B26 RID: 11046
	private global::UnityEngine.Mesh mMesh1;

	// Token: 0x04002B27 RID: 11047
	private global::UnityEngine.MeshFilter mFilter;

	// Token: 0x04002B28 RID: 11048
	private global::UnityEngine.MeshRenderer mRen;

	// Token: 0x04002B29 RID: 11049
	private global::UIDrawCall.Clipping mClipping;

	// Token: 0x04002B2A RID: 11050
	private global::UnityEngine.Vector4 mClipRange;

	// Token: 0x04002B2B RID: 11051
	private global::UnityEngine.Vector2 mClipSoft;

	// Token: 0x04002B2C RID: 11052
	private global::UIMaterial mDepthMat;

	// Token: 0x04002B2D RID: 11053
	private int[] mIndices;

	// Token: 0x04002B2E RID: 11054
	private global::UnityEngine.Vector3[] mVerts;

	// Token: 0x04002B2F RID: 11055
	private global::UnityEngine.Vector2[] mUVs;

	// Token: 0x04002B30 RID: 11056
	private global::UnityEngine.Color[] mColors;

	// Token: 0x04002B31 RID: 11057
	private global::UIDrawCall mNext;

	// Token: 0x04002B32 RID: 11058
	private global::UIDrawCall mPrev;

	// Token: 0x04002B33 RID: 11059
	private bool mHasNext;

	// Token: 0x04002B34 RID: 11060
	private bool mHasPrev;

	// Token: 0x04002B35 RID: 11061
	private global::UIPanelMaterialPropertyBlock mPanelPropertyBlock;

	// Token: 0x04002B36 RID: 11062
	private global::UnityEngine.MaterialPropertyBlock mBlock;

	// Token: 0x04002B37 RID: 11063
	private bool mDepthPass;

	// Token: 0x04002B38 RID: 11064
	private bool mReset = true;

	// Token: 0x04002B39 RID: 11065
	private bool mEven = true;

	// Token: 0x04002B3A RID: 11066
	private static global::UnityEngine.Material[] materialBuffer2 = new global::UnityEngine.Material[2];

	// Token: 0x04002B3B RID: 11067
	private static global::UnityEngine.Material[] materialBuffer1 = new global::UnityEngine.Material[1];

	// Token: 0x020008EC RID: 2284
	public enum Clipping
	{
		// Token: 0x04002B3D RID: 11069
		None,
		// Token: 0x04002B3E RID: 11070
		HardClip,
		// Token: 0x04002B3F RID: 11071
		AlphaClip,
		// Token: 0x04002B40 RID: 11072
		SoftClip
	}

	// Token: 0x020008ED RID: 2285
	public struct Iterator
	{
		// Token: 0x17000E84 RID: 3716
		// (get) Token: 0x06004E77 RID: 20087 RVA: 0x0012E358 File Offset: 0x0012C558
		public global::UIDrawCall.Iterator Next
		{
			get
			{
				if (this.Has)
				{
					global::UIDrawCall.Iterator result;
					result.Has = this.Current.mHasNext;
					result.Current = this.Current.mNext;
					return result;
				}
				return default(global::UIDrawCall.Iterator);
			}
		}

		// Token: 0x17000E85 RID: 3717
		// (get) Token: 0x06004E78 RID: 20088 RVA: 0x0012E3A0 File Offset: 0x0012C5A0
		public global::UIDrawCall.Iterator Prev
		{
			get
			{
				if (this.Has)
				{
					global::UIDrawCall.Iterator result;
					result.Has = this.Current.mHasPrev;
					result.Current = this.Current.mPrev;
					return result;
				}
				return default(global::UIDrawCall.Iterator);
			}
		}

		// Token: 0x06004E79 RID: 20089 RVA: 0x0012E3E8 File Offset: 0x0012C5E8
		public static explicit operator global::UIDrawCall.Iterator(global::UIDrawCall call)
		{
			global::UIDrawCall.Iterator result;
			result.Has = call;
			if (result.Has)
			{
				result.Current = call;
			}
			else
			{
				result.Current = null;
			}
			return result;
		}

		// Token: 0x04002B41 RID: 11073
		public global::UIDrawCall Current;

		// Token: 0x04002B42 RID: 11074
		public bool Has;
	}

	// Token: 0x020008EE RID: 2286
	private static class FastProperties
	{
		// Token: 0x06004E7A RID: 20090 RVA: 0x0012E424 File Offset: 0x0012C624
		static FastProperties()
		{
		}

		// Token: 0x04002B43 RID: 11075
		public static readonly int kProp_ClippingRegion = global::UnityEngine.Shader.PropertyToID("_MainTex_ST");

		// Token: 0x04002B44 RID: 11076
		public static readonly int kProp_ClipSharpness = global::UnityEngine.Shader.PropertyToID("_ClipSharpness");
	}
}
