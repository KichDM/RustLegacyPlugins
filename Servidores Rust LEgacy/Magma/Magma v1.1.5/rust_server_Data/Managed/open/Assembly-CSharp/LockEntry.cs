using System;
using Facepunch.Cursor;
using UnityEngine;

// Token: 0x02000516 RID: 1302
public class LockEntry : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002C5B RID: 11355 RVA: 0x000A7350 File Offset: 0x000A5550
	public LockEntry()
	{
	}

	// Token: 0x06002C5C RID: 11356 RVA: 0x000A7358 File Offset: 0x000A5558
	// Note: this type is marked as 'beforefieldinit'.
	static LockEntry()
	{
	}

	// Token: 0x040016A7 RID: 5799
	private static global::LockEntry singleton;

	// Token: 0x040016A8 RID: 5800
	private global::Facepunch.Cursor.UnlockCursorNode cursorLocker;

	// Token: 0x040016A9 RID: 5801
	public global::dfTextbox passwordInput;

	// Token: 0x040016AA RID: 5802
	public global::dfRichTextLabel entryLabel;
}
