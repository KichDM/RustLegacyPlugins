using System;
using Facepunch;
using uLink;
using UnityEngine;

// Token: 0x0200032A RID: 810
public class CullCell : global::Facepunch.MonoBehaviour
{
	// Token: 0x06001B26 RID: 6950 RVA: 0x0006BB74 File Offset: 0x00069D74
	public CullCell()
	{
	}

	// Token: 0x06001B27 RID: 6951 RVA: 0x0006BB7C File Offset: 0x00069D7C
	private static float HeightCast(global::UnityEngine.Vector2 point)
	{
		global::UnityEngine.RaycastHit raycastHit;
		return (!global::UnityEngine.Physics.Raycast(new global::UnityEngine.Vector3(point.x, 5000f, point.y), global::UnityEngine.Vector3.down, ref raycastHit, float.PositiveInfinity, global::CullCell.g.terrainMask)) ? 0f : raycastHit.point.y;
	}

	// Token: 0x06001B28 RID: 6952 RVA: 0x0006BBD8 File Offset: 0x00069DD8
	private void uLink_OnNetworkInstantiate(global::uLink.NetworkMessageInfo info)
	{
		global::uLink.NetworkView networkView = info.networkView;
		this.groupID = info.networkView.group;
		this.center = global::CullGrid.Flat(networkView.position);
		this.size = networkView.position.y;
		this.extent = this.size / 2f;
		ushort num;
		ushort num2;
		global::CullGrid.CellFromGroupID(this.groupID, out num, out num2);
		base.name = string.Format("GRID-CELL:{0:00000}-[{1},{2}]", this.groupID, num, num2);
		this.y_mc = global::CullCell.HeightCast(this.center);
		this.y_xy = global::CullCell.HeightCast(new global::UnityEngine.Vector2(this.center.x - this.extent, this.center.y - this.extent));
		this.y_XY = global::CullCell.HeightCast(new global::UnityEngine.Vector2(this.center.x + this.extent, this.center.y + this.extent));
		this.y_Xy = global::CullCell.HeightCast(new global::UnityEngine.Vector2(this.center.x + this.extent, this.center.y - this.extent));
		this.y_xY = global::CullCell.HeightCast(new global::UnityEngine.Vector2(this.center.x - this.extent, this.center.y + this.extent));
		this.y_xc = global::CullCell.HeightCast(new global::UnityEngine.Vector2(this.center.x - this.extent, this.center.y));
		this.y_Xc = global::CullCell.HeightCast(new global::UnityEngine.Vector2(this.center.x + this.extent, this.center.y));
		this.y_my = global::CullCell.HeightCast(new global::UnityEngine.Vector2(this.center.x, this.center.y - this.extent));
		this.y_mY = global::CullCell.HeightCast(new global::UnityEngine.Vector2(this.center.x, this.center.y + this.extent));
		base.transform.position = new global::UnityEngine.Vector3(this.center.x, this.y_mc, this.center.y);
		float num3 = global::UnityEngine.Mathf.Min(new float[]
		{
			this.y_xy,
			this.y_XY,
			this.y_Xy,
			this.y_xY,
			this.y_xc,
			this.y_Xc,
			this.y_my,
			this.y_mY,
			this.y_mc
		});
		float num4 = global::UnityEngine.Mathf.Max(new float[]
		{
			this.y_xy,
			this.y_XY,
			this.y_Xy,
			this.y_xY,
			this.y_xc,
			this.y_Xc,
			this.y_my,
			this.y_mY,
			this.y_mc
		});
		float num5 = num4 - num3;
		this.bounds = new global::UnityEngine.Bounds(new global::UnityEngine.Vector3(this.center.x, num3 + num5 * 0.5f, this.center.y), new global::UnityEngine.Vector3(this.size, num5, this.size));
		foreach (object obj in base.transform)
		{
			global::UnityEngine.Transform transform = (global::UnityEngine.Transform)obj;
			global::UnityEngine.Object.Destroy(transform.gameObject);
		}
	}

	// Token: 0x1700077E RID: 1918
	// (get) Token: 0x06001B29 RID: 6953 RVA: 0x0006BFA8 File Offset: 0x0006A1A8
	public static global::UnityEngine.Quaternion instantiateRotation
	{
		get
		{
			return new global::UnityEngine.Quaternion(0f, 0.7071068f, 0.7071068f, --0f);
		}
	}

	// Token: 0x06001B2A RID: 6954 RVA: 0x0006BFC4 File Offset: 0x0006A1C4
	private void OnGUI()
	{
		if (global::UnityEngine.Event.current.type != 7)
		{
			return;
		}
		global::UnityEngine.Vector3 position = this.t_mc.position;
		global::UnityEngine.Camera main = global::UnityEngine.Camera.main;
		if (main)
		{
			global::UnityEngine.Vector3 vector = main.WorldToScreenPoint(position);
			if (vector.z > 0f && vector.z < 150f)
			{
				global::UnityEngine.Vector2 vector2 = global::UnityEngine.GUIUtility.ScreenToGUIPoint(vector);
				vector2.y = (float)global::UnityEngine.Screen.height - (vector2.y + 1f);
				if (vector.z > 10f)
				{
					global::UnityEngine.GUI.color *= new global::UnityEngine.Color(1f, 1f, 1f, 1f - (vector.z - 10f) / 140f);
				}
				global::UnityEngine.Rect rect;
				rect..ctor(vector2.x - 64f, vector2.y - 12f, 128f, 24f);
				if (string.IsNullOrEmpty(this.groupString))
				{
					this.groupString = base.networkView.group.ToString();
				}
				global::UnityEngine.GUI.Label(rect, this.groupString);
			}
		}
	}

	// Token: 0x04000FDE RID: 4062
	private const float kMaxDistance = 150f;

	// Token: 0x04000FDF RID: 4063
	private const float kFadeDistance = 10f;

	// Token: 0x04000FE0 RID: 4064
	[global::System.NonSerialized]
	public int groupID;

	// Token: 0x04000FE1 RID: 4065
	[global::System.NonSerialized]
	public global::UnityEngine.Vector2 center;

	// Token: 0x04000FE2 RID: 4066
	[global::System.NonSerialized]
	public float extent;

	// Token: 0x04000FE3 RID: 4067
	[global::System.NonSerialized]
	public float size;

	// Token: 0x04000FE4 RID: 4068
	[global::System.NonSerialized]
	public float y_xy;

	// Token: 0x04000FE5 RID: 4069
	[global::System.NonSerialized]
	public float y_Xy;

	// Token: 0x04000FE6 RID: 4070
	[global::System.NonSerialized]
	public float y_xY;

	// Token: 0x04000FE7 RID: 4071
	[global::System.NonSerialized]
	public float y_XY;

	// Token: 0x04000FE8 RID: 4072
	[global::System.NonSerialized]
	public float y_mc;

	// Token: 0x04000FE9 RID: 4073
	[global::System.NonSerialized]
	public float y_my;

	// Token: 0x04000FEA RID: 4074
	[global::System.NonSerialized]
	public float y_mY;

	// Token: 0x04000FEB RID: 4075
	[global::System.NonSerialized]
	public float y_xc;

	// Token: 0x04000FEC RID: 4076
	[global::System.NonSerialized]
	public float y_Xc;

	// Token: 0x04000FED RID: 4077
	[global::System.NonSerialized]
	public global::UnityEngine.Bounds bounds;

	// Token: 0x04000FEE RID: 4078
	[global::System.NonSerialized]
	private global::UnityEngine.Transform t_xy;

	// Token: 0x04000FEF RID: 4079
	[global::System.NonSerialized]
	private global::UnityEngine.Transform t_XY;

	// Token: 0x04000FF0 RID: 4080
	[global::System.NonSerialized]
	private global::UnityEngine.Transform t_Xy;

	// Token: 0x04000FF1 RID: 4081
	[global::System.NonSerialized]
	private global::UnityEngine.Transform t_xY;

	// Token: 0x04000FF2 RID: 4082
	[global::System.NonSerialized]
	private global::UnityEngine.Transform t_xc;

	// Token: 0x04000FF3 RID: 4083
	[global::System.NonSerialized]
	private global::UnityEngine.Transform t_Xc;

	// Token: 0x04000FF4 RID: 4084
	[global::System.NonSerialized]
	private global::UnityEngine.Transform t_my;

	// Token: 0x04000FF5 RID: 4085
	[global::System.NonSerialized]
	private global::UnityEngine.Transform t_mY;

	// Token: 0x04000FF6 RID: 4086
	[global::System.NonSerialized]
	private global::UnityEngine.Transform t_mc;

	// Token: 0x04000FF7 RID: 4087
	private string groupString;

	// Token: 0x0200032B RID: 811
	private static class g
	{
		// Token: 0x06001B2B RID: 6955 RVA: 0x0006C100 File Offset: 0x0006A300
		static g()
		{
		}

		// Token: 0x04000FF8 RID: 4088
		public static readonly int terrainMask = 1 << global::UnityEngine.LayerMask.NameToLayer("Terrain");
	}
}
