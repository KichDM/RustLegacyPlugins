using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Jint.Native;

namespace Jint
{
	// Token: 0x02000027 RID: 39
	internal class DoubleListPropertyBag : global::Jint.IPropertyBag, global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor>>, global::System.Collections.IEnumerable
	{
		// Token: 0x0600023D RID: 573 RVA: 0x0001B588 File Offset: 0x00019788
		public DoubleListPropertyBag()
		{
			this.keys = new global::System.Collections.Generic.List<string>(5);
			this.values = new global::System.Collections.Generic.List<global::Jint.Native.Descriptor>(5);
		}

		// Token: 0x0600023E RID: 574 RVA: 0x0001B5A8 File Offset: 0x000197A8
		public global::Jint.Native.Descriptor Put(string name, global::Jint.Native.Descriptor descriptor)
		{
			lock (this.keys)
			{
				this.keys.Add(name);
				this.values.Add(descriptor);
			}
			return descriptor;
		}

		// Token: 0x0600023F RID: 575 RVA: 0x0001B5F8 File Offset: 0x000197F8
		public void Delete(string name)
		{
			int index = this.keys.IndexOf(name);
			this.keys.RemoveAt(index);
			this.values.RemoveAt(index);
		}

		// Token: 0x06000240 RID: 576 RVA: 0x0001B630 File Offset: 0x00019830
		public global::Jint.Native.Descriptor Get(string name)
		{
			int index = this.keys.IndexOf(name);
			return this.values[index];
		}

		// Token: 0x06000241 RID: 577 RVA: 0x0001B65C File Offset: 0x0001985C
		public bool TryGet(string name, out global::Jint.Native.Descriptor descriptor)
		{
			int num = this.keys.IndexOf(name);
			if (num < 0)
			{
				descriptor = null;
				return false;
			}
			descriptor = this.values[num];
			return true;
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000242 RID: 578 RVA: 0x0001B698 File Offset: 0x00019898
		public int Count
		{
			get
			{
				return this.keys.Count;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000243 RID: 579 RVA: 0x0001B6A8 File Offset: 0x000198A8
		public global::System.Collections.Generic.IEnumerable<global::Jint.Native.Descriptor> Values
		{
			get
			{
				return this.values;
			}
		}

		// Token: 0x06000244 RID: 580 RVA: 0x0001B6B0 File Offset: 0x000198B0
		public global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor>> GetEnumerator()
		{
			for (int i = 0; i < this.keys.Count; i++)
			{
				yield return new global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor>(this.keys[i], this.values[i]);
			}
			yield break;
		}

		// Token: 0x06000245 RID: 581 RVA: 0x0001B6D0 File Offset: 0x000198D0
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x040001C9 RID: 457
		private global::System.Collections.Generic.IList<string> keys;

		// Token: 0x040001CA RID: 458
		private global::System.Collections.Generic.IList<global::Jint.Native.Descriptor> values;

		// Token: 0x02000144 RID: 324
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <GetEnumerator>d__0 : global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor>>, global::System.Collections.IEnumerator, global::System.IDisposable
		{
			// Token: 0x06000BBE RID: 3006 RVA: 0x0003B77C File Offset: 0x0003997C
			bool global::System.Collections.IEnumerator.MoveNext()
			{
				switch (this.<>1__state)
				{
				case 0:
					this.<>1__state = -1;
					i = 0;
					break;
				case 1:
					this.<>1__state = -1;
					i++;
					break;
				default:
					return false;
				}
				if (i < this.keys.Count)
				{
					this.<>2__current = new global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor>(this.keys[i], this.values[i]);
					this.<>1__state = 1;
					return true;
				}
				return false;
			}

			// Token: 0x1700029A RID: 666
			// (get) Token: 0x06000BBF RID: 3007 RVA: 0x0003B828 File Offset: 0x00039A28
			global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor> global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor>>.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.<>2__current;
				}
			}

			// Token: 0x06000BC0 RID: 3008 RVA: 0x0003B830 File Offset: 0x00039A30
			[global::System.Diagnostics.DebuggerHidden]
			void global::System.Collections.IEnumerator.Reset()
			{
				throw new global::System.NotSupportedException();
			}

			// Token: 0x06000BC1 RID: 3009 RVA: 0x0003B838 File Offset: 0x00039A38
			void global::System.IDisposable.Dispose()
			{
			}

			// Token: 0x1700029B RID: 667
			// (get) Token: 0x06000BC2 RID: 3010 RVA: 0x0003B83C File Offset: 0x00039A3C
			object global::System.Collections.IEnumerator.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.<>2__current;
				}
			}

			// Token: 0x06000BC3 RID: 3011 RVA: 0x0003B84C File Offset: 0x00039A4C
			[global::System.Diagnostics.DebuggerHidden]
			public <GetEnumerator>d__0(int <>1__state)
			{
				this.<>1__state = <>1__state;
			}

			// Token: 0x0400069A RID: 1690
			private global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor> <>2__current;

			// Token: 0x0400069B RID: 1691
			private int <>1__state;

			// Token: 0x0400069C RID: 1692
			public global::Jint.DoubleListPropertyBag <>4__this;

			// Token: 0x0400069D RID: 1693
			public int <i>5__1;
		}
	}
}
