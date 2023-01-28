using System;
using Jint.Expressions;

namespace Jint.Native
{
	// Token: 0x02000039 RID: 57
	[global::System.Serializable]
	public class JsErrorConstructor : global::Jint.Native.JsConstructor
	{
		// Token: 0x060002B3 RID: 691 RVA: 0x0001BCA8 File Offset: 0x00019EA8
		public JsErrorConstructor(global::Jint.Native.IGlobal global, string errorType) : base(global)
		{
			this.errorType = errorType;
			base.Name = errorType;
			base.DefineOwnProperty(global::Jint.Native.JsFunction.PROTOTYPE, global.ObjectClass.New(this), global::Jint.Native.PropertyAttributes.ReadOnly | global::Jint.Native.PropertyAttributes.DontEnum | global::Jint.Native.PropertyAttributes.DontDelete);
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0001BCE8 File Offset: 0x00019EE8
		public override void InitPrototype(global::Jint.Native.IGlobal global)
		{
			global::Jint.Native.JsObject prototypeProperty = base.PrototypeProperty;
			prototypeProperty.DefineOwnProperty("name", global.StringClass.New(this.errorType), global::Jint.Native.PropertyAttributes.ReadOnly | global::Jint.Native.PropertyAttributes.DontEnum | global::Jint.Native.PropertyAttributes.DontDelete);
			prototypeProperty.DefineOwnProperty("toString", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToStringImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("toLocaleString", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToStringImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0001BD64 File Offset: 0x00019F64
		public global::Jint.Native.JsError New(string message)
		{
			global::Jint.Native.JsError jsError = new global::Jint.Native.JsError(base.Global);
			jsError["message"] = base.Global.StringClass.New(message);
			return jsError;
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0001BDA0 File Offset: 0x00019FA0
		public global::Jint.Native.JsError New()
		{
			return this.New(string.Empty);
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x0001BDB0 File Offset: 0x00019FB0
		public override global::Jint.Native.JsInstance Execute(global::Jint.Expressions.IJintVisitor visitor, global::Jint.Native.JsDictionaryObject that, global::Jint.Native.JsInstance[] parameters)
		{
			if (that == null || that as global::Jint.Native.IGlobal == visitor.Global)
			{
				visitor.Return((parameters.Length > 0) ? this.New(parameters[0].ToString()) : this.New());
			}
			else
			{
				if (parameters.Length > 0)
				{
					that.Value = parameters[0].ToString();
				}
				else
				{
					that.Value = string.Empty;
				}
				visitor.Return(that);
			}
			return that;
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0001BE40 File Offset: 0x0001A040
		public global::Jint.Native.JsInstance ToStringImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			return base.Global.StringClass.New(target["name"] + ": " + target["message"]);
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x0001BE84 File Offset: 0x0001A084
		public override global::Jint.Native.JsObject Construct(global::Jint.Native.JsInstance[] parameters, global::System.Type[] genericArgs, global::Jint.Expressions.IJintVisitor visitor)
		{
			if (parameters == null || parameters.Length <= 0)
			{
				return visitor.Global.ErrorClass.New();
			}
			return visitor.Global.ErrorClass.New(parameters[0].ToString());
		}

		// Token: 0x040001E9 RID: 489
		private string errorType;
	}
}
