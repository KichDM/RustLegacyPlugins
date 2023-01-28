using System;

namespace MoPhoGames.USpeak.Core
{
	// Token: 0x020000D1 RID: 209
	public class USpeakSettingsData
	{
		// Token: 0x06000413 RID: 1043 RVA: 0x0001372C File Offset: 0x0001192C
		public USpeakSettingsData()
		{
			this.bandMode = global::BandMode.Narrow;
			this.Codec = 0;
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x00013744 File Offset: 0x00011944
		public USpeakSettingsData(byte src)
		{
			if ((src & 1) == 1)
			{
				this.bandMode = global::BandMode.Narrow;
			}
			else if ((src & 2) == 2)
			{
				this.bandMode = global::BandMode.Wide;
			}
			else
			{
				this.bandMode = global::BandMode.UltraWide;
			}
			this.Codec = src >> 2;
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x00013794 File Offset: 0x00011994
		public byte ToByte()
		{
			byte b = 0;
			if (this.bandMode == global::BandMode.Narrow)
			{
				b |= 1;
			}
			else if (this.bandMode == global::BandMode.Wide)
			{
				b |= 2;
			}
			return b | (byte)(this.Codec << 2);
		}

		// Token: 0x040003DE RID: 990
		public global::BandMode bandMode;

		// Token: 0x040003DF RID: 991
		public int Codec;
	}
}
