using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000223 RID: 547
public static class TransformHelpers
{
	// Token: 0x06000EB7 RID: 3767 RVA: 0x0003813C File Offset: 0x0003633C
	// Note: this type is marked as 'beforefieldinit'.
	static TransformHelpers()
	{
		global::UnityEngine.Vector2[] array = new global::UnityEngine.Vector2[4];
		int num = 0;
		global::UnityEngine.Vector2 vector = default(global::UnityEngine.Vector2);
		vector.y = -1000f;
		array[num] = vector;
		int num2 = 1;
		global::UnityEngine.Vector2 vector2 = default(global::UnityEngine.Vector2);
		vector2.x = 5f;
		vector2.y = -1000f;
		array[num2] = vector2;
		int num3 = 2;
		global::UnityEngine.Vector2 vector3 = default(global::UnityEngine.Vector2);
		vector3.x = 30f;
		vector3.y = -2000f;
		array[num3] = vector3;
		int num4 = 3;
		global::UnityEngine.Vector2 vector4 = default(global::UnityEngine.Vector2);
		vector4.x = 200f;
		vector4.y = -4000f;
		array[num4] = vector4;
		global::TransformHelpers.upHeightTests = array;
	}

	// Token: 0x06000EB8 RID: 3768 RVA: 0x000381FC File Offset: 0x000363FC
	public static void SetLocalPositionY(this global::UnityEngine.Transform transform, float y)
	{
		global::UnityEngine.Vector3 localPosition = transform.localPosition;
		localPosition.y = y;
		transform.localPosition = localPosition;
	}

	// Token: 0x06000EB9 RID: 3769 RVA: 0x00038220 File Offset: 0x00036420
	public static void SetLocalPositionX(this global::UnityEngine.Transform transform, float x)
	{
		global::UnityEngine.Vector3 localPosition = transform.localPosition;
		localPosition.x = x;
		transform.localPosition = localPosition;
	}

	// Token: 0x06000EBA RID: 3770 RVA: 0x00038244 File Offset: 0x00036444
	public static void SetLocalPositionZ(this global::UnityEngine.Transform transform, float z)
	{
		global::UnityEngine.Vector3 localPosition = transform.localPosition;
		localPosition.z = z;
		transform.localPosition = localPosition;
	}

	// Token: 0x06000EBB RID: 3771 RVA: 0x00038268 File Offset: 0x00036468
	private static global::System.Collections.Generic.IEnumerable<global::UnityEngine.Transform> IterateChildren(global::UnityEngine.Transform parent, int iChild)
	{
		global::UnityEngine.Transform child;
		for (;;)
		{
			child = parent.GetChild(iChild);
			yield return child;
			if (child.childCount > 0)
			{
				break;
			}
			if (++iChild >= parent.childCount)
			{
				goto IL_1C6;
			}
		}
		if (iChild + 1 < parent.childCount)
		{
			foreach (global::UnityEngine.Transform sibling in global::TransformHelpers.IterateChildren(parent, ++iChild))
			{
				yield return sibling;
			}
		}
		foreach (global::UnityEngine.Transform subChild in global::TransformHelpers.IterateChildren(child, 0))
		{
			yield return subChild;
		}
		IL_1C6:
		yield break;
	}

	// Token: 0x06000EBC RID: 3772 RVA: 0x000382A0 File Offset: 0x000364A0
	public static global::System.Collections.Generic.List<global::UnityEngine.Transform> ListDecendantsByDepth(this global::UnityEngine.Transform root)
	{
		return (root.childCount != 0) ? new global::System.Collections.Generic.List<global::UnityEngine.Transform>(global::TransformHelpers.IterateChildren(root, 0)) : new global::System.Collections.Generic.List<global::UnityEngine.Transform>(0);
	}

	// Token: 0x06000EBD RID: 3773 RVA: 0x000382D0 File Offset: 0x000364D0
	public static bool GetGroundInfo(this global::UnityEngine.Transform transform, out global::UnityEngine.Vector3 pos, out global::UnityEngine.Vector3 normal)
	{
		return global::TransformHelpers.GetGroundInfoNoTransform(transform.position, out pos, out normal);
	}

	// Token: 0x06000EBE RID: 3774 RVA: 0x000382E0 File Offset: 0x000364E0
	public static bool GetGroundInfoNoTransform(global::UnityEngine.Vector3 transformOrigin, out global::UnityEngine.Vector3 pos, out global::UnityEngine.Vector3 normal)
	{
		global::UnityEngine.Vector3 vector = transformOrigin;
		vector.y += 0.25f;
		global::UnityEngine.Ray ray;
		ray..ctor(vector, global::UnityEngine.Vector3.down);
		global::UnityEngine.RaycastHit raycastHit;
		if (global::UnityEngine.Physics.Raycast(ray, ref raycastHit, 1000f))
		{
			pos = raycastHit.point;
			normal = raycastHit.normal;
			return true;
		}
		pos = transformOrigin;
		normal = global::UnityEngine.Vector3.up;
		return false;
	}

	// Token: 0x06000EBF RID: 3775 RVA: 0x00038350 File Offset: 0x00036550
	public static global::UnityEngine.Quaternion GetGroundInfoRotation(global::UnityEngine.Quaternion ang, global::UnityEngine.Vector3 y)
	{
		float num = y.magnitude;
		if (global::UnityEngine.Mathf.Approximately(num, 0f))
		{
			y = global::UnityEngine.Vector3.up;
			num = 0f;
		}
		global::UnityEngine.Vector3 vector;
		global::UnityEngine.Vector3 vector2;
		vector.y = (vector.z = (vector2.x = (vector2.y = 0f)));
		vector.x = (vector2.z = num);
		vector = ang * vector;
		vector2 = ang * vector2;
		float num2 = vector2.x * y.x + vector2.y * y.y + vector2.z * y.z;
		float num3 = vector.x * y.x + vector.y * y.y + vector.z * y.z;
		if (num2 * num2 > num3 * num3)
		{
			return global::TransformHelpers.LookRotationForcedUp(vector, y);
		}
		return global::TransformHelpers.LookRotationForcedUp(vector2, y);
	}

	// Token: 0x06000EC0 RID: 3776 RVA: 0x00038454 File Offset: 0x00036654
	public static bool GetGroundInfo(global::UnityEngine.Vector3 startPos, out global::UnityEngine.Vector3 pos, out global::UnityEngine.Vector3 normal)
	{
		return global::TransformHelpers.GetGroundInfo(startPos, 100f, out pos, out normal);
	}

	// Token: 0x06000EC1 RID: 3777 RVA: 0x00038464 File Offset: 0x00036664
	public static bool GetGroundInfo(global::UnityEngine.Vector3 startPos, float range, out global::UnityEngine.Vector3 pos, out global::UnityEngine.Vector3 normal)
	{
		startPos.y += 0.25f;
		global::UnityEngine.Ray ray;
		ray..ctor(startPos, global::UnityEngine.Vector3.down);
		global::UnityEngine.RaycastHit raycastHit;
		if (global::UnityEngine.Physics.Raycast(ray, ref raycastHit, range, -0x1C270005))
		{
			pos = raycastHit.point;
			normal = raycastHit.normal;
			return true;
		}
		pos = startPos;
		normal = global::UnityEngine.Vector3.up;
		return false;
	}

	// Token: 0x06000EC2 RID: 3778 RVA: 0x000384D4 File Offset: 0x000366D4
	public static bool GetGroundInfoTerrainOnly(global::UnityEngine.Vector3 startPos, float range, out global::UnityEngine.Vector3 pos, out global::UnityEngine.Vector3 normal)
	{
		startPos.y += 0.25f;
		global::UnityEngine.Ray ray;
		ray..ctor(startPos, global::UnityEngine.Vector3.down);
		global::UnityEngine.RaycastHit raycastHit;
		if (global::UnityEngine.Physics.Raycast(ray, ref raycastHit, range + 0.25f) && raycastHit.collider is global::UnityEngine.TerrainCollider)
		{
			pos = raycastHit.point;
			normal = raycastHit.normal;
			return true;
		}
		pos = startPos;
		normal = global::UnityEngine.Vector3.up;
		return false;
	}

	// Token: 0x06000EC3 RID: 3779 RVA: 0x00038558 File Offset: 0x00036758
	private static bool GetGroundInfoNavMesh(global::UnityEngine.Vector3 startPos, out global::UnityEngine.NavMeshHit hit, float maxVariationFallback, int acceptMask)
	{
		int num = ~acceptMask;
		global::UnityEngine.Vector3 vector;
		global::UnityEngine.Vector3 vector2;
		vector.x = (vector2.x = startPos.x);
		vector.z = (vector2.z = startPos.z);
		for (int i = 0; i < global::TransformHelpers.upHeightTests.Length; i++)
		{
			vector2.y = startPos.y + global::TransformHelpers.upHeightTests[i].x;
			vector.y = startPos.y + global::TransformHelpers.upHeightTests[i].y;
			if (global::UnityEngine.NavMesh.Raycast(vector2, vector, ref hit, num))
			{
				return true;
			}
		}
		return global::UnityEngine.NavMesh.SamplePosition(startPos, ref hit, maxVariationFallback, acceptMask);
	}

	// Token: 0x06000EC4 RID: 3780 RVA: 0x00038614 File Offset: 0x00036814
	public static bool GetGroundInfoNavMesh(global::UnityEngine.Vector3 startPos, out global::UnityEngine.Vector3 pos, float maxVariationFallback, int acceptMask)
	{
		global::UnityEngine.NavMeshHit navMeshHit;
		if (global::TransformHelpers.GetGroundInfoNavMesh(startPos, out navMeshHit, maxVariationFallback, acceptMask))
		{
			pos = navMeshHit.position;
			return true;
		}
		pos = startPos;
		return false;
	}

	// Token: 0x06000EC5 RID: 3781 RVA: 0x00038648 File Offset: 0x00036848
	public static bool GetGroundInfoNavMesh(global::UnityEngine.Vector3 startPos, out global::UnityEngine.Vector3 pos, float maxVariationFallback)
	{
		return global::TransformHelpers.GetGroundInfoNavMesh(startPos, out pos, maxVariationFallback, -1);
	}

	// Token: 0x06000EC6 RID: 3782 RVA: 0x00038654 File Offset: 0x00036854
	public static bool GetGroundInfoNavMesh(global::UnityEngine.Vector3 startPos, out global::UnityEngine.Vector3 pos)
	{
		return global::TransformHelpers.GetGroundInfoNavMesh(startPos, out pos, 200f);
	}

	// Token: 0x06000EC7 RID: 3783 RVA: 0x00038664 File Offset: 0x00036864
	public static global::UnityEngine.Vector3 TestBoxCorners(global::UnityEngine.Vector3 origin, global::UnityEngine.Quaternion rotation, global::UnityEngine.Vector3 boxCenter, global::UnityEngine.Vector3 boxSize, int layerMask = 0x400, int iterations = 7)
	{
		boxSize.x = global::UnityEngine.Mathf.Abs(boxSize.x) * 0.5f;
		boxSize.y = global::UnityEngine.Mathf.Abs(boxSize.y) * 0.5f;
		boxSize.z = global::UnityEngine.Mathf.Abs(boxSize.z) * 0.5f;
		global::UnityEngine.Vector3 vector;
		global::UnityEngine.Vector3 vector2;
		vector.x = (vector2.x = boxCenter.x - boxSize.x);
		global::UnityEngine.Vector3 vector3;
		global::UnityEngine.Vector3 vector4;
		vector3.x = (vector4.x = boxCenter.x + boxSize.x);
		vector2.z = (vector4.z = boxCenter.z - boxSize.z);
		vector.z = (vector3.z = boxCenter.z + boxSize.z);
		vector.y = (vector3.y = (vector2.y = (vector4.y = boxCenter.y + boxSize.y)));
		vector = rotation * vector;
		vector2 = rotation * vector2;
		vector3 = rotation * vector3;
		vector4 = rotation * vector4;
		float magnitude = vector.magnitude;
		float magnitude2 = vector2.magnitude;
		float magnitude3 = vector3.magnitude;
		float magnitude4 = vector4.magnitude;
		float num = 1f / magnitude;
		float num2 = 1f / magnitude2;
		float num3 = 1f / magnitude3;
		float num4 = 1f / magnitude4;
		global::UnityEngine.Vector3 vector5 = vector * num;
		global::UnityEngine.Vector3 vector6 = vector2 * num2;
		global::UnityEngine.Vector3 vector7 = vector3 * num3;
		global::UnityEngine.Vector3 vector8 = vector4 * num4;
		global::UnityEngine.Vector3 vector9 = global::UnityEngine.Vector3.Lerp(global::UnityEngine.Vector3.Lerp(vector, vector4, 0.5f), global::UnityEngine.Vector3.Lerp(vector3, vector2, 0.5f), 0.5f);
		for (int i = 0; i < iterations; i++)
		{
			global::UnityEngine.Vector3 vector10 = origin + vector;
			global::UnityEngine.Vector3 vector11 = origin + vector2;
			global::UnityEngine.Vector3 vector12 = origin + vector3;
			global::UnityEngine.Vector3 vector13 = origin + vector4;
			global::UnityEngine.RaycastHit raycastHit;
			bool flag = global::UnityEngine.Physics.Raycast(vector10, -vector5, ref raycastHit, magnitude, layerMask);
			global::UnityEngine.RaycastHit raycastHit2;
			bool flag2 = global::UnityEngine.Physics.Raycast(vector11, -vector6, ref raycastHit2, magnitude2, layerMask);
			global::UnityEngine.RaycastHit raycastHit3;
			bool flag3 = global::UnityEngine.Physics.Raycast(vector12, -vector7, ref raycastHit3, magnitude3, layerMask);
			global::UnityEngine.RaycastHit raycastHit4;
			bool flag4 = global::UnityEngine.Physics.Raycast(vector13, -vector8, ref raycastHit4, magnitude4, layerMask);
			if (!flag && !flag2 && !flag3 && !flag4)
			{
				break;
			}
			global::UnityEngine.Vector3 vector14 = (!flag) ? vector : (raycastHit.point - origin);
			global::UnityEngine.Vector3 vector15 = (!flag2) ? vector2 : (raycastHit2.point - origin);
			global::UnityEngine.Vector3 vector16 = (!flag3) ? vector3 : (raycastHit3.point - origin);
			global::UnityEngine.Vector3 vector17 = (!flag4) ? vector4 : (raycastHit4.point - origin);
			global::UnityEngine.Vector3 vector18 = global::UnityEngine.Vector3.Lerp(global::UnityEngine.Vector3.Lerp(vector14, vector17, 0.5f), global::UnityEngine.Vector3.Lerp(vector16, vector15, 0.5f), 0.5f);
			global::UnityEngine.Vector3 vector19 = vector18 - vector9;
			vector19.y = 0f;
			origin += vector19 * 2.15f;
		}
		return origin;
	}

	// Token: 0x06000EC8 RID: 3784 RVA: 0x000389B0 File Offset: 0x00036BB0
	public static global::UnityEngine.Quaternion LookRotationForcedUp(global::UnityEngine.Vector3 forward, global::UnityEngine.Vector3 up)
	{
		if (forward == up)
		{
			return global::UnityEngine.Quaternion.LookRotation(up);
		}
		global::UnityEngine.Vector3 vector = global::UnityEngine.Vector3.Cross(forward, up);
		forward = global::UnityEngine.Vector3.Cross(up, vector);
		if (forward == global::UnityEngine.Vector3.zero)
		{
			forward = global::UnityEngine.Vector3.forward;
		}
		return global::UnityEngine.Quaternion.LookRotation(forward, up);
	}

	// Token: 0x06000EC9 RID: 3785 RVA: 0x00038A00 File Offset: 0x00036C00
	private static float InvSqrt(float x)
	{
		return 1f / global::UnityEngine.Mathf.Sqrt(x);
	}

	// Token: 0x06000ECA RID: 3786 RVA: 0x00038A10 File Offset: 0x00036C10
	private static float InvSqrt(float x, float y)
	{
		return 1f / global::UnityEngine.Mathf.Sqrt(x * x + y * y);
	}

	// Token: 0x06000ECB RID: 3787 RVA: 0x00038A24 File Offset: 0x00036C24
	private static float InvSqrt(float x, float y, float z)
	{
		return 1f / global::UnityEngine.Mathf.Sqrt(x * x + y * y + z * z);
	}

	// Token: 0x06000ECC RID: 3788 RVA: 0x00038A3C File Offset: 0x00036C3C
	private static float InvSqrt(float x, float y, float z, float w)
	{
		return 1f / global::UnityEngine.Mathf.Sqrt(x * x + y * y + z * z + w * w);
	}

	// Token: 0x06000ECD RID: 3789 RVA: 0x00038A58 File Offset: 0x00036C58
	public static global::UnityEngine.Quaternion LookRotationForcedUp(global::UnityEngine.Quaternion rotation, global::UnityEngine.Vector3 up)
	{
		float num = up.x * up.x + up.y * up.y + up.z * up.z;
		if (num < 1E-45f)
		{
			return rotation;
		}
		float num2 = global::TransformHelpers.InvSqrt(num);
		up.x *= num2;
		up.y *= num2;
		up.z *= num2;
		global::UnityEngine.Vector3 vector;
		vector.x = up.x;
		vector.y = up.y;
		vector.z = up.z;
		global::UnityEngine.Vector3 vector2;
		global::UnityEngine.Vector3 vector3;
		vector2.z = (vector3.x = 1f);
		vector2.y = (vector2.x = (vector3.z = (vector3.y = 0f)));
		vector2 = rotation * vector2;
		vector3 = rotation * vector3;
		float num3 = vector2.x * vector.x + vector2.y * vector.y + vector2.z * vector.z;
		float num4 = vector3.x * vector.x + vector3.y * vector.y + vector3.z * vector.z;
		global::UnityEngine.Vector3 vector4;
		global::UnityEngine.Vector3 vector5;
		if (num3 * num3 > num4 * num4)
		{
			vector4.x = vector.x;
			vector4.y = vector.y;
			vector4.z = vector.z;
			vector5.x = vector3.x;
			vector5.y = vector3.y;
			vector5.z = vector3.z;
			vector2.x = -(vector4.y * vector5.z - vector4.z * vector5.y);
			vector2.y = -(vector4.z * vector5.x - vector4.x * vector5.z);
			vector2.z = -(vector4.x * vector5.y - vector4.y * vector5.x);
			float num5 = global::TransformHelpers.InvSqrt(vector2.x, vector2.y, vector2.z);
			vector4.x = num5 * vector2.x;
			vector4.y = num5 * vector2.y;
			vector4.z = num5 * vector2.z;
		}
		else
		{
			vector4.x = vector2.x;
			vector4.y = vector2.y;
			vector4.z = vector2.z;
		}
		vector5.x = vector.x;
		vector5.y = vector.y;
		vector5.z = vector.z;
		vector3.x = vector4.y * vector5.z - vector4.z * vector5.y;
		vector3.y = vector4.z * vector5.x - vector4.x * vector5.z;
		vector3.z = vector4.x * vector5.y - vector4.y * vector5.x;
		float num6 = global::TransformHelpers.InvSqrt(vector3.x, vector3.y, vector3.z);
		vector5.x = vector3.x * num6;
		vector5.y = vector3.y * num6;
		vector5.z = vector3.z * num6;
		vector4.x = vector.x;
		vector4.y = vector.y;
		vector4.z = vector.z;
		vector2.x = vector4.y * vector5.z - vector4.z * vector5.y;
		vector2.y = vector4.z * vector5.x - vector4.x * vector5.z;
		vector2.z = vector4.x * vector5.y - vector4.y * vector5.x;
		if (vector2.x * vector2.x + vector2.y * vector2.y + vector2.z * vector2.z < 1E-45f)
		{
			return rotation;
		}
		return global::UnityEngine.Quaternion.LookRotation(vector2, up);
	}

	// Token: 0x06000ECE RID: 3790 RVA: 0x00038EE0 File Offset: 0x000370E0
	public static global::UnityEngine.Quaternion UpRotation(global::UnityEngine.Vector3 up)
	{
		float num = global::UnityEngine.Vector3.Dot(up, global::UnityEngine.Vector3.forward);
		float num2 = global::UnityEngine.Vector3.Dot(up, global::UnityEngine.Vector3.right);
		global::UnityEngine.Vector3 vector;
		if (num * num < num2 * num2)
		{
			vector = global::UnityEngine.Vector3.Cross(up, global::UnityEngine.Vector3.forward);
		}
		else
		{
			vector = global::UnityEngine.Vector3.Cross(up, global::UnityEngine.Vector3.right);
		}
		return global::UnityEngine.Quaternion.LookRotation(vector, up);
	}

	// Token: 0x06000ECF RID: 3791 RVA: 0x00038F34 File Offset: 0x00037134
	public static void DropToGround(this global::UnityEngine.Transform transform, bool useNormal)
	{
		global::UnityEngine.Vector3 position;
		global::UnityEngine.Vector3 vector;
		if (transform.GetGroundInfo(out position, out vector))
		{
			transform.position = position;
			if (useNormal)
			{
				transform.rotation = global::UnityEngine.Quaternion.LookRotation(vector);
			}
		}
	}

	// Token: 0x06000ED0 RID: 3792 RVA: 0x00038F6C File Offset: 0x0003716C
	public static float Dist2D(global::UnityEngine.Vector3 a, global::UnityEngine.Vector3 b)
	{
		global::UnityEngine.Vector2 vector;
		vector.x = b.x - a.x;
		vector.y = b.z - a.z;
		return global::UnityEngine.Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y);
	}

	// Token: 0x06000ED1 RID: 3793 RVA: 0x00038FCC File Offset: 0x000371CC
	public static bool GetIDBaseFromCollider(global::UnityEngine.Collider collider, out global::IDBase id)
	{
		if (!collider)
		{
			id = null;
			return false;
		}
		id = global::IDBase.Get(collider);
		if (id)
		{
			return true;
		}
		global::UnityEngine.Rigidbody attachedRigidbody = collider.attachedRigidbody;
		if (attachedRigidbody)
		{
			id = attachedRigidbody.GetComponent<global::IDBase>();
			return id;
		}
		return false;
	}

	// Token: 0x06000ED2 RID: 3794 RVA: 0x00039024 File Offset: 0x00037224
	public static bool GetIDMainFromCollider(global::UnityEngine.Collider collider, out global::IDMain main)
	{
		global::IDBase idbase;
		if (global::TransformHelpers.GetIDBaseFromCollider(collider, out idbase))
		{
			main = idbase.idMain;
			return main;
		}
		main = null;
		return false;
	}

	// Token: 0x0400095A RID: 2394
	private static readonly global::UnityEngine.Vector2[] upHeightTests;

	// Token: 0x02000224 RID: 548
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <IterateChildren>c__Iterator2B : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::UnityEngine.Transform>, global::System.Collections.Generic.IEnumerator<global::UnityEngine.Transform>
	{
		// Token: 0x06000ED3 RID: 3795 RVA: 0x00039054 File Offset: 0x00037254
		public <IterateChildren>c__Iterator2B()
		{
		}

		// Token: 0x17000380 RID: 896
		// (get) Token: 0x06000ED4 RID: 3796 RVA: 0x0003905C File Offset: 0x0003725C
		global::UnityEngine.Transform global::System.Collections.Generic.IEnumerator<global::UnityEngine.Transform>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000381 RID: 897
		// (get) Token: 0x06000ED5 RID: 3797 RVA: 0x00039064 File Offset: 0x00037264
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000ED6 RID: 3798 RVA: 0x0003906C File Offset: 0x0003726C
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<UnityEngine.Transform>.GetEnumerator();
		}

		// Token: 0x06000ED7 RID: 3799 RVA: 0x00039074 File Offset: 0x00037274
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::UnityEngine.Transform> global::System.Collections.Generic.IEnumerable<global::UnityEngine.Transform>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::TransformHelpers.<IterateChildren>c__Iterator2B <IterateChildren>c__Iterator2B = new global::TransformHelpers.<IterateChildren>c__Iterator2B();
			<IterateChildren>c__Iterator2B.parent = parent;
			<IterateChildren>c__Iterator2B.iChild = iChild;
			return <IterateChildren>c__Iterator2B;
		}

		// Token: 0x06000ED8 RID: 3800 RVA: 0x000390B4 File Offset: 0x000372B4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0U:
				break;
			case 1U:
				if (child.childCount <= 0)
				{
					if (++iChild >= parent.childCount)
					{
						goto IL_1C6;
					}
				}
				else
				{
					if (iChild + 1 < parent.childCount)
					{
						enumerator = global::TransformHelpers.IterateChildren(parent, ++iChild).GetEnumerator();
						num = 0xFFFFFFFDU;
						goto Block_4;
					}
					goto IL_11C;
				}
				break;
			case 2U:
				goto IL_B2;
			case 3U:
				Block_5:
				try
				{
					switch (num)
					{
					}
					if (enumerator2.MoveNext())
					{
						subChild = enumerator2.Current;
						this.$current = subChild;
						this.$PC = 3;
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if (enumerator2 != null)
						{
							enumerator2.Dispose();
						}
					}
				}
				goto IL_1C6;
			default:
				return false;
			}
			child = parent.GetChild(iChild);
			this.$current = child;
			this.$PC = 1;
			return true;
			Block_4:
			try
			{
				IL_B2:
				switch (num)
				{
				}
				if (enumerator.MoveNext())
				{
					sibling = enumerator.Current;
					this.$current = sibling;
					this.$PC = 2;
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
			}
			IL_11C:
			enumerator2 = global::TransformHelpers.IterateChildren(child, 0).GetEnumerator();
			num = 0xFFFFFFFDU;
			goto Block_5;
			IL_1C6:
			this.$PC = -1;
			return false;
		}

		// Token: 0x06000ED9 RID: 3801 RVA: 0x000392C8 File Offset: 0x000374C8
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 2U:
				try
				{
				}
				finally
				{
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
				break;
			case 3U:
				try
				{
				}
				finally
				{
					if (enumerator2 != null)
					{
						enumerator2.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06000EDA RID: 3802 RVA: 0x0003936C File Offset: 0x0003756C
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x0400095B RID: 2395
		internal global::UnityEngine.Transform parent;

		// Token: 0x0400095C RID: 2396
		internal int iChild;

		// Token: 0x0400095D RID: 2397
		internal global::UnityEngine.Transform <child>__0;

		// Token: 0x0400095E RID: 2398
		internal global::System.Collections.Generic.IEnumerator<global::UnityEngine.Transform> <$s_261>__1;

		// Token: 0x0400095F RID: 2399
		internal global::UnityEngine.Transform <sibling>__2;

		// Token: 0x04000960 RID: 2400
		internal global::System.Collections.Generic.IEnumerator<global::UnityEngine.Transform> <$s_262>__3;

		// Token: 0x04000961 RID: 2401
		internal global::UnityEngine.Transform <subChild>__4;

		// Token: 0x04000962 RID: 2402
		internal int $PC;

		// Token: 0x04000963 RID: 2403
		internal global::UnityEngine.Transform $current;

		// Token: 0x04000964 RID: 2404
		internal global::UnityEngine.Transform <$>parent;

		// Token: 0x04000965 RID: 2405
		internal int <$>iChild;
	}
}
