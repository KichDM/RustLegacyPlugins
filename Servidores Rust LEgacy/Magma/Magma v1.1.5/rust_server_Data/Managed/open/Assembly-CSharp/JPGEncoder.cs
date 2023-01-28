using System;
using System.IO;
using System.Threading;
using UnityEngine;

// Token: 0x020004F9 RID: 1273
public class JPGEncoder
{
	// Token: 0x06002BDF RID: 11231 RVA: 0x000A4848 File Offset: 0x000A2A48
	public JPGEncoder(global::UnityEngine.Texture2D texture, float quality) : this(texture, quality, string.Empty, false)
	{
	}

	// Token: 0x06002BE0 RID: 11232 RVA: 0x000A4858 File Offset: 0x000A2A58
	public JPGEncoder(global::UnityEngine.Texture2D texture, float quality, bool blocking) : this(texture, quality, string.Empty, blocking)
	{
	}

	// Token: 0x06002BE1 RID: 11233 RVA: 0x000A4868 File Offset: 0x000A2A68
	public JPGEncoder(global::UnityEngine.Texture2D texture, float quality, string path) : this(texture, quality, path, false)
	{
	}

	// Token: 0x06002BE2 RID: 11234 RVA: 0x000A4874 File Offset: 0x000A2A74
	public JPGEncoder(global::UnityEngine.Texture2D texture, float quality, string path, bool blocking)
	{
		this.path = path;
		this.image = new global::JPGEncoder.BitmapData(texture);
		quality = global::UnityEngine.Mathf.Clamp(quality, 1f, 100f);
		this.sf = ((quality >= 50f) ? ((int)(200f - quality * 2f)) : ((int)(5000f / quality)));
		this.cores = global::UnityEngine.SystemInfo.processorCount;
		global::System.Threading.Thread thread = new global::System.Threading.Thread(new global::System.Threading.ThreadStart(this.DoEncoding));
		thread.Start();
		if (blocking)
		{
			thread.Join();
		}
	}

	// Token: 0x06002BE3 RID: 11235 RVA: 0x000A4A80 File Offset: 0x000A2C80
	private void InitQuantTables(int sf)
	{
		int[] array = new int[]
		{
			0x10,
			0xB,
			0xA,
			0x10,
			0x18,
			0x28,
			0x33,
			0x3D,
			0xC,
			0xC,
			0xE,
			0x13,
			0x1A,
			0x3A,
			0x3C,
			0x37,
			0xE,
			0xD,
			0x10,
			0x18,
			0x28,
			0x39,
			0x45,
			0x38,
			0xE,
			0x11,
			0x16,
			0x1D,
			0x33,
			0x57,
			0x50,
			0x3E,
			0x12,
			0x16,
			0x25,
			0x38,
			0x44,
			0x6D,
			0x67,
			0x4D,
			0x18,
			0x23,
			0x37,
			0x40,
			0x51,
			0x68,
			0x71,
			0x5C,
			0x31,
			0x40,
			0x4E,
			0x57,
			0x67,
			0x79,
			0x78,
			0x65,
			0x48,
			0x5C,
			0x5F,
			0x62,
			0x70,
			0x64,
			0x67,
			0x63
		};
		int i;
		for (i = 0; i < 0x40; i++)
		{
			float num = global::UnityEngine.Mathf.Floor((float)((array[i] * sf + 0x32) / 0x64));
			num = global::UnityEngine.Mathf.Clamp(num, 1f, 255f);
			this.YTable[this.ZigZag[i]] = global::UnityEngine.Mathf.RoundToInt(num);
		}
		int[] array2 = new int[]
		{
			0x11,
			0x12,
			0x18,
			0x2F,
			0x63,
			0x63,
			0x63,
			0x63,
			0x12,
			0x15,
			0x1A,
			0x42,
			0x63,
			0x63,
			0x63,
			0x63,
			0x18,
			0x1A,
			0x38,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x2F,
			0x42,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63,
			0x63
		};
		for (i = 0; i < 0x40; i++)
		{
			float num = global::UnityEngine.Mathf.Floor((float)((array2[i] * sf + 0x32) / 0x64));
			num = global::UnityEngine.Mathf.Clamp(num, 1f, 255f);
			this.UVTable[this.ZigZag[i]] = (int)num;
		}
		float[] array3 = new float[]
		{
			1f,
			1.3870399f,
			1.306563f,
			1.1758755f,
			1f,
			0.78569496f,
			0.5411961f,
			0.27589938f
		};
		i = 0;
		for (int j = 0; j < 8; j++)
		{
			for (int k = 0; k < 8; k++)
			{
				this.fdtbl_Y[i] = 1f / ((float)this.YTable[this.ZigZag[i]] * array3[j] * array3[k] * 8f);
				this.fdtbl_UV[i] = 1f / ((float)this.UVTable[this.ZigZag[i]] * array3[j] * array3[k] * 8f);
				i++;
			}
		}
	}

	// Token: 0x06002BE4 RID: 11236 RVA: 0x000A4BEC File Offset: 0x000A2DEC
	private global::JPGEncoder.BitString[] ComputeHuffmanTbl(byte[] nrcodes, byte[] std_table)
	{
		int num = 0;
		int num2 = 0;
		global::JPGEncoder.BitString[] array = new global::JPGEncoder.BitString[0x100];
		for (int i = 1; i <= 0x10; i++)
		{
			for (int j = 1; j <= (int)nrcodes[i]; j++)
			{
				array[(int)std_table[num2]] = default(global::JPGEncoder.BitString);
				array[(int)std_table[num2]].value = num;
				array[(int)std_table[num2]].length = i;
				num2++;
				num++;
			}
			num *= 2;
		}
		return array;
	}

	// Token: 0x06002BE5 RID: 11237 RVA: 0x000A4C78 File Offset: 0x000A2E78
	private void InitHuffmanTbl()
	{
		this.YDC_HT = this.ComputeHuffmanTbl(this.std_dc_luminance_nrcodes, this.std_dc_luminance_values);
		this.UVDC_HT = this.ComputeHuffmanTbl(this.std_dc_chrominance_nrcodes, this.std_dc_chrominance_values);
		this.YAC_HT = this.ComputeHuffmanTbl(this.std_ac_luminance_nrcodes, this.std_ac_luminance_values);
		this.UVAC_HT = this.ComputeHuffmanTbl(this.std_ac_chrominance_nrcodes, this.std_ac_chrominance_values);
	}

	// Token: 0x06002BE6 RID: 11238 RVA: 0x000A4CE8 File Offset: 0x000A2EE8
	private void InitCategoryfloat()
	{
		int num = 1;
		int num2 = 2;
		for (int i = 1; i <= 0xF; i++)
		{
			for (int j = num; j < num2; j++)
			{
				this.category[0x7FFF + j] = i;
				global::JPGEncoder.BitString bitString = default(global::JPGEncoder.BitString);
				bitString.length = i;
				bitString.value = j;
				this.bitcode[0x7FFF + j] = bitString;
			}
			for (int j = -(num2 - 1); j <= -num; j++)
			{
				this.category[0x7FFF + j] = i;
				global::JPGEncoder.BitString bitString = default(global::JPGEncoder.BitString);
				bitString.length = i;
				bitString.value = num2 - 1 + j;
				this.bitcode[0x7FFF + j] = bitString;
			}
			num <<= 1;
			num2 <<= 1;
		}
	}

	// Token: 0x06002BE7 RID: 11239 RVA: 0x000A4DC8 File Offset: 0x000A2FC8
	public byte[] GetBytes()
	{
		if (!this.isDone)
		{
			global::UnityEngine.Debug.LogError("JPEGEncoder not complete, cannot get bytes!");
			return null;
		}
		return this.byteout.GetAllBytes();
	}

	// Token: 0x06002BE8 RID: 11240 RVA: 0x000A4DF8 File Offset: 0x000A2FF8
	private void WriteBits(global::JPGEncoder.BitString bs)
	{
		int value = bs.value;
		int i = bs.length - 1;
		while (i >= 0)
		{
			if (((long)value & (long)((ulong)global::System.Convert.ToUInt32(1 << i))) != 0L)
			{
				this.bytenew |= global::System.Convert.ToUInt32(1 << this.bytepos);
			}
			i--;
			this.bytepos--;
			if (this.bytepos < 0)
			{
				if (this.bytenew == 0xFFU)
				{
					this.WriteByte(byte.MaxValue);
					this.WriteByte(0);
				}
				else
				{
					this.WriteByte((byte)this.bytenew);
				}
				this.bytepos = 7;
				this.bytenew = 0U;
			}
		}
	}

	// Token: 0x06002BE9 RID: 11241 RVA: 0x000A4EB4 File Offset: 0x000A30B4
	private void WriteByte(byte value)
	{
		this.byteout.WriteByte(value);
	}

	// Token: 0x06002BEA RID: 11242 RVA: 0x000A4EC4 File Offset: 0x000A30C4
	private void WriteWord(int value)
	{
		this.WriteByte((byte)(value >> 8 & 0xFF));
		this.WriteByte((byte)(value & 0xFF));
	}

	// Token: 0x06002BEB RID: 11243 RVA: 0x000A4EE4 File Offset: 0x000A30E4
	private float[] FDCTQuant(float[] data, float[] fdtbl)
	{
		int num = 0;
		for (int i = 0; i < 8; i++)
		{
			float num2 = data[num] + data[num + 7];
			float num3 = data[num] - data[num + 7];
			float num4 = data[num + 1] + data[num + 6];
			float num5 = data[num + 1] - data[num + 6];
			float num6 = data[num + 2] + data[num + 5];
			float num7 = data[num + 2] - data[num + 5];
			float num8 = data[num + 3] + data[num + 4];
			float num9 = data[num + 3] - data[num + 4];
			float num10 = num2 + num8;
			float num11 = num2 - num8;
			float num12 = num4 + num6;
			float num13 = num4 - num6;
			data[num] = num10 + num12;
			data[num + 4] = num10 - num12;
			float num14 = (num13 + num11) * 0.70710677f;
			data[num + 2] = num11 + num14;
			data[num + 6] = num11 - num14;
			num10 = num9 + num7;
			num12 = num7 + num5;
			num13 = num5 + num3;
			float num15 = (num10 - num13) * 0.38268343f;
			float num16 = 0.5411961f * num10 + num15;
			float num17 = 1.306563f * num13 + num15;
			float num18 = num12 * 0.70710677f;
			float num19 = num3 + num18;
			float num20 = num3 - num18;
			data[num + 5] = num20 + num16;
			data[num + 3] = num20 - num16;
			data[num + 1] = num19 + num17;
			data[num + 7] = num19 - num17;
			num += 8;
		}
		num = 0;
		for (int i = 0; i < 8; i++)
		{
			float num2 = data[num] + data[num + 0x38];
			float num3 = data[num] - data[num + 0x38];
			float num4 = data[num + 8] + data[num + 0x30];
			float num5 = data[num + 8] - data[num + 0x30];
			float num6 = data[num + 0x10] + data[num + 0x28];
			float num7 = data[num + 0x10] - data[num + 0x28];
			float num8 = data[num + 0x18] + data[num + 0x20];
			float num9 = data[num + 0x18] - data[num + 0x20];
			float num10 = num2 + num8;
			float num11 = num2 - num8;
			float num12 = num4 + num6;
			float num13 = num4 - num6;
			data[num] = num10 + num12;
			data[num + 0x20] = num10 - num12;
			float num14 = (num13 + num11) * 0.70710677f;
			data[num + 0x10] = num11 + num14;
			data[num + 0x30] = num11 - num14;
			num10 = num9 + num7;
			num12 = num7 + num5;
			num13 = num5 + num3;
			float num15 = (num10 - num13) * 0.38268343f;
			float num16 = 0.5411961f * num10 + num15;
			float num17 = 1.306563f * num13 + num15;
			float num18 = num12 * 0.70710677f;
			float num19 = num3 + num18;
			float num20 = num3 - num18;
			data[num + 0x28] = num20 + num16;
			data[num + 0x18] = num20 - num16;
			data[num + 8] = num19 + num17;
			data[num + 0x38] = num19 - num17;
			num++;
		}
		for (int i = 0; i < 0x40; i++)
		{
			data[i] = global::UnityEngine.Mathf.Round(data[i] * fdtbl[i]);
		}
		return data;
	}

	// Token: 0x06002BEC RID: 11244 RVA: 0x000A51E4 File Offset: 0x000A33E4
	private void WriteAPP0()
	{
		this.WriteWord(0xFFE0);
		this.WriteWord(0x10);
		this.WriteByte(0x4A);
		this.WriteByte(0x46);
		this.WriteByte(0x49);
		this.WriteByte(0x46);
		this.WriteByte(0);
		this.WriteByte(1);
		this.WriteByte(1);
		this.WriteByte(0);
		this.WriteWord(1);
		this.WriteWord(1);
		this.WriteByte(0);
		this.WriteByte(0);
	}

	// Token: 0x06002BED RID: 11245 RVA: 0x000A525C File Offset: 0x000A345C
	private void WriteSOF0(int width, int height)
	{
		this.WriteWord(0xFFC0);
		this.WriteWord(0x11);
		this.WriteByte(8);
		this.WriteWord(height);
		this.WriteWord(width);
		this.WriteByte(3);
		this.WriteByte(1);
		this.WriteByte(0x11);
		this.WriteByte(0);
		this.WriteByte(2);
		this.WriteByte(0x11);
		this.WriteByte(1);
		this.WriteByte(3);
		this.WriteByte(0x11);
		this.WriteByte(1);
	}

	// Token: 0x06002BEE RID: 11246 RVA: 0x000A52DC File Offset: 0x000A34DC
	private void WriteDQT()
	{
		this.WriteWord(0xFFDB);
		this.WriteWord(0x84);
		this.WriteByte(0);
		for (int i = 0; i < 0x40; i++)
		{
			this.WriteByte((byte)this.YTable[i]);
		}
		this.WriteByte(1);
		for (int i = 0; i < 0x40; i++)
		{
			this.WriteByte((byte)this.UVTable[i]);
		}
	}

	// Token: 0x06002BEF RID: 11247 RVA: 0x000A5354 File Offset: 0x000A3554
	private void WriteDHT()
	{
		this.WriteWord(0xFFC4);
		this.WriteWord(0x1A2);
		this.WriteByte(0);
		for (int i = 0; i < 0x10; i++)
		{
			this.WriteByte(this.std_dc_luminance_nrcodes[i + 1]);
		}
		for (int i = 0; i <= 0xB; i++)
		{
			this.WriteByte(this.std_dc_luminance_values[i]);
		}
		this.WriteByte(0x10);
		for (int i = 0; i < 0x10; i++)
		{
			this.WriteByte(this.std_ac_luminance_nrcodes[i + 1]);
		}
		for (int i = 0; i <= 0xA1; i++)
		{
			this.WriteByte(this.std_ac_luminance_values[i]);
		}
		this.WriteByte(1);
		for (int i = 0; i < 0x10; i++)
		{
			this.WriteByte(this.std_dc_chrominance_nrcodes[i + 1]);
		}
		for (int i = 0; i <= 0xB; i++)
		{
			this.WriteByte(this.std_dc_chrominance_values[i]);
		}
		this.WriteByte(0x11);
		for (int i = 0; i < 0x10; i++)
		{
			this.WriteByte(this.std_ac_chrominance_nrcodes[i + 1]);
		}
		for (int i = 0; i <= 0xA1; i++)
		{
			this.WriteByte(this.std_ac_chrominance_values[i]);
		}
	}

	// Token: 0x06002BF0 RID: 11248 RVA: 0x000A54AC File Offset: 0x000A36AC
	private void writeSOS()
	{
		this.WriteWord(0xFFDA);
		this.WriteWord(0xC);
		this.WriteByte(3);
		this.WriteByte(1);
		this.WriteByte(0);
		this.WriteByte(2);
		this.WriteByte(0x11);
		this.WriteByte(3);
		this.WriteByte(0x11);
		this.WriteByte(0);
		this.WriteByte(0x3F);
		this.WriteByte(0);
	}

	// Token: 0x06002BF1 RID: 11249 RVA: 0x000A5518 File Offset: 0x000A3718
	private float ProcessDU(float[] CDU, float[] fdtbl, float DC, global::JPGEncoder.BitString[] HTDC, global::JPGEncoder.BitString[] HTAC)
	{
		global::JPGEncoder.BitString bs = HTAC[0];
		global::JPGEncoder.BitString bs2 = HTAC[0xF0];
		float[] array = this.FDCTQuant(CDU, fdtbl);
		for (int i = 0; i < 0x40; i++)
		{
			this.DU[this.ZigZag[i]] = (int)array[i];
		}
		int num = (int)((float)this.DU[0] - DC);
		DC = (float)this.DU[0];
		if (num == 0)
		{
			this.WriteBits(HTDC[0]);
		}
		else
		{
			this.WriteBits(HTDC[this.category[0x7FFF + num]]);
			this.WriteBits(this.bitcode[0x7FFF + num]);
		}
		int num2 = 0x3F;
		while (num2 > 0 && this.DU[num2] == 0)
		{
			num2--;
		}
		if (num2 == 0)
		{
			this.WriteBits(bs);
			return DC;
		}
		for (int i = 1; i <= num2; i++)
		{
			int num3 = i;
			while (this.DU[i] == 0 && i <= num2)
			{
				i++;
			}
			int num4 = i - num3;
			if (num4 >= 0x10)
			{
				for (int j = 1; j <= num4 / 0x10; j++)
				{
					this.WriteBits(bs2);
				}
				num4 &= 0xF;
			}
			this.WriteBits(HTAC[num4 * 0x10 + this.category[0x7FFF + this.DU[i]]]);
			this.WriteBits(this.bitcode[0x7FFF + this.DU[i]]);
		}
		if (num2 != 0x3F)
		{
			this.WriteBits(bs);
		}
		return DC;
	}

	// Token: 0x06002BF2 RID: 11250 RVA: 0x000A56F0 File Offset: 0x000A38F0
	private void RGB2YUV(global::JPGEncoder.BitmapData image, int xpos, int ypos)
	{
		int num = 0;
		for (int i = 0; i < 8; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				global::UnityEngine.Color32 pixelColor = image.GetPixelColor(xpos + j, image.height - (ypos + i));
				this.YDU[num] = 0.299f * (float)pixelColor.r + 0.587f * (float)pixelColor.g + 0.114f * (float)pixelColor.b - 128f;
				this.UDU[num] = -0.16874f * (float)pixelColor.r + -0.33126f * (float)pixelColor.g + 0.5f * (float)pixelColor.b;
				this.VDU[num] = 0.5f * (float)pixelColor.r + -0.41869f * (float)pixelColor.g + -0.08131f * (float)pixelColor.b;
				num++;
			}
		}
	}

	// Token: 0x06002BF3 RID: 11251 RVA: 0x000A57E0 File Offset: 0x000A39E0
	private void DoEncoding()
	{
		this.isDone = false;
		this.InitHuffmanTbl();
		this.InitCategoryfloat();
		this.InitQuantTables(this.sf);
		this.Encode();
		if (!string.IsNullOrEmpty(this.path))
		{
			global::System.IO.File.WriteAllBytes(this.path, this.GetBytes());
		}
		this.isDone = true;
	}

	// Token: 0x06002BF4 RID: 11252 RVA: 0x000A583C File Offset: 0x000A3A3C
	private void Encode()
	{
		this.byteout = new global::JPGEncoder.ByteArray();
		this.bytenew = 0U;
		this.bytepos = 7;
		this.WriteWord(0xFFD8);
		this.WriteAPP0();
		this.WriteDQT();
		this.WriteSOF0(this.image.width, this.image.height);
		this.WriteDHT();
		this.writeSOS();
		float dc = 0f;
		float dc2 = 0f;
		float dc3 = 0f;
		this.bytenew = 0U;
		this.bytepos = 7;
		for (int i = 0; i < this.image.height; i += 8)
		{
			for (int j = 0; j < this.image.width; j += 8)
			{
				this.RGB2YUV(this.image, j, i);
				dc = this.ProcessDU(this.YDU, this.fdtbl_Y, dc, this.YDC_HT, this.YAC_HT);
				dc2 = this.ProcessDU(this.UDU, this.fdtbl_UV, dc2, this.UVDC_HT, this.UVAC_HT);
				dc3 = this.ProcessDU(this.VDU, this.fdtbl_UV, dc3, this.UVDC_HT, this.UVAC_HT);
				if (this.cores == 1)
				{
					global::System.Threading.Thread.Sleep(0);
				}
			}
		}
		if (this.bytepos >= 0)
		{
			this.WriteBits(new global::JPGEncoder.BitString
			{
				length = this.bytepos + 1,
				value = (1 << this.bytepos + 1) - 1
			});
		}
		this.WriteWord(0xFFD9);
		this.isDone = true;
	}

	// Token: 0x04001630 RID: 5680
	private int[] ZigZag = new int[]
	{
		0,
		1,
		5,
		6,
		0xE,
		0xF,
		0x1B,
		0x1C,
		2,
		4,
		7,
		0xD,
		0x10,
		0x1A,
		0x1D,
		0x2A,
		3,
		8,
		0xC,
		0x11,
		0x19,
		0x1E,
		0x29,
		0x2B,
		9,
		0xB,
		0x12,
		0x18,
		0x1F,
		0x28,
		0x2C,
		0x35,
		0xA,
		0x13,
		0x17,
		0x20,
		0x27,
		0x2D,
		0x34,
		0x36,
		0x14,
		0x16,
		0x21,
		0x26,
		0x2E,
		0x33,
		0x37,
		0x3C,
		0x15,
		0x22,
		0x25,
		0x2F,
		0x32,
		0x38,
		0x3B,
		0x3D,
		0x23,
		0x24,
		0x30,
		0x31,
		0x39,
		0x3A,
		0x3E,
		0x3F
	};

	// Token: 0x04001631 RID: 5681
	private int[] YTable = new int[0x40];

	// Token: 0x04001632 RID: 5682
	private int[] UVTable = new int[0x40];

	// Token: 0x04001633 RID: 5683
	private float[] fdtbl_Y = new float[0x40];

	// Token: 0x04001634 RID: 5684
	private float[] fdtbl_UV = new float[0x40];

	// Token: 0x04001635 RID: 5685
	private global::JPGEncoder.BitString[] YDC_HT;

	// Token: 0x04001636 RID: 5686
	private global::JPGEncoder.BitString[] UVDC_HT;

	// Token: 0x04001637 RID: 5687
	private global::JPGEncoder.BitString[] YAC_HT;

	// Token: 0x04001638 RID: 5688
	private global::JPGEncoder.BitString[] UVAC_HT;

	// Token: 0x04001639 RID: 5689
	private byte[] std_dc_luminance_nrcodes = new byte[]
	{
		0,
		0,
		1,
		5,
		1,
		1,
		1,
		1,
		1,
		1,
		0,
		0,
		0,
		0,
		0,
		0,
		0
	};

	// Token: 0x0400163A RID: 5690
	private byte[] std_dc_luminance_values = new byte[]
	{
		0,
		1,
		2,
		3,
		4,
		5,
		6,
		7,
		8,
		9,
		0xA,
		0xB
	};

	// Token: 0x0400163B RID: 5691
	private byte[] std_ac_luminance_nrcodes = new byte[]
	{
		0,
		0,
		2,
		1,
		3,
		3,
		2,
		4,
		3,
		5,
		5,
		4,
		4,
		0,
		0,
		1,
		0x7D
	};

	// Token: 0x0400163C RID: 5692
	private byte[] std_ac_luminance_values = new byte[]
	{
		1,
		2,
		3,
		0,
		4,
		0x11,
		5,
		0x12,
		0x21,
		0x31,
		0x41,
		6,
		0x13,
		0x51,
		0x61,
		7,
		0x22,
		0x71,
		0x14,
		0x32,
		0x81,
		0x91,
		0xA1,
		8,
		0x23,
		0x42,
		0xB1,
		0xC1,
		0x15,
		0x52,
		0xD1,
		0xF0,
		0x24,
		0x33,
		0x62,
		0x72,
		0x82,
		9,
		0xA,
		0x16,
		0x17,
		0x18,
		0x19,
		0x1A,
		0x25,
		0x26,
		0x27,
		0x28,
		0x29,
		0x2A,
		0x34,
		0x35,
		0x36,
		0x37,
		0x38,
		0x39,
		0x3A,
		0x43,
		0x44,
		0x45,
		0x46,
		0x47,
		0x48,
		0x49,
		0x4A,
		0x53,
		0x54,
		0x55,
		0x56,
		0x57,
		0x58,
		0x59,
		0x5A,
		0x63,
		0x64,
		0x65,
		0x66,
		0x67,
		0x68,
		0x69,
		0x6A,
		0x73,
		0x74,
		0x75,
		0x76,
		0x77,
		0x78,
		0x79,
		0x7A,
		0x83,
		0x84,
		0x85,
		0x86,
		0x87,
		0x88,
		0x89,
		0x8A,
		0x92,
		0x93,
		0x94,
		0x95,
		0x96,
		0x97,
		0x98,
		0x99,
		0x9A,
		0xA2,
		0xA3,
		0xA4,
		0xA5,
		0xA6,
		0xA7,
		0xA8,
		0xA9,
		0xAA,
		0xB2,
		0xB3,
		0xB4,
		0xB5,
		0xB6,
		0xB7,
		0xB8,
		0xB9,
		0xBA,
		0xC2,
		0xC3,
		0xC4,
		0xC5,
		0xC6,
		0xC7,
		0xC8,
		0xC9,
		0xCA,
		0xD2,
		0xD3,
		0xD4,
		0xD5,
		0xD6,
		0xD7,
		0xD8,
		0xD9,
		0xDA,
		0xE1,
		0xE2,
		0xE3,
		0xE4,
		0xE5,
		0xE6,
		0xE7,
		0xE8,
		0xE9,
		0xEA,
		0xF1,
		0xF2,
		0xF3,
		0xF4,
		0xF5,
		0xF6,
		0xF7,
		0xF8,
		0xF9,
		0xFA
	};

	// Token: 0x0400163D RID: 5693
	private byte[] std_dc_chrominance_nrcodes = new byte[]
	{
		0,
		0,
		3,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		0,
		0,
		0,
		0,
		0
	};

	// Token: 0x0400163E RID: 5694
	private byte[] std_dc_chrominance_values = new byte[]
	{
		0,
		1,
		2,
		3,
		4,
		5,
		6,
		7,
		8,
		9,
		0xA,
		0xB
	};

	// Token: 0x0400163F RID: 5695
	private byte[] std_ac_chrominance_nrcodes = new byte[]
	{
		0,
		0,
		2,
		1,
		2,
		4,
		4,
		3,
		4,
		7,
		5,
		4,
		4,
		0,
		1,
		2,
		0x77
	};

	// Token: 0x04001640 RID: 5696
	private byte[] std_ac_chrominance_values = new byte[]
	{
		0,
		1,
		2,
		3,
		0x11,
		4,
		5,
		0x21,
		0x31,
		6,
		0x12,
		0x41,
		0x51,
		7,
		0x61,
		0x71,
		0x13,
		0x22,
		0x32,
		0x81,
		8,
		0x14,
		0x42,
		0x91,
		0xA1,
		0xB1,
		0xC1,
		9,
		0x23,
		0x33,
		0x52,
		0xF0,
		0x15,
		0x62,
		0x72,
		0xD1,
		0xA,
		0x16,
		0x24,
		0x34,
		0xE1,
		0x25,
		0xF1,
		0x17,
		0x18,
		0x19,
		0x1A,
		0x26,
		0x27,
		0x28,
		0x29,
		0x2A,
		0x35,
		0x36,
		0x37,
		0x38,
		0x39,
		0x3A,
		0x43,
		0x44,
		0x45,
		0x46,
		0x47,
		0x48,
		0x49,
		0x4A,
		0x53,
		0x54,
		0x55,
		0x56,
		0x57,
		0x58,
		0x59,
		0x5A,
		0x63,
		0x64,
		0x65,
		0x66,
		0x67,
		0x68,
		0x69,
		0x6A,
		0x73,
		0x74,
		0x75,
		0x76,
		0x77,
		0x78,
		0x79,
		0x7A,
		0x82,
		0x83,
		0x84,
		0x85,
		0x86,
		0x87,
		0x88,
		0x89,
		0x8A,
		0x92,
		0x93,
		0x94,
		0x95,
		0x96,
		0x97,
		0x98,
		0x99,
		0x9A,
		0xA2,
		0xA3,
		0xA4,
		0xA5,
		0xA6,
		0xA7,
		0xA8,
		0xA9,
		0xAA,
		0xB2,
		0xB3,
		0xB4,
		0xB5,
		0xB6,
		0xB7,
		0xB8,
		0xB9,
		0xBA,
		0xC2,
		0xC3,
		0xC4,
		0xC5,
		0xC6,
		0xC7,
		0xC8,
		0xC9,
		0xCA,
		0xD2,
		0xD3,
		0xD4,
		0xD5,
		0xD6,
		0xD7,
		0xD8,
		0xD9,
		0xDA,
		0xE2,
		0xE3,
		0xE4,
		0xE5,
		0xE6,
		0xE7,
		0xE8,
		0xE9,
		0xEA,
		0xF2,
		0xF3,
		0xF4,
		0xF5,
		0xF6,
		0xF7,
		0xF8,
		0xF9,
		0xFA
	};

	// Token: 0x04001641 RID: 5697
	private global::JPGEncoder.BitString[] bitcode = new global::JPGEncoder.BitString[0xFFFF];

	// Token: 0x04001642 RID: 5698
	private int[] category = new int[0xFFFF];

	// Token: 0x04001643 RID: 5699
	private uint bytenew;

	// Token: 0x04001644 RID: 5700
	private int bytepos = 7;

	// Token: 0x04001645 RID: 5701
	private global::JPGEncoder.ByteArray byteout = new global::JPGEncoder.ByteArray();

	// Token: 0x04001646 RID: 5702
	private int[] DU = new int[0x40];

	// Token: 0x04001647 RID: 5703
	private float[] YDU = new float[0x40];

	// Token: 0x04001648 RID: 5704
	private float[] UDU = new float[0x40];

	// Token: 0x04001649 RID: 5705
	private float[] VDU = new float[0x40];

	// Token: 0x0400164A RID: 5706
	public bool isDone;

	// Token: 0x0400164B RID: 5707
	private global::JPGEncoder.BitmapData image;

	// Token: 0x0400164C RID: 5708
	private int sf;

	// Token: 0x0400164D RID: 5709
	private string path;

	// Token: 0x0400164E RID: 5710
	private int cores;

	// Token: 0x020004FA RID: 1274
	private class ByteArray
	{
		// Token: 0x06002BF5 RID: 11253 RVA: 0x000A59D4 File Offset: 0x000A3BD4
		public ByteArray()
		{
			this.stream = new global::System.IO.MemoryStream();
			this.writer = new global::System.IO.BinaryWriter(this.stream);
		}

		// Token: 0x06002BF6 RID: 11254 RVA: 0x000A5A04 File Offset: 0x000A3C04
		public void WriteByte(byte value)
		{
			this.writer.Write(value);
		}

		// Token: 0x06002BF7 RID: 11255 RVA: 0x000A5A14 File Offset: 0x000A3C14
		public byte[] GetAllBytes()
		{
			byte[] array = new byte[this.stream.Length];
			this.stream.Position = 0L;
			this.stream.Read(array, 0, array.Length);
			return array;
		}

		// Token: 0x0400164F RID: 5711
		private global::System.IO.MemoryStream stream;

		// Token: 0x04001650 RID: 5712
		private global::System.IO.BinaryWriter writer;
	}

	// Token: 0x020004FB RID: 1275
	private struct BitString
	{
		// Token: 0x04001651 RID: 5713
		public int length;

		// Token: 0x04001652 RID: 5714
		public int value;
	}

	// Token: 0x020004FC RID: 1276
	private class BitmapData
	{
		// Token: 0x06002BF8 RID: 11256 RVA: 0x000A5A54 File Offset: 0x000A3C54
		public BitmapData(global::UnityEngine.Texture2D texture)
		{
			this.height = texture.height;
			this.width = texture.width;
			this.pixels = texture.GetPixels32();
		}

		// Token: 0x06002BF9 RID: 11257 RVA: 0x000A5A8C File Offset: 0x000A3C8C
		public global::UnityEngine.Color32 GetPixelColor(int x, int y)
		{
			x = global::UnityEngine.Mathf.Clamp(x, 0, this.width - 1);
			y = global::UnityEngine.Mathf.Clamp(y, 0, this.height - 1);
			return this.pixels[y * this.width + x];
		}

		// Token: 0x04001653 RID: 5715
		public int height;

		// Token: 0x04001654 RID: 5716
		public int width;

		// Token: 0x04001655 RID: 5717
		private global::UnityEngine.Color32[] pixels;
	}
}
