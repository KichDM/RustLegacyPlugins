using System;
using Jint.Expressions;

namespace Jint.Native
{
	// Token: 0x02000035 RID: 53
	[global::System.Serializable]
	public class JsApplyFunction : global::Jint.Native.JsFunction
	{
		// Token: 0x060002A3 RID: 675 RVA: 0x0001BA30 File Offset: 0x00019C30
		public JsApplyFunction(global::Jint.Native.JsFunctionConstructor constructor) : base(constructor.PrototypeProperty)
		{
			base.DefineOwnProperty("length", constructor.Global.NumberClass.New(2.0), global::Jint.Native.PropertyAttributes.ReadOnly);
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0001BA74 File Offset: 0x00019C74
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
				global::Jint.Native.JsObject jsObject = parameters[1] as global::Jint.Native.JsObject;
				if (jsObject == null)
				{
					throw new global::Jint.Native.JsException(visitor.Global.TypeErrorClass.New("second argument must be an array"));
				}
				array = new global::Jint.Native.JsInstance[jsObject.Length];
				for (int i = 0; i < jsObject.Length; i++)
				{
					array[i] = jsObject[i.ToString()];
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
