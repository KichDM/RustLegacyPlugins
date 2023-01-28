using System;

namespace MoPhoGames.USpeak.Codec
{
	// Token: 0x020000C3 RID: 195
	public interface ICodec
	{
		// Token: 0x060003D2 RID: 978
		byte[] Encode(short[] data, global::BandMode bandMode);

		// Token: 0x060003D3 RID: 979
		short[] Decode(byte[] data, global::BandMode bandMode);

		// Token: 0x060003D4 RID: 980
		int GetSampleSize(int recordingFrequency);
	}
}
