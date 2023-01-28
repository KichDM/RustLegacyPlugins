using System;
using UnityEngine;

// Token: 0x0200017E RID: 382
public class RecoilSimulation : global::IDLocalCharacter
{
	// Token: 0x06000B30 RID: 2864 RVA: 0x0002B68C File Offset: 0x0002988C
	public RecoilSimulation()
	{
	}

	// Token: 0x06000B31 RID: 2865 RVA: 0x0002B694 File Offset: 0x00029894
	private void LateUpdate()
	{
		global::Angle2 angles;
		if (this.ExtractRecoil(out angles))
		{
			base.ApplyAdditiveEyeAngles(angles);
		}
	}

	// Token: 0x06000B32 RID: 2866 RVA: 0x0002B6B8 File Offset: 0x000298B8
	private bool ExtractRecoil(out global::Angle2 offset)
	{
		offset = default(global::Angle2);
		if (this.recoilImpulses != null)
		{
			int count = this.recoilImpulses.Count;
			if (count > 0)
			{
				float deltaTime = global::UnityEngine.Time.deltaTime;
				global::RecoilSimulation.Recoil[] buffer = this.recoilImpulses.Buffer;
				for (int i = count - 1; i >= 0; i--)
				{
					if (buffer[i].Extract(ref offset, deltaTime))
					{
						this.recoilImpulses.RemoveAt(i);
						while (--i >= 0)
						{
							if (buffer[i].Extract(ref offset, deltaTime))
							{
								this.recoilImpulses.RemoveAt(i);
							}
						}
						if (this.recoilImpulses.Count == 0)
						{
							base.enabled = false;
						}
					}
				}
				return offset.pitch != 0f || offset.yaw != 0f;
			}
		}
		return false;
	}

	// Token: 0x06000B33 RID: 2867 RVA: 0x0002B7A4 File Offset: 0x000299A4
	public void AddRecoil(float duration, float pitch, float yaw)
	{
		global::Angle2 angle = default(global::Angle2);
		angle.pitch = pitch;
		angle.yaw = yaw;
		this.AddRecoil(duration, ref angle);
	}

	// Token: 0x06000B34 RID: 2868 RVA: 0x0002B7D4 File Offset: 0x000299D4
	public void AddRecoil(float duration, float pitch)
	{
		global::Angle2 angle = default(global::Angle2);
		angle.pitch = pitch;
		this.AddRecoil(duration, ref angle);
	}

	// Token: 0x06000B35 RID: 2869 RVA: 0x0002B7FC File Offset: 0x000299FC
	public void AddRecoil(float duration, global::Angle2 angle)
	{
		this.AddRecoil(duration, ref angle);
	}

	// Token: 0x06000B36 RID: 2870 RVA: 0x0002B808 File Offset: 0x00029A08
	public void AddRecoil(float duration, ref global::Angle2 angle2)
	{
		if (duration > 0f && (angle2.pitch != 0f || angle2.yaw != 0f))
		{
			if (this.recoilImpulses == null)
			{
				this.recoilImpulses = new global::GrabBag<global::RecoilSimulation.Recoil>(4);
				global::UnityEngine.Debug.Log("Created GrabBag<Recoil>", this);
			}
			if (this.recoilImpulses.Add(new global::RecoilSimulation.Recoil(ref angle2, duration)) == 0)
			{
				base.enabled = true;
			}
		}
	}

	// Token: 0x040007A0 RID: 1952
	[global::System.NonSerialized]
	private global::GrabBag<global::RecoilSimulation.Recoil> recoilImpulses;

	// Token: 0x0200017F RID: 383
	private struct Recoil
	{
		// Token: 0x06000B37 RID: 2871 RVA: 0x0002B880 File Offset: 0x00029A80
		public Recoil(ref global::Angle2 angle, float duration)
		{
			this.angle = angle;
			this.timeScale = 1f / duration;
			this.fraction = 0f;
		}

		// Token: 0x06000B38 RID: 2872 RVA: 0x0002B8B4 File Offset: 0x00029AB4
		public bool Extract(ref global::Angle2 sum, float deltaTime)
		{
			float num = this.fraction + (this.fraction - this.fraction * this.fraction);
			this.fraction += deltaTime * this.timeScale;
			if (this.fraction >= 1f)
			{
				num = 1f - num;
				sum.pitch += this.angle.pitch * num;
				sum.yaw += this.angle.yaw * num;
				return true;
			}
			num = this.fraction + (this.fraction - this.fraction * this.fraction) - num;
			sum.pitch += this.angle.pitch * num;
			sum.yaw += this.angle.yaw * num;
			return false;
		}

		// Token: 0x040007A1 RID: 1953
		public global::Angle2 angle;

		// Token: 0x040007A2 RID: 1954
		public float fraction;

		// Token: 0x040007A3 RID: 1955
		public float timeScale;
	}
}
