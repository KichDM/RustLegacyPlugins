using System;
using System.Collections;
using System.Collections.Generic;
using Jint.Native;

namespace Jint.PropertyBags
{
	// Token: 0x02000089 RID: 137
	public class MiniCachedPropertyBag : global::Jint.IPropertyBag, global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor>>, global::System.Collections.IEnumerable
	{
		// Token: 0x0600060C RID: 1548 RVA: 0x0002B394 File Offset: 0x00029594
		public MiniCachedPropertyBag()
		{
			this.bag = new global::Jint.DictionaryPropertyBag();
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x0002B3A8 File Offset: 0x000295A8
		public global::Jint.Native.Descriptor Put(string name, global::Jint.Native.Descriptor descriptor)
		{
			this.bag.Put(name, descriptor);
			this.lastAccessed = descriptor;
			return descriptor;
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x0002B3D4 File Offset: 0x000295D4
		public void Delete(string name)
		{
			this.bag.Delete(name);
			if (this.lastAccessed != null && this.lastAccessed.Name == name)
			{
				this.lastAccessed = null;
			}
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x0002B40C File Offset: 0x0002960C
		public global::Jint.Native.Descriptor Get(string name)
		{
			if (this.lastAccessed != null && this.lastAccessed.Name == name)
			{
				return this.lastAccessed;
			}
			global::Jint.Native.Descriptor descriptor = this.bag.Get(name);
			if (descriptor != null)
			{
				this.lastAccessed = descriptor;
			}
			return descriptor;
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x0002B460 File Offset: 0x00029660
		public bool TryGet(string name, out global::Jint.Native.Descriptor descriptor)
		{
			if (this.lastAccessed != null && this.lastAccessed.Name == name)
			{
				descriptor = this.lastAccessed;
				return true;
			}
			bool flag = this.bag.TryGet(name, out descriptor);
			if (flag)
			{
				this.lastAccessed = descriptor;
			}
			return flag;
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000611 RID: 1553 RVA: 0x0002B4BC File Offset: 0x000296BC
		public int Count
		{
			get
			{
				return this.bag.Count;
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000612 RID: 1554 RVA: 0x0002B4CC File Offset: 0x000296CC
		public global::System.Collections.Generic.IEnumerable<global::Jint.Native.Descriptor> Values
		{
			get
			{
				return this.bag.Values;
			}
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x0002B4DC File Offset: 0x000296DC
		public global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor>> GetEnumerator()
		{
			return this.bag.GetEnumerator();
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x0002B4EC File Offset: 0x000296EC
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x040002C9 RID: 713
		private global::Jint.IPropertyBag bag;

		// Token: 0x040002CA RID: 714
		private global::Jint.Native.Descriptor lastAccessed;
	}
}
