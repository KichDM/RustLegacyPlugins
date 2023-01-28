using System;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x020006AE RID: 1710
public class ShotgunDataBlock : global::BulletWeaponDataBlock
{
	// Token: 0x060038F7 RID: 14583 RVA: 0x000CFA58 File Offset: 0x000CDC58
	public ShotgunDataBlock()
	{
	}

	// Token: 0x060038F8 RID: 14584 RVA: 0x000CFA80 File Offset: 0x000CDC80
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::ShotgunDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x060038F9 RID: 14585 RVA: 0x000CFA88 File Offset: 0x000CDC88
	public override float GetGUIDamage()
	{
		return base.GetGUIDamage() * (float)this.numPellets;
	}

	// Token: 0x060038FA RID: 14586 RVA: 0x000CFA98 File Offset: 0x000CDC98
	public virtual void FireSingleBullet(global::uLink.BitStream sendStream, global::UnityEngine.Ray ray, global::ItemRepresentation itemRep, out global::UnityEngine.Component hitComponent, out bool allowBlood)
	{
		global::NetEntityID hitView = global::NetEntityID.unassigned;
		bool flag = false;
		global::RaycastHit2 raycastHit;
		bool flag2 = global::Physics2.Raycast2(ray, ref raycastHit, this.GetBulletRange(itemRep), 0x183E1411);
		if (flag2)
		{
			global::UnityEngine.Vector3 point = raycastHit.point;
			global::IDBase id = raycastHit.id;
			hitComponent = ((!raycastHit.remoteBodyPart) ? raycastHit.collider : raycastHit.remoteBodyPart);
			global::IDMain idmain = (!id) ? null : id.idMain;
			if (idmain)
			{
				hitView = global::NetEntityID.Get(idmain);
				if (!hitView.isUnassigned)
				{
					global::TakeDamage component = idmain.GetComponent<global::TakeDamage>();
					if (component)
					{
						flag = true;
						if (component.ShouldPlayHitNotification())
						{
							this.PlayHitNotification(point, null);
						}
					}
				}
			}
		}
		else
		{
			global::UnityEngine.Vector3 point = ray.GetPoint(this.GetBulletRange(itemRep));
			hitComponent = null;
		}
		this.WriteHitInfo(sendStream, ref ray, flag2, ref raycastHit, flag, hitView);
		allowBlood = (flag2 && flag);
	}

	// Token: 0x060038FB RID: 14587 RVA: 0x000CFBA4 File Offset: 0x000CDDA4
	public override void Local_FireWeapon(global::ViewModel vm, global::ItemRepresentation itemRep, global::IBulletWeaponItem itemInstance, ref global::HumanController.InputSample sample)
	{
		global::Character character = itemInstance.character;
		if (character == null)
		{
			return;
		}
		if (itemInstance.clipAmmo <= 0)
		{
			return;
		}
		global::UnityEngine.Ray eyesRay = character.eyesRay;
		int num = 1;
		itemInstance.Consume(ref num);
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		float bulletRange = this.GetBulletRange(itemRep);
		for (int i = 0; i < this.numPellets; i++)
		{
			global::UnityEngine.Ray ray = eyesRay;
			ray.direction = global::UnityEngine.Quaternion.LookRotation(eyesRay.direction) * global::UnityEngine.Quaternion.Euler(global::UnityEngine.Random.Range(-this.xSpread, this.xSpread), global::UnityEngine.Random.Range(-this.ySpread, this.ySpread), 0f) * global::UnityEngine.Vector3.forward;
			global::UnityEngine.Component component = null;
			bool allowBlood;
			this.FireSingleBullet(bitStream, ray, itemRep, out component, out allowBlood);
			this.MakeTracer(ray.origin, ray.origin + ray.direction * bulletRange, bulletRange, component, allowBlood);
		}
		itemRep.ActionStream(1, 0, bitStream);
		bool flag = vm;
		global::Socket muzzle;
		if (flag)
		{
			muzzle = vm.muzzle;
		}
		else
		{
			muzzle = itemRep.muzzle;
		}
		this.DoWeaponEffects(character.transform, muzzle, flag, itemRep);
		float num2 = 1f;
		if (sample.aim)
		{
			num2 -= this.aimingRecoilSubtract;
		}
		else if (sample.crouch)
		{
			num2 -= this.crouchRecoilSubtract;
		}
		float pitch = global::UnityEngine.Random.Range(this.recoilPitchMin, this.recoilPitchMax) * num2;
		float yaw = global::UnityEngine.Random.Range(this.recoilYawMin, this.recoilYawMax) * num2;
		global::RecoilSimulation recoilSimulation = character.recoilSimulation;
		if (recoilSimulation)
		{
			recoilSimulation.AddRecoil(this.recoilDuration, pitch, yaw);
		}
	}

	// Token: 0x060038FC RID: 14588 RVA: 0x000CFD6C File Offset: 0x000CDF6C
	public virtual void MakeTracer(global::UnityEngine.Vector3 startPos, global::UnityEngine.Vector3 endPos, float range, global::UnityEngine.Component component, bool allowBlood)
	{
		global::UnityEngine.Vector3 vector = endPos - startPos;
		vector.Normalize();
		global::UnityEngine.GameObject gameObject = (global::UnityEngine.GameObject)global::UnityEngine.Object.Instantiate(this.tracerPrefab, startPos, global::UnityEngine.Quaternion.LookRotation(vector));
		global::Tracer component2 = gameObject.GetComponent<global::Tracer>();
		if (component2)
		{
			component2.Init(component, 0x183E1411, range, allowBlood);
		}
	}

	// Token: 0x060038FD RID: 14589 RVA: 0x000CFDC4 File Offset: 0x000CDFC4
	public virtual void DoWeaponEffects(global::UnityEngine.Transform soundTransform, global::Socket muzzleSocket, bool firstPerson, global::ItemRepresentation itemRep)
	{
		this.PlayFireSound(soundTransform, firstPerson, itemRep);
		global::UnityEngine.GameObject gameObject = muzzleSocket.InstantiateAsChild((!firstPerson) ? this.muzzleFlashWorld : this.muzzleflashVM, false);
		global::UnityEngine.Object.Destroy(gameObject, 1f);
	}

	// Token: 0x060038FE RID: 14590 RVA: 0x000CFE08 File Offset: 0x000CE008
	public override void DoAction1(global::uLink.BitStream stream, global::ItemRepresentation rep, ref global::uLink.NetworkMessageInfo info)
	{
		global::NetCull.VerifyRPC(ref info, false);
		global::IBulletWeaponItem bulletWeaponItem = null;
		if (!rep.Item<global::IBulletWeaponItem>(out bulletWeaponItem) || bulletWeaponItem.uses <= 0)
		{
			return;
		}
		global::TakeDamage local = bulletWeaponItem.inventory.GetLocal<global::TakeDamage>();
		if (local && local.dead)
		{
			return;
		}
		if (!bulletWeaponItem.ValidatePrimaryMessageTime(info.timestamp))
		{
			return;
		}
		int num = 1;
		bulletWeaponItem.Consume(ref num);
		bulletWeaponItem.itemRepresentation.ActionStream(1, 0xA, stream);
		float bulletRange = this.GetBulletRange(rep);
		for (int i = 0; i < this.numPellets; i++)
		{
			global::UnityEngine.GameObject gameObject;
			bool flag;
			bool flag2;
			global::BodyPart bodyPart;
			global::IDRemoteBodyPart idremoteBodyPart;
			global::NetEntityID netEntityID;
			global::UnityEngine.Transform fromTransform;
			global::UnityEngine.Vector3 endPos;
			global::UnityEngine.Vector3 vector;
			bool isHeadshot;
			this.ReadHitInfo(stream, out gameObject, out flag, out flag2, out bodyPart, out idremoteBodyPart, out netEntityID, out fromTransform, out endPos, out vector, out isHeadshot);
			if (gameObject)
			{
				base.ApplyDamage(gameObject, fromTransform, isHeadshot, endPos, bodyPart, rep);
			}
		}
		bulletWeaponItem.TryConditionLoss(0.5f, 0.02f);
	}

	// Token: 0x060038FF RID: 14591 RVA: 0x000CFEF4 File Offset: 0x000CE0F4
	protected override void SecureWriteMemberValues(global::uLink.BitStream stream)
	{
		base.SecureWriteMemberValues(stream);
		stream.Write<float>(this.xSpread, new object[0]);
		stream.Write<int>(this.numPellets, new object[0]);
		stream.Write<float>(this.ySpread, new object[0]);
	}

	// Token: 0x04001E1F RID: 7711
	public int numPellets = 6;

	// Token: 0x04001E20 RID: 7712
	public float xSpread = 8f;

	// Token: 0x04001E21 RID: 7713
	public float ySpread = 8f;

	// Token: 0x020006AF RID: 1711
	private sealed class ITEM_TYPE : global::BulletWeaponItem<global::ShotgunDataBlock>, global::IBulletWeaponItem, global::IHeldItem, global::IInventoryItem, global::IWeaponItem
	{
		// Token: 0x06003900 RID: 14592 RVA: 0x000CFF40 File Offset: 0x000CE140
		public ITEM_TYPE(global::ShotgunDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000B0A RID: 2826
		// (get) Token: 0x06003901 RID: 14593 RVA: 0x000CFF4C File Offset: 0x000CE14C
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x06003902 RID: 14594 RVA: 0x000CFF54 File Offset: 0x000CE154
		global::MagazineDataBlock get_clipType()
		{
			return base.clipType;
		}

		// Token: 0x06003903 RID: 14595 RVA: 0x000CFF5C File Offset: 0x000CE15C
		int get_clipAmmo()
		{
			return base.clipAmmo;
		}

		// Token: 0x06003904 RID: 14596 RVA: 0x000CFF64 File Offset: 0x000CE164
		void set_clipAmmo(int value)
		{
			base.clipAmmo = value;
		}

		// Token: 0x06003905 RID: 14597 RVA: 0x000CFF70 File Offset: 0x000CE170
		int get_cachedCasings()
		{
			return base.cachedCasings;
		}

		// Token: 0x06003906 RID: 14598 RVA: 0x000CFF78 File Offset: 0x000CE178
		void set_cachedCasings(int value)
		{
			base.cachedCasings = value;
		}

		// Token: 0x06003907 RID: 14599 RVA: 0x000CFF84 File Offset: 0x000CE184
		float get_nextCasingsTime()
		{
			return base.nextCasingsTime;
		}

		// Token: 0x06003908 RID: 14600 RVA: 0x000CFF8C File Offset: 0x000CE18C
		void set_nextCasingsTime(float value)
		{
			base.nextCasingsTime = value;
		}

		// Token: 0x06003909 RID: 14601 RVA: 0x000CFF98 File Offset: 0x000CE198
		bool ValidatePrimaryMessageTime(double timestamp)
		{
			return base.ValidatePrimaryMessageTime(timestamp);
		}

		// Token: 0x0600390A RID: 14602 RVA: 0x000CFFA4 File Offset: 0x000CE1A4
		bool get_canAim()
		{
			return base.canAim;
		}

		// Token: 0x0600390B RID: 14603 RVA: 0x000CFFAC File Offset: 0x000CE1AC
		float get_nextPrimaryAttackTime()
		{
			return base.nextPrimaryAttackTime;
		}

		// Token: 0x0600390C RID: 14604 RVA: 0x000CFFB4 File Offset: 0x000CE1B4
		void set_nextPrimaryAttackTime(float value)
		{
			base.nextPrimaryAttackTime = value;
		}

		// Token: 0x0600390D RID: 14605 RVA: 0x000CFFC0 File Offset: 0x000CE1C0
		float get_nextSecondaryAttackTime()
		{
			return base.nextSecondaryAttackTime;
		}

		// Token: 0x0600390E RID: 14606 RVA: 0x000CFFC8 File Offset: 0x000CE1C8
		void set_nextSecondaryAttackTime(float value)
		{
			base.nextSecondaryAttackTime = value;
		}

		// Token: 0x0600390F RID: 14607 RVA: 0x000CFFD4 File Offset: 0x000CE1D4
		float get_deployFinishedTime()
		{
			return base.deployFinishedTime;
		}

		// Token: 0x06003910 RID: 14608 RVA: 0x000CFFDC File Offset: 0x000CE1DC
		void set_deployFinishedTime(float value)
		{
			base.deployFinishedTime = value;
		}

		// Token: 0x06003911 RID: 14609 RVA: 0x000CFFE8 File Offset: 0x000CE1E8
		void SetTotalModSlotCount(int count)
		{
			base.SetTotalModSlotCount(count);
		}

		// Token: 0x06003912 RID: 14610 RVA: 0x000CFFF4 File Offset: 0x000CE1F4
		void SetUsedModSlotCount(int count)
		{
			base.SetUsedModSlotCount(count);
		}

		// Token: 0x06003913 RID: 14611 RVA: 0x000D0000 File Offset: 0x000CE200
		void AddMod(global::ItemModDataBlock mod)
		{
			base.AddMod(mod);
		}

		// Token: 0x06003914 RID: 14612 RVA: 0x000D000C File Offset: 0x000CE20C
		int FindMod(global::ItemModDataBlock mod)
		{
			return base.FindMod(mod);
		}

		// Token: 0x06003915 RID: 14613 RVA: 0x000D0018 File Offset: 0x000CE218
		void OnActivate()
		{
			base.OnActivate();
		}

		// Token: 0x06003916 RID: 14614 RVA: 0x000D0020 File Offset: 0x000CE220
		void OnDeactivate()
		{
			base.OnDeactivate();
		}

		// Token: 0x06003917 RID: 14615 RVA: 0x000D0028 File Offset: 0x000CE228
		global::ViewModel get_viewModelInstance()
		{
			return base.viewModelInstance;
		}

		// Token: 0x06003918 RID: 14616 RVA: 0x000D0030 File Offset: 0x000CE230
		global::ItemRepresentation get_itemRepresentation()
		{
			return base.itemRepresentation;
		}

		// Token: 0x06003919 RID: 14617 RVA: 0x000D0038 File Offset: 0x000CE238
		void set_itemRepresentation(global::ItemRepresentation value)
		{
			base.itemRepresentation = value;
		}

		// Token: 0x0600391A RID: 14618 RVA: 0x000D0044 File Offset: 0x000CE244
		bool get_canActivate()
		{
			return base.canActivate;
		}

		// Token: 0x0600391B RID: 14619 RVA: 0x000D004C File Offset: 0x000CE24C
		bool get_canDeactivate()
		{
			return base.canDeactivate;
		}

		// Token: 0x0600391C RID: 14620 RVA: 0x000D0054 File Offset: 0x000CE254
		global::ItemModFlags get_modFlags()
		{
			return base.modFlags;
		}

		// Token: 0x0600391D RID: 14621 RVA: 0x000D005C File Offset: 0x000CE25C
		global::ItemModDataBlock[] get_itemMods()
		{
			return base.itemMods;
		}

		// Token: 0x0600391E RID: 14622 RVA: 0x000D0064 File Offset: 0x000CE264
		int get_totalModSlots()
		{
			return base.totalModSlots;
		}

		// Token: 0x0600391F RID: 14623 RVA: 0x000D006C File Offset: 0x000CE26C
		int get_usedModSlots()
		{
			return base.usedModSlots;
		}

		// Token: 0x06003920 RID: 14624 RVA: 0x000D0074 File Offset: 0x000CE274
		int get_freeModSlots()
		{
			return base.freeModSlots;
		}

		// Token: 0x06003921 RID: 14625 RVA: 0x000D007C File Offset: 0x000CE27C
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x06003922 RID: 14626 RVA: 0x000D0084 File Offset: 0x000CE284
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x06003923 RID: 14627 RVA: 0x000D008C File Offset: 0x000CE28C
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x06003924 RID: 14628 RVA: 0x000D0094 File Offset: 0x000CE294
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x06003925 RID: 14629 RVA: 0x000D00A0 File Offset: 0x000CE2A0
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x06003926 RID: 14630 RVA: 0x000D00AC File Offset: 0x000CE2AC
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x06003927 RID: 14631 RVA: 0x000D00B8 File Offset: 0x000CE2B8
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x06003928 RID: 14632 RVA: 0x000D00C4 File Offset: 0x000CE2C4
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x06003929 RID: 14633 RVA: 0x000D00D0 File Offset: 0x000CE2D0
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x0600392A RID: 14634 RVA: 0x000D00DC File Offset: 0x000CE2DC
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x0600392B RID: 14635 RVA: 0x000D00E8 File Offset: 0x000CE2E8
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x0600392C RID: 14636 RVA: 0x000D00F4 File Offset: 0x000CE2F4
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x0600392D RID: 14637 RVA: 0x000D00FC File Offset: 0x000CE2FC
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x0600392E RID: 14638 RVA: 0x000D0108 File Offset: 0x000CE308
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x0600392F RID: 14639 RVA: 0x000D0114 File Offset: 0x000CE314
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x06003930 RID: 14640 RVA: 0x000D011C File Offset: 0x000CE31C
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x06003931 RID: 14641 RVA: 0x000D0124 File Offset: 0x000CE324
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x06003932 RID: 14642 RVA: 0x000D012C File Offset: 0x000CE32C
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x06003933 RID: 14643 RVA: 0x000D0134 File Offset: 0x000CE334
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x06003934 RID: 14644 RVA: 0x000D013C File Offset: 0x000CE33C
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x06003935 RID: 14645 RVA: 0x000D0144 File Offset: 0x000CE344
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x06003936 RID: 14646 RVA: 0x000D014C File Offset: 0x000CE34C
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x06003937 RID: 14647 RVA: 0x000D0158 File Offset: 0x000CE358
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x06003938 RID: 14648 RVA: 0x000D0160 File Offset: 0x000CE360
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x06003939 RID: 14649 RVA: 0x000D0168 File Offset: 0x000CE368
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x0600393A RID: 14650 RVA: 0x000D0170 File Offset: 0x000CE370
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x0600393B RID: 14651 RVA: 0x000D0178 File Offset: 0x000CE378
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x0600393C RID: 14652 RVA: 0x000D0180 File Offset: 0x000CE380
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x0600393D RID: 14653 RVA: 0x000D0188 File Offset: 0x000CE388
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}
}
