using System;
using UnityEngine;

// Token: 0x0200042F RID: 1071
public sealed class RigidbodyInterpolator : global::StateInterpolator<global::PosRot>, global::IStateInterpolatorWithLinearVelocity, global::IStateInterpolator<global::PosRot>, global::IStateInterpolatorSampler<global::PosRot>
{
	// Token: 0x06002542 RID: 9538 RVA: 0x0008E6C4 File Offset: 0x0008C8C4
	public RigidbodyInterpolator()
	{
	}

	// Token: 0x06002543 RID: 9539 RVA: 0x0008E6D8 File Offset: 0x0008C8D8
	public sealed override void SetGoals(global::UnityEngine.Vector3 pos, global::UnityEngine.Quaternion rot, double timestamp)
	{
		global::PosRot posRot;
		posRot.position = pos;
		posRot.rotation = rot;
		this.SetGoals(ref posRot, ref timestamp);
	}

	// Token: 0x06002544 RID: 9540 RVA: 0x0008E700 File Offset: 0x0008C900
	public void SetGoals(global::PosRot frame, double timestamp)
	{
		this.SetGoals(ref frame, ref timestamp);
	}

	// Token: 0x06002545 RID: 9541 RVA: 0x0008E70C File Offset: 0x0008C90C
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

	// Token: 0x06002546 RID: 9542 RVA: 0x0008E970 File Offset: 0x0008CB70
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

	// Token: 0x06002547 RID: 9543 RVA: 0x0008EADC File Offset: 0x0008CCDC
	public bool SampleWorldVelocity(out global::UnityEngine.Vector3 worldLinearVelocity)
	{
		return this.SampleWorldVelocity(global::Interpolation.time, out worldLinearVelocity);
	}

	// Token: 0x06002548 RID: 9544 RVA: 0x0008EAEC File Offset: 0x0008CCEC
	protected override void Syncronize()
	{
		double time = global::Interpolation.time;
		global::PosRot posRot;
		if (this.Sample(ref time, out posRot))
		{
			this.target.MovePosition(posRot.position);
			this.target.MoveRotation(posRot.rotation);
		}
	}

	// Token: 0x06002549 RID: 9545 RVA: 0x0008EB34 File Offset: 0x0008CD34
	void SetGoals(ref global::TimeStamped<global::PosRot> sample)
	{
		base.SetGoals(ref sample);
	}

	// Token: 0x04001300 RID: 4864
	public global::UnityEngine.Rigidbody target;

	// Token: 0x04001301 RID: 4865
	public bool exterpolate;

	// Token: 0x04001302 RID: 4866
	public float allowDifference = 0.1f;
}
