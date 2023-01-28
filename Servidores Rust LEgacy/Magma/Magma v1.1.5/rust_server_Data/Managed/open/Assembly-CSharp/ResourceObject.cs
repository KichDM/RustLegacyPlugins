using System;
using uLink;
using UnityEngine;

// Token: 0x02000795 RID: 1941
public class ResourceObject : global::IDMain
{
	// Token: 0x06004091 RID: 16529 RVA: 0x000E70A0 File Offset: 0x000E52A0
	public ResourceObject() : base(0)
	{
	}

	// Token: 0x06004092 RID: 16530 RVA: 0x000E70B8 File Offset: 0x000E52B8
	private void NGC_OnInstantiate(global::NGCView view)
	{
		this.myID = global::NetEntityID.Get(this);
		this._resTarg = base.GetComponent<global::ResourceTarget>();
		global::ServerHelper.SetupForServer(base.gameObject);
		this.TryUpdateMesh();
	}

	// Token: 0x06004093 RID: 16531 RVA: 0x000E70E4 File Offset: 0x000E52E4
	public virtual void ResourcesDepletedMsg()
	{
		global::NetCull.Destroy(base.gameObject);
	}

	// Token: 0x06004094 RID: 16532 RVA: 0x000E70F4 File Offset: 0x000E52F4
	public virtual void ResourcesGathered()
	{
		this.TryUpdateMesh();
	}

	// Token: 0x06004095 RID: 16533 RVA: 0x000E70FC File Offset: 0x000E52FC
	protected void OnDestroy()
	{
		if (this._mySpawner)
		{
			this._mySpawner.WasKilled(base.gameObject);
		}
		base.OnDestroy();
	}

	// Token: 0x06004096 RID: 16534 RVA: 0x000E7128 File Offset: 0x000E5328
	public void SetSpawner(global::UnityEngine.GameObject spawner)
	{
		this._mySpawner = spawner.GetComponent<global::GenericSpawner>();
	}

	// Token: 0x06004097 RID: 16535 RVA: 0x000E7138 File Offset: 0x000E5338
	public void TryUpdateMesh()
	{
		if (this.visualMeshes.Length == 0)
		{
			return;
		}
		float num = this._resTarg.GetPercentFull();
		if (num <= 0f)
		{
			num = 0.01f;
		}
		int num2 = this.visualMeshes.Length - global::UnityEngine.Mathf.CeilToInt(num * (float)this.visualMeshes.Length);
		if (num2 == this._lastModelIndex)
		{
			return;
		}
		global::NetCull.RemoveRPCsByName(this.myID, "modelindex");
		global::NetCull.RPC<int>(this.myID, "modelindex", 5, num2);
		this.ChangeModelIndex(num2);
	}

	// Token: 0x06004098 RID: 16536 RVA: 0x000E71C4 File Offset: 0x000E53C4
	public void ChangeModelIndex(int index)
	{
		this._meshCollider.sharedMesh = this.collisionMeshes[index];
		this._lastModelIndex = index;
	}

	// Token: 0x06004099 RID: 16537 RVA: 0x000E71E0 File Offset: 0x000E53E0
	public void DelayedModelChangeIndex()
	{
		this.ChangeModelIndex(this._pendingMeshIndex);
	}

	// Token: 0x0600409A RID: 16538 RVA: 0x000E71F0 File Offset: 0x000E53F0
	[global::UnityEngine.RPC]
	public void modelindex(int index, global::uLink.NetworkMessageInfo info)
	{
		bool flag = false;
		if (global::EnvironmentControlCenter.Singleton && global::EnvironmentControlCenter.Singleton.IsNight() && global::PlayerClient.GetLocalPlayer().controllable && global::UnityEngine.Vector3.Distance(global::PlayerClient.GetLocalPlayer().controllable.transform.position, base.transform.position) > 20f)
		{
			flag = true;
		}
		if (this.clientMeshChangeEffect && this._lastModelIndex != -1 && !flag)
		{
			global::UnityEngine.GameObject gameObject = global::UnityEngine.Object.Instantiate(this.clientMeshChangeEffect, base.transform.position, base.transform.rotation) as global::UnityEngine.GameObject;
			global::UnityEngine.Object.Destroy(gameObject, 5f);
		}
		this._pendingMeshIndex = index;
		base.Invoke("DelayedModelChangeIndex", 0.15f);
	}

	// Token: 0x040021A1 RID: 8609
	private global::GenericSpawner _mySpawner;

	// Token: 0x040021A2 RID: 8610
	public global::UnityEngine.Mesh[] visualMeshes;

	// Token: 0x040021A3 RID: 8611
	public global::UnityEngine.Mesh[] collisionMeshes;

	// Token: 0x040021A4 RID: 8612
	public global::UnityEngine.GameObject clientMeshChangeEffect;

	// Token: 0x040021A5 RID: 8613
	public global::ResourceTarget _resTarg;

	// Token: 0x040021A6 RID: 8614
	public global::UnityEngine.MeshFilter _meshFilter;

	// Token: 0x040021A7 RID: 8615
	public global::UnityEngine.MeshCollider _meshCollider;

	// Token: 0x040021A8 RID: 8616
	private int _pendingMeshIndex = -1;

	// Token: 0x040021A9 RID: 8617
	private int _lastModelIndex = -1;

	// Token: 0x040021AA RID: 8618
	private global::NetEntityID myID;
}
