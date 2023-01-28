using System;
using System.Runtime.CompilerServices;
using Mono.Cecil.Metadata;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x0200006C RID: 108
	public abstract class TypeSystem
	{
		// Token: 0x060004C5 RID: 1221 RVA: 0x0000B528 File Offset: 0x00009728
		private TypeSystem(global::Mono.Cecil.ModuleDefinition module)
		{
			this.module = module;
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x0000B537 File Offset: 0x00009737
		internal static global::Mono.Cecil.TypeSystem CreateTypeSystem(global::Mono.Cecil.ModuleDefinition module)
		{
			if (global::Mono.Cecil.TypeSystem.IsCorlib(module))
			{
				return new global::Mono.Cecil.TypeSystem.CorlibTypeSystem(module);
			}
			return new global::Mono.Cecil.TypeSystem.CommonTypeSystem(module);
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x0000B54E File Offset: 0x0000974E
		private static bool IsCorlib(global::Mono.Cecil.ModuleDefinition module)
		{
			return module.Assembly != null && module.Assembly.Name.Name == "mscorlib";
		}

		// Token: 0x060004C8 RID: 1224
		internal abstract global::Mono.Cecil.TypeReference LookupType(string @namespace, string name);

		// Token: 0x060004C9 RID: 1225 RVA: 0x0000B574 File Offset: 0x00009774
		private global::Mono.Cecil.TypeReference LookupSystemType(string name, global::Mono.Cecil.Metadata.ElementType element_type)
		{
			global::Mono.Cecil.TypeReference typeReference = this.LookupType("System", name);
			typeReference.etype = element_type;
			return typeReference;
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x0000B598 File Offset: 0x00009798
		private global::Mono.Cecil.TypeReference LookupSystemValueType(string name, global::Mono.Cecil.Metadata.ElementType element_type)
		{
			global::Mono.Cecil.TypeReference typeReference = this.LookupSystemType(name, element_type);
			typeReference.IsValueType = true;
			return typeReference;
		}

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x060004CB RID: 1227 RVA: 0x0000B5B8 File Offset: 0x000097B8
		public global::Mono.Cecil.IMetadataScope Corlib
		{
			get
			{
				global::Mono.Cecil.TypeSystem.CommonTypeSystem commonTypeSystem = this as global::Mono.Cecil.TypeSystem.CommonTypeSystem;
				if (commonTypeSystem == null)
				{
					return this.module;
				}
				return commonTypeSystem.GetCorlibReference();
			}
		}

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x060004CC RID: 1228 RVA: 0x0000B5DC File Offset: 0x000097DC
		public global::Mono.Cecil.TypeReference Object
		{
			get
			{
				global::Mono.Cecil.TypeReference result;
				if ((result = this.type_object) == null)
				{
					result = (this.type_object = this.LookupSystemType("Object", global::Mono.Cecil.Metadata.ElementType.Object));
				}
				return result;
			}
		}

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x060004CD RID: 1229 RVA: 0x0000B60C File Offset: 0x0000980C
		public global::Mono.Cecil.TypeReference Void
		{
			get
			{
				global::Mono.Cecil.TypeReference result;
				if ((result = this.type_void) == null)
				{
					result = (this.type_void = this.LookupSystemType("Void", global::Mono.Cecil.Metadata.ElementType.Void));
				}
				return result;
			}
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x060004CE RID: 1230 RVA: 0x0000B638 File Offset: 0x00009838
		public global::Mono.Cecil.TypeReference Boolean
		{
			get
			{
				global::Mono.Cecil.TypeReference result;
				if ((result = this.type_bool) == null)
				{
					result = (this.type_bool = this.LookupSystemValueType("Boolean", global::Mono.Cecil.Metadata.ElementType.Boolean));
				}
				return result;
			}
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x060004CF RID: 1231 RVA: 0x0000B664 File Offset: 0x00009864
		public global::Mono.Cecil.TypeReference Char
		{
			get
			{
				global::Mono.Cecil.TypeReference result;
				if ((result = this.type_char) == null)
				{
					result = (this.type_char = this.LookupSystemValueType("Char", global::Mono.Cecil.Metadata.ElementType.Char));
				}
				return result;
			}
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x060004D0 RID: 1232 RVA: 0x0000B690 File Offset: 0x00009890
		public global::Mono.Cecil.TypeReference SByte
		{
			get
			{
				global::Mono.Cecil.TypeReference result;
				if ((result = this.type_sbyte) == null)
				{
					result = (this.type_sbyte = this.LookupSystemValueType("SByte", global::Mono.Cecil.Metadata.ElementType.I1));
				}
				return result;
			}
		}

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x060004D1 RID: 1233 RVA: 0x0000B6BC File Offset: 0x000098BC
		public global::Mono.Cecil.TypeReference Byte
		{
			get
			{
				global::Mono.Cecil.TypeReference result;
				if ((result = this.type_byte) == null)
				{
					result = (this.type_byte = this.LookupSystemValueType("Byte", global::Mono.Cecil.Metadata.ElementType.U1));
				}
				return result;
			}
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x060004D2 RID: 1234 RVA: 0x0000B6E8 File Offset: 0x000098E8
		public global::Mono.Cecil.TypeReference Int16
		{
			get
			{
				global::Mono.Cecil.TypeReference result;
				if ((result = this.type_int16) == null)
				{
					result = (this.type_int16 = this.LookupSystemValueType("Int16", global::Mono.Cecil.Metadata.ElementType.I2));
				}
				return result;
			}
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x060004D3 RID: 1235 RVA: 0x0000B714 File Offset: 0x00009914
		public global::Mono.Cecil.TypeReference UInt16
		{
			get
			{
				global::Mono.Cecil.TypeReference result;
				if ((result = this.type_uint16) == null)
				{
					result = (this.type_uint16 = this.LookupSystemValueType("UInt16", global::Mono.Cecil.Metadata.ElementType.U2));
				}
				return result;
			}
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x060004D4 RID: 1236 RVA: 0x0000B740 File Offset: 0x00009940
		public global::Mono.Cecil.TypeReference Int32
		{
			get
			{
				global::Mono.Cecil.TypeReference result;
				if ((result = this.type_int32) == null)
				{
					result = (this.type_int32 = this.LookupSystemValueType("Int32", global::Mono.Cecil.Metadata.ElementType.I4));
				}
				return result;
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x060004D5 RID: 1237 RVA: 0x0000B76C File Offset: 0x0000996C
		public global::Mono.Cecil.TypeReference UInt32
		{
			get
			{
				global::Mono.Cecil.TypeReference result;
				if ((result = this.type_uint32) == null)
				{
					result = (this.type_uint32 = this.LookupSystemValueType("UInt32", global::Mono.Cecil.Metadata.ElementType.U4));
				}
				return result;
			}
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x060004D6 RID: 1238 RVA: 0x0000B79C File Offset: 0x0000999C
		public global::Mono.Cecil.TypeReference Int64
		{
			get
			{
				global::Mono.Cecil.TypeReference result;
				if ((result = this.type_int64) == null)
				{
					result = (this.type_int64 = this.LookupSystemValueType("Int64", global::Mono.Cecil.Metadata.ElementType.I8));
				}
				return result;
			}
		}

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x060004D7 RID: 1239 RVA: 0x0000B7CC File Offset: 0x000099CC
		public global::Mono.Cecil.TypeReference UInt64
		{
			get
			{
				global::Mono.Cecil.TypeReference result;
				if ((result = this.type_uint64) == null)
				{
					result = (this.type_uint64 = this.LookupSystemValueType("UInt64", global::Mono.Cecil.Metadata.ElementType.U8));
				}
				return result;
			}
		}

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x060004D8 RID: 1240 RVA: 0x0000B7FC File Offset: 0x000099FC
		public global::Mono.Cecil.TypeReference Single
		{
			get
			{
				global::Mono.Cecil.TypeReference result;
				if ((result = this.type_single) == null)
				{
					result = (this.type_single = this.LookupSystemValueType("Single", global::Mono.Cecil.Metadata.ElementType.R4));
				}
				return result;
			}
		}

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x060004D9 RID: 1241 RVA: 0x0000B82C File Offset: 0x00009A2C
		public global::Mono.Cecil.TypeReference Double
		{
			get
			{
				global::Mono.Cecil.TypeReference result;
				if ((result = this.type_double) == null)
				{
					result = (this.type_double = this.LookupSystemValueType("Double", global::Mono.Cecil.Metadata.ElementType.R8));
				}
				return result;
			}
		}

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x060004DA RID: 1242 RVA: 0x0000B85C File Offset: 0x00009A5C
		public global::Mono.Cecil.TypeReference IntPtr
		{
			get
			{
				global::Mono.Cecil.TypeReference result;
				if ((result = this.type_intptr) == null)
				{
					result = (this.type_intptr = this.LookupSystemValueType("IntPtr", global::Mono.Cecil.Metadata.ElementType.I));
				}
				return result;
			}
		}

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x060004DB RID: 1243 RVA: 0x0000B88C File Offset: 0x00009A8C
		public global::Mono.Cecil.TypeReference UIntPtr
		{
			get
			{
				global::Mono.Cecil.TypeReference result;
				if ((result = this.type_uintptr) == null)
				{
					result = (this.type_uintptr = this.LookupSystemValueType("UIntPtr", global::Mono.Cecil.Metadata.ElementType.U));
				}
				return result;
			}
		}

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x060004DC RID: 1244 RVA: 0x0000B8BC File Offset: 0x00009ABC
		public global::Mono.Cecil.TypeReference String
		{
			get
			{
				global::Mono.Cecil.TypeReference result;
				if ((result = this.type_string) == null)
				{
					result = (this.type_string = this.LookupSystemType("String", global::Mono.Cecil.Metadata.ElementType.String));
				}
				return result;
			}
		}

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x060004DD RID: 1245 RVA: 0x0000B8EC File Offset: 0x00009AEC
		public global::Mono.Cecil.TypeReference TypedReference
		{
			get
			{
				global::Mono.Cecil.TypeReference result;
				if ((result = this.type_typedref) == null)
				{
					result = (this.type_typedref = this.LookupSystemValueType("TypedReference", global::Mono.Cecil.Metadata.ElementType.TypedByRef));
				}
				return result;
			}
		}

		// Token: 0x040002DD RID: 733
		private readonly global::Mono.Cecil.ModuleDefinition module;

		// Token: 0x040002DE RID: 734
		private global::Mono.Cecil.TypeReference type_object;

		// Token: 0x040002DF RID: 735
		private global::Mono.Cecil.TypeReference type_void;

		// Token: 0x040002E0 RID: 736
		private global::Mono.Cecil.TypeReference type_bool;

		// Token: 0x040002E1 RID: 737
		private global::Mono.Cecil.TypeReference type_char;

		// Token: 0x040002E2 RID: 738
		private global::Mono.Cecil.TypeReference type_sbyte;

		// Token: 0x040002E3 RID: 739
		private global::Mono.Cecil.TypeReference type_byte;

		// Token: 0x040002E4 RID: 740
		private global::Mono.Cecil.TypeReference type_int16;

		// Token: 0x040002E5 RID: 741
		private global::Mono.Cecil.TypeReference type_uint16;

		// Token: 0x040002E6 RID: 742
		private global::Mono.Cecil.TypeReference type_int32;

		// Token: 0x040002E7 RID: 743
		private global::Mono.Cecil.TypeReference type_uint32;

		// Token: 0x040002E8 RID: 744
		private global::Mono.Cecil.TypeReference type_int64;

		// Token: 0x040002E9 RID: 745
		private global::Mono.Cecil.TypeReference type_uint64;

		// Token: 0x040002EA RID: 746
		private global::Mono.Cecil.TypeReference type_single;

		// Token: 0x040002EB RID: 747
		private global::Mono.Cecil.TypeReference type_double;

		// Token: 0x040002EC RID: 748
		private global::Mono.Cecil.TypeReference type_intptr;

		// Token: 0x040002ED RID: 749
		private global::Mono.Cecil.TypeReference type_uintptr;

		// Token: 0x040002EE RID: 750
		private global::Mono.Cecil.TypeReference type_string;

		// Token: 0x040002EF RID: 751
		private global::Mono.Cecil.TypeReference type_typedref;

		// Token: 0x0200006D RID: 109
		private sealed class CorlibTypeSystem : global::Mono.Cecil.TypeSystem
		{
			// Token: 0x060004DE RID: 1246 RVA: 0x0000B919 File Offset: 0x00009B19
			public CorlibTypeSystem(global::Mono.Cecil.ModuleDefinition module) : base(module)
			{
			}

			// Token: 0x060004DF RID: 1247 RVA: 0x0000B98C File Offset: 0x00009B8C
			internal override global::Mono.Cecil.TypeReference LookupType(string @namespace, string name)
			{
				global::Mono.Cecil.MetadataSystem metadataSystem = this.module.MetadataSystem;
				if (metadataSystem.Types == null)
				{
					global::Mono.Cecil.TypeSystem.CorlibTypeSystem.Initialize(this.module.Types);
				}
				return this.module.Read<global::Mono.Cecil.Metadata.Row<string, string>, global::Mono.Cecil.TypeDefinition>(new global::Mono.Cecil.Metadata.Row<string, string>(@namespace, name), delegate(global::Mono.Cecil.Metadata.Row<string, string> row, global::Mono.Cecil.MetadataReader reader)
				{
					global::Mono.Cecil.TypeDefinition[] types = reader.metadata.Types;
					for (int i = 0; i < types.Length; i++)
					{
						if (types[i] == null)
						{
							types[i] = reader.GetTypeDefinition((uint)(i + 1));
						}
						global::Mono.Cecil.TypeDefinition typeDefinition = types[i];
						if (typeDefinition.Name == row.Col2 && typeDefinition.Namespace == row.Col1)
						{
							return typeDefinition;
						}
					}
					return null;
				});
			}

			// Token: 0x060004E0 RID: 1248 RVA: 0x0000B9EC File Offset: 0x00009BEC
			private static void Initialize(object obj)
			{
			}

			// Token: 0x060004E1 RID: 1249 RVA: 0x0000B924 File Offset: 0x00009B24
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private static global::Mono.Cecil.TypeDefinition <LookupType>b__0(global::Mono.Cecil.Metadata.Row<string, string> row, global::Mono.Cecil.MetadataReader reader)
			{
				global::Mono.Cecil.TypeDefinition[] types = reader.metadata.Types;
				for (int i = 0; i < types.Length; i++)
				{
					if (types[i] == null)
					{
						types[i] = reader.GetTypeDefinition((uint)(i + 1));
					}
					global::Mono.Cecil.TypeDefinition typeDefinition = types[i];
					if (typeDefinition.Name == row.Col2 && typeDefinition.Namespace == row.Col1)
					{
						return typeDefinition;
					}
				}
				return null;
			}

			// Token: 0x040002F0 RID: 752
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private static global::System.Func<global::Mono.Cecil.Metadata.Row<string, string>, global::Mono.Cecil.MetadataReader, global::Mono.Cecil.TypeDefinition> CS$<>9__CachedAnonymousMethodDelegate1;
		}

		// Token: 0x0200006E RID: 110
		private sealed class CommonTypeSystem : global::Mono.Cecil.TypeSystem
		{
			// Token: 0x060004E2 RID: 1250 RVA: 0x0000B9EE File Offset: 0x00009BEE
			public CommonTypeSystem(global::Mono.Cecil.ModuleDefinition module) : base(module)
			{
			}

			// Token: 0x060004E3 RID: 1251 RVA: 0x0000B9F7 File Offset: 0x00009BF7
			internal override global::Mono.Cecil.TypeReference LookupType(string @namespace, string name)
			{
				return this.CreateTypeReference(@namespace, name);
			}

			// Token: 0x060004E4 RID: 1252 RVA: 0x0000BA10 File Offset: 0x00009C10
			public global::Mono.Cecil.AssemblyNameReference GetCorlibReference()
			{
				if (this.corlib != null)
				{
					return this.corlib;
				}
				global::Mono.Collections.Generic.Collection<global::Mono.Cecil.AssemblyNameReference> assemblyReferences = this.module.AssemblyReferences;
				for (int i = 0; i < assemblyReferences.Count; i++)
				{
					global::Mono.Cecil.AssemblyNameReference assemblyNameReference = assemblyReferences[i];
					if (assemblyNameReference.Name == "mscorlib")
					{
						return this.corlib = assemblyNameReference;
					}
				}
				this.corlib = new global::Mono.Cecil.AssemblyNameReference
				{
					Name = "mscorlib",
					Version = this.GetCorlibVersion(),
					PublicKeyToken = new byte[]
					{
						0xB7,
						0x7A,
						0x5C,
						0x56,
						0x19,
						0x34,
						0xE0,
						0x89
					}
				};
				assemblyReferences.Add(this.corlib);
				return this.corlib;
			}

			// Token: 0x060004E5 RID: 1253 RVA: 0x0000BAC0 File Offset: 0x00009CC0
			private global::System.Version GetCorlibVersion()
			{
				switch (this.module.Runtime)
				{
				case global::Mono.Cecil.TargetRuntime.Net_1_0:
				case global::Mono.Cecil.TargetRuntime.Net_1_1:
					return new global::System.Version(1, 0, 0, 0);
				case global::Mono.Cecil.TargetRuntime.Net_2_0:
					return new global::System.Version(2, 0, 0, 0);
				case global::Mono.Cecil.TargetRuntime.Net_4_0:
					return new global::System.Version(4, 0, 0, 0);
				default:
					throw new global::System.NotSupportedException();
				}
			}

			// Token: 0x060004E6 RID: 1254 RVA: 0x0000BB14 File Offset: 0x00009D14
			private global::Mono.Cecil.TypeReference CreateTypeReference(string @namespace, string name)
			{
				return new global::Mono.Cecil.TypeReference(@namespace, name, this.module, this.GetCorlibReference());
			}

			// Token: 0x040002F1 RID: 753
			private global::Mono.Cecil.AssemblyNameReference corlib;
		}
	}
}
