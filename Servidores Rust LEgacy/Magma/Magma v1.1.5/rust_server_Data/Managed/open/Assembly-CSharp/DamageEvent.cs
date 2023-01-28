using System;

// Token: 0x02000182 RID: 386
public struct DamageEvent
{
	// Token: 0x17000313 RID: 787
	// (get) Token: 0x06000B4C RID: 2892 RVA: 0x0002BE90 File Offset: 0x0002A090
	public global::BodyPart bodyPart
	{
		get
		{
			return this.victim.bodyPart;
		}
	}

	// Token: 0x06000B4D RID: 2893 RVA: 0x0002BEA0 File Offset: 0x0002A0A0
	public override string ToString()
	{
		return string.Format("{{attacker={3}, victim={0}, amount={1}, status={2}, sender={4}}}", new object[]
		{
			this.victim,
			this.amount,
			this.status,
			this.attacker,
			this.sender
		});
	}

	// Token: 0x040007AA RID: 1962
	public global::DamageBeing attacker;

	// Token: 0x040007AB RID: 1963
	public global::DamageBeing victim;

	// Token: 0x040007AC RID: 1964
	public global::TakeDamage sender;

	// Token: 0x040007AD RID: 1965
	public global::LifeStatus status;

	// Token: 0x040007AE RID: 1966
	public global::DamageTypeFlags damageTypes;

	// Token: 0x040007AF RID: 1967
	public float amount;

	// Token: 0x040007B0 RID: 1968
	public object extraData;
}
