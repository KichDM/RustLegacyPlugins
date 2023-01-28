using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Facepunch;
using uLink;
using UnityEngine;

// Token: 0x0200042C RID: 1068
public abstract class RigidObj : global::IDMain, global::IInterpTimedEventReceiver
{
	// Token: 0x06002525 RID: 9509 RVA: 0x0008DFC0 File Offset: 0x0008C1C0
	protected RigidObj(global::RigidObj.FeatureFlags classFeatures) : base(2)
	{
		this.featureFlags = classFeatures;
	}

	// Token: 0x06002526 RID: 9510 RVA: 0x0008DFDC File Offset: 0x0008C1DC
	void global::IInterpTimedEventReceiver.OnInterpTimedEvent()
	{
		if (!this.OnInterpTimedEvent())
		{
			global::InterpTimedEvent.MarkUnhandled();
		}
	}

	// Token: 0x17000855 RID: 2133
	// (get) Token: 0x06002527 RID: 9511 RVA: 0x0008DFF0 File Offset: 0x0008C1F0
	public bool expectsInitialVelocity
	{
		get
		{
			return (byte)(this.featureFlags & global::RigidObj.FeatureFlags.StreamInitialVelocity) == 1;
		}
	}

	// Token: 0x17000856 RID: 2134
	// (get) Token: 0x06002528 RID: 9512 RVA: 0x0008E000 File Offset: 0x0008C200
	public bool expectsOwner
	{
		get
		{
			return (byte)(this.featureFlags & global::RigidObj.FeatureFlags.StreamOwnerViewID) == 2;
		}
	}

	// Token: 0x17000857 RID: 2135
	// (get) Token: 0x06002529 RID: 9513 RVA: 0x0008E010 File Offset: 0x0008C210
	public bool serverSideCollisions
	{
		get
		{
			return (byte)(this.featureFlags & global::RigidObj.FeatureFlags.ServerCollisions) == 0x80;
		}
	}

	// Token: 0x17000858 RID: 2136
	// (get) Token: 0x0600252A RID: 9514 RVA: 0x0008E028 File Offset: 0x0008C228
	// (set) Token: 0x0600252B RID: 9515 RVA: 0x0008E034 File Offset: 0x0008C234
	public bool showing
	{
		get
		{
			return !this.__hiding;
		}
		protected set
		{
			if (this.__hiding == value)
			{
				this.__hiding = !value;
			}
		}
	}

	// Token: 0x17000859 RID: 2137
	// (get) Token: 0x0600252C RID: 9516 RVA: 0x0008E04C File Offset: 0x0008C24C
	public global::Facepunch.NetworkView ownerView
	{
		get
		{
			return (!this.__ownerView) ? (this.__ownerView = global::Facepunch.NetworkView.Find(this.ownerViewID)) : this.__ownerView;
		}
	}

	// Token: 0x0600252D RID: 9517 RVA: 0x0008E088 File Offset: 0x0008C288
	protected void Awake()
	{
		this.rigidbody = base.rigidbody;
		this._interp = base.GetComponent<global::RigidbodyInterpolator>();
	}

	// Token: 0x0600252E RID: 9518 RVA: 0x0008E0A4 File Offset: 0x0008C2A4
	private void __invoke_do_network()
	{
		if (this.__calling_from_do_network)
		{
			return;
		}
		try
		{
			this.__calling_from_do_network = true;
			this.DoNetwork();
		}
		finally
		{
			this.__calling_from_do_network = false;
		}
	}

	// Token: 0x0600252F RID: 9519 RVA: 0x0008E0F4 File Offset: 0x0008C2F4
	protected virtual void DoNetwork()
	{
		base.networkView.RPC("RecieveNetwork", 0xA, new object[]
		{
			this.rigidbody.position,
			this.rigidbody.rotation
		});
		this.serverLastUpdateTimestamp = global::NetCull.time;
	}

	// Token: 0x06002530 RID: 9520 RVA: 0x0008E14C File Offset: 0x0008C34C
	[global::UnityEngine.RPC]
	protected void RecieveNetwork(global::UnityEngine.Vector3 pos, global::UnityEngine.Quaternion rot, global::uLink.NetworkMessageInfo info)
	{
		if (this.hasInterp && this._interp)
		{
			global::PosRot frame;
			frame.position = pos;
			frame.rotation = rot;
			this.rigidbody.isKinematic = true;
			this._interp.SetGoals(frame, info.timestamp);
			this._interp.running = true;
		}
	}

	// Token: 0x06002531 RID: 9521 RVA: 0x0008E1B0 File Offset: 0x0008C3B0
	protected void uLink_OnNetworkInstantiate(global::uLink.NetworkMessageInfo info)
	{
		this.view = (global::Facepunch.NetworkView)info.networkView;
		global::uLink.BitStream initialData = this.view.initialData;
		if (this.expectsInitialVelocity)
		{
			this.initialVelocity = initialData.ReadVector3();
		}
		if (this.expectsOwner)
		{
			this.ownerViewID = initialData.ReadNetworkViewID();
		}
		this.spawnTime = info.timestamp;
		this.updateInterval = 1.0 / ((double)global::NetCull.sendRate * (double)global::UnityEngine.Mathf.Max(1f, this.updateRate));
		this.hasInterp = false;
		global::UnityEngine.Object.Destroy(this._interp);
		if (this.serverSideCollisions)
		{
			this._serverCollision = base.gameObject.AddComponent<global::RigidObjServerCollision>();
			this._serverCollision.rigidObj = this;
		}
		this.rigidbody.isKinematic = false;
		if (this.expectsInitialVelocity)
		{
			this.rigidbody.velocity = this.initialVelocity;
		}
		base.InvokeRepeating("__invoke_do_network", (float)this.updateInterval, (float)this.updateInterval);
	}

	// Token: 0x06002532 RID: 9522 RVA: 0x0008E2B8 File Offset: 0x0008C4B8
	public static void MakeDoneAndDestroy(global::RigidObj rigidObj)
	{
		if (rigidObj)
		{
			if (!rigidObj.__done)
			{
				rigidObj.CancelInvoke("__invoke_do_network");
				if (rigidObj.view)
				{
					rigidObj.__invoke_do_network();
					if (!rigidObj)
					{
						return;
					}
				}
				try
				{
					rigidObj.OnDone();
				}
				finally
				{
					if (rigidObj)
					{
						if (rigidObj.view)
						{
							try
							{
								rigidObj.view.RPC("RODone", 1, new object[0]);
							}
							finally
							{
								rigidObj.__done = true;
								global::NetCull.Destroy(rigidObj.gameObject);
							}
						}
						else
						{
							rigidObj.__done = true;
							global::UnityEngine.Object.Destroy(rigidObj.gameObject);
						}
					}
				}
			}
			else
			{
				global::NetCull.Destroy(rigidObj.gameObject);
			}
		}
	}

	// Token: 0x06002533 RID: 9523 RVA: 0x0008E3BC File Offset: 0x0008C5BC
	[global::System.Obsolete("Do not call manually")]
	[global::UnityEngine.RPC]
	protected void RODone(global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x06002534 RID: 9524
	protected abstract void OnHide();

	// Token: 0x06002535 RID: 9525
	protected abstract void OnShow();

	// Token: 0x06002536 RID: 9526
	protected abstract void OnDone();

	// Token: 0x06002537 RID: 9527 RVA: 0x0008E3C0 File Offset: 0x0008C5C0
	protected virtual void OnServerCollisionEnter(global::UnityEngine.Collision collision)
	{
	}

	// Token: 0x06002538 RID: 9528 RVA: 0x0008E3C4 File Offset: 0x0008C5C4
	protected virtual void OnServerCollisionStay(global::UnityEngine.Collision collision)
	{
	}

	// Token: 0x06002539 RID: 9529 RVA: 0x0008E3C8 File Offset: 0x0008C5C8
	protected virtual void OnServerCollisionExit(global::UnityEngine.Collision collision)
	{
	}

	// Token: 0x0600253A RID: 9530 RVA: 0x0008E3CC File Offset: 0x0008C5CC
	internal void OnServerCollision(byte kind, global::UnityEngine.Collision collision)
	{
		switch (kind)
		{
		case 0:
			this.OnServerCollisionEnter(collision);
			break;
		case 1:
			this.OnServerCollisionExit(collision);
			break;
		case 2:
			this.OnServerCollisionStay(collision);
			break;
		default:
			throw new global::System.NotImplementedException();
		}
	}

	// Token: 0x0600253B RID: 9531 RVA: 0x0008E41C File Offset: 0x0008C61C
	protected virtual bool OnInterpTimedEvent()
	{
		string tag = global::InterpTimedEvent.Tag;
		if (tag != null)
		{
			if (global::RigidObj.<>f__switch$map6 == null)
			{
				global::RigidObj.<>f__switch$map6 = new global::System.Collections.Generic.Dictionary<string, int>(2)
				{
					{
						"_init",
						0
					},
					{
						"_done",
						1
					}
				};
			}
			int num;
			if (global::RigidObj.<>f__switch$map6.TryGetValue(tag, out num))
			{
				if (num == 0)
				{
					this.showing = true;
					if (this.expectsInitialVelocity)
					{
						this.rigidbody.isKinematic = false;
						this.rigidbody.velocity = this.initialVelocity;
					}
					return true;
				}
				if (num == 1)
				{
					try
					{
						this.OnDone();
					}
					finally
					{
						try
						{
							this.showing = false;
						}
						finally
						{
							global::UnityEngine.Object.Destroy(base.gameObject);
						}
					}
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600253C RID: 9532 RVA: 0x0008E514 File Offset: 0x0008C714
	public static TRigidObj InstantiateRigidObj<TRigidObj>(global::uLink.NetworkViewID owner, TRigidObj prefabObj, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, global::UnityEngine.Vector3 velocity) where TRigidObj : global::RigidObj
	{
		global::UnityEngine.GameObject gameObject = prefabObj.gameObject;
		global::UnityEngine.GameObject gameObject2;
		if (prefabObj.expectsInitialVelocity)
		{
			if (prefabObj.expectsOwner)
			{
				gameObject2 = global::NetCull.InstantiateDynamicWithArgs(gameObject, position, rotation, new object[]
				{
					velocity,
					owner
				});
			}
			else
			{
				gameObject2 = global::NetCull.InstantiateDynamicWithArgs<global::UnityEngine.Vector3>(gameObject, position, rotation, velocity);
			}
		}
		else if (prefabObj.expectsOwner)
		{
			gameObject2 = global::NetCull.InstantiateDynamicWithArgs<global::uLink.NetworkViewID>(gameObject, position, rotation, owner);
		}
		else
		{
			gameObject2 = global::NetCull.InstantiateDynamic(gameObject, position, rotation);
		}
		return gameObject2.GetComponent<TRigidObj>();
	}

	// Token: 0x0600253D RID: 9533 RVA: 0x0008E5BC File Offset: 0x0008C7BC
	public static TRigidObj InstantiateRigidObj<TRigidObj>(global::uLink.NetworkViewID owner, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, global::UnityEngine.Vector3 velocity) where TRigidObj : global::RigidObj
	{
		TRigidObj component = prefab.GetComponent<TRigidObj>();
		global::UnityEngine.GameObject gameObject;
		if (component.expectsInitialVelocity)
		{
			if (component.expectsOwner)
			{
				gameObject = global::NetCull.InstantiateDynamicWithArgs(prefab, position, rotation, new object[]
				{
					velocity,
					owner
				});
			}
			else
			{
				gameObject = global::NetCull.InstantiateDynamicWithArgs<global::UnityEngine.Vector3>(prefab, position, rotation, velocity);
			}
		}
		else if (component.expectsOwner)
		{
			gameObject = global::NetCull.InstantiateDynamicWithArgs<global::uLink.NetworkViewID>(prefab, position, rotation, owner);
		}
		else
		{
			gameObject = global::NetCull.InstantiateDynamic(prefab, position, rotation);
		}
		return gameObject.GetComponent<TRigidObj>();
	}

	// Token: 0x040012E6 RID: 4838
	private const string kDoNetworkMethodName = "__invoke_do_network";

	// Token: 0x040012E7 RID: 4839
	[global::System.NonSerialized]
	public global::UnityEngine.Rigidbody rigidbody;

	// Token: 0x040012E8 RID: 4840
	[global::System.NonSerialized]
	protected readonly global::RigidObj.FeatureFlags featureFlags;

	// Token: 0x040012E9 RID: 4841
	[global::UnityEngine.SerializeField]
	private float updateRate = 2f;

	// Token: 0x040012EA RID: 4842
	private double updateInterval;

	// Token: 0x040012EB RID: 4843
	private double serverLastUpdateTimestamp;

	// Token: 0x040012EC RID: 4844
	protected global::Facepunch.NetworkView view;

	// Token: 0x040012ED RID: 4845
	private global::RigidbodyInterpolator _interp;

	// Token: 0x040012EE RID: 4846
	private global::RigidObjServerCollision _serverCollision;

	// Token: 0x040012EF RID: 4847
	private bool hasInterp;

	// Token: 0x040012F0 RID: 4848
	private bool __hiding;

	// Token: 0x040012F1 RID: 4849
	private bool __done;

	// Token: 0x040012F2 RID: 4850
	private bool __calling_from_do_network;

	// Token: 0x040012F3 RID: 4851
	protected global::UnityEngine.Vector3 initialVelocity;

	// Token: 0x040012F4 RID: 4852
	protected double spawnTime;

	// Token: 0x040012F5 RID: 4853
	protected global::uLink.NetworkViewID ownerViewID;

	// Token: 0x040012F6 RID: 4854
	private global::Facepunch.NetworkView __ownerView;

	// Token: 0x040012F7 RID: 4855
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static global::System.Collections.Generic.Dictionary<string, int> <>f__switch$map6;

	// Token: 0x0200042D RID: 1069
	[global::System.Flags]
	protected enum FeatureFlags : byte
	{
		// Token: 0x040012F9 RID: 4857
		StreamInitialVelocity = 1,
		// Token: 0x040012FA RID: 4858
		StreamOwnerViewID = 2,
		// Token: 0x040012FB RID: 4859
		ServerCollisions = 0x80
	}
}
