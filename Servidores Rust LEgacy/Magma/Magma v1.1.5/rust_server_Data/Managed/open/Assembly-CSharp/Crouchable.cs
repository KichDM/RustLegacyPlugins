using System;
using UnityEngine;

// Token: 0x02000176 RID: 374
public class Crouchable : global::IDLocalCharacter
{
	// Token: 0x06000A4F RID: 2639 RVA: 0x0002A4D4 File Offset: 0x000286D4
	public Crouchable()
	{
	}

	// Token: 0x1700029A RID: 666
	// (get) Token: 0x06000A50 RID: 2640 RVA: 0x0002A4DC File Offset: 0x000286DC
	protected global::CharacterCrouchTrait crouchTrait
	{
		get
		{
			if (!this.didCrouchTraitTest)
			{
				this._crouchTrait = base.GetTrait<global::CharacterCrouchTrait>();
				this.didCrouchTraitTest = true;
			}
			return this._crouchTrait;
		}
	}

	// Token: 0x1700029B RID: 667
	// (get) Token: 0x06000A51 RID: 2641 RVA: 0x0002A510 File Offset: 0x00028710
	protected global::UnityEngine.AnimationCurve crouchCurve
	{
		get
		{
			return this.crouchTrait.crouchCurve;
		}
	}

	// Token: 0x1700029C RID: 668
	// (get) Token: 0x06000A52 RID: 2642 RVA: 0x0002A520 File Offset: 0x00028720
	protected float crouchToSpeedFraction
	{
		get
		{
			return this.crouchTrait.crouchToSpeedFraction;
		}
	}

	// Token: 0x1700029D RID: 669
	// (get) Token: 0x06000A53 RID: 2643 RVA: 0x0002A530 File Offset: 0x00028730
	public new global::Crouchable crouchable
	{
		get
		{
			return this;
		}
	}

	// Token: 0x1700029E RID: 670
	// (get) Token: 0x06000A54 RID: 2644 RVA: 0x0002A534 File Offset: 0x00028734
	public new bool crouched
	{
		get
		{
			return this.crouchUnits < 0f;
		}
	}

	// Token: 0x06000A55 RID: 2645 RVA: 0x0002A544 File Offset: 0x00028744
	public void ApplyCrouchOffset(ref global::CCTotem.PositionPlacement placement)
	{
		float num = placement.bottom.y + base.initialEyesOffsetY;
		float num2 = placement.originalTop.y - num;
		float num3 = placement.top.y - num2;
		float num4 = num3 - num;
		this.crouchUnits = ((!global::UnityEngine.Mathf.Approximately(num4, 0f)) ? num4 : 0f);
		base.idMain.InvalidateEyesOffset();
	}

	// Token: 0x06000A56 RID: 2646 RVA: 0x0002A5B0 File Offset: 0x000287B0
	protected internal void ApplyCrouch(ref global::UnityEngine.Vector3 localPosition)
	{
		localPosition.y += this.crouchUnits;
	}

	// Token: 0x0400078B RID: 1931
	[global::System.NonSerialized]
	private global::CharacterCrouchTrait _crouchTrait;

	// Token: 0x0400078C RID: 1932
	[global::System.NonSerialized]
	private bool didCrouchTraitTest;

	// Token: 0x0400078D RID: 1933
	[global::System.NonSerialized]
	private float crouchUnits;

	// Token: 0x0400078E RID: 1934
	[global::System.NonSerialized]
	private float crouchTime;
}
