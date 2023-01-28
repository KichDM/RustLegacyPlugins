using System;
using POSIX;
using RustProto;
using RustProto.Helpers;
using UnityEngine;

// Token: 0x020000AB RID: 171
public class AvatarSaveRestore : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600034C RID: 844 RVA: 0x0000FD8C File Offset: 0x0000DF8C
	public AvatarSaveRestore()
	{
	}

	// Token: 0x0600034D RID: 845 RVA: 0x0000FD94 File Offset: 0x0000DF94
	public void ClearAvatar()
	{
		global::Character character;
		if (!global::IDBase.GetMain<global::Character>(base.gameObject, ref character))
		{
			global::UnityEngine.Debug.LogWarning("Couldn't clear Avatar - no Character component!");
			return;
		}
		using (global::RustProto.Helpers.Recycler<global::RustProto.Avatar, global::RustProto.Avatar.Builder> recycler = global::RustProto.Avatar.Recycler())
		{
			global::RustProto.Avatar.Builder builder = recycler.OpenBuilder();
			character.GetLocal<global::PlayerInventory>().SaveToAvatar(ref builder);
			character.netUser.SaveAvatar(builder.Build());
		}
		this._loaded_once = true;
		global::AvatarSaveProc.UnManage(this);
	}

	// Token: 0x0600034E RID: 846 RVA: 0x0000FE24 File Offset: 0x0000E024
	public static global::RustProto.AwayEvent MakeAwayEvent(global::RustProto.AwayEvent.Types.AwayEventType awayEvent)
	{
		return global::AvatarSaveRestore.MakeAwayEvent(awayEvent, 0UL);
	}

	// Token: 0x0600034F RID: 847 RVA: 0x0000FE30 File Offset: 0x0000E030
	public static global::RustProto.AwayEvent MakeAwayEvent(global::RustProto.AwayEvent.Types.AwayEventType awayEvent, ulong instigatorUserID)
	{
		global::RustProto.AwayEvent result;
		using (global::RustProto.Helpers.Recycler<global::RustProto.AwayEvent, global::RustProto.AwayEvent.Builder> recycler = global::RustProto.AwayEvent.Recycler())
		{
			global::RustProto.AwayEvent.Builder builder = recycler.OpenBuilder();
			builder.Type = awayEvent;
			builder.Timestamp = global::POSIX.Time.NowStamp;
			if (instigatorUserID != 0UL)
			{
				builder.Instigator = instigatorUserID;
			}
			result = builder.Build();
		}
		return result;
	}

	// Token: 0x06000350 RID: 848 RVA: 0x0000FEA4 File Offset: 0x0000E0A4
	public static global::RustProto.AwayEvent MakeAwayEvent(global::RustProto.AwayEvent.Types.AwayEventType awayEvent, global::NetUser instigatingUser)
	{
		if (object.ReferenceEquals(instigatingUser, null))
		{
			return global::AvatarSaveRestore.MakeAwayEvent(awayEvent);
		}
		return global::AvatarSaveRestore.MakeAwayEvent(awayEvent, instigatingUser.user.Userid);
	}

	// Token: 0x06000351 RID: 849 RVA: 0x0000FED8 File Offset: 0x0000E0D8
	public void SetAwayEvent(global::RustProto.AwayEvent.Types.AwayEventType awayEvent, ulong instigatorUserID)
	{
		this.awayEvent = global::AvatarSaveRestore.MakeAwayEvent(awayEvent, instigatorUserID);
	}

	// Token: 0x06000352 RID: 850 RVA: 0x0000FEE8 File Offset: 0x0000E0E8
	public void SetAwayEvent(global::RustProto.AwayEvent.Types.AwayEventType awayEvent)
	{
		this.awayEvent = global::AvatarSaveRestore.MakeAwayEvent(awayEvent, 0UL);
	}

	// Token: 0x06000353 RID: 851 RVA: 0x0000FEF8 File Offset: 0x0000E0F8
	public void SetAwayEvent(global::RustProto.AwayEvent.Types.AwayEventType awayEvent, global::NetUser instigator)
	{
		this.awayEvent = global::AvatarSaveRestore.MakeAwayEvent(awayEvent, instigator);
	}

	// Token: 0x06000354 RID: 852 RVA: 0x0000FF08 File Offset: 0x0000E108
	public void ClearAwayEvent()
	{
		this.awayEvent = null;
	}

	// Token: 0x17000079 RID: 121
	// (get) Token: 0x06000355 RID: 853 RVA: 0x0000FF14 File Offset: 0x0000E114
	public bool HasAwayEvent
	{
		get
		{
			return this.awayEvent != null;
		}
	}

	// Token: 0x06000356 RID: 854 RVA: 0x0000FF24 File Offset: 0x0000E124
	public void SaveAvatar()
	{
		global::Character character;
		if (!global::IDBase.GetMain<global::Character>(base.gameObject, ref character))
		{
			global::UnityEngine.Debug.LogWarning("Couldn't save Avatar - no Character component!");
			return;
		}
		using (global::RustProto.Helpers.Recycler<global::RustProto.Avatar, global::RustProto.Avatar.Builder> recycler = global::RustProto.Avatar.Recycler())
		{
			global::RustProto.Avatar.Builder builder = recycler.OpenBuilder();
			global::Character character2 = character.masterCharacter;
			if (!character2)
			{
				character2 = character;
			}
			builder.SetPos(character2.origin);
			builder.SetAng(character2.rotation);
			using (global::RustProto.Helpers.Recycler<global::RustProto.Vitals, global::RustProto.Vitals.Builder> recycler2 = global::RustProto.Vitals.Recycler())
			{
				global::RustProto.Vitals.Builder vitals = recycler2.OpenBuilder();
				character.GetLocal<global::Metabolism>().SaveVitals(ref vitals);
				character.takeDamage.SaveVitals(ref vitals);
				builder.SetVitals(vitals);
			}
			character.GetLocal<global::PlayerInventory>().SaveToAvatar(ref builder);
			if (this.HasAwayEvent)
			{
				builder.SetAwayEvent(this.awayEvent);
				this.ClearAwayEvent();
			}
			character.netUser.SaveAvatar(builder.Build());
		}
		global::AvatarSaveProc.MoveBack(this);
	}

	// Token: 0x06000357 RID: 855 RVA: 0x00010064 File Offset: 0x0000E264
	public void LoadAvatar()
	{
		if (!this._loaded_once)
		{
			this._loaded_once = true;
			global::AvatarSaveProc.Manage(this);
		}
		global::Character character;
		if (!global::IDBase.GetMain<global::Character>(base.gameObject, ref character))
		{
			global::UnityEngine.Debug.LogWarning("Couldn't load Avatar - no Character component!");
			return;
		}
		global::NetUser netUser = character.netUser;
		if (netUser == null)
		{
			global::UnityEngine.Debug.LogWarning("Couldn't load Avatar - no character.netUser!");
			return;
		}
		global::RustProto.Avatar avatar = netUser.LoadAvatar();
		if (avatar.HasVitals)
		{
			character.GetLocal<global::Metabolism>().LoadVitals(avatar.Vitals);
			character.takeDamage.LoadVitals(avatar.Vitals);
		}
		character.GetLocal<global::PlayerInventory>().LoadToAvatar(ref avatar);
		character.GetLocal<global::InventoryHolder>().TryGiveDefaultItems();
	}

	// Token: 0x06000358 RID: 856 RVA: 0x0001010C File Offset: 0x0000E30C
	public void ShutdownAvatar(bool save)
	{
		if (!this._has_shutdown)
		{
			this._has_shutdown = true;
			if (save)
			{
				this.SaveAvatar();
			}
			if (this._loaded_once)
			{
				global::AvatarSaveProc.UnManage(this);
			}
		}
	}

	// Token: 0x06000359 RID: 857 RVA: 0x00010140 File Offset: 0x0000E340
	private void OnDestroy()
	{
		if (this._loaded_once && !this._has_shutdown)
		{
			this._has_shutdown = true;
			this._loaded_once = false;
			global::AvatarSaveProc.UnManage(this);
		}
	}

	// Token: 0x0600035A RID: 858 RVA: 0x00010178 File Offset: 0x0000E378
	public static void CopyPersistantMessages(ref global::RustProto.Avatar.Builder builder, ref global::RustProto.Avatar avatar)
	{
		builder.ClearBlueprints();
		for (int i = 0; i < avatar.BlueprintsCount; i++)
		{
			builder.AddBlueprints(avatar.GetBlueprints(i));
		}
	}

	// Token: 0x04000301 RID: 769
	[global::System.NonSerialized]
	internal bool __managed_by_save_proc;

	// Token: 0x04000302 RID: 770
	[global::System.NonSerialized]
	private bool _loaded_once;

	// Token: 0x04000303 RID: 771
	[global::System.NonSerialized]
	private bool _has_shutdown;

	// Token: 0x04000304 RID: 772
	[global::System.NonSerialized]
	private global::RustProto.AwayEvent awayEvent;
}
