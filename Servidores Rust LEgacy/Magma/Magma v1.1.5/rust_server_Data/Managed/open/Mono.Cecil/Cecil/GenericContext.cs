using System;

namespace Mono.Cecil
{
	// Token: 0x020000B3 RID: 179
	public class GenericContext
	{
		// Token: 0x1700028B RID: 651
		// (get) Token: 0x06000748 RID: 1864 RVA: 0x0001363A File Offset: 0x0001183A
		// (set) Token: 0x06000749 RID: 1865 RVA: 0x00013642 File Offset: 0x00011842
		public global::Mono.Cecil.TypeReference Type
		{
			get
			{
				return this.m_type;
			}
			set
			{
				this.m_type = value;
			}
		}

		// Token: 0x1700028C RID: 652
		// (get) Token: 0x0600074A RID: 1866 RVA: 0x0001364B File Offset: 0x0001184B
		// (set) Token: 0x0600074B RID: 1867 RVA: 0x00013653 File Offset: 0x00011853
		public global::Mono.Cecil.MethodReference Method
		{
			get
			{
				return this.m_method;
			}
			set
			{
				this.m_method = value;
			}
		}

		// Token: 0x1700028D RID: 653
		// (get) Token: 0x0600074C RID: 1868 RVA: 0x0001365C File Offset: 0x0001185C
		public bool AllowCreation
		{
			get
			{
				return this.m_type != null && this.m_type.GetType() == typeof(global::Mono.Cecil.TypeReference);
			}
		}

		// Token: 0x1700028E RID: 654
		// (get) Token: 0x0600074D RID: 1869 RVA: 0x0001367F File Offset: 0x0001187F
		public bool Null
		{
			get
			{
				return this.m_type == null && this.m_method == null;
			}
		}

		// Token: 0x0600074E RID: 1870 RVA: 0x00013694 File Offset: 0x00011894
		public GenericContext()
		{
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x0001369C File Offset: 0x0001189C
		public GenericContext(global::Mono.Cecil.TypeReference type, global::Mono.Cecil.MethodReference meth)
		{
			this.m_type = type;
			this.m_method = meth;
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x000136B4 File Offset: 0x000118B4
		public GenericContext(global::Mono.Cecil.IGenericParameterProvider provider)
		{
			if (provider is global::Mono.Cecil.TypeReference)
			{
				this.m_type = (provider as global::Mono.Cecil.TypeReference);
				return;
			}
			if (provider is global::Mono.Cecil.MethodReference)
			{
				global::Mono.Cecil.MethodReference methodReference = provider as global::Mono.Cecil.MethodReference;
				this.m_method = methodReference;
				this.m_type = methodReference.DeclaringType;
			}
		}

		// Token: 0x06000751 RID: 1873 RVA: 0x00013700 File Offset: 0x00011900
		internal void CheckProvider(global::Mono.Cecil.IGenericParameterProvider provider, int count)
		{
			if (!this.AllowCreation)
			{
				return;
			}
			for (int i = provider.GenericParameters.Count; i < count; i++)
			{
				provider.GenericParameters.Add(new global::Mono.Cecil.GenericParameter(provider));
			}
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x00013740 File Offset: 0x00011940
		public global::Mono.Cecil.GenericContext Clone()
		{
			return new global::Mono.Cecil.GenericContext
			{
				Type = this.m_type,
				Method = this.m_method
			};
		}

		// Token: 0x0400058D RID: 1421
		private global::Mono.Cecil.TypeReference m_type;

		// Token: 0x0400058E RID: 1422
		private global::Mono.Cecil.MethodReference m_method;
	}
}
