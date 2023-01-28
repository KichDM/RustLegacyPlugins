using System;
using Magma;
using RustProto;
using UnityEngine;

// Token: 0x020005B7 RID: 1463
public class HumanBodyTakeDamage : global::ProtectionTakeDamage
{
	// Token: 0x06003014 RID: 12308 RVA: 0x000B712C File Offset: 0x000B532C
	public HumanBodyTakeDamage()
	{
	}

	// Token: 0x06003015 RID: 12309 RVA: 0x000B7158 File Offset: 0x000B5358
	protected new void Awake()
	{
		base.Awake();
		this.checkLevelInterval = 1f;
		base.InvokeRepeating("CheckLevels", this.checkLevelInterval, this.checkLevelInterval);
		this._playerInv = base.GetComponent<global::PlayerInventory>();
	}

	// Token: 0x06003016 RID: 12310 RVA: 0x000B719C File Offset: 0x000B539C
	public void CheckLevels()
	{
		float num = (this._lastLevelCheckTime <= 0f) ? 0f : (global::UnityEngine.Time.time - this._lastLevelCheckTime);
		this._lastLevelCheckTime = global::UnityEngine.Time.time;
		if (this._healOverTime > 0f)
		{
			float num2 = global::UnityEngine.Mathf.Clamp(num * 3f, 0f, this._healOverTime);
			this._healOverTime -= num2;
			if (this._healOverTime < 0f)
			{
				this._healOverTime = 0f;
			}
			base.Heal(this.idMain, num2);
		}
	}

	// Token: 0x06003017 RID: 12311 RVA: 0x000B723C File Offset: 0x000B543C
	private void CopyMembersToHumanBodyTakeDamage(global::HumanBodyTakeDamage other)
	{
		other._bleedingLevelMax = this._bleedingLevelMax;
		other._bleedInterval = this._bleedInterval;
		other._healOverTime = this._healOverTime;
		other._lastLevelCheckTime = this._lastLevelCheckTime;
		other.bleedAttacker = this.bleedAttacker;
		other.bleedingID = this.bleedingID;
		other.lastBleedTime = this.lastBleedTime;
		if (other.checkLevelInterval != this.checkLevelInterval)
		{
			other.checkLevelInterval = this.checkLevelInterval;
			other.CancelInvoke("CheckLevels");
			other.InvokeRepeating("CheckLevels", this.checkLevelInterval, this.checkLevelInterval);
		}
		other.SetBleedingLevel(this._bleedingLevel);
	}

	// Token: 0x06003018 RID: 12312 RVA: 0x000B72E8 File Offset: 0x000B54E8
	protected override void CopyMembersTo(global::TakeDamage other)
	{
		base.CopyMembersTo(other);
		if (other is global::HumanBodyTakeDamage)
		{
			this.CopyMembersToHumanBodyTakeDamage((global::HumanBodyTakeDamage)other);
		}
	}

	// Token: 0x06003019 RID: 12313 RVA: 0x000B7308 File Offset: 0x000B5508
	public virtual bool IsBleeding()
	{
		return this._bleedingLevel > 0f;
	}

	// Token: 0x0600301A RID: 12314 RVA: 0x000B7318 File Offset: 0x000B5518
	public void AddBleedingLevel(float lvl)
	{
		this.SetBleedingLevel(this._bleedingLevel + lvl);
	}

	// Token: 0x0600301B RID: 12315 RVA: 0x000B7328 File Offset: 0x000B5528
	public void SetBleedingLevel(float lvl)
	{
		this._bleedingLevel = lvl;
		if (this._bleedingLevel > 0f)
		{
			base.CancelInvoke("DoBleed");
			base.InvokeRepeating("DoBleed", this._bleedInterval, this._bleedInterval);
		}
		else
		{
			base.CancelInvoke("DoBleed");
		}
		base.SendMessage("BleedingLevelChanged", lvl, 1);
	}

	// Token: 0x0600301C RID: 12316 RVA: 0x000B7390 File Offset: 0x000B5590
	public void Bandage(float amountToRestore)
	{
		this.SetBleedingLevel(global::UnityEngine.Mathf.Clamp(this._bleedingLevel - amountToRestore, 0f, this._bleedingLevelMax));
		if (this._bleedingLevel <= 0f)
		{
			base.CancelInvoke("DoBleed");
		}
	}

	// Token: 0x0600301D RID: 12317 RVA: 0x000B73CC File Offset: 0x000B55CC
	public void DoBleed()
	{
		if (base.alive && this._bleedingLevel > 0f)
		{
			float healthPoints = this._bleedingLevel;
			global::Metabolism component = base.GetComponent<global::Metabolism>();
			if (component)
			{
				healthPoints = this._bleedingLevel * ((!component.IsWarm()) ? 1f : 0.4f);
			}
			global::LifeStatus lifeStatus;
			if (this.bleedAttacker && this.bleedingID)
			{
				lifeStatus = global::TakeDamage.Hurt(this.bleedAttacker, this.bleedingID, healthPoints, null);
			}
			else
			{
				lifeStatus = global::TakeDamage.HurtSelf(this.idMain, healthPoints, null);
			}
			if (lifeStatus == global::LifeStatus.IsAlive)
			{
				float num = 0.2f;
				this.SetBleedingLevel(global::UnityEngine.Mathf.Clamp(this._bleedingLevel - num, 0f, this._bleedingLevel));
			}
			else
			{
				base.CancelInvoke("DoBleed");
			}
		}
		else
		{
			base.CancelInvoke("DoBleed");
		}
	}

	// Token: 0x0600301E RID: 12318 RVA: 0x000B74CC File Offset: 0x000B56CC
	protected override global::LifeStatus Hurt(ref global::DamageEvent damage)
	{
		global::Magma.Hooks.PlayerHurt(ref damage);
		if (!global::server.pvp)
		{
			global::PlayerClient client = damage.victim.client;
			if (client && damage.attacker.IsDifferentPlayer(client))
			{
				return damage.status;
			}
		}
		global::LifeStatus lifeStatus = base.Hurt(ref damage);
		bool flag = (damage.damageTypes & (global::DamageTypeFlags.damage_bullet | global::DamageTypeFlags.damage_melee | global::DamageTypeFlags.damage_explosion)) != (global::DamageTypeFlags)0;
		if (flag)
		{
			this._healOverTime = 0f;
		}
		if (this._playerInv != null && flag)
		{
			float num = damage.amount / 100f * global::conditionloss.armorhealthmult;
			for (int i = 0; i < 4; i++)
			{
				global::IArmorItem armorItem = null;
				if (this._playerInv.GetArmorItem<global::IArmorItem>((global::ArmorModelSlot)i, out armorItem))
				{
					armorItem.TryConditionLoss(0.75f, num * global::UnityEngine.Random.Range(0.8f, 1.2f));
				}
			}
		}
		if (lifeStatus == global::LifeStatus.WasKilled)
		{
			base.CancelInvoke("DoBleed");
		}
		else if (lifeStatus == global::LifeStatus.IsAlive && base.healthLossFraction > 0.2f)
		{
			float num2 = damage.amount / base.maxHealth;
			if ((damage.damageTypes & (global::DamageTypeFlags.damage_bullet | global::DamageTypeFlags.damage_melee)) != (global::DamageTypeFlags)0 && damage.amount > base.maxHealth * 0.05f)
			{
				int num3 = 0;
				if (num2 >= 0.25f)
				{
					num3 = 1;
				}
				else if (num2 >= 0.15f)
				{
					num3 = 2;
				}
				else if (num2 >= 0.05f)
				{
					num3 = 3;
				}
				bool flag2 = global::UnityEngine.Random.Range(0, num3) == 1 || num3 == 1;
				if (flag2)
				{
					this.AddBleedingLevel(global::UnityEngine.Mathf.Clamp(damage.amount * 0.15f, 1f, base.maxHealth));
					this.bleedAttacker = damage.attacker.id;
					this.bleedingID = damage.victim.id;
				}
			}
		}
		return lifeStatus;
	}

	// Token: 0x0600301F RID: 12319 RVA: 0x000B76B8 File Offset: 0x000B58B8
	public virtual void HealOverTime(float amountToHeal)
	{
		this._healOverTime += amountToHeal;
	}

	// Token: 0x06003020 RID: 12320 RVA: 0x000B76C8 File Offset: 0x000B58C8
	public override void ServerFrame()
	{
	}

	// Token: 0x06003021 RID: 12321 RVA: 0x000B76CC File Offset: 0x000B58CC
	public override void SaveVitals(ref global::RustProto.Vitals.Builder vitals)
	{
		base.SaveVitals(ref vitals);
		vitals.SetBleedSpeed(this._bleedingLevel);
		vitals.SetHealSpeed(this._healOverTime);
	}

	// Token: 0x06003022 RID: 12322 RVA: 0x000B76F4 File Offset: 0x000B58F4
	public override void LoadVitals(global::RustProto.Vitals vitals)
	{
		base.LoadVitals(vitals);
		this._bleedingLevel = vitals.BleedSpeed;
		this._healOverTime = vitals.HealSpeed;
	}

	// Token: 0x040019D0 RID: 6608
	private const string CheckLevelMethodName = "CheckLevels";

	// Token: 0x040019D1 RID: 6609
	private const string DoBleedMethodName = "DoBleed";

	// Token: 0x040019D2 RID: 6610
	public float _bleedInterval = 10f;

	// Token: 0x040019D3 RID: 6611
	public float _bleedingLevel;

	// Token: 0x040019D4 RID: 6612
	public float _bleedingLevelMax = 100f;

	// Token: 0x040019D5 RID: 6613
	private float lastBleedTime;

	// Token: 0x040019D6 RID: 6614
	public float checkLevelInterval = 2f;

	// Token: 0x040019D7 RID: 6615
	private global::IDBase bleedAttacker;

	// Token: 0x040019D8 RID: 6616
	private global::IDBase bleedingID;

	// Token: 0x040019D9 RID: 6617
	private float _healOverTime;

	// Token: 0x040019DA RID: 6618
	private float _lastLevelCheckTime;

	// Token: 0x040019DB RID: 6619
	private global::PlayerInventory _playerInv;
}
