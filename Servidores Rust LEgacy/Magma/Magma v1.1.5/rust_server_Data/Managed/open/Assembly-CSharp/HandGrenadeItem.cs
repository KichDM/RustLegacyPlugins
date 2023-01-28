using System;

// Token: 0x020006EC RID: 1772
public abstract class HandGrenadeItem<T> : global::ThrowableItem<T> where T : global::HandGrenadeDataBlock
{
	// Token: 0x06003C50 RID: 15440 RVA: 0x000D57B0 File Offset: 0x000D39B0
	protected HandGrenadeItem(T db) : base(db)
	{
	}
}
