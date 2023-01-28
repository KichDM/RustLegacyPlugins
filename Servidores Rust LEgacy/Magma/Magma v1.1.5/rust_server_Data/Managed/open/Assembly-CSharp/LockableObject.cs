using System;
using Facepunch;
using RustProto;
using RustProto.Helpers;

// Token: 0x0200078F RID: 1935
public class LockableObject : global::Facepunch.NetBehaviour, global::IServerSaveable
{
	// Token: 0x0600404C RID: 16460 RVA: 0x000E604C File Offset: 0x000E424C
	public LockableObject()
	{
	}

	// Token: 0x0600404D RID: 16461 RVA: 0x000E605C File Offset: 0x000E425C
	public virtual bool IsPickable()
	{
		return false;
	}

	// Token: 0x0600404E RID: 16462 RVA: 0x000E6060 File Offset: 0x000E4260
	public virtual bool PickAttempt(float skill)
	{
		return false;
	}

	// Token: 0x0600404F RID: 16463 RVA: 0x000E6064 File Offset: 0x000E4264
	public bool IsLockActive()
	{
		return this.lockActive;
	}

	// Token: 0x06004050 RID: 16464 RVA: 0x000E606C File Offset: 0x000E426C
	public void SetLockActive(bool on)
	{
		this.lockActive = on;
	}

	// Token: 0x06004051 RID: 16465 RVA: 0x000E6078 File Offset: 0x000E4278
	public virtual bool HasAccess(global::Controllable controllable)
	{
		global::NetUser netUser = global::NetUser.Find(controllable.networkView.owner);
		return netUser != null && this.HasAccess(netUser.userID);
	}

	// Token: 0x06004052 RID: 16466 RVA: 0x000E60AC File Offset: 0x000E42AC
	public virtual string GetLockedStringForPopup(global::Controllable controllable)
	{
		return "Locked...";
	}

	// Token: 0x06004053 RID: 16467 RVA: 0x000E60B4 File Offset: 0x000E42B4
	public virtual bool HasAccess(ulong userid)
	{
		return false;
	}

	// Token: 0x06004054 RID: 16468 RVA: 0x000E60B8 File Offset: 0x000E42B8
	public void WriteObjectSave(ref global::RustProto.SavedObject.Builder saveobj)
	{
		using (global::RustProto.Helpers.Recycler<global::RustProto.objectLockable, global::RustProto.objectLockable.Builder> recycler = global::RustProto.objectLockable.Recycler())
		{
			global::RustProto.objectLockable.Builder builder = recycler.OpenBuilder();
			this.WriteLockable(builder);
			saveobj.SetLockable(builder);
		}
	}

	// Token: 0x06004055 RID: 16469 RVA: 0x000E6110 File Offset: 0x000E4310
	public void ReadObjectSave(ref global::RustProto.SavedObject saveobj)
	{
		if (saveobj.HasLockable)
		{
			this.ReadLockable(saveobj.Lockable);
		}
	}

	// Token: 0x06004056 RID: 16470 RVA: 0x000E612C File Offset: 0x000E432C
	public virtual void ReadLockable(global::RustProto.objectLockable lockable)
	{
		this.SetLockActive(lockable.Locked);
	}

	// Token: 0x06004057 RID: 16471 RVA: 0x000E613C File Offset: 0x000E433C
	public virtual void WriteLockable(global::RustProto.objectLockable.Builder builder)
	{
		builder.SetLocked(this.lockActive);
	}

	// Token: 0x04002183 RID: 8579
	[global::System.NonSerialized]
	protected bool lockActive = true;
}
