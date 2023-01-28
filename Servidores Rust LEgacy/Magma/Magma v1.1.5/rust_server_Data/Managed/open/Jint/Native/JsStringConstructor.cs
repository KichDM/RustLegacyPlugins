using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Jint.Expressions;

namespace Jint.Native
{
	// Token: 0x02000055 RID: 85
	[global::System.Serializable]
	public class JsStringConstructor : global::Jint.Native.JsConstructor
	{
		// Token: 0x06000401 RID: 1025 RVA: 0x00022E3C File Offset: 0x0002103C
		public JsStringConstructor(global::Jint.Native.IGlobal global) : base(global)
		{
			base.DefineOwnProperty(global::Jint.Native.JsFunction.PROTOTYPE, global.ObjectClass.New(this), global::Jint.Native.PropertyAttributes.ReadOnly | global::Jint.Native.PropertyAttributes.DontEnum | global::Jint.Native.PropertyAttributes.DontDelete);
			base.Name = "String";
			this["fromCharCode"] = global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.FromCharCodeImpl));
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x00022E9C File Offset: 0x0002109C
		public override void InitPrototype(global::Jint.Native.IGlobal global)
		{
			global::Jint.Native.JsObject prototypeProperty = base.PrototypeProperty;
			prototypeProperty.DefineOwnProperty("split", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.SplitImpl), 2), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("replace", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ReplaceImpl), 2), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("toString", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToStringImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("toLocaleString", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToStringImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("match", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.MatchFunc)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("localeCompare", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.LocaleCompareImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("substring", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.SubstringImpl), 2), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("substr", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.SubstrImpl), 2), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("search", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.SearchImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("valueOf", global.FunctionClass.New<global::Jint.Native.JsString>(new global::System.Func<global::Jint.Native.JsString, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ValueOfImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("concat", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ConcatImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("charAt", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.CharAtImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("charCodeAt", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.CharCodeAtImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("lastIndexOf", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.LastIndexOfImpl), 1), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("indexOf", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.IndexOfImpl), 1), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("toLowerCase", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToLowerCaseImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("toLocaleLowerCase", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToLocaleLowerCaseImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("toUpperCase", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToUpperCaseImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("toLocaleUpperCase", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToLocaleUpperCaseImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("slice", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.SliceImpl), 2), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty(new global::Jint.Native.PropertyDescriptor<global::Jint.Native.JsDictionaryObject>(global, prototypeProperty, "length", new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance>(this.LengthImpl)));
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x00023198 File Offset: 0x00021398
		public global::Jint.Native.JsString New()
		{
			return this.New(string.Empty);
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x000231A8 File Offset: 0x000213A8
		public global::Jint.Native.JsString New(string value)
		{
			return new global::Jint.Native.JsString(value, base.PrototypeProperty);
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x000231B8 File Offset: 0x000213B8
		public override global::Jint.Native.JsInstance Execute(global::Jint.Expressions.IJintVisitor visitor, global::Jint.Native.JsDictionaryObject that, global::Jint.Native.JsInstance[] parameters)
		{
			if (that != null && that as global::Jint.Native.IGlobal != visitor.Global)
			{
				if (parameters.Length > 0)
				{
					that.Value = parameters[0].ToString();
				}
				else
				{
					that.Value = string.Empty;
				}
				return visitor.Return(that);
			}
			if (parameters.Length > 0)
			{
				return visitor.Return(base.Global.StringClass.New(parameters[0].ToString()));
			}
			return visitor.Return(base.Global.StringClass.New(string.Empty));
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x0002325C File Offset: 0x0002145C
		private static string EvaluateReplacePattern(string matched, string before, string after, string newString, global::System.Text.RegularExpressions.GroupCollection groups)
		{
			if (newString.Contains("$"))
			{
				global::System.Text.RegularExpressions.Regex regex = new global::System.Text.RegularExpressions.Regex("\\$\\$|\\$&|\\$`|\\$'|\\$\\d{1,2}", global::System.Text.RegularExpressions.RegexOptions.Compiled);
				return regex.Replace(newString, delegate(global::System.Text.RegularExpressions.Match m)
				{
					string value;
					if ((value = m.Value) != null)
					{
						if (value == "$$")
						{
							return "$";
						}
						if (value == "$&")
						{
							return matched;
						}
						if (value == "$`")
						{
							return before;
						}
						if (value == "$'")
						{
							return after;
						}
					}
					int num = int.Parse(m.Value.Substring(1));
					if (num != 0)
					{
						return groups[num].Value;
					}
					return m.Value;
				});
			}
			return newString;
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x000232D0 File Offset: 0x000214D0
		public global::Jint.Native.JsInstance ToStringImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			return base.Global.StringClass.New(target.ToString());
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x000232F8 File Offset: 0x000214F8
		public global::Jint.Native.JsInstance ValueOfImpl(global::Jint.Native.JsString target, global::Jint.Native.JsInstance[] parameters)
		{
			return base.Global.StringClass.New(target.ToString());
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x00023320 File Offset: 0x00021520
		public global::Jint.Native.JsInstance CharAtImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			return this.SubstringImpl(target, new global::Jint.Native.JsInstance[]
			{
				parameters[0],
				base.Global.NumberClass.New(parameters[0].ToNumber() + 1.0)
			});
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x0002337C File Offset: 0x0002157C
		public global::Jint.Native.JsInstance CharCodeAtImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			string text = target.ToString();
			int num = (int)parameters[0].ToNumber();
			if (text == string.Empty || num > text.Length - 1)
			{
				return base.Global.NaN;
			}
			return base.Global.NumberClass.New((double)global::System.Convert.ToInt32(text[num]));
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x000233EC File Offset: 0x000215EC
		public global::Jint.Native.JsInstance FromCharCodeImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			string text = string.Empty;
			foreach (global::Jint.Native.JsInstance jsInstance in parameters)
			{
				text += global::System.Convert.ToChar(global::System.Convert.ToUInt32(jsInstance.ToNumber()));
			}
			return base.Global.StringClass.New(text);
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x0002344C File Offset: 0x0002164C
		public global::Jint.Native.JsInstance ConcatImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			stringBuilder.Append(target.ToString());
			for (int i = 0; i < parameters.Length; i++)
			{
				stringBuilder.Append(parameters[i].ToString());
			}
			return base.Global.StringClass.New(stringBuilder.ToString());
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x000234AC File Offset: 0x000216AC
		public global::Jint.Native.JsInstance IndexOfImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			string text = target.ToString();
			string text2 = parameters[0].ToString();
			int num = (parameters.Length > 1) ? ((int)parameters[1].ToNumber()) : 0;
			if (text2 == string.Empty)
			{
				if (parameters.Length > 1)
				{
					return base.Global.NumberClass.New((double)global::System.Math.Min(text.Length, num));
				}
				return base.Global.NumberClass.New(0.0);
			}
			else
			{
				if (num >= text.Length)
				{
					return base.Global.NumberClass.New(-1.0);
				}
				return base.Global.NumberClass.New((double)text.IndexOf(text2, num));
			}
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x00023580 File Offset: 0x00021780
		public global::Jint.Native.JsInstance LastIndexOfImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			string text = target.ToString();
			string value = parameters[0].ToString();
			int length = (parameters.Length > 1) ? ((int)parameters[1].ToNumber()) : text.Length;
			return base.Global.NumberClass.New((double)text.Substring(0, length).LastIndexOf(value));
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x000235E8 File Offset: 0x000217E8
		public global::Jint.Native.JsInstance LocaleCompareImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			return base.Global.NumberClass.New((double)target.ToString().CompareTo(parameters[0].ToString()));
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x00023624 File Offset: 0x00021824
		public global::Jint.Native.JsInstance MatchFunc(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			global::Jint.Native.JsRegExp jsRegExp = (parameters[0].Class == "String") ? base.Global.RegExpClass.New(parameters[0].ToString(), false, false, false) : ((global::Jint.Native.JsRegExp)parameters[0]);
			if (!jsRegExp.IsGlobal)
			{
				return base.Global.RegExpClass.ExecImpl(jsRegExp, new global::Jint.Native.JsInstance[]
				{
					target
				});
			}
			global::Jint.Native.JsArray jsArray = base.Global.ArrayClass.New();
			global::System.Text.RegularExpressions.MatchCollection matchCollection = global::System.Text.RegularExpressions.Regex.Matches(target.ToString(), jsRegExp.Pattern, jsRegExp.Options);
			if (matchCollection.Count > 0)
			{
				int num = 0;
				foreach (object obj in matchCollection)
				{
					global::System.Text.RegularExpressions.Match match = (global::System.Text.RegularExpressions.Match)obj;
					jsArray[base.Global.NumberClass.New((double)num++)] = base.Global.StringClass.New(match.Value);
				}
				return jsArray;
			}
			return global::Jint.Native.JsNull.Instance;
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x00023770 File Offset: 0x00021970
		public global::Jint.Native.JsInstance ReplaceImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			global::Jint.Native.JsStringConstructor.<>c__DisplayClass6 CS$<>8__locals1 = new global::Jint.Native.JsStringConstructor.<>c__DisplayClass6();
			CS$<>8__locals1.<>4__this = this;
			if (parameters.Length == 0)
			{
				return base.Global.StringClass.New(target.ToString());
			}
			global::Jint.Native.JsInstance jsInstance = parameters[0];
			global::Jint.Native.JsInstance jsInstance2 = global::Jint.Native.JsUndefined.Instance;
			if (parameters.Length > 1)
			{
				jsInstance2 = parameters[1];
			}
			CS$<>8__locals1.source = target.ToString();
			CS$<>8__locals1.function = (jsInstance2 as global::Jint.Native.JsFunction);
			if (jsInstance.Class == "RegExp")
			{
				global::Jint.Native.JsStringConstructor.<>c__DisplayClass9 CS$<>8__locals2 = new global::Jint.Native.JsStringConstructor.<>c__DisplayClass9();
				CS$<>8__locals2.CS$<>8__locals7 = CS$<>8__locals1;
				int count = ((global::Jint.Native.JsRegExp)parameters[0]).IsGlobal ? int.MaxValue : 1;
				CS$<>8__locals2.regexp = (global::Jint.Native.JsRegExp)parameters[0];
				int startat = CS$<>8__locals2.regexp.IsGlobal ? 0 : global::System.Math.Max(0, (int)CS$<>8__locals2.regexp["lastIndex"].ToNumber() - 1);
				if (CS$<>8__locals2.regexp.IsGlobal)
				{
					CS$<>8__locals2.regexp["lastIndex"] = base.Global.NumberClass.New(0.0);
				}
				if (jsInstance2 is global::Jint.Native.JsFunction)
				{
					string value = ((global::Jint.Native.JsRegExp)parameters[0]).Regex.Replace(CS$<>8__locals1.source, delegate(global::System.Text.RegularExpressions.Match m)
					{
						global::System.Collections.Generic.List<global::Jint.Native.JsInstance> list2 = new global::System.Collections.Generic.List<global::Jint.Native.JsInstance>();
						if (!CS$<>8__locals2.regexp.IsGlobal)
						{
							CS$<>8__locals2.regexp["lastIndex"] = CS$<>8__locals2.CS$<>8__locals7.<>4__this.Global.NumberClass.New((double)(m.Index + 1));
						}
						list2.Add(CS$<>8__locals2.CS$<>8__locals7.<>4__this.Global.StringClass.New(m.Value));
						for (int i = 1; i < m.Groups.Count; i++)
						{
							if (m.Groups[i].Success)
							{
								list2.Add(CS$<>8__locals2.CS$<>8__locals7.<>4__this.Global.StringClass.New(m.Groups[i].Value));
							}
							else
							{
								list2.Add(global::Jint.Native.JsUndefined.Instance);
							}
						}
						list2.Add(CS$<>8__locals2.CS$<>8__locals7.<>4__this.Global.NumberClass.New((double)m.Index));
						list2.Add(CS$<>8__locals2.CS$<>8__locals7.<>4__this.Global.StringClass.New(CS$<>8__locals2.CS$<>8__locals7.source));
						CS$<>8__locals2.CS$<>8__locals7.<>4__this.Global.Visitor.ExecuteFunction(CS$<>8__locals2.CS$<>8__locals7.function, null, list2.ToArray());
						return CS$<>8__locals2.CS$<>8__locals7.<>4__this.Global.Visitor.Returned.ToString();
					}, count, startat);
					return base.Global.StringClass.New(value);
				}
				string str = parameters[1].ToString();
				string value2 = ((global::Jint.Native.JsRegExp)parameters[0]).Regex.Replace(target.ToString(), delegate(global::System.Text.RegularExpressions.Match m)
				{
					if (!CS$<>8__locals2.regexp.IsGlobal)
					{
						CS$<>8__locals2.regexp["lastIndex"] = CS$<>8__locals1.<>4__this.Global.NumberClass.New((double)(m.Index + 1));
					}
					string after = CS$<>8__locals1.source.Substring(global::System.Math.Min(CS$<>8__locals1.source.Length - 1, m.Index + m.Length));
					return global::Jint.Native.JsStringConstructor.EvaluateReplacePattern(m.Value, CS$<>8__locals1.source.Substring(0, m.Index), after, str, m.Groups);
				}, count, startat);
				return base.Global.StringClass.New(value2);
			}
			else
			{
				string text = jsInstance.ToString();
				int num = CS$<>8__locals1.source.IndexOf(text);
				if (num == -1)
				{
					return base.Global.StringClass.New(CS$<>8__locals1.source);
				}
				if (jsInstance2 is global::Jint.Native.JsFunction)
				{
					global::System.Collections.Generic.List<global::Jint.Native.JsInstance> list = new global::System.Collections.Generic.List<global::Jint.Native.JsInstance>();
					list.Add(base.Global.StringClass.New(text));
					list.Add(base.Global.NumberClass.New((double)num));
					list.Add(base.Global.StringClass.New(CS$<>8__locals1.source));
					base.Global.Visitor.ExecuteFunction(CS$<>8__locals1.function, null, list.ToArray());
					jsInstance2 = base.Global.Visitor.Result;
					return base.Global.StringClass.New(CS$<>8__locals1.source.Substring(0, num) + jsInstance2.ToString() + CS$<>8__locals1.source.Substring(num + text.Length));
				}
				string text2 = CS$<>8__locals1.source.Substring(0, num);
				string text3 = CS$<>8__locals1.source.Substring(num + text.Length);
				string str2 = global::Jint.Native.JsStringConstructor.EvaluateReplacePattern(text, text2, text3, jsInstance2.ToString(), null);
				return base.Global.StringClass.New(text2 + str2 + text3);
			}
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x00023AD4 File Offset: 0x00021CD4
		public global::Jint.Native.JsInstance SearchImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (parameters[0].Class == "String")
			{
				parameters[0] = base.Global.RegExpClass.New(parameters[0].ToString(), false, false, false);
			}
			global::System.Text.RegularExpressions.Match match = ((global::Jint.Native.JsRegExp)parameters[0]).Regex.Match(target.ToString());
			if (match != null && match.Success)
			{
				return base.Global.NumberClass.New((double)match.Index);
			}
			return base.Global.NumberClass.New(-1.0);
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x00023B88 File Offset: 0x00021D88
		public global::Jint.Native.JsInstance SliceImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			string text = target.ToString();
			int num = (int)parameters[0].ToNumber();
			int num2 = text.Length;
			if (parameters.Length > 1)
			{
				num2 = (int)parameters[1].ToNumber();
				if (num2 < 0)
				{
					num2 = text.Length + num2;
				}
			}
			if (num < 0)
			{
				num = text.Length + num;
			}
			return base.Global.StringClass.New(text.Substring(num, num2 - num));
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x00023C08 File Offset: 0x00021E08
		public global::Jint.Native.JsInstance SplitImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			global::Jint.Native.JsObject jsObject = base.Global.ArrayClass.New();
			string text = target.ToString();
			if (parameters.Length == 0 || parameters[0] == global::Jint.Native.JsUndefined.Instance)
			{
				jsObject["0"] = base.Global.StringClass.New(text);
			}
			global::Jint.Native.JsInstance jsInstance = parameters[0];
			int count = (parameters.Length > 1) ? global::System.Convert.ToInt32(parameters[1].ToNumber()) : int.MaxValue;
			int length = text.Length;
			string[] array;
			if (jsInstance.Class == "RegExp")
			{
				array = ((global::Jint.Native.JsRegExp)parameters[0]).Regex.Split(text, count);
			}
			else
			{
				array = text.Split(new string[]
				{
					jsInstance.ToString()
				}, count, global::System.StringSplitOptions.None);
			}
			for (int i = 0; i < array.Length; i++)
			{
				jsObject[i.ToString()] = base.Global.StringClass.New(array[i]);
			}
			return jsObject;
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x00023D30 File Offset: 0x00021F30
		public global::Jint.Native.JsInstance SubstringImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			string text = target.ToString();
			int num = 0;
			int num2 = text.Length;
			if (parameters.Length > 0 && !double.IsNaN(parameters[0].ToNumber()))
			{
				num = global::System.Convert.ToInt32(parameters[0].ToNumber());
			}
			if (parameters.Length > 1 && parameters[1] != global::Jint.Native.JsUndefined.Instance && !double.IsNaN(parameters[1].ToNumber()))
			{
				num2 = global::System.Convert.ToInt32(parameters[1].ToNumber());
			}
			num = global::System.Math.Min(global::System.Math.Max(num, 0), global::System.Math.Max(0, text.Length - 1));
			num2 = global::System.Math.Min(global::System.Math.Max(num2, 0), text.Length);
			text = text.Substring(num, num2 - num);
			return this.New(text);
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x00023E04 File Offset: 0x00022004
		public global::Jint.Native.JsInstance SubstrImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			string text = target.ToString();
			int num = 0;
			int num2 = text.Length;
			if (parameters.Length > 0 && !double.IsNaN(parameters[0].ToNumber()))
			{
				num = global::System.Convert.ToInt32(parameters[0].ToNumber());
			}
			if (parameters.Length > 1 && parameters[1] != global::Jint.Native.JsUndefined.Instance && !double.IsNaN(parameters[1].ToNumber()))
			{
				num2 = global::System.Convert.ToInt32(parameters[1].ToNumber());
			}
			num = global::System.Math.Min(global::System.Math.Max(num, 0), global::System.Math.Max(0, text.Length - 1));
			num2 = global::System.Math.Min(global::System.Math.Max(num2, 0), text.Length);
			text = text.Substring(num, num2);
			return this.New(text);
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x00023ED8 File Offset: 0x000220D8
		public global::Jint.Native.JsInstance ToLowerCaseImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			return base.Global.StringClass.New(target.ToString().ToLowerInvariant());
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x00023F04 File Offset: 0x00022104
		public global::Jint.Native.JsInstance ToLocaleLowerCaseImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			return base.Global.StringClass.New(target.ToString().ToLower());
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x00023F30 File Offset: 0x00022130
		public global::Jint.Native.JsInstance ToUpperCaseImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			return base.Global.StringClass.New(target.ToString().ToUpperInvariant());
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x00023F5C File Offset: 0x0002215C
		public global::Jint.Native.JsInstance ToLocaleUpperCaseImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			string text = target.ToString();
			return base.Global.StringClass.New(text.ToUpper());
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x00023F8C File Offset: 0x0002218C
		public global::Jint.Native.JsInstance LengthImpl(global::Jint.Native.JsDictionaryObject target)
		{
			string text = target.ToString();
			return base.Global.NumberClass.New((double)text.Length);
		}

		// Token: 0x0200014E RID: 334
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <>c__DisplayClass2
		{
			// Token: 0x06000BF5 RID: 3061 RVA: 0x0003C140 File Offset: 0x0003A340
			public <>c__DisplayClass2()
			{
			}

			// Token: 0x06000BF6 RID: 3062 RVA: 0x0003C148 File Offset: 0x0003A348
			public string <EvaluateReplacePattern>b__0(global::System.Text.RegularExpressions.Match m)
			{
				string value;
				if ((value = m.Value) != null)
				{
					if (value == "$$")
					{
						return "$";
					}
					if (value == "$&")
					{
						return this.matched;
					}
					if (value == "$`")
					{
						return this.before;
					}
					if (value == "$'")
					{
						return this.after;
					}
				}
				int num = int.Parse(m.Value.Substring(1));
				if (num != 0)
				{
					return this.groups[num].Value;
				}
				return m.Value;
			}

			// Token: 0x040006C6 RID: 1734
			public string matched;

			// Token: 0x040006C7 RID: 1735
			public string before;

			// Token: 0x040006C8 RID: 1736
			public string after;

			// Token: 0x040006C9 RID: 1737
			public global::System.Text.RegularExpressions.GroupCollection groups;
		}

		// Token: 0x0200014F RID: 335
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <>c__DisplayClass6
		{
			// Token: 0x06000BF7 RID: 3063 RVA: 0x0003C1F8 File Offset: 0x0003A3F8
			public <>c__DisplayClass6()
			{
			}

			// Token: 0x040006CA RID: 1738
			public string source;

			// Token: 0x040006CB RID: 1739
			public global::Jint.Native.JsFunction function;

			// Token: 0x040006CC RID: 1740
			public global::Jint.Native.JsStringConstructor <>4__this;
		}

		// Token: 0x02000150 RID: 336
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <>c__DisplayClass9
		{
			// Token: 0x06000BF8 RID: 3064 RVA: 0x0003C200 File Offset: 0x0003A400
			public <>c__DisplayClass9()
			{
			}

			// Token: 0x06000BF9 RID: 3065 RVA: 0x0003C208 File Offset: 0x0003A408
			public string <ReplaceImpl>b__4(global::System.Text.RegularExpressions.Match m)
			{
				global::System.Collections.Generic.List<global::Jint.Native.JsInstance> list = new global::System.Collections.Generic.List<global::Jint.Native.JsInstance>();
				if (!this.regexp.IsGlobal)
				{
					this.regexp["lastIndex"] = this.CS$<>8__locals7.<>4__this.Global.NumberClass.New((double)(m.Index + 1));
				}
				list.Add(this.CS$<>8__locals7.<>4__this.Global.StringClass.New(m.Value));
				for (int i = 1; i < m.Groups.Count; i++)
				{
					if (m.Groups[i].Success)
					{
						list.Add(this.CS$<>8__locals7.<>4__this.Global.StringClass.New(m.Groups[i].Value));
					}
					else
					{
						list.Add(global::Jint.Native.JsUndefined.Instance);
					}
				}
				list.Add(this.CS$<>8__locals7.<>4__this.Global.NumberClass.New((double)m.Index));
				list.Add(this.CS$<>8__locals7.<>4__this.Global.StringClass.New(this.CS$<>8__locals7.source));
				this.CS$<>8__locals7.<>4__this.Global.Visitor.ExecuteFunction(this.CS$<>8__locals7.function, null, list.ToArray());
				return this.CS$<>8__locals7.<>4__this.Global.Visitor.Returned.ToString();
			}

			// Token: 0x040006CD RID: 1741
			public global::Jint.Native.JsStringConstructor.<>c__DisplayClass6 CS$<>8__locals7;

			// Token: 0x040006CE RID: 1742
			public global::Jint.Native.JsRegExp regexp;
		}

		// Token: 0x02000151 RID: 337
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <>c__DisplayClassb
		{
			// Token: 0x06000BFA RID: 3066 RVA: 0x0003C398 File Offset: 0x0003A598
			public <>c__DisplayClassb()
			{
			}

			// Token: 0x06000BFB RID: 3067 RVA: 0x0003C3A0 File Offset: 0x0003A5A0
			public string <ReplaceImpl>b__5(global::System.Text.RegularExpressions.Match m)
			{
				if (!this.CS$<>8__localsa.regexp.IsGlobal)
				{
					this.CS$<>8__localsa.regexp["lastIndex"] = this.CS$<>8__locals7.<>4__this.Global.NumberClass.New((double)(m.Index + 1));
				}
				string after = this.CS$<>8__locals7.source.Substring(global::System.Math.Min(this.CS$<>8__locals7.source.Length - 1, m.Index + m.Length));
				return global::Jint.Native.JsStringConstructor.EvaluateReplacePattern(m.Value, this.CS$<>8__locals7.source.Substring(0, m.Index), after, this.str, m.Groups);
			}

			// Token: 0x040006CF RID: 1743
			public global::Jint.Native.JsStringConstructor.<>c__DisplayClass9 CS$<>8__localsa;

			// Token: 0x040006D0 RID: 1744
			public global::Jint.Native.JsStringConstructor.<>c__DisplayClass6 CS$<>8__locals7;

			// Token: 0x040006D1 RID: 1745
			public string str;
		}
	}
}
