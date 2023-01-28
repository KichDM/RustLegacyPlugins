using System;

// Token: 0x02000004 RID: 4
public abstract class PostAuthAttribute : global::System.Attribute
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	internal PostAuthAttribute(global::AuthTarg target, global::AuthOptions options, string nameMask)
	{
		this._target = target;
		if (!string.IsNullOrEmpty(nameMask))
		{
			this._options = (options | (global::AuthOptions)4);
			this._nameMask = nameMask;
		}
		else
		{
			this._options = options;
			this._nameMask = string.Empty;
		}
	}

	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000002 RID: 2 RVA: 0x0000209C File Offset: 0x0000029C
	public global::AuthTarg target
	{
		get
		{
			return this._target;
		}
	}

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x06000003 RID: 3 RVA: 0x000020A4 File Offset: 0x000002A4
	public global::AuthOptions options
	{
		get
		{
			return this._options;
		}
	}

	// Token: 0x17000003 RID: 3
	// (get) Token: 0x06000004 RID: 4 RVA: 0x000020AC File Offset: 0x000002AC
	public string nameMask
	{
		get
		{
			return this._nameMask;
		}
	}

	// Token: 0x04000009 RID: 9
	public const global::AuthOptions kOption_None = (global::AuthOptions)0;

	// Token: 0x0400000A RID: 10
	public const global::AuthOptions kOption_Down = global::AuthOptions.SearchDown;

	// Token: 0x0400000B RID: 11
	public const global::AuthOptions kOption_Up = global::AuthOptions.SearchUp;

	// Token: 0x0400000C RID: 12
	public const global::AuthOptions kOption_NameMask = (global::AuthOptions)4;

	// Token: 0x0400000D RID: 13
	public const global::AuthOptions kOption_Include = global::AuthOptions.SearchInclusive;

	// Token: 0x0400000E RID: 14
	public const global::AuthOptions kOption_Reverse = global::AuthOptions.SearchReverse;

	// Token: 0x0400000F RID: 15
	private readonly global::AuthOptions _options;

	// Token: 0x04000010 RID: 16
	private readonly global::AuthTarg _target;

	// Token: 0x04000011 RID: 17
	private readonly string _nameMask;
}
