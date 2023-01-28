using System;

// Token: 0x02000946 RID: 2374
public struct UITextPosition
{
	// Token: 0x060050B1 RID: 20657 RVA: 0x0013C218 File Offset: 0x0013A418
	public UITextPosition(global::UITextRegion beforeOrPre)
	{
		this.line = 0;
		this.column = 0;
		this.position = 0;
		this.deformed = 0;
		this.region = beforeOrPre;
		this.uniformRegion = beforeOrPre;
	}

	// Token: 0x060050B2 RID: 20658 RVA: 0x0013C250 File Offset: 0x0013A450
	public UITextPosition(int line, int column, int position, global::UITextRegion region)
	{
		this.line = line;
		this.column = column;
		this.position = position;
		this.deformed = 0;
		this.region = region;
		this.uniformRegion = region;
	}

	// Token: 0x17000EF4 RID: 3828
	// (get) Token: 0x060050B3 RID: 20659 RVA: 0x0013C28C File Offset: 0x0013A48C
	// (set) Token: 0x060050B4 RID: 20660 RVA: 0x0013C29C File Offset: 0x0013A49C
	public int uniformPosition
	{
		get
		{
			return this.position + (int)this.deformed;
		}
		set
		{
			this.deformed = (short)(value - this.position);
		}
	}

	// Token: 0x17000EF5 RID: 3829
	// (get) Token: 0x060050B5 RID: 20661 RVA: 0x0013C2B0 File Offset: 0x0013A4B0
	public bool valid
	{
		get
		{
			return this.region != global::UITextRegion.Invalid;
		}
	}

	// Token: 0x060050B6 RID: 20662 RVA: 0x0013C2C0 File Offset: 0x0013A4C0
	public override string ToString()
	{
		return string.Format("[{0} pos={1}{{{2}:{3}}} uniform={{{4}-{5}}}]", new object[]
		{
			this.region,
			this.position,
			this.line,
			this.column,
			this.uniformPosition,
			this.uniformRegion
		});
	}

	// Token: 0x04002D65 RID: 11621
	public int line;

	// Token: 0x04002D66 RID: 11622
	public int column;

	// Token: 0x04002D67 RID: 11623
	public int position;

	// Token: 0x04002D68 RID: 11624
	public short deformed;

	// Token: 0x04002D69 RID: 11625
	public global::UITextRegion region;

	// Token: 0x04002D6A RID: 11626
	public global::UITextRegion uniformRegion;
}
