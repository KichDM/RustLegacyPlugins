using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Jint.Native;

namespace Jint.PropertyBags
{
	// Token: 0x02000033 RID: 51
	public class HashedPropertyBag : global::Jint.IPropertyBag, global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor>>, global::System.Collections.IEnumerable
	{
		// Token: 0x06000281 RID: 641 RVA: 0x0001B978 File Offset: 0x00019B78
		public HashedPropertyBag()
		{
			this.keys = new global::System.Collections.Hashtable();
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0001B98C File Offset: 0x00019B8C
		public global::Jint.Native.Descriptor Put(string name, global::Jint.Native.Descriptor descriptor)
		{
			this.keys.Add(name, descriptor);
			return descriptor;
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0001B99C File Offset: 0x00019B9C
		public void Delete(string name)
		{
			this.keys.Remove(name);
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0001B9AC File Offset: 0x00019BAC
		public global::Jint.Native.Descriptor Get(string name)
		{
			return this.keys[name] as global::Jint.Native.Descriptor;
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0001B9C0 File Offset: 0x00019BC0
		public bool TryGet(string name, out global::Jint.Native.Descriptor descriptor)
		{
			descriptor = this.Get(name);
			return descriptor != null;
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000286 RID: 646 RVA: 0x0001B9D4 File Offset: 0x00019BD4
		public int Count
		{
			get
			{
				return this.keys.Count;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000287 RID: 647 RVA: 0x0001B9E4 File Offset: 0x00019BE4
		public global::System.Collections.Generic.IEnumerable<global::Jint.Native.Descriptor> Values
		{
			get
			{
				foreach (object obj in this.keys)
				{
					global::System.Collections.DictionaryEntry de = (global::System.Collections.DictionaryEntry)obj;
					global::System.Collections.DictionaryEntry dictionaryEntry = de;
					yield return dictionaryEntry.Value as global::Jint.Native.Descriptor;
				}
				yield break;
			}
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0001BA08 File Offset: 0x00019C08
		public global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor>> GetEnumerator()
		{
			foreach (object obj in this.keys)
			{
				global::System.Collections.DictionaryEntry de = (global::System.Collections.DictionaryEntry)obj;
				global::System.Collections.DictionaryEntry dictionaryEntry = de;
				string key = dictionaryEntry.Key as string;
				global::System.Collections.DictionaryEntry dictionaryEntry2 = de;
				yield return new global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor>(key, dictionaryEntry2.Value as global::Jint.Native.Descriptor);
			}
			yield break;
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0001BA28 File Offset: 0x00019C28
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x040001E1 RID: 481
		private global::System.Collections.Hashtable keys;

		// Token: 0x02000146 RID: 326
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <get_Values>d__0 : global::System.Collections.Generic.IEnumerable<global::Jint.Native.Descriptor>, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerator<global::Jint.Native.Descriptor>, global::System.Collections.IEnumerator, global::System.IDisposable
		{
			// Token: 0x06000BC9 RID: 3017 RVA: 0x0003B89C File Offset: 0x00039A9C
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.Generic.IEnumerator<global::Jint.Native.Descriptor> global::System.Collections.Generic.IEnumerable<global::Jint.Native.Descriptor>.GetEnumerator()
			{
				global::Jint.PropertyBags.HashedPropertyBag.<get_Values>d__0 <get_Values>d__;
				if (global::System.Threading.Thread.CurrentThread.ManagedThreadId == this.<>l__initialThreadId && this.<>1__state == -2)
				{
					this.<>1__state = 0;
					<get_Values>d__ = this;
				}
				else
				{
					<get_Values>d__ = new global::Jint.PropertyBags.HashedPropertyBag.<get_Values>d__0(0);
					<get_Values>d__.<>4__this = this;
				}
				return <get_Values>d__;
			}

			// Token: 0x06000BCA RID: 3018 RVA: 0x0003B8F4 File Offset: 0x00039AF4
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<Jint.Native.Descriptor>.GetEnumerator();
			}

			// Token: 0x06000BCB RID: 3019 RVA: 0x0003B8FC File Offset: 0x00039AFC
			bool global::System.Collections.IEnumerator.MoveNext()
			{
				bool result;
				try
				{
					switch (this.<>1__state)
					{
					case 0:
						this.<>1__state = -1;
						enumerator = this.keys.GetEnumerator();
						this.<>1__state = 1;
						break;
					case 1:
						goto IL_9E;
					case 2:
						this.<>1__state = 1;
						break;
					default:
						goto IL_9E;
					}
					if (enumerator.MoveNext())
					{
						de = (global::System.Collections.DictionaryEntry)enumerator.Current;
						global::System.Collections.DictionaryEntry dictionaryEntry = de;
						this.<>2__current = (dictionaryEntry.Value as global::Jint.Native.Descriptor);
						this.<>1__state = 2;
						return true;
					}
					this.<>m__Finally4();
					IL_9E:
					result = false;
				}
				catch
				{
					this.System.IDisposable.Dispose();
					throw;
				}
				return result;
			}

			// Token: 0x1700029E RID: 670
			// (get) Token: 0x06000BCC RID: 3020 RVA: 0x0003B9C8 File Offset: 0x00039BC8
			global::Jint.Native.Descriptor global::System.Collections.Generic.IEnumerator<global::Jint.Native.Descriptor>.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.<>2__current;
				}
			}

			// Token: 0x06000BCD RID: 3021 RVA: 0x0003B9D0 File Offset: 0x00039BD0
			[global::System.Diagnostics.DebuggerHidden]
			void global::System.Collections.IEnumerator.Reset()
			{
				throw new global::System.NotSupportedException();
			}

			// Token: 0x06000BCE RID: 3022 RVA: 0x0003B9D8 File Offset: 0x00039BD8
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
					return;
				default:
					return;
				}
			}

			// Token: 0x1700029F RID: 671
			// (get) Token: 0x06000BCF RID: 3023 RVA: 0x0003BA1C File Offset: 0x00039C1C
			object global::System.Collections.IEnumerator.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.<>2__current;
				}
			}

			// Token: 0x06000BD0 RID: 3024 RVA: 0x0003BA24 File Offset: 0x00039C24
			[global::System.Diagnostics.DebuggerHidden]
			public <get_Values>d__0(int <>1__state)
			{
				this.<>1__state = <>1__state;
				this.<>l__initialThreadId = global::System.Threading.Thread.CurrentThread.ManagedThreadId;
			}

			// Token: 0x06000BD1 RID: 3025 RVA: 0x0003BA44 File Offset: 0x00039C44
			private void <>m__Finally4()
			{
				this.<>1__state = -1;
				disposable = (enumerator as global::System.IDisposable);
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}

			// Token: 0x040006A0 RID: 1696
			private global::Jint.Native.Descriptor <>2__current;

			// Token: 0x040006A1 RID: 1697
			private int <>1__state;

			// Token: 0x040006A2 RID: 1698
			private int <>l__initialThreadId;

			// Token: 0x040006A3 RID: 1699
			public global::Jint.PropertyBags.HashedPropertyBag <>4__this;

			// Token: 0x040006A4 RID: 1700
			public global::System.Collections.DictionaryEntry <de>5__1;

			// Token: 0x040006A5 RID: 1701
			public global::System.Collections.IDictionaryEnumerator <>7__wrap2;

			// Token: 0x040006A6 RID: 1702
			public global::System.IDisposable <>7__wrap3;
		}

		// Token: 0x02000147 RID: 327
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <GetEnumerator>d__7 : global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor>>, global::System.Collections.IEnumerator, global::System.IDisposable
		{
			// Token: 0x06000BD2 RID: 3026 RVA: 0x0003BA74 File Offset: 0x00039C74
			bool global::System.Collections.IEnumerator.MoveNext()
			{
				bool result;
				try
				{
					switch (this.<>1__state)
					{
					case 0:
						this.<>1__state = -1;
						enumerator = this.keys.GetEnumerator();
						this.<>1__state = 1;
						break;
					case 1:
						goto IL_B6;
					case 2:
						this.<>1__state = 1;
						break;
					default:
						goto IL_B6;
					}
					if (enumerator.MoveNext())
					{
						de = (global::System.Collections.DictionaryEntry)enumerator.Current;
						global::System.Collections.DictionaryEntry dictionaryEntry = de;
						string key = dictionaryEntry.Key as string;
						global::System.Collections.DictionaryEntry dictionaryEntry2 = de;
						this.<>2__current = new global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor>(key, dictionaryEntry2.Value as global::Jint.Native.Descriptor);
						this.<>1__state = 2;
						return true;
					}
					this.<>m__Finallyb();
					IL_B6:
					result = false;
				}
				catch
				{
					this.System.IDisposable.Dispose();
					throw;
				}
				return result;
			}

			// Token: 0x170002A0 RID: 672
			// (get) Token: 0x06000BD3 RID: 3027 RVA: 0x0003BB58 File Offset: 0x00039D58
			global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor> global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor>>.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.<>2__current;
				}
			}

			// Token: 0x06000BD4 RID: 3028 RVA: 0x0003BB60 File Offset: 0x00039D60
			[global::System.Diagnostics.DebuggerHidden]
			void global::System.Collections.IEnumerator.Reset()
			{
				throw new global::System.NotSupportedException();
			}

			// Token: 0x06000BD5 RID: 3029 RVA: 0x0003BB68 File Offset: 0x00039D68
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
						this.<>m__Finallyb();
					}
					return;
				default:
					return;
				}
			}

			// Token: 0x170002A1 RID: 673
			// (get) Token: 0x06000BD6 RID: 3030 RVA: 0x0003BBAC File Offset: 0x00039DAC
			object global::System.Collections.IEnumerator.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.<>2__current;
				}
			}

			// Token: 0x06000BD7 RID: 3031 RVA: 0x0003BBBC File Offset: 0x00039DBC
			[global::System.Diagnostics.DebuggerHidden]
			public <GetEnumerator>d__7(int <>1__state)
			{
				this.<>1__state = <>1__state;
			}

			// Token: 0x06000BD8 RID: 3032 RVA: 0x0003BBCC File Offset: 0x00039DCC
			private void <>m__Finallyb()
			{
				this.<>1__state = -1;
				disposable = (enumerator as global::System.IDisposable);
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}

			// Token: 0x040006A7 RID: 1703
			private global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor> <>2__current;

			// Token: 0x040006A8 RID: 1704
			private int <>1__state;

			// Token: 0x040006A9 RID: 1705
			public global::Jint.PropertyBags.HashedPropertyBag <>4__this;

			// Token: 0x040006AA RID: 1706
			public global::System.Collections.DictionaryEntry <de>5__8;

			// Token: 0x040006AB RID: 1707
			public global::System.Collections.IDictionaryEnumerator <>7__wrap9;

			// Token: 0x040006AC RID: 1708
			public global::System.IDisposable <>7__wrapa;
		}
	}
}
