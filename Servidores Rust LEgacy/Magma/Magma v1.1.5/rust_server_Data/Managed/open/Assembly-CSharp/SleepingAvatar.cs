using System;
using System.Collections.Generic;
using POSIX;
using RustProto;
using RustProto.Helpers;
using uLink;
using UnityEngine;

// Token: 0x02000797 RID: 1943
[global::NGCAutoAddScript]
public class SleepingAvatar : global::DeployableObject, global::IServerSaveable
{
	// Token: 0x0600409E RID: 16542 RVA: 0x000E72F0 File Offset: 0x000E54F0
	public SleepingAvatar()
	{
	}

	// Token: 0x0600409F RID: 16543 RVA: 0x000E72F8 File Offset: 0x000E54F8
	public void OnKilled(global::DamageEvent damageEvent)
	{
		try
		{
			ulong attackerUserID;
			try
			{
				attackerUserID = damageEvent.attacker.userID;
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex);
				attackerUserID = 0UL;
			}
			global::SleepingAvatar.KillQuery killQuery = new global::SleepingAvatar.KillQuery(this.creatorID, ";drop_lootsack", attackerUserID);
			killQuery.Commit();
		}
		catch (global::System.Exception ex2)
		{
			global::UnityEngine.Debug.LogException(ex2, this);
		}
		finally
		{
			this.UnRegister();
		}
		try
		{
			base.OnKilled();
		}
		catch (global::System.Exception ex3)
		{
			global::UnityEngine.Debug.LogException(ex3, this);
		}
		finally
		{
			if (this && base.gameObject)
			{
				global::NetCull.Destroy(base.gameObject);
			}
		}
	}

	// Token: 0x060040A0 RID: 16544 RVA: 0x000E7418 File Offset: 0x000E5618
	private bool Register()
	{
		return !this.registered && global::SleepingAvatar.Registry.Register(this);
	}

	// Token: 0x060040A1 RID: 16545 RVA: 0x000E7430 File Offset: 0x000E5630
	private bool UnRegister()
	{
		return this.registered && global::SleepingAvatar.Registry.UnRegister(this);
	}

	// Token: 0x060040A2 RID: 16546 RVA: 0x000E7448 File Offset: 0x000E5648
	public static bool Open(global::Character character)
	{
		if (!global::sleepers.on)
		{
			return false;
		}
		global::NetUser netUser = character.netUser;
		if (object.ReferenceEquals(netUser, null))
		{
			return false;
		}
		global::CharacterSleepingAvatarTrait trait = character.GetTrait<global::CharacterSleepingAvatarTrait>();
		if (!trait.valid)
		{
			return false;
		}
		if (global::sleepers.loglevel > 2)
		{
			global::UnityEngine.Debug.Log("sleeper:Checking if theres a sleeper for " + character, character);
		}
		if (global::SleepingAvatar.IsOpen(netUser))
		{
			if (global::sleepers.loglevel > 0)
			{
				global::UnityEngine.Debug.LogWarning(string.Format("sleeper:A sleeping avatar already open for {0}", netUser), character);
			}
			return false;
		}
		if (global::sleepers.loglevel > 2)
		{
			global::UnityEngine.Debug.Log("sleeper:Getting ground info for " + character, character);
		}
		global::UnityEngine.Vector3 origin;
		global::UnityEngine.Vector3 y;
		global::TransformHelpers.GetGroundInfoNoTransform(character.origin, out origin, out y);
		global::UnityEngine.Quaternion groundInfoRotation = global::TransformHelpers.GetGroundInfoRotation(character.rotation, y);
		if (global::sleepers.loglevel > 2)
		{
			global::UnityEngine.Debug.Log("sleeper:Spawning sleeper for " + character, character);
		}
		global::UnityEngine.GameObject gameObject = global::NetCull.InstantiateStatic(trait.prefab, trait.SolvePlacement(origin, groundInfoRotation, global::sleepers.pointsolver), groundInfoRotation);
		if (!gameObject)
		{
			if (global::sleepers.loglevel > 0)
			{
				global::UnityEngine.Debug.LogError("sleeper:Couldnt create sleeping avatar " + trait.prefab, character);
			}
			return false;
		}
		global::SleepingAvatar component = gameObject.GetComponent<global::SleepingAvatar>();
		if (global::sleepers.loglevel > 2)
		{
			global::UnityEngine.Debug.Log("sleeper:Setting up for character " + character, character);
		}
		component.SetupCharacter(character, netUser, trait);
		return component;
	}

	// Token: 0x060040A3 RID: 16547 RVA: 0x000E75A4 File Offset: 0x000E57A4
	internal static global::SleepingAvatar.TransientData Close(ulong UserID)
	{
		global::SleepingAvatar sleepingAvatar;
		if (global::SleepingAvatar.Registry.Find(UserID, out sleepingAvatar))
		{
			global::SleepingAvatar.TransientData result = global::SleepingAvatar.TransientData.Collect(sleepingAvatar);
			sleepingAvatar.UnRegister();
			global::NetCull.Destroy(sleepingAvatar.gameObject);
			return result;
		}
		return default(global::SleepingAvatar.TransientData);
	}

	// Token: 0x060040A4 RID: 16548 RVA: 0x000E75E4 File Offset: 0x000E57E4
	internal static void Kill(ulong UserID)
	{
		global::SleepingAvatar sleepingAvatar;
		if (global::SleepingAvatar.Registry.Find(UserID, out sleepingAvatar))
		{
			global::DamageEvent damageEvent;
			global::TakeDamage.Kill(sleepingAvatar, sleepingAvatar, out damageEvent, null);
			if (sleepingAvatar)
			{
				global::NetCull.Destroy(sleepingAvatar.gameObject);
			}
		}
	}

	// Token: 0x060040A5 RID: 16549 RVA: 0x000E7620 File Offset: 0x000E5820
	internal static bool IsOpen(ulong UserID)
	{
		global::SleepingAvatar sleepingAvatar;
		return global::SleepingAvatar.Registry.Find(UserID, out sleepingAvatar);
	}

	// Token: 0x060040A6 RID: 16550 RVA: 0x000E7638 File Offset: 0x000E5838
	public static bool IsOpen(global::NetUser user)
	{
		return !object.ReferenceEquals(user, null) && !object.ReferenceEquals(user.user, null) && user.user.HasUserid && global::SleepingAvatar.IsOpen(user.user.Userid);
	}

	// Token: 0x060040A7 RID: 16551 RVA: 0x000E7688 File Offset: 0x000E5888
	public static global::SleepingAvatar.TransientData Close(global::NetUser user)
	{
		if (!object.ReferenceEquals(user, null) && !object.ReferenceEquals(user.user, null) && user.user.HasUserid)
		{
			return global::SleepingAvatar.Close(user.user.Userid);
		}
		return default(global::SleepingAvatar.TransientData);
	}

	// Token: 0x060040A8 RID: 16552 RVA: 0x000E76DC File Offset: 0x000E58DC
	public static void CloseAll(bool andKill, bool areYouSureYouWantToDoThis__Its_Undoable)
	{
		if (!areYouSureYouWantToDoThis__Its_Undoable)
		{
			return;
		}
		global::SleepingAvatar.Registry.Clear(andKill);
	}

	// Token: 0x060040A9 RID: 16553 RVA: 0x000E76EC File Offset: 0x000E58EC
	[global::NGCRPC]
	protected void SAAM(int footArmorUID, int legArmorUID, int torsoArmorUID, int headArmorUID)
	{
		if (footArmorUID == 0)
		{
			this.footArmor = null;
		}
		else
		{
			this.footArmor = (global::ArmorDataBlock)global::DatablockDictionary.GetByUniqueID(footArmorUID);
		}
		if (legArmorUID == 0)
		{
			this.legArmor = null;
		}
		else
		{
			this.legArmor = (global::ArmorDataBlock)global::DatablockDictionary.GetByUniqueID(legArmorUID);
		}
		if (torsoArmorUID == 0)
		{
			this.torsoArmor = null;
		}
		else
		{
			this.torsoArmor = (global::ArmorDataBlock)global::DatablockDictionary.GetByUniqueID(torsoArmorUID);
		}
		if (headArmorUID == 0)
		{
			this.headArmor = null;
		}
		else
		{
			this.headArmor = (global::ArmorDataBlock)global::DatablockDictionary.GetByUniqueID(headArmorUID);
		}
	}

	// Token: 0x060040AA RID: 16554 RVA: 0x000E7788 File Offset: 0x000E5988
	[global::NGCRPC]
	protected void SACH(global::NetEntityID makingForCharacterIDNow, global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x060040AB RID: 16555 RVA: 0x000E778C File Offset: 0x000E598C
	[global::NGCRPC]
	protected void SAKL(global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x060040AC RID: 16556 RVA: 0x000E7790 File Offset: 0x000E5990
	private static void DestroyFilter(ref global::UnityEngine.MeshFilter filter)
	{
		if (filter)
		{
			global::UnityEngine.Object.Destroy(filter.gameObject);
		}
		filter = null;
	}

	// Token: 0x060040AD RID: 16557 RVA: 0x000E77B0 File Offset: 0x000E59B0
	public new void NGC_OnInstantiate(global::NGCView view)
	{
		this.ngcView = view;
		base.NGC_OnInstantiate(view);
		this.takeDamage = base.GetLocal<global::TakeDamage>();
		global::SleepingAvatar.DestroyFilter(ref this.footMeshFilter);
		global::SleepingAvatar.DestroyFilter(ref this.legMeshFilter);
		global::SleepingAvatar.DestroyFilter(ref this.torsoMeshFilter);
		global::SleepingAvatar.DestroyFilter(ref this.headMeshFilter);
	}

	// Token: 0x060040AE RID: 16558 RVA: 0x000E7804 File Offset: 0x000E5A04
	public override void CreatorSet()
	{
		if (this.Register())
		{
			base.CreatorSet();
		}
	}

	// Token: 0x060040AF RID: 16559 RVA: 0x000E7818 File Offset: 0x000E5A18
	[global::System.Obsolete("You must use SetupCharacter on SleepingAvatar(s)", true)]
	public sealed override void SetupCreator(global::Controllable controllable)
	{
		throw new global::System.InvalidOperationException("You must use SetupCharacter on SleepingAvatar(s)");
	}

	// Token: 0x060040B0 RID: 16560 RVA: 0x000E7824 File Offset: 0x000E5A24
	public void SetupCharacter(global::Character character, global::NetUser user, global::CharacterSleepingAvatarTrait trait)
	{
		this.timeStamp = global::POSIX.Time.NowStamp;
		if (global::sleepers.loglevel > 2)
		{
			global::UnityEngine.Debug.Log("sleeper:Base setup creator " + character, character);
		}
		base.SetupCreator(character.controllable);
		global::PlayerInventory component = character.GetComponent<global::PlayerInventory>();
		this.footArmor = null;
		this.legArmor = null;
		this.torsoArmor = null;
		this.headArmor = null;
		if (global::sleepers.loglevel > 2)
		{
			global::UnityEngine.Debug.Log("sleeper:Looking for armor " + character, character);
		}
		using (global::Inventory.OccupiedIterator occupiedIterator = component.occupiedIterator)
		{
			global::IArmorItem armorItem;
			while (occupiedIterator.Next<global::IArmorItem>(out armorItem))
			{
				global::ArmorDataBlock armorDataBlock = armorItem.datablock as global::ArmorDataBlock;
				global::ArmorModelSlot armorModelSlot;
				if (armorDataBlock.GetArmorModelSlot(out armorModelSlot))
				{
					switch (armorModelSlot)
					{
					case global::ArmorModelSlot.Feet:
						this.footArmor = armorDataBlock;
						break;
					case global::ArmorModelSlot.Legs:
						this.legArmor = armorDataBlock;
						break;
					case global::ArmorModelSlot.Torso:
						this.torsoArmor = armorDataBlock;
						break;
					case global::ArmorModelSlot.Head:
						this.headArmor = armorDataBlock;
						break;
					default:
						throw new global::System.NotImplementedException();
					}
				}
			}
		}
		if (global::sleepers.loglevel > 2)
		{
			global::UnityEngine.Debug.Log("sleeper:buffering armor data " + character, character);
		}
		this.UpdateBufferedArmor();
		if (this.takeDamage)
		{
			global::TakeDamage takeDamage = character.takeDamage;
			if (takeDamage)
			{
				if (global::sleepers.loglevel > 2)
				{
					global::UnityEngine.Debug.Log("sleeper:copying take damage " + character, character);
				}
				takeDamage.CopyStateTo(this.takeDamage);
			}
		}
		if (global::sleepers.loglevel > 2)
		{
			global::UnityEngine.Debug.Log("sleeper:informing players in group this sleeper was created now. " + character, character);
		}
		this.ngcView.RPC<global::NetEntityID>("SACH", 1, global::NetEntityID.Get(character));
		if (trait.grabsCarrierOnCreate)
		{
			if (global::sleepers.loglevel > 2)
			{
				global::UnityEngine.Debug.Log("sleeper:grabbing carrier. " + character, character);
			}
			base.GrabCarrier();
		}
	}

	// Token: 0x060040B1 RID: 16561 RVA: 0x000E7A28 File Offset: 0x000E5C28
	private void UpdateBufferedArmor()
	{
		global::NetEntityID entID = global::NetEntityID.Get(this);
		bool flag = this.bufferedArmor;
		if (this.bufferedArmor)
		{
			global::NetCull.RemoveRPCsByName(entID, "SAAM");
			this.bufferedArmor = false;
		}
		int num = (!this.footArmor) ? 0 : this.footArmor.uniqueID;
		int num2 = (!this.legArmor) ? 0 : this.legArmor.uniqueID;
		int num3 = (!this.torsoArmor) ? 0 : this.torsoArmor.uniqueID;
		int num4 = (!this.headArmor) ? 0 : this.headArmor.uniqueID;
		if (flag || true)
		{
			global::NetCull.RPC<int, int, int, int>(entID, "SAAM", 5, num, num2, num3, num4);
			this.bufferedArmor = true;
		}
		if (this.takeDamage is global::ProtectionTakeDamage)
		{
			global::ProtectionTakeDamage protectionTakeDamage = (global::ProtectionTakeDamage)this.takeDamage;
			global::DamageTypeList damageTypeList = new global::DamageTypeList();
			if (num != 0)
			{
				this.footArmor.AddToDamageTypeList(damageTypeList);
			}
			if (num2 != 0)
			{
				this.legArmor.AddToDamageTypeList(damageTypeList);
			}
			if (num3 != 0)
			{
				this.torsoArmor.AddToDamageTypeList(damageTypeList);
			}
			if (num4 != 0)
			{
				this.headArmor.AddToDamageTypeList(damageTypeList);
			}
			protectionTakeDamage.SetArmorValues(damageTypeList);
		}
	}

	// Token: 0x060040B2 RID: 16562 RVA: 0x000E7B8C File Offset: 0x000E5D8C
	public new void WriteObjectSave(ref global::RustProto.SavedObject.Builder saveobj)
	{
		base.WriteObjectSave(ref saveobj);
		using (global::RustProto.Helpers.Recycler<global::RustProto.objectSleepingAvatar, global::RustProto.objectSleepingAvatar.Builder> recycler = global::RustProto.objectSleepingAvatar.Recycler())
		{
			global::RustProto.objectSleepingAvatar.Builder builder = recycler.OpenBuilder();
			if (this.footArmor)
			{
				builder.SetFootArmor(this.footArmor.uniqueID);
			}
			if (this.legArmor)
			{
				builder.SetLegArmor(this.legArmor.uniqueID);
			}
			if (this.torsoArmor)
			{
				builder.SetTorsoArmor(this.torsoArmor.uniqueID);
			}
			if (this.headArmor)
			{
				builder.SetHeadArmor(this.headArmor.uniqueID);
			}
			builder.SetTimestamp(this.timeStamp);
			global::SleepingAvatar.TransientData transientData = global::SleepingAvatar.TransientData.Collect(this);
			if (transientData.hasVitals)
			{
				builder.SetVitals(transientData.vitals);
			}
			saveobj.SetSleepingAvatar(builder);
		}
	}

	// Token: 0x060040B3 RID: 16563 RVA: 0x000E7C9C File Offset: 0x000E5E9C
	public new void ReadObjectSave(ref global::RustProto.SavedObject saveobj)
	{
		base.ReadObjectSave(ref saveobj);
		if (saveobj.HasSleepingAvatar)
		{
			global::RustProto.objectSleepingAvatar sleepingAvatar = saveobj.SleepingAvatar;
			if (!sleepingAvatar.HasTimestamp)
			{
				this.timeStamp = global::POSIX.Time.NowStamp - 0xA;
			}
			if (sleepingAvatar.HasFootArmor)
			{
				this.footArmor = (global::ArmorDataBlock)global::DatablockDictionary.GetByUniqueID(sleepingAvatar.FootArmor);
			}
			else
			{
				this.footArmor = null;
			}
			if (sleepingAvatar.HasLegArmor)
			{
				this.legArmor = (global::ArmorDataBlock)global::DatablockDictionary.GetByUniqueID(sleepingAvatar.LegArmor);
			}
			else
			{
				this.legArmor = null;
			}
			if (sleepingAvatar.HasTorsoArmor)
			{
				this.torsoArmor = (global::ArmorDataBlock)global::DatablockDictionary.GetByUniqueID(sleepingAvatar.TorsoArmor);
			}
			else
			{
				this.torsoArmor = null;
			}
			if (sleepingAvatar.HasHeadArmor)
			{
				this.headArmor = (global::ArmorDataBlock)global::DatablockDictionary.GetByUniqueID(sleepingAvatar.HeadArmor);
			}
			else
			{
				this.headArmor = null;
			}
			if (sleepingAvatar.HasVitals)
			{
				if (this.takeDamage)
				{
					this.takeDamage.LoadVitals(sleepingAvatar.Vitals);
				}
				else
				{
					global::UnityEngine.Debug.LogWarning("had vitals, but no takeDamage. Data was lost.");
				}
			}
			this.UpdateBufferedArmor();
		}
	}

	// Token: 0x060040B4 RID: 16564 RVA: 0x000E7DD4 File Offset: 0x000E5FD4
	protected new void OnDestroy()
	{
		try
		{
			base.OnDestroy();
		}
		finally
		{
			this.UnRegister();
		}
	}

	// Token: 0x040021AE RID: 8622
	private const string kPoseName = "sleep";

	// Token: 0x040021AF RID: 8623
	protected const string ArmorConfigRPC = "SAAM";

	// Token: 0x040021B0 RID: 8624
	protected const string SettingLiveCharacterNowRPC = "SACH";

	// Token: 0x040021B1 RID: 8625
	protected const string HasDiedNowRPC = "SAKL";

	// Token: 0x040021B2 RID: 8626
	private const string MustUseSetupCharacterError = "You must use SetupCharacter on SleepingAvatar(s)";

	// Token: 0x040021B3 RID: 8627
	[global::System.NonSerialized]
	private bool registered;

	// Token: 0x040021B4 RID: 8628
	[global::System.NonSerialized]
	public global::ArmorDataBlock footArmor;

	// Token: 0x040021B5 RID: 8629
	[global::System.NonSerialized]
	public global::ArmorDataBlock legArmor;

	// Token: 0x040021B6 RID: 8630
	[global::System.NonSerialized]
	public global::ArmorDataBlock torsoArmor;

	// Token: 0x040021B7 RID: 8631
	[global::System.NonSerialized]
	public global::ArmorDataBlock headArmor;

	// Token: 0x040021B8 RID: 8632
	public global::UnityEngine.MeshFilter footMeshFilter;

	// Token: 0x040021B9 RID: 8633
	public global::UnityEngine.MeshFilter legMeshFilter;

	// Token: 0x040021BA RID: 8634
	public global::UnityEngine.MeshFilter torsoMeshFilter;

	// Token: 0x040021BB RID: 8635
	public global::UnityEngine.MeshFilter headMeshFilter;

	// Token: 0x040021BC RID: 8636
	public global::Ragdoll ragdollPrefab;

	// Token: 0x040021BD RID: 8637
	[global::System.NonSerialized]
	private int timeStamp;

	// Token: 0x040021BE RID: 8638
	[global::System.NonSerialized]
	private bool bufferedArmor;

	// Token: 0x040021BF RID: 8639
	[global::System.NonSerialized]
	private bool hasCreator;

	// Token: 0x040021C0 RID: 8640
	[global::System.NonSerialized]
	private global::TakeDamage takeDamage;

	// Token: 0x040021C1 RID: 8641
	[global::System.NonSerialized]
	private global::NGCView ngcView;

	// Token: 0x02000798 RID: 1944
	private class KillQuery
	{
		// Token: 0x060040B5 RID: 16565 RVA: 0x000E7E10 File Offset: 0x000E6010
		public KillQuery(ulong UserID, string DropPrefabName, ulong AttackerUserID)
		{
			this.UserID = UserID;
			this.DropPrefabName = DropPrefabName;
			this.AttackerUserID = AttackerUserID;
		}

		// Token: 0x060040B6 RID: 16566 RVA: 0x000E7E30 File Offset: 0x000E6030
		public bool Commit()
		{
			if (!this.Committed)
			{
				this.Committed = true;
				if (global::sleepers.loglevel > 2)
				{
					global::UnityEngine.Debug.Log("sleeper-kq: sending query for user id " + this.UserID);
				}
				global::System.GC.ReRegisterForFinalize(this);
				if (global::sleepers.loglevel > 2)
				{
					global::UnityEngine.Debug.Log("sleeper-kq: sending.." + this.UserID);
				}
				global::RustProto.Avatar avatar = global::NetUser.LoadAvatar(this.UserID);
				this.OnSuccess(ref avatar);
				return true;
			}
			return false;
		}

		// Token: 0x060040B7 RID: 16567 RVA: 0x000E7EB8 File Offset: 0x000E60B8
		private void DropInventoryFromAvatar(ref global::RustProto.Avatar avatar)
		{
			int inventoryCount;
			int wearableCount;
			int beltCount;
			int num;
			if (avatar.HasPos && avatar.HasAng && (num = (inventoryCount = avatar.InventoryCount) + (wearableCount = avatar.WearableCount) + (beltCount = avatar.BeltCount)) > 0)
			{
				if (global::sleepers.loglevel > 2)
				{
					global::UnityEngine.Debug.Log("sleeper-kq: determining placement of lootsack" + this.UserID);
				}
				global::RustProto.Vector pos = avatar.Pos;
				global::RustProto.Quaternion ang = avatar.Ang;
				global::UnityEngine.Vector3 transformOrigin;
				transformOrigin..ctor(pos.X, pos.Y, pos.Z);
				global::UnityEngine.Quaternion ang2;
				ang2..ctor(ang.X, ang.Y, ang.Z, ang.W);
				global::UnityEngine.Vector3 position;
				global::UnityEngine.Vector3 y;
				global::TransformHelpers.GetGroundInfoNoTransform(transformOrigin, out position, out y);
				global::UnityEngine.Quaternion groundInfoRotation = global::TransformHelpers.GetGroundInfoRotation(ang2, y);
				if (global::sleepers.loglevel > 2)
				{
					global::UnityEngine.Debug.Log("sleeper-kq: instantiating lootsack" + this.UserID);
				}
				global::UnityEngine.GameObject gameObject = global::NetCull.InstantiateStatic(this.DropPrefabName, position, groundInfoRotation);
				if (gameObject)
				{
					global::Inventory component = gameObject.GetComponent<global::Inventory>();
					if (!component)
					{
						if (global::sleepers.loglevel > 0)
						{
							global::UnityEngine.Debug.LogError(string.Format("The prefab \"{0}\" has no inventory.", this.DropPrefabName), gameObject);
						}
					}
					else
					{
						if (global::sleepers.loglevel > 2)
						{
							global::UnityEngine.Debug.Log(string.Concat(new object[]
							{
								"sleeper-kq: sizing lootsack to ",
								num,
								" user ",
								this.UserID
							}));
						}
						int num2;
						if (!component.TryToInitializeSize(num))
						{
							num2 = component.slotCount;
						}
						else
						{
							num2 = num;
						}
						int num3 = 0;
						if (global::sleepers.loglevel > 2)
						{
							global::UnityEngine.Debug.Log(string.Concat(new object[]
							{
								"sleeper-kq: wearables: ",
								wearableCount,
								" user ",
								this.UserID
							}));
						}
						int num4 = 0;
						while (num3 < num2 && wearableCount-- > 0)
						{
							global::RustProto.Item item = avatar.GetWearable(num4++);
							if (!object.ReferenceEquals(component.LoadItemIntoVacantSlot(ref item), null))
							{
								num3++;
							}
						}
						if (global::sleepers.loglevel > 2)
						{
							global::UnityEngine.Debug.Log(string.Concat(new object[]
							{
								"sleeper-kq: belt: ",
								beltCount,
								" user ",
								this.UserID
							}));
						}
						num4 = 0;
						while (num3 < num2 && beltCount-- > 0)
						{
							global::RustProto.Item item = avatar.GetBelt(num4++);
							if (!object.ReferenceEquals(component.LoadItemIntoVacantSlot(ref item), null))
							{
								num3++;
							}
						}
						if (global::sleepers.loglevel > 2)
						{
							global::UnityEngine.Debug.Log(string.Concat(new object[]
							{
								"sleeper-kq: inv: ",
								inventoryCount,
								" user ",
								this.UserID
							}));
						}
						num4 = 0;
						while (num3 < num2 && inventoryCount-- > 0)
						{
							global::RustProto.Item item = avatar.GetInventory(num4++);
							if (!object.ReferenceEquals(component.LoadItemIntoVacantSlot(ref item), null))
							{
								num3++;
							}
						}
						if (global::sleepers.loglevel > 2)
						{
							global::UnityEngine.Debug.Log("sleeper-kq: done populating inventory" + this.UserID);
						}
					}
				}
			}
			else if (global::sleepers.loglevel > 2)
			{
				global::UnityEngine.Debug.Log("sleeper-kq: there were no items on avatar for user " + this.UserID);
			}
		}

		// Token: 0x060040B8 RID: 16568 RVA: 0x000E8258 File Offset: 0x000E6458
		private void ModifyAvatar(ref global::RustProto.Avatar avatar)
		{
			if (global::sleepers.loglevel > 2)
			{
				global::UnityEngine.Debug.Log("sleeper-kq: modifying avatar " + this.UserID);
			}
			using (global::RustProto.Helpers.Recycler<global::RustProto.Avatar, global::RustProto.Avatar.Builder> recycler = global::RustProto.Avatar.Recycler())
			{
				global::RustProto.Avatar.Builder builder = recycler.OpenBuilder();
				global::AvatarSaveRestore.CopyPersistantMessages(ref builder, ref avatar);
				builder.AwayEvent = global::AvatarSaveRestore.MakeAwayEvent(global::RustProto.AwayEvent.Types.AwayEventType.DIED, this.AttackerUserID);
				avatar = builder.Build();
			}
			if (global::sleepers.loglevel > 2)
			{
				global::UnityEngine.Debug.Log("sleeper-kq: modified avatar " + this.UserID);
			}
		}

		// Token: 0x060040B9 RID: 16569 RVA: 0x000E830C File Offset: 0x000E650C
		private void Execute(ref global::RustProto.Avatar avatar)
		{
			try
			{
				this.DropInventoryFromAvatar(ref avatar);
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex);
			}
			try
			{
				this.ModifyAvatar(ref avatar);
			}
			catch (global::System.Exception ex2)
			{
				global::UnityEngine.Debug.LogException(ex2);
			}
			try
			{
				if (global::sleepers.loglevel > 2)
				{
					global::UnityEngine.Debug.Log("sleeper-kq: NetUser.SaveAvatar " + this.UserID);
				}
				global::NetUser.SaveAvatar(this.UserID, ref avatar);
				if (global::sleepers.loglevel > 2)
				{
					global::UnityEngine.Debug.Log("sleeper-kq: saved " + this.UserID);
				}
			}
			catch (global::System.Exception ex3)
			{
				global::UnityEngine.Debug.LogException(ex3);
			}
		}

		// Token: 0x060040BA RID: 16570 RVA: 0x000E83FC File Offset: 0x000E65FC
		private void OnSuccess(ref global::RustProto.Avatar avatar)
		{
			try
			{
				if (global::sleepers.loglevel > 2)
				{
					global::UnityEngine.Debug.Log("sleeper-kq: executing " + this.UserID);
				}
				this.Execute(ref avatar);
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex);
				global::UnityEngine.Debug.LogWarning(string.Format("Above exception was in a KillQuery for UserID:{0}", this.UserID));
			}
		}

		// Token: 0x040021C2 RID: 8642
		public readonly ulong UserID;

		// Token: 0x040021C3 RID: 8643
		public readonly string DropPrefabName;

		// Token: 0x040021C4 RID: 8644
		public readonly ulong AttackerUserID;

		// Token: 0x040021C5 RID: 8645
		private bool Committed;

		// Token: 0x040021C6 RID: 8646
		private bool GotResponse;

		// Token: 0x040021C7 RID: 8647
		private bool WasRespondedTo;
	}

	// Token: 0x02000799 RID: 1945
	private static class Registry
	{
		// Token: 0x060040BB RID: 16571 RVA: 0x000E847C File Offset: 0x000E667C
		// Note: this type is marked as 'beforefieldinit'.
		static Registry()
		{
		}

		// Token: 0x060040BC RID: 16572 RVA: 0x000E8488 File Offset: 0x000E6688
		public static bool Find(ulong UserID, out global::SleepingAvatar sleepingAvatar)
		{
			if (!global::SleepingAvatar.Registry.all.TryGetValue(UserID, out sleepingAvatar))
			{
				return false;
			}
			if (!sleepingAvatar)
			{
				global::SleepingAvatar.Registry.all.Remove(UserID);
				global::UnityEngine.Debug.LogWarning("Something is wrong here.");
				return false;
			}
			return true;
		}

		// Token: 0x060040BD RID: 16573 RVA: 0x000E84D0 File Offset: 0x000E66D0
		public static bool Register(global::SleepingAvatar avatar)
		{
			global::SleepingAvatar sleepingAvatar;
			if (global::SleepingAvatar.Registry.all.TryGetValue(avatar.creatorID, out sleepingAvatar))
			{
				if (sleepingAvatar == avatar)
				{
					return false;
				}
				sleepingAvatar.registered = false;
			}
			global::SleepingAvatar.Registry.all[avatar.creatorID] = avatar;
			avatar.registered = true;
			return true;
		}

		// Token: 0x060040BE RID: 16574 RVA: 0x000E8524 File Offset: 0x000E6724
		public static bool UnRegister(global::SleepingAvatar avatar)
		{
			if (avatar)
			{
				if (avatar.registered)
				{
					global::SleepingAvatar sleepingAvatar;
					if (global::SleepingAvatar.Registry.all.TryGetValue(avatar.creatorID, out sleepingAvatar) && sleepingAvatar == avatar)
					{
						global::SleepingAvatar.Registry.all.Remove(avatar.creatorID);
					}
					avatar.registered = false;
					return true;
				}
			}
			else if (!object.ReferenceEquals(avatar, null))
			{
				global::UnityEngine.Debug.LogWarning("Got missing avatar in UnRegister, running scan to find invalid entries..", avatar);
				global::SleepingAvatar.Registry.CleanUpPossibleMissingPairs();
			}
			return false;
		}

		// Token: 0x060040BF RID: 16575 RVA: 0x000E85A8 File Offset: 0x000E67A8
		public static int CleanUpPossibleMissingPairs()
		{
			int num = 0;
			global::System.Collections.Generic.List<ulong> list = null;
			foreach (global::System.Collections.Generic.KeyValuePair<ulong, global::SleepingAvatar> keyValuePair in global::SleepingAvatar.Registry.all)
			{
				global::System.Collections.Generic.KeyValuePair<ulong, global::SleepingAvatar> keyValuePair3;
				global::System.Collections.Generic.KeyValuePair<ulong, global::SleepingAvatar> keyValuePair2 = keyValuePair3 = keyValuePair;
				if (!keyValuePair3.Value)
				{
					(list = new global::System.Collections.Generic.List<ulong>(1)).Add(keyValuePair2.Key);
					global::System.Collections.Generic.Dictionary<ulong, global::SleepingAvatar>.Enumerator enumerator;
					while (enumerator.MoveNext())
					{
						global::System.Collections.Generic.KeyValuePair<ulong, global::SleepingAvatar> keyValuePair4 = enumerator.Current;
						global::System.Collections.Generic.KeyValuePair<ulong, global::SleepingAvatar> keyValuePair5;
						keyValuePair2 = (keyValuePair5 = keyValuePair4);
						if (!keyValuePair5.Value)
						{
							list.Add(keyValuePair2.Key);
						}
					}
					num = list.Count;
				}
			}
			if (num > 0)
			{
				foreach (ulong key in list)
				{
					global::SleepingAvatar.Registry.all.Remove(key);
				}
			}
			return num;
		}

		// Token: 0x060040C0 RID: 16576 RVA: 0x000E86D4 File Offset: 0x000E68D4
		public static void Clear(bool andKill)
		{
			global::System.Collections.Generic.List<global::SleepingAvatar> list = new global::System.Collections.Generic.List<global::SleepingAvatar>(global::SleepingAvatar.Registry.all.Values);
			foreach (global::SleepingAvatar sleepingAvatar in list)
			{
				if (sleepingAvatar)
				{
					if (andKill)
					{
						global::DamageEvent damageEvent;
						global::TakeDamage.Kill(sleepingAvatar, sleepingAvatar, out damageEvent, null);
						if (!sleepingAvatar)
						{
							continue;
						}
					}
					global::NetCull.Destroy(sleepingAvatar.gameObject);
				}
			}
		}

		// Token: 0x040021C8 RID: 8648
		private static readonly global::System.Collections.Generic.Dictionary<ulong, global::SleepingAvatar> all = new global::System.Collections.Generic.Dictionary<ulong, global::SleepingAvatar>();
	}

	// Token: 0x0200079A RID: 1946
	public struct TransientData
	{
		// Token: 0x060040C1 RID: 16577 RVA: 0x000E8778 File Offset: 0x000E6978
		private TransientData(global::System.TimeSpan slumberTime, global::RustProto.Vitals vitals)
		{
			this.slumberTime = slumberTime;
			this.vitals = vitals;
			this.hasVitals = true;
			this.exists = true;
		}

		// Token: 0x060040C2 RID: 16578 RVA: 0x000E8798 File Offset: 0x000E6998
		private TransientData(global::System.TimeSpan slumberTime)
		{
			this.slumberTime = slumberTime;
			this.vitals = null;
			this.hasVitals = false;
			this.exists = true;
		}

		// Token: 0x060040C3 RID: 16579 RVA: 0x000E87B8 File Offset: 0x000E69B8
		private void Merge(global::RustProto.Avatar.Builder avatar, bool mergeVitals)
		{
			if (mergeVitals)
			{
				using (global::RustProto.Helpers.Recycler<global::RustProto.Vitals, global::RustProto.Vitals.Builder> recycler = global::RustProto.Vitals.Recycler())
				{
					global::RustProto.Vitals.Builder builder = recycler.OpenBuilder(avatar.Vitals);
					avatar.SetVitals(builder);
				}
			}
		}

		// Token: 0x060040C4 RID: 16580 RVA: 0x000E8814 File Offset: 0x000E6A14
		public void AdjustIncomingAvatar(ref global::RustProto.Avatar avatar)
		{
			if (this.vitals == null)
			{
				return;
			}
			if (!avatar.HasVitals)
			{
				return;
			}
			global::RustProto.Vitals vitals = avatar.Vitals;
			using (global::RustProto.Helpers.Recycler<global::RustProto.Avatar, global::RustProto.Avatar.Builder> recycler = global::RustProto.Avatar.Recycler())
			{
				global::RustProto.Avatar.Builder builder = recycler.OpenBuilder(avatar);
				this.Merge(builder, true);
				avatar = builder.Build();
			}
		}

		// Token: 0x060040C5 RID: 16581 RVA: 0x000E8890 File Offset: 0x000E6A90
		internal static global::SleepingAvatar.TransientData Collect(global::SleepingAvatar sleepingAvatar)
		{
			if (!sleepingAvatar)
			{
				return default(global::SleepingAvatar.TransientData);
			}
			global::System.TimeSpan timeSpan = global::POSIX.Time.ElapsedSince(sleepingAvatar.timeStamp);
			global::RustProto.Vitals vitals = null;
			if (sleepingAvatar.takeDamage)
			{
				using (global::RustProto.Helpers.Recycler<global::RustProto.Vitals, global::RustProto.Vitals.Builder> recycler = global::RustProto.Vitals.Recycler())
				{
					global::RustProto.Vitals.Builder builder = recycler.OpenBuilder();
					sleepingAvatar.takeDamage.SaveVitals(ref builder);
					if (builder.IsInitialized)
					{
						return new global::SleepingAvatar.TransientData(timeSpan, builder.Build());
					}
					global::UnityEngine.Debug.LogError("!builder.IsInitialized");
				}
			}
			return new global::SleepingAvatar.TransientData(timeSpan, vitals);
		}

		// Token: 0x040021C9 RID: 8649
		public readonly global::System.TimeSpan slumberTime;

		// Token: 0x040021CA RID: 8650
		public readonly global::RustProto.Vitals vitals;

		// Token: 0x040021CB RID: 8651
		public readonly bool exists;

		// Token: 0x040021CC RID: 8652
		public readonly bool hasVitals;
	}
}
