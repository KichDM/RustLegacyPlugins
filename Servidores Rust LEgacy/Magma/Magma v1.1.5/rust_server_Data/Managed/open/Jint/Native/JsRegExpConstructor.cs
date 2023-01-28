using System;
using System.Text.RegularExpressions;
using Jint.Expressions;

namespace Jint.Native
{
	// Token: 0x02000054 RID: 84
	[global::System.Serializable]
	public class JsRegExpConstructor : global::Jint.Native.JsConstructor
	{
		// Token: 0x060003F8 RID: 1016 RVA: 0x000229FC File Offset: 0x00020BFC
		public JsRegExpConstructor(global::Jint.Native.IGlobal global) : base(global)
		{
			base.Name = "RegExp";
			base.DefineOwnProperty(global::Jint.Native.JsFunction.PROTOTYPE, global.ObjectClass.New(this), global::Jint.Native.PropertyAttributes.ReadOnly | global::Jint.Native.PropertyAttributes.DontEnum | global::Jint.Native.PropertyAttributes.DontDelete);
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x00022A38 File Offset: 0x00020C38
		public override void InitPrototype(global::Jint.Native.IGlobal global)
		{
			global::Jint.Native.JsObject prototypeProperty = base.PrototypeProperty;
			prototypeProperty.DefineOwnProperty("toString", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToStringImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("toLocaleString", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToStringImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("lastIndex", global.FunctionClass.New<global::Jint.Native.JsRegExp>(new global::System.Func<global::Jint.Native.JsRegExp, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.GetLastIndex)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("exec", global.FunctionClass.New<global::Jint.Native.JsRegExp>(new global::System.Func<global::Jint.Native.JsRegExp, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ExecImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("test", global.FunctionClass.New<global::Jint.Native.JsRegExp>(new global::System.Func<global::Jint.Native.JsRegExp, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.TestImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x00022B00 File Offset: 0x00020D00
		public global::Jint.Native.JsInstance GetLastIndex(global::Jint.Native.JsRegExp regex, global::Jint.Native.JsInstance[] parameters)
		{
			return regex["lastIndex"];
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x00022B10 File Offset: 0x00020D10
		public global::Jint.Native.JsRegExp New()
		{
			return this.New(string.Empty, false, false, false);
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x00022B20 File Offset: 0x00020D20
		public global::Jint.Native.JsRegExp New(string pattern, bool g, bool i, bool m)
		{
			global::Jint.Native.JsRegExp jsRegExp = new global::Jint.Native.JsRegExp(pattern, g, i, m, base.PrototypeProperty);
			jsRegExp["source"] = base.Global.StringClass.New(pattern);
			jsRegExp["lastIndex"] = base.Global.NumberClass.New(0.0);
			jsRegExp["global"] = base.Global.BooleanClass.New(g);
			return jsRegExp;
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x00022BA0 File Offset: 0x00020DA0
		public global::Jint.Native.JsInstance ExecImpl(global::Jint.Native.JsRegExp regexp, global::Jint.Native.JsInstance[] parameters)
		{
			global::Jint.Native.JsArray jsArray = base.Global.ArrayClass.New();
			string text = parameters[0].ToString();
			jsArray["input"] = base.Global.StringClass.New(text);
			int num = 0;
			double num2 = regexp.IsGlobal ? regexp["lastIndex"].ToNumber() : 0.0;
			global::System.Text.RegularExpressions.MatchCollection matchCollection = global::System.Text.RegularExpressions.Regex.Matches(text.Substring((int)num2), regexp.Pattern, regexp.Options);
			if (matchCollection.Count > 0)
			{
				jsArray["index"] = base.Global.NumberClass.New((double)matchCollection[0].Index);
				if (regexp.IsGlobal)
				{
					regexp["lastIndex"] = base.Global.NumberClass.New(num2 + (double)matchCollection[0].Index + (double)matchCollection[0].Value.Length);
				}
				foreach (object obj in matchCollection[0].Groups)
				{
					global::System.Text.RegularExpressions.Group group = (global::System.Text.RegularExpressions.Group)obj;
					jsArray[base.Global.NumberClass.New((double)num++)] = base.Global.StringClass.New(group.Value);
				}
				return jsArray;
			}
			return global::Jint.Native.JsNull.Instance;
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x00022D48 File Offset: 0x00020F48
		public global::Jint.Native.JsInstance TestImpl(global::Jint.Native.JsRegExp regex, global::Jint.Native.JsInstance[] parameters)
		{
			global::Jint.Native.JsArray jsArray = this.ExecImpl(regex, parameters) as global::Jint.Native.JsArray;
			return base.Global.BooleanClass.New(jsArray != null && jsArray.Length > 0);
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x00022D8C File Offset: 0x00020F8C
		public override global::Jint.Native.JsInstance Execute(global::Jint.Expressions.IJintVisitor visitor, global::Jint.Native.JsDictionaryObject that, global::Jint.Native.JsInstance[] parameters)
		{
			if (parameters.Length == 0)
			{
				return visitor.Return(this.New());
			}
			bool g = false;
			bool m = false;
			bool i = false;
			if (parameters.Length == 2)
			{
				string text = parameters[1].ToString();
				if (text != null)
				{
					m = text.Contains("m");
					i = text.Contains("i");
					g = text.Contains("g");
				}
			}
			return visitor.Return(this.New(parameters[0].ToString(), g, i, m));
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x00022E14 File Offset: 0x00021014
		public global::Jint.Native.JsInstance ToStringImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			return base.Global.StringClass.New(target.ToString());
		}
	}
}
