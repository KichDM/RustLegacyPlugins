using System;
using UnityEngine;

// Token: 0x02000054 RID: 84
public class ClientStreamLevelLoader : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06000286 RID: 646 RVA: 0x0000D100 File Offset: 0x0000B300
	public ClientStreamLevelLoader()
	{
	}

	// Token: 0x06000287 RID: 647 RVA: 0x0000D108 File Offset: 0x0000B308
	private void Start()
	{
		global::RustLoader rustLoader = (global::RustLoader)global::UnityEngine.Object.Instantiate(this.loaderPrefab);
		base.enabled = false;
	}

	// Token: 0x040001D3 RID: 467
	[global::UnityEngine.SerializeField]
	private global::RustLoader loaderPrefab;
}
