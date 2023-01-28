using System;
using System.Globalization;
using Jint.Expressions;

namespace Jint.Native
{
	// Token: 0x02000053 RID: 83
	[global::System.Serializable]
	public class JsNumberConstructor : global::Jint.Native.JsConstructor
	{
		// Token: 0x060003ED RID: 1005 RVA: 0x00022340 File Offset: 0x00020540
		public JsNumberConstructor(global::Jint.Native.IGlobal global) : base(global)
		{
			base.Name = "Number";
			base.DefineOwnProperty(global::Jint.Native.JsFunction.PROTOTYPE, global.ObjectClass.New(this), global::Jint.Native.PropertyAttributes.ReadOnly | global::Jint.Native.PropertyAttributes.DontEnum | global::Jint.Native.PropertyAttributes.DontDelete);
			this.DefineOwnProperty("MAX_VALUE", this.New(double.MaxValue));
			this.DefineOwnProperty("MIN_VALUE", this.New(double.MinValue));
			this.DefineOwnProperty("NaN", this.New(double.NaN));
			this.DefineOwnProperty("NEGATIVE_INFINITY", this.New(double.PositiveInfinity));
			this.DefineOwnProperty("POSITIVE_INFINITY", this.New(double.NegativeInfinity));
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x00022400 File Offset: 0x00020600
		public override void InitPrototype(global::Jint.Native.IGlobal global)
		{
			global::Jint.Native.JsObject prototypeProperty = base.PrototypeProperty;
			prototypeProperty.DefineOwnProperty("toString", global.FunctionClass.New<global::Jint.Native.JsInstance>(new global::System.Func<global::Jint.Native.JsInstance, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToStringImpl), 1), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("toLocaleString", global.FunctionClass.New<global::Jint.Native.JsInstance>(new global::System.Func<global::Jint.Native.JsInstance, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToLocaleStringImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("toFixed", global.FunctionClass.New<global::Jint.Native.JsInstance>(new global::System.Func<global::Jint.Native.JsInstance, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToFixedImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("toExponential", global.FunctionClass.New<global::Jint.Native.JsInstance>(new global::System.Func<global::Jint.Native.JsInstance, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToExponentialImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("toPrecision", global.FunctionClass.New<global::Jint.Native.JsInstance>(new global::System.Func<global::Jint.Native.JsInstance, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToPrecisionImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x000224C8 File Offset: 0x000206C8
		public global::Jint.Native.JsNumber New(double value)
		{
			return new global::Jint.Native.JsNumber(value, base.PrototypeProperty);
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x000224D8 File Offset: 0x000206D8
		public global::Jint.Native.JsNumber New()
		{
			return this.New(0.0);
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x000224EC File Offset: 0x000206EC
		public override global::Jint.Native.JsInstance Execute(global::Jint.Expressions.IJintVisitor visitor, global::Jint.Native.JsDictionaryObject that, global::Jint.Native.JsInstance[] parameters)
		{
			if (that != null && that as global::Jint.Native.IGlobal != visitor.Global)
			{
				if (parameters.Length > 0)
				{
					that.Value = parameters[0].ToNumber();
				}
				else
				{
					that.Value = 0;
				}
				return visitor.Return(that);
			}
			if (parameters.Length > 0)
			{
				return visitor.Return(this.New(parameters[0].ToNumber()));
			}
			return visitor.Return(this.New(0.0));
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x00022584 File Offset: 0x00020784
		public global::Jint.Native.JsInstance ToLocaleStringImpl(global::Jint.Native.JsInstance target, global::Jint.Native.JsInstance[] parameters)
		{
			return this.ToStringImpl(target, new global::Jint.Native.JsInstance[0]);
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x00022594 File Offset: 0x00020794
		public global::Jint.Native.JsInstance ToStringImpl(global::Jint.Native.JsInstance target, global::Jint.Native.JsInstance[] parameters)
		{
			if (target == this["NaN"])
			{
				return base.Global.StringClass.New("NaN");
			}
			if (target == this["NEGATIVE_INFINITY"])
			{
				return base.Global.StringClass.New("-Infinity");
			}
			if (target == this["POSITIVE_INFINITY"])
			{
				return base.Global.StringClass.New("Infinity");
			}
			int num = 0xA;
			if (parameters.Length > 0 && parameters[0] != global::Jint.Native.JsUndefined.Instance)
			{
				num = (int)parameters[0].ToNumber();
			}
			long num2 = (long)target.ToNumber();
			if (num == 0xA)
			{
				return base.Global.StringClass.New(target.ToNumber().ToString(global::System.Globalization.CultureInfo.InvariantCulture).ToLower());
			}
			long num3 = global::System.Math.Abs(num2);
			char[] array = new char[0x3F];
			int num4 = 0;
			while (num4 <= 0x40 && num3 != 0L)
			{
				array[array.Length - num4 - 1] = global::Jint.Native.JsNumberConstructor.rDigits[(int)(checked((global::System.IntPtr)(num3 % unchecked((long)num))))];
				num3 /= (long)num;
				num4++;
			}
			if (num2 < 0L)
			{
				array[array.Length - num4++ - 1] = '-';
			}
			return base.Global.StringClass.New(new string(array, array.Length - num4, num4).ToLower());
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x0002270C File Offset: 0x0002090C
		public global::Jint.Native.JsInstance ToFixedImpl(global::Jint.Native.JsInstance target, global::Jint.Native.JsInstance[] parameters)
		{
			int num = 0;
			if (parameters.Length > 0)
			{
				num = global::System.Convert.ToInt32(parameters[0].ToNumber());
			}
			if (num > 0x14 || num < 0)
			{
				throw new global::Jint.Native.JsException(base.Global.SyntaxErrorClass.New("Fraction Digits must be greater than 0 and lesser than 20"));
			}
			if (target == base.Global.NaN)
			{
				return base.Global.StringClass.New(target.ToString());
			}
			return base.Global.StringClass.New(target.ToNumber().ToString("f" + num, global::System.Globalization.CultureInfo.InvariantCulture));
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x000227C0 File Offset: 0x000209C0
		public global::Jint.Native.JsInstance ToExponentialImpl(global::Jint.Native.JsInstance target, global::Jint.Native.JsInstance[] parameters)
		{
			if (double.IsInfinity(target.ToNumber()) || double.IsNaN(target.ToNumber()))
			{
				return this.ToStringImpl(target, new global::Jint.Native.JsInstance[0]);
			}
			int num = 0x10;
			if (parameters.Length > 0)
			{
				num = global::System.Convert.ToInt32(parameters[0].ToNumber());
			}
			if (num > 0x14 || num < 0)
			{
				throw new global::Jint.Native.JsException(base.Global.SyntaxErrorClass.New("Fraction Digits must be greater than 0 and lesser than 20"));
			}
			string format = "#." + new string('0', num) + "e+0";
			return base.Global.StringClass.New(target.ToNumber().ToString(format, global::System.Globalization.CultureInfo.InvariantCulture));
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x00022884 File Offset: 0x00020A84
		public global::Jint.Native.JsInstance ToPrecisionImpl(global::Jint.Native.JsInstance target, global::Jint.Native.JsInstance[] parameters)
		{
			if (double.IsInfinity(target.ToNumber()) || double.IsNaN(target.ToNumber()))
			{
				return this.ToStringImpl(target, new global::Jint.Native.JsInstance[0]);
			}
			if (parameters.Length == 0)
			{
				throw new global::Jint.Native.JsException(base.Global.SyntaxErrorClass.New("precision missing"));
			}
			if (parameters[0] == global::Jint.Native.JsUndefined.Instance)
			{
				return this.ToStringImpl(target, new global::Jint.Native.JsInstance[0]);
			}
			int num = 0;
			if (parameters.Length > 0)
			{
				num = global::System.Convert.ToInt32(parameters[0].ToNumber());
			}
			if (num < 1 || num > 0x15)
			{
				throw new global::Jint.Native.JsException(base.Global.RangeErrorClass.New("precision must be between 1 and 21"));
			}
			string text = target.ToNumber().ToString("e23", global::System.Globalization.CultureInfo.InvariantCulture);
			int num2 = text.IndexOfAny(new char[]
			{
				'.',
				'e'
			});
			num2 = ((num2 == -1) ? text.Length : num2);
			num -= num2;
			num = ((num < 1) ? 1 : num);
			return base.Global.StringClass.New(target.ToNumber().ToString("f" + num, global::System.Globalization.CultureInfo.InvariantCulture));
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x000229E0 File Offset: 0x00020BE0
		// Note: this type is marked as 'beforefieldinit'.
		static JsNumberConstructor()
		{
		}

		// Token: 0x0400021D RID: 541
		private static char[] rDigits = new char[]
		{
			'0',
			'1',
			'2',
			'3',
			'4',
			'5',
			'6',
			'7',
			'8',
			'9',
			'A',
			'B',
			'C',
			'D',
			'E',
			'F',
			'G',
			'H',
			'I',
			'J',
			'K',
			'L',
			'M',
			'N',
			'O',
			'P',
			'Q',
			'R',
			'S',
			'T',
			'U',
			'V',
			'W',
			'X',
			'Y',
			'Z'
		};
	}
}
