using System;

// Token: 0x02000847 RID: 2119
public interface IObservableValue
{
	// Token: 0x17000DC3 RID: 3523
	// (get) Token: 0x0600494C RID: 18764
	object Value { get; }

	// Token: 0x17000DC4 RID: 3524
	// (get) Token: 0x0600494D RID: 18765
	bool HasChanged { get; }
}
