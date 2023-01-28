using System;
using UnityEngine;

// Token: 0x02000067 RID: 103
public class WorkZone : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060002DC RID: 732 RVA: 0x0000E734 File Offset: 0x0000C934
	public WorkZone()
	{
	}

	// Token: 0x060002DD RID: 733 RVA: 0x0000E744 File Offset: 0x0000C944
	public void SetOn(bool on)
	{
		this._isOn = on;
	}

	// Token: 0x060002DE RID: 734 RVA: 0x0000E750 File Offset: 0x0000C950
	public global::CraftingInventory GetFromCollider(global::UnityEngine.Collider other)
	{
		return other.gameObject.GetComponent<global::CraftingInventory>();
	}

	// Token: 0x060002DF RID: 735 RVA: 0x0000E76C File Offset: 0x0000C96C
	public void OnTriggerStay(global::UnityEngine.Collider other)
	{
		if (!this._isOn)
		{
			return;
		}
		global::CraftingInventory fromCollider = this.GetFromCollider(other);
		if (fromCollider == null)
		{
			return;
		}
		fromCollider.MarkWorkBench();
	}

	// Token: 0x04000203 RID: 515
	private bool _isOn = true;
}
