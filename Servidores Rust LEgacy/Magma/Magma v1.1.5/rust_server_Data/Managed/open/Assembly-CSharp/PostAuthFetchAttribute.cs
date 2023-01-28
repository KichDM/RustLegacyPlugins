using System;

// Token: 0x02000005 RID: 5
[global::System.AttributeUsage(global::System.AttributeTargets.Field)]
public sealed class PostAuthFetchAttribute : global::PostAuthAttribute
{
	// Token: 0x06000005 RID: 5 RVA: 0x000020B4 File Offset: 0x000002B4
	public PostAuthFetchAttribute(global::AuthTarg target, string nameMask) : base(target, (global::AuthOptions)0, nameMask)
	{
	}

	// Token: 0x06000006 RID: 6 RVA: 0x000020C0 File Offset: 0x000002C0
	public PostAuthFetchAttribute(global::AuthTarg target) : this(target, null)
	{
	}
}
