using System;
using UnityEngine;

// Token: 0x02000443 RID: 1091
public sealed class TransformInterpolatorEarly : global::StateInterpolator<global::PosRot>, global::IStateInterpolatorWithLinearVelocity, global::IStateInterpolator<global::PosRot>, global::IStateInterpolatorSampler<global::PosRot>
{
	// Token: 0x060025E8 RID: 9704 RVA: 0x000911CC File Offset: 0x0008F3CC
	public TransformInterpolatorEarly()
	{
	}

	// Token: 0x060025E9 RID: 9705 RVA: 0x000911E0 File Offset: 0x0008F3E0
	public sealed override void SetGoals(global::UnityEngine.Vector3 pos, global::UnityEngine.Quaternion rot, double timestamp)
	{
		global::PosRot posRot;
		posRot.position = pos;
		posRot.rotation = rot;
		this.SetGoals(ref posRot, ref timestamp);
	}

	// Token: 0x060025EA RID: 9706 RVA: 0x00091208 File Offset: 0x0008F408
	public void SetGoals(global::PosRot frame, double timestamp)
	{
		this.SetGoals(ref frame, ref timestamp);
	}

	// Token: 0x060025EB RID: 9707 RVA: 0x00091214 File Offset: 0x0008F414
	public bool Sample(ref double time, out global::PosRot result)
	{
		int len = this.len;
		if (len == 0)
		{
			result = default(global::PosRot);
			return false;
		}
		int index;
		double num3;
		if (len != 1)
		{
			int num = 0;
			int num2 = -1;
			for (;;)
			{
				index = this.tbuffer[num].index;
				num3 = this.tbuffer[index].timeStamp;
				if (num3 > time)
				{
					num2 = index;
				}
				else
				{
					if (num3 == time)
					{
						break;
					}
					if (num3 < time)
					{
						goto Block_5;
					}
				}
				if (++num >= this.len)
				{
					goto Block_11;
				}
			}
			result = this.tbuffer[index].value;
			return true;
			Block_5:
			if (num2 == -1)
			{
				if (this.exterpolate && num < this.len - 1)
				{
					num2 = index;
					index = this.tbuffer[num + 1].index;
					double t = (time - this.tbuffer[index].timeStamp) / (this.tbuffer[num2].timeStamp - this.tbuffer[index].timeStamp);
					global::PosRot.Lerp(ref this.tbuffer[index].value, ref this.tbuffer[num2].value, t, out result);
				}
				else
				{
					result = this.tbuffer[index].value;
				}
			}
			else
			{
				double timeStamp = this.tbuffer[num2].timeStamp;
				double num4 = (double)this.allowDifference + global::NetCull.sendInterval;
				double num5 = timeStamp - num3;
				if (num5 > num4)
				{
					num3 = timeStamp - (num5 = num4);
					if (num3 >= time)
					{
						result = this.tbuffer[index].value;
						return true;
					}
				}
				double t2 = (time - num3) / num5;
				global::PosRot.Lerp(ref this.tbuffer[index].value, ref this.tbuffer[num2].value, t2, out result);
			}
			return true;
			Block_11:
			result = this.tbuffer[this.tbuffer[this.len - 1].index].value;
			return true;
		}
		index = this.tbuffer[0].index;
		num3 = this.tbuffer[index].timeStamp;
		result = this.tbuffer[index].value;
		return true;
	}

	// Token: 0x060025EC RID: 9708 RVA: 0x00091478 File Offset: 0x0008F678
	public bool SampleWorldVelocity(double time, out global::UnityEngine.Vector3 worldLinearVelocity)
	{
		int len = this.len;
		if (len != 0 && len != 1)
		{
			int num = 0;
			int num2 = -1;
			int index;
			double num3;
			for (;;)
			{
				index = this.tbuffer[num].index;
				num3 = this.tbuffer[index].timeStamp;
				if (num3 <= time)
				{
					break;
				}
				num2 = index;
				if (++num >= this.len)
				{
					goto Block_7;
				}
			}
			if (num2 == -1)
			{
				worldLinearVelocity = default(global::UnityEngine.Vector3);
				return false;
			}
			double timeStamp = this.tbuffer[num2].timeStamp;
			double num4 = (double)this.allowDifference + global::NetCull.sendInterval;
			double num5 = timeStamp - num3;
			if (num5 >= num4)
			{
				num5 = num4;
				num3 = timeStamp - num5;
				if (time <= num3)
				{
					worldLinearVelocity = default(global::UnityEngine.Vector3);
					return false;
				}
			}
			worldLinearVelocity = this.tbuffer[num2].value.position - this.tbuffer[index].value.position;
			worldLinearVelocity.x = (float)((double)worldLinearVelocity.x / num5);
			worldLinearVelocity.y = (float)((double)worldLinearVelocity.y / num5);
			worldLinearVelocity.z = (float)((double)worldLinearVelocity.z / num5);
			return true;
			Block_7:
			worldLinearVelocity = default(global::UnityEngine.Vector3);
			return false;
		}
		worldLinearVelocity = default(global::UnityEngine.Vector3);
		return false;
	}

	// Token: 0x060025ED RID: 9709 RVA: 0x000915E4 File Offset: 0x0008F7E4
	public bool SampleWorldVelocity(out global::UnityEngine.Vector3 worldLinearVelocity)
	{
		return this.SampleWorldVelocity(global::Interpolation.time, out worldLinearVelocity);
	}

	// Token: 0x060025EE RID: 9710 RVA: 0x000915F4 File Offset: 0x0008F7F4
	protected override void Syncronize()
	{
	}

	// Token: 0x060025EF RID: 9711 RVA: 0x000915F8 File Offset: 0x0008F7F8
	public void Update()
	{
		if (!base.running)
		{
			return;
		}
		double time = global::Interpolation.time;
		global::PosRot posRot;
		if (this.Sample(ref time, out posRot))
		{
			this.target.position = posRot.position;
			this.target.rotation = posRot.rotation;
		}
	}

	// Token: 0x060025F0 RID: 9712 RVA: 0x0009164C File Offset: 0x0008F84C
	void SetGoals(ref global::TimeStamped<global::PosRot> sample)
	{
		base.SetGoals(ref sample);
	}

	// Token: 0x04001348 RID: 4936
	public global::UnityEngine.Transform target;

	// Token: 0x04001349 RID: 4937
	public bool exterpolate;

	// Token: 0x0400134A RID: 4938
	public float allowDifference = 0.1f;
}
