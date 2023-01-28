using System;

namespace Mono.Cecil
{
	// Token: 0x02000004 RID: 4
	public abstract class ParameterReference : global::Mono.Cecil.IMetadataTokenProvider, global::Mono.Cecil.IReflectionVisitable
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000004 RID: 4 RVA: 0x000020D0 File Offset: 0x000002D0
		// (set) Token: 0x06000005 RID: 5 RVA: 0x000020D8 File Offset: 0x000002D8
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000006 RID: 6 RVA: 0x000020E1 File Offset: 0x000002E1
		public int Index
		{
			get
			{
				return this.index;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000007 RID: 7 RVA: 0x000020E9 File Offset: 0x000002E9
		// (set) Token: 0x06000008 RID: 8 RVA: 0x000020F1 File Offset: 0x000002F1
		public global::Mono.Cecil.TypeReference ParameterType
		{
			get
			{
				return this.parameter_type;
			}
			set
			{
				this.parameter_type = value;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000009 RID: 9 RVA: 0x000020FA File Offset: 0x000002FA
		// (set) Token: 0x0600000A RID: 10 RVA: 0x00002102 File Offset: 0x00000302
		public global::Mono.Cecil.MetadataToken MetadataToken
		{
			get
			{
				return this.token;
			}
			set
			{
				this.token = value;
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000210B File Offset: 0x0000030B
		internal ParameterReference(string name, global::Mono.Cecil.TypeReference parameterType)
		{
			if (parameterType == null)
			{
				throw new global::System.ArgumentNullException("parameterType");
			}
			this.name = (name ?? string.Empty);
			this.parameter_type = parameterType;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x0000213F File Offset: 0x0000033F
		public override string ToString()
		{
			return this.name;
		}

		// Token: 0x0600000D RID: 13
		public abstract global::Mono.Cecil.ParameterDefinition Resolve();

		// Token: 0x0600000E RID: 14
		public abstract void Accept(global::Mono.Cecil.IReflectionVisitor visitor);

		// Token: 0x04000001 RID: 1
		private string name;

		// Token: 0x04000002 RID: 2
		internal int index = -1;

		// Token: 0x04000003 RID: 3
		protected global::Mono.Cecil.TypeReference parameter_type;

		// Token: 0x04000004 RID: 4
		internal global::Mono.Cecil.MetadataToken token;
	}
}
