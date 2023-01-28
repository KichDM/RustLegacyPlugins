using System;
using Facepunch;
using RustProto;
using UnityEngine;

// Token: 0x020005B9 RID: 1465
public class Metabolism : global::IDLocalCharacter
{
	// Token: 0x06003026 RID: 12326 RVA: 0x000B7734 File Offset: 0x000B5934
	public Metabolism()
	{
	}

	// Token: 0x06003027 RID: 12327 RVA: 0x000B7804 File Offset: 0x000B5A04
	// Note: this type is marked as 'beforefieldinit'.
	static Metabolism()
	{
	}

	// Token: 0x06003028 RID: 12328 RVA: 0x000B780C File Offset: 0x000B5A0C
	public void SetTargetActivityLevel(float level)
	{
		this._targetActivityLevel = level;
	}

	// Token: 0x06003029 RID: 12329 RVA: 0x000B7818 File Offset: 0x000B5A18
	public float GetActivityLevel()
	{
		return this._activityLevel;
	}

	// Token: 0x0600302A RID: 12330 RVA: 0x000B7820 File Offset: 0x000B5A20
	public float GetNextConsumeTime()
	{
		return this._lastConsumeTime + 3f;
	}

	// Token: 0x0600302B RID: 12331 RVA: 0x000B7830 File Offset: 0x000B5A30
	public void MarkConsumptionTime()
	{
		this._lastConsumeTime = global::UnityEngine.Time.time;
	}

	// Token: 0x0600302C RID: 12332 RVA: 0x000B7840 File Offset: 0x000B5A40
	public bool CanConsumeYet()
	{
		return this.GetNextConsumeTime() < global::UnityEngine.Time.time;
	}

	// Token: 0x0600302D RID: 12333 RVA: 0x000B7850 File Offset: 0x000B5A50
	public float GetCalorieLevel()
	{
		return this.caloricLevel;
	}

	// Token: 0x0600302E RID: 12334 RVA: 0x000B7858 File Offset: 0x000B5A58
	public float GetRemainingCaloricSpace()
	{
		return this.maxCaloricLevel - this.caloricLevel;
	}

	// Token: 0x0600302F RID: 12335 RVA: 0x000B7868 File Offset: 0x000B5A68
	public float GetRadLevel()
	{
		return this.radiationLevel;
	}

	// Token: 0x06003030 RID: 12336 RVA: 0x000B7870 File Offset: 0x000B5A70
	public bool IsCold()
	{
		return this.coreTemperature < 0f;
	}

	// Token: 0x06003031 RID: 12337 RVA: 0x000B7880 File Offset: 0x000B5A80
	public bool HasRadiationPoisoning()
	{
		return this.radiationLevel > 500f;
	}

	// Token: 0x06003032 RID: 12338 RVA: 0x000B7890 File Offset: 0x000B5A90
	public bool IsPoisoned()
	{
		return this.poisonLevel > 1f;
	}

	// Token: 0x06003033 RID: 12339 RVA: 0x000B78A0 File Offset: 0x000B5AA0
	private void Awake()
	{
		global::CharacterMetabolismTrait trait = base.GetTrait<global::CharacterMetabolismTrait>();
		if (trait)
		{
			this.hungerDamagePerMin = trait.hungerDamagePerMin;
			this.selfTick = trait.selfTick;
			this.tickRate = trait.tickRate;
		}
		this._lastTickTime = global::UnityEngine.Time.time;
		if (this.selfTick)
		{
			base.InvokeRepeating("MetabolicFrame", this.tickRate, this.tickRate);
		}
	}

	// Token: 0x06003034 RID: 12340 RVA: 0x000B7910 File Offset: 0x000B5B10
	public void MakeDirty()
	{
		this._dirty = true;
	}

	// Token: 0x06003035 RID: 12341 RVA: 0x000B791C File Offset: 0x000B5B1C
	public void MakeClean()
	{
		this._dirty = false;
	}

	// Token: 0x06003036 RID: 12342 RVA: 0x000B7928 File Offset: 0x000B5B28
	public bool IsDirty()
	{
		return this._dirty;
	}

	// Token: 0x06003037 RID: 12343 RVA: 0x000B7930 File Offset: 0x000B5B30
	public void SubtractCalories(float numCalories)
	{
		this.caloricLevel -= numCalories;
		if (this.caloricLevel < 0f)
		{
			this.caloricLevel = 0f;
		}
		this.MakeDirty();
	}

	// Token: 0x06003038 RID: 12344 RVA: 0x000B7964 File Offset: 0x000B5B64
	public void AddCalories(float numCalories)
	{
		this.caloricLevel += numCalories;
		if (this.caloricLevel > this.maxCaloricLevel)
		{
			this.caloricLevel = this.maxCaloricLevel;
		}
		this.MakeDirty();
	}

	// Token: 0x06003039 RID: 12345 RVA: 0x000B7998 File Offset: 0x000B5B98
	public void AddWater(float litres)
	{
		this.waterLevelLitre += litres;
		if (this.waterLevelLitre > this.maxWaterLevelLitre)
		{
			this.waterLevelLitre = this.maxWaterLevelLitre;
		}
		this.MakeDirty();
	}

	// Token: 0x0600303A RID: 12346 RVA: 0x000B79CC File Offset: 0x000B5BCC
	public void AddAntiRad(float addAntiRad)
	{
		this.antiRads += addAntiRad;
		this.MakeDirty();
	}

	// Token: 0x0600303B RID: 12347 RVA: 0x000B79E4 File Offset: 0x000B5BE4
	public void AddRads(float rads)
	{
		this.radiationLevel += rads;
		this.MakeDirty();
	}

	// Token: 0x0600303C RID: 12348 RVA: 0x000B79FC File Offset: 0x000B5BFC
	public void AddPoison(float amount)
	{
		this.poisonLevel += amount;
		if (global::UnityEngine.Time.time > this.nextVomitTime)
		{
			this.nextVomitTime = global::UnityEngine.Time.time + 5f;
		}
		this.MakeDirty();
	}

	// Token: 0x0600303D RID: 12349 RVA: 0x000B7A34 File Offset: 0x000B5C34
	public void SubtractPosion(float amount)
	{
		this.poisonLevel -= amount;
		if (this.poisonLevel <= 0f)
		{
			this.nextVomitTime = 0f;
		}
		this.MakeDirty();
	}

	// Token: 0x0600303E RID: 12350 RVA: 0x000B7A68 File Offset: 0x000B5C68
	public void MarkWarm()
	{
		this._lastWarmTime = global::UnityEngine.Time.time;
	}

	// Token: 0x0600303F RID: 12351 RVA: 0x000B7A78 File Offset: 0x000B5C78
	public bool IsWarm()
	{
		return global::UnityEngine.Time.time - this._lastWarmTime <= 1f;
	}

	// Token: 0x06003040 RID: 12352 RVA: 0x000B7A90 File Offset: 0x000B5C90
	private void MetabolicFrame()
	{
		this.MetabolicUpdateFrame();
	}

	// Token: 0x06003041 RID: 12353 RVA: 0x000B7A9C File Offset: 0x000B5C9C
	public global::LifeStatus MetabolicUpdateFrame()
	{
		global::LifeStatus lifeStatus = (!base.alive) ? global::LifeStatus.IsDead : global::LifeStatus.IsAlive;
		if (lifeStatus == global::LifeStatus.IsAlive)
		{
			try
			{
				float time = global::UnityEngine.Time.time;
				float num = time - this._lastTickTime;
				if (num > 0f && (this.selfTick || num >= this.tickRate))
				{
					this._lastTickTime = time;
					global::Metabolism.VitalsUpdate vitalsUpdate = this.CalculateMetabolicVitals(num);
					if (vitalsUpdate.Changed)
					{
						if (vitalsUpdate.IsHurt)
						{
							lifeStatus = global::TakeDamage.HurtSelf(this, vitalsUpdate.HurtAmount, null);
						}
						else
						{
							base.takeDamage.Heal(this, vitalsUpdate.HealAmount);
						}
					}
					if (lifeStatus == global::LifeStatus.IsAlive)
					{
						this.DoNetworkUpdate();
					}
				}
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex, this);
				lifeStatus = ((!base.dead) ? lifeStatus : global::LifeStatus.IsDead);
			}
		}
		return lifeStatus;
	}

	// Token: 0x06003042 RID: 12354 RVA: 0x000B7B98 File Offset: 0x000B5D98
	private global::Metabolism.VitalsUpdate CalculateMetabolicVitals(float timePassed)
	{
		global::Metabolism.VitalsUpdate result = default(global::Metabolism.VitalsUpdate);
		float num = timePassed / 60f;
		float num2 = num / 60f;
		this._activityLevel = global::UnityEngine.Mathf.Lerp(this._activityLevel, this._targetActivityLevel, timePassed / 15f);
		global::TakeDamage takeDamage = base.takeDamage;
		global::HumanBodyTakeDamage humanBodyTakeDamage = takeDamage as global::HumanBodyTakeDamage;
		float num3 = 0f;
		if (humanBodyTakeDamage)
		{
			bool flag = true;
			if (global::EnvironmentControlCenter.Singleton)
			{
				flag = !global::EnvironmentControlCenter.Singleton.IsNight();
			}
			if (this.IsWarm())
			{
				this.coreTemperature = 1f;
			}
			else if (!flag)
			{
				this.coreTemperature = -1f;
			}
			else
			{
				this.coreTemperature = 0f;
			}
			if (this.coreTemperature < 0f)
			{
				float armorValue = humanBodyTakeDamage.GetArmorValue(5);
				this.coreTemperature += armorValue * 0.05f;
				if (this.coreTemperature > 0f)
				{
					this.coreTemperature = 0f;
				}
				float num4 = global::UnityEngine.Mathf.Abs(this.coreTemperature);
				if (this.coreTemperature < 0f)
				{
					num3 = 1500f * num4;
				}
				if (global::Metabolism.dmg_metabolism)
				{
				}
			}
			this.MakeDirty();
		}
		float num5 = this.caloricMetabolicRate + this.GetActivityLevel() * (this.caloricMetabolicRateMax - this.caloricMetabolicRate) + num3;
		float num6 = num5 * num2;
		if (this.caloricLevel <= num6)
		{
			float num7 = num * this.starvingDamagePerMin;
			if (global::Metabolism.dmg_metabolism)
			{
				result.Hurt += num7;
			}
			if (this.caloricLevel != 0f)
			{
				this.MakeDirty();
			}
			this.caloricLevel = 0f;
		}
		else
		{
			this.caloricLevel -= num6;
			this.MakeDirty();
			if (base.healthLoss > 0f && this.radiationLevel < 500f && !humanBodyTakeDamage.IsBleeding() && this.coreTemperature >= 0f && this.TimeSinceHurt() > 10f)
			{
				float num8 = 10f * num;
				float num9 = this.caloriesPerHP * num8;
				if (this.IsWarm())
				{
					num8 *= 5f;
				}
				if (this.caloricLevel >= num9)
				{
					this.caloricLevel -= num9;
					if (takeDamage)
					{
						result.Heal += num8;
					}
				}
			}
		}
		if (this.antiRads > 0f)
		{
			float num10 = global::UnityEngine.Mathf.Clamp(this.antiRadUsePerMin * num, 0f, this.antiRads);
			this.radiationLevel -= num10;
			this.antiRads -= num10;
			if (this.radiationLevel < 0f)
			{
				this.radiationLevel = 0f;
			}
			this.MakeDirty();
		}
		if (this.radiationLevel > 0f)
		{
			float num11 = this.radiationLevel / this.maxRadiationLevel * 300f * num;
			this.radiationLevel = global::UnityEngine.Mathf.Clamp(this.radiationLevel - num11 * ((!this.IsWarm()) ? 5f : 10f), 0f, this.radiationLevel);
			this.MakeDirty();
			if (global::Metabolism.dmg_metabolism && this.radiationLevel > 500f)
			{
				result.Hurt += num11 * ((!this.IsWarm()) ? 1f : 0.33f);
			}
		}
		if (global::UnityEngine.Time.time > this.nextVomitTime && this.poisonLevel > 0f)
		{
			this.nextVomitTime = global::UnityEngine.Time.time + 10f;
			base.networkView.RPC("Vomit", base.networkView.owner, new object[0]);
			float numCalories = (float)global::UnityEngine.Random.Range(0x64, 0xC8);
			this.SubtractCalories(numCalories);
			result.Hurt += 2f;
			this.SubtractPosion(1f);
			this.MakeDirty();
		}
		if (this.poisonLevel > 0f)
		{
			float num12 = this.poisonLevel * 10f * num;
			if (global::Metabolism.dmg_metabolism)
			{
				result.Hurt += num12;
			}
		}
		return result;
	}

	// Token: 0x06003043 RID: 12355 RVA: 0x000B7FFC File Offset: 0x000B61FC
	[global::UnityEngine.RPC]
	public void Vomit()
	{
		if (global::Metabolism.vomitSound == null)
		{
			global::Facepunch.Bundling.Load<global::UnityEngine.AudioClip>("content/shared/sfx/vomit", out global::Metabolism.vomitSound);
		}
		global::Metabolism.vomitSound.Play(1f);
	}

	// Token: 0x06003044 RID: 12356 RVA: 0x000B8030 File Offset: 0x000B6230
	public void MarkDamageTime()
	{
		this._lastDamageTime = global::UnityEngine.Time.time;
	}

	// Token: 0x06003045 RID: 12357 RVA: 0x000B8040 File Offset: 0x000B6240
	public float TimeSinceHurt()
	{
		return global::UnityEngine.Time.time - this._lastDamageTime;
	}

	// Token: 0x06003046 RID: 12358 RVA: 0x000B8050 File Offset: 0x000B6250
	public void OnHurt(global::DamageEvent damage)
	{
		this.MarkDamageTime();
	}

	// Token: 0x06003047 RID: 12359 RVA: 0x000B8058 File Offset: 0x000B6258
	public void DoNetworkUpdate()
	{
		if (this.IsDirty())
		{
			base.networkView.RPC("RecieveNetwork", base.networkView.owner, new object[]
			{
				this.caloricLevel,
				this.waterLevelLitre,
				this.radiationLevel,
				this.antiRads,
				this.coreTemperature,
				this.poisonLevel
			});
		}
		this.MakeClean();
	}

	// Token: 0x06003048 RID: 12360 RVA: 0x000B80EC File Offset: 0x000B62EC
	[global::UnityEngine.RPC]
	public void RecieveNetwork(float calories, float water, float rad, float anti, float temp, float poison)
	{
		this.caloricLevel = calories;
		this.waterLevelLitre = water;
		this.radiationLevel = rad;
		this.antiRads = anti;
		this.coreTemperature = temp;
		this.poisonLevel = poison;
		if (temp >= 1f)
		{
			this._lastWarmTime = global::UnityEngine.Time.time;
		}
		else if (temp < 0f)
		{
			this._lastWarmTime = -1000f;
		}
		global::RPOS.MetabolismUpdate();
	}

	// Token: 0x06003049 RID: 12361 RVA: 0x000B8160 File Offset: 0x000B6360
	public void SaveVitals(ref global::RustProto.Vitals.Builder vitals)
	{
		vitals.SetCalories(this.caloricLevel);
		vitals.SetHydration(this.waterLevelLitre);
		vitals.SetRadiation(this.radiationLevel);
		vitals.SetRadiationAnti(this.antiRads);
		vitals.SetTemperature(this.coreTemperature);
	}

	// Token: 0x0600304A RID: 12362 RVA: 0x000B81B4 File Offset: 0x000B63B4
	public void LoadVitals(global::RustProto.Vitals vitals)
	{
		this.caloricLevel = vitals.Calories;
		this.waterLevelLitre = vitals.Hydration;
		this.radiationLevel = vitals.Radiation;
		this.antiRads = vitals.RadiationAnti;
		this.coreTemperature = vitals.Temperature;
	}

	// Token: 0x040019DD RID: 6621
	private bool _dirty;

	// Token: 0x040019DE RID: 6622
	private float _lastTickTime;

	// Token: 0x040019DF RID: 6623
	[global::System.NonSerialized]
	public float tickRate = 3f;

	// Token: 0x040019E0 RID: 6624
	[global::System.NonSerialized]
	public bool selfTick;

	// Token: 0x040019E1 RID: 6625
	[global::System.NonSerialized]
	public float hungerDamagePerMin = 5f;

	// Token: 0x040019E2 RID: 6626
	private float caloricLevel = 1250f;

	// Token: 0x040019E3 RID: 6627
	private float maxCaloricLevel = 3000f;

	// Token: 0x040019E4 RID: 6628
	private float caloriesPerHP = 5f;

	// Token: 0x040019E5 RID: 6629
	private float starvingDamagePerMin = 10f;

	// Token: 0x040019E6 RID: 6630
	private float waterLevelLitre = 30f;

	// Token: 0x040019E7 RID: 6631
	private float maxWaterLevelLitre = 30f;

	// Token: 0x040019E8 RID: 6632
	private float caloricMetabolicRate = 300f;

	// Token: 0x040019E9 RID: 6633
	private float caloricMetabolicRateMax = 3000f;

	// Token: 0x040019EA RID: 6634
	private float hydrationMetablicRate = 0.125f;

	// Token: 0x040019EB RID: 6635
	private float sweatWaterLossMax = 1.5f;

	// Token: 0x040019EC RID: 6636
	private float radMetabolizationRate = 800f;

	// Token: 0x040019ED RID: 6637
	private float damagePerRad = 0.06f;

	// Token: 0x040019EE RID: 6638
	private float radiationLevel;

	// Token: 0x040019EF RID: 6639
	private float maxRadiationLevel = 3000f;

	// Token: 0x040019F0 RID: 6640
	private float antiRads;

	// Token: 0x040019F1 RID: 6641
	private float antiRadUsePerMin = 3000f;

	// Token: 0x040019F2 RID: 6642
	private float _activityLevel;

	// Token: 0x040019F3 RID: 6643
	private float _targetActivityLevel;

	// Token: 0x040019F4 RID: 6644
	private float _lastConsumeTime;

	// Token: 0x040019F5 RID: 6645
	private float coreTemperature;

	// Token: 0x040019F6 RID: 6646
	private float _lastWarmTime = -1000f;

	// Token: 0x040019F7 RID: 6647
	private float lastVomitTime;

	// Token: 0x040019F8 RID: 6648
	private float nextVomitTime;

	// Token: 0x040019F9 RID: 6649
	private float poisonLevel;

	// Token: 0x040019FA RID: 6650
	private float _lastDamageTime;

	// Token: 0x040019FB RID: 6651
	private static bool dmg_metabolism = true;

	// Token: 0x040019FC RID: 6652
	private static global::UnityEngine.AudioClip vomitSound;

	// Token: 0x020005BA RID: 1466
	private struct VitalsUpdate
	{
		// Token: 0x17000A27 RID: 2599
		// (get) Token: 0x0600304B RID: 12363 RVA: 0x000B8200 File Offset: 0x000B6400
		public bool IsHeal
		{
			get
			{
				return this.Heal > this.Hurt;
			}
		}

		// Token: 0x17000A28 RID: 2600
		// (get) Token: 0x0600304C RID: 12364 RVA: 0x000B8210 File Offset: 0x000B6410
		public bool IsHurt
		{
			get
			{
				return this.Hurt > this.Heal;
			}
		}

		// Token: 0x17000A29 RID: 2601
		// (get) Token: 0x0600304D RID: 12365 RVA: 0x000B8220 File Offset: 0x000B6420
		public bool Unchanged
		{
			get
			{
				return this.Hurt == this.Heal;
			}
		}

		// Token: 0x17000A2A RID: 2602
		// (get) Token: 0x0600304E RID: 12366 RVA: 0x000B8230 File Offset: 0x000B6430
		public bool Changed
		{
			get
			{
				return this.Hurt != this.Heal;
			}
		}

		// Token: 0x17000A2B RID: 2603
		// (get) Token: 0x0600304F RID: 12367 RVA: 0x000B8244 File Offset: 0x000B6444
		public float HurtAmount
		{
			get
			{
				return (!this.IsHurt) ? 0f : (this.Hurt - this.Heal);
			}
		}

		// Token: 0x17000A2C RID: 2604
		// (get) Token: 0x06003050 RID: 12368 RVA: 0x000B8274 File Offset: 0x000B6474
		public float HealAmount
		{
			get
			{
				return (!this.IsHeal) ? 0f : (this.Heal - this.Hurt);
			}
		}

		// Token: 0x040019FD RID: 6653
		public float Hurt;

		// Token: 0x040019FE RID: 6654
		public float Heal;
	}
}
