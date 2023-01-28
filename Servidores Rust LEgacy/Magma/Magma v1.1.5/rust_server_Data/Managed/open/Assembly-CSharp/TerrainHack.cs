using System;
using System.Reflection;
using UnityEngine;

// Token: 0x020007CA RID: 1994
public static class TerrainHack
{
	// Token: 0x06004211 RID: 16913 RVA: 0x000F017C File Offset: 0x000EE37C
	static TerrainHack()
	{
		if (global::TerrainHack.OnTerrainChanged != null)
		{
			global::System.Type type = global::System.Type.GetType("UnityEngine.TerrainChangedFlags, UnityEngine", false, false);
			if (type != null)
			{
				object obj;
				try
				{
					obj = global::System.Enum.Parse(type, "TreeInstances", false);
				}
				catch (global::System.Exception ex)
				{
					global::UnityEngine.Debug.LogException(ex);
					try
					{
						obj = global::System.Enum.ToObject(type, 2);
					}
					catch (global::System.Exception ex2)
					{
						global::UnityEngine.Debug.LogException(ex);
						return;
					}
				}
				global::TerrainHack.AbleToLocateOnTerrainChanged = true;
				global::TerrainHack.TriggerTreeChangeValues = new object[]
				{
					obj
				};
			}
			else
			{
				global::UnityEngine.Debug.LogWarning("Couldnt locate enum TerrainChangedFlags.");
			}
		}
		else
		{
			global::UnityEngine.Debug.LogWarning("Couldnt locate method OnTerrainChanged");
		}
	}

	// Token: 0x06004212 RID: 16914 RVA: 0x000F0264 File Offset: 0x000EE464
	public static void RefreshTreeTextures(global::UnityEngine.Terrain terrain)
	{
		if (!terrain)
		{
			throw new global::System.NullReferenceException();
		}
		if (!global::TerrainHack.RanOnce)
		{
			global::TerrainHack.RanOnce = true;
			if (global::TerrainHack.AbleToLocateOnTerrainChanged)
			{
				try
				{
					global::TerrainHack.OnTerrainChanged.Invoke(terrain, global::TerrainHack.TriggerTreeChangeValues);
					global::TerrainHack.Working = true;
					return;
				}
				catch (global::System.Exception ex)
				{
					global::UnityEngine.Debug.LogException(ex);
					global::TerrainHack.Working = false;
				}
			}
		}
		if (global::TerrainHack.Working)
		{
			global::TerrainHack.OnTerrainChanged.Invoke(terrain, global::TerrainHack.TriggerTreeChangeValues);
		}
		else
		{
			terrain.Flush();
		}
	}

	// Token: 0x040022E7 RID: 8935
	private static readonly bool AbleToLocateOnTerrainChanged;

	// Token: 0x040022E8 RID: 8936
	private static readonly object[] TriggerTreeChangeValues;

	// Token: 0x040022E9 RID: 8937
	private static bool RanOnce;

	// Token: 0x040022EA RID: 8938
	private static bool Working;

	// Token: 0x040022EB RID: 8939
	private static global::System.Reflection.MethodInfo OnTerrainChanged = typeof(global::UnityEngine.Terrain).GetMethod("OnTerrainChanged", global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic);
}
