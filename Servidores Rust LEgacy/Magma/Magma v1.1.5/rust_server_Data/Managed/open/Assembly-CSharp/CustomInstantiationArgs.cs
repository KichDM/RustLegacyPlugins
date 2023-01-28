using System;
using uLink;
using UnityEngine;

// Token: 0x02000421 RID: 1057
public struct CustomInstantiationArgs
{
	// Token: 0x060024C6 RID: 9414 RVA: 0x0008C430 File Offset: 0x0008A630
	public CustomInstantiationArgs(global::NetMainPrefab netMain, global::IDMain prefab, ref global::uLink.NetworkInstantiateArgs args, bool server)
	{
		this = new global::CustomInstantiationArgs(netMain, null, prefab, ref args, server, false);
	}

	// Token: 0x060024C7 RID: 9415 RVA: 0x0008C440 File Offset: 0x0008A640
	public CustomInstantiationArgs(global::NetMainPrefab netMain, global::UnityEngine.Object customInstantiator, global::IDMain prefab, ref global::uLink.NetworkInstantiateArgs args, bool server)
	{
		this = new global::CustomInstantiationArgs(netMain, customInstantiator, prefab, ref args, server, true);
	}

	// Token: 0x060024C8 RID: 9416 RVA: 0x0008C450 File Offset: 0x0008A650
	private CustomInstantiationArgs(global::NetMainPrefab netMain, global::UnityEngine.Object customInstantiator, global::IDMain prefab, ref global::uLink.NetworkInstantiateArgs args, bool server, bool checkCustomInstantitorArgument)
	{
		this.netMain = netMain;
		this.prefab = prefab;
		this.prefabNetworkView = prefab.networkView;
		this.args = args;
		this.server = server;
		if (checkCustomInstantitorArgument && customInstantiator)
		{
			this.customInstantiate = (customInstantiator as global::IPrefabCustomInstantiate);
			if (this.customInstantiate == null)
			{
				this.hasCustomInstantiator = global::CustomInstantiationArgs.CheckNetworkViewCustomInstantiator(this.prefabNetworkView, this.prefab, out this.customInstantiate);
			}
			else
			{
				this.hasCustomInstantiator = true;
			}
		}
		else
		{
			this.hasCustomInstantiator = global::CustomInstantiationArgs.CheckNetworkViewCustomInstantiator(this.prefabNetworkView, this.prefab, out this.customInstantiate);
		}
	}

	// Token: 0x17000848 RID: 2120
	// (get) Token: 0x060024C9 RID: 9417 RVA: 0x0008C500 File Offset: 0x0008A700
	public global::uLink.BitStream initialData
	{
		get
		{
			return this.args.initialData;
		}
	}

	// Token: 0x17000849 RID: 2121
	// (get) Token: 0x060024CA RID: 9418 RVA: 0x0008C51C File Offset: 0x0008A71C
	public global::UnityEngine.Vector3 position
	{
		get
		{
			return this.args.position;
		}
	}

	// Token: 0x1700084A RID: 2122
	// (get) Token: 0x060024CB RID: 9419 RVA: 0x0008C538 File Offset: 0x0008A738
	public global::UnityEngine.Quaternion rotation
	{
		get
		{
			return this.args.rotation;
		}
	}

	// Token: 0x1700084B RID: 2123
	// (get) Token: 0x060024CC RID: 9420 RVA: 0x0008C554 File Offset: 0x0008A754
	public bool client
	{
		get
		{
			return !this.server;
		}
	}

	// Token: 0x060024CD RID: 9421 RVA: 0x0008C560 File Offset: 0x0008A760
	private static bool CheckNetworkViewCustomInstantiator(global::uLink.NetworkView view, out global::IPrefabCustomInstantiate custom)
	{
		custom = (view.observed as global::IPrefabCustomInstantiate);
		return custom != null;
	}

	// Token: 0x060024CE RID: 9422 RVA: 0x0008C578 File Offset: 0x0008A778
	private static bool CheckNetworkViewCustomInstantiator(global::IDMain character, out global::IPrefabCustomInstantiate custom)
	{
		custom = (character as global::IPrefabCustomInstantiate);
		return custom != null;
	}

	// Token: 0x060024CF RID: 9423 RVA: 0x0008C58C File Offset: 0x0008A78C
	private static bool CheckNetworkViewCustomInstantiator(global::uLink.NetworkView view, global::IDMain character, out global::IPrefabCustomInstantiate custom)
	{
		return global::CustomInstantiationArgs.CheckNetworkViewCustomInstantiator(view, out custom) || global::CustomInstantiationArgs.CheckNetworkViewCustomInstantiator(character, out custom);
	}

	// Token: 0x0400128C RID: 4748
	public readonly global::NetMainPrefab netMain;

	// Token: 0x0400128D RID: 4749
	public readonly global::IDMain prefab;

	// Token: 0x0400128E RID: 4750
	public readonly global::uLink.NetworkView prefabNetworkView;

	// Token: 0x0400128F RID: 4751
	public readonly global::uLink.NetworkInstantiateArgs args;

	// Token: 0x04001290 RID: 4752
	public readonly global::IPrefabCustomInstantiate customInstantiate;

	// Token: 0x04001291 RID: 4753
	public readonly bool server;

	// Token: 0x04001292 RID: 4754
	public readonly bool hasCustomInstantiator;
}
