using System;
using UnityEngine;

// Token: 0x0200077F RID: 1919
[global::NGCAutoAddScript]
public class MovingDoor : global::BasicDoor
{
	// Token: 0x06003FCC RID: 16332 RVA: 0x000E3B70 File Offset: 0x000E1D70
	public MovingDoor()
	{
	}

	// Token: 0x06003FCD RID: 16333 RVA: 0x000E3B9C File Offset: 0x000E1D9C
	protected void UpdateMovement(double openFraction, out global::UnityEngine.Vector3 localPosition, out global::UnityEngine.Quaternion localRotation)
	{
		if (openFraction == 0.0)
		{
			localPosition = this.originalLocalPosition;
			localRotation = this.originalLocalRotation;
			return;
		}
		if (this.smooth)
		{
			openFraction = (double)((openFraction >= 0.0) ? global::UnityEngine.Mathf.SmoothStep(0f, 1f, (float)openFraction) : global::UnityEngine.Mathf.SmoothStep(0f, -1f, (float)(-(float)openFraction)));
		}
		double num2;
		double num;
		double num3;
		if (!this.slerpMovementByDegrees || this.degrees == 0f || openFraction == 0.0 || openFraction == 1.0 || (num = global::System.Math.Sin(num2 = (double)this.degrees * 3.141592653589793 / 180.0)) == 0.0)
		{
			num3 = openFraction;
		}
		else
		{
			double num4 = global::System.Math.Sin(openFraction * num2) / num;
			num3 = num4;
		}
		global::UnityEngine.Quaternion quaternion = (openFraction != 0.0) ? global::UnityEngine.Quaternion.AngleAxis((float)((double)this.degrees * ((!this.rotationABS) ? openFraction : global::System.Math.Abs(openFraction))), this.rotationAxis) : global::UnityEngine.Quaternion.identity;
		global::UnityEngine.Vector3 vector = this.openMovement * (float)((!this.movementABS) ? num3 : global::System.Math.Abs(num3));
		global::UnityEngine.Vector3 vector2 = quaternion * -this.closedPositionPivot + this.closedPositionPivot;
		if (this.rotationFirst)
		{
			localPosition = this.originalLocalPosition + this.originalLocalRotation * (vector2 + quaternion * vector);
		}
		else
		{
			localPosition = this.originalLocalPosition + this.originalLocalRotation * (vector2 + vector);
		}
		localRotation = ((openFraction != 0.0) ? (this.originalLocalRotation * quaternion) : this.originalLocalRotation);
	}

	// Token: 0x06003FCE RID: 16334 RVA: 0x000E3DB0 File Offset: 0x000E1FB0
	protected void UpdateMovement(double openFraction)
	{
		global::UnityEngine.Vector3 localPosition;
		global::UnityEngine.Quaternion localRotation;
		this.UpdateMovement(openFraction, out localPosition, out localRotation);
		base.transform.localPosition = localPosition;
		base.transform.localRotation = localRotation;
	}

	// Token: 0x06003FCF RID: 16335 RVA: 0x000E3DE0 File Offset: 0x000E1FE0
	protected override void OnDoorFraction(double fractionOpen)
	{
		this.UpdateMovement(fractionOpen);
	}

	// Token: 0x06003FD0 RID: 16336 RVA: 0x000E3DEC File Offset: 0x000E1FEC
	protected override global::BasicDoor.IdealSide IdealSideForPoint(global::UnityEngine.Vector3 worldPoint)
	{
		float num = global::UnityEngine.Vector3.Dot(base.transform.InverseTransformPoint(worldPoint), global::UnityEngine.Vector3.Cross(this.rotationCross, this.rotationAxis));
		if (float.IsInfinity(num) || float.IsNaN(num) || global::UnityEngine.Mathf.Approximately(0f, num))
		{
			return global::BasicDoor.IdealSide.Unknown;
		}
		return (num <= 0f) ? global::BasicDoor.IdealSide.Reverse : global::BasicDoor.IdealSide.Forward;
	}

	// Token: 0x06003FD1 RID: 16337 RVA: 0x000E3E58 File Offset: 0x000E2058
	private static void DrawOpenGizmo(global::UnityEngine.Vector3 closedPositionPivot, global::UnityEngine.Vector3 rotationCross, global::UnityEngine.Vector3 rotationAxis, float degrees, global::UnityEngine.Vector3 openMovement, bool movementABS, bool rotationABS, bool rotationFirst, bool reversed)
	{
		global::UnityEngine.Color color = global::UnityEngine.Gizmos.color;
		global::UnityEngine.Vector3 vector = closedPositionPivot;
		global::UnityEngine.Vector3 vector2 = vector + rotationCross;
		bool flag = !global::UnityEngine.Mathf.Approximately(degrees, 0f);
		bool flag2 = !global::UnityEngine.Mathf.Approximately(openMovement.magnitude, 0f);
		global::UnityEngine.Quaternion quaternion = global::UnityEngine.Quaternion.identity;
		for (int i = 1; i < 0x15; i++)
		{
			float num = (float)i / 20f;
			global::UnityEngine.Quaternion quaternion2 = global::UnityEngine.Quaternion.AngleAxis(degrees * ((!reversed || rotationABS) ? num : (-num)), rotationAxis);
			global::UnityEngine.Vector3 vector3;
			if (rotationFirst)
			{
				vector3 = closedPositionPivot + quaternion2 * (openMovement * ((!reversed || movementABS) ? num : (-num)));
			}
			else
			{
				vector3 = closedPositionPivot + openMovement * ((!reversed || movementABS) ? num : (-num));
			}
			if (flag2)
			{
				global::UnityEngine.Gizmos.color = global::UnityEngine.Color.Lerp(global::UnityEngine.Color.red, (!reversed) ? global::UnityEngine.Color.green : global::UnityEngine.Color.yellow, num);
				global::UnityEngine.Gizmos.DrawLine(vector, vector3);
			}
			vector = vector3;
			global::UnityEngine.Vector3 vector4 = vector3 + quaternion2 * rotationCross;
			if (flag)
			{
				global::UnityEngine.Gizmos.color = global::UnityEngine.Color.Lerp(global::UnityEngine.Color.blue, (!reversed) ? global::UnityEngine.Color.cyan : global::UnityEngine.Color.magenta, num);
				global::UnityEngine.Gizmos.DrawLine(vector2, vector4);
			}
			vector2 = vector4;
			quaternion = quaternion2;
		}
		if (flag)
		{
			global::UnityEngine.Vector3 vector5 = closedPositionPivot + ((!rotationFirst) ? openMovement : (quaternion * openMovement));
			global::UnityEngine.Gizmos.color = new global::UnityEngine.Color(1f, (!reversed) ? 0f : 1f, 0f, 0.5f);
			global::UnityEngine.Gizmos.DrawLine(global::UnityEngine.Vector3.Lerp(vector5, vector2, 0.5f), vector2);
		}
		global::UnityEngine.Gizmos.color = color;
	}

	// Token: 0x04002134 RID: 8500
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Vector3 closedPositionPivot;

	// Token: 0x04002135 RID: 8501
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Vector3 openMovement = global::UnityEngine.Vector3.up;

	// Token: 0x04002136 RID: 8502
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Vector3 rotationAxis = global::UnityEngine.Vector3.up;

	// Token: 0x04002137 RID: 8503
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Vector3 rotationCross = global::UnityEngine.Vector3.right;

	// Token: 0x04002138 RID: 8504
	[global::UnityEngine.SerializeField]
	protected float degrees;

	// Token: 0x04002139 RID: 8505
	[global::UnityEngine.SerializeField]
	protected bool rotationFirst;

	// Token: 0x0400213A RID: 8506
	[global::UnityEngine.SerializeField]
	protected bool smooth;

	// Token: 0x0400213B RID: 8507
	[global::UnityEngine.SerializeField]
	protected bool movementABS;

	// Token: 0x0400213C RID: 8508
	[global::UnityEngine.SerializeField]
	protected bool rotationABS;

	// Token: 0x0400213D RID: 8509
	[global::UnityEngine.SerializeField]
	protected bool slerpMovementByDegrees;

	// Token: 0x0400213E RID: 8510
	private global::UnityEngine.Quaternion baseRot;
}
