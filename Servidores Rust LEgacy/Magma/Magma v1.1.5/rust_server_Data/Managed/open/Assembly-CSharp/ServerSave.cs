using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Facepunch;
using Google.ProtocolBuffers;
using RustProto;
using RustProto.Helpers;
using uLink;
using UnityEngine;

// Token: 0x020000D9 RID: 217
public class ServerSave : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600042E RID: 1070 RVA: 0x00013CF4 File Offset: 0x00011EF4
	public ServerSave()
	{
	}

	// Token: 0x1700008E RID: 142
	// (get) Token: 0x0600042F RID: 1071 RVA: 0x00013D04 File Offset: 0x00011F04
	internal global::ServerSave.Reged REGED
	{
		get
		{
			return this.registered;
		}
	}

	// Token: 0x06000430 RID: 1072 RVA: 0x00013D0C File Offset: 0x00011F0C
	private global::UnityEngine.MonoBehaviour[] GetServerSaveables()
	{
		if (!this.builtServerSaveablesArray)
		{
			int newSize = 0;
			global::UnityEngine.MonoBehaviour[] componentsInChildren = base.GetComponentsInChildren<global::UnityEngine.MonoBehaviour>(true);
			foreach (global::UnityEngine.MonoBehaviour monoBehaviour in componentsInChildren)
			{
				if (monoBehaviour && monoBehaviour is global::IServerSaveable)
				{
					componentsInChildren[newSize++] = monoBehaviour;
				}
			}
			global::System.Array.Resize<global::UnityEngine.MonoBehaviour>(ref componentsInChildren, newSize);
			this.serverSaveables = componentsInChildren;
			this.builtServerSaveablesArray = true;
		}
		return this.serverSaveables;
	}

	// Token: 0x06000431 RID: 1073 RVA: 0x00013D88 File Offset: 0x00011F88
	public void SaveServerSaveables(ref global::RustProto.SavedObject.Builder saveobj)
	{
		foreach (global::UnityEngine.MonoBehaviour monoBehaviour in this.GetServerSaveables())
		{
			global::IServerSaveable serverSaveable;
			if (monoBehaviour && !object.ReferenceEquals(serverSaveable = (monoBehaviour as global::IServerSaveable), null))
			{
				serverSaveable.WriteObjectSave(ref saveobj);
			}
		}
	}

	// Token: 0x06000432 RID: 1074 RVA: 0x00013DDC File Offset: 0x00011FDC
	public void LoadServerSavables(ref global::RustProto.SavedObject saveobj)
	{
		foreach (global::UnityEngine.MonoBehaviour monoBehaviour in this.GetServerSaveables())
		{
			global::IServerSaveable serverSaveable;
			if (monoBehaviour && !object.ReferenceEquals(serverSaveable = (monoBehaviour as global::IServerSaveable), null))
			{
				serverSaveable.ReadObjectSave(ref saveobj);
			}
		}
	}

	// Token: 0x06000433 RID: 1075 RVA: 0x00013E30 File Offset: 0x00012030
	public void Reset()
	{
		global::ServerSaveManager.Consolidate();
	}

	// Token: 0x06000434 RID: 1076 RVA: 0x00013E38 File Offset: 0x00012038
	public global::System.Collections.Generic.IEnumerable<global::UnityEngine.MonoBehaviour> GetServerSaveableComponents()
	{
		foreach (global::UnityEngine.MonoBehaviour component in base.GetComponents<global::UnityEngine.MonoBehaviour>())
		{
			if (component && component is global::IServerSaveable)
			{
				yield return component;
			}
		}
		yield break;
	}

	// Token: 0x06000435 RID: 1077 RVA: 0x00013E5C File Offset: 0x0001205C
	public global::System.Collections.Generic.IEnumerable<TMonoBehaviour> GetServerSaveableComponents<TMonoBehaviour>() where TMonoBehaviour : global::UnityEngine.MonoBehaviour
	{
		foreach (TMonoBehaviour component in base.GetComponents<TMonoBehaviour>())
		{
			if (component && component is global::IServerSaveable)
			{
				yield return component;
			}
		}
		yield break;
	}

	// Token: 0x06000436 RID: 1078 RVA: 0x00013E80 File Offset: 0x00012080
	private void uLink_OnNetworkInstantiate(global::uLink.NetworkMessageInfo info)
	{
		if (this.autoNetSerialize && (int)this.registered == 0 && global::ServerSaveManager.NetRegister(this, ref info))
		{
			this.registered = global::ServerSave.Reged.ToNet;
		}
	}

	// Token: 0x06000437 RID: 1079 RVA: 0x00013EB0 File Offset: 0x000120B0
	private void NGC_OnInstantiate(global::NGCView view)
	{
		if (this.autoNetSerialize && (int)this.registered == 0 && global::ServerSaveManager.NGCRegister(this))
		{
			this.registered = global::ServerSave.Reged.ToNGC;
		}
	}

	// Token: 0x06000438 RID: 1080 RVA: 0x00013EDC File Offset: 0x000120DC
	private void OnDestroy()
	{
		switch (this.registered)
		{
		case global::ServerSave.Reged.None:
			return;
		case global::ServerSave.Reged.ToNet:
			try
			{
				global::ServerSaveManager.NetUnregister(this);
			}
			finally
			{
				this.registered = global::ServerSave.Reged.None;
			}
			return;
		case global::ServerSave.Reged.ToNGC:
			try
			{
				global::ServerSaveManager.NGCUnregister(this);
			}
			finally
			{
				this.registered = global::ServerSave.Reged.None;
			}
			return;
		default:
			global::UnityEngine.Debug.Log(" unknown reged " + this.registered);
			return;
		}
	}

	// Token: 0x06000439 RID: 1081 RVA: 0x00013F80 File Offset: 0x00012180
	public void SaveInstance_Generic(ref global::RustProto.SavedObject.Builder obj, global::UnityEngine.Vector3 OldPos, global::UnityEngine.Quaternion OldAng, int? sortOrder)
	{
		this.SaveServerSaveables(ref obj);
		if (sortOrder != null)
		{
			obj.SetSortOrder(sortOrder.Value);
		}
		using (global::RustProto.Helpers.Recycler<global::RustProto.objectCoords, global::RustProto.objectCoords.Builder> recycler = global::RustProto.objectCoords.Recycler())
		{
			global::RustProto.objectCoords.Builder builder = recycler.OpenBuilder();
			builder.SetPos(base.transform.position);
			builder.SetRot(base.transform.rotation);
			builder.SetOldPos(OldPos);
			builder.SetOldRot(OldAng);
			obj.SetCoords(builder);
		}
	}

	// Token: 0x0600043A RID: 1082 RVA: 0x0001403C File Offset: 0x0001223C
	public void SaveInstance_NetworkView(ref global::RustProto.SavedObject.Builder obj, int sortOrder)
	{
		using (global::RustProto.Helpers.Recycler<global::RustProto.objectNetInstance, global::RustProto.objectNetInstance.Builder> recycler = global::RustProto.objectNetInstance.Recycler())
		{
			global::RustProto.objectNetInstance.Builder builder = recycler.OpenBuilder();
			global::uLinkNetworkView component = base.GetComponent<global::uLinkNetworkView>();
			this.SaveInstance_Generic(ref obj, component.position, component.rotation, new int?(sortOrder));
			obj.SetId(component.viewID.id);
			builder.SetServerPrefab(global::SaveStringPool.GetInt(component.serverPrefab));
			builder.SetOwnerPrefab(global::SaveStringPool.GetInt(component.ownerPrefab));
			builder.SetProxyPrefab(global::SaveStringPool.GetInt(component.proxyPrefab));
			global::NetworkCullInfo component2 = base.GetComponent<global::NetworkCullInfo>();
			if (!component2)
			{
				builder.SetGroupID(component.group.id);
			}
			obj.SetNetInstance(builder);
		}
	}

	// Token: 0x0600043B RID: 1083 RVA: 0x00014124 File Offset: 0x00012324
	public void SaveInstance_NGC(ref global::RustProto.SavedObject.Builder obj, int sortOrder)
	{
		using (global::RustProto.Helpers.Recycler<global::RustProto.objectNGCInstance, global::RustProto.objectNGCInstance.Builder> recycler = global::RustProto.objectNGCInstance.Recycler())
		{
			global::RustProto.objectNGCInstance.Builder builder = recycler.OpenBuilder();
			global::NGCView component = base.GetComponent<global::NGCView>();
			this.SaveInstance_Generic(ref obj, component.creationPosition, component.creationRotation, new int?(sortOrder));
			obj.SetId(component.entityID.id);
			builder.Clear();
			builder.SetID(component.prefab.key);
			if (component.initialData != null)
			{
				builder.SetData(global::Google.ProtocolBuffers.ByteString.CopyFrom(component.initialData.GetDataByteArray()));
			}
			obj.SetNgcInstance(builder);
		}
	}

	// Token: 0x0600043C RID: 1084 RVA: 0x000141E8 File Offset: 0x000123E8
	public static global::Facepunch.NetworkView CreateNetInstance(ref global::RustProto.SavedObject saveObj, global::UnityEngine.Vector3 vPos, global::UnityEngine.Quaternion vAng)
	{
		string prefab = global::SaveStringPool.Convert(saveObj.NetInstance.ServerPrefab);
		global::UnityEngine.GameObject gameObject;
		if (saveObj.NetInstance.HasGroupID)
		{
			if (saveObj.NetInstance.GroupID == 0)
			{
				gameObject = global::NetCull.InstantiateClassic(prefab, vPos, vAng, saveObj.NetInstance.GroupID);
			}
			else
			{
				gameObject = global::NetCull.InstantiateStatic(prefab, vPos, vAng);
			}
		}
		else
		{
			gameObject = global::NetCull.InstantiateDynamic(prefab, vPos, vAng);
		}
		global::ServerSave component = gameObject.GetComponent<global::ServerSave>();
		component.LoadServerSavables(ref saveObj);
		return global::Facepunch.NetworkView.Get(gameObject);
	}

	// Token: 0x0600043D RID: 1085 RVA: 0x00014270 File Offset: 0x00012470
	public static global::NGCView CreateNGCInstance(ref global::RustProto.SavedObject saveObj, global::UnityEngine.Vector3 vPos, global::UnityEngine.Quaternion vAng)
	{
		string prefab = global::NGC.Prefab.Register.FindName(saveObj.NgcInstance.ID);
		global::UnityEngine.GameObject gameObject;
		if (saveObj.NgcInstance.HasData)
		{
			byte[] arg = saveObj.NgcInstance.Data.ToByteArray();
			gameObject = global::NetCull.InstantiateStaticWithArgs<byte[]>(prefab, vPos, vAng, arg);
		}
		else
		{
			gameObject = global::NetCull.InstantiateStatic(prefab, vPos, vAng);
		}
		global::ServerSave component = gameObject.GetComponent<global::ServerSave>();
		component.LoadServerSavables(ref saveObj);
		return gameObject.GetComponent<global::NGCView>();
	}

	// Token: 0x040003EB RID: 1003
	private static global::System.Collections.Generic.Dictionary<int, string> StructureDictionary;

	// Token: 0x040003EC RID: 1004
	[global::UnityEngine.SerializeField]
	private bool autoNetSerialize = true;

	// Token: 0x040003ED RID: 1005
	[global::System.NonSerialized]
	private global::ServerSave.Reged registered;

	// Token: 0x040003EE RID: 1006
	[global::System.NonSerialized]
	private global::UnityEngine.MonoBehaviour[] serverSaveables;

	// Token: 0x040003EF RID: 1007
	[global::System.NonSerialized]
	private bool builtServerSaveablesArray;

	// Token: 0x020000DA RID: 218
	internal enum Reged : sbyte
	{
		// Token: 0x040003F1 RID: 1009
		None,
		// Token: 0x040003F2 RID: 1010
		ToNet,
		// Token: 0x040003F3 RID: 1011
		ToNGC
	}

	// Token: 0x020000DB RID: 219
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <GetServerSaveableComponents>c__Iterator16 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::UnityEngine.MonoBehaviour>, global::System.Collections.Generic.IEnumerator<global::UnityEngine.MonoBehaviour>
	{
		// Token: 0x0600043E RID: 1086 RVA: 0x000142E0 File Offset: 0x000124E0
		public <GetServerSaveableComponents>c__Iterator16()
		{
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x0600043F RID: 1087 RVA: 0x000142E8 File Offset: 0x000124E8
		global::UnityEngine.MonoBehaviour global::System.Collections.Generic.IEnumerator<global::UnityEngine.MonoBehaviour>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000440 RID: 1088 RVA: 0x000142F0 File Offset: 0x000124F0
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x000142F8 File Offset: 0x000124F8
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<UnityEngine.MonoBehaviour>.GetEnumerator();
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x00014300 File Offset: 0x00012500
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::UnityEngine.MonoBehaviour> global::System.Collections.Generic.IEnumerable<global::UnityEngine.MonoBehaviour>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::ServerSave.<GetServerSaveableComponents>c__Iterator16 <GetServerSaveableComponents>c__Iterator = new global::ServerSave.<GetServerSaveableComponents>c__Iterator16();
			<GetServerSaveableComponents>c__Iterator.<>f__this = this;
			return <GetServerSaveableComponents>c__Iterator;
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x00014334 File Offset: 0x00012534
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				components = base.GetComponents<global::UnityEngine.MonoBehaviour>();
				i = 0;
				break;
			case 1U:
				IL_89:
				i++;
				break;
			default:
				return false;
			}
			if (i >= components.Length)
			{
				this.$PC = -1;
			}
			else
			{
				component = components[i];
				if (component && component is global::IServerSaveable)
				{
					this.$current = component;
					this.$PC = 1;
					return true;
				}
				goto IL_89;
			}
			return false;
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x000143F8 File Offset: 0x000125F8
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00014404 File Offset: 0x00012604
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x040003F4 RID: 1012
		internal global::UnityEngine.MonoBehaviour[] <$s_141>__0;

		// Token: 0x040003F5 RID: 1013
		internal int <$s_142>__1;

		// Token: 0x040003F6 RID: 1014
		internal global::UnityEngine.MonoBehaviour <component>__2;

		// Token: 0x040003F7 RID: 1015
		internal int $PC;

		// Token: 0x040003F8 RID: 1016
		internal global::UnityEngine.MonoBehaviour $current;

		// Token: 0x040003F9 RID: 1017
		internal global::ServerSave <>f__this;
	}

	// Token: 0x020000DC RID: 220
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <GetServerSaveableComponents>c__Iterator17<TMonoBehaviour> : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<!0>, global::System.Collections.Generic.IEnumerator<!0> where TMonoBehaviour : global::UnityEngine.MonoBehaviour
	{
		// Token: 0x06000446 RID: 1094 RVA: 0x0001440C File Offset: 0x0001260C
		public <GetServerSaveableComponents>c__Iterator17()
		{
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000447 RID: 1095 RVA: 0x00014414 File Offset: 0x00012614
		TMonoBehaviour global::System.Collections.Generic.IEnumerator<!0>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000448 RID: 1096 RVA: 0x0001441C File Offset: 0x0001261C
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x0001442C File Offset: 0x0001262C
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<TMonoBehaviour>.GetEnumerator();
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x00014434 File Offset: 0x00012634
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<TMonoBehaviour> global::System.Collections.Generic.IEnumerable<!0>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::ServerSave.<GetServerSaveableComponents>c__Iterator17<TMonoBehaviour> <GetServerSaveableComponents>c__Iterator = new global::ServerSave.<GetServerSaveableComponents>c__Iterator17<TMonoBehaviour>();
			<GetServerSaveableComponents>c__Iterator.<>f__this = this;
			return <GetServerSaveableComponents>c__Iterator;
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x00014468 File Offset: 0x00012668
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				components = base.GetComponents<TMonoBehaviour>();
				i = 0;
				break;
			case 1U:
				IL_97:
				i++;
				break;
			default:
				return false;
			}
			if (i >= components.Length)
			{
				this.$PC = -1;
			}
			else
			{
				component = components[i];
				if (component && component is global::IServerSaveable)
				{
					this.$current = component;
					this.$PC = 1;
					return true;
				}
				goto IL_97;
			}
			return false;
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x0001453C File Offset: 0x0001273C
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x00014548 File Offset: 0x00012748
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x040003FA RID: 1018
		internal TMonoBehaviour[] <$s_143>__0;

		// Token: 0x040003FB RID: 1019
		internal int <$s_144>__1;

		// Token: 0x040003FC RID: 1020
		internal TMonoBehaviour <component>__2;

		// Token: 0x040003FD RID: 1021
		internal int $PC;

		// Token: 0x040003FE RID: 1022
		internal TMonoBehaviour $current;

		// Token: 0x040003FF RID: 1023
		internal global::ServerSave <>f__this;
	}
}
