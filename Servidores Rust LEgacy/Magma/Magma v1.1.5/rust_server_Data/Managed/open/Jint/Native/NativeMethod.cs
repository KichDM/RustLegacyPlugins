using System;
using System.Reflection;
using Jint.Expressions;
using Jint.Marshal;

namespace Jint.Native
{
	// Token: 0x0200001F RID: 31
	public class NativeMethod : global::Jint.Native.JsFunction
	{
		// Token: 0x06000108 RID: 264 RVA: 0x00007364 File Offset: 0x00005564
		public NativeMethod(global::Jint.Marshal.JsMethodImpl impl, global::System.Reflection.MethodInfo nativeMethod, global::Jint.Native.JsObject prototype) : base(prototype)
		{
			if (impl == null)
			{
				throw new global::System.ArgumentNullException("impl");
			}
			this.m_nativeMethod = nativeMethod;
			this.m_impl = impl;
			if (nativeMethod != null)
			{
				base.Name = nativeMethod.Name;
				foreach (global::System.Reflection.ParameterInfo parameterInfo in nativeMethod.GetParameters())
				{
					base.Arguments.Add(parameterInfo.Name);
				}
			}
		}

		// Token: 0x06000109 RID: 265 RVA: 0x000073E0 File Offset: 0x000055E0
		public NativeMethod(global::Jint.Marshal.JsMethodImpl impl, global::Jint.Native.JsObject prototype) : this(impl, null, prototype)
		{
			foreach (global::System.Reflection.ParameterInfo parameterInfo in impl.Method.GetParameters())
			{
				base.Arguments.Add(parameterInfo.Name);
			}
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00007430 File Offset: 0x00005630
		public NativeMethod(global::System.Reflection.MethodInfo info, global::Jint.Native.JsObject prototype, global::Jint.Native.IGlobal global) : base(prototype)
		{
			if (info == null)
			{
				throw new global::System.ArgumentNullException("info");
			}
			if (global == null)
			{
				throw new global::System.ArgumentNullException("global");
			}
			this.m_nativeMethod = info;
			this.m_impl = global.Marshaller.WrapMethod(info, true);
			base.Name = info.Name;
			foreach (global::System.Reflection.ParameterInfo parameterInfo in info.GetParameters())
			{
				base.Arguments.Add(parameterInfo.Name);
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600010B RID: 267 RVA: 0x000074C4 File Offset: 0x000056C4
		public override bool IsClr
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600010C RID: 268 RVA: 0x000074C8 File Offset: 0x000056C8
		public global::System.Reflection.MethodInfo GetWrappedMethod()
		{
			return this.m_nativeMethod;
		}

		// Token: 0x0600010D RID: 269 RVA: 0x000074D0 File Offset: 0x000056D0
		public override global::Jint.Native.JsInstance Execute(global::Jint.Expressions.IJintVisitor visitor, global::Jint.Native.JsDictionaryObject that, global::Jint.Native.JsInstance[] parameters)
		{
			visitor.Return(this.m_impl(visitor.Global, that, parameters));
			return that;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x000074FC File Offset: 0x000056FC
		public override global::Jint.Native.JsObject Construct(global::Jint.Native.JsInstance[] parameters, global::System.Type[] genericArgs, global::Jint.Expressions.IJintVisitor visitor)
		{
			throw new global::Jint.JintException("This method can't be used as a constructor");
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00007508 File Offset: 0x00005708
		public override string GetBody()
		{
			return "[native code]";
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00007510 File Offset: 0x00005710
		public override global::Jint.Native.JsInstance ToPrimitive(global::Jint.Native.IGlobal global)
		{
			return global.StringClass.New(this.ToString());
		}

		// Token: 0x04000063 RID: 99
		private global::System.Reflection.MethodInfo m_nativeMethod;

		// Token: 0x04000064 RID: 100
		private global::Jint.Marshal.JsMethodImpl m_impl;
	}
}
