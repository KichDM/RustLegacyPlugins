using System;
using System.Collections.Generic;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x020000C6 RID: 198
	internal static class MetadataResolver
	{
		// Token: 0x060007FF RID: 2047 RVA: 0x00015920 File Offset: 0x00013B20
		public static global::Mono.Cecil.TypeDefinition Resolve(global::Mono.Cecil.IAssemblyResolver resolver, global::Mono.Cecil.TypeReference type)
		{
			type = type.GetElementType();
			global::Mono.Cecil.IMetadataScope scope = type.Scope;
			switch (scope.MetadataScopeType)
			{
			case global::Mono.Cecil.MetadataScopeType.AssemblyNameReference:
			{
				global::Mono.Cecil.AssemblyDefinition assemblyDefinition = resolver.Resolve((global::Mono.Cecil.AssemblyNameReference)scope);
				if (assemblyDefinition == null)
				{
					return null;
				}
				return global::Mono.Cecil.MetadataResolver.GetType(resolver, assemblyDefinition.MainModule, type);
			}
			case global::Mono.Cecil.MetadataScopeType.ModuleReference:
			{
				global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ModuleDefinition> modules = type.Module.Assembly.Modules;
				global::Mono.Cecil.ModuleReference moduleReference = (global::Mono.Cecil.ModuleReference)scope;
				for (int i = 0; i < modules.Count; i++)
				{
					global::Mono.Cecil.ModuleDefinition moduleDefinition = modules[i];
					if (moduleDefinition.Name == moduleReference.Name)
					{
						return global::Mono.Cecil.MetadataResolver.GetType(resolver, moduleDefinition, type);
					}
				}
				break;
			}
			case global::Mono.Cecil.MetadataScopeType.ModuleDefinition:
				return global::Mono.Cecil.MetadataResolver.GetType(resolver, (global::Mono.Cecil.ModuleDefinition)scope, type);
			}
			throw new global::System.NotSupportedException();
		}

		// Token: 0x06000800 RID: 2048 RVA: 0x000159E4 File Offset: 0x00013BE4
		private static global::Mono.Cecil.TypeDefinition GetType(global::Mono.Cecil.IAssemblyResolver resolver, global::Mono.Cecil.ModuleDefinition module, global::Mono.Cecil.TypeReference reference)
		{
			global::Mono.Cecil.TypeDefinition type = global::Mono.Cecil.MetadataResolver.GetType(module, reference);
			if (type != null)
			{
				return type;
			}
			if (!module.HasExportedTypes)
			{
				return null;
			}
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ExportedType> exportedTypes = module.ExportedTypes;
			for (int i = 0; i < exportedTypes.Count; i++)
			{
				global::Mono.Cecil.ExportedType exportedType = exportedTypes[i];
				if (!(exportedType.Name != reference.Name) && !(exportedType.Namespace != reference.Namespace))
				{
					return exportedType.Resolve();
				}
			}
			return null;
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x00015A58 File Offset: 0x00013C58
		private static global::Mono.Cecil.TypeDefinition GetType(global::Mono.Cecil.ModuleDefinition module, global::Mono.Cecil.TypeReference type)
		{
			if (!type.IsNested)
			{
				return module.GetType(type.Namespace, type.Name);
			}
			global::Mono.Cecil.TypeDefinition typeDefinition = type.DeclaringType.Resolve();
			if (typeDefinition == null)
			{
				return null;
			}
			return typeDefinition.GetNestedType(type.Name);
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x00015AA0 File Offset: 0x00013CA0
		public static global::Mono.Cecil.FieldDefinition Resolve(global::Mono.Cecil.IAssemblyResolver resolver, global::Mono.Cecil.FieldReference field)
		{
			global::Mono.Cecil.TypeDefinition typeDefinition = global::Mono.Cecil.MetadataResolver.Resolve(resolver, field.DeclaringType);
			if (typeDefinition == null)
			{
				return null;
			}
			if (!typeDefinition.HasFields)
			{
				return null;
			}
			return global::Mono.Cecil.MetadataResolver.GetField(resolver, typeDefinition, field);
		}

		// Token: 0x06000803 RID: 2051 RVA: 0x00015AD4 File Offset: 0x00013CD4
		private static global::Mono.Cecil.FieldDefinition GetField(global::Mono.Cecil.IAssemblyResolver resolver, global::Mono.Cecil.TypeDefinition type, global::Mono.Cecil.FieldReference reference)
		{
			while (type != null)
			{
				global::Mono.Cecil.FieldDefinition field = global::Mono.Cecil.MetadataResolver.GetField(type.Fields, reference);
				if (field != null)
				{
					return field;
				}
				if (type.BaseType == null)
				{
					return null;
				}
				type = global::Mono.Cecil.MetadataResolver.Resolve(resolver, type.BaseType);
			}
			return null;
		}

		// Token: 0x06000804 RID: 2052 RVA: 0x00015B14 File Offset: 0x00013D14
		private static global::Mono.Cecil.FieldDefinition GetField(global::System.Collections.Generic.IList<global::Mono.Cecil.FieldDefinition> fields, global::Mono.Cecil.FieldReference reference)
		{
			for (int i = 0; i < fields.Count; i++)
			{
				global::Mono.Cecil.FieldDefinition fieldDefinition = fields[i];
				if (!(fieldDefinition.Name != reference.Name) && global::Mono.Cecil.MetadataResolver.AreSame(fieldDefinition.FieldType, reference.FieldType))
				{
					return fieldDefinition;
				}
			}
			return null;
		}

		// Token: 0x06000805 RID: 2053 RVA: 0x00015B64 File Offset: 0x00013D64
		public static global::Mono.Cecil.MethodDefinition Resolve(global::Mono.Cecil.IAssemblyResolver resolver, global::Mono.Cecil.MethodReference method)
		{
			global::Mono.Cecil.TypeDefinition typeDefinition = global::Mono.Cecil.MetadataResolver.Resolve(resolver, method.DeclaringType);
			if (typeDefinition == null)
			{
				return null;
			}
			method = method.GetElementMethod();
			if (!typeDefinition.HasMethods)
			{
				return null;
			}
			return global::Mono.Cecil.MetadataResolver.GetMethod(resolver, typeDefinition, method);
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x00015BA0 File Offset: 0x00013DA0
		private static global::Mono.Cecil.MethodDefinition GetMethod(global::Mono.Cecil.IAssemblyResolver resolver, global::Mono.Cecil.TypeDefinition type, global::Mono.Cecil.MethodReference reference)
		{
			while (type != null)
			{
				global::Mono.Cecil.MethodDefinition method = global::Mono.Cecil.MetadataResolver.GetMethod(type.Methods, reference);
				if (method != null)
				{
					return method;
				}
				if (type.BaseType == null)
				{
					return null;
				}
				type = global::Mono.Cecil.MetadataResolver.Resolve(resolver, type.BaseType);
			}
			return null;
		}

		// Token: 0x06000807 RID: 2055 RVA: 0x00015BE0 File Offset: 0x00013DE0
		public static global::Mono.Cecil.MethodDefinition GetMethod(global::System.Collections.Generic.IList<global::Mono.Cecil.MethodDefinition> methods, global::Mono.Cecil.MethodReference reference)
		{
			for (int i = 0; i < methods.Count; i++)
			{
				global::Mono.Cecil.MethodDefinition methodDefinition = methods[i];
				if (!(methodDefinition.Name != reference.Name) && methodDefinition.HasGenericParameters == reference.HasGenericParameters && (!methodDefinition.HasGenericParameters || methodDefinition.GenericParameters.Count == reference.GenericParameters.Count) && global::Mono.Cecil.MetadataResolver.AreSame(methodDefinition.ReturnType, reference.ReturnType) && methodDefinition.HasParameters == reference.HasParameters)
				{
					if (!methodDefinition.HasParameters && !reference.HasParameters)
					{
						return methodDefinition;
					}
					if (global::Mono.Cecil.MetadataResolver.AreSame(methodDefinition.Parameters, reference.Parameters))
					{
						return methodDefinition;
					}
				}
			}
			return null;
		}

		// Token: 0x06000808 RID: 2056 RVA: 0x00015C98 File Offset: 0x00013E98
		private static bool AreSame(global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition> a, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition> b)
		{
			int count = a.Count;
			if (count != b.Count)
			{
				return false;
			}
			if (count == 0)
			{
				return true;
			}
			for (int i = 0; i < count; i++)
			{
				if (!global::Mono.Cecil.MetadataResolver.AreSame(a[i].ParameterType, b[i].ParameterType))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000809 RID: 2057 RVA: 0x00015CEC File Offset: 0x00013EEC
		private static bool AreSame(global::Mono.Cecil.TypeSpecification a, global::Mono.Cecil.TypeSpecification b)
		{
			if (!global::Mono.Cecil.MetadataResolver.AreSame(a.ElementType, b.ElementType))
			{
				return false;
			}
			if (a.IsGenericInstance)
			{
				return global::Mono.Cecil.MetadataResolver.AreSame((global::Mono.Cecil.GenericInstanceType)a, (global::Mono.Cecil.GenericInstanceType)b);
			}
			if (a.IsRequiredModifier || a.IsOptionalModifier)
			{
				return global::Mono.Cecil.MetadataResolver.AreSame((global::Mono.Cecil.IModifierType)a, (global::Mono.Cecil.IModifierType)b);
			}
			return !a.IsArray || global::Mono.Cecil.MetadataResolver.AreSame((global::Mono.Cecil.ArrayType)a, (global::Mono.Cecil.ArrayType)b);
		}

		// Token: 0x0600080A RID: 2058 RVA: 0x00015D65 File Offset: 0x00013F65
		private static bool AreSame(global::Mono.Cecil.ArrayType a, global::Mono.Cecil.ArrayType b)
		{
			return a.Rank == b.Rank;
		}

		// Token: 0x0600080B RID: 2059 RVA: 0x00015D78 File Offset: 0x00013F78
		private static bool AreSame(global::Mono.Cecil.IModifierType a, global::Mono.Cecil.IModifierType b)
		{
			return global::Mono.Cecil.MetadataResolver.AreSame(a.ModifierType, b.ModifierType);
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x00015D8C File Offset: 0x00013F8C
		private static bool AreSame(global::Mono.Cecil.GenericInstanceType a, global::Mono.Cecil.GenericInstanceType b)
		{
			if (a.GenericArguments.Count != b.GenericArguments.Count)
			{
				return false;
			}
			for (int i = 0; i < a.GenericArguments.Count; i++)
			{
				if (!global::Mono.Cecil.MetadataResolver.AreSame(a.GenericArguments[i], b.GenericArguments[i]))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600080D RID: 2061 RVA: 0x00015DEB File Offset: 0x00013FEB
		private static bool AreSame(global::Mono.Cecil.GenericParameter a, global::Mono.Cecil.GenericParameter b)
		{
			return a.Position == b.Position;
		}

		// Token: 0x0600080E RID: 2062 RVA: 0x00015DFC File Offset: 0x00013FFC
		private static bool AreSame(global::Mono.Cecil.TypeReference a, global::Mono.Cecil.TypeReference b)
		{
			if (object.ReferenceEquals(a, b))
			{
				return true;
			}
			if (a == null || b == null)
			{
				return false;
			}
			if (a.etype != b.etype)
			{
				return false;
			}
			if (a.IsGenericParameter)
			{
				return global::Mono.Cecil.MetadataResolver.AreSame((global::Mono.Cecil.GenericParameter)a, (global::Mono.Cecil.GenericParameter)b);
			}
			if (a.IsTypeSpecification())
			{
				return global::Mono.Cecil.MetadataResolver.AreSame((global::Mono.Cecil.TypeSpecification)a, (global::Mono.Cecil.TypeSpecification)b);
			}
			return !(a.Name != b.Name) && !(a.Namespace != b.Namespace) && global::Mono.Cecil.MetadataResolver.AreSame(a.DeclaringType, b.DeclaringType);
		}
	}
}
