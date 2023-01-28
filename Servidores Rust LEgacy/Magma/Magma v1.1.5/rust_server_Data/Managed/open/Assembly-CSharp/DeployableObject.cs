using System;
using Facepunch.MeshBatch;
using Magma;
using RustProto;
using RustProto.Helpers;
using uLink;
using UnityEngine;

// Token: 0x02000776 RID: 1910
[global::NGCAutoAddScript]
public class DeployableObject : global::IDMain, global::IDeployedObjectMain, global::IServerSaveable, global::IServerSaveNotify, global::ICarriableTrans
{
	// Token: 0x06003F55 RID: 16213 RVA: 0x000E216C File Offset: 0x000E036C
	public DeployableObject() : this(0)
	{
	}

	// Token: 0x06003F56 RID: 16214 RVA: 0x000E2178 File Offset: 0x000E0378
	protected DeployableObject(global::IDFlags flags) : base(flags)
	{
	}

	// Token: 0x06003F57 RID: 16215 RVA: 0x000E21B0 File Offset: 0x000E03B0
	void global::IServerSaveNotify.PostLoad()
	{
		this.CacheCreator();
		if (!this._carrier)
		{
			this.GrabCarrier();
		}
		this.UpdateClientHealth();
	}

	// Token: 0x17000BE5 RID: 3045
	// (get) Token: 0x06003F58 RID: 16216 RVA: 0x000E21E0 File Offset: 0x000E03E0
	global::DeployedObjectInfo global::IDeployedObjectMain.DeployedObjectInfo
	{
		get
		{
			global::DeployedObjectInfo result;
			result.userID = this.ownerID;
			result.valid = (this.ownerID != 0UL);
			return result;
		}
	}

	// Token: 0x06003F59 RID: 16217 RVA: 0x000E2210 File Offset: 0x000E0410
	public void uLink_OnNetworkInstantiate(global::uLink.NetworkMessageInfo info)
	{
		this.SharedNetworkInstantiate();
	}

	// Token: 0x06003F5A RID: 16218 RVA: 0x000E2218 File Offset: 0x000E0418
	public void NGC_OnInstantiate(global::NGCView view)
	{
		this.SharedNetworkInstantiate();
	}

	// Token: 0x06003F5B RID: 16219 RVA: 0x000E2220 File Offset: 0x000E0420
	public void SharedNetworkInstantiate()
	{
		this.UpdateClientHealth();
	}

	// Token: 0x06003F5C RID: 16220 RVA: 0x000E2228 File Offset: 0x000E0428
	public void Awake()
	{
		global::ServerHelper.SetupForServer(base.gameObject);
		this._EnvDecay = base.GetComponent<global::EnvDecay>();
	}

	// Token: 0x06003F5D RID: 16221 RVA: 0x000E2244 File Offset: 0x000E0444
	public void OnDestroy()
	{
		if (this._carrier)
		{
			this._carrier.RemoveObject(this);
			this._carrier = null;
		}
		base.OnDestroy();
	}

	// Token: 0x06003F5E RID: 16222 RVA: 0x000E2270 File Offset: 0x000E0470
	public void OnAddedToCarrier(global::TransCarrier carrier)
	{
		this._carrier = carrier;
	}

	// Token: 0x06003F5F RID: 16223 RVA: 0x000E227C File Offset: 0x000E047C
	public void OnDroppedFromCarrier(global::TransCarrier carrier)
	{
		this._carrier = null;
		global::NetCull.Destroy(base.gameObject);
	}

	// Token: 0x06003F60 RID: 16224 RVA: 0x000E2290 File Offset: 0x000E0490
	public void Touched()
	{
		global::TransCarrier carrier = this.GetCarrier();
		if (!carrier)
		{
			return;
		}
		global::IDMain idMain = carrier.idMain;
		if (!idMain)
		{
			return;
		}
		global::EnvDecay local;
		if (idMain is global::StructureComponent)
		{
			((global::StructureComponent)idMain).Touched();
		}
		else if (idMain is global::DeployableObject)
		{
			((global::DeployableObject)idMain).DecayTouch();
		}
		else if (local = idMain.GetLocal<global::EnvDecay>())
		{
			local.DecayTouch();
		}
	}

	// Token: 0x06003F61 RID: 16225 RVA: 0x000E2314 File Offset: 0x000E0514
	public global::TransCarrier GetCarrier()
	{
		return this._carrier;
	}

	// Token: 0x06003F62 RID: 16226 RVA: 0x000E231C File Offset: 0x000E051C
	public void SetDecayEnabled(bool on)
	{
		if (this._EnvDecay)
		{
			this._EnvDecay.SetDecayEnabled(on);
		}
	}

	// Token: 0x06003F63 RID: 16227 RVA: 0x000E233C File Offset: 0x000E053C
	public void DecayTouch()
	{
		if (this._EnvDecay)
		{
			this._EnvDecay.DecayTouch();
		}
	}

	// Token: 0x06003F64 RID: 16228 RVA: 0x000E235C File Offset: 0x000E055C
	public void WriteObjectSave(ref global::RustProto.SavedObject.Builder saveobj)
	{
		using (global::RustProto.Helpers.Recycler<global::RustProto.objectDeployable, global::RustProto.objectDeployable.Builder> recycler = global::RustProto.objectDeployable.Recycler())
		{
			global::RustProto.objectDeployable.Builder builder = recycler.OpenBuilder();
			builder.SetCreatorID(this.creatorID);
			builder.SetOwnerID(this.ownerID);
			saveobj.SetDeployable(builder);
		}
		using (global::RustProto.Helpers.Recycler<global::RustProto.objectICarriableTrans, global::RustProto.objectICarriableTrans.Builder> recycler2 = global::RustProto.objectICarriableTrans.Recycler())
		{
			global::RustProto.objectICarriableTrans.Builder builder2 = recycler2.OpenBuilder();
			global::NetEntityID netEntityID;
			if (this._carrier && (int)global::NetEntityID.Of(this._carrier, out netEntityID) != 0)
			{
				builder2.SetTransCarrierID(netEntityID.id);
			}
			else
			{
				builder2.ClearTransCarrierID();
			}
			saveobj.SetCarriableTrans(builder2);
		}
	}

	// Token: 0x06003F65 RID: 16229 RVA: 0x000E2444 File Offset: 0x000E0644
	public void ReadObjectSave(ref global::RustProto.SavedObject saveobj)
	{
		if (saveobj.HasDeployable)
		{
			this.creatorID = saveobj.Deployable.CreatorID;
			this.ownerID = saveobj.Deployable.OwnerID;
			this.CreatorSet();
		}
		if (saveobj.HasCarriableTrans && saveobj.CarriableTrans.HasTransCarrierID)
		{
			global::TransCarrier.AddToTransCarrierPostLoad(this, saveobj.CarriableTrans.TransCarrierID);
		}
	}

	// Token: 0x06003F66 RID: 16230 RVA: 0x000E24B8 File Offset: 0x000E06B8
	public void GrabCarrier()
	{
		global::UnityEngine.Ray ray;
		ray..ctor(base.transform.position + global::UnityEngine.Vector3.up * 0.01f, global::UnityEngine.Vector3.down);
		global::UnityEngine.RaycastHit raycastHit;
		bool flag;
		global::Facepunch.MeshBatch.MeshBatchInstance meshBatchInstance;
		if (global::Facepunch.MeshBatch.MeshBatchPhysics.Raycast(ray, ref raycastHit, 5f, ref flag, ref meshBatchInstance))
		{
			global::IDMain idmain = (!flag) ? global::IDBase.GetMain(raycastHit.collider) : meshBatchInstance.idMain;
			if (idmain)
			{
				global::TransCarrier local = idmain.GetLocal<global::TransCarrier>();
				if (local)
				{
					local.AddObject(this);
				}
			}
		}
	}

	// Token: 0x06003F67 RID: 16231 RVA: 0x000E2550 File Offset: 0x000E0750
	public void CacheCreator()
	{
		global::NetEntityID entID = global::NetEntityID.Get(this);
		if (this.ownerBuffered)
		{
			global::NetCull.RemoveRPCsByName(entID, "GetOwnerInfo");
		}
		this.ownerBuffered = true;
		global::NetCull.RPC<ulong, ulong>(entID, "GetOwnerInfo", 0xE, this.creatorID, this.ownerID);
	}

	// Token: 0x06003F68 RID: 16232 RVA: 0x000E259C File Offset: 0x000E079C
	[global::UnityEngine.RPC]
	public void GetOwnerInfo(ulong creator, ulong owner)
	{
	}

	// Token: 0x06003F69 RID: 16233 RVA: 0x000E25A0 File Offset: 0x000E07A0
	public virtual void SetupCreator(global::Controllable controllable)
	{
		global::uLink.NetworkPlayer owner = controllable.networkView.owner;
		global::NetUser netUser = global::NetUser.Find(owner);
		if (netUser != null)
		{
			this.creatorID = netUser.user.Userid;
			this.ownerID = netUser.user.Userid;
			this.CacheCreator();
		}
		this.CreatorSet();
	}

	// Token: 0x06003F6A RID: 16234 RVA: 0x000E25F4 File Offset: 0x000E07F4
	public virtual void CreatorSet()
	{
	}

	// Token: 0x06003F6B RID: 16235 RVA: 0x000E25F8 File Offset: 0x000E07F8
	public void OnKilled()
	{
		if (this.handleDeathHere)
		{
			if (this.clientDeathEffect)
			{
				global::NetEntityID entID = global::NetEntityID.Get(this);
				global::NetCull.RPC(entID, "Client_OnKilled", 5);
			}
			global::NetCull.Destroy(base.gameObject);
			if (this.corpseObject)
			{
				global::NetCull.InstantiateStatic(this.corpseObject, base.transform.position, base.transform.rotation);
			}
		}
	}

	// Token: 0x06003F6C RID: 16236 RVA: 0x000E2674 File Offset: 0x000E0874
	[global::UnityEngine.RPC]
	public void Client_OnKilled()
	{
	}

	// Token: 0x06003F6D RID: 16237 RVA: 0x000E2678 File Offset: 0x000E0878
	public void OnHurt(global::DamageEvent damage)
	{
		global::Magma.Hooks.EntityHurt(this, ref damage);
	}

	// Token: 0x06003F6E RID: 16238 RVA: 0x000E2684 File Offset: 0x000E0884
	public void OnRepair()
	{
		this.UpdateClientHealth();
	}

	// Token: 0x06003F6F RID: 16239 RVA: 0x000E268C File Offset: 0x000E088C
	public void UpdateClientHealth()
	{
		this.healthBuffer.CheckAuto(this, "ClientHealthUpdate", false, false, 0.01f, (global::BufferHealthRPC.Flags)0);
	}

	// Token: 0x06003F70 RID: 16240 RVA: 0x000E26A8 File Offset: 0x000E08A8
	[global::UnityEngine.RPC]
	public void ClientHealthUpdate(float newHealth)
	{
	}

	// Token: 0x06003F71 RID: 16241 RVA: 0x000E26AC File Offset: 0x000E08AC
	public bool BelongsTo(global::Controllable controllable)
	{
		return global::Magma.Hooks.CheckOwner(this, controllable);
	}

	// Token: 0x06003F72 RID: 16242 RVA: 0x000E26C4 File Offset: 0x000E08C4
	public static bool IsValidLocation(global::UnityEngine.Vector3 location, global::UnityEngine.Vector3 surfaceNormal, global::UnityEngine.Quaternion rotation, global::DeployableObject prefab)
	{
		if (prefab.doEdgeCheck)
		{
			return false;
		}
		float num = global::UnityEngine.Vector3.Angle(surfaceNormal, global::UnityEngine.Vector3.up);
		return num <= prefab.maxSlope;
	}

	// Token: 0x040020A6 RID: 8358
	public bool decayProtector;

	// Token: 0x040020A7 RID: 8359
	public bool cantPlaceOn;

	// Token: 0x040020A8 RID: 8360
	public bool doEdgeCheck;

	// Token: 0x040020A9 RID: 8361
	public float maxEdgeDifferential = 1f;

	// Token: 0x040020AA RID: 8362
	public float maxSlope = 30f;

	// Token: 0x040020AB RID: 8363
	public ulong creatorID;

	// Token: 0x040020AC RID: 8364
	public ulong ownerID;

	// Token: 0x040020AD RID: 8365
	public string ownerName = string.Empty;

	// Token: 0x040020AE RID: 8366
	public bool handleDeathHere;

	// Token: 0x040020AF RID: 8367
	public global::UnityEngine.GameObject corpseObject;

	// Token: 0x040020B0 RID: 8368
	public global::TransCarrier _carrier;

	// Token: 0x040020B1 RID: 8369
	public global::UnityEngine.GameObject clientDeathEffect;

	// Token: 0x040020B2 RID: 8370
	private global::EnvDecay _EnvDecay;

	// Token: 0x040020B3 RID: 8371
	[global::System.NonSerialized]
	private bool ownerBuffered;

	// Token: 0x040020B4 RID: 8372
	[global::System.NonSerialized]
	private global::BufferHealthRPC healthBuffer;
}
