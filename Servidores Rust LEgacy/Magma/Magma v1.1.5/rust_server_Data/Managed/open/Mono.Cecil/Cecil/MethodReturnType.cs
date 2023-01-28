using System;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x02000008 RID: 8
	public sealed class MethodReturnType : global::Mono.Cecil.IConstantProvider, global::Mono.Cecil.ICustomAttributeProvider, global::Mono.Cecil.IMarshalInfoProvider, global::Mono.Cecil.IMetadataTokenProvider
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000018 RID: 24 RVA: 0x00002147 File Offset: 0x00000347
		public global::Mono.Cecil.IMethodSignature Method
		{
			get
			{
				return this.method;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000019 RID: 25 RVA: 0x0000214F File Offset: 0x0000034F
		// (set) Token: 0x0600001A RID: 26 RVA: 0x00002157 File Offset: 0x00000357
		public global::Mono.Cecil.TypeReference ReturnType
		{
			get
			{
				return this.return_type;
			}
			set
			{
				this.return_type = value;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600001B RID: 27 RVA: 0x00002160 File Offset: 0x00000360
		// (set) Token: 0x0600001C RID: 28 RVA: 0x0000218B File Offset: 0x0000038B
		internal global::Mono.Cecil.ParameterDefinition Parameter
		{
			get
			{
				global::Mono.Cecil.ParameterDefinition result;
				if ((result = this.parameter) == null)
				{
					result = (this.parameter = new global::Mono.Cecil.ParameterDefinition(this.return_type));
				}
				return result;
			}
			set
			{
				this.parameter = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600001D RID: 29 RVA: 0x00002194 File Offset: 0x00000394
		// (set) Token: 0x0600001E RID: 30 RVA: 0x000021A1 File Offset: 0x000003A1
		public global::Mono.Cecil.MetadataToken MetadataToken
		{
			get
			{
				return this.Parameter.MetadataToken;
			}
			set
			{
				this.Parameter.MetadataToken = value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600001F RID: 31 RVA: 0x000021AF File Offset: 0x000003AF
		public bool HasCustomAttributes
		{
			get
			{
				return this.parameter != null && this.parameter.HasCustomAttributes;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000020 RID: 32 RVA: 0x000021C6 File Offset: 0x000003C6
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> CustomAttributes
		{
			get
			{
				return this.Parameter.CustomAttributes;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000021 RID: 33 RVA: 0x000021D3 File Offset: 0x000003D3
		// (set) Token: 0x06000022 RID: 34 RVA: 0x000021EA File Offset: 0x000003EA
		public bool HasDefault
		{
			get
			{
				return this.parameter != null && this.parameter.HasDefault;
			}
			set
			{
				this.Parameter.HasDefault = value;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000023 RID: 35 RVA: 0x000021F8 File Offset: 0x000003F8
		// (set) Token: 0x06000024 RID: 36 RVA: 0x0000220F File Offset: 0x0000040F
		public bool HasConstant
		{
			get
			{
				return this.parameter != null && this.parameter.HasConstant;
			}
			set
			{
				this.parameter.HasConstant = value;
				if (!value)
				{
					this.parameter.Constant = global::Mono.Cecil.Mixin.NoValue;
				}
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00002230 File Offset: 0x00000430
		// (set) Token: 0x06000026 RID: 38 RVA: 0x0000223D File Offset: 0x0000043D
		public object Constant
		{
			get
			{
				return this.Parameter.Constant;
			}
			set
			{
				this.Parameter.Constant = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000027 RID: 39 RVA: 0x0000224B File Offset: 0x0000044B
		// (set) Token: 0x06000028 RID: 40 RVA: 0x00002262 File Offset: 0x00000462
		public bool HasFieldMarshal
		{
			get
			{
				return this.parameter != null && this.parameter.HasFieldMarshal;
			}
			set
			{
				this.Parameter.HasFieldMarshal = value;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00002270 File Offset: 0x00000470
		public bool HasMarshalInfo
		{
			get
			{
				return this.parameter != null && this.parameter.HasMarshalInfo;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600002A RID: 42 RVA: 0x00002287 File Offset: 0x00000487
		// (set) Token: 0x0600002B RID: 43 RVA: 0x00002294 File Offset: 0x00000494
		public global::Mono.Cecil.MarshalInfo MarshalInfo
		{
			get
			{
				return this.Parameter.MarshalInfo;
			}
			set
			{
				this.Parameter.MarshalInfo = value;
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000022A2 File Offset: 0x000004A2
		public MethodReturnType(global::Mono.Cecil.IMethodSignature method)
		{
			this.method = method;
		}

		// Token: 0x04000005 RID: 5
		internal global::Mono.Cecil.IMethodSignature method;

		// Token: 0x04000006 RID: 6
		internal global::Mono.Cecil.ParameterDefinition parameter;

		// Token: 0x04000007 RID: 7
		private global::Mono.Cecil.TypeReference return_type;
	}
}
