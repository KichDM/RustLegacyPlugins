using System;
using UnityEngine;

// Token: 0x020004E8 RID: 1256
public abstract class VisReactor : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002B85 RID: 11141 RVA: 0x000A38F0 File Offset: 0x000A1AF0
	protected VisReactor()
	{
	}

	// Token: 0x1700098F RID: 2447
	// (set) Token: 0x06002B86 RID: 11142 RVA: 0x000A38F8 File Offset: 0x000A1AF8
	internal global::VisNode __visNode
	{
		set
		{
			this._visNode = value;
		}
	}

	// Token: 0x17000990 RID: 2448
	// (get) Token: 0x06002B87 RID: 11143 RVA: 0x000A3904 File Offset: 0x000A1B04
	public global::VisNode node
	{
		get
		{
			return this._visNode;
		}
	}

	// Token: 0x17000991 RID: 2449
	// (get) Token: 0x06002B88 RID: 11144 RVA: 0x000A390C File Offset: 0x000A1B0C
	protected global::VisNode self
	{
		get
		{
			return this._visNode;
		}
	}

	// Token: 0x06002B89 RID: 11145 RVA: 0x000A3914 File Offset: 0x000A1B14
	protected virtual void React_SpectatedEnter()
	{
	}

	// Token: 0x06002B8A RID: 11146 RVA: 0x000A3918 File Offset: 0x000A1B18
	protected virtual void React_SpectatedExit()
	{
	}

	// Token: 0x06002B8B RID: 11147 RVA: 0x000A391C File Offset: 0x000A1B1C
	protected virtual void React_SpectatorAdd(global::VisNode spectator)
	{
	}

	// Token: 0x06002B8C RID: 11148 RVA: 0x000A3920 File Offset: 0x000A1B20
	protected virtual void React_SpectatorRemove(global::VisNode spectator)
	{
	}

	// Token: 0x06002B8D RID: 11149 RVA: 0x000A3924 File Offset: 0x000A1B24
	protected virtual void React_AwareEnter()
	{
	}

	// Token: 0x06002B8E RID: 11150 RVA: 0x000A3928 File Offset: 0x000A1B28
	protected virtual void React_AwareExit()
	{
	}

	// Token: 0x06002B8F RID: 11151 RVA: 0x000A392C File Offset: 0x000A1B2C
	protected virtual void React_SeeAdd(global::VisNode spotted)
	{
	}

	// Token: 0x06002B90 RID: 11152 RVA: 0x000A3930 File Offset: 0x000A1B30
	protected virtual void React_SeeRemove(global::VisNode lost)
	{
	}

	// Token: 0x06002B91 RID: 11153 RVA: 0x000A3934 File Offset: 0x000A1B34
	internal void SPECTATED_ENTER()
	{
		try
		{
			this.React_SpectatedEnter();
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogError(ex, this);
		}
	}

	// Token: 0x06002B92 RID: 11154 RVA: 0x000A3978 File Offset: 0x000A1B78
	internal void SPECTATOR_ADD(global::VisNode spectator)
	{
		try
		{
			this.React_SpectatorAdd(spectator);
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogError(ex, this);
		}
	}

	// Token: 0x06002B93 RID: 11155 RVA: 0x000A39BC File Offset: 0x000A1BBC
	internal void SPECTATOR_REMOVE(global::VisNode spectator)
	{
		try
		{
			this.React_SpectatorRemove(spectator);
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogError(ex, this);
		}
	}

	// Token: 0x06002B94 RID: 11156 RVA: 0x000A3A00 File Offset: 0x000A1C00
	internal void SPECTATED_EXIT()
	{
		try
		{
			this.React_SpectatedExit();
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogError(ex, this);
		}
	}

	// Token: 0x06002B95 RID: 11157 RVA: 0x000A3A44 File Offset: 0x000A1C44
	internal void AWARE_ENTER()
	{
		try
		{
			this.React_AwareEnter();
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogError(ex, this);
		}
	}

	// Token: 0x06002B96 RID: 11158 RVA: 0x000A3A88 File Offset: 0x000A1C88
	internal void SEE_ADD(global::VisNode spotted)
	{
		try
		{
			this.React_SeeAdd(spotted);
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogError(ex, this);
		}
	}

	// Token: 0x06002B97 RID: 11159 RVA: 0x000A3ACC File Offset: 0x000A1CCC
	internal void SEE_REMOVE(global::VisNode lost)
	{
		try
		{
			this.React_SeeRemove(lost);
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogError(ex, this);
		}
	}

	// Token: 0x06002B98 RID: 11160 RVA: 0x000A3B10 File Offset: 0x000A1D10
	internal void AWARE_EXIT()
	{
		try
		{
			this.React_AwareExit();
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogError(ex, this);
		}
	}

	// Token: 0x06002B99 RID: 11161 RVA: 0x000A3B54 File Offset: 0x000A1D54
	protected void Reset()
	{
		this._visNode = base.GetComponent<global::VisNode>();
		if (this._visNode)
		{
			this._visNode.__reactor = this;
		}
	}

	// Token: 0x04001604 RID: 5636
	[global::PrefetchComponent]
	[global::UnityEngine.SerializeField]
	private global::VisNode _visNode;
}
