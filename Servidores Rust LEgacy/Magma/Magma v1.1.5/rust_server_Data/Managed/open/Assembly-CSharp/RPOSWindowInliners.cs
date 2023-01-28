using System;

// Token: 0x02000544 RID: 1348
public static class RPOSWindowInliners
{
	// Token: 0x06002E08 RID: 11784 RVA: 0x000AEF9C File Offset: 0x000AD19C
	public static TRPOSWindow EnsureAwake<TRPOSWindow>(this TRPOSWindow window) where TRPOSWindow : global::RPOSWindow
	{
		if (window)
		{
			global::RPOSWindow.EnsureAwake(window);
		}
		return window;
	}

	// Token: 0x06002E09 RID: 11785 RVA: 0x000AEFBC File Offset: 0x000AD1BC
	public static bool IsRegistered(this global::RPOSWindow window)
	{
		return window && window.ready;
	}
}
