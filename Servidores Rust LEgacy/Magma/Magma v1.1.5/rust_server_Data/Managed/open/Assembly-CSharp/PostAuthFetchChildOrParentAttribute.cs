using System;

// Token: 0x02000008 RID: 8
[global::System.AttributeUsage(global::System.AttributeTargets.Field)]
public sealed class PostAuthFetchChildOrParentAttribute : global::PostAuthAttribute
{
	// Token: 0x0600000D RID: 13 RVA: 0x0000212C File Offset: 0x0000032C
	private PostAuthFetchChildOrParentAttribute(global::AuthTarg target, bool includeThisGameObject, string nameMask) : base(target, (!includeThisGameObject) ? (global::AuthOptions.SearchDown | global::AuthOptions.SearchUp) : (global::AuthOptions.SearchDown | global::AuthOptions.SearchUp | global::AuthOptions.SearchInclusive), nameMask)
	{
	}

	// Token: 0x0600000E RID: 14 RVA: 0x00002144 File Offset: 0x00000344
	public PostAuthFetchChildOrParentAttribute(global::AuthTarg target, string nameMask) : this(target, false, nameMask)
	{
	}

	// Token: 0x0600000F RID: 15 RVA: 0x00002150 File Offset: 0x00000350
	public PostAuthFetchChildOrParentAttribute(global::AuthTarg target, bool includeThisGameObject) : this(target, includeThisGameObject, null)
	{
	}

	// Token: 0x04000014 RID: 20
	private const global::AuthOptions kFixedOptions = global::AuthOptions.SearchDown | global::AuthOptions.SearchUp;
}
