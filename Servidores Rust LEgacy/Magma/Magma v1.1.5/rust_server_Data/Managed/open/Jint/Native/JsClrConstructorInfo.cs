using System;
using System.Reflection;

namespace Jint.Native
{
	// Token: 0x0200004A RID: 74
	[global::System.Serializable]
	public class JsClrConstructorInfo : global::Jint.Native.JsObject
	{
		// Token: 0x0600036D RID: 877 RVA: 0x0001F8AC File Offset: 0x0001DAAC
		public JsClrConstructorInfo()
		{
			this.value = null;
		}

		// Token: 0x0600036E RID: 878 RVA: 0x0001F8BC File Offset: 0x0001DABC
		public JsClrConstructorInfo(global::System.Reflection.ConstructorInfo clr)
		{
			this.value = clr;
		}

		// Token: 0x0600036F RID: 879 RVA: 0x0001F8CC File Offset: 0x0001DACC
		public override bool ToBoolean()
		{
			return false;
		}

		// Token: 0x06000370 RID: 880 RVA: 0x0001F8D0 File Offset: 0x0001DAD0
		public override double ToNumber()
		{
			return 0.0;
		}

		// Token: 0x06000371 RID: 881 RVA: 0x0001F8DC File Offset: 0x0001DADC
		public override string ToString()
		{
			return this.value.Name;
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000372 RID: 882 RVA: 0x0001F8EC File Offset: 0x0001DAEC
		public override string Class
		{
			get
			{
				return "clrMethodInfo";
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000373 RID: 883 RVA: 0x0001F8F4 File Offset: 0x0001DAF4
		public override object Value
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x0400020D RID: 525
		public const string TYPEOF = "clrMethodInfo";

		// Token: 0x0400020E RID: 526
		private new global::System.Reflection.ConstructorInfo value;
	}
}
