using System;

namespace Mono.Cecil.Cil
{
	// Token: 0x020000B5 RID: 181
	public sealed class SequencePoint
	{
		// Token: 0x17000290 RID: 656
		// (get) Token: 0x06000757 RID: 1879 RVA: 0x0001378F File Offset: 0x0001198F
		// (set) Token: 0x06000758 RID: 1880 RVA: 0x00013797 File Offset: 0x00011997
		public int StartLine
		{
			get
			{
				return this.start_line;
			}
			set
			{
				this.start_line = value;
			}
		}

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x06000759 RID: 1881 RVA: 0x000137A0 File Offset: 0x000119A0
		// (set) Token: 0x0600075A RID: 1882 RVA: 0x000137A8 File Offset: 0x000119A8
		public int StartColumn
		{
			get
			{
				return this.start_column;
			}
			set
			{
				this.start_column = value;
			}
		}

		// Token: 0x17000292 RID: 658
		// (get) Token: 0x0600075B RID: 1883 RVA: 0x000137B1 File Offset: 0x000119B1
		// (set) Token: 0x0600075C RID: 1884 RVA: 0x000137B9 File Offset: 0x000119B9
		public int EndLine
		{
			get
			{
				return this.end_line;
			}
			set
			{
				this.end_line = value;
			}
		}

		// Token: 0x17000293 RID: 659
		// (get) Token: 0x0600075D RID: 1885 RVA: 0x000137C2 File Offset: 0x000119C2
		// (set) Token: 0x0600075E RID: 1886 RVA: 0x000137CA File Offset: 0x000119CA
		public int EndColumn
		{
			get
			{
				return this.end_column;
			}
			set
			{
				this.end_column = value;
			}
		}

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x0600075F RID: 1887 RVA: 0x000137D3 File Offset: 0x000119D3
		// (set) Token: 0x06000760 RID: 1888 RVA: 0x000137DB File Offset: 0x000119DB
		public global::Mono.Cecil.Cil.Document Document
		{
			get
			{
				return this.document;
			}
			set
			{
				this.document = value;
			}
		}

		// Token: 0x06000761 RID: 1889 RVA: 0x000137E4 File Offset: 0x000119E4
		public SequencePoint(global::Mono.Cecil.Cil.Document document)
		{
			this.document = document;
		}

		// Token: 0x0400058F RID: 1423
		private global::Mono.Cecil.Cil.Document document;

		// Token: 0x04000590 RID: 1424
		private int start_line;

		// Token: 0x04000591 RID: 1425
		private int start_column;

		// Token: 0x04000592 RID: 1426
		private int end_line;

		// Token: 0x04000593 RID: 1427
		private int end_column;
	}
}
