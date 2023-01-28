using System;

namespace Facepunch.Load
{
	// Token: 0x020002DF RID: 735
	public abstract class Stream : global::System.IDisposable
	{
		// Token: 0x06001957 RID: 6487 RVA: 0x00062488 File Offset: 0x00060688
		protected Stream()
		{
		}

		// Token: 0x06001958 RID: 6488
		public abstract void Dispose();

		// Token: 0x020002E0 RID: 736
		protected static class Property
		{
			// Token: 0x04000E51 RID: 3665
			public const string Path = "filename";

			// Token: 0x04000E52 RID: 3666
			public const string TypeOfAssets = "type";

			// Token: 0x04000E53 RID: 3667
			public const string ContentType = "content";

			// Token: 0x04000E54 RID: 3668
			public const string ByteLength = "size";

			// Token: 0x04000E55 RID: 3669
			public const string RelativeOrAbsoluteURL = "url";
		}
	}
}
