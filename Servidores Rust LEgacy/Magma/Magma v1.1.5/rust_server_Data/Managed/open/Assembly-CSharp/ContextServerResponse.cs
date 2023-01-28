using System;

// Token: 0x0200059B RID: 1435
internal enum ContextServerResponse : byte
{
	// Token: 0x0400195E RID: 6494
	ImmediateSuccess,
	// Token: 0x0400195F RID: 6495
	ImmediateFail,
	// Token: 0x04001960 RID: 6496
	InvalidCast,
	// Token: 0x04001961 RID: 6497
	PutInMenu,
	// Token: 0x04001962 RID: 6498
	NoMenuOptions,
	// Token: 0x04001963 RID: 6499
	PutInMenuException,
	// Token: 0x04001964 RID: 6500
	NoOp,
	// Token: 0x04001965 RID: 6501
	NoSelection,
	// Token: 0x04001966 RID: 6502
	SelectionSuccess,
	// Token: 0x04001967 RID: 6503
	SelectionFail,
	// Token: 0x04001968 RID: 6504
	CouldNotGetPlayerContextContextual,
	// Token: 0x04001969 RID: 6505
	CouldNotGetPlayerContext,
	// Token: 0x0400196A RID: 6506
	CouldNotGetPlayerControllable,
	// Token: 0x0400196B RID: 6507
	CouldNotGetPlayerClient,
	// Token: 0x0400196C RID: 6508
	CouldNotGetServerManagement
}
