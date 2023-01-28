using System;

namespace Mono.Cecil
{
	// Token: 0x0200002D RID: 45
	public class ModuleReference : global::Mono.Cecil.IMetadataScope, global::Mono.Cecil.IMetadataTokenProvider
	{
		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000242 RID: 578 RVA: 0x000074AC File Offset: 0x000056AC
		// (set) Token: 0x06000243 RID: 579 RVA: 0x000074B4 File Offset: 0x000056B4
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

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000244 RID: 580 RVA: 0x000074BD File Offset: 0x000056BD
		public virtual global::Mono.Cecil.MetadataScopeType MetadataScopeType
		{
			get
			{
				return global::Mono.Cecil.MetadataScopeType.ModuleReference;
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000245 RID: 581 RVA: 0x000074C0 File Offset: 0x000056C0
		// (set) Token: 0x06000246 RID: 582 RVA: 0x000074C8 File Offset: 0x000056C8
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

		// Token: 0x06000247 RID: 583 RVA: 0x000074D1 File Offset: 0x000056D1
		internal ModuleReference()
		{
			this.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.ModuleRef);
		}

		// Token: 0x06000248 RID: 584 RVA: 0x000074E9 File Offset: 0x000056E9
		public ModuleReference(string name) : this()
		{
			this.name = name;
		}

		// Token: 0x06000249 RID: 585 RVA: 0x000074F8 File Offset: 0x000056F8
		public override string ToString()
		{
			return this.name;
		}

		// Token: 0x040001A6 RID: 422
		private string name;

		// Token: 0x040001A7 RID: 423
		internal global::Mono.Cecil.MetadataToken token;
	}
}
