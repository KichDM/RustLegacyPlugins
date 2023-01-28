using System;
using UnityEngine;

// Token: 0x020000BD RID: 189
public class OfflineMode : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060003BE RID: 958 RVA: 0x00012160 File Offset: 0x00010360
	public OfflineMode()
	{
	}

	// Token: 0x060003BF RID: 959 RVA: 0x00012174 File Offset: 0x00010374
	private void Start()
	{
	}

	// Token: 0x04000383 RID: 899
	[global::UnityEngine.SerializeField]
	private global::CharacterPrefab characterPrefab;

	// Token: 0x04000384 RID: 900
	[global::UnityEngine.SerializeField]
	private global::OfflinePlayer offlinePlayer;

	// Token: 0x04000385 RID: 901
	[global::UnityEngine.SerializeField]
	private global::MountedCamera sceneCameraPrefab;

	// Token: 0x04000386 RID: 902
	[global::UnityEngine.SerializeField]
	private bool useSceneViewWhenAvailable;

	// Token: 0x04000387 RID: 903
	[global::UnityEngine.SerializeField]
	private bool paused;

	// Token: 0x04000388 RID: 904
	[global::UnityEngine.SerializeField]
	private bool respawn;

	// Token: 0x04000389 RID: 905
	[global::UnityEngine.SerializeField]
	private bool teleport;

	// Token: 0x0400038A RID: 906
	[global::UnityEngine.SerializeField]
	private float timeScale = 1f;
}
