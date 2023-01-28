using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using Jint.Expressions;
using Jint.Marshal;

namespace Jint.Native
{
	// Token: 0x0200001E RID: 30
	public class NativeMethodOverload : global::Jint.Native.JsFunction
	{
		// Token: 0x060000FF RID: 255 RVA: 0x00007150 File Offset: 0x00005350
		public NativeMethodOverload(global::System.Collections.Generic.ICollection<global::System.Reflection.MethodInfo> methods, global::Jint.Native.JsObject prototype, global::Jint.Native.IGlobal global) : base(prototype)
		{
			if (global == null)
			{
				throw new global::System.ArgumentNullException("global");
			}
			this.m_marshaller = global.Marshaller;
			using (global::System.Collections.Generic.IEnumerator<global::System.Reflection.MethodInfo> enumerator = methods.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					global::System.Reflection.MethodInfo methodInfo = enumerator.Current;
					base.Name = methodInfo.Name;
				}
			}
			foreach (global::System.Reflection.MethodInfo methodInfo2 in methods)
			{
				if (methodInfo2.IsGenericMethodDefinition)
				{
					this.m_generics.AddLast(methodInfo2);
				}
				else if (!methodInfo2.ContainsGenericParameters)
				{
					this.m_methods.AddLast(methodInfo2);
				}
			}
			this.m_overloads = new global::Jint.Native.NativeOverloadImpl<global::System.Reflection.MethodInfo, global::Jint.Marshal.JsMethodImpl>(this.m_marshaller, new global::Jint.Native.NativeOverloadImpl<global::System.Reflection.MethodInfo, global::Jint.Marshal.JsMethodImpl>.GetMembersDelegate(this.GetMembers), new global::Jint.Native.NativeOverloadImpl<global::System.Reflection.MethodInfo, global::Jint.Marshal.JsMethodImpl>.WrapMmemberDelegate(this.WrapMember));
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000100 RID: 256 RVA: 0x0000727C File Offset: 0x0000547C
		public override bool IsClr
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000101 RID: 257 RVA: 0x00007280 File Offset: 0x00005480
		// (set) Token: 0x06000102 RID: 258 RVA: 0x00007288 File Offset: 0x00005488
		public override object Value
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000728C File Offset: 0x0000548C
		public override global::Jint.Native.JsInstance Execute(global::Jint.Expressions.IJintVisitor visitor, global::Jint.Native.JsDictionaryObject that, global::Jint.Native.JsInstance[] parameters)
		{
			return this.Execute(visitor, that, parameters, null);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00007298 File Offset: 0x00005498
		public override global::Jint.Native.JsInstance Execute(global::Jint.Expressions.IJintVisitor visitor, global::Jint.Native.JsDictionaryObject that, global::Jint.Native.JsInstance[] parameters, global::System.Type[] genericArguments)
		{
			if (this.m_generics.Count == 0 && genericArguments != null && genericArguments.Length > 0)
			{
				return base.Execute(visitor, that, parameters, genericArguments);
			}
			global::Jint.Marshal.JsMethodImpl jsMethodImpl = this.m_overloads.ResolveOverload(parameters, genericArguments);
			if (jsMethodImpl == null)
			{
				throw new global::Jint.JintException(string.Format("No matching overload found {0}<{1}>", base.Name, genericArguments));
			}
			visitor.Return(jsMethodImpl(visitor.Global, that, parameters));
			return that;
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0000731C File Offset: 0x0000551C
		protected global::Jint.Marshal.JsMethodImpl WrapMember(global::System.Reflection.MethodInfo info)
		{
			return this.m_marshaller.WrapMethod(info, true);
		}

		// Token: 0x06000106 RID: 262 RVA: 0x0000732C File Offset: 0x0000552C
		protected global::System.Collections.Generic.IEnumerable<global::System.Reflection.MethodInfo> GetMembers(global::System.Type[] genericArguments, int argCount)
		{
			if (genericArguments != null && genericArguments.Length > 0)
			{
				foreach (global::System.Reflection.MethodInfo item in this.m_generics)
				{
					if (item.GetGenericArguments().Length == genericArguments.Length && item.GetParameters().Length == argCount)
					{
						global::System.Reflection.MethodInfo i = null;
						try
						{
							i = item.MakeGenericMethod(genericArguments);
						}
						catch
						{
						}
						if (i != null)
						{
							yield return i;
						}
					}
				}
			}
			foreach (global::System.Reflection.MethodInfo item2 in this.m_methods)
			{
				global::System.Reflection.ParameterInfo[] parameters = item2.GetParameters();
				if (parameters.Length == argCount)
				{
					yield return item2;
				}
			}
			yield break;
		}

		// Token: 0x06000107 RID: 263 RVA: 0x0000735C File Offset: 0x0000555C
		public override string GetBody()
		{
			return "[native overload]";
		}

		// Token: 0x0400005F RID: 95
		private global::Jint.Marshaller m_marshaller;

		// Token: 0x04000060 RID: 96
		private global::Jint.Native.NativeOverloadImpl<global::System.Reflection.MethodInfo, global::Jint.Marshal.JsMethodImpl> m_overloads;

		// Token: 0x04000061 RID: 97
		private global::System.Collections.Generic.LinkedList<global::System.Reflection.MethodInfo> m_methods = new global::System.Collections.Generic.LinkedList<global::System.Reflection.MethodInfo>();

		// Token: 0x04000062 RID: 98
		private global::System.Collections.Generic.LinkedList<global::System.Reflection.MethodInfo> m_generics = new global::System.Collections.Generic.LinkedList<global::System.Reflection.MethodInfo>();

		// Token: 0x020000E9 RID: 233
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <GetMembers>d__0 : global::System.Collections.Generic.IEnumerable<global::System.Reflection.MethodInfo>, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerator<global::System.Reflection.MethodInfo>, global::System.Collections.IEnumerator, global::System.IDisposable
		{
			// Token: 0x06000A4F RID: 2639 RVA: 0x0003618C File Offset: 0x0003438C
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.Generic.IEnumerator<global::System.Reflection.MethodInfo> global::System.Collections.Generic.IEnumerable<global::System.Reflection.MethodInfo>.GetEnumerator()
			{
				global::Jint.Native.NativeMethodOverload.<GetMembers>d__0 <GetMembers>d__;
				if (global::System.Threading.Thread.CurrentThread.ManagedThreadId == this.<>l__initialThreadId && this.<>1__state == -2)
				{
					this.<>1__state = 0;
					<GetMembers>d__ = this;
				}
				else
				{
					<GetMembers>d__ = new global::Jint.Native.NativeMethodOverload.<GetMembers>d__0(0);
					<GetMembers>d__.<>4__this = this;
				}
				<GetMembers>d__.genericArguments = genericArguments;
				<GetMembers>d__.argCount = argCount;
				return <GetMembers>d__;
			}

			// Token: 0x06000A50 RID: 2640 RVA: 0x000361FC File Offset: 0x000343FC
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<System.Reflection.MethodInfo>.GetEnumerator();
			}

			// Token: 0x06000A51 RID: 2641 RVA: 0x00036204 File Offset: 0x00034404
			bool global::System.Collections.IEnumerator.MoveNext()
			{
				bool result;
				try
				{
					int num = this.<>1__state;
					if (num != 0)
					{
						switch (num)
						{
						case 3:
							this.<>1__state = 1;
							break;
						case 4:
							goto IL_1A2;
						case 5:
							this.<>1__state = 4;
							goto IL_18F;
						default:
							goto IL_1A2;
						}
					}
					else
					{
						this.<>1__state = -1;
						if (genericArguments == null || genericArguments.Length <= 0)
						{
							goto IL_117;
						}
						enumerator = this.m_generics.GetEnumerator();
						this.<>1__state = 1;
					}
					while (enumerator.MoveNext())
					{
						item = enumerator.Current;
						if (item.GetGenericArguments().Length == genericArguments.Length && item.GetParameters().Length == argCount)
						{
							i = null;
							try
							{
								i = item.MakeGenericMethod(genericArguments);
							}
							catch
							{
							}
							if (i != null)
							{
								this.<>2__current = i;
								this.<>1__state = 3;
								return true;
							}
						}
					}
					this.<>m__Finally6();
					goto IL_117;
					IL_18F:
					while (enumerator2.MoveNext())
					{
						item2 = enumerator2.Current;
						parameters = item2.GetParameters();
						if (parameters.Length == argCount)
						{
							this.<>2__current = item2;
							this.<>1__state = 5;
							return true;
						}
					}
					this.<>m__Finally8();
					goto IL_1A2;
					IL_117:
					enumerator2 = this.m_methods.GetEnumerator();
					this.<>1__state = 4;
					goto IL_18F;
					IL_1A2:
					result = false;
				}
				catch
				{
					this.System.IDisposable.Dispose();
					throw;
				}
				return result;
			}

			// Token: 0x170001EB RID: 491
			// (get) Token: 0x06000A52 RID: 2642 RVA: 0x000363F8 File Offset: 0x000345F8
			global::System.Reflection.MethodInfo global::System.Collections.Generic.IEnumerator<global::System.Reflection.MethodInfo>.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.<>2__current;
				}
			}

			// Token: 0x06000A53 RID: 2643 RVA: 0x00036400 File Offset: 0x00034600
			[global::System.Diagnostics.DebuggerHidden]
			void global::System.Collections.IEnumerator.Reset()
			{
				throw new global::System.NotSupportedException();
			}

			// Token: 0x06000A54 RID: 2644 RVA: 0x00036408 File Offset: 0x00034608
			void global::System.IDisposable.Dispose()
			{
				switch (this.<>1__state)
				{
				case 1:
				case 3:
					try
					{
					}
					finally
					{
						this.<>m__Finally6();
					}
					break;
				}
				switch (this.<>1__state)
				{
				case 4:
				case 5:
					try
					{
					}
					finally
					{
						this.<>m__Finally8();
					}
					return;
				default:
					return;
				}
			}

			// Token: 0x170001EC RID: 492
			// (get) Token: 0x06000A55 RID: 2645 RVA: 0x00036484 File Offset: 0x00034684
			object global::System.Collections.IEnumerator.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.<>2__current;
				}
			}

			// Token: 0x06000A56 RID: 2646 RVA: 0x0003648C File Offset: 0x0003468C
			[global::System.Diagnostics.DebuggerHidden]
			public <GetMembers>d__0(int <>1__state)
			{
				this.<>1__state = <>1__state;
				this.<>l__initialThreadId = global::System.Threading.Thread.CurrentThread.ManagedThreadId;
			}

			// Token: 0x06000A57 RID: 2647 RVA: 0x000364AC File Offset: 0x000346AC
			private void <>m__Finally6()
			{
				this.<>1__state = -1;
				((global::System.IDisposable)enumerator).Dispose();
			}

			// Token: 0x06000A58 RID: 2648 RVA: 0x000364C8 File Offset: 0x000346C8
			private void <>m__Finally8()
			{
				this.<>1__state = -1;
				((global::System.IDisposable)enumerator2).Dispose();
			}

			// Token: 0x04000451 RID: 1105
			private global::System.Reflection.MethodInfo <>2__current;

			// Token: 0x04000452 RID: 1106
			private int <>1__state;

			// Token: 0x04000453 RID: 1107
			private int <>l__initialThreadId;

			// Token: 0x04000454 RID: 1108
			public global::Jint.Native.NativeMethodOverload <>4__this;

			// Token: 0x04000455 RID: 1109
			public global::System.Type[] genericArguments;

			// Token: 0x04000456 RID: 1110
			public global::System.Type[] <>3__genericArguments;

			// Token: 0x04000457 RID: 1111
			public int argCount;

			// Token: 0x04000458 RID: 1112
			public int <>3__argCount;

			// Token: 0x04000459 RID: 1113
			public global::System.Reflection.MethodInfo <item>5__1;

			// Token: 0x0400045A RID: 1114
			public global::System.Reflection.MethodInfo <m>5__2;

			// Token: 0x0400045B RID: 1115
			public global::System.Reflection.MethodInfo <item>5__3;

			// Token: 0x0400045C RID: 1116
			public global::System.Reflection.ParameterInfo[] <parameters>5__4;

			// Token: 0x0400045D RID: 1117
			public global::System.Collections.Generic.LinkedList<global::System.Reflection.MethodInfo>.Enumerator <>7__wrap5;

			// Token: 0x0400045E RID: 1118
			public global::System.Collections.Generic.LinkedList<global::System.Reflection.MethodInfo>.Enumerator <>7__wrap7;
		}
	}
}
