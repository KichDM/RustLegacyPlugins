using System;
using Facepunch;
using uLink;
using UnityEngine;

// Token: 0x020005AD RID: 1453
[global::InterfaceDriverComponent(typeof(global::IContextRequestable), "_implementation", "implementation", SearchRoute = global::InterfaceSearchRoute.GameObject, UnityType = typeof(global::Facepunch.MonoBehaviour), AlwaysSaveDisabled = true)]
public sealed class Contextual : global::UnityEngine.MonoBehaviour, global::IComponentInterfaceDriver<global::IContextRequestable, global::Facepunch.MonoBehaviour, global::Contextual>
{
	// Token: 0x06002FD4 RID: 12244 RVA: 0x000B6350 File Offset: 0x000B4550
	public Contextual()
	{
	}

	// Token: 0x17000A1F RID: 2591
	// (get) Token: 0x06002FD5 RID: 12245 RVA: 0x000B6358 File Offset: 0x000B4558
	public bool isSoleAccess
	{
		get
		{
			bool? isSoleAccess = this._isSoleAccess;
			bool value;
			if (isSoleAccess != null)
			{
				value = isSoleAccess.Value;
			}
			else
			{
				bool? flag = this._isSoleAccess = new bool?(this.@interface is global::IContextRequestableSoleAccess);
				value = flag.Value;
			}
			return value;
		}
	}

	// Token: 0x17000A20 RID: 2592
	// (get) Token: 0x06002FD6 RID: 12246 RVA: 0x000B63A8 File Offset: 0x000B45A8
	public bool isMenu
	{
		get
		{
			bool? isMenu = this._isMenu;
			bool value;
			if (isMenu != null)
			{
				value = isMenu.Value;
			}
			else
			{
				bool? flag = this._isMenu = new bool?(this.@interface is global::IContextRequestableMenu);
				value = flag.Value;
			}
			return value;
		}
	}

	// Token: 0x17000A21 RID: 2593
	// (get) Token: 0x06002FD7 RID: 12247 RVA: 0x000B63F8 File Offset: 0x000B45F8
	public bool isQuick
	{
		get
		{
			bool? isQuick = this._isQuick;
			bool value;
			if (isQuick != null)
			{
				value = isQuick.Value;
			}
			else
			{
				bool? flag = this._isQuick = new bool?(this.@interface is global::IContextRequestableQuick);
				value = flag.Value;
			}
			return value;
		}
	}

	// Token: 0x06002FD8 RID: 12248 RVA: 0x000B6448 File Offset: 0x000B4648
	public bool AsMenu(out global::IContextRequestableMenu menu)
	{
		if (this.isMenu)
		{
			menu = (this.@interface as global::IContextRequestableMenu);
			return this.implementor;
		}
		menu = null;
		return false;
	}

	// Token: 0x06002FD9 RID: 12249 RVA: 0x000B6480 File Offset: 0x000B4680
	public bool AsMenu<IContextRequestableMenuType>(out IContextRequestableMenuType menu) where IContextRequestableMenuType : class, global::IContextRequestableMenu
	{
		global::IContextRequestableMenu contextRequestableMenu;
		if (this.AsMenu(out contextRequestableMenu))
		{
			return !object.ReferenceEquals(menu = (contextRequestableMenu as IContextRequestableMenuType), null);
		}
		menu = (IContextRequestableMenuType)((object)null);
		return false;
	}

	// Token: 0x06002FDA RID: 12250 RVA: 0x000B64CC File Offset: 0x000B46CC
	public bool AsQuick(out global::IContextRequestableQuick quick)
	{
		if (this.isQuick)
		{
			quick = (this.@interface as global::IContextRequestableQuick);
			return this.implementor;
		}
		quick = null;
		return false;
	}

	// Token: 0x06002FDB RID: 12251 RVA: 0x000B6504 File Offset: 0x000B4704
	public bool AsQuick<IContextRequestableQuickType>(out IContextRequestableQuickType quick) where IContextRequestableQuickType : class, global::IContextRequestableQuick
	{
		global::IContextRequestableQuick contextRequestableQuick;
		if (this.AsQuick(out contextRequestableQuick))
		{
			return !object.ReferenceEquals(quick = (contextRequestableQuick as IContextRequestableQuickType), null);
		}
		quick = (IContextRequestableQuickType)((object)null);
		return false;
	}

	// Token: 0x06002FDC RID: 12252 RVA: 0x000B6550 File Offset: 0x000B4750
	public bool RouteToQuickOnEmptyMenu(global::Controllable control, ulong timestamp, bool fromError)
	{
		if (!this.exists)
		{
			return false;
		}
		if (this.@interface is global::IContextRequestableMenuQuickRouter)
		{
			try
			{
				return ((global::IContextRequestableMenuQuickRouter)this.@interface).ContextQuickWhenNoMenuActions(control, timestamp, fromError);
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex, this);
			}
			return false;
		}
		return false;
	}

	// Token: 0x17000A22 RID: 2594
	// (get) Token: 0x06002FDD RID: 12253 RVA: 0x000B65C4 File Offset: 0x000B47C4
	public global::Facepunch.MonoBehaviour implementor
	{
		get
		{
			if (!this._awoke)
			{
				try
				{
					this.Refresh();
				}
				finally
				{
					this._awoke = true;
				}
			}
			return this.implementation;
		}
	}

	// Token: 0x17000A23 RID: 2595
	// (get) Token: 0x06002FDE RID: 12254 RVA: 0x000B6614 File Offset: 0x000B4814
	public global::IContextRequestable @interface
	{
		get
		{
			if (!this._awoke)
			{
				try
				{
					this.Refresh();
				}
				finally
				{
					this._awoke = true;
				}
			}
			return this._requestable;
		}
	}

	// Token: 0x17000A24 RID: 2596
	// (get) Token: 0x06002FDF RID: 12255 RVA: 0x000B6664 File Offset: 0x000B4864
	public bool exists
	{
		get
		{
			if (!this._awoke)
			{
				try
				{
					this.Refresh();
				}
				finally
				{
					this._awoke = true;
				}
			}
			return this._implemented && (this._implemented = this.implementation);
		}
	}

	// Token: 0x17000A25 RID: 2597
	// (get) Token: 0x06002FE0 RID: 12256 RVA: 0x000B66D0 File Offset: 0x000B48D0
	public global::Contextual driver
	{
		get
		{
			return this;
		}
	}

	// Token: 0x06002FE1 RID: 12257 RVA: 0x000B66D4 File Offset: 0x000B48D4
	private void Refresh()
	{
		this.implementation = this._implementation;
		this._implementation = null;
		this._requestable = (this.implementation as global::IContextRequestable);
		this._implemented = (this._requestable != null);
		if (!this._implemented)
		{
			global::UnityEngine.Debug.LogWarning("implementation is null or does not implement IContextRequestable", this);
		}
	}

	// Token: 0x06002FE2 RID: 12258 RVA: 0x000B6730 File Offset: 0x000B4930
	private void OnDestroy()
	{
		this.shuttingDown = true;
		if (this.accessCount > 0)
		{
			global::Context.Abort(this);
		}
	}

	// Token: 0x06002FE3 RID: 12259 RVA: 0x000B674C File Offset: 0x000B494C
	public static bool FindUp(global::UnityEngine.Transform transform, out global::Contextual contextual)
	{
		while (transform)
		{
			global::Contextual component;
			contextual = (component = transform.GetComponent<global::Contextual>());
			if (component)
			{
				return true;
			}
			transform = transform.parent;
		}
		contextual = null;
		return false;
	}

	// Token: 0x06002FE4 RID: 12260 RVA: 0x000B678C File Offset: 0x000B498C
	private static bool GetMB(global::UnityEngine.MonoBehaviour networkView, out global::Contextual contextual)
	{
		if (networkView)
		{
			global::Contextual component;
			contextual = (component = networkView.GetComponent<global::Contextual>());
			if (component)
			{
				return contextual.exists;
			}
		}
		contextual = null;
		return false;
	}

	// Token: 0x06002FE5 RID: 12261 RVA: 0x000B67C8 File Offset: 0x000B49C8
	public static bool ContextOf(global::Facepunch.NetworkView networkView, out global::Contextual contextual)
	{
		return global::Contextual.GetMB(networkView, out contextual);
	}

	// Token: 0x06002FE6 RID: 12262 RVA: 0x000B67D4 File Offset: 0x000B49D4
	public static bool ContextOf(global::NGCView networkView, out global::Contextual contextual)
	{
		return global::Contextual.GetMB(networkView, out contextual);
	}

	// Token: 0x06002FE7 RID: 12263 RVA: 0x000B67E0 File Offset: 0x000B49E0
	public static bool ContextOf(global::uLink.NetworkViewID networkViewID, out global::Contextual contextual)
	{
		return global::Contextual.GetMB(global::Facepunch.NetworkView.Find(networkViewID), out contextual);
	}

	// Token: 0x06002FE8 RID: 12264 RVA: 0x000B67F0 File Offset: 0x000B49F0
	public static bool ContextOf(global::NetEntityID entityID, out global::Contextual contextual)
	{
		return global::Contextual.GetMB(entityID.view, out contextual);
	}

	// Token: 0x06002FE9 RID: 12265 RVA: 0x000B6800 File Offset: 0x000B4A00
	public static bool ContextOf(global::UnityEngine.GameObject gameObject, out global::Contextual contextual)
	{
		global::UnityEngine.MonoBehaviour networkView;
		if ((int)global::NetEntityID.Of(gameObject, out networkView) == 0)
		{
			contextual = null;
			return false;
		}
		return global::Contextual.GetMB(networkView, out contextual);
	}

	// Token: 0x06002FEA RID: 12266 RVA: 0x000B6828 File Offset: 0x000B4A28
	public static bool ContextOf(global::UnityEngine.Component component, out global::Contextual contextual)
	{
		global::UnityEngine.MonoBehaviour networkView;
		if ((int)global::NetEntityID.Of(component, out networkView) == 0)
		{
			contextual = null;
			return false;
		}
		return global::Contextual.GetMB(networkView, out contextual);
	}

	// Token: 0x040019AC RID: 6572
	[global::UnityEngine.SerializeField]
	private global::Facepunch.MonoBehaviour _implementation;

	// Token: 0x040019AD RID: 6573
	[global::System.NonSerialized]
	private global::Facepunch.MonoBehaviour implementation;

	// Token: 0x040019AE RID: 6574
	[global::System.NonSerialized]
	private global::IContextRequestable _requestable;

	// Token: 0x040019AF RID: 6575
	[global::System.NonSerialized]
	private bool _implemented;

	// Token: 0x040019B0 RID: 6576
	[global::System.NonSerialized]
	private bool _awoke;

	// Token: 0x040019B1 RID: 6577
	[global::System.NonSerialized]
	private bool? _isSoleAccess;

	// Token: 0x040019B2 RID: 6578
	[global::System.NonSerialized]
	private bool? _isMenu;

	// Token: 0x040019B3 RID: 6579
	[global::System.NonSerialized]
	private bool? _isQuick;

	// Token: 0x040019B4 RID: 6580
	[global::System.NonSerialized]
	public bool soleAccessObtained;

	// Token: 0x040019B5 RID: 6581
	[global::System.NonSerialized]
	public bool shuttingDown;

	// Token: 0x040019B6 RID: 6582
	[global::System.NonSerialized]
	public int accessCount;
}
