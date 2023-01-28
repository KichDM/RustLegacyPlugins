using System;
using UnityEngine;

// Token: 0x02000539 RID: 1337
public abstract class RPOSDragArbiter
{
	// Token: 0x06002D61 RID: 11617 RVA: 0x000AC724 File Offset: 0x000AA924
	protected RPOSDragArbiter()
	{
	}

	// Token: 0x170009BF RID: 2495
	// (get) Token: 0x06002D62 RID: 11618
	public abstract global::RPOSInventoryCell Instigator { get; }

	// Token: 0x170009C0 RID: 2496
	// (get) Token: 0x06002D63 RID: 11619
	public abstract global::RPOSInventoryCell Under { get; }

	// Token: 0x06002D64 RID: 11620
	public abstract void HoverEnter(global::UnityEngine.GameObject landing);

	// Token: 0x06002D65 RID: 11621
	public abstract void HoverExit(global::UnityEngine.GameObject landing);

	// Token: 0x06002D66 RID: 11622
	public abstract void Land(global::UnityEngine.GameObject landing);
}
