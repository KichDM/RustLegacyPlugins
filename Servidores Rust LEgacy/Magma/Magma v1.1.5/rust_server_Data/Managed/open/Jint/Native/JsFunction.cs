using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Jint.Expressions;

namespace Jint.Native
{
	// Token: 0x02000011 RID: 17
	[global::System.Serializable]
	public class JsFunction : global::Jint.Native.JsObject
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000077 RID: 119 RVA: 0x00004FC0 File Offset: 0x000031C0
		// (set) Token: 0x06000078 RID: 120 RVA: 0x00004FC8 File Offset: 0x000031C8
		public string Name
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Name>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Name>k__BackingField = value;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000079 RID: 121 RVA: 0x00004FD4 File Offset: 0x000031D4
		// (set) Token: 0x0600007A RID: 122 RVA: 0x00004FDC File Offset: 0x000031DC
		public global::Jint.Expressions.Statement Statement
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Statement>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Statement>k__BackingField = value;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600007B RID: 123 RVA: 0x00004FE8 File Offset: 0x000031E8
		// (set) Token: 0x0600007C RID: 124 RVA: 0x00004FF0 File Offset: 0x000031F0
		public global::System.Collections.Generic.List<string> Arguments
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Arguments>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Arguments>k__BackingField = value;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600007D RID: 125 RVA: 0x00004FFC File Offset: 0x000031FC
		// (set) Token: 0x0600007E RID: 126 RVA: 0x00005004 File Offset: 0x00003204
		public global::Jint.Native.JsScope Scope
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Scope>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Scope>k__BackingField = value;
			}
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00005010 File Offset: 0x00003210
		public JsFunction(global::Jint.Native.IGlobal global, global::Jint.Expressions.Statement statement) : this(global.FunctionClass.PrototypeProperty)
		{
			this.Statement = statement;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000503C File Offset: 0x0000323C
		public JsFunction(global::Jint.Native.IGlobal global) : this(global.FunctionClass.PrototypeProperty)
		{
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00005050 File Offset: 0x00003250
		public JsFunction(global::Jint.Native.JsObject prototype) : base(prototype)
		{
			this.Arguments = new global::System.Collections.Generic.List<string>();
			this.Statement = new global::Jint.Expressions.EmptyStatement();
			base.DefineOwnProperty(global::Jint.Native.JsFunction.PROTOTYPE, global::Jint.Native.JsNull.Instance, global::Jint.Native.PropertyAttributes.DontEnum);
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000082 RID: 130 RVA: 0x00005090 File Offset: 0x00003290
		// (set) Token: 0x06000083 RID: 131 RVA: 0x000050A0 File Offset: 0x000032A0
		public override int Length
		{
			get
			{
				return this.Arguments.Count;
			}
			set
			{
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000084 RID: 132 RVA: 0x000050A4 File Offset: 0x000032A4
		// (set) Token: 0x06000085 RID: 133 RVA: 0x000050B8 File Offset: 0x000032B8
		public global::Jint.Native.JsObject PrototypeProperty
		{
			get
			{
				return this[global::Jint.Native.JsFunction.PROTOTYPE] as global::Jint.Native.JsObject;
			}
			set
			{
				this[global::Jint.Native.JsFunction.PROTOTYPE] = value;
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x000050C8 File Offset: 0x000032C8
		public virtual bool HasInstance(global::Jint.Native.JsObject inst)
		{
			return inst != null && inst != global::Jint.Native.JsNull.Instance && inst != global::Jint.Native.JsNull.Instance && this.PrototypeProperty.IsPrototypeOf(inst);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x000050F4 File Offset: 0x000032F4
		public virtual global::Jint.Native.JsObject Construct(global::Jint.Native.JsInstance[] parameters, global::System.Type[] genericArgs, global::Jint.Expressions.IJintVisitor visitor)
		{
			global::Jint.Native.JsObject jsObject = visitor.Global.ObjectClass.New(this.PrototypeProperty);
			visitor.ExecuteFunction(this, jsObject, parameters);
			return (visitor.Result as global::Jint.Native.JsObject) ?? jsObject;
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000088 RID: 136 RVA: 0x00005138 File Offset: 0x00003338
		public override bool IsClr
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000089 RID: 137 RVA: 0x0000513C File Offset: 0x0000333C
		// (set) Token: 0x0600008A RID: 138 RVA: 0x00005140 File Offset: 0x00003340
		public override object Value
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00005144 File Offset: 0x00003344
		public virtual global::Jint.Native.JsInstance Execute(global::Jint.Expressions.IJintVisitor visitor, global::Jint.Native.JsDictionaryObject that, global::Jint.Native.JsInstance[] parameters)
		{
			this.Statement.Accept((global::Jint.Expressions.IStatementVisitor)visitor);
			return that;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00005158 File Offset: 0x00003358
		public virtual global::Jint.Native.JsInstance Execute(global::Jint.Expressions.IJintVisitor visitor, global::Jint.Native.JsDictionaryObject that, global::Jint.Native.JsInstance[] parameters, global::System.Type[] genericArguments)
		{
			throw new global::Jint.JintException("This method can't be called as a generic");
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600008D RID: 141 RVA: 0x00005164 File Offset: 0x00003364
		public override string Class
		{
			get
			{
				return "Function";
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x0000516C File Offset: 0x0000336C
		public override string ToSource()
		{
			return string.Format("function {0} ( {1} ) {{ {2} }}", this.Name, string.Join(", ", this.Arguments.ToArray()), this.GetBody());
		}

		// Token: 0x0600008F RID: 143 RVA: 0x000051A8 File Offset: 0x000033A8
		public virtual string GetBody()
		{
			return "/* js code */";
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000051B0 File Offset: 0x000033B0
		public override string ToString()
		{
			return this.ToSource();
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000051B8 File Offset: 0x000033B8
		public override bool ToBoolean()
		{
			return true;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000051BC File Offset: 0x000033BC
		public override double ToNumber()
		{
			return 1.0;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000051C8 File Offset: 0x000033C8
		// Note: this type is marked as 'beforefieldinit'.
		static JsFunction()
		{
		}

		// Token: 0x04000033 RID: 51
		public static string CALL = "call";

		// Token: 0x04000034 RID: 52
		public static string APPLY = "apply";

		// Token: 0x04000035 RID: 53
		public static string CONSTRUCTOR = "constructor";

		// Token: 0x04000036 RID: 54
		public static string PROTOTYPE = "prototype";

		// Token: 0x04000037 RID: 55
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string <Name>k__BackingField;

		// Token: 0x04000038 RID: 56
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Statement <Statement>k__BackingField;

		// Token: 0x04000039 RID: 57
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::System.Collections.Generic.List<string> <Arguments>k__BackingField;

		// Token: 0x0400003A RID: 58
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsScope <Scope>k__BackingField;
	}
}
