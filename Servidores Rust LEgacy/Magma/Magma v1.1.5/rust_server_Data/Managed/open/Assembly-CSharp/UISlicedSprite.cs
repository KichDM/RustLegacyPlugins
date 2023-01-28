using System;
using UnityEngine;

// Token: 0x0200095F RID: 2399
[global::UnityEngine.AddComponentMenu("NGUI/UI/Sprite (Sliced)")]
[global::UnityEngine.ExecuteInEditMode]
public class UISlicedSprite : global::UIGeometricSprite
{
	// Token: 0x060051CD RID: 20941 RVA: 0x00144914 File Offset: 0x00142B14
	public UISlicedSprite() : this(global::UIWidget.WidgetFlags.CustomBorder)
	{
	}

	// Token: 0x060051CE RID: 20942 RVA: 0x00144920 File Offset: 0x00142B20
	protected UISlicedSprite(global::UIWidget.WidgetFlags additionalFlags) : base(additionalFlags)
	{
	}

	// Token: 0x17000F43 RID: 3907
	// (get) Token: 0x060051CF RID: 20943 RVA: 0x0014492C File Offset: 0x00142B2C
	public new global::UnityEngine.Vector4 border
	{
		get
		{
			global::UIAtlas.Sprite sprite = base.sprite;
			if (sprite == null)
			{
				return global::UnityEngine.Vector4.zero;
			}
			global::UnityEngine.Rect rect = sprite.outer;
			global::UnityEngine.Rect rect2 = sprite.inner;
			global::UnityEngine.Texture mainTexture = base.mainTexture;
			if (base.atlas.coordinates == global::UIAtlas.Coordinates.TexCoords && mainTexture != null)
			{
				rect = global::NGUIMath.ConvertToPixels(rect, mainTexture.width, mainTexture.height, true);
				rect2 = global::NGUIMath.ConvertToPixels(rect2, mainTexture.width, mainTexture.height, true);
			}
			return new global::UnityEngine.Vector4(rect2.xMin - rect.xMin, rect2.yMin - rect.yMin, rect.xMax - rect2.xMax, rect.yMax - rect2.yMax) * base.atlas.pixelSize;
		}
	}

	// Token: 0x17000F44 RID: 3908
	// (get) Token: 0x060051D0 RID: 20944 RVA: 0x001449F8 File Offset: 0x00142BF8
	protected override global::UnityEngine.Vector4 customBorder
	{
		get
		{
			return this.border;
		}
	}
}
