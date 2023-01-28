using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000872 RID: 2162
[global::dfMarkupTagInfo("ul")]
[global::dfMarkupTagInfo("ol")]
public class dfMarkupTagList : global::dfMarkupTag
{
	// Token: 0x06004ADF RID: 19167 RVA: 0x00119D24 File Offset: 0x00117F24
	public dfMarkupTagList() : base("ul")
	{
	}

	// Token: 0x06004AE0 RID: 19168 RVA: 0x00119D34 File Offset: 0x00117F34
	public dfMarkupTagList(global::dfMarkupTag original) : base(original)
	{
	}

	// Token: 0x17000E04 RID: 3588
	// (get) Token: 0x06004AE1 RID: 19169 RVA: 0x00119D40 File Offset: 0x00117F40
	// (set) Token: 0x06004AE2 RID: 19170 RVA: 0x00119D48 File Offset: 0x00117F48
	internal int BulletWidth
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<BulletWidth>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<BulletWidth>k__BackingField = value;
		}
	}

	// Token: 0x06004AE3 RID: 19171 RVA: 0x00119D54 File Offset: 0x00117F54
	protected override void _PerformLayoutImpl(global::dfMarkupBox container, global::dfMarkupStyle style)
	{
		if (base.ChildNodes.Count == 0)
		{
			return;
		}
		style.Align = global::dfMarkupTextAlign.Left;
		global::dfMarkupBox dfMarkupBox = new global::dfMarkupBox(this, global::dfMarkupDisplayType.block, style);
		container.AddChild(dfMarkupBox);
		this.calculateBulletWidth(style);
		for (int i = 0; i < base.ChildNodes.Count; i++)
		{
			global::dfMarkupTag dfMarkupTag = base.ChildNodes[i] as global::dfMarkupTag;
			if (dfMarkupTag != null && !(dfMarkupTag.TagName != "li"))
			{
				dfMarkupTag.PerformLayout(dfMarkupBox, style);
			}
		}
		dfMarkupBox.FitToContents(false);
	}

	// Token: 0x06004AE4 RID: 19172 RVA: 0x00119DF0 File Offset: 0x00117FF0
	private void calculateBulletWidth(global::dfMarkupStyle style)
	{
		if (base.TagName == "ul")
		{
			this.BulletWidth = global::UnityEngine.Mathf.CeilToInt(style.Font.MeasureText("•", style.FontSize, style.FontStyle).x);
			return;
		}
		int num = 0;
		for (int i = 0; i < base.ChildNodes.Count; i++)
		{
			global::dfMarkupTag dfMarkupTag = base.ChildNodes[i] as global::dfMarkupTag;
			if (dfMarkupTag != null && dfMarkupTag.TagName == "li")
			{
				num++;
			}
		}
		string text = new string('X', num.ToString().Length) + ".";
		this.BulletWidth = global::UnityEngine.Mathf.CeilToInt(style.Font.MeasureText(text, style.FontSize, style.FontStyle).x);
	}

	// Token: 0x040027F0 RID: 10224
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private int <BulletWidth>k__BackingField;
}
