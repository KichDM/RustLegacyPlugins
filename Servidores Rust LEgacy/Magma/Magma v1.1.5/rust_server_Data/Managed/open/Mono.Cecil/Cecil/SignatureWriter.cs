using System;
using System.Text;
using Mono.Cecil.Metadata;
using Mono.Cecil.PE;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x020000F0 RID: 240
	internal sealed class SignatureWriter : global::Mono.Cecil.PE.ByteBuffer
	{
		// Token: 0x060008CB RID: 2251 RVA: 0x00018F2C File Offset: 0x0001712C
		public SignatureWriter(global::Mono.Cecil.MetadataBuilder metadata) : base(6)
		{
			this.metadata = metadata;
		}

		// Token: 0x060008CC RID: 2252 RVA: 0x00018F3C File Offset: 0x0001713C
		public void WriteElementType(global::Mono.Cecil.Metadata.ElementType element_type)
		{
			base.WriteByte((byte)element_type);
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x00018F48 File Offset: 0x00017148
		public void WriteUTF8String(string @string)
		{
			if (@string == null)
			{
				base.WriteByte(byte.MaxValue);
				return;
			}
			byte[] bytes = global::System.Text.Encoding.UTF8.GetBytes(@string);
			base.WriteCompressedUInt32((uint)bytes.Length);
			base.WriteBytes(bytes);
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x00018F80 File Offset: 0x00017180
		public void WriteMethodSignature(global::Mono.Cecil.IMethodSignature method)
		{
			byte b = (byte)method.CallingConvention;
			if (method.HasThis)
			{
				b |= 0x20;
			}
			if (method.ExplicitThis)
			{
				b |= 0x40;
			}
			global::Mono.Cecil.IGenericParameterProvider genericParameterProvider = method as global::Mono.Cecil.IGenericParameterProvider;
			int num = (genericParameterProvider != null && genericParameterProvider.HasGenericParameters) ? genericParameterProvider.GenericParameters.Count : 0;
			if (num > 0)
			{
				b |= 0x10;
			}
			int num2 = method.HasParameters ? method.Parameters.Count : 0;
			base.WriteByte(b);
			if (num > 0)
			{
				base.WriteCompressedUInt32((uint)num);
			}
			base.WriteCompressedUInt32((uint)num2);
			this.WriteTypeSignature(method.ReturnType);
			if (num2 == 0)
			{
				return;
			}
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition> parameters = method.Parameters;
			for (int i = 0; i < num2; i++)
			{
				this.WriteTypeSignature(parameters[i].ParameterType);
			}
		}

		// Token: 0x060008CF RID: 2255 RVA: 0x00019047 File Offset: 0x00017247
		private uint MakeTypeDefOrRefCodedRID(global::Mono.Cecil.TypeReference type)
		{
			return global::Mono.Cecil.Metadata.CodedIndex.TypeDefOrRef.CompressMetadataToken(this.metadata.LookupToken(type));
		}

		// Token: 0x060008D0 RID: 2256 RVA: 0x0001905C File Offset: 0x0001725C
		public void WriteTypeSignature(global::Mono.Cecil.TypeReference type)
		{
			if (type == null)
			{
				throw new global::System.ArgumentNullException();
			}
			global::Mono.Cecil.Metadata.ElementType etype = type.etype;
			global::Mono.Cecil.Metadata.ElementType elementType = etype;
			if (elementType <= global::Mono.Cecil.Metadata.ElementType.GenericInst)
			{
				if (elementType == global::Mono.Cecil.Metadata.ElementType.None)
				{
					this.WriteElementType(type.IsValueType ? global::Mono.Cecil.Metadata.ElementType.ValueType : global::Mono.Cecil.Metadata.ElementType.Class);
					base.WriteCompressedUInt32(this.MakeTypeDefOrRefCodedRID(type));
					return;
				}
				switch (elementType)
				{
				case global::Mono.Cecil.Metadata.ElementType.Ptr:
				case global::Mono.Cecil.Metadata.ElementType.ByRef:
					goto IL_E3;
				case global::Mono.Cecil.Metadata.ElementType.ValueType:
				case global::Mono.Cecil.Metadata.ElementType.Class:
					goto IL_17D;
				case global::Mono.Cecil.Metadata.ElementType.Var:
					break;
				case global::Mono.Cecil.Metadata.ElementType.Array:
				{
					global::Mono.Cecil.ArrayType arrayType = (global::Mono.Cecil.ArrayType)type;
					if (!arrayType.IsVector)
					{
						this.WriteArrayTypeSignature(arrayType);
						return;
					}
					this.WriteElementType(global::Mono.Cecil.Metadata.ElementType.SzArray);
					this.WriteTypeSignature(arrayType.ElementType);
					return;
				}
				case global::Mono.Cecil.Metadata.ElementType.GenericInst:
				{
					global::Mono.Cecil.GenericInstanceType genericInstanceType = (global::Mono.Cecil.GenericInstanceType)type;
					this.WriteElementType(global::Mono.Cecil.Metadata.ElementType.GenericInst);
					this.WriteElementType(genericInstanceType.IsValueType ? global::Mono.Cecil.Metadata.ElementType.ValueType : global::Mono.Cecil.Metadata.ElementType.Class);
					base.WriteCompressedUInt32(this.MakeTypeDefOrRefCodedRID(genericInstanceType.ElementType));
					this.WriteGenericInstanceSignature(genericInstanceType);
					return;
				}
				default:
					goto IL_17D;
				}
			}
			else
			{
				switch (elementType)
				{
				case global::Mono.Cecil.Metadata.ElementType.FnPtr:
				{
					global::Mono.Cecil.FunctionPointerType method = (global::Mono.Cecil.FunctionPointerType)type;
					this.WriteElementType(global::Mono.Cecil.Metadata.ElementType.FnPtr);
					this.WriteMethodSignature(method);
					return;
				}
				case global::Mono.Cecil.Metadata.ElementType.Object:
				case global::Mono.Cecil.Metadata.ElementType.SzArray:
					goto IL_17D;
				case global::Mono.Cecil.Metadata.ElementType.MVar:
					break;
				case global::Mono.Cecil.Metadata.ElementType.CModReqD:
				case global::Mono.Cecil.Metadata.ElementType.CModOpt:
				{
					global::Mono.Cecil.IModifierType type2 = (global::Mono.Cecil.IModifierType)type;
					this.WriteModifierSignature(etype, type2);
					return;
				}
				default:
					if (elementType != global::Mono.Cecil.Metadata.ElementType.Sentinel && elementType != global::Mono.Cecil.Metadata.ElementType.Pinned)
					{
						goto IL_17D;
					}
					goto IL_E3;
				}
			}
			global::Mono.Cecil.GenericParameter genericParameter = (global::Mono.Cecil.GenericParameter)type;
			this.WriteElementType(etype);
			int position = genericParameter.Position;
			if (position == -1)
			{
				throw new global::System.NotSupportedException();
			}
			base.WriteCompressedUInt32((uint)position);
			return;
			IL_E3:
			global::Mono.Cecil.TypeSpecification typeSpecification = (global::Mono.Cecil.TypeSpecification)type;
			this.WriteElementType(etype);
			this.WriteTypeSignature(typeSpecification.ElementType);
			return;
			IL_17D:
			if (!this.TryWriteElementType(type))
			{
				throw new global::System.NotSupportedException();
			}
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x000191F8 File Offset: 0x000173F8
		private void WriteArrayTypeSignature(global::Mono.Cecil.ArrayType array)
		{
			this.WriteElementType(global::Mono.Cecil.Metadata.ElementType.Array);
			this.WriteTypeSignature(array.ElementType);
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ArrayDimension> dimensions = array.Dimensions;
			int count = dimensions.Count;
			base.WriteCompressedUInt32((uint)count);
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < count; i++)
			{
				global::Mono.Cecil.ArrayDimension arrayDimension = dimensions[i];
				if (arrayDimension.UpperBound != null)
				{
					num++;
					num2++;
				}
				else if (arrayDimension.LowerBound != null)
				{
					num2++;
				}
			}
			int[] array2 = new int[num];
			int[] array3 = new int[num2];
			for (int j = 0; j < num2; j++)
			{
				global::Mono.Cecil.ArrayDimension arrayDimension2 = dimensions[j];
				array3[j] = arrayDimension2.LowerBound.GetValueOrDefault();
				if (arrayDimension2.UpperBound != null)
				{
					array2[j] = arrayDimension2.UpperBound.Value - array3[j] + 1;
				}
			}
			base.WriteCompressedUInt32((uint)num);
			for (int k = 0; k < num; k++)
			{
				base.WriteCompressedUInt32((uint)array2[k]);
			}
			base.WriteCompressedUInt32((uint)num2);
			for (int l = 0; l < num2; l++)
			{
				base.WriteCompressedInt32(array3[l]);
			}
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x00019330 File Offset: 0x00017530
		public void WriteGenericInstanceSignature(global::Mono.Cecil.IGenericInstance instance)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> genericArguments = instance.GenericArguments;
			int count = genericArguments.Count;
			base.WriteCompressedUInt32((uint)count);
			for (int i = 0; i < count; i++)
			{
				this.WriteTypeSignature(genericArguments[i]);
			}
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x0001936B File Offset: 0x0001756B
		private void WriteModifierSignature(global::Mono.Cecil.Metadata.ElementType element_type, global::Mono.Cecil.IModifierType type)
		{
			this.WriteElementType(element_type);
			base.WriteCompressedUInt32(this.MakeTypeDefOrRefCodedRID(type.ModifierType));
			this.WriteTypeSignature(type.ElementType);
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x00019394 File Offset: 0x00017594
		private bool TryWriteElementType(global::Mono.Cecil.TypeReference type)
		{
			global::Mono.Cecil.Metadata.ElementType etype = type.etype;
			if (etype == global::Mono.Cecil.Metadata.ElementType.None)
			{
				return false;
			}
			this.WriteElementType(etype);
			return true;
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x000193B5 File Offset: 0x000175B5
		public void WriteConstantString(string value)
		{
			base.WriteBytes(global::System.Text.Encoding.Unicode.GetBytes(value));
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x000193C8 File Offset: 0x000175C8
		public void WriteConstantPrimitive(object value)
		{
			this.WritePrimitiveValue(value);
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x000193D4 File Offset: 0x000175D4
		public void WriteCustomAttributeConstructorArguments(global::Mono.Cecil.CustomAttribute attribute)
		{
			if (!attribute.HasConstructorArguments)
			{
				return;
			}
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeArgument> constructorArguments = attribute.ConstructorArguments;
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition> parameters = attribute.Constructor.Parameters;
			if (parameters.Count != constructorArguments.Count)
			{
				throw new global::System.InvalidOperationException();
			}
			for (int i = 0; i < constructorArguments.Count; i++)
			{
				this.WriteCustomAttributeFixedArgument(parameters[i].ParameterType, constructorArguments[i]);
			}
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x0001943B File Offset: 0x0001763B
		private void WriteCustomAttributeFixedArgument(global::Mono.Cecil.TypeReference type, global::Mono.Cecil.CustomAttributeArgument argument)
		{
			if (type.IsArray)
			{
				this.WriteCustomAttributeFixedArrayArgument((global::Mono.Cecil.ArrayType)type, argument);
				return;
			}
			this.WriteCustomAttributeElement(type, argument);
		}

		// Token: 0x060008D9 RID: 2265 RVA: 0x0001945C File Offset: 0x0001765C
		private void WriteCustomAttributeFixedArrayArgument(global::Mono.Cecil.ArrayType type, global::Mono.Cecil.CustomAttributeArgument argument)
		{
			global::Mono.Cecil.CustomAttributeArgument[] array = argument.Value as global::Mono.Cecil.CustomAttributeArgument[];
			if (array == null)
			{
				base.WriteUInt32(uint.MaxValue);
				return;
			}
			base.WriteInt32(array.Length);
			if (array.Length == 0)
			{
				return;
			}
			global::Mono.Cecil.TypeReference elementType = type.ElementType;
			for (int i = 0; i < array.Length; i++)
			{
				this.WriteCustomAttributeElement(elementType, array[i]);
			}
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x000194B8 File Offset: 0x000176B8
		private void WriteCustomAttributeElement(global::Mono.Cecil.TypeReference type, global::Mono.Cecil.CustomAttributeArgument argument)
		{
			if (type.IsArray)
			{
				this.WriteCustomAttributeFixedArrayArgument((global::Mono.Cecil.ArrayType)type, argument);
				return;
			}
			if (type.etype == global::Mono.Cecil.Metadata.ElementType.Object)
			{
				argument = (global::Mono.Cecil.CustomAttributeArgument)argument.Value;
				type = argument.Type;
				this.WriteCustomAttributeFieldOrPropType(type);
				this.WriteCustomAttributeElement(type, argument);
				return;
			}
			this.WriteCustomAttributeValue(type, argument.Value);
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x0001951C File Offset: 0x0001771C
		private void WriteCustomAttributeValue(global::Mono.Cecil.TypeReference type, object value)
		{
			global::Mono.Cecil.Metadata.ElementType etype = type.etype;
			global::Mono.Cecil.Metadata.ElementType elementType = etype;
			if (elementType != global::Mono.Cecil.Metadata.ElementType.None)
			{
				if (elementType != global::Mono.Cecil.Metadata.ElementType.String)
				{
					this.WritePrimitiveValue(value);
					return;
				}
				string text = (string)value;
				if (text == null)
				{
					base.WriteByte(byte.MaxValue);
					return;
				}
				this.WriteUTF8String(text);
				return;
			}
			else
			{
				if (type.IsTypeOf("System", "Type"))
				{
					this.WriteTypeReference((global::Mono.Cecil.TypeReference)value);
					return;
				}
				this.WriteCustomAttributeEnumValue(type, value);
				return;
			}
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x00019588 File Offset: 0x00017788
		private void WritePrimitiveValue(object value)
		{
			if (value == null)
			{
				throw new global::System.ArgumentNullException();
			}
			switch (global::System.Type.GetTypeCode(value.GetType()))
			{
			case global::System.TypeCode.Boolean:
				base.WriteByte(((bool)value) ? 1 : 0);
				return;
			case global::System.TypeCode.Char:
				base.WriteInt16((short)((char)value));
				return;
			case global::System.TypeCode.SByte:
				base.WriteSByte((sbyte)value);
				return;
			case global::System.TypeCode.Byte:
				base.WriteByte((byte)value);
				return;
			case global::System.TypeCode.Int16:
				base.WriteInt16((short)value);
				return;
			case global::System.TypeCode.UInt16:
				base.WriteUInt16((ushort)value);
				return;
			case global::System.TypeCode.Int32:
				base.WriteInt32((int)value);
				return;
			case global::System.TypeCode.UInt32:
				base.WriteUInt32((uint)value);
				return;
			case global::System.TypeCode.Int64:
				base.WriteInt64((long)value);
				return;
			case global::System.TypeCode.UInt64:
				base.WriteUInt64((ulong)value);
				return;
			case global::System.TypeCode.Single:
				base.WriteSingle((float)value);
				return;
			case global::System.TypeCode.Double:
				base.WriteDouble((double)value);
				return;
			default:
				throw new global::System.NotSupportedException(value.GetType().FullName);
			}
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x0001969C File Offset: 0x0001789C
		private void WriteCustomAttributeEnumValue(global::Mono.Cecil.TypeReference enum_type, object value)
		{
			global::Mono.Cecil.TypeDefinition typeDefinition = enum_type.CheckedResolve();
			if (!typeDefinition.IsEnum)
			{
				throw new global::System.ArgumentException();
			}
			this.WriteCustomAttributeValue(typeDefinition.GetEnumUnderlyingType(), value);
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x000196CC File Offset: 0x000178CC
		private void WriteCustomAttributeFieldOrPropType(global::Mono.Cecil.TypeReference type)
		{
			if (type.IsArray)
			{
				global::Mono.Cecil.ArrayType arrayType = (global::Mono.Cecil.ArrayType)type;
				this.WriteElementType(global::Mono.Cecil.Metadata.ElementType.SzArray);
				this.WriteCustomAttributeFieldOrPropType(arrayType.ElementType);
				return;
			}
			global::Mono.Cecil.Metadata.ElementType etype = type.etype;
			global::Mono.Cecil.Metadata.ElementType elementType = etype;
			if (elementType != global::Mono.Cecil.Metadata.ElementType.None)
			{
				if (elementType == global::Mono.Cecil.Metadata.ElementType.Object)
				{
					this.WriteElementType(global::Mono.Cecil.Metadata.ElementType.Boxed);
					return;
				}
				this.WriteElementType(etype);
				return;
			}
			else
			{
				if (type.IsTypeOf("System", "Type"))
				{
					this.WriteElementType(global::Mono.Cecil.Metadata.ElementType.Type);
					return;
				}
				this.WriteElementType(global::Mono.Cecil.Metadata.ElementType.Enum);
				this.WriteTypeReference(type);
				return;
			}
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x0001974C File Offset: 0x0001794C
		public void WriteCustomAttributeNamedArguments(global::Mono.Cecil.CustomAttribute attribute)
		{
			int namedArgumentCount = global::Mono.Cecil.SignatureWriter.GetNamedArgumentCount(attribute);
			base.WriteUInt16((ushort)namedArgumentCount);
			if (namedArgumentCount == 0)
			{
				return;
			}
			this.WriteICustomAttributeNamedArguments(attribute);
		}

		// Token: 0x060008E0 RID: 2272 RVA: 0x00019774 File Offset: 0x00017974
		private static int GetNamedArgumentCount(global::Mono.Cecil.ICustomAttribute attribute)
		{
			int num = 0;
			if (attribute.HasFields)
			{
				num += attribute.Fields.Count;
			}
			if (attribute.HasProperties)
			{
				num += attribute.Properties.Count;
			}
			return num;
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x000197B0 File Offset: 0x000179B0
		private void WriteICustomAttributeNamedArguments(global::Mono.Cecil.ICustomAttribute attribute)
		{
			if (attribute.HasFields)
			{
				this.WriteCustomAttributeNamedArguments(0x53, attribute.Fields);
			}
			if (attribute.HasProperties)
			{
				this.WriteCustomAttributeNamedArguments(0x54, attribute.Properties);
			}
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x000197E0 File Offset: 0x000179E0
		private void WriteCustomAttributeNamedArguments(byte kind, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument> named_arguments)
		{
			for (int i = 0; i < named_arguments.Count; i++)
			{
				this.WriteCustomAttributeNamedArgument(kind, named_arguments[i]);
			}
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x0001980C File Offset: 0x00017A0C
		private void WriteCustomAttributeNamedArgument(byte kind, global::Mono.Cecil.CustomAttributeNamedArgument named_argument)
		{
			global::Mono.Cecil.CustomAttributeArgument argument = named_argument.Argument;
			base.WriteByte(kind);
			this.WriteCustomAttributeFieldOrPropType(argument.Type);
			this.WriteUTF8String(named_argument.Name);
			this.WriteCustomAttributeFixedArgument(argument.Type, argument);
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x00019850 File Offset: 0x00017A50
		private void WriteSecurityAttribute(global::Mono.Cecil.SecurityAttribute attribute)
		{
			this.WriteTypeReference(attribute.AttributeType);
			int namedArgumentCount = global::Mono.Cecil.SignatureWriter.GetNamedArgumentCount(attribute);
			if (namedArgumentCount == 0)
			{
				base.WriteCompressedUInt32(0U);
				base.WriteCompressedUInt32(0U);
				return;
			}
			global::Mono.Cecil.SignatureWriter signatureWriter = new global::Mono.Cecil.SignatureWriter(this.metadata);
			signatureWriter.WriteCompressedUInt32((uint)namedArgumentCount);
			signatureWriter.WriteICustomAttributeNamedArguments(attribute);
			base.WriteCompressedUInt32((uint)signatureWriter.length);
			base.WriteBytes(signatureWriter);
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x000198B0 File Offset: 0x00017AB0
		public void WriteSecurityDeclaration(global::Mono.Cecil.SecurityDeclaration declaration)
		{
			base.WriteByte(0x2E);
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityAttribute> security_attributes = declaration.security_attributes;
			if (security_attributes == null)
			{
				throw new global::System.NotSupportedException();
			}
			base.WriteCompressedUInt32((uint)security_attributes.Count);
			for (int i = 0; i < security_attributes.Count; i++)
			{
				this.WriteSecurityAttribute(security_attributes[i]);
			}
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x00019900 File Offset: 0x00017B00
		public void WriteXmlSecurityDeclaration(global::Mono.Cecil.SecurityDeclaration declaration)
		{
			string xmlSecurityDeclaration = global::Mono.Cecil.SignatureWriter.GetXmlSecurityDeclaration(declaration);
			if (xmlSecurityDeclaration == null)
			{
				throw new global::System.NotSupportedException();
			}
			base.WriteBytes(global::System.Text.Encoding.Unicode.GetBytes(xmlSecurityDeclaration));
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x00019930 File Offset: 0x00017B30
		private static string GetXmlSecurityDeclaration(global::Mono.Cecil.SecurityDeclaration declaration)
		{
			if (declaration.security_attributes == null || declaration.security_attributes.Count != 1)
			{
				return null;
			}
			global::Mono.Cecil.SecurityAttribute securityAttribute = declaration.security_attributes[0];
			if (!securityAttribute.AttributeType.IsTypeOf("System.Security.Permissions", "PermissionSetAttribute"))
			{
				return null;
			}
			if (securityAttribute.properties == null || securityAttribute.properties.Count != 1)
			{
				return null;
			}
			global::Mono.Cecil.CustomAttributeNamedArgument customAttributeNamedArgument = securityAttribute.properties[0];
			if (customAttributeNamedArgument.Name != "XML")
			{
				return null;
			}
			return (string)customAttributeNamedArgument.Argument.Value;
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x000199C9 File Offset: 0x00017BC9
		private void WriteTypeReference(global::Mono.Cecil.TypeReference type)
		{
			this.WriteUTF8String(global::Mono.Cecil.TypeParser.ToParseable(type));
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x000199D8 File Offset: 0x00017BD8
		public void WriteMarshalInfo(global::Mono.Cecil.MarshalInfo marshal_info)
		{
			this.WriteNativeType(marshal_info.native);
			global::Mono.Cecil.NativeType native = marshal_info.native;
			if (native == global::Mono.Cecil.NativeType.FixedSysString)
			{
				global::Mono.Cecil.FixedSysStringMarshalInfo fixedSysStringMarshalInfo = (global::Mono.Cecil.FixedSysStringMarshalInfo)marshal_info;
				if (fixedSysStringMarshalInfo.size > -1)
				{
					base.WriteCompressedUInt32((uint)fixedSysStringMarshalInfo.size);
				}
				return;
			}
			switch (native)
			{
			case global::Mono.Cecil.NativeType.SafeArray:
			{
				global::Mono.Cecil.SafeArrayMarshalInfo safeArrayMarshalInfo = (global::Mono.Cecil.SafeArrayMarshalInfo)marshal_info;
				if (safeArrayMarshalInfo.element_type != global::Mono.Cecil.VariantType.None)
				{
					this.WriteVariantType(safeArrayMarshalInfo.element_type);
				}
				return;
			}
			case global::Mono.Cecil.NativeType.FixedArray:
			{
				global::Mono.Cecil.FixedArrayMarshalInfo fixedArrayMarshalInfo = (global::Mono.Cecil.FixedArrayMarshalInfo)marshal_info;
				if (fixedArrayMarshalInfo.size > -1)
				{
					base.WriteCompressedUInt32((uint)fixedArrayMarshalInfo.size);
				}
				if (fixedArrayMarshalInfo.element_type != global::Mono.Cecil.NativeType.None)
				{
					this.WriteNativeType(fixedArrayMarshalInfo.element_type);
				}
				return;
			}
			default:
				switch (native)
				{
				case global::Mono.Cecil.NativeType.Array:
				{
					global::Mono.Cecil.ArrayMarshalInfo arrayMarshalInfo = (global::Mono.Cecil.ArrayMarshalInfo)marshal_info;
					if (arrayMarshalInfo.element_type != global::Mono.Cecil.NativeType.None)
					{
						this.WriteNativeType(arrayMarshalInfo.element_type);
					}
					if (arrayMarshalInfo.size_parameter_index > -1)
					{
						base.WriteCompressedUInt32((uint)arrayMarshalInfo.size_parameter_index);
					}
					if (arrayMarshalInfo.size > -1)
					{
						base.WriteCompressedUInt32((uint)arrayMarshalInfo.size);
					}
					if (arrayMarshalInfo.size_parameter_multiplier > -1)
					{
						base.WriteCompressedUInt32((uint)arrayMarshalInfo.size_parameter_multiplier);
					}
					return;
				}
				case global::Mono.Cecil.NativeType.LPStruct:
					break;
				case global::Mono.Cecil.NativeType.CustomMarshaler:
				{
					global::Mono.Cecil.CustomMarshalInfo customMarshalInfo = (global::Mono.Cecil.CustomMarshalInfo)marshal_info;
					this.WriteUTF8String((customMarshalInfo.guid != global::System.Guid.Empty) ? customMarshalInfo.guid.ToString() : string.Empty);
					this.WriteUTF8String(customMarshalInfo.unmanaged_type);
					this.WriteTypeReference(customMarshalInfo.managed_type);
					this.WriteUTF8String(customMarshalInfo.cookie);
					break;
				}
				default:
					return;
				}
				return;
			}
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x00019B55 File Offset: 0x00017D55
		private void WriteNativeType(global::Mono.Cecil.NativeType native)
		{
			base.WriteByte((byte)native);
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x00019B5F File Offset: 0x00017D5F
		private void WriteVariantType(global::Mono.Cecil.VariantType variant)
		{
			base.WriteByte((byte)variant);
		}

		// Token: 0x0400060A RID: 1546
		private readonly global::Mono.Cecil.MetadataBuilder metadata;
	}
}
