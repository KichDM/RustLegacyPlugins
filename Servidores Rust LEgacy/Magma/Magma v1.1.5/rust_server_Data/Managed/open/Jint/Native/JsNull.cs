using System;
using System.Collections.Generic;

namespace Jint.Native
{
	// Token: 0x02000058 RID: 88
	[global::System.Serializable]
	public class JsNull : global::Jint.Native.JsObject
	{
		// Token: 0x0600043C RID: 1084 RVA: 0x000253F8 File Offset: 0x000235F8
		public JsNull()
		{
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x0600043D RID: 1085 RVA: 0x00025400 File Offset: 0x00023600
		public override bool IsClr
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x0600043E RID: 1086 RVA: 0x00025404 File Offset: 0x00023604
		public override string Type
		{
			get
			{
				return "null";
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x0600043F RID: 1087 RVA: 0x0002540C File Offset: 0x0002360C
		public override string Class
		{
			get
			{
				return "Null";
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000440 RID: 1088 RVA: 0x00025414 File Offset: 0x00023614
		// (set) Token: 0x06000441 RID: 1089 RVA: 0x00025418 File Offset: 0x00023618
		public override int Length
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x0002541C File Offset: 0x0002361C
		public override bool ToBoolean()
		{
			return false;
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x00025420 File Offset: 0x00023620
		public override double ToNumber()
		{
			return 0.0;
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x0002542C File Offset: 0x0002362C
		public override string ToString()
		{
			return "null";
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00025434 File Offset: 0x00023634
		public override global::Jint.Native.Descriptor GetDescriptor(string index)
		{
			return null;
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x00025438 File Offset: 0x00023638
		public override global::System.Collections.Generic.IEnumerable<string> GetKeys()
		{
			return new string[0];
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000447 RID: 1095 RVA: 0x00025440 File Offset: 0x00023640
		// (set) Token: 0x06000448 RID: 1096 RVA: 0x00025444 File Offset: 0x00023644
		public override object Value
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x00025448 File Offset: 0x00023648
		public override void DefineOwnProperty(global::Jint.Native.Descriptor value)
		{
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x0002544C File Offset: 0x0002364C
		public override bool HasProperty(string key)
		{
			return false;
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x00025450 File Offset: 0x00023650
		public override bool HasOwnProperty(string key)
		{
			return false;
		}

		// Token: 0x170000A8 RID: 168
		public override global::Jint.Native.JsInstance this[string index]
		{
			get
			{
				return global::Jint.Native.JsUndefined.Instance;
			}
			set
			{
			}
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x00025460 File Offset: 0x00023660
		// Note: this type is marked as 'beforefieldinit'.
		static JsNull()
		{
		}

		// Token: 0x04000220 RID: 544
		public static global::Jint.Native.JsNull Instance = new global::Jint.Native.JsNull();
	}
}
