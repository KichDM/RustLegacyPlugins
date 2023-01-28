using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200055A RID: 1370
[global::UnityEngine.AddComponentMenu("")]
public sealed class WildlifeManager : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002EB8 RID: 11960 RVA: 0x000B2124 File Offset: 0x000B0324
	public WildlifeManager()
	{
	}

	// Token: 0x06002EB9 RID: 11961 RVA: 0x000B212C File Offset: 0x000B032C
	// Note: this type is marked as 'beforefieldinit'.
	static WildlifeManager()
	{
	}

	// Token: 0x06002EBA RID: 11962 RVA: 0x000B213C File Offset: 0x000B033C
	public static bool AddWildlifeInstance(global::BasicWildLifeAI ai)
	{
		return !global::WildlifeManager.DataShutdown && global::WildlifeManager.Data.Add(ai);
	}

	// Token: 0x06002EBB RID: 11963 RVA: 0x000B2154 File Offset: 0x000B0354
	public static bool RemoveWildlifeInstance(global::BasicWildLifeAI ai)
	{
		return global::WildlifeManager.DataInitialized && global::WildlifeManager.Data.Remove(ai);
	}

	// Token: 0x170009ED RID: 2541
	// (get) Token: 0x06002EBC RID: 11964 RVA: 0x000B216C File Offset: 0x000B036C
	[global::System.Obsolete("DO NOT USE", false)]
	internal static bool ZZZmZaZnZaZgZeZrZAZvZaZiZlZaZbZlZeZ
	{
		get
		{
			return global::WildlifeManager.DataInitialized && !global::WildlifeManager.DataShutdown;
		}
	}

	// Token: 0x06002EBD RID: 11965 RVA: 0x000B2184 File Offset: 0x000B0384
	private void Update()
	{
		if (global::WildlifeManager.DataInitialized)
		{
			if (global::WildlifeManager.PauseUpdates || global::ServerSaveManager.IsLoading)
			{
				global::WildlifeManager.PauseUpdatesCaught = true;
				return;
			}
			if (global::WildlifeManager.PauseUpdatesCaught)
			{
				global::WildlifeManager.PauseUpdatesCaught = false;
				global::WildlifeManager.Data.ResetTimers();
			}
			global::WildlifeManager.Data.Think(global::wildlife.forceupdate);
		}
	}

	// Token: 0x06002EBE RID: 11966 RVA: 0x000B21D8 File Offset: 0x000B03D8
	private void OnDestroy()
	{
		if (global::WildlifeManager.DataInitialized)
		{
			global::WildlifeManager.Data.DeleteSingleton(this);
		}
	}

	// Token: 0x04001851 RID: 6225
	private const ulong thinkInterval = 0xFUL;

	// Token: 0x04001852 RID: 6226
	private const int maxThinkCountPerUpdate = 0x96;

	// Token: 0x04001853 RID: 6227
	private static ulong instanceThinkInterval = 0x3E8UL;

	// Token: 0x04001854 RID: 6228
	private static bool DataInitialized;

	// Token: 0x04001855 RID: 6229
	private static bool DataShutdown;

	// Token: 0x04001856 RID: 6230
	public static bool PauseUpdates;

	// Token: 0x04001857 RID: 6231
	private static bool PauseUpdatesCaught;

	// Token: 0x0200055B RID: 1371
	public sealed class LocalData
	{
		// Token: 0x06002EBF RID: 11967 RVA: 0x000B21EC File Offset: 0x000B03EC
		internal LocalData()
		{
			this.networkedOrigin.y = float.NegativeInfinity;
		}

		// Token: 0x06002EC0 RID: 11968 RVA: 0x000B2204 File Offset: 0x000B0404
		public bool CoordinatesChanged(ref global::UnityEngine.Vector3 origin, ref global::UnityEngine.Quaternion rotation)
		{
			if (origin != this.networkedOrigin || rotation != this.networkedRotation)
			{
				this.networkedOrigin = origin;
				this.networkedRotation = rotation;
				return true;
			}
			return false;
		}

		// Token: 0x04001858 RID: 6232
		[global::System.NonSerialized]
		public ulong lastUpdateTime;

		// Token: 0x04001859 RID: 6233
		[global::System.NonSerialized]
		internal bool ZuZpZdZaZtZeZdZOZnZcZeZ;

		// Token: 0x0400185A RID: 6234
		[global::System.NonSerialized]
		public object tag;

		// Token: 0x0400185B RID: 6235
		[global::System.NonSerialized]
		private global::UnityEngine.Vector3 networkedOrigin;

		// Token: 0x0400185C RID: 6236
		[global::System.NonSerialized]
		private global::UnityEngine.Quaternion networkedRotation;
	}

	// Token: 0x0200055C RID: 1372
	private static class Data
	{
		// Token: 0x06002EC1 RID: 11969 RVA: 0x000B2258 File Offset: 0x000B0458
		static Data()
		{
			global::UnityEngine.GameObject gameObject = new global::UnityEngine.GameObject("__WILDLIFEMANAGER", new global::System.Type[]
			{
				typeof(global::WildlifeManager)
			});
			global::UnityEngine.Object.DontDestroyOnLoad(gameObject);
			global::WildlifeManager.Data.singleton = gameObject.GetComponent<global::WildlifeManager>();
			global::WildlifeManager.Data.lifeInstances = new global::System.Collections.Generic.List<global::BasicWildLifeAI>();
			global::WildlifeManager.Data.singleton.enabled = false;
			global::WildlifeManager.DataInitialized = true;
		}

		// Token: 0x06002EC2 RID: 11970 RVA: 0x000B22B0 File Offset: 0x000B04B0
		public static int Think(bool forceNow)
		{
			if (global::WildlifeManager.Data.lifeInstanceCount == 0)
			{
				return 0;
			}
			ulong timeInMillis = global::NetCull.timeInMillis;
			if (global::WildlifeManager.Data.runImmediateOnce)
			{
				global::WildlifeManager.Data.runImmediateOnce = false;
			}
			else if (!forceNow)
			{
				ulong num = timeInMillis - global::WildlifeManager.Data.lastThinkTime;
				if (num < 0xFUL)
				{
					return 0;
				}
			}
			global::WildlifeManager.Data.lastThinkTime = timeInMillis;
			global::WildlifeManager.Data.thinkCountRemaining = global::WildlifeManager.Data.lifeInstanceCount;
			global::WildlifeManager.Data.RefreshInstanceThinkInterval();
			int num2 = 0;
			for (;;)
			{
				global::BasicWildLifeAI basicWildLifeAI = global::WildlifeManager.Data.lifeInstances[global::WildlifeManager.Data.thinkIterator];
				global::WildlifeManager.Data.thinkIterator++;
				global::WildlifeManager.Data.thinkCountRemaining--;
				if (global::WildlifeManager.Data.thinkIterator == global::WildlifeManager.Data.lifeInstanceCount)
				{
					global::WildlifeManager.Data.thinkIterator = 0;
				}
				bool flag;
				try
				{
					global::WildlifeManager.LocalData zzlZoZcZaZlZZ = basicWildLifeAI.ZZlZoZcZaZlZZ;
					ulong timeInMillis2 = global::NetCull.timeInMillis;
					ulong num3;
					if (!zzlZoZcZaZlZZ.ZuZpZdZaZtZeZdZOZnZcZeZ)
					{
						zzlZoZcZaZlZZ.lastUpdateTime = timeInMillis2 - global::WildlifeManager.instanceThinkInterval;
						zzlZoZcZaZlZZ.ZuZpZdZaZtZeZdZOZnZcZeZ = true;
						num3 = global::WildlifeManager.instanceThinkInterval;
					}
					else
					{
						num3 = timeInMillis2 - zzlZoZcZaZlZZ.lastUpdateTime;
						if (num3 < global::WildlifeManager.instanceThinkInterval - 0xFUL)
						{
							goto IL_14B;
						}
						zzlZoZcZaZlZZ.lastUpdateTime = timeInMillis2;
					}
					flag = basicWildLifeAI.ManagedUpdate(num3, zzlZoZcZaZlZZ);
				}
				catch (global::System.Exception ex)
				{
					global::UnityEngine.Debug.LogException(ex, basicWildLifeAI);
					flag = true;
				}
				goto IL_11F;
				IL_14B:
				if (global::WildlifeManager.Data.thinkCountRemaining <= 0)
				{
					break;
				}
				continue;
				IL_11F:
				if (flag && ++num2 == 0x96 && global::WildlifeManager.Data.thinkCountRemaining != 0)
				{
					global::WildlifeManager.Data.thinkCountRemaining = 0;
					global::WildlifeManager.Data.runImmediateOnce = true;
					goto IL_14B;
				}
				goto IL_14B;
			}
			return num2;
		}

		// Token: 0x06002EC3 RID: 11971 RVA: 0x000B2430 File Offset: 0x000B0630
		public static bool Add(global::BasicWildLifeAI ai)
		{
			if (!ai || ai.ZZmZaZnZaZgZeZrZZZZmZaZnZaZgZeZdZZ)
			{
				return false;
			}
			if (global::WildlifeManager.Data.thinkIterator == 0)
			{
				global::WildlifeManager.Data.lifeInstances.Add(ai);
			}
			else
			{
				global::WildlifeManager.Data.lifeInstances.Insert(global::WildlifeManager.Data.thinkIterator - 1, ai);
				global::WildlifeManager.Data.thinkIterator++;
			}
			if (global::WildlifeManager.Data.lifeInstanceCount++ == 0)
			{
				global::WildlifeManager.Data.singleton.enabled = true;
			}
			ai.ZZlZoZcZaZlZZ = new global::WildlifeManager.LocalData();
			ai.ZZmZaZnZaZgZeZrZZZZmZaZnZaZgZeZdZZ = true;
			return true;
		}

		// Token: 0x06002EC4 RID: 11972 RVA: 0x000B24C0 File Offset: 0x000B06C0
		public static bool Remove(global::BasicWildLifeAI ai)
		{
			if (global::WildlifeManager.Data.lifeInstanceCount == 0)
			{
				return false;
			}
			bool flag = ai;
			if (flag || !ai.ZZmZaZnZaZgZeZrZZZZmZaZnZaZgZeZdZZ)
			{
				return false;
			}
			int num = global::WildlifeManager.Data.lifeInstances.IndexOf(ai);
			if (num == -1)
			{
				return false;
			}
			global::WildlifeManager.Data.lifeInstances.RemoveAt(num);
			global::WildlifeManager.Data.lifeInstanceCount--;
			if (num > global::WildlifeManager.Data.thinkIterator && global::WildlifeManager.Data.thinkCountRemaining > 0 && num < global::WildlifeManager.Data.thinkIterator + global::WildlifeManager.Data.thinkCountRemaining)
			{
				global::WildlifeManager.Data.thinkCountRemaining--;
			}
			if (num == global::WildlifeManager.Data.thinkIterator && global::WildlifeManager.Data.thinkCountRemaining > 0)
			{
				global::WildlifeManager.Data.thinkCountRemaining--;
			}
			if (num < global::WildlifeManager.Data.thinkIterator)
			{
				if (global::WildlifeManager.Data.thinkCountRemaining > 0)
				{
					int num2 = global::WildlifeManager.Data.thinkIterator - global::WildlifeManager.Data.lifeInstanceCount + global::WildlifeManager.Data.thinkCountRemaining;
					if (num2 > num)
					{
						global::WildlifeManager.Data.thinkCountRemaining--;
					}
				}
				global::WildlifeManager.Data.thinkIterator--;
			}
			else if (global::WildlifeManager.Data.lifeInstanceCount == global::WildlifeManager.Data.thinkIterator)
			{
				global::WildlifeManager.Data.thinkIterator = 0;
				if (global::WildlifeManager.Data.lifeInstanceCount == 0)
				{
					global::WildlifeManager.Data.singleton.enabled = false;
				}
			}
			if (flag)
			{
				ai.ZZlZoZcZaZlZZ = null;
				ai.ZZmZaZnZaZgZeZrZZZZmZaZnZaZgZeZdZZ = false;
			}
			return true;
		}

		// Token: 0x06002EC5 RID: 11973 RVA: 0x000B2600 File Offset: 0x000B0800
		public static void DeleteSingleton(global::WildlifeManager instance)
		{
			if (instance != global::WildlifeManager.Data.singleton)
			{
				return;
			}
			global::WildlifeManager.Data.singleton = null;
			global::WildlifeManager.DataInitialized = false;
			global::WildlifeManager.DataShutdown = true;
			if (global::WildlifeManager.Data.lifeInstanceCount > 0)
			{
				global::WildlifeManager.Data.lifeInstances.Clear();
			}
			global::WildlifeManager.Data.thinkCountRemaining = (global::WildlifeManager.Data.lifeInstanceCount = (global::WildlifeManager.Data.thinkIterator = (global::WildlifeManager.Data.lifeInstanceCount = 0)));
		}

		// Token: 0x06002EC6 RID: 11974 RVA: 0x000B2660 File Offset: 0x000B0860
		private static void RefreshInstanceThinkInterval()
		{
			global::WildlifeManager.instanceThinkInterval = (ulong)global::System.Math.Floor(1000.0 * global::NetCull.sendInterval);
			if (global::WildlifeManager.instanceThinkInterval < 0xFUL)
			{
				global::WildlifeManager.instanceThinkInterval = 0xFUL;
			}
		}

		// Token: 0x06002EC7 RID: 11975 RVA: 0x000B2694 File Offset: 0x000B0894
		internal static void ResetTimers()
		{
			foreach (global::BasicWildLifeAI basicWildLifeAI in global::WildlifeManager.Data.lifeInstances)
			{
				if (basicWildLifeAI)
				{
					basicWildLifeAI.ZZlZoZcZaZlZZ.ZuZpZdZaZtZeZdZOZnZcZeZ = false;
				}
			}
		}

		// Token: 0x0400185D RID: 6237
		private static global::WildlifeManager singleton;

		// Token: 0x0400185E RID: 6238
		private static readonly global::System.Collections.Generic.List<global::BasicWildLifeAI> lifeInstances;

		// Token: 0x0400185F RID: 6239
		private static int lifeInstanceCount;

		// Token: 0x04001860 RID: 6240
		private static int thinkIterator;

		// Token: 0x04001861 RID: 6241
		private static int thinkCountRemaining;

		// Token: 0x04001862 RID: 6242
		private static ulong lastThinkTime;

		// Token: 0x04001863 RID: 6243
		private static bool runImmediateOnce;
	}
}
