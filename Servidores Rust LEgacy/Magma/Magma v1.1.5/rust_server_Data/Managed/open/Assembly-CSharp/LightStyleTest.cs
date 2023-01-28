using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200073C RID: 1852
public class LightStyleTest : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06003E7D RID: 15997 RVA: 0x000DC9A0 File Offset: 0x000DABA0
	public LightStyleTest()
	{
	}

	// Token: 0x06003E7E RID: 15998 RVA: 0x000DC9CC File Offset: 0x000DABCC
	private void Update()
	{
		if (global::UnityEngine.Input.GetKeyDown(0x112))
		{
			this.index = (this.index + 1) % this.tests.Length;
		}
		if (global::UnityEngine.Input.GetKeyDown(0x111))
		{
			this.index = (this.index + (this.tests.Length - 1)) % this.tests.Length;
		}
		if (global::UnityEngine.Input.GetKey(0x20))
		{
			this.stylist.Blend(this.tests[this.index], this.spacebarTargetWeight, this.spacebarFadeLength);
		}
		if (global::UnityEngine.Input.GetKeyDown(0xD))
		{
			this.stylist.CrossFade(this.tests[this.index], this.enterCrossfadeLength);
		}
		if (global::UnityEngine.Input.GetKeyDown(0x132) | global::UnityEngine.Input.GetKeyDown(0x131))
		{
			this.stylist.Play(this.tests[this.index]);
		}
	}

	// Token: 0x06003E7F RID: 15999 RVA: 0x000DCACC File Offset: 0x000DACCC
	private void OnGUI()
	{
		for (int i = 0; i < this.tests.Length; i++)
		{
			if (this.index == i)
			{
				global::UnityEngine.GUILayout.Box(this.tests[i], new global::UnityEngine.GUILayoutOption[0]);
			}
			else
			{
				global::UnityEngine.GUILayout.Label(this.tests[i], new global::UnityEngine.GUILayoutOption[0]);
			}
		}
		if (global::UnityEngine.Event.current.type == 7)
		{
			if (this.weights == null)
			{
				this.weights = new global::System.Collections.Generic.List<float>();
			}
			else
			{
				this.weights.Clear();
			}
			this.weights.AddRange(this.stylist.Weights);
			int count = this.weights.Count;
			for (int j = 0; j < count; j++)
			{
				global::UnityEngine.GUI.Box(new global::UnityEngine.Rect((float)(global::UnityEngine.Screen.width / count * j), (float)(global::UnityEngine.Screen.height - 0x78), (float)(global::UnityEngine.Screen.width / count), 120f * this.weights[j]), this.weights[j].ToString());
			}
			global::UnityEngine.GUI.Label(new global::UnityEngine.Rect((float)(global::UnityEngine.Screen.width - 0x190), 0f, 400f, 100f), "\nPress up and down to change light style.\nHold space to apply it through LightStylist.Blend\nPress enter to apply it through LightStylist.CrossFade\nPress ctrl to apply it through LightStylist.Play");
		}
	}

	// Token: 0x06003E80 RID: 16000 RVA: 0x000DCC08 File Offset: 0x000DAE08
	private void Reset()
	{
		this.tests = new string[]
		{
			"pulsate"
		};
	}

	// Token: 0x04001FEC RID: 8172
	public global::LightStylist stylist;

	// Token: 0x04001FED RID: 8173
	public string[] tests;

	// Token: 0x04001FEE RID: 8174
	public float spacebarTargetWeight = 1f;

	// Token: 0x04001FEF RID: 8175
	public float spacebarFadeLength = 1.3f;

	// Token: 0x04001FF0 RID: 8176
	public float enterCrossfadeLength = 0.3f;

	// Token: 0x04001FF1 RID: 8177
	private int index;

	// Token: 0x04001FF2 RID: 8178
	private global::System.Collections.Generic.List<float> weights;
}
