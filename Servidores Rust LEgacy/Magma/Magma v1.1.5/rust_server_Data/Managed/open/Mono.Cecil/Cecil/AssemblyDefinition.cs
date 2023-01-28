using System;
using System.IO;
using System.Runtime.CompilerServices;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x020000C4 RID: 196
	public sealed class AssemblyDefinition : global::Mono.Cecil.ICustomAttributeProvider, global::Mono.Cecil.ISecurityDeclarationProvider, global::Mono.Cecil.IMetadataTokenProvider
	{
		// Token: 0x170002AD RID: 685
		// (get) Token: 0x060007E2 RID: 2018 RVA: 0x00015654 File Offset: 0x00013854
		// (set) Token: 0x060007E3 RID: 2019 RVA: 0x0001565C File Offset: 0x0001385C
		public global::Mono.Cecil.AssemblyNameDefinition Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

		// Token: 0x170002AE RID: 686
		// (get) Token: 0x060007E4 RID: 2020 RVA: 0x00015665 File Offset: 0x00013865
		public string FullName
		{
			get
			{
				if (this.name == null)
				{
					return string.Empty;
				}
				return this.name.FullName;
			}
		}

		// Token: 0x170002AF RID: 687
		// (get) Token: 0x060007E5 RID: 2021 RVA: 0x00015680 File Offset: 0x00013880
		// (set) Token: 0x060007E6 RID: 2022 RVA: 0x0001568D File Offset: 0x0001388D
		public global::Mono.Cecil.MetadataToken MetadataToken
		{
			get
			{
				return new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.Assembly, 1);
			}
			set
			{
			}
		}

		// Token: 0x170002B0 RID: 688
		// (get) Token: 0x060007E7 RID: 2023 RVA: 0x00015698 File Offset: 0x00013898
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ModuleDefinition> Modules
		{
			get
			{
				if (this.modules != null)
				{
					return this.modules;
				}
				if (this.main_module.HasImage)
				{
					return this.modules = this.main_module.Read<global::Mono.Cecil.AssemblyDefinition, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ModuleDefinition>>(this, (global::Mono.Cecil.AssemblyDefinition _, global::Mono.Cecil.MetadataReader reader) => reader.ReadModules());
				}
				return this.modules = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ModuleDefinition>(1)
				{
					this.main_module
				};
			}
		}

		// Token: 0x170002B1 RID: 689
		// (get) Token: 0x060007E8 RID: 2024 RVA: 0x00015711 File Offset: 0x00013911
		public global::Mono.Cecil.ModuleDefinition MainModule
		{
			get
			{
				return this.main_module;
			}
		}

		// Token: 0x170002B2 RID: 690
		// (get) Token: 0x060007E9 RID: 2025 RVA: 0x00015719 File Offset: 0x00013919
		// (set) Token: 0x060007EA RID: 2026 RVA: 0x00015726 File Offset: 0x00013926
		public global::Mono.Cecil.MethodDefinition EntryPoint
		{
			get
			{
				return this.main_module.EntryPoint;
			}
			set
			{
				this.main_module.EntryPoint = value;
			}
		}

		// Token: 0x170002B3 RID: 691
		// (get) Token: 0x060007EB RID: 2027 RVA: 0x00015734 File Offset: 0x00013934
		public bool HasCustomAttributes
		{
			get
			{
				if (this.custom_attributes != null)
				{
					return this.custom_attributes.Count > 0;
				}
				return this.GetHasCustomAttributes(this.main_module);
			}
		}

		// Token: 0x170002B4 RID: 692
		// (get) Token: 0x060007EC RID: 2028 RVA: 0x0001575C File Offset: 0x0001395C
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> CustomAttributes
		{
			get
			{
				global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> result;
				if ((result = this.custom_attributes) == null)
				{
					result = (this.custom_attributes = this.GetCustomAttributes(this.main_module));
				}
				return result;
			}
		}

		// Token: 0x170002B5 RID: 693
		// (get) Token: 0x060007ED RID: 2029 RVA: 0x00015788 File Offset: 0x00013988
		public bool HasSecurityDeclarations
		{
			get
			{
				if (this.security_declarations != null)
				{
					return this.security_declarations.Count > 0;
				}
				return this.GetHasSecurityDeclarations(this.main_module);
			}
		}

		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x060007EE RID: 2030 RVA: 0x000157B0 File Offset: 0x000139B0
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityDeclaration> SecurityDeclarations
		{
			get
			{
				global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityDeclaration> result;
				if ((result = this.security_declarations) == null)
				{
					result = (this.security_declarations = this.GetSecurityDeclarations(this.main_module));
				}
				return result;
			}
		}

		// Token: 0x060007EF RID: 2031 RVA: 0x000157DC File Offset: 0x000139DC
		internal AssemblyDefinition()
		{
		}

		// Token: 0x060007F0 RID: 2032 RVA: 0x000157E4 File Offset: 0x000139E4
		public static global::Mono.Cecil.AssemblyDefinition CreateAssembly(global::Mono.Cecil.AssemblyNameDefinition assemblyName, string moduleName, global::Mono.Cecil.ModuleKind kind)
		{
			return global::Mono.Cecil.AssemblyDefinition.CreateAssembly(assemblyName, moduleName, new global::Mono.Cecil.ModuleParameters
			{
				Kind = kind
			});
		}

		// Token: 0x060007F1 RID: 2033 RVA: 0x00015808 File Offset: 0x00013A08
		public static global::Mono.Cecil.AssemblyDefinition CreateAssembly(global::Mono.Cecil.AssemblyNameDefinition assemblyName, string moduleName, global::Mono.Cecil.ModuleParameters parameters)
		{
			if (assemblyName == null)
			{
				throw new global::System.ArgumentNullException("assemblyName");
			}
			if (moduleName == null)
			{
				throw new global::System.ArgumentNullException("moduleName");
			}
			global::Mono.Cecil.Mixin.CheckParameters(parameters);
			if (parameters.Kind == global::Mono.Cecil.ModuleKind.NetModule)
			{
				throw new global::System.ArgumentException("kind");
			}
			global::Mono.Cecil.AssemblyDefinition assembly = global::Mono.Cecil.ModuleDefinition.CreateModule(moduleName, parameters).Assembly;
			assembly.Name = assemblyName;
			return assembly;
		}

		// Token: 0x060007F2 RID: 2034 RVA: 0x00015860 File Offset: 0x00013A60
		public static global::Mono.Cecil.AssemblyDefinition ReadAssembly(string fileName)
		{
			return global::Mono.Cecil.AssemblyDefinition.ReadAssembly(global::Mono.Cecil.ModuleDefinition.ReadModule(fileName));
		}

		// Token: 0x060007F3 RID: 2035 RVA: 0x0001586D File Offset: 0x00013A6D
		public static global::Mono.Cecil.AssemblyDefinition ReadAssembly(string fileName, global::Mono.Cecil.ReaderParameters parameters)
		{
			return global::Mono.Cecil.AssemblyDefinition.ReadAssembly(global::Mono.Cecil.ModuleDefinition.ReadModule(fileName, parameters));
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x0001587B File Offset: 0x00013A7B
		public static global::Mono.Cecil.AssemblyDefinition ReadAssembly(global::System.IO.Stream stream)
		{
			return global::Mono.Cecil.AssemblyDefinition.ReadAssembly(global::Mono.Cecil.ModuleDefinition.ReadModule(stream));
		}

		// Token: 0x060007F5 RID: 2037 RVA: 0x00015888 File Offset: 0x00013A88
		public static global::Mono.Cecil.AssemblyDefinition ReadAssembly(global::System.IO.Stream stream, global::Mono.Cecil.ReaderParameters parameters)
		{
			return global::Mono.Cecil.AssemblyDefinition.ReadAssembly(global::Mono.Cecil.ModuleDefinition.ReadModule(stream, parameters));
		}

		// Token: 0x060007F6 RID: 2038 RVA: 0x00015898 File Offset: 0x00013A98
		private static global::Mono.Cecil.AssemblyDefinition ReadAssembly(global::Mono.Cecil.ModuleDefinition module)
		{
			global::Mono.Cecil.AssemblyDefinition assembly = module.Assembly;
			if (assembly == null)
			{
				throw new global::System.ArgumentException();
			}
			return assembly;
		}

		// Token: 0x060007F7 RID: 2039 RVA: 0x000158B6 File Offset: 0x00013AB6
		public void Write(string fileName)
		{
			this.Write(fileName, new global::Mono.Cecil.WriterParameters());
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x000158C4 File Offset: 0x00013AC4
		public void Write(global::System.IO.Stream stream)
		{
			this.Write(stream, new global::Mono.Cecil.WriterParameters());
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x000158D2 File Offset: 0x00013AD2
		public void Write(string fileName, global::Mono.Cecil.WriterParameters parameters)
		{
			this.main_module.Write(fileName, parameters);
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x000158E1 File Offset: 0x00013AE1
		public void Write(global::System.IO.Stream stream, global::Mono.Cecil.WriterParameters parameters)
		{
			this.main_module.Write(stream, parameters);
		}

		// Token: 0x060007FB RID: 2043 RVA: 0x000158F0 File Offset: 0x00013AF0
		public override string ToString()
		{
			return this.FullName;
		}

		// Token: 0x060007FC RID: 2044 RVA: 0x0001568F File Offset: 0x0001388F
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ModuleDefinition> <get_Modules>b__1(global::Mono.Cecil.AssemblyDefinition _, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadModules();
		}

		// Token: 0x040005D3 RID: 1491
		private global::Mono.Cecil.AssemblyNameDefinition name;

		// Token: 0x040005D4 RID: 1492
		internal global::Mono.Cecil.ModuleDefinition main_module;

		// Token: 0x040005D5 RID: 1493
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ModuleDefinition> modules;

		// Token: 0x040005D6 RID: 1494
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> custom_attributes;

		// Token: 0x040005D7 RID: 1495
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityDeclaration> security_declarations;

		// Token: 0x040005D8 RID: 1496
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.AssemblyDefinition, global::Mono.Cecil.MetadataReader, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ModuleDefinition>> CS$<>9__CachedAnonymousMethodDelegate2;
	}
}
