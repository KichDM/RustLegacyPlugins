using System;
using System.Runtime.CompilerServices;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x02000094 RID: 148
	public sealed class EventDefinition : global::Mono.Cecil.EventReference, global::Mono.Cecil.IMemberDefinition, global::Mono.Cecil.ICustomAttributeProvider, global::Mono.Cecil.IMetadataTokenProvider
	{
		// Token: 0x17000244 RID: 580
		// (get) Token: 0x0600063C RID: 1596 RVA: 0x0000FB9B File Offset: 0x0000DD9B
		// (set) Token: 0x0600063D RID: 1597 RVA: 0x0000FBA3 File Offset: 0x0000DDA3
		public global::Mono.Cecil.EventAttributes Attributes
		{
			get
			{
				return (global::Mono.Cecil.EventAttributes)this.attributes;
			}
			set
			{
				this.attributes = (ushort)value;
			}
		}

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x0600063E RID: 1598 RVA: 0x0000FBAC File Offset: 0x0000DDAC
		// (set) Token: 0x0600063F RID: 1599 RVA: 0x0000FBC9 File Offset: 0x0000DDC9
		public global::Mono.Cecil.MethodDefinition AddMethod
		{
			get
			{
				if (this.add_method != null)
				{
					return this.add_method;
				}
				this.InitializeMethods();
				return this.add_method;
			}
			set
			{
				this.add_method = value;
			}
		}

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x06000640 RID: 1600 RVA: 0x0000FBD2 File Offset: 0x0000DDD2
		// (set) Token: 0x06000641 RID: 1601 RVA: 0x0000FBEF File Offset: 0x0000DDEF
		public global::Mono.Cecil.MethodDefinition InvokeMethod
		{
			get
			{
				if (this.invoke_method != null)
				{
					return this.invoke_method;
				}
				this.InitializeMethods();
				return this.invoke_method;
			}
			set
			{
				this.invoke_method = value;
			}
		}

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x06000642 RID: 1602 RVA: 0x0000FBF8 File Offset: 0x0000DDF8
		// (set) Token: 0x06000643 RID: 1603 RVA: 0x0000FC15 File Offset: 0x0000DE15
		public global::Mono.Cecil.MethodDefinition RemoveMethod
		{
			get
			{
				if (this.remove_method != null)
				{
					return this.remove_method;
				}
				this.InitializeMethods();
				return this.remove_method;
			}
			set
			{
				this.remove_method = value;
			}
		}

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x06000644 RID: 1604 RVA: 0x0000FC1E File Offset: 0x0000DE1E
		public bool HasOtherMethods
		{
			get
			{
				if (this.other_methods != null)
				{
					return this.other_methods.Count > 0;
				}
				this.InitializeMethods();
				return !this.other_methods.IsNullOrEmpty<global::Mono.Cecil.MethodDefinition>();
			}
		}

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06000645 RID: 1605 RVA: 0x0000FC4C File Offset: 0x0000DE4C
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodDefinition> OtherMethods
		{
			get
			{
				if (this.other_methods != null)
				{
					return this.other_methods;
				}
				this.InitializeMethods();
				if (this.other_methods != null)
				{
					return this.other_methods;
				}
				return this.other_methods = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodDefinition>();
			}
		}

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x06000646 RID: 1606 RVA: 0x0000FC8B File Offset: 0x0000DE8B
		public bool HasCustomAttributes
		{
			get
			{
				if (this.custom_attributes != null)
				{
					return this.custom_attributes.Count > 0;
				}
				return this.GetHasCustomAttributes(this.Module);
			}
		}

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x06000647 RID: 1607 RVA: 0x0000FCB0 File Offset: 0x0000DEB0
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> CustomAttributes
		{
			get
			{
				global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> result;
				if ((result = this.custom_attributes) == null)
				{
					result = (this.custom_attributes = this.GetCustomAttributes(this.Module));
				}
				return result;
			}
		}

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06000648 RID: 1608 RVA: 0x0000FCDC File Offset: 0x0000DEDC
		// (set) Token: 0x06000649 RID: 1609 RVA: 0x0000FCEE File Offset: 0x0000DEEE
		public bool IsSpecialName
		{
			get
			{
				return this.attributes.GetAttributes(0x200);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x200, value);
			}
		}

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x0600064A RID: 1610 RVA: 0x0000FD07 File Offset: 0x0000DF07
		// (set) Token: 0x0600064B RID: 1611 RVA: 0x0000FD19 File Offset: 0x0000DF19
		public bool IsRuntimeSpecialName
		{
			get
			{
				return this.attributes.GetAttributes(0x400);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x400, value);
			}
		}

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x0600064C RID: 1612 RVA: 0x0000FD32 File Offset: 0x0000DF32
		// (set) Token: 0x0600064D RID: 1613 RVA: 0x0000FD3F File Offset: 0x0000DF3F
		public new global::Mono.Cecil.TypeDefinition DeclaringType
		{
			get
			{
				return (global::Mono.Cecil.TypeDefinition)base.DeclaringType;
			}
			set
			{
				base.DeclaringType = value;
			}
		}

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x0600064E RID: 1614 RVA: 0x0000FD48 File Offset: 0x0000DF48
		public override bool IsDefinition
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600064F RID: 1615 RVA: 0x0000FD4B File Offset: 0x0000DF4B
		public EventDefinition(string name, global::Mono.Cecil.EventAttributes attributes, global::Mono.Cecil.TypeReference eventType) : base(name, eventType)
		{
			this.attributes = (ushort)attributes;
			this.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.Event);
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x0000FD78 File Offset: 0x0000DF78
		private void InitializeMethods()
		{
			if (this.add_method != null || this.invoke_method != null || this.remove_method != null)
			{
				return;
			}
			global::Mono.Cecil.ModuleDefinition module = this.Module;
			if (!module.HasImage())
			{
				return;
			}
			module.Read<global::Mono.Cecil.EventDefinition, global::Mono.Cecil.EventDefinition>(this, (global::Mono.Cecil.EventDefinition @event, global::Mono.Cecil.MetadataReader reader) => reader.ReadMethods(@event));
		}

		// Token: 0x06000651 RID: 1617 RVA: 0x0000FDD3 File Offset: 0x0000DFD3
		public override global::Mono.Cecil.EventDefinition Resolve()
		{
			return this;
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x0000FDD6 File Offset: 0x0000DFD6
		public override void Accept(global::Mono.Cecil.IReflectionVisitor visitor)
		{
			visitor.VisitEventDefinition(this);
			visitor.VisitCustomAttributeCollection(this.CustomAttributes);
		}

		// Token: 0x06000653 RID: 1619 RVA: 0x0000FD6C File Offset: 0x0000DF6C
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Cecil.EventDefinition <InitializeMethods>b__0(global::Mono.Cecil.EventDefinition @event, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadMethods(@event);
		}

		// Token: 0x040004C8 RID: 1224
		private ushort attributes;

		// Token: 0x040004C9 RID: 1225
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> custom_attributes;

		// Token: 0x040004CA RID: 1226
		internal global::Mono.Cecil.MethodDefinition add_method;

		// Token: 0x040004CB RID: 1227
		internal global::Mono.Cecil.MethodDefinition invoke_method;

		// Token: 0x040004CC RID: 1228
		internal global::Mono.Cecil.MethodDefinition remove_method;

		// Token: 0x040004CD RID: 1229
		internal global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodDefinition> other_methods;

		// Token: 0x040004CE RID: 1230
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.EventDefinition, global::Mono.Cecil.MetadataReader, global::Mono.Cecil.EventDefinition> CS$<>9__CachedAnonymousMethodDelegate1;
	}
}
