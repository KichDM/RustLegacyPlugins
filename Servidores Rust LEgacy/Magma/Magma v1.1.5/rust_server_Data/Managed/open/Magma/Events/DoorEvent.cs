using System;

namespace Magma.Events
{
	// Token: 0x02000006 RID: 6
	public class DoorEvent
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600002F RID: 47 RVA: 0x000028EE File Offset: 0x00000AEE
		// (set) Token: 0x06000030 RID: 48 RVA: 0x000028F6 File Offset: 0x00000AF6
		public bool Open
		{
			get
			{
				return this._open;
			}
			set
			{
				this._open = value;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000031 RID: 49 RVA: 0x000028FF File Offset: 0x00000AFF
		// (set) Token: 0x06000032 RID: 50 RVA: 0x00002907 File Offset: 0x00000B07
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

		// Token: 0x06000033 RID: 51 RVA: 0x00002910 File Offset: 0x00000B10
		public DoorEvent(global::Magma.Entity e)
		{
			this.Open = false;
			this.Entity = e;
		}

		// Token: 0x0400000C RID: 12
		private bool _open;

		// Token: 0x0400000D RID: 13
		private global::Magma.Entity _ent;
	}
}
