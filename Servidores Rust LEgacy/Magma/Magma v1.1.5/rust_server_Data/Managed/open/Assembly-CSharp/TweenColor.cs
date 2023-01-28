using System;
using UnityEngine;

// Token: 0x02000910 RID: 2320
[global::UnityEngine.AddComponentMenu("NGUI/Tween/Color")]
public class TweenColor : global::UITweener
{
	// Token: 0x06004F72 RID: 20338 RVA: 0x00134A04 File Offset: 0x00132C04
	public TweenColor()
	{
	}

	// Token: 0x17000EA3 RID: 3747
	// (get) Token: 0x06004F73 RID: 20339 RVA: 0x00134A24 File Offset: 0x00132C24
	// (set) Token: 0x06004F74 RID: 20340 RVA: 0x00134A90 File Offset: 0x00132C90
	public global::UnityEngine.Color color
	{
		get
		{
			if (this.mWidget != null)
			{
				return this.mWidget.color;
			}
			if (this.mLight != null)
			{
				return this.mLight.color;
			}
			if (this.mMat != null)
			{
				return this.mMat.color;
			}
			return global::UnityEngine.Color.black;
		}
		set
		{
			if (this.mWidget != null)
			{
				this.mWidget.color = value;
			}
			if (this.mMat != null)
			{
				this.mMat.color = value;
			}
			if (this.mLight != null)
			{
				this.mLight.color = value;
				this.mLight.enabled = (value.r + value.g + value.b > 0.01f);
			}
		}
	}

	// Token: 0x06004F75 RID: 20341 RVA: 0x00134B20 File Offset: 0x00132D20
	private void Awake()
	{
		this.mWidget = base.GetComponentInChildren<global::UIWidget>();
		global::UnityEngine.Renderer renderer = base.renderer;
		if (renderer != null)
		{
			this.mMat = renderer.material;
		}
		this.mLight = base.light;
	}

	// Token: 0x06004F76 RID: 20342 RVA: 0x00134B64 File Offset: 0x00132D64
	protected override void OnUpdate(float factor)
	{
		global::UnityEngine.Color color = this.from * (1f - factor) + this.to * factor;
		if (this.isFullscreen)
		{
			global::GFxImageEffect_GameFullscreen.autoFadeColor = color;
			color.a = 0f;
		}
		this.color = color;
	}

	// Token: 0x06004F77 RID: 20343 RVA: 0x00134BBC File Offset: 0x00132DBC
	public static global::TweenColor Begin(global::UnityEngine.GameObject go, float duration, global::UnityEngine.Color color)
	{
		global::TweenColor tweenColor = global::UITweener.Begin<global::TweenColor>(go, duration);
		tweenColor.from = tweenColor.color;
		tweenColor.to = color;
		return tweenColor;
	}

	// Token: 0x04002BEB RID: 11243
	public global::UnityEngine.Color from = global::UnityEngine.Color.white;

	// Token: 0x04002BEC RID: 11244
	public global::UnityEngine.Color to = global::UnityEngine.Color.white;

	// Token: 0x04002BED RID: 11245
	[global::System.NonSerialized]
	public bool isFullscreen;

	// Token: 0x04002BEE RID: 11246
	private global::UnityEngine.Transform mTrans;

	// Token: 0x04002BEF RID: 11247
	private global::UIWidget mWidget;

	// Token: 0x04002BF0 RID: 11248
	private global::UnityEngine.Material mMat;

	// Token: 0x04002BF1 RID: 11249
	private global::UnityEngine.Light mLight;
}
