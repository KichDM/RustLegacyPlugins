using System;
using System.Collections.Generic;

// Token: 0x0200059C RID: 1436
internal class ContextServerStage
{
	// Token: 0x06002F81 RID: 12161 RVA: 0x000B52B0 File Offset: 0x000B34B0
	public ContextServerStage()
	{
	}

	// Token: 0x0400196D RID: 6509
	[global::System.NonSerialized]
	public global::System.Collections.Generic.IEnumerable<global::ContextActionPrototype> actions;

	// Token: 0x0400196E RID: 6510
	[global::System.NonSerialized]
	public global::Contextual contextual;

	// Token: 0x0400196F RID: 6511
	[global::System.NonSerialized]
	public global::ContextExecution execution;

	// Token: 0x04001970 RID: 6512
	[global::System.NonSerialized]
	public ulong created_timestamp_client;

	// Token: 0x04001971 RID: 6513
	[global::System.NonSerialized]
	public ulong created_timestamp_server;
}
