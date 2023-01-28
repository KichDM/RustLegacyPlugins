using System;

namespace Magma.Events
{
	// Token: 0x02000008 RID: 8
	public class HurtEvent
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00002A04 File Offset: 0x00000C04
		// (set) Token: 0x06000040 RID: 64 RVA: 0x00002A0C File Offset: 0x00000C0C
		public object Attacker
		{
			get
			{
				return this._attacker;
			}
			set
			{
				this._attacker = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00002A15 File Offset: 0x00000C15
		// (set) Token: 0x06000042 RID: 66 RVA: 0x00002A1D File Offset: 0x00000C1D
		public object Victim
		{
			get
			{
				return this._victim;
			}
			set
			{
				this._victim = value;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00002A26 File Offset: 0x00000C26
		// (set) Token: 0x06000044 RID: 68 RVA: 0x00002A2E File Offset: 0x00000C2E
		public global::Magma.Entity Entity
		{
			get
			{
				return this._ent;
			}
			set
			{
				this._ent = value;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000045 RID: 69 RVA: 0x00002A37 File Offset: 0x00000C37
		// (set) Token: 0x06000046 RID: 70 RVA: 0x00002A3F File Offset: 0x00000C3F
		public string WeaponName
		{
			get
			{
				return this._weapon;
			}
			set
			{
				this._weapon = value;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00002A48 File Offset: 0x00000C48
		// (set) Token: 0x06000048 RID: 72 RVA: 0x00002A55 File Offset: 0x00000C55
		public float DamageAmount
		{
			get
			{
				return this._de.amount;
			}
			set
			{
				this._de.amount = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00002A63 File Offset: 0x00000C63
		// (set) Token: 0x0600004A RID: 74 RVA: 0x00002A6B File Offset: 0x00000C6B
		public global::DamageEvent DamageEvent
		{
			get
			{
				return this._de;
			}
			set
			{
				this._de = value;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600004B RID: 75 RVA: 0x00002A74 File Offset: 0x00000C74
		// (set) Token: 0x0600004C RID: 76 RVA: 0x00002A7C File Offset: 0x00000C7C
		public global::WeaponImpact WeaponData
		{
			get
			{
				return this._wi;
			}
			set
			{
				this._wi = value;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00002A88 File Offset: 0x00000C88
		public string DamageType
		{
			get
			{
				string result = "Unknown";
				int damageTypes = (int)this.DamageEvent.damageTypes;
				switch (damageTypes)
				{
				case 0:
					result = "Bleeding";
					break;
				case 1:
					result = "Generic";
					break;
				case 2:
					result = "Bullet";
					break;
				case 3:
				case 5:
				case 6:
				case 7:
					break;
				case 4:
					result = "Melee";
					break;
				case 8:
					result = "Explosion";
					break;
				default:
					if (damageTypes != 0x10)
					{
						if (damageTypes == 0x20)
						{
							result = "Cold";
						}
					}
					else
					{
						result = "Radiation";
					}
					break;
				}
				return result;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600004E RID: 78 RVA: 0x00002B14 File Offset: 0x00000D14
		// (set) Token: 0x0600004F RID: 79 RVA: 0x00002B1C File Offset: 0x00000D1C
		public bool IsDecay
		{
			get
			{
				return this._decay;
			}
			set
			{
				this._decay = value;
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002B28 File Offset: 0x00000D28
		public HurtEvent(ref global::DamageEvent d)
		{
			global::Magma.Player player = global::Magma.Player.FindByPlayerClient(d.attacker.client);
			if (player != null)
			{
				this.Attacker = player;
			}
			else
			{
				this.Attacker = new global::Magma.NPC(d.attacker.character);
			}
			global::Magma.Player player2 = global::Magma.Player.FindByPlayerClient(d.victim.client);
			if (player2 != null)
			{
				this.Victim = player2;
			}
			else
			{
				this.Victim = new global::Magma.NPC(d.victim.character);
			}
			this.DamageEvent = d;
			this.WeaponData = null;
			this.IsDecay = false;
			if (d.extraData != null)
			{
				global::WeaponImpact weaponImpact = d.extraData as global::WeaponImpact;
				this.WeaponData = weaponImpact;
				string weaponName = "";
				if (weaponImpact.dataBlock != null)
				{
					weaponName = weaponImpact.dataBlock.name;
				}
				this.WeaponName = weaponName;
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002BFD File Offset: 0x00000DFD
		public HurtEvent(ref global::DamageEvent d, global::Magma.Entity en) : this(ref d)
		{
			this.Entity = en;
		}

		// Token: 0x04000013 RID: 19
		private object _attacker;

		// Token: 0x04000014 RID: 20
		private object _victim;

		// Token: 0x04000015 RID: 21
		private global::Magma.Entity _ent;

		// Token: 0x04000016 RID: 22
		private string _weapon;

		// Token: 0x04000017 RID: 23
		private global::DamageEvent _de;

		// Token: 0x04000018 RID: 24
		private global::WeaponImpact _wi;

		// Token: 0x04000019 RID: 25
		private bool _decay;
	}
}
