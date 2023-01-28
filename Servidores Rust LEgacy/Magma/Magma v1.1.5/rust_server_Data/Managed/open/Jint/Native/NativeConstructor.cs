using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Jint.Expressions;
using Jint.Marshal;

namespace Jint.Native
{
	// Token: 0x0200001D RID: 29
	public class NativeConstructor : global::Jint.Native.JsConstructor
	{
		// Token: 0x060000EE RID: 238 RVA: 0x00006640 File Offset: 0x00004840
		public NativeConstructor(global::System.Type type, global::Jint.Native.IGlobal global) : this(type, global, null, global.FunctionClass.PrototypeProperty)
		{
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00006668 File Offset: 0x00004868
		public NativeConstructor(global::System.Type type, global::Jint.Native.IGlobal global, global::Jint.Native.JsObject PrototypePrototype) : this(type, global, PrototypePrototype, global.FunctionClass.PrototypeProperty)
		{
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00006690 File Offset: 0x00004890
		public NativeConstructor(global::System.Type type, global::Jint.Native.IGlobal global, global::Jint.Native.JsObject PrototypePrototype, global::Jint.Native.JsObject prototype) : base(global, prototype)
		{
			if (type == null)
			{
				throw new global::System.ArgumentNullException("type");
			}
			if (type.IsGenericType && type.ContainsGenericParameters)
			{
				throw new global::System.InvalidOperationException("A native constructor can't be built against an open generic");
			}
			this.m_marshaller = global.Marshaller;
			this.reflectedType = type;
			base.Name = type.FullName;
			if (!type.IsAbstract)
			{
				this.m_constructors = type.GetConstructors();
			}
			base.DefineOwnProperty(global::Jint.Native.JsFunction.PROTOTYPE, (PrototypePrototype == null) ? base.Global.ObjectClass.New(this) : base.Global.ObjectClass.New(this, PrototypePrototype), global::Jint.Native.PropertyAttributes.ReadOnly | global::Jint.Native.PropertyAttributes.DontEnum | global::Jint.Native.PropertyAttributes.DontDelete);
			this.m_overloads = new global::Jint.Native.NativeOverloadImpl<global::System.Reflection.ConstructorInfo, global::Jint.Marshal.ConstructorImpl>(this.m_marshaller, new global::Jint.Native.NativeOverloadImpl<global::System.Reflection.ConstructorInfo, global::Jint.Marshal.ConstructorImpl>.GetMembersDelegate(this.GetMembers), new global::Jint.Native.NativeOverloadImpl<global::System.Reflection.ConstructorInfo, global::Jint.Marshal.ConstructorImpl>.WrapMmemberDelegate(this.WrapMember));
			if (type.IsValueType)
			{
				this.m_overloads.DefineCustomOverload(new global::System.Type[0], new global::System.Type[0], (global::Jint.Marshal.ConstructorImpl)global::System.Delegate.CreateDelegate(typeof(global::Jint.Marshal.ConstructorImpl), typeof(global::Jint.Native.NativeConstructor).GetMethod("CreateStruct", global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.NonPublic).MakeGenericMethod(new global::System.Type[]
				{
					type
				})));
			}
			global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.LinkedList<global::System.Reflection.MethodInfo>> dictionary = new global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.LinkedList<global::System.Reflection.MethodInfo>>();
			foreach (global::System.Reflection.MethodInfo methodInfo in type.GetMethods(global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.Public))
			{
				if (!methodInfo.ReturnType.IsByRef)
				{
					if (!dictionary.ContainsKey(methodInfo.Name))
					{
						dictionary[methodInfo.Name] = new global::System.Collections.Generic.LinkedList<global::System.Reflection.MethodInfo>();
					}
					dictionary[methodInfo.Name].AddLast(methodInfo);
				}
			}
			foreach (global::System.Collections.Generic.KeyValuePair<string, global::System.Collections.Generic.LinkedList<global::System.Reflection.MethodInfo>> keyValuePair in dictionary)
			{
				this.DefineOwnProperty(keyValuePair.Key, this.ReflectOverload(keyValuePair.Value));
			}
			foreach (global::System.Reflection.PropertyInfo prop in type.GetProperties(global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.Public))
			{
				this.DefineOwnProperty(base.Global.Marshaller.MarshalPropertyInfo(prop, this));
			}
			foreach (global::System.Reflection.FieldInfo prop2 in type.GetFields(global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.Public))
			{
				this.DefineOwnProperty(base.Global.Marshaller.MarshalFieldInfo(prop2, this));
			}
			if (type.IsEnum)
			{
				string[] names = global::System.Enum.GetNames(type);
				object[] array = new object[names.Length];
				global::System.Enum.GetValues(type).CopyTo(array, 0);
				for (int l = 0; l < names.Length; l++)
				{
					this.DefineOwnProperty(names[l], base.Global.ObjectClass.New(array[l], base.PrototypeProperty));
				}
			}
			foreach (global::System.Type type2 in type.GetNestedTypes(global::System.Reflection.BindingFlags.Public))
			{
				base.DefineOwnProperty(type2.Name, base.Global.Marshaller.MarshalClrValue<global::System.Type>(type2), global::Jint.Native.PropertyAttributes.DontEnum);
			}
			global::System.Collections.Generic.LinkedList<global::System.Reflection.MethodInfo> linkedList = new global::System.Collections.Generic.LinkedList<global::System.Reflection.MethodInfo>();
			global::System.Collections.Generic.LinkedList<global::System.Reflection.MethodInfo> linkedList2 = new global::System.Collections.Generic.LinkedList<global::System.Reflection.MethodInfo>();
			foreach (global::System.Reflection.PropertyInfo propertyInfo in type.GetProperties(global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.Public))
			{
				global::System.Reflection.ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
				if (indexParameters == null || indexParameters.Length == 0)
				{
					this.m_properties.AddLast(global.Marshaller.MarshalPropertyInfo(propertyInfo, this));
				}
				else if (propertyInfo.Name == "Item" && indexParameters.Length == 1)
				{
					if (propertyInfo.CanRead)
					{
						linkedList.AddLast(propertyInfo.GetGetMethod());
					}
					if (propertyInfo.CanWrite)
					{
						linkedList2.AddLast(propertyInfo.GetSetMethod());
					}
				}
			}
			if (linkedList.Count > 0 || linkedList2.Count > 0)
			{
				global::System.Reflection.MethodInfo[] array2 = new global::System.Reflection.MethodInfo[linkedList.Count];
				linkedList.CopyTo(array2, 0);
				global::System.Reflection.MethodInfo[] array3 = new global::System.Reflection.MethodInfo[linkedList2.Count];
				linkedList2.CopyTo(array3, 0);
				this.m_indexer = new global::Jint.Native.NativeIndexer(this.m_marshaller, array2, array3);
			}
			if (this.reflectedType.IsArray)
			{
				this.m_indexer = (global::Jint.Native.INativeIndexer)typeof(global::Jint.Native.NativeArrayIndexer<>).MakeGenericType(new global::System.Type[]
				{
					this.reflectedType.GetElementType()
				}).GetConstructor(new global::System.Type[]
				{
					typeof(global::Jint.Marshaller)
				}).Invoke(new object[]
				{
					this.m_marshaller
				});
			}
			foreach (global::System.Reflection.FieldInfo prop3 in type.GetFields(global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.Public))
			{
				this.m_properties.AddLast(global.Marshaller.MarshalFieldInfo(prop3, this));
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00006BDC File Offset: 0x00004DDC
		private global::Jint.Native.JsFunction ReflectOverload(global::System.Collections.Generic.ICollection<global::System.Reflection.MethodInfo> methods)
		{
			if (methods.Count == 0)
			{
				throw new global::System.ArgumentException("At least one method is required", "methods");
			}
			if (methods.Count == 1)
			{
				using (global::System.Collections.Generic.IEnumerator<global::System.Reflection.MethodInfo> enumerator = methods.GetEnumerator())
				{
					if (!enumerator.MoveNext())
					{
						goto IL_C0;
					}
					global::System.Reflection.MethodInfo methodInfo = enumerator.Current;
					if (methodInfo.ContainsGenericParameters)
					{
						return new global::Jint.Native.NativeMethodOverload(methods, base.Global.FunctionClass.PrototypeProperty, base.Global);
					}
					return new global::Jint.Native.NativeMethod(methodInfo, base.Global.FunctionClass.PrototypeProperty, base.Global);
				}
				goto IL_A3;
				IL_C0:
				throw new global::System.ApplicationException("Unexpected error");
			}
			IL_A3:
			return new global::Jint.Native.NativeMethodOverload(methods, base.Global.FunctionClass.PrototypeProperty, base.Global);
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x00006CC8 File Offset: 0x00004EC8
		public override bool IsClr
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000F3 RID: 243 RVA: 0x00006CCC File Offset: 0x00004ECC
		// (set) Token: 0x060000F4 RID: 244 RVA: 0x00006CD4 File Offset: 0x00004ED4
		public override object Value
		{
			get
			{
				return this.reflectedType;
			}
			set
			{
			}
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00006CD8 File Offset: 0x00004ED8
		public override void InitPrototype(global::Jint.Native.IGlobal global)
		{
			global::Jint.Native.JsObject prototypeProperty = base.PrototypeProperty;
			global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.LinkedList<global::System.Reflection.MethodInfo>> dictionary = new global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.LinkedList<global::System.Reflection.MethodInfo>>();
			foreach (global::System.Reflection.MethodInfo methodInfo in this.reflectedType.GetMethods(global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.Public))
			{
				if (!methodInfo.ReturnType.IsByRef)
				{
					if (!dictionary.ContainsKey(methodInfo.Name))
					{
						dictionary[methodInfo.Name] = new global::System.Collections.Generic.LinkedList<global::System.Reflection.MethodInfo>();
					}
					dictionary[methodInfo.Name].AddLast(methodInfo);
				}
			}
			foreach (global::System.Collections.Generic.KeyValuePair<string, global::System.Collections.Generic.LinkedList<global::System.Reflection.MethodInfo>> keyValuePair in dictionary)
			{
				prototypeProperty[keyValuePair.Key] = this.ReflectOverload(keyValuePair.Value);
			}
			prototypeProperty["toString"] = new global::Jint.Native.NativeMethod(this.reflectedType.GetMethod("ToString", new global::System.Type[0]), base.Global.FunctionClass.PrototypeProperty, base.Global);
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00006DFC File Offset: 0x00004FFC
		private static object CreateStruct<T>(global::Jint.Native.IGlobal global, global::Jint.Native.JsInstance[] args) where T : struct
		{
			return default(T);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00006E1C File Offset: 0x0000501C
		public override global::Jint.Native.JsInstance Execute(global::Jint.Expressions.IJintVisitor visitor, global::Jint.Native.JsDictionaryObject that, global::Jint.Native.JsInstance[] parameters)
		{
			if (that == null || that == global::Jint.Native.JsUndefined.Instance || that == global::Jint.Native.JsNull.Instance || that as global::Jint.Native.IGlobal == visitor.Global)
			{
				throw new global::Jint.JintException("A constructor '" + this.reflectedType.FullName + "' should be applied to the object");
			}
			if (that.Value != null)
			{
				throw new global::Jint.JintException(string.Concat(new string[]
				{
					"Can't apply the constructor '",
					this.reflectedType.FullName,
					"' to already initialized '",
					that.Value.ToString(),
					"'"
				}));
			}
			that.Value = this.CreateInstance(visitor, parameters);
			this.SetupNativeProperties(that);
			((global::Jint.Native.JsObject)that).Indexer = this.m_indexer;
			return that;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00006F08 File Offset: 0x00005108
		public override global::Jint.Native.JsObject Construct(global::Jint.Native.JsInstance[] parameters, global::System.Type[] genericArgs, global::Jint.Expressions.IJintVisitor visitor)
		{
			return (global::Jint.Native.JsObject)this.Wrap<object>(this.CreateInstance(visitor, parameters));
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00006F20 File Offset: 0x00005120
		private object CreateInstance(global::Jint.Expressions.IJintVisitor visitor, global::Jint.Native.JsInstance[] parameters)
		{
			global::Jint.Marshal.ConstructorImpl constructorImpl = this.m_overloads.ResolveOverload(parameters, null);
			if (constructorImpl == null)
			{
				throw new global::Jint.JintException(string.Format("No matching overload found {0}({1})", this.reflectedType.FullName, string.Join(",", global::System.Array.ConvertAll<global::Jint.Native.JsInstance, string>(parameters, (global::Jint.Native.JsInstance p) => p.ToString()))));
			}
			return constructorImpl(visitor.Global, parameters);
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00006FA0 File Offset: 0x000051A0
		public void SetupNativeProperties(global::Jint.Native.JsDictionaryObject target)
		{
			if (target == null || target == global::Jint.Native.JsNull.Instance || target == global::Jint.Native.JsUndefined.Instance)
			{
				throw new global::System.ArgumentException("A valid js object is required", "target");
			}
			foreach (global::Jint.Native.NativeDescriptor src in this.m_properties)
			{
				target.DefineOwnProperty(new global::Jint.Native.NativeDescriptor(target, src));
			}
		}

		// Token: 0x060000FB RID: 251 RVA: 0x0000702C File Offset: 0x0000522C
		public override global::Jint.Native.JsInstance Wrap<T>(T value)
		{
			if (!this.reflectedType.IsAssignableFrom(value.GetType()))
			{
				throw new global::Jint.JintException(string.Concat(new string[]
				{
					"Attempt to wrap '",
					typeof(T).FullName,
					"' with '",
					this.reflectedType.FullName,
					"'"
				}));
			}
			global::Jint.Native.JsObject jsObject = base.Global.ObjectClass.New(base.PrototypeProperty);
			jsObject.Value = value;
			jsObject.Indexer = this.m_indexer;
			this.SetupNativeProperties(jsObject);
			return jsObject;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x000070F0 File Offset: 0x000052F0
		protected global::Jint.Marshal.ConstructorImpl WrapMember(global::System.Reflection.ConstructorInfo info)
		{
			return this.m_marshaller.WrapConstructor(info, true);
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00007100 File Offset: 0x00005300
		protected global::System.Collections.Generic.IEnumerable<global::System.Reflection.ConstructorInfo> GetMembers(global::System.Type[] genericArguments, int argCount)
		{
			if (this.m_constructors == null)
			{
				return new global::System.Reflection.ConstructorInfo[0];
			}
			return global::System.Array.FindAll<global::System.Reflection.ConstructorInfo>(this.m_constructors, (global::System.Reflection.ConstructorInfo con) => con.GetParameters().Length == argCount);
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00007148 File Offset: 0x00005348
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static string <CreateInstance>b__0(global::Jint.Native.JsInstance p)
		{
			return p.ToString();
		}

		// Token: 0x04000058 RID: 88
		private global::System.Type reflectedType;

		// Token: 0x04000059 RID: 89
		private global::System.Collections.Generic.LinkedList<global::Jint.Native.NativeDescriptor> m_properties = new global::System.Collections.Generic.LinkedList<global::Jint.Native.NativeDescriptor>();

		// Token: 0x0400005A RID: 90
		private global::Jint.Native.INativeIndexer m_indexer;

		// Token: 0x0400005B RID: 91
		private global::System.Reflection.ConstructorInfo[] m_constructors;

		// Token: 0x0400005C RID: 92
		private global::Jint.Marshaller m_marshaller;

		// Token: 0x0400005D RID: 93
		private global::Jint.Native.NativeOverloadImpl<global::System.Reflection.ConstructorInfo, global::Jint.Marshal.ConstructorImpl> m_overloads;

		// Token: 0x0400005E RID: 94
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Converter<global::Jint.Native.JsInstance, string> CS$<>9__CachedAnonymousMethodDelegate1;

		// Token: 0x020000E8 RID: 232
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <>c__DisplayClass3
		{
			// Token: 0x06000A4D RID: 2637 RVA: 0x00036170 File Offset: 0x00034370
			public <>c__DisplayClass3()
			{
			}

			// Token: 0x06000A4E RID: 2638 RVA: 0x00036178 File Offset: 0x00034378
			public bool <GetMembers>b__2(global::System.Reflection.ConstructorInfo con)
			{
				return con.GetParameters().Length == this.argCount;
			}

			// Token: 0x04000450 RID: 1104
			public int argCount;
		}
	}
}
