using System;

namespace Jint.Native
{
	// Token: 0x0200004B RID: 75
	[global::System.Serializable]
	public class JsClrMethodInfo : global::Jint.Native.JsObject
	{
		// Token: 0x06000374 RID: 884 RVA: 0x0001F8FC File Offset: 0x0001DAFC
		public JsClrMethodInfo()
		{
		}

		// Token: 0x06000375 RID: 885 RVA: 0x0001F904 File Offset: 0x0001DB04
		public JsClrMethodInfo(string method)
		{
			this.value = method;
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0001F914 File Offset: 0x0001DB14
		public override bool ToBoolean()
		{
			return false;
		}

		// Token: 0x06000377 RID: 887 RVA: 0x0001F918 File Offset: 0x0001DB18
		public override double ToNumber()
		{
			return 0.0;
		}

		// Token: 0x06000378 RID: 888 RVA: 0x0001F924 File Offset: 0x0001DB24
		public override string ToString()
		{
			return string.Empty;
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000379 RID: 889 RVA: 0x0001F92C File Offset: 0x0001DB2C
		public override string Class
		{
			get
			{
				return "clrMethodInfo";
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x0600037A RID: 890 RVA: 0x0001F934 File Offset: 0x0001DB34
		public override object Value
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x0400020F RID: 527
		public const string TYPEOF = "clrMethodInfo";

		// Token: 0x04000210 RID: 528
		private new string value;
	}
}
