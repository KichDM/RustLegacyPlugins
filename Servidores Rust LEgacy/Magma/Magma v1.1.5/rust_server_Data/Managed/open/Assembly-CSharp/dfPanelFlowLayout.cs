using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000829 RID: 2089
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/Panel Addon/Flow Layout")]
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::dfPanel))]
public class dfPanelFlowLayout : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060046F6 RID: 18166 RVA: 0x00105780 File Offset: 0x00103980
	public dfPanelFlowLayout()
	{
	}

	// Token: 0x17000D39 RID: 3385
	// (get) Token: 0x060046F7 RID: 18167 RVA: 0x001057B0 File Offset: 0x001039B0
	// (set) Token: 0x060046F8 RID: 18168 RVA: 0x001057B8 File Offset: 0x001039B8
	public global::dfControlOrientation Direction
	{
		get
		{
			return this.flowDirection;
		}
		set
		{
			if (value != this.flowDirection)
			{
				this.flowDirection = value;
				this.performLayout();
			}
		}
	}

	// Token: 0x17000D3A RID: 3386
	// (get) Token: 0x060046F9 RID: 18169 RVA: 0x001057D4 File Offset: 0x001039D4
	// (set) Token: 0x060046FA RID: 18170 RVA: 0x001057DC File Offset: 0x001039DC
	public global::UnityEngine.Vector2 ItemSpacing
	{
		get
		{
			return this.itemSpacing;
		}
		set
		{
			value = global::UnityEngine.Vector2.Max(value, global::UnityEngine.Vector2.zero);
			if (!object.Equals(value, this.itemSpacing))
			{
				this.itemSpacing = value;
				this.performLayout();
			}
		}
	}

	// Token: 0x17000D3B RID: 3387
	// (get) Token: 0x060046FB RID: 18171 RVA: 0x00105814 File Offset: 0x00103A14
	// (set) Token: 0x060046FC RID: 18172 RVA: 0x00105834 File Offset: 0x00103A34
	public global::UnityEngine.RectOffset BorderPadding
	{
		get
		{
			if (this.borderPadding == null)
			{
				this.borderPadding = new global::UnityEngine.RectOffset();
			}
			return this.borderPadding;
		}
		set
		{
			value = value.ConstrainPadding();
			if (!object.Equals(value, this.borderPadding))
			{
				this.borderPadding = value;
				this.performLayout();
			}
		}
	}

	// Token: 0x17000D3C RID: 3388
	// (get) Token: 0x060046FD RID: 18173 RVA: 0x00105868 File Offset: 0x00103A68
	// (set) Token: 0x060046FE RID: 18174 RVA: 0x00105870 File Offset: 0x00103A70
	public bool HideClippedControls
	{
		get
		{
			return this.hideClippedControls;
		}
		set
		{
			if (value != this.hideClippedControls)
			{
				this.hideClippedControls = value;
				this.performLayout();
			}
		}
	}

	// Token: 0x060046FF RID: 18175 RVA: 0x0010588C File Offset: 0x00103A8C
	public void OnEnable()
	{
		this.panel = base.GetComponent<global::dfPanel>();
		this.panel.SizeChanged += this.OnSizeChanged;
	}

	// Token: 0x06004700 RID: 18176 RVA: 0x001058B4 File Offset: 0x00103AB4
	public void OnControlAdded(global::dfControl container, global::dfControl child)
	{
		child.ZOrderChanged += this.child_ZOrderChanged;
		child.SizeChanged += this.child_SizeChanged;
		this.performLayout();
	}

	// Token: 0x06004701 RID: 18177 RVA: 0x001058EC File Offset: 0x00103AEC
	public void OnControlRemoved(global::dfControl container, global::dfControl child)
	{
		child.ZOrderChanged -= this.child_ZOrderChanged;
		child.SizeChanged -= this.child_SizeChanged;
		this.performLayout();
	}

	// Token: 0x06004702 RID: 18178 RVA: 0x00105924 File Offset: 0x00103B24
	public void OnSizeChanged(global::dfControl control, global::UnityEngine.Vector2 value)
	{
		this.performLayout();
	}

	// Token: 0x06004703 RID: 18179 RVA: 0x0010592C File Offset: 0x00103B2C
	private void child_SizeChanged(global::dfControl control, global::UnityEngine.Vector2 value)
	{
		this.performLayout();
	}

	// Token: 0x06004704 RID: 18180 RVA: 0x00105934 File Offset: 0x00103B34
	private void child_ZOrderChanged(global::dfControl control, int value)
	{
		this.performLayout();
	}

	// Token: 0x06004705 RID: 18181 RVA: 0x0010593C File Offset: 0x00103B3C
	private void performLayout()
	{
		if (this.panel == null)
		{
			this.panel = base.GetComponent<global::dfPanel>();
		}
		global::UnityEngine.Vector3 relativePosition;
		relativePosition..ctor((float)this.borderPadding.left, (float)this.borderPadding.top);
		bool flag = true;
		float num = this.panel.Width - (float)this.borderPadding.right;
		float num2 = this.panel.Height - (float)this.borderPadding.bottom;
		int num3 = 0;
		global::System.Collections.Generic.IList<global::dfControl> controls = this.panel.Controls;
		int i = 0;
		while (i < controls.Count)
		{
			if (!flag)
			{
				if (this.flowDirection == global::dfControlOrientation.Horizontal)
				{
					relativePosition.x += this.itemSpacing.x;
				}
				else
				{
					relativePosition.y += this.itemSpacing.y;
				}
			}
			global::dfControl dfControl = controls[i];
			if (this.flowDirection == global::dfControlOrientation.Horizontal)
			{
				if (!flag && relativePosition.x + dfControl.Width >= num)
				{
					relativePosition.x = (float)this.borderPadding.left;
					relativePosition.y += (float)num3;
					num3 = 0;
				}
			}
			else if (!flag && relativePosition.y + dfControl.Height >= num2)
			{
				relativePosition.y = (float)this.borderPadding.top;
				relativePosition.x += (float)num3;
				num3 = 0;
			}
			dfControl.RelativePosition = relativePosition;
			if (this.flowDirection == global::dfControlOrientation.Horizontal)
			{
				relativePosition.x += dfControl.Width;
				num3 = global::UnityEngine.Mathf.Max(global::UnityEngine.Mathf.CeilToInt(dfControl.Height + this.itemSpacing.y), num3);
			}
			else
			{
				relativePosition.y += dfControl.Height;
				num3 = global::UnityEngine.Mathf.Max(global::UnityEngine.Mathf.CeilToInt(dfControl.Width + this.itemSpacing.x), num3);
			}
			dfControl.IsVisible = this.canShowControlUnclipped(dfControl);
			i++;
			flag = false;
		}
	}

	// Token: 0x06004706 RID: 18182 RVA: 0x00105B68 File Offset: 0x00103D68
	private bool canShowControlUnclipped(global::dfControl control)
	{
		if (!this.hideClippedControls)
		{
			return true;
		}
		global::UnityEngine.Vector3 relativePosition = control.RelativePosition;
		return relativePosition.x + control.Width < this.panel.Width - (float)this.borderPadding.right && relativePosition.y + control.Height < this.panel.Height - (float)this.borderPadding.bottom;
	}

	// Token: 0x04002643 RID: 9795
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.RectOffset borderPadding = new global::UnityEngine.RectOffset();

	// Token: 0x04002644 RID: 9796
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Vector2 itemSpacing = default(global::UnityEngine.Vector2);

	// Token: 0x04002645 RID: 9797
	[global::UnityEngine.SerializeField]
	protected global::dfControlOrientation flowDirection;

	// Token: 0x04002646 RID: 9798
	[global::UnityEngine.SerializeField]
	protected bool hideClippedControls;

	// Token: 0x04002647 RID: 9799
	private global::dfPanel panel;
}
