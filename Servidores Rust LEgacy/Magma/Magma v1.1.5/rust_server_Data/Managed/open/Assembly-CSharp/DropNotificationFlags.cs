using System;

// Token: 0x02000921 RID: 2337
[global::System.Flags]
public enum DropNotificationFlags
{
	// Token: 0x04002C41 RID: 11329
	DragDrop = 1,
	// Token: 0x04002C42 RID: 11330
	DragLand = 2,
	// Token: 0x04002C43 RID: 11331
	DragReverse = 4,
	// Token: 0x04002C44 RID: 11332
	AltDrop = 8,
	// Token: 0x04002C45 RID: 11333
	AltLand = 0x10,
	// Token: 0x04002C46 RID: 11334
	AltReverse = 0x20,
	// Token: 0x04002C47 RID: 11335
	MidDrop = 0x40,
	// Token: 0x04002C48 RID: 11336
	MidLand = 0x80,
	// Token: 0x04002C49 RID: 11337
	MidReverse = 0x100,
	// Token: 0x04002C4A RID: 11338
	DragHover = 0x200,
	// Token: 0x04002C4B RID: 11339
	LandHover = 0x400,
	// Token: 0x04002C4C RID: 11340
	ReverseHover = 0x800,
	// Token: 0x04002C4D RID: 11341
	RegularHover = 0x1000,
	// Token: 0x04002C4E RID: 11342
	DragLandOutside = 0x2000
}
