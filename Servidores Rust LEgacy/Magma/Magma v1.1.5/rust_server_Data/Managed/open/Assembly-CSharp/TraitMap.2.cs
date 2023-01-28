using System;
using Facepunch.Abstract;
using UnityEngine;

// Token: 0x02000220 RID: 544
public abstract class TraitMap<Key> : global::BaseTraitMap where Key : global::TraitKey
{
	// Token: 0x06000EA9 RID: 3753 RVA: 0x00037FC8 File Offset: 0x000361C8
	protected TraitMap()
	{
	}

	// Token: 0x1700037B RID: 891
	// (get) Token: 0x06000EAA RID: 3754
	internal abstract global::TraitMap<Key> __baseMap { get; }

	// Token: 0x1700037C RID: 892
	// (get) Token: 0x06000EAB RID: 3755 RVA: 0x00037FD0 File Offset: 0x000361D0
	private global::Facepunch.Abstract.KeyTypeInfo<Key>.TraitDictionary map
	{
		get
		{
			if (!this.createdDict)
			{
				this.dict = new global::Facepunch.Abstract.KeyTypeInfo<Key>.TraitDictionary(this.K);
				global::TraitMap<Key> _baseMap = this.__baseMap;
				if (_baseMap)
				{
					_baseMap.map.MergeUpon(this.dict);
				}
				this.createdDict = true;
			}
			return this.dict;
		}
	}

	// Token: 0x06000EAC RID: 3756 RVA: 0x0003802C File Offset: 0x0003622C
	public Key GetTrait(global::System.Type traitType)
	{
		return this.map.TryGet(traitType);
	}

	// Token: 0x06000EAD RID: 3757 RVA: 0x0003803C File Offset: 0x0003623C
	public T GetTrait<T>() where T : Key
	{
		return this.map.TryGetSoftCast<T>();
	}

	// Token: 0x04000954 RID: 2388
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private Key[] K;

	// Token: 0x04000955 RID: 2389
	[global::System.NonSerialized]
	private global::Facepunch.Abstract.KeyTypeInfo<Key>.TraitDictionary dict;

	// Token: 0x04000956 RID: 2390
	[global::System.NonSerialized]
	private bool createdDict;
}
