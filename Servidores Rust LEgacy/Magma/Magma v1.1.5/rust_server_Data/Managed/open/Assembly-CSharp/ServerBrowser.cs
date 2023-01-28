using System;
using UnityEngine;

// Token: 0x02000527 RID: 1319
public class ServerBrowser : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002C9A RID: 11418 RVA: 0x000A878C File Offset: 0x000A698C
	public ServerBrowser()
	{
	}

	// Token: 0x040016CC RID: 5836
	public global::UnityEngine.GameObject serverItem;

	// Token: 0x040016CD RID: 5837
	public global::ServerCategory[] categoryButtons;

	// Token: 0x040016CE RID: 5838
	public global::dfPanel serverContainer;

	// Token: 0x040016CF RID: 5839
	public global::Pagination pagination;

	// Token: 0x040016D0 RID: 5840
	public global::dfControl refreshButton;

	// Token: 0x040016D1 RID: 5841
	public global::dfRichTextLabel detailsLabel;

	// Token: 0x040016D2 RID: 5842
	public string currentServerChecksum;

	// Token: 0x02000528 RID: 1320
	public class Server
	{
		// Token: 0x06002C9B RID: 11419 RVA: 0x000A8794 File Offset: 0x000A6994
		public Server()
		{
		}

		// Token: 0x040016D3 RID: 5843
		public bool passworded;

		// Token: 0x040016D4 RID: 5844
		public string name;

		// Token: 0x040016D5 RID: 5845
		public string address;

		// Token: 0x040016D6 RID: 5846
		public int maxplayers;

		// Token: 0x040016D7 RID: 5847
		public int currentplayers;

		// Token: 0x040016D8 RID: 5848
		public int ping;

		// Token: 0x040016D9 RID: 5849
		public uint lastplayed;

		// Token: 0x040016DA RID: 5850
		public int port;

		// Token: 0x040016DB RID: 5851
		public int queryport;

		// Token: 0x040016DC RID: 5852
		public bool fave;
	}
}
