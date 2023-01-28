using System;
using System.Collections.Generic;
using System.IO;
using MoPhoGames.USpeak.Codec;
using MoPhoGames.USpeak.Core.Utils;
using UnityEngine;

namespace MoPhoGames.USpeak.Core
{
	// Token: 0x020000CC RID: 204
	public class USpeakAudioClipCompressor : global::UnityEngine.MonoBehaviour
	{
		// Token: 0x060003FF RID: 1023 RVA: 0x0001325C File Offset: 0x0001145C
		public USpeakAudioClipCompressor()
		{
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x00013264 File Offset: 0x00011464
		// Note: this type is marked as 'beforefieldinit'.
		static USpeakAudioClipCompressor()
		{
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x0001327C File Offset: 0x0001147C
		public static byte[] CompressAudioData(float[] samples, int channels, out int sample_count, global::BandMode mode, global::MoPhoGames.USpeak.Codec.ICodec Codec, float gain = 1f)
		{
			global::MoPhoGames.USpeak.Core.USpeakAudioClipCompressor.data.Clear();
			sample_count = 0;
			short[] d = global::MoPhoGames.USpeak.Core.USpeakAudioClipConverter.AudioDataToShorts(samples, channels, gain);
			byte[] array = Codec.Encode(d, mode);
			global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.Return(d);
			global::MoPhoGames.USpeak.Core.USpeakAudioClipCompressor.data.AddRange(array);
			global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.Return(array);
			return global::MoPhoGames.USpeak.Core.USpeakAudioClipCompressor.data.ToArray();
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x000132CC File Offset: 0x000114CC
		public static float[] DecompressAudio(byte[] data, int samples, int channels, bool threeD, global::BandMode mode, global::MoPhoGames.USpeak.Codec.ICodec Codec, float gain)
		{
			int frequency = 0xFA0;
			if (mode == global::BandMode.Narrow)
			{
				frequency = 0x1F40;
			}
			else if (mode == global::BandMode.Wide)
			{
				frequency = 0x3E80;
			}
			short[] array = Codec.Decode(data, mode);
			global::MoPhoGames.USpeak.Core.USpeakAudioClipCompressor.tmp.Clear();
			global::MoPhoGames.USpeak.Core.USpeakAudioClipCompressor.tmp.AddRange(array);
			global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.Return(array);
			return global::MoPhoGames.USpeak.Core.USpeakAudioClipConverter.ShortsToAudioData(global::MoPhoGames.USpeak.Core.USpeakAudioClipCompressor.tmp.ToArray(), channels, frequency, threeD, gain);
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x0001333C File Offset: 0x0001153C
		private static void CopyStream(global::System.IO.Stream input, global::System.IO.Stream output)
		{
			byte[] @byte = global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.GetByte(0x8000);
			for (;;)
			{
				int num = input.Read(@byte, 0, @byte.Length);
				if (num <= 0)
				{
					break;
				}
				output.Write(@byte, 0, num);
			}
			global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.Return(@byte);
		}

		// Token: 0x040003D3 RID: 979
		private static global::System.Collections.Generic.List<byte> data = new global::System.Collections.Generic.List<byte>();

		// Token: 0x040003D4 RID: 980
		private static global::System.Collections.Generic.List<short> tmp = new global::System.Collections.Generic.List<short>();
	}
}
