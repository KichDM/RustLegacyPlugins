using System;
using System.Runtime.CompilerServices;

namespace Jint.Debugger
{
	// Token: 0x02000028 RID: 40
	[global::System.Serializable]
	public class BreakPoint
	{
		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000246 RID: 582 RVA: 0x0001B6D8 File Offset: 0x000198D8
		// (set) Token: 0x06000247 RID: 583 RVA: 0x0001B6E0 File Offset: 0x000198E0
		public int Line
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Line>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Line>k__BackingField = value;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000248 RID: 584 RVA: 0x0001B6EC File Offset: 0x000198EC
		// (set) Token: 0x06000249 RID: 585 RVA: 0x0001B6F4 File Offset: 0x000198F4
		public int Char
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Char>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Char>k__BackingField = value;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600024A RID: 586 RVA: 0x0001B700 File Offset: 0x00019900
		// (set) Token: 0x0600024B RID: 587 RVA: 0x0001B708 File Offset: 0x00019908
		public string Condition
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Condition>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Condition>k__BackingField = value;
			}
		}

		// Token: 0x0600024C RID: 588 RVA: 0x0001B714 File Offset: 0x00019914
		public BreakPoint(int line, int character)
		{
			this.Line = line;
			this.Char = character;
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0001B72C File Offset: 0x0001992C
		public BreakPoint(int line, int character, string condition) : this(line, character)
		{
			this.Condition = condition;
		}

		// Token: 0x040001CB RID: 459
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private int <Line>k__BackingField;

		// Token: 0x040001CC RID: 460
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private int <Char>k__BackingField;

		// Token: 0x040001CD RID: 461
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string <Condition>k__BackingField;
	}
}
