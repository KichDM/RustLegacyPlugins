using System;
using System.Globalization;

namespace Jint.Native
{
	// Token: 0x0200005F RID: 95
	[global::System.Serializable]
	public sealed class JsString : global::Jint.Native.JsLiteral
	{
		// Token: 0x170000BE RID: 190
		// (get) Token: 0x0600049F RID: 1183 RVA: 0x00026370 File Offset: 0x00024570
		public override object Value
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x00026378 File Offset: 0x00024578
		public JsString(global::Jint.Native.JsObject prototype) : base(prototype)
		{
			this.value = string.Empty;
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x0002638C File Offset: 0x0002458C
		public JsString(string str, global::Jint.Native.JsObject prototype) : base(prototype)
		{
			this.value = str;
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x0002639C File Offset: 0x0002459C
		public static bool StringToBoolean(string value)
		{
			return value != null && (value == "true" || value.Length > 0);
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060004A3 RID: 1187 RVA: 0x000263C8 File Offset: 0x000245C8
		public override bool IsClr
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x000263CC File Offset: 0x000245CC
		public override bool ToBoolean()
		{
			return global::Jint.Native.JsString.StringToBoolean(this.value);
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x000263DC File Offset: 0x000245DC
		public static double StringToNumber(string value)
		{
			if (value == null)
			{
				return double.NaN;
			}
			double result;
			if (double.TryParse(value, global::System.Globalization.NumberStyles.AllowDecimalPoint, global::System.Globalization.CultureInfo.InvariantCulture, out result))
			{
				return result;
			}
			return double.NaN;
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x0002641C File Offset: 0x0002461C
		public override double ToNumber()
		{
			return global::Jint.Native.JsString.StringToNumber(this.value);
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x0002642C File Offset: 0x0002462C
		public override string ToSource()
		{
			if (this.value != null)
			{
				return "'" + this.ToString() + "'";
			}
			return "null";
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x00026454 File Offset: 0x00024654
		public override string ToString()
		{
			return this.value.ToString();
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060004A9 RID: 1193 RVA: 0x00026464 File Offset: 0x00024664
		public override string Class
		{
			get
			{
				return "String";
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060004AA RID: 1194 RVA: 0x0002646C File Offset: 0x0002466C
		public override string Type
		{
			get
			{
				return "string";
			}
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x00026474 File Offset: 0x00024674
		public override int GetHashCode()
		{
			return this.value.GetHashCode();
		}

		// Token: 0x04000229 RID: 553
		private new string value;
	}
}
