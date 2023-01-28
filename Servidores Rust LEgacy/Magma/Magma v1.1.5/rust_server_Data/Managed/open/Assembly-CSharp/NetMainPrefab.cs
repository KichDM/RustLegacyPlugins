using System;
using System.Collections.Generic;
using Facepunch;
using uLink;
using UnityEngine;

// Token: 0x0200041F RID: 1055
public class NetMainPrefab : global::UnityEngine.ScriptableObject
{
	// Token: 0x060024A9 RID: 9385 RVA: 0x0008B920 File Offset: 0x00089B20
	public NetMainPrefab() : this(typeof(global::IDMain), false)
	{
	}

	// Token: 0x060024AA RID: 9386 RVA: 0x0008B934 File Offset: 0x00089B34
	protected NetMainPrefab(global::System.Type minimumType) : this(minimumType, true)
	{
	}

	// Token: 0x060024AB RID: 9387 RVA: 0x0008B940 File Offset: 0x00089B40
	private NetMainPrefab(global::System.Type minimumType, bool typeCheck)
	{
		if (typeCheck && !typeof(global::IDMain).IsAssignableFrom(minimumType))
		{
			throw new global::System.ArgumentOutOfRangeException("minimumType", "must be assignable to IDMain");
		}
		this.MinimumTypeAllowed = minimumType;
		this.CollectCallbacks(out this.creator, out this.destroyer);
	}

	// Token: 0x17000840 RID: 2112
	// (get) Token: 0x060024AC RID: 9388 RVA: 0x0008B998 File Offset: 0x00089B98
	private global::IDRemote localAppend
	{
		get
		{
			return this._localAppend;
		}
	}

	// Token: 0x17000841 RID: 2113
	// (get) Token: 0x060024AD RID: 9389 RVA: 0x0008B9A0 File Offset: 0x00089BA0
	public global::IDMain prefab
	{
		get
		{
			return this.serverPrefab;
		}
	}

	// Token: 0x17000842 RID: 2114
	// (get) Token: 0x060024AE RID: 9390 RVA: 0x0008B9A8 File Offset: 0x00089BA8
	public global::IDMain proxyPrefab
	{
		get
		{
			return (!this._proxyPrefab) ? this._serverPrefab : this._proxyPrefab;
		}
	}

	// Token: 0x17000843 RID: 2115
	// (get) Token: 0x060024AF RID: 9391 RVA: 0x0008B9CC File Offset: 0x00089BCC
	public global::IDMain localPrefab
	{
		get
		{
			return (!this._localPrefab) ? this.proxyPrefab : this._localPrefab;
		}
	}

	// Token: 0x17000844 RID: 2116
	// (get) Token: 0x060024B0 RID: 9392 RVA: 0x0008B9F0 File Offset: 0x00089BF0
	public global::IDMain serverPrefab
	{
		get
		{
			return (!this._serverPrefab) ? this.proxyPrefab : this._serverPrefab;
		}
	}

	// Token: 0x060024B1 RID: 9393 RVA: 0x0008BA14 File Offset: 0x00089C14
	public static global::UnityEngine.Transform GetLocalAppendTransform(global::IDMain instanceOrPrefab, string _pathToLocalAppend)
	{
		if (!instanceOrPrefab)
		{
			return null;
		}
		if (string.IsNullOrEmpty(_pathToLocalAppend))
		{
			return instanceOrPrefab.transform;
		}
		global::UnityEngine.Transform transform = instanceOrPrefab.transform.FindChild(_pathToLocalAppend);
		if (!transform)
		{
			global::UnityEngine.Debug.LogError("The transform path:\"" + _pathToLocalAppend + "\" is no longer valid for given transform. returning the transform of the main", instanceOrPrefab);
			transform = instanceOrPrefab.transform;
		}
		return transform;
	}

	// Token: 0x060024B2 RID: 9394 RVA: 0x0008BA78 File Offset: 0x00089C78
	public global::UnityEngine.Transform GetLocalAppendTransform(global::IDMain instanceOrPrefab)
	{
		return global::NetMainPrefab.GetLocalAppendTransform(instanceOrPrefab, this._pathToLocalAppend);
	}

	// Token: 0x17000845 RID: 2117
	// (get) Token: 0x060024B3 RID: 9395 RVA: 0x0008BA88 File Offset: 0x00089C88
	public global::UnityEngine.Transform localAppendTransformInPrefab
	{
		get
		{
			return this.GetLocalAppendTransform(this.proxyPrefab);
		}
	}

	// Token: 0x060024B4 RID: 9396 RVA: 0x0008BA98 File Offset: 0x00089C98
	private global::Facepunch.NetworkView Create(ref global::CustomInstantiationArgs args, out global::IDMain instance)
	{
		if (float.IsNaN(args.position.x) || float.IsNaN(args.position.y) || float.IsNaN(args.position.z))
		{
			global::UnityEngine.Debug.LogWarning("NetMainPrefab -> Create -  args.position = " + args.position);
			global::UnityEngine.Debug.LogWarning("This means you're creating an object with a bad position!");
		}
		global::NetInstance currentNetInstance = global::NetMainPrefab._currentNetInstance;
		global::Facepunch.NetworkView result;
		try
		{
			global::NetMainPrefab._currentNetInstance = null;
			if (args.hasCustomInstantiator)
			{
				instance = null;
				try
				{
					instance = args.customInstantiate.CustomInstantiatePrefab(ref args);
				}
				catch (global::System.Exception arg)
				{
					global::UnityEngine.Debug.LogError(string.Format("Thrown Exception during custom instantiate via '{0}' with instantiation '{2}'\r\ndefault instantiation will now occur --  exception follows..\r\n{1}", args.customInstantiate, arg, this), this);
					if (instance)
					{
						global::UnityEngine.Object.Destroy(instance);
					}
					instance = null;
				}
				global::Facepunch.NetworkView networkView;
				try
				{
					networkView = instance.networkView;
					if (networkView == null)
					{
						global::UnityEngine.Debug.LogWarning(string.Format("The custom instantiator '{0}' with instantiation '{1}' did not return a idmain with a network view. so its being added", args.customInstantiate, this), this);
						networkView = instance.gameObject.AddComponent<global::uLinkNetworkView>();
					}
				}
				catch (global::System.Exception arg2)
				{
					networkView = null;
					global::UnityEngine.Debug.LogError(string.Format("The custom instantiator '{0}' did not instantiate a IDMain with a networkview or something else with instantiation '{2}'.. \r\n {1}", args.customInstantiate, arg2, this), this);
				}
				if (networkView)
				{
					return networkView;
				}
			}
			global::Facepunch.NetworkView networkView2 = (global::Facepunch.NetworkView)global::uLink.NetworkInstantiatorUtility.Instantiate(args.prefabNetworkView, args.args);
			instance = networkView2.GetComponent<global::IDMain>();
			result = networkView2;
		}
		finally
		{
			global::NetMainPrefab._currentNetInstance = currentNetInstance;
		}
		return result;
	}

	// Token: 0x060024B5 RID: 9397 RVA: 0x0008BC6C File Offset: 0x00089E6C
	private global::NetInstance Summon(global::IDMain prefab, bool isServer, ref global::uLink.NetworkInstantiateArgs niargs)
	{
		global::CustomInstantiationArgs args = new global::CustomInstantiationArgs(this, this._customInstantiator, prefab, ref niargs, isServer);
		global::IDMain idMain;
		global::Facepunch.NetworkView networkView = this.Create(ref args, out idMain);
		global::NetInstance netInstance = networkView.gameObject.AddComponent<global::NetInstance>();
		netInstance.args = args;
		netInstance.idMain = idMain;
		netInstance.prepared = false;
		netInstance.networkView = networkView;
		if (global::NetCull.isCurrentlyInstantiating)
		{
			netInstance.hasNetCullInstantiationArgs = true;
			netInstance.netCullInstantiationArgs = global::NetCull.currentlyInstantiating;
		}
		else
		{
			netInstance.hasNetCullInstantiationArgs = false;
			netInstance.netCullInstantiationArgs = default(global::NetCull.InstantiateArgs);
		}
		return netInstance;
	}

	// Token: 0x060024B6 RID: 9398 RVA: 0x0008BCF8 File Offset: 0x00089EF8
	private bool ShouldDoStandardInitialization(global::NetInstance instance)
	{
		global::UnityEngine.Object customInstantiator = this._customInstantiator;
		bool result;
		try
		{
			this._customInstantiator = instance;
			if (instance.args.hasCustomInstantiator)
			{
				try
				{
					return instance.args.customInstantiate.InitializePrefabInstance(instance);
				}
				catch (global::System.Exception ex)
				{
					global::UnityEngine.Debug.LogError(string.Format("A exception was thrown during InitializePrefabInstance with '{0}' as custom instantiate, prefab '{1}' instance '{2}'.\r\ndoing standard initialization..\r\n{3}", new object[]
					{
						instance.args.customInstantiate,
						this,
						instance.args.prefab,
						ex
					}), instance);
				}
			}
			result = true;
		}
		finally
		{
			this._customInstantiator = customInstantiator;
		}
		return result;
	}

	// Token: 0x17000846 RID: 2118
	// (get) Token: 0x060024B7 RID: 9399 RVA: 0x0008BDC8 File Offset: 0x00089FC8
	internal static global::NetInstance zzz__currentNetInstance
	{
		get
		{
			return global::NetMainPrefab._currentNetInstance;
		}
	}

	// Token: 0x060024B8 RID: 9400 RVA: 0x0008BDD0 File Offset: 0x00089FD0
	public static void IssueLocallyAppended(global::IDRemote appended, global::IDMain instance)
	{
		appended.BroadcastMessage("OnLocallyAppended", instance, 1);
	}

	// Token: 0x060024B9 RID: 9401 RVA: 0x0008BDE0 File Offset: 0x00089FE0
	protected virtual void StandardInitialization(bool didAppend, global::IDRemote appended, global::NetInstance instance, global::Facepunch.NetworkView view, ref global::uLink.NetworkMessageInfo info)
	{
		if (didAppend)
		{
			global::NetMainPrefab.IssueLocallyAppended(appended, instance.idMain);
		}
		if (this.ShouldDoStandardInitialization(instance))
		{
			global::uLink.NetworkInstantiatorUtility.BroadcastOnNetworkInstantiate(view, "uLink_OnNetworkInstantiate", info);
		}
	}

	// Token: 0x060024BA RID: 9402 RVA: 0x0008BE10 File Offset: 0x0008A010
	public static global::IDRemote DoLocalAppend(global::IDRemote localAppend, global::IDMain instance, global::UnityEngine.Transform appendPoint)
	{
		global::UnityEngine.Transform transform = localAppend.transform;
		if (localAppend.transform != localAppend.transform.root)
		{
			global::UnityEngine.Debug.LogWarning("The localAppend transform was not a root");
		}
		global::IDRemote idremote = (global::IDRemote)global::UnityEngine.Object.Instantiate(localAppend, appendPoint.TransformPoint(transform.localPosition), appendPoint.rotation * transform.localRotation);
		global::UnityEngine.Transform transform2 = idremote.transform;
		transform2.parent = appendPoint;
		transform2.localPosition = transform.localPosition;
		transform2.localRotation = transform.localRotation;
		transform2.localScale = transform.localScale;
		idremote.idMain = instance;
		foreach (global::IDRemote idremote2 in instance.GetComponentsInChildren<global::IDRemote>())
		{
			if (!idremote2.idMain)
			{
				idremote2.idMain = instance;
			}
		}
		return idremote;
	}

	// Token: 0x060024BB RID: 9403 RVA: 0x0008BEEC File Offset: 0x0008A0EC
	protected global::uLink.NetworkView _Creator(string prefabName, global::uLink.NetworkInstantiateArgs args, global::uLink.NetworkMessageInfo info)
	{
		global::NetInstance netInstance = this.Summon(this.serverPrefab, true, ref args);
		if (!netInstance)
		{
			return null;
		}
		global::Facepunch.NetworkView networkView = netInstance.networkView;
		if (!networkView)
		{
			return null;
		}
		info = new global::uLink.NetworkMessageInfo(info, networkView);
		global::NetInstance currentNetInstance = global::NetMainPrefab._currentNetInstance;
		try
		{
			global::NetMainPrefab._currentNetInstance = netInstance;
			netInstance.info = info;
			netInstance.prepared = true;
			global::NetInstance netInstance2 = netInstance;
			global::uLink.NetworkViewID viewID = args.viewID;
			netInstance2.local = viewID.isMine;
			bool didAppend = false;
			global::IDRemote appended = null;
			if (netInstance.local)
			{
				global::IDRemote localAppend = this.localAppend;
				if (localAppend)
				{
					appended = global::NetMainPrefab.DoLocalAppend(localAppend, netInstance.idMain, this.GetLocalAppendTransform(netInstance.idMain));
					didAppend = true;
				}
			}
			netInstance.zzz___onprecreate();
			this.StandardInitialization(didAppend, appended, netInstance, networkView, ref info);
			netInstance.zzz___onpostcreate();
		}
		finally
		{
			global::NetMainPrefab._currentNetInstance = currentNetInstance;
		}
		return networkView;
	}

	// Token: 0x060024BC RID: 9404 RVA: 0x0008BFE8 File Offset: 0x0008A1E8
	protected void _Destroyer(global::uLink.NetworkView networkView)
	{
		global::NetInstance currentNetInstance = global::NetMainPrefab._currentNetInstance;
		try
		{
			global::NetInstance component = networkView.GetComponent<global::NetInstance>();
			global::NetMainPrefab._currentNetInstance = component;
			if (component)
			{
				component.zzz___onpredestroy();
			}
			global::UnityEngine.Object.Destroy(networkView.gameObject);
		}
		finally
		{
			global::NetMainPrefab._currentNetInstance = currentNetInstance;
		}
	}

	// Token: 0x060024BD RID: 9405 RVA: 0x0008C04C File Offset: 0x0008A24C
	protected virtual void CollectCallbacks(out global::uLink.NetworkInstantiator.Creator creator, out global::uLink.NetworkInstantiator.Destroyer destroyer)
	{
		creator = new global::uLink.NetworkInstantiator.Creator(this._Creator);
		destroyer = new global::uLink.NetworkInstantiator.Destroyer(this._Destroyer);
	}

	// Token: 0x060024BE RID: 9406 RVA: 0x0008C06C File Offset: 0x0008A26C
	public static string DressName(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			throw new global::System.ArgumentException("name cannot be null or empty", "name");
		}
		if (name[0] != ':')
		{
			int length = name.Length;
			for (int i = length - 1; i >= 0; i--)
			{
				if (char.IsUpper(name, i))
				{
					global::UnityEngine.Debug.LogWarning(string.Format("the name \":{0}\" contains upper case characters. it should not.", name));
					return ":" + name.ToLower();
				}
			}
			return ":" + name;
		}
		int length2 = name.Length;
		if (length2 == 1)
		{
			throw new global::System.ArgumentException("if name includes the prefix char it must be followed by at least one more char.", "name");
		}
		for (int j = length2 - 1; j > 0; j--)
		{
			if (char.IsUpper(name, j))
			{
				global::UnityEngine.Debug.LogWarning(string.Format("the name \"{0}\" contains upper case characters. it should not.", name));
				return name.ToLower();
			}
		}
		string text = name.ToLower();
		if (text != name)
		{
			global::UnityEngine.Debug.LogWarning(string.Format("the name \"{0}\" contains upper case characters. it should not.", name));
		}
		if (text[0] == ':')
		{
			return text;
		}
		return ":" + text;
	}

	// Token: 0x17000847 RID: 2119
	// (get) Token: 0x060024BF RID: 9407 RVA: 0x0008C190 File Offset: 0x0008A390
	public string name
	{
		get
		{
			string name = base.name;
			if (name != this._originalName)
			{
				if (global::UnityEngine.Application.isPlaying && !string.IsNullOrEmpty(this._originalName))
				{
					global::UnityEngine.Debug.LogWarning("You can't rename proxy instantiations at runtime!", this);
				}
				else
				{
					this._originalName = name;
					this._name = global::NetMainPrefab.DressName(name);
				}
			}
			return this._name;
		}
	}

	// Token: 0x060024C0 RID: 9408 RVA: 0x0008C1F8 File Offset: 0x0008A3F8
	public static T Lookup<T>(string key) where T : global::UnityEngine.Object
	{
		if (!global::NetMainPrefab.ginit)
		{
			return (T)((object)null);
		}
		global::NetMainPrefab netMainPrefab;
		if (!global::NetMainPrefab.g.dict.TryGetValue(key, out netMainPrefab))
		{
			global::UnityEngine.Debug.LogWarning("There was no registered proxy with key " + key);
			return (T)((object)null);
		}
		if (typeof(global::NetMainPrefab).IsAssignableFrom(typeof(T)))
		{
			return (T)((object)netMainPrefab);
		}
		if (typeof(global::UnityEngine.GameObject).IsAssignableFrom(typeof(T)))
		{
			return (T)((object)netMainPrefab.prefab.gameObject);
		}
		if (!typeof(global::UnityEngine.Component).IsAssignableFrom(typeof(T)))
		{
			return (T)((object)null);
		}
		if (typeof(global::IDMain).IsAssignableFrom(typeof(T)))
		{
			return (T)((object)netMainPrefab.prefab);
		}
		return (T)((object)netMainPrefab.prefab.GetComponent(typeof(T)));
	}

	// Token: 0x060024C1 RID: 9409 RVA: 0x0008C2FC File Offset: 0x0008A4FC
	public static T LookupInChildren<T>(string key) where T : global::UnityEngine.Component
	{
		if (!global::NetMainPrefab.ginit)
		{
			return (T)((object)null);
		}
		global::NetMainPrefab netMainPrefab;
		if (!global::NetMainPrefab.g.dict.TryGetValue(key, out netMainPrefab))
		{
			global::UnityEngine.Debug.LogWarning("There was no registered proxy with key " + key);
			return (T)((object)null);
		}
		return netMainPrefab.prefab.GetComponentInChildren<T>();
	}

	// Token: 0x060024C2 RID: 9410 RVA: 0x0008C350 File Offset: 0x0008A550
	public void Register(bool forceReplace)
	{
		global::uLink.NetworkInstantiator.Add(this.name, this.creator, this.destroyer, forceReplace);
		global::NetMainPrefab.g.dict[this.name] = this;
	}

	// Token: 0x060024C3 RID: 9411 RVA: 0x0008C388 File Offset: 0x0008A588
	public static void EnsurePrefabName(string name)
	{
		global::NetMainPrefabNameException ex;
		if (!global::NetMainPrefab.ValidatePrefabNameOrMakeException(name, out ex))
		{
			throw ex;
		}
	}

	// Token: 0x060024C4 RID: 9412 RVA: 0x0008C3A4 File Offset: 0x0008A5A4
	public static bool ValidatePrefabNameOrMakeException(string name, out global::NetMainPrefabNameException e)
	{
		if (name == null)
		{
			e = new global::NetMainPrefabNameException("name", name, "null");
		}
		else if (name.Length < 2)
		{
			e = new global::NetMainPrefabNameException("name", name, "name must include the prefix character and at least one other after");
		}
		else
		{
			if (name[0] == ':')
			{
				e = null;
				return true;
			}
			e = new global::NetMainPrefabNameException("name", name, "name did not begin with the prefix character");
		}
		return false;
	}

	// Token: 0x0400127C RID: 4732
	public const char prefixChar = ':';

	// Token: 0x0400127D RID: 4733
	public const string prefixCharString = ":";

	// Token: 0x0400127E RID: 4734
	[global::UnityEngine.SerializeField]
	private global::IDMain _proxyPrefab;

	// Token: 0x0400127F RID: 4735
	[global::UnityEngine.SerializeField]
	private global::IDMain _serverPrefab;

	// Token: 0x04001280 RID: 4736
	[global::UnityEngine.SerializeField]
	private global::IDMain _localPrefab;

	// Token: 0x04001281 RID: 4737
	[global::UnityEngine.SerializeField]
	private global::IDRemote _localAppend;

	// Token: 0x04001282 RID: 4738
	[global::UnityEngine.SerializeField]
	private string _pathToLocalAppend;

	// Token: 0x04001283 RID: 4739
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Object _customInstantiator;

	// Token: 0x04001284 RID: 4740
	[global::System.NonSerialized]
	public readonly global::System.Type MinimumTypeAllowed;

	// Token: 0x04001285 RID: 4741
	private readonly global::uLink.NetworkInstantiator.Creator creator;

	// Token: 0x04001286 RID: 4742
	private readonly global::uLink.NetworkInstantiator.Destroyer destroyer;

	// Token: 0x04001287 RID: 4743
	private static global::NetInstance _currentNetInstance;

	// Token: 0x04001288 RID: 4744
	private string _name;

	// Token: 0x04001289 RID: 4745
	private string _originalName;

	// Token: 0x0400128A RID: 4746
	private static bool ginit;

	// Token: 0x02000420 RID: 1056
	private static class g
	{
		// Token: 0x060024C5 RID: 9413 RVA: 0x0008C41C File Offset: 0x0008A61C
		static g()
		{
			global::NetMainPrefab.ginit = true;
		}

		// Token: 0x0400128B RID: 4747
		public static global::System.Collections.Generic.Dictionary<string, global::NetMainPrefab> dict = new global::System.Collections.Generic.Dictionary<string, global::NetMainPrefab>();
	}
}
