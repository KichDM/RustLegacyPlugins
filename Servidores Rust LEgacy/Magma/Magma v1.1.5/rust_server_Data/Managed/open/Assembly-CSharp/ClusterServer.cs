using System;
using System.IO;
using RustProto;
using UnityEngine;

// Token: 0x020004E9 RID: 1257
public class ClusterServer : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002B9A RID: 11162 RVA: 0x000A3B8C File Offset: 0x000A1D8C
	public ClusterServer()
	{
	}

	// Token: 0x06002B9B RID: 11163 RVA: 0x000A3B94 File Offset: 0x000A1D94
	// Note: this type is marked as 'beforefieldinit'.
	static ClusterServer()
	{
	}

	// Token: 0x06002B9C RID: 11164 RVA: 0x000A3BA0 File Offset: 0x000A1DA0
	public static string GetAvatarFolder(ulong iID)
	{
		return global::server.datadir + "userdata/" + iID.ToString();
	}

	// Token: 0x06002B9D RID: 11165 RVA: 0x000A3BB8 File Offset: 0x000A1DB8
	internal static void SaveAvatar(ulong UserID, ref global::RustProto.Avatar avatar)
	{
		string avatarFolder = global::ClusterServer.GetAvatarFolder(UserID);
		string path = avatarFolder + "/avatar.bin";
		if (!global::System.IO.Directory.Exists(avatarFolder))
		{
			global::System.IO.Directory.CreateDirectory(avatarFolder);
		}
		byte[] bytes = avatar.ToByteArray();
		global::System.IO.File.WriteAllBytes(path, bytes);
	}

	// Token: 0x06002B9E RID: 11166 RVA: 0x000A3BFC File Offset: 0x000A1DFC
	internal static global::RustProto.Avatar LoadAvatar(ulong UserID)
	{
		string path = global::ClusterServer.GetAvatarFolder(UserID) + "/avatar.bin";
		global::RustProto.Avatar.Builder builder = global::RustProto.Avatar.CreateBuilder();
		if (global::System.IO.File.Exists(path))
		{
			byte[] array = global::System.IO.File.ReadAllBytes(path);
			builder.MergeFrom(array);
		}
		else
		{
			builder.Clear();
		}
		return builder.Build();
	}

	// Token: 0x04001605 RID: 5637
	public static string dataFolder = string.Empty;
}
