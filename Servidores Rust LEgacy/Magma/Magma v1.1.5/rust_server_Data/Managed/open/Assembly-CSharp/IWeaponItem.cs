using System;

// Token: 0x02000711 RID: 1809
public interface IWeaponItem : global::IHeldItem, global::IInventoryItem
{
	// Token: 0x17000BA8 RID: 2984
	// (get) Token: 0x06003D5E RID: 15710
	bool canPrimaryAttack { get; }

	// Token: 0x06003D5F RID: 15711
	void PrimaryAttack(ref global::HumanController.InputSample sample);

	// Token: 0x17000BA9 RID: 2985
	// (get) Token: 0x06003D60 RID: 15712
	bool canSecondaryAttack { get; }

	// Token: 0x06003D61 RID: 15713
	void SecondaryAttack(ref global::HumanController.InputSample sample);

	// Token: 0x06003D62 RID: 15714
	void Reload(ref global::HumanController.InputSample sample);

	// Token: 0x17000BAA RID: 2986
	// (get) Token: 0x06003D63 RID: 15715
	bool canAim { get; }

	// Token: 0x17000BAB RID: 2987
	// (get) Token: 0x06003D64 RID: 15716
	bool deployed { get; }

	// Token: 0x17000BAC RID: 2988
	// (get) Token: 0x06003D65 RID: 15717
	int possibleReloadCount { get; }

	// Token: 0x17000BAD RID: 2989
	// (get) Token: 0x06003D66 RID: 15718
	// (set) Token: 0x06003D67 RID: 15719
	float nextPrimaryAttackTime { get; set; }

	// Token: 0x17000BAE RID: 2990
	// (get) Token: 0x06003D68 RID: 15720
	// (set) Token: 0x06003D69 RID: 15721
	float nextSecondaryAttackTime { get; set; }

	// Token: 0x17000BAF RID: 2991
	// (get) Token: 0x06003D6A RID: 15722
	// (set) Token: 0x06003D6B RID: 15723
	float deployFinishedTime { get; set; }

	// Token: 0x06003D6C RID: 15724
	bool ValidatePrimaryMessageTime(double timestamp);
}
