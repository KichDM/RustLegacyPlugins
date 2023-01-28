using System;

// Token: 0x02000009 RID: 9
[global::System.AttributeUsage(global::System.AttributeTargets.Field)]
public sealed class PostAuthFetchParentOrChildAttribute : global::PostAuthAttribute
{
	// Token: 0x06000010 RID: 16 RVA: 0x0000215C File Offset: 0x0000035C
	private PostAuthFetchParentOrChildAttribute(global::AuthTarg target, bool includeThisGameObject, string nameMask) : base(target, (!includeThisGameObject) ? (global::AuthOptions.SearchDown | global::AuthOptions.SearchUp | global::AuthOptions.SearchReverse) : (global::AuthOptions.SearchDown | global::AuthOptions.SearchUp | global::AuthOptions.SearchInclusive | global::AuthOptions.SearchReverse), nameMask)
	{
	}

	// Token: 0x06000011 RID: 17 RVA: 0x00002178 File Offset: 0x00000378
	public PostAuthFetchParentOrChildAttribute(global::AuthTarg target, string nameMask) : this(target, false, nameMask)
	{
	}

	// Token: 0x06000012 RID: 18 RVA: 0x00002184 File Offset: 0x00000384
	public PostAuthFetchParentOrChildAttribute(global::AuthTarg target, bool includeThisGameObject) : this(target, includeThisGameObject, null)
	{
	}

	// Token: 0x04000015 RID: 21
	private const global::AuthOptions kFixedOptions = global::AuthOptions.SearchDown | global::AuthOptions.SearchUp | global::AuthOptions.SearchReverse;
}
