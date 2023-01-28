using System;

namespace Mono.Cecil
{
	// Token: 0x02000015 RID: 21
	public sealed class PInvokeInfo : global::Mono.Cecil.IReflectionVisitable
	{
		// Token: 0x060000E0 RID: 224 RVA: 0x00003F2E File Offset: 0x0000212E
		public void Accept(global::Mono.Cecil.IReflectionVisitor visitor)
		{
			visitor.VisitPInvokeInfo(this);
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x00003F37 File Offset: 0x00002137
		// (set) Token: 0x060000E2 RID: 226 RVA: 0x00003F3F File Offset: 0x0000213F
		public global::Mono.Cecil.PInvokeAttributes Attributes
		{
			get
			{
				return (global::Mono.Cecil.PInvokeAttributes)this.attributes;
			}
			set
			{
				this.attributes = (ushort)value;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x00003F48 File Offset: 0x00002148
		// (set) Token: 0x060000E4 RID: 228 RVA: 0x00003F50 File Offset: 0x00002150
		public string EntryPoint
		{
			get
			{
				return this.entry_point;
			}
			set
			{
				this.entry_point = value;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x00003F59 File Offset: 0x00002159
		// (set) Token: 0x060000E6 RID: 230 RVA: 0x00003F61 File Offset: 0x00002161
		public global::Mono.Cecil.ModuleReference Module
		{
			get
			{
				return this.module;
			}
			set
			{
				this.module = value;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x00003F6A File Offset: 0x0000216A
		// (set) Token: 0x060000E8 RID: 232 RVA: 0x00003F78 File Offset: 0x00002178
		public bool IsNoMangle
		{
			get
			{
				return this.attributes.GetAttributes(1);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(1, value);
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x00003F8D File Offset: 0x0000218D
		// (set) Token: 0x060000EA RID: 234 RVA: 0x00003F9C File Offset: 0x0000219C
		public bool IsCharSetNotSpec
		{
			get
			{
				return this.attributes.GetMaskedAttributes(6, 0U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(6, 0U, value);
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060000EB RID: 235 RVA: 0x00003FB2 File Offset: 0x000021B2
		// (set) Token: 0x060000EC RID: 236 RVA: 0x00003FC1 File Offset: 0x000021C1
		public bool IsCharSetAnsi
		{
			get
			{
				return this.attributes.GetMaskedAttributes(6, 2U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(6, 2U, value);
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060000ED RID: 237 RVA: 0x00003FD7 File Offset: 0x000021D7
		// (set) Token: 0x060000EE RID: 238 RVA: 0x00003FE6 File Offset: 0x000021E6
		public bool IsCharSetUnicode
		{
			get
			{
				return this.attributes.GetMaskedAttributes(6, 4U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(6, 4U, value);
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060000EF RID: 239 RVA: 0x00003FFC File Offset: 0x000021FC
		// (set) Token: 0x060000F0 RID: 240 RVA: 0x0000400B File Offset: 0x0000220B
		public bool IsCharSetAuto
		{
			get
			{
				return this.attributes.GetMaskedAttributes(6, 6U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(6, 6U, value);
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060000F1 RID: 241 RVA: 0x00004021 File Offset: 0x00002221
		// (set) Token: 0x060000F2 RID: 242 RVA: 0x00004030 File Offset: 0x00002230
		public bool SupportsLastError
		{
			get
			{
				return this.attributes.GetAttributes(0x40);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x40, value);
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060000F3 RID: 243 RVA: 0x00004046 File Offset: 0x00002246
		// (set) Token: 0x060000F4 RID: 244 RVA: 0x0000405D File Offset: 0x0000225D
		public bool IsCallConvWinapi
		{
			get
			{
				return this.attributes.GetMaskedAttributes(0x700, 0x100U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(0x700, 0x100U, value);
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060000F5 RID: 245 RVA: 0x0000407B File Offset: 0x0000227B
		// (set) Token: 0x060000F6 RID: 246 RVA: 0x00004092 File Offset: 0x00002292
		public bool IsCallConvCdecl
		{
			get
			{
				return this.attributes.GetMaskedAttributes(0x700, 0x200U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(0x700, 0x200U, value);
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060000F7 RID: 247 RVA: 0x000040B0 File Offset: 0x000022B0
		// (set) Token: 0x060000F8 RID: 248 RVA: 0x000040C7 File Offset: 0x000022C7
		public bool IsCallConvStdCall
		{
			get
			{
				return this.attributes.GetMaskedAttributes(0x700, 0x300U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(0x700, 0x300U, value);
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060000F9 RID: 249 RVA: 0x000040E5 File Offset: 0x000022E5
		// (set) Token: 0x060000FA RID: 250 RVA: 0x000040FC File Offset: 0x000022FC
		public bool IsCallConvThiscall
		{
			get
			{
				return this.attributes.GetMaskedAttributes(0x700, 0x400U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(0x700, 0x400U, value);
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060000FB RID: 251 RVA: 0x0000411A File Offset: 0x0000231A
		// (set) Token: 0x060000FC RID: 252 RVA: 0x00004131 File Offset: 0x00002331
		public bool IsCallConvFastcall
		{
			get
			{
				return this.attributes.GetMaskedAttributes(0x700, 0x500U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(0x700, 0x500U, value);
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060000FD RID: 253 RVA: 0x0000414F File Offset: 0x0000234F
		// (set) Token: 0x060000FE RID: 254 RVA: 0x00004160 File Offset: 0x00002360
		public bool IsBestFitEnabled
		{
			get
			{
				return this.attributes.GetMaskedAttributes(0x30, 0x10U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(0x30, 0x10U, value);
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060000FF RID: 255 RVA: 0x00004178 File Offset: 0x00002378
		// (set) Token: 0x06000100 RID: 256 RVA: 0x00004189 File Offset: 0x00002389
		public bool IsBestFitDisabled
		{
			get
			{
				return this.attributes.GetMaskedAttributes(0x30, 0x20U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(0x30, 0x20U, value);
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000101 RID: 257 RVA: 0x000041A1 File Offset: 0x000023A1
		// (set) Token: 0x06000102 RID: 258 RVA: 0x000041B8 File Offset: 0x000023B8
		public bool IsThrowOnUnmappableCharEnabled
		{
			get
			{
				return this.attributes.GetMaskedAttributes(0x3000, 0x1000U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(0x3000, 0x1000U, value);
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000103 RID: 259 RVA: 0x000041D6 File Offset: 0x000023D6
		// (set) Token: 0x06000104 RID: 260 RVA: 0x000041ED File Offset: 0x000023ED
		public bool IsThrowOnUnmappableCharDisabled
		{
			get
			{
				return this.attributes.GetMaskedAttributes(0x3000, 0x2000U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(0x3000, 0x2000U, value);
			}
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0000420B File Offset: 0x0000240B
		public PInvokeInfo(global::Mono.Cecil.PInvokeAttributes attributes, string entryPoint, global::Mono.Cecil.ModuleReference module)
		{
			this.attributes = (ushort)attributes;
			this.entry_point = entryPoint;
			this.module = module;
		}

		// Token: 0x04000057 RID: 87
		private ushort attributes;

		// Token: 0x04000058 RID: 88
		private string entry_point;

		// Token: 0x04000059 RID: 89
		private global::Mono.Cecil.ModuleReference module;
	}
}
