using System;
using uLink;
using UnityEngine;

// Token: 0x020000A2 RID: 162
public class SupplyDropPlane : global::IDMain
{
	// Token: 0x0600031C RID: 796 RVA: 0x0000F09C File Offset: 0x0000D29C
	public SupplyDropPlane() : this(0)
	{
	}

	// Token: 0x0600031D RID: 797 RVA: 0x0000F0A8 File Offset: 0x0000D2A8
	protected SupplyDropPlane(global::IDFlags idFlags) : base(idFlags)
	{
	}

	// Token: 0x0600031E RID: 798 RVA: 0x0000F0D8 File Offset: 0x0000D2D8
	private void uLink_OnNetworkInstantiate(global::uLink.NetworkMessageInfo info)
	{
		this._interp = base.GetComponent<global::TransformInterpolator>();
		this._lastMoveTime = global::NetCull.localTime;
		base.InvokeRepeating("DoNetwork", 0f, global::NetCull.sendIntervalF);
		this._interp.running = false;
		global::ServerHelper.SetupForServer(base.gameObject);
	}

	// Token: 0x0600031F RID: 799 RVA: 0x0000F128 File Offset: 0x0000D328
	public void Update()
	{
	}

	// Token: 0x06000320 RID: 800 RVA: 0x0000F12C File Offset: 0x0000D32C
	public void TargetReached()
	{
		if (this.droppedPayload)
		{
			return;
		}
		this.droppedPayload = true;
		int num = global::UnityEngine.Random.Range(1, this.TEMP_numCratesToDrop + 1);
		float num2 = 0f;
		for (int i = 0; i < num; i++)
		{
			base.Invoke("DropCrate", num2);
			num2 += global::UnityEngine.Random.RandomRange(0.3f, 0.6f);
		}
		this.targetPos += base.transform.forward * this.maxSpeed * 30f;
		this.targetPos.y = this.targetPos.y + 800f;
		base.Invoke("NetDestroy", 20f);
	}

	// Token: 0x06000321 RID: 801 RVA: 0x0000F1EC File Offset: 0x0000D3EC
	public void NetDestroy()
	{
		base.CancelInvoke();
		global::NetCull.Destroy(base.gameObject);
	}

	// Token: 0x06000322 RID: 802 RVA: 0x0000F200 File Offset: 0x0000D400
	public void DropCrate()
	{
		global::UnityEngine.Vector3 position = base.transform.position - base.transform.forward * 50f;
		global::UnityEngine.GameObject gameObject = global::NetCull.InstantiateClassic("SupplyCrate", position, global::UnityEngine.Quaternion.Euler(new global::UnityEngine.Vector3(0f, global::UnityEngine.Random.Range(0f, 360f), 0f)), 0);
		gameObject.rigidbody.centerOfMass = new global::UnityEngine.Vector3(0f, -1.5f, 0f);
		gameObject.rigidbody.AddForceAtPosition(-base.transform.forward * 50f, gameObject.transform.position - new global::UnityEngine.Vector3(0f, 1f, 0f));
	}

	// Token: 0x06000323 RID: 803 RVA: 0x0000F2CC File Offset: 0x0000D4CC
	public void SetDropTarget(global::UnityEngine.Vector3 pos)
	{
		this.dropTargetPos = pos;
		this.targetPos = this.dropTargetPos;
	}

	// Token: 0x06000324 RID: 804 RVA: 0x0000F2E4 File Offset: 0x0000D4E4
	public void DoMovement()
	{
		double num = global::NetCull.localTime - this._lastMoveTime;
		this._lastMoveTime = global::NetCull.localTime;
		if (num <= 0.0)
		{
			return;
		}
		global::UnityEngine.Quaternion quaternion = base.transform.rotation;
		global::UnityEngine.Vector3 vector = base.transform.forward;
		if (global::UnityEngine.Vector3.Distance(this.targetPos, base.transform.position) > 5f)
		{
			vector = this.targetPos - base.transform.position;
			vector.Normalize();
			quaternion = global::UnityEngine.Quaternion.LookRotation(vector);
		}
		base.transform.position += vector * (float)((double)this.maxSpeed * num);
		float num2 = global::UnityEngine.Vector3.Distance(base.transform.position, this.dropTargetPos);
		base.transform.rotation = global::UnityEngine.Quaternion.Lerp(base.transform.rotation, quaternion, (float)num * 0.25f);
		if (this.approachingTarget && num2 > this.lastDist)
		{
			this.approachingTarget = false;
			this.TargetReached();
		}
		this.lastDist = num2;
	}

	// Token: 0x06000325 RID: 805 RVA: 0x0000F404 File Offset: 0x0000D604
	public void DoNetwork()
	{
		this.DoMovement();
		base.networkView.RPC("GetNetworkUpdate", 9, new object[]
		{
			base.transform.position,
			base.transform.rotation
		});
	}

	// Token: 0x040002DC RID: 732
	public global::UnityEngine.GameObject[] propellers;

	// Token: 0x040002DD RID: 733
	public global::UnityEngine.Vector3 startPos;

	// Token: 0x040002DE RID: 734
	public global::UnityEngine.Vector3 dropTargetPos;

	// Token: 0x040002DF RID: 735
	public global::UnityEngine.Quaternion startAng;

	// Token: 0x040002E0 RID: 736
	public float maxSpeed = 250f;

	// Token: 0x040002E1 RID: 737
	private bool passedTarget;

	// Token: 0x040002E2 RID: 738
	protected global::UnityEngine.Vector3 targetPos;

	// Token: 0x040002E3 RID: 739
	protected float lastDist = float.PositiveInfinity;

	// Token: 0x040002E4 RID: 740
	protected bool approachingTarget = true;

	// Token: 0x040002E5 RID: 741
	protected float targetReachedTime;

	// Token: 0x040002E6 RID: 742
	protected bool droppedPayload;

	// Token: 0x040002E7 RID: 743
	public int TEMP_numCratesToDrop = 3;

	// Token: 0x040002E8 RID: 744
	protected global::TransformInterpolator _interp;

	// Token: 0x040002E9 RID: 745
	protected double _lastMoveTime;
}
