using System;
using UnityEngine;

// Token: 0x0200071D RID: 1821
[global::System.Serializable]
public class LootSpawnListReference
{
	// Token: 0x06003DBF RID: 15807 RVA: 0x000D875C File Offset: 0x000D695C
	public LootSpawnListReference()
	{
		this.name = string.Empty;
	}

	// Token: 0x17000BC4 RID: 3012
	// (get) Token: 0x06003DC0 RID: 15808 RVA: 0x000D8770 File Offset: 0x000D6970
	// (set) Token: 0x06003DC1 RID: 15809 RVA: 0x000D87A8 File Offset: 0x000D69A8
	public global::LootSpawnList list
	{
		get
		{
			if (!this.once)
			{
				this.once = true;
				this._list = global::DatablockDictionary.GetLootSpawnListByName(this.name ?? string.Empty);
			}
			return this._list;
		}
		set
		{
			this.name = ((!value) ? string.Empty : value.name);
			this._list = value;
			this.once = true;
		}
	}

	// Token: 0x06003DC2 RID: 15810 RVA: 0x000D87DC File Offset: 0x000D69DC
	public static explicit operator global::LootSpawnList(global::LootSpawnListReference reference)
	{
		if (object.ReferenceEquals(reference, null))
		{
			return null;
		}
		return reference.list;
	}

	// Token: 0x06003DC3 RID: 15811 RVA: 0x000D87F4 File Offset: 0x000D69F4
	public static bool operator true(global::LootSpawnListReference reference)
	{
		return !object.ReferenceEquals(reference, null) && reference.list;
	}

	// Token: 0x06003DC4 RID: 15812 RVA: 0x000D8810 File Offset: 0x000D6A10
	public static bool operator false(global::LootSpawnListReference reference)
	{
		return object.ReferenceEquals(reference, null) || !reference.list;
	}

	// Token: 0x04001F35 RID: 7989
	[global::UnityEngine.SerializeField]
	private string name;

	// Token: 0x04001F36 RID: 7990
	[global::System.NonSerialized]
	private bool once;

	// Token: 0x04001F37 RID: 7991
	[global::System.NonSerialized]
	private global::LootSpawnList _list;
}
