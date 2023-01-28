using System;
using Facepunch.Utility;
using uLink;
using UnityEngine;

// Token: 0x02000514 RID: 1300
public class DeathScreen : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002C55 RID: 11349 RVA: 0x000A7270 File Offset: 0x000A5470
	public DeathScreen()
	{
	}

	// Token: 0x06002C56 RID: 11350 RVA: 0x000A7278 File Offset: 0x000A5478
	public static void SetReason(global::uLink.NetworkPlayer player, string strReason)
	{
		strReason = global::Facepunch.Utility.String.QuoteSafe(strReason);
		global::ConsoleNetworker.SendClientCommand(player, "deathscreen.reason " + strReason);
	}

	// Token: 0x040016A6 RID: 5798
	public global::dfLabel lblDescription;
}
