using System;

namespace Jint.Native
{
	// Token: 0x0200005B RID: 91
	[global::System.Serializable]
	public class JsUndefined : global::Jint.Native.JsObject
	{
		// Token: 0x06000466 RID: 1126 RVA: 0x00025A1C File Offset: 0x00023C1C
		public JsUndefined()
		{
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000467 RID: 1127 RVA: 0x00025A24 File Offset: 0x00023C24
		// (set) Token: 0x06000468 RID: 1128 RVA: 0x00025A28 File Offset: 0x00023C28
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

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000469 RID: 1129 RVA: 0x00025A2C File Offset: 0x00023C2C
		public override bool IsClr
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x00025A30 File Offset: 0x00023C30
		public override global::Jint.Native.Descriptor GetDescriptor(string index)
		{
			return null;
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x0600046B RID: 1131 RVA: 0x00025A34 File Offset: 0x00023C34
		public override string Class
		{
			get
			{
				return "Undefined";
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x0600046C RID: 1132 RVA: 0x00025A3C File Offset: 0x00023C3C
		public override string Type
		{
			get
			{
				return "undefined";
			}
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x00025A44 File Offset: 0x00023C44
		public override string ToString()
		{
			return "undefined";
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x00025A4C File Offset: 0x00023C4C
		public override object ToObject()
		{
			return null;
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x00025A50 File Offset: 0x00023C50
		public override bool ToBoolean()
		{
			return false;
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x00025A54 File Offset: 0x00023C54
		public override double ToNumber()
		{
			return double.NaN;
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x00025A60 File Offset: 0x00023C60
		// Note: this type is marked as 'beforefieldinit'.
		static JsUndefined()
		{
		}

		// Token: 0x04000223 RID: 547
		public static global::Jint.Native.JsUndefined Instance = new global::Jint.Native.JsUndefined
		{
			Attributes = (global::Jint.Native.PropertyAttributes.DontEnum | global::Jint.Native.PropertyAttributes.DontDelete)
		};
	}
}
