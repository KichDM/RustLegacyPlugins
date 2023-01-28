using System;

// Token: 0x020005BC RID: 1468
public class RepairReceiver : global::IDLocal
{
	// Token: 0x0600305A RID: 12378 RVA: 0x000B83F0 File Offset: 0x000B65F0
	public RepairReceiver()
	{
	}

	// Token: 0x0600305B RID: 12379 RVA: 0x000B8400 File Offset: 0x000B6600
	public global::ItemDataBlock GetRepairAmmo()
	{
		return this.repairAmmo;
	}

	// Token: 0x04001A03 RID: 6659
	public global::ItemDataBlock repairAmmo;

	// Token: 0x04001A04 RID: 6660
	public int ResForMaxHealth = 0xA;
}
