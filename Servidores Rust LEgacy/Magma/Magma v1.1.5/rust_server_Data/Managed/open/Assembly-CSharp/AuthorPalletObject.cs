using System;
using UnityEngine;

// Token: 0x0200000F RID: 15
public class AuthorPalletObject
{
	// Token: 0x0600005E RID: 94 RVA: 0x00003410 File Offset: 0x00001610
	public AuthorPalletObject()
	{
	}

	// Token: 0x0600005F RID: 95 RVA: 0x00003418 File Offset: 0x00001618
	public bool Validate(global::AuthorCreation creation)
	{
		return this.validator == null || this.validator(creation, this);
	}

	// Token: 0x06000060 RID: 96 RVA: 0x00003438 File Offset: 0x00001638
	public bool Create(global::AuthorCreation creation, out global::AuthorPeice peice)
	{
		if (this.creator == null)
		{
			peice = null;
			return false;
		}
		peice = this.creator(creation, this);
		return peice;
	}

	// Token: 0x0400003E RID: 62
	public global::AuthorPalletObject.Validator validator;

	// Token: 0x0400003F RID: 63
	public global::AuthorPalletObject.Creator creator;

	// Token: 0x04000040 RID: 64
	public global::UnityEngine.GUIContent guiContent;

	// Token: 0x02000010 RID: 16
	// (Invoke) Token: 0x06000062 RID: 98
	public delegate bool Validator(global::AuthorCreation creation, global::AuthorPalletObject obj);

	// Token: 0x02000011 RID: 17
	// (Invoke) Token: 0x06000066 RID: 102
	public delegate global::AuthorPeice Creator(global::AuthorCreation creation, global::AuthorPalletObject obj);
}
