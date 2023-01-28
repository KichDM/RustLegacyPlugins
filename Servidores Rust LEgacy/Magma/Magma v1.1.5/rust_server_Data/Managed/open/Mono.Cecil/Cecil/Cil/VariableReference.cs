using System;

namespace Mono.Cecil.Cil
{
	// Token: 0x02000038 RID: 56
	public abstract class VariableReference
	{
		// Token: 0x17000121 RID: 289
		// (get) Token: 0x0600031A RID: 794 RVA: 0x000090EB File Offset: 0x000072EB
		// (set) Token: 0x0600031B RID: 795 RVA: 0x000090F3 File Offset: 0x000072F3
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

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x0600031C RID: 796 RVA: 0x000090FC File Offset: 0x000072FC
		// (set) Token: 0x0600031D RID: 797 RVA: 0x00009104 File Offset: 0x00007304
		public global::Mono.Cecil.TypeReference VariableType
		{
			get
			{
				return this.variable_type;
			}
			set
			{
				this.variable_type = value;
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x0600031E RID: 798 RVA: 0x0000910D File Offset: 0x0000730D
		public int Index
		{
			get
			{
				return this.index;
			}
		}

		// Token: 0x0600031F RID: 799 RVA: 0x00009115 File Offset: 0x00007315
		internal VariableReference(global::Mono.Cecil.TypeReference variable_type) : this(string.Empty, variable_type)
		{
		}

		// Token: 0x06000320 RID: 800 RVA: 0x00009123 File Offset: 0x00007323
		internal VariableReference(string name, global::Mono.Cecil.TypeReference variable_type)
		{
			this.name = name;
			this.variable_type = variable_type;
		}

		// Token: 0x06000321 RID: 801
		public abstract global::Mono.Cecil.Cil.VariableDefinition Resolve();

		// Token: 0x06000322 RID: 802 RVA: 0x00009140 File Offset: 0x00007340
		public override string ToString()
		{
			if (!string.IsNullOrEmpty(this.name))
			{
				return this.name;
			}
			if (this.index >= 0)
			{
				return "V_" + this.index;
			}
			return string.Empty;
		}

		// Token: 0x04000205 RID: 517
		private string name;

		// Token: 0x04000206 RID: 518
		internal int index = -1;

		// Token: 0x04000207 RID: 519
		protected global::Mono.Cecil.TypeReference variable_type;
	}
}
