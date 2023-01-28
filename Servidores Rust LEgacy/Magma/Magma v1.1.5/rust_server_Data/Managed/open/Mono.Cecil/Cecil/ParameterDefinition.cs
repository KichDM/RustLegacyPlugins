using System;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x02000079 RID: 121
	public sealed class ParameterDefinition : global::Mono.Cecil.ParameterReference, global::Mono.Cecil.ICustomAttributeProvider, global::Mono.Cecil.IConstantProvider, global::Mono.Cecil.IMarshalInfoProvider, global::Mono.Cecil.IMetadataTokenProvider
	{
		// Token: 0x06000524 RID: 1316 RVA: 0x0000C719 File Offset: 0x0000A919
		public override void Accept(global::Mono.Cecil.IReflectionVisitor visitor)
		{
			visitor.VisitParameterDefinition(this);
			if (this.MarshalInfo != null)
			{
				this.MarshalInfo.Accept(visitor);
			}
			visitor.VisitCustomAttributeCollection(this.CustomAttributes);
		}

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x06000525 RID: 1317 RVA: 0x0000C742 File Offset: 0x0000A942
		// (set) Token: 0x06000526 RID: 1318 RVA: 0x0000C74A File Offset: 0x0000A94A
		public global::Mono.Cecil.ParameterAttributes Attributes
		{
			get
			{
				return (global::Mono.Cecil.ParameterAttributes)this.attributes;
			}
			set
			{
				this.attributes = (ushort)value;
			}
		}

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x06000527 RID: 1319 RVA: 0x0000C753 File Offset: 0x0000A953
		public global::Mono.Cecil.IMethodSignature Method
		{
			get
			{
				return this.method;
			}
		}

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x06000528 RID: 1320 RVA: 0x0000C75B File Offset: 0x0000A95B
		public int Sequence
		{
			get
			{
				if (this.method == null)
				{
					return -1;
				}
				if (!this.method.HasThis)
				{
					return this.index;
				}
				return this.index + 1;
			}
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x06000529 RID: 1321 RVA: 0x0000C783 File Offset: 0x0000A983
		// (set) Token: 0x0600052A RID: 1322 RVA: 0x0000C79B File Offset: 0x0000A99B
		public bool HasConstant
		{
			get
			{
				this.ResolveConstant();
				return this.constant != global::Mono.Cecil.Mixin.NoValue;
			}
			set
			{
				if (!value)
				{
					this.constant = global::Mono.Cecil.Mixin.NoValue;
				}
			}
		}

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x0600052B RID: 1323 RVA: 0x0000C7AB File Offset: 0x0000A9AB
		// (set) Token: 0x0600052C RID: 1324 RVA: 0x0000C7BD File Offset: 0x0000A9BD
		public object Constant
		{
			get
			{
				if (!this.HasConstant)
				{
					return null;
				}
				return this.constant;
			}
			set
			{
				this.constant = value;
			}
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x0000C7C6 File Offset: 0x0000A9C6
		private void ResolveConstant()
		{
			if (this.constant != global::Mono.Cecil.Mixin.NotResolved)
			{
				return;
			}
			this.ResolveConstant(ref this.constant, this.parameter_type.Module);
		}

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x0600052E RID: 1326 RVA: 0x0000C7ED File Offset: 0x0000A9ED
		public bool HasCustomAttributes
		{
			get
			{
				if (this.custom_attributes != null)
				{
					return this.custom_attributes.Count > 0;
				}
				return this.GetHasCustomAttributes(this.parameter_type.Module);
			}
		}

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x0600052F RID: 1327 RVA: 0x0000C818 File Offset: 0x0000AA18
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> CustomAttributes
		{
			get
			{
				global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> result;
				if ((result = this.custom_attributes) == null)
				{
					result = (this.custom_attributes = this.GetCustomAttributes(this.parameter_type.Module));
				}
				return result;
			}
		}

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x06000530 RID: 1328 RVA: 0x0000C849 File Offset: 0x0000AA49
		public bool HasMarshalInfo
		{
			get
			{
				return this.marshal_info != null || this.GetHasMarshalInfo(this.parameter_type.Module);
			}
		}

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x06000531 RID: 1329 RVA: 0x0000C868 File Offset: 0x0000AA68
		// (set) Token: 0x06000532 RID: 1330 RVA: 0x0000C899 File Offset: 0x0000AA99
		public global::Mono.Cecil.MarshalInfo MarshalInfo
		{
			get
			{
				global::Mono.Cecil.MarshalInfo result;
				if ((result = this.marshal_info) == null)
				{
					result = (this.marshal_info = this.GetMarshalInfo(this.parameter_type.Module));
				}
				return result;
			}
			set
			{
				this.marshal_info = value;
			}
		}

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x06000533 RID: 1331 RVA: 0x0000C8A2 File Offset: 0x0000AAA2
		// (set) Token: 0x06000534 RID: 1332 RVA: 0x0000C8B0 File Offset: 0x0000AAB0
		public bool IsIn
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

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x06000535 RID: 1333 RVA: 0x0000C8C5 File Offset: 0x0000AAC5
		// (set) Token: 0x06000536 RID: 1334 RVA: 0x0000C8D3 File Offset: 0x0000AAD3
		public bool IsOut
		{
			get
			{
				return this.attributes.GetAttributes(2);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(2, value);
			}
		}

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x06000537 RID: 1335 RVA: 0x0000C8E8 File Offset: 0x0000AAE8
		// (set) Token: 0x06000538 RID: 1336 RVA: 0x0000C8F6 File Offset: 0x0000AAF6
		public bool IsLcid
		{
			get
			{
				return this.attributes.GetAttributes(4);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(4, value);
			}
		}

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x06000539 RID: 1337 RVA: 0x0000C90B File Offset: 0x0000AB0B
		// (set) Token: 0x0600053A RID: 1338 RVA: 0x0000C919 File Offset: 0x0000AB19
		public bool IsReturnValue
		{
			get
			{
				return this.attributes.GetAttributes(8);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(8, value);
			}
		}

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x0600053B RID: 1339 RVA: 0x0000C92E File Offset: 0x0000AB2E
		// (set) Token: 0x0600053C RID: 1340 RVA: 0x0000C93D File Offset: 0x0000AB3D
		public bool IsOptional
		{
			get
			{
				return this.attributes.GetAttributes(0x10);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x10, value);
			}
		}

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x0600053D RID: 1341 RVA: 0x0000C953 File Offset: 0x0000AB53
		// (set) Token: 0x0600053E RID: 1342 RVA: 0x0000C965 File Offset: 0x0000AB65
		public bool HasDefault
		{
			get
			{
				return this.attributes.GetAttributes(0x1000);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x1000, value);
			}
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x0600053F RID: 1343 RVA: 0x0000C97E File Offset: 0x0000AB7E
		// (set) Token: 0x06000540 RID: 1344 RVA: 0x0000C990 File Offset: 0x0000AB90
		public bool HasFieldMarshal
		{
			get
			{
				return this.attributes.GetAttributes(0x2000);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x2000, value);
			}
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x0000C9A9 File Offset: 0x0000ABA9
		public ParameterDefinition(global::Mono.Cecil.TypeReference parameterType) : this(string.Empty, global::Mono.Cecil.ParameterAttributes.None, parameterType)
		{
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x0000C9B8 File Offset: 0x0000ABB8
		public ParameterDefinition(string name, global::Mono.Cecil.ParameterAttributes attributes, global::Mono.Cecil.TypeReference parameterType) : base(name, parameterType)
		{
			this.attributes = (ushort)attributes;
			this.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.Param);
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x0000C9E4 File Offset: 0x0000ABE4
		public override global::Mono.Cecil.ParameterDefinition Resolve()
		{
			return this;
		}

		// Token: 0x0400030A RID: 778
		private ushort attributes;

		// Token: 0x0400030B RID: 779
		internal global::Mono.Cecil.IMethodSignature method;

		// Token: 0x0400030C RID: 780
		private object constant = global::Mono.Cecil.Mixin.NotResolved;

		// Token: 0x0400030D RID: 781
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> custom_attributes;

		// Token: 0x0400030E RID: 782
		private global::Mono.Cecil.MarshalInfo marshal_info;
	}
}
