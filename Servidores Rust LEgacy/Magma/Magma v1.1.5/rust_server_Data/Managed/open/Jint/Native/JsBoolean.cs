using System;

namespace Jint.Native
{
	// Token: 0x0200005E RID: 94
	[global::System.Serializable]
	public sealed class JsBoolean : global::Jint.Native.JsLiteral
	{
		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000495 RID: 1173 RVA: 0x000262E8 File Offset: 0x000244E8
		public override object Value
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x000262F8 File Offset: 0x000244F8
		public JsBoolean(global::Jint.Native.JsObject prototype) : this(false, prototype)
		{
			this.value = false;
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x0002630C File Offset: 0x0002450C
		public JsBoolean(bool boolean, global::Jint.Native.JsObject prototype) : base(prototype)
		{
			this.value = boolean;
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000498 RID: 1176 RVA: 0x0002631C File Offset: 0x0002451C
		public override bool IsClr
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000499 RID: 1177 RVA: 0x00026320 File Offset: 0x00024520
		public override string Type
		{
			get
			{
				return "boolean";
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x0600049A RID: 1178 RVA: 0x00026328 File Offset: 0x00024528
		public override string Class
		{
			get
			{
				return "Boolean";
			}
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x00026330 File Offset: 0x00024530
		public override bool ToBoolean()
		{
			return this.value;
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x00026338 File Offset: 0x00024538
		public override string ToString()
		{
			if (!this.value)
			{
				return "false";
			}
			return "true";
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x00026350 File Offset: 0x00024550
		public static double BooleanToNumber(bool value)
		{
			return (double)(value ? 1 : 0);
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x00026360 File Offset: 0x00024560
		public override double ToNumber()
		{
			return global::Jint.Native.JsBoolean.BooleanToNumber(this.value);
		}

		// Token: 0x04000228 RID: 552
		private new bool value;
	}
}
