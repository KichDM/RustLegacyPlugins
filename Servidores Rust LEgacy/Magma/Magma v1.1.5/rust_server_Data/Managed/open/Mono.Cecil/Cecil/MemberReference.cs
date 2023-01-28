using System;

namespace Mono.Cecil
{
	// Token: 0x02000009 RID: 9
	public abstract class MemberReference : global::Mono.Cecil.IMetadataTokenProvider, global::Mono.Cecil.IReflectionVisitable
	{
		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600002D RID: 45 RVA: 0x000022B1 File Offset: 0x000004B1
		// (set) Token: 0x0600002E RID: 46 RVA: 0x000022B9 File Offset: 0x000004B9
		public virtual string Name
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

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600002F RID: 47
		public abstract string FullName { get; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000030 RID: 48 RVA: 0x000022C2 File Offset: 0x000004C2
		// (set) Token: 0x06000031 RID: 49 RVA: 0x000022CA File Offset: 0x000004CA
		public virtual global::Mono.Cecil.TypeReference DeclaringType
		{
			get
			{
				return this.declaring_type;
			}
			set
			{
				this.declaring_type = value;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000032 RID: 50 RVA: 0x000022D3 File Offset: 0x000004D3
		// (set) Token: 0x06000033 RID: 51 RVA: 0x000022DB File Offset: 0x000004DB
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

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000034 RID: 52 RVA: 0x000022E4 File Offset: 0x000004E4
		internal bool HasImage
		{
			get
			{
				global::Mono.Cecil.ModuleDefinition module = this.Module;
				return module != null && module.HasImage;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00002303 File Offset: 0x00000503
		public virtual global::Mono.Cecil.ModuleDefinition Module
		{
			get
			{
				if (this.declaring_type == null)
				{
					return null;
				}
				return this.declaring_type.Module;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000036 RID: 54 RVA: 0x0000231A File Offset: 0x0000051A
		public virtual bool IsDefinition
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000037 RID: 55 RVA: 0x0000231D File Offset: 0x0000051D
		internal virtual bool ContainsGenericParameter
		{
			get
			{
				return this.declaring_type != null && this.declaring_type.ContainsGenericParameter;
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002334 File Offset: 0x00000534
		internal MemberReference()
		{
		}

		// Token: 0x06000039 RID: 57 RVA: 0x0000233C File Offset: 0x0000053C
		internal MemberReference(string name)
		{
			this.name = (name ?? string.Empty);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002354 File Offset: 0x00000554
		internal string MemberFullName()
		{
			if (this.declaring_type == null)
			{
				return this.name;
			}
			return this.declaring_type.FullName + "::" + this.name;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002380 File Offset: 0x00000580
		public override string ToString()
		{
			return this.FullName;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002388 File Offset: 0x00000588
		public virtual void Accept(global::Mono.Cecil.IReflectionVisitor visitor)
		{
		}

		// Token: 0x04000008 RID: 8
		private string name;

		// Token: 0x04000009 RID: 9
		private global::Mono.Cecil.TypeReference declaring_type;

		// Token: 0x0400000A RID: 10
		internal global::Mono.Cecil.MetadataToken token;
	}
}
