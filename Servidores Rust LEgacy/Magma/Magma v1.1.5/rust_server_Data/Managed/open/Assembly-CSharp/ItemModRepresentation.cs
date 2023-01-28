using System;
using UnityEngine;

// Token: 0x020006CA RID: 1738
public class ItemModRepresentation : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06003B7F RID: 15231 RVA: 0x000D350C File Offset: 0x000D170C
	public ItemModRepresentation()
	{
		if (base.GetType() != typeof(global::ItemModRepresentation))
		{
			this.caps = (global::ItemModRepresentation.Caps.Initialize | global::ItemModRepresentation.Caps.BindStateFlags | global::ItemModRepresentation.Caps.Shutdown);
		}
		else
		{
			this.caps = (global::ItemModRepresentation.Caps)0;
		}
	}

	// Token: 0x06003B80 RID: 15232 RVA: 0x000D3548 File Offset: 0x000D1748
	protected ItemModRepresentation(global::ItemModRepresentation.Caps caps)
	{
		this.caps = caps;
	}

	// Token: 0x17000B28 RID: 2856
	// (get) Token: 0x06003B81 RID: 15233 RVA: 0x000D3560 File Offset: 0x000D1760
	public global::ItemRepresentation itemRep
	{
		get
		{
			return this._itemRep;
		}
	}

	// Token: 0x06003B82 RID: 15234 RVA: 0x000D3568 File Offset: 0x000D1768
	public bool Item<IInventoryItemInterface>(out IInventoryItemInterface item) where IInventoryItemInterface : class, global::IInventoryItem
	{
		if (this._itemRep)
		{
			return this._itemRep.Item<IInventoryItemInterface>(out item);
		}
		item = (IInventoryItemInterface)((object)null);
		return false;
	}

	// Token: 0x17000B29 RID: 2857
	// (get) Token: 0x06003B83 RID: 15235 RVA: 0x000D35A0 File Offset: 0x000D17A0
	public global::HeldItemDataBlock itemDatablock
	{
		get
		{
			return (!this._itemRep) ? null : this._itemRep.datablock;
		}
	}

	// Token: 0x17000B2A RID: 2858
	// (get) Token: 0x06003B84 RID: 15236 RVA: 0x000D35C4 File Offset: 0x000D17C4
	public global::ItemModDataBlock modDataBlock
	{
		get
		{
			return this._itemRep._itemMods.ItemModDataBlock(this._modSlot);
		}
	}

	// Token: 0x17000B2B RID: 2859
	// (get) Token: 0x06003B85 RID: 15237 RVA: 0x000D35DC File Offset: 0x000D17DC
	public int modSlot
	{
		get
		{
			return this._modSlot;
		}
	}

	// Token: 0x17000B2C RID: 2860
	// (get) Token: 0x06003B86 RID: 15238 RVA: 0x000D35E4 File Offset: 0x000D17E4
	public bool initialized
	{
		get
		{
			return this._modSlot != -1;
		}
	}

	// Token: 0x17000B2D RID: 2861
	// (get) Token: 0x06003B87 RID: 15239 RVA: 0x000D35F4 File Offset: 0x000D17F4
	public bool destroyed
	{
		get
		{
			return this._modSlot == -2;
		}
	}

	// Token: 0x06003B88 RID: 15240 RVA: 0x000D3600 File Offset: 0x000D1800
	internal void Initialize(global::ItemRepresentation itemRep, int modSlot, global::CharacterStateFlags flags)
	{
		if (this._modSlot == -1)
		{
			if (!itemRep)
			{
				throw new global::System.ArgumentOutOfRangeException("itemRep", itemRep, "!itemRep");
			}
			if (modSlot < 0 || modSlot >= 5)
			{
				throw new global::System.ArgumentOutOfRangeException("modSlot", modSlot, "modSlot<0||modSlot>=MAX_SUPPORTED_ITEM_MODS");
			}
			this._itemRep = itemRep;
			this._modSlot = modSlot;
			if ((byte)(this.caps & global::ItemModRepresentation.Caps.Initialize) == 1)
			{
				try
				{
					this.Initialize();
				}
				catch (global::System.Exception)
				{
					this._itemRep = null;
					this._modSlot = -1;
					throw;
				}
			}
			this.HandleChangedStateFlags(flags, false);
		}
		else
		{
			if (this._modSlot == -2)
			{
				throw new global::System.InvalidOperationException("This ItemModRepresentation has been destroyed");
			}
			if (itemRep != this._itemRep || (modSlot < 0 && modSlot < 5 && modSlot != this._modSlot))
			{
				throw new global::System.InvalidOperationException(string.Format("The ItemModRepresentation was already initialized with {{\"item\":\"{0}\",\"slot\":{1}}} and cannot be re-initialized to use {{\"item\":\"{2|\",\"slot\":{3}}}", new object[]
				{
					this._itemRep,
					this._modSlot,
					itemRep,
					modSlot
				}));
			}
		}
	}

	// Token: 0x06003B89 RID: 15241 RVA: 0x000D3740 File Offset: 0x000D1940
	internal void HandleChangedStateFlags(global::CharacterStateFlags flags, bool notFromLoading)
	{
		if ((byte)(this.caps & global::ItemModRepresentation.Caps.BindStateFlags) == 2 && (this._lastFlags == null || !this._lastFlags.Value.Equals(flags)))
		{
			this.BindStateFlags(flags, (!notFromLoading) ? global::ItemModRepresentation.Reason.Initialization : global::ItemModRepresentation.Reason.Explicit);
			this._lastFlags = new global::CharacterStateFlags?(flags);
		}
	}

	// Token: 0x06003B8A RID: 15242 RVA: 0x000D37A8 File Offset: 0x000D19A8
	[global::System.Obsolete("Do not use OnDestroy in implementing classes. Instead override Shutdown() and specify Caps.Shutdown in the constructor!")]
	private void OnDestroy()
	{
		if (this._modSlot != -2)
		{
			try
			{
				if (this._modSlot != -1)
				{
					if (this._itemRep)
					{
						try
						{
							if ((byte)(this.caps & global::ItemModRepresentation.Caps.Shutdown) == 0x80)
							{
								try
								{
									this.Shutdown();
								}
								catch (global::System.Exception ex)
								{
									global::UnityEngine.Debug.LogError(ex, this);
								}
							}
							try
							{
								this._itemRep.ItemModRepresentationDestroyed(this);
							}
							catch (global::System.Exception ex2)
							{
								global::UnityEngine.Debug.LogError(ex2, this);
							}
						}
						finally
						{
							this._itemRep = null;
						}
					}
					else
					{
						this._itemRep = null;
					}
				}
			}
			finally
			{
				this._modSlot = -2;
			}
		}
	}

	// Token: 0x06003B8B RID: 15243 RVA: 0x000D38B8 File Offset: 0x000D1AB8
	protected virtual void Initialize()
	{
	}

	// Token: 0x06003B8C RID: 15244 RVA: 0x000D38BC File Offset: 0x000D1ABC
	protected virtual void BindStateFlags(global::CharacterStateFlags flags, global::ItemModRepresentation.Reason reason)
	{
	}

	// Token: 0x06003B8D RID: 15245 RVA: 0x000D38C0 File Offset: 0x000D1AC0
	protected virtual void Shutdown()
	{
	}

	// Token: 0x04001E6A RID: 7786
	protected const global::ItemModRepresentation.Caps kAllCaps = global::ItemModRepresentation.Caps.Initialize | global::ItemModRepresentation.Caps.BindStateFlags | global::ItemModRepresentation.Caps.Shutdown;

	// Token: 0x04001E6B RID: 7787
	protected const global::ItemModRepresentation.Caps kNoCaps = (global::ItemModRepresentation.Caps)0;

	// Token: 0x04001E6C RID: 7788
	private global::ItemRepresentation _itemRep;

	// Token: 0x04001E6D RID: 7789
	private int _modSlot = -1;

	// Token: 0x04001E6E RID: 7790
	[global::System.NonSerialized]
	public global::UnityEngine.GameObject instantiatedThing;

	// Token: 0x04001E6F RID: 7791
	[global::System.NonSerialized]
	protected readonly global::ItemModRepresentation.Caps caps;

	// Token: 0x04001E70 RID: 7792
	private global::CharacterStateFlags? _lastFlags;

	// Token: 0x020006CB RID: 1739
	[global::System.Flags]
	protected enum Caps : byte
	{
		// Token: 0x04001E72 RID: 7794
		Initialize = 1,
		// Token: 0x04001E73 RID: 7795
		BindStateFlags = 2,
		// Token: 0x04001E74 RID: 7796
		Shutdown = 0x80
	}

	// Token: 0x020006CC RID: 1740
	protected enum Reason
	{
		// Token: 0x04001E76 RID: 7798
		Initialization,
		// Token: 0x04001E77 RID: 7799
		Implicit,
		// Token: 0x04001E78 RID: 7800
		Explicit
	}
}
