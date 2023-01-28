using System;
using System.Runtime.CompilerServices;

// Token: 0x020001C7 RID: 455
public static class GameEvent
{
	// Token: 0x14000005 RID: 5
	// (add) Token: 0x06000D36 RID: 3382 RVA: 0x00034104 File Offset: 0x00032304
	// (remove) Token: 0x06000D37 RID: 3383 RVA: 0x0003411C File Offset: 0x0003231C
	public static event global::GameEvent.OnPlayerConnectedHandler PlayerConnected
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			global::GameEvent.PlayerConnected = (global::GameEvent.OnPlayerConnectedHandler)global::System.Delegate.Combine(global::GameEvent.PlayerConnected, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			global::GameEvent.PlayerConnected = (global::GameEvent.OnPlayerConnectedHandler)global::System.Delegate.Remove(global::GameEvent.PlayerConnected, value);
		}
	}

	// Token: 0x14000006 RID: 6
	// (add) Token: 0x06000D38 RID: 3384 RVA: 0x00034134 File Offset: 0x00032334
	// (remove) Token: 0x06000D39 RID: 3385 RVA: 0x0003414C File Offset: 0x0003234C
	public static event global::GameEvent.OnGenericEvent QualitySettingsRefresh
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			global::GameEvent.QualitySettingsRefresh = (global::GameEvent.OnGenericEvent)global::System.Delegate.Combine(global::GameEvent.QualitySettingsRefresh, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			global::GameEvent.QualitySettingsRefresh = (global::GameEvent.OnGenericEvent)global::System.Delegate.Remove(global::GameEvent.QualitySettingsRefresh, value);
		}
	}

	// Token: 0x06000D3A RID: 3386 RVA: 0x00034164 File Offset: 0x00032364
	public static void DoPlayerConnected(global::PlayerClient player)
	{
		if (global::GameEvent.PlayerConnected != null)
		{
			global::GameEvent.PlayerConnected(player);
		}
	}

	// Token: 0x06000D3B RID: 3387 RVA: 0x0003417C File Offset: 0x0003237C
	public static void DoQualitySettingsRefresh()
	{
		if (global::GameEvent.QualitySettingsRefresh != null)
		{
			global::GameEvent.QualitySettingsRefresh();
		}
	}

	// Token: 0x04000886 RID: 2182
	private static global::GameEvent.OnPlayerConnectedHandler PlayerConnected;

	// Token: 0x04000887 RID: 2183
	private static global::GameEvent.OnGenericEvent QualitySettingsRefresh;

	// Token: 0x020001C8 RID: 456
	// (Invoke) Token: 0x06000D3D RID: 3389
	public delegate void OnGenericEvent();

	// Token: 0x020001C9 RID: 457
	// (Invoke) Token: 0x06000D41 RID: 3393
	public delegate void OnPlayerConnectedHandler(global::PlayerClient player);
}
