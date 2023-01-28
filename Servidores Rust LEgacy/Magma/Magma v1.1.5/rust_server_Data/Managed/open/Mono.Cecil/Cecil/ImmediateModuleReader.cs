using System;
using System.Runtime.CompilerServices;
using Mono.Cecil.PE;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x020000F2 RID: 242
	internal sealed class ImmediateModuleReader : global::Mono.Cecil.ModuleReader
	{
		// Token: 0x060008F4 RID: 2292 RVA: 0x00019CE0 File Offset: 0x00017EE0
		public ImmediateModuleReader(global::Mono.Cecil.PE.Image image) : base(image, global::Mono.Cecil.ReadingMode.Immediate)
		{
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x00019CFA File Offset: 0x00017EFA
		protected override void ReadModule()
		{
			this.module.Read<global::Mono.Cecil.ModuleDefinition, global::Mono.Cecil.ModuleDefinition>(this.module, delegate(global::Mono.Cecil.ModuleDefinition module, global::Mono.Cecil.MetadataReader reader)
			{
				base.ReadModuleManifest(reader);
				global::Mono.Cecil.ImmediateModuleReader.ReadModule(module);
				return module;
			});
		}

		// Token: 0x060008F6 RID: 2294 RVA: 0x00019D1C File Offset: 0x00017F1C
		public static void ReadModule(global::Mono.Cecil.ModuleDefinition module)
		{
			if (module.HasAssemblyReferences)
			{
				global::Mono.Cecil.ImmediateModuleReader.Read(module.AssemblyReferences);
			}
			if (module.HasResources)
			{
				global::Mono.Cecil.ImmediateModuleReader.Read(module.Resources);
			}
			if (module.HasModuleReferences)
			{
				global::Mono.Cecil.ImmediateModuleReader.Read(module.ModuleReferences);
			}
			if (module.HasTypes)
			{
				global::Mono.Cecil.ImmediateModuleReader.ReadTypes(module.Types);
			}
			if (module.HasExportedTypes)
			{
				global::Mono.Cecil.ImmediateModuleReader.Read(module.ExportedTypes);
			}
			if (module.HasCustomAttributes)
			{
				global::Mono.Cecil.ImmediateModuleReader.Read(module.CustomAttributes);
			}
			global::Mono.Cecil.AssemblyDefinition assembly = module.Assembly;
			if (assembly == null)
			{
				return;
			}
			if (assembly.HasCustomAttributes)
			{
				global::Mono.Cecil.ImmediateModuleReader.Read(assembly.CustomAttributes);
			}
			if (assembly.HasSecurityDeclarations)
			{
				global::Mono.Cecil.ImmediateModuleReader.Read(assembly.SecurityDeclarations);
			}
		}

		// Token: 0x060008F7 RID: 2295 RVA: 0x00019DCC File Offset: 0x00017FCC
		private static void ReadTypes(global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeDefinition> types)
		{
			for (int i = 0; i < types.Count; i++)
			{
				global::Mono.Cecil.ImmediateModuleReader.ReadType(types[i]);
			}
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x00019DF8 File Offset: 0x00017FF8
		private static void ReadType(global::Mono.Cecil.TypeDefinition type)
		{
			global::Mono.Cecil.ImmediateModuleReader.ReadGenericParameters(type);
			if (type.HasInterfaces)
			{
				global::Mono.Cecil.ImmediateModuleReader.Read(type.Interfaces);
			}
			if (type.HasNestedTypes)
			{
				global::Mono.Cecil.ImmediateModuleReader.ReadTypes(type.NestedTypes);
			}
			if (type.HasLayoutInfo)
			{
				global::Mono.Cecil.ImmediateModuleReader.Read(type.ClassSize);
			}
			if (type.HasFields)
			{
				global::Mono.Cecil.ImmediateModuleReader.ReadFields(type);
			}
			if (type.HasMethods)
			{
				global::Mono.Cecil.ImmediateModuleReader.ReadMethods(type);
			}
			if (type.HasProperties)
			{
				global::Mono.Cecil.ImmediateModuleReader.ReadProperties(type);
			}
			if (type.HasEvents)
			{
				global::Mono.Cecil.ImmediateModuleReader.ReadEvents(type);
			}
			global::Mono.Cecil.ImmediateModuleReader.ReadSecurityDeclarations(type);
			global::Mono.Cecil.ImmediateModuleReader.ReadCustomAttributes(type);
		}

		// Token: 0x060008F9 RID: 2297 RVA: 0x00019E90 File Offset: 0x00018090
		private static void ReadGenericParameters(global::Mono.Cecil.IGenericParameterProvider provider)
		{
			if (!provider.HasGenericParameters)
			{
				return;
			}
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.GenericParameter> genericParameters = provider.GenericParameters;
			for (int i = 0; i < genericParameters.Count; i++)
			{
				global::Mono.Cecil.GenericParameter genericParameter = genericParameters[i];
				if (genericParameter.HasConstraints)
				{
					global::Mono.Cecil.ImmediateModuleReader.Read(genericParameter.Constraints);
				}
				if (genericParameter.HasCustomAttributes)
				{
					global::Mono.Cecil.ImmediateModuleReader.Read(genericParameter.CustomAttributes);
				}
			}
		}

		// Token: 0x060008FA RID: 2298 RVA: 0x00019EEC File Offset: 0x000180EC
		private static void ReadSecurityDeclarations(global::Mono.Cecil.ISecurityDeclarationProvider provider)
		{
			if (provider.HasSecurityDeclarations)
			{
				global::Mono.Cecil.ImmediateModuleReader.Read(provider.SecurityDeclarations);
			}
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x00019F01 File Offset: 0x00018101
		private static void ReadCustomAttributes(global::Mono.Cecil.ICustomAttributeProvider provider)
		{
			if (provider.HasCustomAttributes)
			{
				global::Mono.Cecil.ImmediateModuleReader.Read(provider.CustomAttributes);
			}
		}

		// Token: 0x060008FC RID: 2300 RVA: 0x00019F18 File Offset: 0x00018118
		private static void ReadFields(global::Mono.Cecil.TypeDefinition type)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.FieldDefinition> fields = type.Fields;
			for (int i = 0; i < fields.Count; i++)
			{
				global::Mono.Cecil.FieldDefinition fieldDefinition = fields[i];
				if (fieldDefinition.HasConstant)
				{
					global::Mono.Cecil.ImmediateModuleReader.Read(fieldDefinition.Constant);
				}
				if (fieldDefinition.HasLayoutInfo)
				{
					global::Mono.Cecil.ImmediateModuleReader.Read(fieldDefinition.Offset);
				}
				if (fieldDefinition.RVA > 0)
				{
					global::Mono.Cecil.ImmediateModuleReader.Read(fieldDefinition.InitialValue);
				}
				if (fieldDefinition.HasMarshalInfo)
				{
					global::Mono.Cecil.ImmediateModuleReader.Read(fieldDefinition.MarshalInfo);
				}
				global::Mono.Cecil.ImmediateModuleReader.ReadCustomAttributes(fieldDefinition);
			}
		}

		// Token: 0x060008FD RID: 2301 RVA: 0x00019FA0 File Offset: 0x000181A0
		private static void ReadMethods(global::Mono.Cecil.TypeDefinition type)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodDefinition> methods = type.Methods;
			for (int i = 0; i < methods.Count; i++)
			{
				global::Mono.Cecil.MethodDefinition methodDefinition = methods[i];
				global::Mono.Cecil.ImmediateModuleReader.ReadGenericParameters(methodDefinition);
				if (methodDefinition.HasParameters)
				{
					global::Mono.Cecil.ImmediateModuleReader.ReadParameters(methodDefinition);
				}
				if (methodDefinition.HasOverrides)
				{
					global::Mono.Cecil.ImmediateModuleReader.Read(methodDefinition.Overrides);
				}
				if (methodDefinition.IsPInvokeImpl)
				{
					global::Mono.Cecil.ImmediateModuleReader.Read(methodDefinition.PInvokeInfo);
				}
				global::Mono.Cecil.ImmediateModuleReader.ReadSecurityDeclarations(methodDefinition);
				global::Mono.Cecil.ImmediateModuleReader.ReadCustomAttributes(methodDefinition);
				global::Mono.Cecil.MethodReturnType methodReturnType = methodDefinition.MethodReturnType;
				if (methodReturnType.HasConstant)
				{
					global::Mono.Cecil.ImmediateModuleReader.Read(methodReturnType.Constant);
				}
				if (methodReturnType.HasMarshalInfo)
				{
					global::Mono.Cecil.ImmediateModuleReader.Read(methodReturnType.MarshalInfo);
				}
				global::Mono.Cecil.ImmediateModuleReader.ReadCustomAttributes(methodReturnType);
			}
		}

		// Token: 0x060008FE RID: 2302 RVA: 0x0001A04C File Offset: 0x0001824C
		private static void ReadParameters(global::Mono.Cecil.MethodDefinition method)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition> parameters = method.Parameters;
			for (int i = 0; i < parameters.Count; i++)
			{
				global::Mono.Cecil.ParameterDefinition parameterDefinition = parameters[i];
				if (parameterDefinition.HasConstant)
				{
					global::Mono.Cecil.ImmediateModuleReader.Read(parameterDefinition.Constant);
				}
				if (parameterDefinition.HasMarshalInfo)
				{
					global::Mono.Cecil.ImmediateModuleReader.Read(parameterDefinition.MarshalInfo);
				}
				global::Mono.Cecil.ImmediateModuleReader.ReadCustomAttributes(parameterDefinition);
			}
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x0001A0A8 File Offset: 0x000182A8
		private static void ReadProperties(global::Mono.Cecil.TypeDefinition type)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.PropertyDefinition> properties = type.Properties;
			for (int i = 0; i < properties.Count; i++)
			{
				global::Mono.Cecil.PropertyDefinition propertyDefinition = properties[i];
				global::Mono.Cecil.ImmediateModuleReader.Read(propertyDefinition.GetMethod);
				if (propertyDefinition.HasConstant)
				{
					global::Mono.Cecil.ImmediateModuleReader.Read(propertyDefinition.Constant);
				}
				global::Mono.Cecil.ImmediateModuleReader.ReadCustomAttributes(propertyDefinition);
			}
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x0001A0FC File Offset: 0x000182FC
		private static void ReadEvents(global::Mono.Cecil.TypeDefinition type)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.EventDefinition> events = type.Events;
			for (int i = 0; i < events.Count; i++)
			{
				global::Mono.Cecil.EventDefinition eventDefinition = events[i];
				global::Mono.Cecil.ImmediateModuleReader.Read(eventDefinition.AddMethod);
				global::Mono.Cecil.ImmediateModuleReader.ReadCustomAttributes(eventDefinition);
			}
		}

		// Token: 0x06000901 RID: 2305 RVA: 0x0001A13A File Offset: 0x0001833A
		private static void Read(object collection)
		{
		}

		// Token: 0x06000902 RID: 2306 RVA: 0x00019CEA File Offset: 0x00017EEA
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Mono.Cecil.ModuleDefinition <ReadModule>b__0(global::Mono.Cecil.ModuleDefinition module, global::Mono.Cecil.MetadataReader reader)
		{
			base.ReadModuleManifest(reader);
			global::Mono.Cecil.ImmediateModuleReader.ReadModule(module);
			return module;
		}
	}
}
