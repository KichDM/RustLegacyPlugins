using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Facepunch;
using uLink;
using UnityEngine;

// Token: 0x020006CD RID: 1741
[global::UnityEngine.RequireComponent(typeof(global::uLinkNetworkView))]
public class ItemRepresentation : global::IDMain, global::IInterpTimedEventReceiver
{
	// Token: 0x06003B8E RID: 15246 RVA: 0x000D38C4 File Offset: 0x000D1AC4
	public ItemRepresentation() : base(2)
	{
		this.stateSignalReceive = new global::CharacterStateSignal(this.StateSignalReceive);
	}

	// Token: 0x06003B8F RID: 15247 RVA: 0x000D38E0 File Offset: 0x000D1AE0
	void global::IInterpTimedEventReceiver.OnInterpTimedEvent()
	{
		this.OnInterpTimedEvent();
	}

	// Token: 0x17000B2E RID: 2862
	// (get) Token: 0x06003B90 RID: 15248 RVA: 0x000D38E8 File Offset: 0x000D1AE8
	public global::ItemModFlags modFlags
	{
		get
		{
			return this._modFlags;
		}
	}

	// Token: 0x17000B2F RID: 2863
	// (get) Token: 0x06003B91 RID: 15249 RVA: 0x000D38F0 File Offset: 0x000D1AF0
	public global::HeldItemDataBlock datablock
	{
		get
		{
			return this._datablock;
		}
	}

	// Token: 0x06003B92 RID: 15250 RVA: 0x000D38F8 File Offset: 0x000D1AF8
	private void BindModAsProxy(ref global::ItemRepresentation.ItemModPair pair)
	{
		if ((int)pair.bindState == 1)
		{
			pair.dataBlock.BindAsProxy(pair.representation);
			pair.bindState = global::ItemRepresentation.BindState.World;
		}
	}

	// Token: 0x06003B93 RID: 15251 RVA: 0x000D3920 File Offset: 0x000D1B20
	private void UnBindModAsProxy(ref global::ItemRepresentation.ItemModPair pair)
	{
		if ((int)pair.bindState == 2)
		{
			pair.dataBlock.UnBindAsProxy(pair.representation);
			pair.bindState = global::ItemRepresentation.BindState.None;
		}
	}

	// Token: 0x06003B94 RID: 15252 RVA: 0x000D3948 File Offset: 0x000D1B48
	protected void Awake()
	{
		global::ServerHelper.SetupForServer(base.gameObject);
	}

	// Token: 0x17000B30 RID: 2864
	// (get) Token: 0x06003B95 RID: 15253 RVA: 0x000D3958 File Offset: 0x000D1B58
	public string worldAnimationGroupName
	{
		get
		{
			return this.worldAnimationGroupNameOverride ?? this.datablock.animationGroupName;
		}
	}

	// Token: 0x06003B96 RID: 15254 RVA: 0x000D3974 File Offset: 0x000D1B74
	public bool Item<IInventoryItemInterface>(out IInventoryItemInterface found) where IInventoryItemInterface : class, global::IInventoryItem
	{
		found = (this._item as IInventoryItemInterface);
		return !object.ReferenceEquals(found, null);
	}

	// Token: 0x06003B97 RID: 15255 RVA: 0x000D39A8 File Offset: 0x000D1BA8
	protected void OnDrawGizmosSelected()
	{
		this.muzzle.DrawGizmos("muzzle");
	}

	// Token: 0x06003B98 RID: 15256 RVA: 0x000D39BC File Offset: 0x000D1BBC
	private void KillModRep(ref global::ItemModRepresentation rep, bool fromCallback)
	{
		if (!fromCallback && rep)
		{
			global::ItemModRepresentation itemModRepresentation = this.destroyingRep;
			try
			{
				this.destroyingRep = rep;
				global::UnityEngine.Object.Destroy(rep);
			}
			finally
			{
				this.destroyingRep = itemModRepresentation;
			}
		}
		rep = null;
	}

	// Token: 0x06003B99 RID: 15257 RVA: 0x000D3A20 File Offset: 0x000D1C20
	protected void OnDestroy()
	{
		try
		{
			this.ClearMods();
		}
		finally
		{
			this._parentViewID = global::uLink.NetworkViewID.unassigned;
			this.ClearSignals();
			base.OnDestroy();
		}
	}

	// Token: 0x06003B9A RID: 15258 RVA: 0x000D3A70 File Offset: 0x000D1C70
	public virtual void SetParent(global::UnityEngine.GameObject parentGameObject)
	{
		global::UnityEngine.Transform transform = parentGameObject.transform;
		if (!base.transform.IsChildOf(transform))
		{
			base.transform.parent = transform;
		}
	}

	// Token: 0x06003B9B RID: 15259 RVA: 0x000D3AA4 File Offset: 0x000D1CA4
	protected bool CheckParent()
	{
		if (this._parentView)
		{
			return true;
		}
		if (this._parentViewID != global::uLink.NetworkViewID.unassigned)
		{
			this._parentView = global::Facepunch.NetworkView.Find(this._parentViewID);
			if (this._parentView)
			{
				this._parentMain = null;
				global::PlayerAnimation component = this._parentView.GetComponent<global::PlayerAnimation>();
				global::Socket.LocalSpace itemAttachment = component.itemAttachment;
				if (itemAttachment != null)
				{
					global::UnityEngine.Vector3 offsetFromThisSocket;
					global::UnityEngine.Quaternion rotationOffsetFromThisSocket;
					if (this.hand.parent && this.hand.parent != base.transform)
					{
						offsetFromThisSocket = base.transform.InverseTransformPoint(this.hand.position);
						global::UnityEngine.Quaternion rotation = this.hand.rotation;
						global::UnityEngine.Vector3 vector = rotation * global::UnityEngine.Vector3.forward;
						global::UnityEngine.Vector3 vector2 = rotation * global::UnityEngine.Vector3.up;
						vector = base.transform.InverseTransformDirection(vector);
						vector2 = base.transform.InverseTransformDirection(vector2);
						rotationOffsetFromThisSocket = global::UnityEngine.Quaternion.LookRotation(vector, vector2);
					}
					else
					{
						offsetFromThisSocket = this.hand.offset;
						rotationOffsetFromThisSocket = global::UnityEngine.Quaternion.Euler(this.hand.eulerRotate);
					}
					itemAttachment.AddChildWithCoords(base.transform, offsetFromThisSocket, rotationOffsetFromThisSocket);
				}
				this.FindSignalee();
				return true;
			}
		}
		this.ClearSignals();
		return false;
	}

	// Token: 0x06003B9C RID: 15260 RVA: 0x000D3BF4 File Offset: 0x000D1DF4
	protected void uLink_OnNetworkInstantiate(global::uLink.NetworkMessageInfo info)
	{
		this._parentViewID = info.networkView.initialData.ReadNetworkViewID();
		int uniqueID = info.networkView.initialData.ReadInt32();
		this._datablock = (global::HeldItemDataBlock)global::DatablockDictionary.GetByUniqueID(uniqueID);
		if (!this.CheckParent())
		{
			global::UnityEngine.Debug.Log("No parent for item rep (yet)", this);
		}
	}

	// Token: 0x06003B9D RID: 15261 RVA: 0x000D3C50 File Offset: 0x000D1E50
	[global::UnityEngine.RPC]
	protected void Mods(byte[] data)
	{
		this.ClearMods();
		global::uLink.BitStream bitStream = new global::uLink.BitStream(data, false);
		byte b = bitStream.ReadByte();
		if (b > 0)
		{
			global::CharacterStateFlags characterStateFlags = this.GetCharacterStateFlags();
			for (int i = 0; i < (int)b; i++)
			{
				int uniqueID = bitStream.ReadInt32();
				global::ItemModDataBlock itemModDataBlock = (global::ItemModDataBlock)global::DatablockDictionary.GetByUniqueID(uniqueID);
				this._itemMods.InstallMod(i, this, itemModDataBlock, characterStateFlags);
				this._modFlags |= itemModDataBlock.modFlag;
			}
		}
	}

	// Token: 0x17000B31 RID: 2865
	// (get) Token: 0x06003B9E RID: 15262 RVA: 0x000D3CD0 File Offset: 0x000D1ED0
	// (set) Token: 0x06003B9F RID: 15263 RVA: 0x000D3CDC File Offset: 0x000D1EDC
	public bool worldModels
	{
		get
		{
			return !this.worldStateDisabled;
		}
		set
		{
			if (this.worldStateDisabled == value)
			{
				this.worldStateDisabled = !this.worldStateDisabled;
				if (this.visuals != null)
				{
					for (int i = 0; i < this.visuals.Length; i++)
					{
						if (this.visuals[i])
						{
							this.visuals[i].SetActive(value);
						}
					}
				}
				if (base.renderer)
				{
					base.renderer.enabled = value;
				}
				if (value)
				{
					for (int j = 0; j < 5; j++)
					{
						this._itemMods.BindAsProxy(j, this);
					}
				}
				else
				{
					for (int k = 0; k < 5; k++)
					{
						this._itemMods.UnBindAsProxy(k, this);
					}
				}
			}
		}
	}

	// Token: 0x06003BA0 RID: 15264 RVA: 0x000D3DB0 File Offset: 0x000D1FB0
	protected virtual void StateSignalReceive(global::Character character, bool treatedAsFirst)
	{
		global::CharacterStateFlags stateFlags = character.stateFlags;
		if (this.lastCharacterStateFlags != null && this.lastCharacterStateFlags.Value.Equals(stateFlags))
		{
			return;
		}
		this.lastCharacterStateFlags = new global::CharacterStateFlags?(stateFlags);
		for (int i = 0; i < 5; i++)
		{
			if (this._itemMods[i].representation)
			{
				this._itemMods[i].representation.HandleChangedStateFlags(stateFlags, !treatedAsFirst);
			}
		}
	}

	// Token: 0x06003BA1 RID: 15265 RVA: 0x000D3E4C File Offset: 0x000D204C
	[global::UnityEngine.RPC]
	protected void InterpDestroy(global::uLink.NetworkMessageInfo info)
	{
		global::InterpTimedEvent.Queue(this, "InterpDestroy", ref info);
	}

	// Token: 0x06003BA2 RID: 15266 RVA: 0x000D3E5C File Offset: 0x000D205C
	private static string ActionRPC(int number)
	{
		switch (number)
		{
		case 1:
			return "Action1";
		case 2:
			return "Action2";
		case 3:
			return "Action3";
		default:
			throw new global::System.ArgumentOutOfRangeException("number", number, "number must be at or between 1 and 3");
		}
	}

	// Token: 0x06003BA3 RID: 15267 RVA: 0x000D3EAC File Offset: 0x000D20AC
	private static string ActionRPCBitstream(int number)
	{
		switch (number)
		{
		case 1:
			return "Action1B";
		case 2:
			return "Action2B";
		case 3:
			return "Action3B";
		default:
			throw new global::System.ArgumentOutOfRangeException("number", number, "number must be at or between 1 and 3");
		}
	}

	// Token: 0x06003BA4 RID: 15268 RVA: 0x000D3EFC File Offset: 0x000D20FC
	public void Action(int number, global::uLink.RPCMode mode)
	{
		base.networkView.RPC(global::ItemRepresentation.ActionRPC(number), mode, new object[0]);
	}

	// Token: 0x06003BA5 RID: 15269 RVA: 0x000D3F18 File Offset: 0x000D2118
	public void Action<T>(int number, global::uLink.RPCMode mode, T argument)
	{
		base.networkView.RPC<T>(global::ItemRepresentation.ActionRPC(number), mode, argument);
	}

	// Token: 0x06003BA6 RID: 15270 RVA: 0x000D3F30 File Offset: 0x000D2130
	public void Action(int number, global::uLink.RPCMode mode, params object[] arguments)
	{
		base.networkView.RPC(global::ItemRepresentation.ActionRPC(number), mode, arguments);
	}

	// Token: 0x06003BA7 RID: 15271 RVA: 0x000D3F48 File Offset: 0x000D2148
	public void Action(int number, global::uLink.NetworkPlayer target)
	{
		base.networkView.RPC(global::ItemRepresentation.ActionRPC(number), target, new object[0]);
	}

	// Token: 0x06003BA8 RID: 15272 RVA: 0x000D3F64 File Offset: 0x000D2164
	public void Action<T>(int number, global::uLink.NetworkPlayer target, T argument)
	{
		base.networkView.RPC<T>(global::ItemRepresentation.ActionRPC(number), target, argument);
	}

	// Token: 0x06003BA9 RID: 15273 RVA: 0x000D3F7C File Offset: 0x000D217C
	public void Action(int number, global::uLink.NetworkPlayer target, params object[] arguments)
	{
		base.networkView.RPC(global::ItemRepresentation.ActionRPC(number), target, arguments);
	}

	// Token: 0x06003BAA RID: 15274 RVA: 0x000D3F94 File Offset: 0x000D2194
	public void Action(int number, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets)
	{
		base.networkView.RPC(global::ItemRepresentation.ActionRPC(number), targets, new object[0]);
	}

	// Token: 0x06003BAB RID: 15275 RVA: 0x000D3FB0 File Offset: 0x000D21B0
	public void Action<T>(int number, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, T argument)
	{
		base.networkView.RPC<T>(global::ItemRepresentation.ActionRPC(number), targets, argument);
	}

	// Token: 0x06003BAC RID: 15276 RVA: 0x000D3FC8 File Offset: 0x000D21C8
	public void Action(int number, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, params object[] arguments)
	{
		base.networkView.RPC(global::ItemRepresentation.ActionRPC(number), targets, arguments);
	}

	// Token: 0x06003BAD RID: 15277 RVA: 0x000D3FE0 File Offset: 0x000D21E0
	public void ActionStream(int number, global::System.Collections.Generic.IEnumerable<global::uLink.NetworkPlayer> targets, global::uLink.BitStream stream)
	{
		base.networkView.RPC<byte[]>(global::ItemRepresentation.ActionRPCBitstream(number), targets, stream.GetDataByteArray());
	}

	// Token: 0x06003BAE RID: 15278 RVA: 0x000D4008 File Offset: 0x000D2208
	public void ActionStream(int number, global::uLink.NetworkPlayer target, global::uLink.BitStream stream)
	{
		base.networkView.RPC<byte[]>(global::ItemRepresentation.ActionRPCBitstream(number), target, stream.GetDataByteArray());
	}

	// Token: 0x06003BAF RID: 15279 RVA: 0x000D4030 File Offset: 0x000D2230
	public void ActionStream(int number, global::uLink.RPCMode mode, global::uLink.BitStream stream)
	{
		base.networkView.RPC<byte[]>(global::ItemRepresentation.ActionRPCBitstream(number), mode, stream.GetDataByteArray());
	}

	// Token: 0x06003BB0 RID: 15280 RVA: 0x000D4058 File Offset: 0x000D2258
	private void RunServerAction(int number, global::uLink.BitStream stream, ref global::uLink.NetworkMessageInfo info)
	{
		try
		{
			this.RunAction(number, stream, ref info);
		}
		catch (global::NetCull.RPCVerificationSenderException)
		{
		}
		catch (global::NetCull.RPCVerificationDropException)
		{
			if (!object.ReferenceEquals(this._item, null))
			{
				this._item.MarkDirty();
			}
		}
		catch (global::NetCull.RPCVerificationException)
		{
		}
		catch (global::System.Exception ex)
		{
			if (global::packet.loglevel > 0)
			{
				global::UnityEngine.Debug.LogException(ex);
			}
		}
	}

	// Token: 0x06003BB1 RID: 15281 RVA: 0x000D4120 File Offset: 0x000D2320
	private void RunAction(int number, global::uLink.BitStream stream, ref global::uLink.NetworkMessageInfo info)
	{
		switch (number)
		{
		case 1:
			this.datablock.DoAction1(stream, this, ref info);
			break;
		case 2:
			this.datablock.DoAction2(stream, this, ref info);
			break;
		case 3:
			this.datablock.DoAction3(stream, this, ref info);
			break;
		}
	}

	// Token: 0x06003BB2 RID: 15282 RVA: 0x000D4184 File Offset: 0x000D2384
	[global::UnityEngine.RPC]
	protected void Action1(global::uLink.BitStream stream, global::uLink.NetworkMessageInfo info)
	{
		this.RunServerAction(1, stream, ref info);
	}

	// Token: 0x06003BB3 RID: 15283 RVA: 0x000D4190 File Offset: 0x000D2390
	[global::UnityEngine.RPC]
	protected void Action2(global::uLink.BitStream stream, global::uLink.NetworkMessageInfo info)
	{
		this.RunServerAction(2, stream, ref info);
	}

	// Token: 0x06003BB4 RID: 15284 RVA: 0x000D419C File Offset: 0x000D239C
	[global::UnityEngine.RPC]
	protected void Action3(global::uLink.BitStream stream, global::uLink.NetworkMessageInfo info)
	{
		this.RunServerAction(3, stream, ref info);
	}

	// Token: 0x06003BB5 RID: 15285 RVA: 0x000D41A8 File Offset: 0x000D23A8
	[global::UnityEngine.RPC]
	protected void Action1B(byte[] data, global::uLink.NetworkMessageInfo info)
	{
		this.Action1(new global::uLink.BitStream(data, false), info);
	}

	// Token: 0x06003BB6 RID: 15286 RVA: 0x000D41B8 File Offset: 0x000D23B8
	[global::UnityEngine.RPC]
	protected void Action2B(byte[] data, global::uLink.NetworkMessageInfo info)
	{
		this.Action2(new global::uLink.BitStream(data, false), info);
	}

	// Token: 0x06003BB7 RID: 15287 RVA: 0x000D41C8 File Offset: 0x000D23C8
	[global::UnityEngine.RPC]
	protected void Action3B(byte[] data, global::uLink.NetworkMessageInfo info)
	{
		this.Action3(new global::uLink.BitStream(data, false), info);
	}

	// Token: 0x06003BB8 RID: 15288 RVA: 0x000D41D8 File Offset: 0x000D23D8
	protected virtual void OnInterpTimedEvent()
	{
		string tag = global::InterpTimedEvent.Tag;
		if (tag != null)
		{
			if (global::ItemRepresentation.<>f__switch$mapB == null)
			{
				global::ItemRepresentation.<>f__switch$mapB = new global::System.Collections.Generic.Dictionary<string, int>(4)
				{
					{
						"Action1",
						0
					},
					{
						"Action2",
						1
					},
					{
						"Action3",
						2
					},
					{
						"InterpDestroy",
						3
					}
				};
			}
			int num;
			if (global::ItemRepresentation.<>f__switch$mapB.TryGetValue(tag, out num))
			{
				int number;
				global::uLink.BitStream stream;
				switch (num)
				{
				case 0:
					number = 1;
					stream = global::InterpTimedEvent.Argument<global::uLink.BitStream>(0);
					break;
				case 1:
					number = 2;
					stream = global::InterpTimedEvent.Argument<global::uLink.BitStream>(0);
					break;
				case 2:
					number = 3;
					stream = global::InterpTimedEvent.Argument<global::uLink.BitStream>(0);
					break;
				case 3:
					global::UnityEngine.Object.Destroy(base.gameObject);
					return;
				default:
					goto IL_BF;
				}
				global::uLink.NetworkMessageInfo info = global::InterpTimedEvent.Info;
				this.RunServerAction(number, stream, ref info);
				return;
			}
		}
		IL_BF:
		global::InterpTimedEvent.MarkUnhandled();
	}

	// Token: 0x06003BB9 RID: 15289 RVA: 0x000D42BC File Offset: 0x000D24BC
	private void FindSignalee()
	{
		this._parentMain = this._parentView.idMain;
		if (this._parentMain is global::Character)
		{
			global::Character character = (global::Character)this._parentMain;
			this.SetSignalee(character);
			this._holder = character.GetLocal<global::InventoryHolder>();
			if (this._holder)
			{
				this._holder.SetItemRepresentation(this);
			}
			return;
		}
		this._holder = null;
		this.ClearSignals();
	}

	// Token: 0x06003BBA RID: 15290 RVA: 0x000D4334 File Offset: 0x000D2534
	private void ClearSignals()
	{
		if (this._characterSignalee)
		{
			this._characterSignalee.signal_state -= this.stateSignalReceive;
		}
		if (this._holder)
		{
			this._holder.ClearItemRepresentation(this);
			this._holder = null;
		}
		this._characterSignalee = null;
	}

	// Token: 0x06003BBB RID: 15291 RVA: 0x000D438C File Offset: 0x000D258C
	private void SetSignalee(global::Character signalee)
	{
		if (!signalee)
		{
			this.ClearSignals();
		}
		else
		{
			if (this._characterSignalee && this._characterSignalee == signalee)
			{
				return;
			}
			signalee.signal_state += this.stateSignalReceive;
			this._characterSignalee = signalee;
		}
	}

	// Token: 0x06003BBC RID: 15292 RVA: 0x000D43E4 File Offset: 0x000D25E4
	private void EraseModDatablock(ref global::ItemModDataBlock block)
	{
		block = null;
	}

	// Token: 0x06003BBD RID: 15293 RVA: 0x000D43EC File Offset: 0x000D25EC
	private void ClearModPair(ref global::ItemRepresentation.ItemModPair pair)
	{
		this.KillModRep(ref pair.representation, false);
		this.EraseModDatablock(ref pair.dataBlock);
		pair = default(global::ItemRepresentation.ItemModPair);
	}

	// Token: 0x06003BBE RID: 15294 RVA: 0x000D4424 File Offset: 0x000D2624
	private bool ClearMods()
	{
		bool flag = this.modLock;
		if (!this.modLock)
		{
			this._modFlags = global::ItemModFlags.Other;
			try
			{
				this.modLock = true;
				for (int i = 0; i < 5; i++)
				{
					this._itemMods.ClearModPair(i, this);
				}
			}
			finally
			{
				this.modLock = flag;
			}
			return true;
		}
		return false;
	}

	// Token: 0x06003BBF RID: 15295 RVA: 0x000D449C File Offset: 0x000D269C
	internal void ItemModRepresentationDestroyed(global::ItemModRepresentation rep)
	{
		if (this.modLock || this.destroyingRep == rep)
		{
			return;
		}
		this._itemMods.KillModForRep(rep, this, true);
	}

	// Token: 0x06003BC0 RID: 15296 RVA: 0x000D44D8 File Offset: 0x000D26D8
	private void InstallMod(ref global::ItemRepresentation.ItemModPair to, int slot, global::ItemModDataBlock datablock, global::CharacterStateFlags flags)
	{
		to.dataBlock = datablock;
		if (to.representation)
		{
			this.KillModRep(ref to.representation, false);
		}
		if (to.dataBlock.hasModRepresentation && to.dataBlock.AddModRepresentationComponent(base.gameObject, out to.representation))
		{
			to.bindState = global::ItemRepresentation.BindState.None;
			to.representation.Initialize(this, slot, flags);
			if (to.representation)
			{
				if (this.worldModels)
				{
					this._itemMods.BindAsProxy(slot, this);
				}
			}
			else
			{
				to.bindState = global::ItemRepresentation.BindState.Vacant;
				to.representation = null;
			}
		}
	}

	// Token: 0x06003BC1 RID: 15297 RVA: 0x000D4588 File Offset: 0x000D2788
	protected global::CharacterStateFlags GetCharacterStateFlags()
	{
		if (this.CheckParent() && this._parentMain is global::Character)
		{
			global::CharacterStateFlags stateFlags = ((global::Character)this._parentMain).stateFlags;
			this.lastCharacterStateFlags = new global::CharacterStateFlags?(stateFlags);
			return stateFlags;
		}
		global::CharacterStateFlags? characterStateFlags = this.lastCharacterStateFlags;
		return (characterStateFlags == null) ? default(global::CharacterStateFlags) : characterStateFlags.Value;
	}

	// Token: 0x06003BC2 RID: 15298 RVA: 0x000D45F8 File Offset: 0x000D27F8
	[global::System.Obsolete("This is dumb. The datablock shouldnt change")]
	internal void SetDataBlockFromHeldItem<T>(global::HeldItem<T> item) where T : global::HeldItemDataBlock
	{
		this._datablock = item.datablock;
	}

	// Token: 0x06003BC3 RID: 15299 RVA: 0x000D460C File Offset: 0x000D280C
	internal void _internal_bind_server_item(global::InventoryItem heldItem)
	{
		this._item = heldItem;
	}

	// Token: 0x04001E79 RID: 7801
	private global::HeldItemDataBlock _datablock;

	// Token: 0x04001E7A RID: 7802
	private global::InventoryHolder _holder;

	// Token: 0x04001E7B RID: 7803
	private global::InventoryItem _item;

	// Token: 0x04001E7C RID: 7804
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.GameObject[] visuals;

	// Token: 0x04001E7D RID: 7805
	internal global::ItemRepresentation.ItemModPairArray _itemMods;

	// Token: 0x04001E7E RID: 7806
	private global::Facepunch.NetworkView _parentView;

	// Token: 0x04001E7F RID: 7807
	private global::IDMain _parentMain;

	// Token: 0x04001E80 RID: 7808
	private global::uLink.NetworkViewID _parentViewID;

	// Token: 0x04001E81 RID: 7809
	private global::Character _characterSignalee;

	// Token: 0x04001E82 RID: 7810
	private global::ViewModel _lastViewModel;

	// Token: 0x04001E83 RID: 7811
	[global::System.NonSerialized]
	private string worldAnimationGroupNameOverride;

	// Token: 0x04001E84 RID: 7812
	public global::Socket.LocalSpace muzzle;

	// Token: 0x04001E85 RID: 7813
	public global::Socket.LocalSpace hand;

	// Token: 0x04001E86 RID: 7814
	private global::ItemModFlags _modFlags;

	// Token: 0x04001E87 RID: 7815
	private bool worldStateDisabled;

	// Token: 0x04001E88 RID: 7816
	private global::CharacterStateFlags? lastCharacterStateFlags;

	// Token: 0x04001E89 RID: 7817
	private readonly global::CharacterStateSignal stateSignalReceive;

	// Token: 0x04001E8A RID: 7818
	private bool modLock;

	// Token: 0x04001E8B RID: 7819
	[global::System.NonSerialized]
	private global::ItemModRepresentation destroyingRep;

	// Token: 0x04001E8C RID: 7820
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static global::System.Collections.Generic.Dictionary<string, int> <>f__switch$mapB;

	// Token: 0x020006CE RID: 1742
	internal struct ItemModPair
	{
		// Token: 0x04001E8D RID: 7821
		public global::ItemModDataBlock dataBlock;

		// Token: 0x04001E8E RID: 7822
		public global::ItemModRepresentation representation;

		// Token: 0x04001E8F RID: 7823
		public global::ItemRepresentation.BindState bindState;
	}

	// Token: 0x020006CF RID: 1743
	internal enum BindState : sbyte
	{
		// Token: 0x04001E91 RID: 7825
		Vacant,
		// Token: 0x04001E92 RID: 7826
		None,
		// Token: 0x04001E93 RID: 7827
		World
	}

	// Token: 0x020006D0 RID: 1744
	internal struct ItemModPairArray
	{
		// Token: 0x06003BC4 RID: 15300 RVA: 0x000D4618 File Offset: 0x000D2818
		static ItemModPairArray()
		{
		}

		// Token: 0x17000B32 RID: 2866
		public global::ItemRepresentation.ItemModPair this[int slotNumber]
		{
			get
			{
				switch (slotNumber)
				{
				case 0:
					return this.a;
				case 1:
					return this.b;
				case 2:
					return this.c;
				case 3:
					return this.d;
				case 4:
					return this.e;
				default:
					throw new global::System.IndexOutOfRangeException();
				}
			}
			set
			{
				switch (slotNumber)
				{
				case 0:
					this.a = value;
					break;
				case 1:
					this.b = value;
					break;
				case 2:
					this.c = value;
					break;
				case 3:
					this.d = value;
					break;
				case 4:
					this.e = value;
					break;
				default:
					throw new global::System.IndexOutOfRangeException();
				}
			}
		}

		// Token: 0x06003BC7 RID: 15303 RVA: 0x000D46E4 File Offset: 0x000D28E4
		public global::ItemModDataBlock ItemModDataBlock(int slotNumber)
		{
			switch (slotNumber)
			{
			case 0:
				return this.a.dataBlock;
			case 1:
				return this.b.dataBlock;
			case 2:
				return this.c.dataBlock;
			case 3:
				return this.d.dataBlock;
			case 4:
				return this.e.dataBlock;
			default:
				throw new global::System.IndexOutOfRangeException();
			}
		}

		// Token: 0x06003BC8 RID: 15304 RVA: 0x000D4754 File Offset: 0x000D2954
		public void BindAsProxy(int slotNumber, global::ItemRepresentation itemRep)
		{
			switch (slotNumber)
			{
			case 0:
				itemRep.BindModAsProxy(ref this.a);
				break;
			case 1:
				itemRep.BindModAsProxy(ref this.b);
				break;
			case 2:
				itemRep.BindModAsProxy(ref this.c);
				break;
			case 3:
				itemRep.BindModAsProxy(ref this.d);
				break;
			case 4:
				itemRep.BindModAsProxy(ref this.e);
				break;
			default:
				throw new global::System.IndexOutOfRangeException();
			}
		}

		// Token: 0x06003BC9 RID: 15305 RVA: 0x000D47E0 File Offset: 0x000D29E0
		public void UnBindAsProxy(int slotNumber, global::ItemRepresentation itemRep)
		{
			switch (slotNumber)
			{
			case 0:
				itemRep.UnBindModAsProxy(ref this.a);
				break;
			case 1:
				itemRep.UnBindModAsProxy(ref this.b);
				break;
			case 2:
				itemRep.UnBindModAsProxy(ref this.c);
				break;
			case 3:
				itemRep.UnBindModAsProxy(ref this.d);
				break;
			case 4:
				itemRep.UnBindModAsProxy(ref this.e);
				break;
			default:
				throw new global::System.IndexOutOfRangeException();
			}
		}

		// Token: 0x06003BCA RID: 15306 RVA: 0x000D486C File Offset: 0x000D2A6C
		public void ClearModPair(int slotNumber, global::ItemRepresentation owner)
		{
			switch (slotNumber)
			{
			case 0:
				owner.ClearModPair(ref this.a);
				break;
			case 1:
				owner.ClearModPair(ref this.b);
				break;
			case 2:
				owner.ClearModPair(ref this.c);
				break;
			case 3:
				owner.ClearModPair(ref this.d);
				break;
			case 4:
				owner.ClearModPair(ref this.e);
				break;
			default:
				throw new global::System.IndexOutOfRangeException();
			}
		}

		// Token: 0x06003BCB RID: 15307 RVA: 0x000D48F8 File Offset: 0x000D2AF8
		private static bool KillModForRep(ref global::ItemRepresentation.ItemModPair pair, global::ItemModRepresentation modRep, global::ItemRepresentation owner, bool fromCallback)
		{
			if (pair.representation == modRep)
			{
				owner.KillModRep(ref pair.representation, fromCallback);
				return true;
			}
			return true;
		}

		// Token: 0x06003BCC RID: 15308 RVA: 0x000D491C File Offset: 0x000D2B1C
		public bool KillModForRep(global::ItemModRepresentation modRep, global::ItemRepresentation owner, bool fromCallback)
		{
			switch (modRep.modSlot)
			{
			case 0:
				return global::ItemRepresentation.ItemModPairArray.KillModForRep(ref this.a, modRep, owner, fromCallback);
			case 1:
				return global::ItemRepresentation.ItemModPairArray.KillModForRep(ref this.b, modRep, owner, fromCallback);
			case 2:
				return global::ItemRepresentation.ItemModPairArray.KillModForRep(ref this.c, modRep, owner, fromCallback);
			case 3:
				return global::ItemRepresentation.ItemModPairArray.KillModForRep(ref this.d, modRep, owner, fromCallback);
			case 4:
				return global::ItemRepresentation.ItemModPairArray.KillModForRep(ref this.e, modRep, owner, fromCallback);
			default:
				throw new global::System.IndexOutOfRangeException();
			}
		}

		// Token: 0x06003BCD RID: 15309 RVA: 0x000D49A0 File Offset: 0x000D2BA0
		public void InstallMod(int slotNumber, global::ItemRepresentation owner, global::ItemModDataBlock datablock, global::CharacterStateFlags flags)
		{
			switch (slotNumber)
			{
			case 0:
				owner.InstallMod(ref this.a, 0, datablock, flags);
				break;
			case 1:
				owner.InstallMod(ref this.b, 1, datablock, flags);
				break;
			case 2:
				owner.InstallMod(ref this.c, 2, datablock, flags);
				break;
			case 3:
				owner.InstallMod(ref this.d, 3, datablock, flags);
				break;
			case 4:
				owner.InstallMod(ref this.e, 4, datablock, flags);
				break;
			default:
				throw new global::System.IndexOutOfRangeException();
			}
		}

		// Token: 0x04001E94 RID: 7828
		private const int internalPairCount = 5;

		// Token: 0x04001E95 RID: 7829
		private global::ItemRepresentation.ItemModPair a;

		// Token: 0x04001E96 RID: 7830
		private global::ItemRepresentation.ItemModPair b;

		// Token: 0x04001E97 RID: 7831
		private global::ItemRepresentation.ItemModPair c;

		// Token: 0x04001E98 RID: 7832
		private global::ItemRepresentation.ItemModPair d;

		// Token: 0x04001E99 RID: 7833
		private global::ItemRepresentation.ItemModPair e;
	}
}
