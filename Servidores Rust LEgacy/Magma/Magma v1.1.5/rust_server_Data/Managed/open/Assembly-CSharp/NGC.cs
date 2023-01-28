using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Facepunch;
using uLink;
using UnityEngine;

// Token: 0x0200034C RID: 844
[global::UnityEngine.AddComponentMenu("")]
public sealed class NGC : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06001C48 RID: 7240 RVA: 0x000712CC File Offset: 0x0006F4CC
	public NGC()
	{
	}

	// Token: 0x06001C49 RID: 7241 RVA: 0x000712EC File Offset: 0x0006F4EC
	// Note: this type is marked as 'beforefieldinit'.
	static NGC()
	{
	}

	// Token: 0x06001C4A RID: 7242 RVA: 0x000712F0 File Offset: 0x0006F4F0
	private void uLink_OnNetworkInstantiate(global::uLink.NetworkMessageInfo info)
	{
		this.uidmapper = new global::NGC.UIDMapper();
		global::NGC ngc;
		if (global::NGC.Global.byGroup.TryGetValue(this.groupNumber, out ngc))
		{
			if (ngc == this)
			{
				return;
			}
			if (ngc)
			{
				ngc.Release();
			}
		}
		global::NGC.Global.all.Add(this);
		this.groupNumber = (ushort)this.networkView.group.id;
		global::NGC.Global.byGroup[this.groupNumber] = this;
		this.added = true;
		this.creation = info;
	}

	// Token: 0x06001C4B RID: 7243 RVA: 0x00071384 File Offset: 0x0006F584
	private void Release()
	{
		if (this.added)
		{
			if (global::NGC.Global.all.Remove(this))
			{
				global::NGC.Global.byGroup.Remove(this.groupNumber);
			}
			this.added = false;
		}
	}

	// Token: 0x06001C4C RID: 7244 RVA: 0x000713BC File Offset: 0x0006F5BC
	private void DestroyView(global::NGCView view, bool andGameObject, bool skipPreDestroy)
	{
		if (!view)
		{
			return;
		}
		if (andGameObject)
		{
			global::UnityEngine.GameObject gameObject = view.gameObject;
			if (!skipPreDestroy)
			{
				this.DestroyView(view, false, false);
			}
			global::UnityEngine.Object.Destroy(gameObject);
		}
		else if (!skipPreDestroy)
		{
			try
			{
				view.PreDestroy();
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex);
			}
		}
	}

	// Token: 0x06001C4D RID: 7245 RVA: 0x00071438 File Offset: 0x0006F638
	private void PreDestroy()
	{
		global::System.Collections.Generic.List<global::NGCView> list = new global::System.Collections.Generic.List<global::NGCView>(this.views.Values);
		foreach (global::NGCView view in list)
		{
			this.DestroyView(view, false, false);
		}
		foreach (global::NGCView view2 in list)
		{
			this.DestroyView(view2, true, true);
		}
	}

	// Token: 0x06001C4E RID: 7246 RVA: 0x00071500 File Offset: 0x0006F700
	private void OnDestroy()
	{
		this.Release();
	}

	// Token: 0x06001C4F RID: 7247 RVA: 0x00071508 File Offset: 0x0006F708
	internal global::System.Collections.Generic.Dictionary<ushort, global::NGCView>.ValueCollection GetViews()
	{
		return this.views.Values;
	}

	// Token: 0x06001C50 RID: 7248 RVA: 0x00071518 File Offset: 0x0006F718
	private global::NGCView Add(byte[] data, int offset, int length, global::uLink.NetworkMessageInfo info)
	{
		int index = global::System.BitConverter.ToInt32(data, offset);
		int num = offset + 4;
		ushort innerID = global::System.BitConverter.ToUInt16(data, num);
		num += 2;
		global::UnityEngine.Vector3 vector;
		vector.x = global::System.BitConverter.ToSingle(data, num);
		num += 4;
		vector.y = global::System.BitConverter.ToSingle(data, num);
		num += 4;
		vector.z = global::System.BitConverter.ToSingle(data, num);
		num += 4;
		global::UnityEngine.Vector3 vector2;
		vector2.x = global::System.BitConverter.ToSingle(data, num);
		num += 4;
		vector2.y = global::System.BitConverter.ToSingle(data, num);
		num += 4;
		vector2.z = global::System.BitConverter.ToSingle(data, num);
		num += 4;
		global::UnityEngine.Quaternion quaternion = global::UnityEngine.Quaternion.Euler(vector2);
		global::NGC.Prefab prefab;
		global::NGC.Prefab.Register.Find(index, out prefab);
		global::NGCView ngcview = (global::NGCView)global::UnityEngine.Object.Instantiate(prefab.prefab, vector, quaternion);
		ngcview.creation = info;
		ngcview.innerID = innerID;
		ngcview.prefab = prefab;
		ngcview.outer = this;
		ngcview.spawnPosition = vector;
		ngcview.spawnRotation = quaternion;
		int num2 = offset + length;
		if (num2 == num)
		{
			ngcview.initialData = null;
		}
		else
		{
			byte[] array = new byte[num2 - num];
			int num3 = 0;
			do
			{
				array[num3++] = data[num++];
			}
			while (num < num2);
			ngcview.initialData = new global::uLink.BitStream(array, false);
		}
		ngcview.install = new global::NGC.Prefab.Installation.Instance(prefab.installation);
		ngcview.addRPCName = this.currentAddRPCName;
		ngcview.callRPCName = global::NGC.GenerateRPCName("C", ngcview.innerID);
		ngcview.removeRPCName = global::NGC.GenerateRPCName("D", ngcview.innerID);
		return ngcview;
	}

	// Token: 0x06001C51 RID: 7249 RVA: 0x000716A8 File Offset: 0x0006F8A8
	private global::NGCView Delete(ushort id, global::uLink.NetworkMessageInfo info)
	{
		if (!this.uidmapper.Free((int)id))
		{
			global::UnityEngine.Debug.LogError("This is not supposed to happen!");
		}
		global::NGCView ngcview = this.views[id];
		this.DestroyView(ngcview, false, false);
		this.views.Remove(id);
		return ngcview;
	}

	// Token: 0x06001C52 RID: 7250 RVA: 0x000716F4 File Offset: 0x0006F8F4
	private global::NGC.Procedure Message(int id, int msg, byte[] args, int argByteSize, global::uLink.NetworkMessageInfo info)
	{
		return new global::NGC.Procedure
		{
			outer = this,
			target = id,
			message = msg,
			data = args,
			dataLength = argByteSize,
			info = info
		};
	}

	// Token: 0x06001C53 RID: 7251 RVA: 0x00071734 File Offset: 0x0006F934
	private global::NGC.Procedure Message(int id_msg, byte[] args, int argByteSize, global::uLink.NetworkMessageInfo info)
	{
		return this.Message(id_msg >> 0x10 & 0xFFFF, id_msg & 0xFFFF, args, argByteSize, info);
	}

	// Token: 0x06001C54 RID: 7252 RVA: 0x00071754 File Offset: 0x0006F954
	private global::NGC.Procedure Message(byte[] data, int offset, int length, global::uLink.NetworkMessageInfo info)
	{
		int id_msg = global::System.BitConverter.ToInt32(data, offset);
		int num = offset + 4;
		int num2 = offset + length;
		byte[] array;
		int num3;
		if (num == num2)
		{
			array = null;
			num3 = 0;
		}
		else
		{
			num3 = num2 - num;
			array = new byte[num3];
			int num4 = 0;
			do
			{
				array[num4++] = data[num++];
			}
			while (num < num2);
		}
		return this.Message(id_msg, array, num3, info);
	}

	// Token: 0x06001C55 RID: 7253 RVA: 0x000717B8 File Offset: 0x0006F9B8
	[global::UnityEngine.RPC]
	internal void A(byte[] data, global::uLink.NetworkMessageInfo info)
	{
		if (info.sender != global::uLink.NetworkPlayer.server)
		{
			return;
		}
		global::NGCView ngcview = this.Add(data, 0, data.Length, info);
		this.views[ngcview.innerID] = ngcview;
		try
		{
			ngcview.PostInstantiate();
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogException(ex);
		}
		finally
		{
			this.serverInstantiatedStack.Push(ngcview);
		}
	}

	// Token: 0x06001C56 RID: 7254 RVA: 0x00071854 File Offset: 0x0006FA54
	[global::UnityEngine.RPC]
	internal void D(ushort id, global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x06001C57 RID: 7255 RVA: 0x00071858 File Offset: 0x0006FA58
	[global::UnityEngine.RPC]
	internal void C(byte[] data, global::uLink.NetworkMessageInfo info)
	{
		global::NGC.Procedure procedure = this.Message(data, 0, data.Length, info);
		if (!procedure.Call())
		{
			if (procedure.view)
			{
				global::UnityEngine.Debug.LogWarning(string.Format("Did not call rpc \"{0}\" for view \"{1}\" (entid:{2},msg:{3})", new object[]
				{
					procedure.view.prefab.installation.methods[procedure.message].method.Name,
					procedure.view.name,
					procedure.view.id,
					procedure.message
				}), this);
			}
			else if (global::NGC.log_nonexistant_ngc_errors)
			{
				global::UnityEngine.Debug.LogWarning(string.Format("Did not call rpc to non existant view# {0}. ( message id was {1} )", procedure.target, procedure.message), this);
			}
		}
	}

	// Token: 0x06001C58 RID: 7256 RVA: 0x00071934 File Offset: 0x0006FB34
	private byte[] RPCData(int viewID, int messageID, byte[] arguments, int argumentsOffset, int argumentsLength)
	{
		byte[] bytes = global::System.BitConverter.GetBytes(viewID << 0x10 | (messageID & 0xFFFF));
		byte[] array = new byte[bytes.Length + argumentsLength];
		int num = 0;
		for (int i = 0; i < bytes.Length; i++)
		{
			array[num++] = bytes[i];
		}
		int num2 = argumentsOffset;
		int j = 0;
		while (j < argumentsLength)
		{
			array[num++] = arguments[num2];
			j++;
			num2++;
		}
		return array;
	}

	// Token: 0x06001C59 RID: 7257 RVA: 0x000719AC File Offset: 0x0006FBAC
	private void ShootRPC(global::NGC.RPCName rpc, global::uLink.RPCMode mode, byte[] data)
	{
		if (!rpc.valid)
		{
			return;
		}
		if (rpc.flags == null)
		{
			this.networkView.RPC<byte[]>(rpc.name, mode, data);
		}
		else
		{
			this.networkView.RPC<byte[]>(rpc.flags, rpc.name, mode, data);
		}
		if (rpc.mapBuffered)
		{
			rpc.view.DidBufferedRPCCall(rpc.message);
		}
	}

	// Token: 0x06001C5A RID: 7258 RVA: 0x00071A28 File Offset: 0x0006FC28
	private void ShootRPC(global::NGC.RPCName rpc, global::uLink.NetworkPlayer target, byte[] data)
	{
		if (!rpc.valid)
		{
			return;
		}
		if (rpc.flags == null)
		{
			this.networkView.RPC<byte[]>(rpc.name, target, data);
		}
		else
		{
			this.networkView.RPC<byte[]>(rpc.flags, rpc.name, target, data);
		}
	}

	// Token: 0x06001C5B RID: 7259 RVA: 0x00071A84 File Offset: 0x0006FC84
	private void ShootRPC(global::NGC.RPCName rpc, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, byte[] data)
	{
		if (!rpc.valid)
		{
			return;
		}
		if (rpc.flags == null)
		{
			this.networkView.RPC<byte[]>(rpc.name, targets, data);
		}
		else
		{
			this.networkView.RPC<byte[]>(rpc.flags, rpc.name, targets, data);
		}
	}

	// Token: 0x06001C5C RID: 7260 RVA: 0x00071AE0 File Offset: 0x0006FCE0
	private static global::NGC.RPCName CallRPCName(global::uLink.NetworkFlags? flags, global::NGCView view, int messageID)
	{
		return new global::NGC.RPCName(view, messageID, "C", (flags == null) ? view.prefab.DefaultNetworkFlags(messageID) : flags.Value);
	}

	// Token: 0x06001C5D RID: 7261 RVA: 0x00071B20 File Offset: 0x0006FD20
	private static global::NGC.RPCName CallRPCName(global::uLink.NetworkFlags? flags, global::NGCView view, int messageID, ref global::uLink.NetworkPlayer target)
	{
		return global::NGC.CallRPCName(flags, view, messageID);
	}

	// Token: 0x06001C5E RID: 7262 RVA: 0x00071B2C File Offset: 0x0006FD2C
	private static global::NGC.RPCName CallRPCName(global::uLink.NetworkFlags? flags, global::NGCView view, int messageID, ref global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets)
	{
		return global::NGC.CallRPCName(flags, view, messageID);
	}

	// Token: 0x06001C5F RID: 7263 RVA: 0x00071B38 File Offset: 0x0006FD38
	private static global::NGC.RPCName CallRPCName(global::uLink.NetworkFlags? flags, global::NGCView view, int messageID, ref global::uLink.RPCMode mode)
	{
		global::uLink.NetworkFlags networkFlags = (flags == null) ? view.prefab.DefaultNetworkFlags(messageID) : flags.Value;
		global::uLink.RPCMode rpcmode;
		if ((networkFlags & 3) == 0)
		{
			rpcmode = mode;
			switch (rpcmode)
			{
			case 4:
			case 5:
			case 6:
				break;
			default:
				if (rpcmode != 0xD && rpcmode != 0xE)
				{
					goto IL_C8;
				}
				break;
			}
			return new global::NGC.RPCName(view, messageID, view.GetBufferedCallRPCName(messageID), networkFlags, true);
		}
		rpcmode = mode;
		switch (rpcmode)
		{
		case 4:
			return default(global::NGC.RPCName);
		case 5:
			mode = 1;
			break;
		case 6:
			mode = 2;
			break;
		default:
			if (rpcmode != 0xD)
			{
				if (rpcmode == 0xE)
				{
					mode = 0xA;
				}
			}
			else
			{
				mode = 9;
			}
			break;
		}
		IL_C8:
		return new global::NGC.RPCName(view, messageID, "C", networkFlags, false);
	}

	// Token: 0x06001C60 RID: 7264 RVA: 0x00071C1C File Offset: 0x0006FE1C
	internal void NGCViewRPC(global::uLink.NetworkFlags flags, global::uLink.RPCMode mode, global::NGCView view, int messageID, byte[] arguments, int argumentsOffset, int argumentsLength)
	{
		this.ShootRPC(global::NGC.CallRPCName(new global::uLink.NetworkFlags?(flags), view, messageID, ref mode), mode, this.RPCData((int)view.innerID, messageID, arguments, argumentsOffset, argumentsLength));
	}

	// Token: 0x06001C61 RID: 7265 RVA: 0x00071C54 File Offset: 0x0006FE54
	internal void NGCViewRPC(global::uLink.NetworkFlags flags, global::uLink.NetworkPlayer target, global::NGCView view, int messageID, byte[] arguments, int argumentsOffset, int argumentsLength)
	{
		this.ShootRPC(global::NGC.CallRPCName(new global::uLink.NetworkFlags?(flags), view, messageID, ref target), target, this.RPCData((int)view.innerID, messageID, arguments, argumentsOffset, argumentsLength));
	}

	// Token: 0x06001C62 RID: 7266 RVA: 0x00071C8C File Offset: 0x0006FE8C
	internal void NGCViewRPC(global::uLink.NetworkFlags flags, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, global::NGCView view, int messageID, byte[] arguments, int argumentsOffset, int argumentsLength)
	{
		this.ShootRPC(global::NGC.CallRPCName(new global::uLink.NetworkFlags?(flags), view, messageID, ref targets), targets, this.RPCData((int)view.innerID, messageID, arguments, argumentsOffset, argumentsLength));
	}

	// Token: 0x06001C63 RID: 7267 RVA: 0x00071CC4 File Offset: 0x0006FEC4
	internal void NGCViewRPC(global::uLink.RPCMode mode, global::NGCView view, int messageID, byte[] arguments, int argumentsOffset, int argumentsLength)
	{
		this.ShootRPC(global::NGC.CallRPCName(null, view, messageID, ref mode), mode, this.RPCData((int)view.innerID, messageID, arguments, argumentsOffset, argumentsLength));
	}

	// Token: 0x06001C64 RID: 7268 RVA: 0x00071D00 File Offset: 0x0006FF00
	internal void NGCViewRPC(global::uLink.NetworkPlayer target, global::NGCView view, int messageID, byte[] arguments, int argumentsOffset, int argumentsLength)
	{
		this.ShootRPC(global::NGC.CallRPCName(null, view, messageID, ref target), target, this.RPCData((int)view.innerID, messageID, arguments, argumentsOffset, argumentsLength));
	}

	// Token: 0x06001C65 RID: 7269 RVA: 0x00071D3C File Offset: 0x0006FF3C
	internal void NGCViewRPC(global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, global::NGCView view, int messageID, byte[] arguments, int argumentsOffset, int argumentsLength)
	{
		this.ShootRPC(global::NGC.CallRPCName(null, view, messageID, ref targets), targets, this.RPCData((int)view.innerID, messageID, arguments, argumentsOffset, argumentsLength));
	}

	// Token: 0x06001C66 RID: 7270 RVA: 0x00071D78 File Offset: 0x0006FF78
	[global::System.Obsolete("NO, Use net cull making sure the prefab name string you must use starts with ;", true)]
	public static global::UnityEngine.Object Instantiate(global::UnityEngine.Object obj)
	{
		return global::UnityEngine.Object.Instantiate(obj);
	}

	// Token: 0x06001C67 RID: 7271 RVA: 0x00071D80 File Offset: 0x0006FF80
	[global::System.Obsolete("NO, Use net cull making sure the prefab name string you must use starts with ;", true)]
	public static global::UnityEngine.Object Instantiate(global::UnityEngine.Object obj, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		return global::UnityEngine.Object.Instantiate(obj, position, rotation);
	}

	// Token: 0x06001C68 RID: 7272 RVA: 0x00071D8C File Offset: 0x0006FF8C
	private static global::uLink.NetworkView SpawnNGC_NetworkView(string prefabName, global::uLink.NetworkInstantiateArgs args, global::uLink.NetworkMessageInfo info)
	{
		global::uLink.NetworkInstantiatorUtility.AutoSetupNetworkViewOnAwake(args);
		global::UnityEngine.GameObject gameObject = new global::UnityEngine.GameObject(string.Format("__NGC-{0:X}", args.group), new global::System.Type[]
		{
			typeof(global::NGC),
			typeof(global::NGCInternalView)
		})
		{
			hideFlags = 1
		};
		global::uLink.NetworkInstantiatorUtility.ClearAutoSetupNetworkViewOnAwake();
		global::uLinkNetworkView component = gameObject.GetComponent<global::uLinkNetworkView>();
		global::NGC component2 = gameObject.GetComponent<global::NGC>();
		component.observed = component2;
		component.rpcReceiver = 1;
		component.stateSynchronization = 0;
		global::uLink.NetworkMessageInfo info2 = new global::uLink.NetworkMessageInfo(info, component);
		component2.uLink_OnNetworkInstantiate(info2);
		return component;
	}

	// Token: 0x06001C69 RID: 7273 RVA: 0x00071E20 File Offset: 0x00070020
	private static void DestroyNGC_NetworkView(global::uLink.NetworkView view)
	{
		global::NGC component = view.GetComponent<global::NGC>();
		component.PreDestroy();
		global::UnityEngine.Object.Destroy(component);
		global::uLink.NetworkInstantiator.defaultDestroyer.Invoke(view);
	}

	// Token: 0x06001C6A RID: 7274 RVA: 0x00071E4C File Offset: 0x0007004C
	public static void Register(global::NGCConfiguration configuration)
	{
		global::uLink.NetworkInstantiator.Add("!Ng", new global::uLink.NetworkInstantiator.Creator(global::NGC.SpawnNGC_NetworkView), new global::uLink.NetworkInstantiator.Destroyer(global::NGC.DestroyNGC_NetworkView));
		configuration.Install();
	}

	// Token: 0x06001C6B RID: 7275 RVA: 0x00071E84 File Offset: 0x00070084
	private static string GenerateRPCName(string incoming, ushort viewID)
	{
		return incoming + viewID.ToString("x");
	}

	// Token: 0x06001C6C RID: 7276 RVA: 0x00071E98 File Offset: 0x00070098
	private global::UnityEngine.Object ServerInstantiate(global::NGC.Prefab prefab, ref global::NetCull.InstantiateArgs args)
	{
		global::NGCView prefab2 = prefab.prefab;
		if (prefab2 == null)
		{
			global::UnityEngine.Debug.Log(string.Format("Prefab for '{0}'['{1:X}'] could not be loaded.", args.prefabName, prefab.key), this);
			return null;
		}
		global::NetCullInstantiationCall call = args.call;
		byte[] array;
		if (call != global::NetCullInstantiationCall.Classic_Args && call != global::NetCullInstantiationCall.Static_Args)
		{
			array = new byte[0x1E];
		}
		else
		{
			global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
			foreach (object obj in args.args)
			{
				bitStream.WriteObject(obj, new object[0]);
			}
			array = bitStream.GetDataByteArrayShiftedRight(0x1E);
		}
		int num = 0;
		byte[] bytes = global::System.BitConverter.GetBytes(prefab.key);
		for (int j = 0; j < 4; j++)
		{
			array[num++] = bytes[j];
		}
		ushort num2;
		if (!this.uidmapper.Alloc(out num2))
		{
			throw new global::System.InvalidOperationException("out of uids");
		}
		try
		{
			bytes = global::System.BitConverter.GetBytes(num2);
			for (int k = 0; k < 2; k++)
			{
				array[num++] = bytes[k];
			}
			for (int l = 0; l < 2; l++)
			{
				global::UnityEngine.Vector3 vector = (l != 0) ? args.rotation.eulerAngles : args.position;
				for (int m = 0; m < 3; m++)
				{
					bytes = global::System.BitConverter.GetBytes(vector[m]);
					for (int n = 0; n < 4; n++)
					{
						array[num++] = bytes[n];
					}
				}
			}
			string text = this.currentAddRPCName;
			try
			{
				this.currentAddRPCName = global::NGC.GenerateRPCName("A", num2);
				this.ShootRPC(new global::NGC.RPCName(null, -1, this.currentAddRPCName, 0, false), 6, array);
			}
			finally
			{
				this.currentAddRPCName = text;
			}
		}
		catch
		{
			this.uidmapper.Free((int)num2);
			throw;
		}
		global::NGCView ngcview = this.serverInstantiatedStack.Pop();
		return (!ngcview) ? null : ngcview.gameObject;
	}

	// Token: 0x06001C6D RID: 7277 RVA: 0x00072104 File Offset: 0x00070304
	internal static global::UnityEngine.Object Instantiate(ref global::NetCull.InstantiateArgs args, int groupToUse)
	{
		if (groupToUse < 0)
		{
			global::UnityEngine.Debug.LogError("Group cant be less than zero");
			return null;
		}
		global::NGC.Prefab prefab;
		if (!global::NGC.Prefab.Register.Find(args.prefabName, out prefab))
		{
			global::UnityEngine.Debug.LogError("No NGC Prefab with name:" + args.prefabName);
			return null;
		}
		global::NGC component;
		if (!global::NGC.Global.byGroup.TryGetValue((ushort)groupToUse, out component))
		{
			component = global::NetCull.InstantiateClassic("!Ng", global::UnityEngine.Vector3.zero, global::UnityEngine.Quaternion.identity, groupToUse).GetComponent<global::NGC>();
		}
		return component.ServerInstantiate(prefab, ref args);
	}

	// Token: 0x06001C6E RID: 7278 RVA: 0x00072184 File Offset: 0x00070384
	private void NetDestroy(global::NGCView view)
	{
		global::NGCView ngcview;
		if (this.views.TryGetValue(view.innerID, out ngcview) && ngcview == view)
		{
			if (ngcview._net_destroying)
			{
				return;
			}
			ngcview._net_destroying = true;
			global::ServerManagement serverManagement = global::ServerManagement.Get();
			if (serverManagement)
			{
				global::IDMain component = view.GetComponent<global::IDMain>();
				if (component)
				{
					serverManagement.ServerWillDestroyMain(component, view.entityID, global::NetEntityID.Kind.NGC, view);
				}
			}
			try
			{
				view.PreDestroy();
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex);
			}
			foreach (string rpcName in view.AllRPCNamesUsed())
			{
				global::NetCull.RemoveRPCsByName(this.networkViewID, rpcName);
			}
			ushort innerID = view.innerID;
			view.innerID = 0;
			view.outer = null;
			try
			{
				this.networkView.RPC<ushort>("D", 1, innerID);
			}
			catch (global::System.Exception ex2)
			{
				global::UnityEngine.Debug.LogException(ex2);
			}
			finally
			{
				try
				{
					this.DestroyView(view, true, true);
				}
				catch (global::System.Exception ex3)
				{
					global::UnityEngine.Debug.LogException(ex3);
				}
				finally
				{
					try
					{
						this.views.Remove(innerID);
					}
					catch (global::System.Exception ex4)
					{
						global::UnityEngine.Debug.LogException(ex4);
					}
				}
			}
		}
	}

	// Token: 0x06001C6F RID: 7279 RVA: 0x00072380 File Offset: 0x00070580
	internal static void DispatchNetDestroy(global::NGCView view)
	{
		if (view.innerID != 0 && view.outer)
		{
			view.outer.NetDestroy(view);
		}
	}

	// Token: 0x06001C70 RID: 7280 RVA: 0x000723AC File Offset: 0x000705AC
	internal static int PackID(int groupNumber, int innerID)
	{
		if (groupNumber < 0 || innerID <= 0)
		{
			return 0;
		}
		return (groupNumber & 0xFFFF) << 0x10 | innerID;
	}

	// Token: 0x06001C71 RID: 7281 RVA: 0x000723CC File Offset: 0x000705CC
	internal static bool UnpackID(int packed, out ushort groupNumber, out ushort innerID)
	{
		if (packed == 0)
		{
			groupNumber = 0;
			innerID = 0;
			return false;
		}
		groupNumber = (ushort)(packed >> 0x10 & 0xFFFF);
		innerID = (ushort)(packed & 0xFFFF);
		return true;
	}

	// Token: 0x06001C72 RID: 7282 RVA: 0x00072400 File Offset: 0x00070600
	public static global::NGCView Find(int id)
	{
		ushort key;
		ushort key2;
		if (!global::NGC.UnpackID(id, out key, out key2))
		{
			return null;
		}
		global::NGC ngc;
		if (!global::NGC.Global.byGroup.TryGetValue(key, out ngc))
		{
			return null;
		}
		global::NGCView result;
		ngc.views.TryGetValue(key2, out result);
		return result;
	}

	// Token: 0x06001C73 RID: 7283 RVA: 0x00072444 File Offset: 0x00070644
	internal static bool InternalRemoveRPCs(global::NGCView view)
	{
		return view && view.innerID != 0 && view.outer && view.RemoveRPCs();
	}

	// Token: 0x06001C74 RID: 7284 RVA: 0x00072480 File Offset: 0x00070680
	internal static bool InternalRemoveRPCsByName(global::NGCView view, string rpcName)
	{
		return view && view.innerID != 0 && view.outer && view.RemoveRPCs(rpcName);
	}

	// Token: 0x06001C75 RID: 7285 RVA: 0x000724B4 File Offset: 0x000706B4
	internal static bool InternalRemoveRPCs(int entID)
	{
		return global::NGC.InternalRemoveRPCs(global::NGC.Find(entID));
	}

	// Token: 0x06001C76 RID: 7286 RVA: 0x000724C4 File Offset: 0x000706C4
	internal static bool InternalRemoveRPCsByName(int entID, string rpcName)
	{
		return global::NGC.InternalRemoveRPCsByName(global::NGC.Find(entID), rpcName);
	}

	// Token: 0x06001C77 RID: 7287 RVA: 0x000724D4 File Offset: 0x000706D4
	public static global::NGC.callf<P0>.Block BlockArgs<P0>(P0 p0)
	{
		global::NGC.callf<P0>.Block result;
		result.p0 = p0;
		return result;
	}

	// Token: 0x06001C78 RID: 7288 RVA: 0x000724EC File Offset: 0x000706EC
	public static global::NGC.callf<P0, P1>.Block BlockArgs<P0, P1>(P0 p0, P1 p1)
	{
		global::NGC.callf<P0, P1>.Block result;
		result.p0 = p0;
		result.p1 = p1;
		return result;
	}

	// Token: 0x06001C79 RID: 7289 RVA: 0x0007250C File Offset: 0x0007070C
	public static global::NGC.callf<P0, P1, P2>.Block BlockArgs<P0, P1, P2>(P0 p0, P1 p1, P2 p2)
	{
		global::NGC.callf<P0, P1, P2>.Block result;
		result.p0 = p0;
		result.p1 = p1;
		result.p2 = p2;
		return result;
	}

	// Token: 0x06001C7A RID: 7290 RVA: 0x00072534 File Offset: 0x00070734
	public static global::NGC.callf<P0, P1, P2, P3>.Block BlockArgs<P0, P1, P2, P3>(P0 p0, P1 p1, P2 p2, P3 p3)
	{
		global::NGC.callf<P0, P1, P2, P3>.Block result;
		result.p0 = p0;
		result.p1 = p1;
		result.p2 = p2;
		result.p3 = p3;
		return result;
	}

	// Token: 0x06001C7B RID: 7291 RVA: 0x00072564 File Offset: 0x00070764
	public static global::NGC.callf<P0, P1, P2, P3, P4>.Block BlockArgs<P0, P1, P2, P3, P4>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4)
	{
		global::NGC.callf<P0, P1, P2, P3, P4>.Block result;
		result.p0 = p0;
		result.p1 = p1;
		result.p2 = p2;
		result.p3 = p3;
		result.p4 = p4;
		return result;
	}

	// Token: 0x06001C7C RID: 7292 RVA: 0x0007259C File Offset: 0x0007079C
	public static global::NGC.callf<P0, P1, P2, P3, P4, P5>.Block BlockArgs<P0, P1, P2, P3, P4, P5>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
	{
		global::NGC.callf<P0, P1, P2, P3, P4, P5>.Block result;
		result.p0 = p0;
		result.p1 = p1;
		result.p2 = p2;
		result.p3 = p3;
		result.p4 = p4;
		result.p5 = p5;
		return result;
	}

	// Token: 0x06001C7D RID: 7293 RVA: 0x000725DC File Offset: 0x000707DC
	public static global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.Block BlockArgs<P0, P1, P2, P3, P4, P5, P6>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
	{
		global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.Block result;
		result.p0 = p0;
		result.p1 = p1;
		result.p2 = p2;
		result.p3 = p3;
		result.p4 = p4;
		result.p5 = p5;
		result.p6 = p6;
		return result;
	}

	// Token: 0x06001C7E RID: 7294 RVA: 0x00072628 File Offset: 0x00070828
	public static global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.Block BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
	{
		global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.Block result;
		result.p0 = p0;
		result.p1 = p1;
		result.p2 = p2;
		result.p3 = p3;
		result.p4 = p4;
		result.p5 = p5;
		result.p6 = p6;
		result.p7 = p7;
		return result;
	}

	// Token: 0x06001C7F RID: 7295 RVA: 0x0007267C File Offset: 0x0007087C
	public static global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.Block BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7, P8>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
	{
		global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.Block result;
		result.p0 = p0;
		result.p1 = p1;
		result.p2 = p2;
		result.p3 = p3;
		result.p4 = p4;
		result.p5 = p5;
		result.p6 = p6;
		result.p7 = p7;
		result.p8 = p8;
		return result;
	}

	// Token: 0x06001C80 RID: 7296 RVA: 0x000726D8 File Offset: 0x000708D8
	public static global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.Block BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
	{
		global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.Block result;
		result.p0 = p0;
		result.p1 = p1;
		result.p2 = p2;
		result.p3 = p3;
		result.p4 = p4;
		result.p5 = p5;
		result.p6 = p6;
		result.p7 = p7;
		result.p8 = p8;
		result.p9 = p9;
		return result;
	}

	// Token: 0x06001C81 RID: 7297 RVA: 0x0007273C File Offset: 0x0007093C
	public static global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.Block BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
	{
		global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.Block result;
		result.p0 = p0;
		result.p1 = p1;
		result.p2 = p2;
		result.p3 = p3;
		result.p4 = p4;
		result.p5 = p5;
		result.p6 = p6;
		result.p7 = p7;
		result.p8 = p8;
		result.p9 = p9;
		result.p10 = p10;
		return result;
	}

	// Token: 0x06001C82 RID: 7298 RVA: 0x000727AC File Offset: 0x000709AC
	public static global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.Block BlockArgs<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
	{
		global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.Block result;
		result.p0 = p0;
		result.p1 = p1;
		result.p2 = p2;
		result.p3 = p3;
		result.p4 = p4;
		result.p5 = p5;
		result.p6 = p6;
		result.p7 = p7;
		result.p8 = p8;
		result.p9 = p9;
		result.p10 = p10;
		result.p11 = p11;
		return result;
	}

	// Token: 0x06001C83 RID: 7299 RVA: 0x00072824 File Offset: 0x00070A24
	private static global::NGC.IExecuter FindExecuter(global::System.Type[] argumentTypes)
	{
		switch (argumentTypes.Length)
		{
		case 0:
			return typeof(global::NGC.callf).GetProperty("Exec", global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.Public).GetValue(null, null) as global::NGC.IExecuter;
		case 1:
			return typeof(global::NGC.callf<>).MakeGenericType(argumentTypes).GetProperty("Exec", global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.Public).GetValue(null, null) as global::NGC.IExecuter;
		case 2:
			return typeof(global::NGC.callf<, >).MakeGenericType(argumentTypes).GetProperty("Exec", global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.Public).GetValue(null, null) as global::NGC.IExecuter;
		case 3:
			return typeof(global::NGC.callf<, , >).MakeGenericType(argumentTypes).GetProperty("Exec", global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.Public).GetValue(null, null) as global::NGC.IExecuter;
		case 4:
			return typeof(global::NGC.callf<, , , >).MakeGenericType(argumentTypes).GetProperty("Exec", global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.Public).GetValue(null, null) as global::NGC.IExecuter;
		case 5:
			return typeof(global::NGC.callf<, , , , >).MakeGenericType(argumentTypes).GetProperty("Exec", global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.Public).GetValue(null, null) as global::NGC.IExecuter;
		case 6:
			return typeof(global::NGC.callf<, , , , , >).MakeGenericType(argumentTypes).GetProperty("Exec", global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.Public).GetValue(null, null) as global::NGC.IExecuter;
		case 7:
			return typeof(global::NGC.callf<, , , , , , >).MakeGenericType(argumentTypes).GetProperty("Exec", global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.Public).GetValue(null, null) as global::NGC.IExecuter;
		case 8:
			return typeof(global::NGC.callf<, , , , , , , >).MakeGenericType(argumentTypes).GetProperty("Exec", global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.Public).GetValue(null, null) as global::NGC.IExecuter;
		case 9:
			return typeof(global::NGC.callf<, , , , , , , , >).MakeGenericType(argumentTypes).GetProperty("Exec", global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.Public).GetValue(null, null) as global::NGC.IExecuter;
		case 0xA:
			return typeof(global::NGC.callf<, , , , , , , , , >).MakeGenericType(argumentTypes).GetProperty("Exec", global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.Public).GetValue(null, null) as global::NGC.IExecuter;
		case 0xB:
			return typeof(global::NGC.callf<, , , , , , , , , , >).MakeGenericType(argumentTypes).GetProperty("Exec", global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.Public).GetValue(null, null) as global::NGC.IExecuter;
		case 0xC:
			return typeof(global::NGC.callf<, , , , , , , , , , , >).MakeGenericType(argumentTypes).GetProperty("Exec", global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.Public).GetValue(null, null) as global::NGC.IExecuter;
		default:
			throw new global::System.ArgumentOutOfRangeException("argumentTypes.Length > {0}");
		}
	}

	// Token: 0x0400108F RID: 4239
	private const string kAddRPC = "A";

	// Token: 0x04001090 RID: 4240
	private const string kDeleteRPC = "D";

	// Token: 0x04001091 RID: 4241
	private const string kCallRPC = "C";

	// Token: 0x04001092 RID: 4242
	private const string kPrefabIdentifier = "!Ng";

	// Token: 0x04001093 RID: 4243
	public const int AddHeaderBaseSize = 0x1E;

	// Token: 0x04001094 RID: 4244
	[global::System.NonSerialized]
	private bool added;

	// Token: 0x04001095 RID: 4245
	[global::System.NonSerialized]
	internal ushort groupNumber;

	// Token: 0x04001096 RID: 4246
	[global::System.NonSerialized]
	private global::uLink.NetworkMessageInfo creation;

	// Token: 0x04001097 RID: 4247
	[global::System.NonSerialized]
	internal global::NGCInternalView networkView;

	// Token: 0x04001098 RID: 4248
	[global::System.NonSerialized]
	internal global::uLink.NetworkViewID networkViewID;

	// Token: 0x04001099 RID: 4249
	[global::System.NonSerialized]
	private global::System.Collections.Generic.Stack<global::NGCView> serverInstantiatedStack = new global::System.Collections.Generic.Stack<global::NGCView>();

	// Token: 0x0400109A RID: 4250
	[global::System.NonSerialized]
	private global::NGC.UIDMapper uidmapper;

	// Token: 0x0400109B RID: 4251
	[global::System.NonSerialized]
	private readonly global::System.Collections.Generic.Dictionary<ushort, global::NGCView> views = new global::System.Collections.Generic.Dictionary<ushort, global::NGCView>();

	// Token: 0x0400109C RID: 4252
	private static bool log_nonexistant_ngc_errors;

	// Token: 0x0400109D RID: 4253
	[global::System.NonSerialized]
	private string currentAddRPCName;

	// Token: 0x0200034D RID: 845
	private static class Global
	{
		// Token: 0x06001C84 RID: 7300 RVA: 0x00072A90 File Offset: 0x00070C90
		// Note: this type is marked as 'beforefieldinit'.
		static Global()
		{
		}

		// Token: 0x0400109E RID: 4254
		public static readonly global::System.Collections.Generic.Dictionary<ushort, global::NGC> byGroup = new global::System.Collections.Generic.Dictionary<ushort, global::NGC>();

		// Token: 0x0400109F RID: 4255
		public static readonly global::System.Collections.Generic.List<global::NGC> all = new global::System.Collections.Generic.List<global::NGC>();
	}

	// Token: 0x0200034E RID: 846
	public interface IExecuter
	{
		// Token: 0x06001C85 RID: 7301
		void ExecuteCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance);

		// Token: 0x06001C86 RID: 7302
		global::System.Collections.IEnumerator ExecuteRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance);

		// Token: 0x06001C87 RID: 7303
		void ExecuteInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info);

		// Token: 0x06001C88 RID: 7304
		global::System.Collections.IEnumerator ExecuteInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info);

		// Token: 0x06001C89 RID: 7305
		void ExecuteStreamCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance);

		// Token: 0x06001C8A RID: 7306
		global::System.Collections.IEnumerator ExecuteStreamRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance);

		// Token: 0x06001C8B RID: 7307
		void ExecuteStreamInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info);

		// Token: 0x06001C8C RID: 7308
		global::System.Collections.IEnumerator ExecuteStreamInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info);
	}

	// Token: 0x0200034F RID: 847
	public sealed class Prefab
	{
		// Token: 0x06001C8D RID: 7309 RVA: 0x00072AA8 File Offset: 0x00070CA8
		private Prefab(string contentPath, int key, string handle)
		{
			this.contentPath = contentPath;
			this.key = key;
			this.handle = handle;
		}

		// Token: 0x06001C8E RID: 7310 RVA: 0x00072AC8 File Offset: 0x00070CC8
		public int MessageIndex(string message)
		{
			int result;
			if (this.cachedMessageIndices != null && this.cachedMessageIndices.TryGetValue(message, out result))
			{
				return result;
			}
			int num = this.MessageIndexFind(message);
			if (num == -1)
			{
				throw new global::System.ArgumentException(message, "message");
			}
			if (this.cachedMessageIndices == null)
			{
				this.cachedMessageIndices = new global::System.Collections.Generic.Dictionary<string, int>();
			}
			this.cachedMessageIndices[message] = num;
			return num;
		}

		// Token: 0x06001C8F RID: 7311 RVA: 0x00072B34 File Offset: 0x00070D34
		private int MessageIndexFind(string message)
		{
			int num = message.LastIndexOf(':');
			if (num == -1)
			{
				for (int i = 0; i < this._installation.methods.Length; i++)
				{
					if (this._installation.methods[i].method.Name == message)
					{
						return i;
					}
				}
			}
			else
			{
				for (int j = 0; j < this._installation.methods.Length; j++)
				{
					if (string.Compare(this._installation.methods[j].method.Name, 0, message, num + 1, message.Length - (num + 1)) == 0 && string.Compare(this._installation.methods[j].method.DeclaringType.FullName, 0, message, 0, num) == 0)
					{
						return j;
					}
				}
			}
			return -1;
		}

		// Token: 0x170007C6 RID: 1990
		// (get) Token: 0x06001C90 RID: 7312 RVA: 0x00072C20 File Offset: 0x00070E20
		public global::NGC.Prefab.Installation installation
		{
			get
			{
				if (this._installation == null && !this.prefab)
				{
					throw new global::System.InvalidOperationException("Could not get installation because prefab could not load");
				}
				return this._installation;
			}
		}

		// Token: 0x170007C7 RID: 1991
		// (get) Token: 0x06001C91 RID: 7313 RVA: 0x00072C5C File Offset: 0x00070E5C
		public global::NGCView prefab
		{
			get
			{
				global::NGCView ngcview;
				if (this.weakReference == null || !(ngcview = (global::NGCView)this.weakReference.Target) || !this.weakReference.IsAlive)
				{
					if (!global::Facepunch.Bundling.Load<global::NGCView>(this.contentPath, typeof(global::NGCView), out ngcview))
					{
						throw new global::UnityEngine.MissingReferenceException("Could not load NGCView at " + this.contentPath);
					}
					if (this._installation == null)
					{
						this._installation = global::NGC.Prefab.Installation.Create(ngcview);
					}
					this.weakReference = new global::System.WeakReference(ngcview);
				}
				return ngcview;
			}
		}

		// Token: 0x06001C92 RID: 7314 RVA: 0x00072CF8 File Offset: 0x00070EF8
		internal global::uLink.NetworkFlags DefaultNetworkFlags(int messageIndex)
		{
			return this.installation.methods[messageIndex].defaultNetworkFlags;
		}

		// Token: 0x040010A0 RID: 4256
		[global::System.NonSerialized]
		public readonly string contentPath;

		// Token: 0x040010A1 RID: 4257
		[global::System.NonSerialized]
		public readonly int key;

		// Token: 0x040010A2 RID: 4258
		[global::System.NonSerialized]
		public readonly string handle;

		// Token: 0x040010A3 RID: 4259
		[global::System.NonSerialized]
		private global::NGC.Prefab.Installation _installation;

		// Token: 0x040010A4 RID: 4260
		private global::System.Collections.Generic.Dictionary<string, int> cachedMessageIndices;

		// Token: 0x040010A5 RID: 4261
		private global::System.WeakReference weakReference;

		// Token: 0x02000350 RID: 848
		public sealed class Installation
		{
			// Token: 0x06001C93 RID: 7315 RVA: 0x00072D10 File Offset: 0x00070F10
			private Installation(global::NGC.Prefab.Installation.Method[] methods, ushort[] methodScriptIndices)
			{
				this.methods = methods;
				this.methodScriptIndices = methodScriptIndices;
			}

			// Token: 0x06001C94 RID: 7316 RVA: 0x00072D28 File Offset: 0x00070F28
			// Note: this type is marked as 'beforefieldinit'.
			static Installation()
			{
			}

			// Token: 0x06001C95 RID: 7317 RVA: 0x00072D34 File Offset: 0x00070F34
			public static global::NGC.Prefab.Installation Create(global::NGCView view)
			{
				int num = 0;
				global::System.Collections.Generic.List<global::NGC.Prefab.Installation.Method[]> list = new global::System.Collections.Generic.List<global::NGC.Prefab.Installation.Method[]>();
				foreach (global::UnityEngine.MonoBehaviour monoBehaviour in view.scripts)
				{
					global::System.Type type = monoBehaviour.GetType();
					global::NGC.Prefab.Installation.Method[] array;
					if (!global::NGC.Prefab.Installation.methodsForType.TryGetValue(type, out array))
					{
						global::System.Collections.Generic.List<global::NGC.Prefab.Installation.Method> list2 = new global::System.Collections.Generic.List<global::NGC.Prefab.Installation.Method>();
						global::System.Reflection.MethodInfo[] array2 = type.GetMethods(global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic);
						foreach (global::System.Reflection.MethodInfo methodInfo in array2)
						{
							bool flag = false;
							if (methodInfo.IsDefined(typeof(global::UnityEngine.RPC), true))
							{
								if (!methodInfo.IsDefined(typeof(global::NGCRPCSkipAttribute), false) || methodInfo.IsDefined(typeof(global::NGCRPCAttribute), true))
								{
									flag = true;
								}
							}
							else if (methodInfo.IsDefined(typeof(global::NGCRPCAttribute), true))
							{
								flag = true;
							}
							if (flag)
							{
								list2.Add(global::NGC.Prefab.Installation.Method.Create(methodInfo));
							}
						}
						list2.Sort((global::NGC.Prefab.Installation.Method x, global::NGC.Prefab.Installation.Method y) => x.method.Name.CompareTo(y.method.Name));
						array = list2.ToArray();
						global::NGC.Prefab.Installation.methodsForType[type] = array;
					}
					num += array.Length;
					list.Add(array);
				}
				global::NGC.Prefab.Installation.Method[] array4 = new global::NGC.Prefab.Installation.Method[num];
				ushort[] array5 = new ushort[num];
				int num2 = 0;
				ushort num3 = 0;
				foreach (global::NGC.Prefab.Installation.Method[] array6 in list)
				{
					foreach (global::NGC.Prefab.Installation.Method method in array6)
					{
						array4[num2] = method;
						array5[num2] = num3;
						num2++;
					}
					num3 += 1;
				}
				return new global::NGC.Prefab.Installation(array4, array5);
			}

			// Token: 0x06001C96 RID: 7318 RVA: 0x00072F48 File Offset: 0x00071148
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private static int <Create>m__14(global::NGC.Prefab.Installation.Method x, global::NGC.Prefab.Installation.Method y)
			{
				return x.method.Name.CompareTo(y.method.Name);
			}

			// Token: 0x040010A6 RID: 4262
			public readonly global::NGC.Prefab.Installation.Method[] methods;

			// Token: 0x040010A7 RID: 4263
			public readonly ushort[] methodScriptIndices;

			// Token: 0x040010A8 RID: 4264
			private static readonly global::System.Collections.Generic.Dictionary<global::System.Type, global::NGC.Prefab.Installation.Method[]> methodsForType = new global::System.Collections.Generic.Dictionary<global::System.Type, global::NGC.Prefab.Installation.Method[]>();

			// Token: 0x040010A9 RID: 4265
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private static global::System.Comparison<global::NGC.Prefab.Installation.Method> <>f__am$cache3;

			// Token: 0x02000351 RID: 849
			public sealed class Instance
			{
				// Token: 0x06001C97 RID: 7319 RVA: 0x00072F68 File Offset: 0x00071168
				public Instance(global::NGC.Prefab.Installation installation)
				{
					this.delegates = new global::System.Delegate[installation.methods.Length];
				}

				// Token: 0x06001C98 RID: 7320 RVA: 0x00072F84 File Offset: 0x00071184
				public void Invoke(global::NGC.Procedure procedure)
				{
					procedure.view.prefab.installation.methods[procedure.message].Invoke(ref this.delegates[procedure.message], procedure, procedure.view.prefab.installation.methodScriptIndices[procedure.message]);
				}

				// Token: 0x040010AA RID: 4266
				public readonly global::System.Delegate[] delegates;
			}

			// Token: 0x02000352 RID: 850
			public struct Method
			{
				// Token: 0x06001C99 RID: 7321 RVA: 0x00072FE4 File Offset: 0x000711E4
				private Method(global::System.Reflection.MethodInfo method, byte flags, global::NGC.IExecuter executer)
				{
					this.method = method;
					this.flags = flags;
					this.executer = executer;
				}

				// Token: 0x170007C8 RID: 1992
				// (get) Token: 0x06001C9A RID: 7322 RVA: 0x00072FFC File Offset: 0x000711FC
				public global::uLink.NetworkFlags defaultNetworkFlags
				{
					get
					{
						global::uLink.NetworkFlags networkFlags = 0;
						if ((this.flags & 0x21) != 1)
						{
							networkFlags |= 8;
						}
						if ((this.flags & 0x80) == 0x80)
						{
							networkFlags |= 0x10;
						}
						if ((this.flags & 0x40) == 0x10)
						{
							networkFlags |= 3;
						}
						else if ((this.flags & 8) == 8)
						{
							networkFlags |= 2;
						}
						if ((this.flags & 0x10) == 0x10)
						{
							networkFlags |= 4;
						}
						return networkFlags;
					}
				}

				// Token: 0x06001C9B RID: 7323 RVA: 0x00073080 File Offset: 0x00071280
				public void Invoke(ref global::System.Delegate d, global::NGC.Procedure procedure, ushort scriptIndex)
				{
					global::UnityEngine.MonoBehaviour monoBehaviour = procedure.view.scripts[(int)scriptIndex];
					global::System.Collections.IEnumerator enumerator;
					switch (this.flags & 7)
					{
					case 0:
						this.executer.ExecuteCall(procedure.CreateBitStream(), ref d, this.method, monoBehaviour);
						return;
					case 1:
						this.executer.ExecuteInfoCall(procedure.CreateBitStream(), ref d, this.method, monoBehaviour, procedure.info);
						return;
					case 2:
						this.executer.ExecuteStreamCall(procedure.CreateBitStream(), ref d, this.method, monoBehaviour);
						return;
					case 3:
						this.executer.ExecuteStreamInfoCall(procedure.CreateBitStream(), ref d, this.method, monoBehaviour, procedure.info);
						return;
					case 4:
						enumerator = this.executer.ExecuteRoutine(procedure.CreateBitStream(), ref d, this.method, monoBehaviour);
						break;
					case 5:
						enumerator = this.executer.ExecuteInfoRoutine(procedure.CreateBitStream(), ref d, this.method, monoBehaviour, procedure.info);
						break;
					case 6:
						enumerator = this.executer.ExecuteStreamRoutine(procedure.CreateBitStream(), ref d, this.method, monoBehaviour);
						break;
					case 7:
						enumerator = this.executer.ExecuteStreamInfoRoutine(procedure.CreateBitStream(), ref d, this.method, monoBehaviour, procedure.info);
						break;
					default:
						throw new global::System.NotImplementedException(((int)(this.flags & 7)).ToString());
					}
					if (enumerator == null)
					{
						return;
					}
					try
					{
						monoBehaviour.StartCoroutine(enumerator);
					}
					catch (global::System.Exception ex)
					{
						global::UnityEngine.Debug.LogException(ex, monoBehaviour);
					}
				}

				// Token: 0x06001C9C RID: 7324 RVA: 0x00073220 File Offset: 0x00071420
				public static global::NGC.Prefab.Installation.Method Create(global::System.Reflection.MethodInfo info)
				{
					global::System.Type returnType = info.ReturnType;
					byte b;
					if (returnType == typeof(void))
					{
						b = 0;
					}
					else
					{
						if (returnType != typeof(global::System.Collections.IEnumerator))
						{
							throw new global::System.InvalidOperationException(string.Format("RPC {0} returns a unhandled type: {1}", info, returnType));
						}
						b = 4;
					}
					global::System.Reflection.ParameterInfo[] parameters = info.GetParameters();
					for (int i = 0; i < parameters.Length; i++)
					{
						if (parameters[i].IsOut || parameters[i].IsIn)
						{
							throw new global::System.InvalidOperationException(string.Format("RPC method {0} has a illegal parameter {1}", info, parameters[i]));
						}
					}
					int num = parameters.Length;
					if (num > 0)
					{
						global::System.Type parameterType;
						if ((parameterType = parameters[parameters.Length - 1].ParameterType) == typeof(global::uLink.NetworkMessageInfo))
						{
							num--;
							if (num > 0 && parameters[num - 1].ParameterType == typeof(global::uLink.BitStream))
							{
								num--;
								b |= 3;
							}
							else
							{
								b |= 1;
							}
						}
						else if (parameterType == typeof(global::uLink.BitStream))
						{
							num--;
							b |= 2;
						}
					}
					global::System.Type[] array = new global::System.Type[num];
					for (int j = 0; j < num; j++)
					{
						array[j] = parameters[j].ParameterType;
					}
					global::NGC.IExecuter executer = global::NGC.FindExecuter(array);
					if (executer != null)
					{
						return new global::NGC.Prefab.Installation.Method(info, b, executer);
					}
					throw new global::System.InvalidProgramException();
				}

				// Token: 0x040010AB RID: 4267
				private const byte FLAG_INFO = 1;

				// Token: 0x040010AC RID: 4268
				private const byte FLAG_STREAM = 2;

				// Token: 0x040010AD RID: 4269
				private const byte FLAG_ENUMERATOR = 4;

				// Token: 0x040010AE RID: 4270
				private const byte FLAG_FORCE_UNBUFFERED = 8;

				// Token: 0x040010AF RID: 4271
				private const byte FLAG_FORCE_INSECURE = 0x10;

				// Token: 0x040010B0 RID: 4272
				private const byte FLAG_FORCE_NO_TIMESTAMP = 0x20;

				// Token: 0x040010B1 RID: 4273
				private const byte FLAG_FORCE_UNRELIABLE = 0x40;

				// Token: 0x040010B2 RID: 4274
				private const byte FLAG_FORCE_TYPE_UNSAFE = 0x80;

				// Token: 0x040010B3 RID: 4275
				private const byte INVOKE_FLAGS = 7;

				// Token: 0x040010B4 RID: 4276
				public readonly global::System.Reflection.MethodInfo method;

				// Token: 0x040010B5 RID: 4277
				public readonly byte flags;

				// Token: 0x040010B6 RID: 4278
				private readonly global::NGC.IExecuter executer;
			}
		}

		// Token: 0x02000353 RID: 851
		public static class Register
		{
			// Token: 0x06001C9D RID: 7325 RVA: 0x00073398 File Offset: 0x00071598
			// Note: this type is marked as 'beforefieldinit'.
			static Register()
			{
			}

			// Token: 0x06001C9E RID: 7326 RVA: 0x000733B8 File Offset: 0x000715B8
			public static bool Find(int index, out global::NGC.Prefab prefab)
			{
				return global::NGC.Prefab.Register.PrefabByIndex.TryGetValue(index, out prefab);
			}

			// Token: 0x06001C9F RID: 7327 RVA: 0x000733C8 File Offset: 0x000715C8
			public static string FindName(int iIndex)
			{
				return global::NGC.Prefab.Register.PrefabByIndex[iIndex].handle;
			}

			// Token: 0x06001CA0 RID: 7328 RVA: 0x000733DC File Offset: 0x000715DC
			public static bool Find(string handle, out global::NGC.Prefab prefab)
			{
				return global::NGC.Prefab.Register.PrefabByName.TryGetValue(handle, out prefab);
			}

			// Token: 0x06001CA1 RID: 7329 RVA: 0x000733EC File Offset: 0x000715EC
			public static bool Add(string contentPath, int index, string handle)
			{
				bool result;
				try
				{
					global::NGC.Prefab prefab = new global::NGC.Prefab(contentPath, index, handle);
					global::NGC.Prefab.Register.PrefabByIndex.Add(index, prefab);
					try
					{
						global::NGC.Prefab.Register.PrefabByName.Add(handle, prefab);
					}
					catch
					{
						global::NGC.Prefab.Register.PrefabByIndex.Remove(index);
						throw;
					}
					global::NGC.Prefab.Register.Prefabs.Add(prefab);
					result = true;
				}
				catch
				{
					result = false;
				}
				return result;
			}

			// Token: 0x040010B7 RID: 4279
			private static readonly global::System.Collections.Generic.Dictionary<int, global::NGC.Prefab> PrefabByIndex = new global::System.Collections.Generic.Dictionary<int, global::NGC.Prefab>();

			// Token: 0x040010B8 RID: 4280
			private static readonly global::System.Collections.Generic.Dictionary<string, global::NGC.Prefab> PrefabByName = new global::System.Collections.Generic.Dictionary<string, global::NGC.Prefab>();

			// Token: 0x040010B9 RID: 4281
			private static readonly global::System.Collections.Generic.List<global::NGC.Prefab> Prefabs = new global::System.Collections.Generic.List<global::NGC.Prefab>();
		}
	}

	// Token: 0x02000354 RID: 852
	public sealed class Procedure
	{
		// Token: 0x06001CA2 RID: 7330 RVA: 0x0007348C File Offset: 0x0007168C
		public Procedure()
		{
		}

		// Token: 0x06001CA3 RID: 7331 RVA: 0x00073494 File Offset: 0x00071694
		public global::uLink.BitStream CreateBitStream()
		{
			if (this.dataLength == 0)
			{
				return new global::uLink.BitStream(false);
			}
			return new global::uLink.BitStream(this.data, false);
		}

		// Token: 0x06001CA4 RID: 7332 RVA: 0x000734B4 File Offset: 0x000716B4
		public bool Call()
		{
			if (!this.view)
			{
				try
				{
					this.view = this.outer.views[(ushort)this.target];
				}
				catch (global::System.Collections.Generic.KeyNotFoundException)
				{
					return false;
				}
			}
			try
			{
				this.view.install.Invoke(this);
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex, this.view);
			}
			return true;
		}

		// Token: 0x040010BA RID: 4282
		public global::NGC outer;

		// Token: 0x040010BB RID: 4283
		public int target;

		// Token: 0x040010BC RID: 4284
		public int message;

		// Token: 0x040010BD RID: 4285
		public byte[] data;

		// Token: 0x040010BE RID: 4286
		public int dataLength;

		// Token: 0x040010BF RID: 4287
		public global::uLink.NetworkMessageInfo info;

		// Token: 0x040010C0 RID: 4288
		public global::NGCView view;
	}

	// Token: 0x02000355 RID: 853
	public class UIDMapper
	{
		// Token: 0x06001CA5 RID: 7333 RVA: 0x00073560 File Offset: 0x00071760
		public UIDMapper()
		{
		}

		// Token: 0x06001CA6 RID: 7334 RVA: 0x00073580 File Offset: 0x00071780
		public bool Alloc(out ushort id)
		{
			if (this.num == 0xFFFD)
			{
				id = 0;
				return false;
			}
			for (int i = 0; i < 0xFFFD; i++)
			{
				int num = this.nextIDBin;
				int num2 = this.nextIDBit;
				int num3 = this.nextIDBin * 0x20 + num2;
				if (num3 == 0xFFFE)
				{
					this.nextIDBit = 2;
					this.nextIDBin = 0;
				}
				else if (++this.nextIDBit == 0x20)
				{
					if (++this.nextIDBin == 0x800)
					{
						this.nextIDBit = 2;
						this.nextIDBin = 0;
					}
					else
					{
						this.nextIDBit = 0;
					}
				}
				int num4 = 1 << num2;
				if ((this.used[num] & num4) != num4)
				{
					this.used[num] |= num4;
					this.num++;
					id = (ushort)num3;
					return true;
				}
			}
			id = 0;
			return false;
		}

		// Token: 0x06001CA7 RID: 7335 RVA: 0x0007368C File Offset: 0x0007188C
		public bool Contains(int id)
		{
			int num;
			return id >= 2 && id <= 0xFFFE && (this.used[id / 0x20] & (num = 1 << id % 0x20)) == num;
		}

		// Token: 0x06001CA8 RID: 7336 RVA: 0x000736C8 File Offset: 0x000718C8
		public bool Free(int id)
		{
			if (id < 2 || id > 0xFFFE)
			{
				return false;
			}
			int num = id / 0x20;
			int num2 = 1 << id % 0x20;
			if ((this.used[num] & num2) == num2)
			{
				this.used[num] &= ~num2;
				this.num--;
				return true;
			}
			return false;
		}

		// Token: 0x040010C1 RID: 4289
		private const int minID = 2;

		// Token: 0x040010C2 RID: 4290
		private const int maxID = 0xFFFE;

		// Token: 0x040010C3 RID: 4291
		private const int binCount = 0x800;

		// Token: 0x040010C4 RID: 4292
		private const int maxIDCount = 0xFFFD;

		// Token: 0x040010C5 RID: 4293
		private readonly int[] used = new int[0x800];

		// Token: 0x040010C6 RID: 4294
		private int nextIDBin;

		// Token: 0x040010C7 RID: 4295
		private int nextIDBit = 2;

		// Token: 0x040010C8 RID: 4296
		private int num;
	}

	// Token: 0x02000356 RID: 854
	private struct RPCName
	{
		// Token: 0x06001CA9 RID: 7337 RVA: 0x0007372C File Offset: 0x0007192C
		public RPCName(global::NGCView view, int message, string name, global::uLink.NetworkFlags flags)
		{
			this.name = name;
			this.flags = flags;
			this.view = view;
			this.message = message;
			this.valid = true;
			this.mapBuffered = false;
		}

		// Token: 0x06001CAA RID: 7338 RVA: 0x0007375C File Offset: 0x0007195C
		public RPCName(global::NGCView view, int message, string name, global::uLink.NetworkFlags flags, bool mapBuffered)
		{
			this = new global::NGC.RPCName(view, message, name, flags);
			this.mapBuffered = mapBuffered;
		}

		// Token: 0x040010C9 RID: 4297
		public readonly global::NGCView view;

		// Token: 0x040010CA RID: 4298
		public readonly string name;

		// Token: 0x040010CB RID: 4299
		public readonly global::uLink.NetworkFlags flags;

		// Token: 0x040010CC RID: 4300
		public readonly int message;

		// Token: 0x040010CD RID: 4301
		public readonly bool valid;

		// Token: 0x040010CE RID: 4302
		public readonly bool mapBuffered;
	}

	// Token: 0x02000357 RID: 855
	public static class callf
	{
		// Token: 0x06001CAB RID: 7339 RVA: 0x00073774 File Offset: 0x00071974
		public static void InvokeCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf.Call), instance, method, true);
			}
			((global::NGC.callf.Call)d)();
		}

		// Token: 0x06001CAC RID: 7340 RVA: 0x000737A0 File Offset: 0x000719A0
		public static global::System.Collections.IEnumerator InvokeRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf.Routine), instance, method, true);
			}
			return ((global::NGC.callf.Routine)d)();
		}

		// Token: 0x06001CAD RID: 7341 RVA: 0x000737CC File Offset: 0x000719CC
		public static void InvokeInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf.InfoCall), instance, method, true);
			}
			((global::NGC.callf.InfoCall)d)(info);
		}

		// Token: 0x06001CAE RID: 7342 RVA: 0x000737F8 File Offset: 0x000719F8
		public static global::System.Collections.IEnumerator InvokeInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf.InfoRoutine), instance, method, true);
			}
			return ((global::NGC.callf.InfoRoutine)d)(info);
		}

		// Token: 0x06001CAF RID: 7343 RVA: 0x00073824 File Offset: 0x00071A24
		public static void InvokeStreamCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf.StreamCall), instance, method, true);
			}
			((global::NGC.callf.StreamCall)d)(stream);
		}

		// Token: 0x06001CB0 RID: 7344 RVA: 0x0007385C File Offset: 0x00071A5C
		public static global::System.Collections.IEnumerator InvokeStreamRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf.StreamRoutine), instance, method, true);
			}
			return ((global::NGC.callf.StreamRoutine)d)(stream);
		}

		// Token: 0x06001CB1 RID: 7345 RVA: 0x00073894 File Offset: 0x00071A94
		public static void InvokeStreamInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf.StreamInfoCall), instance, method, true);
			}
			((global::NGC.callf.StreamInfoCall)d)(info, stream);
		}

		// Token: 0x06001CB2 RID: 7346 RVA: 0x000738CC File Offset: 0x00071ACC
		public static global::System.Collections.IEnumerator InvokeStreamInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf.StreamInfoRoutine), instance, method, true);
			}
			return ((global::NGC.callf.StreamInfoRoutine)d)(info, stream);
		}

		// Token: 0x170007C9 RID: 1993
		// (get) Token: 0x06001CB3 RID: 7347 RVA: 0x00073904 File Offset: 0x00071B04
		public static global::NGC.IExecuter Exec
		{
			get
			{
				return global::NGC.callf.Executer.Singleton;
			}
		}

		// Token: 0x02000358 RID: 856
		private sealed class Executer : global::NGC.IExecuter
		{
			// Token: 0x06001CB4 RID: 7348 RVA: 0x0007390C File Offset: 0x00071B0C
			public Executer()
			{
			}

			// Token: 0x06001CB5 RID: 7349 RVA: 0x00073914 File Offset: 0x00071B14
			// Note: this type is marked as 'beforefieldinit'.
			static Executer()
			{
			}

			// Token: 0x06001CB6 RID: 7350 RVA: 0x00073920 File Offset: 0x00071B20
			public void ExecuteCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				global::NGC.callf.InvokeCall(stream, ref d, method, instance);
			}

			// Token: 0x06001CB7 RID: 7351 RVA: 0x0007392C File Offset: 0x00071B2C
			public global::System.Collections.IEnumerator ExecuteRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				return global::NGC.callf.InvokeRoutine(stream, ref d, method, instance);
			}

			// Token: 0x06001CB8 RID: 7352 RVA: 0x00073938 File Offset: 0x00071B38
			public void ExecuteInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				global::NGC.callf.InvokeInfoCall(stream, ref d, method, instance, info);
			}

			// Token: 0x06001CB9 RID: 7353 RVA: 0x00073948 File Offset: 0x00071B48
			public global::System.Collections.IEnumerator ExecuteInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				return global::NGC.callf.InvokeInfoRoutine(stream, ref d, method, instance, info);
			}

			// Token: 0x06001CBA RID: 7354 RVA: 0x00073958 File Offset: 0x00071B58
			public void ExecuteStreamCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				global::NGC.callf.InvokeStreamCall(stream, ref d, method, instance);
			}

			// Token: 0x06001CBB RID: 7355 RVA: 0x00073964 File Offset: 0x00071B64
			public global::System.Collections.IEnumerator ExecuteStreamRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				return global::NGC.callf.InvokeStreamRoutine(stream, ref d, method, instance);
			}

			// Token: 0x06001CBC RID: 7356 RVA: 0x00073970 File Offset: 0x00071B70
			public void ExecuteStreamInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				global::NGC.callf.InvokeStreamInfoCall(stream, ref d, method, instance, info);
			}

			// Token: 0x06001CBD RID: 7357 RVA: 0x00073980 File Offset: 0x00071B80
			public global::System.Collections.IEnumerator ExecuteStreamInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				return global::NGC.callf.InvokeStreamInfoRoutine(stream, ref d, method, instance, info);
			}

			// Token: 0x040010CF RID: 4303
			public static readonly global::NGC.IExecuter Singleton = new global::NGC.callf.Executer();
		}

		// Token: 0x02000359 RID: 857
		// (Invoke) Token: 0x06001CBF RID: 7359
		public delegate void Call();

		// Token: 0x0200035A RID: 858
		// (Invoke) Token: 0x06001CC3 RID: 7363
		public delegate global::System.Collections.IEnumerator Routine();

		// Token: 0x0200035B RID: 859
		// (Invoke) Token: 0x06001CC7 RID: 7367
		public delegate void InfoCall(global::uLink.NetworkMessageInfo info);

		// Token: 0x0200035C RID: 860
		// (Invoke) Token: 0x06001CCB RID: 7371
		public delegate global::System.Collections.IEnumerator InfoRoutine(global::uLink.NetworkMessageInfo info);

		// Token: 0x0200035D RID: 861
		// (Invoke) Token: 0x06001CCF RID: 7375
		public delegate void StreamCall(global::uLink.BitStream stream);

		// Token: 0x0200035E RID: 862
		// (Invoke) Token: 0x06001CD3 RID: 7379
		public delegate global::System.Collections.IEnumerator StreamRoutine(global::uLink.BitStream stream);

		// Token: 0x0200035F RID: 863
		// (Invoke) Token: 0x06001CD7 RID: 7383
		public delegate void StreamInfoCall(global::uLink.NetworkMessageInfo info, global::uLink.BitStream stream);

		// Token: 0x02000360 RID: 864
		// (Invoke) Token: 0x06001CDB RID: 7387
		public delegate global::System.Collections.IEnumerator StreamInfoRoutine(global::uLink.NetworkMessageInfo info, global::uLink.BitStream stream);
	}

	// Token: 0x02000361 RID: 865
	public static class callf<P0>
	{
		// Token: 0x06001CDE RID: 7390 RVA: 0x00073990 File Offset: 0x00071B90
		static callf()
		{
			global::uLink.BitStreamCodec.Add<global::NGC.callf<P0>.Block>(new global::uLink.BitStreamCodec.Deserializer(global::NGC.callf<P0>.Deserializer), new global::uLink.BitStreamCodec.Serializer(global::NGC.callf<P0>.Serializer));
		}

		// Token: 0x06001CDF RID: 7391 RVA: 0x000739B0 File Offset: 0x00071BB0
		private static object Deserializer(global::uLink.BitStream stream, params object[] codecOptions)
		{
			global::NGC.callf<P0>.Block block;
			block.p0 = stream.Read<P0>(codecOptions);
			return block;
		}

		// Token: 0x06001CE0 RID: 7392 RVA: 0x000739D4 File Offset: 0x00071BD4
		private static void Serializer(global::uLink.BitStream stream, object value, params object[] codecOptions)
		{
			stream.Write<P0>(((global::NGC.callf<P0>.Block)value).p0, codecOptions);
		}

		// Token: 0x06001CE1 RID: 7393 RVA: 0x000739F8 File Offset: 0x00071BF8
		public static void InvokeCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0>.Call), instance, method, true);
			}
			((global::NGC.callf<P0>.Call)d)(p);
		}

		// Token: 0x06001CE2 RID: 7394 RVA: 0x00073A3C File Offset: 0x00071C3C
		public static global::System.Collections.IEnumerator InvokeRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0>.Routine), instance, method, true);
			}
			return ((global::NGC.callf<P0>.Routine)d)(p);
		}

		// Token: 0x06001CE3 RID: 7395 RVA: 0x00073A80 File Offset: 0x00071C80
		public static void InvokeInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0>.InfoCall), instance, method, true);
			}
			((global::NGC.callf<P0>.InfoCall)d)(p, info);
		}

		// Token: 0x06001CE4 RID: 7396 RVA: 0x00073AC4 File Offset: 0x00071CC4
		public static global::System.Collections.IEnumerator InvokeInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0>.InfoRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0>.InfoRoutine)d)(p, info);
		}

		// Token: 0x06001CE5 RID: 7397 RVA: 0x00073B08 File Offset: 0x00071D08
		public static void InvokeStreamCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0>.StreamCall), instance, method, true);
			}
			((global::NGC.callf<P0>.StreamCall)d)(p, stream);
		}

		// Token: 0x06001CE6 RID: 7398 RVA: 0x00073B4C File Offset: 0x00071D4C
		public static global::System.Collections.IEnumerator InvokeStreamRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0>.StreamRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0>.StreamRoutine)d)(p, stream);
		}

		// Token: 0x06001CE7 RID: 7399 RVA: 0x00073B90 File Offset: 0x00071D90
		public static void InvokeStreamInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0>.StreamInfoCall), instance, method, true);
			}
			((global::NGC.callf<P0>.StreamInfoCall)d)(p, info, stream);
		}

		// Token: 0x06001CE8 RID: 7400 RVA: 0x00073BD8 File Offset: 0x00071DD8
		public static global::System.Collections.IEnumerator InvokeStreamInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0>.StreamInfoRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0>.StreamInfoRoutine)d)(p, info, stream);
		}

		// Token: 0x170007CA RID: 1994
		// (get) Token: 0x06001CE9 RID: 7401 RVA: 0x00073C20 File Offset: 0x00071E20
		public static global::NGC.IExecuter Exec
		{
			get
			{
				return global::NGC.callf<P0>.Executer.Singleton;
			}
		}

		// Token: 0x02000362 RID: 866
		public struct Block
		{
			// Token: 0x040010D0 RID: 4304
			public P0 p0;
		}

		// Token: 0x02000363 RID: 867
		private sealed class Executer : global::NGC.IExecuter
		{
			// Token: 0x06001CEA RID: 7402 RVA: 0x00073C28 File Offset: 0x00071E28
			public Executer()
			{
			}

			// Token: 0x06001CEB RID: 7403 RVA: 0x00073C30 File Offset: 0x00071E30
			// Note: this type is marked as 'beforefieldinit'.
			static Executer()
			{
			}

			// Token: 0x06001CEC RID: 7404 RVA: 0x00073C3C File Offset: 0x00071E3C
			public void ExecuteCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				global::NGC.callf<P0>.InvokeCall(stream, ref d, method, instance);
			}

			// Token: 0x06001CED RID: 7405 RVA: 0x00073C48 File Offset: 0x00071E48
			public global::System.Collections.IEnumerator ExecuteRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				return global::NGC.callf<P0>.InvokeRoutine(stream, ref d, method, instance);
			}

			// Token: 0x06001CEE RID: 7406 RVA: 0x00073C54 File Offset: 0x00071E54
			public void ExecuteInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				global::NGC.callf<P0>.InvokeInfoCall(stream, ref d, method, instance, info);
			}

			// Token: 0x06001CEF RID: 7407 RVA: 0x00073C64 File Offset: 0x00071E64
			public global::System.Collections.IEnumerator ExecuteInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				return global::NGC.callf<P0>.InvokeInfoRoutine(stream, ref d, method, instance, info);
			}

			// Token: 0x06001CF0 RID: 7408 RVA: 0x00073C74 File Offset: 0x00071E74
			public void ExecuteStreamCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				global::NGC.callf<P0>.InvokeStreamCall(stream, ref d, method, instance);
			}

			// Token: 0x06001CF1 RID: 7409 RVA: 0x00073C80 File Offset: 0x00071E80
			public global::System.Collections.IEnumerator ExecuteStreamRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				return global::NGC.callf<P0>.InvokeStreamRoutine(stream, ref d, method, instance);
			}

			// Token: 0x06001CF2 RID: 7410 RVA: 0x00073C8C File Offset: 0x00071E8C
			public void ExecuteStreamInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				global::NGC.callf<P0>.InvokeStreamInfoCall(stream, ref d, method, instance, info);
			}

			// Token: 0x06001CF3 RID: 7411 RVA: 0x00073C9C File Offset: 0x00071E9C
			public global::System.Collections.IEnumerator ExecuteStreamInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				return global::NGC.callf<P0>.InvokeStreamInfoRoutine(stream, ref d, method, instance, info);
			}

			// Token: 0x040010D1 RID: 4305
			public static readonly global::NGC.IExecuter Singleton = new global::NGC.callf<P0>.Executer();
		}

		// Token: 0x02000364 RID: 868
		// (Invoke) Token: 0x06001CF5 RID: 7413
		public delegate void Call(P0 p0);

		// Token: 0x02000365 RID: 869
		// (Invoke) Token: 0x06001CF9 RID: 7417
		public delegate global::System.Collections.IEnumerator Routine(P0 p0);

		// Token: 0x02000366 RID: 870
		// (Invoke) Token: 0x06001CFD RID: 7421
		public delegate void InfoCall(P0 p0, global::uLink.NetworkMessageInfo info);

		// Token: 0x02000367 RID: 871
		// (Invoke) Token: 0x06001D01 RID: 7425
		public delegate global::System.Collections.IEnumerator InfoRoutine(P0 p0, global::uLink.NetworkMessageInfo info);

		// Token: 0x02000368 RID: 872
		// (Invoke) Token: 0x06001D05 RID: 7429
		public delegate void StreamCall(P0 p0, global::uLink.BitStream stream);

		// Token: 0x02000369 RID: 873
		// (Invoke) Token: 0x06001D09 RID: 7433
		public delegate global::System.Collections.IEnumerator StreamRoutine(P0 p0, global::uLink.BitStream stream);

		// Token: 0x0200036A RID: 874
		// (Invoke) Token: 0x06001D0D RID: 7437
		public delegate void StreamInfoCall(P0 p0, global::uLink.NetworkMessageInfo info, global::uLink.BitStream stream);

		// Token: 0x0200036B RID: 875
		// (Invoke) Token: 0x06001D11 RID: 7441
		public delegate global::System.Collections.IEnumerator StreamInfoRoutine(P0 p0, global::uLink.NetworkMessageInfo info, global::uLink.BitStream stream);
	}

	// Token: 0x0200036C RID: 876
	public static class callf<P0, P1>
	{
		// Token: 0x06001D14 RID: 7444 RVA: 0x00073CAC File Offset: 0x00071EAC
		static callf()
		{
			global::uLink.BitStreamCodec.Add<global::NGC.callf<P0, P1>.Block>(new global::uLink.BitStreamCodec.Deserializer(global::NGC.callf<P0, P1>.Deserializer), new global::uLink.BitStreamCodec.Serializer(global::NGC.callf<P0, P1>.Serializer));
		}

		// Token: 0x06001D15 RID: 7445 RVA: 0x00073CCC File Offset: 0x00071ECC
		private static object Deserializer(global::uLink.BitStream stream, params object[] codecOptions)
		{
			global::NGC.callf<P0, P1>.Block block;
			block.p0 = stream.Read<P0>(codecOptions);
			block.p1 = stream.Read<P1>(codecOptions);
			return block;
		}

		// Token: 0x06001D16 RID: 7446 RVA: 0x00073CFC File Offset: 0x00071EFC
		private static void Serializer(global::uLink.BitStream stream, object value, params object[] codecOptions)
		{
			global::NGC.callf<P0, P1>.Block block = (global::NGC.callf<P0, P1>.Block)value;
			stream.Write<P0>(block.p0, codecOptions);
			stream.Write<P1>(block.p1, codecOptions);
		}

		// Token: 0x06001D17 RID: 7447 RVA: 0x00073D2C File Offset: 0x00071F2C
		public static void InvokeCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1>.Call), instance, method, true);
			}
			((global::NGC.callf<P0, P1>.Call)d)(p, p2);
		}

		// Token: 0x06001D18 RID: 7448 RVA: 0x00073D7C File Offset: 0x00071F7C
		public static global::System.Collections.IEnumerator InvokeRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1>.Routine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1>.Routine)d)(p, p2);
		}

		// Token: 0x06001D19 RID: 7449 RVA: 0x00073DCC File Offset: 0x00071FCC
		public static void InvokeInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1>.InfoCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1>.InfoCall)d)(p, p2, info);
		}

		// Token: 0x06001D1A RID: 7450 RVA: 0x00073E20 File Offset: 0x00072020
		public static global::System.Collections.IEnumerator InvokeInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1>.InfoRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1>.InfoRoutine)d)(p, p2, info);
		}

		// Token: 0x06001D1B RID: 7451 RVA: 0x00073E74 File Offset: 0x00072074
		public static void InvokeStreamCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1>.StreamCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1>.StreamCall)d)(p, p2, stream);
		}

		// Token: 0x06001D1C RID: 7452 RVA: 0x00073EC8 File Offset: 0x000720C8
		public static global::System.Collections.IEnumerator InvokeStreamRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1>.StreamRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1>.StreamRoutine)d)(p, p2, stream);
		}

		// Token: 0x06001D1D RID: 7453 RVA: 0x00073F1C File Offset: 0x0007211C
		public static void InvokeStreamInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1>.StreamInfoCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1>.StreamInfoCall)d)(p, p2, info, stream);
		}

		// Token: 0x06001D1E RID: 7454 RVA: 0x00073F70 File Offset: 0x00072170
		public static global::System.Collections.IEnumerator InvokeStreamInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1>.StreamInfoRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1>.StreamInfoRoutine)d)(p, p2, info, stream);
		}

		// Token: 0x170007CB RID: 1995
		// (get) Token: 0x06001D1F RID: 7455 RVA: 0x00073FC4 File Offset: 0x000721C4
		public static global::NGC.IExecuter Exec
		{
			get
			{
				return global::NGC.callf<P0, P1>.Executer.Singleton;
			}
		}

		// Token: 0x0200036D RID: 877
		public struct Block
		{
			// Token: 0x040010D2 RID: 4306
			public P0 p0;

			// Token: 0x040010D3 RID: 4307
			public P1 p1;
		}

		// Token: 0x0200036E RID: 878
		private sealed class Executer : global::NGC.IExecuter
		{
			// Token: 0x06001D20 RID: 7456 RVA: 0x00073FCC File Offset: 0x000721CC
			public Executer()
			{
			}

			// Token: 0x06001D21 RID: 7457 RVA: 0x00073FD4 File Offset: 0x000721D4
			// Note: this type is marked as 'beforefieldinit'.
			static Executer()
			{
			}

			// Token: 0x06001D22 RID: 7458 RVA: 0x00073FE0 File Offset: 0x000721E0
			public void ExecuteCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				global::NGC.callf<P0, P1>.InvokeCall(stream, ref d, method, instance);
			}

			// Token: 0x06001D23 RID: 7459 RVA: 0x00073FEC File Offset: 0x000721EC
			public global::System.Collections.IEnumerator ExecuteRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				return global::NGC.callf<P0, P1>.InvokeRoutine(stream, ref d, method, instance);
			}

			// Token: 0x06001D24 RID: 7460 RVA: 0x00073FF8 File Offset: 0x000721F8
			public void ExecuteInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				global::NGC.callf<P0, P1>.InvokeInfoCall(stream, ref d, method, instance, info);
			}

			// Token: 0x06001D25 RID: 7461 RVA: 0x00074008 File Offset: 0x00072208
			public global::System.Collections.IEnumerator ExecuteInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				return global::NGC.callf<P0, P1>.InvokeInfoRoutine(stream, ref d, method, instance, info);
			}

			// Token: 0x06001D26 RID: 7462 RVA: 0x00074018 File Offset: 0x00072218
			public void ExecuteStreamCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				global::NGC.callf<P0, P1>.InvokeStreamCall(stream, ref d, method, instance);
			}

			// Token: 0x06001D27 RID: 7463 RVA: 0x00074024 File Offset: 0x00072224
			public global::System.Collections.IEnumerator ExecuteStreamRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				return global::NGC.callf<P0, P1>.InvokeStreamRoutine(stream, ref d, method, instance);
			}

			// Token: 0x06001D28 RID: 7464 RVA: 0x00074030 File Offset: 0x00072230
			public void ExecuteStreamInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				global::NGC.callf<P0, P1>.InvokeStreamInfoCall(stream, ref d, method, instance, info);
			}

			// Token: 0x06001D29 RID: 7465 RVA: 0x00074040 File Offset: 0x00072240
			public global::System.Collections.IEnumerator ExecuteStreamInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				return global::NGC.callf<P0, P1>.InvokeStreamInfoRoutine(stream, ref d, method, instance, info);
			}

			// Token: 0x040010D4 RID: 4308
			public static readonly global::NGC.IExecuter Singleton = new global::NGC.callf<P0, P1>.Executer();
		}

		// Token: 0x0200036F RID: 879
		// (Invoke) Token: 0x06001D2B RID: 7467
		public delegate void Call(P0 p0, P1 p1);

		// Token: 0x02000370 RID: 880
		// (Invoke) Token: 0x06001D2F RID: 7471
		public delegate global::System.Collections.IEnumerator Routine(P0 p0, P1 p1);

		// Token: 0x02000371 RID: 881
		// (Invoke) Token: 0x06001D33 RID: 7475
		public delegate void InfoCall(P0 p0, P1 p1, global::uLink.NetworkMessageInfo info);

		// Token: 0x02000372 RID: 882
		// (Invoke) Token: 0x06001D37 RID: 7479
		public delegate global::System.Collections.IEnumerator InfoRoutine(P0 p0, P1 p1, global::uLink.NetworkMessageInfo info);

		// Token: 0x02000373 RID: 883
		// (Invoke) Token: 0x06001D3B RID: 7483
		public delegate void StreamCall(P0 p0, P1 p1, global::uLink.BitStream stream);

		// Token: 0x02000374 RID: 884
		// (Invoke) Token: 0x06001D3F RID: 7487
		public delegate global::System.Collections.IEnumerator StreamRoutine(P0 p0, P1 p1, global::uLink.BitStream stream);

		// Token: 0x02000375 RID: 885
		// (Invoke) Token: 0x06001D43 RID: 7491
		public delegate void StreamInfoCall(P0 p0, P1 p1, global::uLink.NetworkMessageInfo info, global::uLink.BitStream stream);

		// Token: 0x02000376 RID: 886
		// (Invoke) Token: 0x06001D47 RID: 7495
		public delegate global::System.Collections.IEnumerator StreamInfoRoutine(P0 p0, P1 p1, global::uLink.NetworkMessageInfo info, global::uLink.BitStream stream);
	}

	// Token: 0x02000377 RID: 887
	public static class callf<P0, P1, P2>
	{
		// Token: 0x06001D4A RID: 7498 RVA: 0x00074050 File Offset: 0x00072250
		static callf()
		{
			global::uLink.BitStreamCodec.Add<global::NGC.callf<P0, P1, P2>.Block>(new global::uLink.BitStreamCodec.Deserializer(global::NGC.callf<P0, P1, P2>.Deserializer), new global::uLink.BitStreamCodec.Serializer(global::NGC.callf<P0, P1, P2>.Serializer));
		}

		// Token: 0x06001D4B RID: 7499 RVA: 0x00074070 File Offset: 0x00072270
		private static object Deserializer(global::uLink.BitStream stream, params object[] codecOptions)
		{
			global::NGC.callf<P0, P1, P2>.Block block;
			block.p0 = stream.Read<P0>(codecOptions);
			block.p1 = stream.Read<P1>(codecOptions);
			block.p2 = stream.Read<P2>(codecOptions);
			return block;
		}

		// Token: 0x06001D4C RID: 7500 RVA: 0x000740B0 File Offset: 0x000722B0
		private static void Serializer(global::uLink.BitStream stream, object value, params object[] codecOptions)
		{
			global::NGC.callf<P0, P1, P2>.Block block = (global::NGC.callf<P0, P1, P2>.Block)value;
			stream.Write<P0>(block.p0, codecOptions);
			stream.Write<P1>(block.p1, codecOptions);
			stream.Write<P2>(block.p2, codecOptions);
		}

		// Token: 0x06001D4D RID: 7501 RVA: 0x000740F0 File Offset: 0x000722F0
		public static void InvokeCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2>.Call), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2>.Call)d)(p, p2, p3);
		}

		// Token: 0x06001D4E RID: 7502 RVA: 0x00074150 File Offset: 0x00072350
		public static global::System.Collections.IEnumerator InvokeRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2>.Routine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2>.Routine)d)(p, p2, p3);
		}

		// Token: 0x06001D4F RID: 7503 RVA: 0x000741B0 File Offset: 0x000723B0
		public static void InvokeInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2>.InfoCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2>.InfoCall)d)(p, p2, p3, info);
		}

		// Token: 0x06001D50 RID: 7504 RVA: 0x00074210 File Offset: 0x00072410
		public static global::System.Collections.IEnumerator InvokeInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2>.InfoRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2>.InfoRoutine)d)(p, p2, p3, info);
		}

		// Token: 0x06001D51 RID: 7505 RVA: 0x00074270 File Offset: 0x00072470
		public static void InvokeStreamCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2>.StreamCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2>.StreamCall)d)(p, p2, p3, stream);
		}

		// Token: 0x06001D52 RID: 7506 RVA: 0x000742D0 File Offset: 0x000724D0
		public static global::System.Collections.IEnumerator InvokeStreamRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2>.StreamRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2>.StreamRoutine)d)(p, p2, p3, stream);
		}

		// Token: 0x06001D53 RID: 7507 RVA: 0x00074330 File Offset: 0x00072530
		public static void InvokeStreamInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2>.StreamInfoCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2>.StreamInfoCall)d)(p, p2, p3, info, stream);
		}

		// Token: 0x06001D54 RID: 7508 RVA: 0x00074394 File Offset: 0x00072594
		public static global::System.Collections.IEnumerator InvokeStreamInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2>.StreamInfoRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2>.StreamInfoRoutine)d)(p, p2, p3, info, stream);
		}

		// Token: 0x170007CC RID: 1996
		// (get) Token: 0x06001D55 RID: 7509 RVA: 0x000743F8 File Offset: 0x000725F8
		public static global::NGC.IExecuter Exec
		{
			get
			{
				return global::NGC.callf<P0, P1, P2>.Executer.Singleton;
			}
		}

		// Token: 0x02000378 RID: 888
		public struct Block
		{
			// Token: 0x040010D5 RID: 4309
			public P0 p0;

			// Token: 0x040010D6 RID: 4310
			public P1 p1;

			// Token: 0x040010D7 RID: 4311
			public P2 p2;
		}

		// Token: 0x02000379 RID: 889
		private sealed class Executer : global::NGC.IExecuter
		{
			// Token: 0x06001D56 RID: 7510 RVA: 0x00074400 File Offset: 0x00072600
			public Executer()
			{
			}

			// Token: 0x06001D57 RID: 7511 RVA: 0x00074408 File Offset: 0x00072608
			// Note: this type is marked as 'beforefieldinit'.
			static Executer()
			{
			}

			// Token: 0x06001D58 RID: 7512 RVA: 0x00074414 File Offset: 0x00072614
			public void ExecuteCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				global::NGC.callf<P0, P1, P2>.InvokeCall(stream, ref d, method, instance);
			}

			// Token: 0x06001D59 RID: 7513 RVA: 0x00074420 File Offset: 0x00072620
			public global::System.Collections.IEnumerator ExecuteRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				return global::NGC.callf<P0, P1, P2>.InvokeRoutine(stream, ref d, method, instance);
			}

			// Token: 0x06001D5A RID: 7514 RVA: 0x0007442C File Offset: 0x0007262C
			public void ExecuteInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				global::NGC.callf<P0, P1, P2>.InvokeInfoCall(stream, ref d, method, instance, info);
			}

			// Token: 0x06001D5B RID: 7515 RVA: 0x0007443C File Offset: 0x0007263C
			public global::System.Collections.IEnumerator ExecuteInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				return global::NGC.callf<P0, P1, P2>.InvokeInfoRoutine(stream, ref d, method, instance, info);
			}

			// Token: 0x06001D5C RID: 7516 RVA: 0x0007444C File Offset: 0x0007264C
			public void ExecuteStreamCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				global::NGC.callf<P0, P1, P2>.InvokeStreamCall(stream, ref d, method, instance);
			}

			// Token: 0x06001D5D RID: 7517 RVA: 0x00074458 File Offset: 0x00072658
			public global::System.Collections.IEnumerator ExecuteStreamRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				return global::NGC.callf<P0, P1, P2>.InvokeStreamRoutine(stream, ref d, method, instance);
			}

			// Token: 0x06001D5E RID: 7518 RVA: 0x00074464 File Offset: 0x00072664
			public void ExecuteStreamInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				global::NGC.callf<P0, P1, P2>.InvokeStreamInfoCall(stream, ref d, method, instance, info);
			}

			// Token: 0x06001D5F RID: 7519 RVA: 0x00074474 File Offset: 0x00072674
			public global::System.Collections.IEnumerator ExecuteStreamInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				return global::NGC.callf<P0, P1, P2>.InvokeStreamInfoRoutine(stream, ref d, method, instance, info);
			}

			// Token: 0x040010D8 RID: 4312
			public static readonly global::NGC.IExecuter Singleton = new global::NGC.callf<P0, P1, P2>.Executer();
		}

		// Token: 0x0200037A RID: 890
		// (Invoke) Token: 0x06001D61 RID: 7521
		public delegate void Call(P0 p0, P1 p1, P2 p2);

		// Token: 0x0200037B RID: 891
		// (Invoke) Token: 0x06001D65 RID: 7525
		public delegate global::System.Collections.IEnumerator Routine(P0 p0, P1 p1, P2 p2);

		// Token: 0x0200037C RID: 892
		// (Invoke) Token: 0x06001D69 RID: 7529
		public delegate void InfoCall(P0 p0, P1 p1, P2 p2, global::uLink.NetworkMessageInfo info);

		// Token: 0x0200037D RID: 893
		// (Invoke) Token: 0x06001D6D RID: 7533
		public delegate global::System.Collections.IEnumerator InfoRoutine(P0 p0, P1 p1, P2 p2, global::uLink.NetworkMessageInfo info);

		// Token: 0x0200037E RID: 894
		// (Invoke) Token: 0x06001D71 RID: 7537
		public delegate void StreamCall(P0 p0, P1 p1, P2 p2, global::uLink.BitStream stream);

		// Token: 0x0200037F RID: 895
		// (Invoke) Token: 0x06001D75 RID: 7541
		public delegate global::System.Collections.IEnumerator StreamRoutine(P0 p0, P1 p1, P2 p2, global::uLink.BitStream stream);

		// Token: 0x02000380 RID: 896
		// (Invoke) Token: 0x06001D79 RID: 7545
		public delegate void StreamInfoCall(P0 p0, P1 p1, P2 p2, global::uLink.NetworkMessageInfo info, global::uLink.BitStream stream);

		// Token: 0x02000381 RID: 897
		// (Invoke) Token: 0x06001D7D RID: 7549
		public delegate global::System.Collections.IEnumerator StreamInfoRoutine(P0 p0, P1 p1, P2 p2, global::uLink.NetworkMessageInfo info, global::uLink.BitStream stream);
	}

	// Token: 0x02000382 RID: 898
	public static class callf<P0, P1, P2, P3>
	{
		// Token: 0x06001D80 RID: 7552 RVA: 0x00074484 File Offset: 0x00072684
		static callf()
		{
			global::uLink.BitStreamCodec.Add<global::NGC.callf<P0, P1, P2, P3>.Block>(new global::uLink.BitStreamCodec.Deserializer(global::NGC.callf<P0, P1, P2, P3>.Deserializer), new global::uLink.BitStreamCodec.Serializer(global::NGC.callf<P0, P1, P2, P3>.Serializer));
		}

		// Token: 0x06001D81 RID: 7553 RVA: 0x000744A4 File Offset: 0x000726A4
		private static object Deserializer(global::uLink.BitStream stream, params object[] codecOptions)
		{
			global::NGC.callf<P0, P1, P2, P3>.Block block;
			block.p0 = stream.Read<P0>(codecOptions);
			block.p1 = stream.Read<P1>(codecOptions);
			block.p2 = stream.Read<P2>(codecOptions);
			block.p3 = stream.Read<P3>(codecOptions);
			return block;
		}

		// Token: 0x06001D82 RID: 7554 RVA: 0x000744F0 File Offset: 0x000726F0
		private static void Serializer(global::uLink.BitStream stream, object value, params object[] codecOptions)
		{
			global::NGC.callf<P0, P1, P2, P3>.Block block = (global::NGC.callf<P0, P1, P2, P3>.Block)value;
			stream.Write<P0>(block.p0, codecOptions);
			stream.Write<P1>(block.p1, codecOptions);
			stream.Write<P2>(block.p2, codecOptions);
			stream.Write<P3>(block.p3, codecOptions);
		}

		// Token: 0x06001D83 RID: 7555 RVA: 0x0007453C File Offset: 0x0007273C
		public static void InvokeCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3>.Call), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3>.Call)d)(p, p2, p3, p4);
		}

		// Token: 0x06001D84 RID: 7556 RVA: 0x000745A8 File Offset: 0x000727A8
		public static global::System.Collections.IEnumerator InvokeRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3>.Routine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3>.Routine)d)(p, p2, p3, p4);
		}

		// Token: 0x06001D85 RID: 7557 RVA: 0x00074614 File Offset: 0x00072814
		public static void InvokeInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3>.InfoCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3>.InfoCall)d)(p, p2, p3, p4, info);
		}

		// Token: 0x06001D86 RID: 7558 RVA: 0x00074684 File Offset: 0x00072884
		public static global::System.Collections.IEnumerator InvokeInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3>.InfoRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3>.InfoRoutine)d)(p, p2, p3, p4, info);
		}

		// Token: 0x06001D87 RID: 7559 RVA: 0x000746F4 File Offset: 0x000728F4
		public static void InvokeStreamCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3>.StreamCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3>.StreamCall)d)(p, p2, p3, p4, stream);
		}

		// Token: 0x06001D88 RID: 7560 RVA: 0x00074764 File Offset: 0x00072964
		public static global::System.Collections.IEnumerator InvokeStreamRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3>.StreamRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3>.StreamRoutine)d)(p, p2, p3, p4, stream);
		}

		// Token: 0x06001D89 RID: 7561 RVA: 0x000747D4 File Offset: 0x000729D4
		public static void InvokeStreamInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3>.StreamInfoCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3>.StreamInfoCall)d)(p, p2, p3, p4, info, stream);
		}

		// Token: 0x06001D8A RID: 7562 RVA: 0x00074844 File Offset: 0x00072A44
		public static global::System.Collections.IEnumerator InvokeStreamInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3>.StreamInfoRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3>.StreamInfoRoutine)d)(p, p2, p3, p4, info, stream);
		}

		// Token: 0x170007CD RID: 1997
		// (get) Token: 0x06001D8B RID: 7563 RVA: 0x000748B4 File Offset: 0x00072AB4
		public static global::NGC.IExecuter Exec
		{
			get
			{
				return global::NGC.callf<P0, P1, P2, P3>.Executer.Singleton;
			}
		}

		// Token: 0x02000383 RID: 899
		public struct Block
		{
			// Token: 0x040010D9 RID: 4313
			public P0 p0;

			// Token: 0x040010DA RID: 4314
			public P1 p1;

			// Token: 0x040010DB RID: 4315
			public P2 p2;

			// Token: 0x040010DC RID: 4316
			public P3 p3;
		}

		// Token: 0x02000384 RID: 900
		private sealed class Executer : global::NGC.IExecuter
		{
			// Token: 0x06001D8C RID: 7564 RVA: 0x000748BC File Offset: 0x00072ABC
			public Executer()
			{
			}

			// Token: 0x06001D8D RID: 7565 RVA: 0x000748C4 File Offset: 0x00072AC4
			// Note: this type is marked as 'beforefieldinit'.
			static Executer()
			{
			}

			// Token: 0x06001D8E RID: 7566 RVA: 0x000748D0 File Offset: 0x00072AD0
			public void ExecuteCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				global::NGC.callf<P0, P1, P2, P3>.InvokeCall(stream, ref d, method, instance);
			}

			// Token: 0x06001D8F RID: 7567 RVA: 0x000748DC File Offset: 0x00072ADC
			public global::System.Collections.IEnumerator ExecuteRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				return global::NGC.callf<P0, P1, P2, P3>.InvokeRoutine(stream, ref d, method, instance);
			}

			// Token: 0x06001D90 RID: 7568 RVA: 0x000748E8 File Offset: 0x00072AE8
			public void ExecuteInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				global::NGC.callf<P0, P1, P2, P3>.InvokeInfoCall(stream, ref d, method, instance, info);
			}

			// Token: 0x06001D91 RID: 7569 RVA: 0x000748F8 File Offset: 0x00072AF8
			public global::System.Collections.IEnumerator ExecuteInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				return global::NGC.callf<P0, P1, P2, P3>.InvokeInfoRoutine(stream, ref d, method, instance, info);
			}

			// Token: 0x06001D92 RID: 7570 RVA: 0x00074908 File Offset: 0x00072B08
			public void ExecuteStreamCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				global::NGC.callf<P0, P1, P2, P3>.InvokeStreamCall(stream, ref d, method, instance);
			}

			// Token: 0x06001D93 RID: 7571 RVA: 0x00074914 File Offset: 0x00072B14
			public global::System.Collections.IEnumerator ExecuteStreamRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				return global::NGC.callf<P0, P1, P2, P3>.InvokeStreamRoutine(stream, ref d, method, instance);
			}

			// Token: 0x06001D94 RID: 7572 RVA: 0x00074920 File Offset: 0x00072B20
			public void ExecuteStreamInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				global::NGC.callf<P0, P1, P2, P3>.InvokeStreamInfoCall(stream, ref d, method, instance, info);
			}

			// Token: 0x06001D95 RID: 7573 RVA: 0x00074930 File Offset: 0x00072B30
			public global::System.Collections.IEnumerator ExecuteStreamInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				return global::NGC.callf<P0, P1, P2, P3>.InvokeStreamInfoRoutine(stream, ref d, method, instance, info);
			}

			// Token: 0x040010DD RID: 4317
			public static readonly global::NGC.IExecuter Singleton = new global::NGC.callf<P0, P1, P2, P3>.Executer();
		}

		// Token: 0x02000385 RID: 901
		// (Invoke) Token: 0x06001D97 RID: 7575
		public delegate void Call(P0 p0, P1 p1, P2 p2, P3 p3);

		// Token: 0x02000386 RID: 902
		// (Invoke) Token: 0x06001D9B RID: 7579
		public delegate global::System.Collections.IEnumerator Routine(P0 p0, P1 p1, P2 p2, P3 p3);

		// Token: 0x02000387 RID: 903
		// (Invoke) Token: 0x06001D9F RID: 7583
		public delegate void InfoCall(P0 p0, P1 p1, P2 p2, P3 p3, global::uLink.NetworkMessageInfo info);

		// Token: 0x02000388 RID: 904
		// (Invoke) Token: 0x06001DA3 RID: 7587
		public delegate global::System.Collections.IEnumerator InfoRoutine(P0 p0, P1 p1, P2 p2, P3 p3, global::uLink.NetworkMessageInfo info);

		// Token: 0x02000389 RID: 905
		// (Invoke) Token: 0x06001DA7 RID: 7591
		public delegate void StreamCall(P0 p0, P1 p1, P2 p2, P3 p3, global::uLink.BitStream stream);

		// Token: 0x0200038A RID: 906
		// (Invoke) Token: 0x06001DAB RID: 7595
		public delegate global::System.Collections.IEnumerator StreamRoutine(P0 p0, P1 p1, P2 p2, P3 p3, global::uLink.BitStream stream);

		// Token: 0x0200038B RID: 907
		// (Invoke) Token: 0x06001DAF RID: 7599
		public delegate void StreamInfoCall(P0 p0, P1 p1, P2 p2, P3 p3, global::uLink.NetworkMessageInfo info, global::uLink.BitStream stream);

		// Token: 0x0200038C RID: 908
		// (Invoke) Token: 0x06001DB3 RID: 7603
		public delegate global::System.Collections.IEnumerator StreamInfoRoutine(P0 p0, P1 p1, P2 p2, P3 p3, global::uLink.NetworkMessageInfo info, global::uLink.BitStream stream);
	}

	// Token: 0x0200038D RID: 909
	public static class callf<P0, P1, P2, P3, P4>
	{
		// Token: 0x06001DB6 RID: 7606 RVA: 0x00074940 File Offset: 0x00072B40
		static callf()
		{
			global::uLink.BitStreamCodec.Add<global::NGC.callf<P0, P1, P2, P3, P4>.Block>(new global::uLink.BitStreamCodec.Deserializer(global::NGC.callf<P0, P1, P2, P3, P4>.Deserializer), new global::uLink.BitStreamCodec.Serializer(global::NGC.callf<P0, P1, P2, P3, P4>.Serializer));
		}

		// Token: 0x06001DB7 RID: 7607 RVA: 0x00074960 File Offset: 0x00072B60
		private static object Deserializer(global::uLink.BitStream stream, params object[] codecOptions)
		{
			global::NGC.callf<P0, P1, P2, P3, P4>.Block block;
			block.p0 = stream.Read<P0>(codecOptions);
			block.p1 = stream.Read<P1>(codecOptions);
			block.p2 = stream.Read<P2>(codecOptions);
			block.p3 = stream.Read<P3>(codecOptions);
			block.p4 = stream.Read<P4>(codecOptions);
			return block;
		}

		// Token: 0x06001DB8 RID: 7608 RVA: 0x000749BC File Offset: 0x00072BBC
		private static void Serializer(global::uLink.BitStream stream, object value, params object[] codecOptions)
		{
			global::NGC.callf<P0, P1, P2, P3, P4>.Block block = (global::NGC.callf<P0, P1, P2, P3, P4>.Block)value;
			stream.Write<P0>(block.p0, codecOptions);
			stream.Write<P1>(block.p1, codecOptions);
			stream.Write<P2>(block.p2, codecOptions);
			stream.Write<P3>(block.p3, codecOptions);
			stream.Write<P4>(block.p4, codecOptions);
		}

		// Token: 0x06001DB9 RID: 7609 RVA: 0x00074A18 File Offset: 0x00072C18
		public static void InvokeCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4>.Call), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4>.Call)d)(p, p2, p3, p4, p5);
		}

		// Token: 0x06001DBA RID: 7610 RVA: 0x00074A94 File Offset: 0x00072C94
		public static global::System.Collections.IEnumerator InvokeRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4>.Routine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4>.Routine)d)(p, p2, p3, p4, p5);
		}

		// Token: 0x06001DBB RID: 7611 RVA: 0x00074B10 File Offset: 0x00072D10
		public static void InvokeInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4>.InfoCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4>.InfoCall)d)(p, p2, p3, p4, p5, info);
		}

		// Token: 0x06001DBC RID: 7612 RVA: 0x00074B90 File Offset: 0x00072D90
		public static global::System.Collections.IEnumerator InvokeInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4>.InfoRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4>.InfoRoutine)d)(p, p2, p3, p4, p5, info);
		}

		// Token: 0x06001DBD RID: 7613 RVA: 0x00074C10 File Offset: 0x00072E10
		public static void InvokeStreamCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4>.StreamCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4>.StreamCall)d)(p, p2, p3, p4, p5, stream);
		}

		// Token: 0x06001DBE RID: 7614 RVA: 0x00074C90 File Offset: 0x00072E90
		public static global::System.Collections.IEnumerator InvokeStreamRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4>.StreamRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4>.StreamRoutine)d)(p, p2, p3, p4, p5, stream);
		}

		// Token: 0x06001DBF RID: 7615 RVA: 0x00074D10 File Offset: 0x00072F10
		public static void InvokeStreamInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4>.StreamInfoCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4>.StreamInfoCall)d)(p, p2, p3, p4, p5, info, stream);
		}

		// Token: 0x06001DC0 RID: 7616 RVA: 0x00074D90 File Offset: 0x00072F90
		public static global::System.Collections.IEnumerator InvokeStreamInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4>.StreamInfoRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4>.StreamInfoRoutine)d)(p, p2, p3, p4, p5, info, stream);
		}

		// Token: 0x170007CE RID: 1998
		// (get) Token: 0x06001DC1 RID: 7617 RVA: 0x00074E10 File Offset: 0x00073010
		public static global::NGC.IExecuter Exec
		{
			get
			{
				return global::NGC.callf<P0, P1, P2, P3, P4>.Executer.Singleton;
			}
		}

		// Token: 0x0200038E RID: 910
		public struct Block
		{
			// Token: 0x040010DE RID: 4318
			public P0 p0;

			// Token: 0x040010DF RID: 4319
			public P1 p1;

			// Token: 0x040010E0 RID: 4320
			public P2 p2;

			// Token: 0x040010E1 RID: 4321
			public P3 p3;

			// Token: 0x040010E2 RID: 4322
			public P4 p4;
		}

		// Token: 0x0200038F RID: 911
		private sealed class Executer : global::NGC.IExecuter
		{
			// Token: 0x06001DC2 RID: 7618 RVA: 0x00074E18 File Offset: 0x00073018
			public Executer()
			{
			}

			// Token: 0x06001DC3 RID: 7619 RVA: 0x00074E20 File Offset: 0x00073020
			// Note: this type is marked as 'beforefieldinit'.
			static Executer()
			{
			}

			// Token: 0x06001DC4 RID: 7620 RVA: 0x00074E2C File Offset: 0x0007302C
			public void ExecuteCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				global::NGC.callf<P0, P1, P2, P3, P4>.InvokeCall(stream, ref d, method, instance);
			}

			// Token: 0x06001DC5 RID: 7621 RVA: 0x00074E38 File Offset: 0x00073038
			public global::System.Collections.IEnumerator ExecuteRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4>.InvokeRoutine(stream, ref d, method, instance);
			}

			// Token: 0x06001DC6 RID: 7622 RVA: 0x00074E44 File Offset: 0x00073044
			public void ExecuteInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				global::NGC.callf<P0, P1, P2, P3, P4>.InvokeInfoCall(stream, ref d, method, instance, info);
			}

			// Token: 0x06001DC7 RID: 7623 RVA: 0x00074E54 File Offset: 0x00073054
			public global::System.Collections.IEnumerator ExecuteInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4>.InvokeInfoRoutine(stream, ref d, method, instance, info);
			}

			// Token: 0x06001DC8 RID: 7624 RVA: 0x00074E64 File Offset: 0x00073064
			public void ExecuteStreamCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				global::NGC.callf<P0, P1, P2, P3, P4>.InvokeStreamCall(stream, ref d, method, instance);
			}

			// Token: 0x06001DC9 RID: 7625 RVA: 0x00074E70 File Offset: 0x00073070
			public global::System.Collections.IEnumerator ExecuteStreamRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4>.InvokeStreamRoutine(stream, ref d, method, instance);
			}

			// Token: 0x06001DCA RID: 7626 RVA: 0x00074E7C File Offset: 0x0007307C
			public void ExecuteStreamInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				global::NGC.callf<P0, P1, P2, P3, P4>.InvokeStreamInfoCall(stream, ref d, method, instance, info);
			}

			// Token: 0x06001DCB RID: 7627 RVA: 0x00074E8C File Offset: 0x0007308C
			public global::System.Collections.IEnumerator ExecuteStreamInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4>.InvokeStreamInfoRoutine(stream, ref d, method, instance, info);
			}

			// Token: 0x040010E3 RID: 4323
			public static readonly global::NGC.IExecuter Singleton = new global::NGC.callf<P0, P1, P2, P3, P4>.Executer();
		}

		// Token: 0x02000390 RID: 912
		// (Invoke) Token: 0x06001DCD RID: 7629
		public delegate void Call(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4);

		// Token: 0x02000391 RID: 913
		// (Invoke) Token: 0x06001DD1 RID: 7633
		public delegate global::System.Collections.IEnumerator Routine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4);

		// Token: 0x02000392 RID: 914
		// (Invoke) Token: 0x06001DD5 RID: 7637
		public delegate void InfoCall(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, global::uLink.NetworkMessageInfo info);

		// Token: 0x02000393 RID: 915
		// (Invoke) Token: 0x06001DD9 RID: 7641
		public delegate global::System.Collections.IEnumerator InfoRoutine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, global::uLink.NetworkMessageInfo info);

		// Token: 0x02000394 RID: 916
		// (Invoke) Token: 0x06001DDD RID: 7645
		public delegate void StreamCall(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, global::uLink.BitStream stream);

		// Token: 0x02000395 RID: 917
		// (Invoke) Token: 0x06001DE1 RID: 7649
		public delegate global::System.Collections.IEnumerator StreamRoutine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, global::uLink.BitStream stream);

		// Token: 0x02000396 RID: 918
		// (Invoke) Token: 0x06001DE5 RID: 7653
		public delegate void StreamInfoCall(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, global::uLink.NetworkMessageInfo info, global::uLink.BitStream stream);

		// Token: 0x02000397 RID: 919
		// (Invoke) Token: 0x06001DE9 RID: 7657
		public delegate global::System.Collections.IEnumerator StreamInfoRoutine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, global::uLink.NetworkMessageInfo info, global::uLink.BitStream stream);
	}

	// Token: 0x02000398 RID: 920
	public static class callf<P0, P1, P2, P3, P4, P5>
	{
		// Token: 0x06001DEC RID: 7660 RVA: 0x00074E9C File Offset: 0x0007309C
		static callf()
		{
			global::uLink.BitStreamCodec.Add<global::NGC.callf<P0, P1, P2, P3, P4, P5>.Block>(new global::uLink.BitStreamCodec.Deserializer(global::NGC.callf<P0, P1, P2, P3, P4, P5>.Deserializer), new global::uLink.BitStreamCodec.Serializer(global::NGC.callf<P0, P1, P2, P3, P4, P5>.Serializer));
		}

		// Token: 0x06001DED RID: 7661 RVA: 0x00074EBC File Offset: 0x000730BC
		private static object Deserializer(global::uLink.BitStream stream, params object[] codecOptions)
		{
			global::NGC.callf<P0, P1, P2, P3, P4, P5>.Block block;
			block.p0 = stream.Read<P0>(codecOptions);
			block.p1 = stream.Read<P1>(codecOptions);
			block.p2 = stream.Read<P2>(codecOptions);
			block.p3 = stream.Read<P3>(codecOptions);
			block.p4 = stream.Read<P4>(codecOptions);
			block.p5 = stream.Read<P5>(codecOptions);
			return block;
		}

		// Token: 0x06001DEE RID: 7662 RVA: 0x00074F24 File Offset: 0x00073124
		private static void Serializer(global::uLink.BitStream stream, object value, params object[] codecOptions)
		{
			global::NGC.callf<P0, P1, P2, P3, P4, P5>.Block block = (global::NGC.callf<P0, P1, P2, P3, P4, P5>.Block)value;
			stream.Write<P0>(block.p0, codecOptions);
			stream.Write<P1>(block.p1, codecOptions);
			stream.Write<P2>(block.p2, codecOptions);
			stream.Write<P3>(block.p3, codecOptions);
			stream.Write<P4>(block.p4, codecOptions);
			stream.Write<P5>(block.p5, codecOptions);
		}

		// Token: 0x06001DEF RID: 7663 RVA: 0x00074F8C File Offset: 0x0007318C
		public static void InvokeCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5>.Call), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4, P5>.Call)d)(p, p2, p3, p4, p5, p6);
		}

		// Token: 0x06001DF0 RID: 7664 RVA: 0x00075018 File Offset: 0x00073218
		public static global::System.Collections.IEnumerator InvokeRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5>.Routine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4, P5>.Routine)d)(p, p2, p3, p4, p5, p6);
		}

		// Token: 0x06001DF1 RID: 7665 RVA: 0x000750A4 File Offset: 0x000732A4
		public static void InvokeInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5>.InfoCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4, P5>.InfoCall)d)(p, p2, p3, p4, p5, p6, info);
		}

		// Token: 0x06001DF2 RID: 7666 RVA: 0x00075134 File Offset: 0x00073334
		public static global::System.Collections.IEnumerator InvokeInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5>.InfoRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4, P5>.InfoRoutine)d)(p, p2, p3, p4, p5, p6, info);
		}

		// Token: 0x06001DF3 RID: 7667 RVA: 0x000751C4 File Offset: 0x000733C4
		public static void InvokeStreamCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5>.StreamCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4, P5>.StreamCall)d)(p, p2, p3, p4, p5, p6, stream);
		}

		// Token: 0x06001DF4 RID: 7668 RVA: 0x00075254 File Offset: 0x00073454
		public static global::System.Collections.IEnumerator InvokeStreamRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5>.StreamRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4, P5>.StreamRoutine)d)(p, p2, p3, p4, p5, p6, stream);
		}

		// Token: 0x06001DF5 RID: 7669 RVA: 0x000752E4 File Offset: 0x000734E4
		public static void InvokeStreamInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5>.StreamInfoCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4, P5>.StreamInfoCall)d)(p, p2, p3, p4, p5, p6, info, stream);
		}

		// Token: 0x06001DF6 RID: 7670 RVA: 0x00075374 File Offset: 0x00073574
		public static global::System.Collections.IEnumerator InvokeStreamInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5>.StreamInfoRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4, P5>.StreamInfoRoutine)d)(p, p2, p3, p4, p5, p6, info, stream);
		}

		// Token: 0x170007CF RID: 1999
		// (get) Token: 0x06001DF7 RID: 7671 RVA: 0x00075404 File Offset: 0x00073604
		public static global::NGC.IExecuter Exec
		{
			get
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5>.Executer.Singleton;
			}
		}

		// Token: 0x02000399 RID: 921
		public struct Block
		{
			// Token: 0x040010E4 RID: 4324
			public P0 p0;

			// Token: 0x040010E5 RID: 4325
			public P1 p1;

			// Token: 0x040010E6 RID: 4326
			public P2 p2;

			// Token: 0x040010E7 RID: 4327
			public P3 p3;

			// Token: 0x040010E8 RID: 4328
			public P4 p4;

			// Token: 0x040010E9 RID: 4329
			public P5 p5;
		}

		// Token: 0x0200039A RID: 922
		private sealed class Executer : global::NGC.IExecuter
		{
			// Token: 0x06001DF8 RID: 7672 RVA: 0x0007540C File Offset: 0x0007360C
			public Executer()
			{
			}

			// Token: 0x06001DF9 RID: 7673 RVA: 0x00075414 File Offset: 0x00073614
			// Note: this type is marked as 'beforefieldinit'.
			static Executer()
			{
			}

			// Token: 0x06001DFA RID: 7674 RVA: 0x00075420 File Offset: 0x00073620
			public void ExecuteCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				global::NGC.callf<P0, P1, P2, P3, P4, P5>.InvokeCall(stream, ref d, method, instance);
			}

			// Token: 0x06001DFB RID: 7675 RVA: 0x0007542C File Offset: 0x0007362C
			public global::System.Collections.IEnumerator ExecuteRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5>.InvokeRoutine(stream, ref d, method, instance);
			}

			// Token: 0x06001DFC RID: 7676 RVA: 0x00075438 File Offset: 0x00073638
			public void ExecuteInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				global::NGC.callf<P0, P1, P2, P3, P4, P5>.InvokeInfoCall(stream, ref d, method, instance, info);
			}

			// Token: 0x06001DFD RID: 7677 RVA: 0x00075448 File Offset: 0x00073648
			public global::System.Collections.IEnumerator ExecuteInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5>.InvokeInfoRoutine(stream, ref d, method, instance, info);
			}

			// Token: 0x06001DFE RID: 7678 RVA: 0x00075458 File Offset: 0x00073658
			public void ExecuteStreamCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				global::NGC.callf<P0, P1, P2, P3, P4, P5>.InvokeStreamCall(stream, ref d, method, instance);
			}

			// Token: 0x06001DFF RID: 7679 RVA: 0x00075464 File Offset: 0x00073664
			public global::System.Collections.IEnumerator ExecuteStreamRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5>.InvokeStreamRoutine(stream, ref d, method, instance);
			}

			// Token: 0x06001E00 RID: 7680 RVA: 0x00075470 File Offset: 0x00073670
			public void ExecuteStreamInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				global::NGC.callf<P0, P1, P2, P3, P4, P5>.InvokeStreamInfoCall(stream, ref d, method, instance, info);
			}

			// Token: 0x06001E01 RID: 7681 RVA: 0x00075480 File Offset: 0x00073680
			public global::System.Collections.IEnumerator ExecuteStreamInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5>.InvokeStreamInfoRoutine(stream, ref d, method, instance, info);
			}

			// Token: 0x040010EA RID: 4330
			public static readonly global::NGC.IExecuter Singleton = new global::NGC.callf<P0, P1, P2, P3, P4, P5>.Executer();
		}

		// Token: 0x0200039B RID: 923
		// (Invoke) Token: 0x06001E03 RID: 7683
		public delegate void Call(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5);

		// Token: 0x0200039C RID: 924
		// (Invoke) Token: 0x06001E07 RID: 7687
		public delegate global::System.Collections.IEnumerator Routine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5);

		// Token: 0x0200039D RID: 925
		// (Invoke) Token: 0x06001E0B RID: 7691
		public delegate void InfoCall(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, global::uLink.NetworkMessageInfo info);

		// Token: 0x0200039E RID: 926
		// (Invoke) Token: 0x06001E0F RID: 7695
		public delegate global::System.Collections.IEnumerator InfoRoutine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, global::uLink.NetworkMessageInfo info);

		// Token: 0x0200039F RID: 927
		// (Invoke) Token: 0x06001E13 RID: 7699
		public delegate void StreamCall(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, global::uLink.BitStream stream);

		// Token: 0x020003A0 RID: 928
		// (Invoke) Token: 0x06001E17 RID: 7703
		public delegate global::System.Collections.IEnumerator StreamRoutine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, global::uLink.BitStream stream);

		// Token: 0x020003A1 RID: 929
		// (Invoke) Token: 0x06001E1B RID: 7707
		public delegate void StreamInfoCall(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, global::uLink.NetworkMessageInfo info, global::uLink.BitStream stream);

		// Token: 0x020003A2 RID: 930
		// (Invoke) Token: 0x06001E1F RID: 7711
		public delegate global::System.Collections.IEnumerator StreamInfoRoutine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, global::uLink.NetworkMessageInfo info, global::uLink.BitStream stream);
	}

	// Token: 0x020003A3 RID: 931
	public static class callf<P0, P1, P2, P3, P4, P5, P6>
	{
		// Token: 0x06001E22 RID: 7714 RVA: 0x00075490 File Offset: 0x00073690
		static callf()
		{
			global::uLink.BitStreamCodec.Add<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.Block>(new global::uLink.BitStreamCodec.Deserializer(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.Deserializer), new global::uLink.BitStreamCodec.Serializer(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.Serializer));
		}

		// Token: 0x06001E23 RID: 7715 RVA: 0x000754B0 File Offset: 0x000736B0
		private static object Deserializer(global::uLink.BitStream stream, params object[] codecOptions)
		{
			global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.Block block;
			block.p0 = stream.Read<P0>(codecOptions);
			block.p1 = stream.Read<P1>(codecOptions);
			block.p2 = stream.Read<P2>(codecOptions);
			block.p3 = stream.Read<P3>(codecOptions);
			block.p4 = stream.Read<P4>(codecOptions);
			block.p5 = stream.Read<P5>(codecOptions);
			block.p6 = stream.Read<P6>(codecOptions);
			return block;
		}

		// Token: 0x06001E24 RID: 7716 RVA: 0x00075528 File Offset: 0x00073728
		private static void Serializer(global::uLink.BitStream stream, object value, params object[] codecOptions)
		{
			global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.Block block = (global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.Block)value;
			stream.Write<P0>(block.p0, codecOptions);
			stream.Write<P1>(block.p1, codecOptions);
			stream.Write<P2>(block.p2, codecOptions);
			stream.Write<P3>(block.p3, codecOptions);
			stream.Write<P4>(block.p4, codecOptions);
			stream.Write<P5>(block.p5, codecOptions);
			stream.Write<P6>(block.p6, codecOptions);
		}

		// Token: 0x06001E25 RID: 7717 RVA: 0x000755A0 File Offset: 0x000737A0
		public static void InvokeCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.Call), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.Call)d)(p, p2, p3, p4, p5, p6, p7);
		}

		// Token: 0x06001E26 RID: 7718 RVA: 0x0007563C File Offset: 0x0007383C
		public static global::System.Collections.IEnumerator InvokeRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.Routine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.Routine)d)(p, p2, p3, p4, p5, p6, p7);
		}

		// Token: 0x06001E27 RID: 7719 RVA: 0x000756D8 File Offset: 0x000738D8
		public static void InvokeInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.InfoCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.InfoCall)d)(p, p2, p3, p4, p5, p6, p7, info);
		}

		// Token: 0x06001E28 RID: 7720 RVA: 0x00075778 File Offset: 0x00073978
		public static global::System.Collections.IEnumerator InvokeInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.InfoRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.InfoRoutine)d)(p, p2, p3, p4, p5, p6, p7, info);
		}

		// Token: 0x06001E29 RID: 7721 RVA: 0x00075818 File Offset: 0x00073A18
		public static void InvokeStreamCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.StreamCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.StreamCall)d)(p, p2, p3, p4, p5, p6, p7, stream);
		}

		// Token: 0x06001E2A RID: 7722 RVA: 0x000758B8 File Offset: 0x00073AB8
		public static global::System.Collections.IEnumerator InvokeStreamRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.StreamRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.StreamRoutine)d)(p, p2, p3, p4, p5, p6, p7, stream);
		}

		// Token: 0x06001E2B RID: 7723 RVA: 0x00075958 File Offset: 0x00073B58
		public static void InvokeStreamInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.StreamInfoCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.StreamInfoCall)d)(p, p2, p3, p4, p5, p6, p7, info, stream);
		}

		// Token: 0x06001E2C RID: 7724 RVA: 0x000759F8 File Offset: 0x00073BF8
		public static global::System.Collections.IEnumerator InvokeStreamInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.StreamInfoRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.StreamInfoRoutine)d)(p, p2, p3, p4, p5, p6, p7, info, stream);
		}

		// Token: 0x170007D0 RID: 2000
		// (get) Token: 0x06001E2D RID: 7725 RVA: 0x00075A98 File Offset: 0x00073C98
		public static global::NGC.IExecuter Exec
		{
			get
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.Executer.Singleton;
			}
		}

		// Token: 0x020003A4 RID: 932
		public struct Block
		{
			// Token: 0x040010EB RID: 4331
			public P0 p0;

			// Token: 0x040010EC RID: 4332
			public P1 p1;

			// Token: 0x040010ED RID: 4333
			public P2 p2;

			// Token: 0x040010EE RID: 4334
			public P3 p3;

			// Token: 0x040010EF RID: 4335
			public P4 p4;

			// Token: 0x040010F0 RID: 4336
			public P5 p5;

			// Token: 0x040010F1 RID: 4337
			public P6 p6;
		}

		// Token: 0x020003A5 RID: 933
		private sealed class Executer : global::NGC.IExecuter
		{
			// Token: 0x06001E2E RID: 7726 RVA: 0x00075AA0 File Offset: 0x00073CA0
			public Executer()
			{
			}

			// Token: 0x06001E2F RID: 7727 RVA: 0x00075AA8 File Offset: 0x00073CA8
			// Note: this type is marked as 'beforefieldinit'.
			static Executer()
			{
			}

			// Token: 0x06001E30 RID: 7728 RVA: 0x00075AB4 File Offset: 0x00073CB4
			public void ExecuteCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.InvokeCall(stream, ref d, method, instance);
			}

			// Token: 0x06001E31 RID: 7729 RVA: 0x00075AC0 File Offset: 0x00073CC0
			public global::System.Collections.IEnumerator ExecuteRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.InvokeRoutine(stream, ref d, method, instance);
			}

			// Token: 0x06001E32 RID: 7730 RVA: 0x00075ACC File Offset: 0x00073CCC
			public void ExecuteInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.InvokeInfoCall(stream, ref d, method, instance, info);
			}

			// Token: 0x06001E33 RID: 7731 RVA: 0x00075ADC File Offset: 0x00073CDC
			public global::System.Collections.IEnumerator ExecuteInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.InvokeInfoRoutine(stream, ref d, method, instance, info);
			}

			// Token: 0x06001E34 RID: 7732 RVA: 0x00075AEC File Offset: 0x00073CEC
			public void ExecuteStreamCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.InvokeStreamCall(stream, ref d, method, instance);
			}

			// Token: 0x06001E35 RID: 7733 RVA: 0x00075AF8 File Offset: 0x00073CF8
			public global::System.Collections.IEnumerator ExecuteStreamRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.InvokeStreamRoutine(stream, ref d, method, instance);
			}

			// Token: 0x06001E36 RID: 7734 RVA: 0x00075B04 File Offset: 0x00073D04
			public void ExecuteStreamInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.InvokeStreamInfoCall(stream, ref d, method, instance, info);
			}

			// Token: 0x06001E37 RID: 7735 RVA: 0x00075B14 File Offset: 0x00073D14
			public global::System.Collections.IEnumerator ExecuteStreamInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.InvokeStreamInfoRoutine(stream, ref d, method, instance, info);
			}

			// Token: 0x040010F2 RID: 4338
			public static readonly global::NGC.IExecuter Singleton = new global::NGC.callf<P0, P1, P2, P3, P4, P5, P6>.Executer();
		}

		// Token: 0x020003A6 RID: 934
		// (Invoke) Token: 0x06001E39 RID: 7737
		public delegate void Call(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6);

		// Token: 0x020003A7 RID: 935
		// (Invoke) Token: 0x06001E3D RID: 7741
		public delegate global::System.Collections.IEnumerator Routine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6);

		// Token: 0x020003A8 RID: 936
		// (Invoke) Token: 0x06001E41 RID: 7745
		public delegate void InfoCall(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, global::uLink.NetworkMessageInfo info);

		// Token: 0x020003A9 RID: 937
		// (Invoke) Token: 0x06001E45 RID: 7749
		public delegate global::System.Collections.IEnumerator InfoRoutine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, global::uLink.NetworkMessageInfo info);

		// Token: 0x020003AA RID: 938
		// (Invoke) Token: 0x06001E49 RID: 7753
		public delegate void StreamCall(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, global::uLink.BitStream stream);

		// Token: 0x020003AB RID: 939
		// (Invoke) Token: 0x06001E4D RID: 7757
		public delegate global::System.Collections.IEnumerator StreamRoutine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, global::uLink.BitStream stream);

		// Token: 0x020003AC RID: 940
		// (Invoke) Token: 0x06001E51 RID: 7761
		public delegate void StreamInfoCall(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, global::uLink.NetworkMessageInfo info, global::uLink.BitStream stream);

		// Token: 0x020003AD RID: 941
		// (Invoke) Token: 0x06001E55 RID: 7765
		public delegate global::System.Collections.IEnumerator StreamInfoRoutine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, global::uLink.NetworkMessageInfo info, global::uLink.BitStream stream);
	}

	// Token: 0x020003AE RID: 942
	public static class callf<P0, P1, P2, P3, P4, P5, P6, P7>
	{
		// Token: 0x06001E58 RID: 7768 RVA: 0x00075B24 File Offset: 0x00073D24
		static callf()
		{
			global::uLink.BitStreamCodec.Add<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.Block>(new global::uLink.BitStreamCodec.Deserializer(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.Deserializer), new global::uLink.BitStreamCodec.Serializer(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.Serializer));
		}

		// Token: 0x06001E59 RID: 7769 RVA: 0x00075B44 File Offset: 0x00073D44
		private static object Deserializer(global::uLink.BitStream stream, params object[] codecOptions)
		{
			global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.Block block;
			block.p0 = stream.Read<P0>(codecOptions);
			block.p1 = stream.Read<P1>(codecOptions);
			block.p2 = stream.Read<P2>(codecOptions);
			block.p3 = stream.Read<P3>(codecOptions);
			block.p4 = stream.Read<P4>(codecOptions);
			block.p5 = stream.Read<P5>(codecOptions);
			block.p6 = stream.Read<P6>(codecOptions);
			block.p7 = stream.Read<P7>(codecOptions);
			return block;
		}

		// Token: 0x06001E5A RID: 7770 RVA: 0x00075BC8 File Offset: 0x00073DC8
		private static void Serializer(global::uLink.BitStream stream, object value, params object[] codecOptions)
		{
			global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.Block block = (global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.Block)value;
			stream.Write<P0>(block.p0, codecOptions);
			stream.Write<P1>(block.p1, codecOptions);
			stream.Write<P2>(block.p2, codecOptions);
			stream.Write<P3>(block.p3, codecOptions);
			stream.Write<P4>(block.p4, codecOptions);
			stream.Write<P5>(block.p5, codecOptions);
			stream.Write<P6>(block.p6, codecOptions);
			stream.Write<P7>(block.p7, codecOptions);
		}

		// Token: 0x06001E5B RID: 7771 RVA: 0x00075C4C File Offset: 0x00073E4C
		public static void InvokeCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.Call), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.Call)d)(p, p2, p3, p4, p5, p6, p7, p8);
		}

		// Token: 0x06001E5C RID: 7772 RVA: 0x00075CF8 File Offset: 0x00073EF8
		public static global::System.Collections.IEnumerator InvokeRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.Routine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.Routine)d)(p, p2, p3, p4, p5, p6, p7, p8);
		}

		// Token: 0x06001E5D RID: 7773 RVA: 0x00075DA4 File Offset: 0x00073FA4
		public static void InvokeInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.InfoCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.InfoCall)d)(p, p2, p3, p4, p5, p6, p7, p8, info);
		}

		// Token: 0x06001E5E RID: 7774 RVA: 0x00075E54 File Offset: 0x00074054
		public static global::System.Collections.IEnumerator InvokeInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.InfoRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.InfoRoutine)d)(p, p2, p3, p4, p5, p6, p7, p8, info);
		}

		// Token: 0x06001E5F RID: 7775 RVA: 0x00075F04 File Offset: 0x00074104
		public static void InvokeStreamCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.StreamCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.StreamCall)d)(p, p2, p3, p4, p5, p6, p7, p8, stream);
		}

		// Token: 0x06001E60 RID: 7776 RVA: 0x00075FB4 File Offset: 0x000741B4
		public static global::System.Collections.IEnumerator InvokeStreamRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.StreamRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.StreamRoutine)d)(p, p2, p3, p4, p5, p6, p7, p8, stream);
		}

		// Token: 0x06001E61 RID: 7777 RVA: 0x00076064 File Offset: 0x00074264
		public static void InvokeStreamInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.StreamInfoCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.StreamInfoCall)d)(p, p2, p3, p4, p5, p6, p7, p8, info, stream);
		}

		// Token: 0x06001E62 RID: 7778 RVA: 0x00076114 File Offset: 0x00074314
		public static global::System.Collections.IEnumerator InvokeStreamInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.StreamInfoRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.StreamInfoRoutine)d)(p, p2, p3, p4, p5, p6, p7, p8, info, stream);
		}

		// Token: 0x170007D1 RID: 2001
		// (get) Token: 0x06001E63 RID: 7779 RVA: 0x000761C4 File Offset: 0x000743C4
		public static global::NGC.IExecuter Exec
		{
			get
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.Executer.Singleton;
			}
		}

		// Token: 0x020003AF RID: 943
		public struct Block
		{
			// Token: 0x040010F3 RID: 4339
			public P0 p0;

			// Token: 0x040010F4 RID: 4340
			public P1 p1;

			// Token: 0x040010F5 RID: 4341
			public P2 p2;

			// Token: 0x040010F6 RID: 4342
			public P3 p3;

			// Token: 0x040010F7 RID: 4343
			public P4 p4;

			// Token: 0x040010F8 RID: 4344
			public P5 p5;

			// Token: 0x040010F9 RID: 4345
			public P6 p6;

			// Token: 0x040010FA RID: 4346
			public P7 p7;
		}

		// Token: 0x020003B0 RID: 944
		private sealed class Executer : global::NGC.IExecuter
		{
			// Token: 0x06001E64 RID: 7780 RVA: 0x000761CC File Offset: 0x000743CC
			public Executer()
			{
			}

			// Token: 0x06001E65 RID: 7781 RVA: 0x000761D4 File Offset: 0x000743D4
			// Note: this type is marked as 'beforefieldinit'.
			static Executer()
			{
			}

			// Token: 0x06001E66 RID: 7782 RVA: 0x000761E0 File Offset: 0x000743E0
			public void ExecuteCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.InvokeCall(stream, ref d, method, instance);
			}

			// Token: 0x06001E67 RID: 7783 RVA: 0x000761EC File Offset: 0x000743EC
			public global::System.Collections.IEnumerator ExecuteRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.InvokeRoutine(stream, ref d, method, instance);
			}

			// Token: 0x06001E68 RID: 7784 RVA: 0x000761F8 File Offset: 0x000743F8
			public void ExecuteInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.InvokeInfoCall(stream, ref d, method, instance, info);
			}

			// Token: 0x06001E69 RID: 7785 RVA: 0x00076208 File Offset: 0x00074408
			public global::System.Collections.IEnumerator ExecuteInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.InvokeInfoRoutine(stream, ref d, method, instance, info);
			}

			// Token: 0x06001E6A RID: 7786 RVA: 0x00076218 File Offset: 0x00074418
			public void ExecuteStreamCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.InvokeStreamCall(stream, ref d, method, instance);
			}

			// Token: 0x06001E6B RID: 7787 RVA: 0x00076224 File Offset: 0x00074424
			public global::System.Collections.IEnumerator ExecuteStreamRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.InvokeStreamRoutine(stream, ref d, method, instance);
			}

			// Token: 0x06001E6C RID: 7788 RVA: 0x00076230 File Offset: 0x00074430
			public void ExecuteStreamInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.InvokeStreamInfoCall(stream, ref d, method, instance, info);
			}

			// Token: 0x06001E6D RID: 7789 RVA: 0x00076240 File Offset: 0x00074440
			public global::System.Collections.IEnumerator ExecuteStreamInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.InvokeStreamInfoRoutine(stream, ref d, method, instance, info);
			}

			// Token: 0x040010FB RID: 4347
			public static readonly global::NGC.IExecuter Singleton = new global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7>.Executer();
		}

		// Token: 0x020003B1 RID: 945
		// (Invoke) Token: 0x06001E6F RID: 7791
		public delegate void Call(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7);

		// Token: 0x020003B2 RID: 946
		// (Invoke) Token: 0x06001E73 RID: 7795
		public delegate global::System.Collections.IEnumerator Routine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7);

		// Token: 0x020003B3 RID: 947
		// (Invoke) Token: 0x06001E77 RID: 7799
		public delegate void InfoCall(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, global::uLink.NetworkMessageInfo info);

		// Token: 0x020003B4 RID: 948
		// (Invoke) Token: 0x06001E7B RID: 7803
		public delegate global::System.Collections.IEnumerator InfoRoutine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, global::uLink.NetworkMessageInfo info);

		// Token: 0x020003B5 RID: 949
		// (Invoke) Token: 0x06001E7F RID: 7807
		public delegate void StreamCall(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, global::uLink.BitStream stream);

		// Token: 0x020003B6 RID: 950
		// (Invoke) Token: 0x06001E83 RID: 7811
		public delegate global::System.Collections.IEnumerator StreamRoutine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, global::uLink.BitStream stream);

		// Token: 0x020003B7 RID: 951
		// (Invoke) Token: 0x06001E87 RID: 7815
		public delegate void StreamInfoCall(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, global::uLink.NetworkMessageInfo info, global::uLink.BitStream stream);

		// Token: 0x020003B8 RID: 952
		// (Invoke) Token: 0x06001E8B RID: 7819
		public delegate global::System.Collections.IEnumerator StreamInfoRoutine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, global::uLink.NetworkMessageInfo info, global::uLink.BitStream stream);
	}

	// Token: 0x020003B9 RID: 953
	public static class callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>
	{
		// Token: 0x06001E8E RID: 7822 RVA: 0x00076250 File Offset: 0x00074450
		static callf()
		{
			global::uLink.BitStreamCodec.Add<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.Block>(new global::uLink.BitStreamCodec.Deserializer(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.Deserializer), new global::uLink.BitStreamCodec.Serializer(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.Serializer));
		}

		// Token: 0x06001E8F RID: 7823 RVA: 0x00076270 File Offset: 0x00074470
		private static object Deserializer(global::uLink.BitStream stream, params object[] codecOptions)
		{
			global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.Block block;
			block.p0 = stream.Read<P0>(codecOptions);
			block.p1 = stream.Read<P1>(codecOptions);
			block.p2 = stream.Read<P2>(codecOptions);
			block.p3 = stream.Read<P3>(codecOptions);
			block.p4 = stream.Read<P4>(codecOptions);
			block.p5 = stream.Read<P5>(codecOptions);
			block.p6 = stream.Read<P6>(codecOptions);
			block.p7 = stream.Read<P7>(codecOptions);
			block.p8 = stream.Read<P8>(codecOptions);
			return block;
		}

		// Token: 0x06001E90 RID: 7824 RVA: 0x00076304 File Offset: 0x00074504
		private static void Serializer(global::uLink.BitStream stream, object value, params object[] codecOptions)
		{
			global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.Block block = (global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.Block)value;
			stream.Write<P0>(block.p0, codecOptions);
			stream.Write<P1>(block.p1, codecOptions);
			stream.Write<P2>(block.p2, codecOptions);
			stream.Write<P3>(block.p3, codecOptions);
			stream.Write<P4>(block.p4, codecOptions);
			stream.Write<P5>(block.p5, codecOptions);
			stream.Write<P6>(block.p6, codecOptions);
			stream.Write<P7>(block.p7, codecOptions);
			stream.Write<P8>(block.p8, codecOptions);
		}

		// Token: 0x06001E91 RID: 7825 RVA: 0x00076398 File Offset: 0x00074598
		public static void InvokeCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.Call), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.Call)d)(p, p2, p3, p4, p5, p6, p7, p8, p9);
		}

		// Token: 0x06001E92 RID: 7826 RVA: 0x00076454 File Offset: 0x00074654
		public static global::System.Collections.IEnumerator InvokeRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.Routine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.Routine)d)(p, p2, p3, p4, p5, p6, p7, p8, p9);
		}

		// Token: 0x06001E93 RID: 7827 RVA: 0x00076510 File Offset: 0x00074710
		public static void InvokeInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.InfoCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.InfoCall)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, info);
		}

		// Token: 0x06001E94 RID: 7828 RVA: 0x000765D0 File Offset: 0x000747D0
		public static global::System.Collections.IEnumerator InvokeInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.InfoRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.InfoRoutine)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, info);
		}

		// Token: 0x06001E95 RID: 7829 RVA: 0x00076690 File Offset: 0x00074890
		public static void InvokeStreamCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.StreamCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.StreamCall)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, stream);
		}

		// Token: 0x06001E96 RID: 7830 RVA: 0x00076750 File Offset: 0x00074950
		public static global::System.Collections.IEnumerator InvokeStreamRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.StreamRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.StreamRoutine)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, stream);
		}

		// Token: 0x06001E97 RID: 7831 RVA: 0x00076810 File Offset: 0x00074A10
		public static void InvokeStreamInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.StreamInfoCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.StreamInfoCall)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, info, stream);
		}

		// Token: 0x06001E98 RID: 7832 RVA: 0x000768D0 File Offset: 0x00074AD0
		public static global::System.Collections.IEnumerator InvokeStreamInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.StreamInfoRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.StreamInfoRoutine)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, info, stream);
		}

		// Token: 0x170007D2 RID: 2002
		// (get) Token: 0x06001E99 RID: 7833 RVA: 0x00076990 File Offset: 0x00074B90
		public static global::NGC.IExecuter Exec
		{
			get
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.Executer.Singleton;
			}
		}

		// Token: 0x020003BA RID: 954
		public struct Block
		{
			// Token: 0x040010FC RID: 4348
			public P0 p0;

			// Token: 0x040010FD RID: 4349
			public P1 p1;

			// Token: 0x040010FE RID: 4350
			public P2 p2;

			// Token: 0x040010FF RID: 4351
			public P3 p3;

			// Token: 0x04001100 RID: 4352
			public P4 p4;

			// Token: 0x04001101 RID: 4353
			public P5 p5;

			// Token: 0x04001102 RID: 4354
			public P6 p6;

			// Token: 0x04001103 RID: 4355
			public P7 p7;

			// Token: 0x04001104 RID: 4356
			public P8 p8;
		}

		// Token: 0x020003BB RID: 955
		private sealed class Executer : global::NGC.IExecuter
		{
			// Token: 0x06001E9A RID: 7834 RVA: 0x00076998 File Offset: 0x00074B98
			public Executer()
			{
			}

			// Token: 0x06001E9B RID: 7835 RVA: 0x000769A0 File Offset: 0x00074BA0
			// Note: this type is marked as 'beforefieldinit'.
			static Executer()
			{
			}

			// Token: 0x06001E9C RID: 7836 RVA: 0x000769AC File Offset: 0x00074BAC
			public void ExecuteCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.InvokeCall(stream, ref d, method, instance);
			}

			// Token: 0x06001E9D RID: 7837 RVA: 0x000769B8 File Offset: 0x00074BB8
			public global::System.Collections.IEnumerator ExecuteRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.InvokeRoutine(stream, ref d, method, instance);
			}

			// Token: 0x06001E9E RID: 7838 RVA: 0x000769C4 File Offset: 0x00074BC4
			public void ExecuteInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.InvokeInfoCall(stream, ref d, method, instance, info);
			}

			// Token: 0x06001E9F RID: 7839 RVA: 0x000769D4 File Offset: 0x00074BD4
			public global::System.Collections.IEnumerator ExecuteInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.InvokeInfoRoutine(stream, ref d, method, instance, info);
			}

			// Token: 0x06001EA0 RID: 7840 RVA: 0x000769E4 File Offset: 0x00074BE4
			public void ExecuteStreamCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.InvokeStreamCall(stream, ref d, method, instance);
			}

			// Token: 0x06001EA1 RID: 7841 RVA: 0x000769F0 File Offset: 0x00074BF0
			public global::System.Collections.IEnumerator ExecuteStreamRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.InvokeStreamRoutine(stream, ref d, method, instance);
			}

			// Token: 0x06001EA2 RID: 7842 RVA: 0x000769FC File Offset: 0x00074BFC
			public void ExecuteStreamInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.InvokeStreamInfoCall(stream, ref d, method, instance, info);
			}

			// Token: 0x06001EA3 RID: 7843 RVA: 0x00076A0C File Offset: 0x00074C0C
			public global::System.Collections.IEnumerator ExecuteStreamInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.InvokeStreamInfoRoutine(stream, ref d, method, instance, info);
			}

			// Token: 0x04001105 RID: 4357
			public static readonly global::NGC.IExecuter Singleton = new global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8>.Executer();
		}

		// Token: 0x020003BC RID: 956
		// (Invoke) Token: 0x06001EA5 RID: 7845
		public delegate void Call(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8);

		// Token: 0x020003BD RID: 957
		// (Invoke) Token: 0x06001EA9 RID: 7849
		public delegate global::System.Collections.IEnumerator Routine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8);

		// Token: 0x020003BE RID: 958
		// (Invoke) Token: 0x06001EAD RID: 7853
		public delegate void InfoCall(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, global::uLink.NetworkMessageInfo info);

		// Token: 0x020003BF RID: 959
		// (Invoke) Token: 0x06001EB1 RID: 7857
		public delegate global::System.Collections.IEnumerator InfoRoutine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, global::uLink.NetworkMessageInfo info);

		// Token: 0x020003C0 RID: 960
		// (Invoke) Token: 0x06001EB5 RID: 7861
		public delegate void StreamCall(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, global::uLink.BitStream stream);

		// Token: 0x020003C1 RID: 961
		// (Invoke) Token: 0x06001EB9 RID: 7865
		public delegate global::System.Collections.IEnumerator StreamRoutine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, global::uLink.BitStream stream);

		// Token: 0x020003C2 RID: 962
		// (Invoke) Token: 0x06001EBD RID: 7869
		public delegate void StreamInfoCall(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, global::uLink.NetworkMessageInfo info, global::uLink.BitStream stream);

		// Token: 0x020003C3 RID: 963
		// (Invoke) Token: 0x06001EC1 RID: 7873
		public delegate global::System.Collections.IEnumerator StreamInfoRoutine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, global::uLink.NetworkMessageInfo info, global::uLink.BitStream stream);
	}

	// Token: 0x020003C4 RID: 964
	public static class callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>
	{
		// Token: 0x06001EC4 RID: 7876 RVA: 0x00076A1C File Offset: 0x00074C1C
		static callf()
		{
			global::uLink.BitStreamCodec.Add<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.Block>(new global::uLink.BitStreamCodec.Deserializer(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.Deserializer), new global::uLink.BitStreamCodec.Serializer(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.Serializer));
		}

		// Token: 0x06001EC5 RID: 7877 RVA: 0x00076A3C File Offset: 0x00074C3C
		private static object Deserializer(global::uLink.BitStream stream, params object[] codecOptions)
		{
			global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.Block block;
			block.p0 = stream.Read<P0>(codecOptions);
			block.p1 = stream.Read<P1>(codecOptions);
			block.p2 = stream.Read<P2>(codecOptions);
			block.p3 = stream.Read<P3>(codecOptions);
			block.p4 = stream.Read<P4>(codecOptions);
			block.p5 = stream.Read<P5>(codecOptions);
			block.p6 = stream.Read<P6>(codecOptions);
			block.p7 = stream.Read<P7>(codecOptions);
			block.p8 = stream.Read<P8>(codecOptions);
			block.p9 = stream.Read<P9>(codecOptions);
			return block;
		}

		// Token: 0x06001EC6 RID: 7878 RVA: 0x00076ADC File Offset: 0x00074CDC
		private static void Serializer(global::uLink.BitStream stream, object value, params object[] codecOptions)
		{
			global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.Block block = (global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.Block)value;
			stream.Write<P0>(block.p0, codecOptions);
			stream.Write<P1>(block.p1, codecOptions);
			stream.Write<P2>(block.p2, codecOptions);
			stream.Write<P3>(block.p3, codecOptions);
			stream.Write<P4>(block.p4, codecOptions);
			stream.Write<P5>(block.p5, codecOptions);
			stream.Write<P6>(block.p6, codecOptions);
			stream.Write<P7>(block.p7, codecOptions);
			stream.Write<P8>(block.p8, codecOptions);
			stream.Write<P9>(block.p9, codecOptions);
		}

		// Token: 0x06001EC7 RID: 7879 RVA: 0x00076B7C File Offset: 0x00074D7C
		public static void InvokeCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			P9 p10 = stream.Read<P9>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.Call), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.Call)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, p10);
		}

		// Token: 0x06001EC8 RID: 7880 RVA: 0x00076C48 File Offset: 0x00074E48
		public static global::System.Collections.IEnumerator InvokeRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			P9 p10 = stream.Read<P9>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.Routine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.Routine)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, p10);
		}

		// Token: 0x06001EC9 RID: 7881 RVA: 0x00076D14 File Offset: 0x00074F14
		public static void InvokeInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			P9 p10 = stream.Read<P9>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.InfoCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.InfoCall)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, p10, info);
		}

		// Token: 0x06001ECA RID: 7882 RVA: 0x00076DE4 File Offset: 0x00074FE4
		public static global::System.Collections.IEnumerator InvokeInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			P9 p10 = stream.Read<P9>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.InfoRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.InfoRoutine)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, p10, info);
		}

		// Token: 0x06001ECB RID: 7883 RVA: 0x00076EB4 File Offset: 0x000750B4
		public static void InvokeStreamCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			P9 p10 = stream.Read<P9>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.StreamCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.StreamCall)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, p10, stream);
		}

		// Token: 0x06001ECC RID: 7884 RVA: 0x00076F84 File Offset: 0x00075184
		public static global::System.Collections.IEnumerator InvokeStreamRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			P9 p10 = stream.Read<P9>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.StreamRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.StreamRoutine)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, p10, stream);
		}

		// Token: 0x06001ECD RID: 7885 RVA: 0x00077054 File Offset: 0x00075254
		public static void InvokeStreamInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			P9 p10 = stream.Read<P9>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.StreamInfoCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.StreamInfoCall)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, p10, info, stream);
		}

		// Token: 0x06001ECE RID: 7886 RVA: 0x00077124 File Offset: 0x00075324
		public static global::System.Collections.IEnumerator InvokeStreamInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			P9 p10 = stream.Read<P9>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.StreamInfoRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.StreamInfoRoutine)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, p10, info, stream);
		}

		// Token: 0x170007D3 RID: 2003
		// (get) Token: 0x06001ECF RID: 7887 RVA: 0x000771F4 File Offset: 0x000753F4
		public static global::NGC.IExecuter Exec
		{
			get
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.Executer.Singleton;
			}
		}

		// Token: 0x020003C5 RID: 965
		public struct Block
		{
			// Token: 0x04001106 RID: 4358
			public P0 p0;

			// Token: 0x04001107 RID: 4359
			public P1 p1;

			// Token: 0x04001108 RID: 4360
			public P2 p2;

			// Token: 0x04001109 RID: 4361
			public P3 p3;

			// Token: 0x0400110A RID: 4362
			public P4 p4;

			// Token: 0x0400110B RID: 4363
			public P5 p5;

			// Token: 0x0400110C RID: 4364
			public P6 p6;

			// Token: 0x0400110D RID: 4365
			public P7 p7;

			// Token: 0x0400110E RID: 4366
			public P8 p8;

			// Token: 0x0400110F RID: 4367
			public P9 p9;
		}

		// Token: 0x020003C6 RID: 966
		private sealed class Executer : global::NGC.IExecuter
		{
			// Token: 0x06001ED0 RID: 7888 RVA: 0x000771FC File Offset: 0x000753FC
			public Executer()
			{
			}

			// Token: 0x06001ED1 RID: 7889 RVA: 0x00077204 File Offset: 0x00075404
			// Note: this type is marked as 'beforefieldinit'.
			static Executer()
			{
			}

			// Token: 0x06001ED2 RID: 7890 RVA: 0x00077210 File Offset: 0x00075410
			public void ExecuteCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.InvokeCall(stream, ref d, method, instance);
			}

			// Token: 0x06001ED3 RID: 7891 RVA: 0x0007721C File Offset: 0x0007541C
			public global::System.Collections.IEnumerator ExecuteRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.InvokeRoutine(stream, ref d, method, instance);
			}

			// Token: 0x06001ED4 RID: 7892 RVA: 0x00077228 File Offset: 0x00075428
			public void ExecuteInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.InvokeInfoCall(stream, ref d, method, instance, info);
			}

			// Token: 0x06001ED5 RID: 7893 RVA: 0x00077238 File Offset: 0x00075438
			public global::System.Collections.IEnumerator ExecuteInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.InvokeInfoRoutine(stream, ref d, method, instance, info);
			}

			// Token: 0x06001ED6 RID: 7894 RVA: 0x00077248 File Offset: 0x00075448
			public void ExecuteStreamCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.InvokeStreamCall(stream, ref d, method, instance);
			}

			// Token: 0x06001ED7 RID: 7895 RVA: 0x00077254 File Offset: 0x00075454
			public global::System.Collections.IEnumerator ExecuteStreamRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.InvokeStreamRoutine(stream, ref d, method, instance);
			}

			// Token: 0x06001ED8 RID: 7896 RVA: 0x00077260 File Offset: 0x00075460
			public void ExecuteStreamInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.InvokeStreamInfoCall(stream, ref d, method, instance, info);
			}

			// Token: 0x06001ED9 RID: 7897 RVA: 0x00077270 File Offset: 0x00075470
			public global::System.Collections.IEnumerator ExecuteStreamInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.InvokeStreamInfoRoutine(stream, ref d, method, instance, info);
			}

			// Token: 0x04001110 RID: 4368
			public static readonly global::NGC.IExecuter Singleton = new global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>.Executer();
		}

		// Token: 0x020003C7 RID: 967
		// (Invoke) Token: 0x06001EDB RID: 7899
		public delegate void Call(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9);

		// Token: 0x020003C8 RID: 968
		// (Invoke) Token: 0x06001EDF RID: 7903
		public delegate global::System.Collections.IEnumerator Routine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9);

		// Token: 0x020003C9 RID: 969
		// (Invoke) Token: 0x06001EE3 RID: 7907
		public delegate void InfoCall(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, global::uLink.NetworkMessageInfo info);

		// Token: 0x020003CA RID: 970
		// (Invoke) Token: 0x06001EE7 RID: 7911
		public delegate global::System.Collections.IEnumerator InfoRoutine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, global::uLink.NetworkMessageInfo info);

		// Token: 0x020003CB RID: 971
		// (Invoke) Token: 0x06001EEB RID: 7915
		public delegate void StreamCall(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, global::uLink.BitStream stream);

		// Token: 0x020003CC RID: 972
		// (Invoke) Token: 0x06001EEF RID: 7919
		public delegate global::System.Collections.IEnumerator StreamRoutine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, global::uLink.BitStream stream);

		// Token: 0x020003CD RID: 973
		// (Invoke) Token: 0x06001EF3 RID: 7923
		public delegate void StreamInfoCall(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, global::uLink.NetworkMessageInfo info, global::uLink.BitStream stream);

		// Token: 0x020003CE RID: 974
		// (Invoke) Token: 0x06001EF7 RID: 7927
		public delegate global::System.Collections.IEnumerator StreamInfoRoutine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, global::uLink.NetworkMessageInfo info, global::uLink.BitStream stream);
	}

	// Token: 0x020003CF RID: 975
	public static class callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>
	{
		// Token: 0x06001EFA RID: 7930 RVA: 0x00077280 File Offset: 0x00075480
		static callf()
		{
			global::uLink.BitStreamCodec.Add<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.Block>(new global::uLink.BitStreamCodec.Deserializer(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.Deserializer), new global::uLink.BitStreamCodec.Serializer(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.Serializer));
		}

		// Token: 0x06001EFB RID: 7931 RVA: 0x000772A0 File Offset: 0x000754A0
		private static object Deserializer(global::uLink.BitStream stream, params object[] codecOptions)
		{
			global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.Block block;
			block.p0 = stream.Read<P0>(codecOptions);
			block.p1 = stream.Read<P1>(codecOptions);
			block.p2 = stream.Read<P2>(codecOptions);
			block.p3 = stream.Read<P3>(codecOptions);
			block.p4 = stream.Read<P4>(codecOptions);
			block.p5 = stream.Read<P5>(codecOptions);
			block.p6 = stream.Read<P6>(codecOptions);
			block.p7 = stream.Read<P7>(codecOptions);
			block.p8 = stream.Read<P8>(codecOptions);
			block.p9 = stream.Read<P9>(codecOptions);
			block.p10 = stream.Read<P10>(codecOptions);
			return block;
		}

		// Token: 0x06001EFC RID: 7932 RVA: 0x00077350 File Offset: 0x00075550
		private static void Serializer(global::uLink.BitStream stream, object value, params object[] codecOptions)
		{
			global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.Block block = (global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.Block)value;
			stream.Write<P0>(block.p0, codecOptions);
			stream.Write<P1>(block.p1, codecOptions);
			stream.Write<P2>(block.p2, codecOptions);
			stream.Write<P3>(block.p3, codecOptions);
			stream.Write<P4>(block.p4, codecOptions);
			stream.Write<P5>(block.p5, codecOptions);
			stream.Write<P6>(block.p6, codecOptions);
			stream.Write<P7>(block.p7, codecOptions);
			stream.Write<P8>(block.p8, codecOptions);
			stream.Write<P9>(block.p9, codecOptions);
			stream.Write<P10>(block.p10, codecOptions);
		}

		// Token: 0x06001EFD RID: 7933 RVA: 0x00077400 File Offset: 0x00075600
		public static void InvokeCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			P9 p10 = stream.Read<P9>(new object[0]);
			P10 p11 = stream.Read<P10>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.Call), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.Call)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
		}

		// Token: 0x06001EFE RID: 7934 RVA: 0x000774DC File Offset: 0x000756DC
		public static global::System.Collections.IEnumerator InvokeRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			P9 p10 = stream.Read<P9>(new object[0]);
			P10 p11 = stream.Read<P10>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.Routine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.Routine)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
		}

		// Token: 0x06001EFF RID: 7935 RVA: 0x000775B8 File Offset: 0x000757B8
		public static void InvokeInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			P9 p10 = stream.Read<P9>(new object[0]);
			P10 p11 = stream.Read<P10>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.InfoCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.InfoCall)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, info);
		}

		// Token: 0x06001F00 RID: 7936 RVA: 0x00077698 File Offset: 0x00075898
		public static global::System.Collections.IEnumerator InvokeInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			P9 p10 = stream.Read<P9>(new object[0]);
			P10 p11 = stream.Read<P10>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.InfoRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.InfoRoutine)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, info);
		}

		// Token: 0x06001F01 RID: 7937 RVA: 0x00077778 File Offset: 0x00075978
		public static void InvokeStreamCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			P9 p10 = stream.Read<P9>(new object[0]);
			P10 p11 = stream.Read<P10>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.StreamCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.StreamCall)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, stream);
		}

		// Token: 0x06001F02 RID: 7938 RVA: 0x00077858 File Offset: 0x00075A58
		public static global::System.Collections.IEnumerator InvokeStreamRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			P9 p10 = stream.Read<P9>(new object[0]);
			P10 p11 = stream.Read<P10>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.StreamRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.StreamRoutine)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, stream);
		}

		// Token: 0x06001F03 RID: 7939 RVA: 0x00077938 File Offset: 0x00075B38
		public static void InvokeStreamInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			P9 p10 = stream.Read<P9>(new object[0]);
			P10 p11 = stream.Read<P10>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.StreamInfoCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.StreamInfoCall)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, info, stream);
		}

		// Token: 0x06001F04 RID: 7940 RVA: 0x00077A18 File Offset: 0x00075C18
		public static global::System.Collections.IEnumerator InvokeStreamInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			P9 p10 = stream.Read<P9>(new object[0]);
			P10 p11 = stream.Read<P10>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.StreamInfoRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.StreamInfoRoutine)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, info, stream);
		}

		// Token: 0x170007D4 RID: 2004
		// (get) Token: 0x06001F05 RID: 7941 RVA: 0x00077AF8 File Offset: 0x00075CF8
		public static global::NGC.IExecuter Exec
		{
			get
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.Executer.Singleton;
			}
		}

		// Token: 0x020003D0 RID: 976
		public struct Block
		{
			// Token: 0x04001111 RID: 4369
			public P0 p0;

			// Token: 0x04001112 RID: 4370
			public P1 p1;

			// Token: 0x04001113 RID: 4371
			public P2 p2;

			// Token: 0x04001114 RID: 4372
			public P3 p3;

			// Token: 0x04001115 RID: 4373
			public P4 p4;

			// Token: 0x04001116 RID: 4374
			public P5 p5;

			// Token: 0x04001117 RID: 4375
			public P6 p6;

			// Token: 0x04001118 RID: 4376
			public P7 p7;

			// Token: 0x04001119 RID: 4377
			public P8 p8;

			// Token: 0x0400111A RID: 4378
			public P9 p9;

			// Token: 0x0400111B RID: 4379
			public P10 p10;
		}

		// Token: 0x020003D1 RID: 977
		private sealed class Executer : global::NGC.IExecuter
		{
			// Token: 0x06001F06 RID: 7942 RVA: 0x00077B00 File Offset: 0x00075D00
			public Executer()
			{
			}

			// Token: 0x06001F07 RID: 7943 RVA: 0x00077B08 File Offset: 0x00075D08
			// Note: this type is marked as 'beforefieldinit'.
			static Executer()
			{
			}

			// Token: 0x06001F08 RID: 7944 RVA: 0x00077B14 File Offset: 0x00075D14
			public void ExecuteCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.InvokeCall(stream, ref d, method, instance);
			}

			// Token: 0x06001F09 RID: 7945 RVA: 0x00077B20 File Offset: 0x00075D20
			public global::System.Collections.IEnumerator ExecuteRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.InvokeRoutine(stream, ref d, method, instance);
			}

			// Token: 0x06001F0A RID: 7946 RVA: 0x00077B2C File Offset: 0x00075D2C
			public void ExecuteInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.InvokeInfoCall(stream, ref d, method, instance, info);
			}

			// Token: 0x06001F0B RID: 7947 RVA: 0x00077B3C File Offset: 0x00075D3C
			public global::System.Collections.IEnumerator ExecuteInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.InvokeInfoRoutine(stream, ref d, method, instance, info);
			}

			// Token: 0x06001F0C RID: 7948 RVA: 0x00077B4C File Offset: 0x00075D4C
			public void ExecuteStreamCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.InvokeStreamCall(stream, ref d, method, instance);
			}

			// Token: 0x06001F0D RID: 7949 RVA: 0x00077B58 File Offset: 0x00075D58
			public global::System.Collections.IEnumerator ExecuteStreamRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.InvokeStreamRoutine(stream, ref d, method, instance);
			}

			// Token: 0x06001F0E RID: 7950 RVA: 0x00077B64 File Offset: 0x00075D64
			public void ExecuteStreamInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.InvokeStreamInfoCall(stream, ref d, method, instance, info);
			}

			// Token: 0x06001F0F RID: 7951 RVA: 0x00077B74 File Offset: 0x00075D74
			public global::System.Collections.IEnumerator ExecuteStreamInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.InvokeStreamInfoRoutine(stream, ref d, method, instance, info);
			}

			// Token: 0x0400111C RID: 4380
			public static readonly global::NGC.IExecuter Singleton = new global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.Executer();
		}

		// Token: 0x020003D2 RID: 978
		// (Invoke) Token: 0x06001F11 RID: 7953
		public delegate void Call(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10);

		// Token: 0x020003D3 RID: 979
		// (Invoke) Token: 0x06001F15 RID: 7957
		public delegate global::System.Collections.IEnumerator Routine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10);

		// Token: 0x020003D4 RID: 980
		// (Invoke) Token: 0x06001F19 RID: 7961
		public delegate void InfoCall(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, global::uLink.NetworkMessageInfo info);

		// Token: 0x020003D5 RID: 981
		// (Invoke) Token: 0x06001F1D RID: 7965
		public delegate global::System.Collections.IEnumerator InfoRoutine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, global::uLink.NetworkMessageInfo info);

		// Token: 0x020003D6 RID: 982
		// (Invoke) Token: 0x06001F21 RID: 7969
		public delegate void StreamCall(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, global::uLink.BitStream stream);

		// Token: 0x020003D7 RID: 983
		// (Invoke) Token: 0x06001F25 RID: 7973
		public delegate global::System.Collections.IEnumerator StreamRoutine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, global::uLink.BitStream stream);

		// Token: 0x020003D8 RID: 984
		// (Invoke) Token: 0x06001F29 RID: 7977
		public delegate void StreamInfoCall(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, global::uLink.NetworkMessageInfo info, global::uLink.BitStream stream);

		// Token: 0x020003D9 RID: 985
		// (Invoke) Token: 0x06001F2D RID: 7981
		public delegate global::System.Collections.IEnumerator StreamInfoRoutine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, global::uLink.NetworkMessageInfo info, global::uLink.BitStream stream);
	}

	// Token: 0x020003DA RID: 986
	public static class callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>
	{
		// Token: 0x06001F30 RID: 7984 RVA: 0x00077B84 File Offset: 0x00075D84
		static callf()
		{
			global::uLink.BitStreamCodec.Add<global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.Block>(new global::uLink.BitStreamCodec.Deserializer(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.Deserializer), new global::uLink.BitStreamCodec.Serializer(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.Serializer));
		}

		// Token: 0x06001F31 RID: 7985 RVA: 0x00077BA4 File Offset: 0x00075DA4
		private static object Deserializer(global::uLink.BitStream stream, params object[] codecOptions)
		{
			global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.Block block;
			block.p0 = stream.Read<P0>(codecOptions);
			block.p1 = stream.Read<P1>(codecOptions);
			block.p2 = stream.Read<P2>(codecOptions);
			block.p3 = stream.Read<P3>(codecOptions);
			block.p4 = stream.Read<P4>(codecOptions);
			block.p5 = stream.Read<P5>(codecOptions);
			block.p6 = stream.Read<P6>(codecOptions);
			block.p7 = stream.Read<P7>(codecOptions);
			block.p8 = stream.Read<P8>(codecOptions);
			block.p9 = stream.Read<P9>(codecOptions);
			block.p10 = stream.Read<P10>(codecOptions);
			block.p11 = stream.Read<P11>(codecOptions);
			return block;
		}

		// Token: 0x06001F32 RID: 7986 RVA: 0x00077C60 File Offset: 0x00075E60
		private static void Serializer(global::uLink.BitStream stream, object value, params object[] codecOptions)
		{
			global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.Block block = (global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.Block)value;
			stream.Write<P0>(block.p0, codecOptions);
			stream.Write<P1>(block.p1, codecOptions);
			stream.Write<P2>(block.p2, codecOptions);
			stream.Write<P3>(block.p3, codecOptions);
			stream.Write<P4>(block.p4, codecOptions);
			stream.Write<P5>(block.p5, codecOptions);
			stream.Write<P6>(block.p6, codecOptions);
			stream.Write<P7>(block.p7, codecOptions);
			stream.Write<P8>(block.p8, codecOptions);
			stream.Write<P9>(block.p9, codecOptions);
			stream.Write<P10>(block.p10, codecOptions);
			stream.Write<P11>(block.p11, codecOptions);
		}

		// Token: 0x06001F33 RID: 7987 RVA: 0x00077D1C File Offset: 0x00075F1C
		public static void InvokeCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			P9 p10 = stream.Read<P9>(new object[0]);
			P10 p11 = stream.Read<P10>(new object[0]);
			P11 p12 = stream.Read<P11>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.Call), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.Call)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);
		}

		// Token: 0x06001F34 RID: 7988 RVA: 0x00077E08 File Offset: 0x00076008
		public static global::System.Collections.IEnumerator InvokeRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			P9 p10 = stream.Read<P9>(new object[0]);
			P10 p11 = stream.Read<P10>(new object[0]);
			P11 p12 = stream.Read<P11>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.Routine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.Routine)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);
		}

		// Token: 0x06001F35 RID: 7989 RVA: 0x00077EF4 File Offset: 0x000760F4
		public static void InvokeInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			P9 p10 = stream.Read<P9>(new object[0]);
			P10 p11 = stream.Read<P10>(new object[0]);
			P11 p12 = stream.Read<P11>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.InfoCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.InfoCall)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, info);
		}

		// Token: 0x06001F36 RID: 7990 RVA: 0x00077FE4 File Offset: 0x000761E4
		public static global::System.Collections.IEnumerator InvokeInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			P9 p10 = stream.Read<P9>(new object[0]);
			P10 p11 = stream.Read<P10>(new object[0]);
			P11 p12 = stream.Read<P11>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.InfoRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.InfoRoutine)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, info);
		}

		// Token: 0x06001F37 RID: 7991 RVA: 0x000780D4 File Offset: 0x000762D4
		public static void InvokeStreamCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			P9 p10 = stream.Read<P9>(new object[0]);
			P10 p11 = stream.Read<P10>(new object[0]);
			P11 p12 = stream.Read<P11>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.StreamCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.StreamCall)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, stream);
		}

		// Token: 0x06001F38 RID: 7992 RVA: 0x000781C4 File Offset: 0x000763C4
		public static global::System.Collections.IEnumerator InvokeStreamRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			P9 p10 = stream.Read<P9>(new object[0]);
			P10 p11 = stream.Read<P10>(new object[0]);
			P11 p12 = stream.Read<P11>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.StreamRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.StreamRoutine)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, stream);
		}

		// Token: 0x06001F39 RID: 7993 RVA: 0x000782B4 File Offset: 0x000764B4
		public static void InvokeStreamInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			P9 p10 = stream.Read<P9>(new object[0]);
			P10 p11 = stream.Read<P10>(new object[0]);
			P11 p12 = stream.Read<P11>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.StreamInfoCall), instance, method, true);
			}
			((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.StreamInfoCall)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, info, stream);
		}

		// Token: 0x06001F3A RID: 7994 RVA: 0x000783A4 File Offset: 0x000765A4
		public static global::System.Collections.IEnumerator InvokeStreamInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
		{
			P0 p = stream.Read<P0>(new object[0]);
			P1 p2 = stream.Read<P1>(new object[0]);
			P2 p3 = stream.Read<P2>(new object[0]);
			P3 p4 = stream.Read<P3>(new object[0]);
			P4 p5 = stream.Read<P4>(new object[0]);
			P5 p6 = stream.Read<P5>(new object[0]);
			P6 p7 = stream.Read<P6>(new object[0]);
			P7 p8 = stream.Read<P7>(new object[0]);
			P8 p9 = stream.Read<P8>(new object[0]);
			P9 p10 = stream.Read<P9>(new object[0]);
			P10 p11 = stream.Read<P10>(new object[0]);
			P11 p12 = stream.Read<P11>(new object[0]);
			if (d == null)
			{
				d = global::System.Delegate.CreateDelegate(typeof(global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.StreamInfoRoutine), instance, method, true);
			}
			return ((global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.StreamInfoRoutine)d)(p, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, info, stream);
		}

		// Token: 0x170007D5 RID: 2005
		// (get) Token: 0x06001F3B RID: 7995 RVA: 0x00078494 File Offset: 0x00076694
		public static global::NGC.IExecuter Exec
		{
			get
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.Executer.Singleton;
			}
		}

		// Token: 0x020003DB RID: 987
		public struct Block
		{
			// Token: 0x0400111D RID: 4381
			public P0 p0;

			// Token: 0x0400111E RID: 4382
			public P1 p1;

			// Token: 0x0400111F RID: 4383
			public P2 p2;

			// Token: 0x04001120 RID: 4384
			public P3 p3;

			// Token: 0x04001121 RID: 4385
			public P4 p4;

			// Token: 0x04001122 RID: 4386
			public P5 p5;

			// Token: 0x04001123 RID: 4387
			public P6 p6;

			// Token: 0x04001124 RID: 4388
			public P7 p7;

			// Token: 0x04001125 RID: 4389
			public P8 p8;

			// Token: 0x04001126 RID: 4390
			public P9 p9;

			// Token: 0x04001127 RID: 4391
			public P10 p10;

			// Token: 0x04001128 RID: 4392
			public P11 p11;
		}

		// Token: 0x020003DC RID: 988
		private sealed class Executer : global::NGC.IExecuter
		{
			// Token: 0x06001F3C RID: 7996 RVA: 0x0007849C File Offset: 0x0007669C
			public Executer()
			{
			}

			// Token: 0x06001F3D RID: 7997 RVA: 0x000784A4 File Offset: 0x000766A4
			// Note: this type is marked as 'beforefieldinit'.
			static Executer()
			{
			}

			// Token: 0x06001F3E RID: 7998 RVA: 0x000784B0 File Offset: 0x000766B0
			public void ExecuteCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.InvokeCall(stream, ref d, method, instance);
			}

			// Token: 0x06001F3F RID: 7999 RVA: 0x000784BC File Offset: 0x000766BC
			public global::System.Collections.IEnumerator ExecuteRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.InvokeRoutine(stream, ref d, method, instance);
			}

			// Token: 0x06001F40 RID: 8000 RVA: 0x000784C8 File Offset: 0x000766C8
			public void ExecuteInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.InvokeInfoCall(stream, ref d, method, instance, info);
			}

			// Token: 0x06001F41 RID: 8001 RVA: 0x000784D8 File Offset: 0x000766D8
			public global::System.Collections.IEnumerator ExecuteInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.InvokeInfoRoutine(stream, ref d, method, instance, info);
			}

			// Token: 0x06001F42 RID: 8002 RVA: 0x000784E8 File Offset: 0x000766E8
			public void ExecuteStreamCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.InvokeStreamCall(stream, ref d, method, instance);
			}

			// Token: 0x06001F43 RID: 8003 RVA: 0x000784F4 File Offset: 0x000766F4
			public global::System.Collections.IEnumerator ExecuteStreamRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.InvokeStreamRoutine(stream, ref d, method, instance);
			}

			// Token: 0x06001F44 RID: 8004 RVA: 0x00078500 File Offset: 0x00076700
			public void ExecuteStreamInfoCall(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.InvokeStreamInfoCall(stream, ref d, method, instance, info);
			}

			// Token: 0x06001F45 RID: 8005 RVA: 0x00078510 File Offset: 0x00076710
			public global::System.Collections.IEnumerator ExecuteStreamInfoRoutine(global::uLink.BitStream stream, ref global::System.Delegate d, global::System.Reflection.MethodInfo method, global::UnityEngine.MonoBehaviour instance, global::uLink.NetworkMessageInfo info)
			{
				return global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.InvokeStreamInfoRoutine(stream, ref d, method, instance, info);
			}

			// Token: 0x04001129 RID: 4393
			public static readonly global::NGC.IExecuter Singleton = new global::NGC.callf<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.Executer();
		}

		// Token: 0x020003DD RID: 989
		// (Invoke) Token: 0x06001F47 RID: 8007
		public delegate void Call(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11);

		// Token: 0x020003DE RID: 990
		// (Invoke) Token: 0x06001F4B RID: 8011
		public delegate global::System.Collections.IEnumerator Routine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11);

		// Token: 0x020003DF RID: 991
		// (Invoke) Token: 0x06001F4F RID: 8015
		public delegate void InfoCall(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, global::uLink.NetworkMessageInfo info);

		// Token: 0x020003E0 RID: 992
		// (Invoke) Token: 0x06001F53 RID: 8019
		public delegate global::System.Collections.IEnumerator InfoRoutine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, global::uLink.NetworkMessageInfo info);

		// Token: 0x020003E1 RID: 993
		// (Invoke) Token: 0x06001F57 RID: 8023
		public delegate void StreamCall(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, global::uLink.BitStream stream);

		// Token: 0x020003E2 RID: 994
		// (Invoke) Token: 0x06001F5B RID: 8027
		public delegate global::System.Collections.IEnumerator StreamRoutine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, global::uLink.BitStream stream);

		// Token: 0x020003E3 RID: 995
		// (Invoke) Token: 0x06001F5F RID: 8031
		public delegate void StreamInfoCall(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, global::uLink.NetworkMessageInfo info, global::uLink.BitStream stream);

		// Token: 0x020003E4 RID: 996
		// (Invoke) Token: 0x06001F63 RID: 8035
		public delegate global::System.Collections.IEnumerator StreamInfoRoutine(P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, global::uLink.NetworkMessageInfo info, global::uLink.BitStream stream);
	}

	// Token: 0x020003E5 RID: 997
	// (Invoke) Token: 0x06001F67 RID: 8039
	public delegate void EventCallback(global::NGCView view);
}
