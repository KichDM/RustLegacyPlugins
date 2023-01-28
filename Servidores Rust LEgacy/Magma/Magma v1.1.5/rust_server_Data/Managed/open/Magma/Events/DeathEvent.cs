using System;

namespace Magma.Events
{
	// Token: 0x02000009 RID: 9
	public class DeathEvent : global::Magma.Events.HurtEvent
	{
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00002C0D File Offset: 0x00000E0D
		// (set) Token: 0x06000053 RID: 83 RVA: 0x00002C15 File Offset: 0x00000E15
		public bool DropItems
		{
			get
			{
				return this._drop;
			}
			set
			{
				this._drop = value;
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002C1E File Offset: 0x00000E1E
		public DeathEvent(ref global::DamageEvent d) : base(ref d)
		{
			this.DropItems = true;
		}

		// Token: 0x0400001A RID: 26
		private bool _drop;
	}
}
