using System;

namespace Facepunch.Build
{
	// Token: 0x0200010A RID: 266
	public interface ConnectionHandler : global::System.IDisposable
	{
		// Token: 0x170000EF RID: 239
		// (get) Token: 0x060005D2 RID: 1490
		string address { get; }

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x060005D3 RID: 1491
		int? port { get; }
	}
}
