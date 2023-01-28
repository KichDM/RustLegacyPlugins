using System;
using UnityEngine;

// Token: 0x020006E6 RID: 1766
public abstract class DeployableItem<T> : global::HeldItem<T> where T : global::DeployableItemDataBlock
{
	// Token: 0x06003C46 RID: 15430 RVA: 0x000D5638 File Offset: 0x000D3838
	protected DeployableItem(T db) : base(db)
	{
	}

	// Token: 0x06003C47 RID: 15431 RVA: 0x000D564C File Offset: 0x000D384C
	protected override void OnSetActive(bool isActive)
	{
		base.OnSetActive(isActive);
	}

	// Token: 0x06003C48 RID: 15432 RVA: 0x000D5658 File Offset: 0x000D3858
	public virtual bool CanPlace()
	{
		T datablock = this.datablock;
		if (datablock.ObjectToPlace == null)
		{
			return false;
		}
		T datablock2 = this.datablock;
		global::UnityEngine.Vector3 vector;
		global::UnityEngine.Quaternion quaternion;
		global::TransCarrier transCarrier;
		return datablock2.CheckPlacement(base.character.eyesRay, out vector, out quaternion, out transCarrier) && this._nextPlaceTime <= global::UnityEngine.Time.time;
	}

	// Token: 0x06003C49 RID: 15433 RVA: 0x000D56C8 File Offset: 0x000D38C8
	public virtual void DoPlace()
	{
		global::UnityEngine.Ray eyesRay = base.character.eyesRay;
		T datablock = this.datablock;
		global::UnityEngine.Vector3 vector;
		global::UnityEngine.Quaternion quaternion;
		global::TransCarrier transCarrier;
		datablock.CheckPlacement(eyesRay, out vector, out quaternion, out transCarrier);
		this._nextPlaceTime = global::UnityEngine.Time.time + 0.5f;
		base.itemRepresentation.Action(1, 0, new object[]
		{
			eyesRay.origin,
			eyesRay.direction
		});
	}

	// Token: 0x04001EAD RID: 7853
	protected float _nextPlaceTime = global::UnityEngine.Time.time;

	// Token: 0x04001EAE RID: 7854
	protected global::PrefabRenderer _prefabRenderer;
}
