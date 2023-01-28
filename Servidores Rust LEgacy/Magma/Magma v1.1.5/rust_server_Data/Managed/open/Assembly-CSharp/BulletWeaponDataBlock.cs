using System;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x02000681 RID: 1665
public class BulletWeaponDataBlock : global::WeaponDataBlock
{
	// Token: 0x060035EB RID: 13803 RVA: 0x000CAA34 File Offset: 0x000C8C34
	public BulletWeaponDataBlock()
	{
	}

	// Token: 0x060035EC RID: 13804 RVA: 0x000CAA90 File Offset: 0x000C8C90
	// Note: this type is marked as 'beforefieldinit'.
	static BulletWeaponDataBlock()
	{
	}

	// Token: 0x060035ED RID: 13805 RVA: 0x000CAAA0 File Offset: 0x000C8CA0
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::BulletWeaponDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x060035EE RID: 13806 RVA: 0x000CAAA8 File Offset: 0x000C8CA8
	public void Awake()
	{
	}

	// Token: 0x060035EF RID: 13807 RVA: 0x000CAAAC File Offset: 0x000C8CAC
	public override byte GetMaxEligableSlots()
	{
		return (byte)this.maxEligableSlots;
	}

	// Token: 0x060035F0 RID: 13808 RVA: 0x000CAAB8 File Offset: 0x000C8CB8
	public override int RetreiveMenuOptions(global::IInventoryItem item, global::InventoryItem.MenuItem[] results, int offset)
	{
		offset = base.RetreiveMenuOptions(item, results, offset);
		if (item.isInLocalInventory)
		{
			results[offset++] = global::InventoryItem.MenuItem.Unload;
		}
		return offset;
	}

	// Token: 0x060035F1 RID: 13809 RVA: 0x000CAAE8 File Offset: 0x000C8CE8
	public override global::InventoryItem.MenuItemResult ExecuteMenuOption(global::InventoryItem.MenuItem option, global::IInventoryItem item)
	{
		if (option != global::InventoryItem.MenuItem.Unload)
		{
			return base.ExecuteMenuOption(option, item);
		}
		int uses = item.uses;
		global::Inventory inventory = item.inventory;
		if (uses > 0 && inventory.anyVacantSlots)
		{
			item.SetUses(inventory.AddItemAmount(this.ammoType, uses));
			item.MarkDirty();
		}
		return global::InventoryItem.MenuItemResult.DoneOnServer;
	}

	// Token: 0x060035F2 RID: 13810 RVA: 0x000CAB48 File Offset: 0x000C8D48
	public override void InstallData(global::IInventoryItem item)
	{
		base.InstallData(item);
		global::IBulletWeaponItem bulletWeaponItem = item as global::IBulletWeaponItem;
		this._maxUses = this.maxClipAmmo;
		bulletWeaponItem.clipAmmo = this.maxClipAmmo;
	}

	// Token: 0x060035F3 RID: 13811 RVA: 0x000CAB7C File Offset: 0x000C8D7C
	public virtual void Local_DryFire(global::ViewModel vm, global::ItemRepresentation itemRep)
	{
		this.dryFireSound.PlayLocal(itemRep.transform, global::UnityEngine.Vector3.zero, 1f, 0);
	}

	// Token: 0x060035F4 RID: 13812 RVA: 0x000CABA8 File Offset: 0x000C8DA8
	public virtual void Local_Reload(global::ViewModel vm, global::ItemRepresentation itemRep, global::IBulletWeaponItem itemInstance, ref global::HumanController.InputSample sample)
	{
		this.reloadSound.PlayLocal(itemRep.transform, global::UnityEngine.Vector3.zero, 1f, 0);
		itemRep.Action(3, 0);
	}

	// Token: 0x060035F5 RID: 13813 RVA: 0x000CABDC File Offset: 0x000C8DDC
	public virtual void Local_FireWeapon(global::ViewModel vm, global::ItemRepresentation itemRep, global::IBulletWeaponItem itemInstance, ref global::HumanController.InputSample sample)
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
		global::NetEntityID hitView = global::NetEntityID.unassigned;
		bool hitNetworkView = false;
		int num = 1;
		itemInstance.Consume(ref num);
		global::RaycastHit2 raycastHit;
		bool flag = global::Physics2.Raycast2(eyesRay, ref raycastHit, this.GetBulletRange(itemRep), 0x183E1411);
		global::TakeDamage takeDamage = null;
		global::UnityEngine.Vector3 point;
		global::UnityEngine.Component hitComponent;
		if (flag)
		{
			point = raycastHit.point;
			global::IDBase id = raycastHit.id;
			hitComponent = ((!raycastHit.remoteBodyPart) ? raycastHit.collider : raycastHit.remoteBodyPart);
			global::IDMain idmain = (!id) ? null : id.idMain;
			if (idmain)
			{
				hitView = global::NetEntityID.Get(idmain);
				if (!hitView.isUnassigned)
				{
					hitNetworkView = true;
					takeDamage = idmain.GetComponent<global::TakeDamage>();
					if (takeDamage && takeDamage.ShouldPlayHitNotification())
					{
						this.PlayHitNotification(point, character);
					}
					bool flag2 = false;
					if (raycastHit.remoteBodyPart)
					{
						global::BodyPart bodyPart = raycastHit.remoteBodyPart.bodyPart;
						switch (bodyPart)
						{
						case 0x10:
						case 0x14:
						case 0x15:
							break;
						default:
							switch (bodyPart)
							{
							case 9:
							case 0xC:
								goto IL_164;
							}
							flag2 = false;
							goto IL_174;
						}
						IL_164:
						flag2 = true;
					}
					IL_174:
					if (flag2)
					{
						this.headshotSound.Play();
					}
				}
			}
		}
		else
		{
			point = eyesRay.GetPoint(1000f);
			hitComponent = null;
		}
		bool allowBlood = flag && (!raycastHit.isHitboxHit || global::BodyParts.IsDefined(raycastHit.bodyPart) || takeDamage != null);
		global::Socket socket;
		bool firstPerson;
		if (vm)
		{
			socket = vm.socketMap["muzzle"].socket;
			firstPerson = true;
		}
		else
		{
			socket = itemRep.muzzle;
			firstPerson = false;
		}
		global::UnityEngine.Vector3 position = socket.position;
		this.DoWeaponEffects(character.transform, position, point, socket, firstPerson, hitComponent, allowBlood, itemRep);
		float num2 = 1f;
		bool flag3 = sample.aim && sample.crouch;
		if (flag3)
		{
			num2 -= this.aimingRecoilSubtract + this.crouchRecoilSubtract * 0.5f;
		}
		else if (sample.aim)
		{
			num2 -= this.aimingRecoilSubtract;
		}
		else if (sample.crouch)
		{
			num2 -= this.crouchRecoilSubtract;
		}
		num2 = global::UnityEngine.Mathf.Clamp01(num2);
		float pitch = global::UnityEngine.Random.Range(this.recoilPitchMin, this.recoilPitchMax) * num2;
		float yaw = global::UnityEngine.Random.Range(this.recoilYawMin, this.recoilYawMax) * num2;
		if (global::BulletWeaponDataBlock.weaponRecoil && character.recoilSimulation)
		{
			character.recoilSimulation.AddRecoil(this.recoilDuration, pitch, yaw);
		}
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		this.WriteHitInfo(bitStream, ref eyesRay, flag, ref raycastHit, hitNetworkView, hitView);
		itemRep.ActionStream(1, 0, bitStream);
	}

	// Token: 0x060035F6 RID: 13814 RVA: 0x000CAF14 File Offset: 0x000C9114
	protected void WriteHitInfo(global::uLink.BitStream sendStream, ref global::UnityEngine.Ray ray, bool didHit, ref global::RaycastHit2 hit)
	{
		global::NetEntityID hitView;
		bool hitNetworkView;
		if (didHit)
		{
			global::IDBase id = hit.id;
			if (id && id.idMain)
			{
				hitView = global::NetEntityID.Get(id.idMain);
				hitNetworkView = !hitView.isUnassigned;
			}
			else
			{
				hitNetworkView = false;
				hitView = global::NetEntityID.unassigned;
			}
		}
		else
		{
			hitView = global::NetEntityID.unassigned;
			hitNetworkView = false;
		}
		this.WriteHitInfo(sendStream, ref ray, didHit, ref hit, hitNetworkView, hitView);
	}

	// Token: 0x060035F7 RID: 13815 RVA: 0x000CAF88 File Offset: 0x000C9188
	protected virtual void WriteHitInfo(global::uLink.BitStream sendStream, ref global::UnityEngine.Ray ray, bool didHit, ref global::RaycastHit2 hit, bool hitNetworkView, global::NetEntityID hitView)
	{
		global::UnityEngine.Vector3 vector;
		if (didHit)
		{
			if (hitNetworkView)
			{
				global::IDRemoteBodyPart remoteBodyPart = hit.remoteBodyPart;
				global::UnityEngine.Transform transform;
				if (remoteBodyPart)
				{
					sendStream.WriteByte(remoteBodyPart.bodyPart);
					transform = remoteBodyPart.transform;
				}
				else
				{
					sendStream.WriteByte(0xFE);
					transform = hitView.transform;
				}
				sendStream.Write<global::NetEntityID>(hitView, new object[0]);
				vector = transform.InverseTransformPoint(hit.point);
			}
			else
			{
				sendStream.WriteByte(byte.MaxValue);
				vector = hit.point;
			}
		}
		else
		{
			sendStream.WriteByte(byte.MaxValue);
			vector = ray.GetPoint(1000f);
		}
		sendStream.WriteVector3(vector);
	}

	// Token: 0x060035F8 RID: 13816 RVA: 0x000CB038 File Offset: 0x000C9238
	protected virtual void ReadHitInfo(global::uLink.BitStream stream, out global::UnityEngine.GameObject hitObj, out bool hitNetworkObj, out bool hitBodyPart, out global::BodyPart bodyPart, out global::IDRemoteBodyPart remoteBodyPart, out global::NetEntityID hitViewID, out global::UnityEngine.Transform fromTransform, out global::UnityEngine.Vector3 endPos, out global::UnityEngine.Vector3 offset, out bool isHeadshot)
	{
		byte b = stream.ReadByte();
		if (b < 0xFF)
		{
			hitNetworkObj = true;
			if (b < 0x78)
			{
				hitBodyPart = true;
				bodyPart = (int)b;
			}
			else
			{
				hitBodyPart = false;
				bodyPart = 0;
			}
		}
		else
		{
			hitNetworkObj = false;
			hitBodyPart = false;
			bodyPart = 0;
		}
		if (hitNetworkObj)
		{
			hitViewID = stream.Read<global::NetEntityID>(new object[0]);
			if (!hitViewID.isUnassigned)
			{
				hitObj = hitViewID.gameObject;
				if (hitObj)
				{
					global::IDBase idbase = global::IDBase.Get(hitObj);
					if (idbase)
					{
						global::IDMain idMain = idbase.idMain;
						if (idMain)
						{
							global::HitBoxSystem hitBoxSystem;
							if (idMain is global::Character)
							{
								hitBoxSystem = ((global::Character)idMain).hitBoxSystem;
							}
							else
							{
								hitBoxSystem = idMain.GetRemote<global::HitBoxSystem>();
							}
							if (hitBoxSystem)
							{
								hitBoxSystem.bodyParts.TryGetValue(bodyPart, ref remoteBodyPart);
							}
							else
							{
								remoteBodyPart = null;
							}
						}
						else
						{
							remoteBodyPart = null;
						}
					}
					else
					{
						remoteBodyPart = null;
					}
				}
				else
				{
					remoteBodyPart = null;
				}
			}
			else
			{
				hitObj = null;
				remoteBodyPart = null;
			}
		}
		else
		{
			hitViewID = global::NetEntityID.unassigned;
			hitObj = null;
			remoteBodyPart = null;
		}
		endPos = stream.ReadVector3();
		offset = global::UnityEngine.Vector3.zero;
		if (remoteBodyPart)
		{
			fromTransform = remoteBodyPart.transform;
			global::BodyPart bodyPart2 = bodyPart;
			switch (bodyPart2)
			{
			case 0x10:
			case 0x14:
			case 0x15:
				break;
			default:
				switch (bodyPart2)
				{
				case 9:
				case 0xC:
					goto IL_1A3;
				}
				isHeadshot = false;
				goto IL_1B5;
			}
			IL_1A3:
			isHeadshot = true;
			IL_1B5:;
		}
		else if (hitObj)
		{
			fromTransform = hitObj.transform;
			isHeadshot = false;
		}
		else
		{
			fromTransform = null;
			isHeadshot = false;
		}
		if (fromTransform)
		{
			offset = endPos;
			endPos = fromTransform.TransformPoint(endPos);
		}
	}

	// Token: 0x060035F9 RID: 13817 RVA: 0x000CB260 File Offset: 0x000C9460
	public override void DoAction1(global::uLink.BitStream stream, global::ItemRepresentation rep, ref global::uLink.NetworkMessageInfo info)
	{
		global::NetCull.VerifyRPC(ref info, false);
		global::UnityEngine.GameObject gameObject;
		bool flag;
		bool flag2;
		global::BodyPart bodyPart;
		global::IDRemoteBodyPart idremoteBodyPart;
		global::NetEntityID netEntityID;
		global::UnityEngine.Transform fromTransform;
		global::UnityEngine.Vector3 vector;
		global::UnityEngine.Vector3 vector2;
		bool isHeadshot;
		this.ReadHitInfo(stream, out gameObject, out flag, out flag2, out bodyPart, out idremoteBodyPart, out netEntityID, out fromTransform, out vector, out vector2, out isHeadshot);
		global::IBulletWeaponItem bulletWeaponItem;
		if (!rep.Item<global::IBulletWeaponItem>(out bulletWeaponItem))
		{
			return;
		}
		if (!bulletWeaponItem.ValidatePrimaryMessageTime(info.timestamp))
		{
			return;
		}
		if (bulletWeaponItem.uses <= 0)
		{
			return;
		}
		global::TakeDamage local = bulletWeaponItem.inventory.GetLocal<global::TakeDamage>();
		if (local && local.dead)
		{
			return;
		}
		int num = 1;
		bulletWeaponItem.Consume(ref num);
		if (gameObject)
		{
		}
		rep.ActionStream(1, 0xA, stream);
		if (gameObject)
		{
			this.ApplyDamage(gameObject, fromTransform, isHeadshot, vector, bodyPart, rep);
		}
		if (global::gunshots.aiscared)
		{
			local.GetComponent<global::Character>().AudibleMessage(20f, "HearDanger", local.transform.position);
			local.GetComponent<global::Character>().AudibleMessage(10f, "HearDanger", vector);
		}
		if (bulletWeaponItem.TryConditionLoss(0.33f, 0.01f))
		{
		}
	}

	// Token: 0x060035FA RID: 13818 RVA: 0x000CB38C File Offset: 0x000C958C
	protected void ApplyDamage(global::UnityEngine.GameObject hitObj, global::UnityEngine.Transform fromTransform, bool isHeadshot, global::UnityEngine.Vector3 endPos, global::BodyPart bodyPart, global::ItemRepresentation rep)
	{
		global::IDBase idbase = global::IDBase.Get(hitObj);
		if (idbase)
		{
			float num = this.GetDamage(rep);
			if (this.IsSilenced(rep))
			{
				num *= 0.75f;
			}
			if (isHeadshot)
			{
				global::Character character;
				bool main = global::IDBase.GetMain<global::Character>(hitObj, ref character);
				if (main)
				{
					if (character.aiControlled)
					{
						num *= 8f;
					}
					else if (character.playerControlled)
					{
						num *= 3f;
					}
				}
			}
			global::UnityEngine.Vector3 vector = endPos;
			global::UnityEngine.Vector3 vector2 = vector - ((rep.muzzle != null) ? rep.muzzle.position : rep.transform.position);
			global::IDBase idbase2;
			if (fromTransform)
			{
				vector = fromTransform.InverseTransformPoint(vector);
				vector2 = fromTransform.InverseTransformDirection(vector2).normalized;
				idbase2 = fromTransform.GetComponent<global::IDRemoteBodyPart>();
				if (!idbase2)
				{
					idbase2 = fromTransform.GetComponent<global::IDBase>();
				}
			}
			else
			{
				vector2.Normalize();
				idbase2 = global::IDBase.Get(hitObj);
				if (idbase2)
				{
					idbase2 = idbase2.idMain;
				}
			}
			global::IBulletWeaponItem bulletWeaponItem;
			if (rep.Item<global::IBulletWeaponItem>(out bulletWeaponItem))
			{
				global::TakeDamage.Hurt(bulletWeaponItem.inventory, idbase2, new global::DamageTypeList(0f, num, 0f, 0f, 0f, 0f), new global::BulletWeaponImpact(this, bulletWeaponItem, rep, fromTransform, vector, vector2));
			}
		}
	}

	// Token: 0x060035FB RID: 13819 RVA: 0x000CB4FC File Offset: 0x000C96FC
	public virtual float GetBulletRange(global::ItemRepresentation itemRep)
	{
		if (!itemRep)
		{
			return this.bulletRange;
		}
		return this.bulletRange * ((!this.IsSilenced(itemRep)) ? 1f : 0.75f);
	}

	// Token: 0x060035FC RID: 13820 RVA: 0x000CB540 File Offset: 0x000C9740
	public virtual float GetDamage(global::ItemRepresentation itemRep)
	{
		float num = global::UnityEngine.Random.Range(this.damageMin, this.damageMax);
		return num * ((!this.IsSilenced(itemRep)) ? 1f : 0.8f);
	}

	// Token: 0x060035FD RID: 13821 RVA: 0x000CB57C File Offset: 0x000C977C
	public virtual bool IsSilenced(global::ItemRepresentation itemRep)
	{
		return (itemRep.modFlags & global::ItemModFlags.Audio) == global::ItemModFlags.Audio;
	}

	// Token: 0x060035FE RID: 13822 RVA: 0x000CB58C File Offset: 0x000C978C
	public virtual global::UnityEngine.AudioClip GetFireSound(global::ItemRepresentation itemRep)
	{
		if (this.IsSilenced(itemRep))
		{
			return this.fireSound_Silenced;
		}
		return this.fireSound;
	}

	// Token: 0x060035FF RID: 13823 RVA: 0x000CB5A8 File Offset: 0x000C97A8
	public virtual global::UnityEngine.AudioClip GetFarFireSound(global::ItemRepresentation itemRep)
	{
		if (this.IsSilenced(itemRep))
		{
			return this.fireSound_SilencedFar;
		}
		return this.fireSound_Far;
	}

	// Token: 0x06003600 RID: 13824 RVA: 0x000CB5C4 File Offset: 0x000C97C4
	public virtual float GetFireSoundRangeMin()
	{
		return 2f;
	}

	// Token: 0x06003601 RID: 13825 RVA: 0x000CB5CC File Offset: 0x000C97CC
	public virtual float GetFireSoundRangeMax()
	{
		return 60f;
	}

	// Token: 0x06003602 RID: 13826 RVA: 0x000CB5D4 File Offset: 0x000C97D4
	public virtual float GetFarFireSoundRangeMin()
	{
		return this.GetFireSoundRangeMax() * 0.5f;
	}

	// Token: 0x06003603 RID: 13827 RVA: 0x000CB5E4 File Offset: 0x000C97E4
	public virtual float GetFarFireSoundRangeMax()
	{
		return this.fireSoundRange;
	}

	// Token: 0x06003604 RID: 13828 RVA: 0x000CB5EC File Offset: 0x000C97EC
	public virtual void PlayFireSound(global::UnityEngine.Transform soundTransform, bool firstPerson, global::ItemRepresentation itemRep)
	{
		bool flag = this.IsSilenced(itemRep);
		global::UnityEngine.AudioClip clip = this.GetFireSound(itemRep);
		float num = global::UnityEngine.Vector3.Distance(soundTransform.position, global::UnityEngine.Camera.main.transform.position);
		float farFireSoundRangeMin = this.GetFarFireSoundRangeMin();
		clip.PlayLocal(soundTransform, global::UnityEngine.Vector3.zero, 1f, global::UnityEngine.Random.Range(0.92f, 1.08f), this.GetFireSoundRangeMin(), this.GetFireSoundRangeMax() * ((!flag) ? 1f : 1.5f), (!firstPerson) ? 0x14 : 0);
		if (!firstPerson && num > farFireSoundRangeMin && !flag)
		{
			global::UnityEngine.AudioClip farFireSound = this.GetFarFireSound(itemRep);
			if (farFireSound)
			{
				farFireSound.PlayLocal(soundTransform, global::UnityEngine.Vector3.zero, 1f, global::UnityEngine.Random.Range(0.9f, 1.1f), 0f, this.GetFarFireSoundRangeMax(), 0x32);
			}
		}
	}

	// Token: 0x06003605 RID: 13829 RVA: 0x000CB6D4 File Offset: 0x000C98D4
	public virtual void DoWeaponEffects(global::UnityEngine.Transform soundTransform, global::UnityEngine.Vector3 startPos, global::UnityEngine.Vector3 endPos, global::Socket muzzleSocket, bool firstPerson, global::UnityEngine.Component hitComponent, bool allowBlood, global::ItemRepresentation itemRep)
	{
		global::UnityEngine.Vector3 vector = endPos - startPos;
		vector.Normalize();
		bool flag = this.IsSilenced(itemRep);
		global::UnityEngine.GameObject gameObject = (global::UnityEngine.GameObject)global::UnityEngine.Object.Instantiate(this.tracerPrefab, startPos, global::UnityEngine.Quaternion.LookRotation(vector));
		global::Tracer component = gameObject.GetComponent<global::Tracer>();
		if (component)
		{
			component.Init(hitComponent, 0x183E1411, this.GetBulletRange(itemRep), allowBlood);
		}
		if (flag)
		{
			component.startScale = global::UnityEngine.Vector3.zero;
		}
		this.PlayFireSound(soundTransform, firstPerson, itemRep);
		if (!flag)
		{
			global::UnityEngine.GameObject gameObject2 = muzzleSocket.InstantiateAsChild((!firstPerson) ? this.muzzleFlashWorld : this.muzzleflashVM, false);
			global::UnityEngine.Object.Destroy(gameObject2, 1f);
		}
	}

	// Token: 0x06003606 RID: 13830 RVA: 0x000CB790 File Offset: 0x000C9990
	public override void DoAction2(global::uLink.BitStream stream, global::ItemRepresentation itemRep, ref global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x06003607 RID: 13831 RVA: 0x000CB794 File Offset: 0x000C9994
	public override void DoAction3(global::uLink.BitStream stream, global::ItemRepresentation itemRep, ref global::uLink.NetworkMessageInfo info)
	{
		global::NetCull.VerifyRPC(ref info, false);
		global::IBulletWeaponItem bulletWeaponItem;
		if (itemRep.Item<global::IBulletWeaponItem>(out bulletWeaponItem))
		{
			bulletWeaponItem.ActualReload();
		}
	}

	// Token: 0x06003608 RID: 13832 RVA: 0x000CB7BC File Offset: 0x000C99BC
	public virtual float GetGUIDamage()
	{
		return this.damageMin + (this.damageMax - this.damageMin) * 0.5f;
	}

	// Token: 0x06003609 RID: 13833 RVA: 0x000CB7D8 File Offset: 0x000C99D8
	public override void PopulateInfoWindow(global::ItemToolTip infoWindow, global::IInventoryItem tipItem)
	{
		infoWindow.AddItemTitle(this, tipItem, 0f);
		infoWindow.AddConditionInfo(tipItem);
		infoWindow.AddSectionTitle("Weapon Stats", 20f);
		float currentAmount = this.recoilPitchMax + this.recoilYawMax;
		float maxAmount = 60f;
		float currentAmount2 = 1f / this.fireRate;
		if (this.isSemiAuto)
		{
			infoWindow.AddBasicLabel("Semi Automatic Weapon", 15f);
		}
		else
		{
			infoWindow.AddProgressStat("Fire Rate", currentAmount2, 12f, 15f);
		}
		infoWindow.AddProgressStat("Damage", this.GetGUIDamage(), 100f, 15f);
		infoWindow.AddProgressStat("Recoil", currentAmount, maxAmount, 15f);
		infoWindow.AddProgressStat("Range", this.GetBulletRange(null), 200f, 15f);
		infoWindow.AddItemDescription(this, 15f);
		infoWindow.FinishPopulating();
	}

	// Token: 0x0600360A RID: 13834 RVA: 0x000CB8C4 File Offset: 0x000C9AC4
	public override string GetItemDescription()
	{
		return "This is a weapon. Drag it to your belt (right side of screen) and press the corresponding number key to use it.";
	}

	// Token: 0x0600360B RID: 13835 RVA: 0x000CB8CC File Offset: 0x000C9ACC
	protected override void SecureWriteMemberValues(global::uLink.BitStream stream)
	{
		base.SecureWriteMemberValues(stream);
		stream.Write<int>(0x183E1411, new object[0]);
		stream.Write<float>(this.crouchRecoilSubtract, new object[0]);
		stream.Write<int>(this.maxClipAmmo, new object[0]);
		stream.Write<float>(this.recoilPitchMin, new object[0]);
		stream.Write<float>(this.recoilPitchMax, new object[0]);
		stream.Write<float>(this.recoilYawMin, new object[0]);
		stream.Write<float>(this.recoilYawMax, new object[0]);
		stream.Write<float>(this.recoilDuration, new object[0]);
		stream.Write<float>(this.aimingRecoilSubtract, new object[0]);
		stream.Write<int>((!this.ammoType) ? 0 : this.ammoType.uniqueID, new object[0]);
	}

	// Token: 0x04001D57 RID: 7511
	public const int hitMask = 0x183E1411;

	// Token: 0x04001D58 RID: 7512
	private const byte kDidNotHitNetworkView = 0xFF;

	// Token: 0x04001D59 RID: 7513
	private const byte kDidHitNetworkViewWithoutBodyPart = 0xFE;

	// Token: 0x04001D5A RID: 7514
	public global::AmmoItemDataBlock ammoType;

	// Token: 0x04001D5B RID: 7515
	public int maxClipAmmo;

	// Token: 0x04001D5C RID: 7516
	public global::UnityEngine.GameObject tracerPrefab;

	// Token: 0x04001D5D RID: 7517
	public global::UnityEngine.GameObject muzzleflashVM;

	// Token: 0x04001D5E RID: 7518
	public global::UnityEngine.GameObject muzzleFlashWorld;

	// Token: 0x04001D5F RID: 7519
	public global::UnityEngine.AudioClip fireSound;

	// Token: 0x04001D60 RID: 7520
	public global::UnityEngine.AudioClip fireSound_Far;

	// Token: 0x04001D61 RID: 7521
	public global::UnityEngine.AudioClip reloadSound;

	// Token: 0x04001D62 RID: 7522
	public global::UnityEngine.AudioClip headshotSound;

	// Token: 0x04001D63 RID: 7523
	public global::UnityEngine.AudioClip fireSound_SilencedFar;

	// Token: 0x04001D64 RID: 7524
	public global::UnityEngine.AudioClip fireSound_Silenced;

	// Token: 0x04001D65 RID: 7525
	public global::UnityEngine.AudioClip dryFireSound;

	// Token: 0x04001D66 RID: 7526
	public float fireSoundRange = 300f;

	// Token: 0x04001D67 RID: 7527
	public float bulletRange = 200f;

	// Token: 0x04001D68 RID: 7528
	public float recoilPitchMin;

	// Token: 0x04001D69 RID: 7529
	public float recoilPitchMax;

	// Token: 0x04001D6A RID: 7530
	public float recoilYawMin;

	// Token: 0x04001D6B RID: 7531
	public float recoilYawMax;

	// Token: 0x04001D6C RID: 7532
	public float recoilDuration;

	// Token: 0x04001D6D RID: 7533
	public float aimingRecoilSubtract = 0.5f;

	// Token: 0x04001D6E RID: 7534
	public float crouchRecoilSubtract = 0.2f;

	// Token: 0x04001D6F RID: 7535
	public float reloadDuration = 1.5f;

	// Token: 0x04001D70 RID: 7536
	public int maxEligableSlots = 5;

	// Token: 0x04001D71 RID: 7537
	public bool NoAimingAfterShot;

	// Token: 0x04001D72 RID: 7538
	public float aimSway;

	// Token: 0x04001D73 RID: 7539
	public float aimSwaySpeed = 1f;

	// Token: 0x04001D74 RID: 7540
	public global::BobEffect shotBob;

	// Token: 0x04001D75 RID: 7541
	private static bool weaponRecoil = true;

	// Token: 0x04001D76 RID: 7542
	private static bool headRecoil = true;

	// Token: 0x02000682 RID: 1666
	private sealed class ITEM_TYPE : global::BulletWeaponItem<global::BulletWeaponDataBlock>, global::IBulletWeaponItem, global::IHeldItem, global::IInventoryItem, global::IWeaponItem
	{
		// Token: 0x0600360C RID: 13836 RVA: 0x000CB9B0 File Offset: 0x000C9BB0
		public ITEM_TYPE(global::BulletWeaponDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000AEF RID: 2799
		// (get) Token: 0x0600360D RID: 13837 RVA: 0x000CB9BC File Offset: 0x000C9BBC
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x0600360E RID: 13838 RVA: 0x000CB9C4 File Offset: 0x000C9BC4
		global::MagazineDataBlock get_clipType()
		{
			return base.clipType;
		}

		// Token: 0x0600360F RID: 13839 RVA: 0x000CB9CC File Offset: 0x000C9BCC
		int get_clipAmmo()
		{
			return base.clipAmmo;
		}

		// Token: 0x06003610 RID: 13840 RVA: 0x000CB9D4 File Offset: 0x000C9BD4
		void set_clipAmmo(int value)
		{
			base.clipAmmo = value;
		}

		// Token: 0x06003611 RID: 13841 RVA: 0x000CB9E0 File Offset: 0x000C9BE0
		int get_cachedCasings()
		{
			return base.cachedCasings;
		}

		// Token: 0x06003612 RID: 13842 RVA: 0x000CB9E8 File Offset: 0x000C9BE8
		void set_cachedCasings(int value)
		{
			base.cachedCasings = value;
		}

		// Token: 0x06003613 RID: 13843 RVA: 0x000CB9F4 File Offset: 0x000C9BF4
		float get_nextCasingsTime()
		{
			return base.nextCasingsTime;
		}

		// Token: 0x06003614 RID: 13844 RVA: 0x000CB9FC File Offset: 0x000C9BFC
		void set_nextCasingsTime(float value)
		{
			base.nextCasingsTime = value;
		}

		// Token: 0x06003615 RID: 13845 RVA: 0x000CBA08 File Offset: 0x000C9C08
		bool ValidatePrimaryMessageTime(double timestamp)
		{
			return base.ValidatePrimaryMessageTime(timestamp);
		}

		// Token: 0x06003616 RID: 13846 RVA: 0x000CBA14 File Offset: 0x000C9C14
		bool get_canAim()
		{
			return base.canAim;
		}

		// Token: 0x06003617 RID: 13847 RVA: 0x000CBA1C File Offset: 0x000C9C1C
		float get_nextPrimaryAttackTime()
		{
			return base.nextPrimaryAttackTime;
		}

		// Token: 0x06003618 RID: 13848 RVA: 0x000CBA24 File Offset: 0x000C9C24
		void set_nextPrimaryAttackTime(float value)
		{
			base.nextPrimaryAttackTime = value;
		}

		// Token: 0x06003619 RID: 13849 RVA: 0x000CBA30 File Offset: 0x000C9C30
		float get_nextSecondaryAttackTime()
		{
			return base.nextSecondaryAttackTime;
		}

		// Token: 0x0600361A RID: 13850 RVA: 0x000CBA38 File Offset: 0x000C9C38
		void set_nextSecondaryAttackTime(float value)
		{
			base.nextSecondaryAttackTime = value;
		}

		// Token: 0x0600361B RID: 13851 RVA: 0x000CBA44 File Offset: 0x000C9C44
		float get_deployFinishedTime()
		{
			return base.deployFinishedTime;
		}

		// Token: 0x0600361C RID: 13852 RVA: 0x000CBA4C File Offset: 0x000C9C4C
		void set_deployFinishedTime(float value)
		{
			base.deployFinishedTime = value;
		}

		// Token: 0x0600361D RID: 13853 RVA: 0x000CBA58 File Offset: 0x000C9C58
		void SetTotalModSlotCount(int count)
		{
			base.SetTotalModSlotCount(count);
		}

		// Token: 0x0600361E RID: 13854 RVA: 0x000CBA64 File Offset: 0x000C9C64
		void SetUsedModSlotCount(int count)
		{
			base.SetUsedModSlotCount(count);
		}

		// Token: 0x0600361F RID: 13855 RVA: 0x000CBA70 File Offset: 0x000C9C70
		void AddMod(global::ItemModDataBlock mod)
		{
			base.AddMod(mod);
		}

		// Token: 0x06003620 RID: 13856 RVA: 0x000CBA7C File Offset: 0x000C9C7C
		int FindMod(global::ItemModDataBlock mod)
		{
			return base.FindMod(mod);
		}

		// Token: 0x06003621 RID: 13857 RVA: 0x000CBA88 File Offset: 0x000C9C88
		void OnActivate()
		{
			base.OnActivate();
		}

		// Token: 0x06003622 RID: 13858 RVA: 0x000CBA90 File Offset: 0x000C9C90
		void OnDeactivate()
		{
			base.OnDeactivate();
		}

		// Token: 0x06003623 RID: 13859 RVA: 0x000CBA98 File Offset: 0x000C9C98
		global::ViewModel get_viewModelInstance()
		{
			return base.viewModelInstance;
		}

		// Token: 0x06003624 RID: 13860 RVA: 0x000CBAA0 File Offset: 0x000C9CA0
		global::ItemRepresentation get_itemRepresentation()
		{
			return base.itemRepresentation;
		}

		// Token: 0x06003625 RID: 13861 RVA: 0x000CBAA8 File Offset: 0x000C9CA8
		void set_itemRepresentation(global::ItemRepresentation value)
		{
			base.itemRepresentation = value;
		}

		// Token: 0x06003626 RID: 13862 RVA: 0x000CBAB4 File Offset: 0x000C9CB4
		bool get_canActivate()
		{
			return base.canActivate;
		}

		// Token: 0x06003627 RID: 13863 RVA: 0x000CBABC File Offset: 0x000C9CBC
		bool get_canDeactivate()
		{
			return base.canDeactivate;
		}

		// Token: 0x06003628 RID: 13864 RVA: 0x000CBAC4 File Offset: 0x000C9CC4
		global::ItemModFlags get_modFlags()
		{
			return base.modFlags;
		}

		// Token: 0x06003629 RID: 13865 RVA: 0x000CBACC File Offset: 0x000C9CCC
		global::ItemModDataBlock[] get_itemMods()
		{
			return base.itemMods;
		}

		// Token: 0x0600362A RID: 13866 RVA: 0x000CBAD4 File Offset: 0x000C9CD4
		int get_totalModSlots()
		{
			return base.totalModSlots;
		}

		// Token: 0x0600362B RID: 13867 RVA: 0x000CBADC File Offset: 0x000C9CDC
		int get_usedModSlots()
		{
			return base.usedModSlots;
		}

		// Token: 0x0600362C RID: 13868 RVA: 0x000CBAE4 File Offset: 0x000C9CE4
		int get_freeModSlots()
		{
			return base.freeModSlots;
		}

		// Token: 0x0600362D RID: 13869 RVA: 0x000CBAEC File Offset: 0x000C9CEC
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x0600362E RID: 13870 RVA: 0x000CBAF4 File Offset: 0x000C9CF4
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x0600362F RID: 13871 RVA: 0x000CBAFC File Offset: 0x000C9CFC
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x06003630 RID: 13872 RVA: 0x000CBB04 File Offset: 0x000C9D04
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x06003631 RID: 13873 RVA: 0x000CBB10 File Offset: 0x000C9D10
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x06003632 RID: 13874 RVA: 0x000CBB1C File Offset: 0x000C9D1C
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x06003633 RID: 13875 RVA: 0x000CBB28 File Offset: 0x000C9D28
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x06003634 RID: 13876 RVA: 0x000CBB34 File Offset: 0x000C9D34
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x06003635 RID: 13877 RVA: 0x000CBB40 File Offset: 0x000C9D40
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x06003636 RID: 13878 RVA: 0x000CBB4C File Offset: 0x000C9D4C
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x06003637 RID: 13879 RVA: 0x000CBB58 File Offset: 0x000C9D58
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x06003638 RID: 13880 RVA: 0x000CBB64 File Offset: 0x000C9D64
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x06003639 RID: 13881 RVA: 0x000CBB6C File Offset: 0x000C9D6C
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x0600363A RID: 13882 RVA: 0x000CBB78 File Offset: 0x000C9D78
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x0600363B RID: 13883 RVA: 0x000CBB84 File Offset: 0x000C9D84
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x0600363C RID: 13884 RVA: 0x000CBB8C File Offset: 0x000C9D8C
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x0600363D RID: 13885 RVA: 0x000CBB94 File Offset: 0x000C9D94
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x0600363E RID: 13886 RVA: 0x000CBB9C File Offset: 0x000C9D9C
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x0600363F RID: 13887 RVA: 0x000CBBA4 File Offset: 0x000C9DA4
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x06003640 RID: 13888 RVA: 0x000CBBAC File Offset: 0x000C9DAC
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x06003641 RID: 13889 RVA: 0x000CBBB4 File Offset: 0x000C9DB4
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x06003642 RID: 13890 RVA: 0x000CBBBC File Offset: 0x000C9DBC
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x06003643 RID: 13891 RVA: 0x000CBBC8 File Offset: 0x000C9DC8
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x06003644 RID: 13892 RVA: 0x000CBBD0 File Offset: 0x000C9DD0
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x06003645 RID: 13893 RVA: 0x000CBBD8 File Offset: 0x000C9DD8
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x06003646 RID: 13894 RVA: 0x000CBBE0 File Offset: 0x000C9DE0
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x06003647 RID: 13895 RVA: 0x000CBBE8 File Offset: 0x000C9DE8
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x06003648 RID: 13896 RVA: 0x000CBBF0 File Offset: 0x000C9DF0
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x06003649 RID: 13897 RVA: 0x000CBBF8 File Offset: 0x000C9DF8
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}
}
