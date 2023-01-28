using System;

// Token: 0x0200076B RID: 1899
public interface ICarriableTrans
{
	// Token: 0x06003F24 RID: 16164
	void OnAddedToCarrier(global::TransCarrier carrier);

	// Token: 0x06003F25 RID: 16165
	void OnDroppedFromCarrier(global::TransCarrier carrier);
}
