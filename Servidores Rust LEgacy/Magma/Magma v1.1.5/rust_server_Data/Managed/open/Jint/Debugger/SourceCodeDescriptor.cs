using System;
using System.Runtime.CompilerServices;

namespace Jint.Debugger
{
	// Token: 0x0200002A RID: 42
	[global::System.Serializable]
	public class SourceCodeDescriptor
	{
		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000255 RID: 597 RVA: 0x0001B784 File Offset: 0x00019984
		// (set) Token: 0x06000256 RID: 598 RVA: 0x0001B78C File Offset: 0x0001998C
		public global::Jint.Debugger.SourceCodeDescriptor.Location Start
		{
			get
			{
				return this.start;
			}
			set
			{
				this.start = value;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000257 RID: 599 RVA: 0x0001B798 File Offset: 0x00019998
		// (set) Token: 0x06000258 RID: 600 RVA: 0x0001B7A0 File Offset: 0x000199A0
		public global::Jint.Debugger.SourceCodeDescriptor.Location Stop
		{
			get
			{
				return this.stop;
			}
			set
			{
				this.stop = value;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000259 RID: 601 RVA: 0x0001B7AC File Offset: 0x000199AC
		// (set) Token: 0x0600025A RID: 602 RVA: 0x0001B7B4 File Offset: 0x000199B4
		public string Code
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Code>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<Code>k__BackingField = value;
			}
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0001B7C0 File Offset: 0x000199C0
		public SourceCodeDescriptor(int startLine, int startChar, int stopLine, int stopChar, string code)
		{
			this.Code = code;
			this.Start = new global::Jint.Debugger.SourceCodeDescriptor.Location(startLine, startChar);
			this.Stop = new global::Jint.Debugger.SourceCodeDescriptor.Location(stopLine, stopChar);
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0001B7FC File Offset: 0x000199FC
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"Line: ",
				this.Start.Line,
				" Char: ",
				this.Start.Char
			});
		}

		// Token: 0x040001D1 RID: 465
		protected global::Jint.Debugger.SourceCodeDescriptor.Location start;

		// Token: 0x040001D2 RID: 466
		protected global::Jint.Debugger.SourceCodeDescriptor.Location stop;

		// Token: 0x040001D3 RID: 467
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string <Code>k__BackingField;

		// Token: 0x02000145 RID: 325
		[global::System.Serializable]
		public class Location
		{
			// Token: 0x06000BC4 RID: 3012 RVA: 0x0003B85C File Offset: 0x00039A5C
			public Location(int line, int c)
			{
				this.line = line;
				this._Char = c;
			}

			// Token: 0x1700029C RID: 668
			// (get) Token: 0x06000BC5 RID: 3013 RVA: 0x0003B874 File Offset: 0x00039A74
			// (set) Token: 0x06000BC6 RID: 3014 RVA: 0x0003B87C File Offset: 0x00039A7C
			public int Line
			{
				get
				{
					return this.line;
				}
				set
				{
					this.line = value;
				}
			}

			// Token: 0x1700029D RID: 669
			// (get) Token: 0x06000BC7 RID: 3015 RVA: 0x0003B888 File Offset: 0x00039A88
			// (set) Token: 0x06000BC8 RID: 3016 RVA: 0x0003B890 File Offset: 0x00039A90
			public int Char
			{
				get
				{
					return this._Char;
				}
				set
				{
					this._Char = value;
				}
			}

			// Token: 0x0400069E RID: 1694
			private int line;

			// Token: 0x0400069F RID: 1695
			private int _Char;
		}
	}
}
