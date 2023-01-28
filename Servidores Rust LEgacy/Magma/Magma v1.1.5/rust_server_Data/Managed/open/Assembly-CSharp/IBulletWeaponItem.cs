using System;

// Token: 0x020006E1 RID: 1761
public interface IBulletWeaponItem : global::IHeldItem, global::IInventoryItem, global::IWeaponItem
{
	// Token: 0x17000B48 RID: 2888
	// (get) Token: 0x06003C26 RID: 15398
	global::MagazineDataBlock clipType { get; }

	// Token: 0x17000B49 RID: 2889
	// (get) Token: 0x06003C27 RID: 15399
	// (set) Token: 0x06003C28 RID: 15400
	int clipAmmo { get; set; }

	// Token: 0x17000B4A RID: 2890
	// (get) Token: 0x06003C29 RID: 15401
	// (set) Token: 0x06003C2A RID: 15402
	int cachedCasings { get; set; }

	// Token: 0x17000B4B RID: 2891
	// (get) Token: 0x06003C2B RID: 15403
	// (set) Token: 0x06003C2C RID: 15404
	float nextCasingsTime { get; set; }

	// Token: 0x06003C2D RID: 15405
	void ActualReload();
}
