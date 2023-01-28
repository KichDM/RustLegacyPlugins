using System;
using UnityEngine;

// Token: 0x0200054B RID: 1355
public class UIActionProgress : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002E2F RID: 11823 RVA: 0x000AFA5C File Offset: 0x000ADC5C
	public UIActionProgress()
	{
	}

	// Token: 0x170009DD RID: 2525
	// (get) Token: 0x06002E30 RID: 11824 RVA: 0x000AFA64 File Offset: 0x000ADC64
	public global::UILabel label
	{
		get
		{
			return this._label;
		}
	}

	// Token: 0x170009DE RID: 2526
	// (get) Token: 0x06002E31 RID: 11825 RVA: 0x000AFA6C File Offset: 0x000ADC6C
	public global::UISlider slider
	{
		get
		{
			return this._slider;
		}
	}

	// Token: 0x170009DF RID: 2527
	// (get) Token: 0x06002E32 RID: 11826 RVA: 0x000AFA74 File Offset: 0x000ADC74
	// (set) Token: 0x06002E33 RID: 11827 RVA: 0x000AFA84 File Offset: 0x000ADC84
	public string text
	{
		get
		{
			return this.label.text;
		}
		set
		{
			this.label.text = value;
		}
	}

	// Token: 0x170009E0 RID: 2528
	// (get) Token: 0x06002E34 RID: 11828 RVA: 0x000AFA94 File Offset: 0x000ADC94
	// (set) Token: 0x06002E35 RID: 11829 RVA: 0x000AFAA4 File Offset: 0x000ADCA4
	public float progress
	{
		get
		{
			return this.slider.sliderValue;
		}
		set
		{
			this.slider.sliderValue = value;
		}
	}

	// Token: 0x06002E36 RID: 11830 RVA: 0x000AFAB4 File Offset: 0x000ADCB4
	private void Awake()
	{
		this.sliderSprites = this._slider.GetComponentsInChildren<global::UISprite>();
	}

	// Token: 0x06002E37 RID: 11831 RVA: 0x000AFAC8 File Offset: 0x000ADCC8
	private void SetEnabled(bool yes)
	{
		if (this._slider)
		{
			this._slider.enabled = yes;
		}
		if (this._label)
		{
			this._label.enabled = yes;
		}
		if (this.sliderSprites != null)
		{
			foreach (global::UISprite uisprite in this.sliderSprites)
			{
				if (uisprite)
				{
					uisprite.enabled = yes;
				}
			}
		}
	}

	// Token: 0x06002E38 RID: 11832 RVA: 0x000AFB4C File Offset: 0x000ADD4C
	private void OnEnable()
	{
		this.SetEnabled(true);
	}

	// Token: 0x06002E39 RID: 11833 RVA: 0x000AFB58 File Offset: 0x000ADD58
	private void OnDisable()
	{
		this.SetEnabled(false);
	}

	// Token: 0x040017E0 RID: 6112
	[global::UnityEngine.SerializeField]
	private global::UILabel _label;

	// Token: 0x040017E1 RID: 6113
	[global::UnityEngine.SerializeField]
	private global::UISlider _slider;

	// Token: 0x040017E2 RID: 6114
	private global::UISprite[] sliderSprites;
}
