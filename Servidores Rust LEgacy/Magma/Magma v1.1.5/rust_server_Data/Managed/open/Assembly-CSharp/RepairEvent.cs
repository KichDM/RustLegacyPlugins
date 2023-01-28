using System;

// Token: 0x02000184 RID: 388
public struct RepairEvent
{
	// Token: 0x17000314 RID: 788
	// (get) Token: 0x06000B4E RID: 2894 RVA: 0x0002BF00 File Offset: 0x0002A100
	public global::IDMain beneficiary
	{
		get
		{
			return (!this.receiver) ? null : this.receiver.idMain;
		}
	}

	// Token: 0x06000B4F RID: 2895 RVA: 0x0002BF24 File Offset: 0x0002A124
	public override string ToString()
	{
		return string.Format("[RepairEvent: beneficiary={0} givenAmount={1} usedAmount={5} status={2} doner={3} receiver={4}]", new object[]
		{
			this.beneficiary,
			this.givenAmount,
			this.status,
			this.doner,
			this.receiver,
			this.usedAmount
		});
	}

	// Token: 0x040007B8 RID: 1976
	public global::IDBase doner;

	// Token: 0x040007B9 RID: 1977
	public global::TakeDamage receiver;

	// Token: 0x040007BA RID: 1978
	public float givenAmount;

	// Token: 0x040007BB RID: 1979
	public float usedAmount;

	// Token: 0x040007BC RID: 1980
	public global::RepairStatus status;
}
