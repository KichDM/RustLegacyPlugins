using System;

// Token: 0x020005AF RID: 1455
public class BaseHitBox : global::IDRemote
{
	// Token: 0x06002FEE RID: 12270 RVA: 0x000B696C File Offset: 0x000B4B6C
	public BaseHitBox()
	{
	}

	// Token: 0x17000A26 RID: 2598
	// (get) Token: 0x06002FEF RID: 12271 RVA: 0x000B6974 File Offset: 0x000B4B74
	public global::Character idMain
	{
		get
		{
			return (global::Character)base.idMain;
		}
	}
}
