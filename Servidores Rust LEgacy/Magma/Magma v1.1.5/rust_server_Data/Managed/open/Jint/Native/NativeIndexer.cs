using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Jint.Marshal;

namespace Jint.Native
{
	// Token: 0x02000017 RID: 23
	public class NativeIndexer : global::Jint.Native.INativeIndexer
	{
		// Token: 0x060000A5 RID: 165 RVA: 0x000054AC File Offset: 0x000036AC
		public NativeIndexer(global::Jint.Marshaller marshaller, global::System.Reflection.MethodInfo[] getters, global::System.Reflection.MethodInfo[] setters)
		{
			this.m_getOverload = new global::Jint.Native.NativeOverloadImpl<global::System.Reflection.MethodInfo, global::Jint.Marshal.JsIndexerGetter>(marshaller, (global::System.Type[] genericArgs, int Length) => global::System.Array.FindAll<global::System.Reflection.MethodInfo>(getters, (global::System.Reflection.MethodInfo mi) => mi.GetParameters().Length == Length), new global::Jint.Native.NativeOverloadImpl<global::System.Reflection.MethodInfo, global::Jint.Marshal.JsIndexerGetter>.WrapMmemberDelegate(marshaller.WrapIndexerGetter));
			this.m_setOverload = new global::Jint.Native.NativeOverloadImpl<global::System.Reflection.MethodInfo, global::Jint.Marshal.JsIndexerSetter>(marshaller, (global::System.Type[] genericArgs, int Length) => global::System.Array.FindAll<global::System.Reflection.MethodInfo>(setters, (global::System.Reflection.MethodInfo mi) => mi.GetParameters().Length == Length), new global::Jint.Native.NativeOverloadImpl<global::System.Reflection.MethodInfo, global::Jint.Marshal.JsIndexerSetter>.WrapMmemberDelegate(marshaller.WrapIndexerSetter));
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00005534 File Offset: 0x00003734
		public global::Jint.Native.JsInstance get(global::Jint.Native.JsInstance that, global::Jint.Native.JsInstance index)
		{
			global::Jint.Marshal.JsIndexerGetter jsIndexerGetter = this.m_getOverload.ResolveOverload(new global::Jint.Native.JsInstance[]
			{
				index
			}, null);
			if (jsIndexerGetter == null)
			{
				throw new global::Jint.JintException("No matching overload found");
			}
			return jsIndexerGetter(that, index);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000557C File Offset: 0x0000377C
		public void set(global::Jint.Native.JsInstance that, global::Jint.Native.JsInstance index, global::Jint.Native.JsInstance value)
		{
			global::Jint.Marshal.JsIndexerSetter jsIndexerSetter = this.m_setOverload.ResolveOverload(new global::Jint.Native.JsInstance[]
			{
				index,
				value
			}, null);
			if (jsIndexerSetter == null)
			{
				throw new global::Jint.JintException("No matching overload found");
			}
			jsIndexerSetter(that, index, value);
		}

		// Token: 0x0400003E RID: 62
		private global::Jint.Native.NativeOverloadImpl<global::System.Reflection.MethodInfo, global::Jint.Marshal.JsIndexerGetter> m_getOverload;

		// Token: 0x0400003F RID: 63
		private global::Jint.Native.NativeOverloadImpl<global::System.Reflection.MethodInfo, global::Jint.Marshal.JsIndexerSetter> m_setOverload;

		// Token: 0x020000E2 RID: 226
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <>c__DisplayClass6
		{
			// Token: 0x06000A3E RID: 2622 RVA: 0x00036044 File Offset: 0x00034244
			public <>c__DisplayClass6()
			{
			}

			// Token: 0x06000A3F RID: 2623 RVA: 0x0003604C File Offset: 0x0003424C
			public global::System.Collections.Generic.IEnumerable<global::System.Reflection.MethodInfo> <.ctor>b__0(global::System.Type[] genericArgs, int Length)
			{
				return global::System.Array.FindAll<global::System.Reflection.MethodInfo>(this.getters, (global::System.Reflection.MethodInfo mi) => mi.GetParameters().Length == Length);
			}

			// Token: 0x06000A40 RID: 2624 RVA: 0x00036088 File Offset: 0x00034288
			public global::System.Collections.Generic.IEnumerable<global::System.Reflection.MethodInfo> <.ctor>b__2(global::System.Type[] genericArgs, int Length)
			{
				return global::System.Array.FindAll<global::System.Reflection.MethodInfo>(this.setters, (global::System.Reflection.MethodInfo mi) => mi.GetParameters().Length == Length);
			}

			// Token: 0x04000447 RID: 1095
			public global::System.Reflection.MethodInfo[] getters;

			// Token: 0x04000448 RID: 1096
			public global::System.Reflection.MethodInfo[] setters;

			// Token: 0x02000168 RID: 360
			private sealed class <>c__DisplayClass8
			{
				// Token: 0x06000C41 RID: 3137 RVA: 0x0003D414 File Offset: 0x0003B614
				public <>c__DisplayClass8()
				{
				}

				// Token: 0x06000C42 RID: 3138 RVA: 0x0003D41C File Offset: 0x0003B61C
				public bool <.ctor>b__1(global::System.Reflection.MethodInfo mi)
				{
					return mi.GetParameters().Length == this.Length;
				}

				// Token: 0x04000714 RID: 1812
				public global::Jint.Native.NativeIndexer.<>c__DisplayClass6 CS$<>8__locals7;

				// Token: 0x04000715 RID: 1813
				public int Length;
			}

			// Token: 0x02000169 RID: 361
			private sealed class <>c__DisplayClassa
			{
				// Token: 0x06000C43 RID: 3139 RVA: 0x0003D430 File Offset: 0x0003B630
				public <>c__DisplayClassa()
				{
				}

				// Token: 0x06000C44 RID: 3140 RVA: 0x0003D438 File Offset: 0x0003B638
				public bool <.ctor>b__3(global::System.Reflection.MethodInfo mi)
				{
					return mi.GetParameters().Length == this.Length;
				}

				// Token: 0x04000716 RID: 1814
				public global::Jint.Native.NativeIndexer.<>c__DisplayClass6 CS$<>8__locals7;

				// Token: 0x04000717 RID: 1815
				public int Length;
			}
		}
	}
}
