using System;
using System.Reflection;
using Jint.Expressions;

namespace Jint.Native
{
	// Token: 0x02000049 RID: 73
	[global::System.Serializable]
	public class ClrImplDefinition<T> : global::Jint.Native.JsFunction where T : global::Jint.Native.JsInstance
	{
		// Token: 0x06000365 RID: 869 RVA: 0x0001F714 File Offset: 0x0001D914
		private ClrImplDefinition(bool hasParameters, global::Jint.Native.JsObject prototype) : base(prototype)
		{
			this.hasParameters = hasParameters;
		}

		// Token: 0x06000366 RID: 870 RVA: 0x0001F724 File Offset: 0x0001D924
		public ClrImplDefinition(global::System.Func<T, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance> impl, global::Jint.Native.JsObject prototype) : this(impl, -1, prototype)
		{
		}

		// Token: 0x06000367 RID: 871 RVA: 0x0001F730 File Offset: 0x0001D930
		public ClrImplDefinition(global::System.Func<T, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance> impl, int length, global::Jint.Native.JsObject prototype) : this(true, prototype)
		{
			this.impl = impl;
			this.length = length;
		}

		// Token: 0x06000368 RID: 872 RVA: 0x0001F748 File Offset: 0x0001D948
		public ClrImplDefinition(global::System.Func<T, global::Jint.Native.JsInstance> impl, global::Jint.Native.JsObject prototype) : this(impl, -1, prototype)
		{
		}

		// Token: 0x06000369 RID: 873 RVA: 0x0001F754 File Offset: 0x0001D954
		public ClrImplDefinition(global::System.Func<T, global::Jint.Native.JsInstance> impl, int length, global::Jint.Native.JsObject prototype) : this(false, prototype)
		{
			this.impl = impl;
			this.length = length;
		}

		// Token: 0x0600036A RID: 874 RVA: 0x0001F76C File Offset: 0x0001D96C
		public override global::Jint.Native.JsInstance Execute(global::Jint.Expressions.IJintVisitor visitor, global::Jint.Native.JsDictionaryObject that, global::Jint.Native.JsInstance[] parameters)
		{
			global::Jint.Native.JsInstance result;
			try
			{
				global::Jint.Native.JsInstance jsInstance;
				if (this.hasParameters)
				{
					jsInstance = (this.impl.DynamicInvoke(new object[]
					{
						that,
						parameters
					}) as global::Jint.Native.JsInstance);
				}
				else
				{
					jsInstance = (this.impl.DynamicInvoke(new object[]
					{
						that
					}) as global::Jint.Native.JsInstance);
				}
				visitor.Return(jsInstance);
				result = jsInstance;
			}
			catch (global::System.Reflection.TargetInvocationException ex)
			{
				throw ex.InnerException;
			}
			catch (global::System.ArgumentException)
			{
				global::Jint.Native.JsFunction jsFunction = that["constructor"] as global::Jint.Native.JsFunction;
				throw new global::Jint.Native.JsException(visitor.Global.TypeErrorClass.New(("incompatible type: " + jsFunction == null) ? "<unknown>" : jsFunction.Name));
			}
			catch (global::System.Exception ex2)
			{
				if (ex2.InnerException is global::Jint.Native.JsException)
				{
					throw ex2.InnerException;
				}
				throw;
			}
			return result;
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x0600036B RID: 875 RVA: 0x0001F874 File Offset: 0x0001DA74
		public override int Length
		{
			get
			{
				if (this.length == -1)
				{
					return base.Length;
				}
				return this.length;
			}
		}

		// Token: 0x0600036C RID: 876 RVA: 0x0001F890 File Offset: 0x0001DA90
		public override string ToString()
		{
			return string.Format("function {0}() { [native code] }", this.impl.Method.Name);
		}

		// Token: 0x0400020A RID: 522
		private global::System.Delegate impl;

		// Token: 0x0400020B RID: 523
		private int length;

		// Token: 0x0400020C RID: 524
		private bool hasParameters;
	}
}
