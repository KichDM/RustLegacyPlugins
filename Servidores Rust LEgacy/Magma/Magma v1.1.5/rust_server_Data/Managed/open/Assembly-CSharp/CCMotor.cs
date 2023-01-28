using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Facepunch.Geometry;
using UnityEngine;

// Token: 0x020002F0 RID: 752
[global::UnityEngine.AddComponentMenu("ID/Local/CCMotor")]
public sealed class CCMotor : global::IDRemote
{
	// Token: 0x060019CB RID: 6603 RVA: 0x00063DB8 File Offset: 0x00061FB8
	public CCMotor()
	{
	}

	// Token: 0x060019CC RID: 6604 RVA: 0x00063DFC File Offset: 0x00061FFC
	// Note: this type is marked as 'beforefieldinit'.
	static CCMotor()
	{
	}

	// Token: 0x17000726 RID: 1830
	// (get) Token: 0x060019CD RID: 6605 RVA: 0x00063E00 File Offset: 0x00062000
	[global::System.Obsolete("Do not query this", true)]
	public global::UnityEngine.Transform transform
	{
		get
		{
			return this.tr;
		}
	}

	// Token: 0x17000727 RID: 1831
	// (get) Token: 0x060019CE RID: 6606 RVA: 0x00063E08 File Offset: 0x00062008
	private global::CCMotor.YawAngle characterYawAngle
	{
		get
		{
			global::Character character = (global::Character)base.idMain;
			return character.eyesYaw + global::UnityEngine.Mathf.DeltaAngle(this.previousYaw.Degrees, this.currentYaw.Degrees);
		}
	}

	// Token: 0x060019CF RID: 6607 RVA: 0x00063E48 File Offset: 0x00062048
	private global::UnityEngine.Vector3 InverseTransformPoint(global::UnityEngine.Vector3 point)
	{
		return this.InverseTransformDirection(this.tr.InverseTransformPoint(point));
	}

	// Token: 0x060019D0 RID: 6608 RVA: 0x00063E5C File Offset: 0x0006205C
	private global::UnityEngine.Vector3 TransformPoint(global::UnityEngine.Vector3 point)
	{
		return this.tr.TransformPoint(this.TransformDirection(point));
	}

	// Token: 0x060019D1 RID: 6609 RVA: 0x00063E70 File Offset: 0x00062070
	private global::UnityEngine.Vector3 InverseTransformDirection(global::UnityEngine.Vector3 direction)
	{
		return this.characterYawAngle.Unrotate(direction);
	}

	// Token: 0x060019D2 RID: 6610 RVA: 0x00063E8C File Offset: 0x0006208C
	private global::UnityEngine.Vector3 TransformDirection(global::UnityEngine.Vector3 direction)
	{
		return this.characterYawAngle.Rotate(direction);
	}

	// Token: 0x17000728 RID: 1832
	// (get) Token: 0x060019D3 RID: 6611 RVA: 0x00063EA8 File Offset: 0x000620A8
	// (set) Token: 0x060019D4 RID: 6612 RVA: 0x00063EB0 File Offset: 0x000620B0
	public global::CCMotorSettings settings
	{
		get
		{
			return this._settings;
		}
		set
		{
			if (value != this._settings)
			{
				this._settings = value;
				if (global::UnityEngine.Application.isPlaying)
				{
					value.BindSettingsTo(this);
				}
			}
		}
	}

	// Token: 0x17000729 RID: 1833
	// (get) Token: 0x060019D5 RID: 6613 RVA: 0x00063EDC File Offset: 0x000620DC
	private float baseHeightVerticalSpeed
	{
		get
		{
			return this.jumpVerticalSpeedCalculator.CalculateVerticalSpeed(ref this.jumping.setup, ref this.movement.setup);
		}
	}

	// Token: 0x1700072A RID: 1834
	// (get) Token: 0x060019D6 RID: 6614 RVA: 0x00063F00 File Offset: 0x00062100
	public global::CCTotemPole ccTotemPole
	{
		get
		{
			return this.cc;
		}
	}

	// Token: 0x1700072B RID: 1835
	// (get) Token: 0x060019D7 RID: 6615 RVA: 0x00063F08 File Offset: 0x00062108
	public bool isJumping
	{
		get
		{
			return this.jumping.jumping;
		}
	}

	// Token: 0x1700072C RID: 1836
	// (get) Token: 0x060019D8 RID: 6616 RVA: 0x00063F18 File Offset: 0x00062118
	public bool isSliding
	{
		get
		{
			return this._grounded && this.sliding.enable && this.tooSteep;
		}
	}

	// Token: 0x1700072D RID: 1837
	// (get) Token: 0x060019D9 RID: 6617 RVA: 0x00063F4C File Offset: 0x0006214C
	public bool isTouchingCeiling
	{
		get
		{
			return (this.movement.collisionFlags & 2) == 2;
		}
	}

	// Token: 0x1700072E RID: 1838
	// (get) Token: 0x060019DA RID: 6618 RVA: 0x00063F60 File Offset: 0x00062160
	public bool isGrounded
	{
		get
		{
			return this._grounded;
		}
	}

	// Token: 0x1700072F RID: 1839
	// (get) Token: 0x060019DB RID: 6619 RVA: 0x00063F68 File Offset: 0x00062168
	public bool isCrouchBlocked
	{
		get
		{
			return this.movement.crouchBlocked;
		}
	}

	// Token: 0x17000730 RID: 1840
	// (get) Token: 0x060019DC RID: 6620 RVA: 0x00063F78 File Offset: 0x00062178
	public bool tooSteep
	{
		get
		{
			return this._groundNormal.y <= global::UnityEngine.Mathf.Cos(this.cc.slopeLimit * 0.017453292f);
		}
	}

	// Token: 0x17000731 RID: 1841
	// (get) Token: 0x060019DD RID: 6621 RVA: 0x00063FAC File Offset: 0x000621AC
	public global::UnityEngine.Vector3 direction
	{
		get
		{
			return this.input.moveDirection;
		}
	}

	// Token: 0x17000732 RID: 1842
	// (get) Token: 0x060019DE RID: 6622 RVA: 0x00063FBC File Offset: 0x000621BC
	// (set) Token: 0x060019DF RID: 6623 RVA: 0x00063FC4 File Offset: 0x000621C4
	public bool driveable
	{
		get
		{
			return this.canControl;
		}
		set
		{
			this.canControl = value;
		}
	}

	// Token: 0x17000733 RID: 1843
	// (get) Token: 0x060019E0 RID: 6624 RVA: 0x00063FD0 File Offset: 0x000621D0
	public global::UnityEngine.Vector3 currentGroundNormal
	{
		get
		{
			return this._groundNormal;
		}
	}

	// Token: 0x17000734 RID: 1844
	// (get) Token: 0x060019E1 RID: 6625 RVA: 0x00063FD8 File Offset: 0x000621D8
	public global::UnityEngine.Vector3 previousGroundNormal
	{
		get
		{
			return this._lastGroundNormal;
		}
	}

	// Token: 0x17000735 RID: 1845
	// (get) Token: 0x060019E2 RID: 6626 RVA: 0x00063FE0 File Offset: 0x000621E0
	public global::UnityEngine.Vector3 currentHitPoint
	{
		get
		{
			return this.movement.hitPoint;
		}
	}

	// Token: 0x17000736 RID: 1846
	// (get) Token: 0x060019E3 RID: 6627 RVA: 0x00063FF0 File Offset: 0x000621F0
	public global::UnityEngine.Vector3 previousHitPoint
	{
		get
		{
			return this.movement.lastHitPoint;
		}
	}

	// Token: 0x17000737 RID: 1847
	// (get) Token: 0x060019E4 RID: 6628 RVA: 0x00064000 File Offset: 0x00062200
	public global::UnityEngine.Vector3? fallbackCurrentGroundNormal
	{
		get
		{
			if (this._grounded)
			{
				return new global::UnityEngine.Vector3?(this._groundNormal);
			}
			return null;
		}
	}

	// Token: 0x17000738 RID: 1848
	// (get) Token: 0x060019E5 RID: 6629 RVA: 0x00064030 File Offset: 0x00062230
	public global::UnityEngine.Vector3? fallbackPreviousGroundNormal
	{
		get
		{
			if (this._lastGroundNormal.x == 0f && this._lastGroundNormal.y == 0f && this._lastGroundNormal.z == 0f)
			{
				return null;
			}
			return new global::UnityEngine.Vector3?(this._lastGroundNormal);
		}
	}

	// Token: 0x17000739 RID: 1849
	// (get) Token: 0x060019E6 RID: 6630 RVA: 0x00064094 File Offset: 0x00062294
	// (set) Token: 0x060019E7 RID: 6631 RVA: 0x000640A4 File Offset: 0x000622A4
	public global::UnityEngine.Vector3 velocity
	{
		get
		{
			return this.movement.velocity;
		}
		set
		{
			this._grounded = false;
			this.movement.velocity = value;
			this.movement.frameVelocity = default(global::UnityEngine.Vector3);
			if (this.sendExternalVelocityMessage)
			{
				this.RouteMessage("OnExternalVelocity");
			}
		}
	}

	// Token: 0x1700073A RID: 1850
	// (get) Token: 0x060019E8 RID: 6632 RVA: 0x000640F0 File Offset: 0x000622F0
	// (set) Token: 0x060019E9 RID: 6633 RVA: 0x00064100 File Offset: 0x00062300
	public global::UnityEngine.Vector3 differentVelocity
	{
		get
		{
			return this.movement.velocity;
		}
		set
		{
			if (this.movement.velocity.x != value.x || this.movement.velocity.y != value.y || this.movement.velocity.z != value.z)
			{
				this.velocity = value;
			}
		}
	}

	// Token: 0x1700073B RID: 1851
	// (get) Token: 0x060019EA RID: 6634 RVA: 0x00064168 File Offset: 0x00062368
	public bool movingWithPlatform
	{
		get
		{
			return this.movingPlatform.setup.enable && (this._grounded || this.movingPlatform.setup.movementTransfer == global::CCMotor.JumpMovementTransfer.PermaLocked) && this.movingPlatform.activePlatform != null;
		}
	}

	// Token: 0x060019EB RID: 6635 RVA: 0x000641C0 File Offset: 0x000623C0
	private void Awake()
	{
		if (this._settings)
		{
			this._settings.BindSettingsTo(this);
		}
	}

	// Token: 0x060019EC RID: 6636 RVA: 0x000641E0 File Offset: 0x000623E0
	private global::CCTotem.MoveInfo ApplyMovementDelta(ref global::UnityEngine.Vector3 moveDistance, float crouchDelta)
	{
		float height = this.cc.Height + crouchDelta;
		return this.cc.Move(moveDistance, height);
	}

	// Token: 0x060019ED RID: 6637 RVA: 0x00064210 File Offset: 0x00062410
	private void ApplyYawDelta(float yRotation)
	{
		if (yRotation != 0f)
		{
			this.currentYaw = global::UnityEngine.Mathf.DeltaAngle(0f, this.currentYaw.Degrees + yRotation);
		}
	}

	// Token: 0x060019EE RID: 6638 RVA: 0x00064240 File Offset: 0x00062440
	public void Step()
	{
		this.Step(global::UnityEngine.Time.deltaTime);
	}

	// Token: 0x060019EF RID: 6639 RVA: 0x00064250 File Offset: 0x00062450
	public void Step(float deltaTime)
	{
		if (deltaTime <= 0f || !base.enabled)
		{
			return;
		}
		this.StepPhysics(deltaTime);
	}

	// Token: 0x060019F0 RID: 6640 RVA: 0x00064270 File Offset: 0x00062470
	private void StepPhysics(float deltaTime)
	{
		global::UnityEngine.Vector3 velocity = this.movement.velocity;
		global::UnityEngine.Vector3 acceleration = this.movement.acceleration;
		this.ApplyInputVelocityChange(deltaTime, ref velocity, ref acceleration);
		bool flag;
		this.ApplyGravityAndJumping(deltaTime, ref velocity, ref acceleration, out flag);
		if (this.movingWithPlatform)
		{
			global::UnityEngine.Vector3 vector = this.movingPlatform.activePlatform.TransformPoint(this.movingPlatform.activeLocal.point);
			global::UnityEngine.Vector3 vector2;
			vector2.x = vector.x - this.movingPlatform.activeGlobal.point.x;
			vector2.y = vector.y - this.movingPlatform.activeGlobal.point.y;
			vector2.z = vector.z - this.movingPlatform.activeGlobal.point.z;
			if (vector2.x != 0f || vector2.y != 0f || vector2.z != 0f)
			{
				this.ApplyMovementDelta(ref vector2, 0f);
			}
			global::UnityEngine.Quaternion quaternion = this.movingPlatform.activePlatform.rotation * this.movingPlatform.activeLocal.rotation;
			float y = (quaternion * global::UnityEngine.Quaternion.Inverse(this.movingPlatform.activeGlobal.rotation)).eulerAngles.y;
			if (y != 0f)
			{
				this.ApplyYawDelta(y);
			}
		}
		global::UnityEngine.Vector3 vector3;
		vector3.x = acceleration.x * deltaTime;
		vector3.y = acceleration.y * deltaTime;
		vector3.z = acceleration.z * deltaTime;
		global::UnityEngine.Vector3 position = this.tr.position;
		global::UnityEngine.Vector3 vector4;
		global::UnityEngine.Vector3 vector5;
		if (flag)
		{
			vector4.x = position.x + deltaTime * (this.movement.velocity.x + vector3.x / 2f);
			vector4.y = position.y + deltaTime * (this.movement.velocity.y + vector3.y / 2f);
			vector4.z = position.z + deltaTime * (this.movement.velocity.z + vector3.z / 2f);
			vector5.x = vector4.x - position.x;
			vector5.y = vector4.y - position.y;
			vector5.z = vector4.z - position.z;
		}
		else
		{
			vector5.x = velocity.x * deltaTime;
			vector5.y = velocity.y * deltaTime;
			vector5.z = velocity.z * deltaTime;
			vector4.x = position.x + vector5.x;
			vector4.y = position.y + vector5.y;
			vector4.z = position.z + vector5.z;
		}
		float stepOffset = this.cc.stepOffset;
		float num = stepOffset * stepOffset;
		float num2 = vector5.x * vector5.x + vector5.z * vector5.z;
		float num3;
		if (num2 > num)
		{
			num3 = global::UnityEngine.Mathf.Sqrt(num2);
		}
		else
		{
			num3 = stepOffset;
		}
		if (this._grounded)
		{
			vector5.y -= num3;
		}
		this.movingPlatform.hitPlatform = null;
		this._groundNormal = default(global::UnityEngine.Vector3);
		float crouchDelta = this.input.crouchSpeed * deltaTime;
		global::CCTotem.MoveInfo moveInfo = this.ApplyMovementDelta(ref vector5, crouchDelta);
		this.movement.collisionFlags = moveInfo.CollisionFlags;
		float num4 = moveInfo.WantedHeight - moveInfo.PositionPlacement.height;
		global::UnityEngine.CollisionFlags collisionFlags = moveInfo.CollisionFlags | moveInfo.WorkingCollisionFlags;
		this.movement.crouchBlocked = (this.input.crouchSpeed > 0f && (collisionFlags & 2) == 2 && num4 > this.movement.setup.maxUnblockingHeightDifference);
		this.movement.lastHitPoint = this.movement.hitPoint;
		this._lastGroundNormal = this._groundNormal;
		if (this.movingPlatform.setup.enable && this.movingPlatform.activePlatform != this.movingPlatform.hitPlatform && this.movingPlatform.hitPlatform != null)
		{
			this.movingPlatform.activePlatform = this.movingPlatform.hitPlatform;
			this.movingPlatform.lastMatrix = this.movingPlatform.hitPlatform.localToWorldMatrix;
			this.movingPlatform.newPlatform = true;
		}
		global::UnityEngine.Vector3 vector7;
		if (this.movement.collisionFlags != null)
		{
			this.movement.acceleration.x = 0f;
			this.movement.acceleration.y = 0f;
			this.movement.acceleration.z = 0f;
			global::UnityEngine.Vector3 vector6;
			vector6.x = velocity.x;
			vector6.y = 0f;
			vector6.z = velocity.z;
			vector7 = this.tr.position;
			this.movement.velocity.x = (vector7.x - position.x) / deltaTime;
			this.movement.velocity.y = (vector7.y - position.y) / deltaTime;
			this.movement.velocity.z = (vector7.z - position.z) / deltaTime;
			global::UnityEngine.Vector3 vector8;
			vector8.x = this.movement.velocity.x;
			vector8.y = 0f;
			vector8.z = this.movement.velocity.z;
			if (vector6.x == 0f && vector6.z == 0f)
			{
				this.movement.velocity.x = 0f;
				this.movement.velocity.z = 0f;
			}
			else
			{
				float num5 = (vector8.x * vector6.x + vector8.z * vector6.z) / (vector6.x * vector6.x + vector6.z * vector6.z);
				if (num5 <= 0f)
				{
					this.movement.velocity.x = 0f;
					this.movement.velocity.z = 0f;
				}
				else if (num5 >= 1f)
				{
					this.movement.velocity.x = vector6.x;
					this.movement.velocity.z = vector6.z;
				}
				else
				{
					this.movement.velocity.x = vector6.x * num5;
					this.movement.velocity.z = vector6.z * num5;
				}
			}
			if (this.movement.velocity.y < velocity.y - 0.001f)
			{
				if (this.movement.velocity.y < 0f)
				{
					this.movement.velocity.y = velocity.y;
				}
				else
				{
					this.jumping.holdingJumpButton = false;
				}
			}
		}
		else
		{
			vector7 = vector4;
			this.movement.velocity = velocity;
			this.movement.acceleration = acceleration;
		}
		if (this._grounded != this._groundNormal.y > 0.01f)
		{
			if (this._grounded)
			{
				this._grounded = false;
				if (this.movingPlatform.setup.enable && (this.movingPlatform.setup.movementTransfer == global::CCMotor.JumpMovementTransfer.InitTransfer || this.movingPlatform.setup.movementTransfer == global::CCMotor.JumpMovementTransfer.PermaTransfer))
				{
					this.movement.frameVelocity = this.movingPlatform.platformVelocity;
					this.movement.velocity = this.movement.velocity + this.movingPlatform.platformVelocity;
				}
				if (this.sendFallMessage)
				{
					this.RouteMessage("OnFall", 1);
				}
				vector7.y += num3;
			}
			else
			{
				this._grounded = true;
				this.jumping.jumping = false;
				if (this.jumping.startedJumping)
				{
					this.jumping.startedJumping = false;
					this.jumping.lastLandTime = global::UnityEngine.Time.time;
				}
				this.SubtractNewPlatformVelocity();
				if (this.sendLandMessage)
				{
					this.RouteMessage("OnLand", 1);
				}
			}
		}
		if (this.movingWithPlatform)
		{
			this.movingPlatform.activeGlobal.point.x = vector7.x;
			this.movingPlatform.activeGlobal.point.y = vector7.y + (this.cc.center.y - this.cc.height * 0.5f + this.cc.radius);
			this.movingPlatform.activeGlobal.point.z = vector7.z;
			this.movingPlatform.activeLocal.point = this.movingPlatform.activePlatform.InverseTransformPoint(this.movingPlatform.activeGlobal.point);
			this.movingPlatform.activeGlobal.rotation = this.tr.rotation;
			this.movingPlatform.activeLocal.rotation = global::UnityEngine.Quaternion.Inverse(this.movingPlatform.activePlatform.rotation) * this.movingPlatform.activeGlobal.rotation;
		}
		this.BindCharacter();
	}

	// Token: 0x060019F1 RID: 6641 RVA: 0x00064C78 File Offset: 0x00062E78
	private void FixedUpdate()
	{
		float deltaTime = global::UnityEngine.Time.deltaTime;
		if (deltaTime == 0f)
		{
			return;
		}
		if (this.movingPlatform.setup.enable)
		{
			if (this.movingPlatform.activePlatform != null)
			{
				global::UnityEngine.Matrix4x4 localToWorldMatrix = this.movingPlatform.activePlatform.localToWorldMatrix;
				if (!this.movingPlatform.newPlatform)
				{
					global::UnityEngine.Vector3 vector = localToWorldMatrix.MultiplyPoint3x4(this.movingPlatform.activeLocal.point);
					global::UnityEngine.Vector3 vector2 = this.movingPlatform.lastMatrix.MultiplyPoint3x4(this.movingPlatform.activeLocal.point);
					this.movingPlatform.platformVelocity.x = (vector.x - vector2.x) / deltaTime;
					this.movingPlatform.platformVelocity.y = (vector.y - vector2.y) / deltaTime;
					this.movingPlatform.platformVelocity.z = (vector.z - vector2.z) / deltaTime;
				}
				else
				{
					this.movingPlatform.newPlatform = false;
				}
				this.movingPlatform.lastMatrix = localToWorldMatrix;
			}
			else
			{
				this.movingPlatform.platformVelocity = default(global::UnityEngine.Vector3);
			}
		}
		if (this.stepMode == global::CCMotor.StepMode.ViaFixedUpdate)
		{
			this.StepPhysics(deltaTime);
		}
	}

	// Token: 0x060019F2 RID: 6642 RVA: 0x00064DCC File Offset: 0x00062FCC
	private void Update()
	{
		float deltaTime;
		if (this.stepMode != global::CCMotor.StepMode.ViaUpdate || (deltaTime = global::UnityEngine.Time.deltaTime) == 0f)
		{
			return;
		}
		this.StepPhysics(deltaTime);
	}

	// Token: 0x060019F3 RID: 6643 RVA: 0x00064E00 File Offset: 0x00063000
	private void DesiredHorizontalVelocity(ref global::UnityEngine.Vector3 inputMoveDirection, out global::UnityEngine.Vector3 desiredVelocity)
	{
		global::UnityEngine.Vector3 vector = this.InverseTransformDirection(inputMoveDirection);
		float num = this.MaxSpeedInDirection(ref vector);
		if (this._grounded)
		{
			num *= this.movement.setup.slopeSpeedMultiplier.Evaluate(global::UnityEngine.Mathf.Asin(this.movement.velocity.normalized.y) * 57.29578f);
		}
		desiredVelocity = this.TransformDirection(vector * num);
		if (this._grounded)
		{
			this.ApplyHorizontalPushVelocity(ref desiredVelocity);
		}
	}

	// Token: 0x060019F4 RID: 6644 RVA: 0x00064E90 File Offset: 0x00063090
	public float MaxSpeedInDirection(ref global::UnityEngine.Vector3 desiredMovementDirection)
	{
		if (desiredMovementDirection.x == 0f && desiredMovementDirection.y == 0f && desiredMovementDirection.z == 0f)
		{
			return 0f;
		}
		if (this.movement.setup.maxSidewaysSpeed == 0f)
		{
			return 0f;
		}
		float num = ((desiredMovementDirection.z <= 0f) ? this.movement.setup.maxBackwardsSpeed : this.movement.setup.maxForwardSpeed) / this.movement.setup.maxSidewaysSpeed;
		global::UnityEngine.Vector3 vector;
		vector.x = desiredMovementDirection.x;
		vector.y = 0f;
		vector.z = desiredMovementDirection.z / num;
		float num2 = vector.x * vector.x + vector.z * vector.z;
		if (num2 != 1f)
		{
			float num3 = global::UnityEngine.Mathf.Sqrt(num2);
			vector.x /= num3;
			vector.z /= num3;
		}
		vector.z *= num;
		return global::UnityEngine.Mathf.Sqrt(vector.x * vector.x + vector.z * vector.z) * this.movement.setup.maxSidewaysSpeed;
	}

	// Token: 0x060019F5 RID: 6645 RVA: 0x00064FF8 File Offset: 0x000631F8
	private void ApplyInputVelocityChange(float deltaTime, ref global::UnityEngine.Vector3 velocity, ref global::UnityEngine.Vector3 acceleration)
	{
		global::UnityEngine.Vector3 vector = (!this.canControl) ? default(global::UnityEngine.Vector3) : this.input.moveDirection;
		global::UnityEngine.Vector3 vector2;
		if (this._grounded && this.tooSteep)
		{
			vector2.y = 0f;
			float num = this._groundNormal.x * this._groundNormal.x + this._groundNormal.z * this._groundNormal.z;
			if (num == 1f)
			{
				vector2.x = this._groundNormal.x;
				vector2.z = this._groundNormal.z;
			}
			else
			{
				float num2 = global::UnityEngine.Mathf.Sqrt(num);
				vector2.x = this._groundNormal.x / num2;
				vector2.z = this._groundNormal.z / num2;
			}
			global::UnityEngine.Vector3 vector3 = global::UnityEngine.Vector3.Project(vector, vector2);
			vector2.x += vector3.x * this.sliding.speedControl + (vector.x - vector3.x) * this.sliding.sidewaysControl;
			vector2.z += vector3.z * this.sliding.speedControl + (vector.z - vector3.z) * this.sliding.sidewaysControl;
			vector2.y = vector3.y * this.sliding.speedControl + (vector.y - vector3.y) * this.sliding.sidewaysControl;
			vector2.x *= this.sliding.slidingSpeed;
			vector2.y *= this.sliding.slidingSpeed;
			vector2.z *= this.sliding.slidingSpeed;
		}
		else
		{
			this.DesiredHorizontalVelocity(ref vector, out vector2);
		}
		if (this.movingPlatform.setup.enable && this.movingPlatform.setup.movementTransfer == global::CCMotor.JumpMovementTransfer.PermaTransfer)
		{
			vector2.x += this.movement.frameVelocity.x;
			vector2.z += this.movement.frameVelocity.z;
			vector2.y = 0f;
		}
		if (this._grounded)
		{
			acceleration.x = 0f;
			acceleration.y = 0f;
			acceleration.z = 0f;
			float num3 = vector2.x * vector2.x + vector2.y * vector2.y + vector2.z * vector2.z;
			if (num3 != 0f)
			{
				vector2 = global::UnityEngine.Vector3.Cross(global::UnityEngine.Vector3.Cross(global::UnityEngine.Vector3.up, vector2), this._groundNormal);
				float num4 = vector2.x * vector2.x + vector2.y * vector2.y + vector2.z * vector2.z;
				if (num4 != num3)
				{
					float num5 = global::UnityEngine.Mathf.Sqrt(num3);
					if (num4 == 1f)
					{
						vector2.x *= num5;
						vector2.y *= num5;
						vector2.z *= num5;
					}
					else
					{
						float num6 = num5 / global::UnityEngine.Mathf.Sqrt(num4);
						vector2.x *= num6;
						vector2.y *= num6;
						vector2.z *= num6;
					}
				}
			}
		}
		else
		{
			acceleration.x = 0f;
			acceleration.y = 0f;
			acceleration.z = 0f;
			velocity.y = 0f;
		}
		if (this._grounded || this.canControl)
		{
			float num7 = ((!this._grounded) ? this.movement.setup.maxAirAcceleration : this.movement.setup.maxGroundAcceleration) * deltaTime;
			global::UnityEngine.Vector3 vector4;
			vector4.x = vector2.x - velocity.x;
			vector4.y = vector2.y - velocity.y;
			vector4.z = vector2.z - velocity.z;
			float num8 = vector4.x * vector4.x + vector4.y * vector4.y + vector4.z * vector4.z;
			if (num8 > num7 * num7)
			{
				float num9 = num7 / global::UnityEngine.Mathf.Sqrt(num8);
				vector4.x *= num9;
				vector4.y *= num9;
				vector4.z *= num9;
			}
			velocity += vector4;
		}
		if (this._grounded && velocity.y > 0f)
		{
			velocity.y = 0f;
		}
	}

	// Token: 0x060019F6 RID: 6646 RVA: 0x00065514 File Offset: 0x00063714
	private void ApplyGravityAndJumping(float deltaTime, ref global::UnityEngine.Vector3 velocity, ref global::UnityEngine.Vector3 acceleration, out bool simulate)
	{
		float time = global::UnityEngine.Time.time;
		if (!this.input.jump || !this.canControl)
		{
			this.jumping.holdingJumpButton = false;
			this.jumping.lastButtonDownTime = -100f;
		}
		if (this.input.jump && this.jumping.lastButtonDownTime < 0f && this.canControl)
		{
			this.jumping.lastButtonDownTime = time;
		}
		if (this._grounded)
		{
			if (velocity.y >= 0f)
			{
				velocity.y = -this.movement.setup.gravity * deltaTime;
			}
			else
			{
				velocity.y -= this.movement.setup.gravity * deltaTime;
			}
			if (this.jumping.setup.enable && this.canControl && time - this.jumping.lastButtonDownTime < 0.2f && (this.minTimeBetweenJumps <= 0f || time - this.jumping.lastLandTime >= this.minTimeBetweenJumps))
			{
				if (this.minTimeBetweenJumps > 0f && time - this.jumping.lastLandTime < this.minTimeBetweenJumps)
				{
					if (this.sendJumpFailureMessage)
					{
						this.RouteMessage("OnJumpFailed", 1);
					}
				}
				else
				{
					this._grounded = false;
					this.jumping.jumping = true;
					this.jumping.lastStartTime = time;
					this.jumping.lastButtonDownTime = -100f;
					this.jumping.holdingJumpButton = true;
					this.jumping.jumpDir = global::UnityEngine.Vector3.Slerp(global::UnityEngine.Vector3.up, this._groundNormal, (!this.tooSteep) ? this.jumping.setup.perpAmount : this.jumping.setup.steepPerpAmount);
					float num = this.jumpVerticalSpeedCalculator.CalculateVerticalSpeed(ref this.jumping.setup, ref this.movement.setup);
					velocity.x += this.jumping.jumpDir.x * num;
					velocity.y = this.jumping.jumpDir.y * num;
					velocity.z += this.jumping.jumpDir.z * num;
					if (this.movingPlatform.setup.enable && (this.movingPlatform.setup.movementTransfer == global::CCMotor.JumpMovementTransfer.InitTransfer || this.movingPlatform.setup.movementTransfer == global::CCMotor.JumpMovementTransfer.PermaTransfer))
					{
						this.movement.frameVelocity = this.movingPlatform.platformVelocity;
						velocity.x += this.movingPlatform.platformVelocity.x;
						velocity.y += this.movingPlatform.platformVelocity.y;
						velocity.z += this.movingPlatform.platformVelocity.z;
					}
					this.jumping.startedJumping = true;
					if (this.sendJumpMessage)
					{
						this.RouteMessage("OnJump", 1);
					}
				}
			}
			else
			{
				this.jumping.holdingJumpButton = false;
			}
			simulate = false;
		}
		else
		{
			acceleration.y = -this.movement.setup.gravity;
			acceleration.z = 0f;
			acceleration.x = 0f;
			if (this.jumping.jumping && this.jumping.holdingJumpButton && time < this.jumping.lastStartTime + this.jumping.setup.extraHeight / this.jumpVerticalSpeedCalculator.CalculateVerticalSpeed(ref this.jumping.setup, ref this.movement.setup))
			{
				acceleration.x += this.jumping.jumpDir.x * this.movement.setup.gravity;
				acceleration.y += this.jumping.jumpDir.y * this.movement.setup.gravity;
				acceleration.z += this.jumping.jumpDir.z * this.movement.setup.gravity;
			}
			global::UnityEngine.Vector3 vector;
			vector.x = acceleration.x * deltaTime;
			vector.y = acceleration.y * deltaTime;
			vector.z = acceleration.z * deltaTime;
			velocity.y = this.movement.velocity.y + vector.y;
			if (this.movement.setup.inputAirVelocityRatio == 1f)
			{
				velocity.x += vector.x;
				velocity.z += vector.z;
			}
			else if (this.movement.setup.inputAirVelocityRatio == 0f)
			{
				velocity.x = this.movement.velocity.x + vector.x;
				velocity.z = this.movement.velocity.z + vector.z;
			}
			else
			{
				float num2 = 1f - this.movement.setup.inputAirVelocityRatio;
				velocity.x = velocity.x * this.movement.setup.inputAirVelocityRatio + this.movement.velocity.x * num2 + vector.x;
				velocity.z = velocity.z * this.movement.setup.inputAirVelocityRatio + this.movement.velocity.z * num2 + vector.z;
			}
			if (-velocity.y > this.movement.setup.maxFallSpeed)
			{
				velocity.y = -this.movement.setup.maxFallSpeed;
			}
			if (this.movement.setup.maxAirHorizontalSpeed > 0f)
			{
				float num3 = velocity.x * velocity.x + velocity.z * velocity.z;
				if (num3 > this.movement.setup.maxAirHorizontalSpeed * this.movement.setup.maxAirHorizontalSpeed)
				{
					float num4 = this.movement.setup.maxAirHorizontalSpeed / global::UnityEngine.Mathf.Sqrt(num3);
					velocity.x *= num4;
					velocity.z *= num4;
				}
			}
			simulate = true;
		}
	}

	// Token: 0x060019F7 RID: 6647 RVA: 0x00065BDC File Offset: 0x00063DDC
	internal void OnBindCCMotorSettings()
	{
	}

	// Token: 0x060019F8 RID: 6648 RVA: 0x00065BE0 File Offset: 0x00063DE0
	private void OnDestroy()
	{
		try
		{
			base.OnDestroy();
		}
		finally
		{
			if (this._installed)
			{
				global::CCMotor.Callbacks.UninstallCallbacks(this, this.cc);
			}
			this.cc = null;
		}
	}

	// Token: 0x060019F9 RID: 6649 RVA: 0x00065C34 File Offset: 0x00063E34
	private void OnHit(ref global::CCDesc.Hit hit)
	{
		global::UnityEngine.Vector3 normal = hit.Normal;
		global::UnityEngine.Vector3 moveDirection = hit.MoveDirection;
		if (normal.y > 0f && normal.y > this._groundNormal.y && moveDirection.y < 0f)
		{
			global::UnityEngine.Vector3 point = hit.Point;
			global::UnityEngine.Vector3 vector;
			vector.x = point.x - this.movement.lastHitPoint.x;
			vector.y = point.y - this.movement.lastHitPoint.y;
			vector.z = point.z - this.movement.lastHitPoint.z;
			if ((this._lastGroundNormal.x == 0f && this._lastGroundNormal.y == 0f && this._lastGroundNormal.z == 0f) || vector.x * vector.x + vector.y * vector.y + vector.z * vector.z > 0.001f)
			{
				this._groundNormal = normal;
			}
			else
			{
				this._groundNormal = this._lastGroundNormal;
			}
			this.movingPlatform.hitPlatform = hit.Collider.transform;
			this.movement.hitPoint = point;
			this.movement.frameVelocity = default(global::UnityEngine.Vector3);
		}
	}

	// Token: 0x060019FA RID: 6650 RVA: 0x00065DB4 File Offset: 0x00063FB4
	private void SubtractNewPlatformVelocity()
	{
		if (this.movingPlatform.setup.enable && (this.movingPlatform.setup.movementTransfer == global::CCMotor.JumpMovementTransfer.InitTransfer || this.movingPlatform.setup.movementTransfer == global::CCMotor.JumpMovementTransfer.PermaTransfer))
		{
			if (this.movingPlatform.newPlatform)
			{
				base.StartCoroutine(this.SubtractNewPlatformVelocityLateRoutine(this.movingPlatform.activePlatform));
			}
			else
			{
				this.movement.velocity = this.movement.velocity - this.movingPlatform.platformVelocity;
			}
		}
	}

	// Token: 0x060019FB RID: 6651 RVA: 0x00065E50 File Offset: 0x00064050
	private global::System.Collections.IEnumerator SubtractNewPlatformVelocityLateRoutine(global::UnityEngine.Transform platform)
	{
		yield return new global::UnityEngine.WaitForFixedUpdate();
		yield return new global::UnityEngine.WaitForFixedUpdate();
		if (this._grounded && platform == this.movingPlatform.activePlatform)
		{
			yield return 1;
		}
		this.movement.velocity = this.movement.velocity - this.movingPlatform.platformVelocity;
		yield break;
	}

	// Token: 0x060019FC RID: 6652 RVA: 0x00065E7C File Offset: 0x0006407C
	private float CalculateJumpVerticalSpeed(float targetJumpHeight)
	{
		return global::UnityEngine.Mathf.Sqrt(2f * targetJumpHeight * this.movement.setup.gravity);
	}

	// Token: 0x060019FD RID: 6653 RVA: 0x00065E9C File Offset: 0x0006409C
	private void DoPush(global::UnityEngine.Rigidbody pusher, global::UnityEngine.Collider pusherCollider, global::UnityEngine.Collision collisionFromPusher)
	{
	}

	// Token: 0x060019FE RID: 6654 RVA: 0x00065EA0 File Offset: 0x000640A0
	public void OnPushEnter(global::UnityEngine.Rigidbody pusher, global::UnityEngine.Collider pusherCollider, global::UnityEngine.Collision collisionFromPusher)
	{
		this.DoPush(pusher, pusherCollider, collisionFromPusher);
	}

	// Token: 0x060019FF RID: 6655 RVA: 0x00065EAC File Offset: 0x000640AC
	public void OnPushStay(global::UnityEngine.Rigidbody pusher, global::UnityEngine.Collider pusherCollider, global::UnityEngine.Collision collisionFromPusher)
	{
		this.DoPush(pusher, pusherCollider, collisionFromPusher);
	}

	// Token: 0x06001A00 RID: 6656 RVA: 0x00065EB8 File Offset: 0x000640B8
	public void OnPushExit(global::UnityEngine.Rigidbody pusher, global::UnityEngine.Collider pusherCollider, global::UnityEngine.Collision collisionFromPusher)
	{
		this.DoPush(pusher, pusherCollider, collisionFromPusher);
	}

	// Token: 0x06001A01 RID: 6657 RVA: 0x00065EC4 File Offset: 0x000640C4
	private void MoveFromCollision(global::UnityEngine.Collision collision)
	{
		global::PlayerPusher component = collision.gameObject.GetComponent<global::PlayerPusher>();
		if (component)
		{
			global::UnityEngine.ContactPoint[] contacts = collision.contacts;
			global::UnityEngine.Vector3 vector = global::UnityEngine.Vector3.zero;
			global::UnityEngine.Vector3 vector2 = global::UnityEngine.Vector3.zero;
			global::UnityEngine.Vector3 vector3 = global::UnityEngine.Vector3.zero;
			for (int i = 0; i < contacts.Length; i++)
			{
				vector3 += contacts[i].point;
				vector2 += contacts[i].normal;
			}
			vector2.Normalize();
			vector3 /= (float)contacts.Length;
			global::UnityEngine.Vector3 position = this.tr.position;
			position.y = vector3.y;
			vector = vector2 * (component.rigidbody.GetPointVelocity(position).magnitude * global::UnityEngine.Time.deltaTime);
			global::UnityEngine.Vector3 position2 = this.tr.position;
			global::UnityEngine.Debug.DrawLine(position2, position2 + vector, global::UnityEngine.Color.yellow, 60f);
			this.ApplyMovementDelta(ref vector, 0f);
			global::UnityEngine.Debug.DrawLine(position2, this.tr.position, global::UnityEngine.Color.green, 60f);
			this.BindCharacter();
		}
	}

	// Token: 0x06001A02 RID: 6658 RVA: 0x00065FEC File Offset: 0x000641EC
	public void OnCollisionEnter(global::UnityEngine.Collision collision)
	{
		this.MoveFromCollision(collision);
	}

	// Token: 0x06001A03 RID: 6659 RVA: 0x00065FF8 File Offset: 0x000641F8
	public void OnCollisionStay(global::UnityEngine.Collision collision)
	{
		this.MoveFromCollision(collision);
	}

	// Token: 0x1700073C RID: 1852
	// (get) Token: 0x06001A04 RID: 6660 RVA: 0x00066004 File Offset: 0x00064204
	public global::CCMotor ccmotor
	{
		get
		{
			return this;
		}
	}

	// Token: 0x06001A05 RID: 6661 RVA: 0x00066008 File Offset: 0x00064208
	public void InitializeSetup(global::Character character, global::CCTotemPole cc, global::CharacterCCMotorTrait trait)
	{
		this.tr = base.transform;
		this.cc = cc;
		base.idMain = character;
		this.currentYaw = (this.previousYaw = 0f);
		if (trait)
		{
			if (trait.settings)
			{
				this.settings = trait.settings;
			}
			this.canControl = trait.canControl;
			this.sendLandMessage = trait.sendLandMessage;
			this.sendJumpMessage = trait.sendJumpMessage;
			this.sendJumpFailureMessage = trait.sendJumpFailureMessage;
			this.sendFallMessage = trait.sendFallMessage;
			this.sendExternalVelocityMessage = trait.sendExternalVelocityMessage;
			this.stepMode = trait.stepMode;
			this.minTimeBetweenJumps = trait.minTimeBetweenJumps;
		}
		if (!this._installed && cc)
		{
			this._installed = true;
			global::CCMotor.Callbacks.InstallCallbacks(this, cc);
		}
	}

	// Token: 0x06001A06 RID: 6662 RVA: 0x000660F4 File Offset: 0x000642F4
	private void BindPosition(ref global::CCTotem.PositionPlacement placement)
	{
		this.tr.position = placement.bottom;
		this.LastPositionPlacement = new global::CCTotem.PositionPlacement?(placement);
	}

	// Token: 0x1700073D RID: 1853
	// (get) Token: 0x06001A07 RID: 6663 RVA: 0x00066124 File Offset: 0x00064324
	public string setupString
	{
		get
		{
			return string.Format("movement={0}, jumping={1}, sliding={2}, movingPlatform={3}", new object[]
			{
				this.movement.setup,
				this.jumping.setup,
				this.sliding,
				this.movingPlatform.setup
			});
		}
	}

	// Token: 0x06001A08 RID: 6664 RVA: 0x00066188 File Offset: 0x00064388
	private void BindCharacter()
	{
		global::Character character = (global::Character)base.idMain;
		character.origin = this.tr.position;
		float num = global::UnityEngine.Mathf.DeltaAngle(this.previousYaw.Degrees, this.currentYaw.Degrees);
		if (num != 0f)
		{
			this.previousYaw = this.currentYaw;
			character.eyesYaw += num;
		}
	}

	// Token: 0x06001A09 RID: 6665 RVA: 0x000661F4 File Offset: 0x000643F4
	private void RouteMessage(string messageName)
	{
		base.idMain.SendMessage(messageName, 1);
	}

	// Token: 0x06001A0A RID: 6666 RVA: 0x00066204 File Offset: 0x00064404
	private void RouteMessage(string messageName, global::UnityEngine.SendMessageOptions sendOptions)
	{
		base.idMain.SendMessage(messageName, sendOptions);
	}

	// Token: 0x06001A0B RID: 6667 RVA: 0x00066214 File Offset: 0x00064414
	public void Teleport(global::UnityEngine.Vector3 origin)
	{
		if (this.cc)
		{
			this.cc.Teleport(origin);
		}
		else
		{
			this.tr.position = origin;
		}
	}

	// Token: 0x06001A0C RID: 6668 RVA: 0x00066244 File Offset: 0x00064444
	private void ApplyHorizontalPushVelocity(ref global::UnityEngine.Vector3 velocity)
	{
		global::CCTotemPole cctotemPole = this.cc;
		if (cctotemPole && cctotemPole.Exists)
		{
			global::CCDesc ccdesc = this.cc.totemicObject.CCDesc;
			global::Facepunch.Geometry.Capsule capsule;
			if (global::Facepunch.Geometry.ColliderUtility.GetGeometricShapeWorld(ccdesc.collider, ref capsule))
			{
				global::Facepunch.Geometry.Sphere sphere = (global::Facepunch.Geometry.Sphere)capsule;
				global::UnityEngine.Vector3 vector = velocity;
				global::Facepunch.Geometry.Vector vector2 = default(global::Facepunch.Geometry.Vector);
				bool flag = false;
				foreach (global::UnityEngine.Collider collider in global::UnityEngine.Physics.OverlapSphere(this.cc.totemicObject.CCDesc.worldCenter, this.cc.totemicObject.CCDesc.effectiveSkinnedHeight, 0x140000))
				{
					global::CCPusher component = collider.GetComponent<global::CCPusher>();
					if (component)
					{
						global::UnityEngine.Vector3 vector3 = default(global::UnityEngine.Vector3);
						if (component.Push(sphere.Transform(global::Facepunch.Geometry.ColliderUtility.WorldToCollider(collider)), ref vector3))
						{
							flag = true;
							vector2 += global::Facepunch.Geometry.ColliderUtility.ColliderToWorld(collider) * vector3;
						}
					}
				}
				if (flag)
				{
					vector2.y = 0f;
					velocity.x += vector2.x;
					velocity.z += vector2.z;
				}
			}
		}
	}

	// Token: 0x04000E9E RID: 3742
	private const float kYEpsilon = 0.001f;

	// Token: 0x04000E9F RID: 3743
	private const float kYMaxNotGrounded = 0.01f;

	// Token: 0x04000EA0 RID: 3744
	private const float kResetButtonDownTime = -100f;

	// Token: 0x04000EA1 RID: 3745
	private const float kJumpButtonDelaySeconds = 0.2f;

	// Token: 0x04000EA2 RID: 3746
	private const float kHitEpsilon = 0.001f;

	// Token: 0x04000EA3 RID: 3747
	private global::CCTotemPole cc;

	// Token: 0x04000EA4 RID: 3748
	internal global::UnityEngine.Transform tr;

	// Token: 0x04000EA5 RID: 3749
	public global::CCMotor.StepMode stepMode;

	// Token: 0x04000EA6 RID: 3750
	internal bool canControl;

	// Token: 0x04000EA7 RID: 3751
	internal bool sendFallMessage;

	// Token: 0x04000EA8 RID: 3752
	internal bool sendLandMessage;

	// Token: 0x04000EA9 RID: 3753
	internal bool sendJumpMessage;

	// Token: 0x04000EAA RID: 3754
	internal bool sendExternalVelocityMessage;

	// Token: 0x04000EAB RID: 3755
	internal bool sendJumpFailureMessage;

	// Token: 0x04000EAC RID: 3756
	private bool _grounded;

	// Token: 0x04000EAD RID: 3757
	private bool _installed;

	// Token: 0x04000EAE RID: 3758
	[global::System.NonSerialized]
	public global::CCTotem.PositionPlacement? LastPositionPlacement;

	// Token: 0x04000EAF RID: 3759
	private global::CCMotor.YawAngle currentYaw;

	// Token: 0x04000EB0 RID: 3760
	private global::CCMotor.YawAngle previousYaw;

	// Token: 0x04000EB1 RID: 3761
	public float minTimeBetweenJumps;

	// Token: 0x04000EB2 RID: 3762
	private global::UnityEngine.Vector3 _groundNormal;

	// Token: 0x04000EB3 RID: 3763
	private global::UnityEngine.Vector3 _lastGroundNormal;

	// Token: 0x04000EB4 RID: 3764
	[global::UnityEngine.SerializeField]
	private global::CCMotorSettings _settings;

	// Token: 0x04000EB5 RID: 3765
	public global::CCMotor.InputFrame input;

	// Token: 0x04000EB6 RID: 3766
	public global::CCMotor.MovementContext movement = new global::CCMotor.MovementContext(global::CCMotor.Movement.init);

	// Token: 0x04000EB7 RID: 3767
	private global::CCMotor.JumpBaseVerticalSpeedArgs jumpVerticalSpeedCalculator;

	// Token: 0x04000EB8 RID: 3768
	public global::CCMotor.JumpingContext jumping = new global::CCMotor.JumpingContext(global::CCMotor.Jumping.init);

	// Token: 0x04000EB9 RID: 3769
	public global::CCMotor.MovingPlatformContext movingPlatform = new global::CCMotor.MovingPlatformContext(global::CCMotor.MovingPlatform.init);

	// Token: 0x04000EBA RID: 3770
	public global::CCMotor.Sliding sliding;

	// Token: 0x04000EBB RID: 3771
	private global::System.Text.StringBuilder stringBuilder;

	// Token: 0x04000EBC RID: 3772
	private static bool ccmotor_debug;

	// Token: 0x020002F1 RID: 753
	public enum StepMode
	{
		// Token: 0x04000EBE RID: 3774
		ViaUpdate,
		// Token: 0x04000EBF RID: 3775
		ViaFixedUpdate,
		// Token: 0x04000EC0 RID: 3776
		Elsewhere
	}

	// Token: 0x020002F2 RID: 754
	private struct YawAngle
	{
		// Token: 0x06001A0D RID: 6669 RVA: 0x0006639C File Offset: 0x0006459C
		private YawAngle(float Degrees)
		{
			this.Degrees = Degrees;
		}

		// Token: 0x06001A0E RID: 6670 RVA: 0x000663A8 File Offset: 0x000645A8
		public global::UnityEngine.Vector3 Rotate(global::UnityEngine.Vector3 direction)
		{
			return global::UnityEngine.Quaternion.AngleAxis(this.Degrees, global::UnityEngine.Vector3.up) * direction;
		}

		// Token: 0x06001A0F RID: 6671 RVA: 0x000663C0 File Offset: 0x000645C0
		public global::UnityEngine.Vector3 Unrotate(global::UnityEngine.Vector3 direction)
		{
			return global::UnityEngine.Quaternion.AngleAxis(this.Degrees, global::UnityEngine.Vector3.down) * direction;
		}

		// Token: 0x06001A10 RID: 6672 RVA: 0x000663D8 File Offset: 0x000645D8
		public static implicit operator global::CCMotor.YawAngle(float Degrees)
		{
			return new global::CCMotor.YawAngle(Degrees);
		}

		// Token: 0x04000EC1 RID: 3777
		public readonly float Degrees;
	}

	// Token: 0x020002F3 RID: 755
	public struct InputFrame
	{
		// Token: 0x04000EC2 RID: 3778
		public global::UnityEngine.Vector3 moveDirection;

		// Token: 0x04000EC3 RID: 3779
		public bool jump;

		// Token: 0x04000EC4 RID: 3780
		public float crouchSpeed;
	}

	// Token: 0x020002F4 RID: 756
	public struct Movement
	{
		// Token: 0x1700073E RID: 1854
		// (get) Token: 0x06001A11 RID: 6673 RVA: 0x000663E0 File Offset: 0x000645E0
		public static global::CCMotor.Movement init
		{
			get
			{
				global::CCMotor.Movement result;
				result.maxForwardSpeed = 3f;
				result.maxSidewaysSpeed = 3f;
				result.maxBackwardsSpeed = 3f;
				result.maxGroundAcceleration = 30f;
				result.maxAirAcceleration = 20f;
				result.gravity = 10f;
				result.maxFallSpeed = 20f;
				result.inputAirVelocityRatio = 0.8f;
				result.maxAirHorizontalSpeed = 750f;
				result.maxUnblockingHeightDifference = 0f;
				result.slopeSpeedMultiplier = new global::UnityEngine.AnimationCurve(new global::UnityEngine.Keyframe[]
				{
					new global::UnityEngine.Keyframe(-90f, 1f),
					new global::UnityEngine.Keyframe(0f, 1f),
					new global::UnityEngine.Keyframe(90f, 0f)
				});
				return result;
			}
		}

		// Token: 0x06001A12 RID: 6674 RVA: 0x000664CC File Offset: 0x000646CC
		public override string ToString()
		{
			return string.Format("[Movement: maxForwardSpeed={0}, maxSidewaysSpeed={1}, maxBackwardsSpeed={2}, maxGroundAcceleration={3}, maxAirAcceleration={4}, inputAirVelocityRatio={5}, gravity={6}, maxFallSpeed={7}, slopeSpeedMultiplier={8}, maxAirHorizontalSpeed={9}]", new object[]
			{
				this.maxForwardSpeed,
				this.maxSidewaysSpeed,
				this.maxBackwardsSpeed,
				this.maxGroundAcceleration,
				this.maxAirAcceleration,
				this.inputAirVelocityRatio,
				this.gravity,
				this.maxFallSpeed,
				this.slopeSpeedMultiplier,
				this.maxAirHorizontalSpeed
			});
		}

		// Token: 0x04000EC5 RID: 3781
		public float maxForwardSpeed;

		// Token: 0x04000EC6 RID: 3782
		public float maxSidewaysSpeed;

		// Token: 0x04000EC7 RID: 3783
		public float maxBackwardsSpeed;

		// Token: 0x04000EC8 RID: 3784
		public float maxGroundAcceleration;

		// Token: 0x04000EC9 RID: 3785
		public float maxAirAcceleration;

		// Token: 0x04000ECA RID: 3786
		public float inputAirVelocityRatio;

		// Token: 0x04000ECB RID: 3787
		public float gravity;

		// Token: 0x04000ECC RID: 3788
		public float maxFallSpeed;

		// Token: 0x04000ECD RID: 3789
		public float maxAirHorizontalSpeed;

		// Token: 0x04000ECE RID: 3790
		public float maxUnblockingHeightDifference;

		// Token: 0x04000ECF RID: 3791
		public global::UnityEngine.AnimationCurve slopeSpeedMultiplier;
	}

	// Token: 0x020002F5 RID: 757
	public struct MovementContext
	{
		// Token: 0x06001A13 RID: 6675 RVA: 0x00066574 File Offset: 0x00064774
		public MovementContext(ref global::CCMotor.Movement setup)
		{
			this.setup = setup;
			this.collisionFlags = 0;
			this.crouchBlocked = false;
			this.acceleration = default(global::UnityEngine.Vector3);
			this.velocity = default(global::UnityEngine.Vector3);
			this.frameVelocity = default(global::UnityEngine.Vector3);
			this.hitPoint = default(global::UnityEngine.Vector3);
			this.lastHitPoint.x = float.PositiveInfinity;
			this.lastHitPoint.y = 0f;
			this.lastHitPoint.z = 0f;
		}

		// Token: 0x06001A14 RID: 6676 RVA: 0x00066608 File Offset: 0x00064808
		public MovementContext(global::CCMotor.Movement setup)
		{
			this = new global::CCMotor.MovementContext(ref setup);
		}

		// Token: 0x06001A15 RID: 6677 RVA: 0x00066614 File Offset: 0x00064814
		public static implicit operator global::CCMotor.Movement(global::CCMotor.MovementContext c)
		{
			return c.setup;
		}

		// Token: 0x04000ED0 RID: 3792
		public global::CCMotor.Movement setup;

		// Token: 0x04000ED1 RID: 3793
		public global::UnityEngine.CollisionFlags collisionFlags;

		// Token: 0x04000ED2 RID: 3794
		public bool crouchBlocked;

		// Token: 0x04000ED3 RID: 3795
		public global::UnityEngine.Vector3 acceleration;

		// Token: 0x04000ED4 RID: 3796
		public global::UnityEngine.Vector3 velocity;

		// Token: 0x04000ED5 RID: 3797
		public global::UnityEngine.Vector3 frameVelocity;

		// Token: 0x04000ED6 RID: 3798
		public global::UnityEngine.Vector3 hitPoint;

		// Token: 0x04000ED7 RID: 3799
		public global::UnityEngine.Vector3 lastHitPoint;
	}

	// Token: 0x020002F6 RID: 758
	public struct Jumping
	{
		// Token: 0x06001A16 RID: 6678 RVA: 0x00066620 File Offset: 0x00064820
		// Note: this type is marked as 'beforefieldinit'.
		static Jumping()
		{
		}

		// Token: 0x06001A17 RID: 6679 RVA: 0x00066668 File Offset: 0x00064868
		public override string ToString()
		{
			return string.Format("[Jumping: enable={0}, baseHeight={1}, extraHeight={2}, perpAmount={3}, steepPerpAmount={4}]", new object[]
			{
				this.enable,
				this.baseHeight,
				this.extraHeight,
				this.perpAmount,
				this.steepPerpAmount
			});
		}

		// Token: 0x04000ED8 RID: 3800
		public bool enable;

		// Token: 0x04000ED9 RID: 3801
		public float baseHeight;

		// Token: 0x04000EDA RID: 3802
		public float extraHeight;

		// Token: 0x04000EDB RID: 3803
		public float perpAmount;

		// Token: 0x04000EDC RID: 3804
		public float steepPerpAmount;

		// Token: 0x04000EDD RID: 3805
		public static readonly global::CCMotor.Jumping init = new global::CCMotor.Jumping
		{
			enable = true,
			baseHeight = 1f,
			extraHeight = 4.1f,
			steepPerpAmount = 0.5f
		};
	}

	// Token: 0x020002F7 RID: 759
	private struct JumpBaseVerticalSpeedArgs
	{
		// Token: 0x1700073F RID: 1855
		// (get) Token: 0x06001A18 RID: 6680 RVA: 0x000666CC File Offset: 0x000648CC
		// (set) Token: 0x06001A19 RID: 6681 RVA: 0x000666D4 File Offset: 0x000648D4
		public float baseHeight
		{
			get
			{
				return this._baseHeight;
			}
			set
			{
				if (this._baseHeight != value)
				{
					this.dirty = true;
					this._baseHeight = value;
				}
			}
		}

		// Token: 0x17000740 RID: 1856
		// (get) Token: 0x06001A1A RID: 6682 RVA: 0x000666F0 File Offset: 0x000648F0
		// (set) Token: 0x06001A1B RID: 6683 RVA: 0x000666F8 File Offset: 0x000648F8
		public float gravity
		{
			get
			{
				return this._gravity;
			}
			set
			{
				if (this._gravity != value)
				{
					this.dirty = true;
					this._gravity = value;
				}
			}
		}

		// Token: 0x06001A1C RID: 6684 RVA: 0x00066714 File Offset: 0x00064914
		public float CalculateVerticalSpeed(ref global::CCMotor.Jumping jumping, ref global::CCMotor.Movement movement)
		{
			if (this.dirty || this._baseHeight != jumping.baseHeight || this._gravity != movement.gravity)
			{
				this._baseHeight = jumping.baseHeight;
				this._gravity = movement.gravity;
				this._verticalSpeed = global::UnityEngine.Mathf.Sqrt(2f * this._baseHeight * this._gravity);
				this.dirty = false;
			}
			return this._verticalSpeed;
		}

		// Token: 0x04000EDE RID: 3806
		private float _baseHeight;

		// Token: 0x04000EDF RID: 3807
		private float _gravity;

		// Token: 0x04000EE0 RID: 3808
		private float _verticalSpeed;

		// Token: 0x04000EE1 RID: 3809
		private bool dirty;
	}

	// Token: 0x020002F8 RID: 760
	public struct JumpingContext
	{
		// Token: 0x06001A1D RID: 6685 RVA: 0x00066794 File Offset: 0x00064994
		public JumpingContext(ref global::CCMotor.Jumping setup)
		{
			this.setup = setup;
			this.jumping = false;
			this.holdingJumpButton = false;
			this.startedJumping = false;
			this.lastStartTime = 0f;
			this.lastButtonDownTime = -100f;
			this.jumpDir.x = 0f;
			this.jumpDir.y = 1f;
			this.jumpDir.z = 0f;
			this.lastLandTime = float.MinValue;
		}

		// Token: 0x06001A1E RID: 6686 RVA: 0x00066814 File Offset: 0x00064A14
		public JumpingContext(global::CCMotor.Jumping setup)
		{
			this = new global::CCMotor.JumpingContext(ref setup);
		}

		// Token: 0x06001A1F RID: 6687 RVA: 0x00066820 File Offset: 0x00064A20
		public static implicit operator global::CCMotor.Jumping(global::CCMotor.JumpingContext c)
		{
			return c.setup;
		}

		// Token: 0x04000EE2 RID: 3810
		public global::CCMotor.Jumping setup;

		// Token: 0x04000EE3 RID: 3811
		public bool jumping;

		// Token: 0x04000EE4 RID: 3812
		public bool holdingJumpButton;

		// Token: 0x04000EE5 RID: 3813
		public bool startedJumping;

		// Token: 0x04000EE6 RID: 3814
		public float lastStartTime;

		// Token: 0x04000EE7 RID: 3815
		public float lastButtonDownTime;

		// Token: 0x04000EE8 RID: 3816
		public float lastLandTime;

		// Token: 0x04000EE9 RID: 3817
		public global::UnityEngine.Vector3 jumpDir;
	}

	// Token: 0x020002F9 RID: 761
	public enum JumpMovementTransfer
	{
		// Token: 0x04000EEB RID: 3819
		None,
		// Token: 0x04000EEC RID: 3820
		InitTransfer,
		// Token: 0x04000EED RID: 3821
		PermaTransfer,
		// Token: 0x04000EEE RID: 3822
		PermaLocked
	}

	// Token: 0x020002FA RID: 762
	public struct MovingPlatform
	{
		// Token: 0x06001A20 RID: 6688 RVA: 0x0006682C File Offset: 0x00064A2C
		// Note: this type is marked as 'beforefieldinit'.
		static MovingPlatform()
		{
		}

		// Token: 0x06001A21 RID: 6689 RVA: 0x00066858 File Offset: 0x00064A58
		public override string ToString()
		{
			return string.Format("[MovingPlatform: enable={0}, movementTransfer={1}]", this.enable, this.movementTransfer);
		}

		// Token: 0x04000EEF RID: 3823
		public bool enable;

		// Token: 0x04000EF0 RID: 3824
		public global::CCMotor.JumpMovementTransfer movementTransfer;

		// Token: 0x04000EF1 RID: 3825
		public static readonly global::CCMotor.MovingPlatform init = new global::CCMotor.MovingPlatform
		{
			enable = true,
			movementTransfer = global::CCMotor.JumpMovementTransfer.PermaTransfer
		};
	}

	// Token: 0x020002FB RID: 763
	public struct MovingPlatformContext
	{
		// Token: 0x06001A22 RID: 6690 RVA: 0x00066888 File Offset: 0x00064A88
		public MovingPlatformContext(ref global::CCMotor.MovingPlatform setup)
		{
			this.setup = setup;
			this.hitPlatform = null;
			this.activePlatform = null;
			this.activeLocal = default(global::CCMotor.MovingPlatformContext.PointAndRotation);
			this.activeGlobal = default(global::CCMotor.MovingPlatformContext.PointAndRotation);
			this.lastMatrix = default(global::UnityEngine.Matrix4x4);
			this.platformVelocity = default(global::UnityEngine.Vector3);
			this.newPlatform = false;
		}

		// Token: 0x06001A23 RID: 6691 RVA: 0x000668F4 File Offset: 0x00064AF4
		public MovingPlatformContext(global::CCMotor.MovingPlatform setup)
		{
			this = new global::CCMotor.MovingPlatformContext(ref setup);
		}

		// Token: 0x06001A24 RID: 6692 RVA: 0x00066900 File Offset: 0x00064B00
		public static implicit operator global::CCMotor.MovingPlatform(global::CCMotor.MovingPlatformContext c)
		{
			return c.setup;
		}

		// Token: 0x04000EF2 RID: 3826
		public global::CCMotor.MovingPlatform setup;

		// Token: 0x04000EF3 RID: 3827
		public global::UnityEngine.Transform hitPlatform;

		// Token: 0x04000EF4 RID: 3828
		public global::UnityEngine.Transform activePlatform;

		// Token: 0x04000EF5 RID: 3829
		public global::CCMotor.MovingPlatformContext.PointAndRotation activeLocal;

		// Token: 0x04000EF6 RID: 3830
		public global::CCMotor.MovingPlatformContext.PointAndRotation activeGlobal;

		// Token: 0x04000EF7 RID: 3831
		public global::UnityEngine.Matrix4x4 lastMatrix;

		// Token: 0x04000EF8 RID: 3832
		public global::UnityEngine.Vector3 platformVelocity;

		// Token: 0x04000EF9 RID: 3833
		public bool newPlatform;

		// Token: 0x020002FC RID: 764
		public struct PointAndRotation
		{
			// Token: 0x04000EFA RID: 3834
			public global::UnityEngine.Vector3 point;

			// Token: 0x04000EFB RID: 3835
			public global::UnityEngine.Quaternion rotation;
		}
	}

	// Token: 0x020002FD RID: 765
	public struct Sliding
	{
		// Token: 0x06001A25 RID: 6693 RVA: 0x0006690C File Offset: 0x00064B0C
		// Note: this type is marked as 'beforefieldinit'.
		static Sliding()
		{
		}

		// Token: 0x06001A26 RID: 6694 RVA: 0x00066954 File Offset: 0x00064B54
		public override string ToString()
		{
			return string.Format("[Sliding enable={0}, slidingSpeed={1}, sidewaysControl={2}, speedControl={3}]", new object[]
			{
				this.enable,
				this.slidingSpeed,
				this.sidewaysControl,
				this.speedControl
			});
		}

		// Token: 0x04000EFC RID: 3836
		public bool enable;

		// Token: 0x04000EFD RID: 3837
		public float slidingSpeed;

		// Token: 0x04000EFE RID: 3838
		public float sidewaysControl;

		// Token: 0x04000EFF RID: 3839
		public float speedControl;

		// Token: 0x04000F00 RID: 3840
		public static readonly global::CCMotor.Sliding init = new global::CCMotor.Sliding
		{
			enable = true,
			slidingSpeed = 15f,
			sidewaysControl = 1f,
			speedControl = 0.4f
		};
	}

	// Token: 0x020002FE RID: 766
	private static class Callbacks
	{
		// Token: 0x06001A27 RID: 6695 RVA: 0x000669AC File Offset: 0x00064BAC
		static Callbacks()
		{
		}

		// Token: 0x06001A28 RID: 6696 RVA: 0x000669E4 File Offset: 0x00064BE4
		public static void InstallCallbacks(global::CCMotor CCMotor, global::CCTotemPole CCTotemPole)
		{
			CCTotemPole.Tag = CCMotor;
			CCTotemPole.OnBindPosition += global::CCMotor.Callbacks.PositionBinder;
			CCTotemPole.OnConfigurationBinding += global::CCMotor.Callbacks.ConfigurationBinder;
		}

		// Token: 0x06001A29 RID: 6697 RVA: 0x00066A04 File Offset: 0x00064C04
		public static void UninstallCallbacks(global::CCMotor CCMotor, global::CCTotemPole CCTotemPole)
		{
			if (CCTotemPole && object.ReferenceEquals(CCTotemPole.Tag, CCMotor))
			{
				CCTotemPole.OnConfigurationBinding -= global::CCMotor.Callbacks.ConfigurationBinder;
				CCTotemPole.OnBindPosition -= global::CCMotor.Callbacks.PositionBinder;
				CCTotemPole.Tag = null;
			}
		}

		// Token: 0x06001A2A RID: 6698 RVA: 0x00066A40 File Offset: 0x00064C40
		private static bool OnHit(global::CCDesc.HitManager HitManager, ref global::CCDesc.Hit hit)
		{
			global::CCMotor ccmotor = (global::CCMotor)HitManager.Tag;
			if (global::CCMotor.ccmotor_debug && !(hit.Collider is global::UnityEngine.TerrainCollider))
			{
				global::UnityEngine.Debug.Log(string.Format("{{\"ccmotor\":{{\"hit\":{{\"point\":[{0},{1},{2}],\"normal\":[{3},{4},{5}]}},\"dir\":[{6},{7},{8}],\"move\":{9},\"obj\":{10}}}}}", new object[]
				{
					hit.Point.x,
					hit.Point.y,
					hit.Point.z,
					hit.Normal.x,
					hit.Normal.y,
					hit.Normal.z,
					hit.MoveDirection.x,
					hit.MoveDirection.y,
					hit.MoveDirection.z,
					hit.MoveLength,
					hit.Collider
				}), hit.GameObject);
			}
			ccmotor.OnHit(ref hit);
			return true;
		}

		// Token: 0x06001A2B RID: 6699 RVA: 0x00066B7C File Offset: 0x00064D7C
		private static void OnConfigurationBinding(bool Bind, global::CCDesc CCDesc, object Tag)
		{
			global::CCHitDispatch hitDispatch = global::CCHitDispatch.GetHitDispatch(CCDesc);
			if (hitDispatch)
			{
				global::CCDesc.HitManager hits = hitDispatch.Hits;
				if (!object.ReferenceEquals(hits, null))
				{
					if (Bind)
					{
						hits.Tag = Tag;
						hits.OnHit += global::CCMotor.Callbacks.HitFilter;
					}
					else if (object.ReferenceEquals(hits.Tag, Tag))
					{
						hits.Tag = null;
						hits.OnHit -= global::CCMotor.Callbacks.HitFilter;
					}
				}
			}
			if (Bind)
			{
				CCDesc.Tag = Tag;
				if (!CCDesc.GetComponent<global::CCTotemicFigure>())
				{
					global::IDRemote idremote = CCDesc.GetComponent<global::IDRemote>();
					if (!idremote)
					{
						idremote = CCDesc.gameObject.AddComponent<global::IDRemoteDefault>();
					}
					idremote.idMain = ((global::CCMotor)Tag).idMain;
					CCDesc.detectCollisions = true;
				}
			}
			else if (object.ReferenceEquals(CCDesc.Tag, Tag))
			{
				CCDesc.Tag = null;
			}
		}

		// Token: 0x06001A2C RID: 6700 RVA: 0x00066C60 File Offset: 0x00064E60
		private static void OnBindPosition(ref global::CCTotem.PositionPlacement PositionPlacement, object Tag)
		{
			global::CCMotor ccmotor = (global::CCMotor)Tag;
			if (ccmotor)
			{
				ccmotor.BindPosition(ref PositionPlacement);
			}
		}

		// Token: 0x04000F01 RID: 3841
		public static readonly global::CCDesc.HitFilter HitFilter = new global::CCDesc.HitFilter(global::CCMotor.Callbacks.OnHit);

		// Token: 0x04000F02 RID: 3842
		public static readonly global::CCTotem.PositionBinder PositionBinder = new global::CCTotem.PositionBinder(global::CCMotor.Callbacks.OnBindPosition);

		// Token: 0x04000F03 RID: 3843
		public static readonly global::CCTotem.ConfigurationBinder ConfigurationBinder = new global::CCTotem.ConfigurationBinder(global::CCMotor.Callbacks.OnConfigurationBinding);
	}

	// Token: 0x020002FF RID: 767
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <SubtractNewPlatformVelocityLateRoutine>c__Iterator2D : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x06001A2D RID: 6701 RVA: 0x00066C88 File Offset: 0x00064E88
		public <SubtractNewPlatformVelocityLateRoutine>c__Iterator2D()
		{
		}

		// Token: 0x17000741 RID: 1857
		// (get) Token: 0x06001A2E RID: 6702 RVA: 0x00066C90 File Offset: 0x00064E90
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000742 RID: 1858
		// (get) Token: 0x06001A2F RID: 6703 RVA: 0x00066C98 File Offset: 0x00064E98
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06001A30 RID: 6704 RVA: 0x00066CA0 File Offset: 0x00064EA0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				this.$current = new global::UnityEngine.WaitForFixedUpdate();
				this.$PC = 1;
				return true;
			case 1U:
				this.$current = new global::UnityEngine.WaitForFixedUpdate();
				this.$PC = 2;
				return true;
			case 2U:
				if (this._grounded && platform == this.movingPlatform.activePlatform)
				{
					this.$current = 1;
					this.$PC = 3;
					return true;
				}
				break;
			case 3U:
				break;
			default:
				return false;
			}
			global::CCMotor ccmotor = this;
			ccmotor.movement.velocity = ccmotor.movement.velocity - this.movingPlatform.platformVelocity;
			this.$PC = -1;
			return false;
		}

		// Token: 0x06001A31 RID: 6705 RVA: 0x00066D84 File Offset: 0x00064F84
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06001A32 RID: 6706 RVA: 0x00066D90 File Offset: 0x00064F90
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04000F04 RID: 3844
		internal global::UnityEngine.Transform platform;

		// Token: 0x04000F05 RID: 3845
		internal int $PC;

		// Token: 0x04000F06 RID: 3846
		internal object $current;

		// Token: 0x04000F07 RID: 3847
		internal global::UnityEngine.Transform <$>platform;

		// Token: 0x04000F08 RID: 3848
		internal global::CCMotor <>f__this;
	}
}
