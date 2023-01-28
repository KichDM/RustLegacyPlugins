using System;
using UnityEngine;

// Token: 0x0200012D RID: 301
public class CharacterDeathDropPrefabTrait : global::CharacterTrait
{
	// Token: 0x0600076A RID: 1898 RVA: 0x000204FC File Offset: 0x0001E6FC
	public CharacterDeathDropPrefabTrait()
	{
	}

	// Token: 0x1700017B RID: 379
	// (get) Token: 0x0600076B RID: 1899 RVA: 0x00020504 File Offset: 0x0001E704
	public bool hasPrefab
	{
		get
		{
			return (!this._loaded) ? this.prefab : (!this._loadFail);
		}
	}

	// Token: 0x1700017C RID: 380
	// (get) Token: 0x0600076C RID: 1900 RVA: 0x00020538 File Offset: 0x0001E738
	public string instantiateString
	{
		get
		{
			if (this.prefab)
			{
				return this._prefabName;
			}
			return null;
		}
	}

	// Token: 0x1700017D RID: 381
	// (get) Token: 0x0600076D RID: 1901 RVA: 0x00020554 File Offset: 0x0001E754
	public global::UnityEngine.Transform prefabTransform
	{
		get
		{
			global::UnityEngine.GameObject prefab = this.prefab;
			return (!prefab) ? null : prefab.transform;
		}
	}

	// Token: 0x1700017E RID: 382
	// (get) Token: 0x0600076E RID: 1902 RVA: 0x00020580 File Offset: 0x0001E780
	private global::UnityEngine.GameObject prefab
	{
		get
		{
			if (!this._loaded)
			{
				this._loaded = true;
				this._loadFail = ((int)global::NetCull.LoadPrefab(this._prefabName, out this._loadedPrefab) == 0);
			}
			return this._loadedPrefab;
		}
	}

	// Token: 0x040005E7 RID: 1511
	[global::UnityEngine.SerializeField]
	private string _prefabName;

	// Token: 0x040005E8 RID: 1512
	[global::System.NonSerialized]
	private global::UnityEngine.GameObject _loadedPrefab;

	// Token: 0x040005E9 RID: 1513
	[global::System.NonSerialized]
	private bool _loaded;

	// Token: 0x040005EA RID: 1514
	[global::System.NonSerialized]
	private bool _loadFail;
}
