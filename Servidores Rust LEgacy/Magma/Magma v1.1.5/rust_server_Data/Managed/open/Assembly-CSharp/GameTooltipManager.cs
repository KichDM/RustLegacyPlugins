using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200050E RID: 1294
public class GameTooltipManager : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002C46 RID: 11334 RVA: 0x000A6E28 File Offset: 0x000A5028
	public GameTooltipManager()
	{
	}

	// Token: 0x06002C47 RID: 11335 RVA: 0x000A6E3C File Offset: 0x000A503C
	// Note: this type is marked as 'beforefieldinit'.
	static GameTooltipManager()
	{
	}

	// Token: 0x06002C48 RID: 11336 RVA: 0x000A6E40 File Offset: 0x000A5040
	private void Start()
	{
		global::GameTooltipManager.Singleton = this;
		for (int i = 0; i < 0x10; i++)
		{
			global::GameTooltipManager.TooltipContainer tooltipContainer = new global::GameTooltipManager.TooltipContainer();
			global::UnityEngine.GameObject gameObject = (global::UnityEngine.GameObject)global::UnityEngine.Object.Instantiate(this.tooltipPrefab);
			gameObject.transform.parent = base.transform;
			tooltipContainer.tooltip = gameObject.GetComponent<global::dfControl>();
			tooltipContainer.tooltip_label = gameObject.GetComponent<global::dfLabel>();
			tooltipContainer.lastSeen = 0;
			this.tooltips.Add(tooltipContainer);
		}
	}

	// Token: 0x06002C49 RID: 11337 RVA: 0x000A6EBC File Offset: 0x000A50BC
	private void Update()
	{
		float num = (float)(global::UnityEngine.Time.frameCount - 3);
		foreach (global::GameTooltipManager.TooltipContainer tooltipContainer in this.tooltips)
		{
			if ((float)tooltipContainer.lastSeen <= num)
			{
				if (tooltipContainer.tooltip.IsVisible)
				{
					tooltipContainer.tooltip.Hide();
				}
			}
		}
	}

	// Token: 0x06002C4A RID: 11338 RVA: 0x000A6F58 File Offset: 0x000A5158
	protected global::GameTooltipManager.TooltipContainer GetTipContainer(global::UnityEngine.GameObject obj)
	{
		int num = global::UnityEngine.Time.frameCount - 3;
		foreach (global::GameTooltipManager.TooltipContainer tooltipContainer in this.tooltips)
		{
			if (tooltipContainer.lastSeen >= num)
			{
				if (tooltipContainer.target == obj)
				{
					return tooltipContainer;
				}
			}
		}
		foreach (global::GameTooltipManager.TooltipContainer tooltipContainer2 in this.tooltips)
		{
			if (tooltipContainer2.target == null)
			{
				return tooltipContainer2;
			}
			if (tooltipContainer2.lastSeen < num)
			{
				return tooltipContainer2;
			}
		}
		return null;
	}

	// Token: 0x06002C4B RID: 11339 RVA: 0x000A706C File Offset: 0x000A526C
	public void UpdateTip(global::UnityEngine.GameObject obj, string text, global::UnityEngine.Vector3 vPosition, global::UnityEngine.Color color, float alpha, float fscale)
	{
		global::GameTooltipManager.TooltipContainer tipContainer = this.GetTipContainer(obj);
		if (tipContainer == null)
		{
			return;
		}
		if (!tipContainer.tooltip.IsVisible)
		{
			tipContainer.tooltip.Show();
		}
		global::dfGUIManager manager = tipContainer.tooltip.GetManager();
		global::UnityEngine.Vector2 screenSize = manager.GetScreenSize();
		global::UnityEngine.Camera renderCamera = manager.RenderCamera;
		global::UnityEngine.Camera main = global::UnityEngine.Camera.main;
		global::UnityEngine.Vector3 vector = global::UnityEngine.Camera.main.WorldToScreenPoint(vPosition);
		vector.x = screenSize.x * (vector.x / main.pixelWidth);
		vector.y = screenSize.y * (vector.y / main.pixelHeight);
		vector = manager.ScreenToGui(vector);
		vector.x -= tipContainer.tooltip.Width / 2f * tipContainer.tooltip.transform.localScale.x;
		vector.y -= tipContainer.tooltip.Height * tipContainer.tooltip.transform.localScale.y;
		tipContainer.tooltip.RelativePosition = vector;
		tipContainer.tooltip_label.Text = text;
		tipContainer.tooltip_label.Color = color;
		tipContainer.tooltip.Opacity = alpha;
		tipContainer.lastSeen = global::UnityEngine.Time.frameCount;
		tipContainer.target = obj;
		tipContainer.tooltip.transform.localScale = new global::UnityEngine.Vector3(fscale, fscale, fscale);
	}

	// Token: 0x04001697 RID: 5783
	public static global::GameTooltipManager Singleton;

	// Token: 0x04001698 RID: 5784
	public global::UnityEngine.GameObject tooltipPrefab;

	// Token: 0x04001699 RID: 5785
	protected global::System.Collections.Generic.List<global::GameTooltipManager.TooltipContainer> tooltips = new global::System.Collections.Generic.List<global::GameTooltipManager.TooltipContainer>();

	// Token: 0x0200050F RID: 1295
	protected class TooltipContainer
	{
		// Token: 0x06002C4C RID: 11340 RVA: 0x000A71F4 File Offset: 0x000A53F4
		public TooltipContainer()
		{
		}

		// Token: 0x0400169A RID: 5786
		public global::UnityEngine.GameObject target;

		// Token: 0x0400169B RID: 5787
		public global::dfControl tooltip;

		// Token: 0x0400169C RID: 5788
		public global::dfLabel tooltip_label;

		// Token: 0x0400169D RID: 5789
		public int lastSeen;
	}
}
