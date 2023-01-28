using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000964 RID: 2404
[global::UnityEngine.AddComponentMenu("NGUI/UI/Sprite Animation")]
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::UISprite))]
public class UISpriteAnimation : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06005211 RID: 21009 RVA: 0x0014FFB4 File Offset: 0x0014E1B4
	public UISpriteAnimation()
	{
	}

	// Token: 0x17000F63 RID: 3939
	// (get) Token: 0x06005212 RID: 21010 RVA: 0x0014FFE8 File Offset: 0x0014E1E8
	// (set) Token: 0x06005213 RID: 21011 RVA: 0x0014FFF0 File Offset: 0x0014E1F0
	public int framesPerSecond
	{
		get
		{
			return this.mFPS;
		}
		set
		{
			this.mFPS = value;
		}
	}

	// Token: 0x17000F64 RID: 3940
	// (get) Token: 0x06005214 RID: 21012 RVA: 0x0014FFFC File Offset: 0x0014E1FC
	// (set) Token: 0x06005215 RID: 21013 RVA: 0x00150004 File Offset: 0x0014E204
	public string namePrefix
	{
		get
		{
			return this.mPrefix;
		}
		set
		{
			if (this.mPrefix != value)
			{
				this.mPrefix = value;
				this.RebuildSpriteList();
			}
		}
	}

	// Token: 0x06005216 RID: 21014 RVA: 0x00150024 File Offset: 0x0014E224
	private void Start()
	{
		this.RebuildSpriteList();
	}

	// Token: 0x06005217 RID: 21015 RVA: 0x0015002C File Offset: 0x0014E22C
	private void Update()
	{
		if (this.mSpriteNames.Count > 1 && global::UnityEngine.Application.isPlaying)
		{
			this.mDelta += global::UnityEngine.Time.deltaTime;
			float num = ((float)this.mFPS <= 0f) ? 0f : (1f / (float)this.mFPS);
			if (num < this.mDelta)
			{
				this.mDelta = ((num <= 0f) ? 0f : (this.mDelta - num));
				if (++this.mIndex >= this.mSpriteNames.Count)
				{
					this.mIndex = 0;
				}
				this.mSprite.spriteName = this.mSpriteNames[this.mIndex];
				this.mSprite.MakePixelPerfect();
			}
		}
	}

	// Token: 0x06005218 RID: 21016 RVA: 0x00150110 File Offset: 0x0014E310
	private void RebuildSpriteList()
	{
		if (this.mSprite == null)
		{
			this.mSprite = base.GetComponent<global::UISprite>();
		}
		this.mSpriteNames.Clear();
		if (this.mSprite != null && this.mSprite.atlas != null)
		{
			global::System.Collections.Generic.List<global::UIAtlas.Sprite> spriteList = this.mSprite.atlas.spriteList;
			int i = 0;
			int count = spriteList.Count;
			while (i < count)
			{
				global::UIAtlas.Sprite sprite = spriteList[i];
				if (string.IsNullOrEmpty(this.mPrefix) || sprite.name.StartsWith(this.mPrefix))
				{
					this.mSpriteNames.Add(sprite.name);
				}
				i++;
			}
			this.mSpriteNames.Sort();
		}
	}

	// Token: 0x04002E67 RID: 11879
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private int mFPS = 0x1E;

	// Token: 0x04002E68 RID: 11880
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private string mPrefix = string.Empty;

	// Token: 0x04002E69 RID: 11881
	private global::UISprite mSprite;

	// Token: 0x04002E6A RID: 11882
	private float mDelta;

	// Token: 0x04002E6B RID: 11883
	private int mIndex;

	// Token: 0x04002E6C RID: 11884
	private global::System.Collections.Generic.List<string> mSpriteNames = new global::System.Collections.Generic.List<string>();
}
