using System;
using System.IO;
using System.Runtime.CompilerServices;
using Mono.Cecil.Cil;
using Mono.Cecil.PE;

namespace Mono.Cecil
{
	// Token: 0x020000C7 RID: 199
	internal static class ModuleWriter
	{
		// Token: 0x0600080F RID: 2063 RVA: 0x00015E9C File Offset: 0x0001409C
		public static void WriteModuleTo(global::Mono.Cecil.ModuleDefinition module, global::System.IO.Stream stream, global::Mono.Cecil.WriterParameters parameters)
		{
			if ((module.Attributes & global::Mono.Cecil.ModuleAttributes.ILOnly) == (global::Mono.Cecil.ModuleAttributes)0)
			{
				throw new global::System.ArgumentException();
			}
			if (module.HasImage && module.ReadingMode == global::Mono.Cecil.ReadingMode.Deferred)
			{
				global::Mono.Cecil.ImmediateModuleReader.ReadModule(module);
			}
			module.MetadataSystem.Clear();
			global::Mono.Cecil.AssemblyNameDefinition assemblyNameDefinition = (module.assembly != null) ? module.assembly.Name : null;
			string fullyQualifiedName = stream.GetFullyQualifiedName();
			global::Mono.Cecil.Cil.ISymbolWriterProvider symbolWriterProvider = parameters.SymbolWriterProvider;
			if (symbolWriterProvider == null && parameters.WriteSymbols)
			{
				symbolWriterProvider = global::Mono.Cecil.Cil.SymbolProvider.GetPlatformWriterProvider();
			}
			global::Mono.Cecil.Cil.ISymbolWriter symbolWriter = global::Mono.Cecil.ModuleWriter.GetSymbolWriter(module, fullyQualifiedName, symbolWriterProvider);
			if (parameters.StrongNameKeyPair != null && assemblyNameDefinition != null)
			{
				assemblyNameDefinition.PublicKey = parameters.StrongNameKeyPair.PublicKey;
			}
			if (assemblyNameDefinition != null && assemblyNameDefinition.HasPublicKey)
			{
				module.Attributes |= global::Mono.Cecil.ModuleAttributes.StrongNameSigned;
			}
			global::Mono.Cecil.MetadataBuilder metadata = new global::Mono.Cecil.MetadataBuilder(module, fullyQualifiedName, symbolWriterProvider, symbolWriter);
			global::Mono.Cecil.ModuleWriter.BuildMetadata(module, metadata);
			if (module.SymbolReader != null)
			{
				module.SymbolReader.Dispose();
			}
			global::Mono.Cecil.PE.ImageWriter imageWriter = global::Mono.Cecil.PE.ImageWriter.CreateWriter(module, metadata, stream);
			imageWriter.WriteImage();
			if (parameters.StrongNameKeyPair != null)
			{
				global::Mono.Cecil.CryptoService.StrongName(stream, imageWriter, parameters.StrongNameKeyPair);
			}
			if (symbolWriter != null)
			{
				symbolWriter.Dispose();
			}
		}

		// Token: 0x06000810 RID: 2064 RVA: 0x00015FAF File Offset: 0x000141AF
		private static void BuildMetadata(global::Mono.Cecil.ModuleDefinition module, global::Mono.Cecil.MetadataBuilder metadata)
		{
			if (!module.HasImage)
			{
				metadata.BuildMetadata();
				return;
			}
			module.Read<global::Mono.Cecil.MetadataBuilder, global::Mono.Cecil.MetadataBuilder>(metadata, delegate(global::Mono.Cecil.MetadataBuilder builder, global::Mono.Cecil.MetadataReader _)
			{
				builder.BuildMetadata();
				return builder;
			});
		}

		// Token: 0x06000811 RID: 2065 RVA: 0x00015FE5 File Offset: 0x000141E5
		private static global::Mono.Cecil.Cil.ISymbolWriter GetSymbolWriter(global::Mono.Cecil.ModuleDefinition module, string fq_name, global::Mono.Cecil.Cil.ISymbolWriterProvider symbol_writer_provider)
		{
			if (symbol_writer_provider == null)
			{
				return null;
			}
			return symbol_writer_provider.GetSymbolWriter(module, fq_name);
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x00015FA6 File Offset: 0x000141A6
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Cecil.MetadataBuilder <BuildMetadata>b__0(global::Mono.Cecil.MetadataBuilder builder, global::Mono.Cecil.MetadataReader _)
		{
			builder.BuildMetadata();
			return builder;
		}

		// Token: 0x040005DA RID: 1498
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.MetadataBuilder, global::Mono.Cecil.MetadataReader, global::Mono.Cecil.MetadataBuilder> CS$<>9__CachedAnonymousMethodDelegate1;
	}
}
