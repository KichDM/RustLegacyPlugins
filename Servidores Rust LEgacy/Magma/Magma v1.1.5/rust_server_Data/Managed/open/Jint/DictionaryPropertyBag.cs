using System;
using System.Collections;
using System.Collections.Generic;
using Jint.Native;

namespace Jint
{
	// Token: 0x02000026 RID: 38
	internal class DictionaryPropertyBag : global::Jint.IPropertyBag, global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor>>, global::System.Collections.IEnumerable
	{
		// Token: 0x06000234 RID: 564 RVA: 0x0001B4EC File Offset: 0x000196EC
		public global::Jint.Native.Descriptor Put(string name, global::Jint.Native.Descriptor descriptor)
		{
			this.bag[name] = descriptor;
			return descriptor;
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0001B4FC File Offset: 0x000196FC
		public void Delete(string name)
		{
			this.bag.Remove(name);
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0001B50C File Offset: 0x0001970C
		public global::Jint.Native.Descriptor Get(string name)
		{
			global::Jint.Native.Descriptor result;
			this.TryGet(name, out result);
			return result;
		}

		// Token: 0x06000237 RID: 567 RVA: 0x0001B528 File Offset: 0x00019728
		public bool TryGet(string name, out global::Jint.Native.Descriptor descriptor)
		{
			return this.bag.TryGetValue(name, out descriptor);
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000238 RID: 568 RVA: 0x0001B538 File Offset: 0x00019738
		public int Count
		{
			get
			{
				return this.bag.Count;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000239 RID: 569 RVA: 0x0001B548 File Offset: 0x00019748
		public global::System.Collections.Generic.IEnumerable<global::Jint.Native.Descriptor> Values
		{
			get
			{
				return this.bag.Values;
			}
		}

		// Token: 0x0600023A RID: 570 RVA: 0x0001B558 File Offset: 0x00019758
		public global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor>> GetEnumerator()
		{
			return this.bag.GetEnumerator();
		}

		// Token: 0x0600023B RID: 571 RVA: 0x0001B56C File Offset: 0x0001976C
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x0600023C RID: 572 RVA: 0x0001B574 File Offset: 0x00019774
		public DictionaryPropertyBag()
		{
		}

		// Token: 0x040001C8 RID: 456
		private global::System.Collections.Generic.Dictionary<string, global::Jint.Native.Descriptor> bag = new global::System.Collections.Generic.Dictionary<string, global::Jint.Native.Descriptor>(5);
	}
}
