using System;
using Facepunch.Precision;
using UnityEngine;

// Token: 0x020005EA RID: 1514
[global::System.Serializable]
public class BobForceCurve
{
	// Token: 0x06003104 RID: 12548 RVA: 0x000BA90C File Offset: 0x000B8B0C
	public BobForceCurve()
	{
	}

	// Token: 0x06003105 RID: 12549 RVA: 0x000BA92C File Offset: 0x000B8B2C
	private void Gasp()
	{
		this.infoX = new global::BobForceCurve.CurveInfo(this.forceX);
		this.infoY = new global::BobForceCurve.CurveInfo(this.forceY);
		this.infoZ = new global::BobForceCurve.CurveInfo(this.forceZ);
		this.calc = (this.infoX.calc || this.infoY.calc || this.infoZ.calc);
		int length = this.sourceMask.length;
		bool flag;
		if (length == 1)
		{
			if (this.sourceMask[0].value == 1f)
			{
				flag = false;
			}
			else if (this.sourceMask[0].value == 0f)
			{
				this.calc = false;
				flag = false;
			}
			else
			{
				flag = true;
			}
		}
		else
		{
			flag = (length != 0);
		}
		length = this.sourceScale.length;
		bool flag2;
		bool flag3;
		if (length == 1)
		{
			flag2 = (this.sourceScale[0].value != 1f);
			flag3 = (this.sourceScale[0].value == 0f);
		}
		else if (length == 0)
		{
			flag2 = false;
			flag3 = false;
		}
		else
		{
			flag2 = true;
			flag3 = false;
		}
		this.mask = flag;
		this.scale = flag2;
		this.scaleFixed = flag3;
		this.once = true;
	}

	// Token: 0x06003106 RID: 12550 RVA: 0x000BAAB4 File Offset: 0x000B8CB4
	public void Calculate(ref global::Facepunch.Precision.Vector3G v, ref double pow, ref double dt, ref global::Facepunch.Precision.Vector3G sum)
	{
		if (!this.once)
		{
			this.Gasp();
		}
		if (!this.calc)
		{
			return;
		}
		float num = (!this.mask) ? 1f : this.sourceMask.Evaluate((float)pow);
		bool flag = num == 0f || num == --0f;
		float num2 = (!this.scaleFixed) ? ((!this.scale) ? 1f : this.sourceScale.Evaluate((float)pow)) : 0f;
		bool flag2 = !this.scaleFixed && num2 != 0f && num2 != --0f;
		global::Facepunch.Precision.Vector3G vector3G;
		if (this.infoX.calc)
		{
			if (flag2 && !this.infoX.constant)
			{
				v.x += pow * dt * (double)num2 * (double)this.positionScale.x;
				if (v.x > (double)this.infoX.duration)
				{
					v.x -= (double)this.infoX.duration;
				}
				else if (v.x < (double)(-(double)this.infoX.duration))
				{
					v.x += (double)this.infoX.duration;
				}
			}
			vector3G.x = (double)((!flag) ? (this.forceX.Evaluate((float)v.x) * this.outputScale.x) : 0f);
		}
		else
		{
			vector3G.x = 0.0;
		}
		if (this.infoY.calc)
		{
			if (flag2 && !this.infoY.constant)
			{
				v.y += pow * dt * (double)num2 * (double)this.positionScale.y;
				if (v.y > (double)this.infoY.duration)
				{
					v.y -= (double)this.infoY.duration;
				}
				else if (v.y < (double)(-(double)this.infoY.duration))
				{
					v.y += (double)this.infoY.duration;
				}
			}
			vector3G.y = (double)((!flag) ? (this.forceY.Evaluate((float)v.y) * this.outputScale.y) : 0f);
		}
		else
		{
			vector3G.y = 0.0;
		}
		if (this.infoZ.calc)
		{
			if (flag2 && !this.infoZ.constant)
			{
				v.z += pow * dt * (double)num2 * (double)this.positionScale.z;
				if (v.z > (double)this.infoZ.duration)
				{
					v.z -= (double)this.infoZ.duration;
				}
				else if (v.z < (double)(-(double)this.infoZ.duration))
				{
					v.z += (double)this.infoZ.duration;
				}
			}
			vector3G.z = (double)((!flag) ? (this.forceZ.Evaluate((float)v.z) * this.outputScale.z) : 0f);
		}
		else
		{
			vector3G.z = 0.0;
		}
		if (!flag)
		{
			sum.x += vector3G.x * (double)num;
			sum.y += vector3G.y * (double)num;
			sum.z += vector3G.z * (double)num;
		}
	}

	// Token: 0x04001B13 RID: 6931
	public global::UnityEngine.Vector3 positionScale = global::UnityEngine.Vector3.one;

	// Token: 0x04001B14 RID: 6932
	public global::UnityEngine.AnimationCurve forceX;

	// Token: 0x04001B15 RID: 6933
	public global::UnityEngine.AnimationCurve forceY;

	// Token: 0x04001B16 RID: 6934
	public global::UnityEngine.AnimationCurve forceZ;

	// Token: 0x04001B17 RID: 6935
	public global::UnityEngine.Vector3 outputScale = global::UnityEngine.Vector3.one;

	// Token: 0x04001B18 RID: 6936
	public global::UnityEngine.AnimationCurve sourceMask;

	// Token: 0x04001B19 RID: 6937
	public global::UnityEngine.AnimationCurve sourceScale;

	// Token: 0x04001B1A RID: 6938
	private float duration;

	// Token: 0x04001B1B RID: 6939
	private float offset;

	// Token: 0x04001B1C RID: 6940
	private global::BobForceCurve.CurveInfo infoX;

	// Token: 0x04001B1D RID: 6941
	private global::BobForceCurve.CurveInfo infoY;

	// Token: 0x04001B1E RID: 6942
	private global::BobForceCurve.CurveInfo infoZ;

	// Token: 0x04001B1F RID: 6943
	private bool once;

	// Token: 0x04001B20 RID: 6944
	private bool calc;

	// Token: 0x04001B21 RID: 6945
	private bool mask;

	// Token: 0x04001B22 RID: 6946
	private bool scale;

	// Token: 0x04001B23 RID: 6947
	private bool scaleFixed;

	// Token: 0x04001B24 RID: 6948
	public global::BobForceCurveTarget target;

	// Token: 0x04001B25 RID: 6949
	public global::BobForceCurveSource source;

	// Token: 0x020005EB RID: 1515
	private struct CurveInfo
	{
		// Token: 0x06003107 RID: 12551 RVA: 0x000BAEB4 File Offset: 0x000B90B4
		public CurveInfo(global::UnityEngine.AnimationCurve curve)
		{
			int num = (curve != null) ? curve.length : 0;
			if (num == 0)
			{
				this.calc = false;
				this.constant = true;
				this.duration = 0f;
				this.offset = 0f;
			}
			else if (num == 1)
			{
				this.calc = (curve[0].value != 0f);
				this.constant = true;
				this.duration = 0f;
				this.offset = 0f;
			}
			else
			{
				global::UnityEngine.Keyframe keyframe = curve[0];
				global::UnityEngine.Keyframe keyframe2 = curve[num - 1];
				this.calc = true;
				this.constant = false;
				this.duration = keyframe2.time - keyframe.time;
				this.offset = curve[0].time;
				this.duration *= 8f;
			}
		}

		// Token: 0x04001B26 RID: 6950
		public float duration;

		// Token: 0x04001B27 RID: 6951
		public float offset;

		// Token: 0x04001B28 RID: 6952
		public bool calc;

		// Token: 0x04001B29 RID: 6953
		public bool constant;
	}
}
