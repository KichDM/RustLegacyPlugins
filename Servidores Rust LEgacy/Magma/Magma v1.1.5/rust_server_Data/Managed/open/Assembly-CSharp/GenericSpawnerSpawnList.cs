using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020005FF RID: 1535
public class GenericSpawnerSpawnList : global::UnityEngine.ScriptableObject
{
	// Token: 0x06003147 RID: 12615 RVA: 0x000BCC38 File Offset: 0x000BAE38
	public GenericSpawnerSpawnList()
	{
	}

	// Token: 0x06003148 RID: 12616 RVA: 0x000BCC40 File Offset: 0x000BAE40
	public global::System.Collections.Generic.List<global::GenericSpawnerSpawnList.GenericSpawnInstance> GetCopy()
	{
		global::System.Collections.Generic.List<global::GenericSpawnerSpawnList.GenericSpawnInstance> list = new global::System.Collections.Generic.List<global::GenericSpawnerSpawnList.GenericSpawnInstance>(this._spawnList.Count);
		foreach (global::GenericSpawnerSpawnList.GenericSpawnInstance genericSpawnInstance in this._spawnList)
		{
			list.Add(genericSpawnInstance.Clone());
		}
		return list;
	}

	// Token: 0x04001B6E RID: 7022
	[global::UnityEngine.SerializeField]
	public global::System.Collections.Generic.List<global::GenericSpawnerSpawnList.GenericSpawnInstance> _spawnList;

	// Token: 0x02000600 RID: 1536
	[global::System.Serializable]
	public class GenericSpawnInstance
	{
		// Token: 0x06003149 RID: 12617 RVA: 0x000BCCC0 File Offset: 0x000BAEC0
		public GenericSpawnInstance()
		{
		}

		// Token: 0x0600314A RID: 12618 RVA: 0x000BCCE4 File Offset: 0x000BAEE4
		public int GetNumActive()
		{
			return this.spawned.Count;
		}

		// Token: 0x0600314B RID: 12619 RVA: 0x000BCCF4 File Offset: 0x000BAEF4
		public global::GenericSpawnerSpawnList.GenericSpawnInstance Clone()
		{
			return new global::GenericSpawnerSpawnList.GenericSpawnInstance
			{
				prefabName = this.prefabName,
				targetPopulation = this.targetPopulation,
				numToSpawnPerTick = this.numToSpawnPerTick,
				forceStaticInstantiate = this.forceStaticInstantiate,
				spawned = new global::System.Collections.Generic.List<global::UnityEngine.GameObject>()
			};
		}

		// Token: 0x04001B6F RID: 7023
		public string prefabName = string.Empty;

		// Token: 0x04001B70 RID: 7024
		public int targetPopulation;

		// Token: 0x04001B71 RID: 7025
		public int numToSpawnPerTick = 1;

		// Token: 0x04001B72 RID: 7026
		public bool forceStaticInstantiate;

		// Token: 0x04001B73 RID: 7027
		public bool useNavmeshSample = true;

		// Token: 0x04001B74 RID: 7028
		public global::System.Collections.Generic.List<global::UnityEngine.GameObject> spawned;
	}
}
