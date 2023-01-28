using System;
using System.IO;
using System.Reflection;

namespace Mono.Cecil.Cil
{
	// Token: 0x02000041 RID: 65
	internal static class SymbolProvider
	{
		// Token: 0x06000341 RID: 833 RVA: 0x00009290 File Offset: 0x00007490
		private static global::System.Reflection.AssemblyName GetPlatformSymbolAssemblyName()
		{
			global::System.Reflection.AssemblyName name = typeof(global::Mono.Cecil.Cil.SymbolProvider).Assembly.GetName();
			global::System.Reflection.AssemblyName assemblyName = new global::System.Reflection.AssemblyName
			{
				Name = "Mono.Cecil." + global::Mono.Cecil.Cil.SymbolProvider.symbol_kind,
				Version = name.Version
			};
			assemblyName.SetPublicKeyToken(name.GetPublicKeyToken());
			return assemblyName;
		}

		// Token: 0x06000342 RID: 834 RVA: 0x000092E8 File Offset: 0x000074E8
		private static global::System.Type GetPlatformType(string fullname)
		{
			global::System.Type type = global::System.Type.GetType(fullname);
			if (type != null)
			{
				return type;
			}
			global::System.Reflection.AssemblyName platformSymbolAssemblyName = global::Mono.Cecil.Cil.SymbolProvider.GetPlatformSymbolAssemblyName();
			type = global::System.Type.GetType(fullname + ", " + platformSymbolAssemblyName.FullName);
			if (type != null)
			{
				return type;
			}
			try
			{
				global::System.Reflection.Assembly assembly = global::System.Reflection.Assembly.Load(platformSymbolAssemblyName);
				if (assembly != null)
				{
					return assembly.GetType(fullname);
				}
			}
			catch (global::System.IO.FileNotFoundException)
			{
			}
			catch (global::System.IO.FileLoadException)
			{
			}
			return null;
		}

		// Token: 0x06000343 RID: 835 RVA: 0x00009360 File Offset: 0x00007560
		public static global::Mono.Cecil.Cil.ISymbolReaderProvider GetPlatformReaderProvider()
		{
			if (global::Mono.Cecil.Cil.SymbolProvider.reader_provider != null)
			{
				return global::Mono.Cecil.Cil.SymbolProvider.reader_provider;
			}
			global::System.Type platformType = global::Mono.Cecil.Cil.SymbolProvider.GetPlatformType(global::Mono.Cecil.Cil.SymbolProvider.GetProviderTypeName("ReaderProvider"));
			if (platformType == null)
			{
				return null;
			}
			return global::Mono.Cecil.Cil.SymbolProvider.reader_provider = (global::Mono.Cecil.Cil.ISymbolReaderProvider)global::System.Activator.CreateInstance(platformType);
		}

		// Token: 0x06000344 RID: 836 RVA: 0x000093A0 File Offset: 0x000075A0
		private static string GetProviderTypeName(string name)
		{
			return string.Concat(new string[]
			{
				"Mono.Cecil.",
				global::Mono.Cecil.Cil.SymbolProvider.symbol_kind,
				".",
				global::Mono.Cecil.Cil.SymbolProvider.symbol_kind,
				name
			});
		}

		// Token: 0x06000345 RID: 837 RVA: 0x000093E0 File Offset: 0x000075E0
		public static global::Mono.Cecil.Cil.ISymbolWriterProvider GetPlatformWriterProvider()
		{
			if (global::Mono.Cecil.Cil.SymbolProvider.writer_provider != null)
			{
				return global::Mono.Cecil.Cil.SymbolProvider.writer_provider;
			}
			global::System.Type platformType = global::Mono.Cecil.Cil.SymbolProvider.GetPlatformType(global::Mono.Cecil.Cil.SymbolProvider.GetProviderTypeName("WriterProvider"));
			if (platformType == null)
			{
				return null;
			}
			return global::Mono.Cecil.Cil.SymbolProvider.writer_provider = (global::Mono.Cecil.Cil.ISymbolWriterProvider)global::System.Activator.CreateInstance(platformType);
		}

		// Token: 0x06000346 RID: 838 RVA: 0x00009420 File Offset: 0x00007620
		// Note: this type is marked as 'beforefieldinit'.
		static SymbolProvider()
		{
		}

		// Token: 0x0400021C RID: 540
		private static readonly string symbol_kind = (global::System.Type.GetType("Mono.Runtime") != null) ? "Mdb" : "Pdb";

		// Token: 0x0400021D RID: 541
		private static global::Mono.Cecil.Cil.ISymbolReaderProvider reader_provider;

		// Token: 0x0400021E RID: 542
		private static global::Mono.Cecil.Cil.ISymbolWriterProvider writer_provider;
	}
}
