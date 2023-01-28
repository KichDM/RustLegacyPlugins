using System;
using UnityEngine;

// Token: 0x02000900 RID: 2304
public class UINode
{
	// Token: 0x06004F01 RID: 20225 RVA: 0x00132B10 File Offset: 0x00130D10
	public UINode(global::UnityEngine.Transform t)
	{
		this.trans = t;
		this.lastPos = this.trans.localPosition;
		this.lastRot = this.trans.localRotation;
		this.lastScale = this.trans.localScale;
		this.mGo = t.gameObject;
	}

	// Token: 0x17000E8D RID: 3725
	// (get) Token: 0x06004F02 RID: 20226 RVA: 0x00132B78 File Offset: 0x00130D78
	// (set) Token: 0x06004F03 RID: 20227 RVA: 0x00132BA4 File Offset: 0x00130DA4
	public int visibleFlag
	{
		get
		{
			return (!(this.widget != null)) ? this.mVisibleFlag : this.widget.visibleFlag;
		}
		set
		{
			if (this.widget != null)
			{
				this.widget.visibleFlag = value;
			}
			else
			{
				this.mVisibleFlag = value;
			}
		}
	}

	// Token: 0x06004F04 RID: 20228 RVA: 0x00132BD0 File Offset: 0x00130DD0
	public bool HasChanged()
	{
		bool flag = this.mGo.activeInHierarchy && (this.widget == null || (this.widget.enabled && this.widget.color.a > 0.001f));
		if (this.lastActive != flag || (flag && (this.lastPos != this.trans.localPosition || this.lastRot != this.trans.localRotation || this.lastScale != this.trans.localScale)))
		{
			this.lastActive = flag;
			this.lastPos = this.trans.localPosition;
			this.lastRot = this.trans.localRotation;
			this.lastScale = this.trans.localScale;
			return true;
		}
		return false;
	}

	// Token: 0x04002B8D RID: 11149
	private int mVisibleFlag = -1;

	// Token: 0x04002B8E RID: 11150
	public global::UnityEngine.Transform trans;

	// Token: 0x04002B8F RID: 11151
	public global::UIWidget widget;

	// Token: 0x04002B90 RID: 11152
	public bool lastActive;

	// Token: 0x04002B91 RID: 11153
	public global::UnityEngine.Vector3 lastPos;

	// Token: 0x04002B92 RID: 11154
	public global::UnityEngine.Quaternion lastRot;

	// Token: 0x04002B93 RID: 11155
	public global::UnityEngine.Vector3 lastScale;

	// Token: 0x04002B94 RID: 11156
	public int changeFlag = -1;

	// Token: 0x04002B95 RID: 11157
	private global::UnityEngine.GameObject mGo;
}
