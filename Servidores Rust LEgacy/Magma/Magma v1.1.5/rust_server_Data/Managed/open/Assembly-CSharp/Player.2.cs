using System;
using uLink;

// Token: 0x020000B9 RID: 185
public class Player : global::IDLocalCharacter
{
	// Token: 0x060003B2 RID: 946 RVA: 0x00011DC4 File Offset: 0x0000FFC4
	public Player()
	{
	}

	// Token: 0x060003B3 RID: 947 RVA: 0x00011DCC File Offset: 0x0000FFCC
	private void uLink_OnNetworkInstantiate(global::uLink.NetworkMessageInfo info)
	{
		if (!base.networkView.isMine)
		{
		}
	}
}
