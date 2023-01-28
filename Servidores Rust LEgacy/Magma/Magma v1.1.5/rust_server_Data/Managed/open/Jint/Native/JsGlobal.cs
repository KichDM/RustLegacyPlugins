using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Jint.Expressions;

namespace Jint.Native
{
	// Token: 0x02000061 RID: 97
	[global::System.Serializable]
	public class JsGlobal : global::Jint.Native.JsObject, global::Jint.Native.IGlobal
	{
		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x060004B8 RID: 1208 RVA: 0x00026538 File Offset: 0x00024738
		// (set) Token: 0x060004B9 RID: 1209 RVA: 0x00026540 File Offset: 0x00024740
		public global::Jint.Expressions.IJintVisitor Visitor
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Visitor>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Visitor>k__BackingField = value;
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x060004BA RID: 1210 RVA: 0x0002654C File Offset: 0x0002474C
		// (set) Token: 0x060004BB RID: 1211 RVA: 0x00026554 File Offset: 0x00024754
		public global::Jint.Options Options
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Options>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Options>k__BackingField = value;
			}
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x00026560 File Offset: 0x00024760
		public JsGlobal(global::Jint.ExecutionVisitor visitor, global::Jint.Options options) : base(global::Jint.Native.JsNull.Instance)
		{
			this.Options = options;
			this.Visitor = visitor;
			this["null"] = global::Jint.Native.JsNull.Instance;
			global::Jint.Native.JsObject jsObject = new global::Jint.Native.JsObject(global::Jint.Native.JsNull.Instance);
			global::Jint.Native.JsFunction prototype = new global::Jint.Native.JsFunctionWrapper((global::Jint.Native.JsInstance[] arguments) => global::Jint.Native.JsUndefined.Instance, jsObject);
			this.Marshaller = new global::Jint.Marshaller(this);
			this["Function"] = (this.FunctionClass = new global::Jint.Native.JsFunctionConstructor(this, prototype));
			this["Object"] = (this.ObjectClass = new global::Jint.Native.JsObjectConstructor(this, prototype, jsObject));
			this.ObjectClass.InitPrototype(this);
			this["Array"] = (this.ArrayClass = new global::Jint.Native.JsArrayConstructor(this));
			this["Boolean"] = (this.BooleanClass = new global::Jint.Native.JsBooleanConstructor(this));
			this["Date"] = (this.DateClass = new global::Jint.Native.JsDateConstructor(this));
			this["Error"] = (this.ErrorClass = new global::Jint.Native.JsErrorConstructor(this, "Error"));
			this["EvalError"] = (this.EvalErrorClass = new global::Jint.Native.JsErrorConstructor(this, "EvalError"));
			this["RangeError"] = (this.RangeErrorClass = new global::Jint.Native.JsErrorConstructor(this, "RangeError"));
			this["ReferenceError"] = (this.ReferenceErrorClass = new global::Jint.Native.JsErrorConstructor(this, "ReferenceError"));
			this["SyntaxError"] = (this.SyntaxErrorClass = new global::Jint.Native.JsErrorConstructor(this, "SyntaxError"));
			this["TypeError"] = (this.TypeErrorClass = new global::Jint.Native.JsErrorConstructor(this, "TypeError"));
			this["URIError"] = (this.URIErrorClass = new global::Jint.Native.JsErrorConstructor(this, "URIError"));
			this["Number"] = (this.NumberClass = new global::Jint.Native.JsNumberConstructor(this));
			this["RegExp"] = (this.RegExpClass = new global::Jint.Native.JsRegExpConstructor(this));
			this["String"] = (this.StringClass = new global::Jint.Native.JsStringConstructor(this));
			this["Math"] = (this.MathClass = new global::Jint.Native.JsMathConstructor(this));
			foreach (global::Jint.Native.JsInstance jsInstance in this.GetValues())
			{
				if (jsInstance is global::Jint.Native.JsConstructor)
				{
					((global::Jint.Native.JsConstructor)jsInstance).InitPrototype(this);
				}
			}
			this["NaN"] = this.NumberClass["NaN"];
			this["Infinity"] = this.NumberClass["POSITIVE_INFINITY"];
			this["undefined"] = global::Jint.Native.JsUndefined.Instance;
			this[global::Jint.Native.JsScope.THIS] = this;
			this["eval"] = new global::Jint.Native.JsFunctionWrapper(new global::System.Func<global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.Eval), this.FunctionClass.PrototypeProperty);
			this["parseInt"] = new global::Jint.Native.JsFunctionWrapper(new global::System.Func<global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ParseInt), this.FunctionClass.PrototypeProperty);
			this["parseFloat"] = new global::Jint.Native.JsFunctionWrapper(new global::System.Func<global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ParseFloat), this.FunctionClass.PrototypeProperty);
			this["isNaN"] = new global::Jint.Native.JsFunctionWrapper(new global::System.Func<global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.IsNaN), this.FunctionClass.PrototypeProperty);
			this["isFinite"] = new global::Jint.Native.JsFunctionWrapper(new global::System.Func<global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.isFinite), this.FunctionClass.PrototypeProperty);
			this["decodeURI"] = new global::Jint.Native.JsFunctionWrapper(new global::System.Func<global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.DecodeURI), this.FunctionClass.PrototypeProperty);
			this["encodeURI"] = new global::Jint.Native.JsFunctionWrapper(new global::System.Func<global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.EncodeURI), this.FunctionClass.PrototypeProperty);
			this["decodeURIComponent"] = new global::Jint.Native.JsFunctionWrapper(new global::System.Func<global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.DecodeURIComponent), this.FunctionClass.PrototypeProperty);
			this["encodeURIComponent"] = new global::Jint.Native.JsFunctionWrapper(new global::System.Func<global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.EncodeURIComponent), this.FunctionClass.PrototypeProperty);
			this.Marshaller.InitTypes();
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x060004BD RID: 1213 RVA: 0x000269E0 File Offset: 0x00024BE0
		public override string Class
		{
			get
			{
				return "Global";
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x060004BE RID: 1214 RVA: 0x000269E8 File Offset: 0x00024BE8
		// (set) Token: 0x060004BF RID: 1215 RVA: 0x000269F0 File Offset: 0x00024BF0
		public global::Jint.Native.JsObjectConstructor ObjectClass
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<ObjectClass>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<ObjectClass>k__BackingField = value;
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x060004C0 RID: 1216 RVA: 0x000269FC File Offset: 0x00024BFC
		// (set) Token: 0x060004C1 RID: 1217 RVA: 0x00026A04 File Offset: 0x00024C04
		public global::Jint.Native.JsFunctionConstructor FunctionClass
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<FunctionClass>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<FunctionClass>k__BackingField = value;
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x060004C2 RID: 1218 RVA: 0x00026A10 File Offset: 0x00024C10
		// (set) Token: 0x060004C3 RID: 1219 RVA: 0x00026A18 File Offset: 0x00024C18
		public global::Jint.Native.JsArrayConstructor ArrayClass
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<ArrayClass>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<ArrayClass>k__BackingField = value;
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x060004C4 RID: 1220 RVA: 0x00026A24 File Offset: 0x00024C24
		// (set) Token: 0x060004C5 RID: 1221 RVA: 0x00026A2C File Offset: 0x00024C2C
		public global::Jint.Native.JsBooleanConstructor BooleanClass
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<BooleanClass>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<BooleanClass>k__BackingField = value;
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x060004C6 RID: 1222 RVA: 0x00026A38 File Offset: 0x00024C38
		// (set) Token: 0x060004C7 RID: 1223 RVA: 0x00026A40 File Offset: 0x00024C40
		public global::Jint.Native.JsDateConstructor DateClass
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<DateClass>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<DateClass>k__BackingField = value;
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x060004C8 RID: 1224 RVA: 0x00026A4C File Offset: 0x00024C4C
		// (set) Token: 0x060004C9 RID: 1225 RVA: 0x00026A54 File Offset: 0x00024C54
		public global::Jint.Native.JsErrorConstructor ErrorClass
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<ErrorClass>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<ErrorClass>k__BackingField = value;
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x060004CA RID: 1226 RVA: 0x00026A60 File Offset: 0x00024C60
		// (set) Token: 0x060004CB RID: 1227 RVA: 0x00026A68 File Offset: 0x00024C68
		public global::Jint.Native.JsErrorConstructor EvalErrorClass
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<EvalErrorClass>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<EvalErrorClass>k__BackingField = value;
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x060004CC RID: 1228 RVA: 0x00026A74 File Offset: 0x00024C74
		// (set) Token: 0x060004CD RID: 1229 RVA: 0x00026A7C File Offset: 0x00024C7C
		public global::Jint.Native.JsErrorConstructor RangeErrorClass
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<RangeErrorClass>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<RangeErrorClass>k__BackingField = value;
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x060004CE RID: 1230 RVA: 0x00026A88 File Offset: 0x00024C88
		// (set) Token: 0x060004CF RID: 1231 RVA: 0x00026A90 File Offset: 0x00024C90
		public global::Jint.Native.JsErrorConstructor ReferenceErrorClass
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<ReferenceErrorClass>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<ReferenceErrorClass>k__BackingField = value;
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x060004D0 RID: 1232 RVA: 0x00026A9C File Offset: 0x00024C9C
		// (set) Token: 0x060004D1 RID: 1233 RVA: 0x00026AA4 File Offset: 0x00024CA4
		public global::Jint.Native.JsErrorConstructor SyntaxErrorClass
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<SyntaxErrorClass>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<SyntaxErrorClass>k__BackingField = value;
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x060004D2 RID: 1234 RVA: 0x00026AB0 File Offset: 0x00024CB0
		// (set) Token: 0x060004D3 RID: 1235 RVA: 0x00026AB8 File Offset: 0x00024CB8
		public global::Jint.Native.JsErrorConstructor TypeErrorClass
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<TypeErrorClass>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<TypeErrorClass>k__BackingField = value;
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x060004D4 RID: 1236 RVA: 0x00026AC4 File Offset: 0x00024CC4
		// (set) Token: 0x060004D5 RID: 1237 RVA: 0x00026ACC File Offset: 0x00024CCC
		public global::Jint.Native.JsErrorConstructor URIErrorClass
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<URIErrorClass>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<URIErrorClass>k__BackingField = value;
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x060004D6 RID: 1238 RVA: 0x00026AD8 File Offset: 0x00024CD8
		// (set) Token: 0x060004D7 RID: 1239 RVA: 0x00026AE0 File Offset: 0x00024CE0
		public global::Jint.Native.JsMathConstructor MathClass
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<MathClass>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<MathClass>k__BackingField = value;
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x060004D8 RID: 1240 RVA: 0x00026AEC File Offset: 0x00024CEC
		// (set) Token: 0x060004D9 RID: 1241 RVA: 0x00026AF4 File Offset: 0x00024CF4
		public global::Jint.Native.JsNumberConstructor NumberClass
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<NumberClass>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<NumberClass>k__BackingField = value;
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x060004DA RID: 1242 RVA: 0x00026B00 File Offset: 0x00024D00
		// (set) Token: 0x060004DB RID: 1243 RVA: 0x00026B08 File Offset: 0x00024D08
		public global::Jint.Native.JsRegExpConstructor RegExpClass
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<RegExpClass>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<RegExpClass>k__BackingField = value;
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x060004DC RID: 1244 RVA: 0x00026B14 File Offset: 0x00024D14
		// (set) Token: 0x060004DD RID: 1245 RVA: 0x00026B1C File Offset: 0x00024D1C
		public global::Jint.Native.JsStringConstructor StringClass
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<StringClass>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<StringClass>k__BackingField = value;
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x060004DE RID: 1246 RVA: 0x00026B28 File Offset: 0x00024D28
		// (set) Token: 0x060004DF RID: 1247 RVA: 0x00026B30 File Offset: 0x00024D30
		public global::Jint.Marshaller Marshaller
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Marshaller>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<Marshaller>k__BackingField = value;
			}
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x00026B3C File Offset: 0x00024D3C
		public global::Jint.Native.JsInstance Eval(global::Jint.Native.JsInstance[] arguments)
		{
			if ("String" != arguments[0].Class)
			{
				return arguments[0];
			}
			global::Jint.Expressions.Program program;
			try
			{
				program = global::Jint.JintEngine.Compile(arguments[0].ToString(), this.Visitor.DebugMode);
			}
			catch (global::System.Exception ex)
			{
				throw new global::Jint.Native.JsException(this.SyntaxErrorClass.New(ex.Message));
			}
			try
			{
				program.Accept((global::Jint.Expressions.IStatementVisitor)this.Visitor);
			}
			catch (global::System.Exception ex2)
			{
				throw new global::Jint.Native.JsException(this.EvalErrorClass.New(ex2.Message));
			}
			return this.Visitor.Result;
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x00026BFC File Offset: 0x00024DFC
		public global::Jint.Native.JsInstance ParseInt(global::Jint.Native.JsInstance[] arguments)
		{
			if (arguments.Length < 1 || arguments[0] == global::Jint.Native.JsUndefined.Instance)
			{
				return global::Jint.Native.JsUndefined.Instance;
			}
			if (arguments[0].IsClr && arguments[0].Value.GetType().IsEnum)
			{
				return this.NumberClass.New((double)((int)arguments[0].Value));
			}
			string text = arguments[0].ToString().Trim();
			int num = 1;
			int num2 = 0xA;
			if (text == string.Empty)
			{
				return this["NaN"];
			}
			if (text.StartsWith("-"))
			{
				text = text.Substring(1);
				num = -1;
			}
			else if (text.StartsWith("+"))
			{
				text = text.Substring(1);
			}
			if (arguments.Length >= 2 && arguments[1] != global::Jint.Native.JsUndefined.Instance && !0.Equals(arguments[1]))
			{
				num2 = global::System.Convert.ToInt32(arguments[1].Value);
			}
			if (num2 == 0)
			{
				num2 = 0xA;
			}
			else if (num2 < 2 || num2 > 0x24)
			{
				return this["NaN"];
			}
			if (text.ToLower().StartsWith("0x"))
			{
				num2 = 0x10;
			}
			global::Jint.Native.JsInstance result;
			try
			{
				if (num2 == 0xA)
				{
					double d;
					if (double.TryParse(text, global::System.Globalization.NumberStyles.Any, global::System.Globalization.CultureInfo.InvariantCulture, out d))
					{
						result = this.NumberClass.New((double)num * global::System.Math.Floor(d));
					}
					else
					{
						result = this["NaN"];
					}
				}
				else
				{
					result = this.NumberClass.New((double)(num * global::System.Convert.ToInt32(text, num2)));
				}
			}
			catch
			{
				result = this["NaN"];
			}
			return result;
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x00026DF0 File Offset: 0x00024FF0
		public global::Jint.Native.JsInstance ParseFloat(global::Jint.Native.JsInstance[] arguments)
		{
			if (arguments.Length < 1 || arguments[0] == global::Jint.Native.JsUndefined.Instance)
			{
				return global::Jint.Native.JsUndefined.Instance;
			}
			string input = arguments[0].ToString().Trim();
			global::System.Text.RegularExpressions.Regex regex = new global::System.Text.RegularExpressions.Regex("^[\\+\\-\\d\\.e]*", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase);
			global::System.Text.RegularExpressions.Match match = regex.Match(input);
			double value;
			if (match.Success && double.TryParse(match.Value, global::System.Globalization.NumberStyles.Float, new global::System.Globalization.CultureInfo("en-US"), out value))
			{
				return this.NumberClass.New(value);
			}
			return this["NaN"];
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x00026E8C File Offset: 0x0002508C
		public global::Jint.Native.JsInstance IsNaN(global::Jint.Native.JsInstance[] arguments)
		{
			if (arguments.Length < 1)
			{
				return this.BooleanClass.New(false);
			}
			return this.BooleanClass.New(double.NaN.Equals(arguments[0].ToNumber()));
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x00026EDC File Offset: 0x000250DC
		protected global::Jint.Native.JsInstance isFinite(global::Jint.Native.JsInstance[] arguments)
		{
			if (arguments.Length < 1 || arguments[0] == global::Jint.Native.JsUndefined.Instance)
			{
				return this.BooleanClass.False;
			}
			global::Jint.Native.JsInstance jsInstance = arguments[0];
			return this.BooleanClass.New(jsInstance != this.NumberClass["NaN"] && jsInstance != this.NumberClass["POSITIVE_INFINITY"] && jsInstance != this.NumberClass["NEGATIVE_INFINITY"]);
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x00026F70 File Offset: 0x00025170
		protected global::Jint.Native.JsInstance DecodeURI(global::Jint.Native.JsInstance[] arguments)
		{
			if (arguments.Length < 1 || arguments[0] == global::Jint.Native.JsUndefined.Instance)
			{
				return this.StringClass.New();
			}
			return this.StringClass.New(global::System.Uri.UnescapeDataString(arguments[0].ToString().Replace("+", " ")));
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x00026FD4 File Offset: 0x000251D4
		protected global::Jint.Native.JsInstance EncodeURI(global::Jint.Native.JsInstance[] arguments)
		{
			if (arguments.Length < 1 || arguments[0] == global::Jint.Native.JsUndefined.Instance)
			{
				return this.StringClass.New();
			}
			string text = global::System.Uri.EscapeDataString(arguments[0].ToString());
			foreach (char c in global::Jint.Native.JsGlobal.reservedEncoded)
			{
				text = text.Replace(global::System.Uri.EscapeDataString(c.ToString()), c.ToString());
			}
			foreach (char c2 in global::Jint.Native.JsGlobal.reservedEncodedComponent)
			{
				text = text.Replace(global::System.Uri.EscapeDataString(c2.ToString()), c2.ToString());
			}
			return this.StringClass.New(text.ToUpper());
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x000270A4 File Offset: 0x000252A4
		protected global::Jint.Native.JsInstance DecodeURIComponent(global::Jint.Native.JsInstance[] arguments)
		{
			if (arguments.Length < 1 || arguments[0] == global::Jint.Native.JsUndefined.Instance)
			{
				return this.StringClass.New();
			}
			return this.StringClass.New(global::System.Uri.UnescapeDataString(arguments[0].ToString().Replace("+", " ")));
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x00027108 File Offset: 0x00025308
		protected global::Jint.Native.JsInstance EncodeURIComponent(global::Jint.Native.JsInstance[] arguments)
		{
			if (arguments.Length < 1 || arguments[0] == global::Jint.Native.JsUndefined.Instance)
			{
				return this.StringClass.New();
			}
			string text = global::System.Uri.EscapeDataString(arguments[0].ToString());
			foreach (char c in global::Jint.Native.JsGlobal.reservedEncodedComponent)
			{
				text = text.Replace(global::System.Uri.EscapeDataString(c.ToString()), c.ToString().ToUpper());
			}
			return this.StringClass.New(text);
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x00027198 File Offset: 0x00025398
		[global::System.Obsolete]
		public global::Jint.Native.JsObject Wrap(object value)
		{
			switch (global::System.Convert.GetTypeCode(value))
			{
			case global::System.TypeCode.Object:
				return this.ObjectClass.New(value);
			case global::System.TypeCode.Boolean:
				return this.BooleanClass.New((bool)value);
			case global::System.TypeCode.Char:
			case global::System.TypeCode.String:
				return this.StringClass.New(global::System.Convert.ToString(value));
			case global::System.TypeCode.SByte:
			case global::System.TypeCode.Byte:
			case global::System.TypeCode.Int16:
			case global::System.TypeCode.UInt16:
			case global::System.TypeCode.Int32:
			case global::System.TypeCode.UInt32:
			case global::System.TypeCode.Int64:
			case global::System.TypeCode.UInt64:
			case global::System.TypeCode.Single:
			case global::System.TypeCode.Double:
			case global::System.TypeCode.Decimal:
				return this.NumberClass.New(global::System.Convert.ToDouble(value));
			case global::System.TypeCode.DateTime:
				return this.DateClass.New((global::System.DateTime)value);
			}
			throw new global::System.ArgumentNullException("value");
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x00027268 File Offset: 0x00025468
		public global::Jint.Native.JsObject WrapClr(object value)
		{
			return (global::Jint.Native.JsObject)this.Marshaller.MarshalClrValue<object>(value);
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x0002727C File Offset: 0x0002547C
		public bool HasOption(global::Jint.Options options)
		{
			return (this.Options & options) == options;
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x060004EC RID: 1260 RVA: 0x0002728C File Offset: 0x0002548C
		public global::Jint.Native.JsInstance NaN
		{
			get
			{
				return this["NaN"];
			}
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x0002729C File Offset: 0x0002549C
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Jint.Native.JsInstance <.ctor>b__0(global::Jint.Native.JsInstance[] arguments)
		{
			return global::Jint.Native.JsUndefined.Instance;
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x000272A4 File Offset: 0x000254A4
		// Note: this type is marked as 'beforefieldinit'.
		static JsGlobal()
		{
		}

		// Token: 0x0400022B RID: 555
		private static char[] reservedEncoded = new char[]
		{
			';',
			',',
			'/',
			'?',
			':',
			'@',
			'&',
			'=',
			'+',
			'$',
			'#'
		};

		// Token: 0x0400022C RID: 556
		private static char[] reservedEncodedComponent = new char[]
		{
			'-',
			'_',
			'.',
			'!',
			'~',
			'*',
			'\'',
			'(',
			')',
			'[',
			']'
		};

		// Token: 0x0400022D RID: 557
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.IJintVisitor <Visitor>k__BackingField;

		// Token: 0x0400022E RID: 558
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Options <Options>k__BackingField;

		// Token: 0x0400022F RID: 559
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsObjectConstructor <ObjectClass>k__BackingField;

		// Token: 0x04000230 RID: 560
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsFunctionConstructor <FunctionClass>k__BackingField;

		// Token: 0x04000231 RID: 561
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsArrayConstructor <ArrayClass>k__BackingField;

		// Token: 0x04000232 RID: 562
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsBooleanConstructor <BooleanClass>k__BackingField;

		// Token: 0x04000233 RID: 563
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsDateConstructor <DateClass>k__BackingField;

		// Token: 0x04000234 RID: 564
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsErrorConstructor <ErrorClass>k__BackingField;

		// Token: 0x04000235 RID: 565
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsErrorConstructor <EvalErrorClass>k__BackingField;

		// Token: 0x04000236 RID: 566
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsErrorConstructor <RangeErrorClass>k__BackingField;

		// Token: 0x04000237 RID: 567
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsErrorConstructor <ReferenceErrorClass>k__BackingField;

		// Token: 0x04000238 RID: 568
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsErrorConstructor <SyntaxErrorClass>k__BackingField;

		// Token: 0x04000239 RID: 569
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsErrorConstructor <TypeErrorClass>k__BackingField;

		// Token: 0x0400023A RID: 570
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsErrorConstructor <URIErrorClass>k__BackingField;

		// Token: 0x0400023B RID: 571
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsMathConstructor <MathClass>k__BackingField;

		// Token: 0x0400023C RID: 572
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsNumberConstructor <NumberClass>k__BackingField;

		// Token: 0x0400023D RID: 573
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsRegExpConstructor <RegExpClass>k__BackingField;

		// Token: 0x0400023E RID: 574
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsStringConstructor <StringClass>k__BackingField;

		// Token: 0x0400023F RID: 575
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Marshaller <Marshaller>k__BackingField;

		// Token: 0x04000240 RID: 576
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance> CS$<>9__CachedAnonymousMethodDelegate1;
	}
}
