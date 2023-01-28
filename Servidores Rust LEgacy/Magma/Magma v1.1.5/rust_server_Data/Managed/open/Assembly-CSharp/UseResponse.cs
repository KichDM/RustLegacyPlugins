using System;

// Token: 0x0200022D RID: 557
public enum UseResponse : sbyte
{
	// Token: 0x04000991 RID: 2449
	Pass_Unchecked,
	// Token: 0x04000992 RID: 2450
	Pass_Checked,
	// Token: 0x04000993 RID: 2451
	Fail_Checked_OutOfOrder = -0x80,
	// Token: 0x04000994 RID: 2452
	Fail_Checked_UserIncompatible,
	// Token: 0x04000995 RID: 2453
	Fail_Checked_BadConfiguration,
	// Token: 0x04000996 RID: 2454
	Fail_Checked_BadResult,
	// Token: 0x04000997 RID: 2455
	Fail_CheckException = -0x10,
	// Token: 0x04000998 RID: 2456
	Fail_EnterException,
	// Token: 0x04000999 RID: 2457
	Fail_Vacancy = -0xA,
	// Token: 0x0400099A RID: 2458
	Fail_Redundant,
	// Token: 0x0400099B RID: 2459
	Fail_UserDead,
	// Token: 0x0400099C RID: 2460
	Fail_Destroyed,
	// Token: 0x0400099D RID: 2461
	Fail_NotIUseable,
	// Token: 0x0400099E RID: 2462
	Fail_InvalidOperation,
	// Token: 0x0400099F RID: 2463
	Fail_NullOrMissingUser
}
