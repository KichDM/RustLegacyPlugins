using System;
using System.Collections;
using System.Collections.Generic;
using Jint.Native;

namespace Jint
{
	// Token: 0x02000025 RID: 37
	public interface IPropertyBag : global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor>>, global::System.Collections.IEnumerable
	{
		// Token: 0x0600022E RID: 558
		global::Jint.Native.Descriptor Put(string name, global::Jint.Native.Descriptor descriptor);

		// Token: 0x0600022F RID: 559
		void Delete(string name);

		// Token: 0x06000230 RID: 560
		global::Jint.Native.Descriptor Get(string name);

		// Token: 0x06000231 RID: 561
		bool TryGet(string name, out global::Jint.Native.Descriptor descriptor);

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000232 RID: 562
		int Count { get; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000233 RID: 563
		global::System.Collections.Generic.IEnumerable<global::Jint.Native.Descriptor> Values { get; }
	}
}
