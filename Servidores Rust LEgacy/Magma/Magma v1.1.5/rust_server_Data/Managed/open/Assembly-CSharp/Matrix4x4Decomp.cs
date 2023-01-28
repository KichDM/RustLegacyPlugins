using System;
using UnityEngine;

// Token: 0x02000474 RID: 1140
public struct Matrix4x4Decomp
{
	// Token: 0x0600281D RID: 10269 RVA: 0x00099564 File Offset: 0x00097764
	public Matrix4x4Decomp(global::UnityEngine.Matrix4x4 v)
	{
		this.r.x = v.m00;
		this.r.y = v.m01;
		this.r.z = v.m02;
		this.s.x = v.m03;
		this.u.x = v.m10;
		this.u.y = v.m11;
		this.u.z = v.m12;
		this.s.y = v.m13;
		this.f.x = v.m20;
		this.f.y = v.m21;
		this.f.z = v.m22;
		this.s.z = v.m23;
		this.t.x = v.m30;
		this.t.y = v.m31;
		this.t.z = v.m32;
		this.s.w = v.m33;
	}

	// Token: 0x170008E1 RID: 2273
	// (get) Token: 0x0600281E RID: 10270 RVA: 0x00099694 File Offset: 0x00097894
	// (set) Token: 0x0600281F RID: 10271 RVA: 0x000997C4 File Offset: 0x000979C4
	public global::UnityEngine.Matrix4x4 m
	{
		get
		{
			global::UnityEngine.Matrix4x4 result;
			result.m00 = this.r.x;
			result.m01 = this.r.y;
			result.m02 = this.r.z;
			result.m03 = this.s.x;
			result.m10 = this.u.x;
			result.m11 = this.u.y;
			result.m12 = this.u.z;
			result.m13 = this.s.y;
			result.m20 = this.f.x;
			result.m21 = this.f.y;
			result.m22 = this.f.z;
			result.m23 = this.s.z;
			result.m30 = this.t.x;
			result.m31 = this.t.y;
			result.m32 = this.t.z;
			result.m33 = this.s.w;
			return result;
		}
		set
		{
			this.r.x = value.m00;
			this.r.y = value.m01;
			this.r.z = value.m02;
			this.s.x = value.m03;
			this.u.x = value.m10;
			this.u.y = value.m11;
			this.u.z = value.m12;
			this.s.y = value.m13;
			this.f.x = value.m20;
			this.f.y = value.m21;
			this.f.z = value.m22;
			this.s.z = value.m23;
			this.t.x = value.m30;
			this.t.y = value.m31;
			this.t.z = value.m32;
			this.s.w = value.m33;
		}
	}

	// Token: 0x170008E2 RID: 2274
	// (get) Token: 0x06002820 RID: 10272 RVA: 0x000998F4 File Offset: 0x00097AF4
	// (set) Token: 0x06002821 RID: 10273 RVA: 0x00099908 File Offset: 0x00097B08
	public global::UnityEngine.Quaternion q
	{
		get
		{
			return global::UnityEngine.Quaternion.LookRotation(this.f, this.u);
		}
		set
		{
			global::UnityEngine.Quaternion quaternion = value * global::UnityEngine.Quaternion.Inverse(this.q);
			this.r = quaternion * this.r;
			this.u = quaternion * this.u;
			this.f = quaternion * this.f;
		}
	}

	// Token: 0x170008E3 RID: 2275
	// (get) Token: 0x06002822 RID: 10274 RVA: 0x00099960 File Offset: 0x00097B60
	// (set) Token: 0x06002823 RID: 10275 RVA: 0x000999A4 File Offset: 0x00097BA4
	public global::UnityEngine.Vector3 S
	{
		get
		{
			global::UnityEngine.Vector3 result;
			result.x = this.s.x;
			result.y = this.s.y;
			result.z = this.s.z;
			return result;
		}
		set
		{
			this.s.x = value.x;
			this.s.y = value.y;
			this.s.z = value.z;
		}
	}

	// Token: 0x170008E4 RID: 2276
	// (get) Token: 0x06002824 RID: 10276 RVA: 0x000999E8 File Offset: 0x00097BE8
	// (set) Token: 0x06002825 RID: 10277 RVA: 0x000999F8 File Offset: 0x00097BF8
	public float w
	{
		get
		{
			return this.s.w;
		}
		set
		{
			this.s.w = value;
		}
	}

	// Token: 0x040013E3 RID: 5091
	public global::UnityEngine.Vector3 r;

	// Token: 0x040013E4 RID: 5092
	public global::UnityEngine.Vector3 u;

	// Token: 0x040013E5 RID: 5093
	public global::UnityEngine.Vector3 f;

	// Token: 0x040013E6 RID: 5094
	public global::UnityEngine.Vector3 t;

	// Token: 0x040013E7 RID: 5095
	public global::UnityEngine.Vector4 s;
}
