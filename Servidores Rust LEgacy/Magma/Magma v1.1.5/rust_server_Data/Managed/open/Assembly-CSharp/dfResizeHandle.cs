using System;
using UnityEngine;

// Token: 0x0200082D RID: 2093
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/Resize Handle")]
[global::UnityEngine.ExecuteInEditMode]
public class dfResizeHandle : global::dfControl
{
	// Token: 0x06004756 RID: 18262 RVA: 0x00107260 File Offset: 0x00105460
	public dfResizeHandle()
	{
	}

	// Token: 0x17000D53 RID: 3411
	// (get) Token: 0x06004757 RID: 18263 RVA: 0x0010727C File Offset: 0x0010547C
	// (set) Token: 0x06004758 RID: 18264 RVA: 0x001072C4 File Offset: 0x001054C4
	public global::dfAtlas Atlas
	{
		get
		{
			if (this.atlas == null)
			{
				global::dfGUIManager manager = base.GetManager();
				if (manager != null)
				{
					return this.atlas = manager.DefaultAtlas;
				}
			}
			return this.atlas;
		}
		set
		{
			if (!global::dfAtlas.Equals(value, this.atlas))
			{
				this.atlas = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D54 RID: 3412
	// (get) Token: 0x06004759 RID: 18265 RVA: 0x001072E4 File Offset: 0x001054E4
	// (set) Token: 0x0600475A RID: 18266 RVA: 0x001072EC File Offset: 0x001054EC
	public string BackgroundSprite
	{
		get
		{
			return this.backgroundSprite;
		}
		set
		{
			if (value != this.backgroundSprite)
			{
				this.backgroundSprite = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D55 RID: 3413
	// (get) Token: 0x0600475B RID: 18267 RVA: 0x0010730C File Offset: 0x0010550C
	// (set) Token: 0x0600475C RID: 18268 RVA: 0x00107314 File Offset: 0x00105514
	public global::dfResizeHandle.ResizeEdge Edges
	{
		get
		{
			return this.edges;
		}
		set
		{
			this.edges = value;
		}
	}

	// Token: 0x0600475D RID: 18269 RVA: 0x00107320 File Offset: 0x00105520
	public override void Start()
	{
		base.Start();
		if (base.Size.magnitude <= 1E-45f)
		{
			base.Size = new global::UnityEngine.Vector2(25f, 25f);
			if (base.Parent != null)
			{
				base.RelativePosition = base.Parent.Size - base.Size;
				base.Anchor = (global::dfAnchorStyle.Bottom | global::dfAnchorStyle.Right);
			}
		}
	}

	// Token: 0x0600475E RID: 18270 RVA: 0x0010739C File Offset: 0x0010559C
	protected override void OnRebuildRenderData()
	{
		if (this.Atlas == null || string.IsNullOrEmpty(this.backgroundSprite))
		{
			return;
		}
		global::dfAtlas.ItemInfo itemInfo = this.Atlas[this.backgroundSprite];
		if (itemInfo == null)
		{
			return;
		}
		this.renderData.Material = this.Atlas.Material;
		global::UnityEngine.Color32 color = base.ApplyOpacity((!base.IsEnabled) ? this.disabledColor : this.color);
		global::dfSprite.RenderOptions options = new global::dfSprite.RenderOptions
		{
			atlas = this.atlas,
			color = color,
			fillAmount = 1f,
			offset = this.pivot.TransformToUpperLeft(base.Size),
			pixelsToUnits = base.PixelsToUnits(),
			size = base.Size,
			spriteInfo = itemInfo
		};
		if (itemInfo.border.horizontal == 0 && itemInfo.border.vertical == 0)
		{
			global::dfSprite.renderSprite(this.renderData, options);
		}
		else
		{
			global::dfSlicedSprite.renderSprite(this.renderData, options);
		}
	}

	// Token: 0x0600475F RID: 18271 RVA: 0x001074C8 File Offset: 0x001056C8
	protected internal override void OnMouseDown(global::dfMouseEventArgs args)
	{
		args.Use();
		global::UnityEngine.Plane plane;
		plane..ctor(this.parent.transform.TransformDirection(global::UnityEngine.Vector3.back), this.parent.transform.position);
		global::UnityEngine.Ray ray = args.Ray;
		float num = 0f;
		plane.Raycast(args.Ray, ref num);
		this.mouseAnchorPos = ray.origin + ray.direction * num;
		this.startSize = this.parent.Size;
		this.startPosition = this.parent.RelativePosition;
		this.minEdgePos = this.startPosition;
		this.maxEdgePos = this.startPosition + this.startSize;
		global::UnityEngine.Vector2 vector = this.parent.CalculateMinimumSize();
		global::UnityEngine.Vector2 vector2 = this.parent.MaximumSize;
		if (vector2.magnitude <= 1E-45f)
		{
			vector2 = global::UnityEngine.Vector2.one * 2048f;
		}
		if ((this.Edges & global::dfResizeHandle.ResizeEdge.Left) == global::dfResizeHandle.ResizeEdge.Left)
		{
			this.minEdgePos.x = this.maxEdgePos.x - vector2.x;
			this.maxEdgePos.x = this.maxEdgePos.x - vector.x;
		}
		else if ((this.Edges & global::dfResizeHandle.ResizeEdge.Right) == global::dfResizeHandle.ResizeEdge.Right)
		{
			this.minEdgePos.x = this.startPosition.x + vector.x;
			this.maxEdgePos.x = this.startPosition.x + vector2.x;
		}
		if ((this.Edges & global::dfResizeHandle.ResizeEdge.Top) == global::dfResizeHandle.ResizeEdge.Top)
		{
			this.minEdgePos.y = this.maxEdgePos.y - vector2.y;
			this.maxEdgePos.y = this.maxEdgePos.y - vector.y;
		}
		else if ((this.Edges & global::dfResizeHandle.ResizeEdge.Bottom) == global::dfResizeHandle.ResizeEdge.Bottom)
		{
			this.minEdgePos.y = this.startPosition.y + vector.y;
			this.maxEdgePos.y = this.startPosition.y + vector2.y;
		}
	}

	// Token: 0x06004760 RID: 18272 RVA: 0x00107700 File Offset: 0x00105900
	protected internal override void OnMouseMove(global::dfMouseEventArgs args)
	{
		if (!args.Buttons.IsSet(global::dfMouseButtons.Left) || this.Edges == global::dfResizeHandle.ResizeEdge.None)
		{
			return;
		}
		args.Use();
		global::UnityEngine.Ray ray = args.Ray;
		float num = 0f;
		global::UnityEngine.Vector3 vector = base.GetCamera().transform.TransformDirection(global::UnityEngine.Vector3.back);
		global::UnityEngine.Plane plane;
		plane..ctor(vector, this.mouseAnchorPos);
		plane.Raycast(ray, ref num);
		float num2 = base.PixelsToUnits();
		global::UnityEngine.Vector3 vector2 = ray.origin + ray.direction * num;
		global::UnityEngine.Vector3 vector3 = (vector2 - this.mouseAnchorPos) / num2;
		vector3.y *= -1f;
		float num3 = this.startPosition.x;
		float num4 = this.startPosition.y;
		float num5 = num3 + this.startSize.x;
		float num6 = num4 + this.startSize.y;
		if ((this.Edges & global::dfResizeHandle.ResizeEdge.Left) == global::dfResizeHandle.ResizeEdge.Left)
		{
			num3 = global::UnityEngine.Mathf.Min(this.maxEdgePos.x, global::UnityEngine.Mathf.Max(this.minEdgePos.x, num3 + vector3.x));
		}
		else if ((this.Edges & global::dfResizeHandle.ResizeEdge.Right) == global::dfResizeHandle.ResizeEdge.Right)
		{
			num5 = global::UnityEngine.Mathf.Min(this.maxEdgePos.x, global::UnityEngine.Mathf.Max(this.minEdgePos.x, num5 + vector3.x));
		}
		if ((this.Edges & global::dfResizeHandle.ResizeEdge.Top) == global::dfResizeHandle.ResizeEdge.Top)
		{
			num4 = global::UnityEngine.Mathf.Min(this.maxEdgePos.y, global::UnityEngine.Mathf.Max(this.minEdgePos.y, num4 + vector3.y));
		}
		else if ((this.Edges & global::dfResizeHandle.ResizeEdge.Bottom) == global::dfResizeHandle.ResizeEdge.Bottom)
		{
			num6 = global::UnityEngine.Mathf.Min(this.maxEdgePos.y, global::UnityEngine.Mathf.Max(this.minEdgePos.y, num6 + vector3.y));
		}
		this.parent.Size = new global::UnityEngine.Vector2(num5 - num3, num6 - num4);
		this.parent.RelativePosition = new global::UnityEngine.Vector3(num3, num4, 0f);
		if (this.parent.GetManager().PixelPerfectMode)
		{
			this.parent.MakePixelPerfect(true);
		}
	}

	// Token: 0x06004761 RID: 18273 RVA: 0x00107938 File Offset: 0x00105B38
	protected internal override void OnMouseUp(global::dfMouseEventArgs args)
	{
		base.Parent.MakePixelPerfect(true);
		args.Use();
		base.OnMouseUp(args);
	}

	// Token: 0x04002661 RID: 9825
	[global::UnityEngine.SerializeField]
	protected global::dfAtlas atlas;

	// Token: 0x04002662 RID: 9826
	[global::UnityEngine.SerializeField]
	protected string backgroundSprite = string.Empty;

	// Token: 0x04002663 RID: 9827
	[global::UnityEngine.SerializeField]
	protected global::dfResizeHandle.ResizeEdge edges = global::dfResizeHandle.ResizeEdge.Right | global::dfResizeHandle.ResizeEdge.Bottom;

	// Token: 0x04002664 RID: 9828
	private global::UnityEngine.Vector3 mouseAnchorPos;

	// Token: 0x04002665 RID: 9829
	private global::UnityEngine.Vector3 startPosition;

	// Token: 0x04002666 RID: 9830
	private global::UnityEngine.Vector2 startSize;

	// Token: 0x04002667 RID: 9831
	private global::UnityEngine.Vector2 minEdgePos;

	// Token: 0x04002668 RID: 9832
	private global::UnityEngine.Vector2 maxEdgePos;

	// Token: 0x0200082E RID: 2094
	[global::System.Flags]
	public enum ResizeEdge
	{
		// Token: 0x0400266A RID: 9834
		None = 0,
		// Token: 0x0400266B RID: 9835
		Left = 1,
		// Token: 0x0400266C RID: 9836
		Right = 2,
		// Token: 0x0400266D RID: 9837
		Top = 4,
		// Token: 0x0400266E RID: 9838
		Bottom = 8
	}
}
