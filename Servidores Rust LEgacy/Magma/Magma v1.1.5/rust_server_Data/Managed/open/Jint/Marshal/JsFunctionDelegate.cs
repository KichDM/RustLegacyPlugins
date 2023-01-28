using System;
using System.Reflection;
using System.Reflection.Emit;
using Jint.Expressions;
using Jint.Native;

namespace Jint.Marshal
{
	// Token: 0x0200000A RID: 10
	internal class JsFunctionDelegate
	{
		// Token: 0x0600001D RID: 29 RVA: 0x00002170 File Offset: 0x00000370
		public JsFunctionDelegate(global::Jint.Expressions.IJintVisitor visitor, global::Jint.Native.JsFunction function, global::Jint.Native.JsDictionaryObject that, global::System.Type delegateType)
		{
			if (visitor == null)
			{
				throw new global::System.ArgumentNullException("visitor");
			}
			if (function == null)
			{
				throw new global::System.ArgumentNullException("function");
			}
			if (delegateType == null)
			{
				throw new global::System.ArgumentNullException("delegateType");
			}
			if (!typeof(global::System.Delegate).IsAssignableFrom(delegateType))
			{
				throw new global::System.ArgumentException("A delegate type is required", "delegateType");
			}
			this.m_visitor = visitor;
			this.m_function = function;
			this.m_delegateType = delegateType;
			this.m_that = that;
			this.m_marshaller = visitor.Global.Marshaller;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002210 File Offset: 0x00000410
		public global::System.Delegate GetDelegate()
		{
			if (this.m_impl != null)
			{
				return this.m_impl;
			}
			global::System.Reflection.MethodInfo method = this.m_delegateType.GetMethod("Invoke");
			global::System.Reflection.ParameterInfo[] parameters = method.GetParameters();
			global::System.Type[] array = new global::System.Type[parameters.Length + 1];
			for (int i = 1; i <= parameters.Length; i++)
			{
				array[i] = parameters[i - 1].ParameterType;
			}
			array[0] = typeof(global::Jint.Marshal.JsFunctionDelegate);
			global::System.Reflection.Emit.DynamicMethod dynamicMethod = new global::System.Reflection.Emit.DynamicMethod("DelegateWrapper", method.ReturnType, array, typeof(global::Jint.Marshal.JsFunctionDelegate));
			global::System.Reflection.Emit.ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
			ilgenerator.DeclareLocal(typeof(global::Jint.Native.JsInstance[]));
			ilgenerator.DeclareLocal(typeof(global::Jint.Marshaller));
			ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldc_I4, parameters.Length);
			ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Newarr, typeof(global::Jint.Native.JsInstance));
			ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Stloc_0);
			ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_0);
			ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldfld, typeof(global::Jint.Marshal.JsFunctionDelegate).GetField("m_marshaller", global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.NonPublic));
			ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Stloc_1);
			for (int j = 1; j <= parameters.Length; j++)
			{
				global::System.Reflection.ParameterInfo parameterInfo = parameters[j - 1];
				global::System.Type type = parameterInfo.ParameterType;
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldloc_0);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldc_I4, j - 1);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldloc_1);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg, j);
				if (type.IsByRef)
				{
					type = type.GetElementType();
					if (parameterInfo.IsOut && !parameterInfo.IsIn)
					{
						ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg, j);
						ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Initobj);
					}
					if (type.IsValueType)
					{
						ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldobj, type);
					}
					else
					{
						ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldind_Ref);
					}
				}
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, typeof(global::Jint.Marshaller).GetMethod("MarshalClrValue").MakeGenericMethod(new global::System.Type[]
				{
					type
				}));
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Stelem, typeof(global::Jint.Native.JsInstance));
			}
			ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_0);
			ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldfld, typeof(global::Jint.Marshal.JsFunctionDelegate).GetField("m_visitor", global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.NonPublic));
			ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_0);
			ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldfld, typeof(global::Jint.Marshal.JsFunctionDelegate).GetField("m_function", global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.NonPublic));
			ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_0);
			ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldfld, typeof(global::Jint.Marshal.JsFunctionDelegate).GetField("m_that", global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.NonPublic));
			ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldloc_0);
			ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Callvirt, typeof(global::Jint.Expressions.IJintVisitor).GetMethod("ExecuteFunction"));
			for (int k = 1; k <= parameters.Length; k++)
			{
				global::System.Reflection.ParameterInfo parameterInfo2 = parameters[k - 1];
				global::System.Type elementType = parameterInfo2.ParameterType.GetElementType();
				if (parameterInfo2.IsOut)
				{
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg, k);
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldloc_1);
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldloc_0);
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldc_I4, k - 1);
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldelem, typeof(global::Jint.Native.JsInstance));
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, typeof(global::Jint.Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(new global::System.Type[]
					{
						elementType
					}));
					if (elementType.IsValueType)
					{
						ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Stobj, elementType);
					}
					else
					{
						ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Stind_Ref);
					}
				}
			}
			if (!method.ReturnType.Equals(typeof(void)))
			{
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldloc_1);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_0);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldfld, typeof(global::Jint.Marshal.JsFunctionDelegate).GetField("m_visitor", global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.NonPublic));
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, typeof(global::Jint.Expressions.IJintVisitor).GetProperty("Returned").GetGetMethod());
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, typeof(global::Jint.Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(new global::System.Type[]
				{
					method.ReturnType
				}));
			}
			ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ret);
			return this.m_impl = dynamicMethod.CreateDelegate(this.m_delegateType, this);
		}

		// Token: 0x04000004 RID: 4
		private global::System.Delegate m_impl;

		// Token: 0x04000005 RID: 5
		private global::Jint.Expressions.IJintVisitor m_visitor;

		// Token: 0x04000006 RID: 6
		private global::Jint.Native.JsFunction m_function;

		// Token: 0x04000007 RID: 7
		private global::Jint.Native.JsDictionaryObject m_that;

		// Token: 0x04000008 RID: 8
		private global::Jint.Marshaller m_marshaller;

		// Token: 0x04000009 RID: 9
		private global::System.Type m_delegateType;
	}
}
