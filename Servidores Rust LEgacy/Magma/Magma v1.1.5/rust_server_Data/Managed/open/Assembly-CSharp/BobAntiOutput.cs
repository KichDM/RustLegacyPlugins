using System;
using UnityEngine;

// Token: 0x020005E9 RID: 1513
[global::System.Serializable]
public class BobAntiOutput
{
	// Token: 0x060030FD RID: 12541 RVA: 0x000BA6EC File Offset: 0x000B88EC
	public BobAntiOutput()
	{
	}

	// Token: 0x060030FE RID: 12542 RVA: 0x000BA6F4 File Offset: 0x000B88F4
	private static global::UnityEngine.Vector3 GetVector3(ref global::UnityEngine.Vector3 v, global::BobAntiOutputAxes axes)
	{
		global::UnityEngine.Vector3 result;
		switch (axes & (global::BobAntiOutputAxes)3)
		{
		default:
			result.x = v.x;
			break;
		case (global::BobAntiOutputAxes)2:
			result.x = v.y;
			break;
		case (global::BobAntiOutputAxes)3:
			result.x = v.z;
			break;
		}
		switch ((axes & (global::BobAntiOutputAxes)0xC) >> 2)
		{
		case (global::BobAntiOutputAxes)1:
			result.y = v.x;
			goto IL_A9;
		case (global::BobAntiOutputAxes)3:
			result.y = v.z;
			goto IL_A9;
		}
		result.y = v.y;
		IL_A9:
		switch ((axes & (global::BobAntiOutputAxes)0x30) >> 4)
		{
		case (global::BobAntiOutputAxes)1:
			result.z = v.x;
			return result;
		case (global::BobAntiOutputAxes)2:
			result.z = v.y;
			return result;
		}
		result.z = v.z;
		return result;
	}

	// Token: 0x060030FF RID: 12543 RVA: 0x000BA804 File Offset: 0x000B8A04
	public global::UnityEngine.Vector3 Positional(global::UnityEngine.Vector3 v)
	{
		return global::UnityEngine.Vector3.Scale(global::BobAntiOutput.GetVector3(ref v, this.positionalAxes), this.positional);
	}

	// Token: 0x06003100 RID: 12544 RVA: 0x000BA820 File Offset: 0x000B8A20
	public global::UnityEngine.Vector3 Rotational(global::UnityEngine.Vector3 v)
	{
		return global::UnityEngine.Vector3.Scale(global::BobAntiOutput.GetVector3(ref v, this.rotationalAxes), this.rotational);
	}

	// Token: 0x06003101 RID: 12545 RVA: 0x000BA83C File Offset: 0x000B8A3C
	public void Add(global::UnityEngine.Transform transform, ref global::UnityEngine.Vector3 lp, ref global::UnityEngine.Vector3 lr)
	{
		if (!this.wasAdded)
		{
			this.lastPos = global::UnityEngine.Vector3.Scale(global::BobAntiOutput.GetVector3(ref lp, this.positionalAxes), this.positional);
			transform.localPosition = this.lastPos;
			this.lastRot = global::UnityEngine.Vector3.Scale(global::BobAntiOutput.GetVector3(ref lr, this.rotationalAxes), this.rotational);
			transform.localEulerAngles = this.lastRot;
			this.wasAdded = true;
		}
	}

	// Token: 0x06003102 RID: 12546 RVA: 0x000BA8B0 File Offset: 0x000B8AB0
	public void Subtract(global::UnityEngine.Transform transform)
	{
		if (this.wasAdded)
		{
			transform.localPosition -= this.lastPos;
			transform.localEulerAngles -= this.lastRot;
			this.wasAdded = false;
		}
	}

	// Token: 0x06003103 RID: 12547 RVA: 0x000BA900 File Offset: 0x000B8B00
	public void Reset()
	{
		this.wasAdded = false;
	}

	// Token: 0x04001B0C RID: 6924
	public global::BobAntiOutputAxes positionalAxes;

	// Token: 0x04001B0D RID: 6925
	public global::UnityEngine.Vector3 positional;

	// Token: 0x04001B0E RID: 6926
	public global::BobAntiOutputAxes rotationalAxes;

	// Token: 0x04001B0F RID: 6927
	public global::UnityEngine.Vector3 rotational;

	// Token: 0x04001B10 RID: 6928
	private bool wasAdded;

	// Token: 0x04001B11 RID: 6929
	private global::UnityEngine.Vector3 lastPos;

	// Token: 0x04001B12 RID: 6930
	private global::UnityEngine.Vector3 lastRot;
}
