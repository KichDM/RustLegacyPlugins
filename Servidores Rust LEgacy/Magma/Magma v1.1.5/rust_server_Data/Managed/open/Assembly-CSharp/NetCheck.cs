using System;
using uLink;

// Token: 0x02000605 RID: 1541
public class NetCheck
{
	// Token: 0x06003156 RID: 12630 RVA: 0x000BCF08 File Offset: 0x000BB108
	public NetCheck()
	{
	}

	// Token: 0x06003157 RID: 12631 RVA: 0x000BCF10 File Offset: 0x000BB110
	public static bool PlayerValid(global::uLink.NetworkPlayer ply)
	{
		return ply.isConnected;
	}
}
