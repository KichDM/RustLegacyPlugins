using System;
using UnityEngine;

// Token: 0x0200029A RID: 666
public class BobPunchEffect : global::BobEffect
{
	// Token: 0x060017B7 RID: 6071 RVA: 0x00058440 File Offset: 0x00056640
	public BobPunchEffect()
	{
	}

	// Token: 0x060017B8 RID: 6072 RVA: 0x00058448 File Offset: 0x00056648
	protected override void InitializeNonSerializedData()
	{
		this.x = new global::BobPunchEffect.CurveInfo(this._x);
		this.y = new global::BobPunchEffect.CurveInfo(this._y);
		this.z = new global::BobPunchEffect.CurveInfo(this._z);
		this.yaw = new global::BobPunchEffect.CurveInfo(this._yaw);
		this.pitch = new global::BobPunchEffect.CurveInfo(this._pitch);
		this.roll = new global::BobPunchEffect.CurveInfo(this._roll);
		this.glob.valid = (this.x.valid || this.y.valid || this.z.valid || this.yaw.valid || this.pitch.valid || this.roll.valid);
		this.glob.constant = (this.glob.valid && ((!this.x.valid || this.x.constant) && (!this.y.valid || this.y.constant) && (!this.z.valid || this.z.constant) && (!this.yaw.valid || this.yaw.constant) && (!this.pitch.valid || this.pitch.constant) && (!this.roll.valid || this.roll.constant)));
		if (this.glob.constant)
		{
			this.glob.valid = false;
			this.glob.startTime = 0f;
			this.glob.endTime = 0f;
			this.glob.duration = 0f;
		}
		else
		{
			this.glob.startTime = float.PositiveInfinity;
			this.glob.endTime = float.NegativeInfinity;
			if (this.x.valid && !this.x.constant)
			{
				if (this.x.startTime < this.glob.startTime)
				{
					this.glob.startTime = this.x.startTime;
				}
				if (this.x.endTime > this.glob.endTime)
				{
					this.glob.endTime = this.x.endTime;
				}
			}
			if (this.z.valid && !this.z.constant)
			{
				if (this.z.startTime < this.glob.startTime)
				{
					this.glob.startTime = this.z.startTime;
				}
				if (this.z.endTime > this.glob.endTime)
				{
					this.glob.endTime = this.z.endTime;
				}
			}
			if (this.yaw.valid && !this.yaw.constant)
			{
				if (this.yaw.startTime < this.glob.startTime)
				{
					this.glob.startTime = this.yaw.startTime;
				}
				if (this.yaw.endTime > this.glob.endTime)
				{
					this.glob.endTime = this.yaw.endTime;
				}
			}
			if (this.pitch.valid && !this.pitch.constant)
			{
				if (this.pitch.startTime < this.glob.startTime)
				{
					this.glob.startTime = this.pitch.startTime;
				}
				if (this.pitch.endTime > this.glob.endTime)
				{
					this.glob.endTime = this.pitch.endTime;
				}
			}
			if (this.roll.valid && !this.roll.constant)
			{
				if (this.roll.startTime < this.glob.startTime)
				{
					this.glob.startTime = this.roll.startTime;
				}
				if (this.roll.endTime > this.glob.endTime)
				{
					this.glob.endTime = this.roll.endTime;
				}
			}
			if (this.roll.valid && !this.roll.constant)
			{
				if (this.roll.startTime < this.glob.startTime)
				{
					this.glob.startTime = this.roll.startTime;
				}
				if (this.roll.endTime > this.glob.endTime)
				{
					this.glob.endTime = this.roll.endTime;
				}
			}
			if (this.glob.startTime == float.PositiveInfinity)
			{
				this.glob.startTime = 0f;
				this.glob.endTime = 0f;
				this.glob.duration = 0f;
				this.glob.valid = false;
			}
			else
			{
				this.glob.duration = this.glob.endTime - this.glob.startTime;
			}
		}
	}

	// Token: 0x060017B9 RID: 6073 RVA: 0x00058A00 File Offset: 0x00056C00
	protected override bool OpenData(out global::BobEffect.Data data)
	{
		if (!this.glob.valid)
		{
			data = null;
			return false;
		}
		data = new global::BobPunchEffect.PunchData();
		data.effect = this;
		return true;
	}

	// Token: 0x060017BA RID: 6074 RVA: 0x00058A28 File Offset: 0x00056C28
	protected override void CloseData(global::BobEffect.Data data)
	{
	}

	// Token: 0x060017BB RID: 6075 RVA: 0x00058A2C File Offset: 0x00056C2C
	protected override global::BOBRES SimulateData(ref global::BobEffect.Context ctx)
	{
		if (ctx.dt == 0.0)
		{
			return global::BOBRES.CONTINUE;
		}
		global::BobPunchEffect.PunchData punchData = (global::BobPunchEffect.PunchData)ctx.data;
		if (punchData.time >= this.glob.endTime)
		{
			return global::BOBRES.EXIT;
		}
		if (punchData.time >= this.glob.endTime)
		{
			return global::BOBRES.EXIT;
		}
		if (this.x.valid)
		{
			if (this.x.constant || punchData.time <= this.x.startTime)
			{
				punchData.force.x = (double)this.x.startValue;
			}
			else if (punchData.time >= this.x.endValue)
			{
				punchData.force.x = (double)this.x.endValue;
			}
			else
			{
				punchData.force.x = (double)this.x.curve.Evaluate(punchData.time);
			}
		}
		if (this.y.valid)
		{
			if (this.y.constant || punchData.time <= this.y.startTime)
			{
				punchData.force.y = (double)this.y.startValue;
			}
			else if (punchData.time >= this.y.endValue)
			{
				punchData.force.y = (double)this.y.endValue;
			}
			else
			{
				punchData.force.y = (double)this.y.curve.Evaluate(punchData.time);
			}
		}
		if (this.z.valid)
		{
			if (this.z.constant || punchData.time <= this.z.startTime)
			{
				punchData.force.z = (double)this.z.startValue;
			}
			else if (punchData.time >= this.z.endValue)
			{
				punchData.force.z = (double)this.z.endValue;
			}
			else
			{
				punchData.force.z = (double)this.z.curve.Evaluate(punchData.time);
			}
		}
		if (this.pitch.valid)
		{
			if (this.pitch.constant || punchData.time <= this.pitch.startTime)
			{
				punchData.torque.x = (double)this.pitch.startValue;
			}
			else if (punchData.time >= this.pitch.endValue)
			{
				punchData.torque.x = (double)this.pitch.endValue;
			}
			else
			{
				punchData.torque.x = (double)this.pitch.curve.Evaluate(punchData.time);
			}
		}
		if (this.yaw.valid)
		{
			if (this.yaw.constant || punchData.time <= this.yaw.startTime)
			{
				punchData.torque.y = (double)this.yaw.startValue;
			}
			else if (punchData.time >= this.yaw.endValue)
			{
				punchData.torque.y = (double)this.yaw.endValue;
			}
			else
			{
				punchData.torque.y = (double)this.yaw.curve.Evaluate(punchData.time);
			}
		}
		if (this.roll.valid)
		{
			if (this.roll.constant || punchData.time <= this.roll.startTime)
			{
				punchData.torque.z = (double)this.roll.startValue;
			}
			else if (punchData.time >= this.roll.endValue)
			{
				punchData.torque.z = (double)this.roll.endValue;
			}
			else
			{
				punchData.torque.z = (double)this.roll.curve.Evaluate(punchData.time);
			}
		}
		punchData.time += (float)ctx.dt;
		return global::BOBRES.CONTINUE;
	}

	// Token: 0x04000C6E RID: 3182
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.AnimationCurve _x;

	// Token: 0x04000C6F RID: 3183
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.AnimationCurve _y;

	// Token: 0x04000C70 RID: 3184
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.AnimationCurve _z;

	// Token: 0x04000C71 RID: 3185
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.AnimationCurve _yaw;

	// Token: 0x04000C72 RID: 3186
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.AnimationCurve _pitch;

	// Token: 0x04000C73 RID: 3187
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.AnimationCurve _roll;

	// Token: 0x04000C74 RID: 3188
	private global::BobPunchEffect.CurveInfo x;

	// Token: 0x04000C75 RID: 3189
	private global::BobPunchEffect.CurveInfo y;

	// Token: 0x04000C76 RID: 3190
	private global::BobPunchEffect.CurveInfo z;

	// Token: 0x04000C77 RID: 3191
	private global::BobPunchEffect.CurveInfo yaw;

	// Token: 0x04000C78 RID: 3192
	private global::BobPunchEffect.CurveInfo pitch;

	// Token: 0x04000C79 RID: 3193
	private global::BobPunchEffect.CurveInfo roll;

	// Token: 0x04000C7A RID: 3194
	private global::BobPunchEffect.CurveInfo glob;

	// Token: 0x0200029B RID: 667
	private class PunchData : global::BobEffect.Data
	{
		// Token: 0x060017BC RID: 6076 RVA: 0x00058E84 File Offset: 0x00057084
		public PunchData()
		{
		}

		// Token: 0x060017BD RID: 6077 RVA: 0x00058E8C File Offset: 0x0005708C
		public override void CopyDataTo(global::BobEffect.Data data)
		{
			base.CopyDataTo(data);
			((global::BobPunchEffect.PunchData)data).time = this.time;
		}

		// Token: 0x04000C7B RID: 3195
		public float time;
	}

	// Token: 0x0200029C RID: 668
	private struct CurveInfo
	{
		// Token: 0x060017BE RID: 6078 RVA: 0x00058EA8 File Offset: 0x000570A8
		public CurveInfo(global::UnityEngine.AnimationCurve curve)
		{
			if (curve == null)
			{
				this = default(global::BobPunchEffect.CurveInfo);
			}
			else
			{
				this.curve = curve;
			}
			this.length = curve.length;
			switch (this.length)
			{
			case 0:
				this.endTime = 0f;
				this.startTime = 0f;
				this.duration = 0f;
				this.min = 0f;
				this.max = 0f;
				this.range = 0f;
				this.startValue = 0f;
				this.endValue = 0f;
				this.valid = false;
				this.constant = false;
				break;
			case 1:
				this.startTime = curve[0].time;
				this.endTime = this.startTime;
				this.duration = 0f;
				this.min = curve[0].value;
				this.max = this.min;
				this.startValue = this.min;
				this.endValue = this.min;
				this.range = 0f;
				this.valid = true;
				this.constant = true;
				break;
			case 2:
				this.startTime = curve[0].time;
				this.endTime = curve[1].time;
				this.duration = this.endTime - this.startTime;
				this.startValue = curve[0].value;
				this.endValue = curve[1].value;
				if (this.endValue < this.startValue)
				{
					this.range = this.startValue - this.endValue;
					this.min = this.endValue;
					this.max = this.startValue;
				}
				else
				{
					this.range = this.endValue - this.startValue;
					this.min = this.startValue;
					this.max = this.endValue;
				}
				this.valid = true;
				this.constant = (this.range == 0f);
				break;
			default:
				this.startTime = curve[0].time;
				this.endTime = curve[this.length - 1].time;
				this.duration = this.endTime - this.startTime;
				this.min = (this.startValue = curve[0].value);
				this.max = this.min;
				this.endValue = this.startValue;
				for (int i = 1; i < this.length; i++)
				{
					this.endValue = curve[i].value;
					if (this.endValue > this.max)
					{
						this.max = this.endValue;
					}
					if (this.endValue < this.min)
					{
						this.min = this.endValue;
					}
				}
				this.range = this.max - this.min;
				this.valid = true;
				this.constant = (this.range == 0f);
				break;
			}
		}

		// Token: 0x060017BF RID: 6079 RVA: 0x00059200 File Offset: 0x00057400
		public override string ToString()
		{
			return string.Format("[CurveInfo startTime={0}, duration={1}, min={2}, max={3}, length={4}, valid={5}, constant={6}]", new object[]
			{
				this.startTime,
				this.duration,
				this.min,
				this.max,
				this.length,
				this.valid,
				this.constant
			});
		}

		// Token: 0x04000C7C RID: 3196
		public global::UnityEngine.AnimationCurve curve;

		// Token: 0x04000C7D RID: 3197
		public float endTime;

		// Token: 0x04000C7E RID: 3198
		public float startTime;

		// Token: 0x04000C7F RID: 3199
		public float startValue;

		// Token: 0x04000C80 RID: 3200
		public float endValue;

		// Token: 0x04000C81 RID: 3201
		public float duration;

		// Token: 0x04000C82 RID: 3202
		public float min;

		// Token: 0x04000C83 RID: 3203
		public float max;

		// Token: 0x04000C84 RID: 3204
		public float range;

		// Token: 0x04000C85 RID: 3205
		public int length;

		// Token: 0x04000C86 RID: 3206
		public bool valid;

		// Token: 0x04000C87 RID: 3207
		public bool constant;
	}
}
