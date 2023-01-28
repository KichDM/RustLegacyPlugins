using System;
using System.Text;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x020000C2 RID: 194
	public sealed class CallSite : global::Mono.Cecil.IMethodSignature, global::Mono.Cecil.IMetadataTokenProvider
	{
		// Token: 0x1700029F RID: 671
		// (get) Token: 0x060007C8 RID: 1992 RVA: 0x0001549F File Offset: 0x0001369F
		// (set) Token: 0x060007C9 RID: 1993 RVA: 0x000154AC File Offset: 0x000136AC
		public bool HasThis
		{
			get
			{
				return this.signature.HasThis;
			}
			set
			{
				this.signature.HasThis = value;
			}
		}

		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x060007CA RID: 1994 RVA: 0x000154BA File Offset: 0x000136BA
		// (set) Token: 0x060007CB RID: 1995 RVA: 0x000154C7 File Offset: 0x000136C7
		public bool ExplicitThis
		{
			get
			{
				return this.signature.ExplicitThis;
			}
			set
			{
				this.signature.ExplicitThis = value;
			}
		}

		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x060007CC RID: 1996 RVA: 0x000154D5 File Offset: 0x000136D5
		// (set) Token: 0x060007CD RID: 1997 RVA: 0x000154E2 File Offset: 0x000136E2
		public global::Mono.Cecil.MethodCallingConvention CallingConvention
		{
			get
			{
				return this.signature.CallingConvention;
			}
			set
			{
				this.signature.CallingConvention = value;
			}
		}

		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x060007CE RID: 1998 RVA: 0x000154F0 File Offset: 0x000136F0
		public bool HasParameters
		{
			get
			{
				return this.signature.HasParameters;
			}
		}

		// Token: 0x170002A3 RID: 675
		// (get) Token: 0x060007CF RID: 1999 RVA: 0x000154FD File Offset: 0x000136FD
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition> Parameters
		{
			get
			{
				return this.signature.Parameters;
			}
		}

		// Token: 0x170002A4 RID: 676
		// (get) Token: 0x060007D0 RID: 2000 RVA: 0x0001550A File Offset: 0x0001370A
		// (set) Token: 0x060007D1 RID: 2001 RVA: 0x0001551C File Offset: 0x0001371C
		public global::Mono.Cecil.TypeReference ReturnType
		{
			get
			{
				return this.signature.MethodReturnType.ReturnType;
			}
			set
			{
				this.signature.MethodReturnType.ReturnType = value;
			}
		}

		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x060007D2 RID: 2002 RVA: 0x0001552F File Offset: 0x0001372F
		public global::Mono.Cecil.MethodReturnType MethodReturnType
		{
			get
			{
				return this.signature.MethodReturnType;
			}
		}

		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x060007D3 RID: 2003 RVA: 0x0001553C File Offset: 0x0001373C
		// (set) Token: 0x060007D4 RID: 2004 RVA: 0x00015543 File Offset: 0x00013743
		public string Name
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

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x060007D5 RID: 2005 RVA: 0x0001554A File Offset: 0x0001374A
		// (set) Token: 0x060007D6 RID: 2006 RVA: 0x00015551 File Offset: 0x00013751
		public string Namespace
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

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x060007D7 RID: 2007 RVA: 0x00015558 File Offset: 0x00013758
		public global::Mono.Cecil.ModuleDefinition Module
		{
			get
			{
				return this.ReturnType.Module;
			}
		}

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x060007D8 RID: 2008 RVA: 0x00015565 File Offset: 0x00013765
		public global::Mono.Cecil.IMetadataScope Scope
		{
			get
			{
				return this.signature.ReturnType.Scope;
			}
		}

		// Token: 0x170002AA RID: 682
		// (get) Token: 0x060007D9 RID: 2009 RVA: 0x00015577 File Offset: 0x00013777
		// (set) Token: 0x060007DA RID: 2010 RVA: 0x00015584 File Offset: 0x00013784
		public global::Mono.Cecil.MetadataToken MetadataToken
		{
			get
			{
				return this.signature.token;
			}
			set
			{
				this.signature.token = value;
			}
		}

		// Token: 0x170002AB RID: 683
		// (get) Token: 0x060007DB RID: 2011 RVA: 0x00015594 File Offset: 0x00013794
		public string FullName
		{
			get
			{
				global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
				stringBuilder.Append(this.ReturnType.FullName);
				this.MethodSignatureFullName(stringBuilder);
				return stringBuilder.ToString();
			}
		}

		// Token: 0x060007DC RID: 2012 RVA: 0x000155C6 File Offset: 0x000137C6
		internal CallSite()
		{
			this.signature = new global::Mono.Cecil.MethodReference();
			this.signature.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.Signature, 0);
		}

		// Token: 0x060007DD RID: 2013 RVA: 0x000155EF File Offset: 0x000137EF
		public CallSite(global::Mono.Cecil.TypeReference returnType) : this()
		{
			if (returnType == null)
			{
				throw new global::System.ArgumentNullException("returnType");
			}
			this.signature.ReturnType = returnType;
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x00015611 File Offset: 0x00013811
		public override string ToString()
		{
			return this.FullName;
		}

		// Token: 0x040005D2 RID: 1490
		private readonly global::Mono.Cecil.MethodReference signature;
	}
}
