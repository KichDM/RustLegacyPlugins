using System;
using Jint.Expressions;

namespace Jint.Native
{
	// Token: 0x02000050 RID: 80
	[global::System.Serializable]
	public class JsCallFunction : global::Jint.Native.JsFunction
	{
		// Token: 0x060003A3 RID: 931 RVA: 0x0001FEC0 File Offset: 0x0001E0C0
		public JsCallFunction(global::Jint.Native.JsFunctionConstructor constructor) : base(constructor.PrototypeProperty)
		{
			base.DefineOwnProperty("length", constructor.Global.NumberClass.New(1.0), global::Jint.Native.PropertyAttributes.ReadOnly);
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x0001FF04 File Offset: 0x0001E104
		public override global::Jint.Native.JsInstance Execute(global::Jint.Expressions.IJintVisitor visitor, global::Jint.Native.JsDictionaryObject that, global::Jint.Native.JsInstance[] parameters)
		{
			global::Jint.Native.JsFunction jsFunction = that as global::Jint.Native.JsFunction;
			if (jsFunction == null)
			{
				throw new global::System.ArgumentException("the target of call() must be a function");
			}
			global::Jint.Native.JsDictionaryObject this2;
			if (parameters.Length >= 1)
			{
				this2 = (parameters[0] as global::Jint.Native.JsDictionaryObject);
			}
			else
			{
				this2 = (visitor.Global as global::Jint.Native.JsDictionaryObject);
			}
			global::Jint.Native.JsInstance[] array;
			if (parameters.Length >= 2 && parameters[1] != global::Jint.Native.JsNull.Instance)
			{
				array = new global::Jint.Native.JsInstance[parameters.Length - 1];
				for (int i = 1; i < parameters.Length; i++)
				{
					array[i - 1] = parameters[i];
				}
			}
			else
			{
				array = global::Jint.Native.JsInstance.EMPTY;
			}
			visitor.ExecuteFunction(jsFunction, this2, array);
			return visitor.Result;
		}
	}
}
