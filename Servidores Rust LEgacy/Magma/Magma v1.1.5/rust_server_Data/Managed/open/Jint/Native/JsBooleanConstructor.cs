using System;
using System.Runtime.CompilerServices;
using Jint.Expressions;

namespace Jint.Native
{
	// Token: 0x02000056 RID: 86
	[global::System.Serializable]
	public class JsBooleanConstructor : global::Jint.Native.JsConstructor
	{
		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x0600041C RID: 1052 RVA: 0x00023FBC File Offset: 0x000221BC
		// (set) Token: 0x0600041D RID: 1053 RVA: 0x00023FC4 File Offset: 0x000221C4
		public global::Jint.Native.JsBoolean False
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<False>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<False>k__BackingField = value;
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x0600041E RID: 1054 RVA: 0x00023FD0 File Offset: 0x000221D0
		// (set) Token: 0x0600041F RID: 1055 RVA: 0x00023FD8 File Offset: 0x000221D8
		public global::Jint.Native.JsBoolean True
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<True>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<True>k__BackingField = value;
			}
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x00023FE4 File Offset: 0x000221E4
		public JsBooleanConstructor(global::Jint.Native.IGlobal global) : base(global)
		{
			base.Name = "Boolean";
			base.DefineOwnProperty(global::Jint.Native.JsFunction.PROTOTYPE, global.ObjectClass.New(this), global::Jint.Native.PropertyAttributes.ReadOnly | global::Jint.Native.PropertyAttributes.DontEnum | global::Jint.Native.PropertyAttributes.DontDelete);
			this.True = this.New(true);
			this.False = this.New(false);
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x0002403C File Offset: 0x0002223C
		public override void InitPrototype(global::Jint.Native.IGlobal global)
		{
			global::Jint.Native.JsObject prototypeProperty = base.PrototypeProperty;
			prototypeProperty.DefineOwnProperty("toString", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToString2)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("toLocaleString", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToString2)), global::Jint.Native.PropertyAttributes.DontEnum);
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x0002409C File Offset: 0x0002229C
		public global::Jint.Native.JsBoolean New()
		{
			return this.New(false);
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x000240A8 File Offset: 0x000222A8
		public global::Jint.Native.JsBoolean New(bool value)
		{
			return new global::Jint.Native.JsBoolean(value, base.PrototypeProperty);
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x000240B8 File Offset: 0x000222B8
		public override global::Jint.Native.JsInstance Execute(global::Jint.Expressions.IJintVisitor visitor, global::Jint.Native.JsDictionaryObject that, global::Jint.Native.JsInstance[] parameters)
		{
			if (that == null || that as global::Jint.Native.IGlobal == visitor.Global)
			{
				visitor.Return((parameters.Length > 0) ? new global::Jint.Native.JsBoolean(parameters[0].ToBoolean(), base.PrototypeProperty) : new global::Jint.Native.JsBoolean(base.PrototypeProperty));
			}
			else
			{
				if (parameters.Length > 0)
				{
					that.Value = parameters[0].ToBoolean();
				}
				else
				{
					that.Value = false;
				}
				visitor.Return(that);
			}
			return that;
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x00024158 File Offset: 0x00022358
		public global::Jint.Native.JsInstance ToString2(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			return base.Global.StringClass.New(target.ToString());
		}

		// Token: 0x0400021E RID: 542
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsBoolean <False>k__BackingField;

		// Token: 0x0400021F RID: 543
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsBoolean <True>k__BackingField;
	}
}
