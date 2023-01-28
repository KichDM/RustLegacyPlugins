using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200076C RID: 1900
public class TransCarrier : global::IDLocal, global::ICarriableTrans
{
	// Token: 0x06003F26 RID: 16166 RVA: 0x000E1244 File Offset: 0x000DF444
	public TransCarrier()
	{
	}

	// Token: 0x06003F27 RID: 16167 RVA: 0x000E124C File Offset: 0x000DF44C
	public void TryInit()
	{
		if (this._objs == null)
		{
			this._objs = new global::System.Collections.Generic.HashSet<global::ICarriableTrans>();
		}
	}

	// Token: 0x06003F28 RID: 16168 RVA: 0x000E1264 File Offset: 0x000DF464
	public virtual void AddObject(global::ICarriableTrans obj)
	{
		if (object.ReferenceEquals(obj, this))
		{
			return;
		}
		if (this.destroying)
		{
			global::UnityEngine.Debug.LogWarning("Did not add object because the this carrier is destroying", this);
		}
		else
		{
			this.TryInit();
			this._objs.Add(obj);
			obj.OnAddedToCarrier(this);
		}
	}

	// Token: 0x06003F29 RID: 16169 RVA: 0x000E12B4 File Offset: 0x000DF4B4
	public virtual void RemoveObject(global::ICarriableTrans obj)
	{
		if (this._objs != null)
		{
			this._objs.Remove(obj);
		}
	}

	// Token: 0x06003F2A RID: 16170 RVA: 0x000E12D0 File Offset: 0x000DF4D0
	public virtual void DropObjects()
	{
		if (this._objs == null)
		{
			return;
		}
		global::System.Collections.Generic.HashSet<global::ICarriableTrans> objs = this._objs;
		this._objs = null;
		foreach (global::ICarriableTrans carriableTrans in objs)
		{
			if (!(carriableTrans is global::UnityEngine.Object) || (global::UnityEngine.Object)carriableTrans)
			{
				carriableTrans.OnDroppedFromCarrier(this);
			}
		}
	}

	// Token: 0x06003F2B RID: 16171 RVA: 0x000E1368 File Offset: 0x000DF568
	public void DropObjects(bool andDisableAddingAfter)
	{
		try
		{
			this.DropObjects();
		}
		finally
		{
			if (andDisableAddingAfter)
			{
				this.destroying = true;
			}
		}
	}

	// Token: 0x06003F2C RID: 16172 RVA: 0x000E13AC File Offset: 0x000DF5AC
	public virtual void OnAddedToCarrier(global::TransCarrier carrier)
	{
	}

	// Token: 0x06003F2D RID: 16173 RVA: 0x000E13B0 File Offset: 0x000DF5B0
	public virtual void OnDroppedFromCarrier(global::TransCarrier carrier)
	{
		this.DropObjects();
	}

	// Token: 0x06003F2E RID: 16174 RVA: 0x000E13B8 File Offset: 0x000DF5B8
	public static void AddToTransCarrierPostLoad(global::ICarriableTrans carriable, int savedNetEntityID)
	{
		global::ServerSaveManager.LoadBinding.RegisterCallbackOnLoaded(savedNetEntityID, global::TransCarrier.Callbacks.addObjectCallback, carriable);
	}

	// Token: 0x04002082 RID: 8322
	public global::System.Collections.Generic.HashSet<global::ICarriableTrans> _objs;

	// Token: 0x04002083 RID: 8323
	private bool destroying;

	// Token: 0x0200076D RID: 1901
	private static class Callbacks
	{
		// Token: 0x06003F2F RID: 16175 RVA: 0x000E13CC File Offset: 0x000DF5CC
		// Note: this type is marked as 'beforefieldinit'.
		static Callbacks()
		{
		}

		// Token: 0x06003F30 RID: 16176 RVA: 0x000E13E0 File Offset: 0x000DF5E0
		private static void AddObjectCallback(int oldID, global::NetEntityID newID, object userData)
		{
			global::TransCarrier component = newID.GetComponent<global::TransCarrier>();
			if (component)
			{
				component.AddObject(userData as global::ICarriableTrans);
			}
		}

		// Token: 0x04002084 RID: 8324
		public static readonly global::SaveLoadBindingCallback addObjectCallback = new global::SaveLoadBindingCallback(global::TransCarrier.Callbacks.AddObjectCallback);
	}
}
