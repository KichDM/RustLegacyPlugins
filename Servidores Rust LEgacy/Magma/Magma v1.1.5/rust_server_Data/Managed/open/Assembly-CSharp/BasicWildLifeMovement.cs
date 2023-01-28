using System;
using Facepunch.Procedural;
using UnityEngine;

// Token: 0x02000553 RID: 1363
public class BasicWildLifeMovement : global::BaseAIMovement
{
	// Token: 0x06002E87 RID: 11911 RVA: 0x000B121C File Offset: 0x000AF41C
	public BasicWildLifeMovement()
	{
	}

	// Token: 0x06002E88 RID: 11912 RVA: 0x000B1248 File Offset: 0x000AF448
	public override void InitializeMovement(global::BasicWildLifeAI ai)
	{
		global::UnityEngine.Transform transform = ai.transform;
		global::UnityEngine.Vector3 forward = transform.forward;
		this.look.value.SetImmediate(ref forward);
		global::UnityEngine.BoxCollider component = base.GetComponent<global::UnityEngine.BoxCollider>();
		if (component)
		{
			this.hullLength = component.size.z * 0.5f;
		}
		this.DropToGround(transform, transform.position);
	}

	// Token: 0x06002E89 RID: 11913 RVA: 0x000B12B0 File Offset: 0x000AF4B0
	public override void SetMoveDirection(global::UnityEngine.Vector3 worldDir, float speed)
	{
		this.look.Target(ref worldDir, this.lookDegreeSpeed);
		this.desiredSpeed = speed;
	}

	// Token: 0x06002E8A RID: 11914 RVA: 0x000B12CC File Offset: 0x000AF4CC
	public new virtual void SetMovePosition(global::UnityEngine.Vector3 worldPos, float speed)
	{
		this.SetMoveDirection((worldPos - base.transform.position).normalized, speed);
	}

	// Token: 0x06002E8B RID: 11915 RVA: 0x000B12FC File Offset: 0x000AF4FC
	public override void Stop()
	{
		this.desiredSpeed = 0f;
	}

	// Token: 0x06002E8C RID: 11916 RVA: 0x000B130C File Offset: 0x000AF50C
	public override void SetMoveTarget(global::UnityEngine.GameObject target, float speed)
	{
		global::UnityEngine.Vector3 worldDir = target.transform.position - base.transform.position;
		worldDir.y = 0f;
		worldDir.Normalize();
		this.SetMoveDirection(worldDir, speed);
	}

	// Token: 0x06002E8D RID: 11917 RVA: 0x000B1350 File Offset: 0x000AF550
	public override void SetLookDirection(global::UnityEngine.Vector3 worldDir)
	{
		this.SetMoveDirection(worldDir, 0f);
	}

	// Token: 0x06002E8E RID: 11918 RVA: 0x000B1360 File Offset: 0x000AF560
	public void DropToGround(global::UnityEngine.Transform transform, global::UnityEngine.Vector3 point)
	{
		global::UnityEngine.Vector3 vector;
		global::UnityEngine.Vector3 up;
		global::TransformHelpers.GetGroundInfo(point, 300f, out vector, out up);
		global::UnityEngine.Quaternion quaternion = global::TransformHelpers.LookRotationForcedUp(this.look.value.current, up);
		this.SetTransform(transform, ref vector, ref quaternion);
	}

	// Token: 0x06002E8F RID: 11919 RVA: 0x000B13A0 File Offset: 0x000AF5A0
	private void SetTransform(global::UnityEngine.Transform transform, ref global::UnityEngine.Vector3 position, ref global::UnityEngine.Quaternion quaternion)
	{
		if (position != this.position_set || quaternion != this.rotation_set)
		{
			transform.position = (this.position_set = position);
			transform.rotation = (this.rotation_set = quaternion);
		}
	}

	// Token: 0x06002E90 RID: 11920 RVA: 0x000B1404 File Offset: 0x000AF604
	public override void DoMove(global::BasicWildLifeAI ai, ulong simMillis)
	{
		if (simMillis == 0UL)
		{
			return;
		}
		global::UnityEngine.Transform transform = ai.transform;
		double num = simMillis * 0.001;
		this.look.Advance(simMillis);
		if (this.desiredSpeed < 0.01f)
		{
			this.force_2ndstage = false;
			global::UnityEngine.Vector3 vector;
			global::UnityEngine.Vector3 vector2;
			if (!this.ground)
			{
				global::TransformHelpers.GetGroundInfo(this.position_set, 10f, out this.groundpos_set, out this.groundnormal_set);
			}
			else if (global::TransformHelpers.GetGroundInfo(this.position_set, 1f, out vector, out vector2))
			{
				this.groundpos_set = vector;
				this.groundnormal_set = vector2;
			}
			global::UnityEngine.Quaternion quaternion = global::TransformHelpers.LookRotationForcedUp(this.look.value.current, this.groundnormal_set);
			this.SetTransform(transform, ref this.groundpos_set, ref quaternion);
			this.actualMoveSpeedPerSec = this.desiredSpeed;
			return;
		}
		global::UnityEngine.Vector3 vector3 = this.position_set;
		float desiredSpeed = this.desiredSpeed;
		float num2 = (float)((double)desiredSpeed * num);
		global::UnityEngine.Vector3 vector4;
		vector4.x = vector3.x;
		vector4.y = vector3.y + this.moveCastOffset;
		vector4.z = vector3.z;
		vector4 += this.look.value.current * this.hullLength;
		global::UnityEngine.Ray ray;
		ray..ctor(vector4, this.look.value.current);
		bool flag = false;
		global::UnityEngine.RaycastHit raycastHit;
		global::UnityEngine.Vector3 vector5;
		if (!global::UnityEngine.Physics.Raycast(ray, ref raycastHit, this.collisionRadius + num2, -0x1C270005))
		{
			vector5 = vector3 + ray.direction * num2;
		}
		else
		{
			vector5 = vector3;
			flag = true;
			this.force_2ndstage = false;
		}
		if (this.ground || this.force_2ndstage || this.raypos_set != vector5)
		{
			this.ground = false;
			this.force_2ndstage = false;
			this.raypos_set = vector5;
			global::UnityEngine.Vector3 vector6;
			global::UnityEngine.Vector3 vector7;
			if (global::TransformHelpers.GetGroundInfo(vector5, 5f, out vector6, out vector7))
			{
				if (vector6 != this.movepos_set || vector7 != this.movenormal_set)
				{
					this.movepos_set = vector6;
					this.movenormal_set = vector7;
					global::UnityEngine.Quaternion quaternion2 = global::TransformHelpers.LookRotationForcedUp(this.look.value.current, this.movenormal_set);
					this.SetTransform(transform, ref vector6, ref quaternion2);
				}
			}
			else
			{
				flag = true;
				this.force_2ndstage = true;
			}
		}
		this.actualMoveSpeedPerSec = (float)((double)global::TransformHelpers.Dist2D(vector3, this.position_set) / num);
		if (flag)
		{
			ai.HitSomething();
		}
	}

	// Token: 0x06002E91 RID: 11921 RVA: 0x000B1690 File Offset: 0x000AF890
	public override float GetActualMovementSpeed()
	{
		return this.actualMoveSpeedPerSec;
	}

	// Token: 0x04001820 RID: 6176
	[global::System.NonSerialized]
	protected global::Facepunch.Procedural.Direction look;

	// Token: 0x04001821 RID: 6177
	protected float actualMoveSpeedPerSec;

	// Token: 0x04001822 RID: 6178
	public float simRate = 5f;

	// Token: 0x04001823 RID: 6179
	public float moveCastOffset = 0.25f;

	// Token: 0x04001824 RID: 6180
	private float hullLength = 0.1f;

	// Token: 0x04001825 RID: 6181
	private global::UnityEngine.Vector3 position_set;

	// Token: 0x04001826 RID: 6182
	private global::UnityEngine.Quaternion rotation_set;

	// Token: 0x04001827 RID: 6183
	private global::UnityEngine.Vector3 groundpos_set;

	// Token: 0x04001828 RID: 6184
	private global::UnityEngine.Vector3 groundnormal_set;

	// Token: 0x04001829 RID: 6185
	private global::UnityEngine.Vector3 movepos_set;

	// Token: 0x0400182A RID: 6186
	private global::UnityEngine.Vector3 movenormal_set;

	// Token: 0x0400182B RID: 6187
	private global::UnityEngine.Vector3 raypos_set;

	// Token: 0x0400182C RID: 6188
	private bool ground;

	// Token: 0x0400182D RID: 6189
	private bool force_2ndstage;
}
