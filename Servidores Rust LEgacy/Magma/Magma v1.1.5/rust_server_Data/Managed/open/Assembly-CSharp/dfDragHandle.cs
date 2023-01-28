using System;
using UnityEngine;

// Token: 0x020007E1 RID: 2017
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/Drag Handle")]
[global::UnityEngine.ExecuteInEditMode]
public class dfDragHandle : global::dfControl
{
	// Token: 0x060043C0 RID: 17344 RVA: 0x000F7824 File Offset: 0x000F5A24
	public dfDragHandle()
	{
	}

	// Token: 0x060043C1 RID: 17345 RVA: 0x000F782C File Offset: 0x000F5A2C
	public override void Start()
	{
		base.Start();
		if (base.Size.magnitude <= 1E-45f)
		{
			if (base.Parent != null)
			{
				base.Size = new global::UnityEngine.Vector2(base.Parent.Width, 30f);
				base.Anchor = (global::dfAnchorStyle.Top | global::dfAnchorStyle.Left | global::dfAnchorStyle.Right);
				base.RelativePosition = global::UnityEngine.Vector2.zero;
			}
			else
			{
				base.Size = new global::UnityEngine.Vector2(200f, 25f);
			}
		}
	}

	// Token: 0x060043C2 RID: 17346 RVA: 0x000F78B8 File Offset: 0x000F5AB8
	protected internal override void OnMouseDown(global::dfMouseEventArgs args)
	{
		base.GetRootContainer().BringToFront();
		args.Use();
		global::UnityEngine.Plane plane;
		plane..ctor(this.parent.transform.TransformDirection(global::UnityEngine.Vector3.back), this.parent.transform.position);
		global::UnityEngine.Ray ray = args.Ray;
		float num = 0f;
		plane.Raycast(args.Ray, ref num);
		this.lastPosition = ray.origin + ray.direction * num;
		base.OnMouseDown(args);
	}

	// Token: 0x060043C3 RID: 17347 RVA: 0x000F7948 File Offset: 0x000F5B48
	protected internal override void OnMouseMove(global::dfMouseEventArgs args)
	{
		args.Use();
		if (args.Buttons.IsSet(global::dfMouseButtons.Left))
		{
			global::UnityEngine.Ray ray = args.Ray;
			float num = 0f;
			global::UnityEngine.Vector3 vector = base.GetCamera().transform.TransformDirection(global::UnityEngine.Vector3.back);
			global::UnityEngine.Plane plane;
			plane..ctor(vector, this.lastPosition);
			plane.Raycast(ray, ref num);
			global::UnityEngine.Vector3 vector2 = (ray.origin + ray.direction * num).Quantize(this.parent.PixelsToUnits());
			global::UnityEngine.Vector3 vector3 = vector2 - this.lastPosition;
			global::UnityEngine.Vector3 position = (this.parent.transform.position + vector3).Quantize(this.parent.PixelsToUnits());
			this.parent.transform.position = position;
			this.lastPosition = vector2;
		}
		base.OnMouseMove(args);
	}

	// Token: 0x060043C4 RID: 17348 RVA: 0x000F7A2C File Offset: 0x000F5C2C
	protected internal override void OnMouseUp(global::dfMouseEventArgs args)
	{
		base.OnMouseUp(args);
		base.Parent.MakePixelPerfect(true);
	}

	// Token: 0x040023FB RID: 9211
	private global::UnityEngine.Vector3 lastPosition;
}
