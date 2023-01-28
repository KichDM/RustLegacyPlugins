using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Jint.Native
{
	// Token: 0x02000018 RID: 24
	public class NativeOverloadImpl<TMemberInfo, TImpl> where TMemberInfo : global::System.Reflection.MethodBase where TImpl : class
	{
		// Token: 0x060000A8 RID: 168 RVA: 0x000055CC File Offset: 0x000037CC
		public NativeOverloadImpl(global::Jint.Marshaller marshaller, global::Jint.Native.NativeOverloadImpl<TMemberInfo, TImpl>.GetMembersDelegate getMembers, global::Jint.Native.NativeOverloadImpl<TMemberInfo, TImpl>.WrapMmemberDelegate wrapMember)
		{
			if (marshaller == null)
			{
				throw new global::System.ArgumentNullException("marshaller");
			}
			if (getMembers == null)
			{
				throw new global::System.ArgumentNullException("getMembers");
			}
			if (wrapMember == null)
			{
				throw new global::System.ArgumentNullException("wrapMember");
			}
			this.m_marshaller = marshaller;
			this.GetMembers = getMembers;
			this.WrapMember = wrapMember;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00005644 File Offset: 0x00003844
		protected TMemberInfo MatchMethod(global::System.Type[] args, global::System.Collections.Generic.IEnumerable<TMemberInfo> members)
		{
			global::System.Collections.Generic.LinkedList<global::Jint.Native.NativeOverloadImpl<TMemberInfo, TImpl>.MethodMatch> linkedList = new global::System.Collections.Generic.LinkedList<global::Jint.Native.NativeOverloadImpl<TMemberInfo, TImpl>.MethodMatch>();
			foreach (TMemberInfo method in members)
			{
				global::System.Collections.Generic.LinkedList<global::Jint.Native.NativeOverloadImpl<TMemberInfo, TImpl>.MethodMatch> linkedList2 = linkedList;
				global::Jint.Native.NativeOverloadImpl<TMemberInfo, TImpl>.MethodMatch methodMatch = new global::Jint.Native.NativeOverloadImpl<TMemberInfo, TImpl>.MethodMatch();
				methodMatch.method = method;
				methodMatch.parameters = global::System.Array.ConvertAll<global::System.Reflection.ParameterInfo, global::System.Type>(method.GetParameters(), (global::System.Reflection.ParameterInfo p) => p.ParameterType);
				methodMatch.weight = 0;
				linkedList2.AddLast(methodMatch);
			}
			if (args != null)
			{
				for (int i = 0; i < args.Length; i++)
				{
					global::System.Type type = args[i];
					global::System.Collections.Generic.LinkedListNode<global::Jint.Native.NativeOverloadImpl<TMemberInfo, TImpl>.MethodMatch> next;
					for (global::System.Collections.Generic.LinkedListNode<global::Jint.Native.NativeOverloadImpl<TMemberInfo, TImpl>.MethodMatch> linkedListNode = linkedList.First; linkedListNode != null; linkedListNode = next)
					{
						next = linkedListNode.Next;
						if (type != null)
						{
							global::System.Type type2 = linkedListNode.Value.parameters[i];
							if (type.Equals(type2))
							{
								linkedListNode.Value.weight++;
							}
							else if ((!typeof(global::System.Delegate).IsAssignableFrom(type2) || !typeof(global::Jint.Native.JsFunction).IsAssignableFrom(type)) && !this.m_marshaller.IsAssignable(type2, type))
							{
								linkedList.Remove(linkedListNode);
							}
						}
						else if (linkedListNode.Value.parameters[i].IsValueType)
						{
							linkedList.Remove(linkedListNode);
						}
					}
				}
			}
			global::Jint.Native.NativeOverloadImpl<TMemberInfo, TImpl>.MethodMatch methodMatch2 = null;
			foreach (global::Jint.Native.NativeOverloadImpl<TMemberInfo, TImpl>.MethodMatch methodMatch3 in linkedList)
			{
				methodMatch2 = ((methodMatch2 == null) ? methodMatch3 : ((methodMatch2.weight < methodMatch3.weight) ? methodMatch3 : methodMatch2));
			}
			if (methodMatch2 != null)
			{
				return methodMatch2.method;
			}
			return default(TMemberInfo);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000586C File Offset: 0x00003A6C
		protected string MakeKey(global::System.Type[] types, global::System.Type[] genericArguments)
		{
			return "<" + string.Join(",", global::System.Array.ConvertAll<global::System.Type, string>(genericArguments ?? new global::System.Type[0], delegate(global::System.Type t)
			{
				if (t != null)
				{
					return t.FullName;
				}
				return "<null>";
			})) + ">" + string.Join(",", global::System.Array.ConvertAll<global::System.Type, string>(types ?? new global::System.Type[0], delegate(global::System.Type t)
			{
				if (t != null)
				{
					return t.FullName;
				}
				return "<null>";
			}));
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00005908 File Offset: 0x00003B08
		public void DefineCustomOverload(global::System.Type[] args, global::System.Type[] generics, TImpl impl)
		{
			this.m_protoCache[this.MakeKey(args, generics)] = impl;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00005920 File Offset: 0x00003B20
		public TImpl ResolveOverload(global::Jint.Native.JsInstance[] args, global::System.Type[] generics)
		{
			global::System.Type[] array = global::System.Array.ConvertAll<global::Jint.Native.JsInstance, global::System.Type>(args, (global::Jint.Native.JsInstance x) => this.m_marshaller.GetInstanceType(x));
			string key = this.MakeKey(array, generics);
			TImpl timpl;
			if (!this.m_protoCache.TryGetValue(key, out timpl))
			{
				TMemberInfo tmemberInfo = this.MatchMethod(array, this.GetMembers(generics, args.Length));
				if (tmemberInfo != null && !this.m_reflectCache.TryGetValue(tmemberInfo, out timpl))
				{
					timpl = (this.m_reflectCache[tmemberInfo] = this.WrapMember(tmemberInfo));
				}
				this.m_protoCache[key] = timpl;
			}
			return timpl;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000059C0 File Offset: 0x00003BC0
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Type <MatchMethod>b__1(global::System.Reflection.ParameterInfo p)
		{
			return p.ParameterType;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x000059C8 File Offset: 0x00003BC8
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static string <MakeKey>b__3(global::System.Type t)
		{
			if (t != null)
			{
				return t.FullName;
			}
			return "<null>";
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000059DC File Offset: 0x00003BDC
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static string <MakeKey>b__4(global::System.Type t)
		{
			if (t != null)
			{
				return t.FullName;
			}
			return "<null>";
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x000059F0 File Offset: 0x00003BF0
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::System.Type <ResolveOverload>b__7(global::Jint.Native.JsInstance x)
		{
			return this.m_marshaller.GetInstanceType(x);
		}

		// Token: 0x04000040 RID: 64
		private global::System.Collections.Generic.Dictionary<string, TImpl> m_protoCache = new global::System.Collections.Generic.Dictionary<string, TImpl>();

		// Token: 0x04000041 RID: 65
		private global::System.Collections.Generic.Dictionary<TMemberInfo, TImpl> m_reflectCache = new global::System.Collections.Generic.Dictionary<TMemberInfo, TImpl>();

		// Token: 0x04000042 RID: 66
		private global::Jint.Marshaller m_marshaller;

		// Token: 0x04000043 RID: 67
		private global::Jint.Native.NativeOverloadImpl<TMemberInfo, TImpl>.GetMembersDelegate GetMembers;

		// Token: 0x04000044 RID: 68
		private global::Jint.Native.NativeOverloadImpl<TMemberInfo, TImpl>.WrapMmemberDelegate WrapMember;

		// Token: 0x04000045 RID: 69
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Converter<global::System.Reflection.ParameterInfo, global::System.Type> CS$<>9__CachedAnonymousMethodDelegate2;

		// Token: 0x04000046 RID: 70
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Converter<global::System.Type, string> CS$<>9__CachedAnonymousMethodDelegate5;

		// Token: 0x04000047 RID: 71
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Converter<global::System.Type, string> CS$<>9__CachedAnonymousMethodDelegate6;

		// Token: 0x020000E3 RID: 227
		// (Invoke) Token: 0x06000A42 RID: 2626
		public delegate global::System.Collections.Generic.IEnumerable<TMemberInfo> GetMembersDelegate(global::System.Type[] genericArguments, int argCount);

		// Token: 0x020000E4 RID: 228
		// (Invoke) Token: 0x06000A46 RID: 2630
		public delegate TImpl WrapMmemberDelegate(TMemberInfo info);

		// Token: 0x020000E5 RID: 229
		private class MethodMatch
		{
			// Token: 0x06000A49 RID: 2633 RVA: 0x000360C4 File Offset: 0x000342C4
			public MethodMatch()
			{
			}

			// Token: 0x04000449 RID: 1097
			public TMemberInfo method;

			// Token: 0x0400044A RID: 1098
			public int weight;

			// Token: 0x0400044B RID: 1099
			public global::System.Type[] parameters;
		}
	}
}
