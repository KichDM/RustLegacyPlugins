using System;
using System.Runtime.CompilerServices;

namespace Jint.Native
{
	// Token: 0x02000010 RID: 16
	[global::System.Serializable]
	public class JsObject : global::Jint.Native.JsDictionaryObject
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00004C74 File Offset: 0x00002E74
		// (set) Token: 0x06000069 RID: 105 RVA: 0x00004C7C File Offset: 0x00002E7C
		public global::Jint.Native.INativeIndexer Indexer
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Indexer>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Indexer>k__BackingField = value;
			}
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00004C88 File Offset: 0x00002E88
		public JsObject()
		{
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00004C90 File Offset: 0x00002E90
		public JsObject(object value, global::Jint.Native.JsObject prototype) : base(prototype)
		{
			this.value = value;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00004CA0 File Offset: 0x00002EA0
		public JsObject(global::Jint.Native.JsObject prototype) : base(prototype)
		{
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600006D RID: 109 RVA: 0x00004CAC File Offset: 0x00002EAC
		public override bool IsClr
		{
			get
			{
				return this.Value != null;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00004CBC File Offset: 0x00002EBC
		public override string Class
		{
			get
			{
				return "Object";
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00004CC4 File Offset: 0x00002EC4
		public override string Type
		{
			get
			{
				return "object";
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000070 RID: 112 RVA: 0x00004CCC File Offset: 0x00002ECC
		// (set) Token: 0x06000071 RID: 113 RVA: 0x00004CD4 File Offset: 0x00002ED4
		public override object Value
		{
			get
			{
				return this.value;
			}
			set
			{
				this.value = value;
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00004CE0 File Offset: 0x00002EE0
		public override int GetHashCode()
		{
			return global::System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(this);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00004CE8 File Offset: 0x00002EE8
		public override global::Jint.Native.JsInstance ToPrimitive(global::Jint.Native.IGlobal global)
		{
			if (this.Value != null && !(this.Value is global::System.IComparable))
			{
				return global.StringClass.New(this.Value.ToString());
			}
			switch (global::System.Convert.GetTypeCode(this.Value))
			{
			case global::System.TypeCode.Object:
			case global::System.TypeCode.Char:
			case global::System.TypeCode.String:
				return global.StringClass.New(this.Value.ToString());
			case global::System.TypeCode.Boolean:
				return global.BooleanClass.New((bool)this.Value);
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
				return global.NumberClass.New(global::System.Convert.ToDouble(this.Value));
			case global::System.TypeCode.DateTime:
				return global.StringClass.New(global::Jint.Native.JsDate.DateToString((global::System.DateTime)this.Value));
			}
			return global::Jint.Native.JsUndefined.Instance;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00004DF4 File Offset: 0x00002FF4
		public override bool ToBoolean()
		{
			if (this.Value != null && !(this.Value is global::System.IConvertible))
			{
				return true;
			}
			switch (global::System.Convert.GetTypeCode(this.Value))
			{
			case global::System.TypeCode.Object:
				return global::System.Convert.ToBoolean(this.Value);
			case global::System.TypeCode.Boolean:
				return (bool)this.Value;
			case global::System.TypeCode.Char:
			case global::System.TypeCode.String:
				return global::Jint.Native.JsString.StringToBoolean((string)this.Value);
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
				return global::Jint.Native.JsNumber.NumberToBoolean(global::System.Convert.ToDouble(this.Value));
			case global::System.TypeCode.DateTime:
				return global::Jint.Native.JsNumber.NumberToBoolean(global::Jint.Native.JsDate.DateToDouble((global::System.DateTime)this.Value));
			}
			return true;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00004ED4 File Offset: 0x000030D4
		public override double ToNumber()
		{
			if (this.Value == null)
			{
				return 0.0;
			}
			if (!(this.Value is global::System.IConvertible))
			{
				return double.NaN;
			}
			global::System.TypeCode typeCode = global::System.Convert.GetTypeCode(this.Value);
			switch (typeCode)
			{
			case global::System.TypeCode.Boolean:
				return global::Jint.Native.JsBoolean.BooleanToNumber((bool)this.Value);
			case global::System.TypeCode.Char:
				break;
			default:
				switch (typeCode)
				{
				case global::System.TypeCode.DateTime:
					return global::Jint.Native.JsDate.DateToDouble((global::System.DateTime)this.Value);
				case global::System.TypeCode.String:
					goto IL_76;
				}
				return global::System.Convert.ToDouble(this.Value);
			}
			IL_76:
			return global::Jint.Native.JsString.StringToNumber((string)this.Value);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00004F88 File Offset: 0x00003188
		public override string ToString()
		{
			if (this.value == null)
			{
				return null;
			}
			if (this.value is global::System.IConvertible)
			{
				return global::System.Convert.ToString(this.Value);
			}
			return this.value.ToString();
		}

		// Token: 0x04000031 RID: 49
		protected object value;

		// Token: 0x04000032 RID: 50
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.INativeIndexer <Indexer>k__BackingField;
	}
}
