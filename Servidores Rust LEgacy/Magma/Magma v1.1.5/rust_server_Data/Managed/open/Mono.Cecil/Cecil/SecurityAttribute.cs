using System;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x0200004B RID: 75
	public sealed class SecurityAttribute : global::Mono.Cecil.ICustomAttribute
	{
		// Token: 0x17000144 RID: 324
		// (get) Token: 0x0600037C RID: 892 RVA: 0x000098EA File Offset: 0x00007AEA
		// (set) Token: 0x0600037D RID: 893 RVA: 0x000098F2 File Offset: 0x00007AF2
		public global::Mono.Cecil.TypeReference AttributeType
		{
			get
			{
				return this.attribute_type;
			}
			set
			{
				this.attribute_type = value;
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x0600037E RID: 894 RVA: 0x000098FB File Offset: 0x00007AFB
		public bool HasFields
		{
			get
			{
				return !this.fields.IsNullOrEmpty<global::Mono.Cecil.CustomAttributeNamedArgument>();
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x0600037F RID: 895 RVA: 0x0000990C File Offset: 0x00007B0C
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument> Fields
		{
			get
			{
				global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument> result;
				if ((result = this.fields) == null)
				{
					result = (this.fields = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument>());
				}
				return result;
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06000380 RID: 896 RVA: 0x00009931 File Offset: 0x00007B31
		public bool HasProperties
		{
			get
			{
				return !this.properties.IsNullOrEmpty<global::Mono.Cecil.CustomAttributeNamedArgument>();
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000381 RID: 897 RVA: 0x00009944 File Offset: 0x00007B44
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument> Properties
		{
			get
			{
				global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument> result;
				if ((result = this.properties) == null)
				{
					result = (this.properties = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument>());
				}
				return result;
			}
		}

		// Token: 0x06000382 RID: 898 RVA: 0x00009969 File Offset: 0x00007B69
		public SecurityAttribute(global::Mono.Cecil.TypeReference attributeType)
		{
			this.attribute_type = attributeType;
		}

		// Token: 0x0400023C RID: 572
		private global::Mono.Cecil.TypeReference attribute_type;

		// Token: 0x0400023D RID: 573
		internal global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument> fields;

		// Token: 0x0400023E RID: 574
		internal global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument> properties;
	}
}
