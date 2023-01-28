using System;

namespace Magma.Events
{
	// Token: 0x0200000A RID: 10
	public class DecayEvent
	{
		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00002C2E File Offset: 0x00000E2E
		// (set) Token: 0x06000056 RID: 86 RVA: 0x00002C36 File Offset: 0x00000E36
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

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00002C3F File Offset: 0x00000E3F
		// (set) Token: 0x06000058 RID: 88 RVA: 0x00002C47 File Offset: 0x00000E47
		public float DamageAmount
		{
			get
			{
				return this._dmg;
			}
			set
			{
				this._dmg = value;
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00002C50 File Offset: 0x00000E50
		public DecayEvent(global::Magma.Entity en, ref float dmg)
		{
			this.Entity = en;
			this.DamageAmount = dmg;
		}

		// Token: 0x0400001B RID: 27
		private global::Magma.Entity _ent;

		// Token: 0x0400001C RID: 28
		private float _dmg;
	}
}
