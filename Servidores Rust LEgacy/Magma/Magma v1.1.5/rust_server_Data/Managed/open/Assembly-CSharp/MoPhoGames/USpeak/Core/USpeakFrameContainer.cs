using System;

namespace MoPhoGames.USpeak.Core
{
	// Token: 0x020000CF RID: 207
	public struct USpeakFrameContainer
	{
		// Token: 0x06000409 RID: 1033 RVA: 0x00013510 File Offset: 0x00011710
		public void LoadFrom(byte[] source)
		{
			int num = global::System.BitConverter.ToInt32(source, 0);
			this.Samples = global::System.BitConverter.ToUInt16(source, 4);
			this.encodedData = new byte[num];
			global::System.Array.Copy(source, 6, this.encodedData, 0, num);
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x00013550 File Offset: 0x00011750
		public byte[] ToByteArray()
		{
			byte[] array = new byte[6 + this.encodedData.Length];
			byte[] bytes = global::System.BitConverter.GetBytes(this.encodedData.Length);
			bytes.CopyTo(array, 0);
			byte[] bytes2 = global::System.BitConverter.GetBytes(this.Samples);
			global::System.Array.Copy(bytes2, 0, array, 4, 2);
			for (int i = 0; i < this.encodedData.Length; i++)
			{
				array[i + 6] = this.encodedData[i];
			}
			return array;
		}

		// Token: 0x040003D9 RID: 985
		public ushort Samples;

		// Token: 0x040003DA RID: 986
		public byte[] encodedData;
	}
}
