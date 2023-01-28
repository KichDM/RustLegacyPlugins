using System;
using UnityEngine;

// Token: 0x02000145 RID: 325
public sealed class CharacterTransformInterpolator : global::CharacterInterpolatorBase<global::CharacterTransformInterpolatorData>, global::IStateInterpolatorSampler<global::CharacterTransformInterpolatorData>, global::IStateInterpolator<global::CharacterTransformInterpolatorData>
{
	// Token: 0x06000875 RID: 2165 RVA: 0x000235F8 File Offset: 0x000217F8
	public CharacterTransformInterpolator()
	{
	}

	// Token: 0x06000876 RID: 2166 RVA: 0x00023600 File Offset: 0x00021800
	public sealed override void SetGoals(global::UnityEngine.Vector3 pos, global::UnityEngine.Quaternion rot, double timestamp)
	{
		this.SetGoals(pos, (global::Angle2)rot, timestamp);
	}

	// Token: 0x06000877 RID: 2167 RVA: 0x00023610 File Offset: 0x00021810
	public void SetGoals(global::UnityEngine.Vector3 pos, global::Angle2 rot, double timestamp)
	{
		global::CharacterTransformInterpolatorData characterTransformInterpolatorData;
		characterTransformInterpolatorData.origin = pos;
		characterTransformInterpolatorData.eyesAngles = rot;
		base.SetGoals(ref characterTransformInterpolatorData, ref timestamp);
	}

	// Token: 0x06000878 RID: 2168 RVA: 0x00023638 File Offset: 0x00021838
	public bool Sample(ref double time, out global::CharacterTransformInterpolatorData result)
	{
		int len = this.len;
		if (len == 0)
		{
			result = default(global::CharacterTransformInterpolatorData);
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
					goto Block_15;
				}
			}
			result = this.tbuffer[index].value;
			return true;
			Block_5:
			if (num2 == -1)
			{
				if (this.extrapolate && num < this.len - 1)
				{
					num2 = index;
					index = this.tbuffer[num + 1].index;
					double num4 = (num3 - this.tbuffer[index].timeStamp) / (num3 - this.tbuffer[index].timeStamp);
					if (num4 == 0.0)
					{
						result = this.tbuffer[index].value;
					}
					else if (num4 == 1.0)
					{
						result = this.tbuffer[num2].value;
					}
					else
					{
						double num5 = 1.0 - num4;
						result.origin.x = (float)((double)this.tbuffer[index].value.origin.x * num5 + (double)this.tbuffer[num2].value.origin.x * num4);
						result.origin.y = (float)((double)this.tbuffer[index].value.origin.y * num5 + (double)this.tbuffer[num2].value.origin.y * num4);
						result.origin.z = (float)((double)this.tbuffer[index].value.origin.z * num5 + (double)this.tbuffer[num2].value.origin.z * num4);
						result.eyesAngles = default(global::Angle2);
						result.eyesAngles.yaw = (float)((double)this.tbuffer[index].value.eyesAngles.yaw + (double)global::UnityEngine.Mathf.DeltaAngle(this.tbuffer[index].value.eyesAngles.yaw, this.tbuffer[num2].value.eyesAngles.yaw) * num4);
						result.eyesAngles.pitch = global::UnityEngine.Mathf.DeltaAngle(0f, (float)((double)this.tbuffer[index].value.eyesAngles.pitch + (double)global::UnityEngine.Mathf.DeltaAngle(this.tbuffer[index].value.eyesAngles.pitch, this.tbuffer[num2].value.eyesAngles.pitch) * num4));
					}
				}
				else
				{
					result = this.tbuffer[index].value;
				}
			}
			else
			{
				double timeStamp = this.tbuffer[num2].timeStamp;
				double num6 = (double)this.allowableTimeSpan + global::NetCull.sendInterval;
				double num7 = timeStamp - num3;
				if (num7 > num6)
				{
					num3 = timeStamp - (num7 = num6);
					if (num3 >= time)
					{
						result = this.tbuffer[index].value;
						return true;
					}
				}
				double num8 = (time - num3) / num7;
				if (num8 == 0.0)
				{
					result = this.tbuffer[index].value;
				}
				else if (num8 == 1.0)
				{
					result = this.tbuffer[num2].value;
				}
				else
				{
					double num9 = 1.0 - num8;
					result.origin.x = (float)((double)this.tbuffer[index].value.origin.x * num9 + (double)this.tbuffer[num2].value.origin.x * num8);
					result.origin.y = (float)((double)this.tbuffer[index].value.origin.y * num9 + (double)this.tbuffer[num2].value.origin.y * num8);
					result.origin.z = (float)((double)this.tbuffer[index].value.origin.z * num9 + (double)this.tbuffer[num2].value.origin.z * num8);
					result.eyesAngles = default(global::Angle2);
					result.eyesAngles.yaw = (float)((double)this.tbuffer[index].value.eyesAngles.yaw + (double)global::UnityEngine.Mathf.DeltaAngle(this.tbuffer[index].value.eyesAngles.yaw, this.tbuffer[num2].value.eyesAngles.yaw) * num8);
					result.eyesAngles.pitch = global::UnityEngine.Mathf.DeltaAngle(0f, (float)((double)this.tbuffer[index].value.eyesAngles.pitch + (double)global::UnityEngine.Mathf.DeltaAngle(this.tbuffer[index].value.eyesAngles.pitch, this.tbuffer[num2].value.eyesAngles.pitch) * num8));
				}
			}
			return true;
			Block_15:
			result = this.tbuffer[this.tbuffer[this.len - 1].index].value;
			return true;
		}
		index = this.tbuffer[0].index;
		num3 = this.tbuffer[index].timeStamp;
		result = this.tbuffer[index].value;
		return true;
	}

	// Token: 0x06000879 RID: 2169 RVA: 0x00023C98 File Offset: 0x00021E98
	public bool SampleWorldVelocity(double time, out global::UnityEngine.Vector3 worldLinearVelocity, out global::Angle2 worldAngularVelocity)
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
				worldAngularVelocity = default(global::Angle2);
				return false;
			}
			double timeStamp = this.tbuffer[num2].timeStamp;
			double num4 = (double)this.allowableTimeSpan + global::NetCull.sendInterval;
			double num5 = timeStamp - num3;
			if (num5 >= num4)
			{
				num5 = num4;
				num3 = timeStamp - num5;
				if (time <= num3)
				{
					worldLinearVelocity = default(global::UnityEngine.Vector3);
					worldAngularVelocity = default(global::Angle2);
					return false;
				}
			}
			worldLinearVelocity = this.tbuffer[num2].value.origin - this.tbuffer[index].value.origin;
			worldAngularVelocity = global::Angle2.Delta(this.tbuffer[index].value.eyesAngles, this.tbuffer[num2].value.eyesAngles);
			worldLinearVelocity.x = (float)((double)worldLinearVelocity.x / num5);
			worldLinearVelocity.y = (float)((double)worldLinearVelocity.y / num5);
			worldLinearVelocity.z = (float)((double)worldLinearVelocity.z / num5);
			worldAngularVelocity.x = (float)((double)worldAngularVelocity.x / num5);
			worldAngularVelocity.y = (float)((double)worldAngularVelocity.y / num5);
			return true;
			Block_7:
			worldLinearVelocity = default(global::UnityEngine.Vector3);
			worldAngularVelocity = default(global::Angle2);
			return false;
		}
		worldLinearVelocity = default(global::UnityEngine.Vector3);
		worldAngularVelocity = default(global::Angle2);
		return false;
	}

	// Token: 0x0600087A RID: 2170 RVA: 0x00023E9C File Offset: 0x0002209C
	public bool SampleWorldVelocity(out global::UnityEngine.Vector3 worldLinearVelocity, out global::Angle2 worldAngularVelocity)
	{
		return this.SampleWorldVelocity(global::Interpolation.time, out worldLinearVelocity, out worldAngularVelocity);
	}

	// Token: 0x0600087B RID: 2171 RVA: 0x00023EAC File Offset: 0x000220AC
	public bool SampleWorldVelocity(double time, out global::Angle2 worldAngularVelocity)
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
				worldAngularVelocity = default(global::Angle2);
				return false;
			}
			double timeStamp = this.tbuffer[num2].timeStamp;
			double num4 = (double)this.allowableTimeSpan + global::NetCull.sendInterval;
			double num5 = timeStamp - num3;
			if (num5 >= num4)
			{
				num5 = num4;
				num3 = timeStamp - num5;
				if (time <= num3)
				{
					worldAngularVelocity = default(global::Angle2);
					return false;
				}
			}
			worldAngularVelocity = global::Angle2.Delta(this.tbuffer[index].value.eyesAngles, this.tbuffer[num2].value.eyesAngles);
			worldAngularVelocity.x = (float)((double)worldAngularVelocity.x / num5);
			worldAngularVelocity.y = (float)((double)worldAngularVelocity.y / num5);
			return true;
			Block_7:
			worldAngularVelocity = default(global::Angle2);
			return false;
		}
		worldAngularVelocity = default(global::Angle2);
		return false;
	}

	// Token: 0x0600087C RID: 2172 RVA: 0x00024008 File Offset: 0x00022208
	public bool SampleWorldVelocity(out global::Angle2 worldAngularVelocity)
	{
		return this.SampleWorldVelocity(global::Interpolation.time, out worldAngularVelocity);
	}

	// Token: 0x0600087D RID: 2173 RVA: 0x00024018 File Offset: 0x00022218
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
			double num4 = (double)this.allowableTimeSpan + global::NetCull.sendInterval;
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
			worldLinearVelocity = this.tbuffer[num2].value.origin - this.tbuffer[index].value.origin;
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

	// Token: 0x0600087E RID: 2174 RVA: 0x00024184 File Offset: 0x00022384
	public bool SampleWorldVelocity(out global::UnityEngine.Vector3 worldLinearVelocity)
	{
		return this.SampleWorldVelocity(global::Interpolation.time, out worldLinearVelocity);
	}

	// Token: 0x0600087F RID: 2175 RVA: 0x00024194 File Offset: 0x00022394
	private void Update()
	{
		double time = global::Interpolation.time;
		global::CharacterTransformInterpolatorData characterTransformInterpolatorData;
		if (this.Sample(ref time, out characterTransformInterpolatorData))
		{
			global::Character idMain = base.idMain;
			if (idMain)
			{
				idMain.origin = characterTransformInterpolatorData.origin;
				idMain.eyesAngles = characterTransformInterpolatorData.eyesAngles;
			}
		}
	}

	// Token: 0x06000880 RID: 2176 RVA: 0x000241E4 File Offset: 0x000223E4
	void SetGoals(ref global::CharacterTransformInterpolatorData sample, ref double timeStamp)
	{
		base.SetGoals(ref sample, ref timeStamp);
	}

	// Token: 0x06000881 RID: 2177 RVA: 0x000241F0 File Offset: 0x000223F0
	void SetGoals(ref global::TimeStamped<global::CharacterTransformInterpolatorData> sample)
	{
		base.SetGoals(ref sample);
	}

	// Token: 0x0400065B RID: 1627
	private bool once;
}
