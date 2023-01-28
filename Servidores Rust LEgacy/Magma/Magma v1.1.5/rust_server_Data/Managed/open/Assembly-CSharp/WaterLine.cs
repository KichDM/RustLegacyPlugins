using System;
using UnityEngine;

// Token: 0x0200054E RID: 1358
public class WaterLine : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002E51 RID: 11857 RVA: 0x000B0720 File Offset: 0x000AE920
	public WaterLine()
	{
	}

	// Token: 0x06002E52 RID: 11858 RVA: 0x000B0728 File Offset: 0x000AE928
	// Note: this type is marked as 'beforefieldinit'.
	static WaterLine()
	{
	}

	// Token: 0x06002E53 RID: 11859 RVA: 0x000B072C File Offset: 0x000AE92C
	public void Start()
	{
	}

	// Token: 0x06002E54 RID: 11860 RVA: 0x000B0730 File Offset: 0x000AE930
	public void OnDestroy()
	{
		global::WaterLine.Height = 0f;
	}

	// Token: 0x06002E55 RID: 11861 RVA: 0x000B073C File Offset: 0x000AE93C
	public void Update()
	{
		global::WaterLine.Height = base.transform.position.y;
	}

	// Token: 0x040017EE RID: 6126
	public static float Height;
}
