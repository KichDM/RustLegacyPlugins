using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Jint.Expressions;

namespace Jint.Native
{
	// Token: 0x02000012 RID: 18
	[global::System.Serializable]
	public class ClrFunction : global::Jint.Native.JsFunction
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000094 RID: 148 RVA: 0x000051F4 File Offset: 0x000033F4
		// (set) Token: 0x06000095 RID: 149 RVA: 0x000051FC File Offset: 0x000033FC
		public global::System.Delegate Delegate
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

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000096 RID: 150 RVA: 0x00005208 File Offset: 0x00003408
		// (set) Token: 0x06000097 RID: 151 RVA: 0x00005210 File Offset: 0x00003410
		public global::System.Reflection.ParameterInfo[] Parameters
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Parameters>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Parameters>k__BackingField = value;
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000521C File Offset: 0x0000341C
		public ClrFunction(global::System.Delegate d, global::Jint.Native.JsObject prototype) : base(prototype)
		{
			this.Delegate = d;
			this.Parameters = d.Method.GetParameters();
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0000524C File Offset: 0x0000344C
		public override global::Jint.Native.JsInstance Execute(global::Jint.Expressions.IJintVisitor visitor, global::Jint.Native.JsDictionaryObject that, global::Jint.Native.JsInstance[] parameters)
		{
			int num = this.Delegate.Method.GetParameters().Length;
			object[] array = new object[num];
			for (int i = 0; i < parameters.Length; i++)
			{
				if (typeof(global::Jint.Native.JsInstance).IsAssignableFrom(this.Parameters[i].ParameterType) && this.Parameters[i].ParameterType.IsInstanceOfType(parameters[i]))
				{
					array[i] = parameters[i];
				}
				else if (this.Parameters[i].ParameterType.IsInstanceOfType(parameters[i].Value))
				{
					array[i] = parameters[i].Value;
				}
				else
				{
					array[i] = visitor.Global.Marshaller.MarshalJsValue<object>(parameters[i]);
				}
			}
			object obj;
			try
			{
				obj = this.Delegate.DynamicInvoke(array);
			}
			catch (global::System.Reflection.TargetInvocationException ex)
			{
				throw ex.InnerException;
			}
			catch (global::System.Exception ex2)
			{
				if (ex2.InnerException is global::Jint.Native.JsException)
				{
					throw ex2.InnerException;
				}
				throw;
			}
			if (obj != null)
			{
				if (typeof(global::Jint.Native.JsInstance).IsInstanceOfType(obj))
				{
					visitor.Return((global::Jint.Native.JsInstance)obj);
				}
				else
				{
					visitor.Return(visitor.Global.WrapClr(obj));
				}
			}
			else
			{
				visitor.Return(global::Jint.Native.JsUndefined.Instance);
			}
			return null;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x000053DC File Offset: 0x000035DC
		public override string ToString()
		{
			return string.Format("function {0}() { [native code] }", this.Delegate.Method.Name);
		}

		// Token: 0x0400003B RID: 59
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::System.Delegate <Delegate>k__BackingField;

		// Token: 0x0400003C RID: 60
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::System.Reflection.ParameterInfo[] <Parameters>k__BackingField;
	}
}
