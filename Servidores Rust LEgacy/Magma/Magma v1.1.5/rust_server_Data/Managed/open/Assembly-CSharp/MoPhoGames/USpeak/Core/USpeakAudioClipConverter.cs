using System;
using MoPhoGames.USpeak.Core.Utils;
using UnityEngine;

namespace MoPhoGames.USpeak.Core
{
	// Token: 0x020000CD RID: 205
	public class USpeakAudioClipConverter
	{
		// Token: 0x06000404 RID: 1028 RVA: 0x00013380 File Offset: 0x00011580
		public USpeakAudioClipConverter()
		{
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x00013388 File Offset: 0x00011588
		public static short[] AudioDataToShorts(float[] samples, int channels, float gain = 1f)
		{
			short[] @short = global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.GetShort(samples.Length * channels);
			for (int i = 0; i < samples.Length; i++)
			{
				float num = samples[i] * gain;
				if (global::UnityEngine.Mathf.Abs(num) > 1f)
				{
					if (num > 0f)
					{
						num = 1f;
					}
					else
					{
						num = -1f;
					}
				}
				float num2 = num * 3267f;
				@short[i] = (short)num2;
			}
			return @short;
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x000133F4 File Offset: 0x000115F4
		public static float[] ShortsToAudioData(short[] data, int channels, int frequency, bool threedimensional, float gain)
		{
			float[] @float = global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.GetFloat(data.Length);
			for (int i = 0; i < @float.Length; i++)
			{
				int num = (int)data[i];
				@float[i] = (float)num / 3267f * gain;
			}
			return @float;
		}
	}
}
