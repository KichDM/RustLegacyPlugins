using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x020000A4 RID: 164
	public sealed class CustomAttribute : global::Mono.Cecil.ICustomAttribute, global::Mono.Cecil.IReflectionVisitable
	{
		// Token: 0x17000269 RID: 617
		// (get) Token: 0x0600069D RID: 1693 RVA: 0x00010651 File Offset: 0x0000E851
		// (set) Token: 0x0600069E RID: 1694 RVA: 0x00010659 File Offset: 0x0000E859
		public global::Mono.Cecil.MethodReference Constructor
		{
			get
			{
				return this.constructor;
			}
			set
			{
				this.constructor = value;
			}
		}

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x0600069F RID: 1695 RVA: 0x00010662 File Offset: 0x0000E862
		public global::Mono.Cecil.TypeReference AttributeType
		{
			get
			{
				return this.constructor.DeclaringType;
			}
		}

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x060006A0 RID: 1696 RVA: 0x0001066F File Offset: 0x0000E86F
		public bool IsResolved
		{
			get
			{
				return this.resolved;
			}
		}

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x060006A1 RID: 1697 RVA: 0x00010677 File Offset: 0x0000E877
		public bool HasConstructorArguments
		{
			get
			{
				this.Resolve();
				return !this.arguments.IsNullOrEmpty<global::Mono.Cecil.CustomAttributeArgument>();
			}
		}

		// Token: 0x1700026D RID: 621
		// (get) Token: 0x060006A2 RID: 1698 RVA: 0x00010690 File Offset: 0x0000E890
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeArgument> ConstructorArguments
		{
			get
			{
				this.Resolve();
				global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeArgument> result;
				if ((result = this.arguments) == null)
				{
					result = (this.arguments = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeArgument>());
				}
				return result;
			}
		}

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x060006A3 RID: 1699 RVA: 0x000106BB File Offset: 0x0000E8BB
		public bool HasFields
		{
			get
			{
				this.Resolve();
				return !this.fields.IsNullOrEmpty<global::Mono.Cecil.CustomAttributeNamedArgument>();
			}
		}

		// Token: 0x1700026F RID: 623
		// (get) Token: 0x060006A4 RID: 1700 RVA: 0x000106D4 File Offset: 0x0000E8D4
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument> Fields
		{
			get
			{
				this.Resolve();
				global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument> result;
				if ((result = this.fields) == null)
				{
					result = (this.fields = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument>());
				}
				return result;
			}
		}

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x060006A5 RID: 1701 RVA: 0x000106FF File Offset: 0x0000E8FF
		public bool HasProperties
		{
			get
			{
				this.Resolve();
				return !this.properties.IsNullOrEmpty<global::Mono.Cecil.CustomAttributeNamedArgument>();
			}
		}

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x060006A6 RID: 1702 RVA: 0x00010718 File Offset: 0x0000E918
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument> Properties
		{
			get
			{
				this.Resolve();
				global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument> result;
				if ((result = this.properties) == null)
				{
					result = (this.properties = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument>());
				}
				return result;
			}
		}

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x060006A7 RID: 1703 RVA: 0x00010743 File Offset: 0x0000E943
		internal bool HasImage
		{
			get
			{
				return this.constructor != null && this.constructor.HasImage;
			}
		}

		// Token: 0x17000273 RID: 627
		// (get) Token: 0x060006A8 RID: 1704 RVA: 0x0001075A File Offset: 0x0000E95A
		internal global::Mono.Cecil.ModuleDefinition Module
		{
			get
			{
				return this.constructor.Module;
			}
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x00010767 File Offset: 0x0000E967
		internal CustomAttribute(uint signature, global::Mono.Cecil.MethodReference constructor)
		{
			this.signature = signature;
			this.constructor = constructor;
			this.resolved = false;
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x00010784 File Offset: 0x0000E984
		public CustomAttribute(global::Mono.Cecil.MethodReference constructor)
		{
			this.constructor = constructor;
			this.resolved = true;
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x0001079A File Offset: 0x0000E99A
		public CustomAttribute(global::Mono.Cecil.MethodReference constructor, byte[] blob)
		{
			this.constructor = constructor;
			this.resolved = false;
			this.blob = blob;
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x000107C8 File Offset: 0x0000E9C8
		public byte[] GetBlob()
		{
			if (this.blob != null)
			{
				return this.blob;
			}
			if (!this.HasImage || this.signature == 0U)
			{
				throw new global::System.NotSupportedException();
			}
			return this.blob = this.Module.Read<global::Mono.Cecil.CustomAttribute, byte[]>(this, (global::Mono.Cecil.CustomAttribute attribute, global::Mono.Cecil.MetadataReader reader) => reader.ReadCustomAttributeBlob(attribute.signature));
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x00010838 File Offset: 0x0000EA38
		private void Resolve()
		{
			if (this.resolved || !this.HasImage)
			{
				return;
			}
			try
			{
				this.Module.Read<global::Mono.Cecil.CustomAttribute, global::Mono.Cecil.CustomAttribute>(this, delegate(global::Mono.Cecil.CustomAttribute attribute, global::Mono.Cecil.MetadataReader reader)
				{
					reader.ReadCustomAttributeSignature(attribute);
					return this;
				});
				this.resolved = true;
			}
			catch (global::Mono.Cecil.ResolutionException)
			{
				if (this.arguments != null)
				{
					this.arguments.Clear();
				}
				if (this.fields != null)
				{
					this.fields.Clear();
				}
				if (this.properties != null)
				{
					this.properties.Clear();
				}
				this.resolved = false;
			}
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x000108D4 File Offset: 0x0000EAD4
		public void Accept(global::Mono.Cecil.IReflectionVisitor visitor)
		{
			visitor.VisitCustomAttribute(this);
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x000108E0 File Offset: 0x0000EAE0
		internal static void CloneDictionary(global::System.Collections.IDictionary original, global::System.Collections.IDictionary target)
		{
			target.Clear();
			foreach (object obj in original)
			{
				global::System.Collections.DictionaryEntry dictionaryEntry = (global::System.Collections.DictionaryEntry)obj;
				target.Add(dictionaryEntry.Key, dictionaryEntry.Value);
			}
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x00010948 File Offset: 0x0000EB48
		internal static global::Mono.Cecil.CustomAttribute Clone(global::Mono.Cecil.CustomAttribute custattr, global::Mono.Cecil.ModuleDefinition context)
		{
			global::Mono.Cecil.CustomAttribute customAttribute = new global::Mono.Cecil.CustomAttribute(context.Import(custattr.Constructor));
			custattr.CopyTo(customAttribute, context);
			return customAttribute;
		}

		// Token: 0x060006B1 RID: 1713 RVA: 0x00010970 File Offset: 0x0000EB70
		private void CopyTo(global::Mono.Cecil.CustomAttribute target, global::Mono.Cecil.ModuleDefinition context)
		{
			foreach (global::Mono.Cecil.CustomAttributeArgument customAttributeArgument in this.ConstructorArguments)
			{
				target.ConstructorArguments.Add(new global::Mono.Cecil.CustomAttributeArgument(context.Import(customAttributeArgument.Type), customAttributeArgument.Value));
			}
			foreach (global::Mono.Cecil.CustomAttributeNamedArgument customAttributeNamedArgument in this.Fields)
			{
				target.Fields.Add(new global::Mono.Cecil.CustomAttributeNamedArgument(customAttributeNamedArgument.Name, new global::Mono.Cecil.CustomAttributeArgument(context.Import(customAttributeNamedArgument.Argument.Type), customAttributeNamedArgument.Argument.Value)));
			}
			foreach (global::Mono.Cecil.CustomAttributeNamedArgument customAttributeNamedArgument2 in this.Properties)
			{
				target.Properties.Add(new global::Mono.Cecil.CustomAttributeNamedArgument(customAttributeNamedArgument2.Name, new global::Mono.Cecil.CustomAttributeArgument(context.Import(customAttributeNamedArgument2.Argument.Type), customAttributeNamedArgument2.Argument.Value)));
			}
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x000107B7 File Offset: 0x0000E9B7
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static byte[] <GetBlob>b__0(global::Mono.Cecil.CustomAttribute attribute, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadCustomAttributeBlob(attribute.signature);
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x0001082C File Offset: 0x0000EA2C
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Mono.Cecil.CustomAttribute <Resolve>b__2(global::Mono.Cecil.CustomAttribute attribute, global::Mono.Cecil.MetadataReader reader)
		{
			reader.ReadCustomAttributeSignature(attribute);
			return this;
		}

		// Token: 0x0400051D RID: 1309
		internal readonly uint signature;

		// Token: 0x0400051E RID: 1310
		internal bool resolved;

		// Token: 0x0400051F RID: 1311
		private global::Mono.Cecil.MethodReference constructor;

		// Token: 0x04000520 RID: 1312
		private byte[] blob;

		// Token: 0x04000521 RID: 1313
		internal global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeArgument> arguments;

		// Token: 0x04000522 RID: 1314
		internal global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument> fields;

		// Token: 0x04000523 RID: 1315
		internal global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument> properties;

		// Token: 0x04000524 RID: 1316
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.CustomAttribute, global::Mono.Cecil.MetadataReader, byte[]> CS$<>9__CachedAnonymousMethodDelegate1;
	}
}
