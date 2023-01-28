using System;
using UnityEngine;

// Token: 0x0200087A RID: 2170
[global::dfMarkupTagInfo("img")]
public class dfMarkupTagImg : global::dfMarkupTag
{
	// Token: 0x06004AFB RID: 19195 RVA: 0x0011A63C File Offset: 0x0011883C
	public dfMarkupTagImg() : base("img")
	{
		this.IsClosedTag = true;
	}

	// Token: 0x06004AFC RID: 19196 RVA: 0x0011A650 File Offset: 0x00118850
	public dfMarkupTagImg(global::dfMarkupTag original) : base(original)
	{
		this.IsClosedTag = true;
	}

	// Token: 0x06004AFD RID: 19197 RVA: 0x0011A660 File Offset: 0x00118860
	protected override void _PerformLayoutImpl(global::dfMarkupBox container, global::dfMarkupStyle style)
	{
		if (base.Owner == null)
		{
			global::UnityEngine.Debug.LogError("Tag has no parent: " + this);
			return;
		}
		style = this.applyStyleAttributes(style);
		global::dfMarkupAttribute dfMarkupAttribute = base.findAttribute(new string[]
		{
			"src"
		});
		if (dfMarkupAttribute == null)
		{
			return;
		}
		string value = dfMarkupAttribute.Value;
		global::dfMarkupBox dfMarkupBox = this.createImageBox(base.Owner.Atlas, value, style);
		if (dfMarkupBox == null)
		{
			return;
		}
		global::UnityEngine.Vector2 size = global::UnityEngine.Vector2.zero;
		global::dfMarkupAttribute dfMarkupAttribute2 = base.findAttribute(new string[]
		{
			"height"
		});
		if (dfMarkupAttribute2 != null)
		{
			size.y = (float)global::dfMarkupStyle.ParseSize(dfMarkupAttribute2.Value, (int)dfMarkupBox.Size.y);
		}
		global::dfMarkupAttribute dfMarkupAttribute3 = base.findAttribute(new string[]
		{
			"width"
		});
		if (dfMarkupAttribute3 != null)
		{
			size.x = (float)global::dfMarkupStyle.ParseSize(dfMarkupAttribute3.Value, (int)dfMarkupBox.Size.x);
		}
		if (size.sqrMagnitude <= 1E-45f)
		{
			size = dfMarkupBox.Size;
		}
		else if (size.x <= 1E-45f)
		{
			size.x = size.y * (dfMarkupBox.Size.x / dfMarkupBox.Size.y);
		}
		else if (size.y <= 1E-45f)
		{
			size.y = size.x * (dfMarkupBox.Size.y / dfMarkupBox.Size.x);
		}
		dfMarkupBox.Size = size;
		dfMarkupBox.Baseline = (int)size.y;
		container.AddChild(dfMarkupBox);
	}

	// Token: 0x06004AFE RID: 19198 RVA: 0x0011A804 File Offset: 0x00118A04
	private global::dfMarkupStyle applyStyleAttributes(global::dfMarkupStyle style)
	{
		global::dfMarkupAttribute dfMarkupAttribute = base.findAttribute(new string[]
		{
			"valign"
		});
		if (dfMarkupAttribute != null)
		{
			style.VerticalAlign = global::dfMarkupStyle.ParseVerticalAlignment(dfMarkupAttribute.Value);
		}
		global::dfMarkupAttribute dfMarkupAttribute2 = base.findAttribute(new string[]
		{
			"color"
		});
		if (dfMarkupAttribute2 != null)
		{
			global::UnityEngine.Color color = global::dfMarkupStyle.ParseColor(dfMarkupAttribute2.Value, base.Owner.Color);
			color.a = style.Opacity;
			style.Color = color;
		}
		return style;
	}

	// Token: 0x06004AFF RID: 19199 RVA: 0x0011A88C File Offset: 0x00118A8C
	private global::dfMarkupBox createImageBox(global::dfAtlas atlas, string source, global::dfMarkupStyle style)
	{
		if (source.ToLowerInvariant().StartsWith("http://"))
		{
			return null;
		}
		if (atlas != null && atlas[source] != null)
		{
			global::dfMarkupBoxSprite dfMarkupBoxSprite = new global::dfMarkupBoxSprite(this, global::dfMarkupDisplayType.inline, style);
			dfMarkupBoxSprite.LoadImage(atlas, source);
			return dfMarkupBoxSprite;
		}
		global::UnityEngine.Texture texture = global::dfMarkupImageCache.Load(source);
		if (texture != null)
		{
			global::dfMarkupBoxTexture dfMarkupBoxTexture = new global::dfMarkupBoxTexture(this, global::dfMarkupDisplayType.inline, style);
			dfMarkupBoxTexture.LoadTexture(texture);
			return dfMarkupBoxTexture;
		}
		return null;
	}
}
