using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using Jint.Expressions;

namespace Jint.Native
{
	// Token: 0x02000051 RID: 81
	[global::System.Serializable]
	public class JsDateConstructor : global::Jint.Native.JsConstructor
	{
		// Token: 0x060003A5 RID: 933 RVA: 0x0001FFB4 File Offset: 0x0001E1B4
		protected JsDateConstructor(global::Jint.Native.IGlobal global, bool initializeUTC) : base(global)
		{
			base.Name = "Date";
			base.DefineOwnProperty(global::Jint.Native.JsFunction.PROTOTYPE, global.ObjectClass.New(this), global::Jint.Native.PropertyAttributes.ReadOnly | global::Jint.Native.PropertyAttributes.DontEnum | global::Jint.Native.PropertyAttributes.DontDelete);
			base.DefineOwnProperty("now", new global::Jint.Native.ClrFunction(new global::System.Func<global::Jint.Native.JsDate>(() => base.Global.DateClass.New(global::System.DateTime.Now)), global.FunctionClass.PrototypeProperty), global::Jint.Native.PropertyAttributes.DontEnum);
			base.DefineOwnProperty("parse", new global::Jint.Native.JsFunctionWrapper(new global::System.Func<global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ParseImpl), global.FunctionClass.PrototypeProperty), global::Jint.Native.PropertyAttributes.DontEnum);
			base.DefineOwnProperty("parseLocale", new global::Jint.Native.JsFunctionWrapper(new global::System.Func<global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ParseLocaleImpl), global.FunctionClass.PrototypeProperty), global::Jint.Native.PropertyAttributes.DontEnum);
			base.DefineOwnProperty("UTC", new global::Jint.Native.JsFunctionWrapper(new global::System.Func<global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.UTCImpl), global.FunctionClass.PrototypeProperty), global::Jint.Native.PropertyAttributes.DontEnum);
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x0002009C File Offset: 0x0001E29C
		public override void InitPrototype(global::Jint.Native.IGlobal global)
		{
			global::Jint.Native.JsObject prototypeProperty = base.PrototypeProperty;
			prototypeProperty.DefineOwnProperty("UTC", new global::Jint.Native.JsFunctionWrapper(new global::System.Func<global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.UTCImpl), global.FunctionClass.PrototypeProperty), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("now", new global::Jint.Native.ClrFunction(new global::System.Func<global::Jint.Native.JsDate>(() => base.Global.DateClass.New(global::System.DateTime.Now)), global.FunctionClass.PrototypeProperty), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("parse", new global::Jint.Native.JsFunctionWrapper(new global::System.Func<global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ParseImpl), global.FunctionClass.PrototypeProperty), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("parseLocale", new global::Jint.Native.JsFunctionWrapper(new global::System.Func<global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ParseLocaleImpl), global.FunctionClass.PrototypeProperty), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("toString", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToStringImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("toDateString", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToDateStringImpl), 0), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("toTimeString", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToTimeStringImpl), 0), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("toLocaleString", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToLocaleStringImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("toLocaleDateString", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToLocaleDateStringImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("toLocaleTimeString", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToLocaleTimeStringImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("valueOf", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ValueOfImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("getTime", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.GetTimeImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("getFullYear", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.GetFullYearImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("getUTCFullYear", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.GetUTCFullYearImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("getMonth", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.GetMonthImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("getUTCMonth", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.GetUTCMonthImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("getDate", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.GetDateImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("getUTCDate", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.GetUTCDateImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("getDay", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.GetDayImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("getUTCDay", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.GetUTCDayImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("getHours", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.GetHoursImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("getUTCHours", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.GetUTCHoursImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("getMinutes", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.GetMinutesImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("getUTCMinutes", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.GetUTCMinutesImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("getSeconds", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.GetSecondsImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("getUTCSeconds", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.GetUTCSecondsImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("getMilliseconds", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.GetMillisecondsImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("getUTCMilliseconds", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.GetUTCMillisecondsImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("getTimezoneOffset", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.GetTimezoneOffsetImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("setTime", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.SetTimeImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("setMilliseconds", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.SetMillisecondsImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("setUTCMilliseconds", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.SetUTCMillisecondsImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("setSeconds", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.SetSecondsImpl), 2), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("setUTCSeconds", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.SetUTCSecondsImpl), 2), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("setMinutes", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.SetMinutesImpl), 3), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("setUTCMinutes", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.SetUTCMinutesImpl), 3), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("setHours", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.SetHoursImpl), 4), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("setUTCHours", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.SetUTCHoursImpl), 4), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("setDate", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.SetDateImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("setUTCDate", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.SetUTCDateImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("setMonth", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.SetMonthImpl), 2), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("setUTCMonth", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.SetUTCMonthImpl), 2), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("setFullYear", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.SetFullYearImpl), 3), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("setUTCFullYear", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.SetUTCFullYearImpl), 3), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("toUTCString", global.FunctionClass.New<global::Jint.Native.JsDictionaryObject>(new global::System.Func<global::Jint.Native.JsDictionaryObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToUTCStringImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x000206FC File Offset: 0x0001E8FC
		public JsDateConstructor(global::Jint.Native.IGlobal global) : this(global, true)
		{
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x00020708 File Offset: 0x0001E908
		public global::Jint.Native.JsDate New()
		{
			return new global::Jint.Native.JsDate(base.PrototypeProperty);
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x00020718 File Offset: 0x0001E918
		public global::Jint.Native.JsDate New(double value)
		{
			return new global::Jint.Native.JsDate(value, base.PrototypeProperty);
		}

		// Token: 0x060003AA RID: 938 RVA: 0x00020728 File Offset: 0x0001E928
		public global::Jint.Native.JsDate New(global::System.DateTime value)
		{
			return new global::Jint.Native.JsDate(value, base.PrototypeProperty);
		}

		// Token: 0x060003AB RID: 939 RVA: 0x00020738 File Offset: 0x0001E938
		public global::Jint.Native.JsDate New(global::System.DateTime value, global::Jint.Native.JsObject prototype)
		{
			return new global::Jint.Native.JsDate(value, prototype);
		}

		// Token: 0x060003AC RID: 940 RVA: 0x00020744 File Offset: 0x0001E944
		public global::Jint.Native.JsDate Construct(global::Jint.Native.JsInstance[] parameters)
		{
			global::Jint.Native.JsDate result;
			if (parameters.Length == 1)
			{
				double value;
				if ((parameters[0].Class == "Number" || parameters[0].Class == "Object") && double.IsNaN(parameters[0].ToNumber()))
				{
					result = this.New(double.NaN);
				}
				else if (parameters[0].Class == "Number")
				{
					result = this.New(parameters[0].ToNumber());
				}
				else if (this.ParseDate(parameters[0].ToString(), global::System.Globalization.CultureInfo.InvariantCulture, out value))
				{
					result = this.New(value);
				}
				else if (this.ParseDate(parameters[0].ToString(), global::System.Globalization.CultureInfo.CurrentCulture, out value))
				{
					result = this.New(value);
				}
				else
				{
					result = this.New(0.0);
				}
			}
			else if (parameters.Length > 1)
			{
				global::System.DateTime value2 = new global::System.DateTime(0L, global::System.DateTimeKind.Local);
				if (parameters.Length > 0)
				{
					int num = (int)parameters[0].ToNumber() - 1;
					if (num < 0x64)
					{
						num += 0x76C;
					}
					value2 = value2.AddYears(num);
				}
				if (parameters.Length > 1)
				{
					value2 = value2.AddMonths((int)parameters[1].ToNumber());
				}
				if (parameters.Length > 2)
				{
					value2 = value2.AddDays((double)((int)parameters[2].ToNumber() - 1));
				}
				if (parameters.Length > 3)
				{
					value2 = value2.AddHours((double)((int)parameters[3].ToNumber()));
				}
				if (parameters.Length > 4)
				{
					value2 = value2.AddMinutes((double)((int)parameters[4].ToNumber()));
				}
				if (parameters.Length > 5)
				{
					value2 = value2.AddSeconds((double)((int)parameters[5].ToNumber()));
				}
				if (parameters.Length > 6)
				{
					value2 = value2.AddMilliseconds((double)((int)parameters[6].ToNumber()));
				}
				result = this.New(value2);
			}
			else
			{
				result = this.New(global::System.DateTime.UtcNow);
			}
			return result;
		}

		// Token: 0x060003AD RID: 941 RVA: 0x0002097C File Offset: 0x0001EB7C
		public override global::Jint.Native.JsInstance Execute(global::Jint.Expressions.IJintVisitor visitor, global::Jint.Native.JsDictionaryObject that, global::Jint.Native.JsInstance[] parameters)
		{
			global::Jint.Native.JsDate jsDate = this.Construct(parameters);
			if (that == null || that as global::Jint.Native.IGlobal == visitor.Global)
			{
				return visitor.Return(this.ToStringImpl(jsDate, global::Jint.Native.JsInstance.EMPTY));
			}
			return jsDate;
		}

		// Token: 0x060003AE RID: 942 RVA: 0x000209C0 File Offset: 0x0001EBC0
		private bool ParseDate(string p, global::System.IFormatProvider culture, out double result)
		{
			global::System.DateTime value = new global::System.DateTime(0L, global::System.DateTimeKind.Utc);
			result = 0.0;
			if (global::System.DateTime.TryParse(p, culture, global::System.Globalization.DateTimeStyles.None, out value))
			{
				result = this.New(value).ToNumber();
				return true;
			}
			if (global::System.DateTime.TryParseExact(p, global::Jint.Native.JsDate.FORMAT, culture, global::System.Globalization.DateTimeStyles.None, out value))
			{
				result = this.New(value).ToNumber();
				return true;
			}
			global::System.DateTime dateTime;
			if (global::System.DateTime.TryParseExact(p, global::Jint.Native.JsDate.DATEFORMAT, culture, global::System.Globalization.DateTimeStyles.None, out dateTime))
			{
				value = value.AddTicks(dateTime.Ticks);
			}
			if (global::System.DateTime.TryParseExact(p, global::Jint.Native.JsDate.TIMEFORMAT, culture, global::System.Globalization.DateTimeStyles.None, out dateTime))
			{
				value = value.AddTicks(dateTime.Ticks);
			}
			if (value.Ticks > 0L)
			{
				result = this.New(value).ToNumber();
				return true;
			}
			return true;
		}

		// Token: 0x060003AF RID: 943 RVA: 0x00020A94 File Offset: 0x0001EC94
		public global::Jint.Native.JsInstance ParseImpl(global::Jint.Native.JsInstance[] parameters)
		{
			double value;
			if (this.ParseDate(parameters[0].ToString(), global::System.Globalization.CultureInfo.InvariantCulture, out value))
			{
				return base.Global.NumberClass.New(value);
			}
			return base.Global.NaN;
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x00020AE0 File Offset: 0x0001ECE0
		public global::Jint.Native.JsInstance ParseLocaleImpl(global::Jint.Native.JsInstance[] parameters)
		{
			double value;
			if (this.ParseDate(parameters[0].ToString(), global::System.Globalization.CultureInfo.CurrentCulture, out value))
			{
				return base.Global.NumberClass.New(value);
			}
			return base.Global.NaN;
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x00020B2C File Offset: 0x0001ED2C
		internal static global::System.DateTime CreateDateTime(double number)
		{
			return new global::System.DateTime((long)(number * (double)global::Jint.Native.JsDate.TICKSFACTOR + (double)global::Jint.Native.JsDate.OFFSET_1970), global::System.DateTimeKind.Utc);
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x00020B44 File Offset: 0x0001ED44
		public global::Jint.Native.JsInstance ToStringImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (double.IsNaN(target.ToNumber()))
			{
				return base.Global.StringClass.New(double.NaN.ToString());
			}
			return base.Global.StringClass.New(global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToLocalTime().ToString(global::Jint.Native.JsDate.FORMAT, global::System.Globalization.CultureInfo.InvariantCulture));
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x00020BBC File Offset: 0x0001EDBC
		public global::Jint.Native.JsInstance ToLocaleStringImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (double.IsNaN(target.ToNumber()))
			{
				return base.Global.StringClass.New(double.NaN.ToString());
			}
			return base.Global.StringClass.New(global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToLocalTime().ToString("F", global::System.Globalization.CultureInfo.CurrentCulture));
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x00020C34 File Offset: 0x0001EE34
		public global::Jint.Native.JsInstance ToDateStringImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (double.IsNaN(target.ToNumber()))
			{
				return base.Global.StringClass.New(double.NaN.ToString());
			}
			return base.Global.StringClass.New(global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToLocalTime().ToString(global::Jint.Native.JsDate.DATEFORMAT, global::System.Globalization.CultureInfo.InvariantCulture));
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x00020CAC File Offset: 0x0001EEAC
		public global::Jint.Native.JsInstance ToTimeStringImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (double.IsNaN(target.ToNumber()))
			{
				return base.Global.StringClass.New(double.NaN.ToString());
			}
			return base.Global.StringClass.New(global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToLocalTime().ToString(global::Jint.Native.JsDate.TIMEFORMAT, global::System.Globalization.CultureInfo.InvariantCulture));
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x00020D24 File Offset: 0x0001EF24
		public global::Jint.Native.JsInstance ToLocaleDateStringImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (double.IsNaN(target.ToNumber()))
			{
				return base.Global.StringClass.New(double.NaN.ToString());
			}
			return base.Global.StringClass.New(global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToLocalTime().ToString(global::Jint.Native.JsDate.DATEFORMAT));
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x00020D98 File Offset: 0x0001EF98
		public global::Jint.Native.JsInstance ToLocaleTimeStringImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (double.IsNaN(target.ToNumber()))
			{
				return base.Global.StringClass.New(double.NaN.ToString());
			}
			return base.Global.StringClass.New(global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToLocalTime().ToString(global::Jint.Native.JsDate.TIMEFORMAT));
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x00020E0C File Offset: 0x0001F00C
		public global::Jint.Native.JsInstance ValueOfImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (double.IsNaN(target.ToNumber()))
			{
				return base.Global.NaN;
			}
			return base.Global.NumberClass.New(target.ToNumber());
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x00020E50 File Offset: 0x0001F050
		public global::Jint.Native.JsInstance GetTimeImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (double.IsNaN(target.ToNumber()))
			{
				return base.Global.NaN;
			}
			return base.Global.NumberClass.New(target.ToNumber());
		}

		// Token: 0x060003BA RID: 954 RVA: 0x00020E94 File Offset: 0x0001F094
		public global::Jint.Native.JsInstance GetFullYearImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (double.IsNaN(target.ToNumber()))
			{
				return base.Global.NaN;
			}
			return base.Global.NumberClass.New((double)global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToLocalTime().Year);
		}

		// Token: 0x060003BB RID: 955 RVA: 0x00020EF0 File Offset: 0x0001F0F0
		public global::Jint.Native.JsInstance GetUTCFullYearImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (double.IsNaN(target.ToNumber()))
			{
				return base.Global.NaN;
			}
			return base.Global.NumberClass.New((double)global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToUniversalTime().Year);
		}

		// Token: 0x060003BC RID: 956 RVA: 0x00020F4C File Offset: 0x0001F14C
		public global::Jint.Native.JsInstance GetMonthImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (double.IsNaN(target.ToNumber()))
			{
				return base.Global.NaN;
			}
			return base.Global.NumberClass.New((double)(global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToLocalTime().Month - 1));
		}

		// Token: 0x060003BD RID: 957 RVA: 0x00020FA8 File Offset: 0x0001F1A8
		public global::Jint.Native.JsInstance GetUTCMonthImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (double.IsNaN(target.ToNumber()))
			{
				return base.Global.NaN;
			}
			return base.Global.NumberClass.New((double)(global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToUniversalTime().Month - 1));
		}

		// Token: 0x060003BE RID: 958 RVA: 0x00021004 File Offset: 0x0001F204
		public global::Jint.Native.JsInstance GetDateImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (double.IsNaN(target.ToNumber()))
			{
				return base.Global.NaN;
			}
			return base.Global.NumberClass.New((double)global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToLocalTime().Day);
		}

		// Token: 0x060003BF RID: 959 RVA: 0x00021060 File Offset: 0x0001F260
		public global::Jint.Native.JsInstance GetUTCDateImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (double.IsNaN(target.ToNumber()))
			{
				return base.Global.NaN;
			}
			return base.Global.NumberClass.New((double)global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToUniversalTime().Day);
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x000210BC File Offset: 0x0001F2BC
		public global::Jint.Native.JsInstance GetDayImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (double.IsNaN(target.ToNumber()))
			{
				return base.Global.NaN;
			}
			return base.Global.NumberClass.New((double)global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToLocalTime().DayOfWeek);
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x00021118 File Offset: 0x0001F318
		public global::Jint.Native.JsInstance GetUTCDayImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (double.IsNaN(target.ToNumber()))
			{
				return base.Global.NaN;
			}
			return base.Global.NumberClass.New((double)global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToUniversalTime().DayOfWeek);
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x00021174 File Offset: 0x0001F374
		public global::Jint.Native.JsInstance GetHoursImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (double.IsNaN(target.ToNumber()))
			{
				return base.Global.NaN;
			}
			return base.Global.NumberClass.New((double)global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToLocalTime().Hour);
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x000211D0 File Offset: 0x0001F3D0
		public global::Jint.Native.JsInstance GetUTCHoursImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (double.IsNaN(target.ToNumber()))
			{
				return base.Global.NaN;
			}
			return base.Global.NumberClass.New((double)global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToUniversalTime().Hour);
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x0002122C File Offset: 0x0001F42C
		public global::Jint.Native.JsInstance GetMinutesImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (double.IsNaN(target.ToNumber()))
			{
				return base.Global.NaN;
			}
			return base.Global.NumberClass.New((double)global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToLocalTime().Minute);
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x00021288 File Offset: 0x0001F488
		public global::Jint.Native.JsInstance GetUTCMinutesImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (double.IsNaN(target.ToNumber()))
			{
				return base.Global.NaN;
			}
			return base.Global.NumberClass.New((double)global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToUniversalTime().Minute);
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x000212E4 File Offset: 0x0001F4E4
		public global::Jint.Native.JsInstance ToUTCStringImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (double.IsNaN(target.ToNumber()))
			{
				return base.Global.StringClass.New(double.NaN.ToString());
			}
			return base.Global.StringClass.New(global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToString(global::Jint.Native.JsDate.FORMATUTC, global::System.Globalization.CultureInfo.InvariantCulture));
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x00021354 File Offset: 0x0001F554
		public global::Jint.Native.JsInstance GetSecondsImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (double.IsNaN(target.ToNumber()))
			{
				return base.Global.NaN;
			}
			return base.Global.NumberClass.New((double)global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToLocalTime().Second);
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x000213B0 File Offset: 0x0001F5B0
		public global::Jint.Native.JsInstance GetUTCSecondsImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (double.IsNaN(target.ToNumber()))
			{
				return base.Global.NaN;
			}
			return base.Global.NumberClass.New((double)global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToUniversalTime().Second);
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x0002140C File Offset: 0x0001F60C
		public global::Jint.Native.JsInstance GetMillisecondsImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (double.IsNaN(target.ToNumber()))
			{
				return base.Global.NaN;
			}
			return base.Global.NumberClass.New((double)global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToLocalTime().Millisecond);
		}

		// Token: 0x060003CA RID: 970 RVA: 0x00021468 File Offset: 0x0001F668
		public global::Jint.Native.JsInstance GetUTCMillisecondsImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (double.IsNaN(target.ToNumber()))
			{
				return base.Global.NaN;
			}
			return base.Global.NumberClass.New((double)global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToUniversalTime().Millisecond);
		}

		// Token: 0x060003CB RID: 971 RVA: 0x000214C4 File Offset: 0x0001F6C4
		public global::Jint.Native.JsInstance GetTimezoneOffsetImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			return base.Global.NumberClass.New(-global::System.TimeZone.CurrentTimeZone.GetUtcOffset(default(global::System.DateTime)).TotalMinutes);
		}

		// Token: 0x060003CC RID: 972 RVA: 0x00021504 File Offset: 0x0001F704
		public global::Jint.Native.JsInstance SetTimeImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (parameters.Length == 0)
			{
				throw new global::System.ArgumentException("There was no tiem specified");
			}
			target.Value = parameters[0].ToNumber();
			return target;
		}

		// Token: 0x060003CD RID: 973 RVA: 0x00021534 File Offset: 0x0001F734
		public global::Jint.Native.JsInstance SetMillisecondsImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (parameters.Length == 0)
			{
				throw new global::System.ArgumentException("There was no millisecond specified");
			}
			global::System.DateTime value = global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToLocalTime();
			value = value.AddMilliseconds((double)(-(double)value.Millisecond));
			value = value.AddMilliseconds(parameters[0].ToNumber());
			target.Value = this.New(value).ToNumber();
			return target;
		}

		// Token: 0x060003CE RID: 974 RVA: 0x000215AC File Offset: 0x0001F7AC
		public global::Jint.Native.JsInstance SetUTCMillisecondsImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (parameters.Length == 0)
			{
				throw new global::System.ArgumentException("There was no millisecond specified");
			}
			global::System.DateTime value = global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber());
			value = value.AddMilliseconds((double)(-(double)value.Millisecond));
			value = value.AddMilliseconds(parameters[0].ToNumber());
			target.Value = this.New(value).ToNumber();
			return target;
		}

		// Token: 0x060003CF RID: 975 RVA: 0x0002161C File Offset: 0x0001F81C
		public global::Jint.Native.JsInstance SetSecondsImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (parameters.Length == 0)
			{
				throw new global::System.ArgumentException("There was no second specified");
			}
			global::System.DateTime dateTime = global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToLocalTime();
			dateTime = dateTime.AddSeconds((double)(-(double)dateTime.Second));
			dateTime = dateTime.AddSeconds(parameters[0].ToNumber());
			target.Value = dateTime;
			if (parameters.Length > 1)
			{
				global::Jint.Native.JsInstance[] array = new global::Jint.Native.JsInstance[parameters.Length - 1];
				global::System.Array.Copy(parameters, 1, array, 0, array.Length);
				target = (global::Jint.Native.JsDate)this.SetMillisecondsImpl(target, array);
			}
			return target;
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x000216B8 File Offset: 0x0001F8B8
		public global::Jint.Native.JsInstance SetUTCSecondsImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (parameters.Length == 0)
			{
				throw new global::System.ArgumentException("There was no second specified");
			}
			global::System.DateTime dateTime = global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber());
			dateTime = dateTime.AddSeconds((double)(-(double)dateTime.Second));
			dateTime = dateTime.AddSeconds(parameters[0].ToNumber());
			target.Value = dateTime;
			if (parameters.Length > 1)
			{
				global::Jint.Native.JsInstance[] array = new global::Jint.Native.JsInstance[parameters.Length - 1];
				global::System.Array.Copy(parameters, 1, array, 0, array.Length);
				target = (global::Jint.Native.JsDate)this.SetMillisecondsImpl(target, array);
			}
			return target;
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x0002174C File Offset: 0x0001F94C
		public global::Jint.Native.JsInstance SetMinutesImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (parameters.Length == 0)
			{
				throw new global::System.ArgumentException("There was no minute specified");
			}
			global::System.DateTime dateTime = global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToLocalTime();
			dateTime = dateTime.AddMinutes((double)(-(double)dateTime.Minute));
			dateTime = dateTime.AddMinutes(parameters[0].ToNumber());
			target.Value = dateTime;
			if (parameters.Length > 1)
			{
				global::Jint.Native.JsInstance[] array = new global::Jint.Native.JsInstance[parameters.Length - 1];
				global::System.Array.Copy(parameters, 1, array, 0, array.Length);
				target = (global::Jint.Native.JsDate)this.SetSecondsImpl(target, array);
			}
			return target;
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x000217E8 File Offset: 0x0001F9E8
		public global::Jint.Native.JsInstance SetUTCMinutesImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (parameters.Length == 0)
			{
				throw new global::System.ArgumentException("There was no minute specified");
			}
			global::System.DateTime dateTime = global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber());
			dateTime = dateTime.AddMinutes((double)(-(double)dateTime.Minute));
			dateTime = dateTime.AddMinutes(parameters[0].ToNumber());
			target.Value = dateTime;
			if (parameters.Length > 1)
			{
				global::Jint.Native.JsInstance[] array = new global::Jint.Native.JsInstance[parameters.Length - 1];
				global::System.Array.Copy(parameters, 1, array, 0, array.Length);
				target = (global::Jint.Native.JsDate)this.SetSecondsImpl(target, array);
			}
			return target;
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x0002187C File Offset: 0x0001FA7C
		public global::Jint.Native.JsInstance SetHoursImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (parameters.Length == 0)
			{
				throw new global::System.ArgumentException("There was no hour specified");
			}
			global::System.DateTime dateTime = global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToLocalTime();
			dateTime = dateTime.AddHours((double)(-(double)dateTime.Hour));
			dateTime = dateTime.AddHours(parameters[0].ToNumber());
			target.Value = dateTime;
			if (parameters.Length > 1)
			{
				global::Jint.Native.JsInstance[] array = new global::Jint.Native.JsInstance[parameters.Length - 1];
				global::System.Array.Copy(parameters, 1, array, 0, array.Length);
				target = (global::Jint.Native.JsDate)this.SetMinutesImpl(target, array);
			}
			return target;
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x00021918 File Offset: 0x0001FB18
		public global::Jint.Native.JsInstance SetUTCHoursImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (parameters.Length == 0)
			{
				throw new global::System.ArgumentException("There was no hour specified");
			}
			global::System.DateTime dateTime = global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber());
			dateTime = dateTime.AddHours((double)(-(double)dateTime.Hour));
			dateTime = dateTime.AddHours(parameters[0].ToNumber());
			target.Value = dateTime;
			if (parameters.Length > 1)
			{
				global::Jint.Native.JsInstance[] array = new global::Jint.Native.JsInstance[parameters.Length - 1];
				global::System.Array.Copy(parameters, 1, array, 0, array.Length);
				target = (global::Jint.Native.JsDate)this.SetMinutesImpl(target, array);
			}
			return target;
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x000219AC File Offset: 0x0001FBAC
		public global::Jint.Native.JsInstance SetDateImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (parameters.Length == 0)
			{
				throw new global::System.ArgumentException("There was no date specified");
			}
			global::System.DateTime dateTime = global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToLocalTime();
			dateTime = dateTime.AddDays((double)(-(double)dateTime.Day));
			dateTime = dateTime.AddDays(parameters[0].ToNumber());
			target.Value = dateTime;
			return target;
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x00021A18 File Offset: 0x0001FC18
		public global::Jint.Native.JsInstance SetUTCDateImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (parameters.Length == 0)
			{
				throw new global::System.ArgumentException("There was no date specified");
			}
			global::System.DateTime dateTime = global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber());
			dateTime = dateTime.AddDays((double)(-(double)dateTime.Day));
			dateTime = dateTime.AddDays(parameters[0].ToNumber());
			target.Value = dateTime;
			return target;
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x00021A7C File Offset: 0x0001FC7C
		public global::Jint.Native.JsInstance SetMonthImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (parameters.Length == 0)
			{
				throw new global::System.ArgumentException("There was no month specified");
			}
			global::System.DateTime dateTime = global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToLocalTime();
			dateTime = dateTime.AddMonths(-dateTime.Month);
			dateTime = dateTime.AddMonths((int)parameters[0].ToNumber() + 1);
			target.Value = dateTime;
			if (parameters.Length > 1)
			{
				global::Jint.Native.JsInstance[] array = new global::Jint.Native.JsInstance[parameters.Length - 1];
				global::System.Array.Copy(parameters, 1, array, 0, array.Length);
				target = (global::Jint.Native.JsDate)this.SetDateImpl(target, array);
			}
			return target;
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x00021B18 File Offset: 0x0001FD18
		public global::Jint.Native.JsInstance SetUTCMonthImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (parameters.Length == 0)
			{
				throw new global::System.ArgumentException("There was no month specified");
			}
			global::System.DateTime dateTime = global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber());
			dateTime = dateTime.AddMonths(-dateTime.Month);
			dateTime = dateTime.AddMonths((int)parameters[0].ToNumber() + 1);
			target.Value = dateTime;
			if (parameters.Length > 1)
			{
				global::Jint.Native.JsInstance[] array = new global::Jint.Native.JsInstance[parameters.Length - 1];
				global::System.Array.Copy(parameters, 1, array, 0, array.Length);
				target = (global::Jint.Native.JsDate)this.SetDateImpl(target, array);
			}
			return target;
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x00021BAC File Offset: 0x0001FDAC
		public global::Jint.Native.JsInstance SetFullYearImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (parameters.Length == 0)
			{
				throw new global::System.ArgumentException("There was no year specified");
			}
			global::System.DateTime dateTime = global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber()).ToLocalTime();
			int num = dateTime.Year - (int)parameters[0].ToNumber();
			dateTime = dateTime.AddYears(-num);
			target.Value = dateTime;
			if (parameters.Length > 1)
			{
				global::Jint.Native.JsInstance[] array = new global::Jint.Native.JsInstance[parameters.Length - 1];
				global::System.Array.Copy(parameters, 1, array, 0, array.Length);
				target = (global::Jint.Native.JsDate)this.SetMonthImpl(target, array);
			}
			return target;
		}

		// Token: 0x060003DA RID: 986 RVA: 0x00021C40 File Offset: 0x0001FE40
		public global::Jint.Native.JsInstance SetUTCFullYearImpl(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (parameters.Length == 0)
			{
				throw new global::System.ArgumentException("There was no year specified");
			}
			global::System.DateTime dateTime = global::Jint.Native.JsDateConstructor.CreateDateTime(target.ToNumber());
			dateTime = dateTime.AddYears(-dateTime.Year);
			dateTime = dateTime.AddYears((int)parameters[0].ToNumber());
			target.Value = dateTime;
			if (parameters.Length > 1)
			{
				global::Jint.Native.JsInstance[] array = new global::Jint.Native.JsInstance[parameters.Length - 1];
				global::System.Array.Copy(parameters, 1, array, 0, array.Length);
				target = (global::Jint.Native.JsDate)this.SetMonthImpl(target, array);
			}
			return target;
		}

		// Token: 0x060003DB RID: 987 RVA: 0x00021CD4 File Offset: 0x0001FED4
		public global::Jint.Native.JsInstance UTCImpl(global::Jint.Native.JsInstance[] parameters)
		{
			for (int i = 0; i < parameters.Length; i++)
			{
				if (parameters[i] == global::Jint.Native.JsUndefined.Instance || (parameters[i].Class == "Number" && double.IsNaN(parameters[i].ToNumber())) || (parameters[i].Class == "Number" && double.IsInfinity(parameters[i].ToNumber())))
				{
					return base.Global.NaN;
				}
			}
			global::Jint.Native.JsDate jsDate = this.Construct(parameters);
			double value = jsDate.ToNumber() + global::System.TimeZone.CurrentTimeZone.GetUtcOffset(default(global::System.DateTime)).TotalMilliseconds;
			return base.Global.NumberClass.New(value);
		}

		// Token: 0x060003DC RID: 988 RVA: 0x00021DB8 File Offset: 0x0001FFB8
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsDate <.ctor>b__0()
		{
			return base.Global.DateClass.New(global::System.DateTime.Now);
		}

		// Token: 0x060003DD RID: 989 RVA: 0x00021DD0 File Offset: 0x0001FFD0
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsDate <InitPrototype>b__2()
		{
			return base.Global.DateClass.New(global::System.DateTime.Now);
		}
	}
}
