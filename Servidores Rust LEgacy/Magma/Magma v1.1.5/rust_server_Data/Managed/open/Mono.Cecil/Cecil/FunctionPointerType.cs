using System;
using System.Text;
using Mono.Cecil.Metadata;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x0200009F RID: 159
	public sealed class FunctionPointerType : global::Mono.Cecil.TypeSpecification, global::Mono.Cecil.IMethodSignature, global::Mono.Cecil.IMetadataTokenProvider
	{
		// Token: 0x17000255 RID: 597
		// (get) Token: 0x06000679 RID: 1657 RVA: 0x000103C3 File Offset: 0x0000E5C3
		// (set) Token: 0x0600067A RID: 1658 RVA: 0x000103D0 File Offset: 0x0000E5D0
		public bool HasThis
		{
			get
			{
				return this.function.HasThis;
			}
			set
			{
				this.function.HasThis = value;
			}
		}

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x0600067B RID: 1659 RVA: 0x000103DE File Offset: 0x0000E5DE
		// (set) Token: 0x0600067C RID: 1660 RVA: 0x000103EB File Offset: 0x0000E5EB
		public bool ExplicitThis
		{
			get
			{
				return this.function.ExplicitThis;
			}
			set
			{
				this.function.ExplicitThis = value;
			}
		}

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x0600067D RID: 1661 RVA: 0x000103F9 File Offset: 0x0000E5F9
		// (set) Token: 0x0600067E RID: 1662 RVA: 0x00010406 File Offset: 0x0000E606
		public global::Mono.Cecil.MethodCallingConvention CallingConvention
		{
			get
			{
				return this.function.CallingConvention;
			}
			set
			{
				this.function.CallingConvention = value;
			}
		}

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x0600067F RID: 1663 RVA: 0x00010414 File Offset: 0x0000E614
		public bool HasParameters
		{
			get
			{
				return this.function.HasParameters;
			}
		}

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x06000680 RID: 1664 RVA: 0x00010421 File Offset: 0x0000E621
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition> Parameters
		{
			get
			{
				return this.function.Parameters;
			}
		}

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x06000681 RID: 1665 RVA: 0x0001042E File Offset: 0x0000E62E
		// (set) Token: 0x06000682 RID: 1666 RVA: 0x00010440 File Offset: 0x0000E640
		public global::Mono.Cecil.TypeReference ReturnType
		{
			get
			{
				return this.function.MethodReturnType.ReturnType;
			}
			set
			{
				this.function.MethodReturnType.ReturnType = value;
			}
		}

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x06000683 RID: 1667 RVA: 0x00010453 File Offset: 0x0000E653
		public global::Mono.Cecil.MethodReturnType MethodReturnType
		{
			get
			{
				return this.function.MethodReturnType;
			}
		}

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x06000684 RID: 1668 RVA: 0x00010460 File Offset: 0x0000E660
		// (set) Token: 0x06000685 RID: 1669 RVA: 0x0001046D File Offset: 0x0000E66D
		public override string Name
		{
			get
			{
				return this.function.Name;
			}
			set
			{
				throw new global::System.InvalidOperationException();
			}
		}

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x06000686 RID: 1670 RVA: 0x00010474 File Offset: 0x0000E674
		// (set) Token: 0x06000687 RID: 1671 RVA: 0x0001047B File Offset: 0x0000E67B
		public override string Namespace
		{
			get
			{
				return string.Empty;
			}
			set
			{
				throw new global::System.InvalidOperationException();
			}
		}

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x06000688 RID: 1672 RVA: 0x00010482 File Offset: 0x0000E682
		public override global::Mono.Cecil.ModuleDefinition Module
		{
			get
			{
				return this.ReturnType.Module;
			}
		}

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x06000689 RID: 1673 RVA: 0x0001048F File Offset: 0x0000E68F
		public override global::Mono.Cecil.IMetadataScope Scope
		{
			get
			{
				return this.function.ReturnType.Scope;
			}
		}

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x0600068A RID: 1674 RVA: 0x000104A1 File Offset: 0x0000E6A1
		public override bool IsFunctionPointer
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x0600068B RID: 1675 RVA: 0x000104A4 File Offset: 0x0000E6A4
		internal override bool ContainsGenericParameter
		{
			get
			{
				return this.function.ContainsGenericParameter;
			}
		}

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x0600068C RID: 1676 RVA: 0x000104B4 File Offset: 0x0000E6B4
		public override string FullName
		{
			get
			{
				global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
				stringBuilder.Append(this.function.Name);
				stringBuilder.Append(" ");
				stringBuilder.Append(this.function.ReturnType.FullName);
				stringBuilder.Append(" *");
				this.MethodSignatureFullName(stringBuilder);
				return stringBuilder.ToString();
			}
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x00010515 File Offset: 0x0000E715
		public FunctionPointerType() : base(null)
		{
			this.function = new global::Mono.Cecil.MethodReference();
			this.function.Name = "method";
			this.etype = global::Mono.Cecil.Metadata.ElementType.FnPtr;
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x00010541 File Offset: 0x0000E741
		public override global::Mono.Cecil.TypeDefinition Resolve()
		{
			return null;
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x00010544 File Offset: 0x0000E744
		public override global::Mono.Cecil.TypeReference GetElementType()
		{
			return this;
		}

		// Token: 0x04000501 RID: 1281
		private readonly global::Mono.Cecil.MethodReference function;
	}
}
