using System;

// Token: 0x02000007 RID: 7
[global::System.AttributeUsage(global::System.AttributeTargets.Field)]
public sealed class PostAuthFetchChildAttribute : global::PostAuthAttribute
{
	// Token: 0x0600000A RID: 10 RVA: 0x000020FC File Offset: 0x000002FC
	private PostAuthFetchChildAttribute(global::AuthTarg target, bool includeThisGameObject, string nameMask) : base(target, (!includeThisGameObject) ? global::AuthOptions.SearchDown : (global::AuthOptions.SearchDown | global::AuthOptions.SearchInclusive), nameMask)
	{
	}

	// Token: 0x0600000B RID: 11 RVA: 0x00002114 File Offset: 0x00000314
	public PostAuthFetchChildAttribute(global::AuthTarg target, string nameMask) : this(target, false, nameMask)
	{
	}

	// Token: 0x0600000C RID: 12 RVA: 0x00002120 File Offset: 0x00000320
	public PostAuthFetchChildAttribute(global::AuthTarg target, bool includeThisGameObject) : this(target, includeThisGameObject, null)
	{
	}

	// Token: 0x04000013 RID: 19
	private const global::AuthOptions kFixedOptions = global::AuthOptions.SearchDown;
}
