using System;
using UnityEngine;

// Token: 0x020007C3 RID: 1987
public class SoundPoolTest : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060041EE RID: 16878 RVA: 0x000EF170 File Offset: 0x000ED370
	public SoundPoolTest()
	{
	}

	// Token: 0x060041EF RID: 16879 RVA: 0x000EF178 File Offset: 0x000ED378
	private void OnEnable()
	{
		this.first = true;
	}

	// Token: 0x060041F0 RID: 16880 RVA: 0x000EF184 File Offset: 0x000ED384
	private void Update()
	{
		if (this.clips != null && this.intervalPlayRandomClip > 0f)
		{
			float num = global::UnityEngine.Mathf.Max(0.05f, this.intervalPlayRandomClip);
			if (this.first)
			{
				this.lastTime = global::UnityEngine.Time.time - num;
			}
			this.first = false;
			while (global::UnityEngine.Time.time - this.lastTime >= num)
			{
				global::UnityEngine.AudioClip clip = this.clips[global::UnityEngine.Random.Range(0, this.clips.Length)];
				if (this.on != null && this.on.Length > 0 && global::UnityEngine.Random.value <= this.chanceOn)
				{
					clip.Play(this.on[global::UnityEngine.Random.Range(0, this.on.Length)]);
				}
				else
				{
					clip.Play();
				}
				this.lastTime += num;
			}
		}
		else
		{
			this.first = true;
		}
	}

	// Token: 0x060041F1 RID: 16881 RVA: 0x000EF274 File Offset: 0x000ED474
	public void OnGUI()
	{
		if (this.clips != null)
		{
			foreach (global::UnityEngine.AudioClip audioClip in this.clips)
			{
				if (global::UnityEngine.GUILayout.Button(audioClip.name, new global::UnityEngine.GUILayoutOption[0]))
				{
					audioClip.Play();
				}
			}
		}
		global::UnityEngine.GUI.Box(new global::UnityEngine.Rect((float)(global::UnityEngine.Screen.width - 0x100), 0f, 256f, 24f), "Total Sound Nodes   " + global::SoundPool.totalCount);
		global::UnityEngine.GUI.Box(new global::UnityEngine.Rect((float)(global::UnityEngine.Screen.width - 0x100), 30f, 256f, 24f), "Playing Sound Nodes " + global::SoundPool.playingCount);
		global::UnityEngine.GUI.Box(new global::UnityEngine.Rect((float)(global::UnityEngine.Screen.width - 0x100), 60f, 256f, 24f), "Reserve Sound Nodes " + global::SoundPool.reserveCount);
		if (global::UnityEngine.GUI.Button(new global::UnityEngine.Rect((float)(global::UnityEngine.Screen.width - 0x80), 90f, 128f, 24f), "Drain Reserves"))
		{
			global::SoundPool.DrainReserves();
		}
		if (global::UnityEngine.GUI.Button(new global::UnityEngine.Rect((float)(global::UnityEngine.Screen.width - 0x80), 120f, 128f, 24f), "Drain"))
		{
			global::SoundPool.Drain();
		}
		if (global::UnityEngine.GUI.Button(new global::UnityEngine.Rect((float)(global::UnityEngine.Screen.width - 0x80), 150f, 128f, 24f), "Stop All"))
		{
			global::SoundPool.Stop();
		}
	}

	// Token: 0x040022AE RID: 8878
	public global::UnityEngine.AudioClip[] clips;

	// Token: 0x040022AF RID: 8879
	public global::UnityEngine.Transform[] on;

	// Token: 0x040022B0 RID: 8880
	public float chanceOn;

	// Token: 0x040022B1 RID: 8881
	public float intervalPlayRandomClip;

	// Token: 0x040022B2 RID: 8882
	private float lastTime;

	// Token: 0x040022B3 RID: 8883
	private bool first;
}
