using System;
using System.Collections.Generic;
using Facepunch;
using uLink;
using UnityEngine;

// Token: 0x0200041B RID: 1051
[global::UnityEngine.AddComponentMenu("")]
public sealed class NetInstance : global::IDLocal
{
	// Token: 0x0600247F RID: 9343 RVA: 0x0008B490 File Offset: 0x00089690
	public NetInstance()
	{
		this.preDestroy = new global::DisposeCallbackList<global::NetInstance, global::NetInstance.CallbackFunction>(this, global::NetInstance.callbackFire);
		this.postCreate = new global::DisposeCallbackList<global::NetInstance, global::NetInstance.CallbackFunction>(this, global::NetInstance.callbackFire);
		this.preCreate = new global::DisposeCallbackList<global::NetInstance, global::NetInstance.CallbackFunction>(this, global::NetInstance.callbackFire);
	}

	// Token: 0x06002480 RID: 9344 RVA: 0x0008B4CC File Offset: 0x000896CC
	// Note: this type is marked as 'beforefieldinit'.
	static NetInstance()
	{
	}

	// Token: 0x14000014 RID: 20
	// (add) Token: 0x06002481 RID: 9345 RVA: 0x0008B4E0 File Offset: 0x000896E0
	// (remove) Token: 0x06002482 RID: 9346 RVA: 0x0008B4F0 File Offset: 0x000896F0
	public event global::NetInstance.CallbackFunction onPreDestroy
	{
		add
		{
			this.preDestroy.Add(value);
		}
		remove
		{
			this.preDestroy.Remove(value);
		}
	}

	// Token: 0x14000015 RID: 21
	// (add) Token: 0x06002483 RID: 9347 RVA: 0x0008B500 File Offset: 0x00089700
	// (remove) Token: 0x06002484 RID: 9348 RVA: 0x0008B510 File Offset: 0x00089710
	public event global::NetInstance.CallbackFunction onPreCreate
	{
		add
		{
			this.preCreate.Add(value);
		}
		remove
		{
			this.preCreate.Remove(value);
		}
	}

	// Token: 0x14000016 RID: 22
	// (add) Token: 0x06002485 RID: 9349 RVA: 0x0008B520 File Offset: 0x00089720
	// (remove) Token: 0x06002486 RID: 9350 RVA: 0x0008B530 File Offset: 0x00089730
	public event global::NetInstance.CallbackFunction onPostCreate
	{
		add
		{
			this.postCreate.Add(value);
		}
		remove
		{
			this.postCreate.Remove(value);
		}
	}

	// Token: 0x17000837 RID: 2103
	// (get) Token: 0x06002487 RID: 9351 RVA: 0x0008B540 File Offset: 0x00089740
	public bool serverSide
	{
		get
		{
			return this.args.server;
		}
	}

	// Token: 0x17000838 RID: 2104
	// (get) Token: 0x06002488 RID: 9352 RVA: 0x0008B550 File Offset: 0x00089750
	public bool clientSide
	{
		get
		{
			return this.args.client;
		}
	}

	// Token: 0x17000839 RID: 2105
	// (get) Token: 0x06002489 RID: 9353 RVA: 0x0008B560 File Offset: 0x00089760
	public bool isProxy
	{
		get
		{
			return this.prepared && this.local && !this.args.server;
		}
	}

	// Token: 0x1700083A RID: 2106
	// (get) Token: 0x0600248A RID: 9354 RVA: 0x0008B58C File Offset: 0x0008978C
	public global::IDMain prefab
	{
		get
		{
			return this.args.prefab;
		}
	}

	// Token: 0x1700083B RID: 2107
	// (get) Token: 0x0600248B RID: 9355 RVA: 0x0008B59C File Offset: 0x0008979C
	public global::uLink.NetworkView prefabNetworkView
	{
		get
		{
			return this.args.prefabNetworkView;
		}
	}

	// Token: 0x1700083C RID: 2108
	// (get) Token: 0x0600248C RID: 9356 RVA: 0x0008B5AC File Offset: 0x000897AC
	public global::NetMainPrefab netMain
	{
		get
		{
			return this.args.netMain;
		}
	}

	// Token: 0x1700083D RID: 2109
	// (get) Token: 0x0600248D RID: 9357 RVA: 0x0008B5BC File Offset: 0x000897BC
	public bool wasCreatedByCustomInstantiate
	{
		get
		{
			return this.args.hasCustomInstantiator;
		}
	}

	// Token: 0x1700083E RID: 2110
	// (get) Token: 0x0600248E RID: 9358 RVA: 0x0008B5CC File Offset: 0x000897CC
	public global::IPrefabCustomInstantiate customeInstantiateCreator
	{
		get
		{
			return this.args.customInstantiate;
		}
	}

	// Token: 0x0600248F RID: 9359 RVA: 0x0008B5DC File Offset: 0x000897DC
	private static void CallbackFire(global::NetInstance instance, global::NetInstance.CallbackFunction func)
	{
		func(instance);
	}

	// Token: 0x06002490 RID: 9360 RVA: 0x0008B5E8 File Offset: 0x000897E8
	internal void zzz___onpredestroy()
	{
		this.preDestroy.Dispose();
	}

	// Token: 0x06002491 RID: 9361 RVA: 0x0008B5F8 File Offset: 0x000897F8
	internal void zzz___onprecreate()
	{
		this.preCreate.Dispose();
	}

	// Token: 0x06002492 RID: 9362 RVA: 0x0008B608 File Offset: 0x00089808
	internal void zzz___onpostcreate()
	{
		this.postCreate.Dispose();
	}

	// Token: 0x06002493 RID: 9363 RVA: 0x0008B618 File Offset: 0x00089818
	private void OnDestroy()
	{
		this.postCreate = (this.preCreate = (this.preDestroy = global::DisposeCallbackList<global::NetInstance, global::NetInstance.CallbackFunction>.invalid));
	}

	// Token: 0x1700083F RID: 2111
	// (get) Token: 0x06002494 RID: 9364 RVA: 0x0008B644 File Offset: 0x00089844
	public static global::NetInstance current
	{
		get
		{
			return global::NetMainPrefab.zzz__currentNetInstance;
		}
	}

	// Token: 0x06002495 RID: 9365 RVA: 0x0008B64C File Offset: 0x0008984C
	public static bool IsCurrentlyDestroying(global::IDMain main)
	{
		global::NetInstance current = global::NetInstance.current;
		return current && current.idMain == main;
	}

	// Token: 0x06002496 RID: 9366 RVA: 0x0008B67C File Offset: 0x0008987C
	public static bool IsCurrentlyDestroying(global::IDLocal local)
	{
		global::NetInstance current = global::NetInstance.current;
		return current && current.idMain == local.idMain;
	}

	// Token: 0x06002497 RID: 9367 RVA: 0x0008B6B0 File Offset: 0x000898B0
	public static bool IsCurrentlyDestroying(global::IDRemote remote)
	{
		global::NetInstance current = global::NetInstance.current;
		return current && current.idMain == remote.idMain;
	}

	// Token: 0x06002498 RID: 9368 RVA: 0x0008B6E4 File Offset: 0x000898E4
	internal static void PreServerDestroy(global::UnityEngine.GameObject go)
	{
		if (go && !global::NetInstance.PreServerDestroy(go.GetComponent<global::NetInstance>()))
		{
			global::NetInstance.NonNetInstanceWorkaround.PreServerDestroy(global::IDBase.GetMain(go));
		}
	}

	// Token: 0x06002499 RID: 9369 RVA: 0x0008B718 File Offset: 0x00089918
	internal static bool PreServerDestroy(global::NetInstance instance)
	{
		if (instance)
		{
			if (!instance.destroying)
			{
				instance.destroying = true;
				if (instance.idMain)
				{
					global::ServerManagement serverManagement = global::ServerManagement.Get();
					if (serverManagement)
					{
						serverManagement.ServerWillDestroyMain(instance.idMain, instance.networkView.viewID, global::NetEntityID.Kind.Net, instance.networkView);
					}
					if (instance.idMain is global::Character)
					{
						global::Character character = (global::Character)instance.idMain;
						if (character)
						{
							global::Controllable controllable = character.controllable;
							if (controllable)
							{
								controllable.OnWillDestroy();
							}
						}
					}
				}
			}
			return true;
		}
		return false;
	}

	// Token: 0x0600249A RID: 9370 RVA: 0x0008B7C8 File Offset: 0x000899C8
	internal static void PreServerDestroy(global::UnityEngine.MonoBehaviour monoBehaviour)
	{
		if (monoBehaviour && !global::NetInstance.PreServerDestroy(monoBehaviour.GetComponent<global::NetInstance>()))
		{
			global::NetInstance.NonNetInstanceWorkaround.PreServerDestroy(global::IDBase.GetMain(monoBehaviour));
		}
	}

	// Token: 0x0600249B RID: 9371 RVA: 0x0008B7FC File Offset: 0x000899FC
	internal static void PreServerDestroy(global::uLink.NetworkViewID viewID)
	{
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(viewID);
		if (networkView)
		{
			global::NetInstance.PreServerDestroy(networkView);
		}
	}

	// Token: 0x0400126B RID: 4715
	[global::System.NonSerialized]
	public global::CustomInstantiationArgs args;

	// Token: 0x0400126C RID: 4716
	[global::System.NonSerialized]
	public global::NetCull.InstantiateArgs netCullInstantiationArgs;

	// Token: 0x0400126D RID: 4717
	[global::System.NonSerialized]
	public bool hasNetCullInstantiationArgs;

	// Token: 0x0400126E RID: 4718
	[global::System.NonSerialized]
	public bool prepared;

	// Token: 0x0400126F RID: 4719
	[global::System.NonSerialized]
	public bool local;

	// Token: 0x04001270 RID: 4720
	[global::System.NonSerialized]
	internal bool destroying;

	// Token: 0x04001271 RID: 4721
	[global::System.NonSerialized]
	public global::uLink.NetworkMessageInfo info;

	// Token: 0x04001272 RID: 4722
	[global::System.NonSerialized]
	public global::Facepunch.NetworkView networkView;

	// Token: 0x04001273 RID: 4723
	[global::System.NonSerialized]
	public global::IDRemote localAppendage;

	// Token: 0x04001274 RID: 4724
	[global::System.NonSerialized]
	public bool madeLocalAppendage;

	// Token: 0x04001275 RID: 4725
	private static readonly global::DisposeCallbackList<global::NetInstance, global::NetInstance.CallbackFunction>.Function callbackFire = new global::DisposeCallbackList<global::NetInstance, global::NetInstance.CallbackFunction>.Function(global::NetInstance.CallbackFire);

	// Token: 0x04001276 RID: 4726
	private global::DisposeCallbackList<global::NetInstance, global::NetInstance.CallbackFunction> preDestroy;

	// Token: 0x04001277 RID: 4727
	private global::DisposeCallbackList<global::NetInstance, global::NetInstance.CallbackFunction> preCreate;

	// Token: 0x04001278 RID: 4728
	private global::DisposeCallbackList<global::NetInstance, global::NetInstance.CallbackFunction> postCreate;

	// Token: 0x0200041C RID: 1052
	private static class NonNetInstanceWorkaround
	{
		// Token: 0x0600249C RID: 9372 RVA: 0x0008B824 File Offset: 0x00089A24
		// Note: this type is marked as 'beforefieldinit'.
		static NonNetInstanceWorkaround()
		{
		}

		// Token: 0x0600249D RID: 9373 RVA: 0x0008B844 File Offset: 0x00089A44
		public static void CleanUp()
		{
			global::NetInstance.NonNetInstanceWorkaround.destroying.Clear();
			global::NetInstance.NonNetInstanceWorkaround.NEED_CLEANUP = false;
		}

		// Token: 0x0600249E RID: 9374 RVA: 0x0008B858 File Offset: 0x00089A58
		public static void PreServerDestroy(global::IDMain idMain)
		{
			if (idMain)
			{
				global::ServerManagement serverManagement = global::ServerManagement.Get();
				if (serverManagement && global::NetInstance.NonNetInstanceWorkaround.destroying.Add(idMain))
				{
					if (!global::NetInstance.NonNetInstanceWorkaround.NEED_CLEANUP)
					{
						global::NetInstance.NonNetInstanceWorkaround.NEED_CLEANUP = true;
						global::NetCull.Callbacks.beforeNextUpdate += global::NetInstance.NonNetInstanceWorkaround.CleanUpCallback;
					}
					global::Facepunch.NetworkView networkView = idMain.networkView;
					if (networkView && networkView.isMine)
					{
						serverManagement.ServerWillDestroyMain(idMain, networkView.viewID, global::NetEntityID.Kind.Net, networkView);
					}
				}
			}
		}

		// Token: 0x04001279 RID: 4729
		private static global::System.Collections.Generic.HashSet<global::IDMain> destroying = new global::System.Collections.Generic.HashSet<global::IDMain>();

		// Token: 0x0400127A RID: 4730
		private static bool NEED_CLEANUP;

		// Token: 0x0400127B RID: 4731
		private static readonly global::NetCull.UpdateFunctor CleanUpCallback = new global::NetCull.UpdateFunctor(global::NetInstance.NonNetInstanceWorkaround.CleanUp);
	}

	// Token: 0x0200041D RID: 1053
	// (Invoke) Token: 0x060024A0 RID: 9376
	public delegate void CallbackFunction(global::NetInstance instance);
}
