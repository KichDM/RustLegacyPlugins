using System;
using UnityEngine;

// Token: 0x02000602 RID: 1538
public class LevelSharedPrefab : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600314D RID: 12621 RVA: 0x000BCD4C File Offset: 0x000BAF4C
	public LevelSharedPrefab()
	{
	}

	// Token: 0x0600314E RID: 12622 RVA: 0x000BCD54 File Offset: 0x000BAF54
	private void Awake()
	{
		base.transform.DetachChildren();
		global::UnityEngine.Object.Destroy(this);
	}
}
