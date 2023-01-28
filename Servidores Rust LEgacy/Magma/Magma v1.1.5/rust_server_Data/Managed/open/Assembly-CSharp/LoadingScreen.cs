using System;
using Facepunch.Progress;
using UnityEngine;

// Token: 0x02000521 RID: 1313
public class LoadingScreen : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002C92 RID: 11410 RVA: 0x000A8744 File Offset: 0x000A6944
	public LoadingScreen()
	{
	}

	// Token: 0x06002C93 RID: 11411 RVA: 0x000A874C File Offset: 0x000A694C
	// Note: this type is marked as 'beforefieldinit'.
	static LoadingScreen()
	{
	}

	// Token: 0x06002C94 RID: 11412 RVA: 0x000A8758 File Offset: 0x000A6958
	public static void Update(string strText)
	{
		global::LoadingScreen.Operations.Clean();
	}

	// Token: 0x040016C4 RID: 5828
	public global::dfRichTextLabel infoText;

	// Token: 0x040016C5 RID: 5829
	public global::dfPanel progressBar;

	// Token: 0x040016C6 RID: 5830
	public global::dfSprite progressIndicator;

	// Token: 0x040016C7 RID: 5831
	public static readonly global::Facepunch.Progress.ProgressBar Operations = new global::Facepunch.Progress.ProgressBar();
}
