using System;
using UnityEngine;

// Token: 0x02000786 RID: 1926
public class FitRequirements : global::UnityEngine.ScriptableObject
{
	// Token: 0x06004004 RID: 16388 RVA: 0x000E4AFC File Offset: 0x000E2CFC
	public FitRequirements()
	{
	}

	// Token: 0x06004005 RID: 16389 RVA: 0x000E4B04 File Offset: 0x000E2D04
	public bool Test(global::UnityEngine.Matrix4x4 placePosition)
	{
		if (!object.ReferenceEquals(this.Conditions, null))
		{
			foreach (global::FitRequirements.Condition condition in this.Conditions)
			{
				if (!condition.Check(ref placePosition))
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x06004006 RID: 16390 RVA: 0x000E4B54 File Offset: 0x000E2D54
	public bool Test(global::UnityEngine.Vector3 origin, global::UnityEngine.Quaternion rotation, global::UnityEngine.Vector3 scale)
	{
		return this.Test(global::UnityEngine.Matrix4x4.TRS(origin, rotation, scale));
	}

	// Token: 0x06004007 RID: 16391 RVA: 0x000E4B64 File Offset: 0x000E2D64
	public bool Test(global::UnityEngine.Vector3 origin, global::UnityEngine.Quaternion rotation)
	{
		return this.Test(global::UnityEngine.Matrix4x4.TRS(origin, rotation, global::UnityEngine.Vector3.one));
	}

	// Token: 0x04002159 RID: 8537
	[global::UnityEngine.SerializeField]
	private global::FitRequirements.Condition[] Conditions;

	// Token: 0x0400215A RID: 8538
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private string assetPreview;

	// Token: 0x02000787 RID: 1927
	public enum Instruction
	{
		// Token: 0x0400215C RID: 8540
		Raycast,
		// Token: 0x0400215D RID: 8541
		SphereCast,
		// Token: 0x0400215E RID: 8542
		CapsuleCast,
		// Token: 0x0400215F RID: 8543
		CheckCapsule,
		// Token: 0x04002160 RID: 8544
		CheckSphere
	}

	// Token: 0x02000788 RID: 1928
	[global::System.Serializable]
	public class Condition
	{
		// Token: 0x06004008 RID: 16392 RVA: 0x000E4B78 File Offset: 0x000E2D78
		public Condition()
		{
			this.flt0.a = 1f;
			this.flt1 = global::UnityEngine.Vector3.up;
			this.flt1.a = 0.5f;
			this.flt2 = global::UnityEngine.Vector3.up;
			this.mask = 0x20000400;
		}

		// Token: 0x17000BF7 RID: 3063
		// (get) Token: 0x06004009 RID: 16393 RVA: 0x000E4BE8 File Offset: 0x000E2DE8
		// (set) Token: 0x0600400A RID: 16394 RVA: 0x000E4BFC File Offset: 0x000E2DFC
		public global::UnityEngine.Vector3 center
		{
			get
			{
				return this.flt0;
			}
			set
			{
				this.flt0.r = value.x;
				this.flt0.g = value.y;
				this.flt0.b = value.z;
			}
		}

		// Token: 0x17000BF8 RID: 3064
		// (get) Token: 0x0600400B RID: 16395 RVA: 0x000E4C40 File Offset: 0x000E2E40
		// (set) Token: 0x0600400C RID: 16396 RVA: 0x000E4C54 File Offset: 0x000E2E54
		public global::UnityEngine.Vector3 capStart
		{
			get
			{
				return this.flt0;
			}
			set
			{
				this.flt0.r = value.x;
				this.flt0.g = value.y;
				this.flt0.b = value.z;
			}
		}

		// Token: 0x17000BF9 RID: 3065
		// (get) Token: 0x0600400D RID: 16397 RVA: 0x000E4C98 File Offset: 0x000E2E98
		// (set) Token: 0x0600400E RID: 16398 RVA: 0x000E4CA8 File Offset: 0x000E2EA8
		public float distance
		{
			get
			{
				return this.flt0.a;
			}
			set
			{
				this.flt0.a = value;
			}
		}

		// Token: 0x17000BFA RID: 3066
		// (get) Token: 0x0600400F RID: 16399 RVA: 0x000E4CB8 File Offset: 0x000E2EB8
		// (set) Token: 0x06004010 RID: 16400 RVA: 0x000E4CC8 File Offset: 0x000E2EC8
		public float radius
		{
			get
			{
				return this.flt1.a;
			}
			set
			{
				this.flt1.a = value;
			}
		}

		// Token: 0x17000BFB RID: 3067
		// (get) Token: 0x06004011 RID: 16401 RVA: 0x000E4CD8 File Offset: 0x000E2ED8
		// (set) Token: 0x06004012 RID: 16402 RVA: 0x000E4CEC File Offset: 0x000E2EEC
		public global::UnityEngine.Vector3 direction
		{
			get
			{
				return this.flt1;
			}
			set
			{
				this.flt1.r = value.x;
				this.flt1.g = value.y;
				this.flt1.b = value.z;
			}
		}

		// Token: 0x17000BFC RID: 3068
		// (get) Token: 0x06004013 RID: 16403 RVA: 0x000E4D30 File Offset: 0x000E2F30
		// (set) Token: 0x06004014 RID: 16404 RVA: 0x000E4D44 File Offset: 0x000E2F44
		public global::UnityEngine.Vector3 capEnd
		{
			get
			{
				return this.flt2;
			}
			set
			{
				this.flt2.r = value.x;
				this.flt2.g = value.y;
				this.flt2.b = value.z;
			}
		}

		// Token: 0x17000BFD RID: 3069
		// (get) Token: 0x06004015 RID: 16405 RVA: 0x000E4D88 File Offset: 0x000E2F88
		// (set) Token: 0x06004016 RID: 16406 RVA: 0x000E4D90 File Offset: 0x000E2F90
		public bool passOnFail
		{
			get
			{
				return this.failPass;
			}
			set
			{
				this.failPass = value;
			}
		}

		// Token: 0x06004017 RID: 16407 RVA: 0x000E4D9C File Offset: 0x000E2F9C
		private static void GizmoCapsuleAxis(ref global::UnityEngine.Matrix4x4 matrix, global::UnityEngine.Vector3 start, float radius, float distance, global::UnityEngine.Vector3 direction, float? unitValueRadius = null, float? unitValueHeight = null)
		{
			global::UnityEngine.Vector3 vector = matrix.MultiplyPoint3x4(start);
			global::UnityEngine.Vector3 normalized = matrix.MultiplyVector(direction).normalized;
			float? num = null;
			float value;
			if (unitValueRadius != null)
			{
				value = unitValueRadius.Value;
			}
			else
			{
				float? num2;
				num = (num2 = new float?(matrix.MultiplyVector(normalized).magnitude));
				value = num2.Value;
			}
			float num3 = value;
			float num4 = (unitValueHeight == null) ? ((num == null) ? matrix.MultiplyVector(normalized).magnitude : num.Value) : unitValueHeight.Value;
			global::UnityEngine.Matrix4x4 matrix2 = global::UnityEngine.Gizmos.matrix;
			global::UnityEngine.Gizmos.matrix = matrix2 * global::UnityEngine.Matrix4x4.TRS(vector, global::UnityEngine.Quaternion.LookRotation(normalized, matrix.MultiplyVector(global::UnityEngine.Vector3.up)), global::UnityEngine.Vector3.one);
			radius = num3 * radius;
			float num5 = num4 * (distance + radius * 2f);
			global::Gizmos2.DrawWireCapsule(new global::UnityEngine.Vector3(0f, 0f, num5 * 0.5f - radius), radius, num5, 2);
			global::UnityEngine.Gizmos.matrix = matrix2;
		}

		// Token: 0x06004018 RID: 16408 RVA: 0x000E4EB4 File Offset: 0x000E30B4
		private static void GizmoCapsulePoles(ref global::UnityEngine.Matrix4x4 matrix, global::UnityEngine.Vector3 start, float radius, global::UnityEngine.Vector3 end)
		{
			global::UnityEngine.Vector3 vector = (end - start).normalized;
			start = matrix.MultiplyPoint3x4(start);
			end = matrix.MultiplyPoint3x4(end);
			float magnitude = matrix.MultiplyVector(vector).magnitude;
			radius *= magnitude;
			vector = (end - start).normalized;
			start -= vector * radius;
			end += vector * radius;
			vector = end - start;
			global::UnityEngine.Matrix4x4 matrix2 = global::UnityEngine.Gizmos.matrix;
			global::UnityEngine.Gizmos.matrix = matrix2 * global::UnityEngine.Matrix4x4.TRS(start, global::UnityEngine.Quaternion.LookRotation(vector, matrix.MultiplyVector(global::UnityEngine.Vector3.up)), global::UnityEngine.Vector3.one);
			float magnitude2 = (end - start).magnitude;
			global::Gizmos2.DrawWireCapsule(new global::UnityEngine.Vector3(0f, 0f, magnitude2 * 0.5f), radius, magnitude2, 2);
			global::UnityEngine.Gizmos.matrix = matrix2;
		}

		// Token: 0x06004019 RID: 16409 RVA: 0x000E4F94 File Offset: 0x000E3194
		public void DrawGizmo(ref global::UnityEngine.Matrix4x4 matrix)
		{
			switch (this.instruction)
			{
			case global::FitRequirements.Instruction.Raycast:
			{
				global::UnityEngine.Vector3 vector = matrix.MultiplyPoint3x4(this.center);
				global::UnityEngine.Vector3 normalized = matrix.MultiplyVector(this.direction).normalized;
				global::UnityEngine.Gizmos.DrawLine(vector, vector + normalized * (matrix.MultiplyVector(normalized).magnitude * this.distance));
				break;
			}
			case global::FitRequirements.Instruction.SphereCast:
				global::FitRequirements.Condition.GizmoCapsuleAxis(ref matrix, this.center, this.radius, this.distance, this.direction, null, null);
				break;
			case global::FitRequirements.Instruction.CapsuleCast:
				global::FitRequirements.Condition.GizmoCapsuleAxis(ref matrix, this.capStart, this.radius, this.distance, this.direction, null, null);
				global::FitRequirements.Condition.GizmoCapsuleAxis(ref matrix, this.capEnd, this.radius, this.distance, this.direction, null, null);
				global::FitRequirements.Condition.GizmoCapsulePoles(ref matrix, this.capStart, this.radius, this.capEnd);
				break;
			case global::FitRequirements.Instruction.CheckCapsule:
				global::FitRequirements.Condition.GizmoCapsulePoles(ref matrix, this.capStart, this.radius, this.capEnd);
				break;
			case global::FitRequirements.Instruction.CheckSphere:
				global::UnityEngine.Gizmos.DrawSphere(matrix.MultiplyPoint3x4(this.center), matrix.MultiplyVector(matrix.MultiplyVector(global::UnityEngine.Vector3.one).normalized).magnitude * this.radius);
				break;
			}
		}

		// Token: 0x0600401A RID: 16410 RVA: 0x000E5134 File Offset: 0x000E3334
		public bool Check(ref global::UnityEngine.Matrix4x4 matrix)
		{
			bool flag;
			switch (this.instruction)
			{
			case global::FitRequirements.Instruction.Raycast:
			{
				global::UnityEngine.Vector3 vector;
				flag = global::UnityEngine.Physics.Raycast(matrix.MultiplyPoint3x4(this.center), vector = matrix.MultiplyVector(this.direction), matrix.MultiplyVector(vector.normalized).magnitude * this.distance, this.mask);
				break;
			}
			case global::FitRequirements.Instruction.SphereCast:
			{
				global::UnityEngine.Ray ray;
				ray..ctor(matrix.MultiplyPoint3x4(this.center), matrix.MultiplyVector(this.direction));
				float magnitude = matrix.MultiplyVector(ray.direction).magnitude;
				flag = global::UnityEngine.Physics.SphereCast(ray, magnitude * this.radius, magnitude * this.distance, this.mask);
				break;
			}
			case global::FitRequirements.Instruction.CapsuleCast:
			{
				global::UnityEngine.Vector3 vector = matrix.MultiplyVector(this.direction);
				float magnitude = matrix.MultiplyVector(vector.normalized).magnitude;
				flag = global::UnityEngine.Physics.CapsuleCast(matrix.MultiplyPoint3x4(this.capStart), matrix.MultiplyPoint3x4(this.capEnd), magnitude * this.radius, vector, magnitude * this.distance, this.mask);
				break;
			}
			case global::FitRequirements.Instruction.CheckCapsule:
				flag = global::UnityEngine.Physics.CheckCapsule(matrix.MultiplyPoint3x4(this.capStart), matrix.MultiplyPoint3x4(this.capEnd), matrix.MultiplyVector(matrix.MultiplyVector(global::UnityEngine.Vector3.one).normalized).magnitude * this.radius, this.mask);
				break;
			case global::FitRequirements.Instruction.CheckSphere:
				flag = global::UnityEngine.Physics.CheckSphere(matrix.MultiplyPoint3x4(this.center), matrix.MultiplyVector(matrix.MultiplyVector(global::UnityEngine.Vector3.one).normalized).magnitude * this.radius, this.mask);
				break;
			default:
				return true;
			}
			return flag != this.passOnFail;
		}

		// Token: 0x04002161 RID: 8545
		[global::UnityEngine.SerializeField]
		private global::FitRequirements.Instruction instruction;

		// Token: 0x04002162 RID: 8546
		[global::UnityEngine.SerializeField]
		private global::UnityEngine.Color flt0;

		// Token: 0x04002163 RID: 8547
		[global::UnityEngine.SerializeField]
		private global::UnityEngine.Color flt1;

		// Token: 0x04002164 RID: 8548
		[global::UnityEngine.SerializeField]
		private global::UnityEngine.Color flt2;

		// Token: 0x04002165 RID: 8549
		[global::UnityEngine.SerializeField]
		private global::UnityEngine.LayerMask mask;

		// Token: 0x04002166 RID: 8550
		[global::UnityEngine.SerializeField]
		private bool failPass;
	}
}
