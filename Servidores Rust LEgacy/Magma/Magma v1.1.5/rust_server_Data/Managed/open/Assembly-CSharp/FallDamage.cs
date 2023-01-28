using System;
using uLink;
using UnityEngine;

// Token: 0x020005B5 RID: 1461
public class FallDamage : global::IDLocalCharacter
{
	// Token: 0x06003006 RID: 12294 RVA: 0x000B6E60 File Offset: 0x000B5060
	public FallDamage()
	{
	}

	// Token: 0x06003007 RID: 12295 RVA: 0x000B6E68 File Offset: 0x000B5068
	public float GetLegInjury()
	{
		return this.injuryLevel;
	}

	// Token: 0x06003008 RID: 12296 RVA: 0x000B6E70 File Offset: 0x000B5070
	public void AddLegInjury(float inj)
	{
		this.SetLegInjury(this.GetLegInjury() + inj);
	}

	// Token: 0x06003009 RID: 12297 RVA: 0x000B6E80 File Offset: 0x000B5080
	public void SetLegInjury(float injAmount)
	{
		this.injuryLevel = injAmount;
		if (this.injuryLevel > 0f)
		{
			this.ResetInjuryTime();
		}
		base.networkView.RPC<float>("fIo", 1, this.injuryLevel);
	}

	// Token: 0x0600300A RID: 12298 RVA: 0x000B6EC4 File Offset: 0x000B50C4
	[global::UnityEngine.RPC]
	protected void fIo(float injAmount)
	{
		this.SetLegInjury(injAmount);
	}

	// Token: 0x0600300B RID: 12299 RVA: 0x000B6ED0 File Offset: 0x000B50D0
	public void ResetInjuryTime()
	{
		base.CancelInvoke("ClearInjury");
		float num = global::falldamage.injury_length * global::UnityEngine.Random.Range(0.9f, 1.1f);
		base.Invoke("ClearInjury", num);
	}

	// Token: 0x0600300C RID: 12300 RVA: 0x000B6F0C File Offset: 0x000B510C
	public void ClearInjury()
	{
		this.SetLegInjury(0f);
	}

	// Token: 0x0600300D RID: 12301 RVA: 0x000B6F1C File Offset: 0x000B511C
	public void FallImpact(float fallspeed)
	{
		float num = (fallspeed - global::falldamage.min_vel) / (global::falldamage.max_vel - global::falldamage.min_vel);
		bool flag = num > 0.25f;
		bool flag2 = num > 0.35f || global::UnityEngine.Random.Range(0, 3) == 0 || base.healthFraction < 0.5f;
		if (flag)
		{
			base.GetComponent<global::HumanBodyTakeDamage>().AddBleedingLevel(3f + (num - 0.25f) * 10f);
		}
		if (flag2)
		{
			this.AddLegInjury(1f);
		}
		global::TakeDamage.HurtSelf(base.idMain, 10f + num * base.maxHealth, null);
	}

	// Token: 0x0600300E RID: 12302 RVA: 0x000B6FC4 File Offset: 0x000B51C4
	private bool ValidateFallVelocity(global::UnityEngine.Vector3 velocity, out float fallspeed)
	{
		if (!global::falldamage.enabled)
		{
			fallspeed = 0f;
			return false;
		}
		fallspeed = global::UnityEngine.Mathf.Abs(velocity.y);
		if (fallspeed < 0f)
		{
			fallspeed = -fallspeed;
		}
		return fallspeed >= global::falldamage.min_vel;
	}

	// Token: 0x0600300F RID: 12303 RVA: 0x000B7010 File Offset: 0x000B5210
	[global::UnityEngine.RPC]
	protected void fIc(float fallspeed)
	{
	}

	// Token: 0x06003010 RID: 12304 RVA: 0x000B7014 File Offset: 0x000B5214
	[global::UnityEngine.RPC]
	protected void fIm(global::UnityEngine.Vector3 velocity, global::uLink.NetworkMessageInfo info)
	{
		if (info.sender != base.networkView.owner)
		{
			global::NetUser netUser = global::NetUser.Find(info.sender);
			if (netUser != null)
			{
				global::FeedbackLog.Start(global::FeedbackLog.TYPE.SimpleExploit);
				global::FeedbackLog.Writer.Write("fall");
				global::FeedbackLog.Writer.Write(netUser.userID);
				global::FeedbackLog.End(global::FeedbackLog.TYPE.SimpleExploit);
			}
			return;
		}
		float num;
		if (!this.ValidateFallVelocity(velocity, out num))
		{
			return;
		}
		base.networkView.RPC<float>("fIc", 1, num);
		this.FallImpact(num);
	}

	// Token: 0x06003011 RID: 12305 RVA: 0x000B70A4 File Offset: 0x000B52A4
	[global::UnityEngine.RPC]
	protected void ReadFallImpact(global::UnityEngine.Vector3 velocity, global::uLink.NetworkMessageInfo info)
	{
		global::NetUser netUser = global::NetUser.Find(info.sender);
		if (netUser != null)
		{
			global::FeedbackLog.Start(global::FeedbackLog.TYPE.SimpleExploit);
			global::FeedbackLog.Writer.Write("fallold");
			global::FeedbackLog.Writer.Write(netUser.userID);
			global::FeedbackLog.End(global::FeedbackLog.TYPE.SimpleExploit);
		}
	}

	// Token: 0x040019C5 RID: 6597
	private const string kRPCName_InjuryInfo = "fIo";

	// Token: 0x040019C6 RID: 6598
	private const string kRPCName_ReadFallImpactClient = "fIc";

	// Token: 0x040019C7 RID: 6599
	private const string kRPCName_ReadFallImpactServer = "fIm";

	// Token: 0x040019C8 RID: 6600
	public global::UnityEngine.AudioClip legBreakSound;

	// Token: 0x040019C9 RID: 6601
	public global::BobEffect fallbob;

	// Token: 0x040019CA RID: 6602
	private float injuryLevel;

	// Token: 0x040019CB RID: 6603
	private float injuredTime;
}
