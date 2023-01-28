using System;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x02000091 RID: 145
	public abstract class PropertyReference : global::Mono.Cecil.MemberReference
	{
		// Token: 0x17000240 RID: 576
		// (get) Token: 0x06000632 RID: 1586 RVA: 0x0000FB20 File Offset: 0x0000DD20
		// (set) Token: 0x06000633 RID: 1587 RVA: 0x0000FB28 File Offset: 0x0000DD28
		public global::Mono.Cecil.TypeReference PropertyType
		{
			get
			{
				return this.property_type;
			}
			set
			{
				this.property_type = value;
			}
		}

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x06000634 RID: 1588
		public abstract global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition> Parameters { get; }

		// Token: 0x06000635 RID: 1589 RVA: 0x0000FB31 File Offset: 0x0000DD31
		internal PropertyReference(string name, global::Mono.Cecil.TypeReference propertyType) : base(name)
		{
			if (propertyType == null)
			{
				throw new global::System.ArgumentNullException("propertyType");
			}
			this.property_type = propertyType;
		}

		// Token: 0x06000636 RID: 1590
		public abstract global::Mono.Cecil.PropertyDefinition Resolve();

		// Token: 0x040004B6 RID: 1206
		private global::Mono.Cecil.TypeReference property_type;
	}
}
