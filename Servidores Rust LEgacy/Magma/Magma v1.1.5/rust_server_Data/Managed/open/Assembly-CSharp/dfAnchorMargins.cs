using System;
using UnityEngine;

// Token: 0x020007F1 RID: 2033
[global::System.Serializable]
public class dfAnchorMargins
{
	// Token: 0x06004417 RID: 17431 RVA: 0x000F9028 File Offset: 0x000F7228
	public dfAnchorMargins()
	{
	}

	// Token: 0x06004418 RID: 17432 RVA: 0x000F9030 File Offset: 0x000F7230
	public override string ToString()
	{
		return string.Format("[L:{0},T:{1},R:{2},B:{3}]", new object[]
		{
			this.left,
			this.top,
			this.right,
			this.bottom
		});
	}

	// Token: 0x0400244C RID: 9292
	[global::UnityEngine.SerializeField]
	public float left;

	// Token: 0x0400244D RID: 9293
	[global::UnityEngine.SerializeField]
	public float top;

	// Token: 0x0400244E RID: 9294
	[global::UnityEngine.SerializeField]
	public float right;

	// Token: 0x0400244F RID: 9295
	[global::UnityEngine.SerializeField]
	public float bottom;
}
