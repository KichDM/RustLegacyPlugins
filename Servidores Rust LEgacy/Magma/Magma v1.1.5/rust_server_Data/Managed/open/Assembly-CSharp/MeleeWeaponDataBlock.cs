using System;
using Magma;
using Rust;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x020006A1 RID: 1697
public class MeleeWeaponDataBlock : global::WeaponDataBlock
{
	// Token: 0x06003832 RID: 14386 RVA: 0x000CE5B4 File Offset: 0x000CC7B4
	public MeleeWeaponDataBlock()
	{
	}

	// Token: 0x06003833 RID: 14387 RVA: 0x000CE60C File Offset: 0x000CC80C
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::MeleeWeaponDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x06003834 RID: 14388 RVA: 0x000CE614 File Offset: 0x000CC814
	public override float GetDamage()
	{
		return global::UnityEngine.Random.Range(this.damageMin, this.damageMax);
	}

	// Token: 0x06003835 RID: 14389 RVA: 0x000CE628 File Offset: 0x000CC828
	public virtual float GetRange()
	{
		return this.range;
	}

	// Token: 0x06003836 RID: 14390 RVA: 0x000CE630 File Offset: 0x000CC830
	public virtual void Local_SecondaryFire(global::ViewModel vm, global::ItemRepresentation itemRep, global::IMeleeWeaponItem itemInstance, ref global::HumanController.InputSample sample)
	{
		global::Character character = itemInstance.character;
		if (character == null)
		{
			return;
		}
		global::UnityEngine.Ray eyesRay = character.eyesRay;
		global::UnityEngine.RaycastHit raycastHit;
		bool flag = global::UnityEngine.Physics.SphereCast(eyesRay, 0.3f, ref raycastHit, this.GetRange(), 0x183E1411);
		if (flag)
		{
			global::IDBase component = raycastHit.collider.gameObject.GetComponent<global::IDBase>();
			if (component)
			{
				global::NetEntityID netEntityID = global::NetEntityID.Get(component);
				global::RepairReceiver local = component.GetLocal<global::RepairReceiver>();
				if (local != null && netEntityID != global::NetEntityID.unassigned)
				{
					itemInstance.QueueSwingSound(global::UnityEngine.Time.time + this.swingSoundDelay);
					itemRep.Action<global::NetEntityID>(2, 0, netEntityID);
				}
			}
		}
	}

	// Token: 0x06003837 RID: 14391 RVA: 0x000CE6E4 File Offset: 0x000CC8E4
	public virtual void Local_FireWeapon(global::ViewModel vm, global::ItemRepresentation itemRep, global::IMeleeWeaponItem itemInstance, ref global::HumanController.InputSample sample)
	{
		itemInstance.QueueSwingSound(global::UnityEngine.Time.time + this.swingSoundDelay);
		itemInstance.QueueMidSwing(global::UnityEngine.Time.time + this.midSwingDelay);
	}

	// Token: 0x06003838 RID: 14392 RVA: 0x000CE718 File Offset: 0x000CC918
	public virtual void SwingSound()
	{
		this.swingSound.PlayLocal(global::UnityEngine.Camera.main.transform, global::UnityEngine.Vector3.zero, 1f, global::UnityEngine.Random.Range(0.85f, 1f), 3f, 20f, 0);
	}

	// Token: 0x06003839 RID: 14393 RVA: 0x000CE760 File Offset: 0x000CC960
	public bool Physics2SphereCast(global::UnityEngine.Ray ray, float radius, float range, int hitMask, out global::UnityEngine.Vector3 point, out global::UnityEngine.Vector3 normal, out global::UnityEngine.Collider hitCollider, out global::BodyPart part)
	{
		global::UnityEngine.RaycastHit raycastHit = default(global::UnityEngine.RaycastHit);
		bool flag = false;
		bool flag2 = false;
		global::UnityEngine.RaycastHit raycastHit2;
		if (global::UnityEngine.Physics.SphereCast(ray, radius, ref raycastHit2, range - radius, hitMask & -0x20001))
		{
			flag2 = true;
			raycastHit = raycastHit2;
			global::UnityEngine.RaycastHit raycastHit3;
			if (global::UnityEngine.Physics.Raycast(ray, ref raycastHit3, range, hitMask & -0x20001))
			{
				flag = true;
				if (raycastHit3.distance < raycastHit2.distance)
				{
					raycastHit = raycastHit3;
				}
			}
		}
		bool flag3 = flag2 || flag;
		global::RaycastHit2 raycastHit4;
		if (global::Physics2.Raycast2(ray, ref raycastHit4, range, hitMask) && (!flag3 || raycastHit4.distance < raycastHit.distance))
		{
			point = raycastHit4.point;
			normal = raycastHit4.normal;
			hitCollider = raycastHit4.collider;
			part = raycastHit4.bodyPart;
			return true;
		}
		if (!flag3)
		{
			global::UnityEngine.Collider[] array = global::UnityEngine.Physics.OverlapSphere(ray.origin, 0.3f, 0x20000);
			if (array.Length > 0)
			{
				point = ray.origin + ray.direction * 0.5f;
				normal = ray.direction * -1f;
				hitCollider = array[0];
				part = 0;
				return true;
			}
		}
		if (!flag3)
		{
			point = ray.origin + ray.direction * range;
			normal = ray.direction * -1f;
			hitCollider = null;
			part = 0;
			return false;
		}
		point = raycastHit.point;
		normal = raycastHit.normal;
		hitCollider = raycastHit.collider;
		part = 0;
		return true;
	}

	// Token: 0x0600383A RID: 14394 RVA: 0x000CE91C File Offset: 0x000CCB1C
	public virtual void Local_MidSwing(global::ViewModel vm, global::ItemRepresentation itemRep, global::IMeleeWeaponItem itemInstance, ref global::HumanController.InputSample sample)
	{
		global::Character character = itemInstance.character;
		if (character == null)
		{
			return;
		}
		global::UnityEngine.Ray eyesRay = character.eyesRay;
		global::UnityEngine.Collider collider = null;
		global::UnityEngine.Vector3 zero = global::UnityEngine.Vector3.zero;
		global::UnityEngine.Vector3 up = global::UnityEngine.Vector3.up;
		global::NetEntityID netEntityID = global::NetEntityID.unassigned;
		bool flag = false;
		global::BodyPart bodyPart;
		bool flag2 = this.Physics2SphereCast(eyesRay, 0.3f, this.GetRange(), 0x183E1411, out zero, out up, out collider, out bodyPart);
		bool flag3 = false;
		if (flag2)
		{
			global::IDBase idbase;
			global::TransformHelpers.GetIDBaseFromCollider(collider, out idbase);
			global::IDMain idmain = (!idbase) ? null : idbase.idMain;
			if (idmain)
			{
				netEntityID = global::NetEntityID.Get(idmain);
				flag = !netEntityID.isUnassigned;
				global::TakeDamage component = idmain.GetComponent<global::TakeDamage>();
				if (component && component.ShouldPlayHitNotification())
				{
					this.PlayHitNotification(zero, character);
				}
			}
			flag3 = collider.gameObject.CompareTag("Tree Collider");
			if (flag3)
			{
				global::WoodBlockerTemp blockerForPoint = global::WoodBlockerTemp.GetBlockerForPoint(zero);
				if (!blockerForPoint.HasWood())
				{
					flag3 = false;
				}
				else
				{
					blockerForPoint.ConsumeWood(this.efficiencies[2]);
				}
			}
			this.DoMeleeEffects(eyesRay.origin, zero, global::UnityEngine.Quaternion.LookRotation(up), collider.gameObject);
		}
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		if (flag)
		{
			bitStream.WriteBoolean(flag);
			bitStream.Write<global::NetEntityID>(netEntityID, new object[0]);
			bitStream.WriteVector3(zero);
		}
		else
		{
			bitStream.WriteBoolean(false);
			bitStream.WriteVector3(zero);
		}
		bitStream.WriteBoolean(flag3);
		itemRep.ActionStream(1, 0, bitStream);
	}

	// Token: 0x0600383B RID: 14395 RVA: 0x000CEAB8 File Offset: 0x000CCCB8
	public virtual void DoMeleeEffects(global::UnityEngine.Vector3 fromPos, global::UnityEngine.Vector3 pos, global::UnityEngine.Quaternion rot, global::UnityEngine.GameObject hitObj)
	{
		if (hitObj.CompareTag("Tree Collider"))
		{
			global::UnityEngine.GameObject gameObject = global::UnityEngine.Object.Instantiate(this.impactEffectWood, pos, rot) as global::UnityEngine.GameObject;
			global::UnityEngine.Object.Destroy(gameObject, 1.5f);
			this.impactSoundWood.Play(pos, 1f, 2f, 10f);
			return;
		}
		global::SurfaceInfo.DoImpact(hitObj, global::SurfaceInfoObject.ImpactType.Melee, pos, rot);
	}

	// Token: 0x0600383C RID: 14396 RVA: 0x000CEB1C File Offset: 0x000CCD1C
	public override void DoAction2(global::uLink.BitStream stream, global::ItemRepresentation rep, ref global::uLink.NetworkMessageInfo info)
	{
		global::NetCull.VerifyRPC(ref info, false);
		global::NetEntityID netEntityID = stream.Read<global::NetEntityID>(new object[0]);
		if (!netEntityID.isUnassigned)
		{
			global::IDBase idBase = netEntityID.idBase;
			if (!idBase)
			{
				return;
			}
		}
	}

	// Token: 0x0600383D RID: 14397 RVA: 0x000CEB60 File Offset: 0x000CCD60
	public override void DoAction3(global::uLink.BitStream stream, global::ItemRepresentation itemRep, ref global::uLink.NetworkMessageInfo info)
	{
		global::NetCull.VerifyRPC(ref info, false);
		itemRep.ActionStream(3, 9, stream);
	}

	// Token: 0x0600383E RID: 14398 RVA: 0x000CEB74 File Offset: 0x000CCD74
	public override void DoAction1(global::uLink.BitStream stream, global::ItemRepresentation rep, ref global::uLink.NetworkMessageInfo info)
	{
		global::NetCull.VerifyRPC(ref info, false);
		bool flag = stream.ReadBoolean();
		global::UnityEngine.GameObject gameObject;
		if (flag)
		{
			global::NetEntityID netEntityID = stream.Read<global::NetEntityID>(new object[0]);
			if (!netEntityID.isUnassigned)
			{
				gameObject = netEntityID.gameObject;
				if (!gameObject)
				{
					netEntityID = global::NetEntityID.unassigned;
				}
			}
			else
			{
				gameObject = null;
			}
		}
		else
		{
			global::NetEntityID netEntityID = global::NetEntityID.unassigned;
			gameObject = null;
		}
		global::UnityEngine.Vector3 vector = stream.ReadVector3();
		bool flag2 = stream.ReadBoolean();
		global::IMeleeWeaponItem meleeWeaponItem;
		if (!rep.Item<global::IMeleeWeaponItem>(out meleeWeaponItem))
		{
			return;
		}
		global::TakeDamage local = meleeWeaponItem.inventory.GetLocal<global::TakeDamage>();
		if (local && local.dead)
		{
			return;
		}
		if (!meleeWeaponItem.ValidatePrimaryMessageTime(info.timestamp))
		{
			return;
		}
		global::IDBase idbase = null;
		global::TakeDamage takeDamage = null;
		if (gameObject)
		{
			idbase = global::IDBase.Get(gameObject);
			takeDamage = ((!idbase) ? null : idbase.idMain.GetLocal<global::TakeDamage>());
		}
		if (gameObject)
		{
			float num = global::UnityEngine.Vector3.Distance(local.transform.position, gameObject.transform.position);
			if (num >= 6f)
			{
				return;
			}
		}
		global::Metabolism component = meleeWeaponItem.inventory.GetComponent<global::Metabolism>();
		if (component)
		{
			component.SubtractCalories(global::UnityEngine.Random.Range(this.caloriesPerSwing * 0.8f, this.caloriesPerSwing * 1.2f));
		}
		rep.ActionStream(1, 0xA, stream);
		global::ResourceTarget resourceTarget = (!(idbase == null) || !(gameObject == null)) ? ((!(idbase == null)) ? idbase.gameObject : gameObject).GetComponent<global::ResourceTarget>() : null;
		if (flag2 || (resourceTarget && (takeDamage == null || takeDamage.dead)))
		{
			global::ResourceTarget.ResourceTargetType resourceTargetType;
			if (flag2)
			{
				resourceTargetType = global::ResourceTarget.ResourceTargetType.StaticTree;
			}
			else
			{
				resourceTargetType = resourceTarget.type;
			}
			float num2 = this.efficiencies[(int)resourceTargetType];
			if (flag2)
			{
				this.resourceGatherLevel += num2;
				if (this.resourceGatherLevel >= 1f)
				{
					int num3 = global::UnityEngine.Mathf.FloorToInt(this.resourceGatherLevel);
					string text = "Wood";
					global::ItemDataBlock byName = global::DatablockDictionary.GetByName(text);
					global::Magma.Hooks.PlayerGatherWood(meleeWeaponItem, resourceTarget, ref byName, ref num3, ref text);
					int num5;
					if (byName)
					{
						int num4 = meleeWeaponItem.inventory.AddItemAmount(byName, num3);
						num5 = num3 - num4;
					}
					else
					{
						num5 = 0;
					}
					if (num5 > 0)
					{
						this.resourceGatherLevel -= (float)num5;
						global::Rust.Notice.Inventory(info.sender, num5.ToString() + " x " + text);
					}
				}
			}
			else if (resourceTarget)
			{
				resourceTarget.DoGather(meleeWeaponItem.inventory, num2);
			}
		}
		if (idbase)
		{
			float damage = this.GetDamage();
			global::TakeDamage.Hurt(meleeWeaponItem.inventory, idbase, new global::DamageTypeList(0f, 0f, damage, 0f, 0f, 0f), new global::WeaponImpact(this, meleeWeaponItem, rep));
		}
		if (gameObject)
		{
			meleeWeaponItem.TryConditionLoss(0.25f, 0.025f);
		}
	}

	// Token: 0x04001DEA RID: 7658
	public const int hitMask = 0x183E1411;

	// Token: 0x04001DEB RID: 7659
	public float range = 2f;

	// Token: 0x04001DEC RID: 7660
	public global::UnityEngine.GameObject impactEffect;

	// Token: 0x04001DED RID: 7661
	public global::UnityEngine.GameObject impactEffectFlesh;

	// Token: 0x04001DEE RID: 7662
	public global::UnityEngine.GameObject impactEffectWood;

	// Token: 0x04001DEF RID: 7663
	public global::UnityEngine.AudioClip impactSoundWood;

	// Token: 0x04001DF0 RID: 7664
	public global::UnityEngine.AudioClip swingSound;

	// Token: 0x04001DF1 RID: 7665
	public float swingSoundDelay = 0.2f;

	// Token: 0x04001DF2 RID: 7666
	public global::UnityEngine.AudioClip impactSoundGeneric;

	// Token: 0x04001DF3 RID: 7667
	public global::UnityEngine.AudioClip[] impactSoundFlesh;

	// Token: 0x04001DF4 RID: 7668
	public float midSwingDelay = 0.35f;

	// Token: 0x04001DF5 RID: 7669
	public float gatherPerHitAmount = 0.25f;

	// Token: 0x04001DF6 RID: 7670
	public bool gathersResources;

	// Token: 0x04001DF7 RID: 7671
	[global::System.NonSerialized]
	private float resourceGatherLevel;

	// Token: 0x04001DF8 RID: 7672
	public float caloriesPerSwing = 5f;

	// Token: 0x04001DF9 RID: 7673
	public float worldSwingAnimationSpeed = 1f;

	// Token: 0x04001DFA RID: 7674
	[global::UnityEngine.SerializeField]
	protected string _swingingMovementAnimationGroupName;

	// Token: 0x04001DFB RID: 7675
	public float[] efficiencies;

	// Token: 0x020006A2 RID: 1698
	private sealed class ITEM_TYPE : global::MeleeWeaponItem<global::MeleeWeaponDataBlock>, global::IHeldItem, global::IInventoryItem, global::IMeleeWeaponItem, global::IWeaponItem
	{
		// Token: 0x0600383F RID: 14399 RVA: 0x000CEEC8 File Offset: 0x000CD0C8
		public ITEM_TYPE(global::MeleeWeaponDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000B05 RID: 2821
		// (get) Token: 0x06003840 RID: 14400 RVA: 0x000CEED4 File Offset: 0x000CD0D4
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x06003841 RID: 14401 RVA: 0x000CEEDC File Offset: 0x000CD0DC
		float get_queuedSwingAttackTime()
		{
			return base.queuedSwingAttackTime;
		}

		// Token: 0x06003842 RID: 14402 RVA: 0x000CEEE4 File Offset: 0x000CD0E4
		void set_queuedSwingAttackTime(float value)
		{
			base.queuedSwingAttackTime = value;
		}

		// Token: 0x06003843 RID: 14403 RVA: 0x000CEEF0 File Offset: 0x000CD0F0
		float get_queuedSwingSoundTime()
		{
			return base.queuedSwingSoundTime;
		}

		// Token: 0x06003844 RID: 14404 RVA: 0x000CEEF8 File Offset: 0x000CD0F8
		void set_queuedSwingSoundTime(float value)
		{
			base.queuedSwingSoundTime = value;
		}

		// Token: 0x06003845 RID: 14405 RVA: 0x000CEF04 File Offset: 0x000CD104
		bool ValidatePrimaryMessageTime(double timestamp)
		{
			return base.ValidatePrimaryMessageTime(timestamp);
		}

		// Token: 0x06003846 RID: 14406 RVA: 0x000CEF10 File Offset: 0x000CD110
		bool get_canAim()
		{
			return base.canAim;
		}

		// Token: 0x06003847 RID: 14407 RVA: 0x000CEF18 File Offset: 0x000CD118
		float get_nextPrimaryAttackTime()
		{
			return base.nextPrimaryAttackTime;
		}

		// Token: 0x06003848 RID: 14408 RVA: 0x000CEF20 File Offset: 0x000CD120
		void set_nextPrimaryAttackTime(float value)
		{
			base.nextPrimaryAttackTime = value;
		}

		// Token: 0x06003849 RID: 14409 RVA: 0x000CEF2C File Offset: 0x000CD12C
		float get_nextSecondaryAttackTime()
		{
			return base.nextSecondaryAttackTime;
		}

		// Token: 0x0600384A RID: 14410 RVA: 0x000CEF34 File Offset: 0x000CD134
		void set_nextSecondaryAttackTime(float value)
		{
			base.nextSecondaryAttackTime = value;
		}

		// Token: 0x0600384B RID: 14411 RVA: 0x000CEF40 File Offset: 0x000CD140
		float get_deployFinishedTime()
		{
			return base.deployFinishedTime;
		}

		// Token: 0x0600384C RID: 14412 RVA: 0x000CEF48 File Offset: 0x000CD148
		void set_deployFinishedTime(float value)
		{
			base.deployFinishedTime = value;
		}

		// Token: 0x0600384D RID: 14413 RVA: 0x000CEF54 File Offset: 0x000CD154
		void SetTotalModSlotCount(int count)
		{
			base.SetTotalModSlotCount(count);
		}

		// Token: 0x0600384E RID: 14414 RVA: 0x000CEF60 File Offset: 0x000CD160
		void SetUsedModSlotCount(int count)
		{
			base.SetUsedModSlotCount(count);
		}

		// Token: 0x0600384F RID: 14415 RVA: 0x000CEF6C File Offset: 0x000CD16C
		void AddMod(global::ItemModDataBlock mod)
		{
			base.AddMod(mod);
		}

		// Token: 0x06003850 RID: 14416 RVA: 0x000CEF78 File Offset: 0x000CD178
		int FindMod(global::ItemModDataBlock mod)
		{
			return base.FindMod(mod);
		}

		// Token: 0x06003851 RID: 14417 RVA: 0x000CEF84 File Offset: 0x000CD184
		void OnActivate()
		{
			base.OnActivate();
		}

		// Token: 0x06003852 RID: 14418 RVA: 0x000CEF8C File Offset: 0x000CD18C
		void OnDeactivate()
		{
			base.OnDeactivate();
		}

		// Token: 0x06003853 RID: 14419 RVA: 0x000CEF94 File Offset: 0x000CD194
		global::ViewModel get_viewModelInstance()
		{
			return base.viewModelInstance;
		}

		// Token: 0x06003854 RID: 14420 RVA: 0x000CEF9C File Offset: 0x000CD19C
		global::ItemRepresentation get_itemRepresentation()
		{
			return base.itemRepresentation;
		}

		// Token: 0x06003855 RID: 14421 RVA: 0x000CEFA4 File Offset: 0x000CD1A4
		void set_itemRepresentation(global::ItemRepresentation value)
		{
			base.itemRepresentation = value;
		}

		// Token: 0x06003856 RID: 14422 RVA: 0x000CEFB0 File Offset: 0x000CD1B0
		bool get_canActivate()
		{
			return base.canActivate;
		}

		// Token: 0x06003857 RID: 14423 RVA: 0x000CEFB8 File Offset: 0x000CD1B8
		bool get_canDeactivate()
		{
			return base.canDeactivate;
		}

		// Token: 0x06003858 RID: 14424 RVA: 0x000CEFC0 File Offset: 0x000CD1C0
		global::ItemModFlags get_modFlags()
		{
			return base.modFlags;
		}

		// Token: 0x06003859 RID: 14425 RVA: 0x000CEFC8 File Offset: 0x000CD1C8
		global::ItemModDataBlock[] get_itemMods()
		{
			return base.itemMods;
		}

		// Token: 0x0600385A RID: 14426 RVA: 0x000CEFD0 File Offset: 0x000CD1D0
		int get_totalModSlots()
		{
			return base.totalModSlots;
		}

		// Token: 0x0600385B RID: 14427 RVA: 0x000CEFD8 File Offset: 0x000CD1D8
		int get_usedModSlots()
		{
			return base.usedModSlots;
		}

		// Token: 0x0600385C RID: 14428 RVA: 0x000CEFE0 File Offset: 0x000CD1E0
		int get_freeModSlots()
		{
			return base.freeModSlots;
		}

		// Token: 0x0600385D RID: 14429 RVA: 0x000CEFE8 File Offset: 0x000CD1E8
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x0600385E RID: 14430 RVA: 0x000CEFF0 File Offset: 0x000CD1F0
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x0600385F RID: 14431 RVA: 0x000CEFF8 File Offset: 0x000CD1F8
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x06003860 RID: 14432 RVA: 0x000CF000 File Offset: 0x000CD200
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x06003861 RID: 14433 RVA: 0x000CF00C File Offset: 0x000CD20C
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x06003862 RID: 14434 RVA: 0x000CF018 File Offset: 0x000CD218
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x06003863 RID: 14435 RVA: 0x000CF024 File Offset: 0x000CD224
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x06003864 RID: 14436 RVA: 0x000CF030 File Offset: 0x000CD230
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x06003865 RID: 14437 RVA: 0x000CF03C File Offset: 0x000CD23C
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x06003866 RID: 14438 RVA: 0x000CF048 File Offset: 0x000CD248
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x06003867 RID: 14439 RVA: 0x000CF054 File Offset: 0x000CD254
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x06003868 RID: 14440 RVA: 0x000CF060 File Offset: 0x000CD260
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x06003869 RID: 14441 RVA: 0x000CF068 File Offset: 0x000CD268
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x0600386A RID: 14442 RVA: 0x000CF074 File Offset: 0x000CD274
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x0600386B RID: 14443 RVA: 0x000CF080 File Offset: 0x000CD280
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x0600386C RID: 14444 RVA: 0x000CF088 File Offset: 0x000CD288
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x0600386D RID: 14445 RVA: 0x000CF090 File Offset: 0x000CD290
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x0600386E RID: 14446 RVA: 0x000CF098 File Offset: 0x000CD298
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x0600386F RID: 14447 RVA: 0x000CF0A0 File Offset: 0x000CD2A0
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x06003870 RID: 14448 RVA: 0x000CF0A8 File Offset: 0x000CD2A8
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x06003871 RID: 14449 RVA: 0x000CF0B0 File Offset: 0x000CD2B0
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x06003872 RID: 14450 RVA: 0x000CF0B8 File Offset: 0x000CD2B8
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x06003873 RID: 14451 RVA: 0x000CF0C4 File Offset: 0x000CD2C4
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x06003874 RID: 14452 RVA: 0x000CF0CC File Offset: 0x000CD2CC
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x06003875 RID: 14453 RVA: 0x000CF0D4 File Offset: 0x000CD2D4
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x06003876 RID: 14454 RVA: 0x000CF0DC File Offset: 0x000CD2DC
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x06003877 RID: 14455 RVA: 0x000CF0E4 File Offset: 0x000CD2E4
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x06003878 RID: 14456 RVA: 0x000CF0EC File Offset: 0x000CD2EC
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x06003879 RID: 14457 RVA: 0x000CF0F4 File Offset: 0x000CD2F4
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}
}
