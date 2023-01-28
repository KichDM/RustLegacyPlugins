using System;
using UnityEngine;

// Token: 0x0200057F RID: 1407
public class CharacterSleepingAvatarTrait : global::CharacterTrait
{
	// Token: 0x06002F2D RID: 12077 RVA: 0x000B3DAC File Offset: 0x000B1FAC
	public CharacterSleepingAvatarTrait()
	{
	}

	// Token: 0x06002F2E RID: 12078 RVA: 0x000B3DB4 File Offset: 0x000B1FB4
	private bool ValidatePrefab()
	{
		if (string.IsNullOrEmpty(this._sleepingAvatarPrefab))
		{
			return false;
		}
		global::UnityEngine.GameObject gameObject;
		global::NetCull.PrefabSearch prefabSearch = global::NetCull.LoadPrefab(this._sleepingAvatarPrefab, out gameObject);
		if ((int)prefabSearch != 1)
		{
			global::UnityEngine.Debug.LogError(string.Format("sleeping avatar prefab named \"{0}\" resulted in {1} which was not {2}(required)", this.prefab, prefabSearch, global::NetCull.PrefabSearch.NGC));
			return false;
		}
		global::IDMain component = gameObject.GetComponent<global::IDMain>();
		if (!(component is global::SleepingAvatar))
		{
			global::UnityEngine.Debug.LogError(string.Format("Theres no Sleeping avatar on prefab \"{0}\"", this.prefab), gameObject);
			return false;
		}
		this._hasInventory = component.GetLocal<global::Inventory>();
		global::TakeDamage local = component.GetLocal<global::TakeDamage>();
		this._hasTakeDamage = local;
		this._takeDamageType = ((!this._hasTakeDamage) ? null : local.GetType());
		return true;
	}

	// Token: 0x17000A0B RID: 2571
	// (get) Token: 0x06002F2F RID: 12079 RVA: 0x000B3E78 File Offset: 0x000B2078
	public bool valid
	{
		get
		{
			bool? prefabValid = this._prefabValid;
			bool value;
			if (prefabValid != null)
			{
				value = prefabValid.Value;
			}
			else
			{
				bool? flag = this._prefabValid = new bool?(this.ValidatePrefab());
				value = flag.Value;
			}
			return value;
		}
	}

	// Token: 0x17000A0C RID: 2572
	// (get) Token: 0x06002F30 RID: 12080 RVA: 0x000B3EC0 File Offset: 0x000B20C0
	public bool hasTakeDamage
	{
		get
		{
			return this.valid && this._hasTakeDamage;
		}
	}

	// Token: 0x17000A0D RID: 2573
	// (get) Token: 0x06002F31 RID: 12081 RVA: 0x000B3ED8 File Offset: 0x000B20D8
	public global::System.Type takeDamageType
	{
		get
		{
			if (!this.hasTakeDamage)
			{
				throw new global::System.InvalidOperationException("You need to check hasTakeDamage before requesting this. hasTakeDamage == False");
			}
			return this._takeDamageType;
		}
	}

	// Token: 0x17000A0E RID: 2574
	// (get) Token: 0x06002F32 RID: 12082 RVA: 0x000B3EF8 File Offset: 0x000B20F8
	public bool hasInventory
	{
		get
		{
			return this.valid && this._hasInventory;
		}
	}

	// Token: 0x17000A0F RID: 2575
	// (get) Token: 0x06002F33 RID: 12083 RVA: 0x000B3F10 File Offset: 0x000B2110
	public bool canDropInventories
	{
		get
		{
			return this._allowDroppingOfInventory && this.hasInventory;
		}
	}

	// Token: 0x17000A10 RID: 2576
	// (get) Token: 0x06002F34 RID: 12084 RVA: 0x000B3F28 File Offset: 0x000B2128
	public string prefab
	{
		get
		{
			return this._sleepingAvatarPrefab ?? string.Empty;
		}
	}

	// Token: 0x17000A11 RID: 2577
	// (get) Token: 0x06002F35 RID: 12085 RVA: 0x000B3F3C File Offset: 0x000B213C
	public bool grabsCarrierOnCreate
	{
		get
		{
			return this.valid && this._grabCarrierOnCreate;
		}
	}

	// Token: 0x06002F36 RID: 12086 RVA: 0x000B3F54 File Offset: 0x000B2154
	public global::UnityEngine.Vector3 SolvePlacement(global::UnityEngine.Vector3 origin, global::UnityEngine.Quaternion rot, int iter)
	{
		return global::TransformHelpers.TestBoxCorners(origin, rot, this.boxCenter, this.boxSize, 0x400, iter);
	}

	// Token: 0x04001901 RID: 6401
	[global::UnityEngine.SerializeField]
	private string _sleepingAvatarPrefab;

	// Token: 0x04001902 RID: 6402
	[global::UnityEngine.SerializeField]
	private bool _allowDroppingOfInventory;

	// Token: 0x04001903 RID: 6403
	[global::UnityEngine.SerializeField]
	private bool _grabCarrierOnCreate;

	// Token: 0x04001904 RID: 6404
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Vector3 boxCenter;

	// Token: 0x04001905 RID: 6405
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Vector3 boxSize;

	// Token: 0x04001906 RID: 6406
	[global::System.NonSerialized]
	private bool? _prefabValid;

	// Token: 0x04001907 RID: 6407
	[global::System.NonSerialized]
	private bool _hasInventory;

	// Token: 0x04001908 RID: 6408
	[global::System.NonSerialized]
	private bool _hasTakeDamage;

	// Token: 0x04001909 RID: 6409
	[global::System.NonSerialized]
	private global::System.Type _takeDamageType;
}
