using System;

namespace Jint.Native
{
	// Token: 0x02000038 RID: 56
	[global::System.Serializable]
	public class JsError : global::Jint.Native.JsObject
	{
		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060002AB RID: 683 RVA: 0x0001BC10 File Offset: 0x00019E10
		// (set) Token: 0x060002AC RID: 684 RVA: 0x0001BC24 File Offset: 0x00019E24
		private string message
		{
			get
			{
				return this["message"].ToString();
			}
			set
			{
				this["message"] = this.global.StringClass.New(value);
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060002AD RID: 685 RVA: 0x0001BC44 File Offset: 0x00019E44
		public override bool IsClr
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060002AE RID: 686 RVA: 0x0001BC48 File Offset: 0x00019E48
		public override object Value
		{
			get
			{
				return this.message;
			}
		}

		// Token: 0x060002AF RID: 687 RVA: 0x0001BC50 File Offset: 0x00019E50
		public JsError(global::Jint.Native.IGlobal global) : this(global, string.Empty)
		{
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x0001BC60 File Offset: 0x00019E60
		public JsError(global::Jint.Native.IGlobal global, string message) : base(global.ErrorClass.PrototypeProperty)
		{
			this.global = global;
			this.message = message;
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060002B1 RID: 689 RVA: 0x0001BC90 File Offset: 0x00019E90
		public override string Class
		{
			get
			{
				return "Error";
			}
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0001BC98 File Offset: 0x00019E98
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x040001E8 RID: 488
		private global::Jint.Native.IGlobal global;
	}
}
