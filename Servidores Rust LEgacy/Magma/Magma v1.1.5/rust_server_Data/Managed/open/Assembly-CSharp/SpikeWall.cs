using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200079D RID: 1949
public class SpikeWall : global::IDLocal
{
	// Token: 0x060040D0 RID: 16592 RVA: 0x000E8B50 File Offset: 0x000E6D50
	public SpikeWall()
	{
	}

	// Token: 0x060040D1 RID: 16593 RVA: 0x000E8B7C File Offset: 0x000E6D7C
	public void Awake()
	{
		this._touching = new global::System.Collections.Generic.List<global::TakeDamage>();
	}

	// Token: 0x060040D2 RID: 16594 RVA: 0x000E8B8C File Offset: 0x000E6D8C
	public void OnHurt(global::DamageEvent damage)
	{
		if ((damage.damageTypes & global::DamageTypeFlags.damage_melee) != (global::DamageTypeFlags)0)
		{
			if (global::UnityEngine.Vector3.Distance(damage.attacker.character.transform.position, base.transform.position) > 8f)
			{
				return;
			}
			float num = damage.amount * this.returnFraction;
			global::TakeDamage.Hurt(this, damage.attacker.character.idMain, new global::DamageTypeList(0f, 0f, num + this.baseReturnDmg, 0f, 0f, 0f), null);
		}
	}

	// Token: 0x060040D3 RID: 16595 RVA: 0x000E8C2C File Offset: 0x000E6E2C
	public global::Character GetFromCollider(global::UnityEngine.Collider other)
	{
		global::IDBase idbase = global::IDBase.Get(other);
		if (!idbase)
		{
			return null;
		}
		return idbase.idMain as global::Character;
	}

	// Token: 0x060040D4 RID: 16596 RVA: 0x000E8C58 File Offset: 0x000E6E58
	private void OnTriggerEnter(global::UnityEngine.Collider other)
	{
		global::Character fromCollider = this.GetFromCollider(other);
		if (fromCollider != null)
		{
			if (this._touching.Contains(fromCollider.takeDamage))
			{
				return;
			}
			this._touching.Add(fromCollider.takeDamage);
		}
		if (this._touching.Count > 0 && !this.running)
		{
			this.SetDamageRunning(true);
		}
	}

	// Token: 0x060040D5 RID: 16597 RVA: 0x000E8CC4 File Offset: 0x000E6EC4
	private void OnTriggerExit(global::UnityEngine.Collider other)
	{
		global::Character fromCollider = this.GetFromCollider(other);
		if (fromCollider != null)
		{
			this._touching.Remove(fromCollider.takeDamage);
		}
		if (this._touching.Count == 0)
		{
			this.SetDamageRunning(false);
		}
	}

	// Token: 0x060040D6 RID: 16598 RVA: 0x000E8D10 File Offset: 0x000E6F10
	public void SetDamageRunning(bool on)
	{
		if (on == this.running)
		{
			return;
		}
		if (on)
		{
			if (!base.IsInvoking("DamageDeal"))
			{
				base.InvokeRepeating("DamageDeal", 0f, 1f);
			}
			this.running = true;
		}
		else
		{
			base.CancelInvoke("DamageDeal");
			this.running = false;
		}
	}

	// Token: 0x060040D7 RID: 16599 RVA: 0x000E8D74 File Offset: 0x000E6F74
	public void DamageDeal()
	{
		if (this._touching.Count == 0)
		{
			this.SetDamageRunning(false);
			return;
		}
		global::DamageTypeList damageTypeList = new global::DamageTypeList(0f, 0f, this.dmgPerTick, 0f, 0f, 0f);
		for (int i = this._touching.Count - 1; i >= 0; i--)
		{
			global::TakeDamage takeDamage = this._touching[i];
			if (takeDamage == null)
			{
				this._touching.Remove(takeDamage);
			}
			else
			{
				global::TakeDamage.Hurt(this, takeDamage.idMain, damageTypeList, null);
			}
		}
	}

	// Token: 0x040021D1 RID: 8657
	public float returnFraction = 0.2f;

	// Token: 0x040021D2 RID: 8658
	public float dmgPerTick = 20f;

	// Token: 0x040021D3 RID: 8659
	public float baseReturnDmg = 5f;

	// Token: 0x040021D4 RID: 8660
	public global::System.Collections.Generic.List<global::TakeDamage> _touching;

	// Token: 0x040021D5 RID: 8661
	private bool running;
}
