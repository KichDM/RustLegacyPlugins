using System;
using Facepunch.MeshBatch;
using Rust;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x020006AC RID: 1708
public class ResourceTypeItemDataBlock : global::ItemDataBlock
{
	// Token: 0x060038D2 RID: 14546 RVA: 0x000CF734 File Offset: 0x000CD934
	public ResourceTypeItemDataBlock()
	{
	}

	// Token: 0x060038D3 RID: 14547 RVA: 0x000CF754 File Offset: 0x000CD954
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::ResourceTypeItemDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x060038D4 RID: 14548 RVA: 0x000CF75C File Offset: 0x000CD95C
	public override string GetItemDescription()
	{
		return "A type of resource";
	}

	// Token: 0x060038D5 RID: 14549 RVA: 0x000CF764 File Offset: 0x000CD964
	public virtual void UseItem(global::IResourceTypeItem rs)
	{
		global::UnityEngine.Ray eyesRay = rs.character.eyesRay;
		global::UnityEngine.RaycastHit raycastHit;
		bool flag;
		global::Facepunch.MeshBatch.MeshBatchInstance meshBatchInstance;
		if (global::Facepunch.MeshBatch.MeshBatchPhysics.SphereCast(eyesRay, 0.5f, ref raycastHit, 4f, ref flag, ref meshBatchInstance))
		{
			global::IDMain idmain;
			if (flag)
			{
				idmain = meshBatchInstance.idMain;
			}
			else
			{
				idmain = global::IDBase.GetMain(raycastHit.collider.gameObject);
			}
			if (!idmain)
			{
				return;
			}
			global::RepairReceiver local = idmain.GetLocal<global::RepairReceiver>();
			global::TakeDamage local2 = idmain.GetLocal<global::TakeDamage>();
			if (!local || !local2)
			{
				return;
			}
			if (local.GetRepairAmmo() != this)
			{
				return;
			}
			if (local2.health == local2.maxHealth)
			{
				return;
			}
			if (local2.TimeSinceHurt() < 5f)
			{
				global::Rust.Notice.Popup(rs.character.netUser.networkPlayer, "ï€\u008d", "Can't repair - Being damaged", 4f);
				return;
			}
			float num = local2.maxHealth / (float)local.ResForMaxHealth;
			if (num > local2.maxHealth - local2.health)
			{
				num = local2.maxHealth - local2.health;
			}
			local2.Heal(rs.character.idMain, num);
			rs.lastUseTime = global::UnityEngine.Time.time;
			int num2 = 1;
			if (rs.Consume(ref num2))
			{
				rs.inventory.RemoveItem(rs.slot);
			}
			string strText = string.Format("Healed {0} ({1}/{2})", (int)num, (int)local2.health, (int)local2.maxHealth);
			global::Rust.Notice.Popup(rs.inventory.networkViewOwner, "ï‚­", strText, 4f);
		}
	}

	// Token: 0x04001E19 RID: 7705
	public bool cookable;

	// Token: 0x04001E1A RID: 7706
	public bool flammable;

	// Token: 0x04001E1B RID: 7707
	public global::ItemDataBlock cookedVersion;

	// Token: 0x04001E1C RID: 7708
	public int cookHeatRequirement = 1;

	// Token: 0x04001E1D RID: 7709
	public int numToGiveCookedMin = 1;

	// Token: 0x04001E1E RID: 7710
	public int numToGiveCookedMax = 1;

	// Token: 0x020006AD RID: 1709
	private sealed class ITEM_TYPE : global::ResourceTypeItem<global::ResourceTypeItemDataBlock>, global::ICookableItem, global::IFlammableItem, global::IInventoryItem, global::IResourceTypeItem
	{
		// Token: 0x060038D6 RID: 14550 RVA: 0x000CF918 File Offset: 0x000CDB18
		public ITEM_TYPE(global::ResourceTypeItemDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000B09 RID: 2825
		// (get) Token: 0x060038D7 RID: 14551 RVA: 0x000CF924 File Offset: 0x000CDB24
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x060038D8 RID: 14552 RVA: 0x000CF92C File Offset: 0x000CDB2C
		bool GetCookableInfo(out int consumeCount, out global::ItemDataBlock cookedVersion, out int cookedCount, out int cookTempMin, out int burnTemp)
		{
			return base.GetCookableInfo(out consumeCount, out cookedVersion, out cookedCount, out cookTempMin, out burnTemp);
		}

		// Token: 0x060038D9 RID: 14553 RVA: 0x000CF93C File Offset: 0x000CDB3C
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x060038DA RID: 14554 RVA: 0x000CF944 File Offset: 0x000CDB44
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x060038DB RID: 14555 RVA: 0x000CF94C File Offset: 0x000CDB4C
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x060038DC RID: 14556 RVA: 0x000CF954 File Offset: 0x000CDB54
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x060038DD RID: 14557 RVA: 0x000CF960 File Offset: 0x000CDB60
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x060038DE RID: 14558 RVA: 0x000CF96C File Offset: 0x000CDB6C
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x060038DF RID: 14559 RVA: 0x000CF978 File Offset: 0x000CDB78
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x060038E0 RID: 14560 RVA: 0x000CF984 File Offset: 0x000CDB84
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x060038E1 RID: 14561 RVA: 0x000CF990 File Offset: 0x000CDB90
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x060038E2 RID: 14562 RVA: 0x000CF99C File Offset: 0x000CDB9C
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x060038E3 RID: 14563 RVA: 0x000CF9A8 File Offset: 0x000CDBA8
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x060038E4 RID: 14564 RVA: 0x000CF9B4 File Offset: 0x000CDBB4
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x060038E5 RID: 14565 RVA: 0x000CF9BC File Offset: 0x000CDBBC
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x060038E6 RID: 14566 RVA: 0x000CF9C8 File Offset: 0x000CDBC8
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x060038E7 RID: 14567 RVA: 0x000CF9D4 File Offset: 0x000CDBD4
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x060038E8 RID: 14568 RVA: 0x000CF9DC File Offset: 0x000CDBDC
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x060038E9 RID: 14569 RVA: 0x000CF9E4 File Offset: 0x000CDBE4
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x060038EA RID: 14570 RVA: 0x000CF9EC File Offset: 0x000CDBEC
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x060038EB RID: 14571 RVA: 0x000CF9F4 File Offset: 0x000CDBF4
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x060038EC RID: 14572 RVA: 0x000CF9FC File Offset: 0x000CDBFC
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x060038ED RID: 14573 RVA: 0x000CFA04 File Offset: 0x000CDC04
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x060038EE RID: 14574 RVA: 0x000CFA0C File Offset: 0x000CDC0C
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x060038EF RID: 14575 RVA: 0x000CFA18 File Offset: 0x000CDC18
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x060038F0 RID: 14576 RVA: 0x000CFA20 File Offset: 0x000CDC20
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x060038F1 RID: 14577 RVA: 0x000CFA28 File Offset: 0x000CDC28
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x060038F2 RID: 14578 RVA: 0x000CFA30 File Offset: 0x000CDC30
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x060038F3 RID: 14579 RVA: 0x000CFA38 File Offset: 0x000CDC38
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x060038F4 RID: 14580 RVA: 0x000CFA40 File Offset: 0x000CDC40
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x060038F5 RID: 14581 RVA: 0x000CFA48 File Offset: 0x000CDC48
		bool get_doNotSave()
		{
			return base.doNotSave;
		}

		// Token: 0x060038F6 RID: 14582 RVA: 0x000CFA50 File Offset: 0x000CDC50
		bool get_flammable()
		{
			return base.flammable;
		}
	}
}
