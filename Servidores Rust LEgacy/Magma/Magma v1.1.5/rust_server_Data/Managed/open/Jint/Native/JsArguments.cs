using System;

namespace Jint.Native
{
	// Token: 0x0200004E RID: 78
	[global::System.Serializable]
	public class JsArguments : global::Jint.Native.JsObject
	{
		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000384 RID: 900 RVA: 0x0001FA0C File Offset: 0x0001DC0C
		// (set) Token: 0x06000385 RID: 901 RVA: 0x0001FA20 File Offset: 0x0001DC20
		protected global::Jint.Native.JsFunction Callee
		{
			get
			{
				return this["callee"] as global::Jint.Native.JsFunction;
			}
			set
			{
				this["callee"] = value;
			}
		}

		// Token: 0x06000386 RID: 902 RVA: 0x0001FA30 File Offset: 0x0001DC30
		public JsArguments(global::Jint.Native.IGlobal global, global::Jint.Native.JsFunction callee, global::Jint.Native.JsInstance[] arguments) : base(global.ObjectClass.New())
		{
			this.global = global;
			for (int i = 0; i < arguments.Length; i++)
			{
				this.DefineOwnProperty(new global::Jint.Native.ValueDescriptor(this, i.ToString(), arguments[i])
				{
					Enumerable = false
				});
			}
			this.length = arguments.Length;
			this.calleeDescriptor = new global::Jint.Native.ValueDescriptor(this, "callee", callee)
			{
				Enumerable = false
			};
			this.DefineOwnProperty(this.calleeDescriptor);
			this.DefineOwnProperty(new global::Jint.Native.PropertyDescriptor<global::Jint.Native.JsArguments>(global, this, "length", new global::System.Func<global::Jint.Native.JsArguments, global::Jint.Native.JsInstance>(this.GetLength))
			{
				Enumerable = false
			});
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000387 RID: 903 RVA: 0x0001FAE4 File Offset: 0x0001DCE4
		public override bool IsClr
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000388 RID: 904 RVA: 0x0001FAE8 File Offset: 0x0001DCE8
		public override bool ToBoolean()
		{
			return false;
		}

		// Token: 0x06000389 RID: 905 RVA: 0x0001FAEC File Offset: 0x0001DCEC
		public override double ToNumber()
		{
			return (double)this.Length;
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600038A RID: 906 RVA: 0x0001FAF8 File Offset: 0x0001DCF8
		// (set) Token: 0x0600038B RID: 907 RVA: 0x0001FB00 File Offset: 0x0001DD00
		public override int Length
		{
			get
			{
				return this.length;
			}
			set
			{
				this.length = value;
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x0600038C RID: 908 RVA: 0x0001FB0C File Offset: 0x0001DD0C
		public override string Class
		{
			get
			{
				return "Arguments";
			}
		}

		// Token: 0x0600038D RID: 909 RVA: 0x0001FB14 File Offset: 0x0001DD14
		public global::Jint.Native.JsInstance GetLength(global::Jint.Native.JsArguments target)
		{
			return this.global.NumberClass.New((double)target.length);
		}

		// Token: 0x04000213 RID: 531
		public const string CALLEE = "callee";

		// Token: 0x04000214 RID: 532
		protected global::Jint.Native.ValueDescriptor calleeDescriptor;

		// Token: 0x04000215 RID: 533
		private int length;

		// Token: 0x04000216 RID: 534
		private global::Jint.Native.IGlobal global;
	}
}
