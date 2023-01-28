using System;
using UnityEngine;

// Token: 0x020008D3 RID: 2259
[global::UnityEngine.AddComponentMenu("NGUI/Examples/Slider Colors")]
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::UISlider))]
public class UISliderColors : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004DB3 RID: 19891 RVA: 0x0012983C File Offset: 0x00127A3C
	public UISliderColors()
	{
	}

	// Token: 0x06004DB4 RID: 19892 RVA: 0x00129890 File Offset: 0x00127A90
	private void Start()
	{
		this.mSlider = base.GetComponent<global::UISlider>();
		this.Update();
	}

	// Token: 0x06004DB5 RID: 19893 RVA: 0x001298A4 File Offset: 0x00127AA4
	private void Update()
	{
		if (this.sprite == null || this.colors.Length == 0)
		{
			return;
		}
		float num = this.mSlider.sliderValue;
		num *= (float)(this.colors.Length - 1);
		int num2 = global::UnityEngine.Mathf.FloorToInt(num);
		global::UnityEngine.Color color = this.colors[0];
		if (num2 >= 0)
		{
			if (num2 + 1 < this.colors.Length)
			{
				float num3 = num - (float)num2;
				color = global::UnityEngine.Color.Lerp(this.colors[num2], this.colors[num2 + 1], num3);
			}
			else if (num2 < this.colors.Length)
			{
				color = this.colors[num2];
			}
			else
			{
				color = this.colors[this.colors.Length - 1];
			}
		}
		color.a = this.sprite.color.a;
		this.sprite.color = color;
	}

	// Token: 0x04002AA9 RID: 10921
	public global::UISprite sprite;

	// Token: 0x04002AAA RID: 10922
	public global::UnityEngine.Color[] colors = new global::UnityEngine.Color[]
	{
		global::UnityEngine.Color.red,
		global::UnityEngine.Color.yellow,
		global::UnityEngine.Color.green
	};

	// Token: 0x04002AAB RID: 10923
	private global::UISlider mSlider;
}
