using System;
using System.Runtime.CompilerServices;
using System.Text;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x020000AD RID: 173
	public sealed class PropertyDefinition : global::Mono.Cecil.PropertyReference, global::Mono.Cecil.IMemberDefinition, global::Mono.Cecil.ICustomAttributeProvider, global::Mono.Cecil.IConstantProvider, global::Mono.Cecil.IMetadataTokenProvider
	{
		// Token: 0x0600070C RID: 1804 RVA: 0x00012B29 File Offset: 0x00010D29
		public override void Accept(global::Mono.Cecil.IReflectionVisitor visitor)
		{
			visitor.VisitPropertyDefinition(this);
			visitor.VisitCustomAttributeCollection(this.CustomAttributes);
		}

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x0600070D RID: 1805 RVA: 0x00012B3E File Offset: 0x00010D3E
		// (set) Token: 0x0600070E RID: 1806 RVA: 0x00012B46 File Offset: 0x00010D46
		public global::Mono.Cecil.PropertyAttributes Attributes
		{
			get
			{
				return (global::Mono.Cecil.PropertyAttributes)this.attributes;
			}
			set
			{
				this.attributes = (ushort)value;
			}
		}

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x0600070F RID: 1807 RVA: 0x00012B50 File Offset: 0x00010D50
		// (set) Token: 0x06000710 RID: 1808 RVA: 0x00012B9F File Offset: 0x00010D9F
		public bool HasThis
		{
			get
			{
				if (this.has_this != null)
				{
					return this.has_this.Value;
				}
				if (this.GetMethod != null)
				{
					return this.get_method.HasThis;
				}
				return this.SetMethod != null && this.set_method.HasThis;
			}
			set
			{
				this.has_this = new bool?(value);
			}
		}

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x06000711 RID: 1809 RVA: 0x00012BAD File Offset: 0x00010DAD
		public bool HasCustomAttributes
		{
			get
			{
				if (this.custom_attributes != null)
				{
					return this.custom_attributes.Count > 0;
				}
				return this.GetHasCustomAttributes(this.Module);
			}
		}

		// Token: 0x17000278 RID: 632
		// (get) Token: 0x06000712 RID: 1810 RVA: 0x00012BD4 File Offset: 0x00010DD4
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> CustomAttributes
		{
			get
			{
				global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> result;
				if ((result = this.custom_attributes) == null)
				{
					result = (this.custom_attributes = this.GetCustomAttributes(this.Module));
				}
				return result;
			}
		}

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x06000713 RID: 1811 RVA: 0x00012C00 File Offset: 0x00010E00
		// (set) Token: 0x06000714 RID: 1812 RVA: 0x00012C1D File Offset: 0x00010E1D
		public global::Mono.Cecil.MethodDefinition GetMethod
		{
			get
			{
				if (this.get_method != null)
				{
					return this.get_method;
				}
				this.InitializeMethods();
				return this.get_method;
			}
			set
			{
				this.get_method = value;
			}
		}

		// Token: 0x1700027A RID: 634
		// (get) Token: 0x06000715 RID: 1813 RVA: 0x00012C26 File Offset: 0x00010E26
		// (set) Token: 0x06000716 RID: 1814 RVA: 0x00012C43 File Offset: 0x00010E43
		public global::Mono.Cecil.MethodDefinition SetMethod
		{
			get
			{
				if (this.set_method != null)
				{
					return this.set_method;
				}
				this.InitializeMethods();
				return this.set_method;
			}
			set
			{
				this.set_method = value;
			}
		}

		// Token: 0x1700027B RID: 635
		// (get) Token: 0x06000717 RID: 1815 RVA: 0x00012C4C File Offset: 0x00010E4C
		public bool HasOtherMethods
		{
			get
			{
				if (this.other_methods != null)
				{
					return this.other_methods.Count > 0;
				}
				this.InitializeMethods();
				return !this.other_methods.IsNullOrEmpty<global::Mono.Cecil.MethodDefinition>();
			}
		}

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x06000718 RID: 1816 RVA: 0x00012C7C File Offset: 0x00010E7C
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodDefinition> OtherMethods
		{
			get
			{
				if (this.other_methods != null)
				{
					return this.other_methods;
				}
				this.InitializeMethods();
				if (this.other_methods != null)
				{
					return this.other_methods;
				}
				return this.other_methods = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodDefinition>();
			}
		}

		// Token: 0x1700027D RID: 637
		// (get) Token: 0x06000719 RID: 1817 RVA: 0x00012CBC File Offset: 0x00010EBC
		public bool HasParameters
		{
			get
			{
				this.InitializeMethods();
				if (this.get_method != null)
				{
					return this.get_method.HasParameters;
				}
				return this.set_method != null && this.set_method.HasParameters && this.set_method.Parameters.Count > 1;
			}
		}

		// Token: 0x1700027E RID: 638
		// (get) Token: 0x0600071A RID: 1818 RVA: 0x00012D0F File Offset: 0x00010F0F
		public override global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition> Parameters
		{
			get
			{
				this.InitializeMethods();
				if (this.get_method != null)
				{
					return global::Mono.Cecil.PropertyDefinition.MirrorParameters(this.get_method, 0);
				}
				if (this.set_method != null)
				{
					return global::Mono.Cecil.PropertyDefinition.MirrorParameters(this.set_method, 1);
				}
				return new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition>();
			}
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x00012D48 File Offset: 0x00010F48
		private static global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition> MirrorParameters(global::Mono.Cecil.MethodDefinition method, int bound)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition> collection = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition>();
			if (!method.HasParameters)
			{
				return collection;
			}
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition> parameters = method.Parameters;
			int num = parameters.Count - bound;
			for (int i = 0; i < num; i++)
			{
				collection.Add(parameters[i]);
			}
			return collection;
		}

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x0600071C RID: 1820 RVA: 0x00012D8F File Offset: 0x00010F8F
		// (set) Token: 0x0600071D RID: 1821 RVA: 0x00012DA7 File Offset: 0x00010FA7
		public bool HasConstant
		{
			get
			{
				this.ResolveConstant();
				return this.constant != global::Mono.Cecil.Mixin.NoValue;
			}
			set
			{
				if (!value)
				{
					this.constant = global::Mono.Cecil.Mixin.NoValue;
				}
			}
		}

		// Token: 0x17000280 RID: 640
		// (get) Token: 0x0600071E RID: 1822 RVA: 0x00012DB7 File Offset: 0x00010FB7
		// (set) Token: 0x0600071F RID: 1823 RVA: 0x00012DC9 File Offset: 0x00010FC9
		public object Constant
		{
			get
			{
				if (!this.HasConstant)
				{
					return null;
				}
				return this.constant;
			}
			set
			{
				this.constant = value;
			}
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x00012DD2 File Offset: 0x00010FD2
		private void ResolveConstant()
		{
			if (this.constant != global::Mono.Cecil.Mixin.NotResolved)
			{
				return;
			}
			this.ResolveConstant(ref this.constant, this.Module);
		}

		// Token: 0x17000281 RID: 641
		// (get) Token: 0x06000721 RID: 1825 RVA: 0x00012DF4 File Offset: 0x00010FF4
		// (set) Token: 0x06000722 RID: 1826 RVA: 0x00012E06 File Offset: 0x00011006
		public bool IsSpecialName
		{
			get
			{
				return this.attributes.GetAttributes(0x200);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x200, value);
			}
		}

		// Token: 0x17000282 RID: 642
		// (get) Token: 0x06000723 RID: 1827 RVA: 0x00012E1F File Offset: 0x0001101F
		// (set) Token: 0x06000724 RID: 1828 RVA: 0x00012E31 File Offset: 0x00011031
		public bool IsRuntimeSpecialName
		{
			get
			{
				return this.attributes.GetAttributes(0x400);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x400, value);
			}
		}

		// Token: 0x17000283 RID: 643
		// (get) Token: 0x06000725 RID: 1829 RVA: 0x00012E4A File Offset: 0x0001104A
		// (set) Token: 0x06000726 RID: 1830 RVA: 0x00012E5C File Offset: 0x0001105C
		public bool HasDefault
		{
			get
			{
				return this.attributes.GetAttributes(0x1000);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x1000, value);
			}
		}

		// Token: 0x17000284 RID: 644
		// (get) Token: 0x06000727 RID: 1831 RVA: 0x00012E75 File Offset: 0x00011075
		// (set) Token: 0x06000728 RID: 1832 RVA: 0x00012E82 File Offset: 0x00011082
		public new global::Mono.Cecil.TypeDefinition DeclaringType
		{
			get
			{
				return (global::Mono.Cecil.TypeDefinition)base.DeclaringType;
			}
			set
			{
				base.DeclaringType = value;
			}
		}

		// Token: 0x17000285 RID: 645
		// (get) Token: 0x06000729 RID: 1833 RVA: 0x00012E8B File Offset: 0x0001108B
		public override bool IsDefinition
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x0600072A RID: 1834 RVA: 0x00012E90 File Offset: 0x00011090
		public override string FullName
		{
			get
			{
				global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
				stringBuilder.Append(base.PropertyType.ToString());
				stringBuilder.Append(' ');
				stringBuilder.Append(base.MemberFullName());
				stringBuilder.Append('(');
				if (this.HasParameters)
				{
					global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition> parameters = this.Parameters;
					for (int i = 0; i < parameters.Count; i++)
					{
						if (i > 0)
						{
							stringBuilder.Append(',');
						}
						stringBuilder.Append(parameters[i].ParameterType.FullName);
					}
				}
				stringBuilder.Append(')');
				return stringBuilder.ToString();
			}
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x00012F28 File Offset: 0x00011128
		public PropertyDefinition(string name, global::Mono.Cecil.PropertyAttributes attributes, global::Mono.Cecil.TypeReference propertyType) : base(name, propertyType)
		{
			this.attributes = (ushort)attributes;
			this.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.Property);
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x00012F60 File Offset: 0x00011160
		private void InitializeMethods()
		{
			if (this.get_method != null || this.set_method != null)
			{
				return;
			}
			global::Mono.Cecil.ModuleDefinition module = this.Module;
			if (!module.HasImage())
			{
				return;
			}
			module.Read<global::Mono.Cecil.PropertyDefinition, global::Mono.Cecil.PropertyDefinition>(this, (global::Mono.Cecil.PropertyDefinition property, global::Mono.Cecil.MetadataReader reader) => reader.ReadMethods(property));
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x00012FB3 File Offset: 0x000111B3
		public override global::Mono.Cecil.PropertyDefinition Resolve()
		{
			return this;
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x00012F54 File Offset: 0x00011154
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Cecil.PropertyDefinition <InitializeMethods>b__0(global::Mono.Cecil.PropertyDefinition property, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadMethods(property);
		}

		// Token: 0x0400056F RID: 1391
		private bool? has_this;

		// Token: 0x04000570 RID: 1392
		private ushort attributes;

		// Token: 0x04000571 RID: 1393
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> custom_attributes;

		// Token: 0x04000572 RID: 1394
		internal global::Mono.Cecil.MethodDefinition get_method;

		// Token: 0x04000573 RID: 1395
		internal global::Mono.Cecil.MethodDefinition set_method;

		// Token: 0x04000574 RID: 1396
		internal global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodDefinition> other_methods;

		// Token: 0x04000575 RID: 1397
		private object constant = global::Mono.Cecil.Mixin.NotResolved;

		// Token: 0x04000576 RID: 1398
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.PropertyDefinition, global::Mono.Cecil.MetadataReader, global::Mono.Cecil.PropertyDefinition> CS$<>9__CachedAnonymousMethodDelegate1;
	}
}
