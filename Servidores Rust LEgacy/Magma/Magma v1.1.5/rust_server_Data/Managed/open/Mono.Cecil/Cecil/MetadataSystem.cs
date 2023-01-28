using System;
using System.Collections.Generic;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x0200001E RID: 30
	internal sealed class MetadataSystem
	{
		// Token: 0x06000147 RID: 327 RVA: 0x00004604 File Offset: 0x00002804
		private static void InitializePrimitives()
		{
			global::Mono.Cecil.MetadataSystem.primitive_value_types = new global::System.Collections.Generic.Dictionary<string, global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, bool>>(0x12)
			{
				{
					"Void",
					new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, bool>(global::Mono.Cecil.Metadata.ElementType.Void, false)
				},
				{
					"Boolean",
					new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, bool>(global::Mono.Cecil.Metadata.ElementType.Boolean, true)
				},
				{
					"Char",
					new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, bool>(global::Mono.Cecil.Metadata.ElementType.Char, true)
				},
				{
					"SByte",
					new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, bool>(global::Mono.Cecil.Metadata.ElementType.I1, true)
				},
				{
					"Byte",
					new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, bool>(global::Mono.Cecil.Metadata.ElementType.U1, true)
				},
				{
					"Int16",
					new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, bool>(global::Mono.Cecil.Metadata.ElementType.I2, true)
				},
				{
					"UInt16",
					new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, bool>(global::Mono.Cecil.Metadata.ElementType.U2, true)
				},
				{
					"Int32",
					new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, bool>(global::Mono.Cecil.Metadata.ElementType.I4, true)
				},
				{
					"UInt32",
					new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, bool>(global::Mono.Cecil.Metadata.ElementType.U4, true)
				},
				{
					"Int64",
					new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, bool>(global::Mono.Cecil.Metadata.ElementType.I8, true)
				},
				{
					"UInt64",
					new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, bool>(global::Mono.Cecil.Metadata.ElementType.U8, true)
				},
				{
					"Single",
					new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, bool>(global::Mono.Cecil.Metadata.ElementType.R4, true)
				},
				{
					"Double",
					new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, bool>(global::Mono.Cecil.Metadata.ElementType.R8, true)
				},
				{
					"String",
					new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, bool>(global::Mono.Cecil.Metadata.ElementType.String, false)
				},
				{
					"TypedReference",
					new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, bool>(global::Mono.Cecil.Metadata.ElementType.TypedByRef, false)
				},
				{
					"IntPtr",
					new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, bool>(global::Mono.Cecil.Metadata.ElementType.I, true)
				},
				{
					"UIntPtr",
					new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, bool>(global::Mono.Cecil.Metadata.ElementType.U, true)
				},
				{
					"Object",
					new global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, bool>(global::Mono.Cecil.Metadata.ElementType.Object, false)
				}
			};
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00004770 File Offset: 0x00002970
		public static void TryProcessPrimitiveType(global::Mono.Cecil.TypeReference type)
		{
			global::Mono.Cecil.IMetadataScope scope = type.scope;
			if (scope == null)
			{
				return;
			}
			if (scope.MetadataScopeType != global::Mono.Cecil.MetadataScopeType.AssemblyNameReference)
			{
				return;
			}
			if (scope.Name != "mscorlib")
			{
				return;
			}
			if (type.Namespace != "System")
			{
				return;
			}
			if (global::Mono.Cecil.MetadataSystem.primitive_value_types == null)
			{
				global::Mono.Cecil.MetadataSystem.InitializePrimitives();
			}
			global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, bool> row;
			if (!global::Mono.Cecil.MetadataSystem.primitive_value_types.TryGetValue(type.Name, out row))
			{
				return;
			}
			type.etype = row.Col1;
			type.IsValueType = row.Col2;
		}

		// Token: 0x06000149 RID: 329 RVA: 0x000047F4 File Offset: 0x000029F4
		public void Clear()
		{
			if (this.NestedTypes != null)
			{
				this.NestedTypes.Clear();
			}
			if (this.ReverseNestedTypes != null)
			{
				this.ReverseNestedTypes.Clear();
			}
			if (this.Interfaces != null)
			{
				this.Interfaces.Clear();
			}
			if (this.ClassLayouts != null)
			{
				this.ClassLayouts.Clear();
			}
			if (this.FieldLayouts != null)
			{
				this.FieldLayouts.Clear();
			}
			if (this.FieldRVAs != null)
			{
				this.FieldRVAs.Clear();
			}
			if (this.FieldMarshals != null)
			{
				this.FieldMarshals.Clear();
			}
			if (this.Constants != null)
			{
				this.Constants.Clear();
			}
			if (this.Overrides != null)
			{
				this.Overrides.Clear();
			}
			if (this.CustomAttributes != null)
			{
				this.CustomAttributes.Clear();
			}
			if (this.SecurityDeclarations != null)
			{
				this.SecurityDeclarations.Clear();
			}
			if (this.Events != null)
			{
				this.Events.Clear();
			}
			if (this.Properties != null)
			{
				this.Properties.Clear();
			}
			if (this.Semantics != null)
			{
				this.Semantics.Clear();
			}
			if (this.PInvokes != null)
			{
				this.PInvokes.Clear();
			}
			if (this.GenericParameters != null)
			{
				this.GenericParameters.Clear();
			}
			if (this.GenericConstraints != null)
			{
				this.GenericConstraints.Clear();
			}
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00004944 File Offset: 0x00002B44
		public global::Mono.Cecil.TypeDefinition GetTypeDefinition(uint rid)
		{
			if (rid < 1U || (ulong)rid > (ulong)((long)this.Types.Length))
			{
				return null;
			}
			return this.Types[(int)((global::System.UIntPtr)(rid - 1U))];
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00004964 File Offset: 0x00002B64
		public void AddTypeDefinition(global::Mono.Cecil.TypeDefinition type)
		{
			this.Types[(int)((global::System.UIntPtr)(type.token.RID - 1U))] = type;
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0000497C File Offset: 0x00002B7C
		public global::Mono.Cecil.TypeReference GetTypeReference(uint rid)
		{
			if (rid < 1U || (ulong)rid > (ulong)((long)this.TypeReferences.Length))
			{
				return null;
			}
			return this.TypeReferences[(int)((global::System.UIntPtr)(rid - 1U))];
		}

		// Token: 0x0600014D RID: 333 RVA: 0x0000499C File Offset: 0x00002B9C
		public void AddTypeReference(global::Mono.Cecil.TypeReference type)
		{
			this.TypeReferences[(int)((global::System.UIntPtr)(type.token.RID - 1U))] = type;
		}

		// Token: 0x0600014E RID: 334 RVA: 0x000049B4 File Offset: 0x00002BB4
		public global::Mono.Cecil.FieldDefinition GetFieldDefinition(uint rid)
		{
			if (rid < 1U || (ulong)rid > (ulong)((long)this.Fields.Length))
			{
				return null;
			}
			return this.Fields[(int)((global::System.UIntPtr)(rid - 1U))];
		}

		// Token: 0x0600014F RID: 335 RVA: 0x000049D4 File Offset: 0x00002BD4
		public void AddFieldDefinition(global::Mono.Cecil.FieldDefinition field)
		{
			this.Fields[(int)((global::System.UIntPtr)(field.token.RID - 1U))] = field;
		}

		// Token: 0x06000150 RID: 336 RVA: 0x000049EC File Offset: 0x00002BEC
		public global::Mono.Cecil.MethodDefinition GetMethodDefinition(uint rid)
		{
			if (rid < 1U || (ulong)rid > (ulong)((long)this.Methods.Length))
			{
				return null;
			}
			return this.Methods[(int)((global::System.UIntPtr)(rid - 1U))];
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00004A0C File Offset: 0x00002C0C
		public void AddMethodDefinition(global::Mono.Cecil.MethodDefinition method)
		{
			this.Methods[(int)((global::System.UIntPtr)(method.token.RID - 1U))] = method;
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00004A24 File Offset: 0x00002C24
		public global::Mono.Cecil.MemberReference GetMemberReference(uint rid)
		{
			if (rid < 1U || (ulong)rid > (ulong)((long)this.MemberReferences.Length))
			{
				return null;
			}
			return this.MemberReferences[(int)((global::System.UIntPtr)(rid - 1U))];
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00004A44 File Offset: 0x00002C44
		public void AddMemberReference(global::Mono.Cecil.MemberReference member)
		{
			this.MemberReferences[(int)((global::System.UIntPtr)(member.token.RID - 1U))] = member;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00004A5C File Offset: 0x00002C5C
		public bool TryGetNestedTypeMapping(global::Mono.Cecil.TypeDefinition type, out uint[] mapping)
		{
			return this.NestedTypes.TryGetValue(type.token.RID, out mapping);
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00004A75 File Offset: 0x00002C75
		public void SetNestedTypeMapping(uint type_rid, uint[] mapping)
		{
			this.NestedTypes[type_rid] = mapping;
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00004A84 File Offset: 0x00002C84
		public void RemoveNestedTypeMapping(global::Mono.Cecil.TypeDefinition type)
		{
			this.NestedTypes.Remove(type.token.RID);
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00004A9D File Offset: 0x00002C9D
		public bool TryGetReverseNestedTypeMapping(global::Mono.Cecil.TypeDefinition type, out uint declaring)
		{
			return this.ReverseNestedTypes.TryGetValue(type.token.RID, out declaring);
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00004AB6 File Offset: 0x00002CB6
		public void SetReverseNestedTypeMapping(uint nested, uint declaring)
		{
			this.ReverseNestedTypes.Add(nested, declaring);
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00004AC5 File Offset: 0x00002CC5
		public void RemoveReverseNestedTypeMapping(global::Mono.Cecil.TypeDefinition type)
		{
			this.ReverseNestedTypes.Remove(type.token.RID);
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00004ADE File Offset: 0x00002CDE
		public bool TryGetInterfaceMapping(global::Mono.Cecil.TypeDefinition type, out global::Mono.Cecil.MetadataToken[] mapping)
		{
			return this.Interfaces.TryGetValue(type.token.RID, out mapping);
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00004AF7 File Offset: 0x00002CF7
		public void SetInterfaceMapping(uint type_rid, global::Mono.Cecil.MetadataToken[] mapping)
		{
			this.Interfaces[type_rid] = mapping;
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00004B06 File Offset: 0x00002D06
		public void RemoveInterfaceMapping(global::Mono.Cecil.TypeDefinition type)
		{
			this.Interfaces.Remove(type.token.RID);
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00004B1F File Offset: 0x00002D1F
		public void AddPropertiesRange(uint type_rid, global::Mono.Cecil.Range range)
		{
			this.Properties.Add(type_rid, range);
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00004B2E File Offset: 0x00002D2E
		public bool TryGetPropertiesRange(global::Mono.Cecil.TypeDefinition type, out global::Mono.Cecil.Range range)
		{
			return this.Properties.TryGetValue(type.token.RID, out range);
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00004B47 File Offset: 0x00002D47
		public void RemovePropertiesRange(global::Mono.Cecil.TypeDefinition type)
		{
			this.Properties.Remove(type.token.RID);
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00004B60 File Offset: 0x00002D60
		public void AddEventsRange(uint type_rid, global::Mono.Cecil.Range range)
		{
			this.Events.Add(type_rid, range);
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00004B6F File Offset: 0x00002D6F
		public bool TryGetEventsRange(global::Mono.Cecil.TypeDefinition type, out global::Mono.Cecil.Range range)
		{
			return this.Events.TryGetValue(type.token.RID, out range);
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00004B88 File Offset: 0x00002D88
		public void RemoveEventsRange(global::Mono.Cecil.TypeDefinition type)
		{
			this.Events.Remove(type.token.RID);
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00004BA1 File Offset: 0x00002DA1
		public bool TryGetGenericParameterRange(global::Mono.Cecil.IGenericParameterProvider owner, out global::Mono.Cecil.Range range)
		{
			return this.GenericParameters.TryGetValue(owner.MetadataToken, out range);
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00004BB5 File Offset: 0x00002DB5
		public void RemoveGenericParameterRange(global::Mono.Cecil.IGenericParameterProvider owner)
		{
			this.GenericParameters.Remove(owner.MetadataToken);
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00004BC9 File Offset: 0x00002DC9
		public bool TryGetCustomAttributeRange(global::Mono.Cecil.ICustomAttributeProvider owner, out global::Mono.Cecil.Range range)
		{
			return this.CustomAttributes.TryGetValue(owner.MetadataToken, out range);
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00004BDD File Offset: 0x00002DDD
		public void RemoveCustomAttributeRange(global::Mono.Cecil.ICustomAttributeProvider owner)
		{
			this.CustomAttributes.Remove(owner.MetadataToken);
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00004BF1 File Offset: 0x00002DF1
		public bool TryGetSecurityDeclarationRange(global::Mono.Cecil.ISecurityDeclarationProvider owner, out global::Mono.Cecil.Range range)
		{
			return this.SecurityDeclarations.TryGetValue(owner.MetadataToken, out range);
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00004C05 File Offset: 0x00002E05
		public void RemoveSecurityDeclarationRange(global::Mono.Cecil.ISecurityDeclarationProvider owner)
		{
			this.SecurityDeclarations.Remove(owner.MetadataToken);
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00004C19 File Offset: 0x00002E19
		public bool TryGetGenericConstraintMapping(global::Mono.Cecil.GenericParameter generic_parameter, out global::Mono.Cecil.MetadataToken[] mapping)
		{
			return this.GenericConstraints.TryGetValue(generic_parameter.token.RID, out mapping);
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00004C32 File Offset: 0x00002E32
		public void SetGenericConstraintMapping(uint gp_rid, global::Mono.Cecil.MetadataToken[] mapping)
		{
			this.GenericConstraints[gp_rid] = mapping;
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00004C41 File Offset: 0x00002E41
		public void RemoveGenericConstraintMapping(global::Mono.Cecil.GenericParameter generic_parameter)
		{
			this.GenericConstraints.Remove(generic_parameter.token.RID);
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00004C5A File Offset: 0x00002E5A
		public bool TryGetOverrideMapping(global::Mono.Cecil.MethodDefinition method, out global::Mono.Cecil.MetadataToken[] mapping)
		{
			return this.Overrides.TryGetValue(method.token.RID, out mapping);
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00004C73 File Offset: 0x00002E73
		public void SetOverrideMapping(uint rid, global::Mono.Cecil.MetadataToken[] mapping)
		{
			this.Overrides[rid] = mapping;
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00004C82 File Offset: 0x00002E82
		public void RemoveOverrideMapping(global::Mono.Cecil.MethodDefinition method)
		{
			this.Overrides.Remove(method.token.RID);
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00004C9B File Offset: 0x00002E9B
		public global::Mono.Cecil.TypeDefinition GetFieldDeclaringType(uint field_rid)
		{
			return global::Mono.Cecil.MetadataSystem.BinaryRangeSearch(this.Types, field_rid, true);
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00004CAA File Offset: 0x00002EAA
		public global::Mono.Cecil.TypeDefinition GetMethodDeclaringType(uint method_rid)
		{
			return global::Mono.Cecil.MetadataSystem.BinaryRangeSearch(this.Types, method_rid, false);
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00004CBC File Offset: 0x00002EBC
		private static global::Mono.Cecil.TypeDefinition BinaryRangeSearch(global::Mono.Cecil.TypeDefinition[] types, uint rid, bool field)
		{
			int i = 0;
			int num = types.Length - 1;
			while (i <= num)
			{
				int num2 = i + (num - i) / 2;
				global::Mono.Cecil.TypeDefinition typeDefinition = types[num2];
				global::Mono.Cecil.Range range = field ? typeDefinition.fields_range : typeDefinition.methods_range;
				if (rid < range.Start)
				{
					num = num2 - 1;
				}
				else
				{
					if (rid < range.Start + range.Length)
					{
						return typeDefinition;
					}
					i = num2 + 1;
				}
			}
			return null;
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00004D21 File Offset: 0x00002F21
		public MetadataSystem()
		{
		}

		// Token: 0x0400007C RID: 124
		internal global::Mono.Cecil.AssemblyNameReference[] AssemblyReferences;

		// Token: 0x0400007D RID: 125
		internal global::Mono.Cecil.ModuleReference[] ModuleReferences;

		// Token: 0x0400007E RID: 126
		internal global::Mono.Cecil.TypeDefinition[] Types;

		// Token: 0x0400007F RID: 127
		internal global::Mono.Cecil.TypeReference[] TypeReferences;

		// Token: 0x04000080 RID: 128
		internal global::Mono.Cecil.FieldDefinition[] Fields;

		// Token: 0x04000081 RID: 129
		internal global::Mono.Cecil.MethodDefinition[] Methods;

		// Token: 0x04000082 RID: 130
		internal global::Mono.Cecil.MemberReference[] MemberReferences;

		// Token: 0x04000083 RID: 131
		internal global::System.Collections.Generic.Dictionary<uint, uint[]> NestedTypes;

		// Token: 0x04000084 RID: 132
		internal global::System.Collections.Generic.Dictionary<uint, uint> ReverseNestedTypes;

		// Token: 0x04000085 RID: 133
		internal global::System.Collections.Generic.Dictionary<uint, global::Mono.Cecil.MetadataToken[]> Interfaces;

		// Token: 0x04000086 RID: 134
		internal global::System.Collections.Generic.Dictionary<uint, global::Mono.Cecil.Metadata.Row<ushort, uint>> ClassLayouts;

		// Token: 0x04000087 RID: 135
		internal global::System.Collections.Generic.Dictionary<uint, uint> FieldLayouts;

		// Token: 0x04000088 RID: 136
		internal global::System.Collections.Generic.Dictionary<uint, uint> FieldRVAs;

		// Token: 0x04000089 RID: 137
		internal global::System.Collections.Generic.Dictionary<global::Mono.Cecil.MetadataToken, uint> FieldMarshals;

		// Token: 0x0400008A RID: 138
		internal global::System.Collections.Generic.Dictionary<global::Mono.Cecil.MetadataToken, global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, uint>> Constants;

		// Token: 0x0400008B RID: 139
		internal global::System.Collections.Generic.Dictionary<uint, global::Mono.Cecil.MetadataToken[]> Overrides;

		// Token: 0x0400008C RID: 140
		internal global::System.Collections.Generic.Dictionary<global::Mono.Cecil.MetadataToken, global::Mono.Cecil.Range> CustomAttributes;

		// Token: 0x0400008D RID: 141
		internal global::System.Collections.Generic.Dictionary<global::Mono.Cecil.MetadataToken, global::Mono.Cecil.Range> SecurityDeclarations;

		// Token: 0x0400008E RID: 142
		internal global::System.Collections.Generic.Dictionary<uint, global::Mono.Cecil.Range> Events;

		// Token: 0x0400008F RID: 143
		internal global::System.Collections.Generic.Dictionary<uint, global::Mono.Cecil.Range> Properties;

		// Token: 0x04000090 RID: 144
		internal global::System.Collections.Generic.Dictionary<uint, global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.MethodSemanticsAttributes, global::Mono.Cecil.MetadataToken>> Semantics;

		// Token: 0x04000091 RID: 145
		internal global::System.Collections.Generic.Dictionary<uint, global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.PInvokeAttributes, uint, uint>> PInvokes;

		// Token: 0x04000092 RID: 146
		internal global::System.Collections.Generic.Dictionary<global::Mono.Cecil.MetadataToken, global::Mono.Cecil.Range> GenericParameters;

		// Token: 0x04000093 RID: 147
		internal global::System.Collections.Generic.Dictionary<uint, global::Mono.Cecil.MetadataToken[]> GenericConstraints;

		// Token: 0x04000094 RID: 148
		private static global::System.Collections.Generic.Dictionary<string, global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, bool>> primitive_value_types;
	}
}
