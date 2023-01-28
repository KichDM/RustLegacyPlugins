using System;
using UnityEngine;

// Token: 0x02000340 RID: 832
public class InterpTimedEventSyncronizer : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06001C08 RID: 7176 RVA: 0x00070A78 File Offset: 0x0006EC78
	public InterpTimedEventSyncronizer()
	{
	}

	// Token: 0x170007AB RID: 1963
	// (get) Token: 0x06001C09 RID: 7177 RVA: 0x00070A80 File Offset: 0x0006EC80
	// (set) Token: 0x06001C0A RID: 7178 RVA: 0x00070A88 File Offset: 0x0006EC88
	internal static bool paused
	{
		get
		{
			return global::InterpTimedEventSyncronizer.syncronizationPaused;
		}
		set
		{
			global::InterpTimedEventSyncronizer.syncronizationPaused = value;
			if (global::InterpTimedEventSyncronizer.singleton)
			{
				global::InterpTimedEventSyncronizer.singleton.enabled = !global::InterpTimedEventSyncronizer.syncronizationPaused;
			}
		}
	}

	// Token: 0x170007AC RID: 1964
	// (get) Token: 0x06001C0B RID: 7179 RVA: 0x00070AB4 File Offset: 0x0006ECB4
	internal static bool available
	{
		get
		{
			return global::InterpTimedEventSyncronizer.exists;
		}
	}

	// Token: 0x06001C0C RID: 7180 RVA: 0x00070ABC File Offset: 0x0006ECBC
	private void Awake()
	{
		if (global::InterpTimedEventSyncronizer.singleton)
		{
			global::UnityEngine.Debug.LogWarning("Destroying old singleton!", global::InterpTimedEventSyncronizer.singleton.gameObject);
			global::UnityEngine.Object.Destroy(global::InterpTimedEventSyncronizer.singleton);
		}
		global::InterpTimedEventSyncronizer.singleton = this;
		global::InterpTimedEventSyncronizer.exists = true;
	}

	// Token: 0x06001C0D RID: 7181 RVA: 0x00070AF8 File Offset: 0x0006ECF8
	private void Update()
	{
		global::InterpTimedEvent.Catchup();
	}

	// Token: 0x06001C0E RID: 7182 RVA: 0x00070B00 File Offset: 0x0006ED00
	private void OnDestroy()
	{
		if (global::InterpTimedEventSyncronizer.singleton == this)
		{
			try
			{
				global::InterpTimedEvent.Clear(false);
			}
			finally
			{
				global::InterpTimedEventSyncronizer.singleton = null;
				global::InterpTimedEventSyncronizer.exists = false;
			}
		}
	}

	// Token: 0x04001062 RID: 4194
	private static global::InterpTimedEventSyncronizer singleton;

	// Token: 0x04001063 RID: 4195
	private static bool syncronizationPaused;

	// Token: 0x04001064 RID: 4196
	private static bool exists;
}
