using System;

// Token: 0x02000561 RID: 1377
public enum ActivationResult
{
	// Token: 0x04001871 RID: 6257
	Success,
	// Token: 0x04001872 RID: 6258
	Fail_Busy,
	// Token: 0x04001873 RID: 6259
	Fail_Broken,
	// Token: 0x04001874 RID: 6260
	Fail_Access,
	// Token: 0x04001875 RID: 6261
	Fail_Redundant,
	// Token: 0x04001876 RID: 6262
	Fail_BadToggle,
	// Token: 0x04001877 RID: 6263
	Fail_RequiresInstigator,
	// Token: 0x04001878 RID: 6264
	Error_Implementation,
	// Token: 0x04001879 RID: 6265
	Error_Destroyed
}
