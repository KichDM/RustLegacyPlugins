using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200091D RID: 2333
[global::UnityEngine.AddComponentMenu("NGUI/UI/Atlas")]
public class UIAtlas : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004FB1 RID: 20401 RVA: 0x00135DE0 File Offset: 0x00133FE0
	public UIAtlas()
	{
	}

	// Token: 0x17000EB0 RID: 3760
	// (get) Token: 0x06004FB2 RID: 20402 RVA: 0x00135E00 File Offset: 0x00134000
	// (set) Token: 0x06004FB3 RID: 20403 RVA: 0x00135E2C File Offset: 0x0013402C
	public global::UnityEngine.Material spriteMaterial
	{
		get
		{
			return (!(this.mReplacement != null)) ? this.material : this.mReplacement.spriteMaterial;
		}
		set
		{
			if (this.mReplacement != null)
			{
				this.mReplacement.spriteMaterial = value;
			}
			else if (this.material == null)
			{
				this.material = value;
			}
			else
			{
				this.MarkAsDirty();
				this.material = value;
				this.MarkAsDirty();
			}
		}
	}

	// Token: 0x17000EB1 RID: 3761
	// (get) Token: 0x06004FB4 RID: 20404 RVA: 0x00135E8C File Offset: 0x0013408C
	// (set) Token: 0x06004FB5 RID: 20405 RVA: 0x00135EB8 File Offset: 0x001340B8
	public global::System.Collections.Generic.List<global::UIAtlas.Sprite> spriteList
	{
		get
		{
			return (!(this.mReplacement != null)) ? this.sprites : this.mReplacement.spriteList;
		}
		set
		{
			if (this.mReplacement != null)
			{
				this.mReplacement.spriteList = value;
			}
			else
			{
				this.sprites = value;
			}
		}
	}

	// Token: 0x17000EB2 RID: 3762
	// (get) Token: 0x06004FB6 RID: 20406 RVA: 0x00135EE4 File Offset: 0x001340E4
	public global::UnityEngine.Texture texture
	{
		get
		{
			return (!(this.mReplacement != null)) ? ((!(this.material != null)) ? null : this.material.mainTexture) : this.mReplacement.texture;
		}
	}

	// Token: 0x17000EB3 RID: 3763
	// (get) Token: 0x06004FB7 RID: 20407 RVA: 0x00135F34 File Offset: 0x00134134
	// (set) Token: 0x06004FB8 RID: 20408 RVA: 0x00135F60 File Offset: 0x00134160
	public global::UIAtlas.Coordinates coordinates
	{
		get
		{
			return (!(this.mReplacement != null)) ? this.mCoordinates : this.mReplacement.coordinates;
		}
		set
		{
			if (this.mReplacement != null)
			{
				this.mReplacement.coordinates = value;
			}
			else if (this.mCoordinates != value)
			{
				if (this.material == null || this.material.mainTexture == null)
				{
					global::UnityEngine.Debug.LogError("Can't switch coordinates until the atlas material has a valid texture");
					return;
				}
				this.mCoordinates = value;
				global::UnityEngine.Texture mainTexture = this.material.mainTexture;
				int i = 0;
				int count = this.sprites.Count;
				while (i < count)
				{
					global::UIAtlas.Sprite sprite = this.sprites[i];
					if (this.mCoordinates == global::UIAtlas.Coordinates.TexCoords)
					{
						sprite.outer = global::NGUIMath.ConvertToTexCoords(sprite.outer, mainTexture.width, mainTexture.height);
						sprite.inner = global::NGUIMath.ConvertToTexCoords(sprite.inner, mainTexture.width, mainTexture.height);
					}
					else
					{
						sprite.outer = global::NGUIMath.ConvertToPixels(sprite.outer, mainTexture.width, mainTexture.height, true);
						sprite.inner = global::NGUIMath.ConvertToPixels(sprite.inner, mainTexture.width, mainTexture.height, true);
					}
					i++;
				}
			}
		}
	}

	// Token: 0x17000EB4 RID: 3764
	// (get) Token: 0x06004FB9 RID: 20409 RVA: 0x00136094 File Offset: 0x00134294
	// (set) Token: 0x06004FBA RID: 20410 RVA: 0x001360C0 File Offset: 0x001342C0
	public float pixelSize
	{
		get
		{
			return (!(this.mReplacement != null)) ? this.mPixelSize : this.mReplacement.pixelSize;
		}
		set
		{
			if (this.mReplacement != null)
			{
				this.mReplacement.pixelSize = value;
			}
			else
			{
				float num = global::UnityEngine.Mathf.Clamp(value, 0.25f, 4f);
				if (this.mPixelSize != num)
				{
					this.mPixelSize = num;
					this.MarkAsDirty();
				}
			}
		}
	}

	// Token: 0x17000EB5 RID: 3765
	// (get) Token: 0x06004FBB RID: 20411 RVA: 0x0013611C File Offset: 0x0013431C
	// (set) Token: 0x06004FBC RID: 20412 RVA: 0x00136124 File Offset: 0x00134324
	public global::UIAtlas replacement
	{
		get
		{
			return this.mReplacement;
		}
		set
		{
			global::UIAtlas uiatlas = value;
			if (uiatlas == this)
			{
				uiatlas = null;
			}
			if (this.mReplacement != uiatlas)
			{
				if (uiatlas != null && uiatlas.replacement == this)
				{
					uiatlas.replacement = null;
				}
				if (this.mReplacement != null)
				{
					this.MarkAsDirty();
				}
				this.mReplacement = uiatlas;
				this.MarkAsDirty();
			}
		}
	}

	// Token: 0x06004FBD RID: 20413 RVA: 0x0013619C File Offset: 0x0013439C
	public global::UIAtlas.Sprite GetSprite(string name)
	{
		if (this.mReplacement != null)
		{
			return this.mReplacement.GetSprite(name);
		}
		if (!string.IsNullOrEmpty(name))
		{
			int i = 0;
			int count = this.sprites.Count;
			while (i < count)
			{
				global::UIAtlas.Sprite sprite = this.sprites[i];
				if (!string.IsNullOrEmpty(sprite.name) && name == sprite.name)
				{
					return sprite;
				}
				i++;
			}
		}
		else
		{
			global::UnityEngine.Debug.LogWarning("Expected a valid name, found nothing");
		}
		return null;
	}

	// Token: 0x06004FBE RID: 20414 RVA: 0x00136230 File Offset: 0x00134430
	public global::System.Collections.Generic.List<string> GetListOfSprites()
	{
		if (this.mReplacement != null)
		{
			return this.mReplacement.GetListOfSprites();
		}
		global::System.Collections.Generic.List<string> list = new global::System.Collections.Generic.List<string>();
		int i = 0;
		int count = this.sprites.Count;
		while (i < count)
		{
			global::UIAtlas.Sprite sprite = this.sprites[i];
			if (sprite != null && !string.IsNullOrEmpty(sprite.name))
			{
				list.Add(sprite.name);
			}
			i++;
		}
		list.Sort();
		return list;
	}

	// Token: 0x06004FBF RID: 20415 RVA: 0x001362B4 File Offset: 0x001344B4
	private bool References(global::UIAtlas atlas)
	{
		return !(atlas == null) && (atlas == this || (this.mReplacement != null && this.mReplacement.References(atlas)));
	}

	// Token: 0x06004FC0 RID: 20416 RVA: 0x00136300 File Offset: 0x00134500
	public static bool CheckIfRelated(global::UIAtlas a, global::UIAtlas b)
	{
		return !(a == null) && !(b == null) && (a == b || a.References(b) || b.References(a));
	}

	// Token: 0x06004FC1 RID: 20417 RVA: 0x0013634C File Offset: 0x0013454C
	public void MarkAsDirty()
	{
		global::UISprite[] array = global::NGUITools.FindActive<global::UISprite>();
		int i = 0;
		int num = array.Length;
		while (i < num)
		{
			global::UISprite uisprite = array[i];
			if (global::UIAtlas.CheckIfRelated(this, uisprite.atlas))
			{
				global::UIAtlas atlas = uisprite.atlas;
				uisprite.atlas = null;
				uisprite.atlas = atlas;
			}
			i++;
		}
		global::UIFont[] array2 = global::Resources.FindObjectsOfTypeAll(typeof(global::UIFont)) as global::UIFont[];
		int j = 0;
		int num2 = array2.Length;
		while (j < num2)
		{
			global::UIFont uifont = array2[j];
			if (global::UIAtlas.CheckIfRelated(this, uifont.atlas))
			{
				global::UIAtlas atlas2 = uifont.atlas;
				uifont.atlas = null;
				uifont.atlas = atlas2;
			}
			j++;
		}
		global::UILabel[] array3 = global::NGUITools.FindActive<global::UILabel>();
		int k = 0;
		int num3 = array3.Length;
		while (k < num3)
		{
			global::UILabel uilabel = array3[k];
			if (uilabel.font != null && global::UIAtlas.CheckIfRelated(this, uilabel.font.atlas))
			{
				global::UIFont font = uilabel.font;
				uilabel.font = null;
				uilabel.font = font;
			}
			k++;
		}
	}

	// Token: 0x04002C30 RID: 11312
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Material material;

	// Token: 0x04002C31 RID: 11313
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::System.Collections.Generic.List<global::UIAtlas.Sprite> sprites = new global::System.Collections.Generic.List<global::UIAtlas.Sprite>();

	// Token: 0x04002C32 RID: 11314
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UIAtlas.Coordinates mCoordinates;

	// Token: 0x04002C33 RID: 11315
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private float mPixelSize = 1f;

	// Token: 0x04002C34 RID: 11316
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UIAtlas mReplacement;

	// Token: 0x0200091E RID: 2334
	[global::System.Serializable]
	public class Sprite
	{
		// Token: 0x06004FC2 RID: 20418 RVA: 0x00136478 File Offset: 0x00134678
		public Sprite()
		{
		}

		// Token: 0x17000EB6 RID: 3766
		// (get) Token: 0x06004FC3 RID: 20419 RVA: 0x001364D4 File Offset: 0x001346D4
		public bool hasPadding
		{
			get
			{
				return this.paddingLeft != 0f || this.paddingRight != 0f || this.paddingTop != 0f || this.paddingBottom != 0f;
			}
		}

		// Token: 0x04002C35 RID: 11317
		public string name = "Unity Bug";

		// Token: 0x04002C36 RID: 11318
		public global::UnityEngine.Rect outer = new global::UnityEngine.Rect(0f, 0f, 1f, 1f);

		// Token: 0x04002C37 RID: 11319
		public global::UnityEngine.Rect inner = new global::UnityEngine.Rect(0f, 0f, 1f, 1f);

		// Token: 0x04002C38 RID: 11320
		public float paddingLeft;

		// Token: 0x04002C39 RID: 11321
		public float paddingRight;

		// Token: 0x04002C3A RID: 11322
		public float paddingTop;

		// Token: 0x04002C3B RID: 11323
		public float paddingBottom;
	}

	// Token: 0x0200091F RID: 2335
	public enum Coordinates
	{
		// Token: 0x04002C3D RID: 11325
		Pixels,
		// Token: 0x04002C3E RID: 11326
		TexCoords
	}
}
