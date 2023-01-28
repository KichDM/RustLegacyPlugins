using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x02000074 RID: 116
	public abstract class BaseAssemblyResolver : global::Mono.Cecil.IAssemblyResolver
	{
		// Token: 0x060004F9 RID: 1273 RVA: 0x0000BC2F File Offset: 0x00009E2F
		public void AddSearchDirectory(string directory)
		{
			this.directories.Add(directory);
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x0000BC3D File Offset: 0x00009E3D
		public void RemoveSearchDirectory(string directory)
		{
			this.directories.Remove(directory);
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x0000BC4C File Offset: 0x00009E4C
		public string[] GetSearchDirectories()
		{
			string[] array = new string[this.directories.size];
			global::System.Array.Copy(this.directories.items, array, array.Length);
			return array;
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x0000BC7F File Offset: 0x00009E7F
		public virtual global::Mono.Cecil.AssemblyDefinition Resolve(string fullName)
		{
			return this.Resolve(fullName, new global::Mono.Cecil.ReaderParameters());
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x0000BC8D File Offset: 0x00009E8D
		public virtual global::Mono.Cecil.AssemblyDefinition Resolve(string fullName, global::Mono.Cecil.ReaderParameters parameters)
		{
			if (fullName == null)
			{
				throw new global::System.ArgumentNullException("fullName");
			}
			return this.Resolve(global::Mono.Cecil.AssemblyNameReference.Parse(fullName), parameters);
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060004FE RID: 1278 RVA: 0x0000BCAC File Offset: 0x00009EAC
		// (remove) Token: 0x060004FF RID: 1279 RVA: 0x0000BCE4 File Offset: 0x00009EE4
		public event global::Mono.Cecil.AssemblyResolveEventHandler ResolveFailure
		{
			add
			{
				global::Mono.Cecil.AssemblyResolveEventHandler assemblyResolveEventHandler = this.ResolveFailure;
				global::Mono.Cecil.AssemblyResolveEventHandler assemblyResolveEventHandler2;
				do
				{
					assemblyResolveEventHandler2 = assemblyResolveEventHandler;
					global::Mono.Cecil.AssemblyResolveEventHandler value2 = (global::Mono.Cecil.AssemblyResolveEventHandler)global::System.Delegate.Combine(assemblyResolveEventHandler2, value);
					assemblyResolveEventHandler = global::System.Threading.Interlocked.CompareExchange<global::Mono.Cecil.AssemblyResolveEventHandler>(ref this.ResolveFailure, value2, assemblyResolveEventHandler2);
				}
				while (assemblyResolveEventHandler != assemblyResolveEventHandler2);
			}
			remove
			{
				global::Mono.Cecil.AssemblyResolveEventHandler assemblyResolveEventHandler = this.ResolveFailure;
				global::Mono.Cecil.AssemblyResolveEventHandler assemblyResolveEventHandler2;
				do
				{
					assemblyResolveEventHandler2 = assemblyResolveEventHandler;
					global::Mono.Cecil.AssemblyResolveEventHandler value2 = (global::Mono.Cecil.AssemblyResolveEventHandler)global::System.Delegate.Remove(assemblyResolveEventHandler2, value);
					assemblyResolveEventHandler = global::System.Threading.Interlocked.CompareExchange<global::Mono.Cecil.AssemblyResolveEventHandler>(ref this.ResolveFailure, value2, assemblyResolveEventHandler2);
				}
				while (assemblyResolveEventHandler != assemblyResolveEventHandler2);
			}
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x0000BD1C File Offset: 0x00009F1C
		protected BaseAssemblyResolver()
		{
			this.directories = new global::Mono.Collections.Generic.Collection<string>(2)
			{
				".",
				"bin"
			};
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x0000BD53 File Offset: 0x00009F53
		private global::Mono.Cecil.AssemblyDefinition GetAssembly(string file, global::Mono.Cecil.ReaderParameters parameters)
		{
			if (parameters.AssemblyResolver == null)
			{
				parameters.AssemblyResolver = this;
			}
			return global::Mono.Cecil.ModuleDefinition.ReadModule(file, parameters).Assembly;
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x0000BD70 File Offset: 0x00009F70
		public virtual global::Mono.Cecil.AssemblyDefinition Resolve(global::Mono.Cecil.AssemblyNameReference name)
		{
			return this.Resolve(name, new global::Mono.Cecil.ReaderParameters());
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x0000BD80 File Offset: 0x00009F80
		public virtual global::Mono.Cecil.AssemblyDefinition Resolve(global::Mono.Cecil.AssemblyNameReference name, global::Mono.Cecil.ReaderParameters parameters)
		{
			if (name == null)
			{
				throw new global::System.ArgumentNullException("name");
			}
			if (parameters == null)
			{
				parameters = new global::Mono.Cecil.ReaderParameters();
			}
			global::Mono.Cecil.AssemblyDefinition assemblyDefinition = this.SearchDirectory(name, this.directories, parameters);
			if (assemblyDefinition != null)
			{
				return assemblyDefinition;
			}
			string directoryName = global::System.IO.Path.GetDirectoryName(typeof(object).Module.FullyQualifiedName);
			if (global::Mono.Cecil.BaseAssemblyResolver.IsZero(name.Version))
			{
				assemblyDefinition = this.SearchDirectory(name, new string[]
				{
					directoryName
				}, parameters);
				if (assemblyDefinition != null)
				{
					return assemblyDefinition;
				}
			}
			if (name.Name == "mscorlib")
			{
				assemblyDefinition = this.GetCorlib(name, parameters);
				if (assemblyDefinition != null)
				{
					return assemblyDefinition;
				}
			}
			assemblyDefinition = this.GetAssemblyInGac(name, parameters);
			if (assemblyDefinition != null)
			{
				return assemblyDefinition;
			}
			assemblyDefinition = this.SearchDirectory(name, new string[]
			{
				directoryName
			}, parameters);
			if (assemblyDefinition != null)
			{
				return assemblyDefinition;
			}
			if (this.ResolveFailure != null)
			{
				assemblyDefinition = this.ResolveFailure(this, name);
				if (assemblyDefinition != null)
				{
					return assemblyDefinition;
				}
			}
			throw new global::Mono.Cecil.AssemblyResolutionException(name);
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x0000BE64 File Offset: 0x0000A064
		private global::Mono.Cecil.AssemblyDefinition SearchDirectory(global::Mono.Cecil.AssemblyNameReference name, global::System.Collections.Generic.IEnumerable<string> directories, global::Mono.Cecil.ReaderParameters parameters)
		{
			string[] array = new string[]
			{
				".exe",
				".dll"
			};
			foreach (string path in directories)
			{
				foreach (string str in array)
				{
					string text = global::System.IO.Path.Combine(path, name.Name + str);
					if (global::System.IO.File.Exists(text))
					{
						return this.GetAssembly(text, parameters);
					}
				}
			}
			return null;
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x0000BF10 File Offset: 0x0000A110
		private static bool IsZero(global::System.Version version)
		{
			return version == null || (version.Major == 0 && version.Minor == 0 && version.Build == 0 && version.Revision == 0);
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x0000BF40 File Offset: 0x0000A140
		private global::Mono.Cecil.AssemblyDefinition GetCorlib(global::Mono.Cecil.AssemblyNameReference reference, global::Mono.Cecil.ReaderParameters parameters)
		{
			global::System.Version version = reference.Version;
			global::System.Reflection.AssemblyName name = typeof(object).Assembly.GetName();
			if (name.Version == version || global::Mono.Cecil.BaseAssemblyResolver.IsZero(version))
			{
				return this.GetAssembly(typeof(object).Module.FullyQualifiedName, parameters);
			}
			string path = global::System.IO.Directory.GetParent(global::System.IO.Directory.GetParent(typeof(object).Module.FullyQualifiedName).FullName).FullName;
			if (!global::Mono.Cecil.BaseAssemblyResolver.on_mono)
			{
				switch (version.Major)
				{
				case 1:
					if (version.MajorRevision == 0xCE4)
					{
						path = global::System.IO.Path.Combine(path, "v1.0.3705");
						goto IL_170;
					}
					path = global::System.IO.Path.Combine(path, "v1.0.5000.0");
					goto IL_170;
				case 2:
					path = global::System.IO.Path.Combine(path, "v2.0.50727");
					goto IL_170;
				case 4:
					path = global::System.IO.Path.Combine(path, "v4.0.30319");
					goto IL_170;
				}
				throw new global::System.NotSupportedException("Version not supported: " + version);
			}
			if (version.Major == 1)
			{
				path = global::System.IO.Path.Combine(path, "1.0");
			}
			else if (version.Major == 2)
			{
				if (version.MajorRevision == 5)
				{
					path = global::System.IO.Path.Combine(path, "2.1");
				}
				else
				{
					path = global::System.IO.Path.Combine(path, "2.0");
				}
			}
			else
			{
				if (version.Major != 4)
				{
					throw new global::System.NotSupportedException("Version not supported: " + version);
				}
				path = global::System.IO.Path.Combine(path, "4.0");
			}
			IL_170:
			string text = global::System.IO.Path.Combine(path, "mscorlib.dll");
			if (global::System.IO.File.Exists(text))
			{
				return this.GetAssembly(text, parameters);
			}
			return null;
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x0000C0DC File Offset: 0x0000A2DC
		private static global::Mono.Collections.Generic.Collection<string> GetGacPaths()
		{
			if (global::Mono.Cecil.BaseAssemblyResolver.on_mono)
			{
				return global::Mono.Cecil.BaseAssemblyResolver.GetDefaultMonoGacPaths();
			}
			global::Mono.Collections.Generic.Collection<string> collection = new global::Mono.Collections.Generic.Collection<string>(2);
			string environmentVariable = global::System.Environment.GetEnvironmentVariable("WINDIR");
			if (environmentVariable == null)
			{
				return collection;
			}
			collection.Add(global::System.IO.Path.Combine(environmentVariable, "assembly"));
			collection.Add(global::System.IO.Path.Combine(environmentVariable, global::System.IO.Path.Combine("Microsoft.NET", "assembly")));
			return collection;
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x0000C13C File Offset: 0x0000A33C
		private static global::Mono.Collections.Generic.Collection<string> GetDefaultMonoGacPaths()
		{
			global::Mono.Collections.Generic.Collection<string> collection = new global::Mono.Collections.Generic.Collection<string>(1);
			string currentMonoGac = global::Mono.Cecil.BaseAssemblyResolver.GetCurrentMonoGac();
			if (currentMonoGac != null)
			{
				collection.Add(currentMonoGac);
			}
			string environmentVariable = global::System.Environment.GetEnvironmentVariable("MONO_GAC_PREFIX");
			if (string.IsNullOrEmpty(environmentVariable))
			{
				return collection;
			}
			string[] array = environmentVariable.Split(new char[]
			{
				global::System.IO.Path.PathSeparator
			});
			foreach (string text in array)
			{
				if (!string.IsNullOrEmpty(text))
				{
					string text2 = global::System.IO.Path.Combine(global::System.IO.Path.Combine(global::System.IO.Path.Combine(text, "lib"), "mono"), "gac");
					if (global::System.IO.Directory.Exists(text2) && !collection.Contains(currentMonoGac))
					{
						collection.Add(text2);
					}
				}
			}
			return collection;
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x0000C1F2 File Offset: 0x0000A3F2
		private static string GetCurrentMonoGac()
		{
			return global::System.IO.Path.Combine(global::System.IO.Directory.GetParent(global::System.IO.Path.GetDirectoryName(typeof(object).Module.FullyQualifiedName)).FullName, "gac");
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x0000C224 File Offset: 0x0000A424
		private global::Mono.Cecil.AssemblyDefinition GetAssemblyInGac(global::Mono.Cecil.AssemblyNameReference reference, global::Mono.Cecil.ReaderParameters parameters)
		{
			if (reference.PublicKeyToken == null || reference.PublicKeyToken.Length == 0)
			{
				return null;
			}
			if (this.gac_paths == null)
			{
				this.gac_paths = global::Mono.Cecil.BaseAssemblyResolver.GetGacPaths();
			}
			if (global::Mono.Cecil.BaseAssemblyResolver.on_mono)
			{
				return this.GetAssemblyInMonoGac(reference, parameters);
			}
			return this.GetAssemblyInNetGac(reference, parameters);
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x0000C270 File Offset: 0x0000A470
		private global::Mono.Cecil.AssemblyDefinition GetAssemblyInMonoGac(global::Mono.Cecil.AssemblyNameReference reference, global::Mono.Cecil.ReaderParameters parameters)
		{
			for (int i = 0; i < this.gac_paths.Count; i++)
			{
				string gac = this.gac_paths[i];
				string assemblyFile = global::Mono.Cecil.BaseAssemblyResolver.GetAssemblyFile(reference, string.Empty, gac);
				if (global::System.IO.File.Exists(assemblyFile))
				{
					return this.GetAssembly(assemblyFile, parameters);
				}
			}
			return null;
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x0000C2C0 File Offset: 0x0000A4C0
		private global::Mono.Cecil.AssemblyDefinition GetAssemblyInNetGac(global::Mono.Cecil.AssemblyNameReference reference, global::Mono.Cecil.ReaderParameters parameters)
		{
			string[] array = new string[]
			{
				"GAC_MSIL",
				"GAC_32",
				"GAC"
			};
			string[] array2 = new string[]
			{
				string.Empty,
				"v4.0_"
			};
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < array.Length; j++)
				{
					string text = global::System.IO.Path.Combine(this.gac_paths[i], array[j]);
					string assemblyFile = global::Mono.Cecil.BaseAssemblyResolver.GetAssemblyFile(reference, array2[i], text);
					if (global::System.IO.Directory.Exists(text) && global::System.IO.File.Exists(assemblyFile))
					{
						return this.GetAssembly(assemblyFile, parameters);
					}
				}
			}
			return null;
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x0000C36C File Offset: 0x0000A56C
		private static string GetAssemblyFile(global::Mono.Cecil.AssemblyNameReference reference, string prefix, string gac)
		{
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder().Append(prefix).Append(reference.Version).Append("__");
			for (int i = 0; i < reference.PublicKeyToken.Length; i++)
			{
				stringBuilder.Append(reference.PublicKeyToken[i].ToString("x2"));
			}
			return global::System.IO.Path.Combine(global::System.IO.Path.Combine(global::System.IO.Path.Combine(gac, reference.Name), stringBuilder.ToString()), reference.Name + ".dll");
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x0000C3F6 File Offset: 0x0000A5F6
		// Note: this type is marked as 'beforefieldinit'.
		static BaseAssemblyResolver()
		{
		}

		// Token: 0x040002F5 RID: 757
		private static readonly bool on_mono = global::System.Type.GetType("Mono.Runtime") != null;

		// Token: 0x040002F6 RID: 758
		private readonly global::Mono.Collections.Generic.Collection<string> directories;

		// Token: 0x040002F7 RID: 759
		private global::Mono.Collections.Generic.Collection<string> gac_paths;

		// Token: 0x040002F8 RID: 760
		private global::Mono.Cecil.AssemblyResolveEventHandler ResolveFailure;
	}
}
