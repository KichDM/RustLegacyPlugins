using System;
using System.Globalization;

namespace Jint.Native
{
	// Token: 0x02000060 RID: 96
	[global::System.Serializable]
	public sealed class JsNumber : global::Jint.Native.JsLiteral
	{
		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060004AC RID: 1196 RVA: 0x00026484 File Offset: 0x00024684
		public override object Value
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x00026494 File Offset: 0x00024694
		public JsNumber(global::Jint.Native.JsObject prototype) : this(0.0, prototype)
		{
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x000264A8 File Offset: 0x000246A8
		public JsNumber(double num, global::Jint.Native.JsObject prototype) : base(prototype)
		{
			this.value = num;
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x000264B8 File Offset: 0x000246B8
		public JsNumber(int num, global::Jint.Native.JsObject prototype) : base(prototype)
		{
			this.value = (double)num;
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060004B0 RID: 1200 RVA: 0x000264CC File Offset: 0x000246CC
		public override bool IsClr
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x000264D0 File Offset: 0x000246D0
		public static bool NumberToBoolean(double value)
		{
			return value != 0.0 && !double.IsNaN(value);
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x000264EC File Offset: 0x000246EC
		public override bool ToBoolean()
		{
			return global::Jint.Native.JsNumber.NumberToBoolean(this.value);
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x000264FC File Offset: 0x000246FC
		public override double ToNumber()
		{
			return this.value;
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x00026504 File Offset: 0x00024704
		public override string ToString()
		{
			return this.value.ToString(global::System.Globalization.CultureInfo.InvariantCulture);
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x00026518 File Offset: 0x00024718
		public override object ToObject()
		{
			return this.value;
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060004B6 RID: 1206 RVA: 0x00026528 File Offset: 0x00024728
		public override string Class
		{
			get
			{
				return "Number";
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060004B7 RID: 1207 RVA: 0x00026530 File Offset: 0x00024730
		public override string Type
		{
			get
			{
				return "number";
			}
		}

		// Token: 0x0400022A RID: 554
		private new double value;
	}
}
