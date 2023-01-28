using System;
using Facepunch;
using Magma;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x020006B2 RID: 1714
public class StructureComponentDataBlock : global::HeldItemDataBlock
{
	// Token: 0x06003981 RID: 14721 RVA: 0x000D0400 File Offset: 0x000CE600
	public StructureComponentDataBlock()
	{
	}

	// Token: 0x06003982 RID: 14722 RVA: 0x000D0408 File Offset: 0x000CE608
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::StructureComponentDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x17000B0C RID: 2828
	// (get) Token: 0x06003983 RID: 14723 RVA: 0x000D0410 File Offset: 0x000CE610
	public global::StructureComponent structureToPlacePrefab
	{
		get
		{
			if (!this._loadedStructureToPlace && global::UnityEngine.Application.isPlaying)
			{
				global::NetCull.LoadPrefabScript<global::StructureComponent>(this.structureToPlaceName, out this._structureToPlace);
				this._loadedStructureToPlace = true;
			}
			return this._structureToPlace;
		}
	}

	// Token: 0x06003984 RID: 14724 RVA: 0x000D0454 File Offset: 0x000CE654
	public bool MasterFromRay(global::UnityEngine.Ray ray)
	{
		foreach (global::StructureMaster structureMaster in global::StructureMaster.RayTestStructures(ray))
		{
			if (structureMaster)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06003985 RID: 14725 RVA: 0x000D0490 File Offset: 0x000CE690
	public bool CheckBlockers(global::UnityEngine.Vector3 pos)
	{
		if (this._structureToPlace.type == global::StructureComponent.StructureComponentType.Foundation)
		{
			global::UnityEngine.Collider[] array = global::UnityEngine.Physics.OverlapSphere(pos, 12f, 0x10360401);
			foreach (global::UnityEngine.Collider collider in array)
			{
				global::IDMain main = global::IDBase.GetMain(collider.gameObject);
				if (main)
				{
					float num = global::TransformHelpers.Dist2D(main.transform.position, pos);
					if (main.GetComponent<global::SpikeWall>() && num < 5f)
					{
						return false;
					}
				}
			}
		}
		return global::NoPlacementZone.ValidPos(pos);
	}

	// Token: 0x06003986 RID: 14726 RVA: 0x000D0534 File Offset: 0x000CE734
	public override void DoAction1(global::uLink.BitStream stream, global::ItemRepresentation rep, ref global::uLink.NetworkMessageInfo info)
	{
		global::NetCull.VerifyRPC(ref info, false);
		global::IStructureComponentItem structureComponentItem;
		if (!rep.Item<global::IStructureComponentItem>(out structureComponentItem) || structureComponentItem.uses <= 0)
		{
			return;
		}
		global::StructureComponent structureToPlacePrefab = this.structureToPlacePrefab;
		global::UnityEngine.Vector3 vector = stream.ReadVector3();
		global::UnityEngine.Vector3 vector2 = stream.ReadVector3();
		global::UnityEngine.Vector3 vector3 = stream.ReadVector3();
		global::UnityEngine.Quaternion quaternion = stream.ReadQuaternion();
		global::uLink.NetworkViewID networkViewID = stream.ReadNetworkViewID();
		global::StructureMaster structureMaster = null;
		if (networkViewID == global::uLink.NetworkViewID.unassigned)
		{
			if (this.MasterFromRay(new global::UnityEngine.Ray(vector, vector2)))
			{
				return;
			}
			if (structureToPlacePrefab.type != global::StructureComponent.StructureComponentType.Foundation)
			{
				global::UnityEngine.Debug.Log("ERROR, tried to place non foundation structure on terrain!");
			}
			else
			{
				structureMaster = global::NetCull.InstantiateClassic<global::StructureMaster>(global::Facepunch.Bundling.Load<global::StructureMaster>("content/structures/StructureMasterPrefab"), vector3, quaternion, 0);
				structureMaster.SetupCreator(structureComponentItem.controllable);
			}
		}
		else
		{
			structureMaster = global::uLink.NetworkView.Find(networkViewID).gameObject.GetComponent<global::StructureMaster>();
		}
		if (structureMaster == null)
		{
			global::UnityEngine.Debug.Log("NO master, something seriously wrong");
			return;
		}
		if (!this._structureToPlace.CheckLocation(structureMaster, vector3, quaternion))
		{
			return;
		}
		if (!this.CheckBlockers(vector3))
		{
			return;
		}
		global::StructureComponent component = global::NetCull.InstantiateStatic(this.structureToPlaceName, vector3, quaternion).GetComponent<global::StructureComponent>();
		if (component)
		{
			structureMaster.AddStructureComponent(component);
			global::Magma.Hooks.EntityDeployed(component);
			int num = 1;
			if (structureComponentItem.Consume(ref num))
			{
				structureComponentItem.inventory.RemoveItem(structureComponentItem.slot);
			}
		}
	}

	// Token: 0x04001E24 RID: 7716
	public string structureToPlaceName;

	// Token: 0x04001E25 RID: 7717
	[global::System.NonSerialized]
	private global::StructureComponent _structureToPlace;

	// Token: 0x04001E26 RID: 7718
	[global::System.NonSerialized]
	private bool _loadedStructureToPlace;

	// Token: 0x04001E27 RID: 7719
	public global::UnityEngine.Material overrideMat;

	// Token: 0x020006B3 RID: 1715
	private sealed class ITEM_TYPE : global::StructureComponentItem<global::StructureComponentDataBlock>, global::IHeldItem, global::IInventoryItem, global::IStructureComponentItem
	{
		// Token: 0x06003987 RID: 14727 RVA: 0x000D06A0 File Offset: 0x000CE8A0
		public ITEM_TYPE(global::StructureComponentDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000B0D RID: 2829
		// (get) Token: 0x06003988 RID: 14728 RVA: 0x000D06AC File Offset: 0x000CE8AC
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x06003989 RID: 14729 RVA: 0x000D06B4 File Offset: 0x000CE8B4
		void SetTotalModSlotCount(int count)
		{
			base.SetTotalModSlotCount(count);
		}

		// Token: 0x0600398A RID: 14730 RVA: 0x000D06C0 File Offset: 0x000CE8C0
		void SetUsedModSlotCount(int count)
		{
			base.SetUsedModSlotCount(count);
		}

		// Token: 0x0600398B RID: 14731 RVA: 0x000D06CC File Offset: 0x000CE8CC
		void AddMod(global::ItemModDataBlock mod)
		{
			base.AddMod(mod);
		}

		// Token: 0x0600398C RID: 14732 RVA: 0x000D06D8 File Offset: 0x000CE8D8
		int FindMod(global::ItemModDataBlock mod)
		{
			return base.FindMod(mod);
		}

		// Token: 0x0600398D RID: 14733 RVA: 0x000D06E4 File Offset: 0x000CE8E4
		void OnActivate()
		{
			base.OnActivate();
		}

		// Token: 0x0600398E RID: 14734 RVA: 0x000D06EC File Offset: 0x000CE8EC
		void OnDeactivate()
		{
			base.OnDeactivate();
		}

		// Token: 0x0600398F RID: 14735 RVA: 0x000D06F4 File Offset: 0x000CE8F4
		global::ViewModel get_viewModelInstance()
		{
			return base.viewModelInstance;
		}

		// Token: 0x06003990 RID: 14736 RVA: 0x000D06FC File Offset: 0x000CE8FC
		global::ItemRepresentation get_itemRepresentation()
		{
			return base.itemRepresentation;
		}

		// Token: 0x06003991 RID: 14737 RVA: 0x000D0704 File Offset: 0x000CE904
		void set_itemRepresentation(global::ItemRepresentation value)
		{
			base.itemRepresentation = value;
		}

		// Token: 0x06003992 RID: 14738 RVA: 0x000D0710 File Offset: 0x000CE910
		bool get_canActivate()
		{
			return base.canActivate;
		}

		// Token: 0x06003993 RID: 14739 RVA: 0x000D0718 File Offset: 0x000CE918
		bool get_canDeactivate()
		{
			return base.canDeactivate;
		}

		// Token: 0x06003994 RID: 14740 RVA: 0x000D0720 File Offset: 0x000CE920
		global::ItemModFlags get_modFlags()
		{
			return base.modFlags;
		}

		// Token: 0x06003995 RID: 14741 RVA: 0x000D0728 File Offset: 0x000CE928
		global::ItemModDataBlock[] get_itemMods()
		{
			return base.itemMods;
		}

		// Token: 0x06003996 RID: 14742 RVA: 0x000D0730 File Offset: 0x000CE930
		int get_totalModSlots()
		{
			return base.totalModSlots;
		}

		// Token: 0x06003997 RID: 14743 RVA: 0x000D0738 File Offset: 0x000CE938
		int get_usedModSlots()
		{
			return base.usedModSlots;
		}

		// Token: 0x06003998 RID: 14744 RVA: 0x000D0740 File Offset: 0x000CE940
		int get_freeModSlots()
		{
			return base.freeModSlots;
		}

		// Token: 0x06003999 RID: 14745 RVA: 0x000D0748 File Offset: 0x000CE948
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x0600399A RID: 14746 RVA: 0x000D0750 File Offset: 0x000CE950
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x0600399B RID: 14747 RVA: 0x000D0758 File Offset: 0x000CE958
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x0600399C RID: 14748 RVA: 0x000D0760 File Offset: 0x000CE960
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x0600399D RID: 14749 RVA: 0x000D076C File Offset: 0x000CE96C
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x0600399E RID: 14750 RVA: 0x000D0778 File Offset: 0x000CE978
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x0600399F RID: 14751 RVA: 0x000D0784 File Offset: 0x000CE984
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x060039A0 RID: 14752 RVA: 0x000D0790 File Offset: 0x000CE990
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x060039A1 RID: 14753 RVA: 0x000D079C File Offset: 0x000CE99C
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x060039A2 RID: 14754 RVA: 0x000D07A8 File Offset: 0x000CE9A8
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x060039A3 RID: 14755 RVA: 0x000D07B4 File Offset: 0x000CE9B4
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x060039A4 RID: 14756 RVA: 0x000D07C0 File Offset: 0x000CE9C0
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x060039A5 RID: 14757 RVA: 0x000D07C8 File Offset: 0x000CE9C8
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x060039A6 RID: 14758 RVA: 0x000D07D4 File Offset: 0x000CE9D4
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x060039A7 RID: 14759 RVA: 0x000D07E0 File Offset: 0x000CE9E0
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x060039A8 RID: 14760 RVA: 0x000D07E8 File Offset: 0x000CE9E8
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x060039A9 RID: 14761 RVA: 0x000D07F0 File Offset: 0x000CE9F0
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x060039AA RID: 14762 RVA: 0x000D07F8 File Offset: 0x000CE9F8
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x060039AB RID: 14763 RVA: 0x000D0800 File Offset: 0x000CEA00
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x060039AC RID: 14764 RVA: 0x000D0808 File Offset: 0x000CEA08
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x060039AD RID: 14765 RVA: 0x000D0810 File Offset: 0x000CEA10
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x060039AE RID: 14766 RVA: 0x000D0818 File Offset: 0x000CEA18
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x060039AF RID: 14767 RVA: 0x000D0824 File Offset: 0x000CEA24
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x060039B0 RID: 14768 RVA: 0x000D082C File Offset: 0x000CEA2C
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x060039B1 RID: 14769 RVA: 0x000D0834 File Offset: 0x000CEA34
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x060039B2 RID: 14770 RVA: 0x000D083C File Offset: 0x000CEA3C
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x060039B3 RID: 14771 RVA: 0x000D0844 File Offset: 0x000CEA44
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x060039B4 RID: 14772 RVA: 0x000D084C File Offset: 0x000CEA4C
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x060039B5 RID: 14773 RVA: 0x000D0854 File Offset: 0x000CEA54
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}
}
