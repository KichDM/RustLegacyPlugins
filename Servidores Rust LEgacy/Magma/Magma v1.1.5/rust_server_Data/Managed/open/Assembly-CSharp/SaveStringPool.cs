using System;
using System.Collections.Generic;

// Token: 0x020000D8 RID: 216
public class SaveStringPool
{
	// Token: 0x0600042A RID: 1066 RVA: 0x00013C34 File Offset: 0x00011E34
	public SaveStringPool()
	{
	}

	// Token: 0x0600042B RID: 1067 RVA: 0x00013C3C File Offset: 0x00011E3C
	// Note: this type is marked as 'beforefieldinit'.
	static SaveStringPool()
	{
	}

	// Token: 0x0600042C RID: 1068 RVA: 0x00013C64 File Offset: 0x00011E64
	public static int GetInt(string strName)
	{
		return global::SaveStringPool.prefabDictionary[strName];
	}

	// Token: 0x0600042D RID: 1069 RVA: 0x00013C74 File Offset: 0x00011E74
	public static string Convert(int iNum)
	{
		foreach (global::System.Collections.Generic.KeyValuePair<string, int> keyValuePair in global::SaveStringPool.prefabDictionary)
		{
			if (keyValuePair.Value == iNum)
			{
				return keyValuePair.Key;
			}
		}
		return string.Empty;
	}

	// Token: 0x040003EA RID: 1002
	private static global::System.Collections.Generic.Dictionary<string, int> prefabDictionary = new global::System.Collections.Generic.Dictionary<string, int>
	{
		{
			"StructureMasterPrefab",
			1
		}
	};
}
