using System;
using UnityEngine;

// Token: 0x02000319 RID: 793
public abstract class CCTotem<TTotemObject, CCTotemScript> : global::CCTotem<TTotemObject> where TTotemObject : global::CCTotem.TotemicObject<CCTotemScript, TTotemObject>, new() where CCTotemScript : global::CCTotem<TTotemObject, CCTotemScript>, new()
{
	// Token: 0x06001ABD RID: 6845 RVA: 0x000695FC File Offset: 0x000677FC
	internal CCTotem()
	{
	}

	// Token: 0x06001ABE RID: 6846 RVA: 0x00069604 File Offset: 0x00067804
	internal void AssignTotemicObject(TTotemObject totemObject)
	{
		if (!object.ReferenceEquals(this.totemicObject, null))
		{
			if (object.ReferenceEquals(this.totemicObject, totemObject))
			{
				return;
			}
			this.ClearTotemicObject();
		}
		this.totemicObject = totemObject;
		if (!object.ReferenceEquals(this.totemicObject, null))
		{
			if (this.destroyed)
			{
				this.totemicObject = (TTotemObject)((object)null);
				throw new global::System.InvalidOperationException("Cannot assign non-null script during destruction");
			}
			this.totemicObject.AssignedToScript((CCTotemScript)((object)this));
		}
	}

	// Token: 0x06001ABF RID: 6847 RVA: 0x000696A0 File Offset: 0x000678A0
	protected void ClearTotemicObject()
	{
		TTotemObject totemicObject = this.totemicObject;
		try
		{
			this.totemicObject.OnScriptDestroy((CCTotemScript)((object)this));
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogException(ex, this);
		}
		finally
		{
			if (object.ReferenceEquals(totemicObject, this.totemicObject))
			{
				this.totemicObject = (TTotemObject)((object)null);
			}
		}
	}

	// Token: 0x06001AC0 RID: 6848 RVA: 0x0006973C File Offset: 0x0006793C
	protected void OnDestroy()
	{
		if (!this.destroyed)
		{
			this.destroyed = true;
			if (!object.ReferenceEquals(this.totemicObject, null))
			{
				this.ClearTotemicObject();
			}
		}
	}

	// Token: 0x04000F96 RID: 3990
	[global::System.NonSerialized]
	private bool destroyed;
}
