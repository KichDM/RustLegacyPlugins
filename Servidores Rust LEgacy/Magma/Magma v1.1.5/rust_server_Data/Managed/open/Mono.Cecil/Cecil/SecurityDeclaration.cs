using System;
using System.Runtime.CompilerServices;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x02000035 RID: 53
	public sealed class SecurityDeclaration : global::Mono.Cecil.IReflectionVisitable
	{
		// Token: 0x060002E6 RID: 742 RVA: 0x00008F82 File Offset: 0x00007182
		public void Accept(global::Mono.Cecil.IReflectionVisitor visitor)
		{
			visitor.VisitSecurityDeclaration(this);
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x060002E7 RID: 743 RVA: 0x00008F8B File Offset: 0x0000718B
		// (set) Token: 0x060002E8 RID: 744 RVA: 0x00008F93 File Offset: 0x00007193
		public global::Mono.Cecil.SecurityAction Action
		{
			get
			{
				return this.action;
			}
			set
			{
				this.action = value;
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x060002E9 RID: 745 RVA: 0x00008F9C File Offset: 0x0000719C
		public bool HasSecurityAttributes
		{
			get
			{
				this.Resolve();
				return !this.security_attributes.IsNullOrEmpty<global::Mono.Cecil.SecurityAttribute>();
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x060002EA RID: 746 RVA: 0x00008FB4 File Offset: 0x000071B4
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityAttribute> SecurityAttributes
		{
			get
			{
				this.Resolve();
				global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityAttribute> result;
				if ((result = this.security_attributes) == null)
				{
					result = (this.security_attributes = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityAttribute>());
				}
				return result;
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x060002EB RID: 747 RVA: 0x00008FDF File Offset: 0x000071DF
		internal bool HasImage
		{
			get
			{
				return this.module != null && this.module.HasImage;
			}
		}

		// Token: 0x060002EC RID: 748 RVA: 0x00008FF6 File Offset: 0x000071F6
		internal SecurityDeclaration(global::Mono.Cecil.SecurityAction action, uint signature, global::Mono.Cecil.ModuleDefinition module)
		{
			this.action = action;
			this.signature = signature;
			this.module = module;
		}

		// Token: 0x060002ED RID: 749 RVA: 0x00009013 File Offset: 0x00007213
		public SecurityDeclaration(global::Mono.Cecil.SecurityAction action)
		{
			this.action = action;
			this.resolved = true;
		}

		// Token: 0x060002EE RID: 750 RVA: 0x00009038 File Offset: 0x00007238
		public byte[] GetBlob()
		{
			if (!this.HasImage || this.signature == 0U)
			{
				throw new global::System.NotSupportedException();
			}
			return this.module.Read<global::Mono.Cecil.SecurityDeclaration, byte[]>(this, (global::Mono.Cecil.SecurityDeclaration declaration, global::Mono.Cecil.MetadataReader reader) => reader.ReadSecurityDeclarationBlob(declaration.signature));
		}

		// Token: 0x060002EF RID: 751 RVA: 0x0000908E File Offset: 0x0000728E
		private void Resolve()
		{
			if (this.resolved || !this.HasImage)
			{
				return;
			}
			this.module.Read<global::Mono.Cecil.SecurityDeclaration, global::Mono.Cecil.SecurityDeclaration>(this, delegate(global::Mono.Cecil.SecurityDeclaration declaration, global::Mono.Cecil.MetadataReader reader)
			{
				reader.ReadSecurityDeclarationSignature(declaration);
				return this;
			});
			this.resolved = true;
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x00009029 File Offset: 0x00007229
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static byte[] <GetBlob>b__0(global::Mono.Cecil.SecurityDeclaration declaration, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadSecurityDeclarationBlob(declaration.signature);
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x00009084 File Offset: 0x00007284
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Mono.Cecil.SecurityDeclaration <Resolve>b__2(global::Mono.Cecil.SecurityDeclaration declaration, global::Mono.Cecil.MetadataReader reader)
		{
			reader.ReadSecurityDeclarationSignature(declaration);
			return this;
		}

		// Token: 0x040001FF RID: 511
		internal readonly uint signature;

		// Token: 0x04000200 RID: 512
		private readonly global::Mono.Cecil.ModuleDefinition module;

		// Token: 0x04000201 RID: 513
		internal bool resolved;

		// Token: 0x04000202 RID: 514
		private global::Mono.Cecil.SecurityAction action;

		// Token: 0x04000203 RID: 515
		internal global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityAttribute> security_attributes;

		// Token: 0x04000204 RID: 516
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.SecurityDeclaration, global::Mono.Cecil.MetadataReader, byte[]> CS$<>9__CachedAnonymousMethodDelegate1;
	}
}
