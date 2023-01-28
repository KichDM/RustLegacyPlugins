using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020008D4 RID: 2260
[global::UnityEngine.AddComponentMenu("NGUI/Interaction/Table")]
[global::UnityEngine.ExecuteInEditMode]
public class UITable : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004DB6 RID: 19894 RVA: 0x001299B8 File Offset: 0x00127BB8
	public UITable()
	{
	}

	// Token: 0x06004DB7 RID: 19895 RVA: 0x001299D4 File Offset: 0x00127BD4
	public static int SortByName(global::UnityEngine.Transform a, global::UnityEngine.Transform b)
	{
		return string.Compare(a.name, b.name);
	}

	// Token: 0x06004DB8 RID: 19896 RVA: 0x001299E8 File Offset: 0x00127BE8
	private void RepositionVariableSize(global::System.Collections.Generic.List<global::UnityEngine.Transform> children)
	{
		float num = 0f;
		float num2 = 0f;
		int num3 = (this.columns <= 0) ? 1 : (children.Count / this.columns + 1);
		int num4 = (this.columns <= 0) ? children.Count : this.columns;
		global::AABBox[,] array = new global::AABBox[num3, num4];
		global::AABBox[] array2 = new global::AABBox[num4];
		global::AABBox[] array3 = new global::AABBox[num3];
		int num5 = 0;
		int num6 = 0;
		int i = 0;
		int count = children.Count;
		while (i < count)
		{
			global::UnityEngine.Transform transform = children[i];
			global::AABBox aabbox = global::NGUIMath.CalculateRelativeWidgetBounds(transform);
			global::UnityEngine.Vector3 localScale = transform.localScale;
			aabbox.SetMinMax(global::UnityEngine.Vector3.Scale(aabbox.min, localScale), global::UnityEngine.Vector3.Scale(aabbox.max, localScale));
			array[num6, num5] = aabbox;
			array2[num5].Encapsulate(aabbox);
			array3[num6].Encapsulate(aabbox);
			if (++num5 >= this.columns && this.columns > 0)
			{
				num5 = 0;
				num6++;
			}
			i++;
		}
		num5 = 0;
		num6 = 0;
		int j = 0;
		int count2 = children.Count;
		while (j < count2)
		{
			global::UnityEngine.Transform transform2 = children[j];
			global::AABBox aabbox2 = array[num6, num5];
			global::AABBox aabbox3 = array2[num5];
			global::AABBox aabbox4 = array3[num6];
			global::UnityEngine.Vector3 localPosition = transform2.localPosition;
			global::UnityEngine.Vector3 min = aabbox2.min;
			global::UnityEngine.Vector3 max = aabbox2.max;
			global::UnityEngine.Vector3 vector = aabbox2.size * 0.5f;
			global::UnityEngine.Vector3 center = aabbox2.center;
			global::UnityEngine.Vector3 min2 = aabbox4.min;
			global::UnityEngine.Vector3 max2 = aabbox4.max;
			global::UnityEngine.Vector3 min3 = aabbox3.min;
			localPosition.x = num + vector.x - center.x;
			localPosition.x += min.x - min3.x + this.padding.x;
			if (this.direction == global::UITable.Direction.Down)
			{
				localPosition.y = -num2 - vector.y - center.y;
				localPosition.y += (max.y - min.y - max2.y + min2.y) * 0.5f - this.padding.y;
			}
			else
			{
				localPosition.y = num2 + vector.y - center.y;
				localPosition.y += (max.y - min.y - max2.y + min2.y) * 0.5f - this.padding.y;
			}
			num += min3.x - min3.x + this.padding.x * 2f;
			transform2.localPosition = localPosition;
			if (++num5 >= this.columns && this.columns > 0)
			{
				num5 = 0;
				num6++;
				num = 0f;
				num2 += vector.y * 2f + this.padding.y * 2f;
			}
			j++;
		}
	}

	// Token: 0x06004DB9 RID: 19897 RVA: 0x00129D3C File Offset: 0x00127F3C
	public void Reposition()
	{
		if (this.mStarted)
		{
			global::UnityEngine.Transform transform = base.transform;
			global::System.Collections.Generic.List<global::UnityEngine.Transform> list = new global::System.Collections.Generic.List<global::UnityEngine.Transform>();
			for (int i = 0; i < transform.childCount; i++)
			{
				global::UnityEngine.Transform child = transform.GetChild(i);
				if (child && (!this.hideInactive || child.gameObject.activeInHierarchy))
				{
					list.Add(child);
				}
			}
			if (this.sorted)
			{
				list.Sort(new global::System.Comparison<global::UnityEngine.Transform>(global::UITable.SortByName));
			}
			if (list.Count > 0)
			{
				this.RepositionVariableSize(list);
			}
			if (this.mPanel != null && this.mDrag == null)
			{
				this.mPanel.ConstrainTargetToBounds(transform, true);
			}
			if (this.mDrag != null)
			{
				this.mDrag.UpdateScrollbars(true);
			}
		}
		else
		{
			this.repositionNow = true;
		}
	}

	// Token: 0x06004DBA RID: 19898 RVA: 0x00129E38 File Offset: 0x00128038
	private void Start()
	{
		this.mStarted = true;
		if (this.keepWithinPanel)
		{
			this.mPanel = global::NGUITools.FindInParents<global::UIPanel>(base.gameObject);
			this.mDrag = global::NGUITools.FindInParents<global::UIDraggablePanel>(base.gameObject);
		}
		this.Reposition();
	}

	// Token: 0x06004DBB RID: 19899 RVA: 0x00129E80 File Offset: 0x00128080
	private void LateUpdate()
	{
		if (this.repositionNow)
		{
			this.repositionNow = false;
			this.Reposition();
			if (this.onReposition != null)
			{
				this.onReposition();
			}
		}
	}

	// Token: 0x04002AAC RID: 10924
	public int columns;

	// Token: 0x04002AAD RID: 10925
	public global::UITable.Direction direction;

	// Token: 0x04002AAE RID: 10926
	public global::UnityEngine.Vector2 padding = global::UnityEngine.Vector2.zero;

	// Token: 0x04002AAF RID: 10927
	public bool sorted;

	// Token: 0x04002AB0 RID: 10928
	public bool hideInactive = true;

	// Token: 0x04002AB1 RID: 10929
	public bool repositionNow;

	// Token: 0x04002AB2 RID: 10930
	public bool keepWithinPanel;

	// Token: 0x04002AB3 RID: 10931
	public global::UITable.OnReposition onReposition;

	// Token: 0x04002AB4 RID: 10932
	private global::UIPanel mPanel;

	// Token: 0x04002AB5 RID: 10933
	private global::UIDraggablePanel mDrag;

	// Token: 0x04002AB6 RID: 10934
	private bool mStarted;

	// Token: 0x020008D5 RID: 2261
	public enum Direction
	{
		// Token: 0x04002AB8 RID: 10936
		Down,
		// Token: 0x04002AB9 RID: 10937
		Up
	}

	// Token: 0x020008D6 RID: 2262
	// (Invoke) Token: 0x06004DBD RID: 19901
	public delegate void OnReposition();
}
