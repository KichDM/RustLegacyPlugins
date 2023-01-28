using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using Mono.Cecil.Cil;
using Mono.Cecil.Metadata;
using Mono.Collections.Generic;
using Mono.Security.Cryptography;

namespace Mono.Cecil
{
	// Token: 0x02000012 RID: 18
	internal static class Mixin
	{
		// Token: 0x060000A8 RID: 168 RVA: 0x00002B59 File Offset: 0x00000D59
		public static void ResolveConstant(this global::Mono.Cecil.IConstantProvider self, ref object constant, global::Mono.Cecil.ModuleDefinition module)
		{
			object obj;
			if (!module.HasImage())
			{
				obj = global::Mono.Cecil.Mixin.NoValue;
			}
			else
			{
				obj = module.Read<global::Mono.Cecil.IConstantProvider, object>(self, (global::Mono.Cecil.IConstantProvider provider, global::Mono.Cecil.MetadataReader reader) => reader.ReadConstant(provider));
			}
			constant = obj;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00002B90 File Offset: 0x00000D90
		public static void CheckModifier(global::Mono.Cecil.TypeReference modifierType, global::Mono.Cecil.TypeReference type)
		{
			if (modifierType == null)
			{
				throw new global::System.ArgumentNullException("modifierType");
			}
			if (type == null)
			{
				throw new global::System.ArgumentNullException("type");
			}
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00002BAE File Offset: 0x00000DAE
		public static bool IsVarArg(this global::Mono.Cecil.IMethodSignature self)
		{
			return (byte)(self.CallingConvention & global::Mono.Cecil.MethodCallingConvention.VarArg) != 0;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00002BC0 File Offset: 0x00000DC0
		public static int GetSentinelPosition(this global::Mono.Cecil.IMethodSignature self)
		{
			if (!self.HasParameters)
			{
				return -1;
			}
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition> parameters = self.Parameters;
			for (int i = 0; i < parameters.Count; i++)
			{
				if (parameters[i].ParameterType.IsSentinel)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00002C0E File Offset: 0x00000E0E
		public static bool GetHasGenericParameters(this global::Mono.Cecil.IGenericParameterProvider self, global::Mono.Cecil.ModuleDefinition module)
		{
			if (!module.HasImage())
			{
				return false;
			}
			return module.Read<global::Mono.Cecil.IGenericParameterProvider, bool>(self, (global::Mono.Cecil.IGenericParameterProvider provider, global::Mono.Cecil.MetadataReader reader) => reader.HasGenericParameters(provider));
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00002C47 File Offset: 0x00000E47
		public static global::Mono.Collections.Generic.Collection<global::Mono.Cecil.GenericParameter> GetGenericParameters(this global::Mono.Cecil.IGenericParameterProvider self, global::Mono.Cecil.ModuleDefinition module)
		{
			if (!module.HasImage())
			{
				return new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.GenericParameter>();
			}
			return module.Read<global::Mono.Cecil.IGenericParameterProvider, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.GenericParameter>>(self, (global::Mono.Cecil.IGenericParameterProvider provider, global::Mono.Cecil.MetadataReader reader) => reader.ReadGenericParameters(provider));
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00002C7B File Offset: 0x00000E7B
		public static bool GetAttributes(this uint self, uint attributes)
		{
			return (self & attributes) != 0U;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00002C86 File Offset: 0x00000E86
		public static uint SetAttributes(this uint self, uint attributes, bool value)
		{
			if (value)
			{
				return self | attributes;
			}
			return self & ~attributes;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00002C93 File Offset: 0x00000E93
		public static bool GetMaskedAttributes(this uint self, uint mask, uint attributes)
		{
			return (self & mask) == attributes;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00002C9B File Offset: 0x00000E9B
		public static uint SetMaskedAttributes(this uint self, uint mask, uint attributes, bool value)
		{
			if (value)
			{
				self &= ~mask;
				return self | attributes;
			}
			return self & ~(mask & attributes);
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00002CB0 File Offset: 0x00000EB0
		public static bool GetAttributes(this ushort self, ushort attributes)
		{
			return (self & attributes) != 0;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00002CBB File Offset: 0x00000EBB
		public static ushort SetAttributes(this ushort self, ushort attributes, bool value)
		{
			if (value)
			{
				return self | attributes;
			}
			return self & ~attributes;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00002CCA File Offset: 0x00000ECA
		public static bool GetMaskedAttributes(this ushort self, ushort mask, uint attributes)
		{
			return (long)(self & mask) == (long)((ulong)attributes);
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00002CD4 File Offset: 0x00000ED4
		public static ushort SetMaskedAttributes(this ushort self, ushort mask, uint attributes, bool value)
		{
			if (value)
			{
				self &= ~mask;
				return (ushort)((uint)self | attributes);
			}
			return (ushort)((uint)self & ~((uint)mask & attributes));
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00002CEC File Offset: 0x00000EEC
		public static global::Mono.Cecil.TypeReference GetEnumUnderlyingType(this global::Mono.Cecil.TypeDefinition self)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.FieldDefinition> fields = self.Fields;
			for (int i = 0; i < fields.Count; i++)
			{
				global::Mono.Cecil.FieldDefinition fieldDefinition = fields[i];
				if (!fieldDefinition.IsStatic)
				{
					return fieldDefinition.FieldType;
				}
			}
			throw new global::System.ArgumentException();
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00002D30 File Offset: 0x00000F30
		public static global::Mono.Cecil.TypeDefinition GetNestedType(this global::Mono.Cecil.TypeDefinition self, string name)
		{
			if (!self.HasNestedTypes)
			{
				return null;
			}
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeDefinition> nestedTypes = self.NestedTypes;
			for (int i = 0; i < nestedTypes.Count; i++)
			{
				global::Mono.Cecil.TypeDefinition typeDefinition = nestedTypes[i];
				if (typeDefinition.Name == name)
				{
					return typeDefinition;
				}
			}
			return null;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00002D78 File Offset: 0x00000F78
		public static bool IsNullOrEmpty<T>(this T[] self)
		{
			return self == null || self.Length == 0;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00002D85 File Offset: 0x00000F85
		public static bool IsNullOrEmpty<T>(this global::Mono.Collections.Generic.Collection<T> self)
		{
			return self == null || self.size == 0;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00002D9E File Offset: 0x00000F9E
		public static bool GetHasSecurityDeclarations(this global::Mono.Cecil.ISecurityDeclarationProvider self, global::Mono.Cecil.ModuleDefinition module)
		{
			if (!module.HasImage())
			{
				return false;
			}
			return module.Read<global::Mono.Cecil.ISecurityDeclarationProvider, bool>(self, (global::Mono.Cecil.ISecurityDeclarationProvider provider, global::Mono.Cecil.MetadataReader reader) => reader.HasSecurityDeclarations(provider));
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00002DD7 File Offset: 0x00000FD7
		public static global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityDeclaration> GetSecurityDeclarations(this global::Mono.Cecil.ISecurityDeclarationProvider self, global::Mono.Cecil.ModuleDefinition module)
		{
			if (!module.HasImage())
			{
				return new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityDeclaration>();
			}
			return module.Read<global::Mono.Cecil.ISecurityDeclarationProvider, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityDeclaration>>(self, (global::Mono.Cecil.ISecurityDeclarationProvider provider, global::Mono.Cecil.MetadataReader reader) => reader.ReadSecurityDeclarations(provider));
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00002E0B File Offset: 0x0000100B
		public static void CheckParameters(object parameters)
		{
			if (parameters == null)
			{
				throw new global::System.ArgumentNullException("parameters");
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00002E1B File Offset: 0x0000101B
		public static bool HasImage(this global::Mono.Cecil.ModuleDefinition self)
		{
			return self != null && self.HasImage;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00002E28 File Offset: 0x00001028
		public static string GetFullyQualifiedName(this global::System.IO.Stream self)
		{
			global::System.IO.FileStream fileStream = self as global::System.IO.FileStream;
			if (fileStream == null)
			{
				return string.Empty;
			}
			return global::System.IO.Path.GetFullPath(fileStream.Name);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00002E50 File Offset: 0x00001050
		public static global::Mono.Cecil.TargetRuntime ParseRuntime(this string self)
		{
			switch (self[1])
			{
			case '1':
				if (self[3] != '0')
				{
					return global::Mono.Cecil.TargetRuntime.Net_1_1;
				}
				return global::Mono.Cecil.TargetRuntime.Net_1_0;
			case '2':
				return global::Mono.Cecil.TargetRuntime.Net_2_0;
			}
			return global::Mono.Cecil.TargetRuntime.Net_4_0;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00002E92 File Offset: 0x00001092
		public static void CheckType(global::Mono.Cecil.TypeReference type)
		{
			if (type == null)
			{
				throw new global::System.ArgumentNullException("type");
			}
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00002EA4 File Offset: 0x000010A4
		public static bool ContainsGenericParameter(this global::Mono.Cecil.IGenericInstance self)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> genericArguments = self.GenericArguments;
			for (int i = 0; i < genericArguments.Count; i++)
			{
				if (genericArguments[i].ContainsGenericParameter)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00002EDC File Offset: 0x000010DC
		public static void GenericInstanceFullName(this global::Mono.Cecil.IGenericInstance self, global::System.Text.StringBuilder builder)
		{
			builder.Append("<");
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> genericArguments = self.GenericArguments;
			for (int i = 0; i < genericArguments.Count; i++)
			{
				if (i > 0)
				{
					builder.Append(",");
				}
				builder.Append(genericArguments[i].FullName);
			}
			builder.Append(">");
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00002F3C File Offset: 0x0000113C
		public static void MethodSignatureFullName(this global::Mono.Cecil.IMethodSignature self, global::System.Text.StringBuilder builder)
		{
			builder.Append("(");
			if (self.HasParameters)
			{
				global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition> parameters = self.Parameters;
				for (int i = 0; i < parameters.Count; i++)
				{
					global::Mono.Cecil.ParameterDefinition parameterDefinition = parameters[i];
					if (i > 0)
					{
						builder.Append(",");
					}
					if (parameterDefinition.ParameterType.IsSentinel)
					{
						builder.Append("...,");
					}
					builder.Append(parameterDefinition.ParameterType.FullName);
				}
			}
			builder.Append(")");
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00002FCD File Offset: 0x000011CD
		public static bool GetHasCustomAttributes(this global::Mono.Cecil.ICustomAttributeProvider self, global::Mono.Cecil.ModuleDefinition module)
		{
			if (!module.HasImage())
			{
				return false;
			}
			return module.Read<global::Mono.Cecil.ICustomAttributeProvider, bool>(self, (global::Mono.Cecil.ICustomAttributeProvider provider, global::Mono.Cecil.MetadataReader reader) => reader.HasCustomAttributes(provider));
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00003006 File Offset: 0x00001206
		public static global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> GetCustomAttributes(this global::Mono.Cecil.ICustomAttributeProvider self, global::Mono.Cecil.ModuleDefinition module)
		{
			if (!module.HasImage())
			{
				return new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute>();
			}
			return module.Read<global::Mono.Cecil.ICustomAttributeProvider, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute>>(self, (global::Mono.Cecil.ICustomAttributeProvider provider, global::Mono.Cecil.MetadataReader reader) => reader.ReadCustomAttributes(provider));
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000303C File Offset: 0x0000123C
		public static global::System.Security.Cryptography.RSA CreateRSA(this global::System.Reflection.StrongNameKeyPair key_pair)
		{
			byte[] blob;
			string keyContainerName;
			if (!global::Mono.Cecil.Mixin.TryGetKeyContainer(key_pair, out blob, out keyContainerName))
			{
				return global::Mono.Security.Cryptography.CryptoConvert.FromCapiKeyBlob(blob);
			}
			global::System.Security.Cryptography.CspParameters parameters = new global::System.Security.Cryptography.CspParameters
			{
				Flags = global::System.Security.Cryptography.CspProviderFlags.UseMachineKeyStore,
				KeyContainerName = keyContainerName,
				KeyNumber = 2
			};
			return new global::System.Security.Cryptography.RSACryptoServiceProvider(parameters);
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00003080 File Offset: 0x00001280
		private static bool TryGetKeyContainer(global::System.Runtime.Serialization.ISerializable key_pair, out byte[] key, out string key_container)
		{
			global::System.Runtime.Serialization.SerializationInfo serializationInfo = new global::System.Runtime.Serialization.SerializationInfo(typeof(global::System.Reflection.StrongNameKeyPair), new global::System.Runtime.Serialization.FormatterConverter());
			key_pair.GetObjectData(serializationInfo, default(global::System.Runtime.Serialization.StreamingContext));
			key = (byte[])serializationInfo.GetValue("_keyPairArray", typeof(byte[]));
			key_container = serializationInfo.GetString("_keyPairContainer");
			return key_container != null;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x000030EC File Offset: 0x000012EC
		public static bool GetHasMarshalInfo(this global::Mono.Cecil.IMarshalInfoProvider self, global::Mono.Cecil.ModuleDefinition module)
		{
			if (!module.HasImage())
			{
				return false;
			}
			return module.Read<global::Mono.Cecil.IMarshalInfoProvider, bool>(self, (global::Mono.Cecil.IMarshalInfoProvider provider, global::Mono.Cecil.MetadataReader reader) => reader.HasMarshalInfo(provider));
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00003125 File Offset: 0x00001325
		public static global::Mono.Cecil.MarshalInfo GetMarshalInfo(this global::Mono.Cecil.IMarshalInfoProvider self, global::Mono.Cecil.ModuleDefinition module)
		{
			if (!module.HasImage())
			{
				return null;
			}
			return module.Read<global::Mono.Cecil.IMarshalInfoProvider, global::Mono.Cecil.MarshalInfo>(self, (global::Mono.Cecil.IMarshalInfoProvider provider, global::Mono.Cecil.MetadataReader reader) => reader.ReadMarshalInfo(provider));
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00003158 File Offset: 0x00001358
		public static uint ReadCompressedUInt32(this byte[] data, ref int position)
		{
			uint num;
			if ((data[position] & 0x80) == 0)
			{
				num = (uint)data[position];
				position++;
			}
			else if ((data[position] & 0x40) == 0)
			{
				num = ((uint)data[position] & 0xFFFFFF7FU) << 8;
				num |= (uint)data[position + 1];
				position += 2;
			}
			else
			{
				num = ((uint)data[position] & 0xFFFFFF3FU) << 0x18;
				num |= (uint)((uint)data[position + 1] << 0x10);
				num |= (uint)((uint)data[position + 2] << 8);
				num |= (uint)data[position + 3];
				position += 4;
			}
			return num;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x000031DC File Offset: 0x000013DC
		public static global::Mono.Cecil.MetadataToken GetMetadataToken(this global::Mono.Cecil.Metadata.CodedIndex self, uint data)
		{
			uint rid;
			global::Mono.Cecil.TokenType type;
			switch (self)
			{
			case global::Mono.Cecil.Metadata.CodedIndex.TypeDefOrRef:
				rid = data >> 2;
				switch (data & 3U)
				{
				case 0U:
					type = global::Mono.Cecil.TokenType.TypeDef;
					break;
				case 1U:
					type = global::Mono.Cecil.TokenType.TypeRef;
					break;
				case 2U:
					type = global::Mono.Cecil.TokenType.TypeSpec;
					break;
				default:
					goto IL_44B;
				}
				break;
			case global::Mono.Cecil.Metadata.CodedIndex.HasConstant:
				rid = data >> 2;
				switch (data & 3U)
				{
				case 0U:
					type = global::Mono.Cecil.TokenType.Field;
					break;
				case 1U:
					type = global::Mono.Cecil.TokenType.Param;
					break;
				case 2U:
					type = global::Mono.Cecil.TokenType.Property;
					break;
				default:
					goto IL_44B;
				}
				break;
			case global::Mono.Cecil.Metadata.CodedIndex.HasCustomAttribute:
				rid = data >> 5;
				switch (data & 0x1FU)
				{
				case 0U:
					type = global::Mono.Cecil.TokenType.Method;
					break;
				case 1U:
					type = global::Mono.Cecil.TokenType.Field;
					break;
				case 2U:
					type = global::Mono.Cecil.TokenType.TypeRef;
					break;
				case 3U:
					type = global::Mono.Cecil.TokenType.TypeDef;
					break;
				case 4U:
					type = global::Mono.Cecil.TokenType.Param;
					break;
				case 5U:
					type = global::Mono.Cecil.TokenType.InterfaceImpl;
					break;
				case 6U:
					type = global::Mono.Cecil.TokenType.MemberRef;
					break;
				case 7U:
					type = global::Mono.Cecil.TokenType.Module;
					break;
				case 8U:
					type = global::Mono.Cecil.TokenType.Permission;
					break;
				case 9U:
					type = global::Mono.Cecil.TokenType.Property;
					break;
				case 0xAU:
					type = global::Mono.Cecil.TokenType.Event;
					break;
				case 0xBU:
					type = global::Mono.Cecil.TokenType.Signature;
					break;
				case 0xCU:
					type = global::Mono.Cecil.TokenType.ModuleRef;
					break;
				case 0xDU:
					type = global::Mono.Cecil.TokenType.TypeSpec;
					break;
				case 0xEU:
					type = global::Mono.Cecil.TokenType.Assembly;
					break;
				case 0xFU:
					type = global::Mono.Cecil.TokenType.AssemblyRef;
					break;
				case 0x10U:
					type = global::Mono.Cecil.TokenType.File;
					break;
				case 0x11U:
					type = global::Mono.Cecil.TokenType.ExportedType;
					break;
				case 0x12U:
					type = global::Mono.Cecil.TokenType.ManifestResource;
					break;
				case 0x13U:
					type = global::Mono.Cecil.TokenType.GenericParam;
					break;
				default:
					goto IL_44B;
				}
				break;
			case global::Mono.Cecil.Metadata.CodedIndex.HasFieldMarshal:
				rid = data >> 1;
				switch (data & 1U)
				{
				case 0U:
					type = global::Mono.Cecil.TokenType.Field;
					break;
				case 1U:
					type = global::Mono.Cecil.TokenType.Param;
					break;
				default:
					goto IL_44B;
				}
				break;
			case global::Mono.Cecil.Metadata.CodedIndex.HasDeclSecurity:
				rid = data >> 2;
				switch (data & 3U)
				{
				case 0U:
					type = global::Mono.Cecil.TokenType.TypeDef;
					break;
				case 1U:
					type = global::Mono.Cecil.TokenType.Method;
					break;
				case 2U:
					type = global::Mono.Cecil.TokenType.Assembly;
					break;
				default:
					goto IL_44B;
				}
				break;
			case global::Mono.Cecil.Metadata.CodedIndex.MemberRefParent:
				rid = data >> 3;
				switch (data & 7U)
				{
				case 0U:
					type = global::Mono.Cecil.TokenType.TypeDef;
					break;
				case 1U:
					type = global::Mono.Cecil.TokenType.TypeRef;
					break;
				case 2U:
					type = global::Mono.Cecil.TokenType.ModuleRef;
					break;
				case 3U:
					type = global::Mono.Cecil.TokenType.Method;
					break;
				case 4U:
					type = global::Mono.Cecil.TokenType.TypeSpec;
					break;
				default:
					goto IL_44B;
				}
				break;
			case global::Mono.Cecil.Metadata.CodedIndex.HasSemantics:
				rid = data >> 1;
				switch (data & 1U)
				{
				case 0U:
					type = global::Mono.Cecil.TokenType.Event;
					break;
				case 1U:
					type = global::Mono.Cecil.TokenType.Property;
					break;
				default:
					goto IL_44B;
				}
				break;
			case global::Mono.Cecil.Metadata.CodedIndex.MethodDefOrRef:
				rid = data >> 1;
				switch (data & 1U)
				{
				case 0U:
					type = global::Mono.Cecil.TokenType.Method;
					break;
				case 1U:
					type = global::Mono.Cecil.TokenType.MemberRef;
					break;
				default:
					goto IL_44B;
				}
				break;
			case global::Mono.Cecil.Metadata.CodedIndex.MemberForwarded:
				rid = data >> 1;
				switch (data & 1U)
				{
				case 0U:
					type = global::Mono.Cecil.TokenType.Field;
					break;
				case 1U:
					type = global::Mono.Cecil.TokenType.Method;
					break;
				default:
					goto IL_44B;
				}
				break;
			case global::Mono.Cecil.Metadata.CodedIndex.Implementation:
				rid = data >> 2;
				switch (data & 3U)
				{
				case 0U:
					type = global::Mono.Cecil.TokenType.File;
					break;
				case 1U:
					type = global::Mono.Cecil.TokenType.AssemblyRef;
					break;
				case 2U:
					type = global::Mono.Cecil.TokenType.ExportedType;
					break;
				default:
					goto IL_44B;
				}
				break;
			case global::Mono.Cecil.Metadata.CodedIndex.CustomAttributeType:
				rid = data >> 3;
				switch (data & 7U)
				{
				case 2U:
					type = global::Mono.Cecil.TokenType.Method;
					break;
				case 3U:
					type = global::Mono.Cecil.TokenType.MemberRef;
					break;
				default:
					goto IL_44B;
				}
				break;
			case global::Mono.Cecil.Metadata.CodedIndex.ResolutionScope:
				rid = data >> 2;
				switch (data & 3U)
				{
				case 0U:
					type = global::Mono.Cecil.TokenType.Module;
					break;
				case 1U:
					type = global::Mono.Cecil.TokenType.ModuleRef;
					break;
				case 2U:
					type = global::Mono.Cecil.TokenType.AssemblyRef;
					break;
				case 3U:
					type = global::Mono.Cecil.TokenType.TypeRef;
					break;
				default:
					goto IL_44B;
				}
				break;
			case global::Mono.Cecil.Metadata.CodedIndex.TypeOrMethodDef:
				rid = data >> 1;
				switch (data & 1U)
				{
				case 0U:
					type = global::Mono.Cecil.TokenType.TypeDef;
					break;
				case 1U:
					type = global::Mono.Cecil.TokenType.Method;
					break;
				default:
					goto IL_44B;
				}
				break;
			default:
				goto IL_44B;
			}
			return new global::Mono.Cecil.MetadataToken(type, rid);
			IL_44B:
			return global::Mono.Cecil.MetadataToken.Zero;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000363C File Offset: 0x0000183C
		public static uint CompressMetadataToken(this global::Mono.Cecil.Metadata.CodedIndex self, global::Mono.Cecil.MetadataToken token)
		{
			uint num = 0U;
			if (token.RID == 0U)
			{
				return num;
			}
			switch (self)
			{
			case global::Mono.Cecil.Metadata.CodedIndex.TypeDefOrRef:
			{
				num = token.RID << 2;
				global::Mono.Cecil.TokenType tokenType = token.TokenType;
				if (tokenType == global::Mono.Cecil.TokenType.TypeRef)
				{
					return num | 1U;
				}
				if (tokenType == global::Mono.Cecil.TokenType.TypeDef)
				{
					return num;
				}
				if (tokenType == global::Mono.Cecil.TokenType.TypeSpec)
				{
					return num | 2U;
				}
				break;
			}
			case global::Mono.Cecil.Metadata.CodedIndex.HasConstant:
			{
				num = token.RID << 2;
				global::Mono.Cecil.TokenType tokenType2 = token.TokenType;
				if (tokenType2 == global::Mono.Cecil.TokenType.Field)
				{
					return num;
				}
				if (tokenType2 == global::Mono.Cecil.TokenType.Param)
				{
					return num | 1U;
				}
				if (tokenType2 == global::Mono.Cecil.TokenType.Property)
				{
					return num | 2U;
				}
				break;
			}
			case global::Mono.Cecil.Metadata.CodedIndex.HasCustomAttribute:
			{
				num = token.RID << 5;
				global::Mono.Cecil.TokenType tokenType3 = token.TokenType;
				if (tokenType3 <= global::Mono.Cecil.TokenType.Signature)
				{
					if (tokenType3 <= global::Mono.Cecil.TokenType.Method)
					{
						if (tokenType3 <= global::Mono.Cecil.TokenType.TypeRef)
						{
							if (tokenType3 == global::Mono.Cecil.TokenType.Module)
							{
								return num | 7U;
							}
							if (tokenType3 == global::Mono.Cecil.TokenType.TypeRef)
							{
								return num | 2U;
							}
						}
						else
						{
							if (tokenType3 == global::Mono.Cecil.TokenType.TypeDef)
							{
								return num | 3U;
							}
							if (tokenType3 == global::Mono.Cecil.TokenType.Field)
							{
								return num | 1U;
							}
							if (tokenType3 == global::Mono.Cecil.TokenType.Method)
							{
								return num;
							}
						}
					}
					else if (tokenType3 <= global::Mono.Cecil.TokenType.InterfaceImpl)
					{
						if (tokenType3 == global::Mono.Cecil.TokenType.Param)
						{
							return num | 4U;
						}
						if (tokenType3 == global::Mono.Cecil.TokenType.InterfaceImpl)
						{
							return num | 5U;
						}
					}
					else
					{
						if (tokenType3 == global::Mono.Cecil.TokenType.MemberRef)
						{
							return num | 6U;
						}
						if (tokenType3 == global::Mono.Cecil.TokenType.Permission)
						{
							return num | 8U;
						}
						if (tokenType3 == global::Mono.Cecil.TokenType.Signature)
						{
							return num | 0xBU;
						}
					}
				}
				else if (tokenType3 <= global::Mono.Cecil.TokenType.Assembly)
				{
					if (tokenType3 <= global::Mono.Cecil.TokenType.Property)
					{
						if (tokenType3 == global::Mono.Cecil.TokenType.Event)
						{
							return num | 0xAU;
						}
						if (tokenType3 == global::Mono.Cecil.TokenType.Property)
						{
							return num | 9U;
						}
					}
					else
					{
						if (tokenType3 == global::Mono.Cecil.TokenType.ModuleRef)
						{
							return num | 0xCU;
						}
						if (tokenType3 == global::Mono.Cecil.TokenType.TypeSpec)
						{
							return num | 0xDU;
						}
						if (tokenType3 == global::Mono.Cecil.TokenType.Assembly)
						{
							return num | 0xEU;
						}
					}
				}
				else if (tokenType3 <= global::Mono.Cecil.TokenType.File)
				{
					if (tokenType3 == global::Mono.Cecil.TokenType.AssemblyRef)
					{
						return num | 0xFU;
					}
					if (tokenType3 == global::Mono.Cecil.TokenType.File)
					{
						return num | 0x10U;
					}
				}
				else
				{
					if (tokenType3 == global::Mono.Cecil.TokenType.ExportedType)
					{
						return num | 0x11U;
					}
					if (tokenType3 == global::Mono.Cecil.TokenType.ManifestResource)
					{
						return num | 0x12U;
					}
					if (tokenType3 == global::Mono.Cecil.TokenType.GenericParam)
					{
						return num | 0x13U;
					}
				}
				break;
			}
			case global::Mono.Cecil.Metadata.CodedIndex.HasFieldMarshal:
			{
				num = token.RID << 1;
				global::Mono.Cecil.TokenType tokenType4 = token.TokenType;
				if (tokenType4 == global::Mono.Cecil.TokenType.Field)
				{
					return num;
				}
				if (tokenType4 == global::Mono.Cecil.TokenType.Param)
				{
					return num | 1U;
				}
				break;
			}
			case global::Mono.Cecil.Metadata.CodedIndex.HasDeclSecurity:
			{
				num = token.RID << 2;
				global::Mono.Cecil.TokenType tokenType5 = token.TokenType;
				if (tokenType5 == global::Mono.Cecil.TokenType.TypeDef)
				{
					return num;
				}
				if (tokenType5 == global::Mono.Cecil.TokenType.Method)
				{
					return num | 1U;
				}
				if (tokenType5 == global::Mono.Cecil.TokenType.Assembly)
				{
					return num | 2U;
				}
				break;
			}
			case global::Mono.Cecil.Metadata.CodedIndex.MemberRefParent:
			{
				num = token.RID << 3;
				global::Mono.Cecil.TokenType tokenType6 = token.TokenType;
				if (tokenType6 <= global::Mono.Cecil.TokenType.TypeDef)
				{
					if (tokenType6 == global::Mono.Cecil.TokenType.TypeRef)
					{
						return num | 1U;
					}
					if (tokenType6 == global::Mono.Cecil.TokenType.TypeDef)
					{
						return num;
					}
				}
				else
				{
					if (tokenType6 == global::Mono.Cecil.TokenType.Method)
					{
						return num | 3U;
					}
					if (tokenType6 == global::Mono.Cecil.TokenType.ModuleRef)
					{
						return num | 2U;
					}
					if (tokenType6 == global::Mono.Cecil.TokenType.TypeSpec)
					{
						return num | 4U;
					}
				}
				break;
			}
			case global::Mono.Cecil.Metadata.CodedIndex.HasSemantics:
			{
				num = token.RID << 1;
				global::Mono.Cecil.TokenType tokenType7 = token.TokenType;
				if (tokenType7 == global::Mono.Cecil.TokenType.Event)
				{
					return num;
				}
				if (tokenType7 == global::Mono.Cecil.TokenType.Property)
				{
					return num | 1U;
				}
				break;
			}
			case global::Mono.Cecil.Metadata.CodedIndex.MethodDefOrRef:
			{
				num = token.RID << 1;
				global::Mono.Cecil.TokenType tokenType8 = token.TokenType;
				if (tokenType8 == global::Mono.Cecil.TokenType.Method)
				{
					return num;
				}
				if (tokenType8 == global::Mono.Cecil.TokenType.MemberRef)
				{
					return num | 1U;
				}
				break;
			}
			case global::Mono.Cecil.Metadata.CodedIndex.MemberForwarded:
			{
				num = token.RID << 1;
				global::Mono.Cecil.TokenType tokenType9 = token.TokenType;
				if (tokenType9 == global::Mono.Cecil.TokenType.Field)
				{
					return num;
				}
				if (tokenType9 == global::Mono.Cecil.TokenType.Method)
				{
					return num | 1U;
				}
				break;
			}
			case global::Mono.Cecil.Metadata.CodedIndex.Implementation:
			{
				num = token.RID << 2;
				global::Mono.Cecil.TokenType tokenType10 = token.TokenType;
				if (tokenType10 == global::Mono.Cecil.TokenType.AssemblyRef)
				{
					return num | 1U;
				}
				if (tokenType10 == global::Mono.Cecil.TokenType.File)
				{
					return num;
				}
				if (tokenType10 == global::Mono.Cecil.TokenType.ExportedType)
				{
					return num | 2U;
				}
				break;
			}
			case global::Mono.Cecil.Metadata.CodedIndex.CustomAttributeType:
			{
				num = token.RID << 3;
				global::Mono.Cecil.TokenType tokenType11 = token.TokenType;
				if (tokenType11 == global::Mono.Cecil.TokenType.Method)
				{
					return num | 2U;
				}
				if (tokenType11 == global::Mono.Cecil.TokenType.MemberRef)
				{
					return num | 3U;
				}
				break;
			}
			case global::Mono.Cecil.Metadata.CodedIndex.ResolutionScope:
			{
				num = token.RID << 2;
				global::Mono.Cecil.TokenType tokenType12 = token.TokenType;
				if (tokenType12 <= global::Mono.Cecil.TokenType.TypeRef)
				{
					if (tokenType12 == global::Mono.Cecil.TokenType.Module)
					{
						return num;
					}
					if (tokenType12 == global::Mono.Cecil.TokenType.TypeRef)
					{
						return num | 3U;
					}
				}
				else
				{
					if (tokenType12 == global::Mono.Cecil.TokenType.ModuleRef)
					{
						return num | 1U;
					}
					if (tokenType12 == global::Mono.Cecil.TokenType.AssemblyRef)
					{
						return num | 2U;
					}
				}
				break;
			}
			case global::Mono.Cecil.Metadata.CodedIndex.TypeOrMethodDef:
			{
				num = token.RID << 1;
				global::Mono.Cecil.TokenType tokenType13 = token.TokenType;
				if (tokenType13 == global::Mono.Cecil.TokenType.TypeDef)
				{
					return num;
				}
				if (tokenType13 == global::Mono.Cecil.TokenType.Method)
				{
					return num | 1U;
				}
				break;
			}
			}
			throw new global::System.ArgumentException();
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00003B10 File Offset: 0x00001D10
		public static int GetSize(this global::Mono.Cecil.Metadata.CodedIndex self, global::System.Func<global::Mono.Cecil.Metadata.Table, int> counter)
		{
			int num;
			global::Mono.Cecil.Metadata.Table[] array;
			switch (self)
			{
			case global::Mono.Cecil.Metadata.CodedIndex.TypeDefOrRef:
				num = 2;
				array = new global::Mono.Cecil.Metadata.Table[]
				{
					global::Mono.Cecil.Metadata.Table.TypeDef,
					global::Mono.Cecil.Metadata.Table.TypeRef,
					global::Mono.Cecil.Metadata.Table.TypeSpec
				};
				break;
			case global::Mono.Cecil.Metadata.CodedIndex.HasConstant:
				num = 2;
				array = new global::Mono.Cecil.Metadata.Table[]
				{
					global::Mono.Cecil.Metadata.Table.Field,
					global::Mono.Cecil.Metadata.Table.Param,
					global::Mono.Cecil.Metadata.Table.Property
				};
				break;
			case global::Mono.Cecil.Metadata.CodedIndex.HasCustomAttribute:
				num = 5;
				array = new global::Mono.Cecil.Metadata.Table[]
				{
					global::Mono.Cecil.Metadata.Table.Method,
					global::Mono.Cecil.Metadata.Table.Field,
					global::Mono.Cecil.Metadata.Table.TypeRef,
					global::Mono.Cecil.Metadata.Table.TypeDef,
					global::Mono.Cecil.Metadata.Table.Param,
					global::Mono.Cecil.Metadata.Table.InterfaceImpl,
					global::Mono.Cecil.Metadata.Table.MemberRef,
					global::Mono.Cecil.Metadata.Table.Module,
					global::Mono.Cecil.Metadata.Table.DeclSecurity,
					global::Mono.Cecil.Metadata.Table.Property,
					global::Mono.Cecil.Metadata.Table.Event,
					global::Mono.Cecil.Metadata.Table.StandAloneSig,
					global::Mono.Cecil.Metadata.Table.ModuleRef,
					global::Mono.Cecil.Metadata.Table.TypeSpec,
					global::Mono.Cecil.Metadata.Table.Assembly,
					global::Mono.Cecil.Metadata.Table.AssemblyRef,
					global::Mono.Cecil.Metadata.Table.File,
					global::Mono.Cecil.Metadata.Table.ExportedType,
					global::Mono.Cecil.Metadata.Table.ManifestResource,
					global::Mono.Cecil.Metadata.Table.GenericParam
				};
				break;
			case global::Mono.Cecil.Metadata.CodedIndex.HasFieldMarshal:
				num = 1;
				array = new global::Mono.Cecil.Metadata.Table[]
				{
					global::Mono.Cecil.Metadata.Table.Field,
					global::Mono.Cecil.Metadata.Table.Param
				};
				break;
			case global::Mono.Cecil.Metadata.CodedIndex.HasDeclSecurity:
				num = 2;
				array = new global::Mono.Cecil.Metadata.Table[]
				{
					global::Mono.Cecil.Metadata.Table.TypeDef,
					global::Mono.Cecil.Metadata.Table.Method,
					global::Mono.Cecil.Metadata.Table.Assembly
				};
				break;
			case global::Mono.Cecil.Metadata.CodedIndex.MemberRefParent:
				num = 3;
				array = new global::Mono.Cecil.Metadata.Table[]
				{
					global::Mono.Cecil.Metadata.Table.TypeDef,
					global::Mono.Cecil.Metadata.Table.TypeRef,
					global::Mono.Cecil.Metadata.Table.ModuleRef,
					global::Mono.Cecil.Metadata.Table.Method,
					global::Mono.Cecil.Metadata.Table.TypeSpec
				};
				break;
			case global::Mono.Cecil.Metadata.CodedIndex.HasSemantics:
				num = 1;
				array = new global::Mono.Cecil.Metadata.Table[]
				{
					global::Mono.Cecil.Metadata.Table.Event,
					global::Mono.Cecil.Metadata.Table.Property
				};
				break;
			case global::Mono.Cecil.Metadata.CodedIndex.MethodDefOrRef:
				num = 1;
				array = new global::Mono.Cecil.Metadata.Table[]
				{
					global::Mono.Cecil.Metadata.Table.Method,
					global::Mono.Cecil.Metadata.Table.MemberRef
				};
				break;
			case global::Mono.Cecil.Metadata.CodedIndex.MemberForwarded:
				num = 1;
				array = new global::Mono.Cecil.Metadata.Table[]
				{
					global::Mono.Cecil.Metadata.Table.Field,
					global::Mono.Cecil.Metadata.Table.Method
				};
				break;
			case global::Mono.Cecil.Metadata.CodedIndex.Implementation:
				num = 2;
				array = new global::Mono.Cecil.Metadata.Table[]
				{
					global::Mono.Cecil.Metadata.Table.File,
					global::Mono.Cecil.Metadata.Table.AssemblyRef,
					global::Mono.Cecil.Metadata.Table.ExportedType
				};
				break;
			case global::Mono.Cecil.Metadata.CodedIndex.CustomAttributeType:
				num = 3;
				array = new global::Mono.Cecil.Metadata.Table[]
				{
					global::Mono.Cecil.Metadata.Table.Method,
					global::Mono.Cecil.Metadata.Table.MemberRef
				};
				break;
			case global::Mono.Cecil.Metadata.CodedIndex.ResolutionScope:
				num = 2;
				array = new global::Mono.Cecil.Metadata.Table[]
				{
					global::Mono.Cecil.Metadata.Table.Module,
					global::Mono.Cecil.Metadata.Table.ModuleRef,
					global::Mono.Cecil.Metadata.Table.AssemblyRef,
					global::Mono.Cecil.Metadata.Table.TypeRef
				};
				break;
			case global::Mono.Cecil.Metadata.CodedIndex.TypeOrMethodDef:
				num = 1;
				array = new global::Mono.Cecil.Metadata.Table[]
				{
					global::Mono.Cecil.Metadata.Table.TypeDef,
					global::Mono.Cecil.Metadata.Table.Method
				};
				break;
			default:
				throw new global::System.ArgumentException();
			}
			int num2 = 0;
			for (int i = 0; i < array.Length; i++)
			{
				num2 = global::System.Math.Max(counter(array[i]), num2);
			}
			if (num2 >= 1 << 0x10 - num)
			{
				return 4;
			}
			return 2;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00003D97 File Offset: 0x00001F97
		public static bool IsTypeOf(this global::Mono.Cecil.TypeReference self, string @namespace, string name)
		{
			return self.Name == name && self.Namespace == @namespace;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00003DB8 File Offset: 0x00001FB8
		public static bool IsTypeSpecification(this global::Mono.Cecil.TypeReference type)
		{
			global::Mono.Cecil.Metadata.ElementType etype = type.etype;
			switch (etype)
			{
			case global::Mono.Cecil.Metadata.ElementType.Ptr:
			case global::Mono.Cecil.Metadata.ElementType.ByRef:
			case global::Mono.Cecil.Metadata.ElementType.Var:
			case global::Mono.Cecil.Metadata.ElementType.Array:
			case global::Mono.Cecil.Metadata.ElementType.GenericInst:
			case global::Mono.Cecil.Metadata.ElementType.FnPtr:
			case global::Mono.Cecil.Metadata.ElementType.SzArray:
			case global::Mono.Cecil.Metadata.ElementType.MVar:
			case global::Mono.Cecil.Metadata.ElementType.CModReqD:
			case global::Mono.Cecil.Metadata.ElementType.CModOpt:
				break;
			case global::Mono.Cecil.Metadata.ElementType.ValueType:
			case global::Mono.Cecil.Metadata.ElementType.Class:
			case global::Mono.Cecil.Metadata.ElementType.TypedByRef:
			case (global::Mono.Cecil.Metadata.ElementType)0x17:
			case global::Mono.Cecil.Metadata.ElementType.I:
			case global::Mono.Cecil.Metadata.ElementType.U:
			case (global::Mono.Cecil.Metadata.ElementType)0x1A:
			case global::Mono.Cecil.Metadata.ElementType.Object:
				return false;
			default:
				if (etype != global::Mono.Cecil.Metadata.ElementType.Sentinel && etype != global::Mono.Cecil.Metadata.ElementType.Pinned)
				{
					return false;
				}
				break;
			}
			return true;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00003E2C File Offset: 0x0000202C
		public static global::Mono.Cecil.TypeDefinition CheckedResolve(this global::Mono.Cecil.TypeReference self)
		{
			global::Mono.Cecil.TypeDefinition typeDefinition = self.Resolve();
			if (typeDefinition == null)
			{
				throw new global::Mono.Cecil.ResolutionException(self);
			}
			return typeDefinition;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00003E4C File Offset: 0x0000204C
		public static global::Mono.Cecil.ParameterDefinition GetParameter(this global::Mono.Cecil.Cil.MethodBody self, int index)
		{
			global::Mono.Cecil.MethodDefinition method = self.method;
			if (method.HasThis)
			{
				if (index == 0)
				{
					return self.ThisParameter;
				}
				index--;
			}
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition> parameters = method.Parameters;
			if (index < 0 || index >= parameters.size)
			{
				return null;
			}
			return parameters[index];
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00003E94 File Offset: 0x00002094
		public static global::Mono.Cecil.Cil.VariableDefinition GetVariable(this global::Mono.Cecil.Cil.MethodBody self, int index)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.VariableDefinition> variables = self.Variables;
			if (index < 0 || index >= variables.size)
			{
				return null;
			}
			return variables[index];
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00003EBE File Offset: 0x000020BE
		public static bool GetSemantics(this global::Mono.Cecil.MethodDefinition self, global::Mono.Cecil.MethodSemanticsAttributes semantics)
		{
			return (ushort)(self.SemanticsAttributes & semantics) != 0;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00003ECF File Offset: 0x000020CF
		public static void SetSemantics(this global::Mono.Cecil.MethodDefinition self, global::Mono.Cecil.MethodSemanticsAttributes semantics, bool value)
		{
			if (value)
			{
				self.SemanticsAttributes |= semantics;
				return;
			}
			self.SemanticsAttributes &= ~semantics;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00003EF5 File Offset: 0x000020F5
		public static void CheckName(string name)
		{
			if (name == null)
			{
				throw new global::System.ArgumentNullException("name");
			}
			if (name.Length == 0)
			{
				throw new global::System.ArgumentException("Empty name");
			}
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00002B50 File Offset: 0x00000D50
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static object <ResolveConstant>b__0(global::Mono.Cecil.IConstantProvider provider, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadConstant(provider);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00002C05 File Offset: 0x00000E05
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static bool <GetHasGenericParameters>b__2(global::Mono.Cecil.IGenericParameterProvider provider, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.HasGenericParameters(provider);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00002C3E File Offset: 0x00000E3E
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Collections.Generic.Collection<global::Mono.Cecil.GenericParameter> <GetGenericParameters>b__4(global::Mono.Cecil.IGenericParameterProvider provider, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadGenericParameters(provider);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00002D95 File Offset: 0x00000F95
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static bool <GetHasSecurityDeclarations>b__6(global::Mono.Cecil.ISecurityDeclarationProvider provider, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.HasSecurityDeclarations(provider);
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00002DCE File Offset: 0x00000FCE
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityDeclaration> <GetSecurityDeclarations>b__8(global::Mono.Cecil.ISecurityDeclarationProvider provider, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadSecurityDeclarations(provider);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00002FC4 File Offset: 0x000011C4
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static bool <GetHasCustomAttributes>b__a(global::Mono.Cecil.ICustomAttributeProvider provider, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.HasCustomAttributes(provider);
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00002FFD File Offset: 0x000011FD
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> <GetCustomAttributes>b__c(global::Mono.Cecil.ICustomAttributeProvider provider, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadCustomAttributes(provider);
		}

		// Token: 0x060000DD RID: 221 RVA: 0x000030E3 File Offset: 0x000012E3
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static bool <GetHasMarshalInfo>b__f(global::Mono.Cecil.IMarshalInfoProvider provider, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.HasMarshalInfo(provider);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000311C File Offset: 0x0000131C
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Cecil.MarshalInfo <GetMarshalInfo>b__11(global::Mono.Cecil.IMarshalInfoProvider provider, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadMarshalInfo(provider);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00003F18 File Offset: 0x00002118
		// Note: this type is marked as 'beforefieldinit'.
		static Mixin()
		{
		}

		// Token: 0x0400001F RID: 31
		public const int NotResolvedMarker = -2;

		// Token: 0x04000020 RID: 32
		public const int NoDataMarker = -1;

		// Token: 0x04000021 RID: 33
		internal static object NoValue = new object();

		// Token: 0x04000022 RID: 34
		internal static object NotResolved = new object();

		// Token: 0x04000023 RID: 35
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.IConstantProvider, global::Mono.Cecil.MetadataReader, object> CS$<>9__CachedAnonymousMethodDelegate1;

		// Token: 0x04000024 RID: 36
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.IGenericParameterProvider, global::Mono.Cecil.MetadataReader, bool> CS$<>9__CachedAnonymousMethodDelegate3;

		// Token: 0x04000025 RID: 37
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.IGenericParameterProvider, global::Mono.Cecil.MetadataReader, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.GenericParameter>> CS$<>9__CachedAnonymousMethodDelegate5;

		// Token: 0x04000026 RID: 38
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.ISecurityDeclarationProvider, global::Mono.Cecil.MetadataReader, bool> CS$<>9__CachedAnonymousMethodDelegate7;

		// Token: 0x04000027 RID: 39
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.ISecurityDeclarationProvider, global::Mono.Cecil.MetadataReader, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityDeclaration>> CS$<>9__CachedAnonymousMethodDelegate9;

		// Token: 0x04000028 RID: 40
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.ICustomAttributeProvider, global::Mono.Cecil.MetadataReader, bool> CS$<>9__CachedAnonymousMethodDelegateb;

		// Token: 0x04000029 RID: 41
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.ICustomAttributeProvider, global::Mono.Cecil.MetadataReader, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute>> CS$<>9__CachedAnonymousMethodDelegated;

		// Token: 0x0400002A RID: 42
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.IMarshalInfoProvider, global::Mono.Cecil.MetadataReader, bool> CS$<>9__CachedAnonymousMethodDelegate10;

		// Token: 0x0400002B RID: 43
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.IMarshalInfoProvider, global::Mono.Cecil.MetadataReader, global::Mono.Cecil.MarshalInfo> CS$<>9__CachedAnonymousMethodDelegate12;
	}
}
