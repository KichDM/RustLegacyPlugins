using System;

// Token: 0x0200017D RID: 381
public abstract class IDLocalCharacterIdleControl : global::IDLocalCharacter
{
	// Token: 0x06000B2A RID: 2858 RVA: 0x0002B58C File Offset: 0x0002978C
	protected IDLocalCharacterIdleControl()
	{
	}

	// Token: 0x17000306 RID: 774
	// (get) Token: 0x06000B2B RID: 2859 RVA: 0x0002B59C File Offset: 0x0002979C
	public new global::IDLocalCharacterIdleControl idleControl
	{
		get
		{
			return this;
		}
	}

	// Token: 0x06000B2C RID: 2860 RVA: 0x0002B5A0 File Offset: 0x000297A0
	internal bool SetIdle(bool value)
	{
		if (!this._setIdle)
		{
			this._setIdle = true;
		}
		else
		{
			if (this._idle == value)
			{
				return false;
			}
			if (this._changingIdle)
			{
				throw new global::System.InvalidOperationException("check callstack. idleControl.set was invoked multiple times. avoid it");
			}
		}
		this._changingIdle = true;
		this._idle = value;
		if (value)
		{
			try
			{
				this.OnIdleEnter();
			}
			finally
			{
				this._changingIdle = false;
			}
		}
		else
		{
			try
			{
				this.OnIdleExit();
			}
			finally
			{
				this._changingIdle = false;
			}
		}
		return true;
	}

	// Token: 0x17000307 RID: 775
	// (get) Token: 0x06000B2D RID: 2861 RVA: 0x0002B65C File Offset: 0x0002985C
	public new bool? idle
	{
		get
		{
			if (this._setIdle)
			{
				return new bool?(this._idle);
			}
			return null;
		}
	}

	// Token: 0x06000B2E RID: 2862
	protected abstract void OnIdleEnter();

	// Token: 0x06000B2F RID: 2863
	protected abstract void OnIdleExit();

	// Token: 0x0400079D RID: 1949
	[global::System.NonSerialized]
	internal bool _idle = true;

	// Token: 0x0400079E RID: 1950
	[global::System.NonSerialized]
	internal bool _setIdle;

	// Token: 0x0400079F RID: 1951
	[global::System.NonSerialized]
	internal bool _changingIdle;
}
