using System;
using UnityEngine;

// Token: 0x020005DE RID: 1502
[global::System.Serializable]
public class ResourceHarvester : global::UnityEngine.Object
{
	// Token: 0x060030DC RID: 12508 RVA: 0x000BA210 File Offset: 0x000B8410
	public ResourceHarvester()
	{
	}

	// Token: 0x060030DD RID: 12509 RVA: 0x000BA218 File Offset: 0x000B8418
	public float ResourceEfficiencyForType(global::ResourceTarget.ResourceTargetType type)
	{
		return 0f;
	}

	// Token: 0x060030DE RID: 12510 RVA: 0x000BA22C File Offset: 0x000B842C
	public static string ResourceDBNameForType(global::ResourceType hitType)
	{
		if (hitType == global::ResourceType.Wood)
		{
			return "Wood";
		}
		if (hitType != global::ResourceType.Meat)
		{
			return string.Empty;
		}
		return "Raw Meat";
	}

	// Token: 0x04001A96 RID: 6806
	public float[] efficiencies;
}
