using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200083E RID: 2110
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/Containers/Tab Control/Tab Page Container")]
[global::UnityEngine.ExecuteInEditMode]
public class dfTabContainer : global::dfControl
{
	// Token: 0x0600485B RID: 18523 RVA: 0x0010D52C File Offset: 0x0010B72C
	public dfTabContainer()
	{
	}

	// Token: 0x14000052 RID: 82
	// (add) Token: 0x0600485C RID: 18524 RVA: 0x0010D540 File Offset: 0x0010B740
	// (remove) Token: 0x0600485D RID: 18525 RVA: 0x0010D55C File Offset: 0x0010B75C
	public event global::PropertyChangedEventHandler<int> SelectedIndexChanged
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.SelectedIndexChanged = (global::PropertyChangedEventHandler<int>)global::System.Delegate.Combine(this.SelectedIndexChanged, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.SelectedIndexChanged = (global::PropertyChangedEventHandler<int>)global::System.Delegate.Remove(this.SelectedIndexChanged, value);
		}
	}

	// Token: 0x17000D8D RID: 3469
	// (get) Token: 0x0600485E RID: 18526 RVA: 0x0010D578 File Offset: 0x0010B778
	// (set) Token: 0x0600485F RID: 18527 RVA: 0x0010D5C0 File Offset: 0x0010B7C0
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

	// Token: 0x17000D8E RID: 3470
	// (get) Token: 0x06004860 RID: 18528 RVA: 0x0010D5E0 File Offset: 0x0010B7E0
	// (set) Token: 0x06004861 RID: 18529 RVA: 0x0010D5E8 File Offset: 0x0010B7E8
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

	// Token: 0x17000D8F RID: 3471
	// (get) Token: 0x06004862 RID: 18530 RVA: 0x0010D608 File Offset: 0x0010B808
	// (set) Token: 0x06004863 RID: 18531 RVA: 0x0010D628 File Offset: 0x0010B828
	public global::UnityEngine.RectOffset Padding
	{
		get
		{
			if (this.padding == null)
			{
				this.padding = new global::UnityEngine.RectOffset();
			}
			return this.padding;
		}
		set
		{
			value = value.ConstrainPadding();
			if (!object.Equals(value, this.padding))
			{
				this.padding = value;
				this.arrangeTabPages();
			}
		}
	}

	// Token: 0x17000D90 RID: 3472
	// (get) Token: 0x06004864 RID: 18532 RVA: 0x0010D65C File Offset: 0x0010B85C
	// (set) Token: 0x06004865 RID: 18533 RVA: 0x0010D664 File Offset: 0x0010B864
	public int SelectedIndex
	{
		get
		{
			return this.selectedIndex;
		}
		set
		{
			if (value != this.selectedIndex)
			{
				this.selectPageByIndex(value);
			}
		}
	}

	// Token: 0x06004866 RID: 18534 RVA: 0x0010D67C File Offset: 0x0010B87C
	public global::dfControl AddTabPage()
	{
		global::dfPanel dfPanel = (from i in this.controls
		where i is global::dfPanel
		select i).FirstOrDefault() as global::dfPanel;
		string name = "Tab Page " + (this.controls.Count + 1);
		global::dfPanel dfPanel2 = base.AddControl<global::dfPanel>();
		dfPanel2.name = name;
		dfPanel2.Atlas = this.Atlas;
		dfPanel2.Anchor = global::dfAnchorStyle.All;
		dfPanel2.ClipChildren = true;
		if (dfPanel != null)
		{
			dfPanel2.Atlas = dfPanel.Atlas;
			dfPanel2.BackgroundSprite = dfPanel.BackgroundSprite;
		}
		this.arrangeTabPages();
		this.Invalidate();
		return dfPanel2;
	}

	// Token: 0x06004867 RID: 18535 RVA: 0x0010D734 File Offset: 0x0010B934
	public override void OnEnable()
	{
		base.OnEnable();
		if (this.size.sqrMagnitude < 1E-45f)
		{
			base.Size = new global::UnityEngine.Vector2(256f, 256f);
		}
	}

	// Token: 0x06004868 RID: 18536 RVA: 0x0010D774 File Offset: 0x0010B974
	protected internal override void OnControlAdded(global::dfControl child)
	{
		base.OnControlAdded(child);
		this.attachEvents(child);
		this.arrangeTabPages();
	}

	// Token: 0x06004869 RID: 18537 RVA: 0x0010D78C File Offset: 0x0010B98C
	protected internal override void OnControlRemoved(global::dfControl child)
	{
		base.OnControlRemoved(child);
		this.detachEvents(child);
		this.arrangeTabPages();
	}

	// Token: 0x0600486A RID: 18538 RVA: 0x0010D7A4 File Offset: 0x0010B9A4
	protected internal virtual void OnSelectedIndexChanged(int Index)
	{
		base.SignalHierarchy("OnSelectedIndexChanged", new object[]
		{
			Index
		});
		if (this.SelectedIndexChanged != null)
		{
			this.SelectedIndexChanged(this, Index);
		}
	}

	// Token: 0x0600486B RID: 18539 RVA: 0x0010D7DC File Offset: 0x0010B9DC
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

	// Token: 0x0600486C RID: 18540 RVA: 0x0010D908 File Offset: 0x0010BB08
	private void selectPageByIndex(int value)
	{
		value = global::UnityEngine.Mathf.Max(global::UnityEngine.Mathf.Min(value, this.controls.Count - 1), -1);
		if (value == this.selectedIndex)
		{
			return;
		}
		this.selectedIndex = value;
		for (int i = 0; i < this.controls.Count; i++)
		{
			global::dfControl dfControl = this.controls[i];
			if (!(dfControl == null))
			{
				dfControl.IsVisible = (i == value);
			}
		}
		this.arrangeTabPages();
		this.Invalidate();
		this.OnSelectedIndexChanged(value);
	}

	// Token: 0x0600486D RID: 18541 RVA: 0x0010D99C File Offset: 0x0010BB9C
	private void arrangeTabPages()
	{
		if (this.padding == null)
		{
			this.padding = new global::UnityEngine.RectOffset(0, 0, 0, 0);
		}
		global::UnityEngine.Vector3 relativePosition;
		relativePosition..ctor((float)this.padding.left, (float)this.padding.top);
		global::UnityEngine.Vector2 size;
		size..ctor(this.size.x - (float)this.padding.horizontal, this.size.y - (float)this.padding.vertical);
		for (int i = 0; i < this.controls.Count; i++)
		{
			global::dfPanel dfPanel = this.controls[i] as global::dfPanel;
			if (dfPanel != null)
			{
				dfPanel.Size = size;
				dfPanel.RelativePosition = relativePosition;
			}
		}
	}

	// Token: 0x0600486E RID: 18542 RVA: 0x0010DA64 File Offset: 0x0010BC64
	private void attachEvents(global::dfControl control)
	{
		control.IsVisibleChanged += this.control_IsVisibleChanged;
		control.PositionChanged += this.childControlInvalidated;
		control.SizeChanged += this.childControlInvalidated;
	}

	// Token: 0x0600486F RID: 18543 RVA: 0x0010DAA8 File Offset: 0x0010BCA8
	private void detachEvents(global::dfControl control)
	{
		control.IsVisibleChanged -= this.control_IsVisibleChanged;
		control.PositionChanged -= this.childControlInvalidated;
		control.SizeChanged -= this.childControlInvalidated;
	}

	// Token: 0x06004870 RID: 18544 RVA: 0x0010DAEC File Offset: 0x0010BCEC
	private void control_IsVisibleChanged(global::dfControl control, bool value)
	{
		this.onChildControlInvalidatedLayout();
	}

	// Token: 0x06004871 RID: 18545 RVA: 0x0010DAF4 File Offset: 0x0010BCF4
	private void childControlInvalidated(global::dfControl control, global::UnityEngine.Vector2 value)
	{
		this.onChildControlInvalidatedLayout();
	}

	// Token: 0x06004872 RID: 18546 RVA: 0x0010DAFC File Offset: 0x0010BCFC
	private void onChildControlInvalidatedLayout()
	{
		if (base.IsLayoutSuspended)
		{
			return;
		}
		this.arrangeTabPages();
		this.Invalidate();
	}

	// Token: 0x06004873 RID: 18547 RVA: 0x0010DB18 File Offset: 0x0010BD18
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static bool <AddTabPage>m__29(global::dfControl i)
	{
		return i is global::dfPanel;
	}

	// Token: 0x040026C3 RID: 9923
	[global::UnityEngine.SerializeField]
	protected global::dfAtlas atlas;

	// Token: 0x040026C4 RID: 9924
	[global::UnityEngine.SerializeField]
	protected string backgroundSprite;

	// Token: 0x040026C5 RID: 9925
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.RectOffset padding = new global::UnityEngine.RectOffset();

	// Token: 0x040026C6 RID: 9926
	[global::UnityEngine.SerializeField]
	protected int selectedIndex;

	// Token: 0x040026C7 RID: 9927
	private global::PropertyChangedEventHandler<int> SelectedIndexChanged;

	// Token: 0x040026C8 RID: 9928
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static global::System.Func<global::dfControl, bool> <>f__am$cache5;
}
