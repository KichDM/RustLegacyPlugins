using System;

// Token: 0x02000947 RID: 2375
public struct UIHighlight
{
	// Token: 0x17000EF6 RID: 3830
	// (get) Token: 0x060050B7 RID: 20663 RVA: 0x0013C334 File Offset: 0x0013A534
	public static global::UIHighlight invalid
	{
		get
		{
			return new global::UIHighlight
			{
				a = new global::UIHighlight.Node
				{
					i = -1
				},
				b = new global::UIHighlight.Node
				{
					i = -1
				}
			};
		}
	}

	// Token: 0x17000EF7 RID: 3831
	// (get) Token: 0x060050B8 RID: 20664 RVA: 0x0013C37C File Offset: 0x0013A57C
	public int lineCount
	{
		get
		{
			return (this.a.i == this.b.i) ? 0 : (this.b.L - this.a.L + 1);
		}
	}

	// Token: 0x17000EF8 RID: 3832
	// (get) Token: 0x060050B9 RID: 20665 RVA: 0x0013C3C4 File Offset: 0x0013A5C4
	public bool empty
	{
		get
		{
			return this.a.i == this.b.i;
		}
	}

	// Token: 0x17000EF9 RID: 3833
	// (get) Token: 0x060050BA RID: 20666 RVA: 0x0013C3E0 File Offset: 0x0013A5E0
	public bool any
	{
		get
		{
			return this.a.i != this.b.i;
		}
	}

	// Token: 0x17000EFA RID: 3834
	// (get) Token: 0x060050BB RID: 20667 RVA: 0x0013C400 File Offset: 0x0013A600
	public int characterCount
	{
		get
		{
			return this.b.i - this.a.i;
		}
	}

	// Token: 0x17000EFB RID: 3835
	// (get) Token: 0x060050BC RID: 20668 RVA: 0x0013C41C File Offset: 0x0013A61C
	public int lineSpan
	{
		get
		{
			return this.b.L - this.a.L;
		}
	}

	// Token: 0x17000EFC RID: 3836
	// (get) Token: 0x060050BD RID: 20669 RVA: 0x0013C438 File Offset: 0x0013A638
	public global::UIHighlight.Node delta
	{
		get
		{
			global::UIHighlight.Node result;
			result.i = this.b.i - this.a.i;
			result.L = this.b.L - this.a.L;
			result.C = this.b.C - this.a.C;
			return result;
		}
	}

	// Token: 0x04002D6B RID: 11627
	public global::UIHighlight.Node a;

	// Token: 0x04002D6C RID: 11628
	public global::UIHighlight.Node b;

	// Token: 0x02000948 RID: 2376
	public struct Node
	{
		// Token: 0x060050BE RID: 20670 RVA: 0x0013C4A0 File Offset: 0x0013A6A0
		public override string ToString()
		{
			return string.Format("[{0}({1}:{2})]", this.i, this.L, this.C);
		}

		// Token: 0x04002D6D RID: 11629
		public int i;

		// Token: 0x04002D6E RID: 11630
		public int L;

		// Token: 0x04002D6F RID: 11631
		public int C;
	}
}
