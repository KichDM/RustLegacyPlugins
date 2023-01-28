using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Jint.Native
{
	// Token: 0x0200004F RID: 79
	[global::System.Serializable]
	public class JsScope : global::Jint.Native.JsDictionaryObject
	{
		// Token: 0x0600038E RID: 910 RVA: 0x0001FB30 File Offset: 0x0001DD30
		public JsScope() : base(global::Jint.Native.JsNull.Instance)
		{
			this.globalScope = null;
		}

		// Token: 0x0600038F RID: 911 RVA: 0x0001FB44 File Offset: 0x0001DD44
		public JsScope(global::Jint.Native.JsScope outer) : base(outer)
		{
			if (outer == null)
			{
				throw new global::System.ArgumentNullException("outer");
			}
			this.globalScope = outer.Global;
		}

		// Token: 0x06000390 RID: 912 RVA: 0x0001FB6C File Offset: 0x0001DD6C
		public JsScope(global::Jint.Native.JsScope outer, global::Jint.Native.JsDictionaryObject bag) : base(outer)
		{
			if (outer == null)
			{
				throw new global::System.ArgumentNullException("outer");
			}
			if (bag == null)
			{
				throw new global::System.ArgumentNullException("bag");
			}
			this.globalScope = outer.Global;
			this.bag = bag;
		}

		// Token: 0x06000391 RID: 913 RVA: 0x0001FBAC File Offset: 0x0001DDAC
		public JsScope(global::Jint.Native.JsDictionaryObject bag) : base(global::Jint.Native.JsNull.Instance)
		{
			this.bag = bag;
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000392 RID: 914 RVA: 0x0001FBC0 File Offset: 0x0001DDC0
		public override string Class
		{
			get
			{
				return "Scope";
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000393 RID: 915 RVA: 0x0001FBC8 File Offset: 0x0001DDC8
		public override string Type
		{
			get
			{
				return "object";
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000394 RID: 916 RVA: 0x0001FBD0 File Offset: 0x0001DDD0
		public global::Jint.Native.JsScope Global
		{
			get
			{
				return this.globalScope ?? this;
			}
		}

		// Token: 0x1700009E RID: 158
		public override global::Jint.Native.JsInstance this[string index]
		{
			get
			{
				if (index == global::Jint.Native.JsScope.THIS && this.thisDescriptor != null)
				{
					return this.thisDescriptor.Get(this);
				}
				if (index == global::Jint.Native.JsScope.ARGUMENTS && this.argumentsDescriptor != null)
				{
					return this.argumentsDescriptor.Get(this);
				}
				return base[index];
			}
			set
			{
				if (index == global::Jint.Native.JsScope.THIS)
				{
					if (this.thisDescriptor != null)
					{
						this.thisDescriptor.Set(this, value);
						return;
					}
					this.DefineOwnProperty(this.thisDescriptor = new global::Jint.Native.ValueDescriptor(this, index, value));
					return;
				}
				else if (index == global::Jint.Native.JsScope.ARGUMENTS)
				{
					if (this.argumentsDescriptor != null)
					{
						this.argumentsDescriptor.Set(this, value);
						return;
					}
					this.DefineOwnProperty(this.argumentsDescriptor = new global::Jint.Native.ValueDescriptor(this, index, value));
					return;
				}
				else
				{
					global::Jint.Native.Descriptor descriptor = this.GetDescriptor(index);
					if (descriptor != null)
					{
						descriptor.Set(this, value);
						return;
					}
					if (this.globalScope != null)
					{
						this.globalScope.DefineOwnProperty(index, value);
						return;
					}
					this.DefineOwnProperty(index, value);
					return;
				}
			}
		}

		// Token: 0x06000397 RID: 919 RVA: 0x0001FD14 File Offset: 0x0001DF14
		public override global::Jint.Native.Descriptor GetDescriptor(string index)
		{
			global::Jint.Native.Descriptor descriptor;
			if ((descriptor = base.GetDescriptor(index)) != null && descriptor.Owner == this)
			{
				return descriptor;
			}
			global::Jint.Native.Descriptor descriptor2;
			if (this.bag != null && (descriptor2 = this.bag.GetDescriptor(index)) != null)
			{
				global::Jint.Native.Descriptor descriptor3 = new global::Jint.Native.LinkedDescriptor(this, descriptor2.Name, descriptor2, this.bag);
				this.DefineOwnProperty(descriptor3);
				return descriptor3;
			}
			return descriptor;
		}

		// Token: 0x06000398 RID: 920 RVA: 0x0001FD80 File Offset: 0x0001DF80
		public override void DefineOwnProperty(string key, global::Jint.Native.JsInstance value)
		{
			if (this.bag != null)
			{
				this.DefineOwnProperty(new global::Jint.Native.ValueDescriptor(this.bag, key, value));
				return;
			}
			this.DefineOwnProperty(new global::Jint.Native.ValueDescriptor(this, key, value));
		}

		// Token: 0x06000399 RID: 921 RVA: 0x0001FDB0 File Offset: 0x0001DFB0
		public override void DefineOwnProperty(global::Jint.Native.Descriptor currentDescriptor)
		{
			if (this.bag != null)
			{
				this.bag.DefineOwnProperty(currentDescriptor);
				return;
			}
			base.DefineOwnProperty(currentDescriptor);
		}

		// Token: 0x0600039A RID: 922 RVA: 0x0001FDD4 File Offset: 0x0001DFD4
		public override bool HasOwnProperty(string key)
		{
			if (this.bag != null)
			{
				return this.bag.HasOwnProperty(key);
			}
			return base.HasOwnProperty(key);
		}

		// Token: 0x0600039B RID: 923 RVA: 0x0001FDF8 File Offset: 0x0001DFF8
		public override global::System.Collections.Generic.IEnumerable<string> GetKeys()
		{
			if (this.bag != null)
			{
				foreach (string key in this.bag.GetKeys())
				{
					if (this.baseGetDescriptor(key) == null)
					{
						yield return key;
					}
				}
			}
			foreach (string key2 in this.baseGetKeys())
			{
				yield return key2;
			}
			yield break;
		}

		// Token: 0x0600039C RID: 924 RVA: 0x0001FE1C File Offset: 0x0001E01C
		private global::Jint.Native.Descriptor baseGetDescriptor(string key)
		{
			return base.GetDescriptor(key);
		}

		// Token: 0x0600039D RID: 925 RVA: 0x0001FE28 File Offset: 0x0001E028
		private global::System.Collections.Generic.IEnumerable<string> baseGetKeys()
		{
			return base.GetKeys();
		}

		// Token: 0x0600039E RID: 926 RVA: 0x0001FE30 File Offset: 0x0001E030
		public override global::System.Collections.Generic.IEnumerable<global::Jint.Native.JsInstance> GetValues()
		{
			foreach (string key in this.GetKeys())
			{
				yield return this[key];
			}
			yield break;
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x0600039F RID: 927 RVA: 0x0001FE54 File Offset: 0x0001E054
		public override bool IsClr
		{
			get
			{
				return this.bag != null && this.bag.IsClr;
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060003A0 RID: 928 RVA: 0x0001FE70 File Offset: 0x0001E070
		// (set) Token: 0x060003A1 RID: 929 RVA: 0x0001FE8C File Offset: 0x0001E08C
		public override object Value
		{
			get
			{
				if (this.bag == null)
				{
					return null;
				}
				return this.bag.Value;
			}
			set
			{
				if (this.bag != null)
				{
					this.bag.Value = value;
				}
			}
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x0001FEA8 File Offset: 0x0001E0A8
		// Note: this type is marked as 'beforefieldinit'.
		static JsScope()
		{
		}

		// Token: 0x04000217 RID: 535
		private global::Jint.Native.Descriptor thisDescriptor;

		// Token: 0x04000218 RID: 536
		private global::Jint.Native.Descriptor argumentsDescriptor;

		// Token: 0x04000219 RID: 537
		private global::Jint.Native.JsScope globalScope;

		// Token: 0x0400021A RID: 538
		private global::Jint.Native.JsDictionaryObject bag;

		// Token: 0x0400021B RID: 539
		public static string THIS = "this";

		// Token: 0x0400021C RID: 540
		public static string ARGUMENTS = "arguments";

		// Token: 0x0200014A RID: 330
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <GetKeys>d__0 : global::System.Collections.Generic.IEnumerable<string>, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerator<string>, global::System.Collections.IEnumerator, global::System.IDisposable
		{
			// Token: 0x06000BDE RID: 3038 RVA: 0x0003BC3C File Offset: 0x00039E3C
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.Generic.IEnumerator<string> global::System.Collections.Generic.IEnumerable<string>.GetEnumerator()
			{
				global::Jint.Native.JsScope.<GetKeys>d__0 <GetKeys>d__;
				if (global::System.Threading.Thread.CurrentThread.ManagedThreadId == this.<>l__initialThreadId && this.<>1__state == -2)
				{
					this.<>1__state = 0;
					<GetKeys>d__ = this;
				}
				else
				{
					<GetKeys>d__ = new global::Jint.Native.JsScope.<GetKeys>d__0(0);
					<GetKeys>d__.<>4__this = this;
				}
				return <GetKeys>d__;
			}

			// Token: 0x06000BDF RID: 3039 RVA: 0x0003BC94 File Offset: 0x00039E94
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<System.String>.GetEnumerator();
			}

			// Token: 0x06000BE0 RID: 3040 RVA: 0x0003BC9C File Offset: 0x00039E9C
			bool global::System.Collections.IEnumerator.MoveNext()
			{
				bool result;
				try
				{
					switch (this.<>1__state)
					{
					case 0:
						this.<>1__state = -1;
						if (this.bag == null)
						{
							goto IL_BF;
						}
						enumerator = this.bag.GetKeys().GetEnumerator();
						this.<>1__state = 1;
						break;
					case 1:
					case 3:
						goto IL_126;
					case 2:
						this.<>1__state = 1;
						break;
					case 4:
						this.<>1__state = 3;
						goto IL_113;
					default:
						goto IL_126;
					}
					while (enumerator.MoveNext())
					{
						key = enumerator.Current;
						if (this.baseGetDescriptor(key) == null)
						{
							this.<>2__current = key;
							this.<>1__state = 2;
							return true;
						}
					}
					this.<>m__Finally4();
					IL_BF:
					enumerator2 = this.baseGetKeys().GetEnumerator();
					this.<>1__state = 3;
					IL_113:
					if (enumerator2.MoveNext())
					{
						key2 = enumerator2.Current;
						this.<>2__current = key2;
						this.<>1__state = 4;
						return true;
					}
					this.<>m__Finally6();
					IL_126:
					result = false;
				}
				catch
				{
					this.System.IDisposable.Dispose();
					throw;
				}
				return result;
			}

			// Token: 0x170002A4 RID: 676
			// (get) Token: 0x06000BE1 RID: 3041 RVA: 0x0003BDFC File Offset: 0x00039FFC
			string global::System.Collections.Generic.IEnumerator<string>.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.<>2__current;
				}
			}

			// Token: 0x06000BE2 RID: 3042 RVA: 0x0003BE04 File Offset: 0x0003A004
			[global::System.Diagnostics.DebuggerHidden]
			void global::System.Collections.IEnumerator.Reset()
			{
				throw new global::System.NotSupportedException();
			}

			// Token: 0x06000BE3 RID: 3043 RVA: 0x0003BE0C File Offset: 0x0003A00C
			void global::System.IDisposable.Dispose()
			{
				switch (this.<>1__state)
				{
				case 1:
				case 2:
					try
					{
					}
					finally
					{
						this.<>m__Finally4();
					}
					break;
				}
				switch (this.<>1__state)
				{
				case 3:
				case 4:
					try
					{
					}
					finally
					{
						this.<>m__Finally6();
					}
					return;
				default:
					return;
				}
			}

			// Token: 0x170002A5 RID: 677
			// (get) Token: 0x06000BE4 RID: 3044 RVA: 0x0003BE84 File Offset: 0x0003A084
			object global::System.Collections.IEnumerator.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.<>2__current;
				}
			}

			// Token: 0x06000BE5 RID: 3045 RVA: 0x0003BE8C File Offset: 0x0003A08C
			[global::System.Diagnostics.DebuggerHidden]
			public <GetKeys>d__0(int <>1__state)
			{
				this.<>1__state = <>1__state;
				this.<>l__initialThreadId = global::System.Threading.Thread.CurrentThread.ManagedThreadId;
			}

			// Token: 0x06000BE6 RID: 3046 RVA: 0x0003BEAC File Offset: 0x0003A0AC
			private void <>m__Finally4()
			{
				this.<>1__state = -1;
				if (enumerator != null)
				{
					enumerator.Dispose();
				}
			}

			// Token: 0x06000BE7 RID: 3047 RVA: 0x0003BECC File Offset: 0x0003A0CC
			private void <>m__Finally6()
			{
				this.<>1__state = -1;
				if (enumerator2 != null)
				{
					enumerator2.Dispose();
				}
			}

			// Token: 0x040006B1 RID: 1713
			private string <>2__current;

			// Token: 0x040006B2 RID: 1714
			private int <>1__state;

			// Token: 0x040006B3 RID: 1715
			private int <>l__initialThreadId;

			// Token: 0x040006B4 RID: 1716
			public global::Jint.Native.JsScope <>4__this;

			// Token: 0x040006B5 RID: 1717
			public string <key>5__1;

			// Token: 0x040006B6 RID: 1718
			public string <key>5__2;

			// Token: 0x040006B7 RID: 1719
			public global::System.Collections.Generic.IEnumerator<string> <>7__wrap3;

			// Token: 0x040006B8 RID: 1720
			public global::System.Collections.Generic.IEnumerator<string> <>7__wrap5;
		}

		// Token: 0x0200014B RID: 331
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <GetValues>d__9 : global::System.Collections.Generic.IEnumerable<global::Jint.Native.JsInstance>, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerator<global::Jint.Native.JsInstance>, global::System.Collections.IEnumerator, global::System.IDisposable
		{
			// Token: 0x06000BE8 RID: 3048 RVA: 0x0003BEEC File Offset: 0x0003A0EC
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.Generic.IEnumerator<global::Jint.Native.JsInstance> global::System.Collections.Generic.IEnumerable<global::Jint.Native.JsInstance>.GetEnumerator()
			{
				global::Jint.Native.JsScope.<GetValues>d__9 <GetValues>d__;
				if (global::System.Threading.Thread.CurrentThread.ManagedThreadId == this.<>l__initialThreadId && this.<>1__state == -2)
				{
					this.<>1__state = 0;
					<GetValues>d__ = this;
				}
				else
				{
					<GetValues>d__ = new global::Jint.Native.JsScope.<GetValues>d__9(0);
					<GetValues>d__.<>4__this = this;
				}
				return <GetValues>d__;
			}

			// Token: 0x06000BE9 RID: 3049 RVA: 0x0003BF44 File Offset: 0x0003A144
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<Jint.Native.JsInstance>.GetEnumerator();
			}

			// Token: 0x06000BEA RID: 3050 RVA: 0x0003BF4C File Offset: 0x0003A14C
			bool global::System.Collections.IEnumerator.MoveNext()
			{
				bool result;
				try
				{
					switch (this.<>1__state)
					{
					case 0:
						this.<>1__state = -1;
						enumerator = this.GetKeys().GetEnumerator();
						this.<>1__state = 1;
						break;
					case 1:
						goto IL_97;
					case 2:
						this.<>1__state = 1;
						break;
					default:
						goto IL_97;
					}
					if (enumerator.MoveNext())
					{
						key = enumerator.Current;
						this.<>2__current = this[key];
						this.<>1__state = 2;
						return true;
					}
					this.<>m__Finallyc();
					IL_97:
					result = false;
				}
				catch
				{
					this.System.IDisposable.Dispose();
					throw;
				}
				return result;
			}

			// Token: 0x170002A6 RID: 678
			// (get) Token: 0x06000BEB RID: 3051 RVA: 0x0003C010 File Offset: 0x0003A210
			global::Jint.Native.JsInstance global::System.Collections.Generic.IEnumerator<global::Jint.Native.JsInstance>.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.<>2__current;
				}
			}

			// Token: 0x06000BEC RID: 3052 RVA: 0x0003C018 File Offset: 0x0003A218
			[global::System.Diagnostics.DebuggerHidden]
			void global::System.Collections.IEnumerator.Reset()
			{
				throw new global::System.NotSupportedException();
			}

			// Token: 0x06000BED RID: 3053 RVA: 0x0003C020 File Offset: 0x0003A220
			void global::System.IDisposable.Dispose()
			{
				switch (this.<>1__state)
				{
				case 1:
				case 2:
					try
					{
					}
					finally
					{
						this.<>m__Finallyc();
					}
					return;
				default:
					return;
				}
			}

			// Token: 0x170002A7 RID: 679
			// (get) Token: 0x06000BEE RID: 3054 RVA: 0x0003C064 File Offset: 0x0003A264
			object global::System.Collections.IEnumerator.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.<>2__current;
				}
			}

			// Token: 0x06000BEF RID: 3055 RVA: 0x0003C06C File Offset: 0x0003A26C
			[global::System.Diagnostics.DebuggerHidden]
			public <GetValues>d__9(int <>1__state)
			{
				this.<>1__state = <>1__state;
				this.<>l__initialThreadId = global::System.Threading.Thread.CurrentThread.ManagedThreadId;
			}

			// Token: 0x06000BF0 RID: 3056 RVA: 0x0003C08C File Offset: 0x0003A28C
			private void <>m__Finallyc()
			{
				this.<>1__state = -1;
				if (enumerator != null)
				{
					enumerator.Dispose();
				}
			}

			// Token: 0x040006B9 RID: 1721
			private global::Jint.Native.JsInstance <>2__current;

			// Token: 0x040006BA RID: 1722
			private int <>1__state;

			// Token: 0x040006BB RID: 1723
			private int <>l__initialThreadId;

			// Token: 0x040006BC RID: 1724
			public global::Jint.Native.JsScope <>4__this;

			// Token: 0x040006BD RID: 1725
			public string <key>5__a;

			// Token: 0x040006BE RID: 1726
			public global::System.Collections.Generic.IEnumerator<string> <>7__wrapb;
		}
	}
}
