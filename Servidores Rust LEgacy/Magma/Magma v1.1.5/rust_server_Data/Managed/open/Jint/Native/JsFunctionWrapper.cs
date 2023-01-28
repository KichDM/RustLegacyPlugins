using System;
using System.Runtime.CompilerServices;
using Jint.Expressions;

namespace Jint.Native
{
	// Token: 0x0200004D RID: 77
	[global::System.Serializable]
	public class JsFunctionWrapper : global::Jint.Native.JsFunction
	{
		// Token: 0x17000096 RID: 150
		// (get) Token: 0x0600037F RID: 895 RVA: 0x0001F968 File Offset: 0x0001DB68
		// (set) Token: 0x06000380 RID: 896 RVA: 0x0001F970 File Offset: 0x0001DB70
		public global::System.Func<global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance> Delegate
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Delegate>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Delegate>k__BackingField = value;
			}
		}

		// Token: 0x06000381 RID: 897 RVA: 0x0001F97C File Offset: 0x0001DB7C
		public JsFunctionWrapper(global::System.Func<global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance> d, global::Jint.Native.JsObject prototype) : base(prototype)
		{
			this.Delegate = d;
		}

		// Token: 0x06000382 RID: 898 RVA: 0x0001F98C File Offset: 0x0001DB8C
		public override global::Jint.Native.JsInstance Execute(global::Jint.Expressions.IJintVisitor visitor, global::Jint.Native.JsDictionaryObject that, global::Jint.Native.JsInstance[] parameters)
		{
			try
			{
				global::Jint.Native.JsInstance jsInstance = this.Delegate(parameters);
				visitor.Return((jsInstance == null) ? global::Jint.Native.JsUndefined.Instance : jsInstance);
			}
			catch (global::System.Exception ex)
			{
				if (ex.InnerException is global::Jint.Native.JsException)
				{
					throw ex.InnerException;
				}
				throw;
			}
			return that;
		}

		// Token: 0x06000383 RID: 899 RVA: 0x0001F9F0 File Offset: 0x0001DBF0
		public override string ToString()
		{
			return string.Format("function {0}() {{ [native code] }}", this.Delegate.Method.Name);
		}

		// Token: 0x04000212 RID: 530
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::System.Func<global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance> <Delegate>k__BackingField;
	}
}
