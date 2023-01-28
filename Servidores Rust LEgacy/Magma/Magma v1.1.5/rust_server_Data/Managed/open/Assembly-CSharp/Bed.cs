using System;
using Facepunch.MeshBatch;
using UnityEngine;

// Token: 0x02000774 RID: 1908
public class Bed : global::DeployedRespawn
{
	// Token: 0x06003F4B RID: 16203 RVA: 0x000E1FFC File Offset: 0x000E01FC
	public Bed()
	{
	}

	// Token: 0x06003F4C RID: 16204 RVA: 0x000E2004 File Offset: 0x000E0204
	public new void Awake()
	{
		this.spawnDelay = 180.0;
	}

	// Token: 0x06003F4D RID: 16205 RVA: 0x000E2018 File Offset: 0x000E0218
	public override global::UnityEngine.Quaternion GetSpawnRot()
	{
		return base.transform.rotation;
	}

	// Token: 0x06003F4E RID: 16206 RVA: 0x000E2028 File Offset: 0x000E0228
	public override global::UnityEngine.Vector3 GetSpawnPos()
	{
		return base.transform.position + new global::UnityEngine.Vector3(0f, 0.4f, 0f);
	}

	// Token: 0x06003F4F RID: 16207 RVA: 0x000E205C File Offset: 0x000E025C
	public override void NearbyRespawn()
	{
	}

	// Token: 0x06003F50 RID: 16208 RVA: 0x000E2060 File Offset: 0x000E0260
	public override bool IsValidToSpawn()
	{
		if (base.IsValidToSpawn())
		{
			if (base.GetCarrier())
			{
				global::StructureComponent component = base.GetCarrier().GetComponent<global::StructureComponent>();
				if (component.type == global::StructureComponent.StructureComponentType.Ceiling)
				{
					return true;
				}
			}
			global::UnityEngine.Ray ray;
			ray..ctor(base.transform.position + new global::UnityEngine.Vector3(0f, 0.25f, 0f), global::UnityEngine.Vector3.up);
			global::UnityEngine.RaycastHit raycastHit;
			bool flag;
			global::Facepunch.MeshBatch.MeshBatchInstance meshBatchInstance;
			if (global::Facepunch.MeshBatch.MeshBatchPhysics.Raycast(ray, ref raycastHit, 12f, ref flag, ref meshBatchInstance))
			{
				global::IDMain idmain = (!flag) ? global::IDBase.GetMain(raycastHit.collider) : meshBatchInstance.idMain;
				if (idmain && idmain.GetComponent<global::StructureComponent>())
				{
					return true;
				}
			}
		}
		return false;
	}
}
