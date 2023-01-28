using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020002E8 RID: 744
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.CharacterController))]
public sealed class CCDesc : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06001972 RID: 6514 RVA: 0x000629D8 File Offset: 0x00060BD8
	public CCDesc()
	{
		global::UnityEngine.Vector3 center = default(global::UnityEngine.Vector3);
		center.y = 1f;
		this.m_Center = center;
		base..ctor();
	}

	// Token: 0x170006F4 RID: 1780
	// (get) Token: 0x06001973 RID: 6515 RVA: 0x00062A40 File Offset: 0x00060C40
	public float height
	{
		get
		{
			return this.m_Height;
		}
	}

	// Token: 0x170006F5 RID: 1781
	// (get) Token: 0x06001974 RID: 6516 RVA: 0x00062A48 File Offset: 0x00060C48
	public float radius
	{
		get
		{
			return this.m_Radius;
		}
	}

	// Token: 0x170006F6 RID: 1782
	// (get) Token: 0x06001975 RID: 6517 RVA: 0x00062A50 File Offset: 0x00060C50
	public global::UnityEngine.Vector3 center
	{
		get
		{
			return this.m_Center;
		}
	}

	// Token: 0x170006F7 RID: 1783
	// (get) Token: 0x06001976 RID: 6518 RVA: 0x00062A58 File Offset: 0x00060C58
	public float slopeLimit
	{
		get
		{
			return this.m_SlopeLimit;
		}
	}

	// Token: 0x170006F8 RID: 1784
	// (get) Token: 0x06001977 RID: 6519 RVA: 0x00062A60 File Offset: 0x00060C60
	public float stepOffset
	{
		get
		{
			return this.m_StepOffset;
		}
	}

	// Token: 0x170006F9 RID: 1785
	// (get) Token: 0x06001978 RID: 6520 RVA: 0x00062A68 File Offset: 0x00060C68
	// (set) Token: 0x06001979 RID: 6521 RVA: 0x00062A78 File Offset: 0x00060C78
	public bool detectCollisions
	{
		get
		{
			return this.m_Collider.detectCollisions;
		}
		set
		{
			this.m_Collider.detectCollisions = value;
		}
	}

	// Token: 0x170006FA RID: 1786
	// (get) Token: 0x0600197A RID: 6522 RVA: 0x00062A88 File Offset: 0x00060C88
	public global::UnityEngine.CollisionFlags collisionFlags
	{
		get
		{
			return this.m_Collider.collisionFlags;
		}
	}

	// Token: 0x170006FB RID: 1787
	// (get) Token: 0x0600197B RID: 6523 RVA: 0x00062A98 File Offset: 0x00060C98
	public bool isGrounded
	{
		get
		{
			return this.m_Collider.isGrounded;
		}
	}

	// Token: 0x170006FC RID: 1788
	// (get) Token: 0x0600197C RID: 6524 RVA: 0x00062AA8 File Offset: 0x00060CA8
	public global::UnityEngine.Vector3 velocity
	{
		get
		{
			return this.m_Collider.velocity;
		}
	}

	// Token: 0x170006FD RID: 1789
	// (get) Token: 0x0600197D RID: 6525 RVA: 0x00062AB8 File Offset: 0x00060CB8
	public float skinWidth
	{
		get
		{
			return this.m_SkinWidth;
		}
	}

	// Token: 0x170006FE RID: 1790
	// (get) Token: 0x0600197E RID: 6526 RVA: 0x00062AC0 File Offset: 0x00060CC0
	public float minMoveDistance
	{
		get
		{
			return this.m_MinMoveDistance;
		}
	}

	// Token: 0x170006FF RID: 1791
	// (get) Token: 0x0600197F RID: 6527 RVA: 0x00062AC8 File Offset: 0x00060CC8
	public float diameter
	{
		get
		{
			return this.m_Radius + this.m_Radius;
		}
	}

	// Token: 0x17000700 RID: 1792
	// (get) Token: 0x06001980 RID: 6528 RVA: 0x00062AD8 File Offset: 0x00060CD8
	public float skinnedRadius
	{
		get
		{
			return this.m_Radius + this.m_SkinWidth;
		}
	}

	// Token: 0x17000701 RID: 1793
	// (get) Token: 0x06001981 RID: 6529 RVA: 0x00062AE8 File Offset: 0x00060CE8
	public float skinnedDiameter
	{
		get
		{
			return this.m_Radius + this.m_Radius + this.m_SkinWidth + this.m_SkinWidth;
		}
	}

	// Token: 0x17000702 RID: 1794
	// (get) Token: 0x06001982 RID: 6530 RVA: 0x00062B08 File Offset: 0x00060D08
	public float effectiveHeight
	{
		get
		{
			float num = this.m_Radius + this.m_Radius;
			return (num <= this.m_Height) ? this.m_Height : num;
		}
	}

	// Token: 0x17000703 RID: 1795
	// (get) Token: 0x06001983 RID: 6531 RVA: 0x00062B3C File Offset: 0x00060D3C
	public float effectiveSkinnedHeight
	{
		get
		{
			float num = this.m_Radius + this.m_Radius;
			return ((num <= this.m_Height) ? this.m_Height : num) + (this.m_SkinWidth + this.m_SkinWidth);
		}
	}

	// Token: 0x17000704 RID: 1796
	// (get) Token: 0x06001984 RID: 6532 RVA: 0x00062B80 File Offset: 0x00060D80
	public float skinnedHeight
	{
		get
		{
			return this.m_Height + this.m_SkinWidth + this.m_SkinWidth;
		}
	}

	// Token: 0x17000705 RID: 1797
	// (get) Token: 0x06001985 RID: 6533 RVA: 0x00062B98 File Offset: 0x00060D98
	public global::UnityEngine.Vector3 top
	{
		get
		{
			global::UnityEngine.Vector3 result;
			result.x = this.m_Center.x;
			result.z = this.m_Center.z;
			float num = this.m_Height * 0.5f;
			if (this.m_Radius > num)
			{
				num = this.m_Radius;
			}
			result.y = this.m_Center.y + num;
			return result;
		}
	}

	// Token: 0x17000706 RID: 1798
	// (get) Token: 0x06001986 RID: 6534 RVA: 0x00062C00 File Offset: 0x00060E00
	public global::UnityEngine.Vector3 skinnedTop
	{
		get
		{
			global::UnityEngine.Vector3 result;
			result.x = this.m_Center.x;
			result.z = this.m_Center.z;
			float num = this.m_Height * 0.5f;
			if (this.m_Radius > num)
			{
				num = this.m_Radius;
			}
			result.y = this.m_Center.y + num + this.m_SkinWidth;
			return result;
		}
	}

	// Token: 0x17000707 RID: 1799
	// (get) Token: 0x06001987 RID: 6535 RVA: 0x00062C70 File Offset: 0x00060E70
	public global::UnityEngine.Vector3 bottom
	{
		get
		{
			global::UnityEngine.Vector3 result;
			result.x = this.m_Center.x;
			result.z = this.m_Center.z;
			float num = this.m_Height * 0.5f;
			if (this.m_Radius > num)
			{
				num = this.m_Radius;
			}
			result.y = this.m_Center.y - num;
			return result;
		}
	}

	// Token: 0x17000708 RID: 1800
	// (get) Token: 0x06001988 RID: 6536 RVA: 0x00062CD8 File Offset: 0x00060ED8
	public global::UnityEngine.Vector3 skinnedBottom
	{
		get
		{
			global::UnityEngine.Vector3 result;
			result.x = this.m_Center.x;
			result.z = this.m_Center.z;
			float num = this.m_Height * 0.5f;
			if (this.m_Radius > num)
			{
				num = this.m_Radius;
			}
			result.y = this.m_Center.y - (num + this.m_SkinWidth);
			return result;
		}
	}

	// Token: 0x17000709 RID: 1801
	// (get) Token: 0x06001989 RID: 6537 RVA: 0x00062D48 File Offset: 0x00060F48
	public global::UnityEngine.Vector3 worldTop
	{
		get
		{
			return this.OffsetToWorld(this.top);
		}
	}

	// Token: 0x1700070A RID: 1802
	// (get) Token: 0x0600198A RID: 6538 RVA: 0x00062D58 File Offset: 0x00060F58
	public global::UnityEngine.Vector3 worldSkinnedTop
	{
		get
		{
			return this.OffsetToWorld(this.skinnedTop);
		}
	}

	// Token: 0x1700070B RID: 1803
	// (get) Token: 0x0600198B RID: 6539 RVA: 0x00062D68 File Offset: 0x00060F68
	public global::UnityEngine.Vector3 worldCenter
	{
		get
		{
			return this.OffsetToWorld(this.m_Center);
		}
	}

	// Token: 0x1700070C RID: 1804
	// (get) Token: 0x0600198C RID: 6540 RVA: 0x00062D78 File Offset: 0x00060F78
	public global::UnityEngine.Vector3 worldBottom
	{
		get
		{
			return this.OffsetToWorld(this.bottom);
		}
	}

	// Token: 0x1700070D RID: 1805
	// (get) Token: 0x0600198D RID: 6541 RVA: 0x00062D88 File Offset: 0x00060F88
	public global::UnityEngine.Vector3 worldSkinnedBottom
	{
		get
		{
			return this.OffsetToWorld(this.skinnedBottom);
		}
	}

	// Token: 0x1700070E RID: 1806
	// (get) Token: 0x0600198E RID: 6542 RVA: 0x00062D98 File Offset: 0x00060F98
	public global::UnityEngine.Vector3 centroidTop
	{
		get
		{
			global::UnityEngine.Vector3 result;
			result.x = this.m_Center.x;
			result.z = this.m_Center.z;
			float num = this.m_Height * 0.5f;
			if (this.m_Radius > num)
			{
				num = 0f;
			}
			else
			{
				num -= this.m_Radius;
			}
			result.y = this.m_Center.y + num;
			return result;
		}
	}

	// Token: 0x1700070F RID: 1807
	// (get) Token: 0x0600198F RID: 6543 RVA: 0x00062E0C File Offset: 0x0006100C
	public global::UnityEngine.Vector3 centroidBottom
	{
		get
		{
			global::UnityEngine.Vector3 result;
			result.x = this.m_Center.x;
			result.z = this.m_Center.z;
			float num = this.m_Height * 0.5f;
			if (this.m_Radius > num)
			{
				num = 0f;
			}
			else
			{
				num -= this.m_Radius;
			}
			result.y = this.m_Center.y - num;
			return result;
		}
	}

	// Token: 0x17000710 RID: 1808
	// (get) Token: 0x06001990 RID: 6544 RVA: 0x00062E80 File Offset: 0x00061080
	public global::UnityEngine.Vector3 worldCentroidTop
	{
		get
		{
			return this.OffsetToWorld(this.centroidTop);
		}
	}

	// Token: 0x17000711 RID: 1809
	// (get) Token: 0x06001991 RID: 6545 RVA: 0x00062E90 File Offset: 0x00061090
	public global::UnityEngine.Vector3 worldCentroidBottom
	{
		get
		{
			return this.OffsetToWorld(this.centroidBottom);
		}
	}

	// Token: 0x17000712 RID: 1810
	// (get) Token: 0x06001992 RID: 6546 RVA: 0x00062EA0 File Offset: 0x000610A0
	public global::UnityEngine.Quaternion flatRotation
	{
		get
		{
			global::UnityEngine.Vector3 forward = base.transform.forward;
			forward.y = forward.x * forward.x + forward.z * forward.z;
			if (global::UnityEngine.Mathf.Approximately(forward.y, 0f))
			{
				global::UnityEngine.Vector3 right = base.transform.right;
				forward.z = right.x;
				forward.x = -right.z;
				forward.y = right.x * right.x + right.z * right.z;
			}
			if (forward.y != 1f)
			{
				forward.y = 1f / global::UnityEngine.Mathf.Sqrt(forward.y);
			}
			forward.x *= forward.y;
			forward.z *= forward.z;
			forward.y = 0f;
			return global::UnityEngine.Quaternion.LookRotation(forward, global::UnityEngine.Vector3.up);
		}
	}

	// Token: 0x17000713 RID: 1811
	// (get) Token: 0x06001993 RID: 6547 RVA: 0x00062FB0 File Offset: 0x000611B0
	public static global::CCDesc Moving
	{
		get
		{
			return global::CCDesc.s_CurrentMovingCCDesc;
		}
	}

	// Token: 0x17000714 RID: 1812
	// (get) Token: 0x06001994 RID: 6548 RVA: 0x00062FB8 File Offset: 0x000611B8
	public global::UnityEngine.Rigidbody attachedRigidbody
	{
		get
		{
			return this.m_Collider.attachedRigidbody;
		}
	}

	// Token: 0x17000715 RID: 1813
	// (get) Token: 0x06001995 RID: 6549 RVA: 0x00062FC8 File Offset: 0x000611C8
	public global::UnityEngine.Bounds bounds
	{
		get
		{
			return this.m_Collider.bounds;
		}
	}

	// Token: 0x17000716 RID: 1814
	// (get) Token: 0x06001996 RID: 6550 RVA: 0x00062FD8 File Offset: 0x000611D8
	// (set) Token: 0x06001997 RID: 6551 RVA: 0x00062FE8 File Offset: 0x000611E8
	public bool enabled
	{
		get
		{
			return this.m_Collider.enabled;
		}
		set
		{
			this.m_Collider.enabled = value;
		}
	}

	// Token: 0x17000717 RID: 1815
	// (get) Token: 0x06001998 RID: 6552 RVA: 0x00062FF8 File Offset: 0x000611F8
	// (set) Token: 0x06001999 RID: 6553 RVA: 0x00063008 File Offset: 0x00061208
	public bool isTrigger
	{
		get
		{
			return this.m_Collider.isTrigger;
		}
		set
		{
			this.m_Collider.isTrigger = value;
		}
	}

	// Token: 0x17000718 RID: 1816
	// (get) Token: 0x0600199A RID: 6554 RVA: 0x00063018 File Offset: 0x00061218
	// (set) Token: 0x0600199B RID: 6555 RVA: 0x00063028 File Offset: 0x00061228
	public global::UnityEngine.PhysicMaterial material
	{
		get
		{
			return this.m_Collider.material;
		}
		set
		{
			this.m_Collider.material = value;
		}
	}

	// Token: 0x17000719 RID: 1817
	// (get) Token: 0x0600199C RID: 6556 RVA: 0x00063038 File Offset: 0x00061238
	// (set) Token: 0x0600199D RID: 6557 RVA: 0x00063048 File Offset: 0x00061248
	public global::UnityEngine.PhysicMaterial sharedMaterial
	{
		get
		{
			return this.m_Collider.sharedMaterial;
		}
		set
		{
			this.m_Collider.sharedMaterial = value;
		}
	}

	// Token: 0x1700071A RID: 1818
	// (get) Token: 0x0600199E RID: 6558 RVA: 0x00063058 File Offset: 0x00061258
	public global::UnityEngine.CharacterController collider
	{
		get
		{
			return this.m_Collider;
		}
	}

	// Token: 0x0600199F RID: 6559 RVA: 0x00063060 File Offset: 0x00061260
	public global::UnityEngine.CollisionFlags Move(global::UnityEngine.Vector3 motion)
	{
		global::CCDesc ccdesc = global::CCDesc.s_CurrentMovingCCDesc;
		global::UnityEngine.CollisionFlags result;
		try
		{
			global::CCDesc.s_CurrentMovingCCDesc = this;
			if (!object.ReferenceEquals(this.AssignedHitManager, null))
			{
				this.AssignedHitManager.Clear();
			}
			result = this.m_Collider.Move(motion);
		}
		finally
		{
			global::CCDesc.s_CurrentMovingCCDesc = ((!ccdesc) ? null : ccdesc);
		}
		return result;
	}

	// Token: 0x060019A0 RID: 6560 RVA: 0x000630E4 File Offset: 0x000612E4
	public bool SimpleMove(global::UnityEngine.Vector3 speed)
	{
		global::CCDesc ccdesc = global::CCDesc.s_CurrentMovingCCDesc;
		bool result;
		try
		{
			global::CCDesc.s_CurrentMovingCCDesc = this;
			result = this.m_Collider.SimpleMove(speed);
		}
		finally
		{
			global::CCDesc.s_CurrentMovingCCDesc = ((!ccdesc) ? null : ccdesc);
		}
		return result;
	}

	// Token: 0x060019A1 RID: 6561 RVA: 0x0006314C File Offset: 0x0006134C
	public global::UnityEngine.Vector3 ClosestPointOnBounds(global::UnityEngine.Vector3 position)
	{
		return this.m_Collider.ClosestPointOnBounds(position);
	}

	// Token: 0x060019A2 RID: 6562 RVA: 0x0006315C File Offset: 0x0006135C
	public bool Raycast(global::UnityEngine.Ray ray, out global::UnityEngine.RaycastHit hitInfo, float distance)
	{
		return this.m_Collider.Raycast(ray, ref hitInfo, distance);
	}

	// Token: 0x060019A3 RID: 6563 RVA: 0x0006316C File Offset: 0x0006136C
	public global::UnityEngine.Vector3 OffsetToWorld(global::UnityEngine.Vector3 offset)
	{
		if (offset.x != 0f || offset.z != 0f)
		{
			offset = this.flatRotation * offset;
		}
		global::UnityEngine.Vector3 lossyScale = base.transform.lossyScale;
		offset.x *= lossyScale.x;
		offset.y *= lossyScale.y;
		offset.z *= lossyScale.z;
		global::UnityEngine.Vector3 position = base.transform.position;
		offset.x += position.x;
		offset.y += position.y;
		offset.z += position.z;
		return offset;
	}

	// Token: 0x060019A4 RID: 6564 RVA: 0x00063240 File Offset: 0x00061440
	public global::CCDesc.HeightModification ModifyHeight(float newEffectiveSkinnedHeight, bool preview = false)
	{
		float num = this.m_Radius + this.m_Radius;
		float num2 = this.m_SkinWidth + this.m_SkinWidth + num;
		float num3 = (num <= this.m_Height) ? (this.m_Height + this.m_SkinWidth + this.m_SkinWidth) : num2;
		global::CCDesc.HeightModification result;
		result.original.effectiveSkinnedHeight = num3;
		result.original.center = this.m_Center;
		if (newEffectiveSkinnedHeight < num2)
		{
			result.modified.effectiveSkinnedHeight = num2;
		}
		else
		{
			result.modified.effectiveSkinnedHeight = newEffectiveSkinnedHeight;
		}
		if (result.differed = (result.original.effectiveSkinnedHeight != result.modified.effectiveSkinnedHeight))
		{
			float num4 = num3 * 0.5f;
			float num5 = result.original.center.y - num4;
			float num6 = result.original.center.y + num4;
			result.delta.effectiveSkinnedHeight = result.modified.effectiveSkinnedHeight - result.original.effectiveSkinnedHeight;
			result.scale = result.modified.effectiveSkinnedHeight / result.original.effectiveSkinnedHeight;
			float num7 = num5 * result.scale;
			float num8 = num6 * result.scale;
			result.modified.center.x = result.original.center.x;
			result.modified.center.z = result.original.center.z;
			result.modified.center.y = num7 + (num8 - num7) * 0.5f;
			result.delta.center.x = 0f;
			result.delta.center.z = 0f;
			result.delta.center.y = result.modified.center.y - result.original.center.y;
			if (result.applied = !preview)
			{
				this.m_Height = result.modified.effectiveSkinnedHeight - (this.m_SkinWidth + this.m_SkinWidth);
				this.m_Center = result.modified.center;
				if (result.scale < 1f)
				{
					this.m_Collider.center = this.m_Center;
					this.m_Collider.height = this.m_Height;
				}
				else
				{
					this.m_Collider.height = this.m_Height;
					this.m_Collider.center = this.m_Center;
				}
			}
		}
		else
		{
			result.modified = result.original;
			result.delta = default(global::CCDesc.HeightModification.State);
			result.applied = false;
			result.scale = 1f;
		}
		return result;
	}

	// Token: 0x04000E71 RID: 3697
	[global::UnityEngine.SerializeField]
	private float m_Height = 2f;

	// Token: 0x04000E72 RID: 3698
	[global::UnityEngine.SerializeField]
	private float m_Radius = 0.4f;

	// Token: 0x04000E73 RID: 3699
	[global::UnityEngine.SerializeField]
	private float m_SlopeLimit = 90f;

	// Token: 0x04000E74 RID: 3700
	[global::UnityEngine.SerializeField]
	private float m_StepOffset = 0.5f;

	// Token: 0x04000E75 RID: 3701
	[global::UnityEngine.SerializeField]
	private float m_SkinWidth = 0.05f;

	// Token: 0x04000E76 RID: 3702
	[global::UnityEngine.SerializeField]
	private float m_MinMoveDistance;

	// Token: 0x04000E77 RID: 3703
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Vector3 m_Center;

	// Token: 0x04000E78 RID: 3704
	[global::PrefetchComponent]
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.CharacterController m_Collider;

	// Token: 0x04000E79 RID: 3705
	[global::System.NonSerialized]
	public object Tag;

	// Token: 0x04000E7A RID: 3706
	private static global::CCDesc s_CurrentMovingCCDesc;

	// Token: 0x04000E7B RID: 3707
	[global::System.NonSerialized]
	internal global::CCDesc.HitManager AssignedHitManager;

	// Token: 0x020002E9 RID: 745
	public struct HeightModification
	{
		// Token: 0x1700071B RID: 1819
		// (get) Token: 0x060019A5 RID: 6565 RVA: 0x00063534 File Offset: 0x00061734
		public float bottomDeltaHeight
		{
			get
			{
				return this.modified.skinnedBottomY - this.original.skinnedBottomY;
			}
		}

		// Token: 0x1700071C RID: 1820
		// (get) Token: 0x060019A6 RID: 6566 RVA: 0x00063550 File Offset: 0x00061750
		public float topDeltaHeight
		{
			get
			{
				return this.modified.skinnedTopY - this.original.skinnedTopY;
			}
		}

		// Token: 0x04000E7C RID: 3708
		public global::CCDesc.HeightModification.State original;

		// Token: 0x04000E7D RID: 3709
		public global::CCDesc.HeightModification.State modified;

		// Token: 0x04000E7E RID: 3710
		public global::CCDesc.HeightModification.State delta;

		// Token: 0x04000E7F RID: 3711
		public float scale;

		// Token: 0x04000E80 RID: 3712
		public bool differed;

		// Token: 0x04000E81 RID: 3713
		public bool applied;

		// Token: 0x020002EA RID: 746
		public struct State
		{
			// Token: 0x1700071D RID: 1821
			// (get) Token: 0x060019A7 RID: 6567 RVA: 0x0006356C File Offset: 0x0006176C
			public float skinnedBottomY
			{
				get
				{
					return this.center.y - this.effectiveSkinnedHeight * 0.5f;
				}
			}

			// Token: 0x1700071E RID: 1822
			// (get) Token: 0x060019A8 RID: 6568 RVA: 0x00063588 File Offset: 0x00061788
			public float skinnedTopY
			{
				get
				{
					return this.center.y + this.effectiveSkinnedHeight * 0.5f;
				}
			}

			// Token: 0x04000E82 RID: 3714
			public float effectiveSkinnedHeight;

			// Token: 0x04000E83 RID: 3715
			public global::UnityEngine.Vector3 center;
		}
	}

	// Token: 0x020002EB RID: 747
	public struct Hit
	{
		// Token: 0x060019A9 RID: 6569 RVA: 0x000635A4 File Offset: 0x000617A4
		public Hit(global::UnityEngine.ControllerColliderHit ControllerColliderHit)
		{
			this.CharacterController = ControllerColliderHit.controller;
			global::CCDesc s_CurrentMovingCCDesc = global::CCDesc.s_CurrentMovingCCDesc;
			if (!s_CurrentMovingCCDesc || s_CurrentMovingCCDesc.collider != this.CharacterController)
			{
				this.CCDesc = this.CharacterController.GetComponent<global::CCDesc>();
			}
			else
			{
				this.CCDesc = s_CurrentMovingCCDesc;
			}
			this.Collider = ControllerColliderHit.collider;
			this.Point = ControllerColliderHit.point;
			this.Normal = ControllerColliderHit.normal;
			this.MoveDirection = ControllerColliderHit.moveDirection;
			this.MoveLength = ControllerColliderHit.moveLength;
		}

		// Token: 0x1700071F RID: 1823
		// (get) Token: 0x060019AA RID: 6570 RVA: 0x00063640 File Offset: 0x00061840
		public global::UnityEngine.GameObject GameObject
		{
			get
			{
				return (!this.Collider) ? null : this.Collider.transform.gameObject;
			}
		}

		// Token: 0x17000720 RID: 1824
		// (get) Token: 0x060019AB RID: 6571 RVA: 0x00063674 File Offset: 0x00061874
		public global::UnityEngine.Transform Transform
		{
			get
			{
				return (!this.Collider) ? null : this.Collider.transform;
			}
		}

		// Token: 0x17000721 RID: 1825
		// (get) Token: 0x060019AC RID: 6572 RVA: 0x00063698 File Offset: 0x00061898
		public global::UnityEngine.Rigidbody Rigidbody
		{
			get
			{
				return (!this.Collider) ? null : this.Collider.attachedRigidbody;
			}
		}

		// Token: 0x04000E84 RID: 3716
		public readonly global::UnityEngine.CharacterController CharacterController;

		// Token: 0x04000E85 RID: 3717
		public readonly global::CCDesc CCDesc;

		// Token: 0x04000E86 RID: 3718
		public readonly global::UnityEngine.Collider Collider;

		// Token: 0x04000E87 RID: 3719
		public readonly global::UnityEngine.Vector3 Point;

		// Token: 0x04000E88 RID: 3720
		public readonly global::UnityEngine.Vector3 Normal;

		// Token: 0x04000E89 RID: 3721
		public readonly global::UnityEngine.Vector3 MoveDirection;

		// Token: 0x04000E8A RID: 3722
		public readonly float MoveLength;
	}

	// Token: 0x020002EC RID: 748
	public class HitManager : global::System.IDisposable
	{
		// Token: 0x060019AD RID: 6573 RVA: 0x000636BC File Offset: 0x000618BC
		public HitManager(int bufferSize)
		{
			this.bufferSize = bufferSize;
			this.buffer = new global::CCDesc.Hit[bufferSize];
			this.filledCount = 0;
		}

		// Token: 0x060019AE RID: 6574 RVA: 0x000636EC File Offset: 0x000618EC
		public HitManager() : this(8)
		{
		}

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x060019AF RID: 6575 RVA: 0x000636F8 File Offset: 0x000618F8
		// (remove) Token: 0x060019B0 RID: 6576 RVA: 0x00063714 File Offset: 0x00061914
		public event global::CCDesc.HitFilter OnHit
		{
			[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
			add
			{
				this.OnHit = (global::CCDesc.HitFilter)global::System.Delegate.Combine(this.OnHit, value);
			}
			[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
			remove
			{
				this.OnHit = (global::CCDesc.HitFilter)global::System.Delegate.Remove(this.OnHit, value);
			}
		}

		// Token: 0x060019B1 RID: 6577 RVA: 0x00063730 File Offset: 0x00061930
		public bool Push(global::UnityEngine.ControllerColliderHit cchit)
		{
			if (this.issuingEvent)
			{
				global::UnityEngine.Debug.LogError("Push during event call back");
				return false;
			}
			if (!object.ReferenceEquals(cchit, null))
			{
				global::CCDesc.Hit hit = new global::CCDesc.Hit(cchit);
				return this.Push(ref hit);
			}
			return false;
		}

		// Token: 0x060019B2 RID: 6578 RVA: 0x00063774 File Offset: 0x00061974
		public bool Push(ref global::CCDesc.Hit evnt)
		{
			if (this.issuingEvent)
			{
				global::UnityEngine.Debug.LogError("Push during event call back");
				return false;
			}
			global::CCDesc.HitFilter onHit = this.OnHit;
			if (onHit != null)
			{
				bool flag = false;
				try
				{
					this.issuingEvent = true;
					flag = !onHit(this, ref evnt);
				}
				catch (global::System.Exception ex)
				{
					global::UnityEngine.Debug.LogException(ex);
				}
				finally
				{
					this.issuingEvent = false;
				}
				if (flag)
				{
					return false;
				}
			}
			int num = this.filledCount++;
			if (this.filledCount > this.bufferSize)
			{
				do
				{
					this.bufferSize += 8;
				}
				while (this.filledCount > this.bufferSize);
				if (this.filledCount > 1)
				{
					global::CCDesc.Hit[] sourceArray = this.buffer;
					this.buffer = new global::CCDesc.Hit[this.bufferSize];
					global::System.Array.Copy(sourceArray, this.buffer, this.filledCount - 1);
				}
				else
				{
					this.buffer = new global::CCDesc.Hit[this.bufferSize];
				}
			}
			this.buffer[num] = evnt;
			return true;
		}

		// Token: 0x060019B3 RID: 6579 RVA: 0x000638BC File Offset: 0x00061ABC
		public void Clear()
		{
			while (this.filledCount > 0)
			{
				this.buffer[--this.filledCount] = default(global::CCDesc.Hit);
			}
		}

		// Token: 0x17000722 RID: 1826
		// (get) Token: 0x060019B4 RID: 6580 RVA: 0x00063904 File Offset: 0x00061B04
		public int Count
		{
			get
			{
				return this.filledCount;
			}
		}

		// Token: 0x17000723 RID: 1827
		public global::CCDesc.Hit this[int i]
		{
			get
			{
				if (i < 0 || i >= this.filledCount)
				{
					throw new global::System.ArgumentOutOfRangeException("i");
				}
				return this.buffer[i];
			}
		}

		// Token: 0x060019B6 RID: 6582 RVA: 0x00063940 File Offset: 0x00061B40
		public void Dispose()
		{
			this.buffer = null;
			this.OnHit = null;
		}

		// Token: 0x060019B7 RID: 6583 RVA: 0x00063950 File Offset: 0x00061B50
		public void CopyTo(global::CCDesc.Hit[] array, int startIndex = 0)
		{
			for (int i = 0; i < this.filledCount; i++)
			{
				array[startIndex++] = this.buffer[i];
			}
		}

		// Token: 0x060019B8 RID: 6584 RVA: 0x00063998 File Offset: 0x00061B98
		public global::CCDesc.Hit[] ToArray()
		{
			global::CCDesc.Hit[] array = new global::CCDesc.Hit[this.filledCount];
			this.CopyTo(array, 0);
			return array;
		}

		// Token: 0x04000E8B RID: 3723
		private global::CCDesc.Hit[] buffer;

		// Token: 0x04000E8C RID: 3724
		private int bufferSize;

		// Token: 0x04000E8D RID: 3725
		private int filledCount;

		// Token: 0x04000E8E RID: 3726
		private bool issuingEvent;

		// Token: 0x04000E8F RID: 3727
		public object Tag;

		// Token: 0x04000E90 RID: 3728
		private global::CCDesc.HitFilter OnHit;
	}

	// Token: 0x020002ED RID: 749
	// (Invoke) Token: 0x060019BA RID: 6586
	public delegate bool HitFilter(global::CCDesc.HitManager hitManager, ref global::CCDesc.Hit hit);
}
