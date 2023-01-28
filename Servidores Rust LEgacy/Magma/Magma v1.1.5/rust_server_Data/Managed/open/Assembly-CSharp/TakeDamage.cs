using System;
using RustProto;
using RustProto.Helpers;
using UnityEngine;

// Token: 0x02000188 RID: 392
[global::UnityEngine.AddComponentMenu("ID/Local/Take Damage")]
public class TakeDamage : global::IDLocal, global::IServerSaveable
{
	// Token: 0x06000B58 RID: 2904 RVA: 0x0002C324 File Offset: 0x0002A524
	public TakeDamage()
	{
	}

	// Token: 0x06000B59 RID: 2905 RVA: 0x0002C354 File Offset: 0x0002A554
	public virtual void SetGodMode(bool on)
	{
		this.takenodamage = on;
	}

	// Token: 0x06000B5A RID: 2906 RVA: 0x0002C360 File Offset: 0x0002A560
	private static float HealthAliveValueClamp(float newHealth)
	{
		return (newHealth >= 0.001f) ? newHealth : 0.001f;
	}

	// Token: 0x06000B5B RID: 2907 RVA: 0x0002C378 File Offset: 0x0002A578
	public bool ShouldPlayHitNotification()
	{
		return this.playsHitNotification && this.alive;
	}

	// Token: 0x06000B5C RID: 2908 RVA: 0x0002C390 File Offset: 0x0002A590
	public void MarkDamageTime()
	{
		this._lastDamageTime = global::UnityEngine.Time.time;
	}

	// Token: 0x06000B5D RID: 2909 RVA: 0x0002C3A0 File Offset: 0x0002A5A0
	public float TimeSinceHurt()
	{
		return global::UnityEngine.Time.time - this._lastDamageTime;
	}

	// Token: 0x06000B5E RID: 2910 RVA: 0x0002C3B0 File Offset: 0x0002A5B0
	public static string DamageIndexToString(int index)
	{
		return global::TakeDamage.DamageIndexToString((global::DamageTypeIndex)index);
	}

	// Token: 0x06000B5F RID: 2911 RVA: 0x0002C3B8 File Offset: 0x0002A5B8
	public static string DamageIndexToString(global::DamageTypeIndex index)
	{
		string result;
		switch (index)
		{
		case global::DamageTypeIndex.damage_bullet:
			result = "Bullet";
			break;
		case global::DamageTypeIndex.damage_melee:
			result = "Melee";
			break;
		case global::DamageTypeIndex.damage_explosion:
			result = "Explosion";
			break;
		case global::DamageTypeIndex.damage_radiation:
			result = "Radiation";
			break;
		case global::DamageTypeIndex.damage_cold:
			result = "Cold";
			break;
		default:
			result = "Generic";
			break;
		}
		return result;
	}

	// Token: 0x17000317 RID: 791
	// (get) Token: 0x06000B60 RID: 2912 RVA: 0x0002C42C File Offset: 0x0002A62C
	// (set) Token: 0x06000B61 RID: 2913 RVA: 0x0002C434 File Offset: 0x0002A634
	public float health
	{
		get
		{
			return this._health;
		}
		set
		{
			this._health = value;
		}
	}

	// Token: 0x17000318 RID: 792
	// (get) Token: 0x06000B62 RID: 2914 RVA: 0x0002C440 File Offset: 0x0002A640
	public float healthFraction
	{
		get
		{
			return this._health / this._maxHealth;
		}
	}

	// Token: 0x17000319 RID: 793
	// (get) Token: 0x06000B63 RID: 2915 RVA: 0x0002C450 File Offset: 0x0002A650
	public float healthLoss
	{
		get
		{
			return this._maxHealth - this.health;
		}
	}

	// Token: 0x1700031A RID: 794
	// (get) Token: 0x06000B64 RID: 2916 RVA: 0x0002C460 File Offset: 0x0002A660
	public float healthLossFraction
	{
		get
		{
			return 1f - this._health / this._maxHealth;
		}
	}

	// Token: 0x1700031B RID: 795
	// (get) Token: 0x06000B65 RID: 2917 RVA: 0x0002C478 File Offset: 0x0002A678
	// (set) Token: 0x06000B66 RID: 2918 RVA: 0x0002C480 File Offset: 0x0002A680
	public float maxHealth
	{
		get
		{
			return this._maxHealth;
		}
		set
		{
			this._maxHealth = value;
		}
	}

	// Token: 0x1700031C RID: 796
	// (get) Token: 0x06000B67 RID: 2919 RVA: 0x0002C48C File Offset: 0x0002A68C
	public bool alive
	{
		get
		{
			return this.health > 0f;
		}
	}

	// Token: 0x1700031D RID: 797
	// (get) Token: 0x06000B68 RID: 2920 RVA: 0x0002C49C File Offset: 0x0002A69C
	public bool dead
	{
		get
		{
			return this.health <= 0f;
		}
	}

	// Token: 0x06000B69 RID: 2921 RVA: 0x0002C4B0 File Offset: 0x0002A6B0
	protected void Awake()
	{
		this._maxHealth = (this._health = global::TakeDamage.HealthAliveValueClamp(this._maxHealth));
	}

	// Token: 0x06000B6A RID: 2922 RVA: 0x0002C4D8 File Offset: 0x0002A6D8
	public global::RepairEvent Heal(global::IDBase healer, float amount)
	{
		global::RepairEvent result;
		this.Heal(healer, amount, out result);
		return result;
	}

	// Token: 0x06000B6B RID: 2923 RVA: 0x0002C4F4 File Offset: 0x0002A6F4
	public global::RepairStatus Heal(global::IDBase healer, float amount, out global::RepairEvent repair)
	{
		repair.doner = healer;
		repair.receiver = this;
		repair.givenAmount = amount;
		if (amount <= 0f)
		{
			repair.status = global::RepairStatus.Failed;
			repair.usedAmount = 0f;
			return global::RepairStatus.Failed;
		}
		if (this.dead)
		{
			repair.status = global::RepairStatus.FailedUnreparable;
			repair.usedAmount = 0f;
		}
		else if (this._health == this._maxHealth)
		{
			repair.status = global::RepairStatus.FailedFull;
			repair.usedAmount = 0f;
		}
		else if (this._health > this._maxHealth - amount)
		{
			this._health = this._maxHealth;
			repair.usedAmount = this._maxHealth - this._health;
			repair.status = global::RepairStatus.AppliedPartial;
		}
		else
		{
			this._health += amount;
			repair.usedAmount = repair.givenAmount;
			if (this._health == this._maxHealth)
			{
				repair.status = global::RepairStatus.AppliedFull;
			}
			else
			{
				repair.status = global::RepairStatus.Applied;
			}
		}
		if (this.sendMessageRepair)
		{
			base.SendMessage("OnRepair", repair, 1);
		}
		return repair.status;
	}

	// Token: 0x06000B6C RID: 2924 RVA: 0x0002C624 File Offset: 0x0002A824
	public static global::LifeStatus Hurt(global::IDBase attacker, global::IDBase victim, global::TakeDamage.Quantity damageQuantity, out global::DamageEvent damage, object extraData = null)
	{
		return global::TakeDamage.HurtShared(attacker, victim, damageQuantity, out damage, extraData);
	}

	// Token: 0x06000B6D RID: 2925 RVA: 0x0002C634 File Offset: 0x0002A834
	public static global::LifeStatus Hurt(global::IDBase attacker, global::IDBase victim, global::TakeDamage.Quantity damageQuantity, object extraData = null)
	{
		return global::TakeDamage.HurtShared(attacker, victim, damageQuantity, extraData);
	}

	// Token: 0x06000B6E RID: 2926 RVA: 0x0002C640 File Offset: 0x0002A840
	public static global::LifeStatus Kill(global::IDBase attacker, global::IDBase victim, out global::DamageEvent damage, object extraData = null)
	{
		return global::TakeDamage.HurtShared(attacker, victim, global::TakeDamage.Quantity.AllHealth, out damage, extraData);
	}

	// Token: 0x06000B6F RID: 2927 RVA: 0x0002C650 File Offset: 0x0002A850
	public static global::LifeStatus Kill(global::IDBase attacker, global::IDBase victim, object extraData = null)
	{
		return global::TakeDamage.HurtShared(attacker, victim, global::TakeDamage.Quantity.AllHealth, extraData);
	}

	// Token: 0x06000B70 RID: 2928 RVA: 0x0002C660 File Offset: 0x0002A860
	public static global::LifeStatus HurtSelf(global::IDBase victim, global::TakeDamage.Quantity damageQuantity, out global::DamageEvent damage, object extraData = null)
	{
		return global::TakeDamage.HurtShared(victim, victim, damageQuantity, out damage, extraData);
	}

	// Token: 0x06000B71 RID: 2929 RVA: 0x0002C66C File Offset: 0x0002A86C
	public static global::LifeStatus HurtSelf(global::IDBase victim, global::TakeDamage.Quantity damageQuantity, object extraData = null)
	{
		return global::TakeDamage.HurtShared(victim, victim, damageQuantity, extraData);
	}

	// Token: 0x06000B72 RID: 2930 RVA: 0x0002C678 File Offset: 0x0002A878
	public static global::LifeStatus KillSelf(global::IDBase victim, object extraData = null)
	{
		return global::TakeDamage.HurtShared(victim, victim, global::TakeDamage.Quantity.AllHealth, extraData);
	}

	// Token: 0x06000B73 RID: 2931 RVA: 0x0002C688 File Offset: 0x0002A888
	public static global::LifeStatus KillSelf(global::IDBase victim, out global::DamageEvent damage, object extraData = null)
	{
		return global::TakeDamage.HurtShared(victim, victim, global::TakeDamage.Quantity.AllHealth, out damage, extraData);
	}

	// Token: 0x06000B74 RID: 2932 RVA: 0x0002C698 File Offset: 0x0002A898
	private static global::LifeStatus HurtShared(global::IDBase attacker, global::IDBase victim, global::TakeDamage.Quantity damageQuantity, out global::DamageEvent damage, object extraData = null)
	{
		if (victim)
		{
			global::IDMain idMain = victim.idMain;
			if (idMain)
			{
				global::TakeDamage takeDamage;
				if (idMain is global::Character)
				{
					takeDamage = ((global::Character)idMain).takeDamage;
				}
				else
				{
					takeDamage = idMain.GetLocal<global::TakeDamage>();
				}
				if (takeDamage && !takeDamage.takenodamage)
				{
					takeDamage.MarkDamageTime();
					damage.victim.id = victim;
					damage.attacker.id = attacker;
					damage.amount = damageQuantity.value;
					damage.sender = takeDamage;
					damage.status = ((!takeDamage.dead) ? global::LifeStatus.IsAlive : global::LifeStatus.IsDead);
					damage.damageTypes = (global::DamageTypeFlags)0;
					damage.extraData = extraData;
					if ((int)damageQuantity.Unit == -1)
					{
						takeDamage.ApplyDamageTypeList(ref damage, damageQuantity.list);
					}
					takeDamage.Hurt(ref damage);
					return damage.status;
				}
			}
		}
		damage.victim.id = null;
		damage.attacker.id = null;
		damage.amount = 0f;
		damage.sender = null;
		damage.damageTypes = (global::DamageTypeFlags)0;
		damage.status = global::LifeStatus.Failed;
		damage.extraData = extraData;
		return global::LifeStatus.Failed;
	}

	// Token: 0x06000B75 RID: 2933 RVA: 0x0002C7C0 File Offset: 0x0002A9C0
	private static global::LifeStatus HurtShared(global::IDBase attacker, global::IDBase victim, global::TakeDamage.Quantity damageQuantity, object extraData = null)
	{
		global::DamageEvent damageEvent;
		return global::TakeDamage.HurtShared(attacker, victim, damageQuantity, out damageEvent, extraData);
	}

	// Token: 0x06000B76 RID: 2934 RVA: 0x0002C7D8 File Offset: 0x0002A9D8
	protected virtual void ApplyDamageTypeList(ref global::DamageEvent damage, global::DamageTypeList damageTypes)
	{
		for (int i = 0; i < 6; i++)
		{
			if (!global::UnityEngine.Mathf.Approximately(damageTypes[i], 0f))
			{
				damage.damageTypes |= (global::DamageTypeFlags)(1 << i);
				damage.amount += damageTypes[i];
			}
		}
	}

	// Token: 0x06000B77 RID: 2935 RVA: 0x0002C834 File Offset: 0x0002AA34
	protected virtual global::LifeStatus Hurt(ref global::DamageEvent damage)
	{
		if (this.dead)
		{
			damage.status = global::LifeStatus.IsDead;
		}
		else if (this.health > damage.amount)
		{
			damage.status = global::LifeStatus.IsAlive;
		}
		else
		{
			damage.status = global::LifeStatus.WasKilled;
		}
		this.ProcessDamageEvent(ref damage);
		if (this.ShouldRelayDamageEvent(ref damage))
		{
			base.SendMessage("OnHurt", damage, 1);
		}
		if (damage.status == global::LifeStatus.WasKilled)
		{
			global::Character character = this.idMain as global::Character;
			if (character)
			{
				character.Signal_ServerCharacterDeath();
			}
			global::FeedbackLog.Start(global::FeedbackLog.TYPE.Death);
			global::FeedbackLog.WriteVector(base.transform.position);
			global::FeedbackLog.WriteObject(base.gameObject);
			if (damage.attacker)
			{
				global::FeedbackLog.WriteObject(damage.attacker.idMain.gameObject);
			}
			else
			{
				global::FeedbackLog.WriteObject(null);
			}
			if (damage.victim)
			{
				global::FeedbackLog.WriteObject(damage.victim.idMain.gameObject);
			}
			else
			{
				global::FeedbackLog.WriteObject(null);
			}
			global::FeedbackLog.End(global::FeedbackLog.TYPE.Death);
			base.SendMessage("OnKilled", damage, 1);
		}
		return damage.status;
	}

	// Token: 0x06000B78 RID: 2936 RVA: 0x0002C978 File Offset: 0x0002AB78
	protected void ProcessDamageEvent(ref global::DamageEvent damage)
	{
		if (this.takenodamage)
		{
			return;
		}
		global::LifeStatus status = damage.status;
		if (status != global::LifeStatus.IsAlive)
		{
			if (status == global::LifeStatus.WasKilled)
			{
				this._health = 0f;
			}
		}
		else
		{
			this._health -= damage.amount;
		}
	}

	// Token: 0x06000B79 RID: 2937 RVA: 0x0002C9D8 File Offset: 0x0002ABD8
	protected bool ShouldRelayDamageEvent(ref global::DamageEvent damage)
	{
		switch (damage.status)
		{
		case global::LifeStatus.IsAlive:
			return this.sendMessageWhenAlive;
		case global::LifeStatus.WasKilled:
			return this.sendMessageWhenKilled;
		case global::LifeStatus.IsDead:
			return this.sendMessageWhenDead;
		default:
			global::UnityEngine.Debug.LogWarning("Unhandled LifeStatus " + damage.status, this);
			return false;
		}
	}

	// Token: 0x06000B7A RID: 2938 RVA: 0x0002CA34 File Offset: 0x0002AC34
	public override string ToString()
	{
		return string.Format("[{0}: health={1}]", base.ToString(), this.health);
	}

	// Token: 0x06000B7B RID: 2939 RVA: 0x0002CA54 File Offset: 0x0002AC54
	public virtual void ServerFrame()
	{
	}

	// Token: 0x06000B7C RID: 2940 RVA: 0x0002CA58 File Offset: 0x0002AC58
	public virtual void SaveVitals(ref global::RustProto.Vitals.Builder vitals)
	{
		vitals.SetHealth(this.health);
	}

	// Token: 0x06000B7D RID: 2941 RVA: 0x0002CA68 File Offset: 0x0002AC68
	public virtual void LoadVitals(global::RustProto.Vitals vitals)
	{
		this.health = vitals.Health;
		if (this.health <= 0f)
		{
			global::UnityEngine.Debug.Log("LOAD VITALS - HEALTH WAS " + this.health);
			this.health = 1f;
		}
	}

	// Token: 0x06000B7E RID: 2942 RVA: 0x0002CAB8 File Offset: 0x0002ACB8
	protected virtual void CopyMembersTo(global::TakeDamage other)
	{
		other._maxHealth = this._maxHealth;
		other._health = this._health;
	}

	// Token: 0x06000B7F RID: 2943 RVA: 0x0002CAD4 File Offset: 0x0002ACD4
	public void CopyStateTo(global::TakeDamage other)
	{
		if (other != this && other)
		{
			this.CopyMembersTo(other);
		}
	}

	// Token: 0x06000B80 RID: 2944 RVA: 0x0002CAF4 File Offset: 0x0002ACF4
	protected bool WriteTakeDamageSave(ref global::RustProto.objectTakeDamage.Builder builder)
	{
		builder.SetHealth(this.health);
		return true;
	}

	// Token: 0x06000B81 RID: 2945 RVA: 0x0002CB08 File Offset: 0x0002AD08
	protected void ReadTakeDamageSave(global::RustProto.objectTakeDamage message)
	{
		if (message.HasHealth)
		{
			this.health = message.Health;
		}
	}

	// Token: 0x06000B82 RID: 2946 RVA: 0x0002CB24 File Offset: 0x0002AD24
	public void WriteObjectSave(ref global::RustProto.SavedObject.Builder saveobj)
	{
		using (global::RustProto.Helpers.Recycler<global::RustProto.objectTakeDamage, global::RustProto.objectTakeDamage.Builder> recycler = global::RustProto.objectTakeDamage.Recycler())
		{
			global::RustProto.objectTakeDamage.Builder takeDamage = recycler.OpenBuilder();
			if (this.WriteTakeDamageSave(ref takeDamage))
			{
				saveobj.SetTakeDamage(takeDamage);
			}
		}
	}

	// Token: 0x06000B83 RID: 2947 RVA: 0x0002CB84 File Offset: 0x0002AD84
	public void ReadObjectSave(ref global::RustProto.SavedObject saveobj)
	{
		if (saveobj.HasTakeDamage)
		{
			this.ReadTakeDamageSave(saveobj.TakeDamage);
		}
	}

	// Token: 0x040007CE RID: 1998
	public const string DamageMessage = "OnHurt";

	// Token: 0x040007CF RID: 1999
	public const string KillMessage = "OnKilled";

	// Token: 0x040007D0 RID: 2000
	public const string RepairMessage = "OnRepair";

	// Token: 0x040007D1 RID: 2001
	public const global::UnityEngine.SendMessageOptions DamageMessageOptions = 1;

	// Token: 0x040007D2 RID: 2002
	public const global::UnityEngine.SendMessageOptions RepairMessageOptions = 1;

	// Token: 0x040007D3 RID: 2003
	public const float kMinimumSetHealthValueWhenAlive = 0.001f;

	// Token: 0x040007D4 RID: 2004
	protected float _lastDamageTime;

	// Token: 0x040007D5 RID: 2005
	private bool takenodamage;

	// Token: 0x040007D6 RID: 2006
	[global::UnityEngine.SerializeField]
	private float _maxHealth = 100f;

	// Token: 0x040007D7 RID: 2007
	private float _health;

	// Token: 0x040007D8 RID: 2008
	public bool playsHitNotification;

	// Token: 0x040007D9 RID: 2009
	public bool sendMessageWhenAlive = true;

	// Token: 0x040007DA RID: 2010
	public bool sendMessageWhenKilled = true;

	// Token: 0x040007DB RID: 2011
	public bool sendMessageWhenDead = true;

	// Token: 0x040007DC RID: 2012
	public bool sendMessageRepair = true;

	// Token: 0x02000189 RID: 393
	public enum Unit : sbyte
	{
		// Token: 0x040007DE RID: 2014
		Unspecified,
		// Token: 0x040007DF RID: 2015
		HealthPoints,
		// Token: 0x040007E0 RID: 2016
		AllHealth,
		// Token: 0x040007E1 RID: 2017
		List = -1
	}

	// Token: 0x0200018A RID: 394
	public struct Quantity
	{
		// Token: 0x06000B84 RID: 2948 RVA: 0x0002CBA0 File Offset: 0x0002ADA0
		private Quantity(global::TakeDamage.Unit Measurement, global::DamageTypeList DamageTypeList, float Value)
		{
			this.Unit = Measurement;
			this.list = DamageTypeList;
			this.value = Value;
		}

		// Token: 0x1700031E RID: 798
		// (get) Token: 0x06000B85 RID: 2949 RVA: 0x0002CBB8 File Offset: 0x0002ADB8
		public static global::TakeDamage.Quantity AllHealth
		{
			get
			{
				return new global::TakeDamage.Quantity(global::TakeDamage.Unit.AllHealth, null, float.PositiveInfinity);
			}
		}

		// Token: 0x1700031F RID: 799
		// (get) Token: 0x06000B86 RID: 2950 RVA: 0x0002CBC8 File Offset: 0x0002ADC8
		public global::DamageTypeList DamageTypeList
		{
			get
			{
				if ((int)this.Unit > 0)
				{
					throw new global::System.InvalidOperationException("Quantity is of HealthPoints");
				}
				return this.list;
			}
		}

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x06000B87 RID: 2951 RVA: 0x0002CBE8 File Offset: 0x0002ADE8
		public bool IsDamageTypeList
		{
			get
			{
				return (int)this.Unit == -1;
			}
		}

		// Token: 0x17000321 RID: 801
		// (get) Token: 0x06000B88 RID: 2952 RVA: 0x0002CBF4 File Offset: 0x0002ADF4
		public float HealthPoints
		{
			get
			{
				if ((int)this.Unit < -1)
				{
					throw new global::System.InvalidOperationException("Quantity is of DamageTypeList");
				}
				return this.value;
			}
		}

		// Token: 0x17000322 RID: 802
		// (get) Token: 0x06000B89 RID: 2953 RVA: 0x0002CC14 File Offset: 0x0002AE14
		public bool IsHealthPoints
		{
			get
			{
				return (int)this.Unit > 0;
			}
		}

		// Token: 0x17000323 RID: 803
		// (get) Token: 0x06000B8A RID: 2954 RVA: 0x0002CC20 File Offset: 0x0002AE20
		public bool IsAllHealthPoints
		{
			get
			{
				return (int)this.Unit == 2;
			}
		}

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x06000B8B RID: 2955 RVA: 0x0002CC2C File Offset: 0x0002AE2C
		public bool Specified
		{
			get
			{
				return (int)this.Unit != 0;
			}
		}

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x06000B8C RID: 2956 RVA: 0x0002CC3C File Offset: 0x0002AE3C
		public object BoxedValue
		{
			get
			{
				return ((int)this.Unit > 0) ? this.value : this.list;
			}
		}

		// Token: 0x06000B8D RID: 2957 RVA: 0x0002CC64 File Offset: 0x0002AE64
		public override string ToString()
		{
			return string.Format("[{0}:{1}]", this.Unit, this.BoxedValue);
		}

		// Token: 0x06000B8E RID: 2958 RVA: 0x0002CC84 File Offset: 0x0002AE84
		public static implicit operator global::TakeDamage.Quantity(int HealthPoints)
		{
			return new global::TakeDamage.Quantity((HealthPoints != 0) ? global::TakeDamage.Unit.HealthPoints : global::TakeDamage.Unit.Unspecified, null, (float)((HealthPoints >= 0) ? HealthPoints : (-(float)HealthPoints)));
		}

		// Token: 0x06000B8F RID: 2959 RVA: 0x0002CCAC File Offset: 0x0002AEAC
		public static implicit operator global::TakeDamage.Quantity(float HealthPoints)
		{
			return new global::TakeDamage.Quantity((HealthPoints != 0f) ? ((!float.IsInfinity(HealthPoints)) ? global::TakeDamage.Unit.HealthPoints : global::TakeDamage.Unit.AllHealth) : global::TakeDamage.Unit.Unspecified, null, HealthPoints);
		}

		// Token: 0x06000B90 RID: 2960 RVA: 0x0002CCE4 File Offset: 0x0002AEE4
		public static implicit operator global::TakeDamage.Quantity(global::DamageTypeList DamageTypeList)
		{
			return new global::TakeDamage.Quantity((!object.ReferenceEquals(DamageTypeList, null)) ? global::TakeDamage.Unit.List : global::TakeDamage.Unit.Unspecified, DamageTypeList, 0f);
		}

		// Token: 0x040007E2 RID: 2018
		public readonly global::TakeDamage.Unit Unit;

		// Token: 0x040007E3 RID: 2019
		internal readonly float value;

		// Token: 0x040007E4 RID: 2020
		internal readonly global::DamageTypeList list;
	}
}
