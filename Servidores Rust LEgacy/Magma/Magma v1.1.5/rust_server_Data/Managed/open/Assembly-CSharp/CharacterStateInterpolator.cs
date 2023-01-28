using System;
using UnityEngine;

// Token: 0x02000140 RID: 320
public sealed class CharacterStateInterpolator : global::CharacterInterpolatorBase<global::CharacterStateInterpolatorData>, global::IStateInterpolator<global::CharacterStateInterpolatorData>, global::IStateInterpolatorWithLinearVelocity, global::IStateInterpolatorWithAngularVelocity, global::IStateInterpolatorWithVelocity, global::IStateInterpolatorSampler<global::CharacterStateInterpolatorData>, global::IStateInterpolatorSampler<global::CharacterTransformInterpolatorData>
{
	// Token: 0x0600085F RID: 2143 RVA: 0x0002270C File Offset: 0x0002090C
	public CharacterStateInterpolator()
	{
	}

	// Token: 0x06000860 RID: 2144 RVA: 0x00022714 File Offset: 0x00020914
	public sealed override void SetGoals(global::UnityEngine.Vector3 pos, global::UnityEngine.Quaternion rot, double timestamp)
	{
		this.SetGoals(pos, (global::Angle2)rot, base.idMain.stateFlags, timestamp);
	}

	// Token: 0x06000861 RID: 2145 RVA: 0x0002273C File Offset: 0x0002093C
	public void SetGoals(global::UnityEngine.Vector3 pos, global::Angle2 rot, global::CharacterStateFlags state, double timestamp)
	{
		global::CharacterStateInterpolatorData characterStateInterpolatorData;
		characterStateInterpolatorData.origin = pos;
		characterStateInterpolatorData.eyesAngles = rot;
		characterStateInterpolatorData.state = state;
		base.SetGoals(ref characterStateInterpolatorData, ref timestamp);
	}

	// Token: 0x06000862 RID: 2146 RVA: 0x0002276C File Offset: 0x0002096C
	public bool Sample(ref double time, out global::CharacterTransformInterpolatorData result)
	{
		global::CharacterStateInterpolatorData characterStateInterpolatorData;
		bool result2 = this.Sample(ref time, out characterStateInterpolatorData);
		result.eyesAngles = characterStateInterpolatorData.eyesAngles;
		result.origin = characterStateInterpolatorData.origin;
		return result2;
	}

	// Token: 0x06000863 RID: 2147 RVA: 0x000227A0 File Offset: 0x000209A0
	public bool Sample(ref double time, out global::CharacterStateInterpolatorData result)
	{
		int len = this.len;
		if (len == 0)
		{
			result = default(global::CharacterStateInterpolatorData);
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
					goto Block_21;
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
						if (num4 > 1.0)
						{
							result.state = this.tbuffer[num2].value.state;
						}
						else if (num4 < 0.0)
						{
							result.state = this.tbuffer[index].value.state;
						}
						else
						{
							result.state = this.tbuffer[index].value.state;
							result.state.flags = (result.state.flags | (ushort)((byte)(this.tbuffer[num2].value.state.flags & 0x43)));
							if (result.state.grounded != this.tbuffer[num2].value.state.grounded)
							{
								result.state.grounded = false;
							}
						}
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
					if (num8 > 1.0)
					{
						result.state = this.tbuffer[num2].value.state;
					}
					else if (num8 < 0.0)
					{
						result.state = this.tbuffer[index].value.state;
					}
					else
					{
						result.state = this.tbuffer[index].value.state;
						result.state.flags = (result.state.flags | (ushort)((byte)(this.tbuffer[num2].value.state.flags & 0x43)));
						if (result.state.grounded != this.tbuffer[num2].value.state.grounded)
						{
							result.state.grounded = false;
						}
					}
				}
			}
			return true;
			Block_21:
			result = this.tbuffer[this.tbuffer[this.len - 1].index].value;
			return true;
		}
		index = this.tbuffer[0].index;
		num3 = this.tbuffer[index].timeStamp;
		result = this.tbuffer[index].value;
		return true;
	}

	// Token: 0x06000864 RID: 2148 RVA: 0x00022FD0 File Offset: 0x000211D0
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

	// Token: 0x06000865 RID: 2149 RVA: 0x000231D4 File Offset: 0x000213D4
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

	// Token: 0x06000866 RID: 2150 RVA: 0x00023340 File Offset: 0x00021540
	public bool SampleWorldVelocity(out global::UnityEngine.Vector3 worldLinearVelocity)
	{
		return this.SampleWorldVelocity(global::Interpolation.time, out worldLinearVelocity);
	}

	// Token: 0x06000867 RID: 2151 RVA: 0x00023350 File Offset: 0x00021550
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

	// Token: 0x06000868 RID: 2152 RVA: 0x000234AC File Offset: 0x000216AC
	public bool SampleWorldVelocity(out global::Angle2 worldAngularVelocity)
	{
		return this.SampleWorldVelocity(global::Interpolation.time, out worldAngularVelocity);
	}

	// Token: 0x06000869 RID: 2153 RVA: 0x000234BC File Offset: 0x000216BC
	public bool SampleWorldVelocity(out global::UnityEngine.Vector3 worldLinearVelocity, out global::Angle2 worldAngularVelocity)
	{
		return this.SampleWorldVelocity(global::Interpolation.time, out worldLinearVelocity, out worldAngularVelocity);
	}

	// Token: 0x0600086A RID: 2154 RVA: 0x000234CC File Offset: 0x000216CC
	protected override void Syncronize()
	{
		double time = global::Interpolation.time;
		global::CharacterStateInterpolatorData characterStateInterpolatorData;
		if (this.Sample(ref time, out characterStateInterpolatorData))
		{
			global::Character idMain = base.idMain;
			if (idMain)
			{
				idMain.origin = characterStateInterpolatorData.origin;
				idMain.eyesAngles = characterStateInterpolatorData.eyesAngles;
				global::CharacterStateFlags stateFlags = idMain.stateFlags;
				idMain.stateFlags = characterStateInterpolatorData.state;
				if (!stateFlags.Equals(characterStateInterpolatorData.state))
				{
					if (!this.once)
					{
						idMain.Signal_State_FlagsChanged(true);
						this.once = true;
					}
					else
					{
						idMain.Signal_State_FlagsChanged(false);
					}
				}
			}
		}
	}

	// Token: 0x0600086B RID: 2155 RVA: 0x00023568 File Offset: 0x00021768
	void SetGoals(ref global::CharacterStateInterpolatorData sample, ref double timeStamp)
	{
		base.SetGoals(ref sample, ref timeStamp);
	}

	// Token: 0x0600086C RID: 2156 RVA: 0x00023574 File Offset: 0x00021774
	void SetGoals(ref global::TimeStamped<global::CharacterStateInterpolatorData> sample)
	{
		base.SetGoals(ref sample);
	}

	// Token: 0x04000653 RID: 1619
	private bool once;
}
