using System;
using UnityEngine;

// Token: 0x0200060D RID: 1549
public class QuickLight : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06003169 RID: 12649 RVA: 0x000BD784 File Offset: 0x000BB984
	public QuickLight()
	{
	}

	// Token: 0x0600316A RID: 12650 RVA: 0x000BD7A4 File Offset: 0x000BB9A4
	public void Update()
	{
		base.light.range -= global::UnityEngine.Time.deltaTime / this.duration;
		if (base.light.range <= 0f)
		{
			base.light.range = 0f;
			base.light.intensity = 0f;
		}
	}

	// Token: 0x04001B94 RID: 7060
	public float range = 1f;

	// Token: 0x04001B95 RID: 7061
	public float duration = 0.25f;
}
