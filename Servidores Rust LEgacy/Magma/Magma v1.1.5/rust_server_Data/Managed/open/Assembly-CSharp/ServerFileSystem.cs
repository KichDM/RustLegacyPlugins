using System;
using System.IO;
using UnityEngine;

// Token: 0x02000430 RID: 1072
public static class ServerFileSystem
{
	// Token: 0x1700085A RID: 2138
	// (get) Token: 0x0600254A RID: 9546 RVA: 0x0008EB40 File Offset: 0x0008CD40
	public static string InstancePath
	{
		get
		{
			return global::ServerFileSystem.Late.serverPath;
		}
	}

	// Token: 0x0600254B RID: 9547 RVA: 0x0008EB48 File Offset: 0x0008CD48
	public static string GetPath(string filename)
	{
		if (global::System.IO.Path.IsPathRooted(filename))
		{
			return filename;
		}
		return global::System.IO.Path.Combine(global::ServerFileSystem.Late.serverPath, filename);
	}

	// Token: 0x0600254C RID: 9548 RVA: 0x0008EB64 File Offset: 0x0008CD64
	public static void EnsureFileSystem(string filename)
	{
		if (global::System.IO.Path.IsPathRooted(filename))
		{
			throw new global::System.InvalidOperationException("filename cannot be rooted");
		}
		filename = global::System.IO.Path.Combine(global::ServerFileSystem.Late.serverPath, filename);
		string directoryName = global::System.IO.Path.GetDirectoryName(filename);
		if (!string.IsNullOrEmpty(filename) && !global::System.IO.Directory.Exists(directoryName))
		{
			global::ServerFileSystem.CreateDirectory(directoryName);
		}
	}

	// Token: 0x0600254D RID: 9549 RVA: 0x0008EBB8 File Offset: 0x0008CDB8
	private static void CreateDirectory(string directory)
	{
		if (!global::System.IO.Directory.Exists(directory))
		{
			global::ServerFileSystem.CreateDirectory(global::System.IO.Path.GetDirectoryName(directory));
			global::System.IO.Directory.CreateDirectory(directory);
		}
	}

	// Token: 0x0600254E RID: 9550 RVA: 0x0008EBD8 File Offset: 0x0008CDD8
	public static global::System.IO.FileStream Open(string filename, global::System.IO.FileMode fileMode)
	{
		return global::System.IO.File.Open(global::ServerFileSystem.GetPath(filename), fileMode);
	}

	// Token: 0x0600254F RID: 9551 RVA: 0x0008EBE8 File Offset: 0x0008CDE8
	public static global::System.IO.FileStream Open(string filename, global::System.IO.FileMode fileMode, global::System.IO.FileAccess fileAccess)
	{
		return global::System.IO.File.Open(global::ServerFileSystem.GetPath(filename), fileMode, fileAccess);
	}

	// Token: 0x06002550 RID: 9552 RVA: 0x0008EBF8 File Offset: 0x0008CDF8
	public static global::System.IO.FileStream Open(string filename, global::System.IO.FileMode fileMode, global::System.IO.FileAccess fileAccess, global::System.IO.FileShare fileShare)
	{
		return global::System.IO.File.Open(global::ServerFileSystem.GetPath(filename), fileMode, fileAccess, fileShare);
	}

	// Token: 0x06002551 RID: 9553 RVA: 0x0008EC08 File Offset: 0x0008CE08
	public static global::System.IO.FileStream OpenRead(string filename)
	{
		return global::System.IO.File.OpenRead(global::ServerFileSystem.GetPath(filename));
	}

	// Token: 0x06002552 RID: 9554 RVA: 0x0008EC18 File Offset: 0x0008CE18
	public static global::System.IO.StreamReader OpenText(string filename)
	{
		return global::System.IO.File.OpenText(global::ServerFileSystem.GetPath(filename));
	}

	// Token: 0x06002553 RID: 9555 RVA: 0x0008EC28 File Offset: 0x0008CE28
	public static bool Exists(string filename)
	{
		return global::System.IO.File.Exists(global::ServerFileSystem.GetPath(filename));
	}

	// Token: 0x06002554 RID: 9556 RVA: 0x0008EC38 File Offset: 0x0008CE38
	public static global::System.IO.FileStream Create(string filename)
	{
		return global::System.IO.File.Create(global::ServerFileSystem.GetPath(filename));
	}

	// Token: 0x06002555 RID: 9557 RVA: 0x0008EC48 File Offset: 0x0008CE48
	public static global::System.IO.StreamWriter CreateText(string filename)
	{
		return global::System.IO.File.CreateText(global::ServerFileSystem.GetPath(filename));
	}

	// Token: 0x06002556 RID: 9558 RVA: 0x0008EC58 File Offset: 0x0008CE58
	public static void Delete(string filename)
	{
		global::System.IO.File.Delete(global::ServerFileSystem.GetPath(filename));
	}

	// Token: 0x06002557 RID: 9559 RVA: 0x0008EC68 File Offset: 0x0008CE68
	public static void Move(string source, string destination)
	{
		global::System.IO.File.Move(global::ServerFileSystem.GetPath(source), global::ServerFileSystem.GetPath(destination));
	}

	// Token: 0x06002558 RID: 9560 RVA: 0x0008EC7C File Offset: 0x0008CE7C
	public static global::System.IO.FileInfo FileInfo(string filename)
	{
		return new global::System.IO.FileInfo(global::ServerFileSystem.GetPath(filename));
	}

	// Token: 0x06002559 RID: 9561 RVA: 0x0008EC8C File Offset: 0x0008CE8C
	public static global::System.DateTime GetLastWriteTime(string filename)
	{
		return global::System.IO.File.GetLastWriteTime(global::ServerFileSystem.GetPath(filename));
	}

	// Token: 0x0600255A RID: 9562 RVA: 0x0008EC9C File Offset: 0x0008CE9C
	public static string GetExtension(string filename)
	{
		return global::System.IO.Path.GetExtension(filename);
	}

	// Token: 0x0600255B RID: 9563 RVA: 0x0008ECA4 File Offset: 0x0008CEA4
	public static byte[] ReadAllBytes(string filename)
	{
		return global::System.IO.File.ReadAllBytes(global::ServerFileSystem.GetPath(filename));
	}

	// Token: 0x02000431 RID: 1073
	private static class Late
	{
		// Token: 0x0600255C RID: 9564 RVA: 0x0008ECB4 File Offset: 0x0008CEB4
		static Late()
		{
			string[] commandLineArgs = global::System.Environment.GetCommandLineArgs();
			for (int i = 0; i < commandLineArgs.Length - 1; i++)
			{
				if (commandLineArgs[i].ToLower() == "-serverinstancedir")
				{
					try
					{
						global::ServerFileSystem.Late.serverPath = global::System.IO.Path.GetFullPath(commandLineArgs[++i]);
					}
					catch (global::System.Exception ex)
					{
						global::UnityEngine.Debug.LogException(ex);
					}
				}
			}
			if (!global::System.IO.Directory.Exists(global::ServerFileSystem.Late.serverPath))
			{
				global::System.IO.Directory.CreateDirectory(global::ServerFileSystem.Late.serverPath);
			}
		}

		// Token: 0x04001303 RID: 4867
		public static readonly string serverPath = global::System.IO.Path.GetDirectoryName(global::System.IO.Path.GetFullPath(global::UnityEngine.Application.dataPath));
	}
}
