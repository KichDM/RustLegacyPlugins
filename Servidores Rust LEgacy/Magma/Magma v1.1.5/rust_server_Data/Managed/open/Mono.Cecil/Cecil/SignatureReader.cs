using System;
using System.Text;
using Mono.Cecil.Metadata;
using Mono.Cecil.PE;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x020000F5 RID: 245
	internal sealed class SignatureReader : global::Mono.Cecil.PE.ByteBuffer
	{
		// Token: 0x170002BD RID: 701
		// (get) Token: 0x060009A1 RID: 2465 RVA: 0x0001D23C File Offset: 0x0001B43C
		private global::Mono.Cecil.TypeSystem TypeSystem
		{
			get
			{
				return this.reader.module.TypeSystem;
			}
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x0001D24E File Offset: 0x0001B44E
		public SignatureReader(uint blob, global::Mono.Cecil.MetadataReader reader) : base(reader.buffer)
		{
			this.reader = reader;
			this.MoveToBlob(blob);
			this.sig_length = base.ReadCompressedUInt32();
			this.start = (uint)this.position;
		}

		// Token: 0x060009A3 RID: 2467 RVA: 0x0001D282 File Offset: 0x0001B482
		private void MoveToBlob(uint blob)
		{
			this.position = (int)(this.reader.image.BlobHeap.Offset + blob);
		}

		// Token: 0x060009A4 RID: 2468 RVA: 0x0001D2A1 File Offset: 0x0001B4A1
		private global::Mono.Cecil.MetadataToken ReadTypeTokenSignature()
		{
			return global::Mono.Cecil.Metadata.CodedIndex.TypeDefOrRef.GetMetadataToken(base.ReadCompressedUInt32());
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x0001D2B0 File Offset: 0x0001B4B0
		private global::Mono.Cecil.GenericParameter GetGenericParameter(global::Mono.Cecil.GenericParameterType type, uint var)
		{
			global::Mono.Cecil.IGenericContext context = this.reader.context;
			if (context == null)
			{
				throw new global::System.NotSupportedException();
			}
			global::Mono.Cecil.IGenericParameterProvider genericParameterProvider;
			switch (type)
			{
			case global::Mono.Cecil.GenericParameterType.Type:
				genericParameterProvider = context.Type;
				break;
			case global::Mono.Cecil.GenericParameterType.Method:
				genericParameterProvider = context.Method;
				break;
			default:
				throw new global::System.NotSupportedException();
			}
			if (!context.IsDefinition)
			{
				global::Mono.Cecil.SignatureReader.CheckGenericContext(genericParameterProvider, (int)var);
			}
			return genericParameterProvider.GenericParameters[(int)var];
		}

		// Token: 0x060009A6 RID: 2470 RVA: 0x0001D31C File Offset: 0x0001B51C
		private static void CheckGenericContext(global::Mono.Cecil.IGenericParameterProvider owner, int index)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.GenericParameter> genericParameters = owner.GenericParameters;
			for (int i = genericParameters.Count; i <= index; i++)
			{
				genericParameters.Add(new global::Mono.Cecil.GenericParameter(owner));
			}
		}

		// Token: 0x060009A7 RID: 2471 RVA: 0x0001D350 File Offset: 0x0001B550
		public void ReadGenericInstanceSignature(global::Mono.Cecil.IGenericParameterProvider provider, global::Mono.Cecil.IGenericInstance instance)
		{
			uint num = base.ReadCompressedUInt32();
			if (!provider.IsDefinition)
			{
				global::Mono.Cecil.SignatureReader.CheckGenericContext(provider, (int)(num - 1U));
			}
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> genericArguments = instance.GenericArguments;
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				genericArguments.Add(this.ReadTypeSignature());
				num2++;
			}
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x0001D398 File Offset: 0x0001B598
		private global::Mono.Cecil.ArrayType ReadArrayTypeSignature()
		{
			global::Mono.Cecil.ArrayType arrayType = new global::Mono.Cecil.ArrayType(this.ReadTypeSignature());
			uint num = base.ReadCompressedUInt32();
			uint[] array = new uint[base.ReadCompressedUInt32()];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = base.ReadCompressedUInt32();
			}
			int[] array2 = new int[base.ReadCompressedUInt32()];
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = base.ReadCompressedInt32();
			}
			arrayType.Dimensions.Clear();
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				int? num3 = null;
				int? upperBound = null;
				if (num2 < array2.Length)
				{
					num3 = new int?(array2[num2]);
				}
				if (num2 < array.Length)
				{
					upperBound = num3 + (int)array[num2] - 1;
				}
				arrayType.Dimensions.Add(new global::Mono.Cecil.ArrayDimension(num3, upperBound));
				num2++;
			}
			return arrayType;
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x0001D4C0 File Offset: 0x0001B6C0
		private global::Mono.Cecil.TypeReference GetTypeDefOrRef(global::Mono.Cecil.MetadataToken token)
		{
			return this.reader.GetTypeDefOrRef(token);
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x0001D4CE File Offset: 0x0001B6CE
		public global::Mono.Cecil.TypeReference ReadTypeSignature()
		{
			return this.ReadTypeSignature((global::Mono.Cecil.Metadata.ElementType)base.ReadByte());
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x0001D4DC File Offset: 0x0001B6DC
		private global::Mono.Cecil.TypeReference ReadTypeSignature(global::Mono.Cecil.Metadata.ElementType etype)
		{
			switch (etype)
			{
			case global::Mono.Cecil.Metadata.ElementType.Void:
				return this.TypeSystem.Void;
			case global::Mono.Cecil.Metadata.ElementType.Boolean:
			case global::Mono.Cecil.Metadata.ElementType.Char:
			case global::Mono.Cecil.Metadata.ElementType.I1:
			case global::Mono.Cecil.Metadata.ElementType.U1:
			case global::Mono.Cecil.Metadata.ElementType.I2:
			case global::Mono.Cecil.Metadata.ElementType.U2:
			case global::Mono.Cecil.Metadata.ElementType.I4:
			case global::Mono.Cecil.Metadata.ElementType.U4:
			case global::Mono.Cecil.Metadata.ElementType.I8:
			case global::Mono.Cecil.Metadata.ElementType.U8:
			case global::Mono.Cecil.Metadata.ElementType.R4:
			case global::Mono.Cecil.Metadata.ElementType.R8:
			case global::Mono.Cecil.Metadata.ElementType.String:
			case (global::Mono.Cecil.Metadata.ElementType)0x17:
			case (global::Mono.Cecil.Metadata.ElementType)0x1A:
				break;
			case global::Mono.Cecil.Metadata.ElementType.Ptr:
				return new global::Mono.Cecil.PointerType(this.ReadTypeSignature());
			case global::Mono.Cecil.Metadata.ElementType.ByRef:
				return new global::Mono.Cecil.ByReferenceType(this.ReadTypeSignature());
			case global::Mono.Cecil.Metadata.ElementType.ValueType:
			{
				global::Mono.Cecil.TypeReference typeDefOrRef = this.GetTypeDefOrRef(this.ReadTypeTokenSignature());
				typeDefOrRef.IsValueType = true;
				return typeDefOrRef;
			}
			case global::Mono.Cecil.Metadata.ElementType.Class:
				return this.GetTypeDefOrRef(this.ReadTypeTokenSignature());
			case global::Mono.Cecil.Metadata.ElementType.Var:
				return this.GetGenericParameter(global::Mono.Cecil.GenericParameterType.Type, base.ReadCompressedUInt32());
			case global::Mono.Cecil.Metadata.ElementType.Array:
				return this.ReadArrayTypeSignature();
			case global::Mono.Cecil.Metadata.ElementType.GenericInst:
			{
				bool flag = base.ReadByte() == 0x11;
				global::Mono.Cecil.TypeReference typeDefOrRef2 = this.GetTypeDefOrRef(this.ReadTypeTokenSignature());
				global::Mono.Cecil.GenericInstanceType genericInstanceType = new global::Mono.Cecil.GenericInstanceType(typeDefOrRef2);
				this.ReadGenericInstanceSignature(typeDefOrRef2, genericInstanceType);
				if (flag)
				{
					genericInstanceType.IsValueType = true;
					typeDefOrRef2.GetElementType().IsValueType = true;
				}
				return genericInstanceType;
			}
			case global::Mono.Cecil.Metadata.ElementType.TypedByRef:
				return this.TypeSystem.TypedReference;
			case global::Mono.Cecil.Metadata.ElementType.I:
				return this.TypeSystem.IntPtr;
			case global::Mono.Cecil.Metadata.ElementType.U:
				return this.TypeSystem.UIntPtr;
			case global::Mono.Cecil.Metadata.ElementType.FnPtr:
			{
				global::Mono.Cecil.FunctionPointerType functionPointerType = new global::Mono.Cecil.FunctionPointerType();
				this.ReadMethodSignature(functionPointerType);
				return functionPointerType;
			}
			case global::Mono.Cecil.Metadata.ElementType.Object:
				return this.TypeSystem.Object;
			case global::Mono.Cecil.Metadata.ElementType.SzArray:
				return new global::Mono.Cecil.ArrayType(this.ReadTypeSignature());
			case global::Mono.Cecil.Metadata.ElementType.MVar:
				return this.GetGenericParameter(global::Mono.Cecil.GenericParameterType.Method, base.ReadCompressedUInt32());
			case global::Mono.Cecil.Metadata.ElementType.CModReqD:
				return new global::Mono.Cecil.RequiredModifierType(this.GetTypeDefOrRef(this.ReadTypeTokenSignature()), this.ReadTypeSignature());
			case global::Mono.Cecil.Metadata.ElementType.CModOpt:
				return new global::Mono.Cecil.OptionalModifierType(this.GetTypeDefOrRef(this.ReadTypeTokenSignature()), this.ReadTypeSignature());
			default:
				if (etype == global::Mono.Cecil.Metadata.ElementType.Sentinel)
				{
					return new global::Mono.Cecil.SentinelType(this.ReadTypeSignature());
				}
				if (etype == global::Mono.Cecil.Metadata.ElementType.Pinned)
				{
					return new global::Mono.Cecil.PinnedType(this.ReadTypeSignature());
				}
				break;
			}
			return this.GetPrimitiveType(etype);
		}

		// Token: 0x060009AC RID: 2476 RVA: 0x0001D6D0 File Offset: 0x0001B8D0
		public void ReadMethodSignature(global::Mono.Cecil.IMethodSignature method)
		{
			byte b = base.ReadByte();
			if ((b & 0x20) != 0)
			{
				method.HasThis = true;
				b = (byte)((int)b & -0x21);
			}
			if ((b & 0x40) != 0)
			{
				method.ExplicitThis = true;
				b = (byte)((int)b & -0x41);
			}
			method.CallingConvention = (global::Mono.Cecil.MethodCallingConvention)b;
			global::Mono.Cecil.MethodReference methodReference = method as global::Mono.Cecil.MethodReference;
			if (methodReference != null)
			{
				this.reader.context = methodReference;
			}
			if ((b & 0x10) != 0)
			{
				uint num = base.ReadCompressedUInt32();
				if (methodReference != null && !methodReference.IsDefinition)
				{
					global::Mono.Cecil.SignatureReader.CheckGenericContext(methodReference, (int)(num - 1U));
				}
			}
			uint num2 = base.ReadCompressedUInt32();
			method.MethodReturnType.ReturnType = this.ReadTypeSignature();
			if (num2 == 0U)
			{
				return;
			}
			global::Mono.Cecil.MethodReference methodReference2 = method as global::Mono.Cecil.MethodReference;
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition> collection;
			if (methodReference2 != null)
			{
				collection = (methodReference2.parameters = new global::Mono.Cecil.ParameterDefinitionCollection(method, (int)num2));
			}
			else
			{
				collection = method.Parameters;
			}
			int num3 = 0;
			while ((long)num3 < (long)((ulong)num2))
			{
				collection.Add(new global::Mono.Cecil.ParameterDefinition(this.ReadTypeSignature()));
				num3++;
			}
		}

		// Token: 0x060009AD RID: 2477 RVA: 0x0001D7B3 File Offset: 0x0001B9B3
		public object ReadConstantSignature(global::Mono.Cecil.Metadata.ElementType type)
		{
			return this.ReadPrimitiveValue(type);
		}

		// Token: 0x060009AE RID: 2478 RVA: 0x0001D7BC File Offset: 0x0001B9BC
		public void ReadCustomAttributeConstructorArguments(global::Mono.Cecil.CustomAttribute attribute, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition> parameters)
		{
			int count = parameters.Count;
			if (count == 0)
			{
				return;
			}
			attribute.arguments = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeArgument>(count);
			for (int i = 0; i < count; i++)
			{
				attribute.arguments.Add(this.ReadCustomAttributeFixedArgument(parameters[i].ParameterType));
			}
		}

		// Token: 0x060009AF RID: 2479 RVA: 0x0001D809 File Offset: 0x0001BA09
		private global::Mono.Cecil.CustomAttributeArgument ReadCustomAttributeFixedArgument(global::Mono.Cecil.TypeReference type)
		{
			if (type.IsArray)
			{
				return this.ReadCustomAttributeFixedArrayArgument((global::Mono.Cecil.ArrayType)type);
			}
			return this.ReadCustomAttributeElement(type);
		}

		// Token: 0x060009B0 RID: 2480 RVA: 0x0001D828 File Offset: 0x0001BA28
		public void ReadCustomAttributeNamedArguments(ushort count, ref global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument> fields, ref global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument> properties)
		{
			for (int i = 0; i < (int)count; i++)
			{
				this.ReadCustomAttributeNamedArgument(ref fields, ref properties);
			}
		}

		// Token: 0x060009B1 RID: 2481 RVA: 0x0001D84C File Offset: 0x0001BA4C
		private void ReadCustomAttributeNamedArgument(ref global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument> fields, ref global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument> properties)
		{
			byte b = base.ReadByte();
			global::Mono.Cecil.TypeReference type = this.ReadCustomAttributeFieldOrPropType();
			string name = this.ReadUTF8String();
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument> customAttributeNamedArgumentCollection;
			switch (b)
			{
			case 0x53:
				customAttributeNamedArgumentCollection = global::Mono.Cecil.SignatureReader.GetCustomAttributeNamedArgumentCollection(ref fields);
				break;
			case 0x54:
				customAttributeNamedArgumentCollection = global::Mono.Cecil.SignatureReader.GetCustomAttributeNamedArgumentCollection(ref properties);
				break;
			default:
				throw new global::System.NotSupportedException();
			}
			customAttributeNamedArgumentCollection.Add(new global::Mono.Cecil.CustomAttributeNamedArgument(name, this.ReadCustomAttributeFixedArgument(type)));
		}

		// Token: 0x060009B2 RID: 2482 RVA: 0x0001D8B0 File Offset: 0x0001BAB0
		private static global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument> GetCustomAttributeNamedArgumentCollection(ref global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument> collection)
		{
			if (collection != null)
			{
				return collection;
			}
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument> result;
			collection = (result = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument>());
			return result;
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x0001D8D0 File Offset: 0x0001BAD0
		private global::Mono.Cecil.CustomAttributeArgument ReadCustomAttributeFixedArrayArgument(global::Mono.Cecil.ArrayType type)
		{
			uint num = base.ReadUInt32();
			if (num == 0xFFFFFFFFU)
			{
				return new global::Mono.Cecil.CustomAttributeArgument(type, null);
			}
			if (num == 0U)
			{
				return new global::Mono.Cecil.CustomAttributeArgument(type, global::Mono.Empty<global::Mono.Cecil.CustomAttributeArgument>.Array);
			}
			global::Mono.Cecil.CustomAttributeArgument[] array = new global::Mono.Cecil.CustomAttributeArgument[num];
			global::Mono.Cecil.TypeReference elementType = type.ElementType;
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				array[num2] = this.ReadCustomAttributeElement(elementType);
				num2++;
			}
			return new global::Mono.Cecil.CustomAttributeArgument(type, array);
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x0001D938 File Offset: 0x0001BB38
		private global::Mono.Cecil.CustomAttributeArgument ReadCustomAttributeElement(global::Mono.Cecil.TypeReference type)
		{
			if (type.IsArray)
			{
				return this.ReadCustomAttributeFixedArrayArgument((global::Mono.Cecil.ArrayType)type);
			}
			return new global::Mono.Cecil.CustomAttributeArgument(type, (type.etype == global::Mono.Cecil.Metadata.ElementType.Object) ? this.ReadCustomAttributeElement(this.ReadCustomAttributeFieldOrPropType()) : this.ReadCustomAttributeElementValue(type));
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x0001D984 File Offset: 0x0001BB84
		private object ReadCustomAttributeElementValue(global::Mono.Cecil.TypeReference type)
		{
			global::Mono.Cecil.Metadata.ElementType etype = type.etype;
			global::Mono.Cecil.Metadata.ElementType elementType = etype;
			if (elementType != global::Mono.Cecil.Metadata.ElementType.None)
			{
				if (elementType == global::Mono.Cecil.Metadata.ElementType.String)
				{
					return this.ReadUTF8String();
				}
				return this.ReadPrimitiveValue(etype);
			}
			else
			{
				if (type.IsTypeOf("System", "Type"))
				{
					return this.ReadTypeReference();
				}
				return this.ReadCustomAttributeEnum(type);
			}
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x0001D9D4 File Offset: 0x0001BBD4
		private object ReadPrimitiveValue(global::Mono.Cecil.Metadata.ElementType type)
		{
			switch (type)
			{
			case global::Mono.Cecil.Metadata.ElementType.Boolean:
				return base.ReadByte() == 1;
			case global::Mono.Cecil.Metadata.ElementType.Char:
				return (char)base.ReadUInt16();
			case global::Mono.Cecil.Metadata.ElementType.I1:
				return (sbyte)base.ReadByte();
			case global::Mono.Cecil.Metadata.ElementType.U1:
				return base.ReadByte();
			case global::Mono.Cecil.Metadata.ElementType.I2:
				return base.ReadInt16();
			case global::Mono.Cecil.Metadata.ElementType.U2:
				return base.ReadUInt16();
			case global::Mono.Cecil.Metadata.ElementType.I4:
				return base.ReadInt32();
			case global::Mono.Cecil.Metadata.ElementType.U4:
				return base.ReadUInt32();
			case global::Mono.Cecil.Metadata.ElementType.I8:
				return base.ReadInt64();
			case global::Mono.Cecil.Metadata.ElementType.U8:
				return base.ReadUInt64();
			case global::Mono.Cecil.Metadata.ElementType.R4:
				return base.ReadSingle();
			case global::Mono.Cecil.Metadata.ElementType.R8:
				return base.ReadDouble();
			default:
				throw new global::System.NotImplementedException(type.ToString());
			}
		}

		// Token: 0x060009B7 RID: 2487 RVA: 0x0001DAC4 File Offset: 0x0001BCC4
		private global::Mono.Cecil.TypeReference GetPrimitiveType(global::Mono.Cecil.Metadata.ElementType etype)
		{
			switch (etype)
			{
			case global::Mono.Cecil.Metadata.ElementType.Boolean:
				return this.TypeSystem.Boolean;
			case global::Mono.Cecil.Metadata.ElementType.Char:
				return this.TypeSystem.Char;
			case global::Mono.Cecil.Metadata.ElementType.I1:
				return this.TypeSystem.SByte;
			case global::Mono.Cecil.Metadata.ElementType.U1:
				return this.TypeSystem.Byte;
			case global::Mono.Cecil.Metadata.ElementType.I2:
				return this.TypeSystem.Int16;
			case global::Mono.Cecil.Metadata.ElementType.U2:
				return this.TypeSystem.UInt16;
			case global::Mono.Cecil.Metadata.ElementType.I4:
				return this.TypeSystem.Int32;
			case global::Mono.Cecil.Metadata.ElementType.U4:
				return this.TypeSystem.UInt32;
			case global::Mono.Cecil.Metadata.ElementType.I8:
				return this.TypeSystem.Int64;
			case global::Mono.Cecil.Metadata.ElementType.U8:
				return this.TypeSystem.UInt64;
			case global::Mono.Cecil.Metadata.ElementType.R4:
				return this.TypeSystem.Single;
			case global::Mono.Cecil.Metadata.ElementType.R8:
				return this.TypeSystem.Double;
			case global::Mono.Cecil.Metadata.ElementType.String:
				return this.TypeSystem.String;
			default:
				throw new global::System.NotImplementedException(etype.ToString());
			}
		}

		// Token: 0x060009B8 RID: 2488 RVA: 0x0001DBC0 File Offset: 0x0001BDC0
		private global::Mono.Cecil.TypeReference ReadCustomAttributeFieldOrPropType()
		{
			global::Mono.Cecil.Metadata.ElementType elementType = (global::Mono.Cecil.Metadata.ElementType)base.ReadByte();
			global::Mono.Cecil.Metadata.ElementType elementType2 = elementType;
			if (elementType2 == global::Mono.Cecil.Metadata.ElementType.SzArray)
			{
				return new global::Mono.Cecil.ArrayType(this.ReadCustomAttributeFieldOrPropType());
			}
			switch (elementType2)
			{
			case global::Mono.Cecil.Metadata.ElementType.Type:
				return this.TypeSystem.LookupType("System", "Type");
			case global::Mono.Cecil.Metadata.ElementType.Boxed:
				return this.TypeSystem.Object;
			default:
				if (elementType2 != global::Mono.Cecil.Metadata.ElementType.Enum)
				{
					return this.GetPrimitiveType(elementType);
				}
				return this.ReadTypeReference();
			}
		}

		// Token: 0x060009B9 RID: 2489 RVA: 0x0001DC2F File Offset: 0x0001BE2F
		public global::Mono.Cecil.TypeReference ReadTypeReference()
		{
			return global::Mono.Cecil.TypeParser.ParseType(this.reader.module, this.ReadUTF8String());
		}

		// Token: 0x060009BA RID: 2490 RVA: 0x0001DC48 File Offset: 0x0001BE48
		private object ReadCustomAttributeEnum(global::Mono.Cecil.TypeReference enum_type)
		{
			global::Mono.Cecil.TypeDefinition typeDefinition = enum_type.CheckedResolve();
			if (!typeDefinition.IsEnum)
			{
				throw new global::System.ArgumentException();
			}
			return this.ReadCustomAttributeElementValue(typeDefinition.GetEnumUnderlyingType());
		}

		// Token: 0x060009BB RID: 2491 RVA: 0x0001DC78 File Offset: 0x0001BE78
		public global::Mono.Cecil.SecurityAttribute ReadSecurityAttribute()
		{
			global::Mono.Cecil.SecurityAttribute securityAttribute = new global::Mono.Cecil.SecurityAttribute(this.ReadTypeReference());
			base.ReadCompressedUInt32();
			this.ReadCustomAttributeNamedArguments((ushort)base.ReadCompressedUInt32(), ref securityAttribute.fields, ref securityAttribute.properties);
			return securityAttribute;
		}

		// Token: 0x060009BC RID: 2492 RVA: 0x0001DCB4 File Offset: 0x0001BEB4
		public global::Mono.Cecil.MarshalInfo ReadMarshalInfo()
		{
			global::Mono.Cecil.NativeType nativeType = this.ReadNativeType();
			global::Mono.Cecil.NativeType nativeType2 = nativeType;
			if (nativeType2 == global::Mono.Cecil.NativeType.FixedSysString)
			{
				global::Mono.Cecil.FixedSysStringMarshalInfo fixedSysStringMarshalInfo = new global::Mono.Cecil.FixedSysStringMarshalInfo();
				if (this.CanReadMore())
				{
					fixedSysStringMarshalInfo.size = (int)base.ReadCompressedUInt32();
				}
				return fixedSysStringMarshalInfo;
			}
			switch (nativeType2)
			{
			case global::Mono.Cecil.NativeType.SafeArray:
			{
				global::Mono.Cecil.SafeArrayMarshalInfo safeArrayMarshalInfo = new global::Mono.Cecil.SafeArrayMarshalInfo();
				if (this.CanReadMore())
				{
					safeArrayMarshalInfo.element_type = this.ReadVariantType();
				}
				return safeArrayMarshalInfo;
			}
			case global::Mono.Cecil.NativeType.FixedArray:
			{
				global::Mono.Cecil.FixedArrayMarshalInfo fixedArrayMarshalInfo = new global::Mono.Cecil.FixedArrayMarshalInfo();
				if (this.CanReadMore())
				{
					fixedArrayMarshalInfo.size = (int)base.ReadCompressedUInt32();
				}
				if (this.CanReadMore())
				{
					fixedArrayMarshalInfo.element_type = this.ReadNativeType();
				}
				return fixedArrayMarshalInfo;
			}
			default:
				switch (nativeType2)
				{
				case global::Mono.Cecil.NativeType.Array:
				{
					global::Mono.Cecil.ArrayMarshalInfo arrayMarshalInfo = new global::Mono.Cecil.ArrayMarshalInfo();
					if (this.CanReadMore())
					{
						arrayMarshalInfo.element_type = this.ReadNativeType();
					}
					if (this.CanReadMore())
					{
						arrayMarshalInfo.size_parameter_index = (int)base.ReadCompressedUInt32();
					}
					if (this.CanReadMore())
					{
						arrayMarshalInfo.size = (int)base.ReadCompressedUInt32();
					}
					if (this.CanReadMore())
					{
						arrayMarshalInfo.size_parameter_multiplier = (int)base.ReadCompressedUInt32();
					}
					return arrayMarshalInfo;
				}
				case global::Mono.Cecil.NativeType.CustomMarshaler:
				{
					global::Mono.Cecil.CustomMarshalInfo customMarshalInfo = new global::Mono.Cecil.CustomMarshalInfo();
					string text = this.ReadUTF8String();
					customMarshalInfo.guid = ((!string.IsNullOrEmpty(text)) ? new global::System.Guid(text) : global::System.Guid.Empty);
					customMarshalInfo.unmanaged_type = this.ReadUTF8String();
					customMarshalInfo.managed_type = this.ReadTypeReference();
					customMarshalInfo.cookie = this.ReadUTF8String();
					return customMarshalInfo;
				}
				}
				return new global::Mono.Cecil.MarshalInfo(nativeType);
			}
		}

		// Token: 0x060009BD RID: 2493 RVA: 0x0001DE21 File Offset: 0x0001C021
		private global::Mono.Cecil.NativeType ReadNativeType()
		{
			return (global::Mono.Cecil.NativeType)base.ReadByte();
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x0001DE29 File Offset: 0x0001C029
		private global::Mono.Cecil.VariantType ReadVariantType()
		{
			return (global::Mono.Cecil.VariantType)base.ReadByte();
		}

		// Token: 0x060009BF RID: 2495 RVA: 0x0001DE34 File Offset: 0x0001C034
		private string ReadUTF8String()
		{
			if (this.buffer[this.position] == 0xFF)
			{
				this.position++;
				return null;
			}
			int num = (int)base.ReadCompressedUInt32();
			if (num == 0)
			{
				return string.Empty;
			}
			string @string = global::System.Text.Encoding.UTF8.GetString(this.buffer, this.position, (this.buffer[this.position + num - 1] == 0) ? (num - 1) : num);
			this.position += num;
			return @string;
		}

		// Token: 0x060009C0 RID: 2496 RVA: 0x0001DEB4 File Offset: 0x0001C0B4
		public bool CanReadMore()
		{
			return (long)this.position - (long)((ulong)this.start) < (long)((ulong)this.sig_length);
		}

		// Token: 0x04000612 RID: 1554
		private readonly global::Mono.Cecil.MetadataReader reader;

		// Token: 0x04000613 RID: 1555
		private readonly uint start;

		// Token: 0x04000614 RID: 1556
		private readonly uint sig_length;
	}
}
