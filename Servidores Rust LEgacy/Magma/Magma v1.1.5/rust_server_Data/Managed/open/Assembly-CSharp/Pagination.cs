using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200052C RID: 1324
public class Pagination : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002CA6 RID: 11430 RVA: 0x000A8AD0 File Offset: 0x000A6CD0
	public Pagination()
	{
	}

	// Token: 0x14000017 RID: 23
	// (add) Token: 0x06002CA7 RID: 11431 RVA: 0x000A8AE0 File Offset: 0x000A6CE0
	// (remove) Token: 0x06002CA8 RID: 11432 RVA: 0x000A8AFC File Offset: 0x000A6CFC
	public event global::Pagination.SwitchToPage OnPageSwitch
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.OnPageSwitch = (global::Pagination.SwitchToPage)global::System.Delegate.Combine(this.OnPageSwitch, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.OnPageSwitch = (global::Pagination.SwitchToPage)global::System.Delegate.Remove(this.OnPageSwitch, value);
		}
	}

	// Token: 0x06002CA9 RID: 11433 RVA: 0x000A8B18 File Offset: 0x000A6D18
	public void Setup(int iPages, int iCurrentPage)
	{
		if (this.pageCount == iPages && this.pageCurrent == iCurrentPage)
		{
			return;
		}
		this.pageCount = iPages;
		this.pageCurrent = iCurrentPage;
		global::dfControl[] componentsInChildren = base.gameObject.GetComponentsInChildren<global::dfControl>();
		foreach (global::dfControl dfControl in componentsInChildren)
		{
			if (!(dfControl.gameObject == base.gameObject))
			{
				global::UnityEngine.Object.Destroy(dfControl.gameObject);
			}
		}
		if (this.pageCount <= 1)
		{
			return;
		}
		global::dfControl component = base.GetComponent<global::dfControl>();
		bool flag = true;
		global::UnityEngine.Vector3 position;
		position..ctor(0f, 0f, 0f);
		for (int j = 0; j < this.pageCount; j++)
		{
			if (this.buttonGroups - j <= 0 && j < this.pageCount - this.buttonGroups && global::System.Math.Abs(j - this.pageCurrent) > this.buttonGroups / 2)
			{
				if (flag)
				{
					this.DropSpacer(ref position);
				}
				flag = false;
			}
			else
			{
				global::UnityEngine.GameObject gameObject = (global::UnityEngine.GameObject)global::UnityEngine.Object.Instantiate(this.clickableButton);
				global::dfButton component2 = gameObject.GetComponent<global::dfButton>();
				component.AddControl(component2);
				component2.Tooltip = j.ToString();
				component2.MouseDown += this.OnButtonClicked;
				component2.Text = (j + 1).ToString();
				component2.Invalidate();
				if (j == this.pageCurrent)
				{
					component2.Disable();
				}
				component2.Position = position;
				position.x += component2.Width + 5f;
				flag = true;
			}
		}
		component.Width = position.x;
	}

	// Token: 0x06002CAA RID: 11434 RVA: 0x000A8CE0 File Offset: 0x000A6EE0
	public void DropSpacer(ref global::UnityEngine.Vector3 vPos)
	{
		if (!this.spacerLabel)
		{
			return;
		}
		global::dfControl component = base.GetComponent<global::dfControl>();
		global::UnityEngine.GameObject gameObject = (global::UnityEngine.GameObject)global::UnityEngine.Object.Instantiate(this.spacerLabel);
		global::dfControl component2 = gameObject.GetComponent<global::dfControl>();
		component.AddControl(component2);
		component2.Position = vPos;
		vPos.x += component2.Width + 5f;
	}

	// Token: 0x06002CAB RID: 11435 RVA: 0x000A8D4C File Offset: 0x000A6F4C
	public void OnButtonClicked(global::dfControl control, global::dfMouseEventArgs mouseEvent)
	{
		int num = int.Parse(control.Tooltip);
		this.Setup(this.pageCount, num);
		if (this.OnPageSwitch != null)
		{
			this.OnPageSwitch(num);
		}
	}

	// Token: 0x040016E7 RID: 5863
	public global::UnityEngine.GameObject clickableButton;

	// Token: 0x040016E8 RID: 5864
	public global::UnityEngine.GameObject spacerLabel;

	// Token: 0x040016E9 RID: 5865
	public int buttonGroups = 2;

	// Token: 0x040016EA RID: 5866
	protected int pageCount;

	// Token: 0x040016EB RID: 5867
	protected int pageCurrent;

	// Token: 0x040016EC RID: 5868
	private global::Pagination.SwitchToPage OnPageSwitch;

	// Token: 0x0200052D RID: 1325
	// (Invoke) Token: 0x06002CAD RID: 11437
	public delegate void SwitchToPage(int iPage);
}
