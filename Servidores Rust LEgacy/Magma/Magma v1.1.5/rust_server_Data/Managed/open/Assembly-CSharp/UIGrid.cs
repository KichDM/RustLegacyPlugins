using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020008C6 RID: 2246
[global::UnityEngine.AddComponentMenu("NGUI/Interaction/Grid")]
[global::UnityEngine.ExecuteInEditMode]
public class UIGrid : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004D63 RID: 19811 RVA: 0x00127270 File Offset: 0x00125470
	public UIGrid()
	{
	}

	// Token: 0x06004D64 RID: 19812 RVA: 0x00127298 File Offset: 0x00125498
	private void Start()
	{
		this.mStarted = true;
		this.Reposition();
	}

	// Token: 0x06004D65 RID: 19813 RVA: 0x001272A8 File Offset: 0x001254A8
	private void Update()
	{
		if (this.repositionNow)
		{
			this.repositionNow = false;
			this.Reposition();
		}
	}

	// Token: 0x06004D66 RID: 19814 RVA: 0x001272C4 File Offset: 0x001254C4
	public static int SortByName(global::UnityEngine.Transform a, global::UnityEngine.Transform b)
	{
		return string.Compare(a.name, b.name);
	}

	// Token: 0x06004D67 RID: 19815 RVA: 0x001272D8 File Offset: 0x001254D8
	public void Reposition()
	{
		if (!this.mStarted)
		{
			this.repositionNow = true;
			return;
		}
		global::UnityEngine.Transform transform = base.transform;
		int num = 0;
		int num2 = 0;
		if (this.sorted)
		{
			global::System.Collections.Generic.List<global::UnityEngine.Transform> list = new global::System.Collections.Generic.List<global::UnityEngine.Transform>();
			for (int i = 0; i < transform.childCount; i++)
			{
				global::UnityEngine.Transform child = transform.GetChild(i);
				if (child)
				{
					list.Add(child);
				}
			}
			list.Sort(new global::System.Comparison<global::UnityEngine.Transform>(global::UIGrid.SortByName));
			int j = 0;
			int count = list.Count;
			while (j < count)
			{
				global::UnityEngine.Transform transform2 = list[j];
				if (transform2.gameObject.activeInHierarchy || !this.hideInactive)
				{
					float z = transform2.localPosition.z;
					transform2.localPosition = ((this.arrangement != global::UIGrid.Arrangement.Horizontal) ? new global::UnityEngine.Vector3(this.cellWidth * (float)num2, -this.cellHeight * (float)num, z) : new global::UnityEngine.Vector3(this.cellWidth * (float)num, -this.cellHeight * (float)num2, z));
					if (++num >= this.maxPerLine && this.maxPerLine > 0)
					{
						num = 0;
						num2++;
					}
				}
				j++;
			}
		}
		else
		{
			for (int k = 0; k < transform.childCount; k++)
			{
				global::UnityEngine.Transform child2 = transform.GetChild(k);
				if (child2.gameObject.activeInHierarchy || !this.hideInactive)
				{
					float z2 = child2.localPosition.z;
					child2.localPosition = ((this.arrangement != global::UIGrid.Arrangement.Horizontal) ? new global::UnityEngine.Vector3(this.cellWidth * (float)num2, -this.cellHeight * (float)num, z2) : new global::UnityEngine.Vector3(this.cellWidth * (float)num, -this.cellHeight * (float)num2, z2));
					if (++num >= this.maxPerLine && this.maxPerLine > 0)
					{
						num = 0;
						num2++;
					}
				}
			}
		}
		global::UIDraggablePanel uidraggablePanel = global::NGUITools.FindInParents<global::UIDraggablePanel>(base.gameObject);
		if (uidraggablePanel != null)
		{
			uidraggablePanel.UpdateScrollbars(true);
		}
	}

	// Token: 0x04002A52 RID: 10834
	public global::UIGrid.Arrangement arrangement;

	// Token: 0x04002A53 RID: 10835
	public int maxPerLine;

	// Token: 0x04002A54 RID: 10836
	public float cellWidth = 200f;

	// Token: 0x04002A55 RID: 10837
	public float cellHeight = 200f;

	// Token: 0x04002A56 RID: 10838
	public bool repositionNow;

	// Token: 0x04002A57 RID: 10839
	public bool sorted;

	// Token: 0x04002A58 RID: 10840
	public bool hideInactive = true;

	// Token: 0x04002A59 RID: 10841
	private bool mStarted;

	// Token: 0x020008C7 RID: 2247
	public enum Arrangement
	{
		// Token: 0x04002A5B RID: 10843
		Horizontal,
		// Token: 0x04002A5C RID: 10844
		Vertical
	}
}
