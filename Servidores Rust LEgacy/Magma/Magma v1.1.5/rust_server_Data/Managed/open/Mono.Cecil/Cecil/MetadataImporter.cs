using System;
using System.Collections.Generic;
using System.Reflection;
using Mono.Cecil.Metadata;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x0200008E RID: 142
	internal class MetadataImporter
	{
		// Token: 0x0600060D RID: 1549 RVA: 0x0000EB72 File Offset: 0x0000CD72
		public MetadataImporter(global::Mono.Cecil.ModuleDefinition module)
		{
			this.module = module;
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x0000EB81 File Offset: 0x0000CD81
		public global::Mono.Cecil.TypeReference ImportType(global::System.Type type, global::Mono.Cecil.IGenericContext context)
		{
			return this.ImportType(type, context, global::Mono.Cecil.ImportGenericKind.Open);
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x0000EB8C File Offset: 0x0000CD8C
		public global::Mono.Cecil.TypeReference ImportType(global::System.Type type, global::Mono.Cecil.IGenericContext context, global::Mono.Cecil.ImportGenericKind import_kind)
		{
			if (global::Mono.Cecil.MetadataImporter.IsTypeSpecification(type) || global::Mono.Cecil.MetadataImporter.ImportOpenGenericType(type, import_kind))
			{
				return this.ImportTypeSpecification(type, context);
			}
			global::Mono.Cecil.TypeReference typeReference = new global::Mono.Cecil.TypeReference(string.Empty, type.Name, this.module, this.ImportScope(type.Assembly), type.IsValueType);
			typeReference.etype = global::Mono.Cecil.MetadataImporter.ImportElementType(type);
			if (global::Mono.Cecil.MetadataImporter.IsNestedType(type))
			{
				typeReference.DeclaringType = this.ImportType(type.DeclaringType, context, import_kind);
			}
			else
			{
				typeReference.Namespace = type.Namespace;
			}
			if (type.IsGenericType)
			{
				global::Mono.Cecil.MetadataImporter.ImportGenericParameters(typeReference, type.GetGenericArguments());
			}
			return typeReference;
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x0000EC27 File Offset: 0x0000CE27
		private static bool ImportOpenGenericType(global::System.Type type, global::Mono.Cecil.ImportGenericKind import_kind)
		{
			return type.IsGenericType && type.IsGenericTypeDefinition && import_kind == global::Mono.Cecil.ImportGenericKind.Open;
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x0000EC3F File Offset: 0x0000CE3F
		private static bool ImportOpenGenericMethod(global::System.Reflection.MethodBase method, global::Mono.Cecil.ImportGenericKind import_kind)
		{
			return method.IsGenericMethod && method.IsGenericMethodDefinition && import_kind == global::Mono.Cecil.ImportGenericKind.Open;
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x0000EC57 File Offset: 0x0000CE57
		private static bool IsNestedType(global::System.Type type)
		{
			return type.IsNested;
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x0000EC60 File Offset: 0x0000CE60
		private global::Mono.Cecil.TypeReference ImportTypeSpecification(global::System.Type type, global::Mono.Cecil.IGenericContext context)
		{
			if (type.IsByRef)
			{
				return new global::Mono.Cecil.ByReferenceType(this.ImportType(type.GetElementType(), context));
			}
			if (type.IsPointer)
			{
				return new global::Mono.Cecil.PointerType(this.ImportType(type.GetElementType(), context));
			}
			if (type.IsArray)
			{
				return new global::Mono.Cecil.ArrayType(this.ImportType(type.GetElementType(), context), type.GetArrayRank());
			}
			if (type.IsGenericType)
			{
				return this.ImportGenericInstance(type, context);
			}
			if (type.IsGenericParameter)
			{
				return global::Mono.Cecil.MetadataImporter.ImportGenericParameter(type, context);
			}
			throw new global::System.NotSupportedException(type.FullName);
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x0000ECF0 File Offset: 0x0000CEF0
		private static global::Mono.Cecil.TypeReference ImportGenericParameter(global::System.Type type, global::Mono.Cecil.IGenericContext context)
		{
			if (context == null)
			{
				throw new global::System.InvalidOperationException();
			}
			global::Mono.Cecil.IGenericParameterProvider genericParameterProvider = (type.DeclaringMethod != null) ? context.Method : context.Type;
			if (genericParameterProvider == null)
			{
				throw new global::System.InvalidOperationException();
			}
			return genericParameterProvider.GenericParameters[type.GenericParameterPosition];
		}

		// Token: 0x06000615 RID: 1557 RVA: 0x0000ED38 File Offset: 0x0000CF38
		private global::Mono.Cecil.TypeReference ImportGenericInstance(global::System.Type type, global::Mono.Cecil.IGenericContext context)
		{
			global::Mono.Cecil.TypeReference typeReference = this.ImportType(type.GetGenericTypeDefinition(), context, global::Mono.Cecil.ImportGenericKind.Definition);
			global::Mono.Cecil.GenericInstanceType genericInstanceType = new global::Mono.Cecil.GenericInstanceType(typeReference);
			global::System.Type[] genericArguments = type.GetGenericArguments();
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> genericArguments2 = genericInstanceType.GenericArguments;
			for (int i = 0; i < genericArguments.Length; i++)
			{
				genericArguments2.Add(this.ImportType(genericArguments[i], context ?? typeReference));
			}
			return genericInstanceType;
		}

		// Token: 0x06000616 RID: 1558 RVA: 0x0000ED92 File Offset: 0x0000CF92
		private static bool IsTypeSpecification(global::System.Type type)
		{
			return type.HasElementType || global::Mono.Cecil.MetadataImporter.IsGenericInstance(type) || type.IsGenericParameter;
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x0000EDAC File Offset: 0x0000CFAC
		private static bool IsGenericInstance(global::System.Type type)
		{
			return type.IsGenericType && !type.IsGenericTypeDefinition;
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x0000EDC4 File Offset: 0x0000CFC4
		private static global::Mono.Cecil.Metadata.ElementType ImportElementType(global::System.Type type)
		{
			global::Mono.Cecil.Metadata.ElementType result;
			if (!global::Mono.Cecil.MetadataImporter.type_etype_mapping.TryGetValue(type, out result))
			{
				return global::Mono.Cecil.Metadata.ElementType.None;
			}
			return result;
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x0000EDE4 File Offset: 0x0000CFE4
		private global::Mono.Cecil.AssemblyNameReference ImportScope(global::System.Reflection.Assembly assembly)
		{
			global::System.Reflection.AssemblyName name = assembly.GetName();
			global::Mono.Cecil.AssemblyNameReference assemblyNameReference;
			if (this.TryGetAssemblyNameReference(name, out assemblyNameReference))
			{
				return assemblyNameReference;
			}
			assemblyNameReference = new global::Mono.Cecil.AssemblyNameReference(name.Name, name.Version)
			{
				Culture = name.CultureInfo.Name,
				PublicKeyToken = name.GetPublicKeyToken(),
				HashAlgorithm = (global::Mono.Cecil.AssemblyHashAlgorithm)name.HashAlgorithm
			};
			this.module.AssemblyReferences.Add(assemblyNameReference);
			return assemblyNameReference;
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x0000EE54 File Offset: 0x0000D054
		private bool TryGetAssemblyNameReference(global::System.Reflection.AssemblyName name, out global::Mono.Cecil.AssemblyNameReference assembly_reference)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.AssemblyNameReference> assemblyReferences = this.module.AssemblyReferences;
			for (int i = 0; i < assemblyReferences.Count; i++)
			{
				global::Mono.Cecil.AssemblyNameReference assemblyNameReference = assemblyReferences[i];
				if (!(name.FullName != assemblyNameReference.FullName))
				{
					assembly_reference = assemblyNameReference;
					return true;
				}
			}
			assembly_reference = null;
			return false;
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x0000EEA4 File Offset: 0x0000D0A4
		public global::Mono.Cecil.FieldReference ImportField(global::System.Reflection.FieldInfo field, global::Mono.Cecil.IGenericContext context)
		{
			global::Mono.Cecil.TypeReference typeReference = this.ImportType(field.DeclaringType, context);
			if (global::Mono.Cecil.MetadataImporter.IsGenericInstance(field.DeclaringType))
			{
				field = global::Mono.Cecil.MetadataImporter.ResolveFieldDefinition(field);
			}
			return new global::Mono.Cecil.FieldReference
			{
				Name = field.Name,
				DeclaringType = typeReference,
				FieldType = this.ImportType(field.FieldType, context ?? typeReference)
			};
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x0000EF06 File Offset: 0x0000D106
		private static global::System.Reflection.FieldInfo ResolveFieldDefinition(global::System.Reflection.FieldInfo field)
		{
			return field.Module.ResolveField(field.MetadataToken);
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x0000EF1C File Offset: 0x0000D11C
		public global::Mono.Cecil.MethodReference ImportMethod(global::System.Reflection.MethodBase method, global::Mono.Cecil.IGenericContext context, global::Mono.Cecil.ImportGenericKind import_kind)
		{
			if (global::Mono.Cecil.MetadataImporter.IsMethodSpecification(method) || global::Mono.Cecil.MetadataImporter.ImportOpenGenericMethod(method, import_kind))
			{
				return this.ImportMethodSpecification(method, context);
			}
			global::Mono.Cecil.TypeReference declaringType = this.ImportType(method.DeclaringType, context);
			if (global::Mono.Cecil.MetadataImporter.IsGenericInstance(method.DeclaringType))
			{
				method = method.Module.ResolveMethod(method.MetadataToken);
			}
			global::Mono.Cecil.MethodReference methodReference = new global::Mono.Cecil.MethodReference
			{
				Name = method.Name,
				HasThis = global::Mono.Cecil.MetadataImporter.HasCallingConvention(method, global::System.Reflection.CallingConventions.HasThis),
				ExplicitThis = global::Mono.Cecil.MetadataImporter.HasCallingConvention(method, global::System.Reflection.CallingConventions.ExplicitThis),
				DeclaringType = this.ImportType(method.DeclaringType, context, global::Mono.Cecil.ImportGenericKind.Definition)
			};
			if (global::Mono.Cecil.MetadataImporter.HasCallingConvention(method, global::System.Reflection.CallingConventions.VarArgs))
			{
				global::Mono.Cecil.MethodReference methodReference2 = methodReference;
				methodReference2.CallingConvention &= global::Mono.Cecil.MethodCallingConvention.VarArg;
			}
			if (method.IsGenericMethod)
			{
				global::Mono.Cecil.MetadataImporter.ImportGenericParameters(methodReference, method.GetGenericArguments());
			}
			global::System.Reflection.MethodInfo methodInfo = method as global::System.Reflection.MethodInfo;
			methodReference.ReturnType = ((methodInfo != null) ? this.ImportType(methodInfo.ReturnType, context ?? methodReference) : this.ImportType(typeof(void), null));
			global::System.Reflection.ParameterInfo[] parameters = method.GetParameters();
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition> parameters2 = methodReference.Parameters;
			for (int i = 0; i < parameters.Length; i++)
			{
				parameters2.Add(new global::Mono.Cecil.ParameterDefinition(this.ImportType(parameters[i].ParameterType, context ?? methodReference)));
			}
			methodReference.DeclaringType = declaringType;
			return methodReference;
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x0000F068 File Offset: 0x0000D268
		private static void ImportGenericParameters(global::Mono.Cecil.IGenericParameterProvider provider, global::System.Type[] arguments)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.GenericParameter> genericParameters = provider.GenericParameters;
			for (int i = 0; i < arguments.Length; i++)
			{
				genericParameters.Add(new global::Mono.Cecil.GenericParameter(arguments[i].Name, provider));
			}
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x0000F09E File Offset: 0x0000D29E
		private static bool IsMethodSpecification(global::System.Reflection.MethodBase method)
		{
			return method.IsGenericMethod && !method.IsGenericMethodDefinition;
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x0000F0B4 File Offset: 0x0000D2B4
		private global::Mono.Cecil.MethodReference ImportMethodSpecification(global::System.Reflection.MethodBase method, global::Mono.Cecil.IGenericContext context)
		{
			global::System.Reflection.MethodInfo methodInfo = method as global::System.Reflection.MethodInfo;
			if (methodInfo == null)
			{
				throw new global::System.InvalidOperationException();
			}
			global::Mono.Cecil.MethodReference methodReference = this.ImportMethod(methodInfo.GetGenericMethodDefinition(), context, global::Mono.Cecil.ImportGenericKind.Definition);
			global::Mono.Cecil.GenericInstanceMethod genericInstanceMethod = new global::Mono.Cecil.GenericInstanceMethod(methodReference);
			global::System.Type[] genericArguments = method.GetGenericArguments();
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> genericArguments2 = genericInstanceMethod.GenericArguments;
			for (int i = 0; i < genericArguments.Length; i++)
			{
				genericArguments2.Add(this.ImportType(genericArguments[i], context ?? methodReference));
			}
			return genericInstanceMethod;
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x0000F120 File Offset: 0x0000D320
		private static bool HasCallingConvention(global::System.Reflection.MethodBase method, global::System.Reflection.CallingConventions conventions)
		{
			return (method.CallingConvention & conventions) != (global::System.Reflection.CallingConventions)0;
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x0000F130 File Offset: 0x0000D330
		public global::Mono.Cecil.TypeReference ImportType(global::Mono.Cecil.TypeReference type, global::Mono.Cecil.IGenericContext context)
		{
			if (type.IsTypeSpecification())
			{
				return this.ImportTypeSpecification(type, context);
			}
			global::Mono.Cecil.TypeReference typeReference = new global::Mono.Cecil.TypeReference(type.Namespace, type.Name, this.module, this.ImportScope(type.Scope), type.IsValueType);
			global::Mono.Cecil.MetadataSystem.TryProcessPrimitiveType(typeReference);
			if (type.IsNested)
			{
				typeReference.DeclaringType = this.ImportType(type.DeclaringType, context);
			}
			if (type.HasGenericParameters)
			{
				global::Mono.Cecil.MetadataImporter.ImportGenericParameters(typeReference, type);
			}
			return typeReference;
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x0000F1AC File Offset: 0x0000D3AC
		private global::Mono.Cecil.IMetadataScope ImportScope(global::Mono.Cecil.IMetadataScope scope)
		{
			switch (scope.MetadataScopeType)
			{
			case global::Mono.Cecil.MetadataScopeType.AssemblyNameReference:
				return this.ImportAssemblyName((global::Mono.Cecil.AssemblyNameReference)scope);
			case global::Mono.Cecil.MetadataScopeType.ModuleReference:
				throw new global::System.NotImplementedException();
			case global::Mono.Cecil.MetadataScopeType.ModuleDefinition:
				return this.ImportAssemblyName(((global::Mono.Cecil.ModuleDefinition)scope).Assembly.Name);
			default:
				throw new global::System.NotSupportedException();
			}
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x0000F204 File Offset: 0x0000D404
		private global::Mono.Cecil.AssemblyNameReference ImportAssemblyName(global::Mono.Cecil.AssemblyNameReference name)
		{
			global::Mono.Cecil.AssemblyNameReference assemblyNameReference;
			if (this.TryGetAssemblyNameReference(name, out assemblyNameReference))
			{
				return assemblyNameReference;
			}
			assemblyNameReference = new global::Mono.Cecil.AssemblyNameReference(name.Name, name.Version)
			{
				Culture = name.Culture,
				HashAlgorithm = name.HashAlgorithm
			};
			byte[] array = (!name.PublicKeyToken.IsNullOrEmpty<byte>()) ? new byte[name.PublicKeyToken.Length] : global::Mono.Empty<byte>.Array;
			if (array.Length > 0)
			{
				global::System.Buffer.BlockCopy(name.PublicKeyToken, 0, array, 0, array.Length);
			}
			assemblyNameReference.PublicKeyToken = array;
			this.module.AssemblyReferences.Add(assemblyNameReference);
			return assemblyNameReference;
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x0000F29C File Offset: 0x0000D49C
		private bool TryGetAssemblyNameReference(global::Mono.Cecil.AssemblyNameReference name_reference, out global::Mono.Cecil.AssemblyNameReference assembly_reference)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.AssemblyNameReference> assemblyReferences = this.module.AssemblyReferences;
			for (int i = 0; i < assemblyReferences.Count; i++)
			{
				global::Mono.Cecil.AssemblyNameReference assemblyNameReference = assemblyReferences[i];
				if (!(name_reference.FullName != assemblyNameReference.FullName))
				{
					assembly_reference = assemblyNameReference;
					return true;
				}
			}
			assembly_reference = null;
			return false;
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x0000F2EC File Offset: 0x0000D4EC
		private static void ImportGenericParameters(global::Mono.Cecil.IGenericParameterProvider imported, global::Mono.Cecil.IGenericParameterProvider original)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.GenericParameter> genericParameters = original.GenericParameters;
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.GenericParameter> genericParameters2 = imported.GenericParameters;
			for (int i = 0; i < genericParameters.Count; i++)
			{
				genericParameters2.Add(new global::Mono.Cecil.GenericParameter(genericParameters[i].Name, imported));
			}
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x0000F330 File Offset: 0x0000D530
		private global::Mono.Cecil.TypeReference ImportTypeSpecification(global::Mono.Cecil.TypeReference type, global::Mono.Cecil.IGenericContext context)
		{
			global::Mono.Cecil.Metadata.ElementType etype = type.etype;
			if (etype <= global::Mono.Cecil.Metadata.ElementType.CModOpt)
			{
				switch (etype)
				{
				case global::Mono.Cecil.Metadata.ElementType.Ptr:
				{
					global::Mono.Cecil.PointerType pointerType = (global::Mono.Cecil.PointerType)type;
					return new global::Mono.Cecil.PointerType(this.ImportType(pointerType.ElementType, context));
				}
				case global::Mono.Cecil.Metadata.ElementType.ByRef:
				{
					global::Mono.Cecil.ByReferenceType byReferenceType = (global::Mono.Cecil.ByReferenceType)type;
					return new global::Mono.Cecil.ByReferenceType(this.ImportType(byReferenceType.ElementType, context));
				}
				case global::Mono.Cecil.Metadata.ElementType.ValueType:
				case global::Mono.Cecil.Metadata.ElementType.Class:
					break;
				case global::Mono.Cecil.Metadata.ElementType.Var:
					if (context == null || context.Type == null)
					{
						throw new global::System.InvalidOperationException();
					}
					return ((global::Mono.Cecil.TypeReference)context.Type).GetElementType().GenericParameters[((global::Mono.Cecil.GenericParameter)type).Position];
				case global::Mono.Cecil.Metadata.ElementType.Array:
				{
					global::Mono.Cecil.ArrayType arrayType = (global::Mono.Cecil.ArrayType)type;
					global::Mono.Cecil.ArrayType arrayType2 = new global::Mono.Cecil.ArrayType(this.ImportType(arrayType.ElementType, context));
					if (arrayType.IsVector)
					{
						return arrayType2;
					}
					global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ArrayDimension> dimensions = arrayType.Dimensions;
					global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ArrayDimension> dimensions2 = arrayType2.Dimensions;
					dimensions2.Clear();
					for (int i = 0; i < dimensions.Count; i++)
					{
						global::Mono.Cecil.ArrayDimension arrayDimension = dimensions[i];
						dimensions2.Add(new global::Mono.Cecil.ArrayDimension(arrayDimension.LowerBound, arrayDimension.UpperBound));
					}
					return arrayType2;
				}
				case global::Mono.Cecil.Metadata.ElementType.GenericInst:
				{
					global::Mono.Cecil.GenericInstanceType genericInstanceType = (global::Mono.Cecil.GenericInstanceType)type;
					global::Mono.Cecil.TypeReference type2 = this.ImportType(genericInstanceType.ElementType, context);
					global::Mono.Cecil.GenericInstanceType genericInstanceType2 = new global::Mono.Cecil.GenericInstanceType(type2);
					global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> genericArguments = genericInstanceType.GenericArguments;
					global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> genericArguments2 = genericInstanceType2.GenericArguments;
					for (int j = 0; j < genericArguments.Count; j++)
					{
						genericArguments2.Add(this.ImportType(genericArguments[j], context));
					}
					return genericInstanceType2;
				}
				default:
					switch (etype)
					{
					case global::Mono.Cecil.Metadata.ElementType.SzArray:
					{
						global::Mono.Cecil.ArrayType arrayType3 = (global::Mono.Cecil.ArrayType)type;
						return new global::Mono.Cecil.ArrayType(this.ImportType(arrayType3.ElementType, context));
					}
					case global::Mono.Cecil.Metadata.ElementType.MVar:
						if (context == null || context.Method == null)
						{
							throw new global::System.InvalidOperationException();
						}
						return context.Method.GenericParameters[((global::Mono.Cecil.GenericParameter)type).Position];
					case global::Mono.Cecil.Metadata.ElementType.CModReqD:
					{
						global::Mono.Cecil.RequiredModifierType requiredModifierType = (global::Mono.Cecil.RequiredModifierType)type;
						return new global::Mono.Cecil.RequiredModifierType(this.ImportType(requiredModifierType.ModifierType, context), this.ImportType(requiredModifierType.ElementType, context));
					}
					case global::Mono.Cecil.Metadata.ElementType.CModOpt:
					{
						global::Mono.Cecil.OptionalModifierType optionalModifierType = (global::Mono.Cecil.OptionalModifierType)type;
						return new global::Mono.Cecil.OptionalModifierType(this.ImportType(optionalModifierType.ModifierType, context), this.ImportType(optionalModifierType.ElementType, context));
					}
					}
					break;
				}
			}
			else
			{
				if (etype == global::Mono.Cecil.Metadata.ElementType.Sentinel)
				{
					global::Mono.Cecil.SentinelType sentinelType = (global::Mono.Cecil.SentinelType)type;
					return new global::Mono.Cecil.SentinelType(this.ImportType(sentinelType.ElementType, context));
				}
				if (etype == global::Mono.Cecil.Metadata.ElementType.Pinned)
				{
					global::Mono.Cecil.PinnedType pinnedType = (global::Mono.Cecil.PinnedType)type;
					return new global::Mono.Cecil.PinnedType(this.ImportType(pinnedType.ElementType, context));
				}
			}
			throw new global::System.NotSupportedException(type.etype.ToString());
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x0000F5D8 File Offset: 0x0000D7D8
		public global::Mono.Cecil.FieldReference ImportField(global::Mono.Cecil.FieldReference field, global::Mono.Cecil.IGenericContext context)
		{
			global::Mono.Cecil.TypeReference typeReference = this.ImportType(field.DeclaringType, context);
			return new global::Mono.Cecil.FieldReference
			{
				Name = field.Name,
				DeclaringType = typeReference,
				FieldType = this.ImportType(field.FieldType, context ?? typeReference)
			};
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x0000F628 File Offset: 0x0000D828
		public global::Mono.Cecil.MethodReference ImportMethod(global::Mono.Cecil.MethodReference method, global::Mono.Cecil.IGenericContext context)
		{
			if (method.IsGenericInstance)
			{
				return this.ImportMethodSpecification(method, context);
			}
			global::Mono.Cecil.TypeReference declaringType = this.ImportType(method.DeclaringType, context);
			global::Mono.Cecil.MethodReference methodReference = new global::Mono.Cecil.MethodReference
			{
				Name = method.Name,
				HasThis = method.HasThis,
				ExplicitThis = method.ExplicitThis,
				DeclaringType = declaringType
			};
			methodReference.CallingConvention = method.CallingConvention;
			if (method.HasGenericParameters)
			{
				global::Mono.Cecil.MetadataImporter.ImportGenericParameters(methodReference, method);
			}
			methodReference.ReturnType = this.ImportType(method.ReturnType, context ?? methodReference);
			if (!method.HasParameters)
			{
				return methodReference;
			}
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition> parameters = methodReference.Parameters;
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition> parameters2 = method.Parameters;
			for (int i = 0; i < parameters2.Count; i++)
			{
				parameters.Add(new global::Mono.Cecil.ParameterDefinition(this.ImportType(parameters2[i].ParameterType, context ?? methodReference)));
			}
			return methodReference;
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x0000F714 File Offset: 0x0000D914
		private global::Mono.Cecil.MethodSpecification ImportMethodSpecification(global::Mono.Cecil.MethodReference method, global::Mono.Cecil.IGenericContext context)
		{
			if (!method.IsGenericInstance)
			{
				throw new global::System.NotSupportedException();
			}
			global::Mono.Cecil.GenericInstanceMethod genericInstanceMethod = (global::Mono.Cecil.GenericInstanceMethod)method;
			global::Mono.Cecil.MethodReference method2 = this.ImportMethod(genericInstanceMethod.ElementMethod, context);
			global::Mono.Cecil.GenericInstanceMethod genericInstanceMethod2 = new global::Mono.Cecil.GenericInstanceMethod(method2);
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> genericArguments = genericInstanceMethod.GenericArguments;
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> genericArguments2 = genericInstanceMethod2.GenericArguments;
			for (int i = 0; i < genericArguments.Count; i++)
			{
				genericArguments2.Add(this.ImportType(genericArguments[i], context));
			}
			return genericInstanceMethod2;
		}

		// Token: 0x0600062B RID: 1579 RVA: 0x0000F788 File Offset: 0x0000D988
		// Note: this type is marked as 'beforefieldinit'.
		static MetadataImporter()
		{
		}

		// Token: 0x040004B0 RID: 1200
		private readonly global::Mono.Cecil.ModuleDefinition module;

		// Token: 0x040004B1 RID: 1201
		private static readonly global::System.Collections.Generic.Dictionary<global::System.Type, global::Mono.Cecil.Metadata.ElementType> type_etype_mapping = new global::System.Collections.Generic.Dictionary<global::System.Type, global::Mono.Cecil.Metadata.ElementType>(0x12)
		{
			{
				typeof(void),
				global::Mono.Cecil.Metadata.ElementType.Void
			},
			{
				typeof(bool),
				global::Mono.Cecil.Metadata.ElementType.Boolean
			},
			{
				typeof(char),
				global::Mono.Cecil.Metadata.ElementType.Char
			},
			{
				typeof(sbyte),
				global::Mono.Cecil.Metadata.ElementType.I1
			},
			{
				typeof(byte),
				global::Mono.Cecil.Metadata.ElementType.U1
			},
			{
				typeof(short),
				global::Mono.Cecil.Metadata.ElementType.I2
			},
			{
				typeof(ushort),
				global::Mono.Cecil.Metadata.ElementType.U2
			},
			{
				typeof(int),
				global::Mono.Cecil.Metadata.ElementType.I4
			},
			{
				typeof(uint),
				global::Mono.Cecil.Metadata.ElementType.U4
			},
			{
				typeof(long),
				global::Mono.Cecil.Metadata.ElementType.I8
			},
			{
				typeof(ulong),
				global::Mono.Cecil.Metadata.ElementType.U8
			},
			{
				typeof(float),
				global::Mono.Cecil.Metadata.ElementType.R4
			},
			{
				typeof(double),
				global::Mono.Cecil.Metadata.ElementType.R8
			},
			{
				typeof(string),
				global::Mono.Cecil.Metadata.ElementType.String
			},
			{
				typeof(global::System.TypedReference),
				global::Mono.Cecil.Metadata.ElementType.TypedByRef
			},
			{
				typeof(global::System.IntPtr),
				global::Mono.Cecil.Metadata.ElementType.I
			},
			{
				typeof(global::System.UIntPtr),
				global::Mono.Cecil.Metadata.ElementType.U
			},
			{
				typeof(object),
				global::Mono.Cecil.Metadata.ElementType.Object
			}
		};
	}
}
