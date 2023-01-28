using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200083F RID: 2111
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/Containers/Tab Control/Tab Strip")]
[global::UnityEngine.ExecuteInEditMode]
public class dfTabstrip : global::dfControl
{
	// Token: 0x06004874 RID: 18548 RVA: 0x0010DB24 File Offset: 0x0010BD24
	public dfTabstrip()
	{
	}

	// Token: 0x14000053 RID: 83
	// (add) Token: 0x06004875 RID: 18549 RVA: 0x0010DB4C File Offset: 0x0010BD4C
	// (remove) Token: 0x06004876 RID: 18550 RVA: 0x0010DB68 File Offset: 0x0010BD68
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

	// Token: 0x17000D91 RID: 3473
	// (get) Token: 0x06004877 RID: 18551 RVA: 0x0010DB84 File Offset: 0x0010BD84
	// (set) Token: 0x06004878 RID: 18552 RVA: 0x0010DB8C File Offset: 0x0010BD8C
	public global::dfTabContainer TabPages
	{
		get
		{
			return this.pageContainer;
		}
		set
		{
			if (this.pageContainer != value)
			{
				this.pageContainer = value;
				if (value != null)
				{
					while (value.Controls.Count < this.controls.Count)
					{
						value.AddTabPage();
					}
				}
				this.pageContainer.SelectedIndex = this.SelectedIndex;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000D92 RID: 3474
	// (get) Token: 0x06004879 RID: 18553 RVA: 0x0010DBFC File Offset: 0x0010BDFC
	// (set) Token: 0x0600487A RID: 18554 RVA: 0x0010DC04 File Offset: 0x0010BE04
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
				this.selectTabByIndex(value);
			}
		}
	}

	// Token: 0x17000D93 RID: 3475
	// (get) Token: 0x0600487B RID: 18555 RVA: 0x0010DC1C File Offset: 0x0010BE1C
	// (set) Token: 0x0600487C RID: 18556 RVA: 0x0010DC64 File Offset: 0x0010BE64
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

	// Token: 0x17000D94 RID: 3476
	// (get) Token: 0x0600487D RID: 18557 RVA: 0x0010DC84 File Offset: 0x0010BE84
	// (set) Token: 0x0600487E RID: 18558 RVA: 0x0010DC8C File Offset: 0x0010BE8C
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

	// Token: 0x17000D95 RID: 3477
	// (get) Token: 0x0600487F RID: 18559 RVA: 0x0010DCAC File Offset: 0x0010BEAC
	// (set) Token: 0x06004880 RID: 18560 RVA: 0x0010DCCC File Offset: 0x0010BECC
	public global::UnityEngine.RectOffset LayoutPadding
	{
		get
		{
			if (this.layoutPadding == null)
			{
				this.layoutPadding = new global::UnityEngine.RectOffset();
			}
			return this.layoutPadding;
		}
		set
		{
			value = value.ConstrainPadding();
			if (!object.Equals(value, this.layoutPadding))
			{
				this.layoutPadding = value;
				this.arrangeTabs();
			}
		}
	}

	// Token: 0x17000D96 RID: 3478
	// (get) Token: 0x06004881 RID: 18561 RVA: 0x0010DD00 File Offset: 0x0010BF00
	// (set) Token: 0x06004882 RID: 18562 RVA: 0x0010DD08 File Offset: 0x0010BF08
	public bool AllowKeyboardNavigation
	{
		get
		{
			return this.allowKeyboardNavigation;
		}
		set
		{
			this.allowKeyboardNavigation = value;
		}
	}

	// Token: 0x06004883 RID: 18563 RVA: 0x0010DD14 File Offset: 0x0010BF14
	public void EnableTab(int index)
	{
		if (this.selectedIndex >= 0 && this.selectedIndex <= this.controls.Count - 1)
		{
			this.controls[index].Enable();
		}
	}

	// Token: 0x06004884 RID: 18564 RVA: 0x0010DD4C File Offset: 0x0010BF4C
	public void DisableTab(int index)
	{
		if (this.selectedIndex >= 0 && this.selectedIndex <= this.controls.Count - 1)
		{
			this.controls[index].Disable();
		}
	}

	// Token: 0x06004885 RID: 18565 RVA: 0x0010DD84 File Offset: 0x0010BF84
	public global::dfControl AddTab(string Text = "")
	{
		global::dfButton dfButton = (from i in this.controls
		where i is global::dfButton
		select i).FirstOrDefault() as global::dfButton;
		string text = "Tab " + (this.controls.Count + 1);
		if (string.IsNullOrEmpty(Text))
		{
			Text = text;
		}
		global::dfButton dfButton2 = base.AddControl<global::dfButton>();
		dfButton2.name = text;
		dfButton2.Atlas = this.Atlas;
		dfButton2.Text = Text;
		dfButton2.ButtonGroup = this;
		if (dfButton != null)
		{
			dfButton2.Atlas = dfButton.Atlas;
			dfButton2.Font = dfButton.Font;
			dfButton2.AutoSize = dfButton.AutoSize;
			dfButton2.Size = dfButton.Size;
			dfButton2.BackgroundSprite = dfButton.BackgroundSprite;
			dfButton2.DisabledSprite = dfButton.DisabledSprite;
			dfButton2.FocusSprite = dfButton.FocusSprite;
			dfButton2.HoverSprite = dfButton.HoverSprite;
			dfButton2.PressedSprite = dfButton.PressedSprite;
			dfButton2.Shadow = dfButton.Shadow;
			dfButton2.ShadowColor = dfButton.ShadowColor;
			dfButton2.ShadowOffset = dfButton.ShadowOffset;
			dfButton2.TextColor = dfButton.TextColor;
			dfButton2.TextAlignment = dfButton.TextAlignment;
			global::UnityEngine.RectOffset padding = dfButton.Padding;
			dfButton2.Padding = new global::UnityEngine.RectOffset(padding.left, padding.right, padding.top, padding.bottom);
		}
		if (this.pageContainer != null)
		{
			this.pageContainer.AddTabPage();
		}
		this.arrangeTabs();
		this.Invalidate();
		return dfButton2;
	}

	// Token: 0x06004886 RID: 18566 RVA: 0x0010DF20 File Offset: 0x0010C120
	protected internal override void OnGotFocus(global::dfFocusEventArgs args)
	{
		if (this.controls.Contains(args.GotFocus))
		{
			this.SelectedIndex = args.GotFocus.ZOrder;
		}
		base.OnGotFocus(args);
	}

	// Token: 0x06004887 RID: 18567 RVA: 0x0010DF5C File Offset: 0x0010C15C
	protected internal override void OnLostFocus(global::dfFocusEventArgs args)
	{
		base.OnLostFocus(args);
		if (this.controls.Contains(args.LostFocus))
		{
			this.showSelectedTab();
		}
	}

	// Token: 0x06004888 RID: 18568 RVA: 0x0010DF84 File Offset: 0x0010C184
	protected internal override void OnClick(global::dfMouseEventArgs args)
	{
		if (this.controls.Contains(args.Source))
		{
			this.SelectedIndex = args.Source.ZOrder;
		}
		base.OnClick(args);
	}

	// Token: 0x06004889 RID: 18569 RVA: 0x0010DFC0 File Offset: 0x0010C1C0
	private void OnClick(global::dfControl sender, global::dfMouseEventArgs args)
	{
		if (!this.controls.Contains(args.Source))
		{
			return;
		}
		this.SelectedIndex = args.Source.ZOrder;
	}

	// Token: 0x0600488A RID: 18570 RVA: 0x0010DFF8 File Offset: 0x0010C1F8
	protected internal override void OnKeyDown(global::dfKeyEventArgs args)
	{
		if (args.Used)
		{
			return;
		}
		if (this.allowKeyboardNavigation)
		{
			if (args.KeyCode == 0x114 || (args.KeyCode == 9 && args.Shift))
			{
				this.SelectedIndex = global::UnityEngine.Mathf.Max(0, this.SelectedIndex - 1);
				args.Use();
				return;
			}
			if (args.KeyCode == 0x113 || args.KeyCode == 9)
			{
				this.SelectedIndex++;
				args.Use();
				return;
			}
		}
		base.OnKeyDown(args);
	}

	// Token: 0x0600488B RID: 18571 RVA: 0x0010E098 File Offset: 0x0010C298
	protected internal override void OnControlAdded(global::dfControl child)
	{
		base.OnControlAdded(child);
		this.attachEvents(child);
		this.arrangeTabs();
	}

	// Token: 0x0600488C RID: 18572 RVA: 0x0010E0B0 File Offset: 0x0010C2B0
	protected internal override void OnControlRemoved(global::dfControl child)
	{
		base.OnControlRemoved(child);
		this.detachEvents(child);
		this.arrangeTabs();
	}

	// Token: 0x0600488D RID: 18573 RVA: 0x0010E0C8 File Offset: 0x0010C2C8
	public override void OnEnable()
	{
		base.OnEnable();
		if (this.size.sqrMagnitude < 1E-45f)
		{
			base.Size = new global::UnityEngine.Vector2(256f, 26f);
		}
		if (global::UnityEngine.Application.isPlaying)
		{
			this.selectTabByIndex(global::UnityEngine.Mathf.Max(this.selectedIndex, 0));
		}
	}

	// Token: 0x0600488E RID: 18574 RVA: 0x0010E124 File Offset: 0x0010C324
	public override void Update()
	{
		base.Update();
		if (this.isControlInvalidated)
		{
			this.arrangeTabs();
		}
		this.showSelectedTab();
	}

	// Token: 0x0600488F RID: 18575 RVA: 0x0010E144 File Offset: 0x0010C344
	protected internal virtual void OnSelectedIndexChanged()
	{
		base.SignalHierarchy("OnSelectedIndexChanged", new object[]
		{
			this.SelectedIndex
		});
		if (this.SelectedIndexChanged != null)
		{
			this.SelectedIndexChanged(this, this.SelectedIndex);
		}
	}

	// Token: 0x06004890 RID: 18576 RVA: 0x0010E190 File Offset: 0x0010C390
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

	// Token: 0x06004891 RID: 18577 RVA: 0x0010E2BC File Offset: 0x0010C4BC
	private void showSelectedTab()
	{
		if (this.selectedIndex >= 0 && this.selectedIndex <= this.controls.Count - 1)
		{
			global::dfButton dfButton = this.controls[this.selectedIndex] as global::dfButton;
			if (dfButton != null && !dfButton.ContainsMouse)
			{
				dfButton.State = global::dfButton.ButtonState.Focus;
			}
		}
	}

	// Token: 0x06004892 RID: 18578 RVA: 0x0010E324 File Offset: 0x0010C524
	private void selectTabByIndex(int value)
	{
		value = global::UnityEngine.Mathf.Max(global::UnityEngine.Mathf.Min(value, this.controls.Count - 1), -1);
		if (value == this.selectedIndex)
		{
			return;
		}
		this.selectedIndex = value;
		for (int i = 0; i < this.controls.Count; i++)
		{
			global::dfButton dfButton = this.controls[i] as global::dfButton;
			if (!(dfButton == null))
			{
				if (i == value)
				{
					dfButton.State = global::dfButton.ButtonState.Focus;
				}
				else
				{
					dfButton.State = global::dfButton.ButtonState.Default;
				}
			}
		}
		this.Invalidate();
		this.OnSelectedIndexChanged();
		if (this.pageContainer != null)
		{
			this.pageContainer.SelectedIndex = value;
		}
	}

	// Token: 0x06004893 RID: 18579 RVA: 0x0010E3E4 File Offset: 0x0010C5E4
	private void arrangeTabs()
	{
		this.SuspendLayout();
		try
		{
			this.layoutPadding = this.layoutPadding.ConstrainPadding();
			float num = (float)this.layoutPadding.left - this.scrollPosition.x;
			float num2 = (float)this.layoutPadding.top - this.scrollPosition.y;
			float num3 = 0f;
			float num4 = 0f;
			for (int i = 0; i < base.Controls.Count; i++)
			{
				global::dfControl dfControl = this.controls[i];
				if (dfControl.IsVisible && dfControl.enabled && dfControl.gameObject.activeSelf)
				{
					global::UnityEngine.Vector2 vector;
					vector..ctor(num, num2);
					dfControl.RelativePosition = vector;
					float num5 = dfControl.Width + (float)this.layoutPadding.horizontal;
					float num6 = dfControl.Height + (float)this.layoutPadding.vertical;
					num3 = global::UnityEngine.Mathf.Max(num5, num3);
					num4 = global::UnityEngine.Mathf.Max(num6, num4);
					num += num5;
				}
			}
		}
		finally
		{
			this.ResumeLayout();
		}
	}

	// Token: 0x06004894 RID: 18580 RVA: 0x0010E528 File Offset: 0x0010C728
	private void attachEvents(global::dfControl control)
	{
		control.IsVisibleChanged += this.control_IsVisibleChanged;
		control.PositionChanged += this.childControlInvalidated;
		control.SizeChanged += this.childControlInvalidated;
		control.ZOrderChanged += this.childControlZOrderChanged;
	}

	// Token: 0x06004895 RID: 18581 RVA: 0x0010E580 File Offset: 0x0010C780
	private void detachEvents(global::dfControl control)
	{
		control.IsVisibleChanged -= this.control_IsVisibleChanged;
		control.PositionChanged -= this.childControlInvalidated;
		control.SizeChanged -= this.childControlInvalidated;
	}

	// Token: 0x06004896 RID: 18582 RVA: 0x0010E5C4 File Offset: 0x0010C7C4
	private void childControlZOrderChanged(global::dfControl control, int value)
	{
		this.onChildControlInvalidatedLayout();
	}

	// Token: 0x06004897 RID: 18583 RVA: 0x0010E5CC File Offset: 0x0010C7CC
	private void control_IsVisibleChanged(global::dfControl control, bool value)
	{
		this.onChildControlInvalidatedLayout();
	}

	// Token: 0x06004898 RID: 18584 RVA: 0x0010E5D4 File Offset: 0x0010C7D4
	private void childControlInvalidated(global::dfControl control, global::UnityEngine.Vector2 value)
	{
		this.onChildControlInvalidatedLayout();
	}

	// Token: 0x06004899 RID: 18585 RVA: 0x0010E5DC File Offset: 0x0010C7DC
	private void onChildControlInvalidatedLayout()
	{
		if (base.IsLayoutSuspended)
		{
			return;
		}
		this.arrangeTabs();
		this.Invalidate();
	}

	// Token: 0x0600489A RID: 18586 RVA: 0x0010E5F8 File Offset: 0x0010C7F8
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static bool <AddTab>m__2A(global::dfControl i)
	{
		return i is global::dfButton;
	}

	// Token: 0x040026C9 RID: 9929
	[global::UnityEngine.SerializeField]
	protected global::dfAtlas atlas;

	// Token: 0x040026CA RID: 9930
	[global::UnityEngine.SerializeField]
	protected string backgroundSprite;

	// Token: 0x040026CB RID: 9931
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.RectOffset layoutPadding = new global::UnityEngine.RectOffset();

	// Token: 0x040026CC RID: 9932
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Vector2 scrollPosition = global::UnityEngine.Vector2.zero;

	// Token: 0x040026CD RID: 9933
	[global::UnityEngine.SerializeField]
	protected int selectedIndex;

	// Token: 0x040026CE RID: 9934
	[global::UnityEngine.SerializeField]
	protected global::dfTabContainer pageContainer;

	// Token: 0x040026CF RID: 9935
	[global::UnityEngine.SerializeField]
	protected bool allowKeyboardNavigation = true;

	// Token: 0x040026D0 RID: 9936
	private global::PropertyChangedEventHandler<int> SelectedIndexChanged;

	// Token: 0x040026D1 RID: 9937
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static global::System.Func<global::dfControl, bool> <>f__am$cache8;
}
