using System;
using System.Runtime.CompilerServices;
using Jint.Expressions;

namespace Jint.Native
{
	// Token: 0x0200000E RID: 14
	[global::System.Serializable]
	public abstract class JsInstance : global::System.IComparable<global::Jint.Native.JsInstance>
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600002C RID: 44
		public abstract bool IsClr { get; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600002D RID: 45
		// (set) Token: 0x0600002E RID: 46
		public abstract object Value { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00004354 File Offset: 0x00002554
		// (set) Token: 0x06000030 RID: 48 RVA: 0x0000435C File Offset: 0x0000255C
		public global::Jint.Native.PropertyAttributes Attributes
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Attributes>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Attributes>k__BackingField = value;
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00004368 File Offset: 0x00002568
		public JsInstance()
		{
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00004370 File Offset: 0x00002570
		public virtual global::Jint.Native.JsInstance ToPrimitive(global::Jint.Native.IGlobal global)
		{
			return global::Jint.Native.JsUndefined.Instance;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00004378 File Offset: 0x00002578
		public virtual bool ToBoolean()
		{
			return true;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x0000437C File Offset: 0x0000257C
		public virtual double ToNumber()
		{
			return 0.0;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00004388 File Offset: 0x00002588
		public virtual int ToInteger()
		{
			return (int)this.ToNumber();
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00004394 File Offset: 0x00002594
		public virtual object ToObject()
		{
			return this.Value;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000439C File Offset: 0x0000259C
		public virtual string ToSource()
		{
			return this.ToString();
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000043A4 File Offset: 0x000025A4
		public override string ToString()
		{
			return (this.Value ?? this.Class).ToString();
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000043C0 File Offset: 0x000025C0
		public override int GetHashCode()
		{
			if (this.Value == null)
			{
				return base.GetHashCode();
			}
			return this.Value.GetHashCode();
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600003A RID: 58
		public abstract string Class { get; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600003B RID: 59
		public abstract string Type { get; }

		// Token: 0x0600003C RID: 60 RVA: 0x000043E0 File Offset: 0x000025E0
		[global::System.Obsolete("will be removed in the 1.0 version", true)]
		public virtual object Call(global::Jint.Expressions.IJintVisitor visitor, string function, params global::Jint.Native.JsInstance[] parameters)
		{
			if (function == "toString")
			{
				return visitor.Global.StringClass.New(this.ToString());
			}
			return global::Jint.Native.JsUndefined.Instance;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00004420 File Offset: 0x00002620
		public static global::Jint.Native.JsInstance StrictlyEquals(global::Jint.Native.IGlobal global, global::Jint.Native.JsInstance left, global::Jint.Native.JsInstance right)
		{
			if (left.Type != right.Type)
			{
				return global.BooleanClass.False;
			}
			if (left is global::Jint.Native.JsUndefined)
			{
				return global.BooleanClass.True;
			}
			if (left is global::Jint.Native.JsNull)
			{
				return global.BooleanClass.True;
			}
			if (left.Type == "number")
			{
				if (left == global.NumberClass["NaN"] || right == global.NumberClass["NaN"])
				{
					return global.BooleanClass.False;
				}
				if (left.ToNumber() == right.ToNumber())
				{
					return global.BooleanClass.True;
				}
				return global.BooleanClass.False;
			}
			else
			{
				if (left.Type == "string")
				{
					return global.BooleanClass.New(left.ToString() == right.ToString());
				}
				if (left.Type == "boolean")
				{
					return global.BooleanClass.New(left.ToBoolean() == right.ToBoolean());
				}
				if (left == right)
				{
					return global.BooleanClass.True;
				}
				return global.BooleanClass.False;
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00004578 File Offset: 0x00002778
		public int CompareTo(global::Jint.Native.JsInstance other)
		{
			return this.ToString().CompareTo(other.ToString());
		}

		// Token: 0x0600003F RID: 63 RVA: 0x0000458C File Offset: 0x0000278C
		// Note: this type is marked as 'beforefieldinit'.
		static JsInstance()
		{
		}

		// Token: 0x04000013 RID: 19
		public const string TYPE_OBJECT = "object";

		// Token: 0x04000014 RID: 20
		public const string TYPE_BOOLEAN = "boolean";

		// Token: 0x04000015 RID: 21
		public const string TYPE_STRING = "string";

		// Token: 0x04000016 RID: 22
		public const string TYPE_NUMBER = "number";

		// Token: 0x04000017 RID: 23
		public const string TYPE_UNDEFINED = "undefined";

		// Token: 0x04000018 RID: 24
		public const string TYPE_NULL = "null";

		// Token: 0x04000019 RID: 25
		public const string TYPE_DESCRIPTOR = "descriptor";

		// Token: 0x0400001A RID: 26
		public const string TYPEOF_FUNCTION = "function";

		// Token: 0x0400001B RID: 27
		public const string CLASS_NUMBER = "Number";

		// Token: 0x0400001C RID: 28
		public const string CLASS_STRING = "String";

		// Token: 0x0400001D RID: 29
		public const string CLASS_BOOLEAN = "Boolean";

		// Token: 0x0400001E RID: 30
		public const string CLASS_OBJECT = "Object";

		// Token: 0x0400001F RID: 31
		public const string CLASS_FUNCTION = "Function";

		// Token: 0x04000020 RID: 32
		public const string CLASS_ARRAY = "Array";

		// Token: 0x04000021 RID: 33
		public const string CLASS_REGEXP = "RegExp";

		// Token: 0x04000022 RID: 34
		public const string CLASS_DATE = "Date";

		// Token: 0x04000023 RID: 35
		public const string CLASS_ERROR = "Error";

		// Token: 0x04000024 RID: 36
		public const string CLASS_ARGUMENTS = "Arguments";

		// Token: 0x04000025 RID: 37
		public const string CLASS_GLOBAL = "Global";

		// Token: 0x04000026 RID: 38
		public const string CLASS_DESCRIPTOR = "Descriptor";

		// Token: 0x04000027 RID: 39
		public const string CLASS_SCOPE = "Scope";

		// Token: 0x04000028 RID: 40
		public const string CLASS_UNDEFINED = "Undefined";

		// Token: 0x04000029 RID: 41
		public const string CLASS_NULL = "Null";

		// Token: 0x0400002A RID: 42
		public static global::Jint.Native.JsInstance[] EMPTY = new global::Jint.Native.JsInstance[0];

		// Token: 0x0400002B RID: 43
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.PropertyAttributes <Attributes>k__BackingField;
	}
}
