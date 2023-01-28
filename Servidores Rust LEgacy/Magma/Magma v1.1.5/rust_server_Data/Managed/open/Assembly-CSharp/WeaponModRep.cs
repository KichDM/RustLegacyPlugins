using System;
using UnityEngine;

// Token: 0x02000724 RID: 1828
public abstract class WeaponModRep : global::ItemModRepresentation
{
	// Token: 0x06003DF3 RID: 15859 RVA: 0x000D91A0 File Offset: 0x000D73A0
	protected WeaponModRep(global::ItemModRepresentation.Caps caps, bool defaultsOn) : base(caps)
	{
		this.defaultsOn = defaultsOn;
		this._on = defaultsOn;
	}

	// Token: 0x06003DF4 RID: 15860 RVA: 0x000D91B8 File Offset: 0x000D73B8
	protected WeaponModRep(global::ItemModRepresentation.Caps caps) : this(caps, false)
	{
	}

	// Token: 0x17000BC7 RID: 3015
	// (get) Token: 0x06003DF5 RID: 15861 RVA: 0x000D91C4 File Offset: 0x000D73C4
	// (set) Token: 0x06003DF6 RID: 15862 RVA: 0x000D91CC File Offset: 0x000D73CC
	public global::UnityEngine.GameObject attached
	{
		get
		{
			return this._attached;
		}
		protected set
		{
			if (value != this._attached)
			{
				if (value)
				{
					if (!this.VerifyCompatible(value))
					{
						throw new global::System.ArgumentOutOfRangeException("value", "incompatible");
					}
					if (this._attached)
					{
						this.OnRemoveAttached();
					}
					this._attached = value;
					this.OnAddAttached();
					if (this._on)
					{
						this.EnableMod(global::ItemModRepresentation.Reason.Implicit);
					}
					else
					{
						this.DisableMod(global::ItemModRepresentation.Reason.Implicit);
					}
				}
				else
				{
					if (this._attached)
					{
						this.OnRemoveAttached();
					}
					this._attached = null;
				}
			}
			this._attached = value;
		}
	}

	// Token: 0x06003DF7 RID: 15863 RVA: 0x000D927C File Offset: 0x000D747C
	public virtual void SetAttached(global::UnityEngine.GameObject attached, bool vm)
	{
		this.attached = attached;
	}

	// Token: 0x17000BC8 RID: 3016
	// (get) Token: 0x06003DF8 RID: 15864 RVA: 0x000D9288 File Offset: 0x000D7488
	// (set) Token: 0x06003DF9 RID: 15865 RVA: 0x000D9290 File Offset: 0x000D7490
	public bool on
	{
		get
		{
			return this._on;
		}
		protected set
		{
			this.SetOn(value, global::ItemModRepresentation.Reason.Explicit);
		}
	}

	// Token: 0x06003DFA RID: 15866 RVA: 0x000D929C File Offset: 0x000D749C
	protected void SetOn(bool on, global::ItemModRepresentation.Reason reason)
	{
		if (this._on != on)
		{
			this._on = on;
			if (this._attached)
			{
				if (on)
				{
					this.EnableMod(reason);
				}
				else
				{
					this.DisableMod(reason);
				}
			}
		}
	}

	// Token: 0x06003DFB RID: 15867 RVA: 0x000D92E8 File Offset: 0x000D74E8
	protected virtual bool VerifyCompatible(global::UnityEngine.GameObject attachment)
	{
		return true;
	}

	// Token: 0x06003DFC RID: 15868 RVA: 0x000D92EC File Offset: 0x000D74EC
	protected virtual void OnAddAttached()
	{
	}

	// Token: 0x06003DFD RID: 15869 RVA: 0x000D92F0 File Offset: 0x000D74F0
	protected virtual void OnRemoveAttached()
	{
	}

	// Token: 0x06003DFE RID: 15870
	protected abstract void DisableMod(global::ItemModRepresentation.Reason reason);

	// Token: 0x06003DFF RID: 15871
	protected abstract void EnableMod(global::ItemModRepresentation.Reason reason);

	// Token: 0x04001F4F RID: 8015
	private global::UnityEngine.GameObject _attached;

	// Token: 0x04001F50 RID: 8016
	protected readonly bool defaultsOn;

	// Token: 0x04001F51 RID: 8017
	private bool _on;
}
