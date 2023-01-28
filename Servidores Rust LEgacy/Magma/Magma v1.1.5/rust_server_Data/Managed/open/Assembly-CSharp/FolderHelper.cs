using System;
using UnityEngine;

// Token: 0x020005FD RID: 1533
public class FolderHelper : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600313D RID: 12605 RVA: 0x000BC7C0 File Offset: 0x000BA9C0
	public FolderHelper()
	{
	}

	// Token: 0x0600313E RID: 12606 RVA: 0x000BC7C8 File Offset: 0x000BA9C8
	private void Awake()
	{
		base.transform.DetachChildren();
		global::UnityEngine.Object.Destroy(base.gameObject);
	}
}
