using System;

// Token: 0x02000006 RID: 6
[global::System.AttributeUsage(global::System.AttributeTargets.Field)]
public sealed class PostAuthFetchParentAttribute : global::PostAuthAttribute
{
	// Token: 0x06000007 RID: 7 RVA: 0x000020CC File Offset: 0x000002CC
	private PostAuthFetchParentAttribute(global::AuthTarg target, bool includeThisGameObject, string nameMask) : base(target, (!includeThisGameObject) ? global::AuthOptions.SearchUp : (global::AuthOptions.SearchUp | global::AuthOptions.SearchInclusive), nameMask)
	{
	}

	// Token: 0x06000008 RID: 8 RVA: 0x000020E4 File Offset: 0x000002E4
	public PostAuthFetchParentAttribute(global::AuthTarg target, string nameMask) : this(target, false, nameMask)
	{
	}

	// Token: 0x06000009 RID: 9 RVA: 0x000020F0 File Offset: 0x000002F0
	public PostAuthFetchParentAttribute(global::AuthTarg target, bool includeThisGameObject) : this(target, includeThisGameObject, null)
	{
	}

	// Token: 0x04000012 RID: 18
	private const global::AuthOptions kFixedOptions = global::AuthOptions.SearchUp;
}
