using System;
using MoPhoGames.USpeak.Core.Utils;

namespace MoPhoGames.USpeak.Codec
{
	// Token: 0x020000C4 RID: 196
	[global::System.Serializable]
	public class MuLawCodec : global::MoPhoGames.USpeak.Codec.ICodec
	{
		// Token: 0x060003D5 RID: 981 RVA: 0x00012794 File Offset: 0x00010994
		public MuLawCodec()
		{
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x0001279C File Offset: 0x0001099C
		public byte[] Encode(short[] data, global::BandMode mode)
		{
			return global::MoPhoGames.USpeak.Codec.MuLawCodec.MuLawEncoder.MuLawEncode(data);
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x000127A4 File Offset: 0x000109A4
		public short[] Decode(byte[] data, global::BandMode mode)
		{
			return global::MoPhoGames.USpeak.Codec.MuLawCodec.MuLawDecoder.MuLawDecode(data);
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x000127AC File Offset: 0x000109AC
		public int GetSampleSize(int recordingFrequency)
		{
			return 0;
		}

		// Token: 0x020000C5 RID: 197
		private class MuLawEncoder
		{
			// Token: 0x060003D9 RID: 985 RVA: 0x000127B0 File Offset: 0x000109B0
			public MuLawEncoder()
			{
			}

			// Token: 0x060003DA RID: 986 RVA: 0x000127B8 File Offset: 0x000109B8
			static MuLawEncoder()
			{
				for (int i = -0x8000; i <= 0x7FFF; i++)
				{
					global::MoPhoGames.USpeak.Codec.MuLawCodec.MuLawEncoder.pcmToMuLawMap[i & 0xFFFF] = global::MoPhoGames.USpeak.Codec.MuLawCodec.MuLawEncoder.encode(i);
				}
			}

			// Token: 0x17000088 RID: 136
			// (get) Token: 0x060003DB RID: 987 RVA: 0x00012804 File Offset: 0x00010A04
			// (set) Token: 0x060003DC RID: 988 RVA: 0x00012818 File Offset: 0x00010A18
			public static bool ZeroTrap
			{
				get
				{
					return global::MoPhoGames.USpeak.Codec.MuLawCodec.MuLawEncoder.pcmToMuLawMap[0x80E8] != 0;
				}
				set
				{
					byte b = (!value) ? 0 : 2;
					for (int i = 0x8000; i <= 0x8484; i++)
					{
						global::MoPhoGames.USpeak.Codec.MuLawCodec.MuLawEncoder.pcmToMuLawMap[i] = b;
					}
				}
			}

			// Token: 0x060003DD RID: 989 RVA: 0x00012858 File Offset: 0x00010A58
			public static byte MuLawEncode(int pcm)
			{
				return global::MoPhoGames.USpeak.Codec.MuLawCodec.MuLawEncoder.pcmToMuLawMap[pcm & 0xFFFF];
			}

			// Token: 0x060003DE RID: 990 RVA: 0x00012868 File Offset: 0x00010A68
			public static byte MuLawEncode(short pcm)
			{
				return global::MoPhoGames.USpeak.Codec.MuLawCodec.MuLawEncoder.pcmToMuLawMap[(int)pcm & 0xFFFF];
			}

			// Token: 0x060003DF RID: 991 RVA: 0x00012878 File Offset: 0x00010A78
			public static byte[] MuLawEncode(int[] pcm)
			{
				int num = pcm.Length;
				byte[] @byte = global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.GetByte(num);
				for (int i = 0; i < num; i++)
				{
					@byte[i] = global::MoPhoGames.USpeak.Codec.MuLawCodec.MuLawEncoder.MuLawEncode(pcm[i]);
				}
				return @byte;
			}

			// Token: 0x060003E0 RID: 992 RVA: 0x000128B0 File Offset: 0x00010AB0
			public static byte[] MuLawEncode(short[] pcm)
			{
				int num = pcm.Length;
				byte[] @byte = global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.GetByte(num);
				for (int i = 0; i < num; i++)
				{
					@byte[i] = global::MoPhoGames.USpeak.Codec.MuLawCodec.MuLawEncoder.MuLawEncode(pcm[i]);
				}
				return @byte;
			}

			// Token: 0x060003E1 RID: 993 RVA: 0x000128E8 File Offset: 0x00010AE8
			private static byte encode(int pcm)
			{
				int num = (pcm & 0x8000) >> 8;
				if (num != 0)
				{
					pcm = -pcm;
				}
				if (pcm > 0x7F7B)
				{
					pcm = 0x7F7B;
				}
				pcm += 0x84;
				int num2 = 7;
				int num3 = 0x4000;
				while ((pcm & num3) == 0)
				{
					num2--;
					num3 >>= 1;
				}
				int num4 = pcm >> num2 + 3 & 0xF;
				byte b = (byte)(num | num2 << 4 | num4);
				return ~b;
			}

			// Token: 0x04000393 RID: 915
			public const int BIAS = 0x84;

			// Token: 0x04000394 RID: 916
			public const int MAX = 0x7F7B;

			// Token: 0x04000395 RID: 917
			private static byte[] pcmToMuLawMap = new byte[0x10000];
		}

		// Token: 0x020000C6 RID: 198
		private class MuLawDecoder
		{
			// Token: 0x060003E2 RID: 994 RVA: 0x0001295C File Offset: 0x00010B5C
			public MuLawDecoder()
			{
			}

			// Token: 0x060003E3 RID: 995 RVA: 0x00012964 File Offset: 0x00010B64
			static MuLawDecoder()
			{
				for (byte b = 0; b < 0xFF; b += 1)
				{
					global::MoPhoGames.USpeak.Codec.MuLawCodec.MuLawDecoder.muLawToPcmMap[(int)b] = global::MoPhoGames.USpeak.Codec.MuLawCodec.MuLawDecoder.Decode(b);
				}
			}

			// Token: 0x060003E4 RID: 996 RVA: 0x000129A4 File Offset: 0x00010BA4
			public static short[] MuLawDecode(byte[] data)
			{
				int num = data.Length;
				short[] @short = global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.GetShort(num);
				for (int i = 0; i < num; i++)
				{
					@short[i] = global::MoPhoGames.USpeak.Codec.MuLawCodec.MuLawDecoder.muLawToPcmMap[(int)data[i]];
				}
				return @short;
			}

			// Token: 0x060003E5 RID: 997 RVA: 0x000129DC File Offset: 0x00010BDC
			private static short Decode(byte mulaw)
			{
				mulaw = ~mulaw;
				int num = (int)(mulaw & 0x80);
				int num2 = (mulaw & 0x70) >> 4;
				int num3 = (int)(mulaw & 0xF);
				num3 |= 0x10;
				num3 <<= 1;
				num3++;
				num3 <<= num2 + 2;
				num3 -= 0x84;
				return (short)((num != 0) ? (-(short)num3) : num3);
			}

			// Token: 0x04000396 RID: 918
			private static readonly short[] muLawToPcmMap = new short[0x100];
		}
	}
}
