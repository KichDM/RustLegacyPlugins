using System;
using MoPhoGames.USpeak.Core.Utils;

namespace MoPhoGames.USpeak.Codec
{
	// Token: 0x020000C2 RID: 194
	[global::System.Serializable]
	internal class ADPCMCodec : global::MoPhoGames.USpeak.Codec.ICodec
	{
		// Token: 0x060003CA RID: 970 RVA: 0x000123B8 File Offset: 0x000105B8
		public ADPCMCodec()
		{
		}

		// Token: 0x060003CB RID: 971 RVA: 0x000123C8 File Offset: 0x000105C8
		// Note: this type is marked as 'beforefieldinit'.
		static ADPCMCodec()
		{
		}

		// Token: 0x060003CC RID: 972 RVA: 0x00012404 File Offset: 0x00010604
		private void Init()
		{
			this.predictedSample = 0;
			this.stepsize = 7;
			this.index = 0;
			this.newSample = 0;
		}

		// Token: 0x060003CD RID: 973 RVA: 0x00012424 File Offset: 0x00010624
		private short ADPCM_Decode(byte originalSample)
		{
			int num = this.stepsize * (int)originalSample / 4 + this.stepsize / 8;
			if ((originalSample & 4) == 4)
			{
				num += this.stepsize;
			}
			if ((originalSample & 2) == 2)
			{
				num += this.stepsize >> 1;
			}
			if ((originalSample & 1) == 1)
			{
				num += this.stepsize >> 2;
			}
			num += this.stepsize >> 3;
			if ((originalSample & 8) == 8)
			{
				num = -num;
			}
			this.newSample = num;
			if (this.newSample > 0x7FFF)
			{
				this.newSample = 0x7FFF;
			}
			else if (this.newSample < -0x8000)
			{
				this.newSample = -0x8000;
			}
			this.index += global::MoPhoGames.USpeak.Codec.ADPCMCodec.indexTable[(int)originalSample];
			if (this.index < 0)
			{
				this.index = 0;
			}
			if (this.index > 0x58)
			{
				this.index = 0x58;
			}
			this.stepsize = global::MoPhoGames.USpeak.Codec.ADPCMCodec.stepsizeTable[this.index];
			return (short)this.newSample;
		}

		// Token: 0x060003CE RID: 974 RVA: 0x00012530 File Offset: 0x00010730
		private byte ADPCM_Encode(short originalSample)
		{
			int num = (int)originalSample - this.predictedSample;
			if (num >= 0)
			{
				this.newSample = 0;
			}
			else
			{
				this.newSample = 8;
				num = -num;
			}
			byte b = 4;
			int num2 = this.stepsize;
			for (int i = 0; i < 3; i++)
			{
				if (num >= num2)
				{
					this.newSample |= (int)b;
					num -= num2;
				}
				num2 >>= 1;
				b = (byte)(b >> 1);
			}
			num = this.stepsize >> 3;
			if ((this.newSample & 4) != 0)
			{
				num += this.stepsize;
			}
			if ((this.newSample & 2) != 0)
			{
				num += this.stepsize >> 1;
			}
			if ((this.newSample & 1) != 0)
			{
				num += this.stepsize >> 2;
			}
			if ((this.newSample & 8) != 0)
			{
				num = -num;
			}
			this.predictedSample += num;
			if (this.predictedSample > 0x7FFF)
			{
				this.predictedSample = 0x7FFF;
			}
			if (this.predictedSample < -0x8000)
			{
				this.predictedSample = -0x8000;
			}
			this.index += global::MoPhoGames.USpeak.Codec.ADPCMCodec.indexTable[this.newSample];
			if (this.index < 0)
			{
				this.index = 0;
			}
			else if (this.index > 0x58)
			{
				this.index = 0x58;
			}
			this.stepsize = global::MoPhoGames.USpeak.Codec.ADPCMCodec.stepsizeTable[this.index];
			return (byte)this.newSample;
		}

		// Token: 0x060003CF RID: 975 RVA: 0x000126A4 File Offset: 0x000108A4
		public byte[] Encode(short[] data, global::BandMode mode)
		{
			this.Init();
			int num = data.Length / 2;
			if (num % 2 != 0)
			{
				num++;
			}
			byte[] @byte = global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.GetByte(num);
			for (int i = 0; i < @byte.Length; i++)
			{
				if (i * 2 >= data.Length)
				{
					break;
				}
				byte b = this.ADPCM_Encode(data[i * 2]);
				byte b2 = 0;
				if (i * 2 + 1 < data.Length)
				{
					b2 = this.ADPCM_Encode(data[i * 2 + 1]);
				}
				byte b3 = (byte)((int)b2 << 4 | (int)b);
				@byte[i] = b3;
			}
			return @byte;
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x00012730 File Offset: 0x00010930
		public short[] Decode(byte[] data, global::BandMode mode)
		{
			this.Init();
			short[] @short = global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.GetShort(data.Length * 2);
			for (int i = 0; i < data.Length; i++)
			{
				byte b = data[i];
				byte originalSample = b & 0xF;
				byte originalSample2 = (byte)(b >> 4);
				@short[i * 2] = this.ADPCM_Decode(originalSample);
				@short[i * 2 + 1] = this.ADPCM_Decode(originalSample2);
			}
			return @short;
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x00012790 File Offset: 0x00010990
		public int GetSampleSize(int recordingFrequency)
		{
			return 0;
		}

		// Token: 0x0400038D RID: 909
		private static int[] indexTable = new int[]
		{
			-1,
			-1,
			-1,
			-1,
			2,
			4,
			6,
			8,
			-1,
			-1,
			-1,
			-1,
			2,
			4,
			6,
			8
		};

		// Token: 0x0400038E RID: 910
		private static int[] stepsizeTable = new int[]
		{
			7,
			8,
			9,
			0xA,
			0xB,
			0xC,
			0xE,
			0x10,
			0x11,
			0x13,
			0x15,
			0x17,
			0x19,
			0x1C,
			0x1F,
			0x22,
			0x25,
			0x29,
			0x2D,
			0x32,
			0x37,
			0x3C,
			0x42,
			0x49,
			0x50,
			0x58,
			0x61,
			0x6B,
			0x76,
			0x82,
			0x8F,
			0x9D,
			0xAD,
			0xBE,
			0xD1,
			0xE6,
			0xFD,
			0x117,
			0x133,
			0x151,
			0x173,
			0x198,
			0x1C1,
			0x1EE,
			0x220,
			0x256,
			0x292,
			0x2D4,
			0x31C,
			0x36C,
			0x3C3,
			0x424,
			0x48E,
			0x502,
			0x583,
			0x5F2,
			0x6AB,
			0x754,
			0x812,
			0x8E0,
			0x9C3,
			0xABD,
			0xBD0,
			0xCFF,
			0xE4C,
			0xFBA,
			0x114C,
			0x1307,
			0x14EE,
			0x1706,
			0x1954,
			0x1BDC,
			0x1EA5,
			0x21B6,
			0x2515,
			0x28CA,
			0x2CDF,
			0x315B,
			0x364B,
			0x3BB9,
			0x41B2,
			0x4844,
			0x31AEC,
			0x5771,
			0x602F,
			0x69CE,
			0x7462,
			0x7FFF
		};

		// Token: 0x0400038F RID: 911
		private int predictedSample;

		// Token: 0x04000390 RID: 912
		private int stepsize = 7;

		// Token: 0x04000391 RID: 913
		private int index;

		// Token: 0x04000392 RID: 914
		private int newSample;
	}
}
