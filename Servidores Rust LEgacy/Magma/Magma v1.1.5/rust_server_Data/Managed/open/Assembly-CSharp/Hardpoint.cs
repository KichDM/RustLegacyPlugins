using System;
using Facepunch.MeshBatch;
using UnityEngine;

// Token: 0x02000768 RID: 1896
public class Hardpoint : global::IDRemote
{
	// Token: 0x06003F15 RID: 16149 RVA: 0x000E0FF8 File Offset: 0x000DF1F8
	public Hardpoint()
	{
	}

	// Token: 0x06003F16 RID: 16150 RVA: 0x000E1008 File Offset: 0x000DF208
	public void Awake()
	{
		global::HardpointMaster component = base.idMain.GetComponent<global::HardpointMaster>();
		if (component)
		{
			this.SetMaster(component);
		}
		base.Awake();
	}

	// Token: 0x06003F17 RID: 16151 RVA: 0x000E103C File Offset: 0x000DF23C
	public void OnDestroy()
	{
		base.OnDestroy();
	}

	// Token: 0x06003F18 RID: 16152 RVA: 0x000E1044 File Offset: 0x000DF244
	public void SetMaster(global::HardpointMaster master)
	{
		this._master = master;
		master.AddHardpoint(this);
	}

	// Token: 0x06003F19 RID: 16153 RVA: 0x000E1054 File Offset: 0x000DF254
	public global::HardpointMaster GetMaster()
	{
		return this._master;
	}

	// Token: 0x06003F1A RID: 16154 RVA: 0x000E105C File Offset: 0x000DF25C
	public bool IsFree()
	{
		return this.holding == null;
	}

	// Token: 0x06003F1B RID: 16155 RVA: 0x000E106C File Offset: 0x000DF26C
	private void OnDrawGizmos()
	{
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.green;
		global::UnityEngine.Gizmos.DrawCube(base.transform.position, new global::UnityEngine.Vector3(0.2f, 0.2f, 0.2f));
	}

	// Token: 0x06003F1C RID: 16156 RVA: 0x000E10A8 File Offset: 0x000DF2A8
	private void OnDrawGizmosSelected()
	{
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.yellow;
		global::UnityEngine.Gizmos.DrawCube(base.transform.position, new global::UnityEngine.Vector3(0.2f, 0.2f, 0.2f));
	}

	// Token: 0x06003F1D RID: 16157 RVA: 0x000E10E4 File Offset: 0x000DF2E4
	public static global::Hardpoint GetHardpointFromRay(global::UnityEngine.Ray ray, global::Hardpoint.hardpoint_type type)
	{
		global::UnityEngine.RaycastHit raycastHit;
		bool flag;
		global::Facepunch.MeshBatch.MeshBatchInstance meshBatchInstance;
		if (global::Facepunch.MeshBatch.MeshBatchPhysics.Raycast(ray, ref raycastHit, 10f, ref flag, ref meshBatchInstance))
		{
			global::IDMain idmain = (!flag) ? global::IDBase.GetMain(raycastHit.collider) : meshBatchInstance.idMain;
			if (idmain)
			{
				global::HardpointMaster component = idmain.GetComponent<global::HardpointMaster>();
				if (component)
				{
					return component.GetHardpointNear(raycastHit.point, type);
				}
			}
		}
		return null;
	}

	// Token: 0x04002077 RID: 8311
	public global::Hardpoint.hardpoint_type type = global::Hardpoint.hardpoint_type.Generic;

	// Token: 0x04002078 RID: 8312
	private global::DeployableObject holding;

	// Token: 0x04002079 RID: 8313
	private global::HardpointMaster _master;

	// Token: 0x02000769 RID: 1897
	public enum hardpoint_type
	{
		// Token: 0x0400207B RID: 8315
		None,
		// Token: 0x0400207C RID: 8316
		Generic,
		// Token: 0x0400207D RID: 8317
		Door,
		// Token: 0x0400207E RID: 8318
		Turret,
		// Token: 0x0400207F RID: 8319
		Gate,
		// Token: 0x04002080 RID: 8320
		Window
	}
}
