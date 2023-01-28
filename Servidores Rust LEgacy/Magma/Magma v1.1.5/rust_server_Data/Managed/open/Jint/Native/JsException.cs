using System;
using System.Runtime.CompilerServices;

namespace Jint.Native
{
	// Token: 0x0200004C RID: 76
	[global::System.Serializable]
	public class JsException : global::System.Exception
	{
		// Token: 0x17000095 RID: 149
		// (get) Token: 0x0600037B RID: 891 RVA: 0x0001F93C File Offset: 0x0001DB3C
		// (set) Token: 0x0600037C RID: 892 RVA: 0x0001F944 File Offset: 0x0001DB44
		public global::Jint.Native.JsInstance Value
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Value>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Value>k__BackingField = value;
			}
		}

		// Token: 0x0600037D RID: 893 RVA: 0x0001F950 File Offset: 0x0001DB50
		public JsException()
		{
		}

		// Token: 0x0600037E RID: 894 RVA: 0x0001F958 File Offset: 0x0001DB58
		public JsException(global::Jint.Native.JsInstance value)
		{
			this.Value = value;
		}

		// Token: 0x04000211 RID: 529
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsInstance <Value>k__BackingField;
	}
}
