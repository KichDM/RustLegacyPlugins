using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Jint.Expressions;
using Jint.Marshal;

namespace Jint.Native
{
	// Token: 0x02000052 RID: 82
	[global::System.Serializable]
	public class JsFunctionConstructor : global::Jint.Native.JsConstructor
	{
		// Token: 0x060003DE RID: 990 RVA: 0x00021DE8 File Offset: 0x0001FFE8
		public JsFunctionConstructor(global::Jint.Native.IGlobal global, global::Jint.Native.JsObject prototype) : base(global, prototype)
		{
			base.Name = "Function";
			base.DefineOwnProperty(global::Jint.Native.JsFunction.PROTOTYPE, prototype, global::Jint.Native.PropertyAttributes.ReadOnly | global::Jint.Native.PropertyAttributes.DontEnum | global::Jint.Native.PropertyAttributes.DontDelete);
		}

		// Token: 0x060003DF RID: 991 RVA: 0x00021E1C File Offset: 0x0002001C
		public override void InitPrototype(global::Jint.Native.IGlobal global)
		{
			global::Jint.Native.JsObject prototypeProperty = base.PrototypeProperty;
			prototypeProperty.DefineOwnProperty("constructor", this, global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty(global::Jint.Native.JsFunction.CALL.ToString(), new global::Jint.Native.JsCallFunction(this), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty(global::Jint.Native.JsFunction.APPLY.ToString(), new global::Jint.Native.JsApplyFunction(this), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("toString", this.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToString2)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("toLocaleString", this.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToString2)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty(new global::Jint.Native.PropertyDescriptor<global::Jint.Native.JsObject>(global, prototypeProperty, "length", new global::System.Func<global::Jint.Native.JsObject, global::Jint.Native.JsInstance>(this.GetLengthImpl), new global::System.Func<global::Jint.Native.JsObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.SetLengthImpl)));
			if (global.HasOption(global::Jint.Options.Ecmascript5))
			{
				prototypeProperty.DefineOwnProperty("bind", global.FunctionClass.New<global::Jint.Native.JsObject>(new global::System.Func<global::Jint.Native.JsObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.Bind), 1), global::Jint.Native.PropertyAttributes.DontEnum);
			}
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x00021F08 File Offset: 0x00020108
		public global::Jint.Native.JsInstance Bind(global::Jint.Native.JsObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (target.Class != "Function")
			{
				throw new global::Jint.Native.JsException(base.Global.ErrorClass.New("Function.prototype.bind - what is trying to be bound is not callable"));
			}
			global::Jint.Native.JsDictionaryObject thisArg = base.Global as global::Jint.Native.JsDictionaryObject;
			global::System.Collections.Generic.List<global::Jint.Native.JsInstance> parameterList = new global::System.Collections.Generic.List<global::Jint.Native.JsInstance>();
			if (parameters.Length != 0)
			{
				thisArg = (parameters[0] as global::Jint.Native.JsDictionaryObject);
				parameterList = new global::System.Collections.Generic.List<global::Jint.Native.JsInstance>(parameters);
				parameterList.RemoveAt(0);
			}
			return new global::Jint.Native.JsFunctionWrapper(delegate(global::Jint.Native.JsInstance[] arguments)
			{
				parameterList.AddRange(arguments);
				this.Global.Visitor.ExecuteFunction((global::Jint.Native.JsFunction)target, thisArg, parameterList.ToArray());
				return this.Global.Visitor.Returned;
			}, global::Jint.Native.JsUndefined.Instance);
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x00021FC8 File Offset: 0x000201C8
		public global::Jint.Native.JsInstance GetLengthImpl(global::Jint.Native.JsDictionaryObject target)
		{
			return base.Global.NumberClass.New((double)target.Length);
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x00021FF0 File Offset: 0x000201F0
		public global::Jint.Native.JsInstance SetLengthImpl(global::Jint.Native.JsInstance target, global::Jint.Native.JsInstance[] parameters)
		{
			int num = (int)parameters[0].ToNumber();
			if (num < 0 || double.IsNaN((double)num) || double.IsInfinity((double)num))
			{
				throw new global::Jint.Native.JsException(base.Global.RangeErrorClass.New("invalid length"));
			}
			global::Jint.Native.JsDictionaryObject jsDictionaryObject = (global::Jint.Native.JsDictionaryObject)target;
			jsDictionaryObject.Length = num;
			return parameters[0];
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x00022060 File Offset: 0x00020260
		public global::Jint.Native.JsInstance GetLength(global::Jint.Native.JsDictionaryObject target)
		{
			return base.Global.NumberClass.New((double)target.Length);
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x00022088 File Offset: 0x00020288
		public global::Jint.Native.JsFunction New()
		{
			global::Jint.Native.JsFunction jsFunction = new global::Jint.Native.JsFunction(base.PrototypeProperty);
			jsFunction.PrototypeProperty = base.Global.ObjectClass.New(jsFunction);
			return jsFunction;
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x000220C0 File Offset: 0x000202C0
		public global::Jint.Native.JsFunction New<T>(global::System.Func<T, global::Jint.Native.JsInstance> impl) where T : global::Jint.Native.JsInstance
		{
			global::Jint.Native.JsFunction jsFunction = new global::Jint.Native.ClrImplDefinition<T>(impl, base.PrototypeProperty);
			jsFunction.PrototypeProperty = base.Global.ObjectClass.New(jsFunction);
			return jsFunction;
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x000220F8 File Offset: 0x000202F8
		public global::Jint.Native.JsFunction New<T>(global::System.Func<T, global::Jint.Native.JsInstance> impl, int length) where T : global::Jint.Native.JsInstance
		{
			global::Jint.Native.JsFunction jsFunction = new global::Jint.Native.ClrImplDefinition<T>(impl, length, base.PrototypeProperty);
			jsFunction.PrototypeProperty = base.Global.ObjectClass.New(jsFunction);
			return jsFunction;
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x00022130 File Offset: 0x00020330
		public global::Jint.Native.JsFunction New<T>(global::System.Func<T, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance> impl) where T : global::Jint.Native.JsInstance
		{
			global::Jint.Native.JsFunction jsFunction = new global::Jint.Native.ClrImplDefinition<T>(impl, base.PrototypeProperty);
			jsFunction.PrototypeProperty = base.Global.ObjectClass.New(jsFunction);
			return jsFunction;
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x00022168 File Offset: 0x00020368
		public global::Jint.Native.JsFunction New<T>(global::System.Func<T, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance> impl, int length) where T : global::Jint.Native.JsInstance
		{
			global::Jint.Native.JsFunction jsFunction = new global::Jint.Native.ClrImplDefinition<T>(impl, length, base.PrototypeProperty);
			jsFunction.PrototypeProperty = base.Global.ObjectClass.New(jsFunction);
			return jsFunction;
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x000221A0 File Offset: 0x000203A0
		public global::Jint.Native.JsFunction New(global::System.Delegate d)
		{
			if (d == null)
			{
				throw new global::System.ArgumentNullException();
			}
			global::Jint.Marshal.JsMethodImpl impl = base.Global.Marshaller.WrapMethod(d.GetType().GetMethod("Invoke"), false);
			global::Jint.Native.JsObject wrapper = new global::Jint.Native.JsObject(d, global::Jint.Native.JsNull.Instance);
			global::Jint.Native.JsFunction jsFunction = this.New<global::Jint.Native.JsInstance>((global::Jint.Native.JsInstance that, global::Jint.Native.JsInstance[] args) => impl(this.Global, wrapper, args));
			jsFunction.PrototypeProperty = base.Global.ObjectClass.New(jsFunction);
			return jsFunction;
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00022230 File Offset: 0x00020430
		public override global::Jint.Native.JsInstance Execute(global::Jint.Expressions.IJintVisitor visitor, global::Jint.Native.JsDictionaryObject that, global::Jint.Native.JsInstance[] parameters)
		{
			return visitor.Return(this.Construct(parameters, null, visitor));
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x00022244 File Offset: 0x00020444
		public override global::Jint.Native.JsObject Construct(global::Jint.Native.JsInstance[] parameters, global::System.Type[] genericArgs, global::Jint.Expressions.IJintVisitor visitor)
		{
			global::Jint.Native.JsFunction jsFunction = this.New();
			jsFunction.Arguments = new global::System.Collections.Generic.List<string>();
			for (int i = 0; i < parameters.Length - 1; i++)
			{
				string text = parameters[i].ToString();
				foreach (string text2 in text.Split(new char[]
				{
					','
				}))
				{
					jsFunction.Arguments.Add(text2.Trim());
				}
			}
			if (parameters.Length >= 1)
			{
				global::Jint.Expressions.Program program = global::Jint.JintEngine.Compile(parameters[parameters.Length - 1].Value.ToString(), visitor.DebugMode);
				jsFunction.Statement = new global::Jint.Expressions.BlockStatement
				{
					Statements = program.Statements
				};
			}
			return jsFunction;
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x00022318 File Offset: 0x00020518
		public global::Jint.Native.JsInstance ToString2(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			return base.Global.StringClass.New(target.ToSource());
		}

		// Token: 0x0200014C RID: 332
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <>c__DisplayClass1
		{
			// Token: 0x06000BF1 RID: 3057 RVA: 0x0003C0AC File Offset: 0x0003A2AC
			public <>c__DisplayClass1()
			{
			}

			// Token: 0x06000BF2 RID: 3058 RVA: 0x0003C0B4 File Offset: 0x0003A2B4
			public global::Jint.Native.JsInstance <Bind>b__0(global::Jint.Native.JsInstance[] arguments)
			{
				this.parameterList.AddRange(arguments);
				this.<>4__this.Global.Visitor.ExecuteFunction((global::Jint.Native.JsFunction)this.target, this.thisArg, this.parameterList.ToArray());
				return this.<>4__this.Global.Visitor.Returned;
			}

			// Token: 0x040006BF RID: 1727
			public global::Jint.Native.JsDictionaryObject thisArg;

			// Token: 0x040006C0 RID: 1728
			public global::System.Collections.Generic.List<global::Jint.Native.JsInstance> parameterList;

			// Token: 0x040006C1 RID: 1729
			public global::Jint.Native.JsFunctionConstructor <>4__this;

			// Token: 0x040006C2 RID: 1730
			public global::Jint.Native.JsObject target;
		}

		// Token: 0x0200014D RID: 333
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <>c__DisplayClass4
		{
			// Token: 0x06000BF3 RID: 3059 RVA: 0x0003C118 File Offset: 0x0003A318
			public <>c__DisplayClass4()
			{
			}

			// Token: 0x06000BF4 RID: 3060 RVA: 0x0003C120 File Offset: 0x0003A320
			public global::Jint.Native.JsInstance <New>b__3(global::Jint.Native.JsInstance that, global::Jint.Native.JsInstance[] args)
			{
				return this.impl(this.<>4__this.Global, this.wrapper, args);
			}

			// Token: 0x040006C3 RID: 1731
			public global::Jint.Marshal.JsMethodImpl impl;

			// Token: 0x040006C4 RID: 1732
			public global::Jint.Native.JsObject wrapper;

			// Token: 0x040006C5 RID: 1733
			public global::Jint.Native.JsFunctionConstructor <>4__this;
		}
	}
}
