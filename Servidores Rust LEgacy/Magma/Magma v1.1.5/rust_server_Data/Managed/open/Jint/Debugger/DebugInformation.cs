using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Jint.Expressions;
using Jint.Native;

namespace Jint.Debugger
{
	// Token: 0x02000029 RID: 41
	[global::System.Serializable]
	public class DebugInformation : global::System.EventArgs
	{
		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600024E RID: 590 RVA: 0x0001B740 File Offset: 0x00019940
		// (set) Token: 0x0600024F RID: 591 RVA: 0x0001B748 File Offset: 0x00019948
		public global::System.Collections.Generic.Stack<string> CallStack
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<CallStack>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<CallStack>k__BackingField = value;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000250 RID: 592 RVA: 0x0001B754 File Offset: 0x00019954
		// (set) Token: 0x06000251 RID: 593 RVA: 0x0001B75C File Offset: 0x0001995C
		public global::Jint.Expressions.Statement CurrentStatement
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<CurrentStatement>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<CurrentStatement>k__BackingField = value;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000252 RID: 594 RVA: 0x0001B768 File Offset: 0x00019968
		// (set) Token: 0x06000253 RID: 595 RVA: 0x0001B770 File Offset: 0x00019970
		public global::Jint.Native.JsDictionaryObject Locals
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Locals>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Locals>k__BackingField = value;
			}
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0001B77C File Offset: 0x0001997C
		public DebugInformation()
		{
		}

		// Token: 0x040001CE RID: 462
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::System.Collections.Generic.Stack<string> <CallStack>k__BackingField;

		// Token: 0x040001CF RID: 463
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Statement <CurrentStatement>k__BackingField;

		// Token: 0x040001D0 RID: 464
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsDictionaryObject <Locals>k__BackingField;
	}
}
