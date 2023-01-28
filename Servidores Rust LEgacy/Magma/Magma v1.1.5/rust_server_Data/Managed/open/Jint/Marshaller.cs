using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Jint.Marshal;
using Jint.Native;

namespace Jint
{
	// Token: 0x0200001B RID: 27
	public class Marshaller
	{
		// Token: 0x060000CE RID: 206 RVA: 0x00005D34 File Offset: 0x00003F34
		public Marshaller(global::Jint.Native.IGlobal global)
		{
			this.m_global = global;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00005D5C File Offset: 0x00003F5C
		public void InitTypes()
		{
			this.m_typeType = global::Jint.Native.NativeTypeConstructor.CreateNativeTypeConstructor(this.m_global);
			this.m_typeCache[typeof(global::System.Type)] = this.m_typeType;
			foreach (global::System.Type type in new global::System.Type[]
			{
				typeof(short),
				typeof(int),
				typeof(long),
				typeof(ushort),
				typeof(uint),
				typeof(ulong),
				typeof(float),
				typeof(double),
				typeof(byte),
				typeof(sbyte)
			})
			{
				this.m_typeCache[type] = this.CreateConstructor(type, this.m_global.NumberClass.PrototypeProperty);
			}
			this.m_typeCache[typeof(string)] = this.CreateConstructor(typeof(string), this.m_global.StringClass.PrototypeProperty);
			this.m_typeCache[typeof(char)] = this.CreateConstructor(typeof(char), this.m_global.StringClass.PrototypeProperty);
			this.m_typeCache[typeof(bool)] = this.CreateConstructor(typeof(bool), this.m_global.BooleanClass.PrototypeProperty);
			this.m_typeCache[typeof(global::System.DateTime)] = this.CreateConstructor(typeof(global::System.DateTime), this.m_global.DateClass.PrototypeProperty);
			this.m_typeCache[typeof(global::System.Text.RegularExpressions.Regex)] = this.CreateConstructor(typeof(global::System.Text.RegularExpressions.Regex), this.m_global.RegExpClass.PrototypeProperty);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00005F94 File Offset: 0x00004194
		public global::Jint.Native.JsInstance MarshalClrValue<T>(T value)
		{
			if (value == null)
			{
				return global::Jint.Native.JsNull.Instance;
			}
			if (value is global::Jint.Native.JsInstance)
			{
				return value as global::Jint.Native.JsInstance;
			}
			if (!(value is global::System.Type))
			{
				return this.MarshalType(value.GetType()).Wrap<T>(value);
			}
			global::System.Type type = value as global::System.Type;
			if (type.IsGenericTypeDefinition)
			{
				global::Jint.Native.NativeGenericType nativeGenericType = new global::Jint.Native.NativeGenericType(type, this.m_typeType.PrototypeProperty);
				this.m_typeType.SetupNativeProperties(nativeGenericType);
				return nativeGenericType;
			}
			return this.MarshalType(value as global::System.Type);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00006044 File Offset: 0x00004244
		public global::Jint.Native.JsConstructor MarshalType(global::System.Type t)
		{
			global::Jint.Native.NativeConstructor result;
			if (this.m_typeCache.TryGetValue(t, out result))
			{
				return result;
			}
			return this.m_typeCache[t] = this.CreateConstructor(t);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00006080 File Offset: 0x00004280
		private global::Jint.Native.NativeConstructor CreateConstructor(global::System.Type t)
		{
			return (global::Jint.Native.NativeConstructor)this.m_typeType.Wrap<global::System.Type>(t);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00006094 File Offset: 0x00004294
		private global::Jint.Native.NativeConstructor CreateConstructor(global::System.Type t, global::Jint.Native.JsObject prototypePropertyPrototype)
		{
			return (global::Jint.Native.NativeConstructor)this.m_typeType.WrapSpecialType(t, prototypePropertyPrototype);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000060A8 File Offset: 0x000042A8
		private TElem[] MarshalJsArrayHelper<TElem>(global::Jint.Native.JsObject value)
		{
			int num = (int)value["length"].ToNumber();
			if (num < 0)
			{
				num = 0;
			}
			TElem[] array = new TElem[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = this.MarshalJsValue<TElem>(value[new global::Jint.Native.JsNumber(i, global::Jint.Native.JsUndefined.Instance)]);
			}
			return array;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000610C File Offset: 0x0000430C
		private object MarshalJsFunctionHelper(global::Jint.Native.JsFunction func, global::System.Type delegateType)
		{
			global::Jint.ExecutionVisitor executionVisitor = new global::Jint.ExecutionVisitor(this.m_global, new global::Jint.Native.JsScope((global::Jint.Native.JsObject)this.m_global));
			global::Jint.ExecutionVisitor executionVisitor2 = (global::Jint.ExecutionVisitor)this.m_global.Visitor;
			executionVisitor.AllowClr = executionVisitor2.AllowClr;
			executionVisitor.PermissionSet = executionVisitor2.PermissionSet;
			global::Jint.Marshal.JsFunctionDelegate jsFunctionDelegate = new global::Jint.Marshal.JsFunctionDelegate(executionVisitor, func, global::Jint.Native.JsNull.Instance, delegateType);
			return jsFunctionDelegate.GetDelegate();
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00006178 File Offset: 0x00004378
		public T MarshalJsValue<T>(global::Jint.Native.JsInstance value)
		{
			if (value.Value is T)
			{
				return (T)((object)value.Value);
			}
			if (typeof(T).IsArray)
			{
				if (value == null || value == global::Jint.Native.JsUndefined.Instance || value == global::Jint.Native.JsNull.Instance)
				{
					return default(T);
				}
				if (this.m_global.ArrayClass.HasInstance(value as global::Jint.Native.JsObject))
				{
					global::System.Delegate @delegate;
					if (!this.m_arrayMarshllers.TryGetValue(typeof(T), out @delegate))
					{
						@delegate = (this.m_arrayMarshllers[typeof(T)] = global::System.Delegate.CreateDelegate(typeof(global::System.Func<global::Jint.Native.JsObject, T>), this, typeof(global::Jint.Marshaller).GetMethod("MarshalJsFunctionHelper").MakeGenericMethod(new global::System.Type[]
						{
							typeof(T).GetElementType()
						})));
					}
					return ((global::System.Func<global::Jint.Native.JsObject, T>)@delegate)(value as global::Jint.Native.JsObject);
				}
				throw new global::Jint.JintException("Array is required");
			}
			else if (typeof(global::System.Delegate).IsAssignableFrom(typeof(T)))
			{
				if (value == null || value == global::Jint.Native.JsUndefined.Instance || value == global::Jint.Native.JsNull.Instance)
				{
					return default(T);
				}
				if (!(value is global::Jint.Native.JsFunction))
				{
					throw new global::Jint.JintException("Can't convert a non function object to a delegate type");
				}
				return (T)((object)this.MarshalJsFunctionHelper(value as global::Jint.Native.JsFunction, typeof(T)));
			}
			else
			{
				if (value != global::Jint.Native.JsNull.Instance && value != global::Jint.Native.JsUndefined.Instance && value is T)
				{
					return (T)((object)value);
				}
				return (T)((object)global::System.Convert.ChangeType(value.Value, typeof(T)));
			}
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000634C File Offset: 0x0000454C
		public object MarshalJsValueBoxed<T>(global::Jint.Native.JsInstance value)
		{
			if (value.Value is T)
			{
				return value.Value;
			}
			return null;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00006368 File Offset: 0x00004568
		public global::System.Type GetInstanceType(global::Jint.Native.JsInstance value)
		{
			if (value == null || value == global::Jint.Native.JsUndefined.Instance || value == global::Jint.Native.JsNull.Instance)
			{
				return null;
			}
			if (value.Value != null)
			{
				return value.Value.GetType();
			}
			return value.GetType();
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x000063A8 File Offset: 0x000045A8
		public global::Jint.Marshal.JsMethodImpl WrapMethod(global::System.Reflection.MethodInfo info, bool passGlobal)
		{
			return global::Jint.Marshal.ProxyHelper.Default.WrapMethod(info, passGlobal);
		}

		// Token: 0x060000DA RID: 218 RVA: 0x000063B8 File Offset: 0x000045B8
		public global::Jint.Marshal.ConstructorImpl WrapConstructor(global::System.Reflection.ConstructorInfo info, bool passGlobal)
		{
			return global::Jint.Marshal.ProxyHelper.Default.WrapConstructor(info, passGlobal);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x000063C8 File Offset: 0x000045C8
		public global::Jint.Marshal.JsGetter WrapGetProperty(global::System.Reflection.PropertyInfo prop)
		{
			return global::Jint.Marshal.ProxyHelper.Default.WrapGetProperty(prop, this);
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000063D8 File Offset: 0x000045D8
		public global::Jint.Marshal.JsGetter WrapGetField(global::System.Reflection.FieldInfo field)
		{
			return global::Jint.Marshal.ProxyHelper.Default.WrapGetField(field, this);
		}

		// Token: 0x060000DD RID: 221 RVA: 0x000063E8 File Offset: 0x000045E8
		public global::Jint.Marshal.JsSetter WrapSetProperty(global::System.Reflection.PropertyInfo prop)
		{
			return global::Jint.Marshal.ProxyHelper.Default.WrapSetProperty(prop, this);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x000063F8 File Offset: 0x000045F8
		public global::Jint.Marshal.JsSetter WrapSetField(global::System.Reflection.FieldInfo field)
		{
			return global::Jint.Marshal.ProxyHelper.Default.WrapSetField(field, this);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00006408 File Offset: 0x00004608
		public global::Jint.Marshal.JsIndexerGetter WrapIndexerGetter(global::System.Reflection.MethodInfo getMethod)
		{
			return global::Jint.Marshal.ProxyHelper.Default.WrapIndexerGetter(getMethod, this);
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00006418 File Offset: 0x00004618
		public global::Jint.Marshal.JsIndexerSetter WrapIndexerSetter(global::System.Reflection.MethodInfo setMethod)
		{
			return global::Jint.Marshal.ProxyHelper.Default.WrapIndexerSetter(setMethod, this);
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00006428 File Offset: 0x00004628
		public global::Jint.Native.NativeDescriptor MarshalPropertyInfo(global::System.Reflection.PropertyInfo prop, global::Jint.Native.JsDictionaryObject owner)
		{
			global::Jint.Marshal.JsSetter jsSetter = null;
			global::Jint.Marshal.JsGetter getter;
			if (prop.CanRead && prop.GetGetMethod() != null)
			{
				getter = this.WrapGetProperty(prop);
			}
			else
			{
				getter = ((global::Jint.Native.JsDictionaryObject that) => global::Jint.Native.JsUndefined.Instance);
			}
			if (prop.CanWrite && prop.GetSetMethod() != null)
			{
				jsSetter = this.WrapSetProperty(prop);
			}
			if (jsSetter != null)
			{
				return new global::Jint.Native.NativeDescriptor(owner, prop.Name, getter, jsSetter)
				{
					Enumerable = true
				};
			}
			return new global::Jint.Native.NativeDescriptor(owner, prop.Name, getter)
			{
				Enumerable = true
			};
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x000064D4 File Offset: 0x000046D4
		public global::Jint.Native.NativeDescriptor MarshalFieldInfo(global::System.Reflection.FieldInfo prop, global::Jint.Native.JsDictionaryObject owner)
		{
			global::Jint.Marshal.JsGetter getter;
			global::Jint.Marshal.JsSetter setter;
			if (prop.IsLiteral)
			{
				global::Jint.Native.JsInstance value = null;
				getter = delegate(global::Jint.Native.JsDictionaryObject that)
				{
					if (value == null)
					{
						value = (global::Jint.Native.JsInstance)typeof(global::Jint.Marshaller).GetMethod("MarshalClrValue").MakeGenericMethod(new global::System.Type[]
						{
							prop.FieldType
						}).Invoke(this, new object[]
						{
							prop.GetValue(null)
						});
					}
					return value;
				};
				setter = delegate(global::Jint.Native.JsDictionaryObject that, global::Jint.Native.JsInstance v)
				{
				};
			}
			else
			{
				getter = this.WrapGetField(prop);
				setter = this.WrapSetField(prop);
			}
			return new global::Jint.Native.NativeDescriptor(owner, prop.Name, getter, setter)
			{
				Enumerable = true
			};
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0000658C File Offset: 0x0000478C
		public bool IsAssignable(global::System.Type target, global::System.Type source)
		{
			return (typeof(global::System.IConvertible).IsAssignableFrom(source) && global::Jint.Marshaller.IntegralTypeConvertions[(int)global::System.Type.GetTypeCode(source), (int)global::System.Type.GetTypeCode(target)]) || target.IsAssignableFrom(source);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x000065C8 File Offset: 0x000047C8
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Jint.Native.JsInstance <MarshalPropertyInfo>b__2(global::Jint.Native.JsDictionaryObject that)
		{
			return global::Jint.Native.JsUndefined.Instance;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x000065D0 File Offset: 0x000047D0
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static void <MarshalFieldInfo>b__6(global::Jint.Native.JsDictionaryObject that, global::Jint.Native.JsInstance v)
		{
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x000065D4 File Offset: 0x000047D4
		// Note: this type is marked as 'beforefieldinit'.
		static Marshaller()
		{
		}

		// Token: 0x04000050 RID: 80
		private global::Jint.Native.IGlobal m_global;

		// Token: 0x04000051 RID: 81
		private global::System.Collections.Generic.Dictionary<global::System.Type, global::Jint.Native.NativeConstructor> m_typeCache = new global::System.Collections.Generic.Dictionary<global::System.Type, global::Jint.Native.NativeConstructor>();

		// Token: 0x04000052 RID: 82
		private global::System.Collections.Generic.Dictionary<global::System.Type, global::System.Delegate> m_arrayMarshllers = new global::System.Collections.Generic.Dictionary<global::System.Type, global::System.Delegate>();

		// Token: 0x04000053 RID: 83
		private global::Jint.Native.NativeTypeConstructor m_typeType;

		// Token: 0x04000054 RID: 84
		private static bool[,] IntegralTypeConvertions = new bool[,]
		{
			{
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				true
			},
			{
				false,
				false,
				false,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				false,
				true
			},
			{
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				true
			},
			{
				false,
				false,
				false,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				false,
				false,
				true
			},
			{
				false,
				false,
				false,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				false,
				false,
				false,
				false,
				false,
				true
			},
			{
				false,
				false,
				false,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				false,
				false,
				true
			},
			{
				false,
				false,
				false,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				false,
				false,
				true
			},
			{
				false,
				false,
				false,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				false,
				false,
				true
			},
			{
				false,
				false,
				false,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				false,
				false,
				true
			},
			{
				false,
				false,
				false,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				false,
				false,
				true
			},
			{
				false,
				false,
				false,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				false,
				false,
				true
			},
			{
				false,
				false,
				false,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				false,
				false,
				true
			},
			{
				false,
				false,
				false,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				false,
				false,
				true
			},
			{
				false,
				false,
				false,
				true,
				false,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				false,
				false,
				true
			},
			{
				false,
				false,
				false,
				true,
				false,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				false,
				false,
				true
			},
			{
				false,
				false,
				false,
				true,
				false,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				false,
				false,
				true
			},
			{
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				true,
				false,
				true
			},
			{
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false
			},
			{
				false,
				false,
				false,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				false,
				true
			}
		};

		// Token: 0x04000055 RID: 85
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Jint.Marshal.JsGetter CS$<>9__CachedAnonymousMethodDelegate3;

		// Token: 0x04000056 RID: 86
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Jint.Marshal.JsSetter CS$<>9__CachedAnonymousMethodDelegate7;

		// Token: 0x020000E6 RID: 230
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <>c__DisplayClass8
		{
			// Token: 0x06000A4A RID: 2634 RVA: 0x000360CC File Offset: 0x000342CC
			public <>c__DisplayClass8()
			{
			}

			// Token: 0x0400044C RID: 1100
			public global::Jint.Marshaller <>4__this;

			// Token: 0x0400044D RID: 1101
			public global::System.Reflection.FieldInfo prop;
		}

		// Token: 0x020000E7 RID: 231
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <>c__DisplayClassa
		{
			// Token: 0x06000A4B RID: 2635 RVA: 0x000360D4 File Offset: 0x000342D4
			public <>c__DisplayClassa()
			{
			}

			// Token: 0x06000A4C RID: 2636 RVA: 0x000360DC File Offset: 0x000342DC
			public global::Jint.Native.JsInstance <MarshalFieldInfo>b__5(global::Jint.Native.JsDictionaryObject that)
			{
				if (this.value == null)
				{
					this.value = (global::Jint.Native.JsInstance)typeof(global::Jint.Marshaller).GetMethod("MarshalClrValue").MakeGenericMethod(new global::System.Type[]
					{
						this.CS$<>8__locals9.prop.FieldType
					}).Invoke(this.CS$<>8__locals9.<>4__this, new object[]
					{
						this.CS$<>8__locals9.prop.GetValue(null)
					});
				}
				return this.value;
			}

			// Token: 0x0400044E RID: 1102
			public global::Jint.Marshaller.<>c__DisplayClass8 CS$<>8__locals9;

			// Token: 0x0400044F RID: 1103
			public global::Jint.Native.JsInstance value;
		}
	}
}
