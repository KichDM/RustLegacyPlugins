using System;
using System.Globalization;

namespace Jint.Native
{
	// Token: 0x02000063 RID: 99
	[global::System.Serializable]
	public sealed class JsDate : global::Jint.Native.JsObject
	{
		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x0600050E RID: 1294 RVA: 0x000279EC File Offset: 0x00025BEC
		// (set) Token: 0x0600050F RID: 1295 RVA: 0x000279FC File Offset: 0x00025BFC
		public override object Value
		{
			get
			{
				return this.value;
			}
			set
			{
				if (value is global::System.DateTime)
				{
					this.value = (global::System.DateTime)value;
					return;
				}
				if (value is double)
				{
					this.value = global::Jint.Native.JsDateConstructor.CreateDateTime((double)value);
				}
			}
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x00027A34 File Offset: 0x00025C34
		public JsDate(global::Jint.Native.JsObject prototype) : base(prototype)
		{
			this.value = new global::System.DateTime(0x7B2, 1, 1, 0, 0, 0, global::System.DateTimeKind.Utc);
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x00027A64 File Offset: 0x00025C64
		public JsDate(global::System.DateTime date, global::Jint.Native.JsObject prototype) : base(prototype)
		{
			this.value = date;
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x00027A74 File Offset: 0x00025C74
		public JsDate(double value, global::Jint.Native.JsObject prototype) : this(global::Jint.Native.JsDateConstructor.CreateDateTime(value), prototype)
		{
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000513 RID: 1299 RVA: 0x00027A84 File Offset: 0x00025C84
		public override bool IsClr
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x00027A88 File Offset: 0x00025C88
		public override double ToNumber()
		{
			return global::Jint.Native.JsDate.DateToDouble(this.value);
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x00027A98 File Offset: 0x00025C98
		public static double DateToDouble(global::System.DateTime date)
		{
			return (double)((date.ToUniversalTime().Ticks - global::Jint.Native.JsDate.OFFSET_1970) / (long)global::Jint.Native.JsDate.TICKSFACTOR);
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x00027AC8 File Offset: 0x00025CC8
		public static string DateToString(global::System.DateTime date)
		{
			return date.ToLocalTime().ToString(global::Jint.Native.JsDate.FORMAT, global::System.Globalization.CultureInfo.InvariantCulture);
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x00027AF4 File Offset: 0x00025CF4
		public override string ToString()
		{
			return global::Jint.Native.JsDate.DateToString(this.value);
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x00027B04 File Offset: 0x00025D04
		public override object ToObject()
		{
			return this.value;
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06000519 RID: 1305 RVA: 0x00027B14 File Offset: 0x00025D14
		public override string Class
		{
			get
			{
				return "Date";
			}
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x00027B1C File Offset: 0x00025D1C
		// Note: this type is marked as 'beforefieldinit'.
		static JsDate()
		{
		}

		// Token: 0x04000243 RID: 579
		internal static long OFFSET_1970 = new global::System.DateTime(0x7B2, 1, 1, 0, 0, 0, global::System.DateTimeKind.Utc).Ticks;

		// Token: 0x04000244 RID: 580
		internal static int TICKSFACTOR = 0x2710;

		// Token: 0x04000245 RID: 581
		private new global::System.DateTime value;

		// Token: 0x04000246 RID: 582
		public static string FORMAT = "ddd, dd MMM yyyy HH':'mm':'ss 'GMT'zzz";

		// Token: 0x04000247 RID: 583
		public static string FORMATUTC = "ddd, dd MMM yyyy HH':'mm':'ss 'UTC'";

		// Token: 0x04000248 RID: 584
		public static string DATEFORMAT = "ddd, dd MMM yyyy";

		// Token: 0x04000249 RID: 585
		public static string TIMEFORMAT = "HH':'mm':'ss 'GMT'zzz";
	}
}
