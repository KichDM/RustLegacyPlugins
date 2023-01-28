using System;
using UnityEngine;

// Token: 0x020004BE RID: 1214
[global::UnityEngine.AddComponentMenu("")]
public class VisManager : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002A30 RID: 10800 RVA: 0x0009F7BC File Offset: 0x0009D9BC
	public VisManager()
	{
	}

	// Token: 0x06002A31 RID: 10801 RVA: 0x0009F7C4 File Offset: 0x0009D9C4
	// Note: this type is marked as 'beforefieldinit'.
	static VisManager()
	{
	}

	// Token: 0x17000951 RID: 2385
	// (get) Token: 0x06002A32 RID: 10802 RVA: 0x0009F7C8 File Offset: 0x0009D9C8
	public static bool guardedUpdate
	{
		get
		{
			return global::VisManager.isUpdatingVisiblity;
		}
	}

	// Token: 0x06002A33 RID: 10803 RVA: 0x0009F7D0 File Offset: 0x0009D9D0
	private void Reset()
	{
		global::UnityEngine.Debug.LogError("REMOVE ME NOW, I GET GENERATED AT RUN TIME", this);
	}

	// Token: 0x06002A34 RID: 10804 RVA: 0x0009F7E0 File Offset: 0x0009D9E0
	private void Update()
	{
		if (!global::VisManager.isUpdatingVisiblity)
		{
			global::VisManager.isUpdatingVisiblity = true;
			try
			{
				global::VisNode.Process();
			}
			catch (global::System.Exception arg)
			{
				if (!global::VisManager.muteVis)
				{
					global::UnityEngine.Debug.LogError(string.Format("{0}\n-- Vis data potentially compromised\n", arg));
				}
			}
			finally
			{
				global::VisManager.isUpdatingVisiblity = false;
			}
		}
	}

	// Token: 0x04001526 RID: 5414
	private static bool isUpdatingVisiblity;

	// Token: 0x04001527 RID: 5415
	private static bool muteVis;
}
