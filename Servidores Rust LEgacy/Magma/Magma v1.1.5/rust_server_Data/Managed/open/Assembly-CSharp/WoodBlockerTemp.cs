using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200061A RID: 1562
public class WoodBlockerTemp : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060031A7 RID: 12711 RVA: 0x000BEAE0 File Offset: 0x000BCCE0
	public WoodBlockerTemp()
	{
	}

	// Token: 0x060031A8 RID: 12712 RVA: 0x000BEAE8 File Offset: 0x000BCCE8
	private static void TryInitBlockers()
	{
		if (global::WoodBlockerTemp._blockers == null)
		{
			global::WoodBlockerTemp._blockers = new global::System.Collections.Generic.List<global::WoodBlockerTemp>();
		}
	}

	// Token: 0x060031A9 RID: 12713 RVA: 0x000BEB00 File Offset: 0x000BCD00
	private void Awake()
	{
		global::WoodBlockerTemp.TryInitBlockers();
		this.numWood = (float)global::UnityEngine.Random.Range(0xA, 0xF);
		global::WoodBlockerTemp._blockers.Add(this);
		global::UnityEngine.Object.Destroy(base.gameObject, 300f);
	}

	// Token: 0x060031AA RID: 12714 RVA: 0x000BEB40 File Offset: 0x000BCD40
	public static global::WoodBlockerTemp GetBlockerForPoint(global::UnityEngine.Vector3 point)
	{
		global::WoodBlockerTemp.TryInitBlockers();
		foreach (global::WoodBlockerTemp woodBlockerTemp in global::WoodBlockerTemp._blockers)
		{
			float num = global::UnityEngine.Vector3.Distance(woodBlockerTemp.transform.position, point);
			if (num < 4f)
			{
				return woodBlockerTemp;
			}
		}
		global::UnityEngine.GameObject gameObject = global::UnityEngine.GameObject.CreatePrimitive(0);
		global::WoodBlockerTemp woodBlockerTemp2 = (global::WoodBlockerTemp)gameObject.AddComponent("WoodBlockerTemp");
		woodBlockerTemp2.renderer.enabled = false;
		woodBlockerTemp2.collider.enabled = false;
		woodBlockerTemp2.transform.position = point;
		woodBlockerTemp2.name = "WBT";
		return woodBlockerTemp2;
	}

	// Token: 0x060031AB RID: 12715 RVA: 0x000BEC1C File Offset: 0x000BCE1C
	public void OnDestroy()
	{
		global::WoodBlockerTemp._blockers.Remove(this);
	}

	// Token: 0x060031AC RID: 12716 RVA: 0x000BEC2C File Offset: 0x000BCE2C
	public bool HasWood()
	{
		return this.numWood >= 1f;
	}

	// Token: 0x060031AD RID: 12717 RVA: 0x000BEC40 File Offset: 0x000BCE40
	public float GetWoodLeft()
	{
		return this.numWood;
	}

	// Token: 0x060031AE RID: 12718 RVA: 0x000BEC48 File Offset: 0x000BCE48
	public void ConsumeWood(float consume)
	{
		this.numWood -= consume;
		if (this.numWood < 0f)
		{
			this.numWood = 0f;
		}
	}

	// Token: 0x04001BC9 RID: 7113
	public static global::System.Collections.Generic.List<global::WoodBlockerTemp> _blockers;

	// Token: 0x04001BCA RID: 7114
	public float numWood;
}
