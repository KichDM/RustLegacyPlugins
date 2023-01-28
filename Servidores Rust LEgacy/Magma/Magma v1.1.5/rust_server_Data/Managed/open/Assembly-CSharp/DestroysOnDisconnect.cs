using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000335 RID: 821
public sealed class DestroysOnDisconnect : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06001BC4 RID: 7108 RVA: 0x0006F604 File Offset: 0x0006D804
	public DestroysOnDisconnect()
	{
	}

	// Token: 0x06001BC5 RID: 7109 RVA: 0x0006F60C File Offset: 0x0006D80C
	private void Awake()
	{
		if (!this.inList)
		{
			this.inList = true;
			try
			{
				global::DestroysOnDisconnect.List.all.Add(this);
			}
			catch
			{
				this.inList = false;
				throw;
			}
		}
	}

	// Token: 0x06001BC6 RID: 7110 RVA: 0x0006F668 File Offset: 0x0006D868
	private void OnDestroy()
	{
		if (this.inList)
		{
			try
			{
				if (!global::DestroysOnDisconnect.List.all.Remove(this))
				{
					global::UnityEngine.Debug.LogWarning("serious problem, script reload?", this);
				}
			}
			finally
			{
				this.inList = false;
			}
		}
	}

	// Token: 0x06001BC7 RID: 7111 RVA: 0x0006F6C4 File Offset: 0x0006D8C4
	private void DestroyManually()
	{
		if (this.inList)
		{
			global::UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001BC8 RID: 7112 RVA: 0x0006F6DC File Offset: 0x0006D8DC
	public static void ApplyToGameObject(global::UnityEngine.GameObject gameObject)
	{
		global::DestroysOnDisconnect component = gameObject.GetComponent<global::DestroysOnDisconnect>();
		if (!component)
		{
			gameObject.AddComponent<global::DestroysOnDisconnect>();
		}
	}

	// Token: 0x0400103D RID: 4157
	private static bool ListClassInitialized;

	// Token: 0x0400103E RID: 4158
	private bool inList;

	// Token: 0x02000336 RID: 822
	private static class List
	{
		// Token: 0x06001BC9 RID: 7113 RVA: 0x0006F704 File Offset: 0x0006D904
		static List()
		{
			global::DestroysOnDisconnect.ListClassInitialized = true;
		}

		// Token: 0x0400103F RID: 4159
		public static readonly global::System.Collections.Generic.List<global::DestroysOnDisconnect> all = new global::System.Collections.Generic.List<global::DestroysOnDisconnect>();
	}
}
