using System;
using System.Runtime.CompilerServices;

namespace Jint.Native
{
	// Token: 0x0200005D RID: 93
	[global::System.Serializable]
	public class JsMathConstructor : global::Jint.Native.JsObject
	{
		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000480 RID: 1152 RVA: 0x00025C18 File Offset: 0x00023E18
		// (set) Token: 0x06000481 RID: 1153 RVA: 0x00025C20 File Offset: 0x00023E20
		public global::Jint.Native.IGlobal Global
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Global>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Global>k__BackingField = value;
			}
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x00025C2C File Offset: 0x00023E2C
		public JsMathConstructor(global::Jint.Native.IGlobal global) : base(global.ObjectClass.PrototypeProperty)
		{
			this.Global = global;
			global::System.Random @object = new global::System.Random();
			this["abs"] = global.FunctionClass.New(new global::System.Func<double, global::Jint.Native.JsNumber>((double d) => this.Global.NumberClass.New(global::System.Math.Abs(d))));
			this["acos"] = global.FunctionClass.New(new global::System.Func<double, global::Jint.Native.JsNumber>((double d) => this.Global.NumberClass.New(global::System.Math.Acos(d))));
			this["asin"] = global.FunctionClass.New(new global::System.Func<double, global::Jint.Native.JsNumber>((double d) => this.Global.NumberClass.New(global::System.Math.Asin(d))));
			this["atan"] = global.FunctionClass.New(new global::System.Func<double, global::Jint.Native.JsNumber>((double d) => this.Global.NumberClass.New(global::System.Math.Atan(d))));
			this["atan2"] = global.FunctionClass.New(new global::System.Func<double, double, global::Jint.Native.JsNumber>((double y, double x) => this.Global.NumberClass.New(global::System.Math.Atan2(y, x))));
			this["ceil"] = global.FunctionClass.New(new global::System.Func<double, global::Jint.Native.JsNumber>((double d) => this.Global.NumberClass.New(global::System.Math.Ceiling(d))));
			this["cos"] = global.FunctionClass.New(new global::System.Func<double, global::Jint.Native.JsNumber>((double d) => this.Global.NumberClass.New(global::System.Math.Cos(d))));
			this["exp"] = global.FunctionClass.New(new global::System.Func<double, global::Jint.Native.JsNumber>((double d) => this.Global.NumberClass.New(global::System.Math.Exp(d))));
			this["floor"] = global.FunctionClass.New(new global::System.Func<double, global::Jint.Native.JsNumber>((double d) => this.Global.NumberClass.New(global::System.Math.Floor(d))));
			this["log"] = global.FunctionClass.New(new global::System.Func<double, global::Jint.Native.JsNumber>((double d) => this.Global.NumberClass.New(global::System.Math.Log(d))));
			this["max"] = global.FunctionClass.New<global::Jint.Native.JsObject>(new global::System.Func<global::Jint.Native.JsObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.MaxImpl));
			this["min"] = global.FunctionClass.New<global::Jint.Native.JsObject>(new global::System.Func<global::Jint.Native.JsObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.MinImpl));
			this["pow"] = global.FunctionClass.New(new global::System.Func<double, double, global::Jint.Native.JsNumber>((double a, double b) => this.Global.NumberClass.New(global::System.Math.Pow(a, b))));
			this["random"] = global.FunctionClass.New(new global::System.Func<double>(@object.NextDouble));
			this["round"] = global.FunctionClass.New(new global::System.Func<double, global::Jint.Native.JsNumber>((double d) => this.Global.NumberClass.New(global::System.Math.Round(d))));
			this["sin"] = global.FunctionClass.New(new global::System.Func<double, global::Jint.Native.JsNumber>((double d) => this.Global.NumberClass.New(global::System.Math.Sin(d))));
			this["sqrt"] = global.FunctionClass.New(new global::System.Func<double, global::Jint.Native.JsNumber>((double d) => this.Global.NumberClass.New(global::System.Math.Sqrt(d))));
			this["tan"] = global.FunctionClass.New(new global::System.Func<double, global::Jint.Native.JsNumber>((double d) => this.Global.NumberClass.New(global::System.Math.Tan(d))));
			this["E"] = global.NumberClass.New(2.718281828459045);
			this["LN2"] = global.NumberClass.New(global::System.Math.Log(2.0));
			this["LN10"] = global.NumberClass.New(global::System.Math.Log(10.0));
			this["LOG2E"] = global.NumberClass.New(global::System.Math.Log(2.718281828459045, 2.0));
			this["PI"] = global.NumberClass.New(3.141592653589793);
			this["SQRT1_2"] = global.NumberClass.New(global::System.Math.Sqrt(0.5));
			this["SQRT2"] = global.NumberClass.New(global::System.Math.Sqrt(2.0));
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000483 RID: 1155 RVA: 0x00026080 File Offset: 0x00024280
		public override string Class
		{
			get
			{
				return "object";
			}
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x00026088 File Offset: 0x00024288
		public global::Jint.Native.JsInstance MaxImpl(global::Jint.Native.JsObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (parameters.Length == 0)
			{
				return this.Global.NumberClass["NEGATIVE_INFINITY"];
			}
			double num = parameters[0].ToNumber();
			foreach (global::Jint.Native.JsInstance jsInstance in parameters)
			{
				num = global::System.Math.Max(jsInstance.ToNumber(), num);
			}
			return this.Global.NumberClass.New(num);
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x00026100 File Offset: 0x00024300
		public global::Jint.Native.JsInstance MinImpl(global::Jint.Native.JsObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (parameters.Length == 0)
			{
				return this.Global.NumberClass["POSITIVE_INFINITY"];
			}
			double num = parameters[0].ToNumber();
			foreach (global::Jint.Native.JsInstance jsInstance in parameters)
			{
				num = global::System.Math.Min(jsInstance.ToNumber(), num);
			}
			return this.Global.NumberClass.New(num);
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x00026178 File Offset: 0x00024378
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsNumber <.ctor>b__0(double d)
		{
			return this.Global.NumberClass.New(global::System.Math.Abs(d));
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x00026190 File Offset: 0x00024390
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsNumber <.ctor>b__1(double d)
		{
			return this.Global.NumberClass.New(global::System.Math.Acos(d));
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x000261A8 File Offset: 0x000243A8
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsNumber <.ctor>b__2(double d)
		{
			return this.Global.NumberClass.New(global::System.Math.Asin(d));
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x000261C0 File Offset: 0x000243C0
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsNumber <.ctor>b__3(double d)
		{
			return this.Global.NumberClass.New(global::System.Math.Atan(d));
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x000261D8 File Offset: 0x000243D8
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsNumber <.ctor>b__4(double y, double x)
		{
			return this.Global.NumberClass.New(global::System.Math.Atan2(y, x));
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x000261F4 File Offset: 0x000243F4
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsNumber <.ctor>b__5(double d)
		{
			return this.Global.NumberClass.New(global::System.Math.Ceiling(d));
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x0002620C File Offset: 0x0002440C
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsNumber <.ctor>b__6(double d)
		{
			return this.Global.NumberClass.New(global::System.Math.Cos(d));
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x00026224 File Offset: 0x00024424
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsNumber <.ctor>b__7(double d)
		{
			return this.Global.NumberClass.New(global::System.Math.Exp(d));
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x0002623C File Offset: 0x0002443C
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsNumber <.ctor>b__8(double d)
		{
			return this.Global.NumberClass.New(global::System.Math.Floor(d));
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x00026254 File Offset: 0x00024454
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsNumber <.ctor>b__9(double d)
		{
			return this.Global.NumberClass.New(global::System.Math.Log(d));
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x0002626C File Offset: 0x0002446C
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsNumber <.ctor>b__a(double a, double b)
		{
			return this.Global.NumberClass.New(global::System.Math.Pow(a, b));
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x00026288 File Offset: 0x00024488
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsNumber <.ctor>b__b(double d)
		{
			return this.Global.NumberClass.New(global::System.Math.Round(d));
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x000262A0 File Offset: 0x000244A0
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsNumber <.ctor>b__c(double d)
		{
			return this.Global.NumberClass.New(global::System.Math.Sin(d));
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x000262B8 File Offset: 0x000244B8
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsNumber <.ctor>b__d(double d)
		{
			return this.Global.NumberClass.New(global::System.Math.Sqrt(d));
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x000262D0 File Offset: 0x000244D0
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsNumber <.ctor>b__e(double d)
		{
			return this.Global.NumberClass.New(global::System.Math.Tan(d));
		}

		// Token: 0x04000226 RID: 550
		public const string MathType = "object";

		// Token: 0x04000227 RID: 551
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.IGlobal <Global>k__BackingField;
	}
}
