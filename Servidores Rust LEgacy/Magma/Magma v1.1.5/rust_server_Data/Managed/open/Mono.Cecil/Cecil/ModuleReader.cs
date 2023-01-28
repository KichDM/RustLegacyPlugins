using System;
using Mono.Cecil.Cil;
using Mono.Cecil.PE;

namespace Mono.Cecil
{
	// Token: 0x020000F1 RID: 241
	internal abstract class ModuleReader
	{
		// Token: 0x060008EC RID: 2284 RVA: 0x00019B69 File Offset: 0x00017D69
		protected ModuleReader(global::Mono.Cecil.PE.Image image, global::Mono.Cecil.ReadingMode mode)
		{
			this.image = image;
			this.module = new global::Mono.Cecil.ModuleDefinition(image);
			this.module.ReadingMode = mode;
		}

		// Token: 0x060008ED RID: 2285
		protected abstract void ReadModule();

		// Token: 0x060008EE RID: 2286 RVA: 0x00019B90 File Offset: 0x00017D90
		protected void ReadModuleManifest(global::Mono.Cecil.MetadataReader reader)
		{
			reader.Populate(this.module);
			this.ReadAssembly(reader);
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x00019BA8 File Offset: 0x00017DA8
		private void ReadAssembly(global::Mono.Cecil.MetadataReader reader)
		{
			global::Mono.Cecil.AssemblyNameDefinition assemblyNameDefinition = reader.ReadAssemblyNameDefinition();
			if (assemblyNameDefinition == null)
			{
				this.module.kind = global::Mono.Cecil.ModuleKind.NetModule;
				return;
			}
			global::Mono.Cecil.AssemblyDefinition assemblyDefinition = new global::Mono.Cecil.AssemblyDefinition();
			assemblyDefinition.Name = assemblyNameDefinition;
			this.module.assembly = assemblyDefinition;
			assemblyDefinition.main_module = this.module;
		}

		// Token: 0x060008F0 RID: 2288 RVA: 0x00019BF4 File Offset: 0x00017DF4
		public static global::Mono.Cecil.ModuleDefinition CreateModuleFrom(global::Mono.Cecil.PE.Image image, global::Mono.Cecil.ReaderParameters parameters)
		{
			global::Mono.Cecil.ModuleDefinition moduleDefinition = global::Mono.Cecil.ModuleReader.ReadModule(image, parameters);
			global::Mono.Cecil.ModuleReader.ReadSymbols(moduleDefinition, parameters);
			if (parameters.AssemblyResolver != null)
			{
				moduleDefinition.assembly_resolver = parameters.AssemblyResolver;
			}
			return moduleDefinition;
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x00019C28 File Offset: 0x00017E28
		private static void ReadSymbols(global::Mono.Cecil.ModuleDefinition module, global::Mono.Cecil.ReaderParameters parameters)
		{
			global::Mono.Cecil.Cil.ISymbolReaderProvider symbolReaderProvider = parameters.SymbolReaderProvider;
			if (symbolReaderProvider == null && parameters.ReadSymbols)
			{
				symbolReaderProvider = global::Mono.Cecil.Cil.SymbolProvider.GetPlatformReaderProvider();
			}
			if (symbolReaderProvider != null)
			{
				module.SymbolReaderProvider = symbolReaderProvider;
				global::Mono.Cecil.Cil.ISymbolReader reader = (parameters.SymbolStream != null) ? symbolReaderProvider.GetSymbolReader(module, parameters.SymbolStream) : symbolReaderProvider.GetSymbolReader(module, module.FullyQualifiedName);
				module.ReadSymbols(reader);
			}
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x00019C84 File Offset: 0x00017E84
		private static global::Mono.Cecil.ModuleDefinition ReadModule(global::Mono.Cecil.PE.Image image, global::Mono.Cecil.ReaderParameters parameters)
		{
			global::Mono.Cecil.ModuleReader moduleReader = global::Mono.Cecil.ModuleReader.CreateModuleReader(image, parameters.ReadingMode);
			moduleReader.ReadModule();
			return moduleReader.module;
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x00019CAC File Offset: 0x00017EAC
		private static global::Mono.Cecil.ModuleReader CreateModuleReader(global::Mono.Cecil.PE.Image image, global::Mono.Cecil.ReadingMode mode)
		{
			switch (mode)
			{
			case global::Mono.Cecil.ReadingMode.Immediate:
				return new global::Mono.Cecil.ImmediateModuleReader(image);
			case global::Mono.Cecil.ReadingMode.Deferred:
				return new global::Mono.Cecil.DeferredModuleReader(image);
			default:
				throw new global::System.ArgumentException();
			}
		}

		// Token: 0x0400060B RID: 1547
		protected readonly global::Mono.Cecil.PE.Image image;

		// Token: 0x0400060C RID: 1548
		protected readonly global::Mono.Cecil.ModuleDefinition module;
	}
}
