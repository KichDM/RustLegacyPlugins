using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Jint.Native;

namespace Jint.Marshal
{
	// Token: 0x0200000C RID: 12
	internal class ProxyHelper
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000021 RID: 33 RVA: 0x000026F8 File Offset: 0x000008F8
		public static global::Jint.Marshal.ProxyHelper Default
		{
			get
			{
				global::Jint.Marshal.ProxyHelper @default;
				lock (typeof(global::Jint.Marshal.ProxyHelper))
				{
					if (global::Jint.Marshal.ProxyHelper.m_default == null)
					{
						global::Jint.Marshal.ProxyHelper.m_default = new global::Jint.Marshal.ProxyHelper();
					}
					@default = global::Jint.Marshal.ProxyHelper.m_default;
				}
				return @default;
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002750 File Offset: 0x00000950
		public global::Jint.Marshal.JsMethodImpl WrapMethod(global::System.Reflection.MethodInfo info, bool passGlobal)
		{
			if (info == null)
			{
				throw new global::System.ArgumentNullException("info");
			}
			if (info.ContainsGenericParameters)
			{
				throw new global::System.InvalidOperationException("Can't wrap an unclosed generic");
			}
			global::Jint.Marshal.JsMethodImpl jsMethodImpl;
			lock (this.methodCache)
			{
				if (this.methodCache.TryGetValue(info, out jsMethodImpl))
				{
					return jsMethodImpl;
				}
			}
			global::System.Collections.Generic.LinkedList<global::System.Reflection.ParameterInfo> linkedList = new global::System.Collections.Generic.LinkedList<global::System.Reflection.ParameterInfo>(info.GetParameters());
			global::System.Collections.Generic.LinkedList<global::Jint.Marshal.ProxyHelper.MarshalledParameter> linkedList2 = new global::System.Collections.Generic.LinkedList<global::Jint.Marshal.ProxyHelper.MarshalledParameter>();
			global::System.Reflection.Emit.DynamicMethod dynamicMethod = new global::System.Reflection.Emit.DynamicMethod("jsWrapper", typeof(global::Jint.Native.JsInstance), new global::System.Type[]
			{
				typeof(global::Jint.Native.IGlobal),
				typeof(global::Jint.Native.JsInstance),
				typeof(global::Jint.Native.JsInstance[])
			}, base.GetType());
			global::System.Reflection.Emit.ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
			ilgenerator.DeclareLocal(typeof(int));
			ilgenerator.DeclareLocal(typeof(global::Jint.Marshaller));
			ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_0);
			ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, typeof(global::Jint.Native.IGlobal).GetProperty("Marshaller").GetGetMethod());
			if (!info.ReturnType.Equals(typeof(void)))
			{
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Dup);
			}
			ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Stloc_1);
			if (!info.IsStatic)
			{
				global::System.Reflection.Emit.Label label = ilgenerator.DefineLabel();
				global::System.Reflection.Emit.Label label2 = ilgenerator.DefineLabel();
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldloc_1);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_1);
				if (info.DeclaringType.IsValueType)
				{
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, typeof(global::Jint.Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(new global::System.Type[]
					{
						info.DeclaringType
					}));
				}
				else
				{
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, typeof(global::Jint.Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(new global::System.Type[]
					{
						info.DeclaringType
					}));
				}
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Dup);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldnull);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Beq, label2);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Br, label);
				ilgenerator.MarkLabel(label2);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldstr, "The specified 'that' object is not acceptable for this method");
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Newobj, typeof(global::Jint.JintException).GetConstructor(new global::System.Type[]
				{
					typeof(string)
				}));
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Throw);
				ilgenerator.MarkLabel(label);
				if (info.DeclaringType.IsValueType)
				{
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Unbox, info.DeclaringType);
				}
			}
			if (passGlobal && linkedList.First != null && typeof(global::Jint.Native.IGlobal).IsAssignableFrom(linkedList.First.Value.ParameterType))
			{
				linkedList.RemoveFirst();
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_0);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Isinst, typeof(global::Jint.Native.IGlobal));
			}
			ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_2);
			ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldlen);
			ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Stloc_0);
			int num = 0;
			foreach (global::System.Reflection.ParameterInfo parameterInfo in linkedList)
			{
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldloc_1);
				global::System.Reflection.Emit.Label label3 = ilgenerator.DefineLabel();
				global::System.Reflection.Emit.Label label4 = ilgenerator.DefineLabel();
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldloc_0);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldc_I4, num);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ble, label3);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_2);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldc_I4, num);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldelem, typeof(global::Jint.Native.JsInstance));
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Br, label4);
				ilgenerator.MarkLabel(label3);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldsfld, typeof(global::Jint.Native.JsUndefined).GetField("Instance"));
				ilgenerator.MarkLabel(label4);
				if (parameterInfo.ParameterType.IsByRef)
				{
					global::System.Type elementType = parameterInfo.ParameterType.GetElementType();
					global::System.Reflection.Emit.LocalBuilder localBuilder = ilgenerator.DeclareLocal(elementType);
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, typeof(global::Jint.Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(new global::System.Type[]
					{
						elementType
					}));
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Stloc, localBuilder.LocalIndex);
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldloca, localBuilder.LocalIndex);
					if (parameterInfo.IsOut)
					{
						linkedList2.AddLast(new global::Jint.Marshal.ProxyHelper.MarshalledParameter(localBuilder, num));
					}
				}
				else
				{
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, typeof(global::Jint.Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(new global::System.Type[]
					{
						parameterInfo.ParameterType
					}));
				}
				num++;
			}
			if (!info.IsStatic)
			{
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Callvirt, info);
			}
			else
			{
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, info);
			}
			foreach (global::Jint.Marshal.ProxyHelper.MarshalledParameter marshalledParameter in linkedList2)
			{
				global::System.Reflection.Emit.Label label5 = ilgenerator.DefineLabel();
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldloc_0);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldc_I4, marshalledParameter.index);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ble, label5);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_2);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldc_I4, marshalledParameter.index);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldloc_1);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldloc, marshalledParameter.tempLocal);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, typeof(global::Jint.Marshaller).GetMethod("MarshalClrValue").MakeGenericMethod(new global::System.Type[]
				{
					marshalledParameter.tempLocal.LocalType
				}));
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Stelem, typeof(global::Jint.Native.JsInstance));
				ilgenerator.MarkLabel(label5);
			}
			if (!info.ReturnType.Equals(typeof(void)))
			{
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, typeof(global::Jint.Marshaller).GetMethod("MarshalClrValue").MakeGenericMethod(new global::System.Type[]
				{
					info.ReturnType
				}));
			}
			else
			{
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldsfld, typeof(global::Jint.Native.JsUndefined).GetField("Instance"));
			}
			ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ret);
			jsMethodImpl = (global::Jint.Marshal.JsMethodImpl)dynamicMethod.CreateDelegate(typeof(global::Jint.Marshal.JsMethodImpl));
			lock (this.methodCache)
			{
				this.methodCache[info] = jsMethodImpl;
			}
			return jsMethodImpl;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002EF8 File Offset: 0x000010F8
		public global::Jint.Marshal.ConstructorImpl WrapConstructor(global::System.Reflection.ConstructorInfo info, bool passGlobal)
		{
			if (info == null)
			{
				throw new global::System.ArgumentNullException("info");
			}
			global::Jint.Marshal.ConstructorImpl constructorImpl;
			lock (this.ctorCache)
			{
				if (this.ctorCache.TryGetValue(info, out constructorImpl))
				{
					return constructorImpl;
				}
			}
			global::System.Collections.Generic.LinkedList<global::System.Reflection.ParameterInfo> linkedList = new global::System.Collections.Generic.LinkedList<global::System.Reflection.ParameterInfo>(info.GetParameters());
			global::System.Reflection.Emit.DynamicMethod dynamicMethod = new global::System.Reflection.Emit.DynamicMethod("clrConstructor", typeof(object), new global::System.Type[]
			{
				typeof(global::Jint.Native.IGlobal),
				typeof(global::Jint.Native.JsInstance[])
			}, base.GetType());
			global::System.Reflection.Emit.ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
			ilgenerator.DeclareLocal(typeof(int));
			if (passGlobal && linkedList.First != null && typeof(global::Jint.Native.IGlobal).IsAssignableFrom(linkedList.First.Value.ParameterType))
			{
				linkedList.RemoveFirst();
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_0);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Isinst, typeof(global::Jint.Native.IGlobal));
			}
			ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_1);
			ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldlen);
			ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Stloc_0);
			int num = 0;
			foreach (global::System.Reflection.ParameterInfo parameterInfo in linkedList)
			{
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_0);
				ilgenerator.EmitCall(global::System.Reflection.Emit.OpCodes.Call, typeof(global::Jint.Native.IGlobal).GetProperty("Marshaller").GetGetMethod(), null);
				global::System.Reflection.Emit.Label label = ilgenerator.DefineLabel();
				global::System.Reflection.Emit.Label label2 = ilgenerator.DefineLabel();
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldloc_0);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldc_I4, num);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ble, label);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_1);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldc_I4, num);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldelem, typeof(global::Jint.Native.JsInstance));
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Br, label2);
				ilgenerator.MarkLabel(label);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldsfld, typeof(global::Jint.Native.JsUndefined).GetField("Instance"));
				ilgenerator.MarkLabel(label2);
				if (parameterInfo.ParameterType.IsByRef)
				{
					global::System.Type elementType = parameterInfo.ParameterType.GetElementType();
					global::System.Reflection.Emit.LocalBuilder localBuilder = ilgenerator.DeclareLocal(elementType);
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, typeof(global::Jint.Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(new global::System.Type[]
					{
						elementType
					}));
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Stloc, localBuilder.LocalIndex);
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldloca, localBuilder.LocalIndex);
				}
				else
				{
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, typeof(global::Jint.Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(new global::System.Type[]
					{
						parameterInfo.ParameterType
					}));
				}
				num++;
			}
			ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Newobj, info);
			if (info.DeclaringType.IsValueType)
			{
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Box, info.DeclaringType);
			}
			ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ret);
			constructorImpl = (global::Jint.Marshal.ConstructorImpl)dynamicMethod.CreateDelegate(typeof(global::Jint.Marshal.ConstructorImpl));
			lock (this.ctorCache)
			{
				this.ctorCache[info] = constructorImpl;
			}
			return constructorImpl;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000032EC File Offset: 0x000014EC
		public global::Jint.Marshal.JsGetter WrapGetProperty(global::System.Reflection.PropertyInfo prop, global::Jint.Marshaller marshaller)
		{
			if (prop == null)
			{
				throw new global::System.ArgumentNullException("prop");
			}
			global::System.Reflection.Emit.DynamicMethod dynamicMethod;
			lock (this.propGetCache)
			{
				this.propGetCache.TryGetValue(prop, out dynamicMethod);
			}
			if (dynamicMethod == null)
			{
				dynamicMethod = new global::System.Reflection.Emit.DynamicMethod("dynamicPropertyGetter", typeof(global::Jint.Native.JsInstance), new global::System.Type[]
				{
					typeof(global::Jint.Marshaller),
					typeof(global::Jint.Native.JsDictionaryObject)
				}, base.GetType());
				global::System.Reflection.MethodInfo getMethod = prop.GetGetMethod();
				global::System.Reflection.Emit.ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_0);
				if (!getMethod.IsStatic)
				{
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Dup);
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_1);
					if (prop.DeclaringType.IsValueType)
					{
						ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Callvirt, typeof(global::Jint.Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(new global::System.Type[]
						{
							prop.DeclaringType
						}));
						ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Unbox, prop.DeclaringType);
					}
					else
					{
						ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Callvirt, typeof(global::Jint.Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(new global::System.Type[]
						{
							prop.DeclaringType
						}));
					}
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Callvirt, getMethod);
				}
				else
				{
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, getMethod);
				}
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, typeof(global::Jint.Marshaller).GetMethod("MarshalClrValue").MakeGenericMethod(new global::System.Type[]
				{
					prop.PropertyType
				}));
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ret);
				lock (this.propGetCache)
				{
					this.propGetCache[prop] = dynamicMethod;
				}
			}
			return (global::Jint.Marshal.JsGetter)dynamicMethod.CreateDelegate(typeof(global::Jint.Marshal.JsGetter), marshaller);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00003520 File Offset: 0x00001720
		public global::Jint.Marshal.JsGetter WrapGetField(global::System.Reflection.FieldInfo field, global::Jint.Marshaller marshaller)
		{
			if (field == null)
			{
				throw new global::System.ArgumentNullException("field");
			}
			global::System.Reflection.Emit.DynamicMethod dynamicMethod;
			lock (this.fieldGetCache)
			{
				this.fieldGetCache.TryGetValue(field, out dynamicMethod);
			}
			if (dynamicMethod == null)
			{
				dynamicMethod = new global::System.Reflection.Emit.DynamicMethod("dynamicFieldGetter", typeof(global::Jint.Native.JsInstance), new global::System.Type[]
				{
					typeof(global::Jint.Marshaller),
					typeof(global::Jint.Native.JsDictionaryObject)
				}, base.GetType());
				global::System.Reflection.Emit.ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_0);
				if (!field.IsStatic)
				{
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Dup);
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_1);
					if (field.DeclaringType.IsValueType)
					{
						ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Callvirt, typeof(global::Jint.Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(new global::System.Type[]
						{
							field.DeclaringType
						}));
						ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Unbox, field.DeclaringType);
					}
					else
					{
						ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Callvirt, typeof(global::Jint.Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(new global::System.Type[]
						{
							field.DeclaringType
						}));
					}
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldfld, field);
				}
				else
				{
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldsfld, field);
				}
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, typeof(global::Jint.Marshaller).GetMethod("MarshalClrValue").MakeGenericMethod(new global::System.Type[]
				{
					field.FieldType
				}));
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ret);
				lock (this.fieldGetCache)
				{
					this.fieldGetCache[field] = dynamicMethod;
				}
			}
			return (global::Jint.Marshal.JsGetter)dynamicMethod.CreateDelegate(typeof(global::Jint.Marshal.JsGetter), marshaller);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00003740 File Offset: 0x00001940
		public global::Jint.Marshal.JsSetter WrapSetProperty(global::System.Reflection.PropertyInfo prop, global::Jint.Marshaller marshaller)
		{
			if (prop == null)
			{
				throw new global::System.ArgumentNullException("prop");
			}
			global::System.Reflection.Emit.DynamicMethod dynamicMethod;
			lock (this.propSetCache)
			{
				this.propSetCache.TryGetValue(prop, out dynamicMethod);
			}
			if (dynamicMethod == null)
			{
				dynamicMethod = new global::System.Reflection.Emit.DynamicMethod("dynamicPropertySetter", null, new global::System.Type[]
				{
					typeof(global::Jint.Marshaller),
					typeof(global::Jint.Native.JsDictionaryObject),
					typeof(global::Jint.Native.JsInstance)
				}, base.GetType());
				global::System.Reflection.MethodInfo setMethod = prop.GetSetMethod();
				global::System.Reflection.Emit.ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
				if (!setMethod.IsStatic)
				{
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_0);
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_1);
					if (prop.DeclaringType.IsValueType)
					{
						ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, typeof(global::Jint.Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(new global::System.Type[]
						{
							prop.DeclaringType
						}));
						ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Unbox, prop.DeclaringType);
					}
					else
					{
						ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Callvirt, typeof(global::Jint.Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(new global::System.Type[]
						{
							prop.DeclaringType
						}));
					}
				}
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_0);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_2);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Callvirt, typeof(global::Jint.Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(new global::System.Type[]
				{
					prop.PropertyType
				}));
				if (setMethod.IsStatic)
				{
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, setMethod);
				}
				else
				{
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Callvirt, setMethod);
				}
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ret);
				lock (this.propSetCache)
				{
					this.propSetCache[prop] = dynamicMethod;
				}
			}
			return (global::Jint.Marshal.JsSetter)dynamicMethod.CreateDelegate(typeof(global::Jint.Marshal.JsSetter), marshaller);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00003994 File Offset: 0x00001B94
		public global::Jint.Marshal.JsSetter WrapSetField(global::System.Reflection.FieldInfo field, global::Jint.Marshaller marshaller)
		{
			if (field == null)
			{
				throw new global::System.ArgumentNullException("field");
			}
			global::System.Reflection.Emit.DynamicMethod dynamicMethod;
			lock (this.fieldSetCache)
			{
				this.fieldSetCache.TryGetValue(field, out dynamicMethod);
			}
			if (dynamicMethod == null)
			{
				dynamicMethod = new global::System.Reflection.Emit.DynamicMethod("dynamicPropertySetter", null, new global::System.Type[]
				{
					typeof(global::Jint.Marshaller),
					typeof(global::Jint.Native.JsDictionaryObject),
					typeof(global::Jint.Native.JsInstance)
				}, base.GetType());
				global::System.Reflection.Emit.ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
				if (!field.IsStatic)
				{
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_0);
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_1);
					if (field.DeclaringType.IsValueType)
					{
						ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Callvirt, typeof(global::Jint.Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(new global::System.Type[]
						{
							field.DeclaringType
						}));
						ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Unbox, field.DeclaringType);
					}
					else
					{
						ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Callvirt, typeof(global::Jint.Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(new global::System.Type[]
						{
							field.DeclaringType
						}));
					}
				}
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_0);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_2);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Callvirt, typeof(global::Jint.Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(new global::System.Type[]
				{
					field.FieldType
				}));
				if (field.IsStatic)
				{
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Stsfld, field);
				}
				else
				{
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Stfld, field);
				}
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ret);
				lock (this.fieldSetCache)
				{
					this.fieldSetCache[field] = dynamicMethod;
				}
			}
			return (global::Jint.Marshal.JsSetter)dynamicMethod.CreateDelegate(typeof(global::Jint.Marshal.JsSetter), marshaller);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00003BD4 File Offset: 0x00001DD4
		public global::Jint.Marshal.JsIndexerGetter WrapIndexerGetter(global::System.Reflection.MethodInfo getMethod, global::Jint.Marshaller marshaller)
		{
			if (getMethod == null)
			{
				throw new global::System.ArgumentNullException("getMethod");
			}
			global::System.Reflection.Emit.DynamicMethod dynamicMethod;
			lock (this.indexerGetCache)
			{
				this.indexerGetCache.TryGetValue(getMethod, out dynamicMethod);
			}
			if (dynamicMethod == null)
			{
				if (getMethod.GetParameters().Length != 1 || getMethod.ReturnType.Equals(typeof(void)))
				{
					throw new global::System.ArgumentException("Invalid getter", "getMethod");
				}
				dynamicMethod = new global::System.Reflection.Emit.DynamicMethod("dynamicIndexerSetter", typeof(global::Jint.Native.JsInstance), new global::System.Type[]
				{
					typeof(global::Jint.Marshaller),
					typeof(global::Jint.Native.JsInstance),
					typeof(global::Jint.Native.JsInstance)
				}, base.GetType());
				global::System.Reflection.Emit.ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_0);
				if (!getMethod.IsStatic)
				{
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_0);
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_1);
					if (getMethod.DeclaringType.IsValueType)
					{
						ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, typeof(global::Jint.Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(new global::System.Type[]
						{
							getMethod.DeclaringType
						}));
						ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Unbox, getMethod.DeclaringType);
					}
					else
					{
						ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, typeof(global::Jint.Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(new global::System.Type[]
						{
							getMethod.DeclaringType
						}));
					}
				}
				global::System.Reflection.ParameterInfo parameterInfo = getMethod.GetParameters()[0];
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_0);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_2);
				if (parameterInfo.ParameterType.IsByRef)
				{
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, typeof(global::Jint.Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(new global::System.Type[]
					{
						parameterInfo.ParameterType
					}));
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Unbox, parameterInfo.ParameterType);
				}
				else
				{
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, typeof(global::Jint.Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(new global::System.Type[]
					{
						parameterInfo.ParameterType
					}));
				}
				if (getMethod.IsStatic)
				{
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, getMethod);
				}
				else
				{
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Callvirt, getMethod);
				}
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Callvirt, typeof(global::Jint.Marshaller).GetMethod("MarshalClrValue").MakeGenericMethod(new global::System.Type[]
				{
					getMethod.ReturnType
				}));
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ret);
				lock (this.indexerGetCache)
				{
					this.indexerGetCache[getMethod] = dynamicMethod;
				}
			}
			return (global::Jint.Marshal.JsIndexerGetter)dynamicMethod.CreateDelegate(typeof(global::Jint.Marshal.JsIndexerGetter), marshaller);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00003F10 File Offset: 0x00002110
		public global::Jint.Marshal.JsIndexerSetter WrapIndexerSetter(global::System.Reflection.MethodInfo setMethod, global::Jint.Marshaller marshaller)
		{
			if (setMethod == null)
			{
				throw new global::System.ArgumentNullException("getMethod");
			}
			global::System.Reflection.Emit.DynamicMethod dynamicMethod;
			lock (this.indexerSetCache)
			{
				this.indexerSetCache.TryGetValue(setMethod, out dynamicMethod);
			}
			if (dynamicMethod == null)
			{
				if (setMethod.GetParameters().Length != 2 || !setMethod.ReturnType.Equals(typeof(void)))
				{
					throw new global::System.ArgumentException("Invalid getter", "getMethod");
				}
				dynamicMethod = new global::System.Reflection.Emit.DynamicMethod("dynamicIndexerSetter", typeof(void), new global::System.Type[]
				{
					typeof(global::Jint.Marshaller),
					typeof(global::Jint.Native.JsInstance),
					typeof(global::Jint.Native.JsInstance),
					typeof(global::Jint.Native.JsInstance)
				}, base.GetType());
				global::System.Reflection.Emit.ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
				if (!setMethod.IsStatic)
				{
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_0);
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_1);
					if (setMethod.DeclaringType.IsValueType)
					{
						ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Callvirt, typeof(global::Jint.Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(new global::System.Type[]
						{
							setMethod.DeclaringType
						}));
						ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Unbox, setMethod.DeclaringType);
					}
					else
					{
						ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Callvirt, typeof(global::Jint.Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(new global::System.Type[]
						{
							setMethod.DeclaringType
						}));
					}
				}
				global::System.Reflection.ParameterInfo parameterInfo = setMethod.GetParameters()[0];
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_0);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_2);
				if (parameterInfo.ParameterType.IsByRef)
				{
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, typeof(global::Jint.Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(new global::System.Type[]
					{
						parameterInfo.ParameterType
					}));
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Unbox, parameterInfo.ParameterType);
				}
				else
				{
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, typeof(global::Jint.Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(new global::System.Type[]
					{
						parameterInfo.ParameterType
					}));
				}
				global::System.Reflection.ParameterInfo parameterInfo2 = setMethod.GetParameters()[1];
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_0);
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_3);
				if (parameterInfo2.ParameterType.IsByRef)
				{
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, typeof(global::Jint.Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(new global::System.Type[]
					{
						parameterInfo2.ParameterType
					}));
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Unbox, parameterInfo2.ParameterType);
				}
				else
				{
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, typeof(global::Jint.Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(new global::System.Type[]
					{
						parameterInfo2.ParameterType
					}));
				}
				if (setMethod.IsStatic)
				{
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Call, setMethod);
				}
				else
				{
					ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Callvirt, setMethod);
				}
				ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ret);
				lock (this.indexerSetCache)
				{
					this.indexerSetCache[setMethod] = dynamicMethod;
				}
			}
			return (global::Jint.Marshal.JsIndexerSetter)dynamicMethod.CreateDelegate(typeof(global::Jint.Marshal.JsIndexerSetter), marshaller);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000042DC File Offset: 0x000024DC
		public ProxyHelper()
		{
		}

		// Token: 0x0400000A RID: 10
		private static global::Jint.Marshal.ProxyHelper m_default;

		// Token: 0x0400000B RID: 11
		private global::System.Collections.Generic.Dictionary<global::System.Reflection.MethodInfo, global::Jint.Marshal.JsMethodImpl> methodCache = new global::System.Collections.Generic.Dictionary<global::System.Reflection.MethodInfo, global::Jint.Marshal.JsMethodImpl>();

		// Token: 0x0400000C RID: 12
		private global::System.Collections.Generic.Dictionary<global::System.Reflection.ConstructorInfo, global::Jint.Marshal.ConstructorImpl> ctorCache = new global::System.Collections.Generic.Dictionary<global::System.Reflection.ConstructorInfo, global::Jint.Marshal.ConstructorImpl>();

		// Token: 0x0400000D RID: 13
		private global::System.Collections.Generic.Dictionary<global::System.Reflection.PropertyInfo, global::System.Reflection.Emit.DynamicMethod> propGetCache = new global::System.Collections.Generic.Dictionary<global::System.Reflection.PropertyInfo, global::System.Reflection.Emit.DynamicMethod>();

		// Token: 0x0400000E RID: 14
		private global::System.Collections.Generic.Dictionary<global::System.Reflection.PropertyInfo, global::System.Reflection.Emit.DynamicMethod> propSetCache = new global::System.Collections.Generic.Dictionary<global::System.Reflection.PropertyInfo, global::System.Reflection.Emit.DynamicMethod>();

		// Token: 0x0400000F RID: 15
		private global::System.Collections.Generic.Dictionary<global::System.Reflection.FieldInfo, global::System.Reflection.Emit.DynamicMethod> fieldSetCache = new global::System.Collections.Generic.Dictionary<global::System.Reflection.FieldInfo, global::System.Reflection.Emit.DynamicMethod>();

		// Token: 0x04000010 RID: 16
		private global::System.Collections.Generic.Dictionary<global::System.Reflection.FieldInfo, global::System.Reflection.Emit.DynamicMethod> fieldGetCache = new global::System.Collections.Generic.Dictionary<global::System.Reflection.FieldInfo, global::System.Reflection.Emit.DynamicMethod>();

		// Token: 0x04000011 RID: 17
		private global::System.Collections.Generic.Dictionary<global::System.Reflection.MethodInfo, global::System.Reflection.Emit.DynamicMethod> indexerGetCache = new global::System.Collections.Generic.Dictionary<global::System.Reflection.MethodInfo, global::System.Reflection.Emit.DynamicMethod>();

		// Token: 0x04000012 RID: 18
		private global::System.Collections.Generic.Dictionary<global::System.Reflection.MethodInfo, global::System.Reflection.Emit.DynamicMethod> indexerSetCache = new global::System.Collections.Generic.Dictionary<global::System.Reflection.MethodInfo, global::System.Reflection.Emit.DynamicMethod>();

		// Token: 0x020000DE RID: 222
		private struct MarshalledParameter
		{
			// Token: 0x06000A23 RID: 2595 RVA: 0x000359BC File Offset: 0x00033BBC
			public MarshalledParameter(global::System.Reflection.Emit.LocalBuilder temp, int index)
			{
				this.tempLocal = temp;
				this.index = index;
			}

			// Token: 0x04000431 RID: 1073
			public global::System.Reflection.Emit.LocalBuilder tempLocal;

			// Token: 0x04000432 RID: 1074
			public int index;
		}
	}
}
