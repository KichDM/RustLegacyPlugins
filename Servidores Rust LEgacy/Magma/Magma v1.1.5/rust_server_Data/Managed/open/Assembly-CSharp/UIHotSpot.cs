using System;
using UnityEngine;

// Token: 0x020008A5 RID: 2213
public class UIHotSpot : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004C71 RID: 19569 RVA: 0x00120FA8 File Offset: 0x0011F1A8
	protected UIHotSpot(global::UIHotSpot.Kind kind, bool configuredInLocalSpace)
	{
		this.kind = kind;
		this.configuredInLocalSpace = configuredInLocalSpace;
	}

	// Token: 0x06004C72 RID: 19570 RVA: 0x00120FC8 File Offset: 0x0011F1C8
	// Note: this type is marked as 'beforefieldinit'.
	static UIHotSpot()
	{
	}

	// Token: 0x17000E35 RID: 3637
	// (get) Token: 0x06004C73 RID: 19571 RVA: 0x00120FE0 File Offset: 0x0011F1E0
	protected static global::UnityEngine.Vector3 forward
	{
		get
		{
			global::UnityEngine.Vector3 result;
			result.x = 0f;
			result.y = 0f;
			result.z = -1f;
			return result;
		}
	}

	// Token: 0x17000E36 RID: 3638
	// (get) Token: 0x06004C74 RID: 19572 RVA: 0x00121014 File Offset: 0x0011F214
	protected static global::UnityEngine.Vector3 backward
	{
		get
		{
			global::UnityEngine.Vector3 result;
			result.x = 0f;
			result.y = 0f;
			result.z = 1f;
			return result;
		}
	}

	// Token: 0x06004C75 RID: 19573 RVA: 0x00121048 File Offset: 0x0011F248
	public static void ConvertRaycastHit(ref global::UnityEngine.Ray ray, ref global::UnityEngine.RaycastHit raycastHit, out global::UIHotSpot.Hit hit)
	{
		hit.collider = raycastHit.collider;
		hit.hotSpot = hit.collider.GetComponent<global::UIHotSpot>();
		hit.isCollider = !hit.hotSpot;
		if (hit.isCollider)
		{
			hit.panel = global::UIPanel.Find(hit.collider.transform);
		}
		else
		{
			hit.panel = ((!hit.hotSpot.panel) ? global::UIPanel.Find(hit.collider.transform) : hit.hotSpot.panel);
		}
		hit.ray = ray;
		hit.distance = raycastHit.distance;
		hit.point = raycastHit.point;
		hit.normal = raycastHit.normal;
	}

	// Token: 0x17000E37 RID: 3639
	// (get) Token: 0x06004C76 RID: 19574 RVA: 0x00121118 File Offset: 0x0011F318
	public global::UIPanel uipanel
	{
		get
		{
			return this.panel;
		}
	}

	// Token: 0x17000E38 RID: 3640
	// (get) Token: 0x06004C77 RID: 19575 RVA: 0x00121120 File Offset: 0x0011F320
	private global::UICircleHotSpot circleUS
	{
		get
		{
			return (global::UICircleHotSpot)this;
		}
	}

	// Token: 0x17000E39 RID: 3641
	// (get) Token: 0x06004C78 RID: 19576 RVA: 0x00121128 File Offset: 0x0011F328
	private global::UIRectHotSpot rectUS
	{
		get
		{
			return (global::UIRectHotSpot)this;
		}
	}

	// Token: 0x17000E3A RID: 3642
	// (get) Token: 0x06004C79 RID: 19577 RVA: 0x00121130 File Offset: 0x0011F330
	private global::UIConvexHotSpot convexUS
	{
		get
		{
			return (global::UIConvexHotSpot)this;
		}
	}

	// Token: 0x17000E3B RID: 3643
	// (get) Token: 0x06004C7A RID: 19578 RVA: 0x00121138 File Offset: 0x0011F338
	private global::UISphereHotSpot sphereUS
	{
		get
		{
			return (global::UISphereHotSpot)this;
		}
	}

	// Token: 0x17000E3C RID: 3644
	// (get) Token: 0x06004C7B RID: 19579 RVA: 0x00121140 File Offset: 0x0011F340
	private global::UIBoxHotSpot boxUS
	{
		get
		{
			return (global::UIBoxHotSpot)this;
		}
	}

	// Token: 0x17000E3D RID: 3645
	// (get) Token: 0x06004C7C RID: 19580 RVA: 0x00121148 File Offset: 0x0011F348
	private global::UIBrushHotSpot brushUS
	{
		get
		{
			return (global::UIBrushHotSpot)this;
		}
	}

	// Token: 0x17000E3E RID: 3646
	// (get) Token: 0x06004C7D RID: 19581 RVA: 0x00121150 File Offset: 0x0011F350
	public global::UICircleHotSpot asCircle
	{
		get
		{
			return (this.kind != global::UIHotSpot.Kind.Circle) ? null : ((global::UICircleHotSpot)this);
		}
	}

	// Token: 0x17000E3F RID: 3647
	// (get) Token: 0x06004C7E RID: 19582 RVA: 0x0012116C File Offset: 0x0011F36C
	public global::UIRectHotSpot asRect
	{
		get
		{
			return (this.kind != global::UIHotSpot.Kind.Rect) ? null : ((global::UIRectHotSpot)this);
		}
	}

	// Token: 0x17000E40 RID: 3648
	// (get) Token: 0x06004C7F RID: 19583 RVA: 0x00121188 File Offset: 0x0011F388
	public global::UIConvexHotSpot asConvex
	{
		get
		{
			return (this.kind != global::UIHotSpot.Kind.Convex) ? null : ((global::UIConvexHotSpot)this);
		}
	}

	// Token: 0x17000E41 RID: 3649
	// (get) Token: 0x06004C80 RID: 19584 RVA: 0x001211A4 File Offset: 0x0011F3A4
	public global::UISphereHotSpot asSphere
	{
		get
		{
			return (this.kind != global::UIHotSpot.Kind.Sphere) ? null : ((global::UISphereHotSpot)this);
		}
	}

	// Token: 0x17000E42 RID: 3650
	// (get) Token: 0x06004C81 RID: 19585 RVA: 0x001211C4 File Offset: 0x0011F3C4
	public global::UIBoxHotSpot asBox
	{
		get
		{
			return (this.kind != global::UIHotSpot.Kind.Box) ? null : ((global::UIBoxHotSpot)this);
		}
	}

	// Token: 0x17000E43 RID: 3651
	// (get) Token: 0x06004C82 RID: 19586 RVA: 0x001211E4 File Offset: 0x0011F3E4
	public global::UIBrushHotSpot asBrush
	{
		get
		{
			return (this.kind != global::UIHotSpot.Kind.Brush) ? null : ((global::UIBrushHotSpot)this);
		}
	}

	// Token: 0x17000E44 RID: 3652
	// (get) Token: 0x06004C83 RID: 19587 RVA: 0x00121204 File Offset: 0x0011F404
	public bool isCircle
	{
		get
		{
			return this.kind == global::UIHotSpot.Kind.Circle;
		}
	}

	// Token: 0x17000E45 RID: 3653
	// (get) Token: 0x06004C84 RID: 19588 RVA: 0x00121210 File Offset: 0x0011F410
	public bool isRect
	{
		get
		{
			return this.kind == global::UIHotSpot.Kind.Rect;
		}
	}

	// Token: 0x17000E46 RID: 3654
	// (get) Token: 0x06004C85 RID: 19589 RVA: 0x0012121C File Offset: 0x0011F41C
	public bool isConvex
	{
		get
		{
			return this.kind == global::UIHotSpot.Kind.Convex;
		}
	}

	// Token: 0x17000E47 RID: 3655
	// (get) Token: 0x06004C86 RID: 19590 RVA: 0x00121228 File Offset: 0x0011F428
	public bool isSphere
	{
		get
		{
			return this.kind == global::UIHotSpot.Kind.Sphere;
		}
	}

	// Token: 0x17000E48 RID: 3656
	// (get) Token: 0x06004C87 RID: 19591 RVA: 0x00121238 File Offset: 0x0011F438
	public bool isBox
	{
		get
		{
			return this.kind == global::UIHotSpot.Kind.Box;
		}
	}

	// Token: 0x17000E49 RID: 3657
	// (get) Token: 0x06004C88 RID: 19592 RVA: 0x00121248 File Offset: 0x0011F448
	public bool isBrush
	{
		get
		{
			return this.kind == global::UIHotSpot.Kind.Brush;
		}
	}

	// Token: 0x06004C89 RID: 19593 RVA: 0x00121258 File Offset: 0x0011F458
	public bool As(out global::UICircleHotSpot cast)
	{
		if (this.kind == global::UIHotSpot.Kind.Circle)
		{
			cast = (global::UICircleHotSpot)this;
			return true;
		}
		cast = null;
		return false;
	}

	// Token: 0x06004C8A RID: 19594 RVA: 0x00121274 File Offset: 0x0011F474
	public bool As(out global::UIRectHotSpot cast)
	{
		if (this.kind == global::UIHotSpot.Kind.Rect)
		{
			cast = (global::UIRectHotSpot)this;
			return true;
		}
		cast = null;
		return false;
	}

	// Token: 0x06004C8B RID: 19595 RVA: 0x00121290 File Offset: 0x0011F490
	public bool As(out global::UIConvexHotSpot cast)
	{
		if (this.kind == global::UIHotSpot.Kind.Convex)
		{
			cast = (global::UIConvexHotSpot)this;
			return true;
		}
		cast = null;
		return false;
	}

	// Token: 0x06004C8C RID: 19596 RVA: 0x001212AC File Offset: 0x0011F4AC
	public bool As(out global::UISphereHotSpot cast)
	{
		if (this.kind == global::UIHotSpot.Kind.Sphere)
		{
			cast = (global::UISphereHotSpot)this;
			return true;
		}
		cast = null;
		return false;
	}

	// Token: 0x06004C8D RID: 19597 RVA: 0x001212CC File Offset: 0x0011F4CC
	public bool As(out global::UIBoxHotSpot cast)
	{
		if (this.kind == global::UIHotSpot.Kind.Box)
		{
			cast = (global::UIBoxHotSpot)this;
			return true;
		}
		cast = null;
		return false;
	}

	// Token: 0x06004C8E RID: 19598 RVA: 0x001212EC File Offset: 0x0011F4EC
	public bool As(out global::UIBrushHotSpot cast)
	{
		if (this.kind == global::UIHotSpot.Kind.Brush)
		{
			cast = (global::UIBrushHotSpot)this;
			return true;
		}
		cast = null;
		return false;
	}

	// Token: 0x06004C8F RID: 19599 RVA: 0x0012130C File Offset: 0x0011F50C
	private bool EnableHotSpot()
	{
		return global::UIHotSpot.Global.Add(this);
	}

	// Token: 0x06004C90 RID: 19600 RVA: 0x00121314 File Offset: 0x0011F514
	private bool DisableHotSpot()
	{
		return global::UIHotSpot.Global.Remove(this);
	}

	// Token: 0x06004C91 RID: 19601 RVA: 0x0012131C File Offset: 0x0011F51C
	private void Start()
	{
		this.panel = global::UIPanel.Find(base.transform);
		if (this.panel)
		{
			global::UIPanel.RegisterHotSpot(this.panel, this);
		}
		else
		{
			global::UnityEngine.Debug.LogWarning("Did not find panel!", this);
		}
	}

	// Token: 0x06004C92 RID: 19602 RVA: 0x0012135C File Offset: 0x0011F55C
	private void OnDestroy()
	{
		if (this.panel)
		{
			global::UIPanel uipanel = this.panel;
			this.panel = null;
			global::UIPanel.UnregisterHotSpot(uipanel, this);
		}
	}

	// Token: 0x06004C93 RID: 19603 RVA: 0x00121390 File Offset: 0x0011F590
	protected void OnEnable()
	{
		if (this.panel && this.panel.enabled)
		{
			this.EnableHotSpot();
		}
	}

	// Token: 0x06004C94 RID: 19604 RVA: 0x001213BC File Offset: 0x0011F5BC
	protected void OnDisable()
	{
		if (this.once)
		{
			this.DisableHotSpot();
		}
	}

	// Token: 0x06004C95 RID: 19605 RVA: 0x001213D0 File Offset: 0x0011F5D0
	internal void OnPanelEnable()
	{
		if (base.enabled)
		{
			this.EnableHotSpot();
		}
	}

	// Token: 0x06004C96 RID: 19606 RVA: 0x001213E4 File Offset: 0x0011F5E4
	internal void OnPanelDisable()
	{
		if (base.enabled)
		{
			this.DisableHotSpot();
		}
	}

	// Token: 0x06004C97 RID: 19607 RVA: 0x001213F8 File Offset: 0x0011F5F8
	internal void OnPanelDestroy()
	{
		global::UIPanel uipanel = this.panel;
		this.panel = null;
		if (base.enabled && uipanel && uipanel.enabled)
		{
			this.OnPanelDisable();
		}
	}

	// Token: 0x06004C98 RID: 19608 RVA: 0x0012143C File Offset: 0x0011F63C
	private void SetBounds(bool moved, global::UnityEngine.Bounds bounds, bool worldEquals)
	{
		if (this.configuredInLocalSpace)
		{
			if (this._lastBoundsEntered == bounds && worldEquals)
			{
				return;
			}
			this._lastBoundsEntered = bounds;
			global::AABBox.Transform3x4(ref bounds, ref this.toWorld, out this._bounds);
		}
		else
		{
			this._lastBoundsEntered = bounds;
			this._bounds = bounds;
		}
	}

	// Token: 0x06004C99 RID: 19609 RVA: 0x0012149C File Offset: 0x0011F69C
	protected virtual void HotSpotInit()
	{
	}

	// Token: 0x06004C9A RID: 19610 RVA: 0x001214A0 File Offset: 0x0011F6A0
	public bool ClosestRaycast(global::UnityEngine.Ray ray, ref global::UIHotSpot.Hit hit)
	{
		global::UIHotSpot.Hit hit2;
		if (this.Raycast(ray, out hit2) && hit2.distance < hit.distance)
		{
			hit = hit2;
			return true;
		}
		return false;
	}

	// Token: 0x06004C9B RID: 19611 RVA: 0x001214D8 File Offset: 0x0011F6D8
	private bool LocalRaycastRef(global::UnityEngine.Ray worldRay, ref global::UIHotSpot.Hit hit)
	{
		global::UnityEngine.Matrix4x4 matrix4x = base.transform.worldToLocalMatrix;
		global::UnityEngine.Ray ray;
		ray..ctor(matrix4x.MultiplyPoint(worldRay.origin), matrix4x.MultiplyVector(worldRay.direction));
		global::UIHotSpot.Hit invalid = global::UIHotSpot.Hit.invalid;
		if (this.DoRaycastRef(ray, ref invalid))
		{
			matrix4x = base.transform.localToWorldMatrix;
			hit.point = matrix4x.MultiplyPoint(invalid.point);
			hit.normal = matrix4x.MultiplyVector(invalid.normal);
			hit.ray = worldRay;
			hit.distance = global::UnityEngine.Vector3.Dot(worldRay.direction, hit.point - worldRay.origin);
			hit.hotSpot = this;
			hit.panel = this.panel;
			return true;
		}
		return false;
	}

	// Token: 0x06004C9C RID: 19612 RVA: 0x001215A0 File Offset: 0x0011F7A0
	private bool DoRaycastRef(global::UnityEngine.Ray ray, ref global::UIHotSpot.Hit hit)
	{
		global::UIHotSpot.Kind kind = this.kind;
		switch (kind)
		{
		case global::UIHotSpot.Kind.Circle:
			return ((global::UICircleHotSpot)this).Internal_RaycastRef(ray, ref hit);
		case global::UIHotSpot.Kind.Rect:
			return ((global::UIRectHotSpot)this).Internal_RaycastRef(ray, ref hit);
		case global::UIHotSpot.Kind.Convex:
			return ((global::UIConvexHotSpot)this).Internal_RaycastRef(ray, ref hit);
		default:
			switch (kind)
			{
			case global::UIHotSpot.Kind.Sphere:
				return ((global::UISphereHotSpot)this).Internal_RaycastRef(ray, ref hit);
			case global::UIHotSpot.Kind.Box:
				return ((global::UIBoxHotSpot)this).Internal_RaycastRef(ray, ref hit);
			case global::UIHotSpot.Kind.Brush:
				return ((global::UIBrushHotSpot)this).Internal_RaycastRef(ray, ref hit);
			default:
				throw new global::System.NotImplementedException();
			}
			break;
		}
	}

	// Token: 0x06004C9D RID: 19613 RVA: 0x0012163C File Offset: 0x0011F83C
	public bool Raycast(global::UnityEngine.Ray ray, out global::UIHotSpot.Hit hit)
	{
		hit = global::UIHotSpot.Hit.invalid;
		return this.RaycastRef(ray, ref hit);
	}

	// Token: 0x06004C9E RID: 19614 RVA: 0x00121654 File Offset: 0x0011F854
	public bool RaycastRef(global::UnityEngine.Ray ray, ref global::UIHotSpot.Hit hit)
	{
		if (this.configuredInLocalSpace)
		{
			return this.LocalRaycastRef(ray, ref hit);
		}
		return this.DoRaycastRef(ray, ref hit);
	}

	// Token: 0x06004C9F RID: 19615 RVA: 0x00121674 File Offset: 0x0011F874
	public static bool Raycast(global::UnityEngine.Ray ray, out global::UIHotSpot.Hit hit, float distance)
	{
		return global::UIHotSpot.Global.Raycast(ray, out hit, distance);
	}

	// Token: 0x17000E4A RID: 3658
	// (get) Token: 0x06004CA0 RID: 19616 RVA: 0x00121680 File Offset: 0x0011F880
	protected global::UnityEngine.Color gizmoColor
	{
		get
		{
			return global::UnityEngine.Color.green;
		}
	}

	// Token: 0x17000E4B RID: 3659
	// (get) Token: 0x06004CA1 RID: 19617 RVA: 0x00121688 File Offset: 0x0011F888
	protected global::UnityEngine.Matrix4x4 gizmoMatrix
	{
		get
		{
			if (this.index == -1)
			{
				return (!this.configuredInLocalSpace) ? global::UnityEngine.Matrix4x4.identity : base.transform.localToWorldMatrix;
			}
			return (!this.configuredInLocalSpace) ? global::UnityEngine.Matrix4x4.identity : this.toWorld;
		}
	}

	// Token: 0x17000E4C RID: 3660
	// (get) Token: 0x06004CA2 RID: 19618 RVA: 0x001216E0 File Offset: 0x0011F8E0
	public global::UnityEngine.Vector3 worldCenter
	{
		get
		{
			global::UIHotSpot.Kind kind = this.kind;
			global::UnityEngine.Vector3 center;
			if (kind != global::UIHotSpot.Kind.Circle)
			{
				if (kind != global::UIHotSpot.Kind.Rect)
				{
					if (kind != global::UIHotSpot.Kind.Sphere)
					{
						if (kind != global::UIHotSpot.Kind.Box)
						{
							throw new global::System.NotImplementedException();
						}
						center = ((global::UIBoxHotSpot)this).center;
					}
					else
					{
						center = ((global::UISphereHotSpot)this).center;
					}
				}
				else
				{
					center = ((global::UIRectHotSpot)this).center;
				}
			}
			else
			{
				center = ((global::UICircleHotSpot)this).center;
			}
			return base.transform.TransformPoint(center);
		}
	}

	// Token: 0x17000E4D RID: 3661
	// (get) Token: 0x06004CA3 RID: 19619 RVA: 0x00121774 File Offset: 0x0011F974
	// (set) Token: 0x06004CA4 RID: 19620 RVA: 0x001217EC File Offset: 0x0011F9EC
	public global::UnityEngine.Vector3 center
	{
		get
		{
			global::UIHotSpot.Kind kind = this.kind;
			if (kind == global::UIHotSpot.Kind.Circle)
			{
				return ((global::UICircleHotSpot)this).center;
			}
			if (kind == global::UIHotSpot.Kind.Rect)
			{
				return ((global::UIRectHotSpot)this).center;
			}
			if (kind == global::UIHotSpot.Kind.Sphere)
			{
				return ((global::UISphereHotSpot)this).center;
			}
			if (kind != global::UIHotSpot.Kind.Box)
			{
				return default(global::UnityEngine.Vector3);
			}
			return ((global::UIBoxHotSpot)this).center;
		}
		set
		{
			global::UIHotSpot.Kind kind = this.kind;
			if (kind != global::UIHotSpot.Kind.Circle)
			{
				if (kind != global::UIHotSpot.Kind.Rect)
				{
					if (kind != global::UIHotSpot.Kind.Sphere)
					{
						if (kind == global::UIHotSpot.Kind.Box)
						{
							((global::UIBoxHotSpot)this).center = value;
						}
					}
					else
					{
						((global::UISphereHotSpot)this).center = value;
					}
				}
				else
				{
					((global::UIRectHotSpot)this).center = value;
				}
			}
			else
			{
				((global::UICircleHotSpot)this).center = value;
			}
		}
	}

	// Token: 0x17000E4E RID: 3662
	// (get) Token: 0x06004CA5 RID: 19621 RVA: 0x00121874 File Offset: 0x0011FA74
	// (set) Token: 0x06004CA6 RID: 19622 RVA: 0x0012193C File Offset: 0x0011FB3C
	public global::UnityEngine.Vector3 size
	{
		get
		{
			global::UIHotSpot.Kind kind = this.kind;
			global::UnityEngine.Vector3 result;
			if (kind == global::UIHotSpot.Kind.Circle)
			{
				result.x = ((global::UICircleHotSpot)this).radius * 2f;
				result.y = result.x;
				result.z = 0f;
				return result;
			}
			if (kind == global::UIHotSpot.Kind.Rect)
			{
				return ((global::UIRectHotSpot)this).size;
			}
			if (kind == global::UIHotSpot.Kind.Sphere)
			{
				result.x = ((global::UICircleHotSpot)this).radius * 1.4142135f;
				result.y = (result.z = result.x);
				return result;
			}
			if (kind != global::UIHotSpot.Kind.Box)
			{
				return default(global::UnityEngine.Vector3);
			}
			return ((global::UIBoxHotSpot)this).size;
		}
		set
		{
			global::UIHotSpot.Kind kind = this.kind;
			if (kind != global::UIHotSpot.Kind.Circle)
			{
				if (kind != global::UIHotSpot.Kind.Rect)
				{
					if (kind != global::UIHotSpot.Kind.Sphere)
					{
						if (kind == global::UIHotSpot.Kind.Box)
						{
							((global::UIBoxHotSpot)this).size = value;
						}
					}
					else
					{
						value.z *= 0.70710677f;
						value.y *= 0.70710677f;
						value.x *= 0.70710677f;
						((global::UISphereHotSpot)this).radius = global::UnityEngine.Mathf.Sqrt(value.x * value.x + value.y * value.y + value.z * value.z) / 2f;
					}
				}
				else
				{
					((global::UIRectHotSpot)this).size = new global::UnityEngine.Vector2(value.x, value.y);
				}
			}
			else
			{
				value.y *= 0.70710677f;
				value.x *= 0.70710677f;
				((global::UICircleHotSpot)this).radius = global::UnityEngine.Mathf.Sqrt(value.x * value.x + value.y * value.y) / 2f;
			}
		}
	}

	// Token: 0x0400295A RID: 10586
	private const global::UIHotSpot.Kind kKindFlag_2D = global::UIHotSpot.Kind.Circle;

	// Token: 0x0400295B RID: 10587
	private const global::UIHotSpot.Kind kKindFlag_3D = global::UIHotSpot.Kind.Sphere;

	// Token: 0x0400295C RID: 10588
	private const global::UIHotSpot.Kind kKindFlag_Radial = global::UIHotSpot.Kind.Circle;

	// Token: 0x0400295D RID: 10589
	private const global::UIHotSpot.Kind kKindFlag_Axial = global::UIHotSpot.Kind.Rect;

	// Token: 0x0400295E RID: 10590
	private const global::UIHotSpot.Kind kKindFlag_Convex = global::UIHotSpot.Kind.Convex;

	// Token: 0x0400295F RID: 10591
	private const float kCos45 = 0.70710677f;

	// Token: 0x04002960 RID: 10592
	private const float k2Cos45 = 1.4142135f;

	// Token: 0x04002961 RID: 10593
	public readonly global::UIHotSpot.Kind kind;

	// Token: 0x04002962 RID: 10594
	private global::UIPanel panel;

	// Token: 0x04002963 RID: 10595
	private global::UnityEngine.Matrix4x4 toWorld;

	// Token: 0x04002964 RID: 10596
	private global::UnityEngine.Matrix4x4 toLocal;

	// Token: 0x04002965 RID: 10597
	private global::UnityEngine.Matrix4x4 lastWorld;

	// Token: 0x04002966 RID: 10598
	private global::UnityEngine.Matrix4x4 lastLocal;

	// Token: 0x04002967 RID: 10599
	private global::UnityEngine.Bounds _bounds;

	// Token: 0x04002968 RID: 10600
	private global::UnityEngine.Bounds _lastBoundsEntered;

	// Token: 0x04002969 RID: 10601
	private bool once;

	// Token: 0x0400296A RID: 10602
	private bool justAdded;

	// Token: 0x0400296B RID: 10603
	private int index = -1;

	// Token: 0x0400296C RID: 10604
	private readonly bool configuredInLocalSpace;

	// Token: 0x0400296D RID: 10605
	protected static readonly global::UnityEngine.Plane localPlane = new global::UnityEngine.Plane(global::UnityEngine.Vector3.back, global::UnityEngine.Vector3.zero);

	// Token: 0x020008A6 RID: 2214
	public enum Kind
	{
		// Token: 0x0400296F RID: 10607
		Circle,
		// Token: 0x04002970 RID: 10608
		Rect,
		// Token: 0x04002971 RID: 10609
		Convex,
		// Token: 0x04002972 RID: 10610
		Sphere = 0x80,
		// Token: 0x04002973 RID: 10611
		Box,
		// Token: 0x04002974 RID: 10612
		Brush
	}

	// Token: 0x020008A7 RID: 2215
	public struct Hit
	{
		// Token: 0x06004CA7 RID: 19623 RVA: 0x00121A90 File Offset: 0x0011FC90
		// Note: this type is marked as 'beforefieldinit'.
		static Hit()
		{
		}

		// Token: 0x17000E4F RID: 3663
		// (get) Token: 0x06004CA8 RID: 19624 RVA: 0x00121AE8 File Offset: 0x0011FCE8
		public global::UnityEngine.GameObject gameObject
		{
			get
			{
				return (!this.isCollider) ? ((!this.hotSpot) ? null : this.hotSpot.gameObject) : this.collider.gameObject;
			}
		}

		// Token: 0x17000E50 RID: 3664
		// (get) Token: 0x06004CA9 RID: 19625 RVA: 0x00121B34 File Offset: 0x0011FD34
		public global::UnityEngine.Transform transform
		{
			get
			{
				return (!this.isCollider) ? ((!this.hotSpot) ? null : this.hotSpot.transform) : this.collider.transform;
			}
		}

		// Token: 0x17000E51 RID: 3665
		// (get) Token: 0x06004CAA RID: 19626 RVA: 0x00121B80 File Offset: 0x0011FD80
		public global::UnityEngine.Component component
		{
			get
			{
				return (!this.isCollider) ? this.hotSpot : this.collider;
			}
		}

		// Token: 0x04002975 RID: 10613
		public global::UIHotSpot hotSpot;

		// Token: 0x04002976 RID: 10614
		public global::UnityEngine.Collider collider;

		// Token: 0x04002977 RID: 10615
		public global::UIPanel panel;

		// Token: 0x04002978 RID: 10616
		public global::UnityEngine.Vector3 point;

		// Token: 0x04002979 RID: 10617
		public global::UnityEngine.Vector3 normal;

		// Token: 0x0400297A RID: 10618
		public global::UnityEngine.Ray ray;

		// Token: 0x0400297B RID: 10619
		public float distance;

		// Token: 0x0400297C RID: 10620
		public bool isCollider;

		// Token: 0x0400297D RID: 10621
		public static readonly global::UIHotSpot.Hit invalid = new global::UIHotSpot.Hit
		{
			distance = float.PositiveInfinity,
			ray = default(global::UnityEngine.Ray),
			point = default(global::UnityEngine.Vector3),
			normal = default(global::UnityEngine.Vector3)
		};
	}

	// Token: 0x020008A8 RID: 2216
	private static class Global
	{
		// Token: 0x06004CAB RID: 19627 RVA: 0x00121BA0 File Offset: 0x0011FDA0
		// Note: this type is marked as 'beforefieldinit'.
		static Global()
		{
		}

		// Token: 0x06004CAC RID: 19628 RVA: 0x00121BAC File Offset: 0x0011FDAC
		public static bool Add(global::UIHotSpot hotSpot)
		{
			if (hotSpot.index != -1)
			{
				return false;
			}
			global::UIHotSpot.Kind kind = hotSpot.kind;
			switch (kind)
			{
			case global::UIHotSpot.Kind.Circle:
				global::UIHotSpot.Global.Circle.Add((global::UICircleHotSpot)hotSpot);
				break;
			case global::UIHotSpot.Kind.Rect:
				global::UIHotSpot.Global.Rect.Add((global::UIRectHotSpot)hotSpot);
				break;
			case global::UIHotSpot.Kind.Convex:
				global::UIHotSpot.Global.Convex.Add((global::UIConvexHotSpot)hotSpot);
				break;
			default:
				switch (kind)
				{
				case global::UIHotSpot.Kind.Sphere:
					global::UIHotSpot.Global.Sphere.Add((global::UISphereHotSpot)hotSpot);
					break;
				case global::UIHotSpot.Kind.Box:
					global::UIHotSpot.Global.Box.Add((global::UIBoxHotSpot)hotSpot);
					break;
				case global::UIHotSpot.Kind.Brush:
					global::UIHotSpot.Global.Brush.Add((global::UIBrushHotSpot)hotSpot);
					break;
				default:
					throw new global::System.NotImplementedException();
				}
				break;
			}
			hotSpot.justAdded = true;
			if (!hotSpot.once)
			{
				hotSpot.HotSpotInit();
				hotSpot.once = true;
			}
			return true;
		}

		// Token: 0x06004CAD RID: 19629 RVA: 0x00121CA4 File Offset: 0x0011FEA4
		public static bool Remove(global::UIHotSpot hotSpot)
		{
			if (hotSpot.index == -1)
			{
				return false;
			}
			global::UIHotSpot.Kind kind = hotSpot.kind;
			switch (kind)
			{
			case global::UIHotSpot.Kind.Circle:
				global::UIHotSpot.Global.Circle.Erase((global::UICircleHotSpot)hotSpot);
				break;
			case global::UIHotSpot.Kind.Rect:
				global::UIHotSpot.Global.Rect.Erase((global::UIRectHotSpot)hotSpot);
				break;
			case global::UIHotSpot.Kind.Convex:
				global::UIHotSpot.Global.Convex.Erase((global::UIConvexHotSpot)hotSpot);
				break;
			default:
				switch (kind)
				{
				case global::UIHotSpot.Kind.Sphere:
					global::UIHotSpot.Global.Sphere.Erase((global::UISphereHotSpot)hotSpot);
					break;
				case global::UIHotSpot.Kind.Box:
					global::UIHotSpot.Global.Box.Erase((global::UIBoxHotSpot)hotSpot);
					break;
				case global::UIHotSpot.Kind.Brush:
					global::UIHotSpot.Global.Brush.Erase((global::UIBrushHotSpot)hotSpot);
					break;
				default:
					throw new global::System.NotImplementedException();
				}
				break;
			}
			return true;
		}

		// Token: 0x06004CAE RID: 19630 RVA: 0x00121D7C File Offset: 0x0011FF7C
		private static bool MatrixEquals(ref global::UnityEngine.Matrix4x4 a, ref global::UnityEngine.Matrix4x4 b)
		{
			return a.m03 == b.m03 && a.m12 == b.m13 && a.m23 == b.m23 && a.m00 == b.m00 && a.m11 == b.m11 && a.m22 == b.m22 && a.m01 == b.m01 && a.m12 == b.m12 && a.m20 == b.m20 && a.m02 == b.m02 && a.m10 == b.m10 && a.m21 == b.m21 && a.m30 == b.m30 && a.m31 == b.m31 && a.m32 == b.m32 && a.m33 == b.m33;
		}

		// Token: 0x06004CAF RID: 19631 RVA: 0x00121E9C File Offset: 0x0012009C
		private static global::UnityEngine.Bounds? DoStep()
		{
			global::UnityEngine.Bounds value = default(global::UnityEngine.Bounds);
			bool flag = true;
			int num = global::UIHotSpot.Global.allCount;
			if (global::UIHotSpot.Global.Circle.any)
			{
				for (int i = 0; i < global::UIHotSpot.Global.Circle.count; i++)
				{
					global::UICircleHotSpot uicircleHotSpot = global::UIHotSpot.Global.Circle.array[i];
					global::UnityEngine.Transform transform = uicircleHotSpot.transform;
					uicircleHotSpot.lastWorld = uicircleHotSpot.toWorld;
					uicircleHotSpot.toWorld = transform.localToWorldMatrix;
					uicircleHotSpot.lastLocal = uicircleHotSpot.toLocal;
					uicircleHotSpot.toLocal = transform.worldToLocalMatrix;
					bool worldEquals;
					bool flag2 = !(worldEquals = !uicircleHotSpot.justAdded) || !(worldEquals = global::UIHotSpot.Global.MatrixEquals(ref uicircleHotSpot.toWorld, ref uicircleHotSpot.lastWorld));
					bool moved = uicircleHotSpot.justAdded || ((!uicircleHotSpot.configuredInLocalSpace) ? flag2 : (!global::UIHotSpot.Global.MatrixEquals(ref uicircleHotSpot.toLocal, ref uicircleHotSpot.lastLocal)));
					global::UIHotSpot uihotSpot = uicircleHotSpot;
					bool moved2 = flag2;
					global::UnityEngine.Bounds? bounds = uicircleHotSpot.Internal_CalculateBounds(moved);
					uihotSpot.SetBounds(moved2, (bounds == null) ? uicircleHotSpot._bounds : bounds.Value, worldEquals);
					uicircleHotSpot.justAdded = false;
					if (uicircleHotSpot._bounds.size != global::UnityEngine.Vector3.zero)
					{
						if (flag)
						{
							if (--num == 0)
							{
								return new global::UnityEngine.Bounds?(uicircleHotSpot._bounds);
							}
							flag = false;
							value = uicircleHotSpot._bounds;
						}
						else
						{
							value.Encapsulate(uicircleHotSpot._bounds);
							if (--num == 0)
							{
								return new global::UnityEngine.Bounds?(value);
							}
						}
					}
					else if (--num == 0)
					{
						return null;
					}
				}
			}
			if (global::UIHotSpot.Global.Rect.any)
			{
				for (int j = 0; j < global::UIHotSpot.Global.Rect.count; j++)
				{
					global::UIRectHotSpot uirectHotSpot = global::UIHotSpot.Global.Rect.array[j];
					global::UnityEngine.Transform transform = uirectHotSpot.transform;
					uirectHotSpot.lastWorld = uirectHotSpot.toWorld;
					uirectHotSpot.toWorld = transform.localToWorldMatrix;
					uirectHotSpot.lastLocal = uirectHotSpot.toLocal;
					uirectHotSpot.toLocal = transform.worldToLocalMatrix;
					bool worldEquals;
					bool flag2 = !(worldEquals = !uirectHotSpot.justAdded) || !(worldEquals = global::UIHotSpot.Global.MatrixEquals(ref uirectHotSpot.toWorld, ref uirectHotSpot.lastWorld));
					bool moved = uirectHotSpot.justAdded || ((!uirectHotSpot.configuredInLocalSpace) ? flag2 : (!global::UIHotSpot.Global.MatrixEquals(ref uirectHotSpot.toLocal, ref uirectHotSpot.lastLocal)));
					global::UIHotSpot uihotSpot2 = uirectHotSpot;
					bool moved3 = flag2;
					global::UnityEngine.Bounds? bounds2 = uirectHotSpot.Internal_CalculateBounds(moved);
					uihotSpot2.SetBounds(moved3, (bounds2 == null) ? uirectHotSpot._bounds : bounds2.Value, worldEquals);
					uirectHotSpot.justAdded = false;
					if (uirectHotSpot._bounds.size != global::UnityEngine.Vector3.zero)
					{
						if (flag)
						{
							if (--num == 0)
							{
								return new global::UnityEngine.Bounds?(uirectHotSpot._bounds);
							}
							flag = false;
							value = uirectHotSpot._bounds;
						}
						else
						{
							value.Encapsulate(uirectHotSpot._bounds);
							if (--num == 0)
							{
								return new global::UnityEngine.Bounds?(value);
							}
						}
					}
					else if (--num == 0)
					{
						return null;
					}
				}
			}
			if (global::UIHotSpot.Global.Convex.any)
			{
				for (int k = 0; k < global::UIHotSpot.Global.Convex.count; k++)
				{
					global::UIConvexHotSpot uiconvexHotSpot = global::UIHotSpot.Global.Convex.array[k];
					global::UnityEngine.Transform transform = uiconvexHotSpot.transform;
					uiconvexHotSpot.lastWorld = uiconvexHotSpot.toWorld;
					uiconvexHotSpot.toWorld = transform.localToWorldMatrix;
					uiconvexHotSpot.lastLocal = uiconvexHotSpot.toLocal;
					uiconvexHotSpot.toLocal = transform.worldToLocalMatrix;
					bool worldEquals;
					bool flag2 = !(worldEquals = !uiconvexHotSpot.justAdded) || !(worldEquals = global::UIHotSpot.Global.MatrixEquals(ref uiconvexHotSpot.toWorld, ref uiconvexHotSpot.lastWorld));
					bool moved = uiconvexHotSpot.justAdded || ((!uiconvexHotSpot.configuredInLocalSpace) ? flag2 : (!global::UIHotSpot.Global.MatrixEquals(ref uiconvexHotSpot.toLocal, ref uiconvexHotSpot.lastLocal)));
					global::UIHotSpot uihotSpot3 = uiconvexHotSpot;
					bool moved4 = flag2;
					global::UnityEngine.Bounds? bounds3 = uiconvexHotSpot.Internal_CalculateBounds(moved);
					uihotSpot3.SetBounds(moved4, (bounds3 == null) ? uiconvexHotSpot._bounds : bounds3.Value, worldEquals);
					uiconvexHotSpot.justAdded = false;
					if (uiconvexHotSpot._bounds.size != global::UnityEngine.Vector3.zero)
					{
						if (flag)
						{
							if (--num == 0)
							{
								return new global::UnityEngine.Bounds?(uiconvexHotSpot._bounds);
							}
							flag = false;
							value = uiconvexHotSpot._bounds;
						}
						else
						{
							value.Encapsulate(uiconvexHotSpot._bounds);
							if (--num == 0)
							{
								return new global::UnityEngine.Bounds?(value);
							}
						}
					}
					else if (--num == 0)
					{
						return null;
					}
				}
			}
			if (global::UIHotSpot.Global.Sphere.any)
			{
				for (int l = 0; l < global::UIHotSpot.Global.Sphere.count; l++)
				{
					global::UISphereHotSpot uisphereHotSpot = global::UIHotSpot.Global.Sphere.array[l];
					global::UnityEngine.Transform transform = uisphereHotSpot.transform;
					uisphereHotSpot.lastWorld = uisphereHotSpot.toWorld;
					uisphereHotSpot.toWorld = transform.localToWorldMatrix;
					uisphereHotSpot.lastLocal = uisphereHotSpot.toLocal;
					uisphereHotSpot.toLocal = transform.worldToLocalMatrix;
					bool worldEquals;
					bool flag2 = !(worldEquals = !uisphereHotSpot.justAdded) || !(worldEquals = global::UIHotSpot.Global.MatrixEquals(ref uisphereHotSpot.toWorld, ref uisphereHotSpot.lastWorld));
					bool moved = uisphereHotSpot.justAdded || ((!uisphereHotSpot.configuredInLocalSpace) ? flag2 : (!global::UIHotSpot.Global.MatrixEquals(ref uisphereHotSpot.toLocal, ref uisphereHotSpot.lastLocal)));
					global::UIHotSpot uihotSpot4 = uisphereHotSpot;
					bool moved5 = flag2;
					global::UnityEngine.Bounds? bounds4 = uisphereHotSpot.Internal_CalculateBounds(moved);
					uihotSpot4.SetBounds(moved5, (bounds4 == null) ? uisphereHotSpot._bounds : bounds4.Value, worldEquals);
					uisphereHotSpot.justAdded = false;
					if (uisphereHotSpot._bounds.size != global::UnityEngine.Vector3.zero)
					{
						if (flag)
						{
							if (--num == 0)
							{
								return new global::UnityEngine.Bounds?(uisphereHotSpot._bounds);
							}
							flag = false;
							value = uisphereHotSpot._bounds;
						}
						else
						{
							value.Encapsulate(uisphereHotSpot._bounds);
							if (--num == 0)
							{
								return new global::UnityEngine.Bounds?(value);
							}
						}
					}
					else if (--num == 0)
					{
						return null;
					}
				}
			}
			if (global::UIHotSpot.Global.Box.any)
			{
				for (int m = 0; m < global::UIHotSpot.Global.Box.count; m++)
				{
					global::UIBoxHotSpot uiboxHotSpot = global::UIHotSpot.Global.Box.array[m];
					global::UnityEngine.Transform transform = uiboxHotSpot.transform;
					uiboxHotSpot.lastWorld = uiboxHotSpot.toWorld;
					uiboxHotSpot.toWorld = transform.localToWorldMatrix;
					uiboxHotSpot.lastLocal = uiboxHotSpot.toLocal;
					uiboxHotSpot.toLocal = transform.worldToLocalMatrix;
					bool worldEquals;
					bool flag2 = !(worldEquals = !uiboxHotSpot.justAdded) || !(worldEquals = global::UIHotSpot.Global.MatrixEquals(ref uiboxHotSpot.toWorld, ref uiboxHotSpot.lastWorld));
					bool moved = uiboxHotSpot.justAdded || ((!uiboxHotSpot.configuredInLocalSpace) ? flag2 : (!global::UIHotSpot.Global.MatrixEquals(ref uiboxHotSpot.toLocal, ref uiboxHotSpot.lastLocal)));
					global::UIHotSpot uihotSpot5 = uiboxHotSpot;
					bool moved6 = flag2;
					global::UnityEngine.Bounds? bounds5 = uiboxHotSpot.Internal_CalculateBounds(moved);
					uihotSpot5.SetBounds(moved6, (bounds5 == null) ? uiboxHotSpot._bounds : bounds5.Value, worldEquals);
					uiboxHotSpot.justAdded = false;
					if (uiboxHotSpot._bounds.size != global::UnityEngine.Vector3.zero)
					{
						if (flag)
						{
							if (--num == 0)
							{
								return new global::UnityEngine.Bounds?(uiboxHotSpot._bounds);
							}
							flag = false;
							value = uiboxHotSpot._bounds;
						}
						else
						{
							value.Encapsulate(uiboxHotSpot._bounds);
							if (--num == 0)
							{
								return new global::UnityEngine.Bounds?(value);
							}
						}
					}
					else if (--num == 0)
					{
						return null;
					}
				}
			}
			if (global::UIHotSpot.Global.Brush.any)
			{
				for (int n = 0; n < global::UIHotSpot.Global.Brush.count; n++)
				{
					global::UIBrushHotSpot uibrushHotSpot = global::UIHotSpot.Global.Brush.array[n];
					global::UnityEngine.Transform transform = uibrushHotSpot.transform;
					uibrushHotSpot.lastWorld = uibrushHotSpot.toWorld;
					uibrushHotSpot.toWorld = transform.localToWorldMatrix;
					uibrushHotSpot.lastLocal = uibrushHotSpot.toLocal;
					uibrushHotSpot.toLocal = transform.worldToLocalMatrix;
					bool worldEquals;
					bool flag2 = !(worldEquals = !uibrushHotSpot.justAdded) || !(worldEquals = global::UIHotSpot.Global.MatrixEquals(ref uibrushHotSpot.toWorld, ref uibrushHotSpot.lastWorld));
					bool moved = uibrushHotSpot.justAdded || ((!uibrushHotSpot.configuredInLocalSpace) ? flag2 : (!global::UIHotSpot.Global.MatrixEquals(ref uibrushHotSpot.toLocal, ref uibrushHotSpot.lastLocal)));
					global::UIHotSpot uihotSpot6 = uibrushHotSpot;
					bool moved7 = flag2;
					global::UnityEngine.Bounds? bounds6 = uibrushHotSpot.Internal_CalculateBounds(moved);
					uihotSpot6.SetBounds(moved7, (bounds6 == null) ? uibrushHotSpot._bounds : bounds6.Value, worldEquals);
					uibrushHotSpot.justAdded = false;
					if (uibrushHotSpot._bounds.size != global::UnityEngine.Vector3.zero)
					{
						if (flag)
						{
							if (--num == 0)
							{
								return new global::UnityEngine.Bounds?(uibrushHotSpot._bounds);
							}
							flag = false;
							value = uibrushHotSpot._bounds;
						}
						else
						{
							value.Encapsulate(uibrushHotSpot._bounds);
							if (--num == 0)
							{
								return new global::UnityEngine.Bounds?(value);
							}
						}
					}
					else if (--num == 0)
					{
						return null;
					}
				}
			}
			throw new global::System.InvalidOperationException("Something is messed up. this line should never execute.");
		}

		// Token: 0x06004CB0 RID: 19632 RVA: 0x001228A8 File Offset: 0x00120AA8
		private static bool DoRaycast(global::UnityEngine.Ray ray, out global::UIHotSpot.Hit hit, float dist)
		{
			hit = global::UIHotSpot.Hit.invalid;
			global::UIHotSpot.Hit invalid = global::UIHotSpot.Hit.invalid;
			bool flag = true;
			global::UnityEngine.Vector3 origin = ray.origin;
			int num = global::UIHotSpot.Global.allCount;
			float num2;
			if (global::UIHotSpot.Global.Circle.any)
			{
				for (int i = 0; i < global::UIHotSpot.Global.Circle.count; i++)
				{
					global::UICircleHotSpot uicircleHotSpot = global::UIHotSpot.Global.Circle.array[i];
					if ((uicircleHotSpot._bounds.Contains(origin) || (uicircleHotSpot._bounds.IntersectRay(ray, ref num2) && num2 < dist)) && uicircleHotSpot.panel.InsideClippingRect(ray, global::UIHotSpot.Global.lastStepFrame) && uicircleHotSpot.RaycastRef(ray, ref invalid) && invalid.distance < dist)
					{
						if (flag)
						{
							flag = false;
						}
						dist = invalid.distance;
						hit = invalid;
						if (--num == 0)
						{
							return true;
						}
					}
					else if (--num == 0)
					{
						return !flag;
					}
				}
			}
			if (global::UIHotSpot.Global.Rect.any)
			{
				for (int j = 0; j < global::UIHotSpot.Global.Rect.count; j++)
				{
					global::UIRectHotSpot uirectHotSpot = global::UIHotSpot.Global.Rect.array[j];
					if ((uirectHotSpot._bounds.Contains(origin) || (uirectHotSpot._bounds.IntersectRay(ray, ref num2) && num2 < dist)) && uirectHotSpot.panel.InsideClippingRect(ray, global::UIHotSpot.Global.lastStepFrame) && uirectHotSpot.RaycastRef(ray, ref invalid) && invalid.distance < dist)
					{
						if (flag)
						{
							flag = false;
						}
						dist = invalid.distance;
						hit = invalid;
						if (--num == 0)
						{
							return true;
						}
					}
					else if (--num == 0)
					{
						return !flag;
					}
				}
			}
			if (global::UIHotSpot.Global.Convex.any)
			{
				for (int k = 0; k < global::UIHotSpot.Global.Convex.count; k++)
				{
					global::UIConvexHotSpot uiconvexHotSpot = global::UIHotSpot.Global.Convex.array[k];
					if ((uiconvexHotSpot._bounds.Contains(origin) || (uiconvexHotSpot._bounds.IntersectRay(ray, ref num2) && num2 < dist)) && uiconvexHotSpot.panel.InsideClippingRect(ray, global::UIHotSpot.Global.lastStepFrame) && uiconvexHotSpot.RaycastRef(ray, ref invalid) && invalid.distance < dist)
					{
						if (flag)
						{
							flag = false;
						}
						dist = invalid.distance;
						hit = invalid;
						if (--num == 0)
						{
							return true;
						}
					}
					else if (--num == 0)
					{
						return !flag;
					}
				}
			}
			if (global::UIHotSpot.Global.Sphere.any)
			{
				for (int l = 0; l < global::UIHotSpot.Global.Sphere.count; l++)
				{
					global::UISphereHotSpot uisphereHotSpot = global::UIHotSpot.Global.Sphere.array[l];
					if ((uisphereHotSpot._bounds.Contains(origin) || (uisphereHotSpot._bounds.IntersectRay(ray, ref num2) && num2 < dist)) && uisphereHotSpot.panel.InsideClippingRect(ray, global::UIHotSpot.Global.lastStepFrame) && uisphereHotSpot.RaycastRef(ray, ref invalid) && invalid.distance < dist)
					{
						if (flag)
						{
							flag = false;
						}
						dist = invalid.distance;
						hit = invalid;
						if (--num == 0)
						{
							return true;
						}
					}
					else if (--num == 0)
					{
						return !flag;
					}
				}
			}
			if (global::UIHotSpot.Global.Box.any)
			{
				for (int m = 0; m < global::UIHotSpot.Global.Box.count; m++)
				{
					global::UIBoxHotSpot uiboxHotSpot = global::UIHotSpot.Global.Box.array[m];
					if ((uiboxHotSpot._bounds.Contains(origin) || (uiboxHotSpot._bounds.IntersectRay(ray, ref num2) && num2 < dist)) && uiboxHotSpot.panel.InsideClippingRect(ray, global::UIHotSpot.Global.lastStepFrame) && uiboxHotSpot.RaycastRef(ray, ref invalid) && invalid.distance < dist)
					{
						if (flag)
						{
							flag = false;
						}
						dist = invalid.distance;
						hit = invalid;
						if (--num == 0)
						{
							return true;
						}
					}
					else if (--num == 0)
					{
						return !flag;
					}
				}
			}
			if (global::UIHotSpot.Global.Brush.any)
			{
				for (int n = 0; n < global::UIHotSpot.Global.Brush.count; n++)
				{
					global::UIBrushHotSpot uibrushHotSpot = global::UIHotSpot.Global.Brush.array[n];
					if ((uibrushHotSpot._bounds.Contains(origin) || (uibrushHotSpot._bounds.IntersectRay(ray, ref num2) && num2 < dist)) && uibrushHotSpot.panel.InsideClippingRect(ray, global::UIHotSpot.Global.lastStepFrame) && uibrushHotSpot.RaycastRef(ray, ref invalid) && invalid.distance < dist)
					{
						if (flag)
						{
							flag = false;
						}
						dist = invalid.distance;
						hit = invalid;
						if (--num == 0)
						{
							return true;
						}
					}
					else if (--num == 0)
					{
						return !flag;
					}
				}
			}
			throw new global::System.InvalidOperationException("Something is messed up. this line should never execute.");
		}

		// Token: 0x06004CB1 RID: 19633 RVA: 0x00122DF8 File Offset: 0x00120FF8
		public static void Step()
		{
			if (global::UIHotSpot.Global.allAny)
			{
				global::UnityEngine.Bounds? bounds = global::UIHotSpot.Global.DoStep();
				global::UIHotSpot.Global.validBounds = (bounds != null);
				if (global::UIHotSpot.Global.validBounds)
				{
					global::UIHotSpot.Global.allBounds = bounds.Value;
				}
			}
			else
			{
				global::UIHotSpot.Global.validBounds = false;
			}
		}

		// Token: 0x06004CB2 RID: 19634 RVA: 0x00122E44 File Offset: 0x00121044
		public static bool Raycast(global::UnityEngine.Ray ray, out global::UIHotSpot.Hit hit, float distance)
		{
			if (!global::UIHotSpot.Global.allAny)
			{
				hit = global::UIHotSpot.Hit.invalid;
				return false;
			}
			int frameCount = global::UnityEngine.Time.frameCount;
			if (global::UIHotSpot.Global.lastStepFrame != frameCount || global::UIHotSpot.Global.anyRemovedRecently || global::UIHotSpot.Global.anyAddedRecently)
			{
				global::UIHotSpot.Global.Step();
				global::UIHotSpot.Global.anyRemovedRecently = (global::UIHotSpot.Global.anyAddedRecently = false);
			}
			global::UIHotSpot.Global.lastStepFrame = frameCount;
			if (!global::UIHotSpot.Global.validBounds)
			{
				hit = global::UIHotSpot.Hit.invalid;
				return false;
			}
			if (global::UIHotSpot.Global.allBounds.Contains(ray.origin))
			{
				float num = 0f;
			}
			else
			{
				float num;
				if (!global::UIHotSpot.Global.allBounds.IntersectRay(ray, ref num) || num > distance)
				{
					hit = global::UIHotSpot.Hit.invalid;
					return false;
				}
				if (num != 0f)
				{
					ray.origin = ray.GetPoint(num - 0.001f);
					num = 0f;
				}
			}
			return global::UIHotSpot.Global.DoRaycast(ray, out hit, distance);
		}

		// Token: 0x0400297E RID: 10622
		private static int allCount;

		// Token: 0x0400297F RID: 10623
		private static bool allAny;

		// Token: 0x04002980 RID: 10624
		private static global::UnityEngine.Bounds allBounds;

		// Token: 0x04002981 RID: 10625
		private static bool validBounds;

		// Token: 0x04002982 RID: 10626
		private static bool anyAddedRecently;

		// Token: 0x04002983 RID: 10627
		private static bool anyRemovedRecently;

		// Token: 0x04002984 RID: 10628
		private static global::UIHotSpot.Global.List<global::UICircleHotSpot> Circle;

		// Token: 0x04002985 RID: 10629
		private static global::UIHotSpot.Global.List<global::UIRectHotSpot> Rect;

		// Token: 0x04002986 RID: 10630
		private static global::UIHotSpot.Global.List<global::UIConvexHotSpot> Convex;

		// Token: 0x04002987 RID: 10631
		private static global::UIHotSpot.Global.List<global::UISphereHotSpot> Sphere;

		// Token: 0x04002988 RID: 10632
		private static global::UIHotSpot.Global.List<global::UIBoxHotSpot> Box;

		// Token: 0x04002989 RID: 10633
		private static global::UIHotSpot.Global.List<global::UIBrushHotSpot> Brush;

		// Token: 0x0400298A RID: 10634
		private static int lastStepFrame = int.MinValue;

		// Token: 0x020008A9 RID: 2217
		private struct List<THotSpot> where THotSpot : global::UIHotSpot
		{
			// Token: 0x06004CB3 RID: 19635 RVA: 0x00122F30 File Offset: 0x00121130
			public void Add(THotSpot hotSpot)
			{
				hotSpot.index = this.count++;
				if (hotSpot.index == this.capacity)
				{
					this.capacity += 8;
					global::System.Array.Resize<THotSpot>(ref this.array, this.capacity);
				}
				this.array[hotSpot.index] = hotSpot;
				this.any = true;
				if (global::UIHotSpot.Global.allCount++ == 0)
				{
					global::UIHotSpot.Global.allAny = true;
				}
				global::UIHotSpot.Global.anyAddedRecently = true;
			}

			// Token: 0x06004CB4 RID: 19636 RVA: 0x00122FCC File Offset: 0x001211CC
			public void Erase(THotSpot hotSpot)
			{
				global::UIHotSpot.Global.allCount--;
				if (--this.count == hotSpot.index)
				{
					this.array[hotSpot.index] = (THotSpot)((object)null);
					this.any = (this.count > 0);
					if (!this.any)
					{
						global::UIHotSpot.Global.allAny = (global::UIHotSpot.Global.allCount > 0);
					}
				}
				else
				{
					(this.array[hotSpot.index] = this.array[this.count]).index = hotSpot.index;
					this.array[this.count] = (THotSpot)((object)null);
				}
				hotSpot.index = -1;
				global::UIHotSpot.Global.anyRemovedRecently = true;
			}

			// Token: 0x0400298B RID: 10635
			public THotSpot[] array;

			// Token: 0x0400298C RID: 10636
			public int count;

			// Token: 0x0400298D RID: 10637
			public int capacity;

			// Token: 0x0400298E RID: 10638
			public bool any;
		}
	}
}
