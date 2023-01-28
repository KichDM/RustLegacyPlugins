using System;

// Token: 0x0200070D RID: 1805
public interface IToolItem : global::IInventoryItem
{
	// Token: 0x17000B9A RID: 2970
	// (get) Token: 0x06003D38 RID: 15672
	bool canWork { get; }

	// Token: 0x06003D39 RID: 15673
	void StartWork();

	// Token: 0x06003D3A RID: 15674
	void CancelWork();

	// Token: 0x06003D3B RID: 15675
	void CompleteWork();

	// Token: 0x17000B9B RID: 2971
	// (get) Token: 0x06003D3C RID: 15676
	float workDuration { get; }
}
