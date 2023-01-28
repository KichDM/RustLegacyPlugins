using System;
using UnityEngine;

// Token: 0x020006D6 RID: 1750
public abstract class BandageItem<T> : global::HeldItem<T> where T : global::BandageDataBlock
{
	// Token: 0x06003BDC RID: 15324 RVA: 0x000D4B34 File Offset: 0x000D2D34
	protected BandageItem(T db) : base(db)
	{
	}

	// Token: 0x17000B36 RID: 2870
	// (get) Token: 0x06003BDD RID: 15325 RVA: 0x000D4B48 File Offset: 0x000D2D48
	// (set) Token: 0x06003BDE RID: 15326 RVA: 0x000D4B50 File Offset: 0x000D2D50
	public float bandageStartTime
	{
		get
		{
			return this._bandageStartTime;
		}
		set
		{
			this._bandageStartTime = value;
		}
	}

	// Token: 0x17000B37 RID: 2871
	// (get) Token: 0x06003BDF RID: 15327 RVA: 0x000D4B5C File Offset: 0x000D2D5C
	// (set) Token: 0x06003BE0 RID: 15328 RVA: 0x000D4B64 File Offset: 0x000D2D64
	public bool lastFramePrimary
	{
		get
		{
			return this._lastFramePrimary;
		}
		set
		{
			this._lastFramePrimary = value;
		}
	}

	// Token: 0x17000B38 RID: 2872
	// (get) Token: 0x06003BE1 RID: 15329 RVA: 0x000D4B70 File Offset: 0x000D2D70
	// (set) Token: 0x06003BE2 RID: 15330 RVA: 0x000D4B78 File Offset: 0x000D2D78
	public float lastBandageTime
	{
		get
		{
			return this._lastBandageTime;
		}
		set
		{
			this._lastBandageTime = value;
		}
	}

	// Token: 0x06003BE3 RID: 15331 RVA: 0x000D4B84 File Offset: 0x000D2D84
	public virtual bool CanBandage()
	{
		global::HumanBodyTakeDamage component = base.inventory.gameObject.GetComponent<global::HumanBodyTakeDamage>();
		if (!component.IsBleeding())
		{
			if (component.healthLossFraction > 0f)
			{
				T datablock = this.datablock;
				if (datablock.DoesGiveBlood())
				{
					goto IL_45;
				}
			}
			return false;
		}
		IL_45:
		return global::UnityEngine.Time.time - this.lastBandageTime > 1.5f;
	}

	// Token: 0x06003BE4 RID: 15332 RVA: 0x000D4BEC File Offset: 0x000D2DEC
	public virtual void Primary(ref global::HumanController.InputSample sample)
	{
		this.lastFramePrimary = true;
		sample.crouch = true;
		sample.walk = 0f;
		sample.strafe = 0f;
		sample.jump = false;
		sample.sprint = false;
		if (this.bandageStartTime == -1f)
		{
			this.StartBandage();
		}
		float num = global::UnityEngine.Time.time - this.bandageStartTime;
		float num2 = global::UnityEngine.Mathf.Clamp(num / this.datablock.bandageDuration, 0f, 1f);
		string empty = string.Empty;
		T datablock = this.datablock;
		bool flag = datablock.DoesGiveBlood();
		T datablock2 = this.datablock;
		bool flag2 = datablock2.DoesBandage();
		if (!flag2 || flag)
		{
			if (!flag2 || !flag)
			{
				if (flag2 || flag)
				{
				}
			}
		}
		if (num2 >= 1f)
		{
			this.FinishBandage();
		}
	}

	// Token: 0x06003BE5 RID: 15333 RVA: 0x000D4CF8 File Offset: 0x000D2EF8
	public void StartBandage()
	{
		this.bandageStartTime = global::UnityEngine.Time.time;
	}

	// Token: 0x06003BE6 RID: 15334 RVA: 0x000D4D08 File Offset: 0x000D2F08
	public void FinishBandage()
	{
		this.bandageStartTime = -1f;
		int num = 1;
		if (base.Consume(ref num))
		{
			base.inventory.RemoveItem(base.slot);
		}
		base.itemRepresentation.Action(3, 0);
	}

	// Token: 0x06003BE7 RID: 15335 RVA: 0x000D4D50 File Offset: 0x000D2F50
	public void CancelBandage()
	{
		this.bandageStartTime = -1f;
	}

	// Token: 0x04001E9A RID: 7834
	private float _bandageStartTime = -1f;

	// Token: 0x04001E9B RID: 7835
	private bool _lastFramePrimary;

	// Token: 0x04001E9C RID: 7836
	private float _lastBandageTime;
}
