using System;

namespace Facepunch.Attributes
{
	// Token: 0x020004F1 RID: 1265
	public abstract class ObjectLookupFieldFixedTypeAttribute : global::Facepunch.Attributes.ObjectLookupFieldAttribute
	{
		// Token: 0x06002BC3 RID: 11203 RVA: 0x000A4218 File Offset: 0x000A2418
		protected ObjectLookupFieldFixedTypeAttribute(global::Facepunch.Attributes.PrefabLookupKinds kinds, global::System.Type minimalType, global::Facepunch.Attributes.SearchMode defaultSearchMode, global::System.Type[] interfacesRequired) : base(kinds, minimalType, defaultSearchMode, interfacesRequired)
		{
		}

		// Token: 0x1700099D RID: 2461
		// (get) Token: 0x06002BC4 RID: 11204 RVA: 0x000A4228 File Offset: 0x000A2428
		public new global::System.Type MinimumType
		{
			get
			{
				return base.MinimumType;
			}
		}

		// Token: 0x0400162D RID: 5677
		public readonly global::System.Type[] RequiredComponents;
	}
}
