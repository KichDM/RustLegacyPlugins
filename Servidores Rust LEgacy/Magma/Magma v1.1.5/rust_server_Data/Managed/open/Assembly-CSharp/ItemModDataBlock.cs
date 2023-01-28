using System;
using System.Collections.Generic;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x020006A6 RID: 1702
public class ItemModDataBlock : global::ItemDataBlock
{
	// Token: 0x0600389F RID: 14495 RVA: 0x000CF3A4 File Offset: 0x000CD5A4
	protected ItemModDataBlock(global::System.Type minimumModRepresentationType)
	{
		if (!typeof(global::ItemModRepresentation).IsAssignableFrom(minimumModRepresentationType))
		{
			throw new global::System.ArgumentOutOfRangeException("minimumModRepresentationType", minimumModRepresentationType, "!typeof(ItemModRepresentation).IsAssignableFrom(minimumModRepresentationType)");
		}
		this.minimumModRepresentationType = minimumModRepresentationType;
	}

	// Token: 0x060038A0 RID: 14496 RVA: 0x000CF3F0 File Offset: 0x000CD5F0
	public ItemModDataBlock() : this(typeof(global::ItemModRepresentation))
	{
	}

	// Token: 0x060038A1 RID: 14497 RVA: 0x000CF404 File Offset: 0x000CD604
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::ItemModDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x17000B07 RID: 2823
	// (get) Token: 0x060038A2 RID: 14498 RVA: 0x000CF40C File Offset: 0x000CD60C
	public bool hasModRepresentation
	{
		get
		{
			return !string.IsNullOrEmpty(this.modRepresentationTypeName);
		}
	}

	// Token: 0x060038A3 RID: 14499 RVA: 0x000CF41C File Offset: 0x000CD61C
	internal bool AddModRepresentationComponent(global::UnityEngine.GameObject gameObject, out global::ItemModRepresentation rep)
	{
		if (this.hasModRepresentation)
		{
			global::ItemModDataBlock.g.TypePair typePair;
			if (!global::ItemModDataBlock.g.cachedTypeLookup.TryGetValue(base.name, out typePair) || typePair.typeString != this.modRepresentationTypeName)
			{
				typePair = new global::ItemModDataBlock.g.TypePair
				{
					typeString = this.modRepresentationTypeName
				};
				typePair.type = global::UnityEngine.Types.GetType(typePair.typeString, "Assembly-CSharp");
				if (typePair.type == null)
				{
					global::UnityEngine.Debug.LogError(string.Format("modRepresentationTypeName:{0} resolves to no type", typePair.typeString), this);
				}
				else if (!this.minimumModRepresentationType.IsAssignableFrom(typePair.type))
				{
					global::UnityEngine.Debug.LogError(string.Format("modRepresentationTypeName:{0} resolved to {1} but {1} is not a {2}", typePair.typeString, typePair.type, this.minimumModRepresentationType), this);
					typePair.type = null;
				}
				global::ItemModDataBlock.g.cachedTypeLookup[base.name] = typePair;
			}
			if (typePair.type != null)
			{
				rep = (global::ItemModRepresentation)gameObject.AddComponent(typePair.type);
				if (rep)
				{
					this.CustomizeItemModRepresentation(rep);
					if (rep)
					{
						return true;
					}
				}
			}
		}
		rep = null;
		return false;
	}

	// Token: 0x060038A4 RID: 14500 RVA: 0x000CF548 File Offset: 0x000CD748
	internal void BindAsProxy(global::ItemModRepresentation rep)
	{
		this.InstallToItemModRepresentation(rep);
	}

	// Token: 0x060038A5 RID: 14501 RVA: 0x000CF554 File Offset: 0x000CD754
	internal void UnBindAsProxy(global::ItemModRepresentation rep)
	{
		this.UninstallFromItemModRepresentation(rep);
	}

	// Token: 0x060038A6 RID: 14502 RVA: 0x000CF560 File Offset: 0x000CD760
	protected virtual void CustomizeItemModRepresentation(global::ItemModRepresentation rep)
	{
	}

	// Token: 0x060038A7 RID: 14503 RVA: 0x000CF564 File Offset: 0x000CD764
	protected virtual void InstallToItemModRepresentation(global::ItemModRepresentation rep)
	{
	}

	// Token: 0x060038A8 RID: 14504 RVA: 0x000CF568 File Offset: 0x000CD768
	protected virtual void UninstallFromItemModRepresentation(global::ItemModRepresentation rep)
	{
	}

	// Token: 0x060038A9 RID: 14505 RVA: 0x000CF56C File Offset: 0x000CD76C
	protected virtual bool InstallToViewModel(ref global::ModViewModelAddArgs a)
	{
		return false;
	}

	// Token: 0x060038AA RID: 14506 RVA: 0x000CF570 File Offset: 0x000CD770
	protected virtual void UninstallFromViewModel(ref global::ModViewModelRemoveArgs a)
	{
	}

	// Token: 0x060038AB RID: 14507 RVA: 0x000CF574 File Offset: 0x000CD774
	protected void OnDestroy()
	{
	}

	// Token: 0x060038AC RID: 14508 RVA: 0x000CF578 File Offset: 0x000CD778
	protected override void SecureWriteMemberValues(global::uLink.BitStream stream)
	{
		base.SecureWriteMemberValues(stream);
		stream.Write<global::ItemModFlags>(this.modFlag, new object[0]);
		stream.Write<string>(this.modRepresentationTypeName, new object[0]);
	}

	// Token: 0x04001E0A RID: 7690
	[global::UnityEngine.SerializeField]
	private string modRepresentationTypeName = "ItemModRepresentation";

	// Token: 0x04001E0B RID: 7691
	public global::ItemModFlags modFlag;

	// Token: 0x04001E0C RID: 7692
	public global::UnityEngine.AudioClip onSound;

	// Token: 0x04001E0D RID: 7693
	public global::UnityEngine.AudioClip offSound;

	// Token: 0x04001E0E RID: 7694
	private readonly global::System.Type minimumModRepresentationType;

	// Token: 0x020006A7 RID: 1703
	private sealed class ITEM_TYPE : global::ItemModItem<global::ItemModDataBlock>, global::IInventoryItem, global::IItemModItem
	{
		// Token: 0x060038AD RID: 14509 RVA: 0x000CF5A8 File Offset: 0x000CD7A8
		public ITEM_TYPE(global::ItemModDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000B08 RID: 2824
		// (get) Token: 0x060038AE RID: 14510 RVA: 0x000CF5B4 File Offset: 0x000CD7B4
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x060038AF RID: 14511 RVA: 0x000CF5BC File Offset: 0x000CD7BC
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x060038B0 RID: 14512 RVA: 0x000CF5C4 File Offset: 0x000CD7C4
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x060038B1 RID: 14513 RVA: 0x000CF5CC File Offset: 0x000CD7CC
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x060038B2 RID: 14514 RVA: 0x000CF5D4 File Offset: 0x000CD7D4
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x060038B3 RID: 14515 RVA: 0x000CF5E0 File Offset: 0x000CD7E0
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x060038B4 RID: 14516 RVA: 0x000CF5EC File Offset: 0x000CD7EC
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x060038B5 RID: 14517 RVA: 0x000CF5F8 File Offset: 0x000CD7F8
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x060038B6 RID: 14518 RVA: 0x000CF604 File Offset: 0x000CD804
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x060038B7 RID: 14519 RVA: 0x000CF610 File Offset: 0x000CD810
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x060038B8 RID: 14520 RVA: 0x000CF61C File Offset: 0x000CD81C
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x060038B9 RID: 14521 RVA: 0x000CF628 File Offset: 0x000CD828
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x060038BA RID: 14522 RVA: 0x000CF634 File Offset: 0x000CD834
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x060038BB RID: 14523 RVA: 0x000CF63C File Offset: 0x000CD83C
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x060038BC RID: 14524 RVA: 0x000CF648 File Offset: 0x000CD848
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x060038BD RID: 14525 RVA: 0x000CF654 File Offset: 0x000CD854
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x060038BE RID: 14526 RVA: 0x000CF65C File Offset: 0x000CD85C
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x060038BF RID: 14527 RVA: 0x000CF664 File Offset: 0x000CD864
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x060038C0 RID: 14528 RVA: 0x000CF66C File Offset: 0x000CD86C
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x060038C1 RID: 14529 RVA: 0x000CF674 File Offset: 0x000CD874
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x060038C2 RID: 14530 RVA: 0x000CF67C File Offset: 0x000CD87C
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x060038C3 RID: 14531 RVA: 0x000CF684 File Offset: 0x000CD884
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x060038C4 RID: 14532 RVA: 0x000CF68C File Offset: 0x000CD88C
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x060038C5 RID: 14533 RVA: 0x000CF698 File Offset: 0x000CD898
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x060038C6 RID: 14534 RVA: 0x000CF6A0 File Offset: 0x000CD8A0
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x060038C7 RID: 14535 RVA: 0x000CF6A8 File Offset: 0x000CD8A8
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x060038C8 RID: 14536 RVA: 0x000CF6B0 File Offset: 0x000CD8B0
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x060038C9 RID: 14537 RVA: 0x000CF6B8 File Offset: 0x000CD8B8
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x060038CA RID: 14538 RVA: 0x000CF6C0 File Offset: 0x000CD8C0
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x060038CB RID: 14539 RVA: 0x000CF6C8 File Offset: 0x000CD8C8
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}

	// Token: 0x020006A8 RID: 1704
	private static class g
	{
		// Token: 0x060038CC RID: 14540 RVA: 0x000CF6D0 File Offset: 0x000CD8D0
		// Note: this type is marked as 'beforefieldinit'.
		static g()
		{
		}

		// Token: 0x04001E0F RID: 7695
		public static global::System.Collections.Generic.Dictionary<string, global::ItemModDataBlock.g.TypePair> cachedTypeLookup = new global::System.Collections.Generic.Dictionary<string, global::ItemModDataBlock.g.TypePair>();

		// Token: 0x020006A9 RID: 1705
		public class TypePair
		{
			// Token: 0x060038CD RID: 14541 RVA: 0x000CF6DC File Offset: 0x000CD8DC
			public TypePair()
			{
			}

			// Token: 0x04001E10 RID: 7696
			public string typeString;

			// Token: 0x04001E11 RID: 7697
			public global::System.Type type;
		}
	}
}
