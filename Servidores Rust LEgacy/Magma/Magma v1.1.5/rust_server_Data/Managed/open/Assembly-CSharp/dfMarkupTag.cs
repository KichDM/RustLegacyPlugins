using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

// Token: 0x0200086F RID: 2159
public class dfMarkupTag : global::dfMarkupElement
{
	// Token: 0x06004AC2 RID: 19138 RVA: 0x001195D0 File Offset: 0x001177D0
	public dfMarkupTag(string tagName)
	{
		this.Attributes = new global::System.Collections.Generic.List<global::dfMarkupAttribute>();
		this.TagName = tagName;
		this.id = tagName + global::dfMarkupTag.ELEMENTID++.ToString("X");
	}

	// Token: 0x06004AC3 RID: 19139 RVA: 0x0011961C File Offset: 0x0011781C
	public dfMarkupTag(global::dfMarkupTag original)
	{
		this.TagName = original.TagName;
		this.Attributes = original.Attributes;
		this.IsEndTag = original.IsEndTag;
		this.IsClosedTag = original.IsClosedTag;
		this.IsInline = original.IsInline;
		this.id = original.id;
		global::System.Collections.Generic.List<global::dfMarkupElement> childNodes = original.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			global::dfMarkupElement node = childNodes[i];
			base.AddChildNode(node);
		}
	}

	// Token: 0x06004AC4 RID: 19140 RVA: 0x001196A4 File Offset: 0x001178A4
	// Note: this type is marked as 'beforefieldinit'.
	static dfMarkupTag()
	{
	}

	// Token: 0x17000DFD RID: 3581
	// (get) Token: 0x06004AC5 RID: 19141 RVA: 0x001196A8 File Offset: 0x001178A8
	// (set) Token: 0x06004AC6 RID: 19142 RVA: 0x001196B0 File Offset: 0x001178B0
	public string TagName
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<TagName>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<TagName>k__BackingField = value;
		}
	}

	// Token: 0x17000DFE RID: 3582
	// (get) Token: 0x06004AC7 RID: 19143 RVA: 0x001196BC File Offset: 0x001178BC
	public string ID
	{
		get
		{
			return this.id;
		}
	}

	// Token: 0x17000DFF RID: 3583
	// (get) Token: 0x06004AC8 RID: 19144 RVA: 0x001196C4 File Offset: 0x001178C4
	// (set) Token: 0x06004AC9 RID: 19145 RVA: 0x001196CC File Offset: 0x001178CC
	public virtual bool IsEndTag
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<IsEndTag>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<IsEndTag>k__BackingField = value;
		}
	}

	// Token: 0x17000E00 RID: 3584
	// (get) Token: 0x06004ACA RID: 19146 RVA: 0x001196D8 File Offset: 0x001178D8
	// (set) Token: 0x06004ACB RID: 19147 RVA: 0x001196E0 File Offset: 0x001178E0
	public virtual bool IsClosedTag
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<IsClosedTag>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<IsClosedTag>k__BackingField = value;
		}
	}

	// Token: 0x17000E01 RID: 3585
	// (get) Token: 0x06004ACC RID: 19148 RVA: 0x001196EC File Offset: 0x001178EC
	// (set) Token: 0x06004ACD RID: 19149 RVA: 0x001196F4 File Offset: 0x001178F4
	public virtual bool IsInline
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<IsInline>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<IsInline>k__BackingField = value;
		}
	}

	// Token: 0x17000E02 RID: 3586
	// (get) Token: 0x06004ACE RID: 19150 RVA: 0x00119700 File Offset: 0x00117900
	// (set) Token: 0x06004ACF RID: 19151 RVA: 0x00119708 File Offset: 0x00117908
	public global::dfRichTextLabel Owner
	{
		get
		{
			return this.owner;
		}
		set
		{
			this.owner = value;
			for (int i = 0; i < base.ChildNodes.Count; i++)
			{
				global::dfMarkupTag dfMarkupTag = base.ChildNodes[i] as global::dfMarkupTag;
				if (dfMarkupTag != null)
				{
					dfMarkupTag.Owner = value;
				}
			}
		}
	}

	// Token: 0x06004AD0 RID: 19152 RVA: 0x00119758 File Offset: 0x00117958
	internal override void Release()
	{
		base.Release();
	}

	// Token: 0x06004AD1 RID: 19153 RVA: 0x00119760 File Offset: 0x00117960
	protected override void _PerformLayoutImpl(global::dfMarkupBox container, global::dfMarkupStyle style)
	{
		if (this.IsEndTag)
		{
			return;
		}
		for (int i = 0; i < base.ChildNodes.Count; i++)
		{
			base.ChildNodes[i].PerformLayout(container, style);
		}
	}

	// Token: 0x06004AD2 RID: 19154 RVA: 0x001197A8 File Offset: 0x001179A8
	protected global::dfMarkupStyle applyTextStyleAttributes(global::dfMarkupStyle style)
	{
		global::dfMarkupAttribute dfMarkupAttribute = this.findAttribute(new string[]
		{
			"font",
			"font-family"
		});
		if (dfMarkupAttribute != null)
		{
			style.Font = global::dfDynamicFont.FindByName(dfMarkupAttribute.Value);
		}
		global::dfMarkupAttribute dfMarkupAttribute2 = this.findAttribute(new string[]
		{
			"style",
			"font-style"
		});
		if (dfMarkupAttribute2 != null)
		{
			style.FontStyle = global::dfMarkupStyle.ParseFontStyle(dfMarkupAttribute2.Value, style.FontStyle);
		}
		global::dfMarkupAttribute dfMarkupAttribute3 = this.findAttribute(new string[]
		{
			"size",
			"font-size"
		});
		if (dfMarkupAttribute3 != null)
		{
			style.FontSize = global::dfMarkupStyle.ParseSize(dfMarkupAttribute3.Value, style.FontSize);
		}
		global::dfMarkupAttribute dfMarkupAttribute4 = this.findAttribute(new string[]
		{
			"color"
		});
		if (dfMarkupAttribute4 != null)
		{
			global::UnityEngine.Color color = global::dfMarkupStyle.ParseColor(dfMarkupAttribute4.Value, style.Color);
			color.a = style.Opacity;
			style.Color = color;
		}
		global::dfMarkupAttribute dfMarkupAttribute5 = this.findAttribute(new string[]
		{
			"align",
			"text-align"
		});
		if (dfMarkupAttribute5 != null)
		{
			style.Align = global::dfMarkupStyle.ParseTextAlignment(dfMarkupAttribute5.Value);
		}
		global::dfMarkupAttribute dfMarkupAttribute6 = this.findAttribute(new string[]
		{
			"valign",
			"vertical-align"
		});
		if (dfMarkupAttribute6 != null)
		{
			style.VerticalAlign = global::dfMarkupStyle.ParseVerticalAlignment(dfMarkupAttribute6.Value);
		}
		global::dfMarkupAttribute dfMarkupAttribute7 = this.findAttribute(new string[]
		{
			"line-height"
		});
		if (dfMarkupAttribute7 != null)
		{
			style.LineHeight = global::dfMarkupStyle.ParseSize(dfMarkupAttribute7.Value, style.LineHeight);
		}
		global::dfMarkupAttribute dfMarkupAttribute8 = this.findAttribute(new string[]
		{
			"text-decoration"
		});
		if (dfMarkupAttribute8 != null)
		{
			style.TextDecoration = global::dfMarkupStyle.ParseTextDecoration(dfMarkupAttribute8.Value);
		}
		global::dfMarkupAttribute dfMarkupAttribute9 = this.findAttribute(new string[]
		{
			"background",
			"background-color"
		});
		if (dfMarkupAttribute9 != null)
		{
			style.BackgroundColor = global::dfMarkupStyle.ParseColor(dfMarkupAttribute9.Value, global::UnityEngine.Color.clear);
			style.BackgroundColor.a = style.Opacity;
		}
		return style;
	}

	// Token: 0x06004AD3 RID: 19155 RVA: 0x001199D0 File Offset: 0x00117BD0
	public override string ToString()
	{
		global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
		stringBuilder.Append("[");
		if (this.IsEndTag)
		{
			stringBuilder.Append("/");
		}
		stringBuilder.Append(this.TagName);
		for (int i = 0; i < this.Attributes.Count; i++)
		{
			stringBuilder.Append(" ");
			stringBuilder.Append(this.Attributes[i].ToString());
		}
		if (this.IsClosedTag)
		{
			stringBuilder.Append("/");
		}
		stringBuilder.Append("]");
		if (!this.IsClosedTag)
		{
			for (int j = 0; j < base.ChildNodes.Count; j++)
			{
				stringBuilder.Append(base.ChildNodes[j].ToString());
			}
			stringBuilder.Append("[/");
			stringBuilder.Append(this.TagName);
			stringBuilder.Append("]");
		}
		return stringBuilder.ToString();
	}

	// Token: 0x06004AD4 RID: 19156 RVA: 0x00119AE0 File Offset: 0x00117CE0
	protected global::dfMarkupAttribute findAttribute(params string[] names)
	{
		for (int i = 0; i < this.Attributes.Count; i++)
		{
			for (int j = 0; j < names.Length; j++)
			{
				if (this.Attributes[i].Name == names[j])
				{
					return this.Attributes[i];
				}
			}
		}
		return null;
	}

	// Token: 0x040027E7 RID: 10215
	private static int ELEMENTID;

	// Token: 0x040027E8 RID: 10216
	public global::System.Collections.Generic.List<global::dfMarkupAttribute> Attributes;

	// Token: 0x040027E9 RID: 10217
	private global::dfRichTextLabel owner;

	// Token: 0x040027EA RID: 10218
	private string id;

	// Token: 0x040027EB RID: 10219
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private string <TagName>k__BackingField;

	// Token: 0x040027EC RID: 10220
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private bool <IsEndTag>k__BackingField;

	// Token: 0x040027ED RID: 10221
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private bool <IsClosedTag>k__BackingField;

	// Token: 0x040027EE RID: 10222
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private bool <IsInline>k__BackingField;
}
