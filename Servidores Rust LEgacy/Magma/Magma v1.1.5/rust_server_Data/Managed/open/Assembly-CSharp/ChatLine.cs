using System;
using UnityEngine;

// Token: 0x02000511 RID: 1297
public class ChatLine : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002C4F RID: 11343 RVA: 0x000A7218 File Offset: 0x000A5418
	public ChatLine()
	{
	}

	// Token: 0x06002C50 RID: 11344 RVA: 0x000A7220 File Offset: 0x000A5420
	public void Setup(string name, string text)
	{
		this.lblName.Text = name;
		this.lblText.Text = text;
	}

	// Token: 0x0400169E RID: 5790
	public global::dfLabel lblName;

	// Token: 0x0400169F RID: 5791
	public global::dfLabel lblText;
}
