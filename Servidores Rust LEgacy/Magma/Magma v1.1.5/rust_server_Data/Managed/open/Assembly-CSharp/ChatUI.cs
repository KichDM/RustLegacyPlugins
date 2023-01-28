using System;
using UnityEngine;

// Token: 0x02000512 RID: 1298
public class ChatUI : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002C51 RID: 11345 RVA: 0x000A723C File Offset: 0x000A543C
	public ChatUI()
	{
	}

	// Token: 0x040016A0 RID: 5792
	public global::dfTextbox textInput;

	// Token: 0x040016A1 RID: 5793
	public global::dfPanel chatContainer;

	// Token: 0x040016A2 RID: 5794
	public global::UnityEngine.Object chatLine;

	// Token: 0x040016A3 RID: 5795
	public static global::ChatUI singleton;
}
