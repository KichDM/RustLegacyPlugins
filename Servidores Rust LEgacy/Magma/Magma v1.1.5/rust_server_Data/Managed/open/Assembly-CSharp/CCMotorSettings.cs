using System;
using UnityEngine;

// Token: 0x02000300 RID: 768
public sealed class CCMotorSettings : global::UnityEngine.ScriptableObject
{
	// Token: 0x06001A33 RID: 6707 RVA: 0x00066D98 File Offset: 0x00064F98
	public CCMotorSettings()
	{
	}

	// Token: 0x06001A34 RID: 6708 RVA: 0x00066F60 File Offset: 0x00065160
	// Note: this type is marked as 'beforefieldinit'.
	static CCMotorSettings()
	{
	}

	// Token: 0x17000743 RID: 1859
	// (get) Token: 0x06001A35 RID: 6709 RVA: 0x00066F6C File Offset: 0x0006516C
	// (set) Token: 0x06001A36 RID: 6710 RVA: 0x00067044 File Offset: 0x00065244
	public global::CCMotor.Movement movement
	{
		get
		{
			global::CCMotor.Movement result;
			result.maxForwardSpeed = this.maxForwardSpeed;
			result.maxSidewaysSpeed = this.maxSidewaysSpeed;
			result.maxBackwardsSpeed = this.maxBackwardsSpeed;
			result.maxGroundAcceleration = this.maxGroundAcceleration;
			result.maxAirAcceleration = this.maxAirAcceleration;
			result.inputAirVelocityRatio = this.inputAirVelocityRatio;
			result.gravity = this.gravity;
			result.maxFallSpeed = this.maxFallSpeed;
			result.maxAirHorizontalSpeed = this.maxAirHorizontalSpeed;
			result.maxUnblockingHeightDifference = this.maxUnblockingHeightDifference;
			result.slopeSpeedMultiplier = new global::UnityEngine.AnimationCurve(this.slopeSpeedMultiplier.keys);
			result.slopeSpeedMultiplier.postWrapMode = this.slopeSpeedMultiplier.postWrapMode;
			result.slopeSpeedMultiplier.preWrapMode = this.slopeSpeedMultiplier.preWrapMode;
			return result;
		}
		set
		{
			this.maxForwardSpeed = value.maxForwardSpeed;
			this.maxSidewaysSpeed = value.maxSidewaysSpeed;
			this.maxBackwardsSpeed = value.maxBackwardsSpeed;
			this.maxGroundAcceleration = value.maxGroundAcceleration;
			this.maxAirAcceleration = value.maxAirAcceleration;
			this.inputAirVelocityRatio = value.inputAirVelocityRatio;
			this.gravity = value.gravity;
			this.maxFallSpeed = value.maxFallSpeed;
			this.maxUnblockingHeightDifference = value.maxUnblockingHeightDifference;
			this.slopeSpeedMultiplier.keys = value.slopeSpeedMultiplier.keys;
			this.slopeSpeedMultiplier.postWrapMode = value.slopeSpeedMultiplier.postWrapMode;
			this.slopeSpeedMultiplier.preWrapMode = value.slopeSpeedMultiplier.preWrapMode;
		}
	}

	// Token: 0x17000744 RID: 1860
	// (get) Token: 0x06001A37 RID: 6711 RVA: 0x0006710C File Offset: 0x0006530C
	// (set) Token: 0x06001A38 RID: 6712 RVA: 0x0006715C File Offset: 0x0006535C
	public global::CCMotor.Jumping jumping
	{
		get
		{
			global::CCMotor.Jumping result;
			result.enable = this.jumpEnable;
			result.baseHeight = this.jumpBaseHeight;
			result.extraHeight = this.jumpExtraHeight;
			result.perpAmount = this.jumpPerpAmount;
			result.steepPerpAmount = this.jumpSteepPerpAmount;
			return result;
		}
		set
		{
			this.jumpEnable = value.enable;
			this.jumpBaseHeight = value.baseHeight;
			this.jumpExtraHeight = value.extraHeight;
			this.jumpPerpAmount = value.perpAmount;
			this.jumpSteepPerpAmount = value.steepPerpAmount;
		}
	}

	// Token: 0x17000745 RID: 1861
	// (get) Token: 0x06001A39 RID: 6713 RVA: 0x000671AC File Offset: 0x000653AC
	// (set) Token: 0x06001A3A RID: 6714 RVA: 0x000671F0 File Offset: 0x000653F0
	public global::CCMotor.Sliding sliding
	{
		get
		{
			global::CCMotor.Sliding result;
			result.enable = this.slidingEnable;
			result.slidingSpeed = this.slidingSpeed;
			result.sidewaysControl = this.slidingSidewaysControl;
			result.speedControl = this.slidingSpeedControl;
			return result;
		}
		set
		{
			this.slidingEnable = value.enable;
			this.slidingSpeed = value.slidingSpeed;
			this.slidingSidewaysControl = value.sidewaysControl;
			this.slidingSpeedControl = value.speedControl;
		}
	}

	// Token: 0x17000746 RID: 1862
	// (get) Token: 0x06001A3B RID: 6715 RVA: 0x00067234 File Offset: 0x00065434
	// (set) Token: 0x06001A3C RID: 6716 RVA: 0x0006725C File Offset: 0x0006545C
	public global::CCMotor.MovingPlatform movingPlatform
	{
		get
		{
			global::CCMotor.MovingPlatform result;
			result.enable = this.platformMovementEnable;
			result.movementTransfer = this.platformMovementTransfer;
			return result;
		}
		set
		{
			this.platformMovementEnable = value.enable;
			this.platformMovementTransfer = value.movementTransfer;
		}
	}

	// Token: 0x06001A3D RID: 6717 RVA: 0x00067278 File Offset: 0x00065478
	public void BindSettingsTo(global::CCMotor motor)
	{
		motor.jumping.setup = this.jumping;
		motor.movement.setup = this.movement;
		motor.movingPlatform.setup = this.movingPlatform;
		motor.sliding = this.sliding;
		motor.OnBindCCMotorSettings();
	}

	// Token: 0x06001A3E RID: 6718 RVA: 0x000672CC File Offset: 0x000654CC
	public void CopySettingsFrom(global::CCMotor motor)
	{
		this.jumping = motor.jumping.setup;
		this.movement = motor.movement.setup;
		this.movingPlatform = motor.movingPlatform.setup;
		this.sliding = motor.sliding;
	}

	// Token: 0x06001A3F RID: 6719 RVA: 0x00067318 File Offset: 0x00065518
	public override string ToString()
	{
		return string.Format("[CCMotorSettings: movement={0}, jumping={1}, sliding={2}, movingPlatform={3}]", new object[]
		{
			this.movement,
			this.jumping,
			this.sliding,
			this.movingPlatform
		});
	}

	// Token: 0x04000F09 RID: 3849
	private static readonly global::CCMotor.Movement Movement_init = global::CCMotor.Movement.init;

	// Token: 0x04000F0A RID: 3850
	public float maxForwardSpeed = global::CCMotorSettings.Movement_init.maxForwardSpeed;

	// Token: 0x04000F0B RID: 3851
	public float maxSidewaysSpeed = global::CCMotorSettings.Movement_init.maxSidewaysSpeed;

	// Token: 0x04000F0C RID: 3852
	public float maxBackwardsSpeed = global::CCMotorSettings.Movement_init.maxBackwardsSpeed;

	// Token: 0x04000F0D RID: 3853
	public float maxGroundAcceleration = global::CCMotorSettings.Movement_init.maxGroundAcceleration;

	// Token: 0x04000F0E RID: 3854
	public float maxAirAcceleration = global::CCMotorSettings.Movement_init.maxAirAcceleration;

	// Token: 0x04000F0F RID: 3855
	public float inputAirVelocityRatio = global::CCMotorSettings.Movement_init.inputAirVelocityRatio;

	// Token: 0x04000F10 RID: 3856
	public float gravity = global::CCMotorSettings.Movement_init.gravity;

	// Token: 0x04000F11 RID: 3857
	public float maxFallSpeed = global::CCMotorSettings.Movement_init.maxFallSpeed;

	// Token: 0x04000F12 RID: 3858
	public float maxAirHorizontalSpeed = global::CCMotorSettings.Movement_init.maxAirHorizontalSpeed;

	// Token: 0x04000F13 RID: 3859
	public float maxUnblockingHeightDifference = global::CCMotorSettings.Movement_init.maxUnblockingHeightDifference;

	// Token: 0x04000F14 RID: 3860
	public global::UnityEngine.AnimationCurve slopeSpeedMultiplier = global::CCMotor.Movement.init.slopeSpeedMultiplier;

	// Token: 0x04000F15 RID: 3861
	public bool jumpEnable = global::CCMotor.Jumping.init.enable;

	// Token: 0x04000F16 RID: 3862
	public float jumpBaseHeight = global::CCMotor.Jumping.init.baseHeight;

	// Token: 0x04000F17 RID: 3863
	public float jumpExtraHeight = global::CCMotor.Jumping.init.extraHeight;

	// Token: 0x04000F18 RID: 3864
	public float jumpPerpAmount = global::CCMotor.Jumping.init.perpAmount;

	// Token: 0x04000F19 RID: 3865
	public float jumpSteepPerpAmount = global::CCMotor.Jumping.init.steepPerpAmount;

	// Token: 0x04000F1A RID: 3866
	public bool slidingEnable = global::CCMotor.Sliding.init.enable;

	// Token: 0x04000F1B RID: 3867
	public float slidingSpeed = global::CCMotor.Sliding.init.slidingSpeed;

	// Token: 0x04000F1C RID: 3868
	public float slidingSidewaysControl = global::CCMotor.Sliding.init.sidewaysControl;

	// Token: 0x04000F1D RID: 3869
	public float slidingSpeedControl = global::CCMotor.Sliding.init.speedControl;

	// Token: 0x04000F1E RID: 3870
	public bool platformMovementEnable = global::CCMotor.MovingPlatform.init.enable;

	// Token: 0x04000F1F RID: 3871
	public global::CCMotor.JumpMovementTransfer platformMovementTransfer = global::CCMotor.MovingPlatform.init.movementTransfer;
}
