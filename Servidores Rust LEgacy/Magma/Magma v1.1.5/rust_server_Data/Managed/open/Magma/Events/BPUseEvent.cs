using System;

namespace Magma.Events
{
	// Token: 0x02000005 RID: 5
	public class BPUseEvent
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000029 RID: 41 RVA: 0x000028A4 File Offset: 0x00000AA4
		// (set) Token: 0x0600002A RID: 42 RVA: 0x000028AC File Offset: 0x00000AAC
		public global::BlueprintDataBlock DataBlock
		{
			get
			{
				return this._bdb;
			}
			set
			{
				this._bdb = value;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600002B RID: 43 RVA: 0x000028B5 File Offset: 0x00000AB5
		// (set) Token: 0x0600002C RID: 44 RVA: 0x000028BD File Offset: 0x00000ABD
		public bool Cancel
		{
			get
			{
				return this._cancel;
			}
			set
			{
				this._cancel = value;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600002D RID: 45 RVA: 0x000028C6 File Offset: 0x00000AC6
		public string ItemName
		{
			get
			{
				return this._bdb.resultItem.name;
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000028D8 File Offset: 0x00000AD8
		public BPUseEvent(global::BlueprintDataBlock bdb)
		{
			this.DataBlock = bdb;
			this.Cancel = false;
		}

		// Token: 0x0400000A RID: 10
		private global::BlueprintDataBlock _bdb;

		// Token: 0x0400000B RID: 11
		private bool _cancel;
	}
}
