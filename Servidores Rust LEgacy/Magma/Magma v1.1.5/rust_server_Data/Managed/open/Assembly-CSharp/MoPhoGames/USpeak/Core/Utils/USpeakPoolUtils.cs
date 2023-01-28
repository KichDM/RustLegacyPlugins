using System;
using System.Collections.Generic;

namespace MoPhoGames.USpeak.Core.Utils
{
	// Token: 0x020000D0 RID: 208
	public class USpeakPoolUtils
	{
		// Token: 0x0600040B RID: 1035 RVA: 0x000135C0 File Offset: 0x000117C0
		public USpeakPoolUtils()
		{
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x000135C8 File Offset: 0x000117C8
		// Note: this type is marked as 'beforefieldinit'.
		static USpeakPoolUtils()
		{
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x000135E8 File Offset: 0x000117E8
		public static float[] GetFloat(int length)
		{
			for (int i = 0; i < global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.FloatPool.Count; i++)
			{
				if (global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.FloatPool[i].Length == length)
				{
					float[] result = global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.FloatPool[i];
					global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.FloatPool.RemoveAt(i);
					return result;
				}
			}
			return new float[length];
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x00013644 File Offset: 0x00011844
		public static short[] GetShort(int length)
		{
			for (int i = 0; i < global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.ShortPool.Count; i++)
			{
				if (global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.ShortPool[i].Length == length)
				{
					short[] result = global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.ShortPool[i];
					global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.ShortPool.RemoveAt(i);
					return result;
				}
			}
			return new short[length];
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x000136A0 File Offset: 0x000118A0
		public static byte[] GetByte(int length)
		{
			for (int i = 0; i < global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.BytePool.Count; i++)
			{
				if (global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.BytePool[i].Length == length)
				{
					byte[] result = global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.BytePool[i];
					global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.BytePool.RemoveAt(i);
					return result;
				}
			}
			return new byte[length];
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x000136FC File Offset: 0x000118FC
		public static void Return(float[] d)
		{
			global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.FloatPool.Add(d);
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x0001370C File Offset: 0x0001190C
		public static void Return(byte[] d)
		{
			global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.BytePool.Add(d);
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x0001371C File Offset: 0x0001191C
		public static void Return(short[] d)
		{
			global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.ShortPool.Add(d);
		}

		// Token: 0x040003DB RID: 987
		private static global::System.Collections.Generic.List<byte[]> BytePool = new global::System.Collections.Generic.List<byte[]>();

		// Token: 0x040003DC RID: 988
		private static global::System.Collections.Generic.List<short[]> ShortPool = new global::System.Collections.Generic.List<short[]>();

		// Token: 0x040003DD RID: 989
		private static global::System.Collections.Generic.List<float[]> FloatPool = new global::System.Collections.Generic.List<float[]>();
	}
}
