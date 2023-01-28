using System;
using Jint.Expressions;

namespace Jint.Native
{
	// Token: 0x02000059 RID: 89
	[global::System.Serializable]
	public class JsObjectConstructor : global::Jint.Native.JsConstructor
	{
		// Token: 0x0600044F RID: 1103 RVA: 0x0002546C File Offset: 0x0002366C
		public JsObjectConstructor(global::Jint.Native.IGlobal global, global::Jint.Native.JsObject prototype, global::Jint.Native.JsObject rootPrototype) : base(global)
		{
			base.Name = "Object";
			base.DefineOwnProperty(global::Jint.Native.JsFunction.PROTOTYPE, rootPrototype, global::Jint.Native.PropertyAttributes.ReadOnly | global::Jint.Native.PropertyAttributes.DontEnum | global::Jint.Native.PropertyAttributes.DontDelete);
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x0002549C File Offset: 0x0002369C
		public override void InitPrototype(global::Jint.Native.IGlobal global)
		{
			global::Jint.Native.JsObject prototypeProperty = base.PrototypeProperty;
			prototypeProperty.DefineOwnProperty("constructor", this, global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("toString", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToStringImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("toLocaleString", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToStringImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("valueOf", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ValueOfImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("hasOwnProperty", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.HasOwnPropertyImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("isPrototypeOf", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.IsPrototypeOfImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("propertyIsEnumerable", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.PropertyIsEnumerableImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("getPrototypeOf", new global::Jint.Native.JsFunctionWrapper(new global::System.Func<global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.GetPrototypeOfImpl), global.FunctionClass.PrototypeProperty), global::Jint.Native.PropertyAttributes.DontEnum);
			if (global.HasOption(global::Jint.Options.Ecmascript5))
			{
				prototypeProperty.DefineOwnProperty("defineProperty", new global::Jint.Native.JsFunctionWrapper(new global::System.Func<global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.DefineProperty), global.FunctionClass.PrototypeProperty), global::Jint.Native.PropertyAttributes.DontEnum);
				prototypeProperty.DefineOwnProperty("__lookupGetter__", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.GetGetFunction)), global::Jint.Native.PropertyAttributes.DontEnum);
				prototypeProperty.DefineOwnProperty("__lookupSetter__", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.GetSetFunction)), global::Jint.Native.PropertyAttributes.DontEnum);
			}
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x00025638 File Offset: 0x00023838
		public global::Jint.Native.JsObject New(global::Jint.Native.JsFunction constructor)
		{
			global::Jint.Native.JsObject jsObject = new global::Jint.Native.JsObject(base.PrototypeProperty);
			jsObject.DefineOwnProperty(new global::Jint.Native.ValueDescriptor(jsObject, global::Jint.Native.JsFunction.CONSTRUCTOR, constructor)
			{
				Enumerable = false
			});
			return jsObject;
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x00025674 File Offset: 0x00023874
		public global::Jint.Native.JsObject New(global::Jint.Native.JsFunction constructor, global::Jint.Native.JsObject Prototype)
		{
			global::Jint.Native.JsObject jsObject = new global::Jint.Native.JsObject(Prototype);
			jsObject.DefineOwnProperty(new global::Jint.Native.ValueDescriptor(jsObject, global::Jint.Native.JsFunction.CONSTRUCTOR, constructor)
			{
				Enumerable = false
			});
			return jsObject;
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x000256A8 File Offset: 0x000238A8
		public global::Jint.Native.JsObject New(object value)
		{
			return new global::Jint.Native.JsObject(value, base.PrototypeProperty);
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x000256B8 File Offset: 0x000238B8
		public global::Jint.Native.JsObject New(object value, global::Jint.Native.JsObject prototype)
		{
			return new global::Jint.Native.JsObject(value, prototype);
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x000256C4 File Offset: 0x000238C4
		public global::Jint.Native.JsObject New()
		{
			return this.New(null);
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x000256D0 File Offset: 0x000238D0
		public global::Jint.Native.JsObject New(global::Jint.Native.JsObject prototype)
		{
			return new global::Jint.Native.JsObject(prototype);
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x000256D8 File Offset: 0x000238D8
		public override global::Jint.Native.JsInstance Execute(global::Jint.Expressions.IJintVisitor visitor, global::Jint.Native.JsDictionaryObject that, global::Jint.Native.JsInstance[] parameters)
		{
			if (parameters.Length > 0)
			{
				string @class;
				if ((@class = parameters[0].Class) != null)
				{
					if (@class == "String")
					{
						return base.Global.StringClass.New(parameters[0].ToString());
					}
					if (@class == "Number")
					{
						return base.Global.NumberClass.New(parameters[0].ToNumber());
					}
					if (@class == "Boolean")
					{
						return base.Global.BooleanClass.New(parameters[0].ToBoolean());
					}
				}
				return parameters[0];
			}
			return this.New(this);
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x000257A0 File Offset: 0x000239A0
		public global::Jint.Native.JsInstance ToStringImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			return base.Global.StringClass.New("[object " + target.Class + "]");
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x000257D8 File Offset: 0x000239D8
		public global::Jint.Native.JsInstance ValueOfImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			return target;
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x000257DC File Offset: 0x000239DC
		public global::Jint.Native.JsInstance HasOwnPropertyImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			return base.Global.BooleanClass.New(target.HasOwnProperty(parameters[0]));
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x0002580C File Offset: 0x00023A0C
		public global::Jint.Native.JsInstance IsPrototypeOfImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (target.Class != "Object")
			{
				return base.Global.BooleanClass.False;
			}
			for (;;)
			{
				base.IsPrototypeOf(target);
				if (target == null)
				{
					break;
				}
				if (target == this)
				{
					goto Block_3;
				}
			}
			return base.Global.BooleanClass.True;
			Block_3:
			return base.Global.BooleanClass.True;
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x00025878 File Offset: 0x00023A78
		public global::Jint.Native.JsInstance PropertyIsEnumerableImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (!this.HasOwnProperty(parameters[0]))
			{
				return base.Global.BooleanClass.False;
			}
			global::Jint.Native.JsInstance jsInstance = target[parameters[0]];
			return base.Global.BooleanClass.New((jsInstance.Attributes & global::Jint.Native.PropertyAttributes.DontEnum) == global::Jint.Native.PropertyAttributes.None);
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x000258D8 File Offset: 0x00023AD8
		public global::Jint.Native.JsInstance GetPrototypeOfImpl(global::Jint.Native.JsInstance[] parameters)
		{
			if (parameters[0].Class != "Object")
			{
				throw new global::Jint.Native.JsException(base.Global.TypeErrorClass.New());
			}
			return ((((parameters[0] as global::Jint.Native.JsObject) ?? global::Jint.Native.JsUndefined.Instance)[global::Jint.Native.JsFunction.CONSTRUCTOR] as global::Jint.Native.JsObject) ?? global::Jint.Native.JsUndefined.Instance)[global::Jint.Native.JsFunction.PROTOTYPE];
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x00025958 File Offset: 0x00023B58
		public global::Jint.Native.JsInstance DefineProperty(global::Jint.Native.JsInstance[] parameters)
		{
			global::Jint.Native.JsInstance jsInstance = parameters[0];
			if (!(jsInstance is global::Jint.Native.JsDictionaryObject))
			{
				throw new global::Jint.Native.JsException(base.Global.TypeErrorClass.New());
			}
			string name = parameters[1].ToString();
			global::Jint.Native.Descriptor currentDescriptor = global::Jint.Native.Descriptor.ToPropertyDesciptor(base.Global, (global::Jint.Native.JsDictionaryObject)jsInstance, name, parameters[2]);
			((global::Jint.Native.JsDictionaryObject)jsInstance).DefineOwnProperty(currentDescriptor);
			return jsInstance;
		}
	}
}
