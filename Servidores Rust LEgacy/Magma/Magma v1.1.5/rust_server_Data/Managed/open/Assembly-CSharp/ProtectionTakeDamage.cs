using System;
using UnityEngine;

// Token: 0x020005BB RID: 1467
public class ProtectionTakeDamage : global::TakeDamage
{
	// Token: 0x06003051 RID: 12369 RVA: 0x000B82A4 File Offset: 0x000B64A4
	public ProtectionTakeDamage()
	{
	}

	// Token: 0x06003052 RID: 12370 RVA: 0x000B82AC File Offset: 0x000B64AC
	private void InitializeArmorValues()
	{
		this._armorValues = new global::DamageTypeList(this._startArmorValues);
		this.initializedArmor = true;
	}

	// Token: 0x06003053 RID: 12371 RVA: 0x000B82C8 File Offset: 0x000B64C8
	protected new void Awake()
	{
		if (!this.initializedArmor)
		{
			this.InitializeArmorValues();
		}
		base.Awake();
	}

	// Token: 0x06003054 RID: 12372 RVA: 0x000B82E4 File Offset: 0x000B64E4
	protected sealed override void ApplyDamageTypeList(ref global::DamageEvent damage, global::DamageTypeList damageTypes)
	{
		for (int i = 0; i < 6; i++)
		{
			if (this._armorValues[i] > 0f && damageTypes[i] > 0f)
			{
				int index2;
				int index = index2 = i;
				float num = damageTypes[index2];
				damageTypes[index] = num * global::UnityEngine.Mathf.Clamp01(1f - this._armorValues[i] / 200f);
			}
		}
		base.ApplyDamageTypeList(ref damage, damageTypes);
	}

	// Token: 0x06003055 RID: 12373 RVA: 0x000B8364 File Offset: 0x000B6564
	public virtual void SetArmorValues(global::DamageTypeList armor)
	{
		if (!this.initializedArmor)
		{
			this._armorValues = new global::DamageTypeList(armor);
			this.initializedArmor = true;
		}
		else
		{
			this._armorValues.SetArmorValues(armor);
		}
	}

	// Token: 0x06003056 RID: 12374 RVA: 0x000B8398 File Offset: 0x000B6598
	public global::DamageTypeList GetArmorValues()
	{
		return this._armorValues;
	}

	// Token: 0x06003057 RID: 12375 RVA: 0x000B83A0 File Offset: 0x000B65A0
	public virtual float GetArmorValue(int index)
	{
		return this._armorValues[index];
	}

	// Token: 0x06003058 RID: 12376 RVA: 0x000B83B0 File Offset: 0x000B65B0
	private void CopyMembersToProtectionTakeDamage(global::ProtectionTakeDamage other)
	{
		other._startArmorValues = new global::DamageTypeList(this._startArmorValues);
		other.SetArmorValues(this._armorValues);
	}

	// Token: 0x06003059 RID: 12377 RVA: 0x000B83D0 File Offset: 0x000B65D0
	protected override void CopyMembersTo(global::TakeDamage other)
	{
		base.CopyMembersTo(other);
		if (other is global::ProtectionTakeDamage)
		{
			this.CopyMembersToProtectionTakeDamage((global::ProtectionTakeDamage)other);
		}
	}

	// Token: 0x040019FF RID: 6655
	protected const float _maxArmorValue = 200f;

	// Token: 0x04001A00 RID: 6656
	[global::UnityEngine.SerializeField]
	private global::DamageTypeList _startArmorValues;

	// Token: 0x04001A01 RID: 6657
	protected global::DamageTypeList _armorValues;

	// Token: 0x04001A02 RID: 6658
	private bool initializedArmor;
}
